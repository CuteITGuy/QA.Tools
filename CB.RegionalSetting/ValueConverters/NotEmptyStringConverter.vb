Imports System.Globalization
Imports System.Windows
Imports System.Windows.Data

<ValueConversion(GetType(String), GetType(Boolean))>
Public Class NotEmptyStringConverter
    Implements IValueConverter

    Public Property TrueIfNotEmpty As Boolean = True

    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
        Dim s As String = value
        Return Not String.IsNullOrEmpty(s) Xor TrueIfNotEmpty
    End Function

    Public Function ConvertBack(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.ConvertBack
        Return DependencyProperty.UnsetValue
    End Function
End Class