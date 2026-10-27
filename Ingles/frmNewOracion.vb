Imports Entidades
Imports Negocios
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Data.SqlClient
'Imports RichTextBoxEx
Imports System.IO

Public Class frmNewOracion

    Public subtemaId As Integer

    Private Sub frmNewOracion_Click(sender As Object, e As System.EventArgs) Handles Me.Click
        txtDescripcion.SelectionStart = 0
        txtDescripcion.SelectionLength = 0
    End Sub
    Private Sub frmNewOracion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtSubtemaId.Text = subtemaId

        'cargarDatos()
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        sqlstring = "select * from  Grupos_oracion "
        sqlstring = sqlstring & " ORDER By orden ASC"

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)
            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try

        cboGrupo.Items.Clear()

        Dim i As Integer
        Dim n As Integer
        n = dt.Rows.Count

        
        Do While i <= n - 1
            Me.cboGrupo.Items.Add(New clsItem(dt.Rows(i).Item(1), dt.Rows(i).Item(0)))
            i = i + 1
        Loop

    End Sub

    Private Sub CmdGuardar_Click(sender As System.Object, e As System.EventArgs) Handles CmdGuardar.Click
        Dim OracionEN As String
        Dim OracionES As String

        ' OracionEN = RichTextBoxEx1.rtb.Text
        OracionEN = txtDescripcion.Text
        OracionES = txtTraduccion.Text


        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim GrupoO As Integer

        If cboGrupo.SelectedIndex = -1 Then Exit Sub
        GrupoO = cboGrupo.Items(cboGrupo.SelectedIndex).ItemData()

        sqlstring = "Insert into Oraciones_fr (Oracion, TextoPlano, Traduccion, GrupoO, foco)"
        sqlstring = sqlstring & " Values (@Oracion, @TextoPlano, @Traduccion, @GrupoO, @foco)"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        _comando.Parameters.AddWithValue("@Oracion", OracionEN)
        _comando.Parameters.AddWithValue("@TextoPlano", OracionEN)
        _comando.Parameters.AddWithValue("@Traduccion", OracionES)
        _comando.Parameters.AddWithValue("@GrupoO", GrupoO)

        If cmdFoco.Checked = True Then
            _comando.Parameters.AddWithValue("@foco", 1)
        Else
            _comando.Parameters.AddWithValue("@foco", 0)
        End If


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

        ' RichTextBoxEx1.rtb.Text = ""
        txtDescripcion.Text = ""
        txtTraduccion.Text = ""



        ' Me.Close()
        '  Me.Dispose()

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        'Agrega la oracion
        Dim OracionEN As String
        Dim OracionES As String
        
        Dim SQL As String
        Dim OracionId As Integer

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer

        ' OracionEN = RichTextBoxEx1.rtb.Text
        OracionES = txtTraduccion.Text
         

        sqlstring = "Insert into Oraciones (Oracion, TextoPlano, Traduccion)"
        sqlstring = sqlstring & " Values ('" & OracionEN & "', '" & OracionEN & "', '" & OracionES & "')"

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
        '_comando.Connection.Close()

        Try
            If i > 0 Then
                SQL = "SELECT @@IDENTITY FROM Oraciones"

                _comando = New SqlCommand(SQL, _comando.Connection)

                Dim value As Object = _comando.ExecuteScalar

                OracionId = value.ToString
            End If
            _comando.Connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        _comando.Connection.Close()

        txtDescripcion.Text = ""
        txtTraduccion.Text = ""

        Me.Close()
        Me.Dispose()
         
        ' OracionId = dgvOraciones.CurrentRow.Cells(5).Value.ToString()

        ' Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        sqlstring = ""

        sqlstring = "Insert into SubtemaxOracion (OracionId, SubtemaId)"
        sqlstring = sqlstring & " Values ('" & OracionId & "', '" & SubtemaId & "' )"

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
        'txtDescripcion.Text = ""
        ' txtTraduccion.Text = ""

        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
        Me.Close()

    End Sub

    Private Sub cboGrupo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboGrupo.SelectedIndexChanged

    End Sub

    Private Sub frmNewOracion_MouseMove(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        txtDescripcion.Focus()
    End Sub

    
    Private Sub txtDescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDescripcion.TextChanged

    End Sub

    Private Sub txtTraduccion_LostFocus(sender As Object, e As System.EventArgs) Handles txtTraduccion.LostFocus

        CmdGuardar_Click(sender, e)


    End Sub

    Private Sub txtTraduccion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTraduccion.TextChanged

    End Sub
End Class