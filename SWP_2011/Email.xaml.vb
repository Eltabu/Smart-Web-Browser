'Imports System.Net
Imports System.Net.Mail
Imports System.Net.Mail.Attachment
Imports System.Windows.Forms

Partial Public Class Email
    Dim O_F As System.Windows.Forms.FileDialog

    Private Sub Button_Close_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Close.Click
        Me.Close()
    End Sub

    Private Sub Button_Add_attachment_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Add_attachment.Click
        Dim Counter As Integer
        O_F = New OpenFileDialog()
        O_F.CheckFileExists = True
        O_F.Title = "Select file(s) to attach"
        O_F.ShowDialog()
        For Counter = 0 To UBound(O_F.FileNames)
            ListBox_attachment.Items.Add(O_F.FileNames(Counter))
        Next

    End Sub

    Private Sub Button_Remove_attachment_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Remove_attachment.Click
        If ListBox_attachment.SelectedIndex > -1 Then
            ListBox_attachment.Items.RemoveAt(ListBox_attachment.SelectedIndex)
        End If
    End Sub

    Private Sub Button_Cancel_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Cancel.Click
        Me.Close()

    End Sub

    Private Sub Button_Yahoo_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Yahoo.Click
        Me.TextBox_Sender_S_P.Text = "Plus.Smtp.Mail.Yahoo.com"
    End Sub

    Private Sub Button_Gmail_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Gmail.Click
        Me.TextBox_Sender_S_P.Text = "Smtp.gmail.com "
    End Sub

    Private Sub Button_GMX_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_GMX.Click
        Me.TextBox_Sender_S_P.Text = "Mail.gmx.com"
    End Sub

    Private Sub Button_Windows_live_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Windows_live.Click
        Me.TextBox_Sender_S_P.Text = "Smtp.live.com"
    End Sub

    Private Sub Button_Ok_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Ok.Click
        Try
            Dim Counter As Integer
            Dim MyMailMessage As New MailMessage()
            Dim Attachment As Attachment

            MyMailMessage.From = New MailAddress(TextBox_From.Text)
            MyMailMessage.To.Add(TextBox_TO.Text)
            MyMailMessage.Subject = TextBox_Sub.Text
            MyMailMessage.Body = TextBox_Body.Text

            For Counter = 0 To ListBox_attachment.Items.Count - 1
                Attachment = New Attachment(ListBox_attachment.Items(Counter))
                'Add it to the mail message
                MyMailMessage.Attachments.Add(Attachment)
            Next


            Dim SMPT As New SmtpClient(TextBox_Sender_S_P.Text)

            Select Case TextBox_Sender_S_P.Text

                Case RTrim(TextBox_Sender_S_P.Text) = "Plus.Smtp.Mail.Yahoo.com"
                    SMPT.Port = 465
                Case RTrim(TextBox_Sender_S_P.Text) = "Smtp.gmail.com"
                    SMPT.Port = 25
                Case RTrim(TextBox_Sender_S_P.Text) = "Mail.gmx.com"
                    SMPT.Port = 25
                Case RTrim(TextBox_Sender_S_P.Text) = "Smtp.live.com"
                    SMPT.Port = 25
            End Select



            SMPT.EnableSsl = True
            SMPT.Credentials = New System.Net.NetworkCredential(TextBox_Sender_U_N.Text, TextBox_Sender_PW.Password)
            SMPT.Send(MyMailMessage)
            MsgBox("The mail has been send!", MsgBoxStyle.Information, "Mail has been send!")
            'Lablel_Erorr_Massge.Content = "The mail has been send successful "
        Catch ex As Exception
            MsgBox(ex.Message.ToString, MsgBoxStyle.Exclamation)
        End Try

    End Sub

    Private Sub Email_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles Me.MouseDown
        Me.DragMove()
    End Sub

    Private Sub TextBox_From_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles TextBox_From.LostFocus
        TextBox_Sender_U_N.Text = TextBox_From.Text
    End Sub
End Class
