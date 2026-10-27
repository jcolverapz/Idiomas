Imports Entidades
Imports Negocios
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Data.SqlClient
'Imports RichTextBoxEx
Imports System.IO

Public Class FrmDetVocabulario

    Public Id As Integer
    Public IdOracion As Integer
    Dim Usadas As String
    Dim Grupo As String
    Dim GrupoId As Integer
    Public instruccion As New OleDbCommand
    Public contenedor As String
    Public sqlstring As String
    Public MaxColumna As Integer
    Public ColorActivo As Object = System.Drawing.Color.FromArgb(198, 255, 196)
    ' Public ColorInicio As SystemBrushes = Brushes.Gainsboro


    'Public Shared Id As Integer
    Public consulta As String
    Dim rowcount As Integer
    ' Public Device As clsDevice
    'Public Id As Integer
    Public Nombre As String = ""
    Public Tipo As String = ""
    Public tipoId As Integer
    Public Status As String = ""
    Public Area As String = ""

    Public Color1 As Color = System.Drawing.Color.FromArgb(253, 239, 202)
    Public Color2 As Color = System.Drawing.Color.FromArgb(128, 94, 14)

    Public Color3 As Color = System.Drawing.Color.FromArgb(209, 235, 222)
    Public Color4 As Color = System.Drawing.Color.FromArgb(31, 92, 60)

    Public Color5 As Color = System.Drawing.Color.FromArgb(207, 218, 223)
    Public Color6 As Color = System.Drawing.Color.FromArgb(19, 49, 57)


    Public avatar1 As Brush = New SolidBrush(Color1)
    Public LblAvatar1 As Brush = New SolidBrush(Color2)

    Public avatar2 As Brush = New SolidBrush(Color3)
    Public LblAvatar2 As Brush = New SolidBrush(Color4)

    Public avatar3 As Brush = New SolidBrush(Color5)
    Public LblAvatar3 As Brush = New SolidBrush(Color6)

    Public Departamento As String = ""
    Public Ubicacion As String = ""
    Public NombreEmpleado As String = ""
    Public ApellidoEmpleado As String = ""
    Public Anydesk As String = ""
    Public estadoCerrado As String = ""
    Public UsuarioCorreo As String = ""
    Public descripcion As String = ""
    Public descripcionCorta As String = ""
    Public estado As String = ""
    Public ContentWord As String = ""
    Public UsuarioAbrioId As String = ""
    Public UsuarioAbrio As String = ""
    Public UsuarioAsignado As String = ""
    Public Usuario As String = ""
    Public UsuarioId As String = ""
    Public Categoria1 As String = ""

    Public ArchivoAdjunto As String = ""
    Public fechaAbrio As Date
    Public HoraAbrio As String = ""
    Public fechaTermino As String = ""
    Public HoraTermino As String = ""
    Public Approval As String = ""
    Public Prioridad As String = ""
    Public fechaEntrega As String = Format(Today, "dd-MM-yyyy")
    Public bandAsignado As Boolean
    Public TipoTicket As String = ""

    'Traduccion
    Public word As String
    Public TextoPlano As String = ""
    Public Oracion As String = ""
    Public GrupoOracionId As Integer

    Public traduccion As String = ""

    Public bandTimeValue As Boolean
    Public bandEstado As Boolean
    Public lstModificaciones As New ListView

    Dim _comando As SqlCommand = MetodosDatos.CrearComando()
    Dim da As New SqlDataAdapter
    Dim i As Integer
    Dim indice As Integer
    Dim nm As String
    Dim str() As String
    Dim tp As String
    Dim param As String = ""
    Dim q As Integer

#Region "Inicio"
    Private Sub FrmDetVocabulario_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim test As Boolean
        ' Dim obj As New RichTextBoxEx.RichTextBoxEx

        '  obj.Controls.Item("rtb").Focus()

        ToolStatus.Text = "Oracion"

        'Grupos
        Dim Grupos As New DataTable

        Dim param As String = " WHERE Oraciones.Id=" & Id
        Dim resp As Integer

        Dim i, n As Integer

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim da As New SqlDataAdapter

        sqlstring = "SELECT       Id, Descripcion, Orden, estatus"
        sqlstring = sqlstring & " FROM Grupos"
        sqlstring = sqlstring & " order by Descripcion"

        'sqlstring = sqlstring & param

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(Grupos)

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        n = Grupos.Rows.Count

        Do While i <= n - 1
            Me.cmbGrupo.Items.Add(New clsItem(Grupos.Rows(i).Item(1), Grupos.Rows(i).Item(0)))
            i = i + 1
        Loop


    End Sub

    Public Sub CargarDatos(Id)

        Dim resp As Integer
        ' Dim Empleados As DataTable
        Dim i, n As Integer
        Dim IdOracion As Integer
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sql As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        param = " Where Conceptos.ID=" & Id

        sqlstring = "SELECT       Conceptos.ID, Conceptos.Concepto, Conceptos.Sel, Conceptos.Breve, Conceptos.Definicion, Conceptos.Tipo, Conceptos.Aprendi, Conceptos.GrupoID, Conceptos.Secuencia, Conceptos.IMG, Conceptos.parecido, "
        sqlstring = sqlstring & "   Conceptos.Uso, Conceptos.Subtipo, Conceptos.Past, Conceptos.IPA, Conceptos.Uso2, Conceptos.Grupo2, Conceptos.Principal, Conceptos.Nodo, Conceptos.Tiempo, Conceptos.Cuenta, Conceptos.ContentWord,"
        sqlstring = sqlstring & "   Grupos.Descripcion"
        sqlstring = sqlstring & "  FROM            Conceptos LEFT JOIN"
        sqlstring = sqlstring & "                  Grupos ON Conceptos.GrupoID = Grupos.Id"
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

        Dim carpeta As String = ""
        Dim filename As String = ""

        resp = dt.Rows.Count

        If resp = 0 Then Exit Sub

        ' IdOracion = dt.Rows(0).Item(0)

        txtId.Text = Id

        If Not IsDBNull(dt.Rows(0).Item(1)) Then
            word = dt.Rows(0).Item(1)
        End If
        txtDescripcion.Text = word


        If Not IsDBNull(dt.Rows(0).Item(4)) Then
            traduccion = dt.Rows(0).Item(4)
        End If
        txtTraduccion.Text = traduccion

        'estatus
        If Not IsDBNull(dt.Rows(0).Item(6)) Then
            If dt.Rows(0).Item(6) = True Then
                estado = "APRENDI"
            Else
                estado = "Falta APRENDER"
            End If
        End If
        cboState.Text = estado

        If Not IsDBNull(dt.Rows(0).Item(21)) Then
            If dt.Rows(0).Item(21) = True Then
                ContentWord = "True"
                chkContentWord.Checked = True

            Else
                ContentWord = "False"
                chkContentWord.Checked = False

            End If
        End If

        If Not IsDBNull(dt.Rows(0).Item(11)) Then
            If dt.Rows(0).Item(11) = True Then
                Usadas = "True"
                chkUsadas.Checked = True
            Else
                Usadas = "False"
                chkUsadas.Checked = False
            End If
        End If


        If Not IsDBNull(dt.Rows(0).Item(22)) Then
            Grupo = dt.Rows(0).Item(22)
            cmbGrupo.Text = Grupo
            GrupoId = dt.Rows(0).Item(7)

        End If


    End Sub

    Private Sub DetectChanges(Nombre, valor, NuevoValor, param)
        Dim item As ListViewItem 'Creo el ListViewItem (item) 
        Dim i As Integer

        i = lstModificaciones.Items.Count + 1

        If lstModificaciones.Items.Count = 0 Then

            item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            item.SubItems.Add(Nombre)
            item.SubItems.Add(valor)
            item.SubItems.Add(NuevoValor)
            item.SubItems.Add(param)

            lstModificaciones.Items.Add(item)

        Else

            Dim foundItem As ListViewItem = lstModificaciones.FindItemWithText(Nombre, True, 0, True)

            If (foundItem IsNot Nothing) Then

                lstModificaciones.Items(foundItem.Index).SubItems(1).Text = Nombre
                lstModificaciones.Items(foundItem.Index).SubItems(2).Text = valor
                lstModificaciones.Items(foundItem.Index).SubItems(3).Text = NuevoValor
                lstModificaciones.Items(foundItem.Index).SubItems(4).Text = param

            Else
                item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

                item.SubItems.Add(Nombre)
                item.SubItems.Add(valor)
                item.SubItems.Add(NuevoValor)
                item.SubItems.Add(param)

                lstModificaciones.Items.Add(item)

            End If
        End If

        lblmod.Text = "( " & lstModificaciones.Items.Count & " )"




    End Sub

#End Region



    Public Sub CargarConversation(Id)
        Dim param As String = " WHERE Oraciones.Id=" & Id
        Dim resp As Integer

        Dim i, n As Integer
        Dim IdOracion As Integer
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sql As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        sqlstring = " SELECT         Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Det_Conversation.Det_Orden, Det_Conversation.Con_Id, Det_Conversation.Det_Person, Det_Conversation.Det_Par, Oraciones.Oracion, "
        sqlstring = sqlstring & " Enc_Conversation.Con_Titulo, Enc_Conversation.Con_Id"
        sqlstring = sqlstring & " FROM            Det_Conversation INNER JOIN"
        sqlstring = sqlstring & "              Enc_Conversation ON Det_Conversation.Con_Id = Enc_Conversation.Con_Id INNER JOIN"
        sqlstring = sqlstring & "              Oraciones ON Det_Conversation.Det_OracionId = Oraciones.Id"

        'sqlstring = "select * from  Oraciones "
        sqlstring = sqlstring & param

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)
            ' DatosTicket = CapaLogica.CatalogoTickets(param)

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        n = dt.Rows.Count

        Do While i <= n - 1
            Me.cmbConversation.Items.Add(New clsItem(dt.Rows(i).Item(7), dt.Rows(i).Item(8)))
            i = i + 1
        Loop



    End Sub

    'Private Sub Solution(Id)
    '    Dim _comando As SqlCommand = MetodosDatos.CrearComando()
    '    Dim sqlstring As String
    '    Dim IdOracion As Integer
    '    Dim dt As New DataTable
    '    Dim da As New SqlDataAdapter
    '    Dim i As Integer

    '    ' IdOracion = lstOraciones.SelectedItems(0).Text


    '    sqlstring = "Insert into det_Conversation (Det_OracionId, Det_Orden, Con_Id)"
    '    sqlstring = sqlstring & " Values ('" & IdOracion & "', '0', '" & Id & "')"

    '    '  _comando.Connection = conexion
    '    _comando.CommandText = sqlstring
    '    _comando.Connection.Open()



    '    Try

    '        i = _comando.ExecuteNonQuery

    '        If i > 0 Then
    '            MsgBox("se guardo")

    '        Else
    '            MsgBox("No se guardo")
    '        End If

    '        ' CrearControles()


    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    Finally

    '    End Try

    'End Sub

    Private Sub lstOraciones_DoubleClick(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub lstOraciones_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        'Id = lstOraciones.SelectedItems(0).Text

    End Sub

    'Private Sub txtTraduccion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTraduccion.TextChanged
    '    If Me.txtTraduccion.Text <> traduccion Then
    '        Try
    '            DetectChanges("Traduccion", traduccion, txtTraduccion.Text, "")
    '            traduccion = txtTraduccion.Text
    '        Catch ex As Exception

    '        End Try
    '    End If
    'End Sub




    Private Sub Solution(Id)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer

        ' IdOracion = lstOraciones.SelectedItems(0).Text


        sqlstring = "Insert into det_Conversation (Det_OracionId, Det_Orden, Con_Id)"
        sqlstring = sqlstring & " Values ('" & IdOracion & "', '0', '" & Id & "')"

        '  _comando.Connection = conexion
        _comando.CommandText = sqlstring
        _comando.Connection.Open()



        Try

            i = _comando.ExecuteNonQuery

            If i > 0 Then
                MsgBox("se guardo")

            Else
                MsgBox("No se guardo")
            End If

            ' CrearControles()


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer

        ' sqlstring = "select * from  SubTemas "
        '    conexion.Open()

        'If cmbPersona.Text = "" Then Exit Sub
        'Try
        '    If lstOraciones.SelectedItems(0).Text = "" Then Exit Sub

        'Catch ex As Exception
        '    Exit Sub
        'End Try

        'IdOracion = lstOraciones.SelectedItems(0).Text
        ''Desc = lstOraciones.SelectedItems(0).Text

        sqlstring = "Insert into det_Conversation (Det_OracionId, Det_Orden, Con_Id, Det_Person)"
        ' sqlstring = sqlstring & " Values ('" & IdOracion & "', '0', '" & Id & "', '" & cmbPersona.Text & "')"

        '  _comando.Connection = conexion
        _comando.CommandText = sqlstring
        _comando.Connection.Open()




        Try

            i = _comando.ExecuteNonQuery

            If i > 0 Then
                MsgBox("se guardo")

            Else
                MsgBox("No se guardo")
            End If

            'CrearControles()


            '_comando.CommandText = sqlstring
            '_comando.Connection.Open()

            'da.SelectCommand = _comando

            'da.Fill(dt)

            '_comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        ' txtBuscar.Text = ""


        'If cmbPersona.Text = 1 Then
        '    cmbPersona.Text = 2
        'Else
        '    cmbPersona.Text = 1
        'End If
        ' RichTextBox1.LoadFile("C:\Legacy\Test.rtf")

    End Sub

    Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs)
        'Me.Close()
        Dim param As String

        Try

            lstModificaciones.Items.Clear()

            Dim frm As FrmTemas = CType(Owner, FrmTemas)

            'frm.cargarDatos()
            frm.CargarSubtemas(frm.IdTema)
            Me.Close()
            Me.Dispose()
        Catch ex As Exception

            Me.Close()
            Me.Dispose()
            Exit Sub

        End Try

    End Sub

    Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim buscar As String
        Dim sqlstring As String = ""
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        ' Dim da As New OleDbDataAdapter
        Dim i, n As Integer

        If buscar = "" Then Exit Sub

        sqlstring = " SELECT Id, TextoPlano, Traduccion  FROM Oraciones"

        sqlstring = sqlstring & " Where TextoPlano LIKE " & "'%" & buscar & "%'"
        sqlstring = sqlstring & " ORDER BY Oraciones.TextoPlano ASC"

        ' param = " WHERE Enc_Id  LIKE " & "'%" & param & "%'"


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
                item.SubItems.Add(dt.Rows(i).Item(1))
                item.SubItems.Add(dt.Rows(i).Item(2))

                item.SubItems(0).ForeColor = Color.Blue

                '   lstOraciones.Items.Add(item)


            Catch ex As Exception

            End Try


            'Agrego el item a la colección de listViewItem's de ListView1

            i = i + 1

        Loop



    End Sub


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)
        Dim n As Integer
        Dim pos As Integer

        '  n = ListView1.Items.Count

        pos = 1

        'IdOracion = lstOraciones.SelectedItems(0).Text

        'sqlstring = "UPDATE Det_Conversation SET Det_Orden = @Det_Orden"
        'sqlstring = sqlstring & " WHERE Id = @Id"

        '_comando.Parameters.AddWithValue("@Det_Orden", pos + 1)


        '_comando.CommandText = sqlstring
        '_comando.Connection.Open()

        Dim itemCurr As ListViewItem
        Dim itemOver As ListViewItem
        Dim itemSel As Integer
        Dim indice As Integer


        ' indice = ListView1.SelectedIndices.Item(0)
        'If ListView1.SelectedItems(0).Index = -1 Then Exit Sub

        'indice = ListView1.SelectedItems(0).Index


        'itemCurr = ListView1.SelectedItems(0)


        'If indice = ListView1.Items.Count - 1 Then

        '    'ListView1.Items.Remove(itemCurr)

        'Else

        '    If indice >= ListView1.Items.Count - 1 Then

        '        ListView1.Items.Remove(itemCurr)

        '    Else
        '        ListView1.Items.Remove(itemCurr)

        '        ListView1.Items.Insert(indice + 1, itemCurr)

        '    End If


        ' End If





    End Sub




    Private Sub RichTextBoxEx1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        MsgBox("test")

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)
        Dim IdOracion As Integer


        ' sqlstring = "select * from  SubTemas "
        '    conexion.Open()
        '  If cmbPersona.Text = "" Then Exit Sub
        IdOracion = txtId.Text


        Dim frm As New frmNewConversation
        frm.IdOracion = IdOracion
        '  frm.IdPersona = cmbPersona.Text

        frm.ShowDialog()

        ' CrearControles()





    End Sub

    Private Sub cmbConversation_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Dim frm As New FrmDetOracion


        Id = cmbConversation.Items(cmbConversation.SelectedIndex).ItemData()

        ' CrearControles()

    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs)
        frmNewOracion.Show()

    End Sub

    Private Sub CmdGuardar_Click(sender As System.Object, e As System.EventArgs) Handles CmdGuardar.Click
        Dim resp As Boolean
        Dim respcorreo As Boolean

         
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim item As ListViewItem

        Dim i As Integer
        Dim _insertado As Boolean = False
        Dim mostrarMensaje As Boolean = False
        Dim stringvalues As String = ""
        Dim sql As String = ""
        Dim IdMax As Integer

        Dim fecha As Date
        Dim fechaEntrega As Date

        ' fecha = Today

        _comando.Connection.Open()


        For Each r In lstModificaciones.Items

            _comando.Parameters.Clear()

            Console.WriteLine(r.SubItems(1).Text)
            Console.WriteLine(r.SubItems(3).Text)

            If r.SubItems(3).text = "Null" Then
                sqlstring = "UPDATE Conceptos SET " & r.SubItems(1).Text & " = Null"
                sqlstring = sqlstring & " WHERE Id = @Id"

            Else
                sqlstring = "UPDATE Conceptos SET " & r.SubItems(1).Text & " = @" & r.SubItems(1).Text
                sqlstring = sqlstring & " WHERE Id = @Id"

                'If r.subitems(1).text = "Enc_Fecha_Entrega" Then
                '    fechaEntrega = r.subitems(3).text
                '_comando.Parameters.AddWithValue("@" & r.SubItems(1).Text, fechaEntrega)

                'Else
                _comando.Parameters.AddWithValue("@" & r.SubItems(1).Text, r.SubItems(3).Text)

                'End If

            End If



            _comando.CommandText = sqlstring

            _comando.Parameters.AddWithValue("@Id", Id)
            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Next
        _comando.Connection.Close()


        If i > 0 Then
            'Return True
            ' MsgBox("Guardado")

        Else
            'Return False

        End If

        cmdExit_Click(sender, e)





    End Sub

    Private Sub txtTraduccion_TextChanged(sender As System.Object, e As System.EventArgs)
        If Me.txtTraduccion.Text <> traduccion Then
            Try
                DetectChanges("Traduccion", traduccion, txtTraduccion.Text, "")
                traduccion = txtTraduccion.Text
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub txtDescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDescripcion.TextChanged
        If Me.txtDescripcion.Text <> word Then
            Try
                DetectChanges("Concepto", word, txtDescripcion.Text, "")
                word = txtDescripcion.Text
            Catch ex As Exception

            End Try
        End If
    End Sub



    Private Sub WebBrowser1_DocumentCompleted(sender As System.Object, e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs)

    End Sub

    Private Sub cboState_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboState.SelectedIndexChanged
        Dim ESTATUS As Boolean
        If Me.cboState.Text <> estado Then
            Try

                If cboState.Text = "APRENDI" Then
                    ESTATUS = True
                Else
                    ESTATUS = False
                End If
                DetectChanges("Aprendi", ESTATUS, ESTATUS, "")
                estado = cboState.Text
            Catch ex As Exception

            End Try
        End If
    End Sub

    'Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles Button2.Click
    '    Dim Id As Integer
    '    Dim frm As New frmSubtema
    '    Dim filename As String = ""

    '    AddOwnedForm(frm)

    '    frm.ruta = "C:\Legacy\Ingles\Temas\"
    '    frm.carpeta = carpeta
    '    frm.archivo = archivo
    '    frm.Id = Id
    '    frm.txtSubtema.Text = Subtema
    '    frm.CargarDatos(Id)
    '    frm.ShowDialog()


    'End Sub

    'Private Sub txtOrden_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOrden.TextChanged
    '   
    'End Sub

    Private Sub cmbGrupo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbGrupo.SelectedIndexChanged
        Dim GrupoIdNuevo As Integer
        GrupoIdNuevo = cmbGrupo.Items(cmbGrupo.SelectedIndex).ItemData()

        If GrupoId <> GrupoIdNuevo Then
            DetectChanges("GrupoId", "", GrupoIdNuevo, "")
            GrupoId = GrupoIdNuevo
        End If

    End Sub


    Private Sub cmdExit_Click_1(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
        Me.Close()

    End Sub

    Private Sub chkContentWord_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkContentWord.CheckedChanged
        Dim valor As String

        If chkContentWord.Checked = "True" Then
            chkContentWord.Text = "Content Word"
            valor = "True"
        Else
            chkContentWord.Text = "No Content Word"
            valor = "False"

        End If

        If valor <> ContentWord Then
            Try
                DetectChanges("ContentWord", ContentWord, valor, "")
                ContentWord = chkContentWord.Text
            Catch ex As Exception

            End Try
        End If

    End Sub

  
    Private Sub chkUsadas_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkUsadas.CheckedChanged
        Dim valor As String

        If chkUsadas.Checked = "True" Then
            chkUsadas.Text = "Mas Usadas"
            valor = "True"
        Else
            chkUsadas.Text = "Menos Usadas"
            valor = "False"

        End If

        If valor <> Usadas Then
            Try
                DetectChanges("Uso", Usadas, valor, "")
                Usadas = chkUsadas.Text
            Catch ex As Exception

            End Try
        End If
    End Sub
 
End Class