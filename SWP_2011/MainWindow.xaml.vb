Imports System
Imports System.Windows.Forms
Imports System.Windows.Forms.Integration
Imports System.Data
Imports System.Data.SqlServerCe
Imports System.IO

Public Class MainWindow
    Dim URL As String = ""
    Dim CURL As String = ""
    Dim count As Integer = 0
    Dim tabstyle As New Style
    Dim OpenFileDialog1 As System.Windows.Forms.FileDialog
    Dim firsttime As Boolean = True
    Dim timmm As New System.Windows.Forms.Timer
    Dim Home_Page As String
    Dim isSearch As Boolean = False
    Dim iskeydown As Boolean = False
    Dim vtypee As Integer = 2



    Private Enum Exec

        OLECMDID_OPTICAL_ZOOM = 63

    End Enum



    Private Enum ExecOpt

        OLECMDID_OPTICAL_ZOOM = 63
        OLECMDEXECOPT_DODEFAULT = 0
        OLECMDEXECOPT_PROMPTUSER = 1
        OLECMDEXECOPT_DONTPROMPTUSER = 2
        OLECMDEXECOPT_SHOWHELP = 3

    End Enum


    'this sub for fill the search combobox
    Sub DroopItem()

        Try

            ComboBox_Search.Items.Clear()

            con.Close()
            Dim cmd2 As New SqlCeCommand
            cmd2.Connection = con
            cmd2.CommandText = "Select count(ID_S) from Search"
            con.Open()
            Dim dr1 As SqlCeDataReader = cmd2.ExecuteReader
            Dim x As Integer = 0
            dr1.Read()
            x = CInt(dr1(0))
            con.Close()

            con.Close()
            Dim cmd As New SqlCeCommand
            cmd.Connection = con
            cmd.CommandText = "Select Searchq from Search "
            con.Open()
            Dim dr As SqlCeDataReader = cmd.ExecuteReader
            For i As Integer = 1 To x
                dr.Read()
                ComboBox_Search.Items.Add(dr(0).ToString)
            Next

        Catch ex As Exception
            MsgBox(ex.Message + "   DroopItem")

        End Try
    End Sub


    'this sub for fill the url combobox 
    Private Sub ComboBox1_DropDownOpened(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.DropDownOpened
        Try

            If iskeydown = False Then
                ComboBox1.Items.Clear()
                con.Close()
                Dim cmd2 As New SqlCeCommand
                cmd2.Connection = con
                cmd2.CommandText = "Select count(Url)   from Page WHERE ID not In (Select ID from Bookmark ) And ID not In (select ID from Blocked) "
                con.Open()
                Dim dr1 As SqlCeDataReader = cmd2.ExecuteReader
                'If dr1.HasRows = True Then
                Dim x As Integer = 0
                dr1.Read()
                x = CInt(dr1(0))
                ''MsgBox(x.ToString)
                con.Close()
                If x = 0 Then

                Else

                    If x > 10 Then


                        con.Close()
                        Dim cmd As New SqlCeCommand
                        cmd.Connection = con
                        cmd.CommandText = "Select  Top(10) Url from Page WHERE ID not In (Select ID from Bookmark ) And ID not In (select ID from Blocked)  ORDER BY Vdate DESC"
                        con.Open()
                        Dim dr As SqlCeDataReader = cmd.ExecuteReader
                        For i As Integer = 1 To 10
                            dr.Read()
                            ComboBox1.Items.Add(dr(0).ToString)
                        Next
                        con.Close()

                    Else

                        con.Close()
                        Dim cmd As New SqlCeCommand
                        cmd.Connection = con
                        cmd.CommandText = "Select  Url from Page WHERE ID not In (Select ID from Bookmark ) And ID not In (select ID from Blocked)  ORDER BY Vdate DESC"
                        con.Open()
                        Dim dr As SqlCeDataReader = cmd.ExecuteReader
                        For i As Integer = 1 To x
                            dr.Read()
                            ComboBox1.Items.Add(dr(0).ToString)
                        Next
                        con.Close()


                    End If
                End If

            End If



        Catch ex As Exception
            MsgBox(ex.Message + " ,ComboBox1_DropDownOpened")
        End Try

    End Sub


    'this sub for when we prass enter key navigate url & search text
    Public Sub ComboBox1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles ComboBox1.KeyUp
        Try
            If e.Key = Key.Enter Then

                Try


                    con.Close()
                    Dim cmd2 As New SqlCeCommand
                    cmd2.Connection = con
                    cmd2.CommandText = "Select count(Url) from Blocked_Page"
                    con.Open()
                    Dim dr1 As SqlCeDataReader = cmd2.ExecuteReader
                    Dim x As Integer = 0
                    dr1.Read()
                    x = CInt(dr1(0))
                    con.Close()


                    con.Close()
                    Dim cmd As New SqlCeCommand
                    cmd.Connection = con
                    cmd.CommandText = "Select Url from Blocked_Page"
                    con.Open()
                    Dim dr As SqlCeDataReader = cmd.ExecuteReader
                    For i As Integer = 1 To x
                        dr.Read()
                        If ComboBox1.Text = dr(0).ToString Then
                            MsgBox("This Page Has Blocked", MsgBoxStyle.Exclamation)
                            Exit Sub
                        End If
                    Next
                    con.Close()
                Catch ex As Exception
                    'MsgBox(ex.Message + "ComboBox1_KeyDown")
                End Try

                If ComboBox1.Text.Contains(".com") = True Or ComboBox1.Text.Contains(".net") = False Then
                    Dim ss As TabItem = TabControl_SWP.SelectedItem
                    Dim gridd As Grid = CType(ss.Content, Grid)
                    Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
                    vtypee = 2
                    CType(wfhh.Child, System.Windows.Forms.WebBrowser).Navigate(ComboBox1.Text.ToString)

                Else
                    ComboBox1.Text = Trim(ComboBox1.Text) + ".com"
                    Dim ss As TabItem = TabControl_SWP.SelectedItem
                    Dim gridd As Grid = CType(ss.Content, Grid)
                    Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
                    vtypee = 2
                    CType(wfhh.Child, System.Windows.Forms.WebBrowser).Navigate(ComboBox1.Text.ToString)

                End If


                'ElseIf ((Keyboard.IsKeyDown(Key.LeftCtrl) || Keyboard.IsKeyDown(Key.RightCtrl)) && Keyboard.IsKeyDown(Key.P)) Then
                '    MsgBox("Ok")
            Else

                Dim st As String = Trim(ComboBox1.Text)
                iskeydown = True

                con.Close()
                Dim cmd2 As New SqlCeCommand
                cmd2.Connection = con
                cmd2.CommandText = "SELECT  count(Url) FROM Page WHERE CONTAINS(Url, ' " & st & "');"
                con.Open()
                Dim dr1 As SqlCeDataReader = cmd2.ExecuteReader
                If dr1.HasRows = True Then
                    ComboBox1.Items.Clear()
                    Dim x As Integer = 0
                    dr1.Read()
                    x = CInt(dr1(0))
                    con.Close()

                    con.Close()
                    Dim cmd As New SqlCeCommand
                    cmd.Connection = con
                    cmd.CommandText = "SELECT Url FROM Page WHERE CONTAINS(Url, ' " & st & "');"
                    con.Open()
                    Dim dr As SqlCeDataReader = cmd.ExecuteReader
                    If dr.HasRows = True Then
                        For i As Integer = 1 To x
                            dr.Read()
                            ComboBox1.Items.Add(dr(0).ToString)
                        Next
                        ComboBox1.IsDropDownOpen = True
                    End If

                End If



                'Dim x As Integer = 0
                'con.Close()
                'Dim cmd As New SqlCeCommand
                'cmd.Connection = con
                'cmd.CommandText = "SELECT Url FROM Page WHERE CONTAINS(Url, ' " & st & "');"
                'con.Open()
                'Dim dr As SqlCeDataReader = cmd.ExecuteReader
                'If dr.HasRows = True Then
                '    ComboBox1.Items.Clear()
                '    For i As Integer = 1 To x
                '        dr.Read()
                '        ComboBox1.Items.Add(dr(0).ToString)
                '    Next
                '    ComboBox1.IsDropDownOpen = True
                'End If


                iskeydown = False

            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub


    'this sub for create web browser contrl when windows loaded
    Public Sub MainWindow_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded

        Try

            Dim web2011 As New System.Windows.Forms.WebBrowser
            TabControl_SWP.SelectedIndex = count
            Dim wfh As New WindowsFormsHost
            wfh.VerticalAlignment = Windows.VerticalAlignment.Stretch
            wfh.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
            wfh.Width = Double.NaN
            wfh.Height = Double.NaN
            Dim anas As TabItem = TabControl_SWP.SelectedItem
            web2011.Dock = DockStyle.Fill
            wfh.Child = web2011
            Dim gridd As Grid = CType(anas.Content, Grid)
            gridd.Children.Add(wfh)
            count = count + 1

            Dim cmd As New SqlCeCommand
            cmd.Connection = con
            cmd.CommandText = "select * from Setting_Table"
            con.Open()
            Dim dr As SqlCeDataReader = cmd.ExecuteReader
            dr.Read()
            Home_Page = dr(0)
            web2011.Navigate(Home_Page)
            ComboBox1.Text = Home_Page
            Dim a As Integer = dr(1)
            con.Close()

            If a = 1 Then
                ComboBox_Icon.SelectedIndex = 0
            ElseIf a = 2 Then
                ComboBox_Icon.SelectedIndex = 1
            ElseIf a = 3 Then
                ComboBox_Icon.SelectedIndex = 2
            ElseIf a = 4 Then
                ComboBox_Icon.SelectedIndex = 3
            End If

            web2011.IsWebBrowserContextMenuEnabled = False
            web2011.ScriptErrorsSuppressed = False

            AddHandler web2011.ProgressChanged, AddressOf Loading
            AddHandler web2011.DocumentCompleted, AddressOf browse_done
            AddHandler web2011.Navigating, AddressOf browse_Nevigating
            AddHandler web2011.DocumentTitleChanged, AddressOf DocumentTitleChanged

        Catch ex As Exception
            MsgBox(ex.Message & "  MainWindow_Loaded")
        End Try

        DroopItem()

        Try
            ComboBox_From.Items.Clear()
            ComboBox_To.Items.Clear()

            Dim SWP_client As New TranslatorService.LanguageServiceClient
            SWP_client = New TranslatorService.LanguageServiceClient()
            Dim lon As String()
            lon = SWP_client.GetLanguages("6CE9C85A41571C050C379F60DA173D286384E0F2")
            Dim x As Integer = lon.Length
            For i As Integer = 0 To x - 1
                ComboBox_From.Items.Add(lon(i))
                ComboBox_To.Items.Add(lon(i))
            Next

        Catch ex As Exception
            MessageBox.Show("The translation function is not working. Please check your internet service and then try again", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try

    End Sub

    'this sub handles when windows closeing to run the option delete browse history
    Private Sub MainWindow_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Closing
        Try
            con.Close()
            Dim cmd1 As New SqlCeCommand
            cmd1.Connection = con
            cmd1.CommandText = "select *  from Setting_Table"
            con.Open()
            Dim dr As SqlCeDataReader = cmd1.ExecuteReader
            dr.Read()
            Dim som As Integer = dr(3)
            If dr(2) = True Then
                con.Close()
                Dim cmdd As New SqlCeCommand
                cmdd.Connection = con
                cmdd.CommandText = "DELETE FROM Search "
                con.Open()
                cmdd.ExecuteNonQuery()
                con.Close()

                con.Close()
                Dim sqlcom As New SqlCeCommand
                sqlcom.Connection = con
                sqlcom.CommandText = "DELETE FROM Downloads "
                con.Open()
                sqlcom.ExecuteNonQuery()
                con.Close()

                con.Close()
                Dim cmd As New SqlCeCommand
                cmd.Connection = con
                cmd.CommandText = "DELETE FROM Page WHERE ID not In (Select ID from Bookmark ) And ID not In (select ID from Blocked)"
                con.Open()
                cmd.ExecuteNonQuery()
                con.Close()
            Else

                con.Close()
                Dim moad As New SqlCeCommand
                moad.Connection = con
                moad.CommandText = "Delete FROM Search WHERE Page_ID in (select ID from Page where Vdate  <'" & Now.Date.AddDays(-som) & "')"
                con.Open()
                moad.ExecuteNonQuery()
                con.Close()

                con.Close()
                Dim Sqlcomm As New SqlCeCommand
                Sqlcomm.Connection = con
                Sqlcomm.CommandText = "Delete FROM Downloads WHERE Page_ID in (select ID from Page where Vdate  <'" & Now.Date.AddDays(-som) & "')"
                con.Open()
                Sqlcomm.ExecuteNonQuery()
                con.Close()

                con.Close()
                Dim anas As New SqlCeCommand
                anas.Connection = con
                anas.CommandText = "DELETE FROM Page WHERE Vdate <'" & Now.Date.AddDays(-som) & "' and ID not In (Select ID from Bookmark ) And ID not In (select ID from Blocked)"
                con.Open()
                anas.ExecuteNonQuery()
                con.Close()

            End If

        Catch ex As Exception
            MsgBox(ex.Message & " MainWindow_Closing")
        End Try

    End Sub


    'this sub for ProgressBar loadting 
    Private Sub Loading(ByVal sender As Object, ByVal e As WebBrowserProgressChangedEventArgs)
        ProgressBar1.Value = e.CurrentProgress
        Dim ss As TabItem = TabControl_SWP.SelectedItem
        Dim gridd As Grid = CType(ss.Content, Grid)
        Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
        StateLable.Content = CType(wfhh.Child, System.Windows.Forms.WebBrowser).StatusText
    End Sub


    'this sub for insert or update the page into page table
    Private Sub browse_done(ByVal sender As Object, ByVal e As WebBrowserDocumentCompletedEventArgs)

        Try

            Dim ss As TabItem = TabControl_SWP.SelectedItem
            Dim gridd As Grid = CType(ss.Content, Grid)
            Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
            URL = CType(wfhh.Child, System.Windows.Forms.WebBrowser).Document.Url.ToString
            CURL = ComboBox1.Text
            'MsgBox(URL & " ,browse_done")
            'ss.Header = CType(wfhh.Child, System.Windows.Forms.WebBrowser).Document.Title.ToString
            ComboBox1.Text = CType(wfhh.Child, System.Windows.Forms.WebBrowser).Url.ToString
            Dim tabheader As String = ss.Header.ToString
            If tabheader = "Navigation Canceled" Then
            ElseIf tabheader = "Internet Explorer cannot display the webpage" Then

            Else

                If CURL = URL Then
                    'MsgBox(ComboBox1.Text & "   " & URL)
                Else


                    If vtypee = 1 Or vtypee = 2 Then

                    Else
                        vtypee = 0
                    End If


                    'If firsttime1 = False Then
                    con.Close()
                    Dim cmd1, cmd5 As New SqlCeCommand
                    cmd1.Connection = con
                    cmd5.Connection = con
                    cmd1.CommandText = "Select Vcount   from Page  WHERE Url = '" & CStr(URL) & "'"
                    cmd5.CommandText = "Select Count(Vcount)   from Page  WHERE Url = '" & CStr(URL) & "'"
                    'cmd1.CommandText = "Select Vcount  from Page  WHERE Url = 'http://www.metrolyrics.com/red-nation-lyrics-game.html'"
                    con.Open()
                    Dim dr, dr5 As SqlCeDataReader

                    dr = cmd1.ExecuteReader
                    dr5 = cmd5.ExecuteReader
                    dr5.Read()

                    Dim xn As Integer = dr5(0)


                    If xn <> 0 Then
                        dr.Read()
                        Dim Reused As Integer = dr.Item(0)
                        con.Close()
                        Dim commd As New SqlCeCommand
                        commd.Connection = con
                        commd.CommandText = " UPDATE Page SET Vcount=@Vcount , Vdate=@Vdate , Vtype=@Vtype  WHERE Url = '" & CStr(URL) & "'"
                        con.Open()
                        commd.Parameters.Add("@Vcount", SqlDbType.Int).Value = Reused + 1
                        commd.Parameters.Add("@Vdate", SqlDbType.DateTime).Value = Now
                        commd.Parameters.Add("@Vtype", SqlDbType.Int).Value = vtypee
                        commd.ExecuteNonQuery()
                        con.Close()
                        Reused = 0
                    Else
                        con.Close()
                        Dim cmd As New SqlCeCommand
                        cmd.CommandText = "insert into Page(Vdate,Url,Vcount,Vtype,Title) values(@Page_Date,@Page_Url,@Page_Reused,@Page_Vtype,@Page_Title)"
                        cmd.Connection = con
                        con.Open()
                        cmd.Parameters.Add("@Page_Date", SqlDbType.DateTime).Value = Now
                        cmd.Parameters.Add("@Page_Url", SqlDbType.NVarChar).Value = URL
                        cmd.Parameters.Add("@Page_Reused", SqlDbType.Int).Value = 1
                        cmd.Parameters.Add("@Page_Vtype", SqlDbType.Int).Value = vtypee
                        cmd.Parameters.Add("@Page_Title", SqlDbType.NVarChar).Value = ss.Header.ToString
                        cmd.ExecuteNonQuery()
                        con.Close()
                    End If
                    vtypee = 0


                    'Else
                    '    'firsttime1 = False
                    'End If

                End If



            End If

            If isSearch = True Then
                con.Close()
                Dim comand As New SqlCeCommand
                comand.Connection = con
                comand.CommandText = "Select ID from Page where Url = '" & CStr(ComboBox1.Text) & "'"
                con.Open()
                Dim dr As SqlCeDataReader = comand.ExecuteReader
                dr.Read()
                Dim Id As Integer = dr(0)
                con.Close()

                Dim sid As Integer = Nothing
                If ComboBox_Icon.Text = "Google" Then
                    sid = 1
                ElseIf ComboBox_Icon.Text = "Yahoo" Then
                    sid = 2
                ElseIf ComboBox_Icon.Text = "Bing" Then
                    sid = 3
                ElseIf ComboBox_Icon.Text = "Youtube" Then
                    sid = 4
                End If


                Dim INS As Boolean = True
                con.Close()
                Dim Anas1 As New SqlCeCommand
                Anas1.Connection = con
                Anas1.CommandText = "Select Count(Searchq) from Search where Searchq = '" & CStr(ComboBox_Search.Text) & "' and Sengine= '" & sid & "'"
                con.Open()
                Dim dr2 As SqlCeDataReader = Anas1.ExecuteReader
                dr2.Read()

                If dr2(0) > 0 Then
                    INS = False
                End If
                con.Close()



                If INS = True Then

                    con.Close()
                    Dim cmd1 As New SqlCeCommand
                    cmd1.CommandText = "insert into Search(Page_ID,Searchq,Sengine) values(@Search_Id_S,@Search_Text,@Search_Id_Search_Engine)"
                    cmd1.Connection = con
                    con.Open()
                    cmd1.Parameters.Add("@Search_Id_S", SqlDbType.Int).Value = Id
                    cmd1.Parameters.Add("@Search_Text", SqlDbType.NVarChar).Value = ComboBox_Search.Text
                    cmd1.Parameters.Add("@Search_Id_Search_Engine", SqlDbType.SmallInt).Value = sid
                    cmd1.ExecuteNonQuery()
                    con.Close()
                    DroopItem()
                    isSearch = False
                    ComboBox_Search.Text = ""

                Else

                    con.Close()
                    Dim cmd1 As New SqlCeCommand
                    cmd1.CommandText = "UPDATE  Search SET Sengine = '" & sid & "' , Page_ID = '" & Id & "'   WHERE Searchq= '" & Trim(ComboBox_Search.Text) & "'"
                    cmd1.Connection = con
                    con.Open()
                    cmd1.ExecuteNonQuery()
                    con.Close()
                    DroopItem()
                    isSearch = False
                    ComboBox_Search.Text = ""

                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message & " browse_done")
        End Try

    End Sub


    'this sub for print the web page
    Private Sub Print_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)

        con.Close()
        Dim Anas1 As New SqlCeCommand
        Anas1.Connection = con
        Anas1.CommandText = "Select Url from dbo.Page where Url = '" & CStr(ComboBox1.Text) & "'"
        con.Open()
        Dim dr2 As SqlCeDataReader = Anas1.ExecuteReader
        dr2.Read()
        If dr2.HasRows = True Then
            Dim ss As TabItem = TabControl_SWP.SelectedItem
            Dim gridd As Grid = CType(ss.Content, Grid)
            Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
            CType(wfhh.Child, System.Windows.Forms.WebBrowser).ShowPrintDialog()
        Else
            MsgBox("You have to load page first", MsgBoxStyle.Exclamation)
        End If
        con.Close()


    End Sub


    'this sub for  print preview the web page 
    Private Sub Print_Preview_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)

        con.Close()
        Dim Anas1 As New SqlCeCommand
        Anas1.Connection = con
        Anas1.CommandText = "Select Url from dbo.Page where Url = '" & CStr(ComboBox1.Text) & "'"
        con.Open()
        Dim dr2 As SqlCeDataReader = Anas1.ExecuteReader
        dr2.Read()
        If dr2.HasRows = True Then
            Dim ss As TabItem = TabControl_SWP.SelectedItem
            Dim gridd As Grid = CType(ss.Content, Grid)
            Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
            CType(wfhh.Child, System.Windows.Forms.WebBrowser).ShowPrintPreviewDialog()
        Else
            MsgBox("You have to load page first", MsgBoxStyle.Exclamation)
        End If
        con.Close()

    End Sub


    'this sub for opene web page that's in client computer 
    Private Sub Open_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Try
            OpenFileDialog1 = New OpenFileDialog()
            OpenFileDialog1.FileName = ""
            OpenFileDialog1.Filter = "WebPages|*.html|All Files|*.*"
            OpenFileDialog1.Title = "SWB Open WebPage"
            If (OpenFileDialog1.ShowDialog = Forms.DialogResult.OK) Then

                Dim ss As TabItem = TabControl_SWP.SelectedItem
                Dim gridd As Grid = CType(ss.Content, Grid)
                Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
                CType(wfhh.Child, System.Windows.Forms.WebBrowser).DocumentText = System.IO.File.ReadAllText(OpenFileDialog1.FileName)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    'this sub for save the web page
    Private Sub Save_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)

        con.Close()
        Dim Anas1 As New SqlCeCommand
        Anas1.Connection = con
        Anas1.CommandText = "Select Url from dbo.Page where Url = '" & CStr(ComboBox1.Text) & "'"
        con.Open()
        Dim dr2 As SqlCeDataReader = Anas1.ExecuteReader
        dr2.Read()
        If dr2.HasRows = True Then
            Dim ss As TabItem = TabControl_SWP.SelectedItem
            Dim gridd As Grid = CType(ss.Content, Grid)
            Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
            CType(wfhh.Child, System.Windows.Forms.WebBrowser).ShowSaveAsDialog()
        Else
            MsgBox("You have to load page first", MsgBoxStyle.Exclamation)
        End If
        con.Close()

    End Sub


    'this sub for let combobox text like url of web page
    Private Sub TabControl_SWP_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles TabControl_SWP.SelectionChanged
        Try
            If firsttime = False Then
                ComboBox1.Text = ""
                Dim ss As TabItem = TabControl_SWP.SelectedItem
                If ss.Header = "TabItem" Then
                    'MsgBox(ss.Header)
                Else
                    Dim gridd As Grid = CType(ss.Content, Grid)
                    Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
                    StateLable.Content = CType(wfhh.Child, System.Windows.Forms.WebBrowser).StatusText
                    If CType(wfhh.Child, System.Windows.Forms.WebBrowser).Document = Nothing Then
                    Else
                        ComboBox1.Text = CType(wfhh.Child, System.Windows.Forms.WebBrowser).Url.ToString
                    End If

                End If
            Else
                firsttime = False
            End If
        Catch ex As Exception
            MsgBox(ex.Message & "  TabControl_SWP_SelectionChanged")
        End Try

    End Sub


    'this sub for display the setting windows
    Private Sub Button_Setting_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Setting.Click
        Dim sss As New Window2
        sss.Show()
    End Sub



    'this sub use M.S to  translate the  text input
    Private Sub Button_Translate_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)

        Dim strTranslatedText As String

        Try

            If TextBox_In.Text <> Nothing Then


                Dim SWP_client As New TranslatorService.LanguageServiceClient
                SWP_client = New TranslatorService.LanguageServiceClient()
                strTranslatedText = SWP_client.Translate("6CE9C85A41571C050C379F60DA173D286384E0F2", TextBox_In.Text, ComboBox_From.SelectedItem.ToString, ComboBox_To.SelectedItem.ToString)
                TextBox_Out.Text = strTranslatedText


            End If



        Catch ex As Exception
            'MessageBox.Show(ex.Message, "Error 2011 ", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub


    'this sub use to show translate window and paste the text in clipboard
    Private Sub Button_Tran_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Translate1.Click


        Try
            ComboBox_From.Items.Clear()
            ComboBox_To.Items.Clear()

            Dim SWP_client As New TranslatorService.LanguageServiceClient
            SWP_client = New TranslatorService.LanguageServiceClient()
            Dim lon As String()
            lon = SWP_client.GetLanguages("6CE9C85A41571C050C379F60DA173D286384E0F2")
            Dim x As Integer = lon.Length
            For i As Integer = 0 To x - 1
                ComboBox_From.Items.Add(lon(i))
                ComboBox_To.Items.Add(lon(i))
            Next
        Catch ex As Exception
            MessageBox.Show("The translation function is not working. Please check your internet service and then try again", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try


        If Grid.GetColumnSpan(TabControl_SWP) = 2 Then
            Grid.SetColumnSpan(TabControl_SWP, 1)
            Grid_Tran.Visibility = Visibility.Visible = True
            Grid_Library.Visibility = Visibility.Visible = False


            If Clipboard.ContainsText = True Then
                TextBox_In.Focus()
                TextBox_In.Text = Clipboard.GetText

            End If

        Else
            Grid.SetColumnSpan(TabControl_SWP, 2)
            Grid_Tran.Visibility = Visibility.Visible = False
        End If

    End Sub


    'this sub for GoBack the web page
    Private Sub Button_Back_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Back.Click
        Dim ss As TabItem = TabControl_SWP.SelectedItem
        Dim gridd As Grid = CType(ss.Content, Grid)
        Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
        CType(wfhh.Child, System.Windows.Forms.WebBrowser).GoBack()
    End Sub


    'this sub for GoForward the web page
    Private Sub Button_Forword_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Forword.Click
        Dim ss As TabItem = TabControl_SWP.SelectedItem
        Dim gridd As Grid = CType(ss.Content, Grid)
        Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
        CType(wfhh.Child, System.Windows.Forms.WebBrowser).GoForward()
    End Sub


    'this sub for Refresh the web page
    Private Sub Button_Refresh_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Refresh.Click
        If ComboBox1.Text <> "" Then
            Dim ss As TabItem = TabControl_SWP.SelectedItem
            Dim gridd As Grid = CType(ss.Content, Grid)
            Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
            CType(wfhh.Child, System.Windows.Forms.WebBrowser).Refresh()
        End If

    End Sub



    'this sub for menu item to exit the prgram
    Private Sub Exit_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Me.Close()
    End Sub


    'this sub for fill the library category
    Private Sub Button_Library_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Library.Click
        If Grid.GetColumnSpan(TabControl_SWP) = 2 Then
            Grid.SetColumnSpan(TabControl_SWP, 1)
            Grid_Library.Visibility = Visibility.Visible = True
            Grid_Tran.Visibility = Visibility.Visible = False
            ListBox_Library.Items.Clear()
            ComboBox_Search_lib.Items.Clear()
            Grid.SetRowSpan(ListBox_Library, 2)
            TextBox_Libra_Content.Text = ""

            Try
                ListBox_Library.Items.Clear()
                ComboBox_Search_lib.Items.Clear()
                con.Close()
                Dim cmd2 As New SqlCeCommand
                cmd2.Connection = con
                cmd2.CommandText = "SELECT count(ID) FROM category"
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
                    ComboBox_Search_lib.Items.Add(dr(0).ToString)
                Next
                con.Close()
            Catch ex As Exception
                'MsgBox(ex.Message & " Button_Library_Click")
            End Try

        Else
            Grid.SetColumnSpan(TabControl_SWP, 2)
            Grid_Library.Visibility = Visibility.Visible = False

        End If
    End Sub


    'this sub for fill the listbox library  with page 
    Private Sub ComboBox_Search_lib_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles ComboBox_Search_lib.SelectionChanged

        Try
            If ComboBox_Search_lib.SelectedItem.ToString = "" Then
            Else

                con.Close()
                Dim cmd2 As New SqlCeCommand
                cmd2.Connection = con
                cmd2.CommandText = "Select count(Url) from Page where ID In (Select ID from Bookmark where Category In ( Select ID  from category Where Cname = '" & ComboBox_Search_lib.SelectedItem.ToString & "' ))"
                con.Open()
                Dim dr1 As SqlCeDataReader = cmd2.ExecuteReader
                Dim x As Integer = 0
                dr1.Read()
                x = CInt(dr1(0))
                con.Close()


                ListBox_Library.Items.Clear()
                con.Close()
                Dim cmd As New SqlCeCommand
                cmd.Connection = con
                cmd.CommandText = "Select Url from Page where ID In (Select ID from Bookmark where Category In ( Select ID  from category Where Cname = '" & ComboBox_Search_lib.SelectedItem.ToString & "' ))"
                con.Open()
                Dim dr As SqlCeDataReader = cmd.ExecuteReader
                For i As Integer = 1 To x
                    dr.Read()
                    ListBox_Library.Items.Add(dr(0).ToString)
                Next
                con.Close()


            End If


        Catch ex As Exception
            'MsgBox(ex.Message & "ComboBox_Search_lib_SelectionChanged")
        End Try

    End Sub


    'this sub for zoom in & out the web page 
    Private Sub Slider_Zoom_ValueChanged(ByVal sender As System.Object, ByVal e As System.Windows.RoutedPropertyChangedEventArgs(Of System.Double)) Handles Slider_Zoom.ValueChanged
        If e.NewValue = 0 Then
            Try
                Dim Res As Object = Nothing
                Dim MyWeb As Object
                Dim ss As TabItem = TabControl_SWP.SelectedItem
                Dim gridd As Grid = CType(ss.Content, Grid)
                Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
                MyWeb = CType(wfhh.Child, System.Windows.Forms.WebBrowser).ActiveXInstance
                MyWeb.ExecWB(Exec.OLECMDID_OPTICAL_ZOOM, ExecOpt.OLECMDEXECOPT_PROMPTUSER, 50, IntPtr.Zero)
            Catch ex As Exception
            End Try
        ElseIf e.NewValue = 1 Then
            Try
                Dim Res As Object = Nothing
                Dim MyWeb As Object
                Dim ss As TabItem = TabControl_SWP.SelectedItem
                Dim gridd As Grid = CType(ss.Content, Grid)
                Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
                MyWeb = CType(wfhh.Child, System.Windows.Forms.WebBrowser).ActiveXInstance
                MyWeb.ExecWB(Exec.OLECMDID_OPTICAL_ZOOM, ExecOpt.OLECMDEXECOPT_PROMPTUSER, 75, IntPtr.Zero)
            Catch ex As Exception
            End Try
        ElseIf e.NewValue = 2 Then
            Try
                Dim Res As Object = Nothing
                Dim MyWeb As Object
                Dim ss As TabItem = TabControl_SWP.SelectedItem
                Dim gridd As Grid = CType(ss.Content, Grid)
                Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
                MyWeb = CType(wfhh.Child, System.Windows.Forms.WebBrowser).ActiveXInstance
                MyWeb.ExecWB(Exec.OLECMDID_OPTICAL_ZOOM, ExecOpt.OLECMDEXECOPT_PROMPTUSER, 100, IntPtr.Zero)
            Catch ex As Exception
            End Try
        ElseIf e.NewValue = 3 Then
            Try
                Dim Res As Object = Nothing
                Dim MyWeb As Object
                Dim ss As TabItem = TabControl_SWP.SelectedItem
                Dim gridd As Grid = CType(ss.Content, Grid)
                Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
                MyWeb = CType(wfhh.Child, System.Windows.Forms.WebBrowser).ActiveXInstance
                MyWeb.ExecWB(Exec.OLECMDID_OPTICAL_ZOOM, ExecOpt.OLECMDEXECOPT_PROMPTUSER, 125, IntPtr.Zero)
            Catch ex As Exception
            End Try
        ElseIf e.NewValue = 4 Then
            Try
                Dim Res As Object = Nothing
                Dim MyWeb As Object
                Dim ss As TabItem = TabControl_SWP.SelectedItem
                Dim gridd As Grid = CType(ss.Content, Grid)
                Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
                MyWeb = CType(wfhh.Child, System.Windows.Forms.WebBrowser).ActiveXInstance
                MyWeb.ExecWB(Exec.OLECMDID_OPTICAL_ZOOM, ExecOpt.OLECMDEXECOPT_PROMPTUSER, 150, IntPtr.Zero)
            Catch ex As Exception
            End Try
        ElseIf e.NewValue = 5 Then
            Try
                Dim Res As Object = Nothing
                Dim MyWeb As Object
                Dim ss As TabItem = TabControl_SWP.SelectedItem
                Dim gridd As Grid = CType(ss.Content, Grid)
                Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
                MyWeb = CType(wfhh.Child, System.Windows.Forms.WebBrowser).ActiveXInstance
                MyWeb.ExecWB(Exec.OLECMDID_OPTICAL_ZOOM, ExecOpt.OLECMDEXECOPT_PROMPTUSER, 200, IntPtr.Zero)
            Catch ex As Exception
            End Try

        End If
    End Sub


    'this sub for search into the selected search engine 
    Private Sub ComboBox_Search_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Input.KeyEventArgs) Handles ComboBox_Search.KeyUp

        If e.Key = Key.Enter And ComboBox_Search.Text <> "" Then

            vtypee = 2
            isSearch = True
            If ComboBox_Icon.SelectedIndex = 0 Then
                Dim tabstyle_Copy As TabItem = TabControl_SWP.SelectedItem
                tabstyle = tabstyle_Copy.Style
                ComboBox1.Text = ""
                Dim web2011 As New System.Windows.Forms.WebBrowser
                Dim wfh1 As New WindowsFormsHost
                wfh1.VerticalAlignment = Windows.VerticalAlignment.Stretch
                wfh1.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
                wfh1.Width = Double.NaN
                wfh1.Height = Double.NaN
                web2011.Dock = DockStyle.Fill
                wfh1.Child = web2011
                Dim gridd As New Grid
                gridd.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
                gridd.VerticalAlignment = Windows.VerticalAlignment.Stretch
                gridd.Width = Double.NaN
                gridd.Height = Double.NaN
                gridd.Background = Brushes.Lavender
                gridd.Children.Add(wfh1)
                Dim anas As New TabItem
                anas.Header = "TabItem"
                anas.Style = tabstyle
                TabControl_SWP.Items.Add(anas)
                anas.Content = gridd
                TabControl_SWP.SelectedIndex = count
                count = count + 1

                web2011.IsWebBrowserContextMenuEnabled = False
                web2011.ScriptErrorsSuppressed = False

                AddHandler web2011.ProgressChanged, AddressOf Loading
                AddHandler web2011.DocumentCompleted, AddressOf browse_done
                AddHandler web2011.Navigating, AddressOf browse_Nevigating
                AddHandler web2011.DocumentTitleChanged, AddressOf DocumentTitleChanged

                Dim ss As TabItem = TabControl_SWP.SelectedItem
                Dim Salm As Grid = CType(ss.Content, Grid)
                Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
                CType(wfhh.Child, System.Windows.Forms.WebBrowser).Navigate("http://www.google.com/search?hl=en&q=" & ComboBox_Search.Text & "&meta=")

            ElseIf ComboBox_Icon.SelectedIndex = 1 Then
                Dim tabstyle_Copy As TabItem = TabControl_SWP.SelectedItem
                tabstyle = tabstyle_Copy.Style
                ComboBox1.Text = ""
                Dim web2011 As New System.Windows.Forms.WebBrowser
                Dim wfh1 As New WindowsFormsHost
                wfh1.VerticalAlignment = Windows.VerticalAlignment.Stretch
                wfh1.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
                wfh1.Width = Double.NaN
                wfh1.Height = Double.NaN
                web2011.Dock = DockStyle.Fill
                wfh1.Child = web2011
                Dim gridd As New Grid
                gridd.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
                gridd.VerticalAlignment = Windows.VerticalAlignment.Stretch
                gridd.Width = Double.NaN
                gridd.Height = Double.NaN
                gridd.Background = Brushes.Lavender
                gridd.Children.Add(wfh1)
                Dim anas As New TabItem
                anas.Header = "TabItem"
                anas.Style = tabstyle
                TabControl_SWP.Items.Add(anas)
                anas.Content = gridd
                TabControl_SWP.SelectedIndex = count
                count = count + 1

                web2011.IsWebBrowserContextMenuEnabled = False
                web2011.ScriptErrorsSuppressed = False

                AddHandler web2011.ProgressChanged, AddressOf Loading
                AddHandler web2011.DocumentCompleted, AddressOf browse_done
                AddHandler web2011.Navigating, AddressOf browse_Nevigating
                AddHandler web2011.DocumentTitleChanged, AddressOf DocumentTitleChanged

                Dim ss As TabItem = TabControl_SWP.SelectedItem
                Dim Salm As Grid = CType(ss.Content, Grid)
                Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
                CType(wfhh.Child, System.Windows.Forms.WebBrowser).Navigate("http://au.search.yahoo.com/search?p=" & ComboBox_Search.Text & "&fr=yfp-t-501&ei=UTF-8")

            ElseIf ComboBox_Icon.SelectedIndex = 2 Then
                Dim tabstyle_Copy As TabItem = TabControl_SWP.SelectedItem
                tabstyle = tabstyle_Copy.Style
                ComboBox1.Text = ""
                Dim web2011 As New System.Windows.Forms.WebBrowser
                Dim wfh1 As New WindowsFormsHost
                wfh1.VerticalAlignment = Windows.VerticalAlignment.Stretch
                wfh1.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
                wfh1.Width = Double.NaN
                wfh1.Height = Double.NaN
                web2011.Dock = DockStyle.Fill
                wfh1.Child = web2011
                Dim gridd As New Grid
                gridd.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
                gridd.VerticalAlignment = Windows.VerticalAlignment.Stretch
                gridd.Width = Double.NaN
                gridd.Height = Double.NaN
                gridd.Background = Brushes.Lavender
                gridd.Children.Add(wfh1)
                Dim anas As New TabItem
                anas.Header = "TabItem"
                anas.Style = tabstyle
                TabControl_SWP.Items.Add(anas)
                anas.Content = gridd
                TabControl_SWP.SelectedIndex = count
                count = count + 1

                web2011.IsWebBrowserContextMenuEnabled = False
                web2011.ScriptErrorsSuppressed = False

                AddHandler web2011.ProgressChanged, AddressOf Loading
                AddHandler web2011.DocumentCompleted, AddressOf browse_done
                AddHandler web2011.Navigating, AddressOf browse_Nevigating
                AddHandler web2011.DocumentTitleChanged, AddressOf DocumentTitleChanged

                Dim ss As TabItem = TabControl_SWP.SelectedItem
                Dim Salm As Grid = CType(ss.Content, Grid)
                Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
                CType(wfhh.Child, System.Windows.Forms.WebBrowser).Navigate("http://www.bing.com/search?q=" & ComboBox_Search.Text & "&form=MSNH50&mkt=en-au&qs=n")

            ElseIf ComboBox_Icon.SelectedIndex = 3 Then
                Dim tabstyle_Copy As TabItem = TabControl_SWP.SelectedItem
                tabstyle = tabstyle_Copy.Style
                ComboBox1.Text = ""
                Dim web2011 As New System.Windows.Forms.WebBrowser
                Dim wfh1 As New WindowsFormsHost
                wfh1.VerticalAlignment = Windows.VerticalAlignment.Stretch
                wfh1.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
                wfh1.Width = Double.NaN
                wfh1.Height = Double.NaN
                web2011.Dock = DockStyle.Fill
                wfh1.Child = web2011
                Dim gridd As New Grid
                gridd.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
                gridd.VerticalAlignment = Windows.VerticalAlignment.Stretch
                gridd.Width = Double.NaN
                gridd.Height = Double.NaN
                gridd.Background = Brushes.Lavender
                gridd.Children.Add(wfh1)
                Dim anas As New TabItem
                anas.Header = "TabItem"
                anas.Style = tabstyle
                TabControl_SWP.Items.Add(anas)
                anas.Content = gridd
                TabControl_SWP.SelectedIndex = count
                count = count + 1

                web2011.IsWebBrowserContextMenuEnabled = False
                web2011.ScriptErrorsSuppressed = False

                AddHandler web2011.ProgressChanged, AddressOf Loading
                AddHandler web2011.DocumentCompleted, AddressOf browse_done
                AddHandler web2011.Navigating, AddressOf browse_Nevigating
                AddHandler web2011.DocumentTitleChanged, AddressOf DocumentTitleChanged

                Dim ss As TabItem = TabControl_SWP.SelectedItem
                Dim Salm As Grid = CType(ss.Content, Grid)
                Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
                CType(wfhh.Child, System.Windows.Forms.WebBrowser).Navigate("http://www.youtube.com/results?search_query=" & ComboBox_Search.Text & "&search_type=&aq=f")

            End If

            'ComboBox_Search.Text = ""

        End If
    End Sub


    'this sub for open the home  web page
    Private Sub Button_Home_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Home.Click
        Dim ss As TabItem = TabControl_SWP.SelectedItem
        Dim Gridd As Grid = CType(ss.Content, Grid)
        Dim wfhh As WindowsFormsHost = CType(Gridd.Children.Item(0), WindowsFormsHost)
        CType(wfhh.Child, System.Windows.Forms.WebBrowser).Navigate(Home_Page)
    End Sub


    'this sub for affirmation the url of page is opened & display the add_library windows
    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Try
            con.Close()
            Dim cmd As New SqlCeCommand
            cmd.Connection = con
            cmd.CommandText = "Select Url from dbo.Page where Url='" & ComboBox1.Text & "'"
            con.Open()
            Dim dr As SqlCeDataReader = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows = True Then
                con.Close()
                Dim cmd1 As New SqlCeCommand
                cmd1.Connection = con
                cmd1.CommandText = "Select ID from Bookmark where ID In (Select ID from Page Where Url = '" & ComboBox1.Text & "')"
                con.Open()
                Dim dr1 As SqlCeDataReader = cmd1.ExecuteReader
                dr1.Read()
                If dr1.HasRows = False Then
                    urll = ComboBox1.Text
                    Dim nn As New Add_Library
                    nn.Show()
                Else
                    MsgBox("This page is already in the bookmark", MsgBoxStyle.Information)
                End If
            Else
                MsgBox("You have to load page first", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try


    End Sub


    'this sub for stop dowanload the web page
    Private Sub Button_Cancel_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Cancel.Click
        Dim ss As TabItem = TabControl_SWP.SelectedItem
        Dim Gridd As Grid = CType(ss.Content, Grid)
        Dim wfhh As WindowsFormsHost = CType(Gridd.Children.Item(0), WindowsFormsHost)
        CType(wfhh.Child, System.Windows.Forms.WebBrowser).Stop()
    End Sub



    'this sub for erase the description
    Private Sub ListBox_Library_LostFocus(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles ListBox_Library.LostFocus
        TextBox_Libra_Content.Text = ""
    End Sub



    'this sub for show web page description in the library
    Private Sub ListBox_Library_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles ListBox_Library.SelectionChanged


        Grid.SetRowSpan(ListBox_Library, 1)
        Dim st As String = ""
        Try

            If ListBox_Library.SelectedItem.ToString = "" Then
            Else
                con.Close()
                Dim cmd As New SqlCeCommand
                cmd.Connection = con
                cmd.CommandText = " SELECT Bookmark.Description FROM Page, Bookmark WHERE Page.ID = Bookmark.ID  AND Page.Url= '" & ListBox_Library.SelectedItem.ToString & "'"
                con.Open()
                Dim da As SqlCeDataReader = cmd.ExecuteReader
                da.Read()
                TextBox_Libra_Content.Text = da(0)
                con.Close()



            End If

        Catch ex As Exception
            'MsgBox(ex.Message & " ListBox_Library_SelectionChanged")
        End Try

    End Sub



    ' This sub for get the search engine for the text search
    Private Sub ComboBox_Search_SelectionChanged(ByVal sender As System.Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles ComboBox_Search.SelectionChanged

        Try

            If ComboBox_Search.Text <> "" Then
                con.Close()
                Dim anas As New SqlCeCommand
                anas.Connection = con
                anas.CommandText = "Select Sengine FROM Search WHERE Searchq = '" & ComboBox_Search.SelectedItem.ToString & "'"
                con.Open()
                Dim dr As SqlCeDataReader = anas.ExecuteReader
                dr.Read()
                Dim Search_Engine As Integer = dr(0)
                con.Close()

                If Search_Engine = 1 Then
                    ComboBox_Icon.SelectedIndex = 0
                ElseIf Search_Engine = 2 Then
                    ComboBox_Icon.SelectedIndex = 1
                ElseIf Search_Engine = 3 Then
                    ComboBox_Icon.SelectedIndex = 2
                ElseIf Search_Engine = 4 Then
                    ComboBox_Icon.SelectedIndex = 3
                End If
            End If

        Catch ex As Exception
            MsgBox(ex.Message & " ComboBox_Search_SelectionChanged")
        End Try

    End Sub


    ' This sub for block the web page & insert into blocked list
    Private Sub Button_Restricted_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Restricted.Click
        Try

            con.Close()
            Dim cmd As New SqlCeCommand
            cmd.Connection = con
            cmd.CommandText = "Select Url from Page where Url='" & ComboBox1.Text & "'"
            con.Open()
            Dim dr As SqlCeDataReader = cmd.ExecuteReader
            dr.Read()
            If dr.HasRows = True Then
                con.Close()
                Dim cmd1 As New SqlCeCommand
                cmd1.Connection = con
                cmd1.CommandText = "Select ID from Blocked where ID In (Select ID  from Page Where Url = '" & ComboBox1.Text & "')"
                con.Open()
                Dim dr1 As SqlCeDataReader = cmd1.ExecuteReader
                dr1.Read()
                If dr1.HasRows = False Then
                    con.Close()
                    Dim cmd2011 As New SqlCeCommand
                    cmd2011.Connection = con
                    cmd2011.CommandText = "Select ID from Page  where Url= '" & ComboBox1.Text & "'"
                    con.Open()
                    Dim dr11 As SqlCeDataReader = cmd2011.ExecuteReader
                    dr11.Read()
                    Dim Id_Pagee As Integer = dr11(0)
                    con.Close()

                    con.Close()
                    Dim cmd11 As New SqlCeCommand
                    cmd11.CommandText = "insert into Blocked(ID,Date) values(@Blocked_Id,@Blocked_date)"
                    cmd11.Connection = con
                    con.Open()
                    cmd11.Parameters.Add("@Blocked_Id", SqlDbType.Int).Value = Id_Pagee
                    cmd11.Parameters.Add("@Blocked_date", SqlDbType.DateTime).Value = Now
                    cmd11.ExecuteNonQuery()
                    con.Close()

                    MsgBox(ComboBox1.Text & " has blocked successful", MsgBoxStyle.Information)

                End If
            End If


        Catch ex As Exception
            MsgBox(ex.Message + " Button_Restricted_Click")
        End Try

    End Sub



    ' This sub for close the selected tab in the tab control
    Private Sub Button_Close_Tab_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If TabControl_SWP.Items.Count = 1 Then
            Me.Close()
        End If

        Try
            Dim moad As TabItem = TabControl_SWP.SelectedItem
            TabControl_SWP.Items.Remove(moad)

        Catch ex As Exception
            MsgBox(ex.Message + "Button_Close_Tab_Click")
        End Try

    End Sub


    ' This sub for display the Email windows
    Private Sub Button_Email_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Email.Click
        Dim emaill As New Email
        emaill.Show()
    End Sub


    ' This sub for display the download windows
    Private Sub Button_Download_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Download.Click

        If ComboBox1.Text = Nothing Then

        Else
            D_Address = ""
            PageUrl = ""
            Dim Down As New Download
            Down.Show()
        End If

    End Sub


    'This sub for get download url
    Private Sub browse_Nevigating(ByVal sender As Object, ByVal e As WebBrowserNavigatingEventArgs)


        'Dim ss As TabItem = TabControl_SWP.SelectedItem
        'Dim gridd As Grid = CType(ss.Content, Grid)
        'Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
        'doctitle = CType(wfhh.Child, System.Windows.Forms.WebBrowser).Document.Url.ToString
        'MsgBox(doctitle & " ,browse_Nevigating")

        Try
            If e.Url.OriginalString.EndsWith(".pdf") Then
                D_Address = e.Url.OriginalString.ToString
                PageUrl = Trim(ComboBox1.Text)
                Dim Down As New Download
                Down.Show()
            ElseIf e.Url.OriginalString.EndsWith(".jpg") Then
                D_Address = e.Url.OriginalString.ToString
                PageUrl = Trim(ComboBox1.Text)
                Dim Down As New Download
                Down.Show()
            ElseIf e.Url.OriginalString.EndsWith(".exe") Then
                D_Address = e.Url.OriginalString.ToString
                PageUrl = Trim(ComboBox1.Text)
                Dim Down As New Download
                Down.Show()
            ElseIf e.Url.OriginalString.EndsWith("..rar") Then
                D_Address = e.Url.OriginalString.ToString
                PageUrl = Trim(ComboBox1.Text)
                Dim Down As New Download
                Down.Show()
            ElseIf e.Url.OriginalString.EndsWith(".zip") Then
                D_Address = e.Url.OriginalString.ToString
                PageUrl = Trim(ComboBox1.Text)
                Dim Down As New Download
                Down.Show()
            ElseIf e.Url.OriginalString.EndsWith(".mp3") Then
                D_Address = e.Url.OriginalString.ToString
                PageUrl = Trim(ComboBox1.Text)
                Dim Down As New Download
                Down.Show()
            ElseIf e.Url.OriginalString.EndsWith(".mp4") Then
                D_Address = e.Url.OriginalString.ToString
                PageUrl = Trim(ComboBox1.Text)
                Dim Down As New Download
                Down.Show()
            ElseIf e.Url.OriginalString.EndsWith(".doc") Then
                D_Address = e.Url.OriginalString.ToString
                PageUrl = Trim(ComboBox1.Text)
                Dim Down As New Download
                Down.Show()
            ElseIf e.Url.OriginalString.EndsWith(".png") Then
                D_Address = e.Url.OriginalString.ToString
                PageUrl = Trim(ComboBox1.Text)
                Dim Down As New Download
                Down.Show()
            Else
                'D_Address = ""
                'PageUrl = ""
            End If
            'MsgBox(PageUrl)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub



    ' This sub for add tab item into tab control menu item
    Private Sub New_Tab_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)

        Try
            Dim tabstyle_Copy As TabItem = TabControl_SWP.SelectedItem
            tabstyle = tabstyle_Copy.Style
            ComboBox1.Text = ""
            Dim web2011 As New System.Windows.Forms.WebBrowser
            Dim wfh1 As New WindowsFormsHost
            wfh1.VerticalAlignment = Windows.VerticalAlignment.Stretch
            wfh1.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
            wfh1.Width = Double.NaN
            wfh1.Height = Double.NaN
            web2011.Dock = DockStyle.Fill
            wfh1.Child = web2011
            Dim gridd As New Grid
            gridd.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
            gridd.VerticalAlignment = Windows.VerticalAlignment.Stretch
            gridd.Width = Double.NaN
            gridd.Height = Double.NaN
            gridd.Background = Brushes.Lavender
            gridd.Children.Add(wfh1)
            Dim anas As New TabItem
            anas.Header = "TabItem"
            anas.Style = tabstyle
            TabControl_SWP.Items.Add(anas)
            anas.Content = gridd
            TabControl_SWP.SelectedIndex = count
            count = count + 1

            web2011.IsWebBrowserContextMenuEnabled = False
            web2011.ScriptErrorsSuppressed = False

            AddHandler web2011.ProgressChanged, AddressOf Loading
            AddHandler web2011.DocumentCompleted, AddressOf browse_done
            AddHandler web2011.Navigating, AddressOf browse_Nevigating
            AddHandler web2011.DocumentTitleChanged, AddressOf DocumentTitleChanged

        Catch ex As Exception
            MsgBox(ex.Message + " Button_Add_Tab_Click")
        End Try

    End Sub


    ' This sub for add tab item into tab control
    Public Sub Button_Add_Tab_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Try
            Dim tabstyle_Copy As TabItem = TabControl_SWP.SelectedItem
            tabstyle = tabstyle_Copy.Style
            ComboBox1.Text = ""
            Dim web2011 As New System.Windows.Forms.WebBrowser
            Dim wfh1 As New WindowsFormsHost
            wfh1.VerticalAlignment = Windows.VerticalAlignment.Stretch
            wfh1.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
            wfh1.Width = Double.NaN
            wfh1.Height = Double.NaN
            web2011.Dock = DockStyle.Fill
            wfh1.Child = web2011
            Dim gridd As New Grid
            gridd.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
            gridd.VerticalAlignment = Windows.VerticalAlignment.Stretch
            gridd.Width = Double.NaN
            gridd.Height = Double.NaN
            gridd.Background = Brushes.Lavender
            gridd.Children.Add(wfh1)
            Dim anas As New TabItem
            anas.Header = "TabItem"
            anas.Style = tabstyle
            TabControl_SWP.Items.Add(anas)
            anas.Content = gridd
            TabControl_SWP.SelectedIndex = count
            count = count + 1

            web2011.IsWebBrowserContextMenuEnabled = False
            web2011.ScriptErrorsSuppressed = False

            AddHandler web2011.ProgressChanged, AddressOf Loading
            AddHandler web2011.DocumentCompleted, AddressOf browse_done
            AddHandler web2011.Navigating, AddressOf browse_Nevigating
            AddHandler web2011.DocumentTitleChanged, AddressOf DocumentTitleChanged

        Catch ex As Exception
            MsgBox(ex.Message + " Button_Add_Tab_Click")
        End Try

    End Sub



    ' this sub for nevagation the url
    Private Sub Button_Nevigation_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Nevigation.Click


        Try

            con.Close()
            Dim cmd2 As New SqlCeCommand
            cmd2.Connection = con
            cmd2.CommandText = "Select count(Url) from Blocked_Page"
            con.Open()
            Dim dr1 As SqlCeDataReader = cmd2.ExecuteReader
            Dim x As Integer = 0
            dr1.Read()
            x = CInt(dr1(0))
            con.Close()


            con.Close()
            Dim cmd As New SqlCeCommand
            cmd.Connection = con
            cmd.CommandText = "Select Url from Blocked_Page"
            con.Open()
            Dim dr As SqlCeDataReader = cmd.ExecuteReader
            For i As Integer = 1 To x
                dr.Read()
                If ComboBox1.Text = dr(0).ToString Then
                    MsgBox("This Page Has Blocked", MsgBoxStyle.Exclamation)
                    Exit Sub
                End If
            Next
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message + "newww")
        End Try



        If ComboBox1.Text = "" Then
        ElseIf ComboBox1.Text.Contains(".com") = False Or ComboBox1.Text.Contains(".net") = False Then
            ComboBox1.Text = Trim(ComboBox1.Text) + ".com"
            Dim ss As TabItem = TabControl_SWP.SelectedItem
            Dim gridd As Grid = CType(ss.Content, Grid)
            Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
            vtypee = 2
            CType(wfhh.Child, System.Windows.Forms.WebBrowser).Navigate(ComboBox1.Text.ToString)
        Else
            Dim ss As TabItem = TabControl_SWP.SelectedItem
            Dim gridd As Grid = CType(ss.Content, Grid)
            Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
            vtypee = 2
            CType(wfhh.Child, System.Windows.Forms.WebBrowser).Navigate(ComboBox1.Text.ToString)
        End If

    End Sub


    'this sub for display the setting windows menu
    Private Sub Settings_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim sss As New Window2
        sss.Show()
    End Sub

    'this sub for delete bwebrowser history
    Private Sub Delete_Hostory_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)

        Try

            con.Close()
            Dim cmdd As New SqlCeCommand
            cmdd.Connection = con
            cmdd.CommandText = "DELETE FROM Search "
            con.Open()
            cmdd.ExecuteNonQuery()
            con.Close()

            con.Close()
            Dim sqlcom As New SqlCeCommand
            sqlcom.Connection = con
            sqlcom.CommandText = "DELETE FROM Downloads "
            con.Open()
            sqlcom.ExecuteNonQuery()
            con.Close()

            con.Close()
            Dim cmd As New SqlCeCommand
            cmd.Connection = con
            cmd.CommandText = "DELETE FROM Page WHERE ID not In (Select ID from Bookmark ) And ID not In (select ID from Blocked)"
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()

        Catch ex As Exception
            'MsgBox(ex.Message & " Delete_Hostory_Click")
        End Try

    End Sub


    'this sub for combobox search  text when prass the button start searching
    Private Sub Button_Search_Text_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Search_Text.Click


        If ComboBox_Search.Text <> "" Then
            vtypee = 2
            isSearch = True
            If ComboBox_Icon.SelectedIndex = 0 Then
                Dim tabstyle_Copy As TabItem = TabControl_SWP.SelectedItem
                tabstyle = tabstyle_Copy.Style
                ComboBox1.Text = ""
                Dim web2011 As New System.Windows.Forms.WebBrowser
                Dim wfh1 As New WindowsFormsHost
                wfh1.VerticalAlignment = Windows.VerticalAlignment.Stretch
                wfh1.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
                wfh1.Width = Double.NaN
                wfh1.Height = Double.NaN
                web2011.Dock = DockStyle.Fill
                wfh1.Child = web2011
                Dim gridd As New Grid
                gridd.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
                gridd.VerticalAlignment = Windows.VerticalAlignment.Stretch
                gridd.Width = Double.NaN
                gridd.Height = Double.NaN
                gridd.Background = Brushes.Lavender
                gridd.Children.Add(wfh1)
                Dim anas As New TabItem
                anas.Header = "TabItem"
                anas.Style = tabstyle
                TabControl_SWP.Items.Add(anas)
                anas.Content = gridd
                TabControl_SWP.SelectedIndex = count
                count = count + 1

                web2011.IsWebBrowserContextMenuEnabled = False
                web2011.ScriptErrorsSuppressed = False

                AddHandler web2011.ProgressChanged, AddressOf Loading
                AddHandler web2011.DocumentCompleted, AddressOf browse_done
                AddHandler web2011.Navigating, AddressOf browse_Nevigating
                AddHandler web2011.DocumentTitleChanged, AddressOf DocumentTitleChanged

                Dim ss As TabItem = TabControl_SWP.SelectedItem
                Dim Salm As Grid = CType(ss.Content, Grid)
                Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
                CType(wfhh.Child, System.Windows.Forms.WebBrowser).Navigate("http://www.google.com/search?hl=en&q=" & ComboBox_Search.Text & "&meta=")

            ElseIf ComboBox_Icon.SelectedIndex = 1 Then
                Dim tabstyle_Copy As TabItem = TabControl_SWP.SelectedItem
                tabstyle = tabstyle_Copy.Style
                ComboBox1.Text = ""
                Dim web2011 As New System.Windows.Forms.WebBrowser
                Dim wfh1 As New WindowsFormsHost
                wfh1.VerticalAlignment = Windows.VerticalAlignment.Stretch
                wfh1.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
                wfh1.Width = Double.NaN
                wfh1.Height = Double.NaN
                web2011.Dock = DockStyle.Fill
                wfh1.Child = web2011
                Dim gridd As New Grid
                gridd.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
                gridd.VerticalAlignment = Windows.VerticalAlignment.Stretch
                gridd.Width = Double.NaN
                gridd.Height = Double.NaN
                gridd.Background = Brushes.Lavender
                gridd.Children.Add(wfh1)
                Dim anas As New TabItem
                anas.Header = "TabItem"
                anas.Style = tabstyle
                TabControl_SWP.Items.Add(anas)
                anas.Content = gridd
                TabControl_SWP.SelectedIndex = count
                count = count + 1

                web2011.IsWebBrowserContextMenuEnabled = False
                web2011.ScriptErrorsSuppressed = False

                AddHandler web2011.ProgressChanged, AddressOf Loading
                AddHandler web2011.DocumentCompleted, AddressOf browse_done
                AddHandler web2011.Navigating, AddressOf browse_Nevigating
                AddHandler web2011.DocumentTitleChanged, AddressOf DocumentTitleChanged

                Dim ss As TabItem = TabControl_SWP.SelectedItem
                Dim Salm As Grid = CType(ss.Content, Grid)
                Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
                CType(wfhh.Child, System.Windows.Forms.WebBrowser).Navigate("http://au.search.yahoo.com/search?p=" & ComboBox_Search.Text & "&fr=yfp-t-501&ei=UTF-8")

            ElseIf ComboBox_Icon.SelectedIndex = 2 Then
                Dim tabstyle_Copy As TabItem = TabControl_SWP.SelectedItem
                tabstyle = tabstyle_Copy.Style
                ComboBox1.Text = ""
                Dim web2011 As New System.Windows.Forms.WebBrowser
                Dim wfh1 As New WindowsFormsHost
                wfh1.VerticalAlignment = Windows.VerticalAlignment.Stretch
                wfh1.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
                wfh1.Width = Double.NaN
                wfh1.Height = Double.NaN
                web2011.Dock = DockStyle.Fill
                wfh1.Child = web2011
                Dim gridd As New Grid
                gridd.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
                gridd.VerticalAlignment = Windows.VerticalAlignment.Stretch
                gridd.Width = Double.NaN
                gridd.Height = Double.NaN
                gridd.Background = Brushes.Lavender
                gridd.Children.Add(wfh1)
                Dim anas As New TabItem
                anas.Header = "TabItem"
                anas.Style = tabstyle
                TabControl_SWP.Items.Add(anas)
                anas.Content = gridd
                TabControl_SWP.SelectedIndex = count
                count = count + 1

                web2011.IsWebBrowserContextMenuEnabled = False
                web2011.ScriptErrorsSuppressed = False

                AddHandler web2011.ProgressChanged, AddressOf Loading
                AddHandler web2011.DocumentCompleted, AddressOf browse_done
                AddHandler web2011.Navigating, AddressOf browse_Nevigating
                AddHandler web2011.DocumentTitleChanged, AddressOf DocumentTitleChanged

                Dim ss As TabItem = TabControl_SWP.SelectedItem
                Dim Salm As Grid = CType(ss.Content, Grid)
                Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
                CType(wfhh.Child, System.Windows.Forms.WebBrowser).Navigate("http://www.bing.com/search?q=" & ComboBox_Search.Text & "&form=MSNH50&mkt=en-au&qs=n")

            ElseIf ComboBox_Icon.SelectedIndex = 3 Then
                Dim tabstyle_Copy As TabItem = TabControl_SWP.SelectedItem
                tabstyle = tabstyle_Copy.Style
                ComboBox1.Text = ""
                Dim web2011 As New System.Windows.Forms.WebBrowser
                Dim wfh1 As New WindowsFormsHost
                wfh1.VerticalAlignment = Windows.VerticalAlignment.Stretch
                wfh1.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
                wfh1.Width = Double.NaN
                wfh1.Height = Double.NaN
                web2011.Dock = DockStyle.Fill
                wfh1.Child = web2011
                Dim gridd As New Grid
                gridd.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
                gridd.VerticalAlignment = Windows.VerticalAlignment.Stretch
                gridd.Width = Double.NaN
                gridd.Height = Double.NaN
                gridd.Background = Brushes.Lavender
                gridd.Children.Add(wfh1)
                Dim anas As New TabItem
                anas.Header = "TabItem"
                anas.Style = tabstyle
                TabControl_SWP.Items.Add(anas)
                anas.Content = gridd
                TabControl_SWP.SelectedIndex = count
                count = count + 1

                web2011.IsWebBrowserContextMenuEnabled = False
                web2011.ScriptErrorsSuppressed = False

                AddHandler web2011.ProgressChanged, AddressOf Loading
                AddHandler web2011.DocumentCompleted, AddressOf browse_done
                AddHandler web2011.Navigating, AddressOf browse_Nevigating
                AddHandler web2011.DocumentTitleChanged, AddressOf DocumentTitleChanged

                Dim ss As TabItem = TabControl_SWP.SelectedItem
                Dim Salm As Grid = CType(ss.Content, Grid)
                Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
                CType(wfhh.Child, System.Windows.Forms.WebBrowser).Navigate("http://www.youtube.com/results?search_query=" & ComboBox_Search.Text & "&search_type=&aq=f")

            End If
            'ComboBox_Search.Text = ""
        End If

    End Sub


    'this sub for open pfd help file 
    Private Sub MenuItem_Help_Ar_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)

        '    'I can also open the pdf in web browser use nevigation

        '    'Dim path As String
        '    'path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase)
        '    'MessageBox.Show(path)

        System.Diagnostics.Process.Start(Directory.GetCurrentDirectory & "\Help_Arabic.pdf")
    End Sub

    'this sub for open pfd help file 
    Private Sub MenuItem_Help_En_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)

        System.Diagnostics.Process.Start(Directory.GetCurrentDirectory & "\Help_English.pdf")

    End Sub


    'this sub for view source code of web page
    Private Sub Source_Code_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)

        Try
            con.Close()
            Dim Anas1 As New SqlCeCommand
            Anas1.Connection = con
            Anas1.CommandText = "Select Url from Page where Url = '" & CStr(ComboBox1.Text) & "'"
            con.Open()
            Dim dr2 As SqlCeDataReader = Anas1.ExecuteReader
            dr2.Read()
            'If dr2.HasRows = True Then

            If ComboBox1.Text <> "" Then
                Dim ss As TabItem = TabControl_SWP.SelectedItem
                Dim gridd As Grid = CType(ss.Content, Grid)
                Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
                sourcee = (CType(wfhh.Child, System.Windows.Forms.WebBrowser).DocumentText.ToString)
                Dim sc As New Source
                sc.Show()

                'End If

            Else
                MsgBox("You have to load the page first", MsgBoxStyle.Exclamation)
            End If
            con.Close()

        Catch ex As Exception
            MsgBox(ex.Message + "Source_Code_Click")
        End Try

    End Sub

    'this sub for  display email window
    Private Sub Quick_E_mail_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim win As New Email
        win.Show()

    End Sub

    'this sub for download file
    Private Sub Download_File_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        If ComboBox1.Text = Nothing Then

        Else
            D_Address = ""
            PageUrl = ""
            Dim Down As New Download
            Down.Show()
        End If
    End Sub

    'this Sub for Menu item to view Library
    Private Sub Library_View_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)

        If Grid.GetColumnSpan(TabControl_SWP) = 2 Then
            Grid.SetColumnSpan(TabControl_SWP, 1)
            Grid_Library.Visibility = Visibility.Visible = True
            Grid_Tran.Visibility = Visibility.Visible = False
            ListBox_Library.Items.Clear()
            ComboBox_Search_lib.Items.Clear()
            Grid.SetRowSpan(ListBox_Library, 2)
            TextBox_Libra_Content.Text = ""

            Try
                ListBox_Library.Items.Clear()
                ComboBox_Search_lib.Items.Clear()
                con.Close()
                Dim cmd2 As New SqlCeCommand
                cmd2.Connection = con
                cmd2.CommandText = "SELECT count(ID) FROM category "
                con.Open()
                Dim dr1 As SqlCeDataReader = cmd2.ExecuteReader
                Dim x As Integer = 0
                dr1.Read()
                x = CInt(dr1(0))
                con.Close()
                con.Close()
                Dim cmd1 As New SqlCeCommand
                cmd1.Connection = con
                cmd1.CommandText = "select Cname  from category"
                con.Open()
                Dim dr As SqlCeDataReader = cmd1.ExecuteReader
                For i As Integer = 0 To x - 1
                    dr.Read()
                    ComboBox_Search_lib.Items.Add(dr(0).ToString)
                Next
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message & " Button_Library_Click")
            End Try

        Else
            Grid.SetColumnSpan(TabControl_SWP, 2)
            Grid_Library.Visibility = Visibility.Visible = False

        End If

    End Sub

    'this sub for swich the language combobox
    Private Sub Button_Swich_click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Try
            Dim X1 As Int16
            Dim X2 As Int16

            X1 = Me.ComboBox_From.SelectedIndex
            X2 = Me.ComboBox_To.SelectedIndex

            Me.ComboBox_From.SelectedIndex = X2
            Me.ComboBox_To.SelectedIndex = X1

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub


    'Private Sub browse_Nevigated(ByVal sender As Object, ByVal e As WebBrowserNavigatedEventArgs)
    '    MsgBox("browse_Nevigated")
    'End Sub

    'this sub for display the feedback windows

    'this sub for display feedback window

    'this sub for display the feedback window
    Private Sub MenuItem_Feedback_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim feedback As New Feedback1
        feedback.Show()
    End Sub

    'this sub for display the dowinload report window
    Private Sub MenuItem_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Try
            Dim INS As Boolean = True
            con.Close()
            Dim Anas1 As New SqlCeCommand
            Anas1.Connection = con
            Anas1.CommandText = "Select cout(ID) from Downloads"
            con.Open()
            Dim dr2 As SqlCeDataReader = Anas1.ExecuteReader
            dr2.Read()
            Dim n As Integer = dr2(0)
            If n <> 0 Then
                Dim downloadd As New Dowinloads_Report
                downloadd.Show()
            Else
                MsgBox("there is no downloads", MsgBoxStyle.Information)
            End If
            con.Close()
        Catch ex As Exception
            MsgBox(ex.Message + "  MenuItem_Click")
        End Try

    End Sub

    'this sub for display the most visited report window
    Private Sub MenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Try
            Dim INS As Boolean = True
            con.Close()
            Dim Anas1 As New SqlCeCommand
            Anas1.Connection = con
            Anas1.CommandText = "Select ID from Page"
            con.Open()
            Dim dr2 As SqlCeDataReader = Anas1.ExecuteReader
            dr2.Read()
            If dr2.HasRows = True Then
                Dim vist As New Most_visited
                vist.Show()
            Else
                MsgBox("there is no pages ", MsgBoxStyle.Information)
            End If
            con.Close()
        Catch ex As Exception

        End Try

    End Sub

    'this sub for display the browsing history window 
    Private Sub MenuItem_Click_2(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Try
            Dim INS As Boolean = True
            con.Close()
            Dim Anas1 As New SqlCeCommand
            Anas1.Connection = con
            Anas1.CommandText = "Select ID from Page"
            con.Open()
            Dim dr2 As SqlCeDataReader = Anas1.ExecuteReader
            dr2.Read()
            If dr2.HasRows = True Then
                Dim browsing As New SWB_History
                browsing.Show()
            Else
                MsgBox("there is no nevigating history", MsgBoxStyle.Information)
            End If
            con.Close()
        Catch ex As Exception

        End Try



    End Sub

    'this sub for display edit page window
    Private Sub Button_Edit_Page_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim editpage As New Edit_Page
        editpage.Show()
    End Sub


    'this sub for open page from library
    Private Sub Button_Open_Page_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs)
        Dim Page_Url As String = ""
        Try
            Page_Url = ListBox_Library.SelectedItem.ToString()
        Catch ex As Exception

        End Try


        If Page_Url = "" Then
            MsgBox("Select Page First")
        Else

            Dim tabstyle_Copy As TabItem = TabControl_SWP.SelectedItem
            tabstyle = tabstyle_Copy.Style
            ComboBox1.Text = ""
            Dim web2011 As New System.Windows.Forms.WebBrowser
            Dim wfh1 As New WindowsFormsHost
            wfh1.VerticalAlignment = Windows.VerticalAlignment.Stretch
            wfh1.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
            wfh1.Width = Double.NaN
            wfh1.Height = Double.NaN
            web2011.Dock = DockStyle.Fill
            wfh1.Child = web2011
            Dim gridd As New Grid
            gridd.HorizontalAlignment = Windows.HorizontalAlignment.Stretch
            gridd.VerticalAlignment = Windows.VerticalAlignment.Stretch
            gridd.Width = Double.NaN
            gridd.Height = Double.NaN
            gridd.Background = Brushes.Lavender
            gridd.Children.Add(wfh1)
            Dim anas As New TabItem
            anas.Header = "TabItem"
            anas.Style = tabstyle
            TabControl_SWP.Items.Add(anas)
            anas.Content = gridd
            TabControl_SWP.SelectedIndex = count
            count = count + 1

            web2011.IsWebBrowserContextMenuEnabled = False
            web2011.ScriptErrorsSuppressed = False

            AddHandler web2011.ProgressChanged, AddressOf Loading
            AddHandler web2011.DocumentCompleted, AddressOf browse_done
            AddHandler web2011.Navigating, AddressOf browse_Nevigating
            AddHandler web2011.DocumentTitleChanged, AddressOf DocumentTitleChanged

            Dim ss As TabItem = TabControl_SWP.SelectedItem
            Dim Salm As Grid = CType(ss.Content, Grid)
            Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
            vtypee = 1
            CType(wfhh.Child, System.Windows.Forms.WebBrowser).Navigate(Page_Url)
        End If



    End Sub


    'this sub for set page title
    Private Sub DocumentTitleChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim doc_title As String = ""

        Dim ss As TabItem = TabControl_SWP.SelectedItem
        Dim gridd As Grid = CType(ss.Content, Grid)
        Dim wfhh As WindowsFormsHost = CType(gridd.Children.Item(0), WindowsFormsHost)
        'StateLable.Content = CType(wfhh.Child, System.Windows.Forms.WebBrowser).StatusText
        'ss.Header = CType(wfhh.Child, System.Windows.Forms.WebBrowser).Document.Title

        Dim get_title As String = CType(wfhh.Child, System.Windows.Forms.WebBrowser).Document.Title

        If get_title.Length > 0 And get_title.Length < 21 Then
            ss.Header = get_title
            ss.ToolTip = get_title
        ElseIf get_title.Length > 20 Then

            doc_title = get_title.Substring(0, 20)
            doc_title = doc_title + "..."
            ss.Header = doc_title
            ss.ToolTip = get_title
        End If


    End Sub


    'this sub for delete page from library
    Private Sub Button_Edit_Page_Copy_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Edit_Page_Copy.Click
        Try

            If ListBox_Library.SelectedItem.ToString = "" Then
                MsgBox("Select the page first", MsgBoxStyle.Information)
            Else


                con.Close()
                Dim cmdd As New SqlCeCommand
                cmdd.Connection = con
                cmdd.CommandText = "Delete from Bookmark where ID = (select ID from Page where Url='" & ListBox_Library.SelectedItem.ToString & "')"
                con.Open()
                cmdd.ExecuteNonQuery()
                con.Close()



                con.Close()
                Dim cmd2 As New SqlCeCommand
                cmd2.Connection = con
                cmd2.CommandText = "Select count(Url) from Page where ID In (Select ID from Bookmark where Category In ( Select ID  from category Where Cname = '" & ComboBox_Search_lib.SelectedItem.ToString & "' ))"
                con.Open()
                Dim dr1 As SqlCeDataReader = cmd2.ExecuteReader
                Dim x As Integer = 0
                dr1.Read()
                x = CInt(dr1(0))
                con.Close()


                ListBox_Library.Items.Clear()
                con.Close()
                Dim cmd As New SqlCeCommand
                cmd.Connection = con
                cmd.CommandText = "Select Url from Page where ID In (Select ID from Bookmark where Category In ( Select ID  from category Where Cname = '" & ComboBox_Search_lib.SelectedItem.ToString & "' ))"
                con.Open()
                Dim dr As SqlCeDataReader = cmd.ExecuteReader
                For i As Integer = 1 To x
                    dr.Read()
                    ListBox_Library.Items.Add(dr(0).ToString)
                Next
                con.Close()


            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub MenuItem_Click_2(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs)
        'TODO: Add event handler implementation here.
    End Sub


End Class