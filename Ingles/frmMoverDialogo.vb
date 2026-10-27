Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO

Imports System.Windows.Forms

Public Class frmMoverDialogo

    Public IdDet As Integer
    Public IdEnc As Integer

    Private Sub CmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub frmMoverDialogo_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        cboTipo.Items.Add("ALL")
        cboTipo.Items.Add("Saludo")
        cboTipo.Items.Add("Presentacion")
        cboTipo.Items.Add("Iniciando")
        cboTipo.Items.Add("Frases")
        cboTipo.Items.Add("Conversacion basica")
        cboTipo.Items.Add("Conversacion")
        cboTipo.Items.Add("Leccion")
        cboTipo.Items.Add("Serie")
        cboTipo.Items.Add("Audios")

    End Sub

    Private Sub CargarDatos()
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim param As String
         
        param = " Where Con_tipo='" & cboTipo.Text & "'"

        sqlstring = " SELECT    Con_Id, Con_Titulo"
        sqlstring = sqlstring & " FROM Enc_Conversation "
        sqlstring = sqlstring & param
        sqlstring = sqlstring & " ORDER BY Con_Titulo"

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando
            da.Fill(dt)
            _comando.Connection.Close()
        Catch ex As Exception

        End Try

        'Conversaciones
        i = 0
        n = dt.Rows.Count

        Do While i <= n - 1
            cboConversation.Items.Add(New clsItem(dt.Rows(i).Item(1), dt.Rows(i).Item(0)))
            i = i + 1
        Loop



    End Sub

    Private Sub cboConversation_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboConversation.SelectedIndexChanged

        IdEnc = cboConversation.Items(cboConversation.SelectedIndex).ItemData()
        txtIdConversationNew.Text = IdEnc

    End Sub

    Private Sub cmdSaveTransferir_Click(sender As System.Object, e As System.EventArgs) Handles cmdSaveTransferir.Click

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim IdDetNuevo As Integer

        i = 0
        
        Dim resp As Boolean

        _comando.Parameters.Clear()
        _comando.Connection.Open()

        sqlstring = "Insert into Det_Conversation (Det_Orden, Con_Id)"
        sqlstring = sqlstring & " Values (@Det_Orden, '" & IdEnc & "')"

        _comando.CommandText = sqlstring

        _comando.Parameters.AddWithValue("@Det_Orden", 0)

        Try

            i = _comando.ExecuteNonQuery

            If i > 0 Then
                resp = True
            Else
                resp = False
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        Dim sql As String

        If i > 0 Then
            Sql = "SELECT @@IDENTITY FROM Det_Conversation"

            _comando = New SqlCommand(Sql, _comando.Connection)

            Dim value As Object = _comando.ExecuteScalar
            IdDetNuevo = value.ToString

        End If

        ' _comando.Connection.Close()
        '_comando.Connection.Open()

        'For Each rw In dt.Rows

        _comando.Parameters.Clear()

        sqlstring = "UPDATE Dialogos SET DetConversacion = @DetConversacion"
        sqlstring = sqlstring & " WHERE DetConversacion ='" & IdDet & "'"

        _comando.CommandText = sqlstring

        _comando.Parameters.AddWithValue("@DetConversacion", IdDetNuevo)
        '_comando.Parameters.AddWithValue("@Det_Con", IdDetNuevo)

        Try
            i = _comando.ExecuteNonQuery
        Catch ex As Exception
        End Try


        If i > 0 Then
            resp = True
        Else
            resp = False
        End If

        _comando.Connection.Close()

        Me.Close()

        ' Me.Dispose()


    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipo.SelectedIndexChanged

        CargarDatos()

    End Sub
End Class