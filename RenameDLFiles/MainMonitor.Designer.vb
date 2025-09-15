<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class MainMonitor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainMonitor))
        butDirectory = New Button()
        txtPath = New TextBox()
        txtLog = New TextBox()
        ttNumber = New TextBox()
        Label1 = New Label()
        chkStart = New CheckBox()
        butExit = New Button()
        chkOverwritefiles = New CheckBox()
        Timer1 = New Timer(components)
        cboCategories = New ComboBox()
        butNEw = New Button()
        chkUseTimestamp = New CheckBox()
        chkVerbose = New CheckBox()
        Label2 = New Label()
        chkRename = New CheckBox()
        Label3 = New Label()
        cboFileCat = New ComboBox()
        Label4 = New Label()
        chkIsActive = New CheckBox()
        GroupBox1 = New GroupBox()
        Label5 = New Label()
        notIcon = New NotifyIcon(components)
        ctxMain = New ContextMenuStrip(components)
        tlstpShow = New ToolStripMenuItem()
        tlstpNewCat = New ToolStripMenuItem()
        tlstpStartStop = New ToolStripMenuItem()
        tlstpExit = New ToolStripMenuItem()
        ActiveCategoriesToolStripMenuItem = New ToolStripMenuItem()
        GroupBox1.SuspendLayout()
        ctxMain.SuspendLayout()
        SuspendLayout()
        ' 
        ' butDirectory
        ' 
        butDirectory.Location = New Point(525, 9)
        butDirectory.Name = "butDirectory"
        butDirectory.Size = New Size(58, 29)
        butDirectory.TabIndex = 2
        butDirectory.Text = "..."
        butDirectory.UseVisualStyleBackColor = True
        ' 
        ' txtPath
        ' 
        txtPath.Location = New Point(62, 11)
        txtPath.Name = "txtPath"
        txtPath.ReadOnly = True
        txtPath.Size = New Size(457, 27)
        txtPath.TabIndex = 1
        ' 
        ' txtLog
        ' 
        txtLog.Font = New Font("Arial", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtLog.Location = New Point(7, 305)
        txtLog.MaxLength = 10240000
        txtLog.Multiline = True
        txtLog.Name = "txtLog"
        txtLog.ReadOnly = True
        txtLog.ScrollBars = ScrollBars.Both
        txtLog.Size = New Size(581, 176)
        txtLog.TabIndex = 7
        ' 
        ' ttNumber
        ' 
        ttNumber.Enabled = False
        ttNumber.Location = New Point(427, 25)
        ttNumber.Name = "ttNumber"
        ttNumber.Size = New Size(63, 27)
        ttNumber.TabIndex = 3
        ttNumber.Text = "1"
        ttNumber.TextAlign = HorizontalAlignment.Right
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(365, 28)
        Label1.Name = "Label1"
        Label1.Size = New Size(57, 20)
        Label1.TabIndex = 2
        Label1.Text = "Start a&t"
        ' 
        ' chkStart
        ' 
        chkStart.Appearance = Appearance.Button
        chkStart.Location = New Point(445, 51)
        chkStart.Name = "chkStart"
        chkStart.Size = New Size(138, 45)
        chkStart.TabIndex = 4
        chkStart.Text = "Start &monitoring"
        chkStart.UseVisualStyleBackColor = True
        ' 
        ' butExit
        ' 
        butExit.Location = New Point(445, 488)
        butExit.Name = "butExit"
        butExit.Size = New Size(141, 48)
        butExit.TabIndex = 8
        butExit.Text = "E&xit"
        butExit.UseVisualStyleBackColor = True
        ' 
        ' chkOverwritefiles
        ' 
        chkOverwritefiles.AutoSize = True
        chkOverwritefiles.Enabled = False
        chkOverwritefiles.Location = New Point(11, 107)
        chkOverwritefiles.Name = "chkOverwritefiles"
        chkOverwritefiles.Size = New Size(123, 24)
        chkOverwritefiles.TabIndex = 7
        chkOverwritefiles.Text = "&Overwrite files"
        chkOverwritefiles.UseVisualStyleBackColor = True
        ' 
        ' Timer1
        ' 
        Timer1.Interval = 500
        ' 
        ' cboCategories
        ' 
        cboCategories.DropDownStyle = ComboBoxStyle.DropDownList
        cboCategories.FormattingEnabled = True
        cboCategories.Location = New Point(120, 25)
        cboCategories.Name = "cboCategories"
        cboCategories.Size = New Size(236, 28)
        cboCategories.TabIndex = 1
        ' 
        ' butNEw
        ' 
        butNEw.Location = New Point(365, 59)
        butNEw.Name = "butNEw"
        butNEw.Size = New Size(126, 43)
        butNEw.TabIndex = 6
        butNEw.Text = "&New category"
        butNEw.UseVisualStyleBackColor = True
        ' 
        ' chkUseTimestamp
        ' 
        chkUseTimestamp.AutoSize = True
        chkUseTimestamp.Enabled = False
        chkUseTimestamp.Location = New Point(134, 107)
        chkUseTimestamp.Name = "chkUseTimestamp"
        chkUseTimestamp.Size = New Size(127, 24)
        chkUseTimestamp.TabIndex = 8
        chkUseTimestamp.Text = "&Use timestamp"
        chkUseTimestamp.UseVisualStyleBackColor = True
        ' 
        ' chkVerbose
        ' 
        chkVerbose.AutoSize = True
        chkVerbose.Location = New Point(62, 63)
        chkVerbose.Name = "chkVerbose"
        chkVerbose.Size = New Size(81, 24)
        chkVerbose.TabIndex = 3
        chkVerbose.Text = "&Verbose"
        chkVerbose.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(2, 25)
        Label2.Name = "Label2"
        Label2.Size = New Size(112, 20)
        Label2.TabIndex = 0
        Label2.Text = "&Active category"
        ' 
        ' chkRename
        ' 
        chkRename.AutoSize = True
        chkRename.Enabled = False
        chkRename.Location = New Point(261, 107)
        chkRename.Name = "chkRename"
        chkRename.Size = New Size(82, 24)
        chkRename.TabIndex = 9
        chkRename.Text = "&Rename"
        chkRename.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(5, 13)
        Label3.Name = "Label3"
        Label3.Size = New Size(37, 20)
        Label3.TabIndex = 0
        Label3.Text = "&Path"
        ' 
        ' cboFileCat
        ' 
        cboFileCat.DropDownStyle = ComboBoxStyle.DropDownList
        cboFileCat.Enabled = False
        cboFileCat.FormattingEnabled = True
        cboFileCat.Items.AddRange(New Object() {"Any file", "Documents", "Executables", "Image files", "PDF files", "Spreadsheets", "Text files", "Zip files"})
        cboFileCat.Location = New Point(120, 67)
        cboFileCat.Name = "cboFileCat"
        cboFileCat.Size = New Size(236, 28)
        cboFileCat.Sorted = True
        cboFileCat.TabIndex = 5
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(9, 69)
        Label4.Name = "Label4"
        Label4.Size = New Size(40, 20)
        Label4.TabIndex = 4
        Label4.Text = "&Type"
        ' 
        ' chkIsActive
        ' 
        chkIsActive.AutoSize = True
        chkIsActive.Enabled = False
        chkIsActive.Location = New Point(346, 107)
        chkIsActive.Name = "chkIsActive"
        chkIsActive.Size = New Size(81, 24)
        chkIsActive.TabIndex = 10
        chkIsActive.Text = "&Is active"
        chkIsActive.UseVisualStyleBackColor = True
        ' 
        ' GroupBox1
        ' 
        GroupBox1.Controls.Add(butNEw)
        GroupBox1.Controls.Add(cboFileCat)
        GroupBox1.Controls.Add(cboCategories)
        GroupBox1.Controls.Add(chkIsActive)
        GroupBox1.Controls.Add(chkRename)
        GroupBox1.Controls.Add(chkUseTimestamp)
        GroupBox1.Controls.Add(chkOverwritefiles)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Controls.Add(Label1)
        GroupBox1.Controls.Add(ttNumber)
        GroupBox1.Location = New Point(5, 103)
        GroupBox1.Margin = New Padding(3, 4, 3, 4)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(3, 4, 3, 4)
        GroupBox1.Size = New Size(584, 164)
        GroupBox1.TabIndex = 5
        GroupBox1.TabStop = False
        ' 
        ' Label5
        ' 
        Label5.Location = New Point(5, 271)
        Label5.Name = "Label5"
        Label5.Size = New Size(61, 32)
        Label5.TabIndex = 6
        Label5.Text = "&Log"
        Label5.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' notIcon
        ' 
        notIcon.Text = "mainIcon"
        notIcon.Visible = True
        ' 
        ' ctxMain
        ' 
        ctxMain.Items.AddRange(New ToolStripItem() {tlstpShow, tlstpNewCat, tlstpStartStop, ActiveCategoriesToolStripMenuItem, tlstpExit})
        ctxMain.Name = "ctxMain"
        ctxMain.Size = New Size(181, 136)
        ' 
        ' tlstpShow
        ' 
        tlstpShow.Name = "tlstpShow"
        tlstpShow.Size = New Size(180, 22)
        tlstpShow.Text = "&Show"
        ' 
        ' tlstpNewCat
        ' 
        tlstpNewCat.Name = "tlstpNewCat"
        tlstpNewCat.Size = New Size(180, 22)
        tlstpNewCat.Text = "&New category"
        ' 
        ' tlstpStartStop
        ' 
        tlstpStartStop.Name = "tlstpStartStop"
        tlstpStartStop.Size = New Size(180, 22)
        tlstpStartStop.Text = "&Start monitoring"
        ' 
        ' tlstpExit
        ' 
        tlstpExit.Name = "tlstpExit"
        tlstpExit.Size = New Size(180, 22)
        tlstpExit.Text = "E&xit"
        ' 
        ' ActiveCategoriesToolStripMenuItem
        ' 
        ActiveCategoriesToolStripMenuItem.Name = "ActiveCategoriesToolStripMenuItem"
        ActiveCategoriesToolStripMenuItem.Size = New Size(180, 22)
        ActiveCategoriesToolStripMenuItem.Text = "Active categories"
        ' 
        ' MainMonitor
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(602, 541)
        Controls.Add(GroupBox1)
        Controls.Add(chkVerbose)
        Controls.Add(chkStart)
        Controls.Add(Label5)
        Controls.Add(Label3)
        Controls.Add(txtLog)
        Controls.Add(txtPath)
        Controls.Add(butExit)
        Controls.Add(butDirectory)
        Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "MainMonitor"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Monitor files"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ctxMain.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents butDirectory As Button
    Friend WithEvents txtPath As TextBox
    Friend WithEvents txtLog As TextBox
    Friend WithEvents ttNumber As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chkStart As CheckBox
    Friend WithEvents butExit As Button
    Friend WithEvents chkOverwritefiles As CheckBox
    Friend WithEvents Timer1 As Timer
    Friend WithEvents cboCategories As ComboBox
    Friend WithEvents butNEw As Button
    Friend WithEvents chkUseTimestamp As CheckBox
    Friend WithEvents chkVerbose As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents chkRename As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents cboFileCat As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents chkIsActive As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label5 As Label
    Friend WithEvents notIcon As NotifyIcon
    Friend WithEvents ctxMain As ContextMenuStrip
    Friend WithEvents tlstpShow As ToolStripMenuItem
    Friend WithEvents tlstpNewCat As ToolStripMenuItem
    Friend WithEvents tlstpStartStop As ToolStripMenuItem
    Friend WithEvents tlstpExit As ToolStripMenuItem
    Friend WithEvents ActiveCategoriesToolStripMenuItem As ToolStripMenuItem

End Class
