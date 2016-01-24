Imports InternationalSettingControl
Imports InternationalSettingHandler

Class MainWindow
    Private Const SAVED_SETTINGS_FILE = "SavedSetting.xml"
    Private Const MAX_RECENT_SETTINGS = 3
    Private Shared ReadOnly _settingSerializer As New InternationalSettingSerializer(SAVED_SETTINGS_FILE)

    Shared Sub New()
        _settingSerializer.Load()
    End Sub
    
    Protected Overrides Sub OnInitialized(e As EventArgs)
        MyBase.OnInitialized(e)
        InitializeAllControls()
        InitializeRecentControls()
    End Sub

    Protected Overrides Sub OnClosed(e As EventArgs)
        Dim recentSettings = From settingControl As SettingControl In ctnRecentControls.Children
                Select settingControl.SettingCategory
        SaveSettings(recentSettings.ToArray())
        MyBase.OnClosed(e)
    End Sub

    Private Sub CtnAllControls_OnSettingChanged(sender As Object, e As RoutedEventArgs)
        Dim settingControl As SettingControl = e.OriginalSource
        If IsNothing(settingControl) Then Return
        AddRecentSettingControl(settingControl.SettingCategory)
    End Sub

    Private Sub InitializeAllControls()
        AddSettingControls(ctnAllControls, [Enum].GetValues(GetType(InternationalSettings)))
    End Sub

    Private Sub InitializeRecentControls()
        AddSettingControls(ctnRecentControls, LoadRecentSettings())
    End Sub

    Private Shared Sub AddSettingControls(container As Panel, settings As IEnumerable(Of InternationalSettings))
        For Each setting In settings.Where(Function(s) s <> InternationalSettings.None)
            Dim settingControl As New SettingControl With {.SettingCategory = setting}
            settingControl.SettingOptions = _settingSerializer.SettingOptions(setting)
            container.Children.Add(settingControl)
        Next
    End Sub

    Private Sub AddRecentSettingControl(settingCategory As InternationalSettings)
        Dim recentSettingControls = ctnRecentControls.Children
        If recentSettingControls.OfType(Of SettingControl).Any(Function(c) c.SettingCategory = settingCategory) Then Return

        Dim settingControl As SettingControl
        If recentSettingControls.Count < MAX_RECENT_SETTINGS Then
            settingControl = New SettingControl()
        Else
            settingControl = recentSettingControls(MAX_RECENT_SETTINGS - 1)
            ctnRecentControls.Children.RemoveAt(MAX_RECENT_SETTINGS - 1)
        End If
        settingControl.SettingCategory = settingCategory
        recentSettingControls.Insert(0, settingControl)
    End Sub

    Private Shared Sub SaveSettings(settings As InternationalSettings())
        _settingSerializer.RecentSettings = settings
        _settingSerializer.Save()
    End Sub

    Private Shared Function LoadRecentSettings() As IEnumerable(Of InternationalSettings)
        Return _settingSerializer.RecentSettings
    End Function
End Class
