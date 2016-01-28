Imports System.Collections.ObjectModel

Public Class InternationalSettingData
    Public Sub New()
    End Sub

    Public Sub New(recentSettings As ICollection(Of InternationalSettings),
                   settingOptions As IDictionary(Of InternationalSettings, ObservableCollection(Of Object)),
                   states As IDictionary(Of String, IDictionary(Of InternationalSettings, Object)))
        Me.RecentSettings = recentSettings.ToArray()
        Me.SettingOptions = settingOptions.Select(Function(pair) New InternationSettingOptions(pair.Key, pair.Value)).ToArray()
        Me.States = states.Select(Function(pair) New InternationalSettingState(pair.Key, pair.Value))
    End Sub


    Public Property RecentSettings As InternationalSettings()

    Public Property SettingOptions As InternationSettingOptions()

    Public Property States As InternationalSettingState()
End Class