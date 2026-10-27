Imports Entidades
Imports Negocios
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Data.SqlClient

Imports System.IO
Imports SpeechLib
Imports System.Speech.Synthesis

Imports System.Speech.AudioFormat


Public Class frmDuplicados
    Public maxColumna As Integer
    Private Sub frmDuplicados_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            dgvGeneral.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvGeneral.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvGeneral.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvGeneral.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvGeneral.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            ' d'gvGeneral.Columns(5).Visible = False
            ' dgvGeneral.Columns(6).Visible = False

        Catch ex As Exception

        End Try
        Dim col As New DataGridViewTextBoxColumn
        col.DataPropertyName = "PropertyName"
        col.HeaderText = "Id"
        col.Name = "Id"
        col.Width = 0
        dgvDetalles.Columns.Add(col)
        Dim col2 As New DataGridViewTextBoxColumn

        col2.DataPropertyName = "PropertyName"
        col2.HeaderText = "Texto"
        col2.Name = "Texto"
        col2.Width = 300

        dgvDetalles.Columns.Add(col2)
        Dim col3 As New DataGridViewTextBoxColumn
        col3.Width = 300

        col3.DataPropertyName = "PropertyName"
        col3.HeaderText = "Traduccion"
        col3.Name = "Traduccion"

        dgvDetalles.Columns.Add(col3)
        Dim col4 As New DataGridViewTextBoxColumn
        col4.DataPropertyName = "PropertyName"
        col4.HeaderText = "Cuenta"
        col4.Name = "Cuenta"
        col4.Width = 100
        dgvDetalles.Columns.Add(col4)

        maxColumna = 4
    End Sub
    Private Sub CmdClose_Click(sender As System.Object, e As System.EventArgs) Handles CmdClose.Click
        Me.Close()
        Me.Dispose()

    End Sub
    Private Sub cmdDuplicados_Click(sender As System.Object, e As System.EventArgs) Handles CmdDuplicados.Click
        Dim i As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim obj As New Label
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim textoOriginal As String = ""
        Dim textoModificado As String = ""
        Dim objDataReader As SqlDataReader
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim n As Integer
        Dim sqlstring As String

       
        sqlstring = "   SELECT        COUNT(Id) AS Cuenta, TextoPlano, traduccion"
        sqlstring = sqlstring & "  FROM Oraciones"
        sqlstring = sqlstring & "  GROUP BY TextoPlano,traduccion"
        sqlstring = sqlstring & "        HAVING(COUNT(Id) > 1)"
        sqlstring = sqlstring & "  ORDER BY Cuenta DESC"

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        n = dt.Rows.Count
        i = 0

        dgvGeneral.DataSource = dt
         
        _comando.Connection.Close()

        dgvGeneral.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgvGeneral.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'dgvGeneral.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'dgvGeneral.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        ' dgvGeneral.Columns(4).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Dim texto As String

      

        'col.DataPropertyName = "PropertyName"
        'col.HeaderText = "Cuenta"
        'col.Name = "Cuenta"

        'dgvDetalles.Columns.Add(col)
        pbAvance.Maximum = dt.Rows.Count
        pbAvance.Value = 0
        dgvDetalles.Rows.Clear()

        Do While i <= n - 1

            texto = dt.Rows(i).Item(1)

            CargarDetalles(texto)
            pbAvance.Value = pbAvance.Value + 1
            i = i + 1
        Loop

        txtCuenta.Text = dgvDetalles.Rows.Count



    End Sub

    Private Sub CargarDetalles(texto)
        Dim Id, j As Integer
        Dim TextoPlano As String
        Dim sqlstring As String
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim i As Integer
        Dim n As Integer
        Dim obj As New Label
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim objDataReader As SqlDataReader

        _comando.Connection.Open()

        Dim celda As DataGridViewCell

        ' Obtén el valor actual del texto y reemplaza el caracter
        Dim valorActual As String
        Dim valorModificado As String

        Try
            'Eliminar
            sqlstring = " Select Id, Oracion, TextoPlano, Traduccion FROM Oraciones"

            sqlstring = sqlstring & " Where TextoPlano = @TextoPlano"
            sqlstring = sqlstring & " ORDER BY TextoPlano ASC"

            _comando.CommandText = sqlstring
            _comando.Parameters.Clear()
            _comando.Parameters.AddWithValue("@TextoPlano", texto)

        Catch ex As Exception
        End Try

        da.SelectCommand = _comando

        da.Fill(dt)
        n = dt.Rows.Count

        Dim value1, value2, value3, value4 As String

        _comando.Connection.Close()

        _comando.Connection.Open()

        Do While i <= n - 1
              
            value1 = dt.Rows(i).Item(0)
            value2 = dt.Rows(i).Item(2)
            Try
                value3 = dt.Rows(i).Item(3)

            Catch ex As Exception

            End Try
            value4 = 0

            Try
 
                sqlstring = "  SELECT       COUNT(Det_Con) AS Cuenta"
                sqlstring = sqlstring & "  FROM Det_Conversation "
                sqlstring = sqlstring & "   WHERE Det_OracionId = '" & value1 & "'"

                _comando.CommandText = sqlstring

                Try
                    Try

                        objDataReader = _comando.ExecuteReader

                        If objDataReader.HasRows Then
                            objDataReader.Read()
                            value4 = objDataReader(0)
                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                    objDataReader.Close()


                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            dgvDetalles.Rows.Insert(0, New String() {value1, value2, value3, value4})

            i = i + 1

        Loop

        _comando.Connection.Close()


        'Try

        '    objDataReader = _comando.ExecuteReader

        'Do While objDataReader.HasRows = True
        '    objDataReader.Read()

        '    value1 = objDataReader(0)
        '    value2 = objDataReader(1)
        '    value3 = objDataReader(2)
        '    value4 = objDataReader(3)

        '    dgvDetalles.Rows.Insert(0, New String() {value1, value2, value3, value4})

        '    objDataReader.NextResult()

        'Loop

        _comando.Connection.Close()


    End Sub



    Private Sub cmdEliminar_Click(sender As System.Object, e As System.EventArgs) Handles cmdEliminar.Click
        Dim Id, j As Integer
        Dim TextoPlano As String
        Dim sqlstring As String
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim i As Integer
        Dim n As Integer
        Dim obj As New Label
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        _comando.Connection.Open()

        For Each RW As DataGridViewRow In dgvDetalles.Rows
            If RW.Selected = True Then

                Id = RW.Cells(0).Value.ToString()

                Try
                    sqlstring = " DELETE FROM Oraciones"
                    sqlstring = sqlstring & " WHERE (Id = '" & Id & "')"

                    _comando.CommandText = sqlstring

                    Try
                        j = _comando.ExecuteNonQuery

                        'dgvDetalles.Rows.Remove(RW)
                        'dgvDetalles.Rows.RemoveAt(RW.Index)
                    Catch ex As Exception

                    End Try

                Catch ex As Exception
                End Try
                 
            End If
             

        Next
        _comando.Connection.Close()

        cmdDuplicados_Click(sender, e)

        txtBuscar.Text = ""


    End Sub

    Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscar.TextChanged, txtCuenta.TextChanged

        If Len(Trim(txtBuscar.Text)) < 3 Then Exit Sub
        'If Trim(txtBuscar.Text) = "" Then Exit Sub

        Dim Id, j As Integer
        Dim TextoPlano As String
        Dim sqlstring As String
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim i As Integer
        Dim n As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim objDataReader As SqlDataReader

        Try
            'Eliminar
            sqlstring = " Select Id, Oracion,TextoPlano, Traduccion FROM Oraciones"

            sqlstring = sqlstring & " Where TextoPlano LIKE " & "'%" & Trim(txtBuscar.Text) & "%'"
            sqlstring = sqlstring & " ORDER BY TextoPlano ASC"

            '  _comando.Parameters.AddWithValue("@TextoPlano", TextoPlano)

            _comando.CommandText = sqlstring

            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)
            dgvDetalles.Columns.Clear()

            dgvDetalles.DataSource = dt

            Dim col As New DataGridViewTextBoxColumn
            col.DataPropertyName = "PropertyName"
            col.HeaderText = "Cuenta"
            col.Name = "Cuenta"

            dgvDetalles.Columns.Add(col)
        Catch ex As Exception
        End Try

        _comando.Connection.Close()

        dgvDetalles.Columns(0).Visible = False

        dgvDetalles.Columns(1).Width = 300
        dgvDetalles.Columns(2).Width = 300
        '  dgvDetalles.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        'dgvDetalles.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        dgvDetalles.Columns(1).Visible = False



        Dim celda As DataGridViewCell

        ' Obtén el valor actual del texto y reemplaza el caracter
        Dim valorActual As String
        Dim valorModificado As String

        For Each RW As DataGridViewRow In dgvDetalles.Rows

            Try

                Id = RW.Cells(0).Value.ToString()
                'Obtén la celda
                'celda = RW.Cells(3)


                sqlstring = "  SELECT       COUNT(Det_Con) AS Cuenta"
                sqlstring = sqlstring & "  FROM Det_Conversation "
                sqlstring = sqlstring & "   WHERE Det_OracionId = '" & Id & "'"

                _comando.CommandText = sqlstring
                _comando.Connection.Open()

                Try
                    Try

                        objDataReader = _comando.ExecuteReader

                        If objDataReader.HasRows Then
                            objDataReader.Read()

                            RW.Cells(4).Value = objDataReader(0)

                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                    _comando.Connection.Close()

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            Catch ex As Exception
            End Try



        Next
        _comando.Connection.Close()

        maxColumna = 4


    End Sub

   


    Private Sub dgvGeneral_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvGeneral.CellContentClick

    End Sub

    Private Sub dgvDetalles_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvDetalles.CellContentClick

    End Sub

    Private Sub dgvDetalles_CellFormatting(sender As Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles dgvDetalles.CellFormatting
        Try
            If dgvDetalles.Columns(e.ColumnIndex).Name.Equals("Cuenta") Then

                If e.Value < 1 Then
                    For ColNo As Integer = 0 To maxColumna
                        dgvDetalles.Rows(e.RowIndex).Cells(ColNo).Style.BackColor = Color.LightGreen
                    Next
                Else
                    For ColNo As Integer = 0 To maxColumna
                        dgvDetalles.Rows(e.RowIndex).Cells(ColNo).Style.BackColor = Color.Salmon
                    Next
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
End Class