Public Class NewCat
    Dim _newCat As Category
    Dim parPath As String
    Private Sub NewCat_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Dim catCol As Dictionary(Of String, Category)
    Public Sub New(pth As String, catColl As Dictionary(Of String, Category))
        InitializeComponent()
        catCol = catColl
        parPath = pth
    End Sub
    Property NewCat As Category
        Get
            Return _NewCat
        End Get
        Set(value As Category)
            _newCat = value
        End Set
    End Property
    Private Sub txtCatName_TextChanged(sender As Object, e As EventArgs) Handles txtCatName.TextChanged
        If String.IsNullOrWhiteSpace(txtCatName.Text) Then

            lblError.Text = "Category name cannot be empty"
            lblError.Visible = True
            lblError.ForeColor = Color.Red
        Else
            lblError.Visible = False
        End If
        If catCol.ContainsKey(txtCatName.Text) Then

            lblError.Text = "Category name already exists"
            lblError.Visible = True
            lblError.ForeColor = Color.Red
        Else
            If IO.Directory.Exists(parPath & "\" & txtCatName.Text) Then
                lblError.Text = "The folder already exists, try different"
                lblError.Visible = True
                lblError.ForeColor = Color.Red
                Exit Sub
            End If
            lblError.Text = "Category name is valid"
            lblError.Visible = True
            lblError.ForeColor = Color.Green
        End If
    End Sub

    Private Sub butOK_Click(sender As Object, e As EventArgs) Handles butOK.Click
        If lblError.Text = "Category name is valid" Then
            Try
                newCat = New Category(parPath, 0)
                newCat.Name = txtCatName.Text
                newCat.DirPath = parPath & "\" & txtCatName.Text
                My.Computer.FileSystem.CreateDirectory(newCat.DirPath)
                newCat.OverWrite = chkOverwritefiles.Checked
                newCat.Rename = chkRename.Checked
                newCat.UseTimeStamp = chkUseTimestamp.Checked
                newCat.IsActive = chkIsActive.Checked
                catCol.Add(newCat.Name, newCat)
                DialogResult = DialogResult.OK
                Close()
            Catch ex As Exception
                lblError.Text = ex.Message
                lblError.Visible = True
                lblError.ForeColor = Color.Red
                Exit Sub
            End Try

        End If
    End Sub
End Class