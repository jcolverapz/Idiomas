Imports System.Data
Imports System.Data.OleDb
Imports System.Data.SqlClient

Public Class FrmVocabulario
    ' Public conexion As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\legacy\Ingles\Ingles.accdb")
    Public instruccion As New OleDbCommand
    Public contenedor As String
    Public sqlstring As String

    Public Shared IdEnc As Integer
    Public consulta As String
    Dim rowcount As Integer
    Public filtro As String
    Public Color1 As Color = System.Drawing.Color.FromArgb(253, 239, 202)
    Public Color2 As Color = System.Drawing.Color.FromArgb(254, 254, 180)

    Public Color3 As Color = System.Drawing.Color.FromArgb(209, 235, 222)
    Public Color4 As Color = System.Drawing.Color.FromArgb(31, 92, 60)

    Public Color5 As Color = System.Drawing.Color.FromArgb(254, 180, 180)
    Public Color6 As Color = System.Drawing.Color.FromArgb(19, 49, 57)
    Public maxColumna As Integer

    Dim dt As New DataTable
    Dim da As New SqlDataAdapter

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
        LlenaGrupos()
        ' LlenaConceptos("")

        dgvConceptos.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgvConceptos.RowTemplate.Height = 24



    End Sub
    Private Sub LlenaTipos()
        
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()

        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        sqlstring = "select * from Tipos"

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


        Try
           

            Me.dgvTipos.DataSource = dt
          
        Catch ex As Exception

            MsgBox(ex.Message)
        Finally
            'conexion.Close()

        End Try
    End Sub
    Private Sub LlenaConceptos(param)

      
        Dim sqlstring As String
        txtCant.Text = 0

        'Aprendidas /Falta
        If cmdAprendidas.Text = "Aprendidas" Then
            param = param & " Where Aprendi = 1"
        Else
            param = param & "  Where Aprendi = 0"
        End If

        'Usadas
        If chkUsadas.Text = "Mas Usadas" Then
            param = param & " And Uso = 1"
        Else
            param = param & " And Uso = 0"
        End If

        If chkTransparente.Text = "Transparentes" Then
            param = param & " And parecido = 1"
        Else
            param = param & " And parecido = 0"
        End If

        If chkContentWord.Text = "Content Word" Then
            param = param & " And ContentWord = 1"
        Else
            param = param & " And ContentWord = 0"
        End If

        'Grupo
        If cboGrupoTema.Text <> "" Then

            If cboGrupoTema.Text = "ALL" Then
            Else
                Dim GrupoId As Integer
                GrupoId = cboGrupoTema.Items(cboGrupoTema.SelectedIndex).ItemData()

                param = param & " And GrupoId = '" & GrupoId & "'"
            End If
           
        End If

      


        If param <> "" Then
        End If

        'Vocabulario
     
        filtro = " SELECT       ID, Concepto, Sel, Breve, Definicion, Tipo, Aprendi, GrupoID, Secuencia, IMG, parecido, Uso, Subtipo, ContentWord, Past, IPA, Uso2, Grupo2, Principal, Nodo, Tiempo, Cuenta"
        filtro = filtro & " FROM Conceptos"
        filtro = filtro & param

        filtro = filtro & " ORDER BY Concepto ASC"
        Console.WriteLine(filtro)

        dt.Clear()

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()

        Try
            _comando.CommandText = filtro
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)
            dt.AcceptChanges()

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        Try

            Me.dgvConceptos.DataSource = dt

            If dt.Rows.Count = 0 Then Exit Sub

        Catch ex As Exception

            MsgBox(ex.Message)
        

        End Try
        maxColumna = dt.Columns.Count

        Try
            dgvConceptos.Columns(0).Visible = False

        Catch ex As Exception

        End Try


        txtCant.Text = dt.Rows.Count


    End Sub
    Private Sub LlenaGrupos()
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim sqlstring As String

        'Grupos
        sqlstring = "SELECT        Id, Descripcion, ESTATUS, IDGrupoII, TipoID, Total, Aprendido, Usadas, Transparentes, Avance, Faltan, Orden, sel, SSMA_TimeStamp"
        sqlstring = sqlstring & " FROM Grupos"
        sqlstring = sqlstring & " ORDER BY Descripcion ASC"

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

        Try
            Dim i, n As Integer
            n = dt.Rows.Count
             
            cboGrupoTema.Items.Clear()
            cboGrupoTema.Items.Add("ALL")

            Do While i <= n - 1
                Me.cboGrupoTema.Items.Add(New clsItem(dt.Rows(i).Item(1), dt.Rows(i).Item(0)))
                i = i + 1
            Loop

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        _comando.Connection.Close()

    End Sub

    Private Sub dgvTipos_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvTipos.CellContentClick
        '  Me.dgvConceptos.Refresh()
        LlenaConceptos("")
    End Sub

    Private Sub dgvTipos_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles dgvTipos.MouseClick
        LlenaConceptos("")

    End Sub

    Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCant.TextChanged, txtbuscar.TextChanged
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim buscar As String
        Dim sqlstring As String = ""
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer

        buscar = Trim(Me.txtbuscar.Text)

        If buscar = "" Then Exit Sub

        If Len(buscar) < 1 Then Exit Sub

        _comando = MetodosDatos.CrearComando()


        'Vocabulario
        filtro = " SELECT       ID, Concepto, Sel, Breve, Definicion, Tipo, Aprendi, GrupoID, Secuencia, IMG, parecido, Uso, Subtipo, Past, IPA, Uso2, Grupo2, Principal, Nodo, Tiempo, Cuenta"
        filtro = filtro & " FROM Conceptos"
        filtro = filtro & " Where Concepto LIKE '%' + @Concepto + '%'"

        filtro = filtro & " ORDER BY Concepto ASC"
         

        Try
            _comando.CommandText = filtro

            _comando.Connection.Open()
            _comando.Parameters.AddWithValue("@Concepto", buscar)

            dt.Clear()

            da.SelectCommand = _comando

            da.Fill(dt)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try
        _comando.Connection.Close()

        n = dt.Rows.Count
        dt.AcceptChanges()

        dgvConceptos.DataSource = dt

        maxColumna = dt.Columns.Count

        Try
            dgvConceptos.Columns(0).Visible = False
            'dgvConceptos.Columns(1).Visible = False

            dgvConceptos.Columns(1).Width = 50
            dgvConceptos.Columns(2).Width = 50
            dgvConceptos.Columns(3).Width = 300
            dgvConceptos.Columns(4).Width = 300

            dgvConceptos.Columns(8).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

            'dgvConceptos.Columns(5).Visible = False
            'dgvConceptos.Columns(6).Visible = False
            'dgvConceptos.Columns(7).Visible = False

            
        Catch ex As Exception

        End Try

        n = dt.Rows.Count

        dgvConceptos.DataSource = dt

 





    End Sub

    Private Sub dgvConceptos_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConceptos.CellContentClick

    End Sub

    Private Sub dgvConceptos_CellEndEdit(sender As Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvConceptos.CellEndEdit
      
        'Vocabulario
       
        sqlstring = " SELECT       ID, Concepto, Sel, Breve, Definicion, Tipo, Aprendi, GrupoID, Secuencia, IMG, parecido, Uso, Subtipo, Past, IPA, Uso2, Grupo2, Principal, Nodo, Tiempo, Cuenta"
        sqlstring = sqlstring & " FROM Conceptos"


        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        _comando.Connection.Open()


        'da.Update(table)
        Dim builder As New SqlCommandBuilder(da)
        'Using cn As New SqlConnection("Your connection string")
        '**EDIT** Add line to re-establish connection for adapter
        da.SelectCommand = New SqlCommand(sqlstring, _comando.Connection)

        Try
            da.Update(dt)

        Catch ex As Exception

        End Try


        txtbuscar.Focus()
    End Sub

    Private Sub dgvConceptos_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvConceptos.CellFormatting
        'Set the background to red for negative values in the Balance column.

        Try
            If dgvConceptos.Columns(e.ColumnIndex).Name.Equals("Aprendi") Then

                If e.Value = True Then
                    For ColNo As Integer = 0 To maxColumna - 1
                        dgvConceptos.Rows(e.RowIndex).Cells(ColNo).Style.BackColor = Color3
                    Next
                 
                Else
                    For ColNo As Integer = 0 To maxColumna - 1
                        dgvConceptos.Rows(e.RowIndex).Cells(ColNo).Style.BackColor = Color5
                    Next
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub dgvConceptos_DoubleClick(sender As Object, e As System.EventArgs) Handles dgvConceptos.DoubleClick
        Dim Id As Integer
        Dim TipoTicket As String
        Dim frm As New FrmDetVocabulario

        AddOwnedForm(frm)

        ' sqlstring = " SELECT Tbl_Devices.,  Tbl_Devices., Tbl_Devices., Tbl_Devices."

        Id = dgvConceptos.CurrentRow.Cells(0).Value.ToString()
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
        frm.Id = Id
        frm.CargarDatos(Id)
        frm.ShowDialog()


    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        FrmNewWord.ShowDialog()


    End Sub

    Private Sub cboGrupoTema_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboGrupoTema.SelectedIndexChanged
        LlenaConceptos("")

    End Sub

    Private Sub cboTipos_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipos.SelectedIndexChanged
        Dim param As String


        'sqlstring = "select  SEL, TextoPlano, Traduccion, Estatus, Oracion, Id, GrupoO from Oraciones "
        ' sqlstring = sqlstring & " Where GrupoO= " & IdOracion '& "'"
        ' sqlstring = sqlstring & " Order By Oracion ASC"

        '  filtro = filtro & " Where Concepto LIKE " & "'%" & buscar & "%'"
        
        LlenaConceptos("")
       
    End Sub

    Private Sub chkTransparente_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkTransparente.CheckedChanged
        If chkTransparente.Text = "Transparentes" Then
            chkTransparente.Text = "No Transparentes"
        Else
            chkTransparente.Text = "Transparentes"
        End If

        LlenaConceptos("")

    End Sub

    Private Sub chkContentWord_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkContentWord.CheckedChanged
        If chkContentWord.Text = "Content Word" Then
            chkContentWord.Text = "No Content Word"
        Else
            chkContentWord.Text = "Content Word"
        End If

        LlenaConceptos("")

    End Sub

    Private Sub chkUsadas_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkUsadas.CheckedChanged
        If chkUsadas.Text = "Mas Usadas" Then
            chkUsadas.Text = "Menos Usadas"
        Else
            chkUsadas.Text = "Mas Usadas"
        End If

        LlenaConceptos("")

    End Sub

    Private Sub cmdAprendidas_Click(sender As System.Object, e As System.EventArgs) Handles cmdAprendidas.Click
        If cmdAprendidas.Text = "Aprendidas" Then
            cmdAprendidas.Text = "Falta"
            cmdAprendidas.BackColor = Color.LightGray
        Else
            cmdAprendidas.Text = "Aprendidas"
            cmdAprendidas.BackColor = Color.LightGreen
        End If

        LlenaConceptos("")

    End Sub
End Class