Public Class InternationalSettingState
    Public Property Name As String

    Public Property SettingValues As InternationalSettingKeyValuePair()

    Public Sub New(name As String, settingValues As InternationalSettingKeyValuePair())
        Me.Name = name
        Me.SettingValues = settingValues
    End Sub

    Public Sub New(name As String, settingValues As IDictionary(Of InternationalSettings,Object))
        Me.Name = name
        Me.SettingValues = settingValues.Select(Function(pair) New InternationalSettingKeyValuePair(pair))
    End Sub
End Class