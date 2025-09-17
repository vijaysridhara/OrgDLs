Public Class About
    Private Sub butExit_Click(sender As Object, e As EventArgs) Handles butExit.Click
        Me.Close()
    End Sub

    Private Sub About_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblAppName.Text = My.Application.Info.ProductName
        lblVersion.Text = "Version: " & My.Application.Info.Version.ToString
        lblCopyright.Text = My.Application.Info.Copyright
        lblDescription.Text = My.Application.Info.Description
        lblURL.Text = My.Application.Info.CompanyName
    End Sub
End Class