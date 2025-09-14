Imports System.IO
Imports System.Text.RegularExpressions

Public Class MainMonitor
    Private flW As FileSystemWatcher
    Dim lastNumber As Integer = 0
    Dim isFileCreated As Boolean
    Private catColl As New Dictionary(Of String, Category)
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles butDirectory.Click
        Dim fb As New FolderBrowserDialog
        fb.SelectedPath = txtPath.Text
        If fb.ShowDialog = DialogResult.OK Then
            My.Settings.FolderMonitor = fb.SelectedPath
            My.Settings.Save()
            txtPath.Text = fb.SelectedPath

        End If
    End Sub

    Private Function GetNextNumber() As String
        lastNumber += 1

        Dim st As String = lastNumber
        While st.Length < 5
            st = "0" & st
        End While
        Return st
    End Function

    Private Sub flW_Created(sender As Object, e As FileSystemEventArgs)
        Try
            If cboCategories.Items.Count = 0 Then Exit Sub
            Dim srcPath As String = e.FullPath
            Dim fext As String = IO.Path.GetExtension(srcPath).ToLower

            Dim validExtensions() As String = {}
            '''Check all categories
            For Each k As String In catColl.Keys
                Dim c As Category = catColl(k)
                If c.IsActive = False Then Continue For
                validExtensions = validExtensions.Union(c.AllowedTypes).ToArray
                If (validExtensions.Contains(fext) Or validExtensions.Count = 0) And IO.File.Exists(srcPath) Then
                    If chkVerbose.Checked Then msgQueue.Enqueue("File qualified for category " & c.Name & " for extension " & fext & " for file " & e.FullPath & ". Processing...")
                    Threading.Thread.Sleep(500)
                    c.SaveFile(srcPath)
                    isFileCreated = True
                End If
            Next
            If chkVerbose.Checked Then msgQueue.Enqueue("No category qualified for extension " & fext & " for file " & e.FullPath)

            'Dim srcPath As String = e.FullPath
            'Threading.Thread.Sleep(500)
            'If IO.File.Exists(srcPath) Then
            '    Dim fname As String = e.Name
            '    Dim tgPath As String = IO.Path.GetDirectoryName(srcPath) & "\" & GetNextNumber() & ".jpg"
            '    If chkOverwritefiles.Checked = False Then
            '        While IO.File.Exists(tgPath)
            '            tgPath = IO.Path.GetDirectoryName(srcPath) & "\" & GetNextNumber() & ".jpg"
            '        End While
            '    End If
            '    IO.File.Move(srcPath, tgPath)
            '    isFileCreated = True
            '    msgQueue.Enqueue("Renamed file " & e.FullPath)

            'End If
        Catch ex As Exception
            msgQueue.Enqueue(ex.Message & " " & e.FullPath)
        End Try
    End Sub
    Private Sub StopMonitoring()
        If flW IsNot Nothing Then
            RemoveHandler flW.Created, AddressOf flW_Created
            flW.EnableRaisingEvents = False
            flW = Nothing

            Timer1.Stop()
        End If
    End Sub
    Dim msgQueue As New Queue(Of String)
    Private Function StartMonitoring() As Boolean
        If IO.Path.Exists(txtPath.Text) Then
            txtLog.Clear()
            isFileCreated = False

            flW = New FileSystemWatcher()
            flW.Filters.Clear()
            flW.Path = txtPath.Text
            flW.Filters.Add("*.*")

            flW.EnableRaisingEvents = True
            lastNumber = CInt(ttNumber.Text)
            AddHandler flW.Created, AddressOf flW_Created
            Return True
        Else
            msgQueue.Enqueue("The directory doesn't exist ")
            Return False
        End If

    End Function
    Private Sub Log(msg As String)
        txtLog.AppendText(msg & vbCrLf)
        txtLog.SelectionStart = txtLog.TextLength
        txtLog.ScrollToCaret()
    End Sub
    Private Sub MainMonitor_Load(sender As Object, e As EventArgs) Handles Me.Load

        chkVerbose.Checked = My.Settings.Verbose
        txtPath.Text = My.Settings.FolderMonitor
        Timer1.Start()
    End Sub

    Private Function GetLastSeq(pth As String) As Integer
        Try
            Dim DirName As String = IO.Path.GetFileName(pth)
            Dim ourPattern = patt.Replace("#CATEGORY#", DirName)
            Dim fls() As String = IO.Directory.GetFiles(pth, "*.*")
            If chkVerbose.Checked Then
                Log("Looking for files in " & pth & " with pattern " & ourPattern)
            End If
            Dim maxSeq As Integer = 0
            Dim bufSeq As Integer = 0
            For Each fl As String In fls
                Dim fname As String = IO.Path.GetFileNameWithoutExtension(fl)
                Dim mtch As Match = Regex.Match(fname, ourPattern, RegexOptions.IgnoreCase)
                If mtch.Success Then
                    bufSeq = mtch.Groups(1).Value
                    maxSeq = Math.Max(bufSeq, maxSeq)
                End If
            Next
            'For Each fl As String In fls
            '    Dim fname As String = IO.Path.GetFileNameWithoutExtension(fl)
            '    Dim mtch As Match = Regex.Match(fname, ourPattern, RegexOptions.IgnoreCase)
            '    If mtch.Success Then
            '        bufSeq = mtch.Groups(1).Value
            '        maxSeq = Math.Max(bufSeq, maxSeq)
            '    End If
            'Next
            'fls = IO.Directory.GetFiles(pth, "*.jpeg")
            'For Each fl As String In fls
            '    Dim fname As String = IO.Path.GetFileNameWithoutExtension(fl)
            '    Dim mtch As Match = Regex.Match(fname, ourPattern, RegexOptions.IgnoreCase)
            '    If mtch.Success Then
            '        bufSeq = mtch.Groups(1).Value
            '        maxSeq = Math.Max(bufSeq, maxSeq)
            '    End If
            'Next
            'fls = IO.Directory.GetFiles(pth, "*.png")
            'For Each fl As String In fls
            '    Dim fname As String = IO.Path.GetFileNameWithoutExtension(fl)
            '    Dim mtch As Match = Regex.Match(fname, ourPattern, RegexOptions.IgnoreCase)
            '    If mtch.Success Then
            '        bufSeq = mtch.Groups(1).Value
            '        maxSeq = Math.Max(bufSeq, maxSeq)
            '    End If
            'Next
            'fls = IO.Directory.GetFiles(pth, "*.webp")
            'For Each fl As String In fls
            '    Dim fname As String = IO.Path.GetFileNameWithoutExtension(fl)
            '    Dim mtch As Match = Regex.Match(fname, ourPattern, RegexOptions.IgnoreCase)
            '    If mtch.Success Then
            '        bufSeq = mtch.Groups(1).Value
            '        maxSeq = Math.Max(bufSeq, maxSeq)
            '    End If
            'Next
            Return maxSeq
        Catch ex As Exception
            de(ex)
            Return 0
        End Try
    End Function
    Dim patt As String = "#CATEGORY#_([0-9]+)"

    Private Sub txtPath_TextChanged(sender As Object, e As EventArgs) Handles txtPath.TextChanged
        For Each cat As Category In catColl.Values
            RemoveHandler cat.CategoryMessage, AddressOf CatMessageARrived
            RemoveHandler cat.SeqNumberChanged, AddressOf CatSeqChanged
        Next
        catColl.Clear()
        curCat = Nothing
        cboCategories.Items.Clear()
        If IO.Directory.Exists(txtPath.Text) Then
            chkStart.Enabled = True
            Dim dirs() As String = IO.Directory.GetDirectories(txtPath.Text)

            For Each d As String In dirs
                If chkVerbose.Checked Then
                    Log("Found category folder: " & d)
                End If
                Dim lseq As Integer = GetLastSeq(d)
                Dim cat As New Category(d, lseq)
                cat.Name = IO.Path.GetFileName(d)
                catColl.Add(cat.Name, cat)
                AddHandler cat.CategoryMessage, AddressOf CatMessageARrived
                AddHandler cat.SeqNumberChanged, AddressOf CatSeqChanged
            Next

            Dim cl As Specialized.StringCollection = My.Settings.Categories

            If cl IsNot Nothing Then
                For Each c As String In cl
                    Dim elems() As String = c.Split(":")
                    If catColl.ContainsKey(elems(0)) Then
                        catColl(elems(0)).FileType = elems(1)
                        catColl(elems(0)).UseTimeStamp = CBool(elems(2))
                        catColl(elems(0)).OverWrite = CBool(elems(3))
                        catColl(elems(0)).IsActive = CBool(elems(4))
                    End If
                    txtLog.AppendText(catColl(elems(0)).Name & " is " & IIf(catColl(elems(0)).IsActive, " ACTIVE", " INACTIVE") & vbCrLf)
                Next
            End If
            cboCategories.Items.AddRange(catColl.Keys.ToArray)
            If cboCategories.Items.Count > 0 Then
                cboCategories.SelectedIndex = 0
            End If
        Else
            chkStart.Enabled = False
        End If

    End Sub

    Private Sub chkStart_CheckedChanged(sender As Object, e As EventArgs) Handles chkStart.CheckedChanged
        If chkStart.Checked Then

            If StartMonitoring() Then
                Log("Started monitoring")
                butDirectory.Enabled = False
            Else
                chkStart.Checked = False
            End If
        Else
            StopMonitoring()
            Log("Stopped monitoring")
            butDirectory.Enabled = True
        End If
    End Sub
    Private Sub butExit_Click(sender As Object, e As EventArgs) Handles butExit.Click
        StopMonitoring()
        Me.Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If isFileCreated Then
            If curCat IsNot Nothing Then
                ttNumber.Text = curCat.LastSeq

            End If
            isFileCreated = False
        End If
        While msgQueue.Count > 0
            Log(msgQueue.Dequeue)
        End While
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles butNEw.Click
        Try
startNaming:
            Dim catName As String = InputBox("Category name", "Provide category", "New folder")
            If String.IsNullOrEmpty(catName) Then Exit Sub
            If catColl.ContainsKey(catName) Then
                MsgBox("already exists", MsgBoxStyle.Information)
                GoTo startNaming
            End If
            MkDir(txtPath.Text & "\" & catName)
            Dim cat As New Category(txtPath.Text & "\" & catName, 0)
            cat.Name = catName
            cat.UseTimeStamp = chkUseTimestamp.Checked
            cat.OverWrite = chkOverwritefiles.Checked

            catColl.Add(cat.Name, cat)
            cboCategories.Items.Add(cat.Name)
            cboCategories.SelectedItem = cat.Name
            If chkVerbose.Checked Then
                Log("Created new category and folder " & cat.Name)
            End If
            AddHandler cat.CategoryMessage, AddressOf CatMessageARrived
            AddHandler cat.SeqNumberChanged, AddressOf CatSeqChanged
        Catch ex As Exception
            de(ex)
        End Try
    End Sub
    Private Sub CatMessageARrived(msg As String, isError As Boolean)
        msgQueue.Enqueue(IIf(isError, "[ERROR]", "") & msg)
    End Sub
    Private Sub CatSeqChanged(cat As String, seq As Integer)
        If curCat Is Nothing Then Exit Sub
        If curCat.Name = cat Then
            'Not required
        End If
    End Sub

    Private Sub de(ex As Exception)
        MsgBox(ex.Message, MsgBoxStyle.Critical)
    End Sub

    Private Sub chkUseTimestamp_CheckedChanged(sender As Object, e As EventArgs) Handles chkUseTimestamp.CheckedChanged
        If curCat Is Nothing Then Exit Sub
        If initializing Then Exit Sub
        curCat.UseTimeStamp = chkUseTimestamp.Checked
        ttNumber.Enabled = curCat.Rename And Not curCat.UseTimeStamp
        If chkVerbose.Checked Then
            Log("" & curCat.Name & " is set to " & IIf(curCat.UseTimeStamp, " USE TIMESTAMP", " NO TIMESTAMP"))

        End If
    End Sub

    Private Sub chkOverwritefiles_CheckedChanged(sender As Object, e As EventArgs) Handles chkOverwritefiles.CheckedChanged
        If curCat Is Nothing Then Exit Sub
        If initializing Then Exit Sub
        curCat.OverWrite = chkOverwritefiles.Checked
        If chkVerbose.Checked Then
            Log(curCat.Name & " is set to " & IIf(curCat.OverWrite, " OVERWRITE", " NO OVERWRITE"))
        End If
    End Sub

    Dim curCat As Category
    Dim initializing As Boolean = False
    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategories.SelectedIndexChanged
        If cboCategories.SelectedIndex = -1 Then
            curCat = Nothing

            cboFileCat.Enabled = False
            chkRename.Enabled = False
            chkOverwritefiles.Enabled = False
            chkUseTimestamp.Enabled = False
            ttNumber.Enabled = False
            chkIsActive.Enabled = False
            Exit Sub
        End If
        initializing = True
        cboFileCat.Enabled = True
        chkRename.Enabled = True
        chkOverwritefiles.Enabled = True
        chkUseTimestamp.Enabled = True
        chkIsActive.Enabled = True

        curCat = catColl(cboCategories.SelectedItem)
        cboFileCat.SelectedItem = curCat.FileType

        chkOverwritefiles.Checked = curCat.OverWrite
        chkRename.Checked = curCat.Rename
        chkUseTimestamp.Checked = curCat.UseTimeStamp
        chkIsActive.Checked = curCat.IsActive
        ttNumber.Text = curCat.LastSeq
        ttNumber.Enabled = curCat.Rename And Not curCat.UseTimeStamp
        initializing = False
    End Sub

    Private Sub MainMonitor_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim cl As New Specialized.StringCollection
        For Each cat As Category In catColl.Values

            cl.Add(cat.Name & ":" & cat.FileType & ":" & cat.UseTimeStamp & ":" & cat.OverWrite & ":" & cat.IsActive)
            RemoveHandler cat.CategoryMessage, AddressOf CatMessageARrived
            RemoveHandler cat.SeqNumberChanged, AddressOf CatSeqChanged
        Next
        My.Settings.Categories = cl
        My.Settings.Save()
        catColl.Clear()
    End Sub

    Private Sub chkVerbose_CheckedChanged(sender As Object, e As EventArgs) Handles chkVerbose.CheckedChanged

        My.Settings.Verbose = chkVerbose.Checked
        My.Settings.Save()
    End Sub

    Private Sub chkRename_CheckedChanged(sender As Object, e As EventArgs) Handles chkRename.CheckedChanged
        If curCat Is Nothing Then Exit Sub
        If initializing Then Exit Sub
        curCat.Rename = chkRename.Checked
        ttNumber.Enabled = curCat.Rename And Not curCat.UseTimeStamp
        If chkVerbose.Checked Then
            Log(curCat.Name & " is set to " & IIf(curCat.Rename, " RENAME", " NO RENAME"))
        End If
    End Sub

    Private Sub cboFileCat_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFileCat.SelectedIndexChanged
        If curCat Is Nothing Then Exit Sub
        If initializing Then Exit Sub
        curCat.FileType = cboFileCat.SelectedItem

    End Sub

    Private Sub ttNumber_TextChanged(sender As Object, e As EventArgs) Handles ttNumber.TextChanged
        If curCat Is Nothing Then Exit Sub
        If initializing Then Exit Sub
        Dim n As Integer = 0
        If Integer.TryParse(ttNumber.Text, n) Then
            curCat.LastSeq = n
        End If

    End Sub



    Private Sub chkIsActive_CheckedChanged(sender As Object, e As EventArgs) Handles chkIsActive.CheckedChanged
        If curCat Is Nothing Then Exit Sub
        If initializing Then Exit Sub
        curCat.IsActive = chkIsActive.Checked
        If chkIsActive.Checked Then
            For Each c As Category In catColl.Values
                If c.Name = curCat.Name Then
                    Continue For
                Else
                    If c.FileType = curCat.FileType Then
                        c.IsActive = False
                    End If
                End If
            Next
        End If

    End Sub
End Class
