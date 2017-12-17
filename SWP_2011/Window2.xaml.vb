Imports System.Data
Imports System.Data.SqlServerCe
Public Class Window2
    Dim S_E As Integer
    Dim doe As Integer
    Dim im_class As Boolean
    Dim im_des As Boolean
    Dim si As String = Nothing
    Dim FirestPassword As Boolean = True
    Dim passw As String

    Private Sub Button_Ok_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Ok.Click


        Try
            'Dim cmd1 As New SqlCeCommand
            'cmd1.Connection = con
            'cmd1.CommandText = "select *  from dbo.Setting_Table"
            'con.Open()
            'Dim dr As SqlCeDataReader = cmd1.ExecuteReader
            'dr.Read()
            'S_E = dr.Item(1)
            'doe = dr.Item(2)

            con.Close()
            Dim moad1 As New SqlCeCommand
            moad1.Connection = con
            moad1.CommandText = "UPDATE Setting_Table  SET home_page = '" & TextBox_HomePage.Text & "' ,  search_engine= '" & S_E & "' ,  doe= '" & doe & "' , delete_date='" & CInt(TextBoxD_A.Text) & "' , imp_to_se_class='" & im_class & "' , imp_to_wr_des='" & im_des & "' "
            con.Open()
            moad1.ExecuteNonQuery()
            con.Close()
            Me.Close()
        Catch ex As Exception
            MsgBox(ex.Message + "Button_Ok_Click")
        End Try

    End Sub

    Private Sub Button_Cancel_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Cancel.Click
        Me.Close()
    End Sub

    Private Sub ListBox_SE_SelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles ListBox_SE.SelectionChanged
        Dim S_I As ListBoxItem = ListBox_SE.SelectedItem
        If S_I.Name = "ListBoxItem_google" Then
            S_E = 1
        ElseIf S_I.Name = "ListBoxItem_yahoo" Then
            S_E = 2
        ElseIf S_I.Name = "ListBoxItem_bing" Then
            S_E = 3
        ElseIf S_I.Name = "ListBoxItem_youtube" Then
            S_E = 4

        End If
    End Sub

    Private Sub Window2_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        Try

            con.Close()
            Dim cmd1 As New SqlCeCommand
            cmd1.Connection = con
            cmd1.CommandText = "select *  from Setting_Table"
            con.Open()
            Dim dr As SqlCeDataReader = cmd1.ExecuteReader
            dr.Read()
            TextBox_HomePage.Text = dr(0)


            If dr(1) = 1 Then
                ListBox_SE.SelectedIndex = 0
            ElseIf dr(1) = 2 Then
                ListBox_SE.SelectedIndex = 1
            ElseIf dr(1) = 3 Then
                ListBox_SE.SelectedIndex = 2
            ElseIf dr(1) = 4 Then
                ListBox_SE.SelectedIndex = 3
            End If


            If dr(2) = False Then
                ChechBox_Doe.IsChecked = False
            Else
                ChechBox_Doe.IsChecked = True
            End If


            TextBoxD_A.Text = dr(3)

            im_class = dr(4)
            If dr(4) = True Then
                CheckBox_class.IsChecked = True
            Else
                CheckBox_class.IsChecked = False
            End If
            im_des = dr(5)
            If dr(5) = True Then
                CheckBox_descreption.IsChecked = True
            Else
                CheckBox_descreption.IsChecked = False
            End If
            con.Close()

            filllist()

            Fill_Bloked()


        Catch ex As Exception
            MsgBox(ex.Message + "  Window2_Loaded")
        End Try

    End Sub

    Private Sub ChechBox_Doe_Checked(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles ChechBox_Doe.Checked
        doe = 1
        TextBoxD_A.IsEnabled = False
    End Sub

    Private Sub ChechBox_Doe_Unchecked(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles ChechBox_Doe.Unchecked
        doe = 0
        TextBoxD_A.IsEnabled = True
    End Sub

    Private Sub CheckBox_class_Checked(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles CheckBox_class.Checked
        im_class = True
    End Sub

    Private Sub CheckBox_class_Unchecked(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles CheckBox_class.Unchecked
        im_class = False
    End Sub

    Private Sub CheckBox_descreption_Checked(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles CheckBox_descreption.Checked
        im_des = True
    End Sub

    Private Sub CheckBox_descreption_Unchecked(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles CheckBox_descreption.Unchecked
        im_des = False
    End Sub

   
    Private Sub Button_class_edit_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_class_edit.Click
        Try
            If Not ListBox_ClassList.SelectedItem.ToString = "" Then
                si = ListBox_ClassList.SelectedItem.ToString
                ListBox_ClassList.IsEnabled = False
                Button_cl_Ok.Visibility = Visibility.Visible = True
                TextBox_class_edit.Visibility = Visibility.Visible = True
                TextBox_class_edit.Text = si
            End If
        Catch ex As Exception
            MsgBox("Select Item First")
        End Try

    End Sub

    Private Sub Button_cl_Ok_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)

        Try
            con.Close()
            Dim moad1 As New SqlCeCommand
            moad1.Connection = con
            moad1.CommandText = "UPDATE category  SET Cname = '" & TextBox_class_edit.Text & "'  where Cname ='" & si & "' "
            con.Open()
            moad1.ExecuteNonQuery()
            con.Close()

            ListBox_ClassList.IsEnabled = True
            filllist()
            Button_cl_Ok.Visibility = Visibility.Visible = False
            TextBox_class_edit.Visibility = Visibility.Visible = False


        Catch ex As Exception
            MsgBox(ex.Message + "  Button_cl_Ok_Click")
        End Try

    End Sub

    Private Sub filllist()
        Try
            con.Close()
            ListBox_ClassList.Items.Clear()
            Dim cmd2 As New SqlCeCommand
            cmd2.Connection = con
            cmd2.CommandText = "Select count(Cname) from category "
            con.Open()
            Dim dr1 As SqlCeDataReader = cmd2.ExecuteReader
            Dim x As Integer
            dr1.Read()
            x = CInt(dr1(0))
            con.Close()


            If x <> 0 Then
                con.Close()
                Dim cmd As New SqlCeCommand
                cmd.Connection = con
                cmd.CommandText = "Select Cname from category"
                con.Open()
                Dim dr2 As SqlCeDataReader = cmd.ExecuteReader
                For i As Integer = 1 To x
                    dr2.Read()
                    ListBox_ClassList.Items.Add(dr2(0).ToString)
                Next
                con.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message + "  filllist")
        End Try

    End Sub

    Private Sub Fill_Bloked()
        Try
            con.Close()
            ListBox_BlokedPage.Items.Clear()
            Dim cmd2 As New SqlCeCommand
            cmd2.Connection = con
            cmd2.CommandText = "Select count(ID) from Blocked "
            con.Open()
            Dim dr1 As SqlCeDataReader = cmd2.ExecuteReader

            Dim x As Integer = 0
            dr1.Read()
            x = CInt(dr1(0))

            If x <> 0 Then
                Dim cmd As New SqlCeCommand
                cmd.Connection = con
                cmd.CommandText = "Select Page.Url from  Page,Blocked Where  Page.ID = Blocked.ID"
                con.Open()
                Dim dr2 As SqlCeDataReader = cmd.ExecuteReader
                For i As Integer = 1 To x
                    dr2.Read()
                    ListBox_BlokedPage.Items.Add(dr2(0).ToString)
                Next
                con.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message + "  Fill_Bloked")
        End Try

    End Sub

    Private Sub Button_class_De_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_class_De.Click
        Try
            If Not ListBox_ClassList.SelectedItem.ToString = "" Then

                If MsgBox("If you delete this category all  the  web sites in the category will be deleted", MsgBoxStyle.OkCancel, "MessageBox") = MsgBoxResult.Ok Then
                    Dim item As String = ListBox_ClassList.SelectedItem.ToString
                    con.Close()
                    Dim cmdd As New SqlCeCommand
                    cmdd.Connection = con
                    cmdd.CommandText = "select ID from category where Cname = '" & item & "' "
                    con.Open()
                    Dim drr As SqlCeDataReader = cmdd.ExecuteReader
                    drr.Read()
                    Dim Id_Class As Integer = drr(0)

                    Try
                        con.Close()
                        Dim moad1, moad2 As New SqlCeCommand
                        moad1.Connection = con
                        moad2.Connection = con

                        moad1.CommandText = "DELETE FROM Bookmark where Category = '" & Id_Class & "' "
                        moad2.CommandText = "DELETE FROM category where ID = '" & Id_Class & "' "

                        con.Open()
                        moad1.ExecuteNonQuery()
                        moad2.ExecuteNonQuery()
                        con.Close()
                        filllist()
                    Catch ex As Exception
                        MsgBox(ex.Message + "  Button_class_De_Click")
                    End Try

                End If

            End If
        Catch ex As Exception
            MsgBox("Select Item First")
        End Try
    End Sub

    Private Sub Button_addclass_apply_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_addclass_apply.Click
        Try
            If Not TextBox_addclass.Text = "" Then
                con.Close()
                Dim cmd As New SqlCeCommand
                cmd.CommandText = "insert into category(Cname) values(@Class_Name)"
                cmd.Connection = con
                con.Open()
                cmd.Parameters.Add("@Class_Name", SqlDbType.NVarChar).Value = TextBox_addclass.Text
                cmd.ExecuteNonQuery()
                con.Close()
            End If




        Catch ex As Exception
            MsgBox(ex.Message + "   Button_addclass_apply_Click")
        End Try

    End Sub

    Private Sub ListBox_ClassList_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles ListBox_ClassList.SelectionChanged
        Try
            Dim item As String = ListBox_ClassList.SelectedItem.ToString
            con.Close()
            Dim cmdd As New SqlCeCommand
            cmdd.Connection = con
            cmdd.CommandText = "select count(ID) from Bookmark where Category In (select ID from category where Cname = '" & item & "' ) "
            con.Open()
            Dim drr As SqlCeDataReader = cmdd.ExecuteReader
            drr.Read()
            Dim Numbwe As Integer = CInt(drr(0))
            TextBlock_class_inf.Text = "This class : content " & Numbwe.ToString & " web site"
        Catch ex As Exception
            MsgBox(ex.Message + "  ListBox_ClassList_SelectionChanged")
        End Try

    End Sub

    Private Sub ListBox_BlokedPage_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles ListBox_BlokedPage.SelectionChanged
        Try
            Dim item As String = ListBox_BlokedPage.SelectedItem.ToString
            con.Close()
            Dim cmdd As New SqlCeCommand
            cmdd.Connection = con
            cmdd.CommandText = "Select Blocked.Date from  Page , Blocked Where  Page.ID = Blocked.ID And Page.Url = '" & item & "' "
            con.Open()
            Dim drr As SqlCeDataReader = cmdd.ExecuteReader
            drr.Read()
            TextContentt_info_bloked.Content = "This web page blocked in : " & (drr(0).ToString)
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message + "  ListBox_BlokedPage_SelectionChanged")
        End Try
    End Sub

    Private Sub Button_Unbloked_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Unbloked.Click
        Try
            Dim item As String = ListBox_BlokedPage.SelectedItem.ToString
            con.Close()
            Dim moad1 As New SqlCeCommand
            moad1.Connection = con
            moad1.CommandText = "DELETE FROM Blocked where ID = (select ID from Page where Url = '" & item & "')  "
            con.Open()
            moad1.ExecuteNonQuery()
            con.Close()
            Fill_Bloked()
        Catch ex As Exception
            MsgBox(ex.Message + "Button_Unbloked_Click")
        End Try

    End Sub

    Private Sub TabControl_Setting_SelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles TabControl_Setting.SelectionChanged
        Try
            If TabItem_Security.IsSelected = True Then

                If FirestPassword = True Then

                    ListBox_BlokedPage.Visibility = Windows.Visibility.Hidden
                    Lable_BP.Visibility = Windows.Visibility.Hidden
                    Path_List.Visibility = Windows.Visibility.Hidden
                    Lable_Ifo.Visibility = Windows.Visibility.Hidden
                    Button_Unbloked.Visibility = Windows.Visibility.Hidden
                    Path_Info.Visibility = Windows.Visibility.Hidden
                    TextContentt_Copy6.Visibility = Windows.Visibility.Hidden
                    TextContentt_Copy7.Visibility = Windows.Visibility.Hidden
                    TextContentt_info_bloked.Visibility = Windows.Visibility.Hidden


                    PasswordBox_Password.Visibility = Windows.Visibility.Visible
                    Button_cl_Ok_Copy.Visibility = Windows.Visibility.Visible
                    TextContentt_Copy5.Visibility = Windows.Visibility.Visible
                    Expander_Opsation.Visibility = Windows.Visibility.Visible


                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message + "   TabControl_Setting_SelectionChanged")
        End Try

    End Sub

    Private Sub Button_cl_Ok_Copy_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_cl_Ok_Copy.Click

        Try

            con.Close()
            Dim cmd1 As New SqlCeCommand
            cmd1.Connection = con
            cmd1.CommandText = "select Setting_Password  from Setting_Table"
            con.Open()
            Dim dr As SqlCeDataReader = cmd1.ExecuteReader
            dr.Read()
            passw = dr(0)
            con.Close()
            If PasswordBox_Password.Password = passw Then

                FirestPassword = False

                ListBox_BlokedPage.Visibility = Windows.Visibility.Visible
                Lable_BP.Visibility = Windows.Visibility.Visible
                Path_List.Visibility = Windows.Visibility.Visible
                Lable_Ifo.Visibility = Windows.Visibility.Visible
                Button_Unbloked.Visibility = Windows.Visibility.Visible
                Path_Info.Visibility = Windows.Visibility.Visible
                TextContentt_Copy6.Visibility = Windows.Visibility.Visible
                TextContentt_Copy7.Visibility = Windows.Visibility.Visible
                TextContentt_info_bloked.Visibility = Windows.Visibility.Visible


                PasswordBox_Password.Visibility = Windows.Visibility.Hidden
                Button_cl_Ok_Copy.Visibility = Windows.Visibility.Hidden
                TextContentt_Copy5.Visibility = Windows.Visibility.Hidden
                Expander_Opsation.Visibility = Windows.Visibility.Hidden

            Else
                MsgBox("The Password is wrong", MsgBoxStyle.Exclamation)

            End If


        Catch ex As Exception
            MsgBox(ex.Message = "  Button_cl_Ok_Copy_Click")
        End Try

    End Sub

    Private Sub Button_Apply_Password_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Apply_Password.Click

        Try
            con.Close()
            Dim cmd1 As New SqlCeCommand
            cmd1.Connection = con
            cmd1.CommandText = "select Setting_Password  from Setting_Table"
            con.Open()
            Dim dr As SqlCeDataReader = cmd1.ExecuteReader
            dr.Read()
            passw = dr(0)
            'MsgBox(passw)
            'MsgBox(TextBox_Old_Password.Text)
            If TextBox_Old_Password.Text = passw Then
                con.Close()
                Dim moad1 As New SqlCeCommand
                moad1.Connection = con
                moad1.CommandText = "UPDATE Setting_Table  SET Setting_Password = '" & TextBox_New_Password.Text & "'"
                con.Open()
                moad1.ExecuteNonQuery()
                con.Close()
                TextBox_New_Password.Text = ""
                TextBox_Old_Password.Text = ""
            Else
                MsgBox("Enter The valid Password", MsgBoxStyle.Exclamation)

            End If
        Catch ex As Exception
            MsgBox(ex.Message + "  Button_Apply_Password_Click")
        End Try

    End Sub


    'This sub for making decision about Best search Engine
    Private Sub ListBox_SE_GotFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles ListBox_SE.GotFocus
        Dim SEN As Integer = 0
        Dim SEC As Integer = 0
        Dim SEN1 As Integer = 0
        Dim SEC1 As Integer = 0

        'Dim x As Integer = 2
        Try
            con.Close()
            Dim cmd As New SqlCeCommand
            cmd.Connection = con
            cmd.CommandText = "Select * from TheBestSearchEngine"
            con.Open()
            Dim dr2 As SqlCeDataReader = cmd.ExecuteReader

            dr2.Read()
            SEN = dr2(0)
            SEC = dr2(1)
            dr2.Read()
            SEN1 = dr2(0)
            SEC1 = dr2(1)

            con.Close()

            If SEC = SEC1 Then

            ElseIf SEC < 10 Then

            Else

                con.Close()
                Dim cmd1 As New SqlCeCommand
                cmd1.Connection = con
                cmd1.CommandText = "Select Search_Engine from Search_Engine where ID_S = '" & SEN.ToString & "'"
                con.Open()
                Dim dr As SqlCeDataReader = cmd1.ExecuteReader
                dr.Read()
                Dim SearchE As String = dr(0)
                con.Close()

                MsgBox("The SWB to suggest  " & SearchE & " As default Search Engine")


            End If


        Catch ex As Exception
            MsgBox(ex.Message + " ListBox_SE_GotFocus")
        End Try


    End Sub

    Private Sub TextBoxD_A_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles TextBoxD_A.KeyUp
        Try


            Dim n1 As String = "NumPad5"
            Dim n2 As String = "NumPad0"
            Dim x As String = e.Key.ToString
            'If x = "0" Or "1" Or "2" Or "3" Or "4" Or "5" Or "6" Or "7" Or "8" Or "9" Then
            If x = "NumPad0" Or x = "NumPad1" Or x = "NumPad2" Or x = "NumPad3" Or x = "NumPad4" Or x = "NumPad5" Or x = "NumPad6" Or x = "NumPad7" Or x = "NumPad8" Or x = "NumPad9" Or x = "D0" Or x = "D1" Or x = "D2" Or x = "D3" Or x = "D4" Or x = "D5" Or x = "D6" Or x = "D7" Or x = "D8" Or x = "D9" Then

            Else

                TextBoxD_A.Text = ""
            End If

        Catch ex As Exception
            MsgBox(ex.Message + "  TextBoxD_A_KeyUp")
        End Try


    End Sub

    Private Sub TextBoxD_A_LostFocus(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles TextBoxD_A.LostFocus

        Try
            Dim inn As Integer = CInt(TextBoxD_A.Text)
            'MsgBox(inn.ToString)
            If inn > 99 Then
                TextBoxD_A.Text = "7"
            End If

        Catch ex As Exception
            MsgBox(ex.Message + "  TextBoxD_A_LostFocus")
        End Try
    
    End Sub

End Class
