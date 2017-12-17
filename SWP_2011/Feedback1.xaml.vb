Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mail.Attachment
Imports System.Windows.Forms
Public Class Feedback1

    Private Sub Button_Close_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Close.Click
        Me.Close()
    End Sub

    Private Sub Window_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles MyBase.MouseDown
        Me.DragMove()
    End Sub

    Private Sub Button_Ok_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Ok.Click
        Try

            Dim MyMailMessage As New MailMessage()

            MyMailMessage.From = New MailAddress("moadeltabu@gmail.com")
            MyMailMessage.To.Add("swb_2012@yahoo.com")
            MyMailMessage.Subject = TextBox_Name.Text + "  Feedback "
            MyMailMessage.Body = TextBox_Body.Text

            Dim SMPT As New SmtpClient("Smtp.gmail.com")
            SMPT.Port = 25

            SMPT.EnableSsl = True
            SMPT.Credentials = New System.Net.NetworkCredential("moadeltabu@gmail.com", "0926070929")
            SMPT.Send(MyMailMessage)
            MsgBox("The feedback has been send!", MsgBoxStyle.Information, "Feedback has been send!")
        Catch ex As Exception
            'MsgBox(ex.Message.ToString)
        End Try
    End Sub

    Private Sub Button_Cancel_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Cancel.Click
        Me.Close()
    End Sub
End Class
