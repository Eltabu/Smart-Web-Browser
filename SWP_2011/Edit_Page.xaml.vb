Imports System
Imports System.IO
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation
Imports System.Data.SqlServerCe

Partial Public Class Edit_Page
    Dim DescraptionBefor As String
    Dim isok As Boolean = False

    Public Sub New()
        MyBase.New()

        Me.InitializeComponent()

        ' Insert code required on object creation below this point.
    End Sub

    Private Sub Edit_Page_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        TextBox_Descraption.IsEnabled = False
        Try

            ComboBox_category.Items.Clear()
            ComboBox_category1.Items.Clear()
            ListBox_category.Items.Clear()
            ListBox_category1.Items.Clear()

            con.Close()
            Dim cmd2 As New SqlCeCommand
            cmd2.Connection = con
            cmd2.CommandText = "Select count(Cname) from category "
            con.Open()
            Dim dr1 As SqlCeDataReader = cmd2.ExecuteReader
            If dr1.HasRows = True Then
                Dim x As Integer = 0
                dr1.Read()
                x = CInt(dr1(0))
                con.Close()

                con.Close()
                Dim cmd As New SqlCeCommand
                cmd.Connection = con
                cmd.CommandText = "Select Cname from category"
                con.Open()
                Dim dr2 As SqlCeDataReader = cmd.ExecuteReader
                For i As Integer = 1 To x
                    dr2.Read()
                    ComboBox_category.Items.Add(dr2(0).ToString)
                    ComboBox_category1.Items.Add(dr2(0).ToString)
                Next
                con.Close()

                'filllist(ListBox_category, ComboBox_category)
                'filllist(ListBox_category1, ComboBox_category1)

            Else
                MsgBox("There is no category in the bookmark ", MsgBoxStyle.Information)
                Me.Close()
            End If


        Catch ex As Exception
            'MsgBox(ex.Message + "  Edit_Page_Loaded")
        End Try


    End Sub

    Public Sub filllist(ByVal listbox_name As Object, ByVal combobox_name As Object)

        Try
            con.Close()
            Dim cmd2 As New SqlCeCommand
            cmd2.Connection = con
            cmd2.CommandText = "Select count(Url) from Page where ID In (Select ID from Bookmark where Category In ( Select ID  from category Where Cname = '" & combobox_name.SelectedItem.ToString & "' ))"
            con.Open()
            Dim dr1 As SqlCeDataReader = cmd2.ExecuteReader
            Dim x As Integer = 0
            dr1.Read()
            x = CInt(dr1(0))
            con.Close()


            listbox_name.Items.Clear()
            con.Close()
            Dim cmd As New SqlCeCommand
            cmd.Connection = con
            cmd.CommandText = "Select Url from Page where ID In (Select ID from Bookmark where Category In ( Select ID  from category Where Cname = '" & combobox_name.SelectedItem.ToString & "' ))"
            con.Open()
            Dim dr As SqlCeDataReader = cmd.ExecuteReader
            For i As Integer = 1 To x
                dr.Read()
                listbox_name.Items.Add(dr(0).ToString)
            Next
            con.Close()

        Catch ex As Exception
            'MsgBox(ex.Message & "filllist")
        End Try


    End Sub



    Private Sub ListBox_category_LostFocus(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles ListBox_category.LostFocus
        'DescraptionBefor = CStr(TextBox_Descraption.Text)
        'TextBox_Descraption.Text = ""
    End Sub

    Private Sub ListBox_category1_LostFocus(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles ListBox_category1.LostFocus
        'DescraptionBefor = CStr(TextBox_Descraption.Text)
        'TextBox_Descraption.Text = ""
    End Sub

    Private Sub ListBox_category_SelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles ListBox_category.SelectionChanged

        Try
            con.Close()
            Dim cmd As New SqlCeCommand
            cmd.Connection = con
            cmd.CommandText = " SELECT Bookmark.Description FROM Page, Bookmark WHERE Page.ID = Bookmark.ID  AND Page.Url= '" & ListBox_category.SelectedItem.ToString & "'"
            con.Open()
            Dim da As SqlCeDataReader = cmd.ExecuteReader
            da.Read()
            TextBox_Descraption.Text = da(0)
            con.Close()
        Catch ex As Exception
            'MsgBox(ex.Message & " ListBox_category_SelectionChanged")
        End Try
    End Sub

    Private Sub ListBox_category1_SelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles ListBox_category1.SelectionChanged
        Try
            con.Close()
            Dim cmd As New SqlCeCommand
            cmd.Connection = con
            cmd.CommandText = " SELECT Bookmark.Description FROM Page, Bookmark WHERE Page.ID = Bookmark.ID  AND Page.Url= '" & ListBox_category1.SelectedItem.ToString & "'"
            con.Open()
            Dim da As SqlCeDataReader = cmd.ExecuteReader
            da.Read()
            TextBox_Descraption.Text = da(0)
            con.Close()
        Catch ex As Exception
            'MsgBox(ex.Message & " ListBox_category1_SelectionChanged")
        End Try
    End Sub



    Private Sub ComboBox_category_SelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles ComboBox_category.SelectionChanged
        filllist(ListBox_category, ComboBox_category)
    End Sub


    Private Sub ComboBox_category1_SelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles ComboBox_category1.SelectionChanged
        filllist(ListBox_category1, ComboBox_category1)
    End Sub



    Private Sub Button_Move11_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Move11.Click

        If ComboBox_category.SelectedIndex = -1 Or ComboBox_category1.SelectedIndex = -1 Then
            MsgBox("Select the category first ", MsgBoxStyle.Information)
        ElseIf ListBox_category1.SelectedItems.Count = 0 Or ListBox_category1.SelectedItems.Count > 1 Then
            MsgBox("Select the  page to complete the operation", MsgBoxStyle.Information)
        Else
            Dim pagee As String = ListBox_category1.SelectedItem.ToString

            con.Close()
            Dim cmd2 As New SqlCeCommand
            cmd2.Connection = con
            cmd2.CommandText = "Select ID from dbo.Page where Url='" & pagee & "'"
            con.Open()
            Dim dr1 As SqlCeDataReader = cmd2.ExecuteReader
            dr1.Read()
            Dim PID As Integer = CInt(dr1(0))
            con.Close()


            con.Close()
            Dim cmd As New SqlCeCommand
            cmd.Connection = con
            cmd.CommandText = "Select ID from category Where Cname = '" & ComboBox_category.SelectedItem.ToString & "'"
            con.Open()
            Dim dr2 As SqlCeDataReader = cmd.ExecuteReader
            dr2.Read()
            Dim CID As Integer = dr2(0)
            'MsgBox(CID.ToString & pagee & PID)
            con.Close()


            con.Close()
            Dim cmd1 As New SqlCeCommand
            cmd1.CommandText = "UPDATE dbo.Bookmark SET Category ='" & CID & "'  WHERE ID = '" & PID & "' "
            cmd1.Connection = con
            con.Open()
            cmd1.ExecuteNonQuery()
            con.Close()
            filllist(ListBox_category, ComboBox_category)
            filllist(ListBox_category1, ComboBox_category1)
        End If

    End Sub


 
    Private Sub Button_Edit_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Edit.Click
        DescraptionBefor = CStr(TextBox_Descraption.Text)
        TextBox_Descraption.IsEnabled = True
        'TextBox_Descraption.Text = ""
        isok = True
    End Sub

    Private Sub Button_Apply_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Apply.Click
        Try
            If isok = False Then
                MsgBox("Select the page to Show Descraption", MsgBoxStyle.Information)
            ElseIf TextBox_Descraption.Text = "" Then
                MsgBox("Enter the Descraption", MsgBoxStyle.Information)
            Else
                'MsgBox(DescraptionBefor)
                con.Close()
                Dim cmd1 As New SqlCeCommand
                cmd1.CommandText = "UPDATE dbo.Bookmark SET Description ='" & TextBox_Descraption.Text & "'  WHERE Description = '" & DescraptionBefor & "' "
                cmd1.Connection = con
                con.Open()
                cmd1.ExecuteNonQuery()
                con.Close()
                isok = False
                TextBox_Descraption.IsEnabled = False
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
       
    End Sub

    Private Sub Button_Close_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_Close.Click
        Me.Close()
    End Sub
End Class
