Imports System.Data
Imports System.Data.SqlClient
'Imports System.Data.OleDb
Imports Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop
Imports System.IO
Imports System.Drawing


Public Class frmRegistrarAvance


    Public Id As Integer

    Public tema As String

    
    Public Sub actualizaCuenta(Id, Cuenta)

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim fechaActual As String


        'Actualizar Cuenta
        ' Cuenta = Cuenta + 1

        sqlstring = "Update Subtemas SET Cuenta=@Cuenta Where ID=@id"

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()


            _comando.Parameters.AddWithValue("@Cuenta", Cuenta)
            _comando.Parameters.AddWithValue("@id", Id)


            i = _comando.ExecuteNonQuery
            If i > 0 Then
            Else
                MsgBox("No se actualizo")
            End If

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try




    End Sub

    Private Sub frmRegistrarAvance_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


        lblTema.Text = Tema
    End Sub

  

    Private Sub txtNivel_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNivel.KeyPress
        If e.KeyChar = ChrW(13) Then
            Guardar()

        End If
    End Sub

  
    Private Sub CmdGuardar_Click(sender As System.Object, e As System.EventArgs) Handles CmdGuardar.Click

        Guardar()

    End Sub

    Private Sub Guardar()
        Dim resp As String
        Dim avance As Integer


        actualizaCuenta(Id, txtNivel.Text)

        'Me.Close()
        Dim param As String

        Try

            Dim frm As FrmTemas = CType(Owner, FrmTemas)

            'frm.cargarDatos()
            frm.CargarSubtemas(frm.IdTema)
            Me.Close()
            Me.Dispose()
        Catch ex As Exception

            Me.Close()
            Me.Dispose()
            Exit Sub

        End Try
    End Sub
End Class