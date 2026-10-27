Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
 
Imports System.Windows.Forms

Public Class frmOrdenarConversacion
    Public Id As Integer

    Private Sub CmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles CmdCerrar.Click
        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub frmOrdenarConversacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        LvwAssigned.View = View.Details ' Set the view to show details.
        LvwAssigned.LabelEdit = False ' Allow the user to edit item text.
        LvwAssigned.AllowColumnReorder = True ' Allow the user to rearrange columns.
        LvwAssigned.FullRowSelect = True ' Select the item and subitems when selection is made.
        LvwAssigned.GridLines = True ' Display grid lines.

        LvwNew.View = View.Details ' Set the view to show details.
        LvwNew.LabelEdit = False ' Allow the user to edit item text.
        LvwNew.AllowColumnReorder = True ' Allow the user to rearrange columns.
        LvwNew.FullRowSelect = True ' Select the item and subitems when selection is made.
        LvwNew.GridLines = True ' Display grid lines.

        txtConversacion.Text = Id

        Dim param As String

        param = " Where Det_Conversation.Con_Id='" & Id & "'"

        CargarDatos(param)


        cboTipo.Items.Add("ALL")
        cboTipo.Items.Add("Saludo")
        cboTipo.Items.Add("Presentacion")
        cboTipo.Items.Add("Iniciando")
        cboTipo.Items.Add("Conversacion")
        cboTipo.Items.Add("Leccion")
        cboTipo.Items.Add("Serie")

        Dim sqlstring As String
        sqlstring = " SELECT    Con_Id, Con_Titulo"
        sqlstring = sqlstring & " FROM Enc_Conversation "
        sqlstring = sqlstring & " ORDER BY Con_Titulo"

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)
            _comando.Connection.Close()
        Catch ex As Exception

        End Try
       
        'Conversaciones
         
        i = 0
        n = dt.Rows.Count

        Do While i <= n - 1
            cboConversation.Items.Add(New clsItem(dt.Rows(i).Item(1), dt.Rows(i).Item(0)))
            i = i + 1
        Loop


    End Sub

    Public Sub CargarDatos(param)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer


        sqlstring = "  SELECT       Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Det_Conversation.Det_Orden, Det_Conversation.Con_Id, Det_Conversation.Det_Person, Det_Conversation.Det_Par, Oraciones.TextoPlano, Oraciones.Traduccion, Det_Conversation.Det_tipo"
        sqlstring = sqlstring & " FROM            Det_Conversation INNER JOIN"
        sqlstring = sqlstring & "                 Oraciones ON Det_Conversation.Det_OracionId = Oraciones.Id"
        sqlstring = sqlstring & param
        sqlstring = sqlstring & " ORDER BY Det_Conversation.Det_Orden"


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
        Dim item As ListViewItem 'Creo el ListViewItem (item) 



        Do While i <= n - 1


            item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            item.UseItemStyleForSubItems = False

            Try
                item.SubItems.Add(dt.Rows(i).Item(0))
                item.SubItems.Add(dt.Rows(i).Item(6))
                item.SubItems.Add(dt.Rows(i).Item(7))
                item.SubItems.Add(dt.Rows(i).Item(1))

                If dt.Rows(i).Item(8) = "Q" Then
                    '  item.SubItems(2).ForeColor = Color.Blue
                    ' item.SubItems(3).ForeColor = Color.Blue
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

        'LvwAssigned.View = View.Details ' Set the view to show details.
        'LvwAssigned.LabelEdit = False ' Allow the user to edit item text.
        'LvwAssigned.AllowColumnReorder = True ' Allow the user to rearrange columns.
        'LvwAssigned.FullRowSelect = True ' Select the item and subitems when selection is made.
        'LvwAssigned.GridLines = True ' Display grid lines.


    End Sub

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
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

            sqlstring = "UPDATE Det_Conversation SET Det_Orden = @Orden"
            sqlstring = sqlstring & " WHERE Det_Con = @Det_Con"


            _comando.Parameters.AddWithValue("@Orden", r.index)
            _comando.Parameters.AddWithValue("@Det_Con", r.SubItems(1).Text)


            _comando.CommandText = sqlstring

            Try
                i = _comando.ExecuteNonQuery
                resp = True
            Catch ex As Exception
                resp = False

            End Try

        Next
        _comando.Connection.Close()


        Try
            Dim frm As FrmConversation = CType(Owner, FrmConversation)

            ' frm.CargarDatos(frm.filtro)
            'frm.CargarConversation(frm.Id)
            frm.CrearControles()
            Me.Close()
            Me.Dispose()
        Catch ex As Exception

            Me.Close()
            Me.Dispose()
            Exit Sub

        End Try



    End Sub

    Private Sub cmdSaveTransferir_Click(sender As System.Object, e As System.EventArgs) Handles cmdSaveTransferir.Click

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim IdPerson As Integer

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

        'IdPerson = 0
        Dim IdConversation As Integer
        IdConversation = txtIdConversationNew.Text

        Try
            If LvwNew.SelectedItems(0).Text = "" Then Exit Sub

        Catch ex As Exception
            ' Exit Sub
        End Try

        _comando.Connection.Open()

        For Each r In LvwNew.Items

            'Console.WriteLine(r.index)
            'Console.WriteLine(r.SubItems(0).Text)
            'Console.WriteLine(r.SubItems(1).Text)
            'Console.WriteLine(r.SubItems(2).Text)
            'Console.WriteLine(r.SubItems(3).Text)
            'Console.WriteLine(r.SubItems(4).Text)

            _comando.Parameters.Clear()

            'sqlstring = "Insert into det_Conversation (Det_OracionId, Det_Orden, Con_Id, Det_Person)"
            'sqlstring = sqlstring & " Values ('" & r.SubItems(4).Text & "', @Det_Orden, '" & IdConversation & "', '" & IdPerson & "')"

            sqlstring = "UPDATE Det_Conversation SET Con_Id = @Con_Id, Det_Orden = @Det_Orden"
            sqlstring = sqlstring & " WHERE Det_Con = @Det_Con"


            _comando.Parameters.AddWithValue("@Con_Id", IdConversation)
            _comando.Parameters.AddWithValue("@Det_Con", r.SubItems(1).Text)
            _comando.Parameters.AddWithValue("@Det_Orden", r.index)

            _comando.CommandText = sqlstring
             
            Try

                i = _comando.ExecuteNonQuery

                If i > 0 Then
                    'MsgBox("se guardo")

                Else
                    MsgBox("No se guardo")
                End If


            Catch ex As Exception
                MsgBox(ex.Message)
            Finally

            End Try

        Next

        _comando.Connection.Close()



    End Sub
    Private Sub LvwAssigned_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles LvwAssigned.DragDrop, LvwNew.DragDrop

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

            If lvi Is Nothing Then
                lvw.Items.Add(new_item)
            Else
                lvw.Items.Insert(index, new_item)
                index += 1
            End If
        Next list_view_item

    End Sub

    Private Sub LvwAssigned_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles LvwAssigned.DragEnter, LvwNew.DragEnter


        ' Check for the custom DataFormat ListViewItem array.
        If e.Data.GetDataPresent("System.Collections.Generic.List(Of " & _
            "System.Windows.Forms.ListViewItem)") Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

 


    Private Sub LvwAssigned_ItemDrag(sender As Object, e As System.Windows.Forms.ItemDragEventArgs) Handles LvwAssigned.ItemDrag, LvwNew.ItemDrag
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


    Private Sub cmdNuevo_Click(sender As System.Object, e As System.EventArgs) Handles cmdNuevo.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sql As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim sqlstring As String = ""
        Dim i As Integer
        Dim IdEnc As Integer
        If cboTipo.Text = "" Then
            MsgBox("Seleccione un tipo")
            Exit Sub
        End If
        sqlstring = "Insert into Enc_Conversation (Con_Titulo, Con_tipo)"
        sqlstring = sqlstring & " Values ('" & "New Conversation" & "', '" & cboTipo.Text & "')"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()


        Try
            i = _comando.ExecuteNonQuery

            If i > 0 Then
                '  MsgBox("se guardo")
            Else
                MsgBox("No se guardo")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try

        If i > 0 Then
            sql = "SELECT @@IDENTITY FROM Enc_Conversation"

            _comando = New SqlCommand(sql, _comando.Connection)

            Dim value As Object = _comando.ExecuteScalar
            IdEnc = value.ToString

        End If
        _comando.Connection.Close()

        txtIdConversationNew.Text = IdEnc

    End Sub

    Private Sub cboConversation_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboConversation.SelectedIndexChanged

        txtIdConversationNew.Text = cboConversation.Items(cboConversation.SelectedIndex).ItemData()

    End Sub

    Private Sub cmdTransferir_Click(sender As System.Object, e As System.EventArgs) Handles cmdTransferir.Click
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

            sqlstring = "UPDATE Det_Conversation SET Con_Id = @Con_Id, Det_orden=@Det_orden"
            sqlstring = sqlstring & " WHERE Det_Con = @Det_Con"


            _comando.Parameters.AddWithValue("@Det_orden", r.index)
            _comando.Parameters.AddWithValue("@Det_Con", r.SubItems(1).Text)
            _comando.Parameters.AddWithValue("@Con_Id", txtIdConversationNew.Text)


            _comando.CommandText = sqlstring

            Try
                i = _comando.ExecuteNonQuery
                resp = True
            Catch ex As Exception
                resp = False

            End Try

        Next
        _comando.Connection.Close()


        Try
            Dim frm As FrmConversation = CType(Owner, FrmConversation)

            ' frm.CargarDatos(frm.filtro)
            'frm.CargarConversation(frm.Id)
            frm.CrearControles()
            Me.Close()
            Me.Dispose()
        Catch ex As Exception

            Me.Close()
            Me.Dispose()
            Exit Sub

        End Try

    End Sub
End Class