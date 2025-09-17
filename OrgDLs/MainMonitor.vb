Imports System.IO
Imports System.Text.RegularExpressions

Public Class MainMonitor
    Private flW As FileSystemWatcher
    Dim lastNumber As Integer = 0
    Dim isFileCreated As Boolean
    Private catColl As New Dictionary(Of String, Category)
    Dim TypesFileLoc As String = IO.Path.GetDirectoryName(Application.ExecutablePath) & "\filetypes.txt"
    Private FileTypes As New Dictionary(Of String, String())
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles butDirectory.Click
        Dim fb As New FolderBrowserDialog
        fb.SelectedPath = txtPath.Text
        If fb.ShowDialog = DialogResult.OK Then
            My.Settings.FolderMonitor = fb.SelectedPath
            My.Settings.Save()
            txtLog.Clear()
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
            If IO.Directory.Exists(e.FullPath) Then Exit Sub
            If cboCategories.Items.Count = 0 Then Exit Sub
            Dim srcPath As String = e.FullPath
            Dim fext As String = IO.Path.GetExtension(srcPath).ToLower
            If fext = ".tmp" Then Exit Sub 'Temporary files are crearted before renaming the file. 
            'The call may come twice, once for .tmp and once for actual file. We will ignore .tmp files
            ' and process only actual files
            CheckandProcessThisFile(e.FullPath, fext)

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
    Private Sub CheckandProcessThisFile(filepath As String, fext As String, Optional force As Boolean = False)
        Try
            Dim validExtensions() As String = {}
            '''Check all categories
            For Each k As String In catColl.Keys
                Dim c As Category = catColl(k)
                If c.IsActive = False And force = False Then Continue For
                validExtensions = validExtensions.Union(c.AllowedTypes).ToArray
                If (validExtensions.Contains(fext) Or validExtensions.Count = 0) And IO.File.Exists(filepath) And fext <> ".tmp" Then
                    If chkVerbose.Checked Then msgQueue.Enqueue("File qualified for category " & c.Name & " for extension " & fext & " for file " & filepath & ". Processing...")
                    Threading.Thread.Sleep(500)
                    c.SaveFile(filepath)
                    isFileCreated = True
                    Exit Sub
                End If
            Next
            If chkVerbose.Checked Then msgQueue.Enqueue("No category qualified for extension " & fext & " for file " & filepath)
        Catch ex As Exception
            msgQueue.Enqueue(ex.Message & "  " & filepath)
        End Try
    End Sub
    Private Sub StopMonitoring()
        If flW IsNot Nothing Then
            RemoveHandler flW.Created, AddressOf flW_Created
            RemoveHandler flW.Error, AddressOf flw_Error
            RemoveHandler flW.Renamed, AddressOf flW_Created
            flW.EnableRaisingEvents = False
            flW = Nothing


        End If
        isMonitoring = False
    End Sub
    Dim msgQueue As New Queue(Of String)

    Private Function StartMonitoring() As Boolean
        If IO.Path.Exists(txtPath.Text) Then

            isFileCreated = False

            flW = New FileSystemWatcher()
            flW.Filters.Clear()
            flW.Path = txtPath.Text
            flW.Filters.Add("*.*")

            flW.EnableRaisingEvents = True
            lastNumber = CInt(ttNumber.Text)
            AddHandler flW.Error, AddressOf flw_Error
            AddHandler flW.Created, AddressOf flW_Created
            AddHandler flW.Renamed, AddressOf flW_Created

            Return True
        Else
            msgQueue.Enqueue("The directory doesn't exist ")
            Return False
        End If

    End Function
    Private Sub flw_Error(sender As Object, e As ErrorEventArgs)
        msgQueue.Enqueue("File system watcher error: " & e.GetException.Message)

    End Sub
    Private Sub Log(msg As String)
        txtLog.AppendText("[" & Format(Date.Now, "yyyy-MM-dd HH:mm:ss") & "] " & msg & vbCrLf)
        txtLog.SelectionStart = txtLog.TextLength
        txtLog.ScrollToCaret()

    End Sub
    Dim isFirstLoad As Boolean = True
    Private Sub MainMonitor_Load(sender As Object, e As EventArgs) Handles Me.Load
        If LoadFileTypes() = False Then
            MsgBox("Error loading file types. Exiting", MsgBoxStyle.Critical)
            Application.Exit()
            Exit Sub
        End If

        cboFileCat.Items.AddRange(FileTypes.Keys.ToArray)
        notIcon.Icon = Me.Icon
        notIcon.ContextMenuStrip = ctxMain
        chkVerbose.Checked = My.Settings.Verbose
        txtPath.Text = My.Settings.FolderMonitor
        Timer1.Start()
        ShowActiveFolders()

    End Sub
    Private Function LoadFileTypes() As Boolean
        Try
            If IO.File.Exists(TypesFileLoc) = False Then
                Return False
            End If

            Dim lines() As String = IO.File.ReadAllLines(TypesFileLoc)
            For Each line As String In lines
                Dim parts() As String = line.Split(":"c)
                If parts.Length = 2 Then
                    Dim category As String = parts(0).Trim()
                    Dim extensions() As String = parts(1).Split(","c).Select(Function(s) s.Trim()).ToArray()
                    FileTypes(category) = extensions
                End If
            Next
            Return True
        Catch ex As Exception
            de(ex)
            Return False
        End Try
    End Function
    Private Sub ShowActiveFolders()
        Dim txt As String = ""
        For Each c As Category In catColl.Values
            If c.IsActive Then
                txt &= c.Name & " (" & c.FileType & ")" & vbCrLf
            End If
        Next
        If String.IsNullOrEmpty(txt) Then
            txt = "No active categories"
        End If
        If isMonitoring Then
            notIcon.BalloonTipTitle = "Active categories (RUNNING)"
        Else
            notIcon.BalloonTipTitle = "Set categories (STOPPED)"
        End If

        notIcon.BalloonTipText = txt
        notIcon.ShowBalloonTip(3000)
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
        If chkStart.Checked Then
            chkStart.Checked = False
        ElseIf isMonitoring Then
            'This is same as above case, but just to be sure
            StopMonitoring()
        End If
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
                Dim cat As New Category(d, lseq, FileTypes)
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
                        catColl(elems(0)).INIT = True
                        catColl(elems(0)).FileType = elems(1)
                        catColl(elems(0)).Rename = CBool(elems(2))
                        catColl(elems(0)).UseTimeStamp = CBool(elems(3))
                        catColl(elems(0)).OverWrite = CBool(elems(4))
                        catColl(elems(0)).IsActive = CBool(elems(5))
                        msgQueue.Enqueue("[" & catColl(elems(0)).Name & "]" & IIf(catColl(elems(0)).IsActive, "-ACTIVATED", "-DEACTIVATED"))
                        catColl(elems(0)).INIT = False
                    End If

                Next
            End If
            cboCategories.Items.AddRange(catColl.Keys.ToArray)
            If cboCategories.Items.Count > 0 Then
                cboCategories.SelectedIndex = 0
            End If
            chkStart.Checked = True
        Else
            chkStart.Enabled = False
        End If
        Dim files() As String = IO.Directory.GetFiles(txtPath.Text, "*.*")
        If files.Length > 0 Then
            If MsgBox("There are " & files.Length & " files in the selected folder. They will be processed based on active categories", MsgBoxStyle.Question Or MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

            'No force, get them into existing active categories
            For Each fl As String In files
                Dim ext As String = IO.Path.GetExtension(fl)
                CheckandProcessThisFile(fl, ext.ToLower)
            Next
            files = IO.Directory.GetFiles(txtPath.Text, "*.*")
            'Now force them to non active categories
            For Each fl As String In files
                Dim ext As String = IO.Path.GetExtension(fl)
                CheckandProcessThisFile(fl, ext.ToLower, True)
            Next
        End If

    End Sub
    Dim isMonitoring As Boolean = False
    Private Sub chkStart_CheckedChanged(sender As Object, e As EventArgs) Handles chkStart.CheckedChanged
        If chkStart.Checked Then

            If StartMonitoring() Then
                Log("Started monitoring")
                isMonitoring = True
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

        Close()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If isFirstLoad Then Me.Visible = False : isFirstLoad = False : tlstpShow.Text = "Show"
        If isFileCreated Then
            If curCat IsNot Nothing Then
                ttNumber.Text = curCat.LastSeq

            End If
            isFileCreated = False
        End If
        While msgQueue.Count > 0
            Log(msgQueue.Dequeue)
        End While
        If String.IsNullOrEmpty(bubbleMessage) = False And chkVerbose.Checked Then
            notIcon.BalloonTipTitle = ""
            notIcon.BalloonTipText = bubbleMessage
            bubbleMessage = ""
            notIcon.ShowBalloonTip(3000)

        End If
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
            Dim cat As New Category(txtPath.Text & "\" & catName, 0, FileTypes)
            cat.Name = catName
            cat.IsActive = True
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
    Dim bubbleMessage As String = ""
    Private Sub CatMessageARrived(msg As String, isError As Boolean)
        msgQueue.Enqueue(IIf(isError, "[ERROR]", "") & msg)
        If msg.StartsWith("Moved file") Then
            bubbleMessage = msg
        End If
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
        If e.CloseReason = CloseReason.UserClosing Then
            e.Cancel = True
            Me.Hide()
            tlstpShow.Text = "Show"
            Exit Sub
        End If
        If isMonitoring Then
            StopMonitoring()
        End If
        Dim cl As New Specialized.StringCollection
        For Each cat As Category In catColl.Values

            cl.Add(cat.Name & ":" & cat.FileType & ":" & cat.Rename & ":" & cat.UseTimeStamp & ":" & cat.OverWrite & ":" & cat.IsActive)
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

    Private Sub ctxMain_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ctxMain.Opening
        If Me.Visible = False Then
            tlstpShow.Text = "Show"
        Else
            tlstpShow.Text = "Hide"
        End If
        If String.IsNullOrEmpty(txtPath.Text) Then
            notIcon.Text = "No folder selected to monitor"
            tlstpStartStop.Enabled = False
            tlstpNewCat.Enabled = False
            If isMonitoring Then
                StopMonitoring()
            End If
            Exit Sub
        End If
        If IO.Directory.Exists(txtPath.Text) = False Then

            tlstpStartStop.Enabled = False
            tlstpNewCat.Enabled = False
            If isMonitoring Then
                StopMonitoring()
            End If
            Exit Sub
        End If
        tlstpStartStop.Enabled = True
        tlstpNewCat.Enabled = True
        If isMonitoring Then

            tlstpStartStop.Text = "Stop"

        Else
            tlstpStartStop.Text = "Start"

        End If
    End Sub

    Private Sub tlstpShow_Click(sender As Object, e As EventArgs) Handles tlstpShow.Click
        If Me.Visible Then
            Me.Hide()
            tlstpShow.Text = "Show"
            Exit Sub
        Else
            Me.Show()
            tlstpShow.Text = "Hide"
        End If


    End Sub

    Private Sub notIcon_DoubleClick(sender As Object, e As EventArgs) Handles notIcon.DoubleClick
        Me.Show()
        tlstpShow.Text = "Hide"

    End Sub

    Private Sub tlstpNewCat_Click(sender As Object, e As EventArgs) Handles tlstpNewCat.Click
        Dim nc As New NewCat(txtPath.Text, FileTypes, catColl)
        If nc.ShowDialog = DialogResult.OK Then
            If chkVerbose.Checked Then
                Log("Created new category and folder " & nc.NewCat.Name)
            End If
            cboCategories.Items.Add(nc.NewCat.Name)
            If nc.NewCat.IsActive Then
                For Each c As Category In catColl.Values
                    If c Is nc.NewCat Then Continue For
                    If c.FileType = nc.NewCat.FileType Then
                        If c.IsActive Then c.IsActive = False
                    End If
                Next
            End If
            cboCategories.SelectedItem = nc.NewCat.Name
        End If
    End Sub

    Private Sub tlstpStartStop_Click(sender As Object, e As EventArgs) Handles tlstpStartStop.Click
        If isMonitoring Then
            chkStart.Checked = False
        Else
            chkStart.Checked = True
        End If
    End Sub

    Private Sub notIcon_MouseMove(sender As Object, e As MouseEventArgs) Handles notIcon.MouseMove
        If String.IsNullOrEmpty(txtPath.Text) Then
            notIcon.Text = "No folder selected to monitor"
            Exit Sub
        End If
        If IO.Directory.Exists(txtPath.Text) = False Then
            notIcon.Text = "The folder to monitor doesn't exist"
            Exit Sub
        End If
        If isMonitoring Then
            notIcon.Text = "Monitoring " & txtPath.Text
        Else
            notIcon.Text = "Monitoring stopped"
        End If

    End Sub

    Private Sub MainMonitor_Closed(sender As Object, e As EventArgs) Handles Me.Closed

    End Sub

    Private Sub MainMonitor_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub tlstpExit_Click(sender As Object, e As EventArgs) Handles tlstpExit.Click
        Application.Exit()
    End Sub

    Private Sub ActiveCategoriesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ActiveCategoriesToolStripMenuItem.Click
        ShowActiveFolders()
    End Sub

    Private Sub butAbout_Click(sender As Object, e As EventArgs) Handles butAbout.Click
        Dim ab As New About
        ab.ShowDialog()
    End Sub
End Class
