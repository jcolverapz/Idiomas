Imports Entidades
Imports Negocios
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Data.SqlClient
'Imports RichTextBoxEx
Imports System.IO
Public Class FrmNewWord

    

    Private Sub CmdGuardar_Click(sender As System.Object, e As System.EventArgs) Handles CmdGuardar.Click
        Dim Concepto As String
        Dim Traduccion As String

        Concepto = txtDescripcion.Text
        Traduccion = txtTraduccion.Text


        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer


        sqlstring = "Insert into Conceptos (Concepto, Definicion)"
        sqlstring = sqlstring & " Values ('" & Concepto & "', '" & Traduccion & "')"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()
        Try
            i = _comando.ExecuteNonQuery

            If i > 0 Then
                ' MsgBox("se guardo")

            Else
                '  MsgBox("No se guardo")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        _comando.Connection.Close()

        txtDescripcion.Text = ""
        txtTraduccion.Text = ""

        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
        Me.Close()

    End Sub
End Class

 