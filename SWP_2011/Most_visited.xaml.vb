Imports System
Imports System.IO
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation
Imports System.Windows.Forms
Imports System.Data.SqlServerCe
Imports System.Data

Partial Public Class Most_visited

    Dim text As Integer
    Dim datee As Date
    Public WithEvents Datag As New System.Windows.Forms.DataGridView
    Public Sub New()
        MyBase.New()

        Me.InitializeComponent()

        ' Insert code required on object creation below this point.
    End Sub


    Private Sub Most_visited_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        

    End Sub

    Private Sub ComboBox_datee_SelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles ComboBox_datee.SelectionChanged
        If ComboBox_datee.SelectedIndex = 0 Then
            datee = Now.Date.AddDays(-1)
            'MsgBox(datee.ToString)
        ElseIf ComboBox_datee.SelectedIndex = 1 Then
            datee = Now.Date.AddDays(-3)
            'MsgBox(datee.ToString)
        ElseIf ComboBox_datee.SelectedIndex = 2 Then
            datee = Now.Date.AddDays(-4)
            'MsgBox(datee.ToString)
        ElseIf ComboBox_datee.SelectedIndex = 3 Then
            datee = Now.Date.AddDays(-5)
            'MsgBox(datee.ToString)
        ElseIf ComboBox_datee.SelectedIndex = 4 Then
            datee = Now.Date.AddDays(-6)
            'MsgBox(datee.ToString)
        ElseIf ComboBox_datee.SelectedIndex = 5 Then
            datee = Now.Date.AddDays(-7)
            'MsgBox(datee.ToString)
        ElseIf ComboBox_datee.SelectedIndex = 6 Then
            datee = Now.Date.AddDays(-8)
            'MsgBox(datee.ToString)
        ElseIf ComboBox_datee.SelectedIndex = 7 Then
            datee = Now.Date.AddMonths(-1)
            'MsgBox(datee.ToString)
        ElseIf ComboBox_datee.SelectedIndex = 8 Then
            datee = Now.Date.AddYears(-5)
            'MsgBox(datee.ToString)
        End If
    End Sub

    Private Sub Button_view_report_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_view_report.Click
        Try

            Datag.Dock = DockStyle.Fill
            Datag.BackgroundColor = System.Drawing.Color.White
            Datag.AllowUserToAddRows = False
            Datag.AllowUserToDeleteRows = False
            WindowsFormsHost_Most_Visted.Child = Datag

            If TextBox__Top_N.Text = "" Then
                MsgBox("Enter number in the top text", MsgBoxStyle.Information)
            Else
                text = CInt(TextBox__Top_N.Text)
                'MsgBox(text.ToString, MsgBoxStyle.Information)

                con.Close()
                Dim comd As New SqlCeCommand
                Dim DT As New DataTable
                comd.Connection = con
                comd.CommandText = "EXEC MostVisited '" & CDate(datee) & "' , '" & text & "' "
                con.Open()
                Dim dr As SqlCeDataReader = comd.ExecuteReader
                DT.Load(dr)
                Datag.DataSource = DT
                dr.Close()
                con.Close()

            End If

        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try


    End Sub
End Class
