Imports System.Data
Imports System.Data.SqlServerCe
Public Class Add_Library

    
    Private Sub Button_Ok_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Ok.Click
        Dim e1 As Boolean = False
        Dim e2 As Boolean = False
        Try

            con.Close()
            Dim cmd3 As New SqlCeCommand
            cmd3.Connection = con
            cmd3.CommandText = "Select imp_to_se_class,imp_to_wr_des  from dbo.Setting_Table "
            con.Open()
            Dim dr4 As SqlCeDataReader = cmd3.ExecuteReader
            dr4.Read()
            Dim i1 As Boolean = dr4(0)
            Dim i2 As Boolean = dr4(1)
            con.Close()

            'If imp_w_des = True Then
            '    If TextBox_Descreption.Text = Nothing Then
            '        MsgBox("")
            '    Else
            '        If imp_s_c = True Then
            '            If ComboBox_Class.SelectedItem.ToString = Nothing Then
            '                MsgBox("")
            '            Else
            '                'insert
            '            End If
            '        End If
            '    End If
            'Else

            '    If imp_s_c = True Then
            '        If ComboBox_Class.SelectedItem.ToString = Nothing Then
            '            MsgBox("")
            '        Else
            '            'insert
            '        End If
            '    Else
            '        'insert

            '    End If

            'End If





            If i1 = True And ComboBox_Class.SelectedItem = Nothing Then
                'Label_Erorr2.Content = "* It's Important to select class to complete the operation"
                e1 = True
            End If

            If i2 = True And TextBox_Descreption.Text = Nothing Then
                'Label_Erorr.Content = "* It's Important to writ description to complete the operation"
                e2 = True
            End If

            If e1 = True Or e2 = True Then

                MsgBox("It's Importan To Enter All Information", MsgBoxStyle.Exclamation)
                Exit Sub
            Else

                con.Close()
                Dim cmd As New SqlCeCommand
                cmd.Connection = con
                cmd.CommandText = "Select ID from dbo.Page  where Url= '" & urll & "'"
                con.Open()
                Dim dr As SqlCeDataReader = cmd.ExecuteReader
                dr.Read()
                Dim Id_Page As Integer = dr(0)
                con.Close()

                con.Close()
                Dim cmd22 As New SqlCeCommand
                cmd22.Connection = con
                cmd22.CommandText = "Select ID from dbo.Bookmark  where ID= '" & Id_Page & "'"
                con.Open()
                Dim dr22 As SqlCeDataReader = cmd22.ExecuteReader
                dr22.Read()
                If dr22.HasRows = True Then
                    MsgBox("This is Page is exist in Bookmark", MsgBoxStyle.Information)
                    con.Close()
                    Exit Sub
                End If
                con.Close()


                con.Close()
                Dim cmd2 As New SqlCeCommand
                cmd2.Connection = con
                cmd2.CommandText = "Select ID from dbo.category  where Cname= '" & ComboBox_Class.Text & "'"
                con.Open()
                Dim dr1 As SqlCeDataReader = cmd2.ExecuteReader
                dr1.Read()
                Dim Id_Class As Integer = dr1(0)
                con.Close()

                con.Close()
                Dim cmd1 As New SqlCeCommand
                cmd1.CommandText = "insert into dbo.Bookmark(ID,Description,Category) values(@ID,@Descriptionn,@Category)"
                cmd1.Connection = con
                con.Open()
                cmd1.Parameters.Add("@ID", SqlDbType.Int).Value = Id_Page
                cmd1.Parameters.Add("@Descriptionn", SqlDbType.NVarChar).Value = Trim(TextBox_Descreption.Text)
                cmd1.Parameters.Add("@Category", SqlDbType.Int).Value = Id_Class
                cmd1.ExecuteNonQuery()
                con.Close()
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Me.Close()
    End Sub

    Private Sub Add_Library_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded

        Try

            con.Close()
            Dim cmd2 As New SqlCeCommand
            cmd2.Connection = con
            cmd2.CommandText = "SELECT count(*) FROM category "
            con.Open()
            Dim dr1 As SqlCeDataReader = cmd2.ExecuteReader
            Dim x As Integer = 0
            dr1.Read()
            x = CInt(dr1(0))
            con.Close()
            con.Close()
            Dim cmd1 As New SqlCeCommand
            cmd1.Connection = con
            cmd1.CommandText = "select Cname  from dbo.category"
            con.Open()
            Dim dr As SqlCeDataReader = cmd1.ExecuteReader
            For i As Integer = 0 To x - 1
                dr.Read()
                ComboBox_Class.Items.Add(dr(0).ToString)
            Next
            con.Close()
            TextBlock_URL.Text = urll
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub

    Private Sub Add_Library_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Input.MouseButtonEventArgs) Handles Me.MouseDown
        Me.DragMove()
    End Sub
    Private Sub Button_Close_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Close.Click
        Me.Close()
    End Sub

    Private Sub Button_Cancel_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Cancel.Click
        Me.Close()
    End Sub

    Private Sub ComboBox_Class_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles ComboBox_Class.SelectionChanged
        Label_Erorr2.Content = ""
    End Sub

    Private Sub TextBox_Descreption_TextChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.TextChangedEventArgs) Handles TextBox_Descreption.TextChanged
        Label_Erorr.Content = ""
    End Sub
End Class
