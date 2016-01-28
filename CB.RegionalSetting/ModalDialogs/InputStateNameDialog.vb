Public Class InputStateNameDialog
    Public Property StateName As String

    Public Function ShowDialog() As Boolean
        Dim win As New InputStateNameWindow.MainWindow()
        If win.ShowDialog() = True
            StateName = win.StateName
            Return True
        End If
        Return False
    End Function
End Class