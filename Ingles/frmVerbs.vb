Imports System.Data
'Imports System.Data.OleDb
Imports Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop
Imports System.Data.SqlClient


Public Class frmVerbs

    Private Sub frmVerbs_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        'cargarDatos()
        'sqlstring = "select * from  SubTemas "
        sqlstring = "select * from  Verbs "
        sqlstring = sqlstring & " ORDER By Simple ASC"

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)

            dgvVerbs.DataSource = dt

            'Me.cboGrupo.DataSource = dt
            'Me.cboGrupo.ValueMember = "Id"
            'Me.cboGrupo.DisplayMember = "Grupo"

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        'Dim sqlstring As String
        'Dim cmd As New OleDbCommand

        'Dim dt As New DataTable
        'Dim da As New OleDbDataAdapter
        'Try
        '    conexion.Open()



        '    cmd.Connection = conexion
        '    cmd.CommandText = sqlstring
        '    da.SelectCommand = cmd

        '    da.Fill(dt)



        'Catch ex As Exception

        '    MsgBox(ex.Message)
        'Finally
        '    conexion.Close()

        'End Try

        ' CargarSubtemas()
        ' dgvEncDatos.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '  dgvEncDatos.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'dgvEncDatos.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '  dgvEncDatos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
        'dgvEncDatos.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'Datagrid.Columns[0].AutoSizeMode =DataGridViewAutoSizeColumnMode.Fill
        '  dgvEncDatos.Columns(0).AutoSizeMode = True
        'dgvEncDatos.Columns(0).MinimumWidth = True
        ' dgvEncDatos.Columns(0).Visible = False

        'Dim migasto As New Gastos
        'migasto.actualizar()
        'cargarDatos()
    End Sub


    'Public conexion As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\legacy\Ingles\Ingles.accdb")
    'Public instruccion As New OleDbCommand
    Public contenedor As String
    Public sqlstring As String

    Public Shared IdEnc As Integer
    Public SubtemaId As Integer

    Public consulta As String
    Dim rowcount As Integer
    Public filtro As String
    Public MaxColumna As Integer
    Public Color1 As Color = System.Drawing.Color.FromArgb(253, 239, 202)
    Public Color2 As Color = System.Drawing.Color.FromArgb(128, 94, 14)

    Public Color3 As Color = System.Drawing.Color.FromArgb(209, 235, 222)
    Public Color4 As Color = System.Drawing.Color.FromArgb(31, 92, 60)

    Public Color5 As Color = System.Drawing.Color.FromArgb(207, 218, 223)
    Public Color6 As Color = System.Drawing.Color.FromArgb(19, 49, 57)

   
    Public Sub CargarDatos(filtro)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter



        Try


            _comando.CommandText = filtro
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)
            dgvVerbs.DataSource = dt
            MaxColumna = dgvVerbs.ColumnCount

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try


        dgvVerbs.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgvVerbs.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgvVerbs.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgvVerbs.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgvVerbs.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'dgvOraciones.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'dgvOraciones.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        ' dgvOraciones.Columns(0).Visible = False
        'dgvOraciones.Columns(1).Visible = False

        ' dgvOraciones.Columns(3).Visible = False
        '  dgvOraciones.Columns(4).Visible = False
        '  dgvVerbs.Columns(5).Visible = False
        ' dgvVerbs.Columns(6).Visible = False

        ' dgvOraciones.Columns(1).DefaultCellStyle.Format = "#,##0.00"
        'Dim sqlstring As String
        'Dim cmd As New OleDbCommand

        'Dim dt As New DataTable
        'Dim da As New OleDbDataAdapter
        'Try
        '    'conexion.Open()



        '    cmd.Connection = conexion
        '    cmd.CommandText = sqlstring
        '    da.SelectCommand = cmd

        '    da.Fill(dt)


        'Catch ex As Exception

        '    MsgBox(ex.Message)
        'Finally
        '    conexion.Close()

        'End Try

        ' Dim column2 = New datag
        '  column2.HeaderText = "Text"
        ' column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'dgvOraciones.Columns(1).DefaultCellStyle.Format. = DataGridViewAutoSizeColumnMode.DisplayedCells
        'DataGridView1.Columns("Codigo").DefaultCellStyle.Format = "#,##0.00"
        'dgvOraciones.Columns(1).DefaultCellStyle.Format = DataGridView

        'dgvOraciones.Columns(1).DefaultCellStyle. = "#,##0.00"


    End Sub
    'customize the TextBoxCellRenderer


    Private Sub cboGrupo_LostFocus(sender As Object, e As System.EventArgs) Handles cboGrupo.LostFocus
        'Dim IdGrupo As Integer
        'If Me.cboGrupo.Text = "" Then Exit Sub
        'If Me.cboGrupo.SelectedIndex < 1 Then Exit Sub
        'IdGrupo = Me.cboGrupo.SelectedValue

        'CargarDatos(IdGrupo)
    End Sub

    Private Sub cboGrupo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboGrupo.SelectedIndexChanged
        Dim IdGrupo As Integer
        Dim sqlstring As String = ""
        If Me.cboGrupo.Text = "" Then Exit Sub
        If Me.cboGrupo.SelectedIndex < 1 Then Exit Sub
        IdGrupo = Me.cboGrupo.SelectedValue

        filtro = "select  STL, TextoPlano, Traduccion, Estatus, Oracion, Id, GrupoO from Oraciones "
        filtro = filtro & " Where GrupoO= '" & IdGrupo & "'"
        filtro = filtro & " Order By Oracion ASC"

        CargarDatos(filtro)
    End Sub




    Private Sub dgvOraciones_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvVerbs.CellFormatting

        'Set the background to red for negative values in the Balance column.


        Try
            If dgvVerbs.Columns(e.ColumnIndex).Name.Equals("STL") Then

                If e.Value = True Then

                    For ColNo As Integer = 0 To MaxColumna - 1
                        dgvVerbs.Rows(e.RowIndex).Cells(ColNo).Style.BackColor = Color3
                    Next



                Else

                    For ColNo As Integer = 0 To MaxColumna - 1
                        dgvVerbs.Rows(e.RowIndex).Cells(ColNo).Style.BackColor = Color1
                    Next

                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvOraciones_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvVerbs.DoubleClick
        Dim Id As Integer
        Dim TipoTicket As String
        Dim frm As New FrmDetOracion

        AddOwnedForm(frm)

        ' sqlstring = " SELECT Tbl_Devices.,  Tbl_Devices., Tbl_Devices., Tbl_Devices."

        Id = dgvVerbs.CurrentRow.Cells(0).Value.ToString()
        ' TipoTicket = dgvOraciones.CurrentRow.Cells(11).Value.ToString()


        'If TipoTicket = "INC" Then
        '    ' Dim frm As New frmItemTicket
        '    frm.lblTipo.Text = "Incident Item"
        '    ' frm.CargarDatos(TicketId)
        '    'frm.ShowDialog()
        'Else
        '    ' Dim frm As New frmItemRequest
        '    ' AddOwnedForm(frm)
        '    frm.lblTipo.Text = "Request Item"
        '    '  frm.CargarDatos(TicketId)
        'End If
        frm.IdOracion = Id
        frm.CargarDatos(Id)
        frm.ShowDialog()

    End Sub

    Private Sub txtBuscar_LostFocus(sender As Object, e As System.EventArgs) Handles txtBuscar.LostFocus

    End Sub

    Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscar.TextChanged
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim buscar As String
        Dim sqlstring As String = ""
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        ' Dim da As New OleDbDataAdapter
        Dim i, n As Integer
        'Try
        ' conexion.Open()
        'lstOraciones.Items.Clear()

        buscar = Me.txtBuscar.Text

        filtro = " SELECT SEL, TextoPlano, Traduccion, Estatus, Oracion, Id, GrupoO, Ora_Aprendido from Oraciones"
        'sqlstring = "select  SEL, TextoPlano, Traduccion, Estatus, Oracion, Id, GrupoO from Oraciones "
        ' sqlstring = sqlstring & " Where GrupoO= " & IdOracion '& "'"
        ' sqlstring = sqlstring & " Order By Oracion ASC"

        filtro = filtro & " Where TextoPlano LIKE " & "'%" & buscar & "%'"
        filtro = filtro & " ORDER BY Oraciones.TextoPlano ASC"

        Try
            _comando.CommandText = filtro
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)


        Catch ex As Exception
            MsgBox(ex.Message)

        Finally

        End Try
        _comando.Connection.Close()

        n = dt.Rows.Count

        dgvVerbs.DataSource = dt


        Try
            dgvVerbs.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvVerbs.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvVerbs.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvVerbs.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvVerbs.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'dgvOraciones.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

            ' dgvOraciones.Columns(0).Visible = False
            'dgvOraciones.Columns(1).Visible = False

            ' dgvOraciones.Columns(3).Visible = False
            '  dgvOraciones.Columns(4).Visible = False
            dgvVerbs.Columns(5).Visible = False
            dgvVerbs.Columns(6).Visible = False
        Catch ex As Exception

        End Try








    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        frmNewOracion.Show()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim OracionEN As String
        Dim OracionES As String
        Dim SQL As String
        Dim Id As Integer
        Dim IdOracion As Integer

        ' OracionEN = txtOracionEN.Text
        '  OracionES = txtOracionES.Text
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        _comando.Connection.Open()
        Dim IdPerson As Integer

        IdPerson = 0
        Id = 6004

        For Each r In dgvVerbs.Rows

            ' IdOracion = dgvOraciones.CurrentRow.Cells(5).Value.ToString()
            IdOracion = r.Cells(5).Value.ToString()

            sqlstring = ""
            'Dim IdOracion As Integer
            'Dim dt As New DataTable
            'Dim da As New SqlDataAdapter
            'Dim i As Integer

            ' sqlstring = "select * from  SubTemas "
            '    conexion.Open()
            'Select Case cmbPersona.Text
            '    Case "Lisa"
            '        IdPerson = 1

            '    Case "Steve"
            '        IdPerson = 2

            '    Case "Maggie"
            '        IdPerson = 3

            '    Case "Marge"
            '        IdPerson = 4

            '    Case "Mark"
            '        IdPerson = 5

            '    Case "Homer"
            '        IdPerson = 6
            '    Case "Doctor"
            '        IdPerson = 9

            'End Select


            'Try
            '    'If lstOraciones.SelectedItems(0).Text = "" Then Exit Sub

            'Catch ex As Exception
            '    'Exit Sub
            'End Try

            'IdOracion = lstOraciones.SelectedItems(0).Text
            'Desc = lstOraciones.SelectedItems(0).Text


            sqlstring = "Insert into det_Conversation (Det_OracionId, Det_Orden, Con_Id, Det_Person)"
            sqlstring = sqlstring & " Values ('" & IdOracion & "', '0', '" & Id & "', '" & IdPerson & "')"

            '  _comando.Connection = conexion
            _comando.CommandText = sqlstring




            Try

                i = _comando.ExecuteNonQuery

                If i > 0 Then
                    'MsgBox("se guardo")

                Else
                    'MsgBox("No se guardo")
                End If


            Catch ex As Exception
                MsgBox(ex.Message)
            Finally

            End Try

            'txtBuscar.Text = ""

        Next
        _comando.Connection.Close()

        'If cmbPersona.Text = "" Then Exit Sub


        'Agrega a Conversacion
        ' Dim _comando As SqlCommand = MetodosDatos.CrearComando()

    End Sub

    Private Sub dgvOraciones_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvVerbs.CellContentClick

    End Sub

    Private Sub dgvOraciones_DefaultValuesNeeded(sender As Object, e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgvVerbs.DefaultValuesNeeded

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim OracionId As Integer
        Dim OracionES As String

        ' OracionEN = RichTextBoxEx1.rtb.Text
        ' OracionES = txtTraduccion.Text

        OracionId = dgvVerbs.CurrentRow.Cells(5).Value.ToString()

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i As Integer


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

    Private Sub CmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub
End Class