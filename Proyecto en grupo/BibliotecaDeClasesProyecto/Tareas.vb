Public Class Tareas
    Public Property CodigoTarea As Integer
    Public Property FechaJornada As Date
    Public Property Dni As String
    Public Property Descripcion As String
    Public Property Duracion As Integer

    Public Sub New(codigoTarea As Integer, fechaJornada As Date, dni As String, descripcion As String, duracion As Decimal)
        Me.CodigoTarea = codigoTarea
        Me.FechaJornada = fechaJornada
        Me.Dni = dni
        Me.Descripcion = descripcion
        Me.Duracion = duracion
    End Sub
End Class
