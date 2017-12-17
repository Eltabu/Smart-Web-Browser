Imports System
Imports System.IO
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Data.SqlServerCe
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation
Imports System.Data
Imports System.Windows.Forms

Partial Public Class Dowinloads_Report
    Dim storby As String = ""
    Dim datee As Date
    Public WithEvents Datag As New System.Windows.Forms.DataGridView

    Private Sub Button_view_report_down_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_view_report_down.Click

        Try

            Datag.Dock = DockStyle.Fill
            Datag.BackgroundColor = System.Drawing.Color.White
            Datag.AllowUserToAddRows = False
            Datag.AllowUserToDeleteRows = False
            WindowsFormsHost_Data.Child = Datag

            If storby = "Date" Then

                con.Close()
                Dim comd As New SqlCeCommand
                Dim DT As New DataTable
                comd.Connection = con
                comd.CommandText = "EXEC downloadreport '" & CDate(datee) & "'"
                con.Open()
                Dim dr As SqlCeDataReader = comd.ExecuteReader
                DT.Load(dr)
                Datag.DataSource = DT
                dr.Close()
                con.Close()
            ElseIf storby = "FileType" Then

                con.Close()
                Dim comd As New SqlCeCommand
                Dim DT As New DataTable
                comd.Connection = con
                comd.CommandText = "EXEC downloadreport1 '" & CDate(datee) & "'"
                con.Open()
                Dim dr As SqlCeDataReader = comd.ExecuteReader
                DT.Load(dr)
                Datag.DataSource = DT
                dr.Close()
                con.Close()
                MsgBox("")
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub


    Private Sub ComboBox_Date_SelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles ComboBox_Date.SelectionChanged

        If ComboBox_Date.SelectedIndex = 0 Then
            datee = Now.Date.AddDays(-1)

        ElseIf ComboBox_Date.SelectedIndex = 1 Then
            datee = Now.Date.AddDays(-3)

        ElseIf ComboBox_Date.SelectedIndex = 2 Then
            datee = Now.Date.AddDays(-4)

        ElseIf ComboBox_Date.SelectedIndex = 3 Then
            datee = Now.Date.AddDays(-5)

        ElseIf ComboBox_Date.SelectedIndex = 4 Then
            datee = Now.Date.AddDays(-6)

        ElseIf ComboBox_Date.SelectedIndex = 5 Then
            datee = Now.Date.AddDays(-7)

        ElseIf ComboBox_Date.SelectedIndex = 6 Then
            datee = Now.Date.AddDays(-8)

        ElseIf ComboBox_Date.SelectedIndex = 7 Then
            datee = Now.Date.AddMonths(-1)

        ElseIf ComboBox_Date.SelectedIndex = 8 Then
            datee = Now.Date.AddYears(-5)

        End If
    End Sub

    Private Sub ComboBox_Storby_SelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles ComboBox_Storby.SelectionChanged
        If ComboBox_Storby.SelectedIndex = 0 Then
            storby = "Date"
        ElseIf ComboBox_Storby.SelectedIndex = 1 Then
            storby = "FileType"
        End If
    End Sub

    Private Sub Dowinloads_Report_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
     

    End Sub
End Class
