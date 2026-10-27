Imports System.Data
'Imports System.Data.OleDb
'Imports Microsoft.Office.Interop.Word
'Imports Microsoft.Office.Interop
Imports System.Data.SqlClient

Public Class frmItemsConversation
    Public maxColumna As Integer
    Public oColorVerde As Color = System.Drawing.Color.FromArgb(209, 235, 222) 'verde
    Public Color4 As Color = System.Drawing.Color.FromArgb(31, 92, 60) 'verde fuerte

    Public oColorSalmon As Color = System.Drawing.Color.FromArgb(254, 180, 180) 'salmon
    Private Sub dgvOraciones_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvOraciones.CellFormatting
         
        Try
            If dgvOraciones.Columns(e.ColumnIndex).Name.Equals("Avance") Then

                If e.Value < 1 Then
                    For ColNo As Integer = 0 To maxColumna
                        dgvOraciones.Rows(e.RowIndex).Cells(ColNo).Style.BackColor = oColorSalmon
                    Next
                Else
                    For ColNo As Integer = 0 To maxColumna
                        dgvOraciones.Rows(e.RowIndex).Cells(ColNo).Style.BackColor = oColorVerde
                    Next
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub dgvOraciones_CellMouseClick(sender As Object, e As System.Windows.Forms.DataGridViewCellMouseEventArgs) Handles dgvOraciones.CellMouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim Id As Integer
            Dim TipoTicket As String
            Dim frm As New frmDetConversation

            AddOwnedForm(frm)

            ' sqlstring = " SELECT Tbl_Devices.,  Tbl_Devices., Tbl_Devices., Tbl_Devices."

            Id = dgvOraciones.CurrentRow.Cells(0).Value.ToString()


            frm.Id = Id
            'frm.lbltitulo.Text = dgvOraciones.CurrentRow.Cells(1).Value.ToString()
            frm.CargarDatos(Id)
            frm.Show()
        End If
    End Sub

    Private Sub dgvOraciones_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvOraciones.DoubleClick
        Dim Id As Integer
        Dim TipoTicket As String
        'Dim frm As New FrmConversation
        Dim frm As New frmEscenas

        AddOwnedForm(frm)

        Id = dgvOraciones.CurrentRow.Cells(0).Value.ToString()

        frm.Id = Id
        frm.lbltitulo.Text = dgvOraciones.CurrentRow.Cells(2).Value.ToString()
        'frm.CargarConversation(Id)

        Try
            frm.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim param As String

        If cboTipo.Text <> "" Then
            param = " Where Con_Tipo='" & cboTipo.Text & "'"

        End If

        CargarDatos()

    End Sub

    Private Sub frmItemsConversation_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


        cboTipo.Items.Add("ALL")
        cboTipo.Items.Add("Saludo")
        cboTipo.Items.Add("Presentacion")
        cboTipo.Items.Add("Iniciando")
        cboTipo.Items.Add("Conversacion basica")
        cboTipo.Items.Add("Conversacion")
        cboTipo.Items.Add("Leccion")
        cboTipo.Items.Add("Serie")

        cboTipo.Text = "Presentacion"

        ' cboTipo.Items.Add("Iniciando")

       
        CargarDatos()

    End Sub

    Public Sub CargarDatos()
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        Dim param As String

        If cboTipo.Text = "ALL" Then
            param = ""
        Else
            param = " Where Con_Tipo='" & cboTipo.Text & "'"
        End If

        'sqlstring = "select * from  SubTemas "
        sqlstring = "select Con_Id,Con_orden, Con_Titulo, Con_Cant, Con_avance, Con_tipo"
        sqlstring = sqlstring & " from  Enc_Conversation"
        sqlstring = sqlstring & param
        sqlstring = sqlstring & " ORDER By Con_orden ASC"

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)


            dgvOraciones.DataSource = dt

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        Dim n As Integer
        n = dt.Rows.Count

        maxColumna = dt.Columns.Count

        dgvOraciones.Columns(0).Visible = False
        ' dgvOraciones.Columns(3).Visible = False
        'dgvOraciones.Columns(4).Visible = False
        ' dgvOraciones.Columns(4).Visible = False

        dgvOraciones.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' dgvOraciones.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgvOraciones.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgvOraciones.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        ' dgvOraciones.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        dgvOraciones.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'dgvOraciones.Columns(4).DefaultCellStyle.Format = "%#"
        dgvOraciones.Columns(4).DefaultCellStyle.Format = "0 %"
        dgvOraciones.Columns(5).Visible = False


        Dim avance As Integer = 0

        Try
            avance = avance / n

            'ProgressBar1.Value = avance

            ' Porcentaje.Text = Math.Round((ProgressBar1.Value / n), 1) * 100 & "%"
            ' Porcentaje.Text = (avance) & "%"

        Catch ex As Exception

        End Try
        _comando.Connection.Close()

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim frm As New frmNewConversation

        AddOwnedForm(frm)

        frm.ShowDialog()

        CargarDatos()


    End Sub

    Private Sub CmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()

    End Sub

    Private Sub cmdEditar_Click(sender As System.Object, e As System.EventArgs) Handles cmdEditar.Click
        Dim Id As Integer
        Dim TipoTicket As String
        Dim frm As New frmDetConversation

        AddOwnedForm(frm)

        ' sqlstring = " SELECT Tbl_Devices.,  Tbl_Devices., Tbl_Devices., Tbl_Devices."

        Id = dgvOraciones.CurrentRow.Cells(0).Value.ToString()


        frm.Id = Id
        'frm.lbltitulo.Text = dgvOraciones.CurrentRow.Cells(1).Value.ToString()
        frm.CargarDatos(Id)
        frm.Show()
        Dim param As String

        param = " Where Con_Tipo='" & cboTipo.Text & "'"
        CargarDatos()
    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipo.SelectedIndexChanged

        CargarDatos()

    End Sub

    Private Sub dgvOraciones_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOraciones.CellContentClick

    End Sub

    Private Sub cmdOrdenar_Click(sender As System.Object, e As System.EventArgs) Handles cmdOrdenar.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, j As Integer

        i = 1

        _comando.Connection.Open()

        For Each r In dgvOraciones.Rows

            Console.WriteLine(r.cells(0).value)
            _comando.Parameters.Clear()

            sqlstring = "UPDATE Enc_conversation SET Con_Orden = @Con_Orden"
            sqlstring = sqlstring & " WHERE  Con_Id = @Con_Id"

            _comando.Parameters.AddWithValue("@Con_Orden", i)
            _comando.Parameters.AddWithValue("@Con_Id", r.cells(0).value.ToString())

            _comando.CommandText = sqlstring

            Try
                j = _comando.ExecuteNonQuery

            Catch ex As Exception

            End Try

            i = i + 1
        Next
        _comando.Connection.Close()

        If i > 0 Then
            CargarDatos()
        Else
            MsgBox("No se actualizo")
        End If
    End Sub

    Private Sub dgvOraciones_CellPainting(sender As Object, e As System.Windows.Forms.DataGridViewCellPaintingEventArgs) Handles dgvOraciones.CellPainting
        If dgvOraciones.SelectedRows.Count > 0 Then
            If e.RowIndex <> dgvOraciones.CurrentCell.RowIndex Then
                Dim oColorOk As Drawing.Color = Color.Chartreuse
                Dim oColorNot As Drawing.Color = Color.Yellow
                If e.ColumnIndex = 4 Then
                    Dim cellValue As Integer
                    If e.RowIndex >= 0 Then
                        cellValue = e.Value
                        If cellValue < 1 Then
                            Bar.PintaDegradado(oColorNot, e, cellValue)
                        Else
                            Bar.PintaDegradado(oColorOk, e, cellValue)

                        End If
                    End If


                End If
            End If
        Else
            'MessageBox.Show("No hay ninguna fila seleccionada")
        End If
    End Sub

    Private Sub dgvOraciones_CursorChanged(sender As Object, e As System.EventArgs) Handles dgvOraciones.CursorChanged

    End Sub

    Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscar.TextChanged
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        Dim param As String

        sqlstring = "SELECT Con_Id,Con_orden, Con_Titulo, Con_Cant, Con_avance, Con_tipo"
        sqlstring = sqlstring & " from  Enc_Conversation"

        If txtBuscar.Text <> "" Then
            sqlstring = sqlstring & " Where Con_Titulo LIKE '%' + @Con_Titulo + '%'"
        Else
            sqlstring = sqlstring & " Where Con_Titulo LIKE '%' + @Con_Titulo + '%'"
        End If

        sqlstring = sqlstring & " ORDER By Con_orden ASC"



        Try
            _comando.CommandText = sqlstring

            _comando.Connection.Open()
            _comando.Parameters.AddWithValue("@Con_Titulo", txtBuscar.Text)

            dt.Clear()

            da.SelectCommand = _comando

            da.Fill(dt)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try


        dgvOraciones.DataSource = dt

        _comando.Connection.Close()

        Dim n As Integer
        n = dt.Rows.Count

        maxColumna = dt.Columns.Count

        dgvOraciones.Columns(0).Visible = False
        ' dgvOraciones.Columns(3).Visible = False
        'dgvOraciones.Columns(4).Visible = False
        ' dgvOraciones.Columns(4).Visible = False

        dgvOraciones.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' dgvOraciones.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgvOraciones.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgvOraciones.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        ' dgvOraciones.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        dgvOraciones.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'dgvOraciones.Columns(4).DefaultCellStyle.Format = "%#"
        dgvOraciones.Columns(4).DefaultCellStyle.Format = "0 %"
        dgvOraciones.Columns(5).Visible = False


        Dim avance As Integer = 0

        Try
            avance = avance / n

        Catch ex As Exception

        End Try
        _comando.Connection.Close()

    End Sub

    Private Sub txtBuscarDialogo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscarDialogo.TextChanged
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        Dim param As String

        'sqlstring = "SELECT Con_Id,Con_orden, Con_Titulo, Con_Cant, Con_avance, Con_tipo"
        'sqlstring = sqlstring & " from  Enc_Conversation"

        sqlstring = "SELECT  Enc_Conversation.Con_Id, Enc_Conversation.Con_orden, Enc_Conversation.Con_Titulo, Enc_Conversation.Con_Cant, Enc_Conversation.Con_avance, Enc_Conversation.Con_tipo, Oraciones.TextoPlano"
        sqlstring = sqlstring & " FROM            Enc_Conversation INNER JOIN"
        sqlstring = sqlstring & "                     Det_Conversation ON Enc_Conversation.Con_Id = Det_Conversation.Con_Id INNER JOIN"
        sqlstring = sqlstring & "                    Dialogos ON Det_Conversation.Det_Con = Dialogos.DetConversacion INNER JOIN"
        sqlstring = sqlstring & "                   Oraciones ON Dialogos.OracionId = Oraciones.Id"

        If txtBuscarDialogo.Text <> "" Then
            sqlstring = sqlstring & " Where Oraciones.TextoPlano LIKE '%' + @TextoPlano + '%'"
        Else
            sqlstring = sqlstring & " Where Oraciones.TextoPlano LIKE '%' + @TextoPlano + '%'"
        End If

        sqlstring = sqlstring & " ORDER By Enc_Conversation.Con_orden ASC"



        Try
            _comando.CommandText = sqlstring

            _comando.Connection.Open()
            _comando.Parameters.AddWithValue("@TextoPlano", txtBuscarDialogo.Text)

            dt.Clear()

            da.SelectCommand = _comando

            da.Fill(dt)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try


        dgvOraciones.DataSource = dt

        _comando.Connection.Close()

        Dim n As Integer
        n = dt.Rows.Count

        maxColumna = dt.Columns.Count

        dgvOraciones.Columns(0).Visible = False
        ' dgvOraciones.Columns(3).Visible = False
        'dgvOraciones.Columns(4).Visible = False
        ' dgvOraciones.Columns(4).Visible = False

        dgvOraciones.Columns(1).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        ' dgvOraciones.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgvOraciones.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgvOraciones.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        ' dgvOraciones.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        dgvOraciones.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'dgvOraciones.Columns(4).DefaultCellStyle.Format = "%#"
        dgvOraciones.Columns(4).DefaultCellStyle.Format = "0 %"
        dgvOraciones.Columns(5).Visible = False


        Dim avance As Integer = 0

        Try
            avance = avance / n

        Catch ex As Exception

        End Try
        _comando.Connection.Close()
    End Sub
End Class