
Public Class DBConfiguracion
    'Shared _cadenaConexionGEM As String = "Data Source=10.18.164.213;Initial Catalog=Gemtron;Persist Security Info=True;User Id=MXSLPAPP;Password=Sch0tt!;"
    'Shared _cadenaConexion As String = "Data Source=(LocalDb)\ServidorLocal;Initial Catalog=Data;Integrated Security=SSPI;"
    Shared _cadenaConexion As String = "Data Source=(LocalDb)\ServidorLocal;Initial Catalog=Data;Integrated Security=SSPI;User Id=usuarioApp;Password=123456;"

    'Shared _cadenaConexionGEM As String = "Data Source=10.18.172.2;Initial Catalog=Gemtron;Persist Security Info=True;User Id=MXAPDAPP;Password=Sch0tt!;"
    'Shared _cadenaConexionAccess As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\legacy\Mantenimientos\Mantenimientos.accdb"
    'Shared _cadenaConexionAccess As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\legacy\Mantenimientos\Mantenimientos.accdb")
    Shared _cadenaConexionAccess As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\legacy\Mantenimientos\Mantenimientos.accdb"
    Public Shared ReadOnly Property CadenaConexion() As String
        Get
            Return _cadenaConexion
        End Get
    End Property
    Public Shared ReadOnly Property cadenaConexionGEM() As String
        Get
            ' Return _cadenaConexionGEM
        End Get
    End Property
    Public Shared ReadOnly Property CadenaConexionAccess() As String
        Get
            Return _cadenaConexionAccess
        End Get
    End Property
End Class

