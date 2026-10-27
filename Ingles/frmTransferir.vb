Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO

' Import necessary libraries
Imports System.Windows.Forms
Public Class frmTransferir
    Dim sqlstring As String
    Dim filtro As String
    ' Public IdGrupo As Integer
    Public fromBuilder As Boolean
    Public IdConversation As Integer
    Public Id As Integer
    Public IdDetalle As Integer
    Public IdDet As Integer
    Public IdEnc As Integer
    Public MaxItem As Integer

#Region "Inicio"
    Private Sub frmTransferir_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        LvwAssigned.View = View.Details ' Set the view to show details.
        LvwAssigned.LabelEdit = False ' Allow the user to edit item text.
        LvwAssigned.AllowColumnReorder = True ' Allow the user to rearrange columns.
        LvwAssigned.FullRowSelect = True ' Select the item and subitems when selection is made.
        LvwAssigned.GridLines = True ' Display grid lines.

        LvwUnassigned.View = View.Details ' Set the view to show details.
        LvwUnassigned.LabelEdit = False ' Allow the user to edit item text.
        LvwUnassigned.AllowColumnReorder = True ' Allow the user to rearrange columns.
        LvwUnassigned.FullRowSelect = True ' Select the item and subitems when selection is made.
        LvwUnassigned.GridLines = True ' Display grid lines.

        'cargarDatos()
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        'sqlstring = "select * from  SubTemas "
        sqlstring = "select * from  Grupos_oracion "
        sqlstring = sqlstring & " Where Idioma='" & ModVar.Idioma & "'"
        sqlstring = sqlstring & " ORDER By orden ASC"

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)

            cboGrupo.Items.Clear()

            Dim i As Integer
            Dim n As Integer
            n = dt.Rows.Count

            cboGrupo.Items.Add("ALL")

            Do While i <= n - 1
                Me.cboGrupo.Items.Add(New clsItem(dt.Rows(i).Item(1), dt.Rows(i).Item(0)))
                i = i + 1
            Loop
            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        Dim Conversaciones As New DataTable
          
        sqlstring = "select Con_Id, Con_titulo from Enc_Conversation "
        sqlstring = sqlstring & " ORDER By Con_titulo ASC"

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(Conversaciones)

            cboConversation.Items.Clear()

            Dim i As Integer
            Dim n As Integer
            n = Conversaciones.Rows.Count

            'cboConversation.Items.Add("ALL")

            Do While i <= n - 1
                cboConversation.Items.Add(New clsItem(Conversaciones.Rows(i).Item(1), Conversaciones.Rows(i).Item(0)))
                i = i + 1
            Loop
            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try


        txtConversacion.Text = IdEnc

       

        ' CargarDatos("")

    End Sub
    Public Sub CargarDatos(param)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer

        'Dialogos
        Dim filtro As String
        'param = " Where Det_Conversation.Con_Id='" & Id & "'"
        filtro = " Where d.Con_Id ='" & IdEnc & "'"
        filtro = filtro & " And d.status ='R'"

        sqlstring = "    SELECT        t.Id, o.TextoPlano, t.IdOracion, t.Orden, t.IdConversacion, t.IMG"
        sqlstring = sqlstring & "  FROM            Tbl_Dialogos t INNER JOIN"
        sqlstring = sqlstring & "                   Det_Conversation d ON t.IdConversacion = d.Det_Con INNER JOIN"
        sqlstring = sqlstring & "                 Oraciones_fr o ON t.IdOracion = o.Id"
        sqlstring = sqlstring & filtro
        sqlstring = sqlstring & " ORDER BY t.Orden"

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

        LvwUnassigned.Items.Clear()

        i = 0
        n = dt.Rows.Count
        If n = 0 Then Exit Sub

        Do While i <= n - 1


            Dim item As ListViewItem 'Creo el ListViewItem (item) 
            item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            Try
                'Conversacion
                
                'Dialogo
                item.SubItems.Add(dt.Rows(i).Item(0))
                item.SubItems.Add(dt.Rows(i).Item(1))
                item.SubItems.Add(dt.Rows(i).Item(2))
                item.SubItems.Add("0")

                LvwUnassigned.Items.Add(item)      'Agrego el item a la colección de listViewItem's de ListView1


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
    Public Sub CargarDetalles(DetalleId)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer

        'Dialogos
        Dim filtro As String
        filtro = " Where d.Det_con='" & DetalleId & "'"
        'filtro = " Where d.Con_Id ='" & IdEnc & "'"

        sqlstring = "    SELECT        t.Id, o.TextoPlano, t.IdOracion, t.Orden, t.IdConversacion, t.IMG"
        sqlstring = sqlstring & "  FROM            Tbl_Dialogos t INNER JOIN"
        sqlstring = sqlstring & "                   Det_Conversation d ON t.IdConversacion = d.Det_Con INNER JOIN"
        sqlstring = sqlstring & "                 Oraciones o ON t.IdOracion = o.Id"
        sqlstring = sqlstring & filtro
        sqlstring = sqlstring & " ORDER BY t.Orden"

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

        LvwUnassigned.Items.Clear()

        i = 0
        n = dt.Rows.Count

        cmdAgregaaDialogo.Enabled = True

        If n = 0 Then Exit Sub

        Do While i <= n - 1


            Dim item As ListViewItem 'Creo el ListViewItem (item) 
            item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            Try
                'Conversacion

                'Dialogo
                item.SubItems.Add(dt.Rows(i).Item(0))
                item.SubItems.Add(dt.Rows(i).Item(1))
                item.SubItems.Add(dt.Rows(i).Item(2))
                item.SubItems.Add("0")

                LvwUnassigned.Items.Add(item)      'Agrego el item a la colección de listViewItem's de ListView1


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

    Public Sub CargarDatosOraciones(sqlstring)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()


        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer

        'sqlstring = "  SELECT       Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Det_Conversation.Det_Orden, Det_Conversation.Con_Id, Det_Conversation.Det_Person, Det_Conversation.Det_Par, Oraciones.TextoPlano,"
        'sqlstring = sqlstring & " Oraciones.Traduccion "
        'sqlstring = sqlstring & " FROM            Det_Conversation INNER JOIN"
        'sqlstring = sqlstring & "                 Oraciones ON Det_Conversation.Det_OracionId = Oraciones.Id"
        'sqlstring = sqlstring & param
        'sqlstring = sqlstring & " ORDER BY Det_Conversation.Det_Orden"

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

            ' sqlstring = "select   Id, orden, TextoPlano, Traduccion, Estatus, Oracion,  GrupoO from Oraciones "

            Dim item As ListViewItem 'Creo el ListViewItem (item) 

            item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            item.UseItemStyleForSubItems = False
            item.Text = dt.Rows(i).Item(0)
            Try

                'item.SubItems.Add(dt.Rows(i).Item(0))
                item.SubItems.Add(dt.Rows(i).Item(1))
                item.SubItems.Add(dt.Rows(i).Item(2))
                item.SubItems.Add(dt.Rows(i).Item(3))
                item.SubItems.Add("X")

                item.SubItems(1).ForeColor = Color.Blue

                LvwAssigned.Items.Add(item)


            Catch ex As Exception

            End Try



            i = i + 1

        Loop



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

    Private Sub txtBuscar_LostFocus(sender As Object, e As System.EventArgs) Handles txtBuscar.LostFocus
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim buscar As String
        Dim sqlstring As String = ""
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        ' Dim da As New OleDbDataAdapter
        Dim i, n As Integer


        LvwAssigned.Items.Clear()

        buscar = Trim(Me.txtBuscar.Text)

        If buscar = "" Then Exit Sub

        If Len(buscar) < 3 Then Exit Sub

        sqlstring = "Select top 200  Id, orden, TextoPlano, Traduccion, Estatus, Oracion,  GrupoO "
        If ModVar.Idioma = "EN" Then
            sqlstring = sqlstring & " from Oraciones "
        Else
            sqlstring = sqlstring & " from Oraciones_FR"

        End If
        sqlstring = sqlstring & " Where TextoPlano LIKE '%' + @buscar + '%'"
        sqlstring = sqlstring & " ORDER BY Oraciones_fr.TextoPlano ASC"

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()
            _comando.Parameters.AddWithValue("@buscar", buscar)


            da.SelectCommand = _comando

            da.Fill(dt)

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            _comando.Connection.Close()

        Finally

        End Try

        n = dt.Rows.Count
        '    da.Fill(dt)
        i = 0

        Do While i <= n - 1

            ' lstAgregar.Items.Add(i)

            Dim item As ListViewItem 'Creo el ListViewItem (item) 


            item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            item.UseItemStyleForSubItems = False
            item.Text = dt.Rows(i).Item(0)
            Try

                'item.SubItems.Add(dt.Rows(i).Item(0))
                item.SubItems.Add(dt.Rows(i).Item(0))
                item.SubItems.Add(dt.Rows(i).Item(2))
                item.SubItems.Add(dt.Rows(i).Item(3))
                item.SubItems.Add("X")

                item.SubItems(1).ForeColor = Color.Blue

                LvwAssigned.Items.Add(item)


            Catch ex As Exception

            End Try


            'Agrego el item a la colección de listViewItem's de ListView1

            i = i + 1

        Loop


        txtBuscar.Text = ""

    End Sub
    Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscar.TextChanged, txtConversacion.TextChanged
 

    End Sub

#End Region

#Region "Drag 1"

    ' ''Private Sub ListView1_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragDrop
    ' ''    If e.Data.GetDataPresent(DataFormats.FileDrop) Then

    ' ''        Dim MyFiles() As String
    ' ''        Dim i As Integer
    ' ''        Dim FileItem As New ListViewItem

    ' ''        MyFiles = e.Data.GetData(DataFormats.FileDrop)


    ' ''        For i = 0 To MyFiles.Length - 1

    ' ''            FilePath = Path.GetDirectoryName(MyFiles(i))
    ' ''            FileItem.Text = Path.GetFileNameWithoutExtension(MyFiles(i))

    ' ''            FileList.Items.Add(FileItem.Text)

    ' ''        Next
    ' ''    End If
    ' ''End Sub

    '' ''Private Sub ListView1_DragOver(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles ListView1.DragOver
    ' ''    If e.Data.GetDataPresent(DataFormats.FileDrop) Then
    ' ''        e.Effect = DragDropEffects.All
    ' ''    End If
    ' ''End Sub




    ' '' Generic DragEnter
    ''Private Sub ddEnter_DragEnter(sender As Object, e As DragEventArgs) Handles ddEnter.DragEnter
    ''    e.Effect = DragDropEffects.Move
    ''End Sub

    ' '' ItemDrag Events
    ''Private Sub fields_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles fields.ItemDrag
    ''    fromBuilder = False
    ''    ListView1.DoDragDrop(e.Item, DragDropEffects.Move)
    ''End Sub

    ''Private Sub builder_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles builder.ItemDrag
    ''    fromBuilder = True
    ''    ListView2.DoDragDrop(e.Item, DragDropEffects.Move)
    ''End Sub

    '' DragDrop Events
    'Private Sub builderAndFields_DragDrop(sender As Object, e As DragEventArgs) Handles builderAndFields.DragDrop
    '    Dim i As ListViewItem = CType(e.Data.GetData(GetType(ListViewItem)), ListViewItem)

    '    ' Since this function works for both the builder and the fields,
    '    ' we have to check to see where we are dropping, the sender
    '    ' is the ListView we are dropping onto
    '    Console.WriteLine(sender.Equals(ListView2))
    '    If sender.Equals(ListView2) Then
    '        Dim c As ListViewItem = CType(i.Clone(), ListViewItem)
    '        Dim cp As Point = ListView2.PointToClient(New Point(e.X, e.Y))
    '        ' Now, we have to check to see if we are reordering or adding
    '        ' So, we check the flag to see if the dragDrop was initiated 
    '        ' on the builder or on the fields ListView
    '        Console.WriteLine(fromBuilder)
    '        If fromBuilder Then
    '            If ListView2.HitTest(cp).Location.ToString() = "None" Then
    '                ListView2.Items.Add(c)
    '                ListView2.Items.Remove(i)
    '            Else
    '                Dim dragToItem As ListViewItem = ListView2.GetItemAt(cp.X, cp.Y)
    '                Dim dropIndex As Integer = dragToItem.Index
    '                ListView2.Items.Insert(dropIndex, c)
    '                ListView2.Items.Remove(i)
    '            End If
    '        Else
    '            If ListView2.HitTest(cp).Location.ToString() = "None" Then
    '                ListView2.Items.Add(c)
    '            Else
    '                Dim dragToItem As ListViewItem = ListView2.GetItemAt(cp.X, cp.Y)
    '                Dim dropIndex As Integer = dragToItem.Index
    '                ListView2.Items.Insert(dropIndex, c)
    '            End If
    '        End If
    '        ' If the sender is the fields listView, the user is trying to remove
    '        ' the item from the builder.
    '    Else
    '        ListView2.Items.Remove(i)
    '    End If
    'End Sub

#End Region




    Private Sub cmdGuardar_Click_1(sender As System.Object, e As System.EventArgs) Handles cmdGuardar.Click

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

        IdPerson = 3

        Try
            'If LvwAssigned.SelectedItems(0).Text = "" Then Exit Sub

        Catch ex As Exception
            ' Exit Sub
        End Try

        _comando.Connection.Open()
        Dim resp As Boolean

        For Each r In LvwUnassigned.Items

            _comando.Parameters.Clear()

            If r.SubItems(4).Text = "X" Then

                sqlstring = "Insert into det_Conversation (Orden, Con_Id, status)"
                sqlstring = sqlstring & " Values (@Orden, '" & Id & "', 'R')"

                _comando.CommandText = sqlstring

                _comando.Parameters.AddWithValue("@Orden", r.index)

                Try

                    i = _comando.ExecuteNonQuery

                    If i > 0 Then
                        resp = True
                    Else
                        resp = False
                    End If

                    r.SubItems(4).Text = "0"

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally

                End Try

            End If
           

        Next

        _comando.Connection.Close()
        If resp Then
            MsgBox("se guardo")
        Else
            MsgBox("No se guardo")
        End If

        txtBuscar.Text = ""

        Try
            Dim frm As FrmConversation = CType(Owner, FrmConversation)

            frm.CrearControles()
            Me.Close()
            ' Me.Dispose()
        Catch ex As Exception

            Me.Close()
            Me.Dispose()
            Exit Sub

        End Try


    End Sub



    Private Sub cboGrupo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboGrupo.SelectedIndexChanged
        Dim IdGrupo As Integer
        Dim sqlstring As String = ""

        If Me.cboGrupo.Text = "" Then Exit Sub
        'If Me.cboGrupo.SelectedIndex < 1 Then Exit Sub

        Try
            If cboGrupo.SelectedIndex = -1 Then
                IdGrupo = -1
            Else
                IdGrupo = cboGrupo.Items(cboGrupo.SelectedIndex).ItemData()

            End If
        Catch ex As Exception

        End Try

        sqlstring = "select  Id, orden, TextoPlano, Traduccion, Estatus, Oracion,  GrupoO "

        If ModVar.Idioma = "EN" Then
            sqlstring = sqlstring & "from Oraciones "
        Else
            sqlstring = sqlstring & "from Oraciones_FR "

        End If
        sqlstring = sqlstring & " Where GrupoO= '" & IdGrupo & "'"
        sqlstring = sqlstring & " Order By orden ASC"

        CargarDatosOraciones(sqlstring)

    End Sub

    Private Sub LvwAssigned_DoubleClick(sender As Object, e As System.EventArgs) Handles LvwAssigned.DoubleClick
        Dim Id As Integer
        Dim TipoTicket As String
        Dim frm As New FrmDetOracion

        AddOwnedForm(frm)

        ' sqlstring = " SELECT Tbl_Devices.,  Tbl_Devices., Tbl_Devices., Tbl_Devices."

        Id = LvwAssigned.SelectedItems.Item(0).Text

        ' TipoTicket = dgvOraciones.CurrentRow.Cells(11).Value.ToString()
        Dim IdGrupo As Integer
        Dim sqlstring As String = ""

        Try
            If cboGrupo.SelectedIndex = -1 Then
                IdGrupo = -1
            Else
                IdGrupo = cboGrupo.Items(cboGrupo.SelectedIndex).ItemData()
                frm.GrupoOracionId = IdGrupo
            End If
        Catch ex As Exception

        End Try


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
        frm.GrupoOracionId = IdGrupo
        frm.IdOracion = Id
        frm.CargarDatos(Id)
        frm.Show()
    End Sub

    Private Sub LvwAssigned_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles LvwAssigned.DragDrop, LvwUnassigned.DragDrop

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

        'txtBuscar.Text = ""
        'txtTraduccion.Text = ""

    End Sub

    Private Sub LvwAssigned_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles LvwAssigned.DragEnter, LvwUnassigned.DragEnter
        ' Check for the custom DataFormat ListViewItem array.
        If e.Data.GetDataPresent("System.Collections.Generic.List(Of " & _
            "System.Windows.Forms.ListViewItem)") Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub LvwAssigned_ItemDrag(sender As Object, e As System.Windows.Forms.ItemDragEventArgs) Handles LvwAssigned.ItemDrag, LvwUnassigned.ItemDrag
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

    Private Sub txtTraduccion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTraduccion.TextChanged
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim Trad As String
        Dim sqlstring As String = ""
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer

        LvwAssigned.Items.Clear()

        Trad = Trim(txtTraduccion.Text)

        If Trad = "" Then Exit Sub
        If Len(Trad) < 2 Then Exit Sub

        sqlstring = "select   Id, orden, TextoPlano, Traduccion, Estatus, Oracion,  GrupoO from Oraciones_fr "

        sqlstring = sqlstring & " Where Traduccion LIKE " & "'%" & Trad & "%'"
        sqlstring = sqlstring & " ORDER BY Oraciones_fr.Traduccion ASC"


        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            _comando.Connection.Close()

        Finally

        End Try

        n = dt.Rows.Count

        i = 0

        Do While i <= n - 1

            Dim item As ListViewItem 'Creo el ListViewItem (item) 

            item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            item.UseItemStyleForSubItems = False
            item.Text = dt.Rows(i).Item(0)

            Try

                item.SubItems.Add(dt.Rows(i).Item(1)) ' Orden
                item.SubItems.Add(dt.Rows(i).Item(2)) ' TextoPlano
                item.SubItems.Add(dt.Rows(i).Item(3)) 'Traduccion
                item.SubItems.Add("X")

                item.SubItems(0).ForeColor = Color.Blue

                LvwAssigned.Items.Add(item)


            Catch ex As Exception

            End Try


            'Agrego el item a la colección de listViewItem's de ListView1

            i = i + 1

        Loop

    End Sub

    Private Sub cmdNuevo_Click(sender As System.Object, e As System.EventArgs) Handles cmdNuevo.Click

        frmNewOracion.Show()

    End Sub

    Private Sub LvwUnassigned_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles LvwUnassigned.SelectedIndexChanged

    End Sub

    Private Sub cmdOrdenar_Click(sender As System.Object, e As System.EventArgs) Handles cmdOrdenar.Click
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


        For Each r In LvwUnassigned.Items

            Console.WriteLine(r.index)
            Console.WriteLine(r.SubItems(1).Text)

            _comando.Parameters.Clear()

            sqlstring = "UPDATE Det_Conversation SET Orden = @Orden"
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

        MsgBox("Se ordenaron")


        Try
            Dim frm As FrmConversation = CType(Owner, FrmConversation)

           
            frm.CrearControles()
            '  Me.Close()
            ' Me.Dispose()
        Catch ex As Exception

            ' Me.Close()
            ' Me.Dispose()
            ' Exit Sub

        End Try


    End Sub

    Private Sub LvwAssigned_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles LvwAssigned.SelectedIndexChanged

    End Sub

    Private Sub cmdSaveDialogo_Click(sender As System.Object, e As System.EventArgs) Handles cmdSaveDialogo.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim i As Integer
        Dim n As Integer

        ' IdDet = GeneraDialogo()

        _comando.Connection.Open()

        For Each r In LvwUnassigned.Items
             

            If r.SubItems(4).Text = "X" Then

                IdDet = GeneraDialogo(r.index)

                sqlstring = "Insert into Tbl_Dialogos_fr (IdOracion, Orden, IdConversacion)"
                sqlstring = sqlstring & " Values ('" & r.SubItems(0).Text & "', @Orden, '" & IdDet & "')"

                _comando.CommandText = sqlstring
                _comando.Parameters.Clear()

                _comando.Parameters.AddWithValue("@Orden", r.index)

                Try

                    i = _comando.ExecuteNonQuery

                    If i > 0 Then
                        ' resp = True
                        n = n + 1
                    Else
                        ' resp = False
                    End If

                    r.SubItems(4).Text = "0"

                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally

                End Try


                


            End If
   

        Next

        _comando.Connection.Close()




        'If resp Then
        '    MsgBox("se guardo")
        'Else
        '    MsgBox("No se guardo")
        'End If

        'txtBuscar.Text = ""

        Try
            'Dim frm As FrmConversation = CType(Owner, FrmConversation)
            ' Dim frm As frmEscenas = CType(Owner, frmEscenas)

            '  frm.CrearControles()
            Me.Close()
            ' Me.Dispose()
        Catch ex As Exception

            Me.Close()
            Me.Dispose()
            Exit Sub

        End Try

    End Sub

    Private Function GeneraDialogo(orden)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer

        Dim resp As Boolean

        'Console.WriteLine(r.SubItems(0).Text)
        'Console.WriteLine(r.SubItems(1).Text)
        'Console.WriteLine(r.SubItems(2).Text)
        'Console.WriteLine(r.SubItems(3).Text)
        'Console.WriteLine(r.SubItems(4).Text)

        _comando.Connection.Open()

        _comando.Parameters.Clear()

        sqlstring = "Insert into Det_Conversation (Orden, Con_Id, status)"
        sqlstring = sqlstring & " Values (@Orden, '" & IdEnc & "', 'R')"
        _comando.CommandText = sqlstring

        _comando.Parameters.AddWithValue("@Orden", orden)

        Try
            i = _comando.ExecuteNonQuery
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try

        Dim sql As String
        Try
            If i > 0 Then
                sql = "SELECT @@IDENTITY FROM Det_conversation"
                _comando = New SqlCommand(sql, _comando.Connection)
                Dim value As Object = _comando.ExecuteScalar
                IdDet = value.ToString
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return IdDet

    End Function

    Private Sub cmdTransferir_Click(sender As System.Object, e As System.EventArgs) Handles cmdTransferir.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim IdPerson As Integer
        Dim orden As Integer

        IdPerson = 3

        _comando.Connection.Open()

        Dim resp As Boolean
        Dim SQL As String

        IdPerson = 3

        orden = 0

        For Each r In LvwAssigned.Items

            _comando.Parameters.Clear()

            Console.WriteLine(r.SubItems(1).Text)
            Console.WriteLine(r.SubItems(2).Text)
            Console.WriteLine(r.SubItems(3).Text)
            Console.WriteLine(r.SubItems(4).Text)
            Console.WriteLine(r.SubItems(0).Text)

            If orden > 3 Then
                orden = 0
                ' _comando.Connection.Open()

                _comando.Parameters.Clear()

                sqlstring = "Insert into Det_Conversation (Orden, Con_Id)"
                sqlstring = sqlstring & " Values (@Orden, '" & IdEnc & "')"

                _comando.CommandText = sqlstring

                _comando.Parameters.AddWithValue("@Orden", 0)

                Try

                    i = _comando.ExecuteNonQuery

                    If i > 0 Then
                        resp = True
                    Else
                        resp = False
                    End If


                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally

                End Try


                If i > 0 Then
                    SQL = "SELECT @@IDENTITY FROM Det_Conversation"

                    _comando = New SqlCommand(SQL, _comando.Connection)

                    Dim value As Object = _comando.ExecuteScalar
                    IdDet = value.ToString

                End If
                ' _comando.Connection.Close()

            End If
            '_comando.Connection.Open()

            sqlstring = "Insert into Dialogos (OracionId, Orden, DetConversacion)"
            sqlstring = sqlstring & " Values ('" & r.SubItems(0).Text & "', @Orden, '" & IdDet & "')"

            _comando.CommandText = sqlstring

            _comando.Parameters.AddWithValue("@Orden", orden)

            Try

                i = _comando.ExecuteNonQuery

                If i > 0 Then
                    resp = True
                Else
                    resp = False
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally

            End Try

            orden += 1

        Next

        _comando.Connection.Close()
        If resp Then
            MsgBox("se guardo")
        Else
            MsgBox("No se guardo")
        End If

        'txtBuscar.Text = ""

        Try
            'Dim frm As FrmConversation = CType(Owner, FrmConversation)
            Dim frm As frmEscenas = CType(Owner, frmEscenas)
            ' frm.CrearControles(filtro, frm.inicio, fin)
             
            Me.Close()
            ' Me.Dispose()
        Catch ex As Exception

            Me.Close()
            Me.Dispose()
            Exit Sub

        End Try


        If resp Then
            MsgBox("se guardo")

            ' CrearControles()

        Else
            MsgBox("No se guardo")
        End If

        'Dim item As ListViewItem


        'Dim _insertado As Boolean = False
        'Dim mostrarMensaje As Boolean = False
        'Dim stringvalues As String = ""
        'Dim sql As String = ""
        'Dim IdMax As Integer
        'Dim n As Integer

        '' Dim resp As Boolean
        'Dim param As String = ""

        '_comando.Connection.Open()


        'For Each r In LvwAssigned.Items

        '    Console.WriteLine(r.index)
        '    Console.WriteLine(r.SubItems(1).Text)

        '    _comando.Parameters.Clear()

        '    sqlstring = "UPDATE Det_Conversation SET Con_Id = @Con_Id, Det_orden=@Det_orden"
        'sqlstring = sqlstring & " WHERE Det_Con = @Det_Con"


        '_comando.Parameters.AddWithValue("@Det_orden", r.index)
        '_comando.Parameters.AddWithValue("@Det_Con", r.SubItems(1).Text)
        '' _comando.Parameters.AddWithValue("@Con_Id", txtIdConversationNew.Text)


        '_comando.CommandText = sqlstring

        'Try
        '    i = _comando.ExecuteNonQuery
        '    resp = True
        'Catch ex As Exception
        '    resp = False

        'End Try

        'Next
        '_comando.Connection.Close()



    End Sub

    Private Sub cmdEliminar_Click(sender As System.Object, e As System.EventArgs) Handles cmdEliminar.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim IdDialogo As Integer
        Dim orden As Integer
         
        IdDialogo = LvwUnassigned.SelectedItems(0).SubItems(1).Text

        sqlstring = "Delete From Dialogos "
        sqlstring = sqlstring & "  WHERE Id = '" & IdDialogo & "'"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()


        Try
            i = _comando.ExecuteNonQuery
        Catch ex As Exception

        End Try
        _comando.Connection.Close()

        LvwUnassigned.Items.Remove(LvwUnassigned.SelectedItems(0))
    End Sub

    Private Sub cmdNuevoDetalle_Click(sender As System.Object, e As System.EventArgs) Handles cmdNuevoDetalle.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim IdPerson As Integer
        Dim resp As Boolean

        IdPerson = 3

        _comando.Connection.Open()

        _comando.Parameters.Clear()

        sqlstring = "Insert into Det_Conversation (Orden, Con_Id)"
        sqlstring = sqlstring & " Values (@Orden, '" & IdEnc & "')"

        _comando.CommandText = sqlstring

        _comando.Parameters.AddWithValue("@Orden", 0)

        Try

            i = _comando.ExecuteNonQuery

            If i > 0 Then
                resp = True
            Else
                resp = False
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

         
        Dim sql As String


        Try
            If i > 0 Then
                sql = "SELECT @@IDENTITY FROM Det_conversation"

                _comando = New SqlCommand(sql, _comando.Connection)

                Dim value As Object = _comando.ExecuteScalar

                IdDet = value.ToString

            End If
            _comando.Connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        _comando.Connection.Close()

        txtDetId.Text = IdDet

        Dim param As String
        'param = " Where Det_Conversation.Con_Id='" & Id & "'"
        param = " Where Det_Conversation.Det_Con='" & IdDet & "'"

        CargarDatos(param)

    End Sub

    Private Sub cboConversation_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboConversation.SelectedIndexChanged

        IdEnc = cboConversation.Items(cboConversation.SelectedIndex).ItemData()

        Dim param As String
        'param = " Where Det_Conversation.Con_Id='" & Id & "'"
        param = " Where d.Con_Id ='" & IdEnc & "'"

        CargarDatos(param)

    End Sub

    Private Sub cmdConsultaHuerfanos_Click(sender As System.Object, e As System.EventArgs) Handles cmdConsultaHuerfanos.Click

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim buscar As String
        Dim sqlstring As String = ""
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer
        
         
        Dim param As String

        param = " Where FrecuenciaUso='0'"
        param = param & " ORDER BY Reproduccion desc"
        'param = param & " order by o.TextoPlano "

        sqlstring = "select top 500  Id, orden, TextoPlano, Traduccion, Estatus, Oracion,  GrupoO, Reproduccion from Oraciones "
        ' sqlstring = sqlstring & " Where TextoPlano LIKE '%' + @buscar + '%'"
        sqlstring = sqlstring & param

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()
            '_comando.Parameters.AddWithValue("@buscar", buscar)

            da.SelectCommand = _comando

            da.Fill(dt)

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            _comando.Connection.Close()
        Finally
        End Try

        LvwAssigned.Items.Clear()

        n = dt.Rows.Count
        '    da.Fill(dt)
        i = 0

        Do While i <= n - 1

            ' lstAgregar.Items.Add(i)

            Dim item As ListViewItem 'Creo el ListViewItem (item) 


            item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            item.UseItemStyleForSubItems = False
            item.Text = dt.Rows(i).Item(0)
            Try

                'item.SubItems.Add(dt.Rows(i).Item(0))
                item.SubItems.Add(dt.Rows(i).Item(0))
                item.SubItems.Add(dt.Rows(i).Item(2))
                item.SubItems.Add(dt.Rows(i).Item(3))
                item.SubItems.Add("X")

                If Not IsDBNull(dt.Rows(i).Item(7)) Then
                    item.SubItems.Add(dt.Rows(i).Item(7))
                Else
                    item.SubItems.Add(0)
                End If


                item.SubItems(1).ForeColor = Color.Blue

                LvwAssigned.Items.Add(item)


            Catch ex As Exception

            End Try


            'Agrego el item a la colección de listViewItem's de ListView1

            i = i + 1

        Loop


        
        

    End Sub

    Private Sub cmdAgregaaDialogo_Click(sender As System.Object, e As System.EventArgs) Handles cmdAgregaaDialogo.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim i As Integer
        Dim n As Integer

        ' IdDet = GeneraDialogo()

        _comando.Connection.Open()

        For Each r In LvwUnassigned.Items

            

            If r.SubItems(4).Text = "X" Then

                ' IdDet = GeneraDialogo()

                sqlstring = "Insert into Tbl_Dialogos (IdOracion, Orden, IdConversacion, Item)"
                sqlstring = sqlstring & " Values ('" & r.SubItems(0).Text & "', @Orden, '" & IdDetalle & "', @Item)"

                _comando.CommandText = sqlstring
                _comando.Parameters.Clear()

                _comando.Parameters.AddWithValue("@Orden", r.index)
                _comando.Parameters.AddWithValue("@Item", MaxItem + 1)


                i = _comando.ExecuteNonQuery
                MaxItem = MaxItem + 1
                If i > 0 Then
                    ' resp = True
                    n = n + 1
                Else
                    ' resp = False
                End If

                r.SubItems(4).Text = "0"

               

            End If


        Next

        _comando.Connection.Close()
       

        _comando.Parameters.Clear()

        sqlstring = "UPDATE Det_Conversation SET Orden = @Orden, Status='R'"
        sqlstring = sqlstring & " WHERE Det_Con = @Det_Con"
        _comando.CommandText = sqlstring


        _comando.Parameters.AddWithValue("@Orden", 0)
        _comando.Parameters.AddWithValue("@Det_Con", IdDetalle)

        _comando.Connection.Open()

            i = _comando.ExecuteNonQuery

        ' MsgBox("actualizado")

            resp = True
         

        _comando.Connection.Close()

            Dim frm As frmMoverDetalleConversacion = CType(Owner, frmMoverDetalleConversacion)
            frm.CargarDatosActual()
            Me.Close()
            Me.Dispose()
       
    End Sub

    Private Sub cmdBuscador_Click(sender As System.Object, e As System.EventArgs) Handles cmdBuscador.Click

        Dim psi As New ProcessStartInfo()
        Dim p As Process '
        Dim resultado As String
     
        psi = New ProcessStartInfo()
        psi.FileName = "python"
        psi.Arguments = """C:\legacy\Programas\Voz_Natural\buscador1.py"""
        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.CreateNoWindow = True

        p = Process.Start(psi)
        resultado = p.StandardOutput.ReadToEnd()
        p.WaitForExit()

    End Sub
End Class

 


 