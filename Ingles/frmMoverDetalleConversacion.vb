Imports System.Data
'Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Imports System.Windows.Forms
'Imports Microsoft.Office.Interop.Word
'Imports Microsoft.Office.Interop
Imports System.Diagnostics
Imports System.Text
Imports System.Web.Script.Serialization
Imports System.Text.Json


Public Class frmMoverDetalleConversacion
    Dim Cuenta As Integer

    Dim ItemUltimo As Integer
    Dim lstEncontrados As New ListView
    Dim Tipo As String
    Dim FILASELECT As Integer = -1
    Dim ULTIMASELECCIONADA As Integer = -1
    Dim _comandoLocal As SqlCommand = MetodosDatos.CrearComando()
    Dim LastIndex As Integer
    Dim firstIndex As Integer = -1
    Dim ListProv As New ListView
    Dim nuevoListView As New ListView
    Dim OrdenDialogo As Integer
    Dim total As Integer
    Dim aprendidos As Integer
    Dim BestIndex As Integer
    Public Enc_Id As Integer
    Dim STATUS As String = "R"
    Dim COPIA As Boolean = True
    Dim bandEstructura As Boolean
    Dim detalleId As Integer
    Public SeleccionadoEscenas As String

#Region "Inicio"

    Private Sub frmMoverDetalleConversacion_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'cmdRevisados.UseVisualStyleBackColor = False
        'cmdRevisados.BackColor = Color.FromArgb(33, 37, 43)
        'cmdRevisados.ForeColor = Color.White
        'cmdRevisados.FlatStyle = FlatStyle.Flat
        'cmdRevisados.FlatAppearance.BorderColor = Color.FromArgb(62, 68, 81)
        ''cmdRevisados.UseVisualStyleBackColor = False
        ''cmdRevisados.BackColor = Color.FromArgb(40, 44, 52)

        LvwAssigned.View = View.Details ' Set the view to show details.
        LvwAssigned.LabelEdit = False ' Allow the user to edit item text.
        LvwAssigned.AllowColumnReorder = True ' Allow the user to rearrange columns.
        LvwAssigned.FullRowSelect = True ' Select the item and subitems when selection is made.
        LvwAssigned.GridLines = False ' Display grid lines.
        LvwAssigned.BorderStyle = BorderStyle.None
        'LvwAssigned.OwnerDraw = True
        ' LvwAssigned.SelectedBackColor = Color.DarkBlue
        ' LvwAssigned.SelectedForeColor = Color.White ' LvwAssigned.SmallImageList = ImageList1
        ' LvwAssigned.OwnerDraw = True
        ' LvwAssigned.FullRowSelect = True
        ' LvwAssigned.HideSelection = False
        ' LvwAssigned.BackColor = Color.FromArgb(40, 44, 52)
        'LvwAssigned.ForeColor = Color.FromArgb(171, 178, 191)

        LvwUnAssigned.View = View.Details ' Set the view to show details.
        LvwUnAssigned.LabelEdit = False ' Allow the user to edit item text.
        LvwUnAssigned.AllowColumnReorder = True ' Allow the user to rearrange columns.
        LvwUnAssigned.FullRowSelect = True ' Select the item and subitems when selection is made.
        LvwUnAssigned.GridLines = False ' Display grid lines.

        LvwActual.View = View.Details ' Set the view to show details.
        LvwActual.LabelEdit = False ' Allow the user to edit item text.
        LvwActual.AllowColumnReorder = True ' Allow the user to rearrange columns.
        LvwActual.FullRowSelect = True ' Select the item and subitems when selection is made.
        LvwActual.GridLines = False ' Display grid lines.

        ListView1.View = View.Details ' Set the view to show details.
        ListView1.LabelEdit = False ' Allow the user to edit item text.
        ListView1.AllowColumnReorder = True ' Allow the user to rearrange columns.
        ListView1.FullRowSelect = True ' Select the item and subitems when selection is made.
        ListView1.GridLines = False ' Display grid lines.


        'lvwFrases.View = View.Details ' Set the view to show details.
        'lvwFrases.LabelEdit = False ' Allow the user to edit item text.
        'lvwFrases.AllowColumnReorder = True ' Allow the user to rearrange columns.
        'lvwFrases.FullRowSelect = True ' Select the item and subitems when selection is made.
        'lvwFrases.GridLines = False ' Display grid lines.

        'lvwRevisado.View = View.Details ' Set the view to show details.
        'lvwRevisado.LabelEdit = False ' Allow the user to edit item text.
        'lvwRevisado.AllowColumnReorder = True ' Allow the user to rearrange columns.
        'lvwRevisado.FullRowSelect = True ' Select the item and subitems when selection is made.
        'lvwRevisado.GridLines = True ' Display grid lines.

        txtConversacion.Text = Enc_Id
        Me.Text = ModVar.Conversacion

        Dim imgList As New ImageList()
        imgList.ImageSize = New Size(48, 48)

        Dim rutaF As String = "C:\Ingles\Imagenes_Ingles\Femenino\Like.png"
        Dim rutaM As String = "C:\Ingles\Imagenes_Ingles\Masculino\Like.png"

        imgList.Images.Clear()

        Using fs As New IO.FileStream(rutaF, IO.FileMode.Open, IO.FileAccess.Read)
            Using temp As Image = Image.FromStream(fs)
                imgList.Images.Add("Femenino", New Bitmap(temp)) ' 🔥 CLAVE
            End Using
        End Using

        'If IO.File.Exists(rutaF) Then
        '    Using temp As Image = Image.FromFile(rutaF)
        '        imgList.Images.Add("Femenino", New Bitmap(temp))
        '    End Using
        'End If

        'If IO.File.Exists(rutaM) Then
        '    Using temp As Image = Image.FromFile(rutaM)
        '        imgList.Images.Add("Masculino", New Bitmap(temp))
        '    End Using
        'End If



        'If IO.File.Exists(rutaF) Then
        '    Using fs As New IO.FileStream(rutaF, IO.FileMode.Open, IO.FileAccess.Read)
        '        imgList.Images.Add("Femenino", Image.FromStream(fs))
        '    End Using
        'End If
        'If IO.File.Exists(rutaM) Then
        '    Using fs As New IO.FileStream(rutaM, IO.FileMode.Open, IO.FileAccess.Read)
        '        imgList.Images.Add("Masculino", Image.FromStream(fs))
        '    End Using
        'End If

        'Using temp As Image = Image.FromFile(rutaF)
        '    imgList.Images.Add("Femenino", New Bitmap(temp))
        'End Using

        'Dim imgList As New ImageList()
        'imgList.ImageSize = New Size(48, 48)

        'imgList.Images.Add("Femenino", Image.FromFile("C:\legacy\Ingles\Imagenes_Ingles\Femenino\Like.png"))
        'Try
        '    imgList.Images.Add("Masculino", Image.FromFile("C:\legacy\Ingles\Imagenes_Ingles\Masculino\Like.png"))

        'Catch ex As Exception
        '    Exit Sub
        'End Try

        LvwAssigned.SmallImageList = imgList

        Dim param As String

        param = " Where d.Con_Id='" & Enc_Id & "' And l.Item='0' And d.status='R'"
        param = param & " ORDER BY d.orden ASC, l.Orden ASC, l.Item ASC"


        '=====================
        ' Datos
        '=======================
        CargarDatos(param)

        ' CargarDatosSugerencia(param)

        CargarDatosDetalles() 'Fallo


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

        txtStatus.Text = STATUS

        'Conversaciones

        i = 0
        n = dt.Rows.Count

        Do While i <= n - 1
            If Not IsDBNull(dt.Rows(i).Item(1)) Then
                cboConversation.Items.Add(New clsItem(dt.Rows(i).Item(1), dt.Rows(i).Item(0)))
                cboConversaciones.Items.Add(New clsItem(dt.Rows(i).Item(1), dt.Rows(i).Item(0)))
                cboConversacionPrincipal.Items.Add(New clsItem(dt.Rows(i).Item(1), dt.Rows(i).Item(0)))
                cboTipoC.Items.Add(New clsItem(dt.Rows(i).Item(1), dt.Rows(i).Item(0)))

            Else
                cboConversation.Items.Add(New clsItem("Sin descripcion", dt.Rows(i).Item(0)))
                cboConversaciones.Items.Add(New clsItem("Sin descripcion", dt.Rows(i).Item(0)))
                cboConversacionPrincipal.Items.Add(New clsItem("Sin descripcion", dt.Rows(i).Item(0)))
                cboTipoC.Items.Add(New clsItem("Sin descripcion", dt.Rows(i).Item(0)))
            End If
            i = i + 1
        Loop

        cboTipoOracion.Items.Add("Saludo")
        cboTipoOracion.Items.Add("Cortesia")
        cboTipoOracion.Items.Add("Declaracion")
        cboTipoOracion.Items.Add("Despedida")
        cboTipoOracion.Items.Add("Explicacion")
        cboTipoOracion.Items.Add("Expresion")
        cboTipoOracion.Items.Add("Fragmento")
        cboTipoOracion.Items.Add("Instruccion")
        cboTipoOracion.Items.Add("Opinion")
        cboTipoOracion.Items.Add("Otro")
        cboTipoOracion.Items.Add("Pregunta")
        cboTipoOracion.Items.Add("Respuesta")


        'naturalidad
        cboNaturalidad.Items.Add("Natural")
        cboNaturalidad.Items.Add("Normal")
        cboNaturalidad.Items.Add("Rara")
        cboNaturalidad.Items.Add("Muy natural")
        'cboNaturalidad.Items.Add("Conversacion")
        'cboNaturalidad.Items.Add("Leccion")
        'cboNaturalidad.Items.Add("Serie")

        Dim Temas As New DataTable
        da = New SqlDataAdapter

        ' sqlstring = "select distinct Id, Tema from  Oraciones "
        ' sqlstring = sqlstring & " ORDER By Tema ASC"
        ' sqlstring = "SELECT DISTINCT Id, Tema FROM Oraciones ORDER BY Tema"
        'sqlstring = "SELECT MIN(Id) AS Id, Tema FROM Oraciones " &
        '    "WHERE Tema IS NOT NULL " &
        '    "GROUP BY Tema " &
        '    "ORDER BY Tema"

        sqlstring = "SELECT DISTINCT Tema"
        sqlstring = sqlstring & " FROM Oraciones"
        sqlstring = sqlstring & " ORDER BY Tema"

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(Temas)

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try

        cboTipoOracion.Items.Clear()

        n = Temas.Rows.Count
        j = 0
        Do While j <= n - 1

            If Not IsDBNull(Temas.Rows(j).Item(0)) Then
                ' cboTipoOracion.Items.Add(New clsItem(Temas.Rows(j).Item(1), Temas.Rows(j).Item(0)))
                cboTipoOracion.Items.Add(Temas.Rows(j).Item(0))
            End If
            j = j + 1

        Loop


        ' cmdcompras.Image = My.Resources.shop_remove

        cmdcompras.Image = New Bitmap(My.Resources.shop_remove, New Size(65, 65))
        cmdCortesia.Image = New Bitmap(My.Resources.sombrero, New Size(65, 65))
        cmdSaludos.Image = New Bitmap(My.Resources.manor, New Size(65, 65))
        cmdRestaurante.Image = New Bitmap(My.Resources.Hamburguesa, New Size(65, 65))
        cmdDaily.Image = New Bitmap(My.Resources.rutina, New Size(65, 65))
        cmdDeportes.Image = New Bitmap(My.Resources.deporte, New Size(65, 65))
        cmdclima.Image = New Bitmap(My.Resources.clima, New Size(65, 65))
        cmdDespedida.Image = New Bitmap(My.Resources.adios, New Size(65, 65))
        cmdIniciando.Image = New Bitmap(My.Resources.personal, New Size(65, 65))
        cmdviaje.Image = New Bitmap(My.Resources.avion, New Size(65, 65))
        cmdExpresiones.Image = New Bitmap(My.Resources.Expresion, New Size(65, 65))
        cmdDialogo.Image = New Bitmap(My.Resources.dialogo, New Size(65, 65))
        cmdInstruccion.Image = New Bitmap(My.Resources.mazo, New Size(65, 65))
        cmdDireccion.Image = New Bitmap(My.Resources.direccion, New Size(65, 65))
        cmdtiempo.Image = New Bitmap(My.Resources.tiempo, New Size(65, 65))
        cmdFamilia.Image = New Bitmap(My.Resources.familia, New Size(65, 65))

        Dim tt As New ToolTip()

        tt.AutoPopDelay = 5000    ' Tiempo visible
        tt.InitialDelay = 500     ' Tiempo antes de aparecer
        tt.ReshowDelay = 200      ' Tiempo entre cambios
        tt.ShowAlways = True

        tt.SetToolTip(cmdSaludos, "Saludos")
        tt.SetToolTip(cmdCortesia, "Cortesia")
        tt.SetToolTip(cmdcompras, "Compras")
        tt.SetToolTip(cmdRestaurante, "Food")
        tt.SetToolTip(cmdDaily, "Daily routine")
        tt.SetToolTip(cmdDeportes, "Deportes")
        tt.SetToolTip(cmdclima, "Clima")
        tt.SetToolTip(cmdDespedida, "Despedidas")
        tt.SetToolTip(cmdIniciando, "Personal Info")

        '  Dim index As Integer = 10 ' el índice que quieres

        'If SeleccionadoEscenas >= 0 AndAlso SeleccionadoEscenas < LvwAssigned.Items.Count Then

        '    LvwAssigned.Items(SeleccionadoEscenas).Selected = True
        '    LvwAssigned.Items(SeleccionadoEscenas).Focused = True

        '    LvwAssigned.EnsureVisible(SeleccionadoEscenas)

        'End If
        'Dim item As ListViewItem = LvwAssigned.FindItemWithText(SeleccionadoEscenas)
        If LvwAssigned.Items.Count > 0 Then
            If IsNothing(SeleccionadoEscenas) Then Exit Sub
            Dim foundItem As ListViewItem = LvwAssigned.FindItemWithText(SeleccionadoEscenas, True, 0, True)

            If (foundItem IsNot Nothing) Then
                LvwAssigned.SelectedItems.Clear()
                foundItem.Selected = True
                foundItem.Focused = True
                foundItem.EnsureVisible()
            End If
        End If


        '  LvwAssigned.Columns(2).Width = 300
        ' If item IsNot Nothing Then
        '
        'End If



    End Sub

    Private Sub CmdCerrar_Click(sender As System.Object, e As System.EventArgs) Handles CmdCerrar.Click



        Dim param As String

        Try

            'If total <> 0 Then
            GuardarAvance(total, aprendidos)
            ' End If

            Dim frm As frmConversaciones = CType(Owner, frmConversaciones)

            Me.Close()
            Me.Dispose()
        Catch ex As Exception

            Me.Close()
            Me.Dispose()
            Exit Sub

        End Try


        Me.Close()
        Me.Dispose()

    End Sub
    Private Sub GuardarAvance(n, a)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim resp As Boolean
        Dim respcorreo As Boolean
        Dim item As ListViewItem

        Dim i As Integer
        Dim _insertado As Boolean = False
        Dim mostrarMensaje As Boolean = False
        Dim stringvalues As String = ""
        Dim sql As String = ""
        Dim IdMax As Integer

        Dim avance As Double

        _comando.Connection.Open()

        _comando.Parameters.Clear()

        sqlstring = "UPDATE Enc_Conversation SET Con_Cant = @Con_Cant, Con_aprendidos = @Con_aprendidos, Con_avance = @Con_avance"
        sqlstring = sqlstring & " WHERE Con_Id = @Con_Id"

        _comando.Parameters.AddWithValue("@Con_Cant", n)
        _comando.Parameters.AddWithValue("@Con_aprendidos", a)

        If n <> 0 Then
            avance = a / n
        Else
            avance = 0
        End If

        'Try
        '    avance = (a / n) ' * 100
        'Catch ex As Exception
        '    avance = 0
        'End Try

        If avance < 0 Then
            avance = 0
        End If

        If Not IsNumeric(avance) Then
            avance = 0
        End If

        _comando.Parameters.AddWithValue("@Con_avance", avance)

        _comando.CommandText = sqlstring

        _comando.Parameters.AddWithValue("@Con_Id", Enc_Id)
        Try
            i = _comando.ExecuteNonQuery

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        _comando.Connection.Close()


        Dim psi As New ProcessStartInfo()
        psi.FileName = "python"
        psi.Arguments = """C:\legacy\Programas\Voz_Natural\eliminaRepetidosIdOracion.py"""
        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.CreateNoWindow = True

        Dim p As Process = Process.Start(psi)
        Dim resultado As String = p.StandardOutput.ReadToEnd()
        p.WaitForExit()

        ' MessageBox.Show(resultado)

    End Sub
    Public Sub CargarDatos(param)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer

        sqlstring = " SELECT        d.Det_Con, l.IdOracion, d.Orden, d.Con_Id, o.Traduccion, d.Det_Par, o.Tipo, "
        sqlstring = sqlstring & " o.TextoPlano, l.Orden, l.Id, l.pin, l.personaje, o.NivelCEFR, o.tema , o.EsRespuesta, o.respuesta, o.traducciontexto, o.Conversacion, o.STL, o.SEL, d.status"

        If ModVar.Idioma = "EN" Then
            sqlstring = sqlstring & " FROM            Tbl_Dialogos l INNER JOIN"
            sqlstring = sqlstring & "                 Oraciones o ON l.IdOracion = o.Id INNER JOIN"
        Else
            sqlstring = sqlstring & " FROM            Tbl_Dialogos_fr l INNER JOIN"
            sqlstring = sqlstring & "                 Oraciones_fr o ON l.IdOracion = o.Id INNER JOIN"
        End If
        sqlstring = sqlstring & "                Det_Conversation  d ON l.IdConversacion = d.Det_Con"
        sqlstring = sqlstring & param

        Console.WriteLine(sqlstring)

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try

        _comando.Connection.Close()

        n = dt.Rows.Count


        Dim objDataReader As SqlDataReader

        sqlstring = "SELECT d.Con_Id, "
        sqlstring = sqlstring & "COUNT(*) AS TotalDialogos, "
        sqlstring = sqlstring & "SUM(CASE WHEN o.STL = 1 THEN 1 ELSE 0 END) AS TotalSTL "

        If ModVar.Idioma = "EN" Then
            sqlstring = sqlstring & " FROM Tbl_Dialogos l "
            sqlstring = sqlstring & "INNER JOIN Oraciones o ON l.IdOracion = o.Id "
        Else
            sqlstring = sqlstring & " FROM Tbl_Dialogos_fr l "
            sqlstring = sqlstring & "INNER JOIN Oraciones_fr o ON l.IdOracion = o.Id "

        End If
        sqlstring = sqlstring & "INNER JOIN Det_Conversation d ON l.IdConversacion = d.Det_Con "
        sqlstring = sqlstring & " WHERE d.Con_Id ='" & Enc_Id & "'"
        sqlstring = sqlstring & "GROUP BY d.Con_Id"

        'sqlstring = "SELECT COUNT(*) AS TotalDialogos "
        'sqlstring = sqlstring & " FROM Tbl_Dialogos l "
        'sqlstring = sqlstring & " INNER JOIN Oraciones o ON l.IdOracion = o.Id "
        'sqlstring = sqlstring & " INNER JOIN Det_Conversation d ON l.IdConversacion = d.Det_Con "
        'sqlstring = sqlstring & " WHERE d.Con_Id 
        ' sqlstring = sqlstring & param
        ' sqlstring = sqlstring & " ORDER BY d.Con_Id"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        objDataReader = _comando.ExecuteReader

        Do While objDataReader.Read()
            total = objDataReader(1)
            aprendidos = objDataReader(2)

        Loop



        '''''''''
        ''CONVERTIR DATATABLE A JSON
        'Dim lista As New List(Of Dictionary(Of String, Object))

        'For Each row As DataRow In dt.Rows

        '    Dim dict As New Dictionary(Of String, Object)

        '    For Each col As DataColumn In dt.Columns
        '        dict(col.ColumnName) = row(col)
        '    Next

        '    lista.Add(dict)
        'Next

        'Dim serializer As New JavaScriptSerializer()



        ' 4. Cargar en ListView
        ' -----------------------------------------

        LvwAssigned.Items.Clear()

        Dim itm As New ListViewItem
        Dim j As Integer



        lblStatus.Text = "total:" & n & " " & Now

        If n = 0 Then Exit Sub

        Do While i <= n - 1

            itm = New ListViewItem("") 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            itm.UseItemStyleForSubItems = False

            itm.SubItems.Add(dt.Rows(i).Item(0)) ' d.Det_Con, 
            itm.SubItems.Add(dt.Rows(i).Item(7)) ', d.Orden,  

            If Not IsDBNull(dt.Rows(i).Item(4)) Then 'o.Traduccion
                itm.SubItems.Add(dt.Rows(i).Item(4))
            Else
                itm.SubItems.Add("Sin traduccion")
            End If

            'If dt.Rows(i).Item(18) = False Then 'o.Traduccion
            '    itm.SubItems(3).ForeColor = Color.LightGray
            'Else
            '    itm.SubItems(3).ForeColor = Color.Chartreuse
            'End If

            'If dt.Rows(i).Item(19) = True Then 'o.Traduccion
            '    itm.SubItems(3).ForeColor = Color.LightSalmon
            'End If

            itm.SubItems.Add(dt.Rows(i).Item(9)) ' o.Id
            itm.SubItems.Add("X")
            itm.SubItems.Add(dt.Rows(i).Item(6))
            itm.SubItems.Add(dt.Rows(i).Item(1)) 'l.IdOracion

            If Not IsDBNull(dt.Rows(i).Item(12)) Then
                itm.SubItems.Add(dt.Rows(i).Item(12))
            Else
                itm.SubItems.Add("N")

            End If
            'Contexto
            If Not IsDBNull(dt.Rows(i).Item(13)) Then
                itm.SubItems.Add(dt.Rows(i).Item(13))
            Else
                itm.SubItems.Add("N")

            End If

            If dt.Rows(i).Item(11) = "A" Then 'Personaje
                itm.ImageKey = "Femenino"   ' itm.ImageIndex = 2   ' Femenino
            Else
                itm.ImageKey = "Masculino" '    itm.ImageIndex = 3  ' Masculino
            End If

            If dt.Rows(i).Item(6) = "Q" Then
                itm.SubItems(2).ForeColor = Color.Cyan
                itm.SubItems(3).ForeColor = Color.Cyan
            ElseIf dt.Rows(i).Item(6) = "S" Then
                itm.SubItems(2).ForeColor = Color.LightGreen
                itm.SubItems(3).ForeColor = Color.LightGreen
            ElseIf dt.Rows(i).Item(6) = "C" Then
                itm.SubItems(2).ForeColor = Color.Gainsboro
                itm.SubItems(3).ForeColor = Color.Gainsboro
            ElseIf dt.Rows(i).Item(6) = "O" Then
                itm.SubItems(2).ForeColor = Color.Yellow
                itm.SubItems(3).ForeColor = Color.Yellow
            ElseIf dt.Rows(i).Item(6) = "E" Then
                itm.SubItems(2).ForeColor = Color.Violet
                itm.SubItems(3).ForeColor = Color.Violet
            ElseIf dt.Rows(i).Item(6) = "R" Then
                itm.SubItems(2).ForeColor = Color.LightSalmon
                itm.SubItems(3).ForeColor = Color.LightSalmon
            Else
                itm.SubItems(2).ForeColor = Color.Honeydew
                itm.SubItems(3).ForeColor = Color.Honeydew
            End If

            'Status
            If Not IsDBNull(dt.Rows(i).Item(20)) Then
                itm.SubItems.Add(dt.Rows(i).Item(20))
            End If

            LvwAssigned.Items.Add(itm)      'Agrego el item a la colección de listViewItem's de ListView1




            ''item = LvwAssigned.Items.Add("icon", 0) ' 0 = my icon ID in ImageList
            'If dt.Rows(i).Item(10) = "S" Then
            '    'itm.ImageIndex = 1
            '    firstIndex = i
            'End If
            'Dim Nuevoitem As ListViewItem
            'Dim copiedItem As ListViewItem = itm.Clone() ' new_item = DirectCast(item.Clone(), ListViewItem)

            'ListProv.Items.Add(DirectCast(itm.Clone, ListViewItem))
            'LvwAssigned.Items.Add(itm)      'Agrego el item a la colección de listViewItem's de ListView1

            'Nuevoitem = New ListViewItem(j) 'Creo una nueva instancia de item pasandole el nombre como dato principal 
            'Nuevoitem.SubItems.Add(dt.Rows(i).Item(0))

            'ListProv.Items.Add(Nuevoitem)

            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try


            i = i + 1
            j = j + 1

        Loop

        For Each item As ListViewItem In LvwAssigned.Items
            If item.Index = ULTIMASELECCIONADA Then
                item.Selected = True
                'item.SubItems(3).ForeColor = Color.Blue
                itm.SubItems(3).BackColor = Color.LightGreen

                item.Focused = True
                item.EnsureVisible()
                Exit For
            End If
        Next
        LvwAssigned.Select()


        txtCant.Text = n

        ' nuevoItem = item.Clone
        'Dim copiedItem As ListViewItem = item.Clone() ' new_item = DirectCast(item.Clone(), ListViewItem)
        '  ListProv.Items.Add(DirectCast(item.Clone, ListViewItem))

        '              Nuevoitem = New ListViewItem(j) 'Creo una nueva instancia de item pasandole el nombre como dato principal 
        '              Nuevoitem.SubItems.Add(dtOrdenado.Rows(i).Item(0))
        'ListProv.Items.Add(Nuevoitem)
        'LvwAssigned.View = View.Details ' Set the view to show details.
        'LvwAssigned.LabelEdit = False ' Allow the user to edit item text.
        'LvwAssigned.AllowColumnReorder = True ' Allow the user to rearrange columns.
        'LvwAssigned.FullRowSelect = True ' Select the item and subitems when selection is made.
        'LvwAssigned.GridLines = True ' Display grid lines.


    End Sub
    Public Sub CargarDatosDetalles()
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer

        sqlstring = " SELECT Det_Con, Orden, Con_Id, coherencia, Status"
        sqlstring = sqlstring & " FROM Det_Conversation "

        sqlstring = sqlstring & " Where Con_Id='" & Enc_Id & "'"
        sqlstring = sqlstring & " And Status='" & STATUS & "'"
        sqlstring = sqlstring & " ORDER BY      Orden      ASC "

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

        ' lvwFrases.Items.Clear()

        i = 0

        n = dt.Rows.Count

        If n = 0 Then Exit Sub

        Dim item As ListViewItem 'Creo el ListViewItem (item) 

        txtTotal.Text = n

        Dim Indice As Integer
        Dim y As Integer
        Dim foundItem As ListViewItem

        Do While i <= n - 1

            'y = 0
            item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            'Do
            '    foundItem = ListProv.FindItemWithText(dt.Rows(i).Item(0), True, 0, True)
            '    If (foundItem IsNot Nothing) Then
            '        foundItem.SubItems(1).Text = "A"
            '        y = y + 1
            '    End If
            'Loop While foundItem IsNot Nothing

            Try
                item.SubItems.Add(dt.Rows(i).Item(0))
                ' item.SubItems.Add(y)
                item.SubItems.Add(y)
                If Not IsDBNull(dt.Rows(i).Item(3)) Then
                    item.SubItems.Add(Math.Round((dt.Rows(i).Item(3) * 100), 0))
                Else
                    item.SubItems.Add("ND")
                End If

                ListView1.Items.Add(item)      'Agrego el item a la colección de listViewItem's de ListView1

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            i = i + 1

        Loop









    End Sub
    Public Sub CargarDatosSugerencia(param)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer

        sqlstring = " SELECT        d.Det_Con, Dialogos.OracionId, Det_Conversation.Det_Orden, Det_Conversation.Con_Id, Oraciones.Traduccion, Det_Conversation.Det_Par, Oraciones.EsRespuesta, "
        sqlstring = sqlstring & " Oraciones.TextoPlano, Dialogos.Orden, Dialogos.Id, Oraciones.EsRespuesta, Dialogos.pin "
        sqlstring = sqlstring & " FROM            Dialogos INNER JOIN"
        sqlstring = sqlstring & "                 Oraciones ON Dialogos.OracionId = Oraciones.Id INNER JOIN"
        sqlstring = sqlstring & "                Det_Conversation ON Dialogos.DetConversacion = Det_Conversation.Det_Con"
        sqlstring = sqlstring & param
        'Console.WriteLine(sqlstring)
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


        '''''''''
        ''Ordenar Lista desordenada
        'Dim trabajo As New List(Of String)
        'Dim gustos As New List(Of String)
        'Dim personal As New List(Of String)
        'Dim contacto As New List(Of String)
        'Dim ubicacion As New List(Of String)
        'Dim cierre As New List(Of String)
        'Dim otros As New List(Of String)


        'Dim preguntas As New List(Of String)
        'Dim respuestasCortas As New List(Of String)
        'Dim afirmaciones As New List(Of String)
        'Dim largas As New List(Of String)



        '  lvwFrases.Items.Clear()

        i = 1

        'For Each frase In resultado
        '    Dim itm As New ListViewItem(i.ToString())
        '    itm.SubItems.Add(frase)
        '    i += 1
        'Next

        Dim item As ListViewItem 'Creo el ListViewItem (item) 

        'Dim j As Integer
        n = dt.Rows.Count

        Do While i <= n - 1

            item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            item.UseItemStyleForSubItems = False


            item.SubItems.Add(dt.Rows(i).Item(0))
            If Not IsDBNull(dt.Rows(i).Item(4)) Then
                item.SubItems.Add(dt.Rows(i).Item(4))
            Else
                item.SubItems.Add("NULL")

            End If
            '  lvwFrases.Items.Add(item)

            'item.SubItems.Add(dt.Rows(i).Item(4))
            'item.SubItems.Add(dt.Rows(i).Item(9))
            'item.SubItems.Add("X")
            'item.SubItems.Add(dt.Rows(i).Item(6))
            'item.SubItems.Add(dt.Rows(i).Item(1))

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

            i = i + 1

            'item.SubItems(2).ForeColor = Color.Brown
            'item.SubItems(3).ForeColor = Color.Brown
        Loop



        '        End If

        ''item = LvwAssigned.Items.Add("icon", 0) ' 0 = my icon ID in ImageList
        'If dt.Rows(i).Item(11) = "S" Then
        '    item.ImageIndex = 1
        '    firstIndex = i
        'End If
        '' nuevoItem = item.Clone
        'Dim copiedItem As ListViewItem = item.Clone() ' new_item = DirectCast(item.Clone(), ListViewItem)
        '  ListProv.Items.Add(DirectCast(item.Clone, ListViewItem))
        'LvwAssigned.Items.Add(item)      'Agrego el item a la colección de listViewItem's de ListView1

        'Nuevoitem = New ListViewItem(j) 'Creo una nueva instancia de item pasandole el nombre como dato principal 
        'Nuevoitem.SubItems.Add(dt.Rows(i).Item(0))

        'ListProv.Items.Add(Nuevoitem)

        '    Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try


        'j = j + 1

        'Loop

        'LvwAssigned.View = View.Details ' Set the view to show details.
        'LvwAssigned.LabelEdit = False ' Allow the user to edit item text.
        'LvwAssigned.AllowColumnReorder = True ' Allow the user to rearrange columns.
        'LvwAssigned.FullRowSelect = True ' Select the item and subitems when selection is made.
        'LvwAssigned.GridLines = True ' Display grid lines.


    End Sub
    Public Sub CargarDatosRevisado(param)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer

        sqlstring = " SELECT        d.Det_Con, l.IdOracion, d.Orden, d.Con_Id, o.Traduccion, d.Det_Par, o.EsRespuesta, "
        sqlstring = sqlstring & " o.TextoPlano, l.Orden, l.Id, l.pin, l.personaje, d.coherencia"
        sqlstring = sqlstring & " FROM            Tbl_Dialogos l INNER JOIN"
        sqlstring = sqlstring & "                 Oraciones o ON l.IdOracion = o.Id INNER JOIN"
        sqlstring = sqlstring & "                Det_Conversation  d ON l.IdConversacion = d.Det_Con INNER JOIN"
        sqlstring = sqlstring & "                Enc_Conversation  e ON e.Con_Id = d.Con_Id"
        sqlstring = sqlstring & param

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try

        _comando.Connection.Close()


        ' 4. Cargar en ListView
        ' -----------------------------------------

        ' lvwRevisado.Items.Clear()

        Dim itm As New ListViewItem
        Dim j As Integer
        n = dt.Rows.Count

        Do While i <= n - 1

            itm = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            itm.UseItemStyleForSubItems = False


            If dt.Rows(i).Item(11) = "A" Then 'Personaje
                itm.ImageKey = "Femenino"   ' itm.ImageIndex = 2   ' Femenino
            Else
                itm.ImageKey = "Masculino" '    itm.ImageIndex = 3  ' Masculino
            End If


            itm.SubItems.Add(dt.Rows(i).Item(0)) ' d.Det_Con, 
            itm.SubItems.Add(dt.Rows(i).Item(7)) 'l.IdOracion, d.Orden, d.Con_Id, ,

            If Not IsDBNull(dt.Rows(i).Item(4)) Then 'o.Traduccion
                itm.SubItems.Add(dt.Rows(i).Item(4))
            Else
                itm.SubItems.Add("Sin traduccion")
                itm.SubItems(3).ForeColor = Color.LightGray
            End If

            itm.SubItems.Add(dt.Rows(i).Item(9)) ' o.Id
            itm.SubItems.Add("X")
            itm.SubItems.Add(dt.Rows(i).Item(6))
            itm.SubItems.Add(dt.Rows(i).Item(1))

            If Not IsDBNull(dt.Rows(i).Item(12)) Then
                itm.SubItems.Add(Math.Round((dt.Rows(i).Item(12) * 100), 0))

            End If

            'If dtOrdenado.Rows(i).Item(6) = "Q" Then
            '    itm.SubItems(2).ForeColor = Color.Blue
            '    itm.SubItems(3).ForeColor = Color.Blue
            'ElseIf dtOrdenado.Rows(i).Item(6) = "S" Then
            '    itm.SubItems(2).ForeColor = Color.Fuchsia
            '    itm.SubItems(3).ForeColor = Color.Fuchsia
            'ElseIf dtOrdenado.Rows(i).Item(6) = "C" Then
            '    itm.SubItems(2).ForeColor = Color.Black
            '    itm.SubItems(3).ForeColor = Color.Black
            'ElseIf dtOrdenado.Rows(i).Item(6) = "O" Then
            '    itm.SubItems(2).ForeColor = Color.BlueViolet
            '    itm.SubItems(3).ForeColor = Color.BlueViolet
            'ElseIf dtOrdenado.Rows(i).Item(6) = "E" Then
            '    itm.SubItems(2).ForeColor = Color.DarkGreen
            '    itm.SubItems(3).ForeColor = Color.DarkGreen
            'Else
            '    itm.SubItems(2).ForeColor = Color.Brown
            '    itm.SubItems(3).ForeColor = Color.Brown

            'End If

            ''item = LvwAssigned.Items.Add("icon", 0) ' 0 = my icon ID in ImageList
            'If dt.Rows(i).Item(10) = "S" Then
            '    'itm.ImageIndex = 1
            '    firstIndex = i
            'End If

            'lvwRevisado.Items.Add(itm)      'Agrego el item a la colección de listViewItem's de ListView1

            'Dim Nuevoitem As ListViewItem
            'Dim copiedItem As ListViewItem = itm.Clone() ' new_item = DirectCast(item.Clone(), ListViewItem)

            'ListProv.Items.Add(DirectCast(itm.Clone, ListViewItem))
            'LvwAssigned.Items.Add(itm)      'Agrego el item a la colección de listViewItem's de ListView1

            'Nuevoitem = New ListViewItem(j) 'Creo una nueva instancia de item pasandole el nombre como dato principal 
            'Nuevoitem.SubItems.Add(dt.Rows(i).Item(0))

            'ListProv.Items.Add(Nuevoitem)

            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try


            i = i + 1
            j = j + 1

        Loop





    End Sub
    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String


        Dim i As Integer
        Dim _insertado As Boolean = False
        Dim mostrarMensaje As Boolean = False
        Dim stringvalues As String = ""
        Dim sql As String = ""
        Dim IdMax As Integer
        Dim n As Integer

        Dim resp As Boolean
        Dim param As String = ""

        Dim band As Boolean
        Dim y As Integer ' Cantidad de Dialogos en Detalle

        'Dim dtDetalles As New DataTable
        ' Copiar columnas

        nuevoListView.Clear()

        ' Agregar columnas 0 y 1 correctamente
        nuevoListView.Columns.Add(LvwAssigned.Columns(0).Text, LvwAssigned.Columns(0).Width)
        nuevoListView.Columns.Add(LvwAssigned.Columns(1).Text, LvwAssigned.Columns(1).Width)

        ' Copiar columnas 0 y 1
        For Each lvItem As ListViewItem In LvwAssigned.Items
            'If lvItem.SubItems.Count > 1 Then

            Dim nuevoItem As New ListViewItem(lvItem.SubItems(0).Text)
            nuevoItem.SubItems.Add(lvItem.SubItems(1).Text)

            nuevoListView.Items.Add(nuevoItem)
            ' End If
        Next

        'nuevoListView.Items.Clear()

        '' Limpiar destino
        'nuevoListView.Columns.Clear()

        '' Agregar SOLO la columna 2 (índice 1)
        'nuevoListView.Columns.Add(LvwAssigned.Columns(1).Text, LvwAssigned.Columns(1).Width)

        '' Copiar únicamente esa columna
        'For Each item As ListViewItem In LvwAssigned.Items

        '    If item.SubItems.Count > 1 Then
        '        Dim nuevoItem As New ListViewItem(item.SubItems(1).Text)
        '        nuevoListView.Items.Add(nuevoItem)
        '    End If

        'Next

        'For Each col As ColumnHeader In LvwAssigned.Columns
        '    nuevoListView.Columns.Add(col.Text, col.Width)
        'Next

        '' Copiar items
        'For Each item In LvwAssigned.Items
        '    Dim nuevoItem As New ListViewItem(item.Text)
        '    ' Copiar subitems
        '    For k As Integer = 1 To item.SubItems.Count - 1
        '        nuevoItem.SubItems.Add(item.SubItems(k).Text)
        '    Next
        '    nuevoListView.Items.Add(nuevoItem)
        'Next

        '    imprimir(items)
        For Each item In nuevoListView.Items
            ' Console.WriteLine(item.SubItems(0).Text & "," & item.SubItems(1).Text & "," & item.SubItems(2).Text & "," & item.SubItems(3).Text & "Indice:" & item.Index)
            'Console.WriteLine(item.SubItems(0).Text & "," & item.SubItems(1).Text)
        Next

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        sqlstring = "  SELECT       L.Id, L.Orden, L.IdConversacion"
        sqlstring = sqlstring & " FROM            Enc_Conversation e INNER JOIN"
        sqlstring = sqlstring & " Det_Conversation d ON e.Con_Id = d.Con_Id INNER JOIN"

        If ModVar.Idioma = "EN" Then
            sqlstring = sqlstring & " Tbl_Dialogos L ON d.Det_Con = L.IdConversacion"
        Else
            sqlstring = sqlstring & " Tbl_Dialogos_FR L ON d.Det_Con = L.IdConversacion"

        End If
        sqlstring = sqlstring & " Where e.Con_Id = @Con_Id"
        sqlstring = sqlstring & " And L.item = '0' And d.Status='" & STATUS & "'"

        sqlstring = sqlstring & " ORDER BY d.orden ASC, L.Orden asc "
        _comando.CommandText = sqlstring

        _comando.Parameters.Clear()
        _comando.Parameters.AddWithValue("@Con_Id", Enc_Id)

        _comando.Connection.Open()
        Try
            da.SelectCommand = _comando
            da.Fill(dt)

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try



        Dim Indices As ListView
        Dim Orden As Integer
        Dim Indice As Integer

        ProgressBar1.Maximum = dt.Rows.Count
        'Console.WriteLine(LvwAssigned.Sorting)
        Dim j As Integer

        OrdenDialogo = 0

        For Each rw In dt.Rows

            ' LvwAssigned.Refresh()
            Console.WriteLine(rw.item(0))
            Console.WriteLine(rw.item(1))
            Console.WriteLine(rw.item(2))
            ' Console.WriteLine(rw.item(0))

            Indice = DetectChanges(rw.item(2))

            Console.WriteLine(rw.item(0) & "," & rw.item(2) & "," & "best Index:" & Indice)
            If lstEncontrados.Items.Count <> 0 Then
                For n = 0 To lstEncontrados.Items.Count - 1  'Actualiza Detalles
                    sqlstring = "UPDATE Det_Conversation SET Orden = @Orden"
                    sqlstring = sqlstring & " WHERE Det_Con = @Det_Con"
                    _comando.CommandText = sqlstring

                    _comando.Parameters.Clear()
                    _comando.Parameters.AddWithValue("@Orden", lstEncontrados.Items(n).SubItems(2).Text)
                    _comando.Parameters.AddWithValue("@Det_Con", rw.item(2))

                    Try
                        i = _comando.ExecuteNonQuery

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                Next
            End If

            'If lstEncontrados.Items.Count <> 0 Then

            '    For n = 0 To lstEncontrados.Items.Count - 1
            '        'Actualiza Detalles
            '        sqlstring = "UPDATE Tbl_Dialogos SET orden = @orden"
            '        sqlstring = sqlstring & " WHERE Id = @Id"
            '        _comando.CommandText = sqlstring

            '        _comando.Parameters.Clear()
            '        _comando.Parameters.AddWithValue("@Id", lstEncontrados.Items(n).SubItems(3).Text)
            '        _comando.Parameters.AddWithValue("@orden", lstEncontrados.Items(n).SubItems(4).Text)

            '        Try
            '            i = _comando.ExecuteNonQuery

            '        Catch ex As Exception
            '            MsgBox(ex.Message)
            '        End Try
            '    Next


            'End If

            ProgressBar1.Value += 1

        Next


        lblStatus.Text = "Actualizado: " & Now
        _comando.Connection.Close()

        Dim dtNueva As New DataTable
        Dim daNueva As New SqlDataAdapter

        'Actualiza Item


        Dim psi As New ProcessStartInfo()
        Dim p As Process '
        Dim resultado As String 'psi.FileName = "python"
        'psi.Arguments = """C:\legacy\Programas\Voz_Natural\items2.py"" " & Id
        'psi.UseShellExecute = False
        'psi.RedirectStandardOutput = True
        'psi.CreateNoWindow = True

        'Dim resultado As String = p.StandardOutput.ReadToEnd()
        '        'p.WaitForExit()

        'MessageBox.Show(resultado)

        'psi = New ProcessStartInfo()
        'psi.FileName = "python"
        'psi.Arguments = """C:\legacy\Programas\Voz_Natural\actualizar0.py"""
        'psi.UseShellExecute = False
        'psi.RedirectStandardOutput = True
        'psi.CreateNoWindow = True

        'p = Process.Start(psi)
        'resultado = p.StandardOutput.ReadToEnd()
        'p.WaitForExit()

        'psi = New ProcessStartInfo()
        'psi.FileName = "python"
        'psi.Arguments = """C:\legacy\Programas\Voz_Natural\ActualizarPersonaje.py"""
        'psi.UseShellExecute = False
        'psi.RedirectStandardOutput = True
        'psi.CreateNoWindow = True

        'p = Process.Start(psi)
        'resultado = p.StandardOutput.ReadToEnd()
        'p.WaitForExit()

        psi = New ProcessStartInfo()
        psi.FileName = "python"
        psi.Arguments = """C:\legacy\Programas\Voz_Natural\Actualiza\ActualizaItems.py"""
        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.CreateNoWindow = True

        p = Process.Start(psi)
        resultado = p.StandardOutput.ReadToEnd()
        p.WaitForExit()


        ' MessageBox.Show(resultado)

        'sqlstring = "  SELECT        Id, Orden, IdConversation"
        'sqlstring = sqlstring & " FROM Tbl_Dialogos"
        'sqlstring = sqlstring & " WHERE Id = @Id"
        'sqlstring = sqlstring & " ORDER BY Orden ASC"
        '_comando.CommandText = sqlstring

        '_comando.Parameters.Clear()
        '_comando.Parameters.AddWithValue("@Con_Id", Id)

        'Try
        '    da.SelectCommand = _comando

        '    da.Fill(dtNueva)
        'Catch ex As Exception
        'End Try

        'Dim j = 0
        '_comando.Connection.Open()



        'Actualizar Item de Dialogos
        'Dim dtDialogos As New DataTable
        '' Dim param As String

        'param = " Where dc.Con_Id='" & Id & "'"
        'param = param & " ORDER BY dc.Orden ASC, L.Item ASC"

        '' Dim da As New SqlDataAdapter
        'sqlstring = " SELECT        dc.Det_Con, L.IdOracion, dc.Orden, dc.Con_Id, o.Traduccion, dc.Det_Par, o.EsRespuesta, "
        'sqlstring = sqlstring & " o.TextoPlano, L.Orden, L.Id, o.EsRespuesta "
        'sqlstring = sqlstring & " FROM            Tbl_Dialogos L INNER JOIN"
        'sqlstring = sqlstring & "                 Oraciones o ON L.IdOracion = o.Id INNER JOIN"
        'sqlstring = sqlstring & "                Det_Conversation dc ON L.IdConversacion = dc.Det_Con"
        'sqlstring = sqlstring & param

        'Try
        '    _comando.CommandText = sqlstring
        '    ' _comando.Connection.Open()

        '    da.SelectCommand = _comando

        '    da.Fill(dtDialogos)

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally

        'End Try

        'For Each rw In dtDialogos.Rows
        '    Indice = DetectChanges(rw.item(9))
        '    'If lstEncontrados.Items.Count <> 0 Then


        param = " Where d.Con_Id='" & Enc_Id & "'"
        param = param & " and l.Item='0' and d.status='R'" ' & STATUS & "'"
        param = param & " ORDER BY  d.Orden ASC, L.orden ASC"

        CargarDatos(param)

        ' CargarDatosDetalles()

        lblStatus.Text = " Guardado " & Format(Now, "hh:mm tt")

        FILASELECT = -1
        ProgressBar1.Value = 0

    End Sub

    Private Function DetectChanges(Nombre) As Integer
        Dim item As ListViewItem 'Creo el ListViewItem (item) 
        Dim i As Integer
        Dim Indice As Integer = -1

        i = lstEncontrados.Items.Count + 1

        Dim foundItem As ListViewItem
        lstEncontrados.Items.Clear()

        If Nombre = 80018 Then
            MsgBox("")
        End If
        Try

            Do
                foundItem = nuevoListView.FindItemWithText(Nombre, True, 0, True)

                If (foundItem IsNot Nothing) Then

                    'Primero en la lista encontrados
                    ' If lstEncontrados.Items.Count = 0 Then
                    BestIndex = foundItem.Index
                    'End If

                    If foundItem.Index <= BestIndex Then
                        BestIndex = foundItem.Index
                    End If

                    item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 
                    item.SubItems.Add(Nombre)
                    item.SubItems.Add(BestIndex)
                    item.SubItems.Add(foundItem.SubItems(1).Text)
                    item.SubItems.Add(OrdenDialogo)

                    ' Console.WriteLine(foundItem.SubItems(4).Text)
                    lstEncontrados.Items.Add(item)

                    'LvwAssigned.Items(foundItem.Index).SubItems(4).Text = "X"
                    OrdenDialogo = OrdenDialogo + 1

                    foundItem.SubItems(1).Text = "0"

                    'nuevoListView.Items.Remove(foundItem)
                    ' nuevoListView.Items.RemoveAt(foundItem.Index)
                    'nuevoListView.Refresh()
                Else
                    'Indice = -1
                End If


            Loop While Not IsNothing(foundItem)


        Catch ex As Exception

        End Try


        Return BestIndex



    End Function

    Private Sub cmdSaveTransferir_Click(sender As System.Object, e As System.EventArgs) Handles cmdSaveTransferir.Click

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim IdPerson As Integer

        Dim IdConversation As Integer

        If txtDetalle.Text = "" Then Exit Sub

        IdConversation = txtDetalle.Text

        _comando.Connection.Open()

        Dim j As Integer

        For Each r In LvwUnAssigned.Items

            '' If r.SubItems(5).Text = "X" Then
            Console.WriteLine(r.index)
            Console.WriteLine(r.SubItems(1).Text)
            Console.WriteLine(r.SubItems(2).Text)
            Console.WriteLine(r.SubItems(3).Text)
            'Console.WriteLine(r.SubItems(4).Text)
            'Console.WriteLine(r.SubItems(5).Text)

            If ModVar.Idioma = "EN" Then
                sqlstring = "UPDATE Tbl_Dialogos SET IdConversacion = @IdConversacion, item = @item"
            Else
                sqlstring = "UPDATE Tbl_Dialogos_FR SET IdConversacion = @IdConversacion, item = @item"

            End If
            sqlstring = sqlstring & " WHERE Id = @Id"

            _comando.CommandText = sqlstring
            _comando.Parameters.Clear()

            _comando.Parameters.AddWithValue("@Id", r.SubItems(4).Text)
            _comando.Parameters.AddWithValue("@IdConversacion", IdConversation) 'Idet del Item seleccionado al hacer doble clic
            _comando.Parameters.AddWithValue("@item", j)

            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
            End Try
            j = j + 1
        Next

        _comando.Connection.Close()


        LvwUnAssigned.Items.Clear()

        'cmdSave_Click(sender, e)



        'For Each r In LvwUnassigned.Items

        '    'Console.WriteLine(r.index)
        '    Console.WriteLine(r.SubItems(0).Text)
        '    Console.WriteLine(r.SubItems(1).Text)
        '    Console.WriteLine(r.SubItems(2).Text)
        '    Console.WriteLine(r.SubItems(3).Text)
        '    Console.WriteLine(r.SubItems(4).Text)
        '    Console.WriteLine(r.SubItems(5).Text)
        '    'Console.WriteLine(r.SubItems(6).Text)

        '    If r.SubItems(5).Text = "X" Then

        '        sqlstring = "UPDATE Dialogos SET DetConversacion = @DetConversacion, Orden = @Orden"
        '        sqlstring = sqlstring & " WHERE Id = @Id"

        '        _comando.CommandText = sqlstring
        '        _comando.Parameters.Clear()

        '        _comando.Parameters.AddWithValue("@Id", r.SubItems(4).Text)
        '        _comando.Parameters.AddWithValue("@DetConversacion", IdConversation) 'Idet del Item seleccionado al hacer doble clic
        '        _comando.Parameters.AddWithValue("@Orden", r.index)


        '        Try

        '            i = _comando.ExecuteNonQuery



        '        Catch ex As Exception
        '            MsgBox(ex.Message)
        '        Finally

        '        End Try
        '    End If

        'Next

        If i > 0 Then
            'MsgBox("se guardo")

        Else
            'MsgBox("No se guardo")
        End If



    End Sub


#End Region

    Private Sub cmdNuevo_Click(sender As System.Object, e As System.EventArgs) Handles cmdNuevo.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sql As String


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

        txtDetalle.Text = IdEnc

    End Sub

    Private Sub cboConversation_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboConversation.SelectedIndexChanged

        txtDetalle.Text = cboConversation.Items(cboConversation.SelectedIndex).ItemData()

    End Sub

    Private Sub cmdTransferir_Click(sender As System.Object, e As System.EventArgs) Handles cmdTransferir.Click

        Dim IdEnc As Integer

        If cboTipoC.SelectedIndex = -1 Then Exit Sub
        _idEnc = cboTipoC.Items(cboTipoC.SelectedIndex).ItemData()

        MoverDetalleTodo(_idEnc, cboTipoC.Text)


    End Sub

#Region "LvwUnAssigned"

    Private Sub LvwunAssigned_ItemDrag(sender As Object, e As System.Windows.Forms.ItemDragEventArgs) Handles LvwUnAssigned.ItemDrag
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

    Private Sub LvwunAssigned_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles LvwUnAssigned.DragDrop

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

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        _comando.Connection.Open()

        '  Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        '  Dim dt As New DataTable
        '  Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim IdPerson As Integer

        Dim IdConversation As Integer
        If txtDetalle.Text = "" Then Exit Sub

        IdConversation = txtDetalle.Text

        For Each r In LvwUnAssigned.Items

            '' If r.SubItems(5).Text = "X" Then
            'Console.WriteLine(r.SubItems(0).Text)
            'Console.WriteLine(r.SubItems(1).Text)
            'Console.WriteLine(r.SubItems(2).Text)
            'Console.WriteLine(r.SubItems(3).Text)
            'Console.WriteLine(r.SubItems(4).Text)
            'Console.WriteLine(r.SubItems(5).Text)

            sqlstring = "UPDATE Tbl_Dialogos SET IdConversacion = @IdConversacion, item = @item"
            sqlstring = sqlstring & " WHERE Id = @Id"

            _comando.CommandText = sqlstring
            _comando.Parameters.Clear()

            _comando.Parameters.AddWithValue("@Id", r.SubItems(4).Text)
            _comando.Parameters.AddWithValue("@IdConversacion", IdConversation) 'Idet del Item seleccionado al hacer doble clic
            _comando.Parameters.AddWithValue("@item", r.index)

            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
            End Try

        Next

        sqlstring = "UPDATE det_conversation SET status = 'R'"
        sqlstring = sqlstring & " WHERE Det_con = @Det_con"

        _comando.CommandText = sqlstring
        _comando.Parameters.Clear()

        _comando.Parameters.AddWithValue("@Det_con", IdConversation)

        Try
            i = _comando.ExecuteNonQuery

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try

        _comando.Connection.Close()


    End Sub

#End Region

#Region "LvwAssigned"
    Private Sub LvwAssigned_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles LvwAssigned.KeyUp
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim Sel As Integer

        If LvwAssigned.SelectedItems.Count = 0 Then Exit Sub

        If e.KeyCode = Keys.Enter Then

            '    'LvwAssigned.Items.Insert(0, itemSel)
            'ElseIf e.KeyCode = 68 Then

            '    Dim itemNew As ListViewItem = Nothing
            '    Dim itemRem As ListViewItem = Nothing
            '    itemNew = LvwAssigned.SelectedItems.Item(0)
            '    'FILASELECT = ListViewEx1.SelectedItems.Item(0).Index
            '    'ListViewEx1.Items(FILASELECT).Selected = True
            '    LvwAssigned.Items.Remove(itemNew)
            '    ' LvwAssigned.Items.Insert(0, itemNew)
            '    LvwAssigned.Items.Add(itemNew)
        ElseIf e.KeyCode = Keys.E Then
            Dim frm As New FrmDetOracion

            AddOwnedForm(frm)
            Dim IdOracion As Integer
            FILASELECT = LvwAssigned.SelectedItems.Item(0).Index

            IdOracion = LvwAssigned.SelectedItems.Item(0).SubItems(7).Text

            frm.IdOracion = IdOracion

            frm.CargarDatos(IdOracion)

            frm.ShowDialog()

            Try
                LvwAssigned.Items(FILASELECT).Selected = True
                LvwAssigned.EnsureVisible(FILASELECT)
                LvwAssigned.Focus()
            Catch ex As Exception

            End Try

        ElseIf e.KeyCode = Keys.X Then 'Status=Eliminar

            Dim sqlstring As String
            Dim IdOracion As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim resp As Boolean
            Dim sql As String
            Dim IdDet As Integer
            Dim j As Integer = 1
            Dim IdDialogo As Integer

            Dim itemSel As ListViewItem = Nothing

            If LvwAssigned.SelectedItems.Count = 0 Then Exit Sub

            itemSel = LvwAssigned.SelectedItems.Item(0)
            Sel = itemSel.Index

            ULTIMASELECCIONADA = Sel

            IdDet = itemSel.SubItems(1).Text
            IdOracion = itemSel.SubItems(7).Text

            _comando.Connection.Open()

            _comando.Parameters.Clear()

            'sqlstring = "Update Oraciones SET Status='X'"
            'sqlstring = sqlstring & "  WHERE Id = '" & IdOracion & "'"
            ' _comando.CommandText = sqlstring

            sqlstring = "Update Det_Conversation SET Status='X'"
            sqlstring = sqlstring & "  WHERE Det_Con = '" & IdDet & "'"
            _comando.CommandText = sqlstring

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            LvwAssigned.Items.Remove(itemSel)

            Try
                LvwAssigned.Items(Sel).Selected = True
            Catch ex As Exception
            End Try
            txtCant.Text = LvwAssigned.Items.Count


        ElseIf e.KeyCode = Keys.V Then

            Dim itemNew As ListViewItem = Nothing
            Dim itemRem As ListViewItem = Nothing
            Dim itemSel As ListViewItem = Nothing

            itemSel = LvwAssigned.SelectedItems.Item(0)
            ULTIMASELECCIONADA = itemSel.Index

            LvwAssigned.Sorting = Windows.Forms.SortOrder.None
            LvwAssigned.ListViewItemSorter = Nothing

            LvwAssigned.BeginUpdate()

            LvwAssigned.Items.Remove(itemSel)
            Try
                itemSel.SubItems(3).BackColor = Color.LightGreen
                itemSel.SubItems(3).ForeColor = Color.Black

                LvwAssigned.Items.Insert(FILASELECT + 1, itemSel)

            Catch ex As Exception

            End Try

            LvwAssigned.EndUpdate()

            Try
            Catch ex As Exception
            End Try

            FILASELECT = FILASELECT + 1

            Try
                LvwAssigned.Items(ULTIMASELECCIONADA + 1).Selected = True
            Catch ex As Exception
            End Try

        ElseIf e.KeyCode = Keys.P Then
            'MessageBox.Show(LvwAssigned.SelectedItems.Item(0).SubItems(3).Text)
            Dim sqlstring As String
            Dim IdOracion As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim resp As Boolean
            Dim sql As String
            Dim IdDetNuevo As Integer
            Dim j As Integer = 1
            Dim IdDialogo As Integer

            Dim itemSel As ListViewItem = Nothing

            itemSel = LvwAssigned.SelectedItems.Item(0)
            ' itemSel.ImageIndex = 1

            IdDialogo = itemSel.SubItems(4).Text

            _comando.Connection.Open()

            _comando.Parameters.Clear()

            If ModVar.Idioma = "EN" Then
                sqlstring = "Update Tbl_Dialogos SET pin='S'"
            Else
                sqlstring = "Update Tbl_Dialogos_FR SET pin='S'"
            End If

            sqlstring = sqlstring & "  WHERE Id = '" & IdDialogo & "'"
            _comando.CommandText = sqlstring

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            'If itemSel.Index > firstIndex Then
            FILASELECT = itemSel.Index
            'End If
            'itemSel.SubItems(2).ForeColor = Color.Brown
            'itemSel.SubItems(3).ForeColor = Color.Brown
            itemSel.SubItems(3).BackColor = Color.LightGray

        ElseIf e.KeyCode = Keys.A Then
            Dim sqlstring As String
            Dim IdOracion As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim resp As Boolean
            Dim sql As String
            Dim IdDet As Integer
            Dim j As Integer = 1
            Dim IdDialogo As Integer
            Dim itemSel As ListViewItem = Nothing

            If LvwAssigned.SelectedItems.Count = 0 Then Exit Sub

            itemSel = LvwAssigned.SelectedItems.Item(0)
            Sel = itemSel.Index

            IdDet = itemSel.SubItems(1).Text

            _comando.Connection.Open()

            _comando.Parameters.Clear()

            sqlstring = "Update Det_Conversation SET Status='A'"
            sqlstring = sqlstring & "  WHERE Det_Con = '" & IdDet & "'"
            _comando.CommandText = sqlstring

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            LvwAssigned.Items.Remove(itemSel)
            Try
                LvwAssigned.Items(Sel).Selected = True
            Catch ex As Exception
            End Try
        ElseIf e.KeyCode = Keys.D Then

            Dim sqlstring As String
            Dim IdOracion As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim resp As Boolean
            Dim sql As String
            Dim IdDet As Integer
            Dim j As Integer = 1
            Dim IdDialogo As Integer
            Dim itemSel As ListViewItem = Nothing

            If LvwAssigned.SelectedItems.Count = 0 Then Exit Sub

            itemSel = LvwAssigned.SelectedItems.Item(0)
            Sel = itemSel.Index

            ULTIMASELECCIONADA = Sel

            'FILASELECT = itemSel.Index

            IdDet = itemSel.SubItems(1).Text

            '_comando.Connection.Open()

            '_comando.Parameters.Clear()

            'sqlstring = "Update Det_Conversation SET Status='R'"
            'sqlstring = sqlstring & "  WHERE Det_Con = '" & IdDet & "'"
            '_comando.CommandText = sqlstring

            'Try
            '    i = _comando.ExecuteNonQuery
            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try

            LvwAssigned.Items.Remove(itemSel)
            LvwAssigned.BeginUpdate()
            LvwAssigned.Items.Remove(itemSel)

            Try
                LvwAssigned.Items.Insert(LvwAssigned.Items.Count, itemSel)

            Catch ex As Exception
            End Try

            LvwAssigned.EndUpdate()

            LvwAssigned.Items(Sel).Selected = True


        ElseIf e.KeyCode = Keys.R Then  'REVISADO 
            Dim sqlstring As String
            Dim IdOracion As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim resp As Boolean
            Dim sql As String
            Dim IdDet As Integer
            Dim j As Integer = 1
            Dim IdDialogo As Integer
            Dim itemSel As ListViewItem = Nothing

            If LvwAssigned.SelectedItems.Count = 0 Then Exit Sub

            itemSel = LvwAssigned.SelectedItems.Item(0)
            Sel = itemSel.Index
            IdOracion = itemSel.SubItems(7).Text

            IdDet = itemSel.SubItems(1).Text

            _comando.Connection.Open()

            _comando.Parameters.Clear()

            'sqlstring = "Update Oraciones SET Status='R', orden ='0'"
            'sqlstring = sqlstring & "  WHERE Id = '" & IdOracion & "'"

            sqlstring = "Update Det_Conversation SET Status='R', orden ='0'"
            sqlstring = sqlstring & "  WHERE Det_Con = '" & IdDet & "'"
            _comando.CommandText = sqlstring

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            LvwAssigned.Items.Remove(itemSel)
            Try
                LvwAssigned.Items(Sel).Selected = True
            Catch ex As Exception
            End Try
            txtCant.Text = LvwAssigned.Items.Count

        ElseIf e.KeyCode = Keys.N Then

            Dim sqlstring As String
            Dim IdOracion As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim resp As Boolean
            Dim sql As String
            Dim IdDet As Integer
            Dim j As Integer = 1
            Dim IdDialogo As Integer

            Dim itemSel As ListViewItem = Nothing

            If LvwAssigned.SelectedItems.Count = 0 Then Exit Sub

            itemSel = LvwAssigned.SelectedItems.Item(0)
            Sel = itemSel.Index

            IdOracion = itemSel.SubItems(7).Text

            IdDet = itemSel.SubItems(1).Text

            _comando.Connection.Open()

            _comando.Parameters.Clear()
            'sqlstring = "Update Oraciones SET Status='N'"
            'sqlstring = sqlstring & "  WHERE Id = '" & IdOracion & "'"
            sqlstring = "Update Det_Conversation SET Status='N'"
            sqlstring = sqlstring & "  WHERE Det_Con = '" & IdDet & "'"
            _comando.CommandText = sqlstring

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            LvwAssigned.Items.Remove(itemSel)
            txtCant.Text = LvwAssigned.Items.Count
            Try
                LvwAssigned.Items(Sel).Selected = True

            Catch ex As Exception

            End Try

        ElseIf e.KeyCode = Keys.Q Then 'Eliminar de Oraciones
            Dim itemSel As ListViewItem = Nothing
            Dim i As Integer
            Dim param As String
            Dim IdDialogo As String
            Dim IdOracion As String


            itemSel = LvwAssigned.SelectedItems.Item(0)

            Sel = itemSel.Index

            IdDialogo = itemSel.SubItems(4).Text
            IdOracion = itemSel.SubItems(7).Text

            Dim sqlstring As String

            '    'Actualiza conexto
            '    Dim _titulo As String = "Nulo"

            sqlstring = ""

            If ModVar.Idioma = "EN" Then
                sqlstring &= "UPDATE Oraciones SET tema = NULL"
            Else
                sqlstring &= "UPDATE Oraciones_FR SET tema = NULL"
            End If

            sqlstring &= " FROM Oraciones"
            sqlstring &= " WHERE Id = @IdOracion"

            _comando.CommandText = sqlstring
            _comando.Parameters.Clear()
            _comando.Parameters.AddWithValue("@IdOracion", IdOracion)
            _comando.Connection.Open()

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
            End Try

            If ModVar.Idioma = "EN" Then
                sqlstring = "Delete FROM Tbl_Dialogos"
            Else
                sqlstring = "Delete FROM Tbl_Dialogos_FR"
            End If

            sqlstring = sqlstring & " WHERE Id = @Id"

            _comando.CommandText = sqlstring

            _comando.Parameters.Clear()
            _comando.Parameters.AddWithValue("@Id", IdDialogo)

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
            End Try
             
            _comando.Connection.Close()

            Dim itemNew As ListViewItem = Nothing
            itemNew = LvwAssigned.SelectedItems.Item(0)
            LvwAssigned.BeginUpdate()
            LvwAssigned.Items.Remove(itemNew)
            LvwAssigned.EndUpdate()

            Try
                LvwAssigned.Items(Sel).Selected = True

            Catch ex As Exception

            End Try

            'quitar beep
            e.SuppressKeyPress = True
            e.Handled = True

            txtCant.Text = LvwAssigned.Items.Count


        ElseIf e.KeyCode = Keys.I Then

            'Dim itemNew As ListViewItem = Nothing
            'Dim itemRem As ListViewItem = Nothing
            'itemNew = LvwAssigned.SelectedItems.Item(0)
            ''FILASELECT = ListViewEx1.SelectedItems.Item(0).Index
            ''ListViewEx1.Items(FILASELECT).Selected = True
            '' LvwAssigned.Items.Insert(0, itemNew)

            'LvwAssigned.Sorting = Windows.Forms.SortOrder.None
            'LvwAssigned.ListViewItemSorter = Nothing

            'LvwAssigned.BeginUpdate()

            'LvwAssigned.Items.Remove(itemNew)
            'LvwAssigned.Items.Insert(0, itemNew)

            'LvwAssigned.EndUpdate()
        ElseIf e.KeyCode = Keys.C Then

            Dim sqlstring As String
            Dim IdOracion As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim resp As Boolean
            Dim sql As String
            Dim IdDet As Integer
            Dim j As Integer = 1
            Dim IdDialogo As Integer

            Dim itemSel As ListViewItem = Nothing


            itemSel = LvwAssigned.SelectedItems.Item(0)
            IdOracion = itemSel.SubItems(7).Text

            _comando.Connection.Open()

            _comando.Parameters.Clear()

            If ModVar.Idioma = "EN" Then
                sqlstring = "Update Oraciones SET Traduccion=''"
            Else
                sqlstring = "Update Oraciones_FR SET Traduccion=''"

            End If

            sqlstring = sqlstring & "  WHERE Id = '" & IdOracion & "'"
            _comando.CommandText = sqlstring

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            _comando.Connection.Close()

            'LvwAssigned.Items.Remove(itemSel)
            'LvwAssigned.BeginUpdate()
            itemSel.SubItems(3).Text = ""
            '  LvwAssigned.Refresh()
            'LvwAssigned.EndUpdate()

            'LvwAssigned.RedrawItems(itemSel.Index, itemSel.Index, False)
        ElseIf e.KeyCode = Keys.T Then

            Dim sqlstring As String
            Dim IdOracion As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim resp As Boolean
            Dim sql As String
            Dim IdDet As Integer
            Dim j As Integer = 1
            Dim IdDialogo As Integer

            Dim itemSel As ListViewItem = Nothing

            Dim tipo As String

            tipo = InputBox("Ingrese tipo E: Interjeccion, S:Simple, C:Compuesta", "Tipo")

            If Trim(tipo) <> "" Then
                itemSel = LvwAssigned.SelectedItems.Item(0)
                IdOracion = itemSel.SubItems(7).Text

                _comando.Connection.Open()

                _comando.Parameters.Clear()

                If ModVar.Idioma = "EN" Then
                    sqlstring = "Update Oraciones SET TipoLongitud=''"
                Else
                    sqlstring = "Update Oraciones_FR SET TipoLongitud=''"
                End If

                sqlstring = sqlstring & "  WHERE Id = '" & IdOracion & "'"
                _comando.CommandText = sqlstring

                Try
                    i = _comando.ExecuteNonQuery
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                _comando.Connection.Close()

                lblStatus.Text = "Actualizado:  " & itemSel.SubItems(2).Text & "  Tipo:  " & tipo
            End If
        ElseIf e.KeyCode = Keys.Delete Then
            Dim itemSel As ListViewItem = Nothing
            Dim i As Integer
            Dim param As String
            Dim IdDialogo As String
            Dim IdOracion As String


            itemSel = LvwAssigned.SelectedItems.Item(0)

            Sel = itemSel.Index

            IdDialogo = itemSel.SubItems(4).Text
            IdOracion = itemSel.SubItems(7).Text

            Dim sqlstring As String

            '    'Actualiza conexto
            '    Dim _titulo As String = "Nulo"

            '    sqlstring = ""
            '    sqlstring &= "UPDATE o SET o.Contexto = @Titulo "
            '    sqlstring &= "FROM Oraciones o "
            '    sqlstring &= "INNER JOIN Tbl_dialogos d ON d.IdOracion = o.Id "
            '    sqlstring &= "WHERE d.Id = @IdDialogo"

            '    _comando.CommandText = sqlstring
            '    _comando.Parameters.Clear()
            '    _comando.Parameters.AddWithValue("@IdDialogo", IdDialogo)
            '    _comando.Parameters.AddWithValue("@Titulo", "")

            _comando.Connection.Open()

            If ModVar.Idioma = "EN" Then
                sqlstring = "Delete FROM Tbl_Dialogos"
            Else
                sqlstring = "Delete FROM Tbl_Dialogos_FR"
            End If

            sqlstring = sqlstring & " WHERE Id = @Id"
            _comando.CommandText = sqlstring

            _comando.Parameters.Clear()
            _comando.Parameters.AddWithValue("@Id", IdDialogo)

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            If ModVar.Idioma = "EN" Then
                sqlstring = "Delete FROM Oraciones"
            Else
                sqlstring = "Delete FROM Oraciones_FR"
            End If

            sqlstring = sqlstring & " WHERE Id = @Id"
            _comando.CommandText = sqlstring

            _comando.Parameters.Clear()
            _comando.Parameters.AddWithValue("@Id", IdOracion)

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            _comando.Connection.Close()

            Dim itemNew As ListViewItem = Nothing
            itemNew = LvwAssigned.SelectedItems.Item(0)
            LvwAssigned.BeginUpdate()
            LvwAssigned.Items.Remove(itemNew)
            LvwAssigned.EndUpdate()

            Try
                LvwAssigned.Items(Sel).Selected = True

            Catch ex As Exception

            End Try

            'quitar beep
            e.SuppressKeyPress = True
            e.Handled = True

            txtCant.Text = LvwAssigned.Items.Count

        ElseIf e.KeyCode = Keys.M Then

            Dim IdDet As Integer
            Dim param As String
            Dim itemSel As ListViewItem

            Try
                IdDet = LvwAssigned.SelectedItems.Item(0).SubItems(1).Text
                txtDetalle.Text = IdDet
                itemSel = LvwAssigned.SelectedItems.Item(0)
                Sel = itemSel.Index

            Catch ex As Exception
                Exit Sub
            End Try

            Dim new_item As ListViewItem = DirectCast(itemSel.Clone(), ListViewItem)

            LvwAssigned.Items.Remove(itemSel)

            param = " Where c.Det_Con='" & IdDet & "'"
            param = param & " ORDER BY d.item ASC"


            Dim sqlstring As String

            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i, n As Integer

            sqlstring = "    SELECT        d.Id, o.TextoPlano, d.IdOracion, d.Orden, d.IdConversacion, d.IMG, o.Traduccion, o.EsRespuesta"

            If ModVar.Idioma = "EN" Then
                sqlstring = sqlstring & "  FROM            Tbl_Dialogos d INNER JOIN"
            Else
                sqlstring = sqlstring & "  FROM            Tbl_Dialogos_FR d INNER JOIN"
            End If

            sqlstring = sqlstring & "                   Det_Conversation c ON d.IdConversacion = c.Det_Con INNER JOIN"
            sqlstring = sqlstring & "                 Oraciones o ON d.IdOracion = o.Id"
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

            If COPIA = True Then
                'LvwUnassigned.Items.Clear()
            Else
                LvwUnAssigned.Items.Clear()
            End If

            i = 0
            n = dt.Rows.Count
            If n = 0 Then Exit Sub

            ' LvwAssigned.Items.Remove(itemSel)
            itemSel.SubItems(3).ForeColor = Color.Cyan
            itemSel.SubItems(4).ForeColor = Color.Cyan
            itemSel.SubItems(5).ForeColor = Color.Cyan
            itemSel.SubItems(6).ForeColor = Color.Cyan
            itemSel.SubItems(7).ForeColor = Color.Cyan
            itemSel.SubItems(8).ForeColor = Color.Cyan

            Do While i <= n - 1


                Dim item As ListViewItem 'Creo el ListViewItem (item) 
                item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 
                item.UseItemStyleForSubItems = False

                Try

                    'Dialogo
                    item.SubItems.Add(dt.Rows(i).Item(4))
                    item.SubItems.Add(dt.Rows(i).Item(1))
                    If Not IsDBNull(dt.Rows(i).Item(6)) Then
                        item.SubItems.Add(dt.Rows(i).Item(6))
                    Else
                        item.SubItems.Add("Sin traduccion")
                    End If
                    item.SubItems.Add(dt.Rows(i).Item(0))
                    item.SubItems.Add("0")

                    'If dt.Rows(i).Item(7) = "Q" Then
                    '    item.SubItems(2).ForeColor = Color.Cyan
                    '    item.SubItems(3).ForeColor = Color.Cyan
                    'ElseIf dt.Rows(i).Item(7) = "S" Then
                    '    item.SubItems(2).ForeColor = Color.Fuchsia
                    '    item.SubItems(3).ForeColor = Color.Fuchsia
                    'ElseIf dt.Rows(i).Item(7) = "C" Then
                    '    item.SubItems(2).ForeColor = Color.Chartreuse
                    '    item.SubItems(3).ForeColor = Color.Chartreuse
                    'ElseIf dt.Rows(i).Item(7) = "O" Then
                    '    item.SubItems(2).ForeColor = Color.LightBlue
                    '    item.SubItems(3).ForeColor = Color.LightBlue
                    'ElseIf dt.Rows(i).Item(7) = "E" Then
                    '    item.SubItems(2).ForeColor = Color.Chartreuse
                    '    item.SubItems(3).ForeColor = Color.Chartreuse
                    'Else
                    '    item.SubItems(2).ForeColor = Color.LightCoral
                    '    item.SubItems(3).ForeColor = Color.LightCoral

                    'End If

                    LvwUnAssigned.Items.Add(item)      'Agrego el item a la colección de listViewItem's de ListView1


                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try


                i = i + 1

            Loop

            Try
                LvwAssigned.Items(Sel).Selected = True
            Catch ex As Exception
            End Try
            txtCant.Text = LvwAssigned.Items.Count

        ElseIf e.KeyCode = Keys.S Then

            Dim sqlstring As String
            Dim IdOracion As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim resp As Boolean
            Dim sql As String
            Dim IdDet As Integer
            Dim j As Integer = 1
            Dim IdDialogo As Integer

            Dim itemSel As ListViewItem = Nothing

            If LvwAssigned.SelectedItems.Count = 0 Then Exit Sub

            itemSel = LvwAssigned.SelectedItems.Item(0)
            Sel = itemSel.Index

            IdOracion = itemSel.SubItems(7).Text

            IdDet = itemSel.SubItems(1).Text

            _comando.Connection.Open()
            _comando.Parameters.Clear()

            If ModVar.Idioma = "EN" Then
                sqlstring = "Update Oraciones SET Sel=1"
            Else
                sqlstring = "Update Oraciones_FR SET Sel=1"
            End If

            sqlstring = sqlstring & "  WHERE Id = '" & IdOracion & "'"
            _comando.CommandText = sqlstring

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            LvwAssigned.BeginUpdate()
            Try
                itemSel.SubItems(3).BackColor = Color.LightSalmon
                itemSel.SubItems(3).ForeColor = Color.Black
            Catch ex As Exception
            End Try
            LvwAssigned.EndUpdate()

            Try
                LvwAssigned.Items(Sel).Selected = True
            Catch ex As Exception
            End Try

            txtCant.Text = LvwAssigned.Items.Count

        ElseIf e.KeyCode = Keys.O Then

            Dim itemSel As ListViewItem = Nothing
            Dim i As Integer
            Dim param As String
            Dim IdDialogo As String
            Dim IdOracion As String


            itemSel = LvwAssigned.SelectedItems.Item(0)

            Sel = itemSel.Index

            IdDialogo = itemSel.SubItems(4).Text
            IdOracion = itemSel.SubItems(7).Text

            Dim sqlstring As String
            sqlstring = ""

            If ModVar.Idioma = "EN" Then
                sqlstring &= "UPDATE Oraciones SET Tipo = @Tipo"
            Else
                sqlstring &= "UPDATE Oraciones_FR SET Tipo = @Tipo"
            End If

            sqlstring &= " FROM Oraciones"
            sqlstring &= " WHERE Id = @IdOracion"

            _comando.CommandText = sqlstring
            _comando.Parameters.Clear()
            _comando.Parameters.AddWithValue("@IdOracion", IdOracion)
            _comando.Parameters.AddWithValue("@Tipo", Tipo)
            _comando.Connection.Open()

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            _comando.Connection.Close()


            If Tipo = "Q" Then
                itemSel.SubItems(2).ForeColor = Color.LightBlue
                itemSel.SubItems(3).ForeColor = Color.LightBlue
            ElseIf Tipo = "S" Then
                itemSel.SubItems(2).ForeColor = Color.LightGreen
                itemSel.SubItems(3).ForeColor = Color.LightGreen
            ElseIf Tipo = "C" Then
                itemSel.SubItems(2).ForeColor = Color.Gainsboro
                itemSel.SubItems(3).ForeColor = Color.Gainsboro
            ElseIf Tipo = "O" Then
                itemSel.SubItems(2).ForeColor = Color.Yellow
                itemSel.SubItems(3).ForeColor = Color.Yellow
            ElseIf Tipo = "E" Then
                itemSel.SubItems(2).ForeColor = Color.Fuchsia
                itemSel.SubItems(3).ForeColor = Color.Fuchsia
            ElseIf Tipo = "R" Then
                itemSel.SubItems(2).ForeColor = Color.LightSalmon
                itemSel.SubItems(3).ForeColor = Color.LightSalmon
            End If

        End If


    End Sub

    Private Sub LvwAssigned_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles LvwAssigned.MouseClick

        'FILASELECT = LvwAssigned.SelectedItems.Item(0).Index
        Dim texto As String

        'If Not IsDBNull(LvwAssigned.SelectedItems.Item(0).SubItems(10).Text) Then
        '    texto = LvwAssigned.SelectedItems.Item(0).SubItems(10).Text
        '    txtRespuesta.Text = texto
        'End If


        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim itemNew As ListViewItem = Nothing
            Dim itemRem As ListViewItem = Nothing
            itemNew = LvwAssigned.SelectedItems.Item(0)
            'FILASELECT = ListViewEx1.SelectedItems.Item(0).Index
            'ListViewEx1.Items(FILASELECT).Selected = True
            LvwAssigned.Items.Remove(itemNew)
            LvwAssigned.Items.Insert(LvwAssigned.Items.Count, itemNew)

        Else
        End If


    End Sub

    Private Sub LvwAssigned_MouseDoubleClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles LvwAssigned.MouseDoubleClick
        Dim IdDet As Integer
        Dim param As String
        Dim itemSel As ListViewItem
        'param = " Where Det_Conversation.Con_Id='" & Id & "'"
        Try
            IdDet = LvwAssigned.SelectedItems.Item(0).SubItems(1).Text
            txtDetalle.Text = IdDet
            itemSel = LvwAssigned.SelectedItems.Item(0)

        Catch ex As Exception
            Exit Sub
        End Try

        Dim new_item As ListViewItem = DirectCast(itemSel.Clone(), ListViewItem)

        If LvwAssigned Is Nothing Then
            'LvwAssigned.Items.Add(new_item)
        Else
            ' LvwAssigned.Items.Insert(index, new_item)
        End If
        LvwAssigned.Items.Remove(itemSel)


        param = " Where c.Det_Con='" & IdDet & "'"
        param = param & " ORDER BY d.item ASC"

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer

        sqlstring = "    SELECT        d.Id, o.TextoPlano, d.IdOracion, d.Orden, d.IdConversacion, d.IMG, o.Traduccion, o.EsRespuesta"

        If ModVar.Idioma = "EN" Then
            sqlstring = sqlstring & "  FROM            Tbl_Dialogos d INNER JOIN"
            sqlstring = sqlstring & "                   Det_Conversation c ON d.IdConversacion = c.Det_Con INNER JOIN"
            sqlstring = sqlstring & "                 Oraciones o ON d.IdOracion = o.Id"
        Else
            sqlstring = sqlstring & "  FROM            Tbl_Dialogos_FR d INNER JOIN"
            sqlstring = sqlstring & "                   Det_Conversation c ON d.IdConversacion = c.Det_Con INNER JOIN"
            sqlstring = sqlstring & "                 Oraciones_FR o ON d.IdOracion = o.Id"

        End If
      
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

        If COPIA = True Then
            'LvwUnassigned.Items.Clear()
        Else
            LvwUnAssigned.Items.Clear()
        End If

        i = 0
        n = dt.Rows.Count
        If n = 0 Then Exit Sub

        ' LvwAssigned.Items.Remove(itemSel)
        itemSel.SubItems(3).ForeColor = Color.Cyan
        itemSel.SubItems(4).ForeColor = Color.Cyan
        itemSel.SubItems(5).ForeColor = Color.Cyan
        itemSel.SubItems(6).ForeColor = Color.Cyan
        itemSel.SubItems(7).ForeColor = Color.Cyan
        itemSel.SubItems(8).ForeColor = Color.Cyan

        Do While i <= n - 1


            Dim item As ListViewItem 'Creo el ListViewItem (item) 
            item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 
            item.UseItemStyleForSubItems = False

            Try

                'Dialogo
                item.SubItems.Add(dt.Rows(i).Item(4))
                item.SubItems.Add(dt.Rows(i).Item(1))
                If Not IsDBNull(dt.Rows(i).Item(6)) Then
                    item.SubItems.Add(dt.Rows(i).Item(6))
                Else
                    item.SubItems.Add("Sin traduccion")
                End If
                item.SubItems.Add(dt.Rows(i).Item(0))
                item.SubItems.Add("0")
                item.SubItems.Add(dt.Rows(i).Item(7))

                If dt.Rows(i).Item(7) = "Q" Then
                    item.SubItems(2).ForeColor = Color.Cyan
                    item.SubItems(3).ForeColor = Color.Cyan
                ElseIf dt.Rows(i).Item(7) = "S" Then
                    item.SubItems(2).ForeColor = Color.Fuchsia
                    item.SubItems(3).ForeColor = Color.Fuchsia
                ElseIf dt.Rows(i).Item(7) = "C" Then
                    item.SubItems(2).ForeColor = Color.Chartreuse
                    item.SubItems(3).ForeColor = Color.Chartreuse
                ElseIf dt.Rows(i).Item(7) = "O" Then
                    item.SubItems(2).ForeColor = Color.LightBlue
                    item.SubItems(3).ForeColor = Color.LightBlue
                ElseIf dt.Rows(i).Item(7) = "E" Then
                    item.SubItems(2).ForeColor = Color.Chartreuse
                    item.SubItems(3).ForeColor = Color.Chartreuse
                Else
                    item.SubItems(2).ForeColor = Color.LightCoral
                    item.SubItems(3).ForeColor = Color.LightCoral

                End If

                LvwUnAssigned.Items.Add(item)      'Agrego el item a la colección de listViewItem's de ListView1



            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


            i = i + 1

        Loop

        ' LvwAssigned.Items.Remove(itemnew)

        'Dim itemNew As ListViewItem = Nothing
        'Dim itemRem As ListViewItem = Nothing
        'itemNew = LvwAssigned.SelectedItems.Item(0)
        ''FILASELECT = ListViewEx1.SelectedItems.Item(0).Index
        ''ListViewEx1.Items(FILASELECT).Selected = True
        'LvwAssigned.Items.Insert(LvwAssigned.Items.Count, itemNew)


    End Sub

    Private Sub LvwAssigned_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles LvwAssigned.SelectedIndexChanged

        Try
            'FILASELECT = LvwAssigned.SelectedItems.Item(0).Index
        Catch ex As Exception
        End Try

        Try
            Clipboard.SetText(LvwAssigned.SelectedItems.Item(0).SubItems(2).Text)
            ' Tipo = LvwAssigned.SelectedItems.Item(0).SubItems(6).Text
            ' txtTipo.Text = Tipo
        Catch ex As Exception
        End Try

        'Dim IdDet As Integer
        Dim param As String

        'param = " Where Det_Conversation.Con_Id='" & Id & "'"
        Try
            detalleId = LvwAssigned.SelectedItems.Item(0).SubItems(1).Text
            txtDetalle.Text = detalleId
        Catch ex As Exception
            Exit Sub
        End Try

        CargarDatosActual()

    End Sub

    Public Sub CargarDatosActual()

        param = " Where d.Det_Con='" & detalleId & "'"
        param = param & " ORDER BY L.item ASC"

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer

        sqlstring = "    SELECT        L.Id, o.TextoPlano, L.IdOracion, L.Item, L.IdConversacion, L.IMG, o.Traduccion, o.EsRespuesta, d.Observaciones, d.status"

        If ModVar.Idioma = "EN" Then
            sqlstring = sqlstring & "  FROM            Tbl_Dialogos L INNER JOIN"
            sqlstring = sqlstring & "                   Det_Conversation d ON L.IdConversacion = d.Det_Con INNER JOIN"
            sqlstring = sqlstring & "                 Oraciones o ON L.IdOracion = o.Id"
        Else
            sqlstring = sqlstring & "  FROM            Tbl_Dialogos_FR L INNER JOIN"
            sqlstring = sqlstring & "                   Det_Conversation d ON L.IdConversacion = d.Det_Con INNER JOIN"
            sqlstring = sqlstring & "                 Oraciones_FR o ON L.IdOracion = o.Id"
        End If

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

        LvwActual.Items.Clear()

        i = 0
        n = dt.Rows.Count
        If n = 0 Then Exit Sub

        Do While i <= n - 1


            Dim item As ListViewItem 'Creo el ListViewItem (item) 
            item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 
            item.UseItemStyleForSubItems = False

            Try

                'Dialogo
                item.SubItems.Add(dt.Rows(i).Item(0))
                item.SubItems.Add(dt.Rows(i).Item(1))
                If Not IsDBNull(dt.Rows(i).Item(6)) Then
                    item.SubItems.Add(dt.Rows(i).Item(6))
                Else
                    item.SubItems.Add("Sin traduccion")
                End If
                item.SubItems.Add(detalleId)
                item.SubItems.Add("0")
                item.SubItems.Add(dt.Rows(i).Item(2))

                If dt.Rows(i).Item(7) = "Q" Then
                    item.SubItems(2).ForeColor = Color.LightBlue
                    item.SubItems(3).ForeColor = Color.LightBlue
                ElseIf dt.Rows(i).Item(7) = "S" Then
                    item.SubItems(2).ForeColor = Color.Fuchsia
                    item.SubItems(3).ForeColor = Color.Fuchsia
                ElseIf dt.Rows(i).Item(7) = "C" Then
                    item.SubItems(2).ForeColor = Color.Chartreuse
                    item.SubItems(3).ForeColor = Color.Chartreuse
                ElseIf dt.Rows(i).Item(7) = "O" Then
                    item.SubItems(2).ForeColor = Color.LightYellow
                    item.SubItems(3).ForeColor = Color.LightYellow
                ElseIf dt.Rows(i).Item(7) = "E" Then
                    item.SubItems(2).ForeColor = Color.Chartreuse
                    item.SubItems(3).ForeColor = Color.Chartreuse
                Else
                    item.SubItems(2).ForeColor = Color.LightSalmon
                    item.SubItems(3).ForeColor = Color.LightSalmon

                End If
                item.SubItems.Add(dt.Rows(i).Item(9))

                LvwActual.Items.Add(item)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


            i = i + 1

        Loop

        If Not IsDBNull(dt.Rows(0).Item(8)) Then
            txtRespuesta.Text = dt.Rows(0).Item(8)
        Else
            txtRespuesta.Text = ""

        End If


    End Sub

    Private Sub LvwAssigned_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles LvwAssigned.DragEnter, LvwUnAssigned.DragEnter
        ' Check for the custom DataFormat ListViewItem array.
        If e.Data.GetDataPresent("System.Collections.Generic.List(Of " & _
            "System.Windows.Forms.ListViewItem)") Then
            e.Effect = DragDropEffects.Move
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub LvwAssigned_ItemDrag(sender As Object, e As System.Windows.Forms.ItemDragEventArgs) Handles LvwAssigned.ItemDrag
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

    Private Sub LvwAssigned_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles LvwAssigned.DragDrop

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


#End Region

#Region "lvw Frases"
    Private Sub lvwFrases_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs)

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

    Private Sub ListViewEx1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        Dim a As Integer
        a = ListView1.Items.Count
    End Sub

    Private Sub lvwFrases_ItemDrag(sender As Object, e As System.Windows.Forms.ItemDragEventArgs)
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

    Private Sub lvwActual_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles LvwActual.MouseClick

        If e.Button.Right = True Then
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sqlstring As String
            Dim IdOracion As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim resp As Boolean
            Dim sql As String
            Dim IdDetNuevo As Integer
            Dim j As Integer = 1
            Dim IdDialogo As Integer
            Dim Orden As Integer

            Orden = ListView1.Items.Count

            IdDialogo = LvwActual.SelectedItems.Item(0).SubItems(1).Text

            _comando.Connection.Open()

            _comando.Parameters.Clear()

            sqlstring = "Insert into Det_Conversation (Det_Orden, Con_Id)"
            sqlstring = sqlstring & " Values (@Det_Orden, '" & Enc_Id & "')"
            _comando.CommandText = sqlstring

            _comando.Parameters.AddWithValue("@Det_Orden", Orden)

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
            End Try

            Try
                If i > 0 Then
                    sql = "SELECT @@IDENTITY FROM Det_conversation"
                    _comando = New SqlCommand(sql, _comando.Connection)
                    Dim value As Object = _comando.ExecuteScalar
                    IdDetNuevo = value.ToString
                End If
                _comando.Connection.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            _comando.Connection.Open()

            sqlstring = "Update Dialogos SET DetConversacion='" & IdDetNuevo & "'"
            sqlstring = sqlstring & "  WHERE Id = '" & IdDialogo & "'"
            _comando.CommandText = sqlstring

            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


            '''''
            Dim param As String
            param = " Where Det_Conversation.Con_Id='" & Enc_Id & "'"
            param = param & " ORDER BY Det_Conversation.Det_Orden ASC, Dialogos.item ASC"

            CargarDatos(param)

            CargarDatosDetalles()



            'sqlstring = "SELECT * FROM Dialogos"
            'sqlstring = sqlstring & " WHERE DetConversacion = @DetConversacion"
            '_comando.CommandText = sqlstring

            '_comando.Parameters.Clear()
            '_comando.Parameters.AddWithValue("@DetConversacion", IdDetNuevo)
            'Try
            '    da.SelectCommand = _comando
            '    da.Fill(dt)

            'Catch ex As Exception
            'End Try

            'Dim n As Integer
            'n = dt.Rows.Count

            'Dim q As Integer = 0

            Dim item As ListViewItem 'Creo el ListViewItem (item) 
            item = New ListViewItem(LvwAssigned.Items.Count) 'Creo una nueva instancia de item pasandole el nombre como dato principal 
            ' item = lvwActual.SelectedItems.Item(0)

            item.SubItems.Add(LvwActual.SelectedItems.Item(0).SubItems(4).Text) ' Det_Conversation.Det_Con
            item.SubItems.Add(LvwActual.SelectedItems.Item(0).SubItems(2).Text) ' '7 Oraciones.TextoPlano, 
            item.SubItems.Add(LvwActual.SelectedItems.Item(0).SubItems(3).Text) ' '4 Oraciones.Traduccion, 
            item.SubItems.Add(LvwActual.SelectedItems.Item(0).SubItems(1).Text) ' '9 Dialogos.Id, 
            item.SubItems.Add("X")
            'item.SubItems.Add(lvwActual.SelectedItems.Item(0).SubItems(11).Text) ' '6 Oraciones.EsRespuesta, ""
            'item.SubItems.Add(lvwActual.SelectedItems.Item(0).SubItems(0).Text) ' '1 Dialogos.OracionId, 



            Try
                LvwAssigned.Items.Insert(LvwAssigned.Items.Count, item)

            Catch ex As Exception

            End Try
            LvwActual.Items.Remove(LvwActual.SelectedItems.Item(0))

            '0-Det_Conversation.Det_Con, 
            '1 Dialogos.OracionId, 
            '2 Det_Conversation.Det_Orden, 
            '3 Det_Conversation.Con_Id, 
            '4 Oraciones.Traduccion, 
            '5 Det_Conversation.Det_Par, 
            '6 Oraciones.EsRespuesta, ""
            '7 Oraciones.TextoPlano, 
            '8 Dialogos.Orden, 
            '9 Dialogos.Id, 
            '10 Oraciones.EsRespuesta, 
            'Dialogos.pin "


        End If

    End Sub

    Private Sub lvwActual_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles LvwActual.KeyUp
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim IdPerson As Integer
        Dim resp As Boolean
        Dim sql As String
        Dim IdDetNuevo As Integer
        Dim j As Integer = 1
        Dim max As Integer

        Dim IdDialogo As Integer
        Dim _status As String

        If LvwActual.SelectedItems.Count = 0 Then Exit Sub

        If e.KeyCode = Keys.M Then

            max = LvwAssigned.Items.Count

            IdDialogo = LvwActual.SelectedItems.Item(0).SubItems(1).Text
            _status = LvwActual.SelectedItems.Item(0).SubItems(7).Text

            _comando.Connection.Open()

            _comando.Parameters.Clear()

            sqlstring = "Insert into Det_Conversation (Orden, Con_Id, Status)"
            sqlstring = sqlstring & " Values (@Orden, '" & Enc_Id & "', @Status)"

            _comando.CommandText = sqlstring

            _comando.Parameters.AddWithValue("@Orden", max)
            _comando.Parameters.AddWithValue("@Status", _status)

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception

            End Try

            Try
                If i > 0 Then
                    sql = "SELECT @@IDENTITY FROM Det_conversation"

                    _comando = New SqlCommand(sql, _comando.Connection)

                    Dim value As Object = _comando.ExecuteScalar

                    IdDetNuevo = value.ToString
                End If
                _comando.Connection.Close()
            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
            _comando.Connection.Close()

            _comando.Connection.Open()

            If ModVar.Idioma = "EN" Then
                sqlstring = "Update Tbl_Dialogos SET IdConversacion='" & IdDetNuevo & "'"
            Else
                sqlstring = "Update Tbl_Dialogos_FR SET IdConversacion='" & IdDetNuevo & "'"
            End If

            sqlstring = sqlstring & "  WHERE Id = '" & IdDialogo & "'"
            _comando.CommandText = sqlstring

            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            LvwActual.Items.Remove(LvwActual.SelectedItems.Item(0))

        ElseIf e.KeyCode = Keys.X Then

            Dim IdDet As Integer


            Dim itemSel As ListViewItem = Nothing

            If LvwActual.SelectedItems.Count = 0 Then Exit Sub

            itemSel = LvwActual.SelectedItems.Item(0)

            Dim Sel As Integer
            Sel = itemSel.Index

            IdDialogo = itemSel.SubItems(1).Text

            _comando.Connection.Open()

            If ModVar.Idioma = "EN" Then
                sqlstring = "Delete FROM Tbl_Dialogos"
            Else
                sqlstring = "Delete FROM Tbl_Dialogos_FR"
            End If

            sqlstring = sqlstring & " WHERE Id = @Id"
            _comando.CommandText = sqlstring

            _comando.Parameters.Clear()
            _comando.Parameters.AddWithValue("@Id", IdDialogo)

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
            End Try



            LvwActual.Items.Remove(itemSel)


        ElseIf e.KeyCode = Keys.E Then
            Dim frm As New FrmDetOracion
            Dim IdOracion As Integer

            AddOwnedForm(frm)
            FILASELECT = LvwActual.SelectedItems.Item(0).Index

            IdOracion = LvwActual.SelectedItems.Item(0).SubItems(6).Text

            frm.IdOracion = IdOracion
            frm.CargarDatos(IdOracion)
            frm.ShowDialog()

            Try
                LvwActual.Items(FILASELECT).Selected = True
                LvwActual.EnsureVisible(FILASELECT)
                LvwActual.Focus()
            Catch ex As Exception
            End Try

        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

        Dim IdDet As Integer
        Dim param As String

        Try
            IdDet = ListView1.SelectedItems.Item(0).SubItems(1).Text
        Catch ex As Exception
            Exit Sub
        End Try

        param = " Where d.Det_Con='" & IdDet & "'"


        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer

        sqlstring = "    SELECT        t.Id, o.TextoPlano, t.IdOracion, t.Orden, t.IdConversacion, t.IMG, o.Traduccion, o.EsRespuesta"
        sqlstring = sqlstring & "  FROM            Tbl_Dialogos t INNER JOIN"
        sqlstring = sqlstring & "                   Det_Conversation d ON t.IdConversacion = d.Det_Con INNER JOIN"
        sqlstring = sqlstring & "                 Oraciones  o ON t.IdOracion = o.Id"
        sqlstring = sqlstring & param
        sqlstring = sqlstring & " ORDER BY t.Orden"


        Try
            _comandoLocal.CommandText = sqlstring
            _comandoLocal.Connection.Open()

            da.SelectCommand = _comandoLocal

            da.Fill(dt)
            _comandoLocal.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

        LvwActual.Items.Clear()

        i = 0
        n = dt.Rows.Count
        If n = 0 Then Exit Sub

        Do While i <= n - 1


            Dim item As ListViewItem 'Creo el ListViewItem (item) 
            item = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 
            item.UseItemStyleForSubItems = False

            Try

                'Dialogo
                item.SubItems.Add(dt.Rows(i).Item(0))
                item.SubItems.Add(dt.Rows(i).Item(1))
                item.SubItems.Add(dt.Rows(i).Item(6))
                item.SubItems.Add(IdDet)
                item.SubItems.Add("0")

                If dt.Rows(i).Item(7) = "Q" Then
                    item.SubItems(2).ForeColor = Color.Blue
                    item.SubItems(3).ForeColor = Color.Blue
                ElseIf dt.Rows(i).Item(7) = "S" Then
                    item.SubItems(2).ForeColor = Color.Fuchsia
                    item.SubItems(3).ForeColor = Color.Fuchsia
                ElseIf dt.Rows(i).Item(7) = "C" Then
                    item.SubItems(2).ForeColor = Color.Black
                    item.SubItems(3).ForeColor = Color.Black
                ElseIf dt.Rows(i).Item(7) = "O" Then
                    item.SubItems(2).ForeColor = Color.BlueViolet
                    item.SubItems(3).ForeColor = Color.BlueViolet
                ElseIf dt.Rows(i).Item(7) = "E" Then
                    item.SubItems(2).ForeColor = Color.DarkGreen
                    item.SubItems(3).ForeColor = Color.DarkGreen
                Else
                    item.SubItems(2).ForeColor = Color.Brown
                    item.SubItems(3).ForeColor = Color.Brown

                End If

                LvwActual.Items.Add(item)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


            i = i + 1

        Loop

        ListView1.SelectedItems.Item(0).SubItems(0).BackColor = Color.LightGreen



        '''''''''
        'Dim itm As ListViewItem 'Creo el ListViewItem (item) 
        LvwAssigned.Items(LastIndex).SubItems(3).BackColor = Color.White

        Dim Orden As Integer
        Dim Indice As Integer
        Dim foundItem As ListViewItem

        Try

            Do
                foundItem = LvwAssigned.FindItemWithText(IdDet, True, 0, True)
                If (foundItem IsNot Nothing) Then
                    LvwAssigned.Items(foundItem.Index).SubItems(3).BackColor = Color.Yellow
                    LvwAssigned.EnsureVisible(foundItem.Index)
                End If

            Loop While foundItem Is Nothing
        Catch ex As Exception
        End Try

        LastIndex = foundItem.Index

        'Dim indice As Integer
        'indice = ListView1.SelectedItems.Item(0).SubItems(0).Text

        'LvwAssigned.Focus()


        'LvwAssigned.Items(indice).Selected = True
        'LvwAssigned.Focus()

    End Sub

    Private Sub ListView1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)
        If e.Button.Right = True Then
            ListView1.Items.Remove(ListView1.SelectedItems.Item(0))
        End If

    End Sub

#End Region

#Region "Otros"
    Private Sub cmdAgregar_Click(sender As System.Object, e As System.EventArgs) Handles cmdAgregar.Click
        Dim frm As New frmTransferir

        AddOwnedForm(frm)

        If LvwAssigned.SelectedItems.Count > 0 Then
            frm.IdDet = LvwAssigned.SelectedItems.Item(0).SubItems(1).Text
        End If


        Try
            frm.IdEnc = Enc_Id
            frm.CargarDatos(Enc_Id)
            frm.ShowDialog()

            Dim psi As New ProcessStartInfo()
            psi.FileName = "python"
            psi.Arguments = """C:\legacy\Programas\Voz_Natural\ActualizarUso.py"" "
            psi.UseShellExecute = False
            psi.RedirectStandardOutput = True
            psi.CreateNoWindow = True

            Dim p As Process = Process.Start(psi)
            Dim resultado As String = p.StandardOutput.ReadToEnd()
            p.WaitForExit()

            MessageBox.Show(resultado)


            Dim param As String
            param = " Where d.Con_Id='" & Enc_Id & "'"


            CargarDatos(param)

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtTipo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTipo.TextChanged

        Try
            txtTipo.Text = UCase(txtTipo.Text)
        Catch ex As Exception
        End Try


        If Me.txtTipo.Text <> Tipo Then
        Else
            ' Exit Sub
        End If

        Tipo = txtTipo.Text
        'Dim resp As Boolean
        'Dim respcorreo As Boolean

        'Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        'Dim sqlstring As String

        'Dim item As ListViewItem

        'Dim i As Integer
        'Dim _insertado As Boolean = False
        'Dim mostrarMensaje As Boolean = False
        'Dim stringvalues As String = ""
        'Dim sql As String = ""
        'Dim IdOracion As Integer

        'Dim fecha As Date
        'Dim fechaEntrega As Date

        'IdOracion = LvwAssigned.SelectedItems.Item(0).SubItems(7).Text

        '_comando.Connection.Open()



        'sqlstring = "UPDATE Oraciones SET EsRespuesta = @EsRespuesta, IMG=@IMG "

        'sqlstring = sqlstring & " WHERE Id = @Id"
        '_comando.CommandText = sqlstring

        '_comando.Parameters.Clear()

        '_comando.Parameters.AddWithValue("@EsRespuesta", txtTipo.Text)

        'If txtTipo.Text = "Q" Then
        '    _comando.Parameters.AddWithValue("@IMG", "Pregunta1.png")
        'Else
        '    _comando.Parameters.AddWithValue("@IMG", "Like.png")
        'End If

        '_comando.Parameters.AddWithValue("@Id", IdOracion)

        'Try
        '    i = _comando.ExecuteNonQuery

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'End Try


        'If txtTipo.Text = "Q" Then
        '    LvwAssigned.SelectedItems.Item(0).SubItems(2).ForeColor = Color.Blue
        '    LvwAssigned.SelectedItems.Item(0).SubItems(3).ForeColor = Color.Blue
        'ElseIf txtTipo.Text = "S" Then
        '    LvwAssigned.SelectedItems.Item(0).SubItems(2).ForeColor = Color.Fuchsia
        '    LvwAssigned.SelectedItems.Item(0).SubItems(3).ForeColor = Color.Fuchsia

        'ElseIf txtTipo.Text = "C" Then
        '    LvwAssigned.SelectedItems.Item(0).SubItems(2).ForeColor = Color.Black
        '    LvwAssigned.SelectedItems.Item(0).SubItems(3).ForeColor = Color.Black

        'ElseIf txtTipo.Text = "O" Then
        '    LvwAssigned.SelectedItems.Item(0).SubItems(2).ForeColor = Color.BlueViolet
        '    LvwAssigned.SelectedItems.Item(0).SubItems(3).ForeColor = Color.BlueViolet

        'ElseIf txtTipo.Text = "E" Then
        '    LvwAssigned.SelectedItems.Item(0).SubItems(2).ForeColor = Color.DarkGreen
        '    LvwAssigned.SelectedItems.Item(0).SubItems(3).ForeColor = Color.DarkGreen

        'Else

        '    LvwAssigned.SelectedItems.Item(0).SubItems(2).ForeColor = Color.Brown
        '    LvwAssigned.SelectedItems.Item(0).SubItems(3).ForeColor = Color.Brown

        'End If



    End Sub

    Private Sub CmdMoverNuevo_Click(sender As System.Object, e As System.EventArgs) Handles CmdMoverNuevo.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim IdPerson As Integer
        Dim resp As Boolean
        Dim sql As String
        Dim IdDetNuevo As Integer
        Dim j As Integer = 1

        Dim IdDialogo As Integer

        If LvwActual.SelectedItems.Count = 0 Then Exit Sub

        IdDialogo = LvwActual.SelectedItems.Item(0).SubItems(1).Text

        _comando.Connection.Open()

        _comando.Parameters.Clear()

        sqlstring = "Insert into Det_Conversation (Orden, Con_Id)"
        sqlstring = sqlstring & " Values (@Orden, '" & Enc_Id & "')"

        _comando.CommandText = sqlstring

        _comando.Parameters.AddWithValue("@Orden", 0)

        Try
            i = _comando.ExecuteNonQuery
        Catch ex As Exception

        End Try

        Try
            If i > 0 Then
                sql = "SELECT @@IDENTITY FROM Det_conversation"

                _comando = New SqlCommand(sql, _comando.Connection)

                Dim value As Object = _comando.ExecuteScalar

                IdDetNuevo = value.ToString
            End If
            _comando.Connection.Close()
        Catch ex As Exception
            MsgBox(ex.Message)

        End Try
        _comando.Connection.Close()


        _comando.Connection.Open()

        'sqlstring = "Delete From Tbl_Dialogos "
        'sqlstring = sqlstring & "  WHERE IdConversacion = '" & IdDialogo & "'"

        '_comando.CommandText = sqlstring

        sqlstring = "Update Tbl_Dialogos SET IdConversacion='" & IdDetNuevo & "'"
        sqlstring = sqlstring & "  WHERE Id = '" & IdDialogo & "'"
        _comando.CommandText = sqlstring

        'sqlstring = "Update Tbl_Dialogos SET IdConversacion='0'" '& IdDetNuevo & "'"
        'sqlstring = sqlstring & "  WHERE Id = '" & IdDialogo & "'"
        '_comando.CommandText = sqlstring

        Try
            i = _comando.ExecuteNonQuery

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        '''''

        'sqlstring = "SELECT * FROM Dialogos"
        'sqlstring = sqlstring & " WHERE DetConversacion = @DetConversacion"
        '_comando.CommandText = sqlstring

        '_comando.Parameters.Clear()
        '_comando.Parameters.AddWithValue("@DetConversacion", IdDetNuevo)
        'Try
        '    da.SelectCommand = _comando
        '    da.Fill(dt)

        'Catch ex As Exception
        'End Try

        'Dim n As Integer
        'n = dt.Rows.Count

        'Dim q As Integer = 0


        LvwActual.Items.Remove(LvwActual.SelectedItems.Item(0))
        'For Each r In dt.Rows

        '    sqlstring = "UPDATE Dialogos SET Orden = @Orden"
        '    sqlstring = sqlstring & " WHERE Id = @Id"
        '    _comando.CommandText = sqlstring
        '    _comando.Parameters.Clear()

        '    _comando.Parameters.AddWithValue("@Orden", q)
        '    _comando.Parameters.AddWithValue("@Id", r.item(0))


        '    Try
        '        i = _comando.ExecuteNonQuery

        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try
        '    q += 1
        'Next

        '_comando.Connection.Close()


        ''Actualiza OracionId 'Det_conversation
        'For Each r In dt.Rows


        '    Try
        '        Console.WriteLine(r.item(1))
        '    Catch ex As Exception

        '    End Try
        '    sqlstring = "UPDATE Det_Conversation SET Det_OracionId = @Det_OracionId"
        '    sqlstring = sqlstring & " WHERE Det_Con = @Det_Con"
        '    _comando.CommandText = sqlstring
        '    _comando.Parameters.Clear()

        '    _comando.Parameters.AddWithValue("@Det_OracionId", r.item(1))
        '    _comando.Parameters.AddWithValue("@Det_Con", IdDetNuevo)

        '    Try
        '        i = _comando.ExecuteNonQuery

        '    Catch ex As Exception
        '    End Try
        'Next


    End Sub

    Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscar.TextChanged
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim buscar As String
        Dim sqlstring As String = ""
        Dim i, n As Integer

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim IdDet As Integer
        Dim param As String

        buscar = Trim(Me.txtBuscar.Text)

        If Len(buscar) < 3 Then Exit Sub

        ' IdDet = cboConversaciones.Items(cboConversaciones.SelectedIndex).ItemData()

        param = " Where o.Traduccion LIKE '%' + @Traduccion + '%'"

        sqlstring = " SELECT        d.Det_Con, l.IdOracion, d.Orden, d.Con_Id, o.Traduccion, d.Det_Par, o.EsRespuesta, "
        sqlstring = sqlstring & " o.TextoPlano, l.Orden, l.Id, l.pin, l.personaje, d.coherencia"
        sqlstring = sqlstring & " FROM            Tbl_Dialogos l INNER JOIN"
        sqlstring = sqlstring & "                 Oraciones o ON l.IdOracion = o.Id INNER JOIN"
        sqlstring = sqlstring & "                Det_Conversation  d ON l.IdConversacion = d.Det_Con"
        sqlstring = sqlstring & param

        _comando.CommandText = sqlstring

        _comando.Parameters.Clear()

        _comando.Parameters.AddWithValue("@Traduccion", txtBuscar.Text)
        Try
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)
            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try


        ' -----------------------------------------

        ' lvwFrases.Items.Clear()

        Dim itm As New ListViewItem
        Dim j As Integer
        n = dt.Rows.Count

        Do While i <= n - 1

            itm = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            itm.UseItemStyleForSubItems = False


            If dt.Rows(i).Item(11) = "A" Then 'Personaje
                itm.ImageKey = "Femenino"   ' itm.ImageIndex = 2   ' Femenino
            Else
                itm.ImageKey = "Masculino" '    itm.ImageIndex = 3  ' Masculino
            End If


            itm.SubItems.Add(dt.Rows(i).Item(0)) ' d.Det_Con, 
            itm.SubItems.Add(dt.Rows(i).Item(7)) 'l.IdOracion, d.Orden, d.Con_Id, ,

            If Not IsDBNull(dt.Rows(i).Item(4)) Then 'o.Traduccion
                itm.SubItems.Add(dt.Rows(i).Item(4))
            Else
                itm.SubItems.Add("Sin traduccion")
                itm.SubItems(3).ForeColor = Color.LightGray
            End If

            itm.SubItems.Add(dt.Rows(i).Item(9)) ' o.Id
            itm.SubItems.Add("X")
            itm.SubItems.Add(dt.Rows(i).Item(6))
            itm.SubItems.Add(dt.Rows(i).Item(1))

            If Not IsDBNull(dt.Rows(i).Item(12)) Then
                itm.SubItems.Add(Math.Round((dt.Rows(i).Item(12) * 100), 0))

            End If

            '  lvwFrases.Items.Add(itm)      'Agrego el item a la colección de listViewItem's de ListView1


            i = i + 1
            j = j + 1

        Loop



    End Sub

    Private Sub cmdFondo_Click(sender As System.Object, e As System.EventArgs) Handles cmdFondo.Click


        Dim itemNew As ListViewItem = Nothing
        Dim itemRem As ListViewItem = Nothing
        itemNew = LvwAssigned.SelectedItems.Item(0)
        'FILASELECT = ListViewEx1.SelectedItems.Item(0).Index
        'ListViewEx1.Items(FILASELECT).Selected = True
        LvwAssigned.Items.Remove(itemNew)
        ' LvwAssigned.Items.Insert(0, itemNew)
        LvwAssigned.Items.Add(itemNew)

    End Sub

    Private Sub cmdShowHide_Click(sender As System.Object, e As System.EventArgs) Handles cmdShowHide.Click

        If cmdShowHide.Text = "Show" Then
            cmdShowHide.Text = "Hide"
            LvwAssigned.Columns(2).Width = 500
            LvwUnAssigned.Columns(2).Width = 500
            LvwActual.Columns(2).Width = 500
        Else
            LvwAssigned.Columns(2).Width = 0
            LvwUnAssigned.Columns(2).Width = 0
            LvwActual.Columns(2).Width = 0
            cmdShowHide.Text = "Show"

        End If
    End Sub

    Private Sub cmdEditar_Click(sender As System.Object, e As System.EventArgs) Handles cmdEditar.Click

        Dim frm As New FrmDetOracion

        AddOwnedForm(frm)
        Dim IdOracion As Integer

        If LvwAssigned.SelectedItems.Count = 0 Then Exit Sub
        FILASELECT = LvwAssigned.SelectedItems.Item(0).Index

        IdOracion = LvwAssigned.SelectedItems.Item(0).SubItems(7).Text

        frm.IdOracion = IdOracion

        frm.CargarDatos(IdOracion)

        frm.ShowDialog()

        Try
            LvwAssigned.Items(FILASELECT).Selected = True
            LvwAssigned.EnsureVisible(FILASELECT)
            LvwAssigned.Focus()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub cmdOrdenar_Click(sender As System.Object, e As System.EventArgs) Handles cmdOrdenar.Click
        Dim param As String

        param = " Where d.Con_Id='" & Enc_Id & "'"
        param = param & " And d.Status='" & STATUS & "'"
        param = param & " ORDER BY  l.orden ASC"

        CargarDatos(param)

        txtCant.Text = LvwAssigned.Items.Count


    End Sub

    Private Sub cmdOrdenarId_Click(sender As System.Object, e As System.EventArgs) Handles cmdOrdenarId.Click
        Dim param As String

        param = " Where d.Con_Id='" & Enc_Id & "' and d.Status='" & STATUS & "'"
        param = param & " ORDER BY  o.TextoPlano ASC"
        CargarDatos(param)

        txtCant.Text = LvwAssigned.Items.Count


    End Sub




    Private Sub cmdEliminar_Click(sender As System.Object, e As System.EventArgs)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdDetalle As Integer
        Dim IdDialogo As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim indice As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer

        ' IdDetalle = LvwAssigned.SelectedItems.Item(0).SubItems(1).Text
        IdDialogo = LvwAssigned.SelectedItems.Item(0).SubItems(4).Text

        'sqlstring = "Delete From Dialogos "
        'sqlstring = sqlstring & "  WHERE Id = '" & IdDialogo & "'"

        '_comando.CommandText = sqlstring



        sqlstring = "Delete FROM Tbl_Dialogos"
        sqlstring = sqlstring & " WHERE Id = @Id"
        _comando.CommandText = sqlstring

        _comando.Parameters.Clear()
        _comando.Parameters.AddWithValue("@Id", IdDialogo)
        _comando.Connection.Open()
        Try
            i = _comando.ExecuteNonQuery
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try

        _comando.Connection.Close()


        param = " Where d.Con_Id='" & Enc_Id & "'"
        param = param & " ORDER BY d.orden ASC, l.Orden ASC, l.Item ASC"

        CargarDatos(param)

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim indice As Integer
        indice = ListView1.SelectedItems.Item(0).SubItems(0).Text



        LvwAssigned.Items(indice).Selected = True
        LvwAssigned.EnsureVisible(indice)
        LvwAssigned.Focus()




        'LvwAssigned.FullRowSelect = True
        '' LvwAssigned.Items(5).Focused = True
        'LvwAssigned.Items(5).Selected = True


    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged
        Dim buscar As String

        buscar = Trim(Me.TextBox1.Text)

        If Len(buscar) <= 3 Then Exit Sub

        Try
            LvwAssigned.Items(LastIndex).SubItems(3).BackColor = Color.White
        Catch ex As Exception
        End Try


        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer

        Dim param As String

        param = " Where o.TextoPlano LIKE '%' + @TextoPlano + '%'"
        param = param & " And d.Con_Id='" & Enc_Id & "'"
        param = param & " ORDER BY d.orden ASC, l.Orden ASC, l.Item ASC"

        sqlstring = " SELECT        d.Det_Con, l.IdOracion, d.Orden, d.Con_Id, o.Traduccion, d.Det_Par, o.EsRespuesta, "
        sqlstring = sqlstring & " o.TextoPlano, l.Orden, l.Id, l.pin, l.personaje, d.coherencia, o.contexto"
        sqlstring = sqlstring & " FROM            Tbl_Dialogos l INNER JOIN"
        sqlstring = sqlstring & "                 Oraciones o ON l.IdOracion = o.Id INNER JOIN"
        sqlstring = sqlstring & "                Det_Conversation  d ON l.IdConversacion = d.Det_Con"
        sqlstring = sqlstring & param

        _comando.CommandText = sqlstring

        Try
            _comando.Parameters.Clear()

            _comando.Parameters.AddWithValue("@TextoPlano", TextBox1.Text)
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)

        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
        End Try

        _comando.Connection.Close()


        LvwAssigned.Items.Clear()

        Dim itm As New ListViewItem
        Dim j As Integer
        n = dt.Rows.Count

        Do While i <= n - 1

            itm = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            itm.UseItemStyleForSubItems = False


            If dt.Rows(i).Item(11) = "A" Then 'Personaje
                itm.ImageKey = "Femenino"   ' itm.ImageIndex = 2   ' Femenino
            Else
                itm.ImageKey = "Masculino" '    itm.ImageIndex = 3  ' Masculino
            End If


            itm.SubItems.Add(dt.Rows(i).Item(0)) ' d.Det_Con, 
            itm.SubItems.Add(dt.Rows(i).Item(7)) 'l.IdOracion, d.Orden, d.Con_Id, ,

            If Not IsDBNull(dt.Rows(i).Item(4)) Then 'o.Traduccion
                itm.SubItems.Add(dt.Rows(i).Item(4))
            Else
                itm.SubItems.Add("Sin traduccion")
                itm.SubItems(3).ForeColor = Color.LightGray
            End If

            itm.SubItems.Add(dt.Rows(i).Item(9)) ' o.Id
            itm.SubItems.Add("X")
            itm.SubItems.Add(dt.Rows(i).Item(6))
            itm.SubItems.Add(dt.Rows(i).Item(1))

            If Not IsDBNull(dt.Rows(i).Item(12)) Then
                itm.SubItems.Add(Math.Round((dt.Rows(i).Item(12) * 100), 0))
            End If
            If Not IsDBNull(dt.Rows(i).Item(13)) Then
                itm.SubItems.Add((dt.Rows(i).Item(13)))
            End If
            LvwAssigned.Items.Add(itm)      'Agrego el item a la colección de listViewItem's de ListView1

            i = i + 1
            j = j + 1

        Loop


    End Sub

    Private Sub cmdEnviarPrincipio_Click(sender As System.Object, e As System.EventArgs) Handles cmdEnviarPrincipio.Click

        Dim itemNew As ListViewItem = Nothing
        Dim itemRem As ListViewItem = Nothing

        itemNew = LvwAssigned.SelectedItems.Item(0)
        'FILASELECT = ListViewEx1.SelectedItems.Item(0).Index
        'ListViewEx1.Items(FILASELECT).Selected = True
        ' LvwAssigned.Items.Insert(0, itemNew)

        LvwAssigned.Sorting = Windows.Forms.SortOrder.None
        LvwAssigned.ListViewItemSorter = Nothing

        LvwAssigned.BeginUpdate()

        LvwAssigned.Items.Remove(itemNew)
        ' LvwAssigned.Items.Insert(0, itemNew)
        LvwAssigned.Items.Insert(firstIndex, itemNew)

        LvwAssigned.EndUpdate()

    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        Dim psi As New ProcessStartInfo()
        psi.FileName = "python"
        psi.Arguments = """C:\legacy\Programas\Voz_Natural\Actualiza\actualizarPanelVacio.py"""
        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.CreateNoWindow = True

        Dim p As Process = Process.Start(psi)
        Dim resultado As String = p.StandardOutput.ReadToEnd()
        p.WaitForExit()

        lblStatus.Text = resultado


    End Sub

    Private Sub txtConversacion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtConversacion.TextChanged

    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim frm As New frmTraducciones

        AddOwnedForm(frm)

        frm.EncId = Enc_Id
        frm.ShowDialog()

    End Sub

    Private Sub cmdEnviarPython_Click(sender As System.Object, e As System.EventArgs)


        Dim lista As New List(Of String) From {
        "What is your job?",
        "I work in an office",
        "Do you like pizza?",
        "Yes I do",
        "Where do you travel?",
        "I travel to Spain"
    }

        Dim serializer As New JavaScriptSerializer()
        Dim json As String = serializer.Serialize(lista)

        Dim psi As New ProcessStartInfo()
        psi.FileName = "python"
        ' psi.Arguments = """C:\Legacy\Programas\backend2.py"""
        psi.Arguments = """C:\Legacy\Programas\Voz_Natural\backend3.py"""
        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.RedirectStandardInput = True
        psi.CreateNoWindow = True

        Dim process As Process = process.Start(psi)

        ' Enviar lista a Python
        process.StandardInput.WriteLine(json)
        process.StandardInput.Close()

        Dim resultadoJson As String = process.StandardOutput.ReadToEnd()
        process.WaitForExit()

        ' Convertir JSON devuelto a lista
        Dim listaOrdenada As List(Of String) =
            serializer.Deserialize(Of List(Of String))(resultadoJson)

        ' Mostrar resultado
        'Dim textoFinal As String = String.Join(Environment.NewLine, listaOrdenada)
        ' MessageBox.Show(textoFinal)
        ' 🔥 CARGAR AL LISTVIEW
        ' lvwFrases.Items.Clear()

        Dim contador As Integer = 1

        For Each frase As String In listaOrdenada

            Dim item As New ListViewItem(contador.ToString())
            item.SubItems.Add(frase)

            ' Opcional: colorear preguntas
            If frase.Contains("?") Then
                item.BackColor = Color.LightYellow
            End If

            'lvwFrases.Items.Add(item)
            contador += 1

        Next



    End Sub





    Private Sub cmdMoverConversacion_Click(sender As System.Object, e As System.EventArgs) Handles cmdMoverConversacion.Click
        Dim _idEnc As Integer
        Try
            _idEnc = cboConversation.Items(cboConversation.SelectedIndex).ItemData()

            moverA(_idEnc, "")
        Catch ex As Exception

        End Try


    End Sub

    Private Sub cmdRestaurante_Click(sender As System.Object, e As System.EventArgs) Handles cmdRestaurante.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, n As Integer
        Dim objDataReader As SqlDataReader

        sqlstring = "SELECT  Con_Id, Con_titulo"
        sqlstring = sqlstring & " FROM Enc_Conversation"
        sqlstring = sqlstring & " WHERE Con_titulo ='food'"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        objDataReader = _comando.ExecuteReader

        If objDataReader.Read() Then
            _Id = objDataReader(0)
            objDataReader.Close()

            moverA(_Id, "")
        End If
    End Sub

    Private Sub moverA(IdEnc, titulo)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim IdPerson As Integer
        Dim resp As Boolean
        Dim sql As String
        Dim IdDetNuevo As Integer
        Dim j As Integer = 1

        Dim IdDialogo As Integer

        _comando.Connection.Open()

        For Each rw As ListViewItem In LvwUnAssigned.Items

            IdDialogo = rw.SubItems(4).Text
            _comando.Parameters.Clear()

            sqlstring = "Insert into Det_Conversation (Orden, Con_Id)"
            sqlstring = sqlstring & " Values (@Orden, '" & IdEnc & "')"

            _comando.CommandText = sqlstring

            _comando.Parameters.AddWithValue("@Orden", 0)

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception

            End Try

            Try
                If i > 0 Then
                    sql = "SELECT @@IDENTITY FROM Det_conversation"
                    _comando = New SqlCommand(sql, _comando.Connection)
                    Dim value As Object = _comando.ExecuteScalar
                    IdDetNuevo = value.ToString
                End If

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

            sqlstring = "Update Tbl_Dialogos SET IdConversacion='" & IdDetNuevo & "'"
            sqlstring = sqlstring & "  WHERE Id = '" & IdDialogo & "'"
            _comando.CommandText = sqlstring

            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try





            'Actualiza conexto
            If titulo <> "" Then
                sqlstring = ""
                sqlstring &= "UPDATE o SET o.Contexto = @Titulo "
                sqlstring &= "FROM Oraciones o "
                sqlstring &= "INNER JOIN Tbl_dialogos d ON d.IdOracion = o.Id "
                sqlstring &= "WHERE d.Id = @IdDialogo"

                _comando.CommandText = sqlstring
                _comando.Parameters.Clear()
                _comando.Parameters.AddWithValue("@IdDialogo", IdDialogo)
                _comando.Parameters.AddWithValue("@Titulo", titulo)


                Try
                    i = _comando.ExecuteNonQuery

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If


            rw.Remove()

        Next





        _comando.Connection.Close()

        'Dim param As String

        'param = " Where d.Con_Id='" & Enc_Id & "' And Item='0'"
        'param = param & " And d.status='" & STATUS & "'"
        'param = param & " ORDER BY d.orden ASC, l.Orden ASC, l.Item ASC"

        'CargarDatos(param)



    End Sub

    Private Sub cmdGeneral_Click(sender As System.Object, e As System.EventArgs) Handles cmdGeneral.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, n As Integer
        Dim objDataReader As SqlDataReader

        sqlstring = "SELECT  Con_Id, Con_titulo"
        sqlstring = sqlstring & " FROM Enc_Conversation"
        sqlstring = sqlstring & " WHERE Con_titulo ='General'"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        objDataReader = _comando.ExecuteReader

        If objDataReader.Read() Then
            _Id = objDataReader(0)
            objDataReader.Close()

            moverA(_Id, "")
        End If
    End Sub

    Private Sub cmdOraciones_Click(sender As System.Object, e As System.EventArgs) Handles cmdOraciones.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, n As Integer
        Dim objDataReader As SqlDataReader

        sqlstring = "SELECT  Con_Id, Con_titulo"
        sqlstring = sqlstring & " FROM Enc_Conversation"
        sqlstring = sqlstring & " WHERE Con_titulo ='Oraciones'"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        objDataReader = _comando.ExecuteReader

        If objDataReader.Read() Then
            _Id = objDataReader(0)
            objDataReader.Close()

            moverA(_Id, "")
        End If

    End Sub

    Private Sub cmdIniciando_Click(sender As System.Object, e As System.EventArgs) Handles cmdIniciando.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, n As Integer
        Dim objDataReader As SqlDataReader

        sqlstring = "SELECT  Con_Id, Con_titulo"
        sqlstring = sqlstring & " FROM Enc_Conversation"
        sqlstring = sqlstring & " WHERE Con_titulo ='Personal information'"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        objDataReader = _comando.ExecuteReader

        If objDataReader.Read() Then
            _Id = objDataReader(0)
            objDataReader.Close()

            moverA(_Id, "")
        End If
    End Sub

    Private Sub cmdExpresiones_Click(sender As System.Object, e As System.EventArgs) Handles cmdExpresiones.Click

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, n As Integer
        Dim objDataReader As SqlDataReader

        sqlstring = "SELECT  Con_Id, Con_titulo"
        sqlstring = sqlstring & " FROM Enc_Conversation"
        sqlstring = sqlstring & " WHERE Con_titulo ='Expresiones'"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        objDataReader = _comando.ExecuteReader

        If objDataReader.Read() Then
            _Id = objDataReader(0)
            objDataReader.Close()

            moverA(_Id, "")
        End If
    End Sub

    Private Sub cmdclima_Click(sender As System.Object, e As System.EventArgs) Handles cmdclima.Click
        'moverA(30090, "Clima")
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, n As Integer
        Dim objDataReader As SqlDataReader

        sqlstring = "SELECT  Con_Id, Con_titulo"
        sqlstring = sqlstring & " FROM Enc_Conversation"
        sqlstring = sqlstring & " WHERE Con_titulo ='weather'"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        objDataReader = _comando.ExecuteReader

        If objDataReader.Read() Then
            _Id = objDataReader(0)
            objDataReader.Close()

            moverA(_Id, "")
        End If
    End Sub

    Private Sub cmdSaludos_Click(sender As System.Object, e As System.EventArgs) Handles cmdSaludos.Click
        ' moverA(30091, "Saludo")
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, n As Integer
        Dim objDataReader As SqlDataReader

        sqlstring = "SELECT  Con_Id, Con_titulo"
        sqlstring = sqlstring & " FROM Enc_Conversation"
        sqlstring = sqlstring & " WHERE Con_titulo ='Greetings'"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        objDataReader = _comando.ExecuteReader

        If objDataReader.Read() Then
            _Id = objDataReader(0)
            objDataReader.Close()

            moverA(_Id, "")
        End If
    End Sub

    Private Sub cmdcompras_Click(sender As System.Object, e As System.EventArgs) Handles cmdcompras.Click
        'moverA(30092, "Compras")
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, n As Integer
        Dim objDataReader As SqlDataReader

        sqlstring = "SELECT  Con_Id, Con_titulo"
        sqlstring = sqlstring & " FROM Enc_Conversation"
        sqlstring = sqlstring & " WHERE Con_titulo ='shopping'"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        objDataReader = _comando.ExecuteReader

        If objDataReader.Read() Then
            _Id = objDataReader(0)
            objDataReader.Close()

            moverA(_Id, "")
        End If
    End Sub

    Private Sub cmdOtros_Click(sender As System.Object, e As System.EventArgs) Handles cmdOtros.Click
        moverA(30093, "")
    End Sub

    Private Sub cmdSimples_Click(sender As System.Object, e As System.EventArgs) Handles cmdSimples.Click
        moverA(29890, "Cortesia")
    End Sub



    Private Sub cboConversaciones_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboConversaciones.SelectedIndexChanged

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer
        Dim IdEnc As Integer
        Dim param As String

        IdEnc = cboConversaciones.Items(cboConversaciones.SelectedIndex).ItemData()

        param = " Where d.Con_Id='" & IdEnc & "'"

        sqlstring = " SELECT        d.Det_Con, l.IdOracion, d.Orden, d.Con_Id, o.Traduccion, d.Det_Par, o.EsRespuesta, "
        sqlstring = sqlstring & " o.TextoPlano, l.Orden, l.Id, l.pin, l.personaje, d.coherencia"
        sqlstring = sqlstring & " FROM            Tbl_Dialogos l INNER JOIN"
        sqlstring = sqlstring & "                 Oraciones o ON l.IdOracion = o.Id INNER JOIN"
        sqlstring = sqlstring & "                Det_Conversation  d ON l.IdConversacion = d.Det_Con"
        sqlstring = sqlstring & param
        sqlstring = sqlstring & "  ORDER BY o.Traduccion ASC "


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


        ' -----------------------------------------

        ' lvwFrases.Items.Clear()

        Dim itm As New ListViewItem
        Dim j As Integer
        n = dt.Rows.Count

        Do While i <= n - 1

            itm = New ListViewItem(i) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

            itm.UseItemStyleForSubItems = False


            If dt.Rows(i).Item(11) = "A" Then 'Personaje
                itm.ImageKey = "Femenino"   ' itm.ImageIndex = 2   ' Femenino
            Else
                itm.ImageKey = "Masculino" '    itm.ImageIndex = 3  ' Masculino
            End If


            itm.SubItems.Add(dt.Rows(i).Item(0)) ' d.Det_Con, 
            itm.SubItems.Add(dt.Rows(i).Item(7)) 'l.IdOracion, d.Orden, d.Con_Id, ,

            If Not IsDBNull(dt.Rows(i).Item(4)) Then 'o.Traduccion
                itm.SubItems.Add(dt.Rows(i).Item(4))
            Else
                itm.SubItems.Add("Sin traduccion")
                itm.SubItems(3).ForeColor = Color.LightGray
            End If

            itm.SubItems.Add(dt.Rows(i).Item(9)) ' o.Id
            itm.SubItems.Add("X")
            itm.SubItems.Add(dt.Rows(i).Item(6))
            itm.SubItems.Add(dt.Rows(i).Item(1))

            If Not IsDBNull(dt.Rows(i).Item(12)) Then
                itm.SubItems.Add(Math.Round((dt.Rows(i).Item(12) * 100), 0))

            End If

            'lvwFrases.Items.Add(itm)      'Agrego el item a la colección de listViewItem's de ListView1


            i = i + 1
            j = j + 1

        Loop

        'For Each item As ListViewItem In LvwAssigned.Items
        '    If item.Index = FILASELECT Then
        '        item.Selected = True
        '        'item.SubItems(3).ForeColor = Color.Blue
        '        itm.SubItems(3).BackColor = Color.LightGray

        '        item.Focused = True
        '        item.EnsureVisible()
        '        Exit For
        '    End If
        'Next
        'lvwFrases.Select()



    End Sub

    Private Sub cboConversacionPrincipal_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboConversacionPrincipal.SelectedIndexChanged

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer

        Dim param As String

        LvwAssigned.Items.Clear()

        Enc_Id = cboConversacionPrincipal.Items(cboConversacionPrincipal.SelectedIndex).ItemData()

        param = " Where d.Con_Id='" & Enc_Id & "'"
        param = param & " ORDER BY d.orden ASC, l.Orden ASC, l.Item ASC"

        CargarDatos(param)


    End Sub

    Private Sub cmdRevisados_Click(sender As System.Object, e As System.EventArgs) Handles cmdRevisados.Click
        'Lista Revisado

        Dim param As String

        If cmdRevisados.Text = "Revisados" Then
            STATUS = "N"
            cmdRevisados.Text = "Sin_Revisar"
            cmdRevisados.BackColor = Color.LightSalmon
            param = " Where d.Con_Id='" & Enc_Id & "' And l.Item='0' and d.Status='N'"
        Else 'Sin_Revisar
            STATUS = "R"
            cmdRevisados.Text = "Revisados"
            cmdRevisados.BackColor = Color.LightGreen
            param = " Where d.Con_Id='" & Enc_Id & "' And l.Item='0' and d.Status='R'"
        End If

        param = param & " ORDER BY d.orden ASC, l.Orden ASC, l.Item ASC"

        CargarDatos(param)

        CargarDatosDetalles()

        txtCant.Text = LvwAssigned.Items.Count
        txtStatus.Text = STATUS
    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles cmdFamilia.Click
        ' moverA(30091, "Saludo")
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, n As Integer
        Dim objDataReader As SqlDataReader

        sqlstring = "SELECT  Con_Id, Con_titulo"
        sqlstring = sqlstring & " FROM Enc_Conversation"
        sqlstring = sqlstring & " WHERE Con_titulo ='Family'"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        objDataReader = _comando.ExecuteReader

        If objDataReader.Read() Then
            _Id = objDataReader(0)
            objDataReader.Close()

            moverA(_Id, "")
        End If
    End Sub

    Private Sub cmdDeportes_Click(sender As System.Object, e As System.EventArgs) Handles cmdDeportes.Click
        ' moverA(30091, "Saludo")
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, n As Integer
        Dim objDataReader As SqlDataReader

        sqlstring = "SELECT  Con_Id, Con_titulo"
        sqlstring = sqlstring & " FROM Enc_Conversation"
        sqlstring = sqlstring & " WHERE Con_titulo ='Deportes'"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        objDataReader = _comando.ExecuteReader

        If objDataReader.Read() Then
            _Id = objDataReader(0)
            objDataReader.Close()

            moverA(_Id, "")
        End If

    End Sub

    Private Sub cmdeliminarDialogos_Click(sender As System.Object, e As System.EventArgs) Handles cmdeliminarDialogos.Click

        If cmdeliminarDialogos.Text = "Mover Eliminar" Then
            Dim psi As New ProcessStartInfo()

            psi.FileName = "python.exe"  ' Mejor especificar .exe

            psi.Arguments = """C:\legacy\Programas\Voz_Natural\Mover\EliminarDialogos.py"" " & Enc_Id.ToString()

            psi.UseShellExecute = False
            psi.RedirectStandardOutput = True
            psi.RedirectStandardError = True   ' 🔥 IMPORTANTE
            psi.CreateNoWindow = True

            Dim p As Process = Process.Start(psi)

            Dim resultado As String = p.StandardOutput.ReadToEnd()
            Dim errorOutput As String = p.StandardError.ReadToEnd()

            p.WaitForExit()

            If errorOutput <> "" Then
                lblStatus.Text = "ERROR: " & errorOutput
            Else
                lblStatus.Text = resultado
            End If

            cmdeliminarDialogos.Text = "Mover SinRevisar"
        Else

            Dim psi As New ProcessStartInfo()
            psi.FileName = "python"
            psi.Arguments = """C:\legacy\Programas\Voz_Natural\Mover\MoverEliminadosSinRevisar.py"" " & Enc_Id
            psi.UseShellExecute = False
            psi.RedirectStandardOutput = True
            psi.CreateNoWindow = True

            Dim p As Process = Process.Start(psi)
            Dim resultado As String = p.StandardOutput.ReadToEnd()
            p.WaitForExit()

            lblStatus.Text = resultado
            cmdeliminarDialogos.Text = "Mover Eliminar"

        End If

    End Sub

    Private Sub cmdMal_Click(sender As System.Object, e As System.EventArgs) Handles cmdMal.Click
        'Lista Revisado

        Dim param As String

        If cmdMal.Text = "Mal" Then
            STATUS = "N"
            cmdMal.Text = "Sin_Revisar"
            param = " Where d.Con_Id='" & Enc_Id & "' And l.Item='0' and d.Status='N'"
            cmdMal.BackColor = Color.LightGreen
        Else 'Sin_Revisar
            STATUS = "X"
            cmdMal.Text = "Mal"
            cmdMal.BackColor = Color.LightSalmon
            param = " Where d.Con_Id='" & Enc_Id & "' And l.Item='0' and d.Status='X'"
        End If

        param = param & " ORDER BY d.orden ASC, l.Orden ASC, l.Item ASC"

        CargarDatos(param)

        CargarDatosDetalles()

        txtCant.Text = LvwAssigned.Items.Count
        txtStatus.Text = STATUS



    End Sub

    Private Sub cmdMoverRevisados_Click(sender As System.Object, e As System.EventArgs) Handles cmdMoverRevisados.Click


        If cmdMoverRevisados.Text = "Mover Revisados" Then
            Dim psi As New ProcessStartInfo()

            psi.FileName = "python.exe"  ' Mejor especificar .exe

            psi.Arguments = """C:\legacy\Programas\Voz_Natural\Mover\MoverRevisados.py"" " & Enc_Id.ToString()

            psi.UseShellExecute = False
            psi.RedirectStandardOutput = True
            psi.RedirectStandardError = True   ' 🔥 IMPORTANTE
            psi.CreateNoWindow = True

            Dim p As Process = Process.Start(psi)

            Dim resultado As String = p.StandardOutput.ReadToEnd()
            Dim errorOutput As String = p.StandardError.ReadToEnd()

            p.WaitForExit()

            If errorOutput <> "" Then
                lblStatus.Text = "ERROR: " & errorOutput
            Else
                lblStatus.Text = resultado
            End If

            cmdMoverRevisados.Text = "Mover Normal"
        Else

            Dim psi As New ProcessStartInfo()
            psi.FileName = "python"
            psi.Arguments = """C:\legacy\Programas\Voz_Natural\Mover\MoverSinRevisar.py"" " & Enc_Id
            psi.UseShellExecute = False
            psi.RedirectStandardOutput = True
            psi.CreateNoWindow = True

            Dim p As Process = Process.Start(psi)
            Dim resultado As String = p.StandardOutput.ReadToEnd()
            p.WaitForExit()

            lblStatus.Text = resultado
            cmdMoverRevisados.Text = "Mover Revisados"

        End If

    End Sub

    Private Sub cmdEliminarMal_Click(sender As System.Object, e As System.EventArgs) Handles cmdEliminarMal.Click

        Dim resp As Integer

        resp = MsgBox("¿Eliminar de dialogos?", MsgBoxStyle.YesNo)
        If resp <> 6 Then
            Exit Sub
        End If

        Dim psi As New ProcessStartInfo()
        psi.FileName = "python"
        psi.Arguments = """C:\legacy\Programas\Voz_Natural\EliminarDialogos0.py"" " & Enc_Id
        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.CreateNoWindow = True

        Dim p As Process = Process.Start(psi)
        Dim resultado As String = p.StandardOutput.ReadToEnd()
        p.WaitForExit()

        LvwAssigned.Items.Clear()
        lblStatus.Text = resultado
    End Sub

    Private Sub cmdMoverDetalle_Click(sender As System.Object, e As System.EventArgs) Handles cmdMoverDetalle.Click
        Dim _idEnc As Integer

        If cboTipoC.Text = "" Then Exit Sub

        If cboTipoC.SelectedIndex = -1 Then Exit Sub
        _idEnc = cboTipoC.Items(cboTipoC.SelectedIndex).ItemData()

        MoverDetalle(_idEnc, cboTipoC.Text)

    End Sub

    Private Sub MoverDetalle(enc_Id, titulo)

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim IdPerson As Integer
        Dim resp As Boolean
        Dim sql As String
        Dim IdDetNuevo As Integer
        Dim j As Integer = 1

        Dim IdDialogo As Integer
        Dim IdConversacionOriginal As Integer
        Dim nuevaLista As New ListView
        'NuevaLista
        ' Copiar columnas

        nuevaLista.Clear()

        ' Agregar columnas 0 y 1 correctamente
        nuevaLista.Columns.Add(LvwUnAssigned.Columns(0).Text)
        nuevaLista.Columns.Add(LvwUnAssigned.Columns(1).Text)

        ' Copiar columnas 0 y 1
        For Each lvItem As ListViewItem In LvwUnAssigned.Items

            'Dim nuevoItem As New ListViewItem(lvItem.SubItems(1).Text)
            ' nuevaLista.Items.Add(nuevoItem)

            If Not nuevaLista.Items.ContainsKey(lvItem.SubItems(1).Text) Then
                Dim nuevoItem As New ListViewItem(lvItem.SubItems(1).Text)
                nuevoItem.Name = lvItem.SubItems(1).Text
                nuevoItem.SubItems.Add(lvItem.SubItems(4).Text)
                nuevaLista.Items.Add(nuevoItem)
            End If

            lvItem.Remove()

        Next

        _comando.Connection.Open()


        For Each rw As ListViewItem In nuevaLista.Items


            _comando.Parameters.Clear()

            sqlstring = "Insert into Det_Conversation (Orden, Con_Id)"
            sqlstring = sqlstring & " Values (@Orden, '" & enc_Id & "')"
            _comando.CommandText = sqlstring

            _comando.Parameters.AddWithValue("@Orden", 0)

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
            End Try

            Try
                If i > 0 Then
                    sql = "SELECT @@IDENTITY FROM Det_conversation"
                    _comando = New SqlCommand(sql, _comando.Connection)
                    Dim value As Object = _comando.ExecuteScalar
                    IdDetNuevo = value.ToString
                End If

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

            IdConversacionOriginal = rw.SubItems(0).Text
            IdDialogo = rw.SubItems(1).Text

            sqlstring = "UPDATE Tbl_Dialogos  SET IdConversacion = @NuevoId"
            sqlstring = sqlstring & "  WHERE IdConversacion = @ViejoId"
            _comando.CommandText = sqlstring

            _comando.Parameters.Clear()
            _comando.Parameters.AddWithValue("@NuevoId", IdDetNuevo)
            _comando.Parameters.AddWithValue("@ViejoId", IdConversacionOriginal)

            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            'Actualiza conexto
            If titulo <> "" Then
                sqlstring = ""
                sqlstring &= "UPDATE o SET o.tema = @Titulo "
                sqlstring &= "FROM Oraciones o "
                sqlstring &= "INNER JOIN Tbl_dialogos d ON d.IdOracion = o.Id "
                sqlstring &= "WHERE d.Id = @IdDialogo"

                _comando.CommandText = sqlstring
                _comando.Parameters.Clear()
                _comando.Parameters.AddWithValue("@IdDialogo", IdDialogo)
                _comando.Parameters.AddWithValue("@Titulo", titulo)


                Try
                    i = _comando.ExecuteNonQuery

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try

            End If



        Next





        _comando.Connection.Close()

        'Dim param As String

        'param = " Where d.Con_Id='" & enc_Id & "' And Item='0'"
        'param = param & " And d.status='" & STATUS & "'"
        'param = param & " ORDER BY d.orden ASC, l.Orden ASC, l.Item ASC"

        'CargarDatos(param)

    End Sub
    Private Sub MoverDetalleTodo(enc_IdNuevo, titulo)

        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim IdPerson As Integer
        Dim resp As Boolean
        Dim sql As String
        Dim IdDetNuevo As Integer
        Dim j As Integer = 1

        Dim IdDialogo As Integer
        Dim IdConversacionOriginal As Integer
        Dim nuevaLista As New ListView

        _comando.Connection.Open()


        For Each rw As ListViewItem In LvwAssigned.Items

            _comando.Parameters.Clear()

            IdConversacionOriginal = rw.SubItems(1).Text
            IdDialogo = rw.SubItems(4).Text

            sqlstring = "UPDATE Det_conversation  SET Con_Id = @NuevoId"
            sqlstring = sqlstring & "  WHERE Con_Id = @ViejoId"
            _comando.CommandText = sqlstring

            _comando.Parameters.Clear()
            _comando.Parameters.AddWithValue("@NuevoId", enc_IdNuevo)
            _comando.Parameters.AddWithValue("@ViejoId", Enc_Id)

            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


        Next

        _comando.Connection.Close()


    End Sub
    Private Sub cmdSortNivel_Click(sender As System.Object, e As System.EventArgs) Handles cmdSortNivel.Click
        Dim param As String

        param = " Where d.Con_Id='" & Enc_Id & "'"
        param = param & "  And l.Item='0' and d.Status='" & STATUS & "'"
        param = param & " ORDER BY  o.frecuencia2 ASC"
        CargarDatos(param)
    End Sub

    Private Sub cmdOrdenarContexto_Click(sender As System.Object, e As System.EventArgs) Handles cmdOrdenarContexto.Click
        Dim param As String

        param = " Where d.Con_Id='" & Enc_Id & "'"
        'param = param & "  And l.Item='0' and d.Status='" & STATUS & "'"
        param = param & " ORDER BY  o.contexto ASC, l.orden ASC "
        CargarDatos(param)

        txtCant.Text = LvwAssigned.Items.Count

    End Sub

    Private Sub cmdOrdenarDialogos_Click(sender As System.Object, e As System.EventArgs) Handles cmdOrdenarDialogos.Click
        lblStatus.Text = "Iniciando..."

        Dim psi As New ProcessStartInfo()
        psi.FileName = "python"
        psi.Arguments = "-u ""C:\legacy\Programas\Voz_Natural\ordenporId.py"" " & Enc_Id
        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.RedirectStandardError = True
        psi.CreateNoWindow = True

        Dim p As New Process()
        p.StartInfo = psi
        p.EnableRaisingEvents = True

        AddHandler p.OutputDataReceived,
            Sub(senderObj, args)
                If args.Data IsNot Nothing Then
                    Me.BeginInvoke(Sub()
                                       lblStatus.Text = args.Data
                                   End Sub)
                End If
            End Sub

        AddHandler p.ErrorDataReceived,
            Sub(senderObj, args)
                If args.Data IsNot Nothing Then
                    Me.BeginInvoke(Sub()
                                       lblStatus.Text = "ERROR: " & args.Data
                                   End Sub)
                End If
            End Sub

        AddHandler p.Exited,
            Sub()
                Me.BeginInvoke(Sub()
                                   lblStatus.Text = "Proceso finalizado"
                               End Sub)
            End Sub

        p.Start()
        p.BeginOutputReadLine()
        p.BeginErrorReadLine()

    End Sub

    Private Sub cmdCopia_Click(sender As System.Object, e As System.EventArgs) Handles cmdCopia.Click

        If cmdCopia.Text = "copia" Then
            COPIA = False
            cmdCopia.Text = "Sin_copia"
            cmdCopia.BackColor = Color.Gray
        Else
            COPIA = True
            cmdCopia.Text = "copia"
            cmdCopia.BackColor = Color.LightGreen

        End If
    End Sub

    Private Sub cmdDescomponer_Click(sender As System.Object, e As System.EventArgs) Handles cmdDescomponer.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim IdPerson As Integer
        Dim resp As Boolean
        Dim sql As String
        Dim IdDetNuevo As Integer
        Dim j As Integer = 1
        Dim orden As Integer
        Dim IdDialogo As Integer

        _comando.Connection.Open()

        For Each rw As ListViewItem In LvwActual.Items

            IdDialogo = rw.SubItems(1).Text
            _comando.Parameters.Clear()

            sqlstring = "Insert into Det_Conversation (Orden, Con_Id, status)"
            sqlstring = sqlstring & " Values (@Orden, '" & Enc_Id & "', 'R')"

            _comando.CommandText = sqlstring

            _comando.Parameters.AddWithValue("@Orden", orden)

            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception

            End Try

            Try
                If i > 0 Then
                    sql = "SELECT @@IDENTITY FROM Det_conversation"
                    _comando = New SqlCommand(sql, _comando.Connection)
                    Dim value As Object = _comando.ExecuteScalar
                    IdDetNuevo = value.ToString
                End If

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try

            sqlstring = "Update Tbl_Dialogos SET IdConversacion='" & IdDetNuevo & "'"
            sqlstring = sqlstring & "  WHERE Id = '" & IdDialogo & "'"
            _comando.CommandText = sqlstring

            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try



            'Actualiza conexto

            sqlstring = ""
            sqlstring &= "UPDATE o SET o.Contexto = @Titulo "
            sqlstring &= "FROM Oraciones o "
            sqlstring &= "INNER JOIN Tbl_dialogos d ON d.IdOracion = o.Id "
            sqlstring &= "WHERE d.Id = @IdDialogo"

            _comando.CommandText = sqlstring
            _comando.Parameters.Clear()
            _comando.Parameters.AddWithValue("@IdDialogo", IdDialogo)
            _comando.Parameters.AddWithValue("@Titulo", ModVar.Conversacion)


            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            'rw.Remove()

            orden = orden + 1

            lblStatus.Text = orden

        Next

        LvwActual.Items.Clear()

        _comando.Connection.Close()

        Dim param As String

        param = " Where d.Con_Id='" & Enc_Id & "' And Item='0'"
        param = param & " And d.status='" & STATUS & "'"
        param = param & " ORDER BY d.orden ASC, l.Orden ASC, l.Item ASC"

        CargarDatos(param)



    End Sub


#End Region


    Private Sub cmdsaveOrdenDialogos_Click(sender As System.Object, e As System.EventArgs) Handles cmdsaveOrdenDialogos.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim i As Integer

        Dim sql As String = ""
        Dim IdMax As Integer
        Dim n As Integer

        Dim resp As Boolean
        Dim param As String = ""

        Dim band As Boolean
        Dim y As Integer ' Cantidad de Dialogos en Detalle

        Dim Indices As ListView
        Dim Orden As Integer
        Dim Indice As Integer

        ProgressBar1.Maximum = LvwAssigned.Items.Count

        Dim j As Integer

        _comando.Connection.Open()

        For Each rw In LvwAssigned.Items

            If ModVar.Idioma = "EN" Then
                sqlstring = "UPDATE Tbl_Dialogos SET orden = @orden"
            Else
                sqlstring = "UPDATE Tbl_Dialogos_FR SET orden = @orden"

            End If
            sqlstring = sqlstring & " WHERE Id = @Id"
            _comando.CommandText = sqlstring

            'Console.WriteLine(rw.SubItems(1).Text)
            'Console.WriteLine(rw.SubItems(2).Text)
            'Console.WriteLine(rw.SubItems(3).Text)
            'Console.WriteLine(rw.SubItems(4).Text)
            'Console.WriteLine(rw.SubItems(5).Text)
            'Console.WriteLine(rw.SubItems(6).Text)
            'Console.WriteLine(rw.SubItems(7).Text)
            Console.WriteLine(rw.SubItems(3).Text)
            Console.WriteLine(rw.SubItems(4).Text)
            ' Console.WriteLine(rw.SubItems(10).Text)

            _comando.Parameters.Clear()
            _comando.Parameters.AddWithValue("@Id", rw.SubItems(4).Text)
            _comando.Parameters.AddWithValue("@orden", rw.index)


            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            ProgressBar1.Value += 1

        Next




        lblStatus.Text = "Actualizado: " & Now
        _comando.Connection.Close()

        Dim dtNueva As New DataTable
        Dim daNueva As New SqlDataAdapter

        'Actualiza Item


        Dim psi As New ProcessStartInfo()
        Dim p As Process '
        Dim resultado As String 'psi.FileName = "python"
        'psi.Arguments = """C:\legacy\Programas\Voz_Natural\items2.py"" " & Id
        'psi.UseShellExecute = False
        'psi.RedirectStandardOutput = True
        'psi.CreateNoWindow = True

        'Dim resultado As String = p.StandardOutput.ReadToEnd()
        '        'p.WaitForExit()

        'MessageBox.Show(resultado)

        'psi = New ProcessStartInfo()
        'psi.FileName = "python"
        'psi.Arguments = """C:\legacy\Programas\Voz_Natural\actualizar0.py"""
        'psi.UseShellExecute = False
        'psi.RedirectStandardOutput = True
        'psi.CreateNoWindow = True

        'p = Process.Start(psi)
        'resultado = p.StandardOutput.ReadToEnd()
        'p.WaitForExit()

        'psi = New ProcessStartInfo()
        'psi.FileName = "python"
        'psi.Arguments = """C:\legacy\Programas\Voz_Natural\ActualizarPersonaje.py"""
        'psi.UseShellExecute = False
        'psi.RedirectStandardOutput = True
        'psi.CreateNoWindow = True

        'p = Process.Start(psi)
        'resultado = p.StandardOutput.ReadToEnd()
        'p.WaitForExit()

        'psi = New ProcessStartInfo()
        'psi.FileName = "python"
        'psi.Arguments = """C:\legacy\Programas\Voz_Natural\ActualizaItems.py"""
        'psi.UseShellExecute = False
        'psi.RedirectStandardOutput = True
        'psi.CreateNoWindow = True

        'p = Process.Start(psi)
        'resultado = p.StandardOutput.ReadToEnd()
        'p.WaitForExit()


        ' MessageBox.Show(resultado)

        'sqlstring = "  SELECT        Id, Orden, IdConversation"
        'sqlstring = sqlstring & " FROM Tbl_Dialogos"
        'sqlstring = sqlstring & " WHERE Id = @Id"
        'sqlstring = sqlstring & " ORDER BY Orden ASC"
        '_comando.CommandText = sqlstring

        '_comando.Parameters.Clear()
        '_comando.Parameters.AddWithValue("@Con_Id", Id)

        'Try
        '    da.SelectCommand = _comando

        '    da.Fill(dtNueva)
        'Catch ex As Exception
        'End Try

        'Dim j = 0
        '_comando.Connection.Open()



        'Actualizar Item de Dialogos
        'Dim dtDialogos As New DataTable
        '' Dim param As String

        'param = " Where dc.Con_Id='" & Id & "'"
        'param = param & " ORDER BY dc.Orden ASC, L.Item ASC"

        '' Dim da As New SqlDataAdapter
        'sqlstring = " SELECT        dc.Det_Con, L.IdOracion, dc.Orden, dc.Con_Id, o.Traduccion, dc.Det_Par, o.EsRespuesta, "
        'sqlstring = sqlstring & " o.TextoPlano, L.Orden, L.Id, o.EsRespuesta "
        'sqlstring = sqlstring & " FROM            Tbl_Dialogos L INNER JOIN"
        'sqlstring = sqlstring & "                 Oraciones o ON L.IdOracion = o.Id INNER JOIN"
        'sqlstring = sqlstring & "                Det_Conversation dc ON L.IdConversacion = dc.Det_Con"
        'sqlstring = sqlstring & param

        'Try
        '    _comando.CommandText = sqlstring
        '    ' _comando.Connection.Open()

        '    da.SelectCommand = _comando

        '    da.Fill(dtDialogos)

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally

        'End Try

        'For Each rw In dtDialogos.Rows
        '    Indice = DetectChanges(rw.item(9))
        '    'If lstEncontrados.Items.Count <> 0 Then
        'Next


        'For Each rw In dtNueva.Rows

        '    sqlstring = "UPDATE Det_Conversation SET Det_Orden = @Det_Orden"
        '    sqlstring = sqlstring & " WHERE Det_Con = @Det_Con"
        '    _comando.CommandText = sqlstring

        '    _comando.Parameters.Clear()
        '    _comando.Parameters.AddWithValue("@Det_Orden", j)
        '    _comando.Parameters.AddWithValue("@Det_Con", rw.item(0))

        '    Try
        '        i = _comando.ExecuteNonQuery

        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try

        '    j = j + 1

        'Next


        '_comando.Connection.Close()


        param = " Where d.Con_Id='" & Enc_Id & "'"
        param = param & " and l.Item='0' and d.status='R'" ' & STATUS & "'"
        param = param & " ORDER BY  d.Orden ASC, L.orden ASC"

        CargarDatos(param)

        ' CargarDatosDetalles()

        lblStatus.Text = " Guardado " & Format(Now, "hh:mm tt")

        FILASELECT = -1
        ProgressBar1.Value = 0

    End Sub

    Private Sub cmdContraido_Click(sender As System.Object, e As System.EventArgs) Handles cmdContraido.Click

        param = " Where d.Con_Id='" & Enc_Id & "'"
        param = param & " and l.Item='0' and d.status='R'" ' & STATUS & "'"
        param = param & " ORDER BY  d.Orden ASC, L.orden ASC"

        CargarDatos(param)

    End Sub

    Private Sub cmdMoverAqui_Click(sender As System.Object, e As System.EventArgs) Handles cmdMoverAqui.Click

        MoverDetalle(Enc_Id, ModVar.Conversacion)

    End Sub

    Private Sub LvwUnAssigned_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles LvwUnAssigned.SelectedIndexChanged

    End Sub

    Private Sub LvwUnAssigned_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles LvwUnAssigned.KeyUp
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim Sel As Integer
        Dim sqlstring As String

        If e.KeyCode = Keys.Q Then 'Eliminar de Oraciones

            Dim itemSel As ListViewItem = Nothing
            Dim i As Integer
            Dim param As String
            Dim IdDialogo As String
            Dim IdOracion As String

            itemSel = LvwUnAssigned.SelectedItems.Item(0)

            Sel = itemSel.Index

            IdDialogo = itemSel.SubItems(4).Text
            'IdOracion = itemSel.SubItems(0).Text

            sqlstring = "Delete FROM Tbl_Dialogos"
            sqlstring = sqlstring & " WHERE Id = @Id"

            _comando.CommandText = sqlstring

            _comando.Parameters.Clear()
            _comando.Parameters.AddWithValue("@Id", IdDialogo)

            _comando.Connection.Open()
            Try
                i = _comando.ExecuteNonQuery
            Catch ex As Exception
                MsgBox(ex.Message)
            Finally
            End Try

            _comando.Connection.Close()

            Dim itemNew As ListViewItem = Nothing
            itemNew = LvwAssigned.SelectedItems.Item(0)
            LvwUnAssigned.BeginUpdate()
            LvwUnAssigned.Items.Remove(itemNew)
            LvwUnAssigned.EndUpdate()

            Try
                LvwUnAssigned.Items(Sel).Selected = True
            Catch ex As Exception
            End Try

            'quitar beep
            e.SuppressKeyPress = True
            e.Handled = True


        End If



    End Sub

    Private Sub cmdDificil_Click(sender As System.Object, e As System.EventArgs) Handles cmdDificil.Click
        Dim param As String

        param = " Where d.Con_Id='" & Enc_Id & "'  and d.Status ='" & STATUS & "'"
        param = param & "  And l.Item='0' "


        If cmdDificil.Text = "Dificil" Then
            cmdDificil.Text = "Facil"
            ' param = param & "  And o.Nivel='N' "
            param = param & " ORDER BY  o.Dificultadscore DESC, o.Estructura DESC"

        Else
            cmdDificil.Text = "Dificil"
            'param = param & "  And o.Nivel='D' "
            param = param & " ORDER BY  o.Dificultadscore ASC, o.Estructura DESC"

        End If



        CargarDatos(param)
    End Sub

    Private Sub cboTipoOracion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipoOracion.SelectedIndexChanged
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, n As Integer

        Dim param As String

        LvwAssigned.Items.Clear()

        'Enc_Id = cboConversacionPrincipal.Items(cboConversacionPrincipal.SelectedIndex).ItemData()

        param = " Where d.Con_Id='" & Enc_Id & "'" & " And o.Tema='" & cboTipoOracion.Text & "'"
        ' param = param & " and d.status='" & STATUS & "' and " & " l.item='0'"
        param = param & " and l.item='0'"

        ' param = param & " ORDER BY d.orden ASC, l.Orden ASC, l.Item ASC"
        param = param & "  Order by o.NivelCEFR ASC"

        CargarDatos(param)


    End Sub

    Private Sub cmdConsulta_Click(sender As System.Object, e As System.EventArgs) Handles cmdConsulta.Click
        Dim param As String

        ' SELECT        EvaluacionFinal, frecuenciaEstructura, Clase, SimilitudTema, Tema, focoSemantico, SimilitudFoco, TextoPlano, Traduccion, EsObjeto, focoValido
        'ORDER BY frecuenciaEstructura DESC, SimilitudTema DESC

        param = " Where d.Con_Id='" & Enc_Id & "'  and o.SimilitudTema > 0.6"
        param = param & "  And l.Item='0' "
        param = param & "  order o.NivelCEFR ASC"


        'If cmdDificil.Text = "Dificil" Then
        '    cmdDificil.Text = "Facil"
        '    param = param & "  And o.Nivel='N' "
        'Else
        '    cmdDificil.Text = "Dificil"
        '    param = param & "  And o.Nivel='D' "

        'End If
        'param = param & " ORDER BY  o.score ASC"

        CargarDatos(param)


    End Sub

    Private Sub cboNaturalidad_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboNaturalidad.SelectedIndexChanged
        Dim naturalidad As String

        Dim param As String

        If cboNaturalidad.SelectedIndex <> -1 Then

            naturalidad = cboNaturalidad.Text

            param = " Where d.Con_Id='" & Enc_Id & "'  and o.NivelNaturalidad ='" & naturalidad & "'"
            param = param & " and d.status='" & STATUS & "'"
            param = param & "  And l.Item='0' "

            CargarDatos(param)

        End If



    End Sub

    Private Sub cmdAgregarDialogo_Click(sender As System.Object, e As System.EventArgs) Handles cmdAgregarDialogo.Click
        Dim frm As New frmTransferir
        Dim DetalleId As Integer


        If LvwAssigned.SelectedItems.Count > 0 Then
            DetalleId = LvwAssigned.SelectedItems.Item(0).SubItems(1).Text
        End If

        AddOwnedForm(frm)

            frm.IdDetalle = DetalleId
            frm.CargarDetalles(DetalleId)
            frm.MaxItem = LvwActual.Items.Count
            frm.ShowDialog()
            CargarDatosActual()

            Dim psi As New ProcessStartInfo()
            psi.FileName = "python"
            psi.Arguments = """C:\legacy\Programas\Voz_Natural\ActualizarUso.py"" "
            psi.UseShellExecute = False
            psi.RedirectStandardOutput = True
            psi.CreateNoWindow = True

            Dim p As Process = Process.Start(psi)
            Dim resultado As String = p.StandardOutput.ReadToEnd()
            p.WaitForExit()

        ' MessageBox.Show(resultado)


            'Dim param As String
            'param = " Where d.Con_Id='" & Enc_Id & "'"


    End Sub


    Private Sub cmdEstructura_Click(sender As System.Object, e As System.EventArgs) Handles cmdEstructura.Click
        Dim param As String

        param = " Where d.Con_Id='" & Enc_Id & "'  and d.Status ='" & STATUS & "'"
        param = param & "  And l.Item='0' "


        If bandEstructura = True Then
            bandEstructura = False
            ' param = param & "  And o.Nivel='N' "
            param = param & " ORDER BY  o.Estructura DESC"
        Else
            bandEstructura = True

            'param = param & "  And o.Nivel='D' "
            param = param & " ORDER BY  o.Estructura ASC"

        End If



        CargarDatos(param)
    End Sub

    Private Sub cmdCortesia_Click(sender As System.Object, e As System.EventArgs) Handles cmdCortesia.Click
        ' moverA(30091, "Saludo")
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, n As Integer
        Dim objDataReader As SqlDataReader

        sqlstring = "SELECT  Con_Id, Con_titulo"
        sqlstring = sqlstring & " FROM Enc_Conversation"
        sqlstring = sqlstring & " WHERE Con_titulo ='Politeness'"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        objDataReader = _comando.ExecuteReader

        If objDataReader.Read() Then
            _Id = objDataReader(0)
            objDataReader.Close()

            moverA(_Id, "")
        End If
    End Sub

    Private Sub cmdDespedida_Click(sender As System.Object, e As System.EventArgs) Handles cmdDespedida.Click
        ' moverA(30091, "Saludo")
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, n As Integer
        Dim objDataReader As SqlDataReader

        sqlstring = "SELECT  Con_Id, Con_titulo"
        sqlstring = sqlstring & " FROM Enc_Conversation"
        sqlstring = sqlstring & " WHERE Con_titulo ='Farewell'"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        objDataReader = _comando.ExecuteReader

        If objDataReader.Read() Then
            _Id = objDataReader(0)
            objDataReader.Close()

            moverA(_Id, "")
        End If
    End Sub

    Private Sub cmdDaily_Click(sender As System.Object, e As System.EventArgs) Handles cmdDaily.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, n As Integer
        Dim objDataReader As SqlDataReader

        sqlstring = "SELECT  Con_Id, Con_titulo"
        sqlstring = sqlstring & " FROM Enc_Conversation"
        sqlstring = sqlstring & " WHERE Con_titulo ='daily routine'"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        objDataReader = _comando.ExecuteReader

        If objDataReader.Read() Then
            _Id = objDataReader(0)
            objDataReader.Close()

            moverA(_Id, "")
        End If
    End Sub

    Private Sub cmdviaje_Click(sender As System.Object, e As System.EventArgs) Handles cmdviaje.Click
        'moverA(30090, "Clima")
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, n As Integer
        Dim objDataReader As SqlDataReader

        sqlstring = "SELECT  Con_Id, Con_titulo"
        sqlstring = sqlstring & " FROM Enc_Conversation"
        sqlstring = sqlstring & " WHERE Con_titulo ='Travel'"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        objDataReader = _comando.ExecuteReader

        If objDataReader.Read() Then
            _Id = objDataReader(0)
            objDataReader.Close()

            moverA(_Id, "")
        End If
    End Sub

    Private Sub cmdDialogo_Click(sender As System.Object, e As System.EventArgs) Handles cmdDialogo.Click
        'moverA(30090, "Clima")
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, n As Integer
        Dim objDataReader As SqlDataReader

        sqlstring = "SELECT  Con_Id, Con_titulo"
        sqlstring = sqlstring & " FROM Enc_Conversation"
        sqlstring = sqlstring & " WHERE Con_titulo ='Comunicacion'"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        objDataReader = _comando.ExecuteReader

        If objDataReader.Read() Then
            _Id = objDataReader(0)
            objDataReader.Close()

            moverA(_Id, "")
        End If
    End Sub

    Private Sub cmdInstruccion_Click(sender As System.Object, e As System.EventArgs) Handles cmdInstruccion.Click
        'moverA(30090, "Clima")
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, n As Integer
        Dim objDataReader As SqlDataReader

        sqlstring = "SELECT  Con_Id, Con_titulo"
        sqlstring = sqlstring & " FROM Enc_Conversation"
        sqlstring = sqlstring & " WHERE Con_titulo ='Instruccion'"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        objDataReader = _comando.ExecuteReader

        If objDataReader.Read() Then
            _Id = objDataReader(0)
            objDataReader.Close()

            moverA(_Id, "")
        End If
    End Sub

    Private Sub cmdDireccion_Click(sender As System.Object, e As System.EventArgs) Handles cmdDireccion.Click
        'moverA(30090, "Clima")
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, n As Integer
        Dim objDataReader As SqlDataReader

        sqlstring = "SELECT  Con_Id, Con_titulo"
        sqlstring = sqlstring & " FROM Enc_Conversation"
        sqlstring = sqlstring & " WHERE Con_titulo ='Direccion'"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        objDataReader = _comando.ExecuteReader

        If objDataReader.Read() Then
            _Id = objDataReader(0)
            objDataReader.Close()

            moverA(_Id, "")
        End If
    End Sub

    Private Sub cmdtiempo_Click(sender As System.Object, e As System.EventArgs) Handles cmdtiempo.Click
        'moverA(30090, "Clima")
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, n As Integer
        Dim objDataReader As SqlDataReader

        sqlstring = "SELECT  Con_Id, Con_titulo"
        sqlstring = sqlstring & " FROM Enc_Conversation"
        sqlstring = sqlstring & " WHERE Con_titulo ='Time'"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        objDataReader = _comando.ExecuteReader

        If objDataReader.Read() Then
            _Id = objDataReader(0)
            objDataReader.Close()

            moverA(_Id, "")
        End If
    End Sub

    Private Sub cmdConversacion_Click(sender As System.Object, e As System.EventArgs) Handles cmdConversacion.Click
        ' moverA(30091, "Saludo")
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, n As Integer
        Dim objDataReader As SqlDataReader

        sqlstring = "SELECT  Con_Id, Con_titulo"
        sqlstring = sqlstring & " FROM Enc_Conversation"
        sqlstring = sqlstring & " WHERE Con_titulo ='Dialogos'"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        objDataReader = _comando.ExecuteReader

        If objDataReader.Read() Then
            _Id = objDataReader(0)
            objDataReader.Close()

            moverA(_Id, "")
        End If
    End Sub

    Private Sub txtRespuesta_LostFocus(sender As Object, e As System.EventArgs) Handles txtRespuesta.LostFocus
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim i As Integer

        _comando.Connection.Open()

        _comando.Parameters.Clear()

        sqlstring = "UPDATE Det_Conversation SET Observaciones = @Observaciones"
        sqlstring = sqlstring & " WHERE Det_Con = @Det_Con"
        _comando.CommandText = sqlstring

        _comando.Parameters.AddWithValue("@Observaciones", txtRespuesta.Text)
        _comando.Parameters.AddWithValue("@Det_Con", detalleId)

        Try
            i = _comando.ExecuteNonQuery
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        _comando.Connection.Close()

    End Sub

    Private Sub txtRespuesta_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRespuesta.TextChanged

    End Sub


    Private Sub cmdPreguntas_Click(sender As System.Object, e As System.EventArgs) Handles cmdPreguntas.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, n As Integer
        Dim objDataReader As SqlDataReader

        sqlstring = "SELECT  Con_Id, Con_titulo"
        sqlstring = sqlstring & " FROM Enc_Conversation"
        sqlstring = sqlstring & " WHERE Con_titulo ='Preguntas_y_respuestas'"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        objDataReader = _comando.ExecuteReader

        If objDataReader.Read() Then
            _Id = objDataReader(0)
            objDataReader.Close()

            moverA(_Id, "")
        End If
    End Sub

    Private Sub LvwActual_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles LvwActual.SelectedIndexChanged

    End Sub

    Private Sub LvwActual_MouseWheel(sender As Object, e As System.Windows.Forms.MouseEventArgs) Handles LvwActual.MouseWheel

    End Sub

   
    Private Sub cmdOracionesFaciles_Click(sender As System.Object, e As System.EventArgs) Handles cmdOracionesFaciles.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim i, n As Integer
        Dim objDataReader As SqlDataReader

        sqlstring = "SELECT  Con_Id, Con_titulo"
        sqlstring = sqlstring & " FROM Enc_Conversation"
        sqlstring = sqlstring & " WHERE Con_titulo ='Oraciones_faciles'"

        _comando.CommandText = sqlstring
        _comando.Connection.Open()

        objDataReader = _comando.ExecuteReader

        If objDataReader.Read() Then
            _Id = objDataReader(0)
            objDataReader.Close()

            moverA(_Id, "")
        End If
    End Sub
End Class