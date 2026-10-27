Public Class usuario

    'Propiedades:
    'nombre
    'raza
    'altura

    Public Property nombre As String
    Public Property perfil As String
    Public Property img As String


    'metodos
    Public Function comer(carne As String) As String
        Return Me.nombre '& " pesa " & Me.peso & " kg." & " y comera " & carne
    End Function

    'constructores
    Public Sub New()

    End Sub

    Public Sub New(nombre As String, perfil As String, img As String)
        Me.nombre = nombre
        Me.perfil = perfil
        Me.img = img

    End Sub




End Class
