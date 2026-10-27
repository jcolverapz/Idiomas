Imports System.Data
'Imports System.Data.OleDb
'Imports Microsoft.Office.Interop.Word
'Imports Microsoft.Office.Interop
Imports System.Data.SqlClient

Public Class frmNewConversation

    Public IdOracion As Integer
    Public IdPersona As Integer
    Public Frase As String
    Private Sub CmdGuardar_Click(sender As System.Object, e As System.EventArgs) Handles CmdGuardar.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim descripcion As String
        Dim sqlstring As String = ""
        Dim i As Integer

        descripcion = txtDescripcion.Text

        Dim IdEnc As Integer
        IdEnc = GuardarConversation(descripcion, cboTipo.Text)

        Dim Id As Integer
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim IdPerson As Integer

        IdPerson = 3

        _comando.Connection.Open()

        Dim resp As Boolean

        For Each r In lsvFrases.Items

            _comando.Parameters.Clear()

            ' Id = lsvFrases.Items(0).SubItems(1).Text

            sqlstring = "Insert into det_Conversation (Det_OracionId, Det_Orden, Con_Id, Det_Person)"
            sqlstring = sqlstring & " Values ('" & r.SubItems(1).Text & "', @Det_Orden, '" & IdEnc & "', '" & IdPerson & "')"

            _comando.CommandText = sqlstring

            _comando.Parameters.AddWithValue("@Det_Orden", r.index)

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

        Next

        _comando.Connection.Close()

        If resp Then
            ' MsgBox("se guardo")
        Else
            'MsgBox("No se guardo")
        End If

        Dim frm As New FrmConversation
        Try

            frm.Id = IdEnc
            frm.lbltitulo.Text = descripcion
            frm.CargarConversation(IdEnc)
            frm.ShowDialog()

            Me.Close()
            Me.Dispose()

        Catch ex As Exception

            Me.Close()
            Me.Dispose()
            Exit Sub

        End Try

       
         

        'Try

        '    Dim frm As frmTexto = CType(Owner, frmTexto)

        '    frm.descripcion = descripcion

        '    Me.Close()
        '    Me.Dispose()

        'Catch ex As Exception

        '    Me.Close()
        '    Me.Dispose()
        '    Exit Sub

        'End Try

    End Sub
    Public Shared Function GuardarConversation(descripcion, tipo) As Integer
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sql As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim sqlstring As String = ""
        Dim i As Integer
        Dim IdEnc As Integer

        sqlstring = "Insert into Enc_Conversation (Con_Titulo, Con_tipo)"
        sqlstring = sqlstring & " Values ('" & descripcion & "', '" & tipo & "')"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()


        Try
            i = _comando.ExecuteNonQuery

            If i > 0 Then
                '  MsgBox("se guardo")
            Else
                MsgBox("No se guardo")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        If i > 0 Then
            sql = "SELECT @@IDENTITY FROM Enc_Conversation"

            _comando = New SqlCommand(sql, _comando.Connection)

            Dim value As Object = _comando.ExecuteScalar
            IdEnc = value.ToString

        End If
        _comando.Connection.Close()

        Return IdEnc


    End Function


    Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
        Me.Close()

    End Sub

    Private Sub frmNewConversation_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        cboTipo.Items.Add("Saludo")
        cboTipo.Items.Add("Iniciando")
        cboTipo.Items.Add("Conversacion")
        cboTipo.Items.Add("Leccion")
        cboTipo.Items.Add("Serie")



        lsvFrases.View = View.Details ' Set the view to show details.
        lsvFrases.LabelEdit = False ' Allow the user to edit item text.
        lsvFrases.AllowColumnReorder = True ' Allow the user to rearrange columns.
        lsvFrases.FullRowSelect = True
        lsvFrases.GridLines = True

        lsvFrases.ShowItemToolTips = True

        Dim item As ListViewItem 'Creo el ListViewItem (item) 

        item = New ListViewItem(0) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

        item.SubItems.Add(IdOracion)
        item.SubItems.Add(Frase)

        lsvFrases.Items.Add(item)

        txtDescripcion.Text = "Conversacion # "
        cboTipo.Text = "Conversacion"


    End Sub
End Class