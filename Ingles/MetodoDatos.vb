Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.OleDb

Public Class MetodosDatos
    Public Shared Function CrearComando() As SqlCommand
        Dim _cadenaConexion = DBConfiguracion.CadenaConexion
        Dim _conexion As New SqlConnection()

        _conexion.ConnectionString = _cadenaConexion

        Dim _comando As New SqlCommand()
        _comando = _conexion.CreateCommand()
        _comando.CommandType = CommandType.Text

        Return _comando
    End Function
    Public Shared Function CrearComandoSQL() As SqlCommand
        Dim _cadenaConexion = DBConfiguracion.cadenaConexionGEM
        Dim _conexion As New SqlConnection()

        _conexion.ConnectionString = _cadenaConexion

        Dim _comando As New SqlCommand()
        _comando = _conexion.CreateCommand()
        _comando.CommandType = CommandType.Text

        Return _comando
    End Function
    ' Public Shared Function CrearConexion() As SqlConnection
    'Dim _cadenaConexion = DBConfiguracion.CadenaConexion
    'Dim _conexion = New SqlConnection()

    '_conexion.ConnectionString = _cadenaConexion
    'Return _conexion
    ' End Function

    Public Shared Function CrearComandoAccess() As OleDbCommand
        Dim _cadenaConexionAccess = DBConfiguracion.CadenaConexionAccess
        Dim _conexionAccess As New OleDbConnection(_cadenaConexionAccess)


        Dim _cmd As New OleDbCommand()


        ' _comando = _conexionAccess.
        ' _comando.CommandType = CommandType.Text
        _cmd.CommandType = CommandType.Text

        _cmd.Connection = _conexionAccess
        '_conexionAccess.ConnectionString = _cadenaConexionAccess
        Return _cmd
    End Function

End Class


