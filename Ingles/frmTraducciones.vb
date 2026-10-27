Imports System.Data
'Imports System.Data.OleDb
Imports Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop
Imports System.Data.SqlClient
Imports WMPLib

Public Class frmTraducciones
    Public EncId As Integer
    Dim dt As DataTable

    Private Sub frmTraducciones_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load


        ListView1.View = System.Windows.Forms.View.Details ' Set the view to show details.
        ListView1.LabelEdit = False ' Allow the user to edit item text.
        ListView1.AllowColumnReorder = True ' Allow the user to rearrange columns.
        ListView1.FullRowSelect = True ' Select the item and subitems when selection is made.
        ListView1.GridLines = True ' Display grid lines.


        CargarDatos("")

    End Sub
    Public Sub CargarDatos(param)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer

        sqlstring = " SELECT Dialogos.OracionId, Oraciones.TextoPlano, Oraciones.Traduccion, "
        sqlstring = sqlstring & " Dialogos.Id"
        sqlstring = sqlstring & " FROM            Dialogos INNER JOIN"
        sqlstring = sqlstring & "                 Oraciones ON Dialogos.OracionId = Oraciones.Id INNER JOIN"
        sqlstring = sqlstring & "                Det_Conversation ON Dialogos.DetConversacion = Det_Conversation.Det_Con"
        sqlstring = sqlstring & " Where Det_Conversation.Con_Id='" & EncId & "'"

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

        dgvOraciones.DataSource = dt

        Try
            dgvOraciones.Columns(0).Visible = False
            'dgvOraciones.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            ' dgvOraciones.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
            dgvOraciones.Columns(1).Width = 200
            dgvOraciones.Columns(2).Width = 200
            'dgvOraciones.Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            'dgvOraciones.Columns(3).Width = 50
            ''dgvOraciones.Columns(2).Width = 100
            'dgvOraciones.Columns(4).Width = 300
            'dgvOraciones.Columns(5).Width = 300
            '' 
            'dgvOraciones.Columns(6).Visible = False
            'dgvOraciones.Columns(7).Visible = False
            'dgvOraciones.Columns(9).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Catch ex As Exception

        End Try
        ' LvwAssigned.Items.Clear()

        i = 0
        n = dt.Rows.Count
        If n = 0 Then Exit Sub



    End Sub
    Public Sub CargarDatos2(filtro)
        ' Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        ' Dim sqlstring As String

        ' If filtro = Nothing Then Exit Sub

        'sqlstring = "Select  Oraciones.Id, Oraciones.orden,  Oraciones.Audio, Oraciones.STL,  Oraciones.TextoPlano, Oraciones.Traduccion, Oraciones.Estatus, Oraciones.Oracion, Oraciones.GrupoO, Grupos_oracion.Grupo, "
        'sqlstring = sqlstring & "Oraciones.foco, Oraciones.Palabras"
        'sqlstring = sqlstring & " FROM            Oraciones INNER JOIN  Grupos_oracion ON Oraciones.GrupoO = Grupos_oracion.Id"
        'sqlstring = sqlstring & filtro
        'sqlstring = sqlstring & " Order By orden ASC"

        'dgvOraciones.DataSource = Nothing
        '' dt.Rows.Clear()

        'Try
        '    _comando.CommandText = sqlstring
        '    _comando.Connection.Open()

        '    ' da.SelectCommand = _comando
        '    ' da.Fill(dt)
        '    ' dt.AcceptChanges()


        '    ' MaxColumna = dgvOraciones.ColumnCount
        '    '
        '    _comando.Connection.Close()

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally

        ' End Try
       



    End Sub
    Private Sub cmdExportarWord_Click(sender As System.Object, e As System.EventArgs) Handles cmdExportarWord.Click

        Dim oWord As Word.Application
        Dim oDoc As Word.Document

        Try
            oWord = New Word.Application()
            oWord.Visible = True ' Set to True to see Word open, False to run in background
            oDoc = oWord.Documents.Add()
            ' ... (rest of the code)
        Catch ex As Exception
            MessageBox.Show("Error exporting to Word: " & ex.Message)
        Finally

        End Try


        Dim r As Integer, c As Integer
        Dim oTable As Word.Table

        'Clipboard.SetText(LvwAssigned.SelectedItems.Item(0).SubItems(3).Text)


        ' Add a new table to the document
        '  oTable = oDoc.Tables.Add(oDoc.Bookmarks.Item("\endofdoc").Range, dgvOraciones.RowCount, dgvOraciones.ColumnCount)
        '   oTable.Range.ParagraphFormat.SpaceAfter = 6 ' Optional: Add spacing

        ' Add column headers
        ' For c = 0 To 3 'dgvOraciones.ColumnCount - 1
        'oTable.Cell(1, c).Range.Text = dgvOraciones.Columns(c).HeaderText
        ' oTable.Cell(1, c + 1).Range.Text = LvwAssigned.Columns(c).Name
        ' oTable.Cell(1, c).Range.Font.Bold = True ' Optional: Make headers bold
        ' Next
        Dim para As Word.Paragraph = oDoc.Content.Paragraphs.Add
        ' pbavance.Maximum = dgvOraciones.RowCount + 1
        ' Populate table with DataGridView data
        Dim item As ListViewItem 'Creo el ListViewItem (item) 
        For i = 0 To dgvOraciones.Rows.Count - 2 ' Exclude the potential new row in DataGridView


            ' Inserta la línea (por ejemplo, usando el código para una línea horizontal)
            ' Para una línea de guiones, usa "---" o "___"
            ' para.Range.InsertAfter("---")

            'para.Range.InsertAfter(vbCrLf) ' Inserta un salto de línea
            'If Len(dgvOraciones(2, r).Value) < 3 Then
            '    For c = 0 To 3
            '        oTable.Cell(r + 2, c).Range.Text = dgvOraciones(c, r).Value.ToString()
            '        ' oTable.Cell(r + 2, c + 1).Range.Text = LvwAssigned.Items(r).SubItems(3).Text
            '    Next
            '    '  pbavance.Value += 1
            'End If



            'Dim j As Integer

            '  If dgvOraciones(2, i).Value.ToString() = "" Then

            'para.Range.InsertAfter(dgvOraciones(1, i).Value.ToString())
            para.Range.InsertBefore(dgvOraciones(1, i).Value.ToString() & vbCrLf)

            '  End If


            ' i = i + 1

        Next

    End Sub

    Private Sub cmdClose_Click(sender As System.Object, e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim parametros() As String
        Dim Traducciones() As String

        Dim i As Integer
        Dim sqlstring As String
        Dim IdOracion As Integer

        Dim SQL As String
        Dim IdCon As Integer
        Dim j As Integer
        Dim textoOriginal As String = ""
        Dim textoModificado As String = ""
        Dim objDataReader As SqlDataReader
        Dim IdDet As Integer
        Dim IdGrupo As Integer
        Dim dt As New DataTable

        dt.Rows.Clear()
        dt.Columns.Clear()

        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Texto", GetType(String))
        dt.Columns.Add("Traduccion", GetType(String))
        dt.Columns.Add("Audio", GetType(String))
        dt.Columns.Add("Index", GetType(Integer))

        Traducciones = Split(txtTraduccion.Text, vbCrLf)

        _comando.Connection.Open()

        For Each p In parametros

            If Trim(p) <> "" Then

                Dim newRow As DataRow = dt.NewRow()

                newRow("Index") = i
                newRow("Texto") = Trim(p)

                _comando.Parameters.Clear()

                'buscar en Oraciones
                sqlstring = " SELECT Id, TextoPlano, Traduccion, Audio  FROM Oraciones"
                sqlstring = sqlstring & " Where TextoPlano = @TextoPlano"

                _comando.CommandText = sqlstring

                _comando.Parameters.AddWithValue("@TextoPlano", Trim(p))

                Try
                    objDataReader = _comando.ExecuteReader

                    If objDataReader.HasRows Then
                        objDataReader.Read()
                        newRow("ID") = objDataReader(0)
                        newRow("Traduccion") = objDataReader(2)
                        newRow("Audio") = objDataReader(3)
                    Else 'No existe

                        newRow("ID") = 0
                        newRow("Traduccion") = ""
                        newRow("Audio") = ""

                    End If

                    dt.Rows.Add(newRow)

                    i = i + 1

                Catch ex As Exception

                End Try
                objDataReader.Close()

            End If

        Next

        i = 0
        For Each p In Traducciones
            If Trim(p) <> "" Then
                Try
                    dt.Rows(i).Item(2) = Trim(p)
                Catch ex As Exception
                End Try
            End If
            i = i + 1
        Next

        IdGrupo = 6 'Frases basicas


        For Each rw In dt.Rows


            If rw.item(0) = 0 Then

                sqlstring = "Insert into Oraciones (TextoPlano, Traduccion, GrupoO)"
                sqlstring = sqlstring & " Values (@TextoPlano, @Traduccion, @GrupoO)"
                _comando.CommandText = sqlstring

                _comando.Parameters.Clear()
                _comando.Parameters.AddWithValue("@TextoPlano", rw.item(1))
                _comando.Parameters.AddWithValue("@Traduccion", "")
                _comando.Parameters.AddWithValue("@GrupoO", IdGrupo)

                j = _comando.ExecuteNonQuery


                If j > 0 Then
                    SQL = "SELECT @@IDENTITY FROM Oraciones"
                    _comando = New SqlCommand(SQL, _comando.Connection)
                    Dim value As Object = _comando.ExecuteScalar
                    IdOracion = value.ToString
                    rw.item(0) = IdOracion

                End If


            End If


        Next



        _comando.Connection.Close()

        dgvOraciones.DataSource = dt

        dgvOraciones.Columns(0).Width = 50
        dgvOraciones.Columns(1).Width = 300
        dgvOraciones.Columns(2).Width = 300

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        
        For r = 0 To dgvOraciones.Rows.Count - 2 ' Exclude the potential new row in DataGridView

            If Len(dgvOraciones(2, r).Value) < 3 Then
                For c = 0 To 3
                    'oTable.Cell(r + 2, c).Range.Text = dgvOraciones(c, r).Value.ToString()
                    ' oTable.Cell(r + 2, c + 1).Range.Text = LvwAssigned.Items(r).SubItems(3).Text
                Next
                '  pbavance.Value += 1
            End If


        Next
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        ' Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim parametros() As String
        Dim Traducciones() As String

        Dim i As Integer
        Dim sqlstring As String
        Dim IdOracion As Integer

        Dim SQL As String
        Dim IdCon As Integer
        Dim j As Integer
       

        i = 0


        Do While i < ListView1.Items.Count - 1
            ListView1.Items(i).SubItems(2).Text = ""
            i = i + 1
        Loop

        Traducciones = Split(txtTraduccion.Text, vbCrLf)
        i = 0
        For Each p In Traducciones
            If Trim(p) <> "" Then
                Try
                    'dt.Rows(i).Item(2) = Trim(p)
                    ListView1.Items(i).SubItems(2).Text = Trim(p)
                Catch ex As Exception
                End Try
            End If
            i = i + 1
        Next
          
        'dgvOraciones.DataSource = dt

        'dgvOraciones.Columns(0).Width = 50
        'dgvOraciones.Columns(1).Width = 300
        'dgvOraciones.Columns(2).Width = 300

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click

    End Sub

    Private Sub cmdBuscar_Click(sender As System.Object, e As System.EventArgs) Handles cmdBuscar.Click
        Dim Orden As Integer
        Dim r As Integer, c As Integer
        Dim sqlstring As String
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim i As Integer
        Dim texto As String
        Dim item As ListViewItem 'Creo el ListViewItem (item) 
        Dim IdOracion As Integer

        _comando.Connection.Open()
        ' Populate table with DataGridView data
        For r = 0 To dgvOraciones.RowCount - 2 ' Exclude the potential new row in DataGridView

            IdOracion = dgvOraciones(0, r).Value.ToString()
            texto = dgvOraciones(1, r).Value.ToString()

            ' If dgvOraciones(2, r).Value.ToString() = "" Then

            Dim Indice As Integer
            'i = ListView1.Items.Count + 1

            Dim foundItem As ListViewItem

            Try
                foundItem = ListView1.FindItemWithText(texto, True, 0, True)

                If (foundItem IsNot Nothing) Then
                    ' Orden = foundItem.Index
                    sqlstring = "UPDATE Oraciones SET Traduccion = @Traduccion"
                    sqlstring = sqlstring & " WHERE Id = @Id"
                    _comando.CommandText = sqlstring

                    _comando.Parameters.Clear()
                    _comando.Parameters.AddWithValue("@Traduccion", foundItem.SubItems(2).Text)
                    '_comando.Parameters.AddWithValue("@Traduccion", "")
                    _comando.Parameters.AddWithValue("@Id", IdOracion)

                    Try
                        i = _comando.ExecuteNonQuery

                    Catch ex As Exception
                    End Try

                    dgvOraciones(2, r).Value = foundItem.SubItems(2).Text

                End If

                foundItem = Nothing

            Catch ex As Exception
            End Try

            '  End If

        Next
        _comando.Connection.Close()

         
    End Sub

    Private Sub cmdTextoSplit_Click(sender As System.Object, e As System.EventArgs) Handles cmdTextoSplit.Click
        ListView1.Items.Clear()

        Dim item As ListViewItem 'Creo el ListViewItem (item) 
        For i = 0 To dgvOraciones.Rows.Count - 2 ' Exclude the potential new row in DataGridView
             
            If dgvOraciones(2, i).Value.ToString() = "" Then
                 
                item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 
                item.SubItems.Add(dgvOraciones(1, i).Value.ToString())
                item.SubItems.Add("")

                ListView1.Items.Add(item)
                 
            End If
             
            'i = i + 1
        Next
    End Sub
End Class