Imports System.Data
'Imports System.Data.OleDb
Imports Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop
Imports System.Data.SqlClient
Public Class frmGrupos

    Private Sub CmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()
    End Sub
    Public Sub CargarDatos()
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        sqlstring = " SELECT      Id, Orden, Grupo,   estatus, Nivel, Observaciones"
        sqlstring = sqlstring & " FROM Grupos_oracion"
        sqlstring = sqlstring & " ORDER By Orden ASC"
        Try


            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)
            dgvGrupos.DataSource = dt
            ' MaxColumna = dgvOraciones.ColumnCount

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        Try
            dgvGrupos.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvGrupos.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvGrupos.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvGrupos.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvGrupos.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvGrupos.Columns(5).Width = 300
            'dgvGrupos.Columns(5).Visible = False
            ' dgvGrupos.Columns(6).Visible = False

        Catch ex As Exception

        End Try

        'dgvOraciones.Columns(7).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'dgvOraciones.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

        ' dgvOraciones.Columns(0).Visible = False
        'dgvOraciones.Columns(1).Visible = False

        ' dgvOraciones.Columns(3).Visible = False
        '  dgvOraciones.Columns(4).Visible = False


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

    Private Sub frmGrupos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        CargarDatos()

    End Sub


    Private Sub dgvGrupos_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvGrupos.DoubleClick
        Dim Id As Integer
        Dim TipoTicket As String
        Dim frm As New frmDetGrupo

        AddOwnedForm(frm)

        
        Id = dgvGrupos.CurrentRow.Cells(0).Value.ToString()
     
        frm.IdGrupo = Id
        frm.CargarDatos(Id)
        frm.ShowDialog()

    End Sub

    Private Sub cmdOrdenar_Click(sender As System.Object, e As System.EventArgs) Handles cmdOrdenar.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, j As Integer

        i = 1

        _comando.Connection.Open()


        For Each r In dgvGrupos.Rows

            _comando.Parameters.Clear()
            

            sqlstring = "UPDATE Grupos_oracion SET Orden = @Orden"
            sqlstring = sqlstring & " WHERE  Id = @Id"

            _comando.Parameters.AddWithValue("@Orden", i)
            _comando.Parameters.AddWithValue("@Id", r.cells(0).value.ToString())

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

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer


        sqlstring = "Insert into Grupos_oracion (Grupo, estatus)"
        sqlstring = sqlstring & " Values ('" & txtDescripcion.Text & "', '1')"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()
        Try
            i = _comando.ExecuteNonQuery

            If i > 0 Then
                MsgBox("se guardo")

            Else
                '  MsgBox("No se guardo")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        _comando.Connection.Close()
        

        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscar.TextChanged
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()

        Dim buscar As String
        Dim sqlstring As String = ""

        Dim i, n As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        buscar = Trim(Me.txtBuscar.Text)

        If Len(buscar) < 1 Then Exit Sub

        sqlstring = " SELECT      Id, Orden, Grupo,   estatus, Nivel, Observaciones"
        sqlstring = sqlstring & " FROM Grupos_oracion"
        sqlstring = sqlstring & " Where Grupo LIKE '%' + @Grupo + '%'"
        sqlstring = sqlstring & " ORDER By Orden ASC"
        _comando.CommandText = sqlstring

        Try
            _comando.Connection.Open()

            _comando.Parameters.AddWithValue("@Grupo", buscar)
            da.SelectCommand = _comando

            da.Fill(dt)
            dgvGrupos.DataSource = dt
            
            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        Try
            dgvGrupos.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvGrupos.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvGrupos.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvGrupos.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvGrupos.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvGrupos.Columns(5).Width = 300
            'dgvGrupos.Columns(5).Visible = False
            ' dgvGrupos.Columns(6).Visible = False
        Catch ex As Exception

        End Try

    End Sub
End Class