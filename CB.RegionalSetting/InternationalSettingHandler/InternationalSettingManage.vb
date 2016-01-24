Imports Microsoft.Win32

Public Class InternationalSettingManage
    Private Const REGISTRY_PATH = "Control Panel\International"

    Public Shared Function GetSettingNames() As String()

        Using key = GetRegistryKey()
            Return key.GetValueNames()
        End Using
    End Function

    Public Shared Function GetSettingValue(setting As InternationalSettings) As Object
        Return GetSettingValue(setting.ToString())
    End Function

    Public Shared Function GetSettingValue(settingName As String) As Object
        Dim result As Object = Nothing
        UseRegistryKey(Sub(key) result = key.GetValue(settingName, Nothing))
        Return result
    End Function

    Public Shared Sub SetSettingValue(setting As InternationalSettings, settingValue As Object)
        If setting = InternationalSettings.None Then Return
        SetSettingValue(setting.ToString(), settingValue)
    End Sub

    Public Shared Sub SetSettingValue(settingName As String, settingValue As Object)
        UseRegistryKey(Sub(key) key.SetValue(settingName, settingValue))
    End Sub

    Private Shared Function GetRegistryKey() As RegistryKey
        Return Registry.CurrentUser.OpenSubKey(REGISTRY_PATH, RegistryKeyPermissionCheck.ReadWriteSubTree)
    End Function

    Private Shared Sub UseRegistryKey(action As Action(Of RegistryKey))
        Using key = GetRegistryKey()
            action(key)
        End Using
    End Sub
End Class