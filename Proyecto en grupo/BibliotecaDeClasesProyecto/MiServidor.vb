Imports System.Data.SqlClient

Public NotInheritable Class MiServidor
    ''Devuelve el nombre del servidor del ordenador en que se esta ejecutando
    Public Shared Function Servidor(ByRef errorServidor As String) As String
        errorServidor = ""
        Dim servidores() As String = {".", ".\SQLEXPRESS"}

        For Each serv As String In servidores
            Try
                Dim cadConexion As String = $"Data Source={serv};Initial Catalog=master;Integrated Security=True;MultipleActiveResultSets=True;Connect Timeout=2"

                Using con As New SqlConnection(cadConexion)
                    con.Open()
                    con.Close()
                    errorServidor = ""
                    Return serv ' Ha podido conectar con SqlServer
                End Using

            Catch exc As Exception
                errorServidor = exc.Message ' NO ha podido conectar, continúa buscando
            End Try
        Next

        errorServidor = "No era ninguno???"
        Return ""
    End Function
End Class
