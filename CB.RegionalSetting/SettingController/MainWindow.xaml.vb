Imports InternationalSettingControl
Imports InternationalSettingHandler
Imports ModalDialogs

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

    Private Sub CmdSaveState_OnClick(sender As Object, e As RoutedEventArgs)
        Dim dialog As New InputStateNameDialog()
        If Not dialog.ShowDialog() Then Return

        AddSettingState(dialog.StateName)
    End Sub

    Private Sub SettingControls_OnSettingChanged(sender As Object, e As RoutedEventArgs)
        Dim settingControl As SettingControl = e.OriginalSource
        If IsNothing(settingControl) Then Return
        Dim setting As InternationalSettings = settingControl.SettingCategory
        AddRecentSettingControl(setting)
        UpdateSetting(setting)
    End Sub

    Private Sub UpdateSetting(setting As InternationalSettings)
        For Each settingControl In GetAllSettingControls().Where(Function(c) c.SettingCategory = setting)
            settingControl.UpdateSettingValue()
        Next
    End Sub

    Private Function GetAllSettingControls() As IEnumerable(Of SettingControl)
        Return ctnAllControls.Children.OfType (Of SettingControl).Concat(
            ctnRecentControls.Children.OfType (Of SettingControl))
    End Function

    Private Sub InitializeAllControls()
        AddSettingControls(ctnAllControls, [Enum].GetValues(GetType(InternationalSettings)))
    End Sub

    Private Sub InitializeRecentControls()
        AddSettingControls(ctnRecentControls, LoadRecentSettings())
    End Sub

    Private Shared Sub AddSettingControls(container As Panel, settings As IEnumerable(Of InternationalSettings))
        For Each setting In settings.Where(Function(s) s <> InternationalSettings.None)
            Dim settingControl As New SettingControl()
            SetInternalSettingInfo(settingControl, setting)
            container.Children.Add(settingControl)
        Next
    End Sub

    Private Shared Sub SetInternalSettingInfo(settingControl As SettingControl, settingCategory As InternationalSettings)
        settingControl.SettingOptions = _settingSerializer.SettingOptions(settingCategory)
        settingControl.SettingCategory = settingCategory
    End Sub

    Private Sub AddRecentSettingControl(settingCategory As InternationalSettings)
        Dim recentSettingControls = ctnRecentControls.Children
        If recentSettingControls.OfType (Of SettingControl).Any(Function(c) c.SettingCategory = settingCategory) Then _
            Return

        Dim settingControl As SettingControl
        If recentSettingControls.Count < MAX_RECENT_SETTINGS Then
            settingControl = New SettingControl()
        Else
            settingControl = recentSettingControls(MAX_RECENT_SETTINGS - 1)
            ctnRecentControls.Children.RemoveAt(MAX_RECENT_SETTINGS - 1)
        End If
        SetInternalSettingInfo(settingControl, settingCategory)
        recentSettingControls.Insert(0, settingControl)
    End Sub

    Private Shared Sub SaveSettings(settings As InternationalSettings())
        _settingSerializer.RecentSettings = settings
        _settingSerializer.Save()
    End Sub

    Private Shared Sub AddSettingState(stateName As String)
        _settingSerializer.States(stateName) = InternationalSettingManage.GetCurrentSettingState()
    End Sub

    Private Shared Function LoadRecentSettings() As IEnumerable(Of InternationalSettings)
        Return _settingSerializer.RecentSettings
    End Function
End Class


'TODO: Choose setting state
'TODO: Reset feature
'TODO: Button hide
'TODO: NotifyIcon