Imports System.Data
Imports System.Data.OleDb
Public Class FrmVocabulario
    Public conexion As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\legacy\Ingles\Ingles.accdb")
    Public instruccion As New OleDbCommand
    Public contenedor As String
    Public sqlstring As String

    Public Shared IdEnc As Integer
    Public consulta As String
    Dim rowcount As Integer
    Private Sub CmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub

    Private Sub FrmVocabulario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ' Dim sqlstring As String
        Dim cmd As New OleDbCommand

        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter

        'Tipos
        LlenaTipos()
        LlenaConceptos()
       
    End Sub
    Private Sub LlenaTipos()
        'TODO: esta línea de código carga datos en la tabla 'InglesDataSet.Conceptos' Puede moverla o quitarla según sea necesario.
        ' Me.ConceptosTableAdapter.Fill(Me.InglesDataSet.Conceptos)
        Dim sqlstring As String
        Dim cmd As New OleDbCommand

        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter


        Try
            conexion.Open()

            sqlstring = "select * from Tipos"
            cmd.Connection = conexion
            cmd.CommandText = sqlstring
            da.SelectCommand = cmd

            da.Fill(dt)



            Me.dgvTipos.DataSource = dt
          
            dgvTipos.Columns(0).Visible = False
            dgvTipos.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvTipos.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

            dgvTipos.Columns(2).Visible = True
            dgvTipos.Columns(3).Visible = False

            'dgvVocabluario.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'dgvEncDatos.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '  dgvEncDatos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            'dgvEncDatos.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'Datagrid.Columns[0].AutoSizeMode =DataGridViewAutoSizeColumnMode.Fill
            '  dgvEncDatos.Columns(0).AutoSizeMode = True
            'dgvEncDatos.Columns(0).MinimumWidth = True

            'Me.cboGrupoTema.DataSource = dt
        Catch ex As Exception

            MsgBox(ex.Message)
        Finally
            conexion.Close()

        End Try
    End Sub
    Private Sub LlenaConceptos()

        Dim sqlstring As String
        Dim cmd As New OleDbCommand

        Dim dt As New DataTable
        Dim da As New OleDbDataAdapter
        'Conceptos
        Try
            conexion.Open()

            sqlstring = "SELECT Grupos.Id, Grupos.Descripcion, Grupos.ESTATUS, Grupos.IDGrupoII, Grupos.TipoID, Grupos.Total, Grupos.Aprendido, Grupos.Usadas, Grupos.Transparentes, Grupos.Avance, Grupos.Faltan, Grupos.Orden, Tipos.TSEL"
            sqlstring = sqlstring & " FROM Tipos INNER JOIN Grupos ON Tipos.Id = Grupos.TipoID"
            sqlstring = sqlstring & " WHERE(((Tipos.TSEL) = True))"
            sqlstring = sqlstring & " ORDER BY Grupos.Descripcion"


            'sqlstring = "SELECT  Conceptos.Id, Conceptos.uso, Conceptos.Concepto as Palabra,  Conceptos.definicion as Traduccion, Conceptos.IPA, Conceptos.subtipo, Conceptos.aprendi,"
            'sqlstring = sqlstring & "Conceptos.tipo, Conceptos.Sel, Conceptos.parecido, Grupos.Id, Grupos.TipoID "
            'sqlstring = sqlstring & " FROM Tipos INNER JOIN (Grupos INNER JOIN Conceptos ON Grupos.Id = Conceptos.GrupoID) ON Tipos.Id = Grupos.TipoID "
            ''sqlstring = "WHERE Conceptos.Concepto Like '*cut*' ORDER BY conceptos.Concepto "

            'FROM Tipos INNER JOIN (Grupos INNER JOIN Conceptos ON Grupos.Id = Conceptos.GrupoID) ON Tipos.Id = Grupos.TipoID
            'WHERE (((Conceptos.Concepto) Like '*cut*'))
            'ORDER BY Conceptos.Concepto;

            'sqlstring = "select * from Conceptos"
            cmd.Connection = conexion
            cmd.CommandText = sqlstring
            da.SelectCommand = cmd

            da.Fill(dt)

            Me.dgvConceptos.DataSource = dt
            ' Me.dgvVocabluario.DataSource = dt

            dgvConceptos.Columns(0).Visible = False
            dgvConceptos.Columns(1).Visible = True
            dgvConceptos.Columns(2).Visible = False
            dgvConceptos.Columns(2).Visible = False

            'dgvVocabluario.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'dgvVocabluario.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'dgvEncDatos.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            '  dgvEncDatos.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter
            'dgvEncDatos.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            'Datagrid.Columns[0].AutoSizeMode =DataGridViewAutoSizeColumnMode.Fill
            '  dgvEncDatos.Columns(0).AutoSizeMode = True
            'dgvEncDatos.Columns(0).MinimumWidth = True

            'Me.cboGrupoTema.DataSource = dt

        Catch ex As Exception

            MsgBox(ex.Message)
        Finally
            conexion.Close()

        End Try
    End Sub


    Private Sub dgvTipos_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTipos.CellContentClick
        '  Me.dgvConceptos.Refresh()
        LlenaConceptos()
    End Sub

    Private Sub dgvTipos_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvTipos.MouseClick
        LlenaConceptos()

    End Sub
End Class