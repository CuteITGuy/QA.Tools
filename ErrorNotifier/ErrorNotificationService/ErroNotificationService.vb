Imports ErrorTestDbContext

Public Class ErroNotificationService
    Implements IErroNotificationService

    Private ReadOnly _errorTestContext As New ErrorTestEntities()

    Public Function GetError(id As Integer) As [Error] Implements IErroNotificationService.GetError
        Dim result = _errorTestContext.GetError_ById(id)
        Return result?.FirstOrDefault()
    End Function

    Public Function GetErrors(Optional fromId As Integer = 0, Optional toId As  Integer = Integer.MaxValue) As IEnumerable(Of [Error]) Implements IErroNotificationService.GetErrors
        Return _errorTestContext?.ListErrors(fromId, toId)
    End Function
End Class
