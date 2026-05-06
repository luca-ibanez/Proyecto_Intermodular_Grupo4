Imports System.Data.SqlClient
Imports System.Net
Imports System.Runtime.ConstrainedExecution

Public Class GestionAlumno
    Private cadenaConexion As String

    Public Sub New(ByRef errorConexion As String)
        Dim servidor As String = MiServidor.Servidor(errorConexion)
        Dim NombreDeBaseDeDatos = "Grupo4"
        cadenaConexion = $"Data Source={servidor};Initial Catalog={NombreDeBaseDeDatos};Integrated Security=True"
    End Sub

    Public Function AñadirAlumno(dni As String, horasTotales As Integer, nombre As String, apellido1 As String, apellido2 As String, ciclo As Integer, aliasDeBD As String) As String

        Dim mensaje As String = ""
        If ComprobarNoAlumnoRepetido(dni, mensaje) = True Then
            If String.IsNullOrWhiteSpace(mensaje) = False Then
                Return mensaje
            Else
                Return "Ya hay un alumno con ese DNI"
            End If
        End If

        Dim conexion As New SqlConnection(cadenaConexion)
        Dim alumno As New Alumno(dni, horasTotales, nombre, apellido1, apellido2, ciclo, aliasDeBD)
        Dim dniAPasar As String = alumno.Dni
        Dim horasAPasar As Integer = alumno.HorasTotales
        Dim nombreAPasar As String = alumno.Nombre
        Dim apellido1APasar As String = alumno.Apellido1
        Dim apellido2APasar As String = alumno.Apellido2
        Dim cicloAPasar As String = alumno.Ciclo
        Dim aliasDeBDAPasar As String = alumno.AliasDeBD
        Dim lineaComando As String = "INSERT INTO ALUMNOS(DNI, HORASTOTALES, NOMBRE, [APELLIDO 1], [APELLIDO 2], CICLO, ALIAS) VALUES (@dni, @horasTotales, @nombre, @apellido1, @apellido2, @ciclo, @alias)"
        Dim crear As New SqlCommand(lineaComando, conexion)

        crear.Parameters.AddWithValue("@dni", dniAPasar)
        crear.Parameters.AddWithValue("@horasTotales", horasAPasar)
        crear.Parameters.AddWithValue("@nombre", nombreAPasar)
        crear.Parameters.AddWithValue("@apellido1", apellido1APasar)
        crear.Parameters.AddWithValue("@apellido2", apellido2APasar)
        crear.Parameters.AddWithValue("@ciclo", cicloAPasar)
        crear.Parameters.AddWithValue("@alias", aliasDeBDAPasar)

        Try
            conexion.Open()
            crear.ExecuteNonQuery()
        Catch ex As Exception
            Return "Error del insertar un alumno: " & ex.Message
        Finally
            conexion.Close()
        End Try
        Return "Insertado"
    End Function

    Public Function ComprobarNoAlumnoRepetido(dni As String, ByRef mensaje As String) As Boolean
        Dim conexion As New SqlConnection(cadenaConexion)
        Dim dniAPasar As String = dni
        Dim lineaComando As String = "SELECT DNI FROM ALUMNOS WHERE DNI = @dni"
        Dim personasConEseDNI As SqlDataReader

        Dim comprobar As New SqlCommand(lineaComando, conexion)

        comprobar.Parameters.AddWithValue("@dni", dniAPasar)

        Try
            conexion.Open()
            personasConEseDNI = comprobar.ExecuteReader()
            Return personasConEseDNI.HasRows
        Catch ex As Exception
            mensaje = "Error del comprobar alumno repetido: " & ex.Message
        Finally
            conexion.Close()
        End Try

        Return True

    End Function

    'Hacer una para que se pueda añadir las tareas de una persona y tambien mostrar las horas totales que han hecho en total solo uno o otra persona?

    Public Function AñadirJornada(fecha As Date, dni As String, duracion As Integer) As String
        Dim mensaje As String = ""
        If ComprobarJornadaRepetida(fecha, dni, mensaje) = True Then
            If String.IsNullOrWhiteSpace(mensaje) = False Then
                Return mensaje
            Else
                Return "Ya hay una jornada en ese dia con ese DNI"
            End If
        End If

        Dim conexion As New SqlConnection(cadenaConexion)
        Dim fechaAPasar As Date = fecha
        Dim dniAPasar As String = dni
        Dim duracionAPasar As Integer = duracion
        Dim lineaComando As String = "INSERT INTO JORNADAS(FECHA, DNI, DURACION) VALUES (@fecha, @dni, @duracion)"
        Dim crear As New SqlCommand(lineaComando, conexion)

        crear.Parameters.AddWithValue("@fecha", fechaAPasar)
        crear.Parameters.AddWithValue("@dni", dniAPasar)
        crear.Parameters.AddWithValue("@duracion", duracionAPasar)

        Try
            conexion.Open()
            crear.ExecuteNonQuery()
        Catch ex As Exception
            Return "Error del añadir jornada: " & ex.Message
        Finally
            conexion.Close()
        End Try

        Return "Insertado"
    End Function


    Public Function ComprobarJornadaRepetida(fecha As Date, dni As String, ByRef mensaje As String) As Boolean
        Dim conexion As New SqlConnection(cadenaConexion)
        Dim fechaAPasar As Date = fecha
        Dim dniAPasar As String = dni
        Dim lineaComando As String = "SELECT FECHA, DNI FROM JORNADAS WHERE FECHA = @fecha AND DNI = @dni"
        Dim comprobar As New SqlCommand(lineaComando, conexion)
        Dim tareasConEseDNIYFecha As SqlDataReader

        comprobar.Parameters.AddWithValue("@fecha", fechaAPasar)
        comprobar.Parameters.AddWithValue("@dni", dniAPasar)

        Try
            conexion.Open()
            tareasConEseDNIYFecha = comprobar.ExecuteReader()
            Return tareasConEseDNIYFecha.HasRows
        Catch ex As Exception
            mensaje = "Error del comprobar jornada repetida: " & ex.Message
        Finally
            conexion.Close()
        End Try

        Return True
    End Function

    ''Hacer una funcion que muestre las horas de un alumno y otro que muestre desde una clase todos sus alumnos y horas

    ''Notas: Cuando solo quieres buscar un solo dato, usas ExecuteScalar() ya que solo devuelve un solo dato
    Public Function MostrarHorasDeAlumno(nombreAlumno As String)
        Dim conexion As New SqlConnection(cadenaConexion)
        Dim alumnoAPasar As String = nombreAlumno
        Dim lineaComando As String = "SELECT ALUMNOS.HORASTOTALES FROM ALUMNOS WHERE NOMBRE = @nombre"
        Dim buscarAlumno As New SqlCommand(lineaComando, conexion)

        buscarAlumno.Parameters.AddWithValue("@nombre", alumnoAPasar)

        Try
            conexion.Open()
            Dim resultado As Integer = buscarAlumno.ExecuteScalar()
            Return resultado.ToString
        Catch ex As Exception
            Return "Error al mirar las horas de un alumno: " & ex.Message
        Finally
            conexion.Close()
        End Try

    End Function

    Public Function MostrarAlumnosYSusHorasTotalesDeUnCiclo(ciclo As Integer)
        Dim conexion As New SqlConnection(cadenaConexion)
        Dim cicloAPasar As String = ciclo
        Dim lineaComando As String = "SELECT ALUMNOS.NOMBRE, JORNADAS.DURACION FROM ALUMNOS INNER JOIN JORNADAS ON ALUMNOS.DNI=JORNADAS.DNI WHERE CICLO = @ciclo"
        Dim buscarAlumnosYSusHoras As New SqlCommand(lineaComando, conexion)
        Dim arrayDeAlumnosYsusHoras As ArrayList
        arrayDeAlumnosYsusHoras = New ArrayList

        buscarAlumnosYSusHoras.Parameters.AddWithValue("@ciclo", cicloAPasar)

        Try
            conexion.Open()
            Dim resultados As SqlDataReader
            resultados = buscarAlumnosYSusHoras.ExecuteReader()
            While resultados.Read
                arrayDeAlumnosYsusHoras.Add(resultados.Read)
            End While
            Return arrayDeAlumnosYsusHoras ''Esto devuelve un arrayList
        Catch ex As Exception
            Return "Error al intentar mostrar los alumnos de un ciclo y sus horas totales: " + ex.Message
        Finally
            conexion.Close()

        End Try

    End Function

    ''Hay que hacer un delete tablas con todo, y recordar reiniciar todos los valores autonumericos para que no esten incorrectos.
    Public Function eliminarAlumnos(dni As String) As String
        Dim conexion As New SqlConnection(cadenaConexion)
        Dim dniAPasar As String = dni
        Dim lineaComando As String = "DELETE ALUMNOS.* FROM ALUMNOS WHERE DNI = @dni"
        Dim eliminar As New SqlCommand(lineaComando, conexion)

        eliminar.Parameters.AddWithValue("@dni", dniAPasar)


        Try
            conexion.Open()
            eliminar.ExecuteNonQuery()
        Catch ex As Exception
            Return "Error al intentar borrar un alumno: " & ex.Message
        Finally
            conexion.Close()
        End Try


    End Function


    ''Ahora esto es sobre añadir la tarea
    Public Function AñadirTarea(codigo As Integer, fecha As Date, dni As String, descripcion As String, duracion As Decimal) As String
        ''Chequear que no se pase de horas
        If (duracion > 8) Then
            Return "¡No puedes realizar mas de 8 horas!"
        End If

        Dim conexion As New SqlConnection(cadenaConexion)
        Dim codigoAPasar = codigo
        Dim fechaAPasar = fecha
        Dim dniAPasar = dni
        Dim descripcionAPasar = descripcion
        Dim duracionAPasar = duracion


        Dim lineaComando As String = "INSERT INTO TAREASREALIZADAS(CODIGOTAREA, FECHAJORNADA, DNI, DESCRIPCION, DURACION) VALUES (@codTarea, @fecha, @dni, @descripcion, @duracion)"
        Dim crear As New SqlCommand(lineaComando, conexion)

        crear.Parameters.AddWithValue("@codTarea", codigoAPasar)
        crear.Parameters.AddWithValue("@fecha", fechaAPasar)
        crear.Parameters.AddWithValue("@dni", dniAPasar)
        crear.Parameters.AddWithValue("@descripcion", descripcionAPasar)
        crear.Parameters.AddWithValue("@duracion", duracionAPasar)



        Try
            conexion.Open()
            crear.ExecuteNonQuery()
        Catch ex As Exception
            Return "Error del añadir tarea: " & ex.Message
        Finally
            conexion.Close()
        End Try

        Return "Tarea insertada"
    End Function


End Class
