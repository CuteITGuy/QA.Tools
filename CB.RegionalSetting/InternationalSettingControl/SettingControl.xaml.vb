Imports System.Collections.ObjectModel
Imports InternationalSettingHandler

Public Class SettingControl
    Public Property SettingCategory As InternationalSettings
        Get
            Return GetValue(SettingCategoryProperty)
        End Get

        Set
            SetValue(SettingCategoryProperty, Value)
        End Set
    End Property

    Public Shared ReadOnly SettingCategoryProperty As DependencyProperty =
                               DependencyProperty.Register("SettingCategory",
                                                           GetType(InternationalSettings), GetType(SettingControl),
                                                           New PropertyMetadata(InternationalSettings.None,
                                                                                AddressOf SettingCategory_Changed))

    Public Property SettingValue As Object
        Get
            Return GetValue(SettingValueProperty)
        End Get

        Set
            SetValue(SettingValueProperty, value)
        End Set
    End Property

    Public Shared ReadOnly SettingValueProperty As DependencyProperty =
                               DependencyProperty.Register("SettingValue",
                                                           GetType(Object), GetType(SettingControl),
                                                           New PropertyMetadata(Nothing))


    Public Property SettingOptions As ObservableCollection(Of Object)
        Get
            Return GetValue(SettingOptionsProperty)
        End Get

        Set
            SetValue(SettingOptionsProperty, value)
        End Set
    End Property

    Public Shared ReadOnly SettingOptionsProperty As DependencyProperty =
                               DependencyProperty.Register("SettingOptions",
                                                           GetType(ObservableCollection(Of Object)), GetType(SettingControl),
                                                           New PropertyMetadata(New ObservableCollection(Of Object)))


    Public Custom Event SettingChanged As RoutedEventHandler

        AddHandler(value As RoutedEventHandler)
            [AddHandler](SettingChangedEvent, value)
        End AddHandler

        RemoveHandler(value As RoutedEventHandler)
            [RemoveHandler](SettingChangedEvent, value)
        End RemoveHandler

        RaiseEvent(sender As Object, e As RoutedEventArgs)
            [RaiseEvent](e)
        End RaiseEvent
    End Event

    Public Shared ReadOnly SettingChangedEvent As RoutedEvent =
                               EventManager.RegisterRoutedEvent("SettingChanged",
                                                                RoutingStrategy.Bubble,
                                                                GetType(RoutedEventHandler), GetType(SettingControl))

    Public Sub UpdateSettingValue()
        SettingValue = InternationalSettingManage.GetSettingValue(SettingCategory)
        AddSettingOption()
    End Sub

    Private Sub CmdSet_OnClick(sender As Object, e As RoutedEventArgs)
        InternationalSettingManage.SetSettingValue(SettingCategory, SettingValue)
        AddSettingOption()
        OnSettingChanged()
    End Sub

    Private Sub AddSettingOption()
        If Not SettingOptions.Contains(SettingValue) Then SettingOptions.Add(SettingValue)
    End Sub

    Private Shared Sub SettingCategory_Changed(d As DependencyObject, e As DependencyPropertyChangedEventArgs)
        Dim sc As SettingControl = d
        sc?.OnInternationSettingChanged()
    End Sub

    Private Sub OnSettingChanged()
        [RaiseEvent](New RoutedEventArgs(SettingChangedEvent, Me))
    End Sub

    Private Sub OnInternationSettingChanged()
        UpdateSettingValue()
    End Sub
End Class
