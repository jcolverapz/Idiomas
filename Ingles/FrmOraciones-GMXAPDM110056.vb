Imports System.Data
Imports System.Data.OleDb
Imports Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop

Public Class FrmOraciones
    Public conexion As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\legacy\Ingles\Ingles.accdb")
    Public instruccion As New OleDbCommand
    Public contenedor As String
    Public sqlstring As String

    Public Shared IdEnc As Integer
    Public consulta As String
    Dim rowcount As Integer
    Private Sub FrmOraciones_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'cargarDatos()

        Dim sqlstring As String
        Dim cmd As New OleDbCommand

        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter
        Try
            conexion.Open()

            sqlstring = "select * from  Grupos_oracion "
            sqlstring = sqlstring & " ORDER By Grupo ASC"

            cmd.Connection = conexion
            cmd.CommandText = sqlstring
            da.SelectCommand = cmd

            da.Fill(dt)

            Me.cboGrupo.DataSource = dt
            Me.cboGrupo.ValueMember = "Id"
            Me.cboGrupo.DisplayMember = "Grupo"


        Catch ex As Exception

            MsgBox(ex.Message)
        Finally
            conexion.Close()

        End Try

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
    Public Sub CargarSubtemas(IdOracion)
        Dim sqlstring As String
        Dim cmd As New OleDbCommand

        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter
        Try
            conexion.Open()

            sqlstring = "select GrupoO, Oracion from Oraciones "
            sqlstring = sqlstring & " Where GrupoO= " & IdOracion '& "'"
            sqlstring = sqlstring & " Order By Oracion ASC"

            cmd.Connection = conexion
            cmd.CommandText = sqlstring
            da.SelectCommand = cmd

            da.Fill(dt)

            dgvOraciones.DataSource = dt

        Catch ex As Exception

            MsgBox(ex.Message)
        Finally
            conexion.Close()

        End Try

        ' Dim column2 = New datag
        '  column2.HeaderText = "Text"
        ' column2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        'dgvOraciones.Columns(1).DefaultCellStyle.Format. = DataGridViewAutoSizeColumnMode.DisplayedCells
        'DataGridView1.Columns("Codigo").DefaultCellStyle.Format = "#,##0.00"
        'dgvOraciones.Columns(1).DefaultCellStyle.Format = DataGridView
        dgvOraciones.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'dgvOraciones.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

     

    End Sub
    'customize the TextBoxCellRenderer



      

    Private Sub cboGrupo_LostFocus(sender As Object, e As System.EventArgs) Handles cboGrupo.LostFocus
        Dim IdGrupo As Integer
        If Me.cboGrupo.Text = "" Then Exit Sub
        If Me.cboGrupo.SelectedIndex < 1 Then Exit Sub
        IdGrupo = Me.cboGrupo.SelectedValue

        CargarSubtemas(IdGrupo)
    End Sub

    Private Sub cboGrupo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboGrupo.SelectedIndexChanged
        
    End Sub
End Class