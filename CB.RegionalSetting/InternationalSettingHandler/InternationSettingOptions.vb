Public Class InternationSettingOptions
    Public Sub New()
    End Sub

    Public Sub New(setting As InternationalSettings, options As ICollection(Of Object))
        Me.Setting = setting
        Me.Options = options.ToArray()
    End Sub

    Public Property Setting As InternationalSettings

    Public Property Options As Object()
End Class