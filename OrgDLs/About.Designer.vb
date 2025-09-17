<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class About
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
        PictureBox1 = New PictureBox()
        lblAppName = New Label()
        lblVersion = New Label()
        lblCopyright = New Label()
        lblDescription = New Label()
        butExit = New Button()
        lblURL = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.appimage
        PictureBox1.Location = New Point(20, 16)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(121, 121)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' lblAppName
        ' 
        lblAppName.AutoSize = True
        lblAppName.Font = New Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblAppName.Location = New Point(155, 26)
        lblAppName.Name = "lblAppName"
        lblAppName.Size = New Size(41, 30)
        lblAppName.TabIndex = 1
        lblAppName.Text = "{0}"
        ' 
        ' lblVersion
        ' 
        lblVersion.AutoSize = True
        lblVersion.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblVersion.Location = New Point(155, 56)
        lblVersion.Name = "lblVersion"
        lblVersion.Size = New Size(132, 21)
        lblVersion.TabIndex = 1
        lblVersion.Text = "Version: {0}.{1}.{2}"
        ' 
        ' lblCopyright
        ' 
        lblCopyright.AutoSize = True
        lblCopyright.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblCopyright.Location = New Point(155, 77)
        lblCopyright.Name = "lblCopyright"
        lblCopyright.Size = New Size(29, 21)
        lblCopyright.TabIndex = 1
        lblCopyright.Text = "{0}"
        ' 
        ' lblDescription
        ' 
        lblDescription.BorderStyle = BorderStyle.FixedSingle
        lblDescription.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDescription.Location = New Point(20, 140)
        lblDescription.Name = "lblDescription"
        lblDescription.Size = New Size(427, 114)
        lblDescription.TabIndex = 1
        lblDescription.Text = "{0}"
        ' 
        ' butExit
        ' 
        butExit.Location = New Point(306, 259)
        butExit.Name = "butExit"
        butExit.Size = New Size(141, 48)
        butExit.TabIndex = 9
        butExit.Text = "E&xit"
        butExit.UseVisualStyleBackColor = True
        ' 
        ' lblURL
        ' 
        lblURL.AutoSize = True
        lblURL.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblURL.Location = New Point(155, 107)
        lblURL.Name = "lblURL"
        lblURL.Size = New Size(29, 21)
        lblURL.TabIndex = 1
        lblURL.Text = "{0}"
        ' 
        ' About
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        CancelButton = butExit
        ClientSize = New Size(456, 319)
        Controls.Add(butExit)
        Controls.Add(lblDescription)
        Controls.Add(lblURL)
        Controls.Add(lblCopyright)
        Controls.Add(lblVersion)
        Controls.Add(lblAppName)
        Controls.Add(PictureBox1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "About"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "About"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents lblAppName As Label
    Friend WithEvents lblVersion As Label
    Friend WithEvents lblCopyright As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents butExit As Button
    Friend WithEvents lblURL As Label
End Class
