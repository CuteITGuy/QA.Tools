Imports System.Collections.ObjectModel
Imports System.IO
Imports System.Xml.Serialization

Public Class InternationalSettingSerializer
    Public Sub New(filePath As String)
        Me.FilePath = filePath
        SettingOptions = New Dictionary(Of InternationalSettings,ObservableCollection(Of Object))()
        For Each setting In [Enum].GetValues(GetType(InternationalSettings)).OfType (Of InternationalSettings)
            SettingOptions(setting) = New ObservableCollection(Of Object)
        Next
    End Sub

    Public Property FilePath As String

    Public Property RecentSettings As ICollection(Of InternationalSettings) = New List(Of InternationalSettings)

    Public Property SettingOptions As IDictionary(Of InternationalSettings, ObservableCollection(Of Object))


    Public Sub Load()
        If Not File.Exists(FilePath) Then Return
        Dim ser = GetSerializer()
        Using reader As New StreamReader(FilePath)
            Dim data As InternationalSettingData = ser.Deserialize(reader)
            SetData(data)
        End Using
    End Sub

    Public Sub Save()
        Dim data As New InternationalSettingData(RecentSettings, SettingOptions)
        Dim ser = GetSerializer()
        Using writer As New StreamWriter(FilePath)
            ser.Serialize(writer, data)
        End Using
    End Sub

    Private Shared Function GetSerializer() As XmlSerializer
        Return New XmlSerializer(GetType(InternationalSettingData))
    End Function

    Private Sub SetData(data As InternationalSettingData)
        RecentSettings = data.RecentSettings.ToList()
        For Each options In data.SettingOptions
            SettingOptions(options.Setting) = New ObservableCollection(Of Object)(options.Options)
        Next
    End Sub
End Class