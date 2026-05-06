Public Class Jornadas
    Public Property Duracion As Decimal
    Public Property Dni As String
    Public Property Fecha As Date

    Public Sub New(duracion As Decimal, dni As String, fecha As Date)
        Me.Duracion = duracion
        Me.Dni = dni
        Me.Fecha = fecha
    End Sub

End Class
