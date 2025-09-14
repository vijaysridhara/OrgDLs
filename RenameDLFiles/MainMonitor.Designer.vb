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
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' butDirectory
        ' 
        butDirectory.Location = New Point(459, 7)
        butDirectory.Margin = New Padding(3, 2, 3, 2)
        butDirectory.Name = "butDirectory"
        butDirectory.Size = New Size(51, 22)
        butDirectory.TabIndex = 2
        butDirectory.Text = "..."
        butDirectory.UseVisualStyleBackColor = True
        ' 
        ' txtPath
        ' 
        txtPath.Location = New Point(54, 8)
        txtPath.Margin = New Padding(3, 2, 3, 2)
        txtPath.Name = "txtPath"
        txtPath.ReadOnly = True
        txtPath.Size = New Size(400, 23)
        txtPath.TabIndex = 1
        ' 
        ' txtLog
        ' 
        txtLog.Font = New Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtLog.Location = New Point(6, 229)
        txtLog.Margin = New Padding(3, 2, 3, 2)
        txtLog.MaxLength = 10240000
        txtLog.Multiline = True
        txtLog.Name = "txtLog"
        txtLog.ReadOnly = True
        txtLog.ScrollBars = ScrollBars.Both
        txtLog.Size = New Size(509, 133)
        txtLog.TabIndex = 7
        ' 
        ' ttNumber
        ' 
        ttNumber.Enabled = False
        ttNumber.Location = New Point(374, 19)
        ttNumber.Margin = New Padding(3, 2, 3, 2)
        ttNumber.Name = "ttNumber"
        ttNumber.Size = New Size(56, 23)
        ttNumber.TabIndex = 3
        ttNumber.Text = "1"
        ttNumber.TextAlign = HorizontalAlignment.Right
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(319, 21)
        Label1.Name = "Label1"
        Label1.Size = New Size(44, 15)
        Label1.TabIndex = 2
        Label1.Text = "Start a&t"
        ' 
        ' chkStart
        ' 
        chkStart.Appearance = Appearance.Button
        chkStart.Location = New Point(406, 38)
        chkStart.Margin = New Padding(3, 2, 3, 2)
        chkStart.Name = "chkStart"
        chkStart.Size = New Size(104, 34)
        chkStart.TabIndex = 4
        chkStart.Text = "Start &monitoring"
        chkStart.UseVisualStyleBackColor = True
        ' 
        ' butExit
        ' 
        butExit.Location = New Point(389, 366)
        butExit.Margin = New Padding(3, 2, 3, 2)
        butExit.Name = "butExit"
        butExit.Size = New Size(123, 36)
        butExit.TabIndex = 8
        butExit.Text = "E&xit"
        butExit.UseVisualStyleBackColor = True
        ' 
        ' chkOverwritefiles
        ' 
        chkOverwritefiles.AutoSize = True
        chkOverwritefiles.Enabled = False
        chkOverwritefiles.Location = New Point(10, 80)
        chkOverwritefiles.Margin = New Padding(3, 2, 3, 2)
        chkOverwritefiles.Name = "chkOverwritefiles"
        chkOverwritefiles.Size = New Size(101, 19)
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
        cboCategories.Location = New Point(105, 19)
        cboCategories.Margin = New Padding(3, 2, 3, 2)
        cboCategories.Name = "cboCategories"
        cboCategories.Size = New Size(207, 23)
        cboCategories.TabIndex = 1
        ' 
        ' butNEw
        ' 
        butNEw.Location = New Point(319, 44)
        butNEw.Margin = New Padding(3, 2, 3, 2)
        butNEw.Name = "butNEw"
        butNEw.Size = New Size(110, 32)
        butNEw.TabIndex = 6
        butNEw.Text = "&New category"
        butNEw.UseVisualStyleBackColor = True
        ' 
        ' chkUseTimestamp
        ' 
        chkUseTimestamp.AutoSize = True
        chkUseTimestamp.Enabled = False
        chkUseTimestamp.Location = New Point(117, 80)
        chkUseTimestamp.Margin = New Padding(3, 2, 3, 2)
        chkUseTimestamp.Name = "chkUseTimestamp"
        chkUseTimestamp.Size = New Size(105, 19)
        chkUseTimestamp.TabIndex = 8
        chkUseTimestamp.Text = "&Use timestamp"
        chkUseTimestamp.UseVisualStyleBackColor = True
        ' 
        ' chkVerbose
        ' 
        chkVerbose.AutoSize = True
        chkVerbose.Location = New Point(54, 47)
        chkVerbose.Margin = New Padding(3, 2, 3, 2)
        chkVerbose.Name = "chkVerbose"
        chkVerbose.Size = New Size(67, 19)
        chkVerbose.TabIndex = 3
        chkVerbose.Text = "&Verbose"
        chkVerbose.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(2, 19)
        Label2.Name = "Label2"
        Label2.Size = New Size(89, 15)
        Label2.TabIndex = 0
        Label2.Text = "&Active category"
        ' 
        ' chkRename
        ' 
        chkRename.AutoSize = True
        chkRename.Enabled = False
        chkRename.Location = New Point(228, 80)
        chkRename.Margin = New Padding(3, 2, 3, 2)
        chkRename.Name = "chkRename"
        chkRename.Size = New Size(69, 19)
        chkRename.TabIndex = 9
        chkRename.Text = "&Rename"
        chkRename.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(4, 10)
        Label3.Name = "Label3"
        Label3.Size = New Size(31, 15)
        Label3.TabIndex = 0
        Label3.Text = "&Path"
        ' 
        ' cboFileCat
        ' 
        cboFileCat.DropDownStyle = ComboBoxStyle.DropDownList
        cboFileCat.Enabled = False
        cboFileCat.FormattingEnabled = True
        cboFileCat.Items.AddRange(New Object() {"Any file", "Documents", "Executables", "Image files", "PDF files", "Spreadsheets", "Text files", "Zip files"})
        cboFileCat.Location = New Point(105, 50)
        cboFileCat.Margin = New Padding(3, 2, 3, 2)
        cboFileCat.Name = "cboFileCat"
        cboFileCat.Size = New Size(207, 23)
        cboFileCat.Sorted = True
        cboFileCat.TabIndex = 5
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(8, 52)
        Label4.Name = "Label4"
        Label4.Size = New Size(32, 15)
        Label4.TabIndex = 4
        Label4.Text = "&Type"
        ' 
        ' chkIsActive
        ' 
        chkIsActive.AutoSize = True
        chkIsActive.Enabled = False
        chkIsActive.Location = New Point(303, 80)
        chkIsActive.Margin = New Padding(3, 2, 3, 2)
        chkIsActive.Name = "chkIsActive"
        chkIsActive.Size = New Size(68, 19)
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
        GroupBox1.Location = New Point(4, 77)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(511, 123)
        GroupBox1.TabIndex = 5
        GroupBox1.TabStop = False
        ' 
        ' Label5
        ' 
        Label5.Location = New Point(4, 203)
        Label5.Name = "Label5"
        Label5.Size = New Size(53, 24)
        Label5.TabIndex = 6
        Label5.Text = "&Log"
        Label5.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' MainMonitor
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(527, 406)
        Controls.Add(GroupBox1)
        Controls.Add(chkVerbose)
        Controls.Add(chkStart)
        Controls.Add(Label5)
        Controls.Add(Label3)
        Controls.Add(txtLog)
        Controls.Add(txtPath)
        Controls.Add(butExit)
        Controls.Add(butDirectory)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Margin = New Padding(3, 2, 3, 2)
        Name = "MainMonitor"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Monitor files"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
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

End Class
