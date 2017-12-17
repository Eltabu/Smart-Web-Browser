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
Imports System.Data
Imports System.Data.SqlServerCe

Partial Public Class SWB_History
    Dim datee As Date
    Public WithEvents Datag As New System.Windows.Forms.DataGridView

    Public Sub New()
        MyBase.New()

        Me.InitializeComponent()

        ' Insert code required on object creation below this point.
    End Sub


    Private Sub Button_view_report_Click(ByVal sender As System.Object, ByVal e As System.Windows.RoutedEventArgs) Handles Button_view_report.Click
      
        Try

            Datag.Dock = DockStyle.Fill
            Datag.BackgroundColor = System.Drawing.Color.White
            Datag.AllowUserToAddRows = False
            Datag.AllowUserToDeleteRows = False
            WindowsFormsHost_History.Child = Datag


            If ComboBox_Storby.SelectedIndex = 0 Then

                con.Close()
                Dim comd As New SqlCeCommand
                Dim DT As New DataTable
                comd.Connection = con
                comd.CommandText = "EXEC History '" & CDate(datee) & "'"
                con.Open()
                Dim dr As SqlCeDataReader = comd.ExecuteReader
                DT.Load(dr)
                Datag.DataSource = DT
                dr.Close()
                con.Close()

            ElseIf ComboBox_Storby.SelectedIndex = 1 Then

                con.Close()
                Dim comd As New SqlCeCommand
                Dim DT As New DataTable
                comd.Connection = con
                comd.CommandText = "Select Page.Title,Page.Url ,Page.Vdate as [Last Visit Date],V_Type.Vtype as [Visit Type]   From Page, V_Type  Where Page.Vtype = V_Type.V_ID And  Vdate > '" & CDate(datee) & "' ORDER BY Vdate DESC;"
                con.Open()
                Dim dr As SqlCeDataReader = comd.ExecuteReader
                DT.Load(dr)
                Datag.DataSource = DT
                dr.Close()
                con.Close()

            End If

        Catch ex As Exception
            MsgBox(ex.Message + " Button_view_report_Click")
        End Try
    End Sub

    Private Sub SWB_History_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
   
    End Sub

    Private Sub ComboBox_From_Date_SelectionChanged(ByVal sender As Object, ByVal e As System.Windows.Controls.SelectionChangedEventArgs) Handles ComboBox_From_Date.SelectionChanged
        If ComboBox_From_Date.SelectedIndex = 0 Then
            datee = Now.Date.AddDays(-1)
            'MsgBox(datee.ToString)
        ElseIf ComboBox_From_Date.SelectedIndex = 1 Then
            datee = Now.Date.AddDays(-3)
            'MsgBox(datee.ToString)
        ElseIf ComboBox_From_Date.SelectedIndex = 2 Then
            datee = Now.Date.AddDays(-4)
            'MsgBox(datee.ToString)
        ElseIf ComboBox_From_Date.SelectedIndex = 3 Then
            datee = Now.Date.AddDays(-5)
            'MsgBox(datee.ToString)
        ElseIf ComboBox_From_Date.SelectedIndex = 4 Then
            datee = Now.Date.AddDays(-6)
            'MsgBox(datee.ToString)
        ElseIf ComboBox_From_Date.SelectedIndex = 5 Then
            datee = Now.Date.AddDays(-7)
            'MsgBox(datee.ToString)
        ElseIf ComboBox_From_Date.SelectedIndex = 6 Then
            datee = Now.Date.AddDays(-8)
            'MsgBox(datee.ToString)
        ElseIf ComboBox_From_Date.SelectedIndex = 7 Then
            datee = Now.Date.AddMonths(-1)
            'MsgBox(datee.ToString)
        ElseIf ComboBox_From_Date.SelectedIndex = 8 Then
            datee = Now.Date.AddYears(-5)
            'MsgBox(datee.ToString)
        End If
    End Sub
End Class
