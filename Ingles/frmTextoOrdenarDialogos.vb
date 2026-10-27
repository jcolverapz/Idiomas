Imports Entidades
Imports Negocios
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Data.SqlClient
'Imports RichTextBoxEx
Imports System.IO
Imports SpeechLib


Public Class frmTextoOrdenarDialogos

    Public Id As Integer
    Dim LastIndex As Integer

    Private Sub frmTextoOrdenarDialogos_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim param As String

        param = " Where Det_Conversation.Con_Id='" & Id & "'"
        param = param & " ORDER BY Dialogos.Orden ASC"

        CargarDatos(param)

        ListView1.View = View.Details ' Set the view to show details.
        ListView1.LabelEdit = False ' Allow the user to edit item text.
        ListView1.AllowColumnReorder = True ' Allow the user to rearrange columns.
        ListView1.FullRowSelect = True ' Select the item and subitems when selection is made.
        ListView1.GridLines = True ' Display grid lines.

    End Sub
    Public Sub CargarDatos(param)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer

        sqlstring = " SELECT       Dialogos.OracionId,  Oraciones.TextoPlano, Dialogos.Id,  Dialogos.Orden, Det_Conversation.Con_Id, Oraciones.Traduccion, Det_Conversation.Det_Par, Oraciones.EsRespuesta, "
        sqlstring = sqlstring & "  Oraciones.EsRespuesta "
        sqlstring = sqlstring & " FROM            Dialogos INNER JOIN"
        sqlstring = sqlstring & "                 Oraciones ON Dialogos.OracionId = Oraciones.Id INNER JOIN"
        sqlstring = sqlstring & "                Det_Conversation ON Dialogos.DetConversacion = Det_Conversation.Det_Con"
        sqlstring = sqlstring & param

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

        lvwActual.Items.Clear()

        i = 0
        n = dt.Rows.Count
        If n = 0 Then Exit Sub
        Dim item As ListViewItem 'Creo el ListViewItem (item) 


        Do While i <= n - 1


            item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            item.UseItemStyleForSubItems = False

            Try
                item.SubItems.Add(dt.Rows(i).Item(0))
                item.SubItems.Add(dt.Rows(i).Item(1))
                item.SubItems.Add(dt.Rows(i).Item(2))
                item.SubItems.Add(dt.Rows(i).Item(3))

                ' item.SubItems.Add(dt.Rows(i).Item(9))
                'item.SubItems.Add("X")
                'item.SubItems.Add(dt.Rows(i).Item(6))
                ' item.SubItems.Add(dt.Rows(i).Item(1))

                'If dt.Rows(i).Item(6) = "Q" Then
                '    item.SubItems(2).ForeColor = Color.Blue
                '    item.SubItems(3).ForeColor = Color.Blue
                'ElseIf dt.Rows(i).Item(6) = "S" Then
                '    item.SubItems(2).ForeColor = Color.Fuchsia
                '    item.SubItems(3).ForeColor = Color.Fuchsia
                'ElseIf dt.Rows(i).Item(6) = "C" Then
                '    item.SubItems(2).ForeColor = Color.Black
                '    item.SubItems(3).ForeColor = Color.Black
                'ElseIf dt.Rows(i).Item(6) = "O" Then
                '    item.SubItems(2).ForeColor = Color.BlueViolet
                '    item.SubItems(3).ForeColor = Color.BlueViolet
                'ElseIf dt.Rows(i).Item(6) = "E" Then
                '    item.SubItems(2).ForeColor = Color.DarkGreen
                '    item.SubItems(3).ForeColor = Color.DarkGreen
                'Else
                '    item.SubItems(2).ForeColor = Color.Brown
                '    item.SubItems(3).ForeColor = Color.Brown

                'End If


                lvwActual.Items.Add(item)      'Agrego el item a la colección de listViewItem's de ListView1


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try



            i = i + 1

        Loop

      

        lvwActual.View = View.Details ' Set the view to show details.
        lvwActual.LabelEdit = False ' Allow the user to edit item text.
        lvwActual.AllowColumnReorder = True ' Allow the user to rearrange columns.
        lvwActual.FullRowSelect = True ' Select the item and subitems when selection is made.
        lvwActual.GridLines = True ' Display grid lines.

    End Sub
    Private Sub Button9_Click(sender As System.Object, e As System.EventArgs) Handles Button9.Click
        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub cmdOrdenar_Click(sender As System.Object, e As System.EventArgs) Handles cmdOrdenar.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim parameters() As String

        parameters = Split(txtTexto.Text, vbCrLf)

        Dim parameters2() As String
        Dim parameters3() As String

        'ListView1.Items.Clear()

        Dim i As Integer
        Dim dt As New DataTable

        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Texto", GetType(String))
        'dt.Columns.Add("Traduccion", GetType(String))
        ' dt.Columns.Add("Audio", GetType(String))
        ' dt.Columns.Add("Index", GetType(Integer))

        i = 0

        'Crear dt
        Dim sqlstring As String
        Dim IdOracion As Integer

        Dim SQL As String
        Dim IdCon As Integer
        Dim j As Integer
        Dim textoOriginal As String = ""
        Dim textoModificado As String = ""
        Dim objDataReader As SqlDataReader
        Dim IdDet As Integer

        parameters = Split(txtTexto.Text, vbCrLf)

        _comando.Connection.Open()

        For Each p In parameters

            If Trim(p) <> "" Then

                Dim newRow As DataRow = dt.NewRow()
                newRow("Texto") = Trim(p)

                _comando.Parameters.Clear()

                'buscar en Oraciones
                sqlstring = " SELECT Id, TextoPlano, Traduccion, Audio  FROM Oraciones"
                sqlstring = sqlstring & " Where TextoPlano = @TextoPlano"
                 
                _comando.CommandText = sqlstring

                _comando.Parameters.AddWithValue("@TextoPlano", Trim(p))

                objDataReader = _comando.ExecuteReader

                If objDataReader.HasRows Then
                    objDataReader.Read()
                    newRow("ID") = objDataReader(0)
                    'newRow("Traduccion") = objDataReader(2)
                    dt.Rows.Add(newRow)
                    'newRow("Audio") = objDataReader(3)
                Else
                    ' newRow("ID") = 0
                    ' newRow("Traduccion") = Trim(p)
                    ' newRow("Audio") = "N"
                End If

                'newRow("Index") = i


                objDataReader.Close()
            End If
        Next

        Dim n As Integer
        n = dt.Rows.Count
        '''
        Dim item As ListViewItem 'Creo el ListViewItem (item) 

        j = ListView1.Items.Count
        n = dt.Rows.Count
        i = 0
        Do While i < n
            item = New ListViewItem(j) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            item.UseItemStyleForSubItems = False

            Try
                item.SubItems.Add(dt.Rows(i).Item(0))
                item.SubItems.Add(dt.Rows(i).Item(1))
                'item.SubItems.Add(dt.Rows(i).Item(2))
                ' item.SubItems.Add("0")

                ListView1.Items.Add(item)      'Agrego el item a la colección de listViewItem's de ListView1

                i = i + 1
                j = j + 1
            Catch ex As Exception
            End Try
        Loop




    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        'Ordenar

        Dim Orden As String
        Dim r As Integer, c As Integer
        Dim sqlstring As String
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim i As Integer
        Dim IdOracion As Integer
        Dim IdDialogo As Integer

        _comando.Connection.Open()
        Dim n As Integer
        n = lvwActual.Items.Count
        Dim oracion As String


        For r = 0 To lvwActual.Items.Count - 1  ' Exclude the potential new row in DataGridView

            IdOracion = lvwActual.Items(r).SubItems(1).Text
            IdDialogo = lvwActual.Items(r).SubItems(3).Text
            oracion = lvwActual.Items(r).SubItems(2).Text

            If lvwActual.Items(r).SubItems(4).Text <> "" Then
                Orden = DetectChanges(oracion)

                sqlstring = "UPDATE Dialogos SET Orden = @Orden"
                sqlstring = sqlstring & " WHERE Id = @Id"
                _comando.CommandText = sqlstring

                _comando.Parameters.Clear()

                _comando.Parameters.AddWithValue("@Id", IdDialogo)

                If Orden <> "" Then
                    _comando.Parameters.AddWithValue("@Orden", Orden)
                Else
                    _comando.Parameters.AddWithValue("@Orden", 10000)
                End If

                Try
                    i = _comando.ExecuteNonQuery
                Catch ex As Exception
                End Try

                'n = n + 1
            ElseIf lvwActual.Items(r).SubItems(4).Text = 10000 Then

                sqlstring = "UPDATE Dialogos SET Orden = @Orden"
                sqlstring = sqlstring & " WHERE Id = @Id"
                _comando.CommandText = sqlstring

                _comando.Parameters.Clear()

                _comando.Parameters.AddWithValue("@Id", IdDialogo)

                Orden = DetectChanges(oracion)

                If Orden <> "" Then
                    Orden = CInt(Orden) + CInt(txtIndice.Text)
                    _comando.Parameters.AddWithValue("@Orden", Orden)
                Else
                    _comando.Parameters.AddWithValue("@Orden", 10000)
                End If

                Try
                    i = _comando.ExecuteNonQuery
                Catch ex As Exception
                End Try
            Else

            End If




        Next

        _comando.Connection.Close()

        Dim param As String

        param = " Where Det_Conversation.Con_Id='" & Id & "'"
        param = param & " ORDER BY Dialogos.Orden ASC"

        CargarDatos(param)

    End Sub

    Private Function DetectChanges(Nombre) As String
        Dim item As ListViewItem 'Creo el ListViewItem (item) 
        Dim i As Integer
        Dim Orden As String = ""

        Dim Indice As Integer
        i = ListView1.Items.Count + 1

        Dim foundItem As ListViewItem

        Try

            foundItem = ListView1.FindItemWithText(Nombre, True, 0, True)

            If (foundItem IsNot Nothing) Then
                Orden = foundItem.Index
            End If


        Catch ex As Exception

        End Try

        Return Orden



    End Function





    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        'Ordenar

        Dim r As Integer, c As Integer
        Dim sqlstring As String
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim i As Integer
        Dim IdOracion As Integer
        Dim IdDialogo As Integer
        Dim Oracion As String
        _comando.Connection.Open()


        Dim item As ListViewItem 'Creo el ListViewItem (item) 
        Dim Orden As String = ""

        Dim Indice As Integer
        i = ListView1.Items.Count + 1



        Dim foundItem As ListViewItem

        For r = 0 To ListView1.Items.Count - 1  ' Exclude the potential new row in DataGridView

            IdOracion = ListView1.Items(r).SubItems(1).Text
            Oracion = ListView1.Items(r).SubItems(2).Text

            Try

                foundItem = lvwActual.FindItemWithText(Oracion, True, 0, True)

                If (foundItem Is Nothing) Then
                    ' Orden = foundItem.Index
                    'Insertar nuevo
                    Dim j As Integer
                    j = 0
                    Dim sql As String
                    Dim IdDetalle As Integer

                    sqlstring = "Insert into det_Conversation (Det_OracionId, Det_Orden, Con_Id, Det_Person)"
                    sqlstring = sqlstring & " Values ('" & IdOracion & "', '" & j & "', '" & Id & "', '0')"
                    _comando.CommandText = sqlstring

                    Try
                        i = _comando.ExecuteNonQuery
                    Catch ex As Exception
                    End Try

                    Try
                        If i > 0 Then
                            sql = "SELECT @@IDENTITY FROM det_Conversation"
                            _comando = New SqlCommand(sql, _comando.Connection)
                            Dim value As Object = _comando.ExecuteScalar
                            IdDetalle = value.ToString
                        End If
                    Catch ex As Exception
                    End Try

                    'Inserta Dialogo

                    sqlstring = "Insert into Dialogos (OracionId, Orden, DetConversacion)"
                    sqlstring = sqlstring & " Values ('" & IdOracion & "', @Orden, '" & IdDetalle & "')"
                    _comando.CommandText = sqlstring

                    _comando.Parameters.AddWithValue("@Orden", 0)

                    Try
                        i = _comando.ExecuteNonQuery
                    Catch ex As Exception
                    End Try

                    j = j + 1

                End If

            Catch ex As Exception
            End Try

        Next


        ' Dim n As Integer

        ' n = lvwActual.Items.Count

        
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        ListView1.Items.Clear()

    End Sub

    Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscar.TextChanged
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim buscar As String
        Dim sqlstring As String = ""
        Dim i, n As Integer


        buscar = Trim(Me.txtBuscar.Text)

        If Len(buscar) < 3 Then Exit Sub

        'Dim itm As ListViewItem 'Creo el ListViewItem (item) 
        Try
            ListView1.Items(LastIndex).SubItems(2).BackColor = Color.White
        Catch ex As Exception
        End Try

        Dim Orden As Integer
        Dim Indice As Integer
        Dim foundItem As ListViewItem

        Try

            
        Catch ex As Exception
        End Try

        'Dim textoABuscar As String = "texto a buscar"
        For Each itemActual As ListViewItem In ListView1.Items
            ' Para buscar solo en el texto principal del ítem
            If itemActual.SubItems(2).Text.Contains(buscar) Then

                ListView1.Items(itemActual.Index).SubItems(2).BackColor = Color.Yellow
                ListView1.EnsureVisible(itemActual.Index)
                LastIndex = itemActual.Index
                'itemActual.Selected = True
                ' Si quieres encontrar solo la primera coincidencia, puedes usar Exit For
                ' Exit For
            End If

            ' Para buscar en los sub-ítems (columnas en modo Details)
            ' For Each subItemActual As ListViewSubItem In itemActual.SubItems
            '     If subItemActual.Text.Contains(textoABuscar) Then
            '         itemActual.Selected = True
            '         ' Exit For
            '     End If
            ' Next
        Next

        'Dim indice As Integ
    End Sub
End Class