Imports System
Imports System.IO
Imports System.Net
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Media.Animation
Imports System.Windows.Navigation

Partial Public Class Source
	Public Sub New()
		MyBase.New()

		Me.InitializeComponent()

		' Insert code required on object creation below this point.
	End Sub

    Private Sub Source_Loaded(ByVal sender As Object, ByVal e As System.Windows.RoutedEventArgs) Handles Me.Loaded
        RichTextBox_Source.AppendText(sourcee)
    End Sub
End Class
