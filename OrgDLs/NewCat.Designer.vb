<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NewCat
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
        cboFileCat = New ComboBox()
        chkIsActive = New CheckBox()
        chkRename = New CheckBox()
        chkUseTimestamp = New CheckBox()
        chkOverwritefiles = New CheckBox()
        Label4 = New Label()
        Label2 = New Label()
        txtCatName = New TextBox()
        butOK = New Button()
        butCancel = New Button()
        lblError = New Label()
        SuspendLayout()
        ' 
        ' cboFileCat
        ' 
        cboFileCat.DropDownStyle = ComboBoxStyle.DropDownList
        cboFileCat.FormattingEnabled = True
        cboFileCat.Items.AddRange(New Object() {"Any file", "Documents", "Executables", "Image files", "PDF files", "Spreadsheets", "Text files", "Zip files"})
        cboFileCat.Location = New Point(85, 93)
        cboFileCat.Name = "cboFileCat"
        cboFileCat.Size = New Size(277, 28)
        cboFileCat.Sorted = True
        cboFileCat.TabIndex = 3
        ' 
        ' chkIsActive
        ' 
        chkIsActive.AutoSize = True
        chkIsActive.Location = New Point(139, 164)
        chkIsActive.Name = "chkIsActive"
        chkIsActive.Size = New Size(81, 24)
        chkIsActive.TabIndex = 7
        chkIsActive.Text = "&Is active"
        chkIsActive.UseVisualStyleBackColor = True
        ' 
        ' chkRename
        ' 
        chkRename.AutoSize = True
        chkRename.Location = New Point(17, 164)
        chkRename.Name = "chkRename"
        chkRename.Size = New Size(82, 24)
        chkRename.TabIndex = 6
        chkRename.Text = "&Rename"
        chkRename.UseVisualStyleBackColor = True
        ' 
        ' chkUseTimestamp
        ' 
        chkUseTimestamp.AutoSize = True
        chkUseTimestamp.Location = New Point(139, 133)
        chkUseTimestamp.Name = "chkUseTimestamp"
        chkUseTimestamp.Size = New Size(127, 24)
        chkUseTimestamp.TabIndex = 5
        chkUseTimestamp.Text = "&Use timestamp"
        chkUseTimestamp.UseVisualStyleBackColor = True
        ' 
        ' chkOverwritefiles
        ' 
        chkOverwritefiles.AutoSize = True
        chkOverwritefiles.Location = New Point(17, 133)
        chkOverwritefiles.Name = "chkOverwritefiles"
        chkOverwritefiles.Size = New Size(123, 24)
        chkOverwritefiles.TabIndex = 4
        chkOverwritefiles.Text = "&Overwrite files"
        chkOverwritefiles.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(15, 96)
        Label4.Name = "Label4"
        Label4.Size = New Size(40, 20)
        Label4.TabIndex = 2
        Label4.Text = "&Type"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(15, 16)
        Label2.Name = "Label2"
        Label2.Size = New Size(69, 20)
        Label2.TabIndex = 0
        Label2.Text = "Cate&gory"
        ' 
        ' txtCatName
        ' 
        txtCatName.Location = New Point(85, 12)
        txtCatName.Margin = New Padding(3, 4, 3, 4)
        txtCatName.Name = "txtCatName"
        txtCatName.Size = New Size(277, 27)
        txtCatName.TabIndex = 1
        ' 
        ' butOK
        ' 
        butOK.Location = New Point(70, 208)
        butOK.Name = "butOK"
        butOK.Size = New Size(141, 48)
        butOK.TabIndex = 8
        butOK.Text = "O&K"
        butOK.UseVisualStyleBackColor = True
        ' 
        ' butCancel
        ' 
        butCancel.Location = New Point(222, 208)
        butCancel.Name = "butCancel"
        butCancel.Size = New Size(141, 48)
        butCancel.TabIndex = 9
        butCancel.Text = "&Cancel"
        butCancel.UseVisualStyleBackColor = True
        ' 
        ' lblError
        ' 
        lblError.AutoSize = True
        lblError.Location = New Point(14, 63)
        lblError.Name = "lblError"
        lblError.Size = New Size(0, 20)
        lblError.TabIndex = 0
        ' 
        ' NewCat
        ' 
        AcceptButton = butOK
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = butCancel
        ClientSize = New Size(390, 267)
        Controls.Add(butCancel)
        Controls.Add(butOK)
        Controls.Add(txtCatName)
        Controls.Add(lblError)
        Controls.Add(Label2)
        Controls.Add(cboFileCat)
        Controls.Add(chkIsActive)
        Controls.Add(chkRename)
        Controls.Add(chkUseTimestamp)
        Controls.Add(chkOverwritefiles)
        Controls.Add(Label4)
        Font = New Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Margin = New Padding(3, 4, 3, 4)
        Name = "NewCat"
        StartPosition = FormStartPosition.CenterScreen
        Text = "NewCat"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents cboFileCat As ComboBox
    Friend WithEvents chkIsActive As CheckBox
    Friend WithEvents chkRename As CheckBox
    Friend WithEvents chkUseTimestamp As CheckBox
    Friend WithEvents chkOverwritefiles As CheckBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCatName As TextBox
    Friend WithEvents butOK As Button
    Friend WithEvents butCancel As Button
    Friend WithEvents lblError As Label
End Class
