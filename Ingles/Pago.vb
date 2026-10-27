Public Class Pago
    'atributors

    Private _nombre As String
    Private _categoria As String
    Private _horas As String

    'propiedades

    Public Property nombre As String
        Get
            Return _nombre

        End Get
        Set(value As String)
            _nombre = value
        End Set
    End Property

    Public Property categoria As String
        Get
            Return _categoria
        End Get
        Set(value As String)
            _categoria = value

        End Set
    End Property

    Public Property horas As Integer
        Get
            Return _horas

        End Get
        Set(value As Integer)
            _horas = value

        End Set
    End Property

    'funciones

    Function calcularCategoria() As Integer

        Select Case _categoria
            Case "A" : Return 40
            Case "B" : Return 30
            Case "C" : Return 20
            Case Else : Return 0

        End Select

        Return 0
    End Function


    Function calcularPago() As Double
        Return _horas * calcularCategoria()

    End Function
End Class
