Option Explicit On
Option Strict On

Public Class MainForm

    Public Enum eSearchMethod
        '''<summary>File content is read in, string is removed and length change is detected.</summary>
        LengthChange = 0
        '''<summary>Use the windows find.exe.</summary>
        WindowsFind
    End Enum

    Public MyPath As String = IO.Path.GetDirectoryName(Reflection.Assembly.GetEntryAssembly.Location)

    Dim LogContent As New List(Of String)

    Dim INIFile As String = "Config.INI"
    Dim UltraEditPath As String = String.Empty
    Dim Stopper As New Stopwatch

    Dim CountTotalFiles As Integer = -1
    Dim CountMatchingFiles As Integer = -1
    Dim CountProcessedFiles As Integer = -1
    Dim CountMatches As Integer = -1
    Dim CurrentAction As String = "---"

    Dim SearchMethod As eSearchMethod = eSearchMethod.LengthChange

    Dim WithEvents FolderDrop As Ato.DragDrop

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        Search()
    End Sub

    Private Sub Search()

        Dim AllFoundFiles As New List(Of String)
        Dim AllMatchingFiles As New Concurrent.ConcurrentBag(Of String)

        'Clear
        CountTotalFiles = 0
        CountMatchingFiles = 0
        CountProcessedFiles = 0
        CountMatches = 0
        LogContent.Clear()
        UpdateCounts()

        'Create the query and run
        CurrentAction = "Searching ..." : UpdateCounts()
        Stopper.Reset() : Stopper.Start()
        If String.IsNullOrEmpty(tbSearchIn.Text) = True Then
            Everything.Everything_SetSearchW(tbFileFilter.Text)
        Else
            Everything.Everything_SetSearchW("""" & tbSearchIn.Text & """ " & tbFileFilter.Text)
        End If
        Everything.Everything_QueryW(True)
        CountTotalFiles = Everything.Everything_GetNumResults
        Stopper.Stop()
        LogContent.Add("Search took " & Stopper.ElapsedMilliseconds.ToString.Trim & " ms")

        'Get all found files
        Stopper.Reset() : Stopper.Start()
        Dim bufsize As Integer = 260
        Dim buf As New System.Text.StringBuilder(bufsize)

        For Idx As Integer = 0 To Everything.Everything_GetNumResults() - 1
            Everything.Everything_GetResultFullPathNameW(Idx, buf, bufsize)
            AllFoundFiles.Add(buf.ToString)
        Next Idx
        LogContent.Add("Search query took " & Stopper.ElapsedMilliseconds.ToString.Trim & " ms")

        'Scan all found files for query string
        Stopper.Reset() : Stopper.Start()

        Dim TotalCount As Long = 0
        SearchMethod = CType(cbSearchMethod.SelectedIndex, eSearchMethod)
        Dim GrepFileName As String = System.IO.Path.Combine(MyPath, "GrepResult.txt")

        tspbMain.Maximum = AllFoundFiles.Count
        tspbMain.Value = 0

        Dim FileList As String() = AllFoundFiles.ToArray
        Dim FileErrorCount As Integer = 0
        If cbRunParallel.Checked Then
            Threading.Tasks.Parallel.For(0, FileList.Length, Sub(idx)
                                                                 Dim SingleFile As String = FileList(idx)
                                                                 Threading.Interlocked.Add(CountProcessedFiles, 1)
                                                                 If String.IsNullOrEmpty(tbContains.Text) = False Then
                                                                     CurrentAction = "Scanning <" & SingleFile & ">"
                                                                     Try
                                                                         Dim Count As Integer
                                                                         Select Case SearchMethod
                                                                             Case eSearchMethod.LengthChange
                                                                                 Dim Info As New System.IO.FileInfo(SingleFile) : LogContent.Add(Info.Length.ToString.Trim.PadLeft(8) & ":" & SingleFile)
                                                                                 Dim FileContent As String = System.IO.File.ReadAllText(SingleFile)
                                                                                 Dim FileLength As Long = FileContent.Length
                                                                                 FileContent = FileContent.Replace(tbContains.Text, String.Empty)
                                                                                 Count = CInt((FileLength - FileContent.Length) / tbContains.Text.Length)
                                                                             Case eSearchMethod.WindowsFind
                                                                                 Dim FindProcess As New ProcessStartInfo
                                                                                 FindProcess.FileName = Quote("C:\Windows\System32\find.exe")
                                                                                 FindProcess.Arguments = "/c """ & tbContains.Text & """ " & Quote(SingleFile) ' & ">" & Quote(GrepFileName)
                                                                                 FindProcess.WindowStyle = ProcessWindowStyle.Hidden
                                                                                 FindProcess.CreateNoWindow = True
                                                                                 FindProcess.UseShellExecute = False
                                                                                 FindProcess.RedirectStandardError = True
                                                                                 FindProcess.RedirectStandardOutput = True
                                                                                 Dim RunningProcess As Process = System.Diagnostics.Process.Start(FindProcess)
                                                                                 RunningProcess.WaitForExit()
                                                                                 Dim ErrorMsg As String = RunningProcess.StandardError.ReadToEnd
                                                                                 Dim GrepContent As String = RunningProcess.StandardOutput.ReadToEnd
                                                                                 If GrepContent.Length > 0 Then
                                                                                     If GrepContent.Length > 0 Then
                                                                                         GrepContent = GrepContent.Trim.Replace(Chr(10) & Chr(13), String.Empty)
                                                                                         GrepContent = GrepContent.Substring(GrepContent.LastIndexOf(":") + 1).Trim
                                                                                         Count = CInt(GrepContent)
                                                                                     End If
                                                                                 End If
                                                                         End Select
                                                                         'If matching entry was found, add to matching files list
                                                                         If Count > 0 Then
                                                                             AllMatchingFiles.Add("<Count: " & Format(Count, "0000").Trim & "> " & SingleFile)
                                                                             Threading.Interlocked.Add(CountMatchingFiles, 1)
                                                                             Threading.Interlocked.Add(CountMatches, Count)
                                                                             DE()
                                                                         End If
                                                                     Catch ex As Exception
                                                                         Threading.Interlocked.Add(FileErrorCount, 1)
                                                                     End Try
                                                                 End If
                                                             End Sub)
        Else
            For idx As Integer = 0 To FileList.Length - 1
                Dim SingleFile As String = FileList(idx)
                CountProcessedFiles += 1
                If String.IsNullOrEmpty(tbContains.Text) = False Then
                    CurrentAction = "Scanning <" & SingleFile & ">"
                    Try
                        Dim Count As Integer
                        Select Case SearchMethod
                            Case eSearchMethod.LengthChange
                                Dim Info As New System.IO.FileInfo(SingleFile) : LogContent.Add(Info.Length.ToString.Trim.PadLeft(8) & ":" & SingleFile)
                                Dim FileContent As String = System.IO.File.ReadAllText(SingleFile)
                                Dim FileLength As Long = FileContent.Length
                                FileContent = FileContent.Replace(tbContains.Text, String.Empty)
                                Count = CInt((FileLength - FileContent.Length) / tbContains.Text.Length)
                            Case eSearchMethod.WindowsFind
                                Dim FindProcess As New ProcessStartInfo
                                FindProcess.FileName = Quote("C:\Windows\System32\find.exe")
                                FindProcess.Arguments = "/c """ & tbContains.Text & """ " & Quote(SingleFile) ' & ">" & Quote(GrepFileName)
                                FindProcess.WindowStyle = ProcessWindowStyle.Hidden
                                FindProcess.CreateNoWindow = True
                                FindProcess.UseShellExecute = False
                                FindProcess.RedirectStandardError = True
                                FindProcess.RedirectStandardOutput = True
                                Dim RunningProcess As Process = System.Diagnostics.Process.Start(FindProcess)
                                RunningProcess.WaitForExit()
                                Dim ErrorMsg As String = RunningProcess.StandardError.ReadToEnd
                                Dim GrepContent As String = RunningProcess.StandardOutput.ReadToEnd
                                If GrepContent.Length > 0 Then
                                    If GrepContent.Length > 0 Then
                                        GrepContent = GrepContent.Trim.Replace(Chr(10) & Chr(13), String.Empty)
                                        GrepContent = GrepContent.Substring(GrepContent.LastIndexOf(":") + 1).Trim
                                        Count = CInt(GrepContent)
                                    End If
                                End If
                        End Select
                        'If matching entry was found, add to matching files list
                        If Count > 0 Then
                            AllMatchingFiles.Add("<Count: " & Format(Count, "0000").Trim & "> " & SingleFile)
                            CountMatchingFiles += 1
                            CountMatches += Count
                            DE()
                        End If

                    Catch ex As Exception
                        FileErrorCount += 1
                    End Try
                End If
                DE()
            Next idx
        End If

        LogContent.Add("Grep took " & Stopper.ElapsedMilliseconds.ToString.Trim & " ms")
        If FileErrorCount > 0 Then
            CurrentAction = FileErrorCount.ToString.Trim & " files with errors"
        Else
            CurrentAction = String.Empty
        End If

        'Add results
        lbResults.Items.Clear()
        Dim Results As New List(Of String)(AllMatchingFiles.ToArray) : Results.Sort()
        For Each FilteredResult As String In Results
            lbResults.Items.Add(FilteredResult)
        Next FilteredResult

        'Reset
        CountProcessedFiles = 0


    End Sub

    Private Function Quote(ByVal Text As String) As String
        Return Chr(34) & Text & Chr(34)
    End Function

    Private Sub lbResults_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lbResults.SelectedIndexChanged

        Dim LinesFound As New List(Of String)

        If lbResults.SelectedItem.ToString.StartsWith("<Count: ") = True Then
            Dim SelectedItem As String = CStr(lbResults.SelectedItem)
            lbDisplayedFile.Text = SelectedItem.Substring(SelectedItem.IndexOf(">") + 2)
            Dim LineIdx As Integer = 1
            For Each Line As String In System.IO.File.ReadAllLines(lbDisplayedFile.Text)
                If Line.Contains(tbContains.Text) = True Then
                    LinesFound.Add(Format(LineIdx, "000000000").Trim & "|" & Line)
                End If
                LineIdx += 1
            Next Line
        End If

        lbLinesFound.Items.Clear()
        For Each Result As String In LinesFound
            lbLinesFound.Items.Add(Result)
        Next Result

    End Sub

    Private Sub lbLinesFound_DoubleClick(sender As Object, e As System.EventArgs) Handles lbLinesFound.DoubleClick
        Dim SelectedLine As String = lbLinesFound.SelectedItem.ToString
        Dim LineToGo As Long = CLng(SelectedLine.Substring(0, 9))
        SelectedLine = SelectedLine.Substring(10)
        Dim ColToGo As Integer = SelectedLine.IndexOf(tbContains.Text) + 1
        If System.IO.File.Exists(UltraEditPath) = True Then
            Process.Start(UltraEditPath, """" & lbDisplayedFile.Text & "/" & LineToGo.ToString.Trim & "/" & ColToGo.ToString.Trim & """")
        Else
            Process.Start("notepad.exe", """" & lbDisplayedFile.Text & """")
        End If
    End Sub

    Private Sub MainForm_FormClosing(sender As Object, e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim INIFileContent As New List(Of String)
        INIFileContent.Add("[General]")
        INIFileContent.Add("SearchIn=" & tbSearchIn.Text)
        INIFileContent.Add("FileFilter=" & tbFileFilter.Text)
        INIFileContent.Add("Contains=" & tbContains.Text)
        If System.IO.File.Exists(INIFile) Then System.IO.File.Delete(INIFile)
        System.IO.File.WriteAllLines(INIFile, INIFileContent.ToArray)
    End Sub

    Private Sub MainForm_Load(sender As Object, e As System.EventArgs) Handles Me.Load

        'Get build data
        Dim BuildDate As String = String.Empty
        Dim AllResources As String() = System.Reflection.Assembly.GetExecutingAssembly.GetManifestResourceNames
        For Each Entry As String In AllResources
            If Entry.EndsWith(".BuildDate.txt") Then
                BuildDate = " (Build of " & (New System.IO.StreamReader(System.Reflection.Assembly.GetExecutingAssembly.GetManifestResourceStream(Entry)).ReadToEnd.Trim).Replace(",", ".") & ")"
                Exit For
            End If
        Next Entry
        Me.Text &= BuildDate

        UltraEditPath = CStr(Microsoft.Win32.Registry.GetValue("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths\Uedit32.exe", "Path", String.Empty))
        UltraEditPath = UltraEditPath & "\Uedit32.exe"
        tbSearchIn.Text = Ato.INIRead.GetINIFromFile(INIFile, "General", "SearchIn", "<Enter directory to search in>")
        tbFileFilter.Text = Ato.INIRead.GetINIFromFile(INIFile, "General", "FileFilter", "<Enter file pattern to match, e.g. *.txt>")
        tbContains.Text = Ato.INIRead.GetINIFromFile(INIFile, "General", "Contains", "<Enter text to be contained in the file>")
        FolderDrop = New Ato.DragDrop(tbSearchIn)

        cbSearchMethod.SelectedIndex = 0

    End Sub

    Private Sub tbContains_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles tbContains.KeyUp, tbFileFilter.KeyUp
        If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Return Then
            Search()
        End If
    End Sub

    Private Sub lbDisplayedFile_DoubleClick(sender As Object, e As System.EventArgs) Handles lbDisplayedFile.DoubleClick
        System.Diagnostics.Process.Start(lbDisplayedFile.Text)
    End Sub

    Private Sub FolderDrop_DropOccured(Files() As String) Handles FolderDrop.DropOccured
        tbSearchIn.Text = Files(0)
    End Sub

    Private Sub btnOpenSearchFolder_Click(sender As Object, e As EventArgs) Handles btnOpenSearchFolder.Click
        If System.IO.Directory.Exists(tbSearchIn.Text) Then Process.Start(tbSearchIn.Text)
    End Sub

    Private Sub tsmiFile_Exit_Click(sender As Object, e As EventArgs) Handles tsmiFile_Exit.Click
        End
    End Sub

    Private Sub tsmiFile_DumpLog_Click(sender As Object, e As EventArgs) Handles tsmiFile_DumpLog.Click
        Dim LogFile As String = System.IO.Path.Combine(MyPath, "SearchLog.log")
        System.IO.File.WriteAllLines(LogFile, LogContent.ToArray)
        Process.Start(LogFile)
    End Sub

    Private Sub DE()
        System.Windows.Forms.Application.DoEvents()
    End Sub

    Private Sub UpdateCounts()
        tUpdateCounts_Tick(Nothing, Nothing)
    End Sub

    Private Sub tUpdateCounts_Tick(sender As Object, e As EventArgs) Handles tUpdateCounts.Tick
        If CountTotalFiles > -1 Then tsslFoundFiles.Text = CountTotalFiles.ToString.Trim
        If CountMatchingFiles > -1 Then tsslMatchingFiles.Text = CountMatchingFiles.ToString.Trim
        If CountMatches > -1 Then tsslTotalCount.Text = CountMatches.ToString.Trim
        If CountProcessedFiles > -1 Then
            If CountProcessedFiles <= tspbMain.Maximum Then
                tspbMain.Value = CountProcessedFiles
            Else
                tspbMain.Value = tspbMain.Maximum
            End If
        End If
        If String.IsNullOrEmpty(CurrentAction) = False Then
            tsslAction.Text = CurrentAction
        Else
            tsslAction.Text = "-- IDLE --"
        End If
        DE()
    End Sub

End Class
