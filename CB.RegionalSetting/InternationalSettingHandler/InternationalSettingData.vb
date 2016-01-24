Public Class InternationalSettingData
    Public Property RecentSettings As InternationalSettings()

    Public Property SettingOptions As InternationSettingOptions()

    Public Sub New()
    End Sub

    Public Sub New(recentSettings As ICollection(Of InternationalSettings),
                   settingOptions As IDictionary(Of InternationalSettings, ICollection(Of Object)))
        Me.RecentSettings = recentSettings.ToArray()
        Me.SettingOptions = settingOptions.Select(Function(pair) New InternationSettingOptions(pair.Key, pair.Value)).ToArray()
    End Sub
End Class