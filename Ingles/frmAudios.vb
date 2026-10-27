Imports System.Data
'Imports System.Data.OleDb
'Imports Microsoft.Office.Interop.Word
'Imports Microsoft.Office.Interop
Imports System.Data.SqlClient

Public Class frmAudios

    Private Sub cmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles cmdCerrar.Click
        Me.Close()

    End Sub

    Private Sub frmAudios_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        CargarDatos("")


        cboTipo.Items.Add("Saludo")
        cboTipo.Items.Add("Iniciando")
        cboTipo.Items.Add("Conversacion")
        cboTipo.Items.Add("Leccion")
        cboTipo.Items.Add("Serie")
        ' cboTipo.Items.Add("Iniciando")

    End Sub
    Public Sub CargarDatos(param)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
            
        sqlstring = "select * from  Tbl_Audios "
        sqlstring = sqlstring & param
        'sqlstring = sqlstring & " ORDER By Con_orden ASC"

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


        'dgvOraciones.Columns(0).Visible = False
        '    ' dgvOraciones.Columns(3).Visible = False
        'dgvOraciones.Columns(4).Visible = False
        '    ' dgvOraciones.Columns(4).Visible = False

        'dgvOraciones.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        '    ' dgvOraciones.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'dgvOraciones.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        '    ' dgvOraciones.Columns(6).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'dgvOraciones.Columns(6).Visible = False
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

    

    Private Sub dgvOraciones_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvOraciones.DoubleClick
        Dim Id As Integer
        Dim TipoTicket As String
        Dim frm As New frmItemAudio

        AddOwnedForm(frm)

        Id = dgvOraciones.CurrentRow.Cells(0).Value.ToString()

        frm.Id = Id
        ' frm.lbltitulo.Text = dgvOraciones.CurrentRow.Cells(1).Value.ToString()
        'frm.CargarConversation(Id)
        Try
            frm.ShowDialog()

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        'Dim param As String

        'param = " Where Con_Tipo='" & cboTipo.Text & "'"
        'CargarDatos(param)

    End Sub

    Private Sub dgvOraciones_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvOraciones.CellContentClick

    End Sub
End Class