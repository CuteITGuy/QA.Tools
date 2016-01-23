﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated from a template.
'
'     Manual changes to this file may cause unexpected behavior in your application.
'     Manual changes to this file will be overwritten if the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Imports System
Imports System.Data.Entity
Imports System.Data.Entity.Infrastructure
Imports System.Data.Entity.Core.Objects
Imports System.Linq

Partial Public Class ErrorTestEntities
    Inherits DbContext

    Public Sub New()
        MyBase.New("name=ErrorTestEntities")
    End Sub

    Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        Throw New UnintentionalCodeFirstException()
    End Sub

    Public Overridable Property Errors() As DbSet(Of [Error])

    Public Overridable Function InsertError(name As String, description As String, createdTime As Nullable(Of Date)) As Integer
        Dim nameParameter As ObjectParameter = If(name IsNot Nothing, New ObjectParameter("Name", name), New ObjectParameter("Name", GetType(String)))

        Dim descriptionParameter As ObjectParameter = If(description IsNot Nothing, New ObjectParameter("Description", description), New ObjectParameter("Description", GetType(String)))

        Dim createdTimeParameter As ObjectParameter = If(createdTime.HasValue, New ObjectParameter("CreatedTime", createdTime), New ObjectParameter("CreatedTime", GetType(Date)))

        Return DirectCast(Me, IObjectContextAdapter).ObjectContext.ExecuteFunction("InsertError", nameParameter, descriptionParameter, createdTimeParameter)
    End Function

End Class
