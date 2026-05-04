Imports BibliotecaDeClasesProyecto

Public Class Form1
    Dim gestion As GestionAlumno
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim errorConexion As String = ""
        gestion = New GestionAlumno(errorConexion)
        If Not String.IsNullOrWhiteSpace(errorConexion) Then
            MessageBox.Show("Error al conectar a la base de datos: " & errorConexion)
        Else
            MessageBox.Show("Todo bien!")
        End If

        ''Cosas aqui que se hacen para probar cosas
        'Dim nombrePersona As String = "Alex"
        'Dim apellido1 As String = "Milagroso"
        'Dim apellido2 As String = "Jose"
        'Dim ciclo As String = "1º"
        'Dim aliasDelCurso As String = "Alias del Curso"
        'Dim nombreDelCurso As String = "DAM"
        'Dim nombreDelModulo As String = "Nombre Modulo"
        Dim dni As String = "1"
        'Dim descripcion As String = "Descripcion de RAS"
        'Dim aliasDelAlumno As String = "Alias del Alumno"

        'Dim ra As Integer = 1
        Dim duracion As Integer = 7
        'Dim codigoModulo As Integer = 1
        'Dim horastotales As Integer = 100

        Dim fechaDeJornada As Date = #4/23/2026#

        'MessageBox.Show(gestion.AñadirAlumno(dni, 1, "nombre", "apellido1", "apellido2", 1, "DES"))

        'MessageBox.Show(gestion.AñadirJornada(fechaDeJornada, dni, duracion))

        'MessageBox.Show(gestion.MostrarHorasDeAlumno("nombre"))

        MessageBox.Show(gestion.MostrarAlumnosYSusHorasTotalesDeUnCiclo(1).ToString)
        Dim resultado = gestion.MostrarAlumnosYSusHorasTotalesDeUnCiclo(1).GetType
        If (resultado = ArrayList) Then

        End If


    End Sub
    Private Sub btnParaAñadirAlumno_Click(sender As Object, e As EventArgs) Handles btnParaAñadirAlumno.Click
        Dim horas As Integer
        Dim ciclo As Integer
        Integer.TryParse(txtHorasTotales.Text, horas)
        Integer.TryParse(txtCiclo.Text, ciclo)
        MessageBox.Show(gestion.AñadirAlumno(txtDni.Text, horas, txtNombre.Text, txtApellido1.Text, txtApellido2.Text, ciclo, txtAlias.Text))
    End Sub
End Class
