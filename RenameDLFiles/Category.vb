Imports System.Configuration
Imports System.Reflection.Metadata

Public Class Category
    Private _Name As String
    Private _LastSeq As Integer
    Private _UseTimeStamp As Boolean
    Private _DirPath As String
    Private _OverWrite As Boolean

    Private _Rename As Boolean = False
    Private _FileType As String = "Any file"
    Private _AllowedTypes As New List(Of String)
    Private _IsActive As Boolean = True
    Event SeqNumberChanged(cat As String, seq As Integer)
    Public INIT As Boolean
    Property IsActive As Boolean
        Get
            Return _IsActive
        End Get
        Set
            If IsActive <> Value And INIT = False Then
                RaiseEvent CategoryMessage("[" & Name & "]" & IIf(Value, "-ACTIVATED", "-DEACTIVATED"), False)
            End If
            _IsActive = Value

        End Set
    End Property

    Property FileType As String
        Get
            Return _FileType
        End Get
        Set
            _FileType = Value
            AllowedTypes.Clear()
            SetAllowedTypes()
        End Set
    End Property
    ReadOnly Property AllowedTypes() As List(Of String)
        Get
            Return _AllowedTypes
        End Get
    End Property
    Private Sub SetAllowedTypes()
        Select Case FileType

            Case "Any file"
                AllowedTypes.Clear()
            Case "Documents"
                AllowedTypes.AddRange({".docx", ".docm", ".doc", ".rtf"})
            Case "Spreadsheets"
                AllowedTypes.AddRange({".xlsx", ".xlsm", ".xls"})
            Case "PDF files"
                AllowedTypes.AddRange({".pdf"})
            Case "Image files"
                AllowedTypes.AddRange({".jpg", ".jpeg", ".bmp", ".png", ".gif", ".webp", ".tiff"})
            Case "Zip files"
                AllowedTypes.AddRange({".zip", ".tar", ".war", ".gzip", ".7zip", ".bzip"})
            Case "Executables"
                AllowedTypes.AddRange({".exe", ".bat", ".dll"})
        End Select
    End Sub
    Property Rename As Boolean
        Get
            Return _Rename
        End Get
        Set
            _Rename = Value
        End Set
    End Property

    Property OverWrite As Boolean
        Get
            Return _OverWrite
        End Get
        Set
            _OverWrite = Value
        End Set
    End Property

    Property DirPath As String
        Get
            Return _DirPath
        End Get
        Set
            _DirPath = Value
        End Set
    End Property

    Property UseTimeStamp As Boolean
        Get
            Return _UseTimeStamp
        End Get
        Set
            _UseTimeStamp = Value
        End Set
    End Property
    Public Sub New(dirP As String, lastSeq As Integer)
        Me.DirPath = dirP
        Me.LastSeq = lastSeq
    End Sub

    Property LastSeq As Integer
        Get
            Return _LastSeq
        End Get
        Set
            _LastSeq = Value
        End Set
    End Property

    Property Name As String
        Get
            Return _Name
        End Get
        Set
            _Name = Value
        End Set
    End Property
    Private Function GetNextNumber() As String
        LastSeq += 1

        Dim st As String = LastSeq
        While st.Length < 5
            st = "0" & st
        End While
        Return st
    End Function


    Event CategoryMessage(msg As String, isError As Boolean)
    Public Sub SaveFile(source As String)
        Try

            Dim newFilename As String = IIf(Rename = False, IO.Path.GetFileNameWithoutExtension(source), IIf(UseTimeStamp, Format(Date.Now, "yyyy-MM-dd HH_mm_ss"), Name & "_" & GetNextNumber()))

            Dim ext As String = IO.Path.GetExtension(source)
            newFilename = DirPath & "\" & newFilename & ext
            If IO.File.Exists(newFilename) Then
                RaiseEvent CategoryMessage("File exists alreasdy, " & IIf(OverWrite, "overwriting it", "skipping the file"), False)
                If OverWrite = False Then Exit Sub
            End If
            My.Computer.FileSystem.MoveFile(source, newFilename, OverWrite)
            RaiseEvent SeqNumberChanged(Name, LastSeq)
            RaiseEvent CategoryMessage("Moved file " & source & " to " & newFilename, False)
        Catch ex As Exception
            RaiseEvent CategoryMessage(ex.Message, True)
        End Try
    End Sub
End Class
