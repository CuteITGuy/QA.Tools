Imports System.Collections.ObjectModel
Imports ErrorTestDbContext


<ServiceContract>
Public Interface IErroNotificationService
    <OperationContract>
    Function GetError(id As Integer) As [Error]

    <OperationContract>
    Function GetErrors(Optional fromId As Integer = 0, Optional toId As Integer = Integer.MaxValue) As IEnumerable(Of [Error])
End Interface
