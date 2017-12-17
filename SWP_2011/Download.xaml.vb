Imports System.Net
Imports System.Data.SqlServerCe
Imports System.Data

Partial Public Class Download
    Dim S_F_D As New System.Windows.Forms.SaveFileDialog
    Public WithEvents dowin As WebClient
    Dim filet As String = ""
    Dim Id As Integer
    Dim Filename As String


    Public Sub Button_Ok_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Download.Click
        dowin = New WebClient
        Try
            If TextBox_url.Text = Nothing Then
                MsgBox("Enter The Path", MsgBoxStyle.Exclamation)
            Else
                S_F_D.Filter = "JPeg Image|*.jpg|.exe|*.exe|*.rar|.rar|*.zip|.zip|*.mp3|.mp3|*.mp4|.mp4|*.pdf|.pdf|*.doc|.doc|*.png|.png"
                S_F_D.ShowDialog()
                TextBox_loc.Text = S_F_D.FileName.ToString
                Filename = GetName(S_F_D.FileName.ToString)
                'filet = FileType(S_F_D.FilterIndex)
                'MsgBox(Filename.ToString)
                dowin.DownloadFileAsync(New Uri(TextBox_url.Text), TextBox_loc.Text)

            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub dowin_DownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs) Handles dowin.DownloadFileCompleted

        MsgBox("Download File Completed", MsgBoxStyle.Information)
        ProgressBar_download.Value = 0
        System.Diagnostics.Process.Start(TextBox_loc.Text)

        'MsgBox(PageUrl)
        Try
            If PageUrl = "" Then

                con.Close()
                Dim cmd As New SqlCeCommand
                cmd.CommandText = "insert into dbo.Downloads (D_Address,Filename,Date,Location,FileType) values(@D_Address,@Filename,@Date,@Location,@FileType)"
                cmd.Connection = con
                con.Open()
                cmd.Parameters.Add("@D_Address", SqlDbType.NVarChar).Value = Trim(TextBox_url.Text)
                cmd.Parameters.Add("@Filename", SqlDbType.NVarChar).Value = Filename
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = Now
                cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = Trim(TextBox_loc.Text)
                cmd.Parameters.Add("@FileType", SqlDbType.Int).Value = S_F_D.FilterIndex
                cmd.ExecuteNonQuery()
                con.Close()

            Else

                con.Close()
                Dim comand As New SqlCeCommand
                comand.Connection = con
                comand.CommandText = "Select ID from dbo.Page where Url = '" & PageUrl & "'"
                con.Open()
                Dim dr As SqlCeDataReader = comand.ExecuteReader
                If dr.HasRows = True Then
                    dr.Read()
                    Id = dr(0)

                Else
                    MsgBox("Erorr")
                End If
                con.Close()


                con.Close()
                Dim cmd As New SqlCeCommand
                cmd.CommandText = "insert into dbo.Downloads (D_Address,Filename,Date,Location,Page_ID,FileType) values(@D_Address,@Filename,@Date,@Location,@Page_ID,@FileType)"
                cmd.Connection = con
                con.Open()
                cmd.Parameters.Add("@D_Address", SqlDbType.NVarChar).Value = Trim(TextBox_url.Text)
                cmd.Parameters.Add("@Filename", SqlDbType.NVarChar).Value = Filename
                cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = Now
                cmd.Parameters.Add("@Location", SqlDbType.NVarChar).Value = Trim(TextBox_loc.Text)
                cmd.Parameters.Add("@Page_ID", SqlDbType.Int).Value = Id
                cmd.Parameters.Add("@FileType", SqlDbType.Int).Value = S_F_D.FilterIndex
                cmd.ExecuteNonQuery()
                con.Close()

            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

        Me.Close()

    End Sub

    Private Sub dowin_DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles dowin.DownloadProgressChanged
        ProgressBar_download.Value = e.ProgressPercentage
    End Sub

    Private Sub Download_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        TextBox_url.Text = D_Address
    End Sub

    Private Sub Window_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles MyBase.MouseDown
        Me.DragMove()
    End Sub

    Private Sub Button_Close_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Close.Click
        Me.Close()
    End Sub

    Private Sub Button_Cancel_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Cancel.Click
        Me.Close()
    End Sub

    'Public Function FileType(ByVal Index As Integer) As String
    '    Dim typp As String = ""
    '    If Index = 1 Then
    '        typp = "jpg"
    '    ElseIf Index = 2 Then
    '        typp = "exe"
    '    ElseIf Index = 3 Then
    '        typp = "rar"
    '    ElseIf Index = 4 Then
    '        typp = "zip"
    '    ElseIf Index = 5 Then
    '        typp = "mp3"
    '    ElseIf Index = 6 Then
    '        typp = "mp4"
    '    ElseIf Index = 7 Then
    '        typp = "pdf"
    '    ElseIf Index = 8 Then
    '        typp = "doc"
    '    End If
    '    Return typp
    'End Function

    Public Function GetName(ByVal textt As String) As String
        Dim name As String = ""
        Dim cuentin As Integer = 0
        Dim cuentin1 As Integer = 0
        Dim lan As Integer = 0
        cuentin = textt.LastIndexOf("\") + 1
        cuentin1 = textt.LastIndexOf(".")
        lan = cuentin1 - cuentin
        name = textt.Substring(cuentin, lan)
        Return name
    End Function



End Class
