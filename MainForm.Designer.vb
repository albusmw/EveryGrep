<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
  Inherits System.Windows.Forms.Form

  'Form overrides dispose to clean up the component list.
  <System.Diagnostics.DebuggerNonUserCode()> _
  Protected Overrides Sub Dispose(ByVal disposing As Boolean)
    Try
      If disposing AndAlso components IsNot Nothing Then
        components.Dispose()
      End If
    Finally
      MyBase.Dispose(disposing)
    End Try
  End Sub

  'Required by the Windows Form Designer
  Private components As System.ComponentModel.IContainer

  'NOTE: The following procedure is required by the Windows Form Designer
  'It can be modified using the Windows Form Designer.  
  'Do not modify it using the code editor.
  <System.Diagnostics.DebuggerStepThrough()> _
  Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.tbSearchIn = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbFileFilter = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.tbContains = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lbResults = New System.Windows.Forms.ListBox()
        Me.lbLinesFound = New System.Windows.Forms.ListBox()
        Me.ssMain = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslAction = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel2 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslFoundFiles = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel4 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslMatchingFiles = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStripStatusLabel3 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslTotalCount = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspbMain = New System.Windows.Forms.ToolStripProgressBar()
        Me.lbDisplayedFile = New System.Windows.Forms.Label()
        Me.scMain = New System.Windows.Forms.SplitContainer()
        Me.ttMain = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnOpenSearchFolder = New System.Windows.Forms.Button()
        Me.gbMain = New System.Windows.Forms.GroupBox()
        Me.cbRunParallel = New System.Windows.Forms.CheckBox()
        Me.cbSearchMethod = New System.Windows.Forms.ComboBox()
        Me.msMain = New System.Windows.Forms.MenuStrip()
        Me.tsmiFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiFile_DumpLog = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsmiFile_Exit = New System.Windows.Forms.ToolStripMenuItem()
        Me.tUpdateCounts = New System.Windows.Forms.Timer(Me.components)
        Me.ssMain.SuspendLayout()
        CType(Me.scMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scMain.Panel1.SuspendLayout()
        Me.scMain.Panel2.SuspendLayout()
        Me.scMain.SuspendLayout()
        Me.gbMain.SuspendLayout()
        Me.msMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Location = New System.Drawing.Point(949, 27)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(70, 99)
        Me.btnSearch.TabIndex = 0
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'tbSearchIn
        '
        Me.tbSearchIn.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbSearchIn.Location = New System.Drawing.Point(77, 19)
        Me.tbSearchIn.Name = "tbSearchIn"
        Me.tbSearchIn.Size = New System.Drawing.Size(818, 20)
        Me.tbSearchIn.TabIndex = 1
        Me.tbSearchIn.Text = "D:\ClearCase_snapshots\weis_m_K18"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(52, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Search in"
        '
        'tbFileFilter
        '
        Me.tbFileFilter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbFileFilter.Location = New System.Drawing.Point(77, 45)
        Me.tbFileFilter.Name = "tbFileFilter"
        Me.tbFileFilter.Size = New System.Drawing.Size(721, 20)
        Me.tbFileFilter.TabIndex = 3
        Me.tbFileFilter.Text = "*implementation*.cpp"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "File filter"
        '
        'tbContains
        '
        Me.tbContains.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbContains.Location = New System.Drawing.Point(77, 71)
        Me.tbContains.Name = "tbContains"
        Me.tbContains.Size = New System.Drawing.Size(721, 20)
        Me.tbContains.TabIndex = 5
        Me.tbContains.Text = "ipp"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Contains"
        '
        'lbResults
        '
        Me.lbResults.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbResults.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbResults.FormattingEnabled = True
        Me.lbResults.IntegralHeight = False
        Me.lbResults.ItemHeight = 14
        Me.lbResults.Location = New System.Drawing.Point(3, 3)
        Me.lbResults.Name = "lbResults"
        Me.lbResults.ScrollAlwaysVisible = True
        Me.lbResults.Size = New System.Drawing.Size(1001, 296)
        Me.lbResults.TabIndex = 7
        Me.ttMain.SetToolTip(Me.lbResults, "Click the file to display the found items in the lower text box")
        '
        'lbLinesFound
        '
        Me.lbLinesFound.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbLinesFound.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLinesFound.FormattingEnabled = True
        Me.lbLinesFound.IntegralHeight = False
        Me.lbLinesFound.ItemHeight = 14
        Me.lbLinesFound.Location = New System.Drawing.Point(0, 18)
        Me.lbLinesFound.Name = "lbLinesFound"
        Me.lbLinesFound.ScrollAlwaysVisible = True
        Me.lbLinesFound.Size = New System.Drawing.Size(1007, 248)
        Me.lbLinesFound.TabIndex = 8
        Me.ttMain.SetToolTip(Me.lbLinesFound, "Double-click the entry to open UltraEdit on the selected position")
        '
        'ssMain
        '
        Me.ssMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1, Me.tsslAction, Me.ToolStripStatusLabel2, Me.tsslFoundFiles, Me.ToolStripStatusLabel4, Me.tsslMatchingFiles, Me.ToolStripStatusLabel3, Me.tsslTotalCount, Me.tspbMain})
        Me.ssMain.Location = New System.Drawing.Point(0, 716)
        Me.ssMain.Name = "ssMain"
        Me.ssMain.Size = New System.Drawing.Size(1031, 22)
        Me.ssMain.TabIndex = 9
        Me.ssMain.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(45, 17)
        Me.ToolStripStatusLabel1.Text = "Action:"
        '
        'tsslAction
        '
        Me.tsslAction.Name = "tsslAction"
        Me.tsslAction.Size = New System.Drawing.Size(561, 17)
        Me.tsslAction.Spring = True
        Me.tsslAction.Text = "-- IDLE --"
        Me.tsslAction.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStripStatusLabel2
        '
        Me.ToolStripStatusLabel2.Name = "ToolStripStatusLabel2"
        Me.ToolStripStatusLabel2.Size = New System.Drawing.Size(68, 17)
        Me.ToolStripStatusLabel2.Text = "Found files:"
        '
        'tsslFoundFiles
        '
        Me.tsslFoundFiles.Name = "tsslFoundFiles"
        Me.tsslFoundFiles.Size = New System.Drawing.Size(13, 17)
        Me.tsslFoundFiles.Text = "0"
        '
        'ToolStripStatusLabel4
        '
        Me.ToolStripStatusLabel4.Name = "ToolStripStatusLabel4"
        Me.ToolStripStatusLabel4.Size = New System.Drawing.Size(85, 17)
        Me.ToolStripStatusLabel4.Text = "Matching files:"
        '
        'tsslMatchingFiles
        '
        Me.tsslMatchingFiles.Name = "tsslMatchingFiles"
        Me.tsslMatchingFiles.Size = New System.Drawing.Size(13, 17)
        Me.tsslMatchingFiles.Text = "0"
        '
        'ToolStripStatusLabel3
        '
        Me.ToolStripStatusLabel3.Name = "ToolStripStatusLabel3"
        Me.ToolStripStatusLabel3.Size = New System.Drawing.Size(116, 17)
        Me.ToolStripStatusLabel3.Text = "Total count of string:"
        '
        'tsslTotalCount
        '
        Me.tsslTotalCount.Name = "tsslTotalCount"
        Me.tsslTotalCount.Size = New System.Drawing.Size(13, 17)
        Me.tsslTotalCount.Text = "0"
        '
        'tspbMain
        '
        Me.tspbMain.Name = "tspbMain"
        Me.tspbMain.Size = New System.Drawing.Size(100, 16)
        Me.tspbMain.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        '
        'lbDisplayedFile
        '
        Me.lbDisplayedFile.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbDisplayedFile.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDisplayedFile.Location = New System.Drawing.Point(3, 0)
        Me.lbDisplayedFile.Name = "lbDisplayedFile"
        Me.lbDisplayedFile.Size = New System.Drawing.Size(1001, 15)
        Me.lbDisplayedFile.TabIndex = 10
        Me.lbDisplayedFile.Text = "---"
        Me.lbDisplayedFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'scMain
        '
        Me.scMain.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.scMain.Location = New System.Drawing.Point(12, 132)
        Me.scMain.Name = "scMain"
        Me.scMain.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'scMain.Panel1
        '
        Me.scMain.Panel1.Controls.Add(Me.lbResults)
        '
        'scMain.Panel2
        '
        Me.scMain.Panel2.Controls.Add(Me.lbDisplayedFile)
        Me.scMain.Panel2.Controls.Add(Me.lbLinesFound)
        Me.scMain.Size = New System.Drawing.Size(1007, 572)
        Me.scMain.SplitterDistance = 302
        Me.scMain.TabIndex = 11
        '
        'btnOpenSearchFolder
        '
        Me.btnOpenSearchFolder.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpenSearchFolder.Location = New System.Drawing.Point(901, 19)
        Me.btnOpenSearchFolder.Name = "btnOpenSearchFolder"
        Me.btnOpenSearchFolder.Size = New System.Drawing.Size(24, 20)
        Me.btnOpenSearchFolder.TabIndex = 3
        Me.btnOpenSearchFolder.Text = "..."
        Me.ttMain.SetToolTip(Me.btnOpenSearchFolder, "Open folder")
        Me.btnOpenSearchFolder.UseVisualStyleBackColor = True
        '
        'gbMain
        '
        Me.gbMain.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbMain.Controls.Add(Me.cbRunParallel)
        Me.gbMain.Controls.Add(Me.cbSearchMethod)
        Me.gbMain.Controls.Add(Me.btnOpenSearchFolder)
        Me.gbMain.Controls.Add(Me.tbSearchIn)
        Me.gbMain.Controls.Add(Me.Label1)
        Me.gbMain.Controls.Add(Me.Label3)
        Me.gbMain.Controls.Add(Me.tbFileFilter)
        Me.gbMain.Controls.Add(Me.tbContains)
        Me.gbMain.Controls.Add(Me.Label2)
        Me.gbMain.Location = New System.Drawing.Point(12, 27)
        Me.gbMain.Name = "gbMain"
        Me.gbMain.Size = New System.Drawing.Size(931, 99)
        Me.gbMain.TabIndex = 12
        Me.gbMain.TabStop = False
        Me.gbMain.Text = "Configuration"
        '
        'cbRunParallel
        '
        Me.cbRunParallel.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbRunParallel.AutoSize = True
        Me.cbRunParallel.Location = New System.Drawing.Point(804, 47)
        Me.cbRunParallel.Name = "cbRunParallel"
        Me.cbRunParallel.Size = New System.Drawing.Size(95, 17)
        Me.cbRunParallel.TabIndex = 8
        Me.cbRunParallel.Text = "Parallel search"
        Me.cbRunParallel.UseVisualStyleBackColor = True
        '
        'cbSearchMethod
        '
        Me.cbSearchMethod.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbSearchMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSearchMethod.FormattingEnabled = True
        Me.cbSearchMethod.Items.AddRange(New Object() {"Length change (total count)", "Windows find.exe (line count)"})
        Me.cbSearchMethod.Location = New System.Drawing.Point(804, 72)
        Me.cbSearchMethod.Name = "cbSearchMethod"
        Me.cbSearchMethod.Size = New System.Drawing.Size(121, 21)
        Me.cbSearchMethod.TabIndex = 7
        '
        'msMain
        '
        Me.msMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiFile})
        Me.msMain.Location = New System.Drawing.Point(0, 0)
        Me.msMain.Name = "msMain"
        Me.msMain.Size = New System.Drawing.Size(1031, 24)
        Me.msMain.TabIndex = 13
        '
        'tsmiFile
        '
        Me.tsmiFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiFile_DumpLog, Me.ToolStripMenuItem1, Me.tsmiFile_Exit})
        Me.tsmiFile.Name = "tsmiFile"
        Me.tsmiFile.Size = New System.Drawing.Size(37, 20)
        Me.tsmiFile.Text = "File"
        '
        'tsmiFile_DumpLog
        '
        Me.tsmiFile_DumpLog.Name = "tsmiFile_DumpLog"
        Me.tsmiFile_DumpLog.Size = New System.Drawing.Size(190, 22)
        Me.tsmiFile_DumpLog.Text = "Dump and display log"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New System.Drawing.Size(187, 6)
        '
        'tsmiFile_Exit
        '
        Me.tsmiFile_Exit.Name = "tsmiFile_Exit"
        Me.tsmiFile_Exit.Size = New System.Drawing.Size(190, 22)
        Me.tsmiFile_Exit.Text = "Exit"
        '
        'tUpdateCounts
        '
        Me.tUpdateCounts.Enabled = True
        '
        'MainForm
        '
        Me.AcceptButton = Me.btnSearch
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1031, 738)
        Me.Controls.Add(Me.gbMain)
        Me.Controls.Add(Me.scMain)
        Me.Controls.Add(Me.ssMain)
        Me.Controls.Add(Me.msMain)
        Me.Controls.Add(Me.btnSearch)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.msMain
        Me.Name = "MainForm"
        Me.Text = "EveryGrep"
        Me.ssMain.ResumeLayout(False)
        Me.ssMain.PerformLayout()
        Me.scMain.Panel1.ResumeLayout(False)
        Me.scMain.Panel2.ResumeLayout(False)
        CType(Me.scMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scMain.ResumeLayout(False)
        Me.gbMain.ResumeLayout(False)
        Me.gbMain.PerformLayout()
        Me.msMain.ResumeLayout(False)
        Me.msMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSearch As System.Windows.Forms.Button
  Friend WithEvents tbSearchIn As System.Windows.Forms.TextBox
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents tbFileFilter As System.Windows.Forms.TextBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents tbContains As System.Windows.Forms.TextBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents lbResults As System.Windows.Forms.ListBox
  Friend WithEvents lbLinesFound As System.Windows.Forms.ListBox
  Friend WithEvents ssMain As System.Windows.Forms.StatusStrip
  Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents tsslAction As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents ToolStripStatusLabel2 As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents tsslFoundFiles As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents lbDisplayedFile As System.Windows.Forms.Label
  Friend WithEvents scMain As System.Windows.Forms.SplitContainer
  Friend WithEvents ttMain As System.Windows.Forms.ToolTip
  Friend WithEvents ToolStripStatusLabel3 As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents tsslTotalCount As System.Windows.Forms.ToolStripStatusLabel
  Friend WithEvents tspbMain As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents gbMain As GroupBox
    Friend WithEvents btnOpenSearchFolder As Button
    Friend WithEvents msMain As MenuStrip
    Friend WithEvents tsmiFile As ToolStripMenuItem
    Friend WithEvents tsmiFile_Exit As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents tsmiFile_DumpLog As ToolStripMenuItem
    Friend WithEvents ToolStripStatusLabel4 As ToolStripStatusLabel
    Friend WithEvents tsslMatchingFiles As ToolStripStatusLabel
    Friend WithEvents cbSearchMethod As ComboBox
    Friend WithEvents cbRunParallel As CheckBox
    Friend WithEvents tUpdateCounts As Timer
End Class
