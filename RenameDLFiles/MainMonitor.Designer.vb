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
        txtPath.Location = New Point(62, 10)
        txtPath.Name = "txtPath"
        txtPath.ReadOnly = True
        txtPath.Size = New Size(457, 27)
        txtPath.TabIndex = 1
        ' 
        ' txtLog
        ' 
        txtLog.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtLog.Location = New Point(10, 190)
        txtLog.MaxLength = 10240000
        txtLog.Multiline = True
        txtLog.Name = "txtLog"
        txtLog.ReadOnly = True
        txtLog.ScrollBars = ScrollBars.Both
        txtLog.Size = New Size(577, 191)
        txtLog.TabIndex = 13
        ' 
        ' ttNumber
        ' 
        ttNumber.Location = New Point(494, 100)
        ttNumber.Name = "ttNumber"
        ttNumber.Size = New Size(91, 27)
        ttNumber.TabIndex = 11
        ttNumber.Text = "1"
        ttNumber.TextAlign = HorizontalAlignment.Right
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(367, 103)
        Label1.Name = "Label1"
        Label1.Size = New Size(121, 20)
        Label1.TabIndex = 10
        Label1.Text = "Starrt &numbering"
        ' 
        ' chkStart
        ' 
        chkStart.Appearance = Appearance.Button
        chkStart.AutoSize = True
        chkStart.Location = New Point(457, 51)
        chkStart.Name = "chkStart"
        chkStart.Size = New Size(128, 30)
        chkStart.TabIndex = 7
        chkStart.Text = "Start &monitoring"
        chkStart.UseVisualStyleBackColor = True
        ' 
        ' butExit
        ' 
        butExit.Location = New Point(442, 387)
        butExit.Name = "butExit"
        butExit.Size = New Size(141, 35)
        butExit.TabIndex = 14
        butExit.Text = "E&xit"
        butExit.UseVisualStyleBackColor = True
        ' 
        ' chkOverwritefiles
        ' 
        chkOverwritefiles.AutoSize = True
        chkOverwritefiles.Location = New Point(10, 51)
        chkOverwritefiles.Name = "chkOverwritefiles"
        chkOverwritefiles.Size = New Size(126, 24)
        chkOverwritefiles.TabIndex = 3
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
        cboCategories.Location = New Point(79, 100)
        cboCategories.Name = "cboCategories"
        cboCategories.Size = New Size(279, 28)
        cboCategories.TabIndex = 9
        ' 
        ' butNEw
        ' 
        butNEw.Location = New Point(457, 133)
        butNEw.Name = "butNEw"
        butNEw.Size = New Size(126, 42)
        butNEw.TabIndex = 12
        butNEw.Text = "&New category"
        butNEw.UseVisualStyleBackColor = True
        ' 
        ' chkUseTimestamp
        ' 
        chkUseTimestamp.AutoSize = True
        chkUseTimestamp.Location = New Point(142, 51)
        chkUseTimestamp.Name = "chkUseTimestamp"
        chkUseTimestamp.Size = New Size(130, 24)
        chkUseTimestamp.TabIndex = 4
        chkUseTimestamp.Text = "&Use timestamp"
        chkUseTimestamp.UseVisualStyleBackColor = True
        ' 
        ' chkVerbose
        ' 
        chkVerbose.AutoSize = True
        chkVerbose.Checked = True
        chkVerbose.CheckState = CheckState.Checked
        chkVerbose.Location = New Point(274, 51)
        chkVerbose.Name = "chkVerbose"
        chkVerbose.Size = New Size(84, 24)
        chkVerbose.TabIndex = 5
        chkVerbose.Text = "&Verbose"
        chkVerbose.UseVisualStyleBackColor = True
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(4, 100)
        Label2.Name = "Label2"
        Label2.Size = New Size(69, 20)
        Label2.TabIndex = 8
        Label2.Text = "Ca&tegory"
        ' 
        ' chkRename
        ' 
        chkRename.AutoSize = True
        chkRename.Checked = True
        chkRename.CheckState = CheckState.Checked
        chkRename.Location = New Point(364, 51)
        chkRename.Name = "chkRename"
        chkRename.Size = New Size(85, 24)
        chkRename.TabIndex = 6
        chkRename.Text = "&Rename"
        chkRename.UseVisualStyleBackColor = True
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(4, 13)
        Label3.Name = "Label3"
        Label3.Size = New Size(37, 20)
        Label3.TabIndex = 0
        Label3.Text = "&Path"
        ' 
        ' cboFileCat
        ' 
        cboFileCat.DropDownStyle = ComboBoxStyle.DropDownList
        cboFileCat.FormattingEnabled = True
        cboFileCat.Items.AddRange(New Object() {"Any file", "Documents", "Executables", "Image files", "PDF Files", "Spreadsheets", "Text files", "Zip files"})
        cboFileCat.Location = New Point(79, 141)
        cboFileCat.Name = "cboFileCat"
        cboFileCat.Size = New Size(279, 28)
        cboFileCat.Sorted = True
        cboFileCat.TabIndex = 9
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(4, 144)
        Label4.Name = "Label4"
        Label4.Size = New Size(40, 20)
        Label4.TabIndex = 8
        Label4.Text = "&Type"
        ' 
        ' MainMonitor
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(599, 428)
        Controls.Add(butNEw)
        Controls.Add(cboFileCat)
        Controls.Add(cboCategories)
        Controls.Add(chkRename)
        Controls.Add(chkVerbose)
        Controls.Add(chkUseTimestamp)
        Controls.Add(chkOverwritefiles)
        Controls.Add(chkStart)
        Controls.Add(Label3)
        Controls.Add(Label4)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(ttNumber)
        Controls.Add(txtLog)
        Controls.Add(txtPath)
        Controls.Add(butExit)
        Controls.Add(butDirectory)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "MainMonitor"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Monitor files"
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

End Class
