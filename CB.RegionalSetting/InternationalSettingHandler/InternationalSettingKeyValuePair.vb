Public Class InternationalSettingKeyValuePair
    Public Property Setting As InternationalSettings

    Public Property Value As Object


    Public Sub New()
    End Sub

    Public Sub New(setting As InternationalSettings, value As Object)
        Me.Setting = setting
        Me.Value = value
    End Sub

    Public Sub New(pair As KeyValuePair(Of InternationalSettings, Object))
        Setting = pair.Key
        Value = pair.Value
    End Sub
End Class