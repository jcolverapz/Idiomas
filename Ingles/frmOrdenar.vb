'Imports Entidades
'Imports Negocios
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO

Public Class frmOrdenar
    Dim sqlstring As String
    Dim filtro As String
    Public IdGrupo As Integer
    Dim Id As Integer
    Dim FILASELECT As Integer

    Private Sub frmOrdenar_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim param As String
         
        param = " Where GrupoO= '" & IdGrupo & "'"

        CargarDatos(param)

        ' LvwUnassigned.View = View.Details ' Set the view to show details.
        'LvwUnassigned.LabelEdit = False ' Allow the user to edit item text.
        'LvwUnassigned.AllowColumnReorder = True ' Allow the user to rearrange columns.
        'LvwUnassigned.FullRowSelect = True ' Select the item and subitems when selection is made.
        'LvwUnassigned.GridLines = True ' Display grid lines.

    End Sub

    Public Sub CargarDatos(param)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer


        filtro = "Select  Id, orden, TextoPlano, Traduccion ,EsRespuesta from Oraciones "
        filtro = filtro & param
        filtro = filtro & " Order By orden ASC"

        Try


            _comando.CommandText = filtro
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)
            ' dgvOraciones.DataSource = dt
            'MaxColumna = dgvOraciones.ColumnCount

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try


        LvwAssigned.Items.Clear()



        i = 0
        n = dt.Rows.Count
        If n = 0 Then Exit Sub

        Do While i <= n - 1


            Dim item As ListViewItem 'Creo el ListViewItem (item) 
            item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 
            item.UseItemStyleForSubItems = False

            Try

                item.SubItems.Add(dt.Rows(i).Item(0))
                item.SubItems.Add(dt.Rows(i).Item(2))
                item.SubItems.Add(dt.Rows(i).Item(3))
                item.SubItems.Add(dt.Rows(i).Item(4))
                ' item.SubItems.Add(dt.Rows(i).Item(0))
                ' item.SubItems.Add(DatosTask.Rows(i).Item(5))
                'item.SubItems.Add(DatosTask.Rows(i).Item(6))
                ' item.SubItems.Add(DatosTask.Rows(i).Item(7))

                If dt.Rows(i).Item(4) = "Q" Then
                    item.SubItems(2).ForeColor = Color.Blue
                    item.SubItems(3).ForeColor = Color.Blue
                ElseIf dt.Rows(i).Item(4) = "S" Then
                    item.SubItems(2).ForeColor = Color.Fuchsia
                    item.SubItems(3).ForeColor = Color.Fuchsia
                ElseIf dt.Rows(i).Item(4) = "C" Then
                    item.SubItems(2).ForeColor = Color.Black
                    item.SubItems(3).ForeColor = Color.Black
                ElseIf dt.Rows(i).Item(4) = "O" Then
                    item.SubItems(2).ForeColor = Color.BlueViolet
                    item.SubItems(3).ForeColor = Color.BlueViolet
                ElseIf dt.Rows(i).Item(4) = "E" Then
                    item.SubItems(2).ForeColor = Color.DarkGreen
                    item.SubItems(3).ForeColor = Color.DarkGreen
                Else
                    item.SubItems(2).ForeColor = Color.Brown
                    item.SubItems(3).ForeColor = Color.Brown

                End If


                LvwAssigned.Items.Add(item)      'Agrego el item a la colección de listViewItem's de ListView1


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


            i = i + 1

        Loop

        LvwAssigned.View = View.Details ' Set the view to show details.
        LvwAssigned.LabelEdit = False ' Allow the user to edit item text.
        LvwAssigned.AllowColumnReorder = True ' Allow the user to rearrange columns.
        LvwAssigned.FullRowSelect = True ' Select the item and subitems when selection is made.
        LvwAssigned.GridLines = True ' Display grid lines.





    End Sub
    Public Sub CargarDatosenConversaciones(param)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer

        sqlstring = "SELECT Oraciones.Id, Oraciones.orden, Oraciones.TextoPlano, Oraciones.Traduccion, Oraciones.EsRespuesta, "
        sqlstring = sqlstring & " Dialogos.Id, Dialogos.OracionId, Dialogos.DetConversacion, Dialogos.IMG, Dialogos.voice"
        sqlstring = sqlstring & " FROM            Dialogos LEFT JOIN"
        sqlstring = sqlstring & "                  Oraciones ON Dialogos.OracionId = Oraciones.Id"
        sqlstring = sqlstring & param
        sqlstring = sqlstring & " Order By orden ASC"

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


        LvwAssigned.Items.Clear()



        i = 0
        n = dt.Rows.Count
        If n = 0 Then Exit Sub

        Do While i <= n - 1


            Dim item As ListViewItem 'Creo el ListViewItem (item) 
            item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 
            item.UseItemStyleForSubItems = False

            Try

                item.SubItems.Add(dt.Rows(i).Item(0))
                item.SubItems.Add(dt.Rows(i).Item(2))
                item.SubItems.Add(dt.Rows(i).Item(3))
                item.SubItems.Add(dt.Rows(i).Item(4))


                If Not IsDBNull(dt.Rows(i).Item(5)) Then
                    'item.SubItems.Add("SI")
                    item.SubItems.Add(dt.Rows(i).Item(7))
                Else
                    item.SubItems.Add("X")

                End If


                If dt.Rows(i).Item(4) = "Q" Then
                    item.SubItems(2).ForeColor = Color.Blue
                    item.SubItems(3).ForeColor = Color.Blue
                ElseIf dt.Rows(i).Item(4) = "S" Then
                    item.SubItems(2).ForeColor = Color.Fuchsia
                    item.SubItems(3).ForeColor = Color.Fuchsia
                ElseIf dt.Rows(i).Item(4) = "C" Then
                    item.SubItems(2).ForeColor = Color.Black
                    item.SubItems(3).ForeColor = Color.Black
                ElseIf dt.Rows(i).Item(4) = "O" Then
                    item.SubItems(2).ForeColor = Color.BlueViolet
                    item.SubItems(3).ForeColor = Color.BlueViolet
                ElseIf dt.Rows(i).Item(4) = "E" Then
                    item.SubItems(2).ForeColor = Color.DarkGreen
                    item.SubItems(3).ForeColor = Color.DarkGreen
                Else
                    item.SubItems(2).ForeColor = Color.Brown
                    item.SubItems(3).ForeColor = Color.Brown

                End If


                LvwAssigned.Items.Add(item)      'Agrego el item a la colección de listViewItem's de ListView1


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


            i = i + 1

        Loop

        LvwAssigned.View = View.Details ' Set the view to show details.
        LvwAssigned.LabelEdit = False ' Allow the user to edit item text.
        LvwAssigned.AllowColumnReorder = True ' Allow the user to rearrange columns.
        LvwAssigned.FullRowSelect = True ' Select the item and subitems when selection is made.
        LvwAssigned.GridLines = True ' Display grid lines.





    End Sub
    Private Sub CmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles CmdCerrar.Click
        'Me.Close()
        Dim param As String

        Try

            'lstModificaciones.Items.Clear()

            Dim frm As FrmOraciones = CType(Owner, FrmOraciones)

            frm.CargarDatos(frm.filtro)

            Me.Close()
            Me.Dispose()
        Catch ex As Exception

            Me.Close()
            Me.Dispose()
            Exit Sub

        End Try

    End Sub

    Private Sub cmdGuardar_Click(sender As System.Object, e As System.EventArgs) Handles cmdGuardar.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim item As ListViewItem

        Dim i As Integer
        Dim _insertado As Boolean = False
        Dim mostrarMensaje As Boolean = False
        Dim stringvalues As String = ""
        Dim sql As String = ""
        Dim IdMax As Integer
        Dim n As Integer

        Dim resp As Boolean
        Dim param As String = ""

        _comando.Connection.Open()


        For Each r In LvwAssigned.Items

            Console.WriteLine(r.index)
            Console.WriteLine(r.SubItems(1).Text)

            _comando.Parameters.Clear()

            sqlstring = "UPDATE Oraciones SET Orden = @Orden"
            sqlstring = sqlstring & " WHERE Id = @Id"


            _comando.Parameters.AddWithValue("@Orden", r.index)
            _comando.Parameters.AddWithValue("@Id", r.SubItems(1).Text)


            _comando.CommandText = sqlstring

            '_comando.Parameters.AddWithValue("@Enc_Id", param)
            Try
                i = _comando.ExecuteNonQuery
                resp = True
            Catch ex As Exception
                resp = False

            End Try

            ' i = i + 1
        Next
        _comando.Connection.Close()


        'If i > 0 Then
        '    Return True
        'Else
        '    Return False

        'End If

        If resp = True Then
            '  MessageBox.Show("Save successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
            'CmdCerrar_Click(sender, e)
        End If


        'For i = 0 To n
    End Sub

    Private Sub cmdEditar_Click(sender As System.Object, e As System.EventArgs) Handles cmdEditar.Click

        cmdGuardar_Click(sender, e)

        Dim frm As New FrmDetOracion

        AddOwnedForm(frm)
        Dim IdOracion As Integer
        FILASELECT = LvwAssigned.SelectedItems.Item(0).Index

        IdOracion = LvwAssigned.SelectedItems.Item(0).SubItems(1).Text

        frm.IdOracion = IdOracion

        frm.CargarDatos(IdOracion)

        frm.ShowDialog()

        ' CargarDatos(IdGrupo)

        Try
            LvwAssigned.Items(FILASELECT).Selected = True
            LvwAssigned.EnsureVisible(FILASELECT)
            LvwAssigned.Focus()

            'ListView1.Items(5).Selected = True

            ' Asegurarse de que la fila seleccionada sea visible.
            'ListView1.EnsureVisible(5)

            ' Opcional: Asegurarse de que el control tiene el foco para que la selección sea visible.
            ' ListView1.Focus()

        Catch ex As Exception

        End Try
    End Sub

     
   

    Private Sub cmdMostrar_Click(sender As System.Object, e As System.EventArgs) Handles cmdMostrar.Click
        'Dim param As String
        'If cmdMostrar.Text = "En Conversacion" Then
        '    cmdMostrar.Text = "Falta en Conversacion"

        '    param = " Where Oraciones.GrupoO= '" & IdGrupo & "'"
        'Else
        '    cmdMostrar.Text = "En Conversacion"
        '    param = " Where Oraciones.GrupoO= '" & IdGrupo & "'"

        'End If

        'CargarDatosenConversaciones(param)

    End Sub

    Private Sub cmdSaveDialogo_Click(sender As System.Object, e As System.EventArgs) Handles cmdSaveDialogo.Click

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim IdPerson As Integer

        IdPerson = 3

        _comando.Connection.Open()
        Dim resp As Boolean

        'For Each r In LvwUnassigned.Items

        '    _comando.Parameters.Clear()
        '    Console.WriteLine(r.SubItems(1).Text)
        '    Console.WriteLine(r.SubItems(2).Text)
        '    Console.WriteLine(r.SubItems(3).Text)
        '    Console.WriteLine(r.SubItems(4).Text)
        '    Console.WriteLine(r.SubItems(5).Text)


        '    If r.SubItems(5).Text <> "OK" Then

        '        sqlstring = "Insert into Dialogos (OracionId, Orden, DetConversacion)"
        '        sqlstring = sqlstring & " Values ('" & r.SubItems(1).Text & "', @Orden, '" & txtDetId.Text & "')"

        '        _comando.CommandText = sqlstring

        '        _comando.Parameters.AddWithValue("@Orden", r.index)

        '        Try

        '            i = _comando.ExecuteNonQuery

        '            If i > 0 Then
        '                resp = True
        '            Else
        '                resp = False
        '            End If

        '            r.SubItems(5).Text = "OK"

        '        Catch ex As Exception
        '            MsgBox(ex.Message)
        '        Finally

        '        End Try

        '    End If


        'Next

        _comando.Connection.Close()
        If resp Then
            MsgBox("se guardo")
        Else
            MsgBox("No se guardo")
        End If



    End Sub
    Private Sub LvwAssigned_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs)

        Dim lvw As ListView = DirectCast(sender, ListView)
        Dim dragged_items As List(Of ListViewItem) = _
            e.Data.GetData("System.Collections.Generic.List(Of " & _
                "System.Windows.Forms.ListViewItem)")

        Dim pt As Point = lvw.PointToClient(New Point(e.X, e.Y))
        Dim lvi As ListViewItem = lvw.GetItemAt(pt.X, pt.Y)
        Dim index As Integer
        If lvi IsNot Nothing Then
            index = lvi.Index
        End If

        For Each list_view_item As ListViewItem In dragged_items
            ' Add the item to the target list.
            Dim new_item As ListViewItem = _
                DirectCast(list_view_item.Clone(), ListViewItem)
            new_item.Font = New Font("Arial", 10, FontStyle.Regular)
            If lvi Is Nothing Then
                lvw.Items.Add(new_item)
            Else
                lvw.Items.Insert(index, new_item)
                index += 1
            End If
        Next list_view_item



    End Sub

    Private Sub LvwAssigned_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs)
        ' Check for the custom DataFormat ListViewItem array.
        If e.Data.GetDataPresent("System.Collections.Generic.List(Of " & _
            "System.Windows.Forms.ListViewItem)") Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub LvwAssigned_ItemDrag(sender As Object, e As System.Windows.Forms.ItemDragEventArgs)
        Dim lvw As ListView = DirectCast(sender, ListView)
        Dim dragged_items As New List(Of ListViewItem)
        For Each selected_item As ListViewItem In _
            lvw.SelectedItems
            dragged_items.Add(selected_item)
        Next selected_item

        Dim result As DragDropEffects = _
            lvw.DoDragDrop(New  _
                DataObject("System.Collections.Generic.List(Of " & _
                "System.Windows.Forms.ListViewItem)", _
                dragged_items), DragDropEffects.Move)

        ' Remove the dragged items if necessary.
        If result = DragDropEffects.Move Then
            For Each selected_item As ListViewItem In _
                dragged_items
                lvw.Items.Remove(selected_item)
            Next selected_item
        End If
    End Sub

    Private Sub LvwAssigned_DoubleClick(sender As Object, e As System.EventArgs) Handles LvwAssigned.DoubleClick

        'Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        'Dim sqlstring As String

        'Dim dt As New DataTable
        'Dim da As New SqlDataAdapter
        'Dim i, n As Integer
        'Dim DetId As Integer
        'Try
        '    DetId = LvwAssigned.SelectedItems.Item(0).SubItems(5).Text
        '    txtDetId.Text = DetId
        'Catch ex As Exception
        '    Exit Sub
        'End Try

        'sqlstring = "SELECT Oraciones.Id, Oraciones.orden, Oraciones.TextoPlano, Oraciones.Traduccion, Oraciones.EsRespuesta, "
        'sqlstring = sqlstring & " Dialogos.Id, Dialogos.OracionId, Dialogos.DetConversacion, Dialogos.IMG, Dialogos.voice"
        'sqlstring = sqlstring & " FROM            Dialogos LEFT JOIN"
        'sqlstring = sqlstring & "                  Oraciones ON Dialogos.OracionId = Oraciones.Id"
        'sqlstring = sqlstring & " WHERE  Dialogos.DetConversacion='" & DetId & "'"
        'sqlstring = sqlstring & " Order By orden ASC"

        'Try

        '    _comando.CommandText = sqlstring
        '    _comando.Connection.Open()

        '    da.SelectCommand = _comando

        '    da.Fill(dt)

        '    _comando.Connection.Close()

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally

        'End Try

        '' LvwUnassigned.Items.Clear()

        'i = 0
        'n = dt.Rows.Count
        'If n = 0 Then Exit Sub

        'Do While i <= n - 1


        '    Dim item As ListViewItem 'Creo el ListViewItem (item) 
        '    item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 
        '    item.UseItemStyleForSubItems = False

        '    Try

        '        item.SubItems.Add(dt.Rows(i).Item(0))
        '        item.SubItems.Add(dt.Rows(i).Item(2))
        '        item.SubItems.Add(dt.Rows(i).Item(3))
        '        item.SubItems.Add(dt.Rows(i).Item(4))
        '        item.SubItems.Add("OK")


        '        If dt.Rows(i).Item(4) = "Q" Then
        '            item.SubItems(2).ForeColor = Color.Blue
        '            item.SubItems(3).ForeColor = Color.Blue
        '        ElseIf dt.Rows(i).Item(4) = "S" Then
        '            item.SubItems(2).ForeColor = Color.Fuchsia
        '            item.SubItems(3).ForeColor = Color.Fuchsia
        '        ElseIf dt.Rows(i).Item(4) = "C" Then
        '            item.SubItems(2).ForeColor = Color.Black
        '            item.SubItems(3).ForeColor = Color.Black
        '        ElseIf dt.Rows(i).Item(4) = "O" Then
        '            item.SubItems(2).ForeColor = Color.BlueViolet
        '            item.SubItems(3).ForeColor = Color.BlueViolet
        '        ElseIf dt.Rows(i).Item(4) = "E" Then
        '            item.SubItems(2).ForeColor = Color.DarkGreen
        '            item.SubItems(3).ForeColor = Color.DarkGreen
        '        Else
        '            item.SubItems(2).ForeColor = Color.Brown
        '            item.SubItems(3).ForeColor = Color.Brown

        '        End If


        '        ' LvwUnassigned.Items.Add(item)      'Agrego el item a la colección de listViewItem's de ListView1


        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try


        '    i = i + 1

        'Loop
    End Sub

    Private Sub LvwAssigned_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles LvwAssigned.MouseClick
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim itemNew As ListViewItem = Nothing
            Dim itemRem As ListViewItem = Nothing
            itemNew = LvwAssigned.SelectedItems.Item(0)
            'FILASELECT = ListViewEx1.SelectedItems.Item(0).Index
            'ListViewEx1.Items(FILASELECT).Selected = True
            LvwAssigned.Items.Remove(itemNew)
            LvwAssigned.Items.Insert(0, itemNew)

        Else

        End If
    End Sub

    Private Sub LvwAssigned_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles LvwAssigned.SelectedIndexChanged

    End Sub
End Class