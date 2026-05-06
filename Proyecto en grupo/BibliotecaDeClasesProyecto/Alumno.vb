Public Class Alumno

    Public Property Dni As String
    Public Property HorasTotales As Integer
    Public Property Nombre As String
    Public Property Apellido1 As String
    Public Property Apellido2 As String
    Public Property Ciclo As Integer
    Public Property AliasDeBD As String

    Public Sub New(dni As String, horasTotales As Integer, nombre As String, apellido1 As String, apellido2 As String, ciclo As Integer, aliasDeBD As String)
        Me.Dni = dni
        Me.HorasTotales = horasTotales
        Me.Nombre = nombre
        Me.Apellido1 = apellido1
        Me.Apellido2 = apellido2
        Me.Ciclo = ciclo
        Me.AliasDeBD = aliasDeBD
    End Sub

End Class
