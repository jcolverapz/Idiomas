Imports Entidades
Imports Negocios
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.IO
Imports SpeechLib
Imports System.Speech.Synthesis
Imports System
Imports System.Media
Imports System.Windows.Forms
Imports WMPLib

Public Class frmConversaciones

#Region "variables"
    Public contenedor As String
    Public sqlstring As String
    Public MaxColumna As Integer
    Public Titulo As String
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
    Public bandActivado As Boolean
    Public bandstop As Boolean
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
    Dim total As Integer
    Dim Cantidad As Integer
    Dim ListDialogos As New ListView
    Dim IdDetAnterior As Integer

    Dim Aprendidos As Integer


    Public traduccion As String = ""

    Public bandTimeValue As Boolean
    Public bandEstado As Boolean

    'Variables
    Public Id As Integer
    Public IdOracion As Integer
    Public paused As Boolean = False

    Public speechRate As Integer = -1 ' Rango desde -10 hasta 10 
    Public volume As Integer = 80 ' Rango desde 0 hasta 100.

    Dim objtextCurrent As RichTextBox
    Dim objtextOver As RichTextBox
    Dim objtextCurrentES As Label
    Dim objtextOverES As Label

    Dim IdCurrent As Integer
    Dim IdOver As Integer
    Dim pnlCurrent As String
    Dim pnlOver As String
    Dim n As Integer

    Public bandComplete As Boolean

    Public lstModificaciones As New ListView
    'Dim speech As New SpVoice '= New SpVoice()

    Dim speaker As New SpeechSynthesizer()
    ' Public Event SpeakCompleted As EventHandler(Of SpeakCompletedEventArgs)
    Public handler As EventHandler(Of SpeakCompletedEventArgs)
    ' Public handler2 As EventHandler(Of spee)
    'Private WithEvents speech As New SpVoice
    ' Dim voice As SpVoice = New SpVoice()
    Private WithEvents speech As New SpVoice
    Public Event SpeakCompleted As EventHandler(Of SpeakCompletedEventArgs)

#End Region
    'Private Player As New SoundPlayer
    'Private Player2 As New SoundPlayer
    Dim pVoice As ISpVoice = CType(speech, ISpVoice)


    Public texto As String
    Dim Player As WindowsMediaPlayer = New WindowsMediaPlayer
    Dim startIndex As Integer
    Dim length As Integer

    Public filename As String
    Dim rate As Double
    Dim volumen As Double
    Private WithEvents synth As New SpeechSynthesizer()

    Public Event SpeakWord As EventHandler(Of SpeakProgressEventArgs)
    Public band As Boolean
    Private hilo1 As Threading.Timer 'a
    Dim IdPanelSeleccionado As String = ""

    Private Sub voice_EndStream(StreamNumber As Integer, StreamPosition As Object) Handles speech.EndStream
        ' This event fires when an asynchronous speech stream has completed.
        'MessageBox.Show("Asynchronous speech completed.")

        ' objtextCurrent.BackColor = Color.Beige
        Try
            objtextCurrent.SelectAll()
            objtextCurrent.SelectionBackColor = Color.Beige

            objtextOver = objtextCurrent
            IdOver = IdCurrent
            pnlOver = pnlCurrent

            If Not IsNothing(objtextOver) Then
                'objtextOver.Font = New Font("Consolas", 11, FontStyle.Regular)
                objtextOver.BackColor = Color.Beige

            End If
        Catch ex As Exception

        End Try


        bandComplete = False

    End Sub
        'Private Sub SpeakButton_Click(sender As Object, e As EventArgs) Handles SpeakButton.Click
        '    synth.SpeakAsync(RichTextBox1.Text)
        'End Sub
        'Private Sub voice_Stream(StreamNumber As Integer, StreamPosition As Object) Handles speech.
        '    ' This event fires when an asynchronous speech stream has completed.
        '    'MessageBox.Show("Asynchronous speech completed.")
        '    objtextOver = objtextCurrent


        '    If Not IsNothing(objtextOver) Then
        '        'objtextOver.Font = New Font("Consolas", 11, FontStyle.Regular)
        '        objtextOver.BackColor = Color.Beige

        '    End If

        '    bandComplete = False

        'End Sub
        'If Player.playState = WMPLib.WMPPlayState.wmppsPlaying Then
        '    'Dim currentPosition As Double = Player.Ctlcontrols.currentPosition
        '    Dim currentPosition As Double = Player.controls.currentPosition

        '    ' Update text based on currentPosition as in the CurrentPositionChange example
        '    ' Assuming you have a RichTextBox named RichTextBox1
        '    ' Select the text you want to highlight
        '    Console.WriteLine("Current Position " & currentPosition)
        '    'RichTextBox1.Select(startIndex, length)
        '    RichTextBox1.Select(currentPosition, 10)

        '    ' Set the background color for the selected text
        '    RichTextBox1.SelectionBackColor = Color.Yellow
        'End If

#Region "Inicio"
    Private Sub frmConversaciones_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim test As Boolean

        'cargarDatos()
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        sqlstring = "select * from  Grupos_oracion "
        sqlstring = sqlstring & " ORDER By orden ASC"

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

        Dim i As Integer
        Dim n As Integer
        n = dt.Rows.Count

        Dim synth As New SpeechSynthesizer()


        cboTipo.Items.Add("ALL")
        cboTipo.Items.Add("Inicio")
        cboTipo.Items.Add("Saludo")
        cboTipo.Items.Add("Presentacion")
        cboTipo.Items.Add("Iniciando")
        cboTipo.Items.Add("Frases")
        cboTipo.Items.Add("Conversacion basica")
        cboTipo.Items.Add("Conversacion")
        cboTipo.Items.Add("Leccion")
        cboTipo.Items.Add("Leccion Nivel 1")
        cboTipo.Items.Add("Leccion Nivel 2")
        cboTipo.Items.Add("Serie")
        cboTipo.Items.Add("Grupo")
        cboTipo.Items.Add("Audios")

        'cboTipo.Text = "Saludo"
        Dim param As String
        param = " Where Inicio='S'"
        param = param & " ORDER By OrdenInicio desc"

        CrearControles(param)

    End Sub

    Public Sub CrearControles(param)
        Dim pAux As Panel
        Dim txtTexto As Label
        Dim txtCuenta As Label
        Dim txtCuentaDialogos As Label
        Dim txtFecha As Label
        Dim txtTraduccion As Label
        Dim descripcion As Label

        Dim btnSolution As Button
        Dim btnUp As Button
        Dim btnDown As Button
        Dim btnDelete As Button
        Dim btnHide As Button
        Dim btnEditar As Button
        Dim btnAprendido As Button
        Dim btnFalta As Button
        Dim btnExam As Button
        Dim btnMover As Button
        Dim btnEliminar As Button
        Dim btnLeer As Button
        Dim btnVoz As Button
        Dim btnTransferir As Button
        Dim btnMoverNuevo As Button
        Dim pbAvance As ColorProgressbar
        Dim yPos As Integer
    
        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
     
        Dim i As Integer
      
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String = ""

        sqlstring = "SELECT Con_Id, Con_orden, Con_Titulo, Con_Cant, Con_avance, Con_tipo, IMG, Inicio, OrdenInicio, url, observaciones"
        sqlstring = sqlstring & " from  Enc_Conversation"
        sqlstring = sqlstring & param

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)

            _comando.Connection.Close()

        Catch ex As Exception
            MsgBox(ex.Message)
            _comando.Connection.Close()

        End Try

        n = dt.Rows.Count

        yPos = 10

        i = 0

        pEtapa.Controls.Clear()

        Dim item As ListViewItem 'Creo el ListViewItem (item) 

        Dim List As New List(Of String)

        ' pEtapa.AutoScroll = True

        Dim person1 As Integer
        Dim person2 As Integer

        Dim p As PictureBox
        Dim pd As PictureBox
        Dim bmp As Bitmap
        Dim g As Graphics
        Dim nm As String
        Dim myPen As Pen
        Dim j As Integer

        Dim pb As PictureBox
        Dim pbf As PictureBox
        Dim pId As PictureBox

        Dim startPoint As Point
        Dim endPoint As Point ' La línea es horizontal si la coordenada Y es la misma
        ' Puntos para la punta de la flecha (triángulo)

        Dim m As Integer
        Dim previousHeight As Integer = 0
        Dim h As Integer
        Dim k As Integer
        Dim txtNo As Label
         
        pEtapa.AutoScroll = True
        ' pEtapa.AutoSize = True

        For Each rw In dt.Rows
 
            '''  Panel

            nm = rw.Item(0)

            If rw.Item(0) = 27641 Then

            End If

            pAux = New Panel
            pAux.Name = "pAux_" & nm
            pAux.Height = 230 '350 
            pAux.Width = 230

            ' pAux.Dock = DockStyle.Fill
            pAux.Location = New Point(0, 0)
            '  pAux.BackColor = Color.Beige
            pAux.BorderStyle = BorderStyle.FixedSingle
            ' pAux.VerticalScroll.Enabled = False
            pAux.AutoScroll = True

            AddHandler pAux.Click, AddressOf PanelSeleccionado
            AddHandler pAux.MouseDown, AddressOf Panel_MouseDown
            AddHandler pAux.MouseMove, AddressOf Panel_MouseMove
            AddHandler pAux.MouseUp, AddressOf Panel_MouseUp
            ' pAux.AutoScrollMinSize = New Size(1000, 0)
            'pAux.HorizontalScroll = True
            Try
                pEtapa.Controls.Add(pAux)
            Catch ex As Exception
            End Try


            'Foto  de Contexto
            p = New PictureBox
            p.Name = rw.Item(0)
            p.Height = 170 '250
            p.Width = 170 '250
            p.Cursor = Cursors.Hand

            If rw.Item(5) = "Leccion Nivel 1" Or rw.Item(5) = "Leccion Nivel 2" Then
                Try
                    p.Image = Image.FromFile("C:\Ingles\Encabezados\" & rw.Item(6))

                Catch ex As Exception
                    p.Image = Image.FromFile("C:\Ingles\Imagenes_Ingles\default.png")
                End Try
            Else
                Try
                    If Not IsDBNull(rw.Item(6)) Then
                        p.Image = Image.FromFile("C:\Ingles\Imagenes_Ingles\" & rw.Item(6))
                    Else
                        p.Image = Image.FromFile("C:\Ingles\Imagenes_Ingles\default.png")

                    End If
                Catch ex As Exception
                    p.Image = Image.FromFile("C:\Ingles\Imagenes_Ingles\vacio.jpg")
                End Try
            End If


            p.SizeMode = PictureBoxSizeMode.Zoom
            p.Location = New Point(10, 0.1)
            If Not IsDBNull(rw.Item(2)) Then
                p.Tag = rw.Item(2)
            Else

            End If
            AddHandler p.Click, AddressOf AbrirConversacion

            pAux.Controls.Add(p)

            'Mover
            txtTexto = New Label
            txtTexto.Name = "txt_" & rw.Item(0)
            ' txtTexto.Width = 25 : txtTexto.Height = 25
            txtTexto.AutoSize = True
            txtTexto.Location = New Point(p.Left, 175)
            If Not IsDBNull(rw.Item(2)) Then
                If rw.Item(5) = "leccion" Then
                    txtTexto.Text = "Leccion " & rw.Item(1)
                Else
                    txtTexto.Text = rw.Item(2)

                End If
            Else
                txtTexto.Text = "Sin descripcion"
            End If
            txtTexto.Tag = rw.Item(0)
            txtTexto.Font = New Font("Arial", 10, FontStyle.Regular)

            AddHandler txtTexto.Click, AddressOf Editar

            pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtTexto)


            'Mover
            descripcion = New Label
            descripcion.Name = "txtdescripcion_" & rw.Item(0)
            txtTexto.AutoSize = True
            ' descripcion.Width = 25 : descripcion.Height = 25 ': btnTask.Text = "Report"
            descripcion.Location = New Point(txtTexto.Left, txtTexto.Bottom + 1)
            If Not IsDBNull(rw.Item(10)) Then
                descripcion.Text = rw.Item(10)
            End If

            pEtapa.Controls.Item("pAux_" & nm).Controls.Add(descripcion)

            '========================
            ' Mover
            '========================
            txtCuenta = New Label
            txtCuenta.Name = "txtCuenta_" & rw.Item(0)

            txtCuenta.AutoSize = True
            txtCuenta.Text = rw.Item(3)
            txtCuenta.TextAlign = ContentAlignment.MiddleRight
            txtCuenta.Font = New Font("Arial Black", 11, FontStyle.Regular)

            ' AddHandler txtCuenta.Click, AddressOf Editar
            'txtCuenta.Location = New Point(pAux.Right - 5, 20)

            pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtCuenta)

            '==============================
            'Avance
            '==============================

            txtAvance = New Label
            txtAvance.Name = "txtAvance_" & rw.Item(0)

            txtAvance.AutoSize = True
            txtAvance.Text = Math.Round((rw.Item(4) * 100), 0) & "%"
            txtAvance.TextAlign = ContentAlignment.MiddleCenter
            'txtCuenta.Tag = rw.Item(0)
            txtAvance.Font = New Font("consolas", 11, FontStyle.Regular)

            ' AddHandler txtCuenta.Click, AddressOf Editar

            pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtAvance)

            pbAvance = New ColorProgressbar
            pbAvance.Name = "pbAvance_" & rw.Item(0)
            pbAvance.Maximum = 100
            pbAvance.Location = New Point(txtTexto.Left - 1, txtTexto.Bottom + 0.5)
            pbAvance.Dock = DockStyle.Bottom
            pbAvance.Height = 10
            Dim avance As Double
            avance = rw.Item(4) * 100
            pbAvance.Value = avance
            ' pbAvance.Tag = rw.Item(0)
            ' pbAvance.Font = New Font("Arial", 12, FontStyle.Regular)
            If avance = 0 Then
                pbAvance.BarColor = Color.Red
                txtAvance.ForeColor = Color.Red

                pbAvance.Value = 5
            ElseIf avance > 0 And avance < 100 Then
                pbAvance.BarColor = Color.Gold
                txtAvance.ForeColor = Color.Olive
                'ElseIf avance > 75 And avance < 90 Then
                ' pbAvance.BarColor = Color.Green

            Else
                pbAvance.BarColor = Color.Chartreuse
                txtAvance.ForeColor = Color.Green

            End If

            txtAvance.Location = New Point(p.Right + 0.5, pbAvance.Top - 0.5)
            txtCuenta.Location = New Point(p.Right + 0.5, 1)

            ' AddHandler txtTexto.Click, AddressOf Editar

            pEtapa.Controls.Item("pAux_" & nm).Controls.Add(pbAvance)

            i = i + 1

        Next

        Try
            If IdPanelSeleccionado <> "" Then
                pEtapa.Controls(IdPanelSeleccionado).BackColor = Color.LightGreen

            End If
        Catch ex As Exception
        End Try

    End Sub

#End Region

#Region "Paneles"
    Dim arrastrando As Boolean
    Dim offset As Point
    Dim panelActual As Panel

    Private Sub Panel_MouseDown(sender As Object, e As MouseEventArgs)
        Dim pnl As Panel = CType(sender, Panel)
        pnl.DoDragDrop(pnl, DragDropEffects.Move)
    End Sub

    Private Sub Panel_MouseMove(sender As Object, e As MouseEventArgs)
        If arrastrando Then
            panelActual.Left += e.X - offset.X
            panelActual.Top += e.Y - offset.Y
        End If
    End Sub

    Private Sub Panel_MouseUp(sender As Object, e As MouseEventArgs)
        arrastrando = False
    End Sub
    Private Sub pEtapa_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles pEtapa.DragEnter
        e.Effect = DragDropEffects.Move
    End Sub
    Private Sub pEtapa_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles pEtapa.DragDrop
        Dim draggedPanel As Panel = CType(e.Data.GetData(GetType(Panel)), Panel)
        Dim punto As Point = pEtapa.PointToClient(New Point(e.X, e.Y))
        Dim destino As Control = pEtapa.GetChildAtPoint(punto)

        If destino IsNot Nothing AndAlso destino IsNot draggedPanel Then
            Dim indexDestino As Integer = pEtapa.Controls.GetChildIndex(destino)
            pEtapa.Controls.SetChildIndex(draggedPanel, indexDestino)
        End If
         
        'PuntoDestino = pEtapa.Controls.Count - pEtapa.Controls.GetChildIndex(destino) - 1
        'Actualizar orden en SQL
        ' ActualizarOrdenSQL()

    End Sub

  
    Private Sub ActualizarOrdenSQL()

        Dim sql As String
        Dim orden As Integer = 1
        Dim j As Integer
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        ' Dim indexDestino As Integer = pEtapa.Controls.GetChildIndex(Destino)
        _comando.Connection.Open()

        Dim str() As String

        sqlstring = "UPDATE  Enc_Conversation SET ordenInicio = @ordenInicio"
        sqlstring = sqlstring & " WHERE Con_Id = @Con_Id"
        _comando.CommandText = sqlstring

        _comando.Parameters.Clear()
        _comando.Parameters.AddWithValue("@ordenInicio", orden)
        _comando.Parameters.AddWithValue("@Con_Id", Id)

        For i As Integer = 0 To pEtapa.Controls.Count - 1

            Dim pnl As Panel = CType(pEtapa.Controls(pEtapa.Controls.Count - 1 - i), Panel)

            str = pnl.Name.Split("_")

            Id = str(1)

            _comando.Parameters("@ordenInicio").Value = orden
            _comando.Parameters("@Con_Id").Value = Id

            Try
                j = _comando.ExecuteNonQuery

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            orden += 1
        Next


        'Dim tipo As String
        'Dim param As String = ""
        'Dim indice As Integer
        'Dim PuntoDestino As Integer
        '' PuntoDestino = pEtapa.Controls.GetChildIndex(destino, False)
        '' Dim PuntoDestino As Integer
        'PuntoDestino = pEtapa.Controls.Count - pEtapa.Controls.GetChildIndex(Destino, False) - 1
        'Dim pnlArrastrado As Panel = CType(panelArrastrado, Panel)
        ''Dim IdDialogo As Integer = pnlArrastrado.Tag
        'Dim NuevoOrden As Integer = PuntoDestino + 1




    End Sub
    Private Sub CmdGuardar_Click(sender As System.Object, e As System.EventArgs) Handles CmdGuardar.Click
        ActualizarOrdenSQL()
    End Sub
#End Region

#Region "Controles"

    Private Sub AbrirConversacion(sender As PictureBox, e As MouseEventArgs)
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim TipoTicket As String
        Dim titulo As Label
        Dim p As PictureBox
        Dim q As Integer
        Dim Str() As String

        Str = sender.Name.Split("_")

        Dim tipo As String
        Dim param As String = ""
        Dim indice As Integer

        Id = sender.Name

        'Dim str() As String
        Str = sender.Name.Split("_")

        '  Dim tipo As String
        'Dim param As String = ""
        ' Dim indice As Integer

        ' Id = str(1)

        IdPanelSeleccionado = sender.Parent.Name
        ' Resetear todos los paneles hijos
        For Each ctrl As Control In pEtapa.Controls
            If TypeOf ctrl Is Panel Then
                ctrl.BackColor = Color.White
            End If
        Next

        ' Pintar el seleccionado
        Dim pnl As Panel = CType(sender.Parent, Panel)
        pnl.BackColor = Color.LightGreen

        If e.Button = Windows.Forms.MouseButtons.Right Then

            Dim frmOrdenar As New frmMoverDetalleConversacion
            AddOwnedForm(frmOrdenar)
            frmOrdenar.Enc_Id = Id
            ModVar.Conversacion = sender.Tag
            frmOrdenar.ShowDialog()

            'cboTipo.Text = "Saludo"
            param = " Where Inicio='S'"
            param = param & " ORDER By OrdenInicio ASC"

            '  CrearControles(param)

            Exit Sub

        End If


        Using frm As New frmEscenas
            AddOwnedForm(frm)

            ' tipo = Str(0)
            ' indice = Str(1)

            titulo = pEtapa.Controls.Item("pAux_" & Id).Controls.Item("txt_" & Id)


            frm.Id = Id
            frm.Titulo = titulo.Text
            frm.Imagen = sender.Tag

            'Try
            frm.ShowDialog()

            ' Catch ex As Exception
            'MsgBox(ex.Message)
            'End Try
            If cboTipo.Text <> "" Then
                param = " Where Con_Tipo='" & cboTipo.Text & "'"

            End If
        End Using

       



    End Sub
    Private Sub PanelSeleccionado(sender, e)
        Dim str() As String
        Str = sender.Name.Split("_")

        Dim tipo As String
        Dim param As String = ""
        Dim indice As Integer

        Id = str(1)

        IdPanelSeleccionado = sender.Name
        ' Resetear todos los paneles hijos
        For Each ctrl As Control In pEtapa.Controls
            If TypeOf ctrl Is Panel Then
                ctrl.BackColor = Color.White
            End If
        Next

        ' Pintar el seleccionado
        Dim pnl As Panel = CType(sender, Panel)
        pnl.BackColor = Color.LightGreen

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

        Dim fecha As Date
        Dim fechaEntrega As Date
        Dim avance As Double

        _comando.Connection.Open()

        _comando.Parameters.Clear()

        sqlstring = "UPDATE Enc_Conversation SET Con_Cant = @Con_Cant, Con_aprendidos = @Con_aprendidos, Con_avance = @Con_avance"
        sqlstring = sqlstring & " WHERE Con_Id = @Con_Id"

        _comando.Parameters.AddWithValue("@Con_Cant", n)
        _comando.Parameters.AddWithValue("@Con_aprendidos", a)
        Try
            avance = (a / n) ' * 100
        Catch ex As Exception
            avance = 0
        End Try
        If avance >= 0 Then
        Else
            avance = 0
        End If
        _comando.Parameters.AddWithValue("@Con_avance", avance)

        _comando.CommandText = sqlstring

        _comando.Parameters.AddWithValue("@Con_Id", Id)
        Try
            i = _comando.ExecuteNonQuery

        Catch ex As Exception
            ' MsgBox(ex.Message)
        End Try

        _comando.Connection.Close()

    End Sub
        
        Private Sub MoveDown(sender, e)
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sqlstring As String
            Dim IdOracion As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim pos As Integer
            Dim n As Integer

            Dim itemOver As ListViewItem
            Dim itemCurr As ListViewItem
            Dim itemSel As Integer
            Dim indice As Integer
            Dim nm As String
            Dim str() As String

            Dim q As Integer

            ' Dim resp As Nullable(Of Integer)
            nm = sender.name
            str = nm.Split("_")
            Dim tp As String
            Dim param As String = ""

            tp = str(0)
            indice = str(1)


        'n = ListView1.Items.Count

            If indice = -1 Then Exit Sub

        '
        ' itemCurr = ListView1.Items(indice)


        'If indice = ListView1.Items.Count - 1 Then

        'ListView1.Items.Remove(itemCurr)

        '    Else

        'If indice >= ListView1.Items.Count - 1 Then

        '    ListView1.Items.Remove(itemCurr)

        'Else

        '    ListView1.Items.Remove(itemCurr)
        '    ListView1.Items.Insert(indice + 1, itemCurr)

        'End If


        '    End If
        'ListView1.Refresh()

        _comando.Connection.Open()

       
        If i > 0 Then
        Else
            MsgBox("No se actualizo")
        End If
        'Bitacora
        'IdOracion = lstOraciones.SelectedItems(0).Text


        CrearControles("")

        '_comando.CommandText = sqlstring

        'Try

        '    i = _comando.ExecuteNonQuery

        '    If i > 0 Then
        '        MsgBox("se guardo")
        '    Else
        '        MsgBox("No se guardo")
        '    End If

        '    CrearControles()

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        'Finally

        'End Try
        End Sub
        Private Sub MoveUp(sender, e)
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sqlstring As String
            Dim IdOracion As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim indice As Integer
            Dim itemCurr As ListViewItem
            Dim itemOver As ListViewItem
            Dim itemSel As Integer
            Dim nm As String
            Dim str() As String
            Dim tp As String
            Dim param As String = ""
            Dim q As Integer

            ' Dim resp As Nullable(Of Integer)
            nm = sender.name
            str = nm.Split("_")

            tp = str(0)
            indice = str(1)

        'itemCurr = ListView1.Items(indice)


            'If indice = ListView1.Items.Count - 1 Then

            'ListView1.Items.Remove(itemCurr)
            '   If ListView1.SelectedItems(0).Index = -1 Then Exit Sub

            '  indice = ListView1.SelectedItems(0).Index
            'itemCurr = ListView1.SelectedItems(0)
            'itemCurr = ListView1.Items(indice)

        'If indice = ListView1.Items.Count - 1 Then
        '    ListView1.Items.Remove(itemCurr)
        '    ListView1.Items.Insert(indice - 1, itemCurr)
        'Else

        '    If indice = 0 Then
        '        ' ListView1.Items.Remove(itemCurr)
        '    Else
        '        ListView1.Items.Remove(itemCurr)
        '        ListView1.Items.Insert(indice - 1, itemCurr)
        '    End If
        'End If

        'ListView1.Refresh()


            _comando.Connection.Open()


            'If i > 0 Then
            '    MsgBox("se guardo")
            'Else
            '    MsgBox("No se guardo")
            'End If

        CrearControles("")




        End Sub
        Private Sub Delete(sender, e)
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sqlstring As String
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

            nm = sender.name
            str = nm.Split("_")

            tp = str(0)
            IdDialogo = str(1)

            sqlstring = "Delete From Dialogos "
            sqlstring = sqlstring & "  WHERE Id = '" & IdDialogo & "'"

            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            Dim PanelId As Integer
            PanelId = sender.tag
            Try

                i = _comando.ExecuteNonQuery

                If i > 0 Then
                    'MsgBox("se guardo")
                Else
                    'MsgBox("No se guardo")
                End If



            Catch ex As Exception
                MsgBox(ex.Message)

            Finally
                ' _comando.Connection.Close()

            End Try



            '  _comando.Connection.Open()

            sqlstring = "SELECT * FROM Dialogos"
            sqlstring = sqlstring & " WHERE DetConversacion = @DetConversacion"
            _comando.CommandText = sqlstring

            _comando.Parameters.Clear()
            _comando.Parameters.AddWithValue("@DetConversacion", PanelId)
            Try
                da.SelectCommand = _comando
                da.Fill(dt)
                ' _comando.Connection.Close()
            Catch ex As Exception
            End Try

            '_comando.Connection.Open()
            n = dt.Rows.Count
            Dim j As Integer = 0
            For Each r In dt.Rows

                sqlstring = "UPDATE Dialogos SET Orden = @Orden"
                sqlstring = sqlstring & " WHERE Id = @Id"
                _comando.CommandText = sqlstring
                _comando.Parameters.Clear()

                _comando.Parameters.AddWithValue("@Orden", j)
                ' _comando.Parameters.AddWithValue("@Id", r.SubItems(1).Text)
                _comando.Parameters.AddWithValue("@Id", r.item(0))


                Try
                    i = _comando.ExecuteNonQuery

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                j += 1
            Next

            _comando.Connection.Close()

            Dim objp As PictureBox

            objp = pEtapa.Controls(sender.parent.name).Controls("p_" & IdDialogo)
            objp.Image = Image.FromFile("C:\Legacy\Ingles\Imagenes_Ingles\X.jpg")
            'pEtapa.Controls(sender.parent.name).Controls.Invalidate()

            'CrearControles()
            ''''''''''










        End Sub
        Private Sub Editar(sender, e)
            

            Dim nm As String
            Dim tp As String

            Dim q As Integer
            Dim obj As New Label
            Dim IdDet As Integer
            
            Dim IdOracionItem As Integer

        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim Id As Integer
            Dim TipoTicket As String
            Dim frm As New frmDetConversation
            Dim str() As String
            str = sender.name.Split("_")

            Dim tipo As String
            Dim param As String = ""
            Dim indice As Integer

            tipo = str(0)
            indice = str(1)
            AddOwnedForm(frm)

            ' sqlstring = " SELECT Tbl_Devices.,  Tbl_Devices., Tbl_Devices., Tbl_Devices."

            ' Id = sender.name


            frm.Id = indice
            'frm.lbltitulo.Text = dgvOraciones.CurrentRow.Cells(1).Value.ToString()
            frm.CargarDatos(indice)
            frm.ShowDialog()

            ' CrearControles("")

        End If

        End Sub
        Private Sub RefreshTexto(sender, e)
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sqlstring As String
            Dim IdOracion As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim indice As Integer
            Dim nm As String
            Dim str() As String
            Dim tp As String
            Dim param As String = ""
            Dim q As Integer
            Dim obj As New RichTextBox

            obj = sender

            nm = sender.Name

            str = nm.Split("_")

            tp = str(0)

            indice = str(1)

            If Id <> 0 Then
                sqlstring = " SELECT         Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Det_Conversation.Det_Orden, Det_Conversation.Con_Id, Oraciones.TextoPlano, Det_Person, Det_Par, Oraciones.traduccion"
                sqlstring = sqlstring & " FROM            Det_Conversation INNER JOIN"
                sqlstring = sqlstring & "              Oraciones ON Det_Conversation.Det_OracionId = Oraciones.Id"
                sqlstring = sqlstring & " WHERE  Det_Conversation.Det_Con='" & str(1) & "'"
                sqlstring = sqlstring & " ORDER BY  Det_Conversation.Det_Orden ASC"

                Try
                    _comando.CommandText = sqlstring

                    _comando.Connection.Open()

                    'i = _comando.ExecuteNonQuery
                    da.SelectCommand = _comando

                    da.Fill(dt)
                Catch ex As Exception

                End Try
                _comando.Connection.Close()
                'SELECT        TOP (200) [Delete], SEL, estatus, GrupoId, forma, STL, GRUPO, IMG, Orden, IPA, Campo3, , CursoId, Ora_Aprendido, Exam, Cuenta, Persona
                'FROM(Oraciones)
                'WHERE(Id = 3000)
            Else
                sqlstring = "select  Id, TextoPlano FROM Oraciones"
                sqlstring = sqlstring & " WHERE Id = @Id"

                _comando.Parameters.AddWithValue("@Id", indice)

                _comando.CommandText = sqlstring
                _comando.Connection.Open()

                Try
                    da.SelectCommand = _comando

                    da.Fill(dt)
                    obj.Text = dt.Rows(0).Item(1)

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                _comando.Connection.Close()


            End If




            Try
                'txtNombre.Text = dt.Rows(i).Item(4) '& " " & dt.Rows(i).Item(1) '& vbCrLf & vbCrLf & dt.Rows(i).Item(3)

                If i > 0 Then
                    'MsgBox("se guardo")
                    'obj.Image = ImageList5.Images(IdPerson)
                    'obj.Text = "test"

                Else
                    'MsgBox("No se guardo")
                End If
            Catch ex As Exception

            End Try


        End Sub
        Private Sub Show(sender, e)
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sqlstring As String
            Dim IdOracion As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim indice As Integer
            Dim nm As String
            Dim str() As String
            Dim tp As String
            Dim param As String = ""
            Dim q As Integer

            ' Dim resp As Nullable(Of Integer)
            nm = sender.name
            str = nm.Split("_")

            tp = str(0)
            IdOracion = str(1)


            If sender.text = "-" Then
                pEtapa.Controls.Item("pAux_" & IdOracion).Controls.Item("txt_" & IdOracion).Visible = False
                pEtapa.Controls.Item("pAux_" & IdOracion).Controls.Item("tra_" & IdOracion).Visible = False
                'bandActivado = False
                sender.text = "?"

            Else
                pEtapa.Controls.Item("pAux_" & IdOracion).Controls.Item("txt_" & IdOracion).Visible = True
                pEtapa.Controls.Item("pAux_" & IdOracion).Controls.Item("tra_" & IdOracion).Visible = True
                sender.text = "-"
                'bandActivado = True
            End If


        End Sub
        Private Sub Exam(sender, e)
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sqlstring As String
            Dim IdOracion As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim indice As Integer
            Dim nm As String
            Dim str() As String
            Dim tp As String
            Dim param As String = ""
            Dim q As Integer
            Dim obj As New Label
            Dim mypen As Pen

            nm = sender.Name

            str = nm.Split("_")
            tp = str(0)

            IdOracion = str(1)

            If UCase(sender.text) = UCase(pEtapa.Controls.Item("pAux_" & IdOracion).Controls.Item("txt_" & IdOracion).Text) Then
                sender.forecolor = Color.DarkGreen
                sender.font = New Font("Consolas", 11, FontStyle.Bold)
                ' objtext.Font = New Font("arial", 12, FontStyle.Bold)
            Else
                sender.forecolor = Color.DarkRed
                sender.font = New Font("Consolas", 11, FontStyle.Bold)


            End If



        End Sub
        Private Sub ExamES(sender, e)
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sqlstring As String
            Dim IdOracion As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim indice As Integer
            Dim nm As String
            Dim str() As String
            Dim tp As String
            Dim param As String = ""
            Dim q As Integer
            Dim obj As New Label
            Dim mypen As Pen

            nm = sender.Name

            str = nm.Split("_")
            tp = str(0)

            IdOracion = str(1)

            If UCase(sender.text) = UCase(pEtapa.Controls.Item("pAux_" & IdOracion).Controls.Item("tra_" & IdOracion).Text) Then
                sender.forecolor = Color.DarkGreen
                sender.font = New Font("Consolas", 11, FontStyle.Bold)
                ' objtext.Font = New Font("arial", 12, FontStyle.Bold)
            Else
                sender.forecolor = Color.DarkRed
                sender.font = New Font("Consolas", 11, FontStyle.Bold)


            End If



        End Sub
        Private Sub SeleccionarPersona(sender, e)
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sqlstring As String
            Dim IdDet As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim indice As Integer
            Dim IdDialogo As Integer
            Dim nm As String
            Dim str() As String
            Dim tp As String
            Dim param As String = ""
            Dim q As Integer
            Dim IdPanel As Integer

            IdPanel = sender.tag
            nm = sender.name
            str = nm.Split("_")

            tp = str(0)
            IdDialogo = str(1)

            Dim Id As Integer
            Dim IdPerson As Integer
            Dim TipoTicket As String

            Dim resp As Integer
            Dim obj As PictureBox

            'obj = sender

          
            ' resp = MsgBox("Confirmar?", MsgBoxStyle.YesNo)
            'If resp = 6 Then

            sqlstring = "Update Dialogos SET voice='" & IdPerson & "'"
            sqlstring = sqlstring & "  WHERE Id = '" & IdDialogo & "'"

            _comando.CommandText = sqlstring
            _comando.Connection.Open()


            Try
                i = _comando.ExecuteNonQuery

                If i > 0 Then
                    'MsgBox("se guardo")
                    'obj.Image = ImageList5.Images(IdPerson)

                Else
                    'MsgBox("No se guardo")
                End If
            Catch ex As Exception

            End Try

            pEtapa.Controls.Item(sender.parent.name).Controls("p_" & IdDialogo).Tag = IdPerson
            pEtapa.Controls.Item(sender.parent.name).Controls("btnVoz_" & IdDialogo).text = IdPerson


        End Sub
        Private Sub SeleccionarPersonaRandom(sender, e)
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sqlstring As String
            Dim IdDet As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim indice As Integer
            Dim nm As String
            Dim str() As String
            Dim tp As String
            Dim param As String = ""
            Dim q As Integer

            nm = sender.name
            str = nm.Split("_")

            tp = str(0)
            IdDet = str(1)

            Dim Id As Integer
            Dim IdPerson As Integer
            Dim TipoTicket As String

            Dim resp As Integer
            Dim obj As PictureBox

            obj = sender

            ' If cmbPersona.Text = "" Then Exit Sub

            '   IdPerson = cmbPersona.SelectedIndex

            sqlstring = "Update Oraciones SET Persona='" & IdPerson & "'"
            sqlstring = sqlstring & "  WHERE Id = '" & IdDet & "'"

            _comando.CommandText = sqlstring
            _comando.Connection.Open()


            Try
                i = _comando.ExecuteNonQuery

                If i > 0 Then
                    'MsgBox("se guardo")
                    obj.Image = ImageList5.Images(IdPerson)

                Else
                    'MsgBox("No se guardo")
                End If
            Catch ex As Exception

            End Try

            pEtapa.Controls.Item("pAux_" & IdDet).Controls("p_" & IdDet).Tag = IdPerson


        End Sub
        Private Sub CambiarColor(sender, e)
            Dim objtext As New Label
            Dim n As String
            n = sender.name

            'objtext = pEtapa.Controls.Item("pAux" & n).Controls.Item("txt" & n)
            objtext = pEtapa.Controls.Item("pAux0").Controls.Item("txt0")
            ' objtext.ForeColor= color.
            objtext.Font = New Font("arial", 12, FontStyle.Bold)
            ' obj.Font = New Font("arial", 12, FontStyle.Bold)
        End Sub
        Private Sub SaveExam(sender, e)
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sqlstring As String
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim indice As Integer
            Dim nm As String
            Dim str() As String
            Dim tp As String
            Dim param As String = ""
            Dim q As Integer
            Dim btnStatus As Button
            Dim IdDet As Integer
            Dim IdOracionItem As Integer

            nm = sender.Name
            str = nm.Split("_")
            tp = str(0)

            IdDet = str(1)

            sqlstring = " SELECT         Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Oraciones.STL"
            sqlstring = sqlstring & " FROM            Det_Conversation INNER JOIN Oraciones"
            sqlstring = sqlstring & "              Oraciones ON Det_Conversation.Det_OracionId = Oraciones.Id"
            sqlstring = sqlstring & " WHERE  Det_Conversation.Det_Con='" & IdDet & "'"

            Dim objDataReader As SqlDataReader

            Try
                _comando.CommandText = sqlstring

                _comando.Connection.Open()

            Catch ex As Exception

            End Try

            Try
                objDataReader = _comando.ExecuteReader

                If objDataReader.HasRows Then

                    objDataReader.Read()

                    IdOracionItem = objDataReader(1)
                Else
                    IdOracionItem = IdDet
                End If

            Catch ex As Exception

            End Try
            _comando.Connection.Close()



            Dim Exam As String
            Exam = pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("tst_" & IdDet).Text


            Try


                sqlstring = "UPDATE Oraciones SET  Exam = @Exam"
                sqlstring = sqlstring & " WHERE Id = @Id"

                _comando.Parameters.AddWithValue("@Id", IdOracionItem)
                _comando.Parameters.AddWithValue("@Exam", Exam)

                _comando.CommandText = sqlstring
                _comando.Connection.Open()

                Try
                    i = _comando.ExecuteNonQuery

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                _comando.Connection.Close()



                If i > 0 Then
                Else
                    MsgBox("no se guardo")

                End If
            Catch ex As Exception

            End Try



            '    If i > 0 Then
            '    Else
            '        'MsgBox("No se guardo")
            '    End If

            '    CrearControles()

            'Catch ex As Exception
            '    MsgBox(ex.Message)
            '    _comando.Connection.Close()

            'Finally

            'End Try
        End Sub
        Private Sub SaveExamES(sender, e)
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sqlstring As String
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim indice As Integer
            Dim nm As String
            Dim str() As String
            Dim tp As String
            Dim param As String = ""
            Dim q As Integer
            Dim btnStatus As Button
            Dim IdDet As Integer
            Dim IdOracionItem As Integer

            nm = sender.Name
            str = nm.Split("_")
            tp = str(0)

            IdDet = str(1)

            sqlstring = " SELECT         Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Oraciones.STL"
            sqlstring = sqlstring & " FROM            Det_Conversation INNER JOIN Oraciones"
            sqlstring = sqlstring & "              Oraciones ON Det_Conversation.Det_OracionId = Oraciones.Id"
            sqlstring = sqlstring & " WHERE  Det_Conversation.Det_Con='" & IdDet & "'"

            Dim objDataReader As SqlDataReader

            Try
                _comando.CommandText = sqlstring

                _comando.Connection.Open()

            Catch ex As Exception

            End Try

            Try
                objDataReader = _comando.ExecuteReader

                If objDataReader.HasRows Then

                    objDataReader.Read()

                    IdOracionItem = objDataReader(1)
                Else
                    IdOracionItem = IdDet
                End If

            Catch ex As Exception

            End Try
            _comando.Connection.Close()



            Dim ExamES As String
            ExamES = pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("tstES_" & IdDet).Text


            Try


                sqlstring = "UPDATE Oraciones SET  ExamES = @ExamES"
                sqlstring = sqlstring & " WHERE Id = @Id"

                _comando.Parameters.AddWithValue("@Id", IdOracionItem)
                _comando.Parameters.AddWithValue("@ExamES", ExamES)

                _comando.CommandText = sqlstring
                _comando.Connection.Open()

                Try
                    i = _comando.ExecuteNonQuery

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                _comando.Connection.Close()



                If i > 0 Then
                Else
                    MsgBox("no se guardo")

                End If
            Catch ex As Exception

            End Try

        End Sub
        Private Sub StatusControl(sender, e)
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sqlstring As String
            'Dim IdOracion As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim indice As Integer
            Dim nm As String
            Dim str() As String
            Dim tp As String
            Dim param As String = ""
            Dim q As Integer
            Dim btnStatus As Button
            ' Dim IdDet As Integer
            Dim IdDet As Integer
            Dim IdDialogo As Integer
            Dim IdOracionItem As Integer
            Dim mypen As Pen
            Dim CuentaOracion As Integer

            nm = sender.Name
            str = nm.Split("_")
            tp = str(0)

            IdDet = sender.tag
            IdDialogo = str(1)

            sqlstring = " SELECT          Dialogos.Id, Dialogos.OracionId, Dialogos.Orden, Dialogos.DetConversacion, Dialogos.IMG, Oraciones.CuentaSTL"
            sqlstring = sqlstring & " FROM            Dialogos INNER JOIN"
            sqlstring = sqlstring & "                    Oraciones ON Dialogos.Id = Oraciones.Id"
            sqlstring = sqlstring & " WHERE  Dialogos.Id='" & IdDialogo & "'"

            Dim objDataReader As SqlDataReader

            Try
                _comando.CommandText = sqlstring

                _comando.Connection.Open()

            Catch ex As Exception

            End Try

            Try
                objDataReader = _comando.ExecuteReader

                If objDataReader.HasRows Then

                    objDataReader.Read()

                    IdOracionItem = objDataReader(1)
                    CuentaOracion = objDataReader(5)

                Else
                    IdOracionItem = IdDet

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            _comando.Connection.Close()

            Dim CuentaSTL As Integer


            Dim Exam As String
            ' Exam = pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txt_" & IdDialogo).Text

            Try
                Dim Cuenta As Integer

                If sender.text = "F" Then
                    '  sender.backcolor = Color.LightGreen
                    ' sender.text = "SI"
                    Aprendidos += 1
                    'pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("tst_" & IdDet).BackColor = Color.LightGreen
                    CuentaSTL -= 1

                Else
                    'sender.backcolor = Color.LightSalmon
                    'sender.text = "NO"
                    Aprendidos = 1
                    'pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("tst_" & IdDet).BackColor = Color.LightSalmon
                    CuentaSTL += 1

                End If

                'Cuenta = pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txtc_" & IdDet).Text
                CuentaSTL += Cuenta

                If CuentaSTL <= 0 Then
                    mypen = New Pen(Color.LightSalmon, 2)
                    Status = False
                    ' pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("btnStatus_" & IdDet).BackColor = Color.Yellow
                    ' pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txtc_" & IdDet).Visible = False

                Else
                    Status = True
                    mypen = New Pen(Color.LimeGreen, 2)
                    ' pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("btnStatus_" & IdDialogo).BackColor = Color.Transparent
                    ' pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txtc_" & IdDialogo).Visible = True

                End If

                sqlstring = "UPDATE Oraciones SET STL = @STL, CuentaSTL=@CuentaSTL"
                sqlstring = sqlstring & " WHERE Id = @Id"

                _comando.Parameters.AddWithValue("@Id", IdOracionItem)
                _comando.Parameters.AddWithValue("@STL", Status)
                _comando.Parameters.AddWithValue("@CuentaSTL", CuentaSTL)


                _comando.CommandText = sqlstring
                _comando.Connection.Open()

                Try
                    i = _comando.ExecuteNonQuery

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                _comando.Connection.Close()


                If i > 0 Then
                Else
                    'MsgBox("No se guardo")
                End If
            Catch ex As Exception

            End Try

            Dim pb As PictureBox
            Dim bmp As Bitmap
            Dim g As Graphics

            Dim obj As PictureBox
            ' PictureBox1()
            'pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("pb_" & IdDialogo).Invalidate()
            obj = pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("pb_" & IdDialogo)
            obj.Image = Nothing
            ' obj.CreateGraphics.DrawRectangle(mypen, 0, 0, 252, 252)
            'obj.Refresh()
            '  pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("pb_" & IdDialogo).CreateGraphics.DrawRectangle(mypen, 0, 0, 252, 252)
            ' pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txtc_" & IdDialogo).Text = CuentaSTL

            ' ''Recuadro de color
            ' pb = New PictureBox
            ' pb.Name = "pb_" & dtDialogos.Rows(j).Item(0)
            ' pb.Width = 255
            ' pb.Height = 255
            bmp = New Bitmap(255, 255)
            obj.Image = bmp

            ' g.DrawRectangle(myPen, p.Location.X, p.Location.Y, 350, 350)

            'g = Graphics.FromImage(pb.Image)
            g = Graphics.FromImage(obj.Image)
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            ' Dim rect As New Rectangle(0, 0, 252, 252)
            ' g.DrawRectangle(myPen, 0, 0, 252, 252)
            g.DrawRectangle(mypen, 0, 0, 252, 252)
            'g.DrawRectangle(myPen, rect)
            ' obj.Location = New Point(p.Left - 1, p.Top - 1)

            'pEtapa.Controls.Item("pAux_" & nm).Controls.Add(pb)
            g.Dispose()


        End Sub
        Private Sub ControlAprendidosES(sender, e)
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sqlstring As String
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim indice As Integer
            Dim nm As String
            Dim str() As String
            Dim tp As String
            Dim param As String = ""
            Dim q As Integer
            Dim btnStatus As Button

            Dim IdDet As Integer
            Dim IdOracionItem As Integer
            Dim mypen As Pen

            nm = sender.Name
            str = nm.Split("_")
            tp = str(0)

            IdDet = str(1)

            sqlstring = " SELECT         Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Oraciones.STL"
            sqlstring = sqlstring & " FROM            Det_Conversation INNER JOIN Oraciones"
            sqlstring = sqlstring & "              Oraciones ON Det_Conversation.Det_OracionId = Oraciones.Id"
            sqlstring = sqlstring & " WHERE  Det_Conversation.Det_Con='" & IdDet & "'"

            Dim objDataReader As SqlDataReader

            Try
                _comando.CommandText = sqlstring

                _comando.Connection.Open()

            Catch ex As Exception

            End Try

            Try
                objDataReader = _comando.ExecuteReader

                If objDataReader.HasRows Then

                    objDataReader.Read()

                    IdOracionItem = objDataReader(1)
                Else
                    IdOracionItem = IdDet

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            _comando.Connection.Close()



            Dim Exam As String
            Exam = pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("tra_" & IdDet).Text

            Try

                If sender.text = "NO" Then
                    Status = True
                    sender.backcolor = Color.LightGreen
                    sender.text = "SI"
                    ' Aprendidos += 1
                    pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("tstES_" & IdDet).BackColor = Color.LightGreen
                    mypen = New Pen(Color.LightGreen, 1)
                Else
                    Status = False
                    sender.backcolor = Color.LightSalmon
                    sender.text = "NO"
                    ' Aprendidos -= 1
                    pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("tstES_" & IdDet).BackColor = Color.LightSalmon
                    mypen = New Pen(Color.LightSalmon, 1)

                End If

                sqlstring = "UPDATE Oraciones SET AprendidoES = @AprendidoES"
                sqlstring = sqlstring & " WHERE Id = @Id"

                _comando.Parameters.AddWithValue("@Id", IdOracionItem)
                _comando.Parameters.AddWithValue("@AprendidoES", Status)


                _comando.CommandText = sqlstring
                _comando.Connection.Open()

                Try
                    i = _comando.ExecuteNonQuery

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                _comando.Connection.Close()


                If i > 0 Then
                Else

                End If
            Catch ex As Exception

            End Try

            Dim pb As PictureBox
            Dim bmp As Bitmap
            Dim g As Graphics

            'pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("pb_" & IdDet).CreateGraphics.DrawRectangle(mypen, 0, 0, 1195, 65)

        End Sub
        Private Sub LeerTexto(sender, e)
            Dim i As Integer
            Dim nm As String
            Dim str() As String
            Dim tp As String
            Dim param As String = ""
            Dim q As Integer
            Dim obj As New Label
            Dim IdDialogo As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()

            nm = sender.Name
            Dim IdPanel As Integer

            str = nm.Split("_")
            tp = str(0)
            IdDialogo = str(1)

            If cmdStop.Text = "Stop" Then
                Exit Sub
            End If

            '1 : Microsoft David - English (United States)
            '2:  Microsoft(James - English(Australia))
            '3:  Microsoft(Linda - English(Canada))
            '4:  Microsoft(Richard - English(Canada))
            '5 : Microsoft George - English (United Kingdom)
            '6 : Microsoft Hazel - English (United Kingdom)
            '7 : Microsoft Susan - English (United Kingdom)
            '8:  Microsoft(Catherine - English(Australia))
            '9 : Microsoft Mark - English (United States)
            '10 : Microsoft Zira - English (United States)

            'speech.Rate = speechRate
            'speech.Volume = volume
            '' speech.Speak(dt.Rows(0).Item(4), SpeechVoiceSpeakFlags.SVSFlagsAsync)
            '' speech.Speak("Text", SpeechVoiceSpeakFlags.SVSFlagsAsync)
            'speech.Speak(dt.Rows(0).Item(4), SpeechVoiceSpeakFlags.SVSFVoiceMask)

            Dim _voice As Integer
            '_voice = pEtapa.Controls.Item("pAux_" & nm).Controls("p_" & nm).Tag
            _voice = sender.Tag

            'If _voice = 0 Then
            '_voice = 3
            'End If

            Select Case _voice
                Case Is = 0, 1
                    _voice = 3
                Case Is = 2   'Woman
                    _voice = 2
                    'Case Is = 2, 4, 5, 6 'Melendez 'Andrews
                    '    _voice = 10
                    'Case Is = 9
                    '    _voice = 9
                    'Case 10, 11
                    '    _voice = 10
            End Select

            If Not IsNothing(objtextOver) Then
                'objtextOver.Font = New Font("Consolas", 11, FontStyle.Regular)
            End If

            Dim myPen As New Pen(Color.Red, 2)
            Dim myPenClear As New Pen(Color.Beige, 2)

            Dim g As Graphics

            'If Not objtextOver Is Nothing Then
            '    g = objtextOver.CreateGraphics
            '    g.DrawRectangle(myPenClear, 0, 0, 40, 40)
            'End If
            IdCurrent = IdDialogo

            If IdOver > 0 Then
                'g = pEtapa.Controls("pAux_" & IdPanel).Controls.Item("p_" & IdOver).CreateGraphics
                ' g.DrawRectangle(myPenClear, 0, 0, 40, 40)
            End If

            'g = pEtapa.Controls("pAux_" & nm).Controls.Item("p_" & nm).CreateGraphics
            'g.DrawRectangle(myPen, 0, 0, 40, 40)

            Try
                objtextCurrent = pEtapa.Controls.Item(sender.parent.name).Controls.Item("txt_" & IdDialogo)
                ' objtextCurr = pEtapa.Controls.Item("pAux0").Controls.Item("txt0")
                ' objtextCurrent.Font = New Font("Consolas", 11, FontStyle.Bold)

                objtextOver = objtextCurrent
                IdOver = IdPanel

                ' Dim pVoice As ISpVoice = CType(voice, ISpVoice)
                Dim otc As SpObjectTokenCategory = New SpObjectTokenCategory()
                otc.SetId("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Speech_OneCore\Voices")

                Dim tokenEnum As ISpeechObjectTokens = otc.EnumerateTokens()
                Dim nTokenCount As Integer = tokenEnum.Count

                '  Console.WriteLine("Number of voices: {0}", nTokenCount)
                Dim n As UInteger = 0
                ' Dim pVoice As ISpVoice = CType(voice, ISpVoice)


                'For Each sot As ISpeechObjectToken In tokenEnum
                '    Console.WriteLine("Voice : {0}", sot.GetDescription())
                'Next

                ' pVoice.SetVoice(CType(sot, ISpObjectToken))
                pVoice.SetVoice(CType(tokenEnum(_voice), ISpObjectToken))
                ' pVoice.SetVoice(CType(tokenEnum(person), ISpObjectToken))
                ' pVoice.SetVoice(CType(tokenEnum(person), ISpObjectToken))
                ' speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(voice)
                ' speech.SetVoice(CType(tokenEnum(0), ISpObjectToken))

                ' AddHandler voice.EndStream, AddressOf speakComplete
            ' pVoice.SetRate(TrackBarVelocidad.Value)
            '   pVoice.SetVolume(TrackBarVolumen.Value)

                Try
                    '  pVoice.Speak(objtextCurrent.Text, 0, n)
                    speech.Speak(objtextCurrent.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync)

                Catch ex As Exception

                End Try

                'For Each sot As ISpeechObjectToken In tokenEnum
                'Console.WriteLine("Voice : {0}", sot.GetDescription())

                'pVoice.SetVoice(CType(sot, ISpObjectToken))
                ' pVoice.SetVoice(CType(tokenEnum(0), ISpObjectToken))
                ' speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(voice)
                ' speech.SetVoice(CType(tokenEnum(0), ISpObjectToken))

                'Try
                '    ' pVoice.Speak(objtextCurr.Text, 0, n)

                '    ' speech.Speak(objtextCurr.Text, 0, 0)
                'Catch ex As System.Exception
                '    'Console.WriteLine("Cannot speak with the voice : {0}", sot.GetDescription())
                'End Try

                ' Next

                'speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(voice)

                'If (paused) = True Then
                '    speech.Resume()
                '    paused = False

                'Else
                '    speech.Rate = speechRate
                '    speech.Volume = volume
                '    speech.Speak(objtextCurr.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync)

                'End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try




        End Sub
        Private Sub LeerTextoES(sender, e)
            Dim i As Integer
            Dim nm As String
            Dim str() As String
            Dim tp As String
            Dim param As String = ""
            Dim q As Integer
            Dim obj As New Label

            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()

            nm = sender.Name

            str = nm.Split("_")
            tp = str(0)

            '1 : Microsoft David - English (United States)
            '2:  Microsoft(James - English(Australia))
            '3:  Microsoft(Linda - English(Canada))
            '4:  Microsoft(Richard - English(Canada))
            '5 : Microsoft George - English (United Kingdom)
            '6 : Microsoft Hazel - English (United Kingdom)
            '7 : Microsoft Susan - English (United Kingdom)
            '8:  Microsoft(Catherine - English(Australia))
            '9 : Microsoft Mark - English (United States)
            '10 : Microsoft Zira - English (United States)

            Dim _voice As Integer
            _voice = pEtapa.Controls.Item("pAux_" & nm).Controls("p_" & nm).Tag


            Select Case _voice
                Case Is = 0, 1
                    _voice = 3
                Case Is = 2   'Woman
                    _voice = 2

            End Select

            If Not IsNothing(objtextOverES) Then
                objtextOverES.Font = New Font("Consolas", 11, FontStyle.Regular)
            End If

            Dim myPen As New Pen(Color.Red, 2)
            Dim myPenClear As New Pen(Color.Beige, 2)

            Dim g As Graphics

            IdCurrent = nm

            If IdOver > 0 Then
                g = pEtapa.Controls("pAux_" & IdOver).Controls.Item("p_" & IdOver).CreateGraphics
                g.DrawRectangle(myPenClear, 0, 0, 40, 40)
            End If
            Dim synth As New SpeechSynthesizer()


            'synth.SetOutputToDefaultAudioDevice()
            'synth.SelectVoice("Microsoft Zira Desktop")
            'objtextCurrentES = pEtapa.Controls.Item("pAux_" & nm).Controls.Item("tra_" & nm)
            'objtextCurrentES.Font = New Font("Consolas", 11, FontStyle.Bold)

            'objtextOverES = objtextCurrentES
            'IdOver = nm

            'synth.SpeakAsync(objtextCurrentES.Text)
            ' synth.Speak("Hello, this is a test of the speech synthesizer.")



            'Dim AudioFormats As String = ""
            'Dim info As VoiceInfo = voice.VoiceInfo

            ' _voice = 10 'Raul
            _voice = 11 '
            'For Each voice As InstalledVoice In spcsynth.GetInstalledVoices()
            'Console.WriteLine(voice.VoiceInfo.Name)
            'Next
            'Each fmt As SpeechAudioFormatInfo In info.SupportedAudioFormats
            ' AudioFormats += String.Format("{0}" & vbLf, fmt.E

            g = pEtapa.Controls("pAux_" & nm).Controls.Item("p_" & nm).CreateGraphics
            g.DrawRectangle(myPen, 0, 0, 40, 40)

            Try
                objtextCurrentES = pEtapa.Controls.Item("pAux_" & nm).Controls.Item("tra_" & nm)
                objtextCurrentES.Font = New Font("Consolas", 11, FontStyle.Bold)

                objtextOverES = objtextCurrentES
                IdOver = nm

                Dim otc As SpObjectTokenCategory = New SpObjectTokenCategory()
                otc.SetId("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Speech_OneCore\Voices")

                Dim tokenEnum As ISpeechObjectTokens = otc.EnumerateTokens()
                Dim nTokenCount As Integer = tokenEnum.Count

                Dim n As UInteger = 0

                pVoice.SetVoice(CType(tokenEnum(_voice), ISpObjectToken))

            ' pVoice.SetRate(TrackBarVelocidad.Value)
            'pVoice.SetVolume(TrackBarVolumen.Value)

                Try
                    speech.Speak(objtextCurrentES.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync)

                Catch ex As Exception

                End Try


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try




        End Sub
        Private Sub cmdLeer_Click(sender As System.Object, e As System.EventArgs)

        End Sub
        Private Sub LeerItem(item, person)
            Dim _voice As String = ""
            Try
                'Voice : Microsoft David - English (United States)
                'Voice:  Microsoft(James - English(Australia))
                'Voice:  Microsoft(Linda - English(Canada))
                'Voice:  Microsoft(Richard - English(Canada))
                'Voice:  Microsoft(Catherine - English(Australia))
                'Voice : Microsoft Mark - English (United States)
                'Voice : Microsoft Zira - English (United States)

                Select Case person

                    Case Is = 0, 1, 2, 4 'Man
                        _voice = 3
                    Case Is = 3, 7, 8  'Woman
                        _voice = 2
                    Case Is = 4, 5 'Melendez 'Andrews
                        _voice = 3
                    Case Is = 9
                        _voice = 3
                End Select

                ' _voice = "Microsoft Catherine - English (Australia)"
                '_voice = "Microsoft Zira Desktop"

                If (paused) = True Then
                    ' speech.Resume()
                    ' paused = False

                Else
                    ' Dim pVoice As ISpVoice = CType(voice, ISpVoice)
                    Dim otc As SpObjectTokenCategory = New SpObjectTokenCategory()
                    otc.SetId("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Speech_OneCore\Voices")

                    Dim tokenEnum As ISpeechObjectTokens = otc.EnumerateTokens()
                    Dim nTokenCount As Integer = tokenEnum.Count

                    '  Console.WriteLine("Number of voices: {0}", nTokenCount)
                    Dim n As UInteger = 0
                    Dim pVoice As ISpVoice = CType(speech, ISpVoice)

                    For Each sot As ISpeechObjectToken In tokenEnum
                        Console.WriteLine("Voice : {0}", sot.GetDescription())
                    Next

                    ' pVoice.SetVoice(CType(sot, ISpObjectToken))
                    pVoice.SetVoice(CType(tokenEnum(_voice), ISpObjectToken))
                    ' pVoice.SetVoice(CType(tokenEnum(person), ISpObjectToken))
                    ' pVoice.SetVoice(CType(tokenEnum(person), ISpObjectToken))
                    ' speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(voice)
                    ' speech.SetVoice(CType(tokenEnum(0), ISpObjectToken))
                '  pVoice.SetRate(TrackBarVelocidad.Value)
                    ' AddHandler voice.EndStream, AddressOf speakComplete

                    Try
                        '  pVoice.Speak(objtextCurrent.Text, 0, n)
                        speech.Speak(objtextCurrent.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync)

                    Catch ex As Exception

                    End Try



                    'pVoice.Speak(objtextCurr.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync, 0)

                    'voice.GetVoices(CType(tokenEnum(person), ISpObjectToken)).Item(5)
                    'speech.SetVoice(CType(tokenEnum(4), ISpObjectToken))

                    ' voice.Speak(objtextCurr.Text, 0, 0)
                    ' voice.Speak(objtextCurr.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync)


                    'speech.Speak(objtextCurr.Text, 0, 0)
                    For Each v In speaker.GetInstalledVoices
                        Console.WriteLine(v.VoiceInfo.Name)
                    Next
                    ' paused = True

                    'If Voice = "" Then
                    '    Voice = "Microsoft Mark"
                    'End If

                    ' speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(1)
                    ' speech.Voice = speech.GetVoices(CType(tokenEnum(4), ISpObjectToken))
                    ' speech.Voice = speech.GetVoices(CType(tokenEnum(4), ISpObjectToken))
                    'speech.SetVoice(CType(tokenEnum(4), ISpObjectToken))

                    ' speech.Rate = speechRate
                    ' speech.Volume = volume

                    ' speech.Speak(objtextCurr.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    ' speaker.SelectVoice(voice)
                    ' speaker.Speak(item.text)
                    ' speaker.SelectVoice(_voice)
                    'speaker.SelectVoice(tokenEnum(0).GetDescription())
                    'pVoice.SetVoice(CType(tokenEnum(person), ISpObjectToken))

                    'speaker.SpeakAsync(item.text)

                    ' speech.Speak("This is an asynchronous speech example.", SpeechVoiceSpeakFlags.SVSFlagsAsync)
                    ' This line executes immediately, before the speech is completed.

                    ' Synth_PhonemeReached(sender, e)
                    ' Dim sentences As New List(Of String)()
                    ' Dim start As Integer = 0
                    ' Dim position As Integer

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try



        End Sub
        Private Sub Voice_Word(StreamNumber As Integer, StreamPosition As Object, CharacterPosition As Integer, Length As Integer) Handles speech.Word
            Try
                objtextCurrent.SelectAll()
                objtextCurrent.SelectionBackColor = Color.Beige ' Or your default background color
                'Highlight word in textbox as it is spoken  
                objtextCurrent.Select(CharacterPosition, Length)
                ' Highlight the current word
                ' RichTextBox1.Select(e.CharacterPosition, e.CharacterCount)
                objtextCurrent.SelectionBackColor = Color.Yellow ' Or your desired highlight color
                ' RichTextBox1.Focus()
            Catch ex As Exception

            End Try

        End Sub
        Private Sub Cuentas(sender, e)
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sqlstring As String
            Dim IdOracion As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim indice As Integer
            Dim itemCurr As ListViewItem
            Dim itemOver As ListViewItem
            Dim itemSel As Integer
            Dim nm As String
            Dim str() As String
            Dim tp As String
            Dim param As String = ""
            Dim q As Integer
            Dim cuenta As Integer

            nm = sender.name

            str = nm.Split("_")

            tp = str(0)

            indice = str(1)

            If pEtapa.Controls("Paux_" & indice).Controls.Item("txtCuenta_" & indice).Text <> "" Then
                cuenta = pEtapa.Controls("Paux_" & indice).Controls.Item("txtCuenta_" & indice).Text
            Else
                Exit Sub
            End If

            cuenta += 1
            _comando.Connection.Open()

            sqlstring = "UPDATE Oraciones SET Cuenta = @Cuenta"
            sqlstring = sqlstring & " WHERE Id = @Id"

            _comando.Parameters.AddWithValue("@Cuenta", cuenta)

            _comando.Parameters.AddWithValue("@Id", indice)

            Try
                _comando.CommandText = sqlstring

                i = _comando.ExecuteNonQuery

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally

            End Try
            _comando.Connection.Close()
            pEtapa.Controls.Item("pAux_" & indice).Controls("txtCuenta_" & indice).Text = cuenta


        End Sub
        Private Sub MostrarImagen(sender, e)
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sqlstring As String
            Dim IdOracion As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim indice As Integer
            Dim itemCurr As ListViewItem
            Dim itemOver As ListViewItem
            Dim itemSel As Integer
            Dim nm As String
            Dim str() As String
            Dim tp As String
            Dim param As String = ""
            Dim q As Integer
            Dim cuenta As Integer

            nm = sender.name

            str = nm.Split("_")

            tp = str(0)

            ' indice = str(1)



            Dim filename As String
            filename = sender.tag

            ' Dim btn As Button
            ' btn = pEtapa.Controls.Item("pAux_" & nm).Controls(nm)
            'PictureBox1.Location = New Point(0, 0)

            ' pbi.Image = Image.FromFile("C:\Legacy\Ingles\Imagenes_Ingles\" & filename)
            'Try
            '    PictureBox1.Image = Image.FromFile("C:\Legacy\Ingles\Imagenes_Ingles\" & filename)
            '    PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
            '    PictureBox1.BringToFront()

            '    Panel3.Visible = True
            '    Panel3.Location = New Point(500, MousePosition.Y - 100)
            'Catch ex As Exception
            '    Panel3.Visible = False

            'End Try


            'Me.Controls.Add(newpanel)

            'newpanel.Location = New Point(100, 100)

            'newpanel.BringToFront()

            'newpanel.Controls.Add(PictureBox1)

            '_comando.Connection.Open()
            '_comando.Parameters.AddWithValue("@Cuenta", cuenta)

            '_comando.Parameters.AddWithValue("@Id", indice)

            'Try
            '    _comando.CommandText = sqlstring

            '    i = _comando.ExecuteNonQuery

            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'Finally

            'End Try
            ' _comando.Connection.Close()
            'pEtapa.Controls.Item("pAux_" & indice).Controls("txtCuenta_" & indice).Text = cuenta


        End Sub
        Private Sub OcultarImagen(sender, e)



            '  Panel3.Visible = False
            'Panel3.Location = New Point(MousePosition.X + 200, MousePosition.Y)




            'Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            'Dim sqlstring As String
            'Dim IdOracion As Integer
            'Dim dt As New DataTable
            'Dim da As New SqlDataAdapter
            'Dim i As Integer
            'Dim indice As Integer
            'Dim itemCurr As ListViewItem
            'Dim itemOver As ListViewItem
            'Dim itemSel As Integer
            'Dim nm As String
            'Dim str() As String
            'Dim tp As String
            'Dim param As String = ""
            'Dim q As Integer
            'Dim cuenta As Integer

            'nm = sender.name

            'str = nm.Split("_")

            'tp = str(0)

            'indice = str(1)

            'If pEtapa.Controls("Paux_" & indice).Controls.Item("txtCuenta_" & indice).Text <> "" Then
            '    cuenta = pEtapa.Controls("Paux_" & indice).Controls.Item("txtCuenta_" & indice).Text
            'Else
            '    Exit Sub
            'End If

            'cuenta += 1
            '_comando.Connection.Open()

            'sqlstring = "UPDATE Oraciones SET Cuenta = @Cuenta"
            'sqlstring = sqlstring & " WHERE Id = @Id"

            '_comando.Parameters.AddWithValue("@Cuenta", cuenta)

            '_comando.Parameters.AddWithValue("@Id", indice)

            'Try
            '    _comando.CommandText = sqlstring

            '    i = _comando.ExecuteNonQuery

            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'Finally

            'End Try
            '_comando.Connection.Close()
            'pEtapa.Controls.Item("pAux_" & indice).Controls("txtCuenta_" & indice).Text = cuenta


        End Sub
        Private Sub CambiarTipoCon(sender, e)
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sqlstring As String
            Dim IdDet As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim indice As Integer
            Dim nm As String
            Dim str() As String
            Dim tp As String
            Dim param As String = ""
            Dim q As Integer

            nm = sender.name
            str = nm.Split("_")

            tp = str(0)
            IdDet = str(1)

            Dim Id As Integer
            Dim IdPerson As Integer
            Dim TipoTicket As String

            Dim resp As Integer
            Dim obj As PictureBox
            Dim valorNuevo As String

            obj = sender

            If sender.tag = "R" Then
                valorNuevo = "Q"
                sqlstring = "Update Det_Conversation SET Det_Tipo='Q'"
                sqlstring = sqlstring & "  WHERE Det_Con = '" & IdDet & "'"
            Else
                valorNuevo = "R"
                sqlstring = "Update Det_Conversation SET Det_Tipo='R'"
                sqlstring = sqlstring & "  WHERE Det_Con = '" & IdDet & "'"
            End If


            _comando.CommandText = sqlstring
            _comando.Connection.Open()


            Try
                i = _comando.ExecuteNonQuery

                If i > 0 Then
                    'MsgBox("se guardo")
                    'obj.Image = ImageList5.Images(IdPerson)

                Else
                    'MsgBox("No se guardo")
                End If
            Catch ex As Exception

            End Try

            Dim bmp As Bitmap
            Dim g As Graphics
            Dim startPoint As Point
            Dim endPoint As Point

            bmp = New Bitmap(80, 80)
            sender.Image = bmp
            sender.tag = valorNuevo

            g = Graphics.FromImage(sender.Image)
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            If valorNuevo <> "R" Then
                startPoint = New Point(10, 55)
                endPoint = New Point(30, 55) ' La línea es horizontal si la coordenada Y es la misma

                Dim tipPoints As Point() = {
           endPoint, New Point(endPoint.X - 10, endPoint.Y - 5), New Point(endPoint.X - 10, endPoint.Y + 5)}

                g.DrawLine(Pens.Blue, startPoint, endPoint)
                g.FillPolygon(Brushes.Blue, tipPoints)

            Else
                startPoint = New Point(30, 55)
                endPoint = New Point(10, 55) ' La línea es horizontal si la coordenada Y es la misma

                Dim tipPoints As Point() = {
           endPoint, New Point(endPoint.X + 10, endPoint.Y - 5), New Point(endPoint.X + 10, endPoint.Y + 5)}

                g.DrawLine(Pens.Orange, startPoint, endPoint)
                g.FillPolygon(Brushes.Orange, tipPoints)
            End If


            ' pEtapa.Controls.Item("pAux_" & nm).Controls.Add(pbf)


        End Sub
        Private Sub CambiarImagen(sender, e)
            Dim sqlstring As String
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

            nm = sender.name
            str = nm.Split("_")

            tp = str(0)
            IdDialogo = str(1)

            Dim Id As Integer
            Dim IdPerson As Integer
            Dim TipoTicket As String

            Dim resp As Integer
            Dim obj As PictureBox

            IdOracion = sender.tag
            Dim _comando As SqlCommand
            Dim filename As String = ""

            Dim Nombre As String
            'Busca y actualiza si no existe en Oraciones
            _comando = MetodosDatos.CrearComando()
            _comando.Connection.Open()

            sqlstring = " SELECT Id, TextoPlano, IMG  FROM Oraciones"
            sqlstring = sqlstring & " WHERE Id = @Id"
            _comando.CommandText = sqlstring

            _comando.Parameters.AddWithValue("@Id", IdOracion)
            Dim objDataReader As SqlDataReader

            Try
                objDataReader = _comando.ExecuteReader

                If objDataReader.HasRows Then
                    objDataReader.Read()
                    If Not IsDBNull(objDataReader(1)) Then
                        Nombre = (objDataReader(1))
                        objDataReader.Close()
                    End If

                End If
                ' Clipboard.SetText(Nombre)

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            objDataReader.Close()

            _comando.Connection.Close()

            Nombre = pEtapa.Controls(sender.parent.name).controls("txt_" & IdDialogo).text
            Clipboard.SetText(Nombre)


            ' Seleccionar Imagen
            Using ofd As New OpenFileDialog
                ofd.InitialDirectory = "C:\Legacy\Ingles\Imagenes_Ingles\"
                '  = IdPerson

                If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then

                    Dim _insertado As Boolean = False
                    Dim mostrarMensaje As Boolean = False
                    Dim stringvalues As String = ""
                    Dim sql As String = ""


                    filename = ofd.SafeFileName

                    'Actualiza en Tbl Dialogos
                    _comando.Connection.Open()

                    sqlstring = "Update Dialogos SET IMG='" & filename & "'"
                    sqlstring = sqlstring & "  WHERE Id = '" & IdDialogo & "'"
                    _comando.CommandText = sqlstring

                    Try
                        i = _comando.ExecuteNonQuery

                    Catch ex As Exception
                        _comando.Connection.Close()
                        Exit Sub
                    End Try

                    _comando.Connection.Close()

                    'Busca y actualiza si no existe en Oraciones
                    _comando.Connection.Open()

                    sqlstring = " SELECT Id, TextoPlano, IMG  FROM Oraciones"
                    sqlstring = sqlstring & " WHERE Id = @Id"
                    _comando.CommandText = sqlstring

                    _comando.Parameters.Clear()
                    _comando.Parameters.AddWithValue("@Id", IdOracion)

                    Try
                        objDataReader = _comando.ExecuteReader

                        If objDataReader.HasRows Then
                            objDataReader.Read()
                            If IsDBNull(objDataReader(2)) Then
                                objDataReader.Close()

                                ' _comando.Connection.Open()

                                sqlstring = "Update Oraciones SET IMG='" & filename & "'"
                                sqlstring = sqlstring & "  WHERE Id = '" & IdOracion & "'"
                                _comando.CommandText = sqlstring

                                Try
                                    i = _comando.ExecuteNonQuery
                                Catch ex As Exception
                                End Try

                            End If

                        End If

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                    objDataReader.Close()

                    sender.Image = Image.FromFile("C:\Legacy\Ingles\Imagenes_Ingles\" & filename)


                End If

                _comando.Connection.Close()


            End Using


        End Sub
        Private Sub CambiarImagenDialogo(sender, e)
            Dim sqlstring As String
            Dim IdDet As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim indice As Integer
            Dim nm As String
            Dim str() As String
            Dim tp As String
            Dim param As String = ""
            Dim q As Integer

            nm = sender.name
            str = nm.Split("_")

            tp = str(0)
            IdDet = str(1)

            Dim Id As Integer
            Dim IdPerson As Integer
            Dim TipoTicket As String

            Dim resp As Integer
            Dim obj As PictureBox

            IdOracion = sender.tag
            Dim _comando As SqlCommand
            Dim filename As String = ""

            Dim Nombre As String

            'Busca y actualiza si no existe en Oraciones
            _comando = MetodosDatos.CrearComando()

            ' Nombre = pEtapa.Controls(sender.parent.name).controls("pd_" & IdDet).text
            Clipboard.SetText(nm)

            ' Seleccionar Imagen
            Using ofd As New OpenFileDialog
                ofd.InitialDirectory = "C:\Legacy\Ingles\Imagenes_Ingles\"

                If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
                    Dim _insertado As Boolean = False
                    Dim mostrarMensaje As Boolean = False
                    Dim stringvalues As String = ""
                    Dim sql As String = ""


                    filename = ofd.SafeFileName

                    'Actualiza en Tbl Dialogos
                    _comando.Connection.Open()

                    sqlstring = "Update Det_Conversation SET IMG='" & filename & "'"
                    sqlstring = sqlstring & "  WHERE Det_Con = '" & IdDet & "'"
                    _comando.CommandText = sqlstring

                    Try
                        i = _comando.ExecuteNonQuery

                    Catch ex As Exception
                        _comando.Connection.Close()
                        Exit Sub
                    End Try
                    sender.Image = Image.FromFile("C:\Legacy\Ingles\Imagenes_Ingles\" & filename)
                End If


                _comando.Connection.Close()


            End Using


        End Sub
        Private Sub MoverDialogo(sender, e)
            Dim sqlstring As String
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim indice As Integer
            Dim nm As String
            Dim str() As String
            Dim tp As String
            Dim param As String = ""
            Dim q As Integer
            Dim btnStatus As Button
            Dim IdDialogo As Integer
            Dim IdDetNuevo As Integer
            Dim IdOracionItem As Integer

            ' If e.Button = MouseButtons.Right Then
            Dim menu = New System.Windows.Forms.ContextMenuStrip()
            Dim posicion As Integer 'dgvDevices.HitTest(e.X, e.Y).RowIndex

            nm = sender.Name
            str = nm.Split("_")
            tp = str(0)

            IdDialogo = str(1)


            If posicion > -1 Then
                menu.Items.Add("Mover").Name = "Mover" & IdDialogo
                menu.Items.Add("Recibir").Name = "Recibir" & IdDialogo
                menu.Items.Add("Ordenar").Name = "Ordenar" & sender.tag
            End If

            menu.Show(pEtapa.Controls.Item("pAux_" & sender.tag), sender.location.X - 120, sender.location.Y - 50)

            AddHandler menu.ItemClicked, AddressOf VerMenu

            'If sender.text = "S" Then
            'sender.text = "M"
            sender.backcolor = Color.Yellow

            '  ElseIf sender.text = "M" Then

            ' Else

            '  End If


        End Sub
        Private Sub VerMenu(sender As Object, e As ToolStripItemClickedEventArgs)
            Dim nombre = e.ClickedItem.Name.ToString
            Dim fecha As Date
            Dim mifecha As String
            Dim Id As Integer
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim IdDetActual As Integer
            Dim IdDetNuevo As Integer
            Dim i As Integer
            Dim mypen As Pen
            Dim MaxOrden As Integer
            Dim rowcount As Integer
            Dim k As Integer
            Dim p As Integer


            If nombre.Contains("Mover") Then
                Dim posicion = nombre.Replace("Mover", "")
                k = ListDialogos.Items.Count
                Dim item1 As New ListViewItem(k) ' Crea un nuevo ítem para la primera columna
                Dim orden As Integer
                item1.SubItems.Add(posicion)   ' Agrega el ítem a la lista

                ' ListDialogos.Items.Add(item1) ' Agrega un subítem para la segunda columna en el ítem ya creado

                _comando.Connection.Open()

                sqlstring = " SELECT         Id, OracionId, Orden, DetConversacion, IMG"
                sqlstring = sqlstring & " FROM            Dialogos "
                sqlstring = sqlstring & "          "
                sqlstring = sqlstring & " WHERE  Id='" & posicion & "'"
                _comando.CommandText = sqlstring

                Dim objDataReader As SqlDataReader

                Try

                    objDataReader = _comando.ExecuteReader

                    If objDataReader.HasRows Then
                        objDataReader.Read()
                        'rowcount += 1
                        IdDetActual = objDataReader(3)
                        orden = objDataReader(2)

                        item1.SubItems.Add(IdDetActual)   ' Agrega el ítem a la lista
                        item1.SubItems.Add(orden)   ' Agrega el ítem a la lista

                    End If

                    ListDialogos.Items.Add(item1)

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                _comando.Connection.Close()


                Dim pic As PictureBox
                pic = pEtapa.Controls.Item("pAux_" & IdDetActual).Controls.Item("p_" & posicion)
                pic.Image = Image.FromFile("C:\Legacy\Ingles\Imagenes_Ingles\X.jpg")

                'pEtapa.Controls.Item("pAux_" & IdDetActual).Controls.Item("txt_" & posicion).Visible = False

                Exit Sub

            ElseIf nombre.Contains("Recibir") Then
                Dim IdDetRecibe As Integer

                If ListDialogos.Items.Count = 0 Then
                    MsgBox("No hay items para mover")
                    Exit Sub
                End If

                Dim posicion = nombre.Replace("Recibir", "")

                '_comando.Connection.Open()

                'sqlstring = " SELECT         Id, OracionId, Orden, DetConversacion, IMG"
                'sqlstring = sqlstring & " FROM            Dialogos "
                'sqlstring = sqlstring & "          "
                'sqlstring = sqlstring & " WHERE  Id='" & posicion & "'"
                '_comando.CommandText = sqlstring

                'Dim objDataReader As SqlDataReader

                'Try

                '    objDataReader = _comando.ExecuteReader

                '    If objDataReader.HasRows Then
                '        objDataReader.Read()
                '        'rowcount += 1
                '        IdDetRecibe = objDataReader(3)
                IdDetRecibe = posicion

                'End If

                '    Catch ex As Exception
                '    MsgBox(ex.Message)
                'End Try
                '_comando.Connection.Close()


                _comando.Connection.Open()

                Dim j As Integer = 1


                For Each d In ListDialogos.Items

                    sqlstring = "UPDATE Dialogos SET DetConversacion = @DetConversacion, Orden = @Orden"
                    sqlstring = sqlstring & " WHERE Id = @Id"
                    _comando.CommandText = sqlstring

                    Dim orden As Integer
                    orden = ListDialogos.Items(0).SubItems(3).Text
                    _comando.Parameters.Clear()
                    _comando.Parameters.AddWithValue("@DetConversacion", IdDetRecibe)
                    _comando.Parameters.AddWithValue("@Orden", orden + 1)
                    _comando.Parameters.AddWithValue("@Id", ListDialogos.Items(0).SubItems(1).Text)

                    Try
                        i = _comando.ExecuteNonQuery

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try

                    Dim txt As RichTextBox
                    txt = pEtapa.Controls.Item("pAux_" & ListDialogos.Items(0).SubItems(2).Text).Controls.Item("txt_" & ListDialogos.Items(0).SubItems(1).Text)
                    pEtapa.Controls.Item("pAux_" & IdDetRecibe).Controls.Add(txt)
                    txt.Location = New Point(500, 0)
                    ' pEtapa.Controls.Item("pAux_" & IdDetActual).Controls.Item("txt_" & posicion).Visible = False
                    Dim trad As Label
                    trad = pEtapa.Controls.Item("pAux_" & ListDialogos.Items(0).SubItems(2).Text).Controls.Item("tra_" & ListDialogos.Items(0).SubItems(1).Text)
                    trad.Location = New Point(500, txt.Bottom + 1)

                    j += 1

                Next





                'Actualiza el Orden 'Dialogos'
                sqlstring = " SELECT         Id, OracionId, Orden, DetConversacion, IMG"
                sqlstring = sqlstring & " FROM            Dialogos "
                sqlstring = sqlstring & "          "
                sqlstring = sqlstring & " WHERE  DetConversacion='" & IdDetRecibe & "'"
                _comando.CommandText = sqlstring

                Dim dt As New DataTable
                Dim da As New SqlDataAdapter

                da.SelectCommand = _comando

                da.Fill(dt)

                n = dt.Rows.Count

                For Each r In dt.Rows

                    sqlstring = "UPDATE Dialogos SET Orden = @Orden"
                    sqlstring = sqlstring & " WHERE Id = @Id"
                    _comando.CommandText = sqlstring
                    _comando.Parameters.Clear()

                    _comando.Parameters.AddWithValue("@Orden", k)
                    ' _comando.Parameters.AddWithValue("@Id", r.SubItems(1).Text)
                    _comando.Parameters.AddWithValue("@Id", r.item(0))

                    Try
                        i = _comando.ExecuteNonQuery

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                    k += 1
                Next

                ' _comando.Connection.Close()

                '''' Actualizar Orden de Det Id Anterior
                sqlstring = " SELECT         Id, OracionId, Orden, DetConversacion, IMG"
                sqlstring = sqlstring & " FROM            Dialogos "
                sqlstring = sqlstring & "          "
                sqlstring = sqlstring & " WHERE  DetConversacion='" & ListDialogos.Items(0).SubItems(1).Text & "'"
                _comando.CommandText = sqlstring

                da.SelectCommand = _comando

                da.Fill(dt)

                n = dt.Rows.Count


                For Each r In dt.Rows

                    sqlstring = "UPDATE Dialogos SET Orden = @Orden"
                    sqlstring = sqlstring & " WHERE Id = @Id"
                    _comando.CommandText = sqlstring
                    _comando.Parameters.Clear()

                    _comando.Parameters.AddWithValue("@Orden", p)
                    _comando.Parameters.AddWithValue("@Id", r.item(0))


                    Try
                        i = _comando.ExecuteNonQuery

                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                    p += 1



                Next

                _comando.Connection.Close()

                ''
                ListDialogos.Items.Clear()

                'CrearControles()

            ElseIf nombre.Contains("Ordenar") Then

                Dim posicion = nombre.Replace("Ordenar", "")

                Dim frm As New frmOrdenarDialogos

                AddOwnedForm(frm)
                frm.Id = posicion

                frm.ShowDialog()

                If band = True Then
                CrearControles("")
                End If

                Exit Sub


            End If

            'CrearControles()


            'Dim CuentaSTL As Integer
            'Dim Exam As String
            'Exam = 

            'Try
            '    Dim Cuenta As Integer

            '    If sender.text = "X" Then
            '        '  sender.backcolor = Color.LightGreen
            '        ' sender.text = "SI"
            '        Aprendidos += 1
            '        'pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("tst_" & IdDet).BackColor = Color.LightGreen
            '        CuentaSTL -= 1

            '    Else
            '        'sender.backcolor = Color.LightSalmon
            '        'sender.text = "NO"
            '        Aprendidos = 1
            '        'pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("tst_" & IdDet).BackColor = Color.LightSalmon
            '        CuentaSTL += 1

            '    End If

            '    Cuenta = pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txtc_" & IdDet).Text
            '    CuentaSTL += Cuenta

            '    If CuentaSTL <= 0 Then
            '        ' mypen = New Pen(Color.LightSalmon, 1)
            '        Status = False
            '        pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("btnStatus_" & IdDet).BackColor = Color.Yellow
            '        pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txtc_" & IdDet).Visible = False

            '    Else
            '        Status = True
            '        ' mypen = New Pen(Color.LightGreen, 1)
            '        pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("btnStatus_" & IdDet).BackColor = Color.Transparent
            '        pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txtc_" & IdDet).Visible = True

            '    End If



            'Catch ex As Exception

            'End Try

            'Dim pb As PictureBox
            'Dim bmp As Bitmap
            'Dim g As Graphics

            'pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("pb_" & IdDet).CreateGraphics.DrawRectangle(mypen, 0, 0, 1195, 85)
            'pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txtc_" & IdDet).Text = CuentaSTL

            'Try
            '    ' IO.File.Open("10.18.172.30\Materials\Readwrite\Checklist\auditoria\" & mifecha & "F-" & id & ".pdf", mode:=IO.FileMode.Append)
            '    'Process.Start("Q:\Materials\Readwrite\Checklist\auditoria-F-" & id & ".pdf") ' Approach 1
            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try



            '' Id = dgvDevices.Rows(posicion).Cells(0).Value.ToString

            'Dim version As Integer
            'Dim Proyecto As String

            'Try
            '    ' Id = dgvDevices.Rows(posicion).Cells(0).Value.ToString
            '    ' Proyecto = dgvDevices.Rows(posicion).Cells(1).Value.ToString
            '    ' version = dgvDevices.Rows(posicion).Cells(0).Value.ToString
            '    version = 1

            'Catch ex As Exception
            '    MsgBox(ex.Message)
            '    'Exit Sub
            'End Try

            'Dim param As String = " WHERE Tbl_files.fil_Id='" & Id & "'"


        End Sub
        Private Sub EliminarPanel(sender, e)
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sqlstring As String
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim indice As Integer
            Dim nm As String
            Dim str() As String
            Dim tp As String
            Dim param As String = ""
            Dim q As Integer
            Dim btnStatus As Button
            Dim IdDet As Integer
            Dim IdOracionItem As Integer

            nm = sender.Name
            str = nm.Split("_")
            tp = str(0)

            Dim resp As Integer

            resp = MsgBox("¿ Eliminar este panel ?", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation)

            If resp = 6 Then
            Else
                Exit Sub
            End If

            IdDet = sender.Name

            sqlstring = "Delete From Det_Conversation "
            sqlstring = sqlstring & "  WHERE Det_Con = '" & IdDet & "'"

            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
            End Try

            sqlstring = "Delete From Dialogos "
            sqlstring = sqlstring & "  WHERE DetConversacion = '" & IdDet & "'"

            _comando.CommandText = sqlstring

            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
            End Try

            _comando.Connection.Close()

            If i > 0 Then
                'MsgBox("se guardo")
            Else
                'MsgBox("No se guardo")
            End If

            'CrearControles()


            pEtapa.Controls.Remove(pEtapa.Controls.Item("pAux_" & IdDet))



        End Sub
        Private Sub Agregar(sender, e)
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sqlstring As String
            Dim IdOracion As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim indice As Integer
            Dim nm As String
            Dim str() As String
            Dim tp As String
            Dim param As String = ""
            Dim q As Integer
            Dim obj As New Label
            Dim IdDet As Integer
            ' Dim resp As Nullable(Of Integer)
            ' obj = sender
            Dim IdOracionItem As Integer
            nm = sender.Name

            str = nm.Split("_")

            tp = str(0)

            IdDet = sender.tag

            Dim frm As New frmTransferir

            AddOwnedForm(frm)

            frm.Id = Id
            frm.IdDet = IdDet
            'frm.IdConversation = Id
            frm.ShowDialog()



            'sqlstring = " SELECT         Dialogos.Id, Dialogos.OracionId"
            'sqlstring = sqlstring & " FROM            Dialogos INNER JOIN"
            'sqlstring = sqlstring & "              Oraciones ON Dialogos.OracionId = Oraciones.Id"
            'sqlstring = sqlstring & " WHERE  Dialogos.Id='" & str(1) & "'"
            ''sqlstring = sqlstring & " ORDER BY  Det_Conversation.Det_Orden ASC"

            'Dim objDataReader As SqlDataReader

            'Try
            '    _comando.CommandText = sqlstring

            '    _comando.Connection.Open()

            'Catch ex As Exception

            'End Try

            'Try
            '    objDataReader = _comando.ExecuteReader

            '    If objDataReader.HasRows Then

            '        objDataReader.Read()

            '        IdOracionItem = objDataReader(1)
            '    Else
            '        IdOracionItem = IdDet

            '    End If

            'Catch ex As Exception
            '    MsgBox(ex.Message)
            'End Try
            '_comando.Connection.Close()


            'Dim Id As Integer
            'Dim TipoTicket As String
            'Dim frm As New FrmDetOracion

            'AddOwnedForm(frm)

            'frm.IdOracion = IdOracionItem
            ''frm.CargarDatos(IdOracionItem)
            'frm.CargarDatos(IdOracionItem)
            'frm.ShowDialog()

        End Sub
        Private Sub Mover(sender, e)
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()
            Dim sqlstring As String
            Dim IdOracion As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim i As Integer
            Dim indice As Integer
            Dim nm As String
            Dim str() As String
            Dim tp As String
            Dim param As String = ""
            Dim q As Integer
            Dim obj As New Label
            Dim IdDet As Integer

            Dim IdOracionItem As Integer
            nm = sender.Name

            str = nm.Split("_")

            tp = str(0)

            IdDet = sender.tag

            Dim frm As New frmMoverDialogo

            AddOwnedForm(frm)

            ' frm.IdEnc = Id
            frm.IdDet = IdDet

            frm.ShowDialog()

            'CrearControles()

            pEtapa.Controls.Remove(sender.parent)

        End Sub
        Private Sub MoverNuevoDialogo(sender, e)

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

            IdPerson = 3

            _comando.Connection.Open()

            _comando.Parameters.Clear()

            sqlstring = "Insert into Det_Conversation (Det_Orden, Con_Id)"
            sqlstring = sqlstring & " Values (@Det_Orden, '" & Id & "')"

            _comando.CommandText = sqlstring

            _comando.Parameters.AddWithValue("@Det_Orden", 0)

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

            Dim IdOracionItem As Integer

            Dim nm As String
            IdOracionItem = sender.tag
            nm = sender.Name
            ' Dim str() As String

            ' Str = nm.Split("_")
            _comando.Connection.Open()


            sqlstring = "Update Dialogos SET DetConversacion='" & IdDetNuevo & "'"
            sqlstring = sqlstring & "  WHERE Id = '" & nm & "'"
            _comando.CommandText = sqlstring

            Try
                i = _comando.ExecuteNonQuery

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try


            Console.WriteLine(sender.name)
            Console.WriteLine(sender.parent.name)


            Dim objp As PictureBox

            objp = pEtapa.Controls(sender.parent.name).Controls("p_" & sender.name)
            objp.Image = Image.FromFile("C:\Legacy\Ingles\Imagenes_Ingles\X.jpg")

            '''''

            sqlstring = "SELECT * FROM Dialogos"
            sqlstring = sqlstring & " WHERE DetConversacion = @DetConversacion"
            _comando.CommandText = sqlstring

            _comando.Parameters.Clear()
            _comando.Parameters.AddWithValue("@DetConversacion", IdDetNuevo)
            Try
                da.SelectCommand = _comando
                da.Fill(dt)

            Catch ex As Exception
            End Try

            n = dt.Rows.Count

            Dim q As Integer = 0
            For Each r In dt.Rows

                sqlstring = "UPDATE Dialogos SET Orden = @Orden"
                sqlstring = sqlstring & " WHERE Id = @Id"
                _comando.CommandText = sqlstring
                _comando.Parameters.Clear()

                _comando.Parameters.AddWithValue("@Orden", q)
                _comando.Parameters.AddWithValue("@Id", r.item(0))


                Try
                    i = _comando.ExecuteNonQuery

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                j += 1
            Next

            _comando.Connection.Close()


            'Actualiza OracionId 'Det_conversation
            For Each r In dt.Rows
                sqlstring = "UPDATE Det_Conversation SET Det_OracionId = @Det_OracionId"
                sqlstring = sqlstring & " WHERE Det_Con = @Det_Con"
                _comando.CommandText = sqlstring
                _comando.Parameters.Clear()

                _comando.Parameters.AddWithValue("@Det_OracionId", r.SubItems(3).Text)
                _comando.Parameters.AddWithValue("@Det_Con", IdDetNuevo)

                Try
                    i = _comando.ExecuteNonQuery

                Catch ex As Exception
                End Try
            Next



        End Sub
        Private Sub ReproducirAudio(sender, e)
            Dim i As Integer
            Dim nm As String
            Dim str() As String
            Dim tp As String
            Dim param As String = ""
            Dim q As Integer
            Dim obj As New Label
            Dim IdDialogo As Integer
            Dim dt As New DataTable
            Dim da As New SqlDataAdapter
            Dim _comando As SqlCommand = MetodosDatos.CrearComando()

            nm = sender.Name
            Dim IdPanel As Integer

            str = nm.Split("_")
            tp = str(0)
            IdDialogo = str(1)

            If Not IsNothing(objtextOver) Then
                'objtextOver.Font = New Font("Consolas", 11, FontStyle.Regular)
            End If

            Dim myPen As New Pen(Color.Red, 2)
            Dim myPenClear As New Pen(Color.Beige, 2)

            Dim g As Graphics

            IdCurrent = IdDialogo

            If IdOver > 0 Then
                'g = pEtapa.Controls("pAux_" & IdPanel).Controls.Item("p_" & IdOver).CreateGraphics
                ' g.DrawRectangle(myPenClear, 0, 0, 40, 40)
            End If

            'g = pEtapa.Controls("pAux_" & nm).Controls.Item("p_" & nm).CreateGraphics
            'g.DrawRectangle(myPen, 0, 0, 40, 40)

            Try
                ' objtextCurrent = pEtapa.Controls.Item(sender.parent.name).Controls.Item("txt_" & IdDialogo)
                ' objtextCurr = pEtapa.Controls.Item("pAux0").Controls.Item("txt0")
                ' objtextCurrent.Font = New Font("Consolas", 11, FontStyle.Bold)

                ' objtextOver = objtextCurrent
                ' IdOver = IdPanel

            sqlstring = " SELECT          Dialogos.Id, Dialogos.OracionId, Dialogos.Orden, Dialogos.DetConversacion, Dialogos.IMG, Oraciones.audio, oraciones.avatar"
                sqlstring = sqlstring & " FROM            Dialogos INNER JOIN"
                sqlstring = sqlstring & "                    Oraciones ON Dialogos.OracionId = Oraciones.Id"
                sqlstring = sqlstring & " WHERE  Dialogos.Id='" & IdDialogo & "'"

                Dim objDataReader As SqlDataReader

                Try
                    _comando.CommandText = sqlstring

                    _comando.Connection.Open()

                Catch ex As Exception

                End Try
                Dim IdOracionItem As Integer
                Dim audio As String
                Try
                    objDataReader = _comando.ExecuteReader

                    If objDataReader.HasRows Then

                        objDataReader.Read()

                        IdOracionItem = objDataReader(1)
                        ' audio = objDataReader(5)

                    Else
                        'IdOracionItem = IdDet

                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                _comando.Connection.Close()

                Dim Cuen

                Dim n As UInteger = 0
                Dim archivo As String

                archivo = "C:\legacy\Ingles\Audios\" & IdOracionItem & ".mp3"


                If File.Exists(archivo) Then
                    ' El archivo existe

                Else
                    ' El archivo no existe

                    Dim Id As Integer
                    Dim TipoTicket As String
                    Dim frm As New FrmDetOracion

                    AddOwnedForm(frm)

                    frm.IdOracion = IdOracionItem
                    'frm.CargarDatos(IdOracionItem)
                    frm.CargarDatos(IdOracionItem)
                    frm.ShowDialog()
                    Exit Sub
                End If

                Try
                    '  pVoice.Speak(objtextCurrent.Text, 0, n)
                    'speech.Speak(objtextCurrent.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync)

                Catch ex As Exception

                End Try

                Me.BringToFront()

                Dim mensaje As String

                '  mensaje = "In a small village nestled between mountains lived an altruistic woman named Clara, known for her generosity and empathy toward others. One day, while strolling through the market, she encountered an eloquent man speaking with such passion that he drew a crowd. He was witty, and his words were so persuasive that even the most skeptical stopped to listen."

                ' Dim SongLocation = Path.Combine(Application.StartupPath, IdOracionItem & ".mp3")


            ' rate = TrackBarVelocidad.Value / 10
                ' Player.URL = SongLocation
            'Player.settings.rate = rate
            'Player.URL = archivo
            '' Player.URL = ruta & "AndiesJob.mp3"
            'Player.controls.play()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try




        End Sub


#End Region

#Region "todo lo demas"

        Private Sub SpeachComplete(sender As Object, e As SpeakCompletedEventArgs)

            'objtextOver = objtextCurrent


            'If Not IsNothing(objtextOver) Then
            '    objtextOver.Font = New Font("Consolas", 11, FontStyle.Regular)

            'End If

            'bandComplete = False

        End Sub

        'Console.WriteLine(Len(Texto.Text))

        'Do While speech.Status.InputSentencePosition <= Len(Texto.Text)
        '    Dim sp1 As System.Speech.Synthesis.PromptEventArgs

        '    '  Console.WriteLine(speech.Status.InputSentencePosition)
        '    Console.WriteLine(sp1.Prompt.IsCompleted)
        'Loop


        ' SpeakCompletedEventArgs()






        'Public Sub CargarHistorial(Id)
        '    Dim param As String = " WHERE Tbl_RT_Historial.Enc_Id=" & Id
        '    Dim DatosHistorial As DataTable
        '    Dim resp As Integer
        '    ' Dim Empleados As DataTable
        '    Dim i, n As Integer
        '    Dim actividad As String
        '    Dim fechaHistorial As String = ""
        '    'DatosMantenimiento = CapaLogica.DatosEquiposMantenimiento(param)
        '    DatosHistorial = CapaLogica.Historial(param)

        '    resp = DatosHistorial.Rows.Count

        '    If resp = 0 Then Exit Sub
        '    n = DatosHistorial.Rows.Count

        '    i = 0
        '    ' lstActivities.Items.Clear()


        '    Dim User1 As String
        '    Do While i <= n - 1


        '        User1 = DatosHistorial.Rows(i).Item(5) & " " & DatosHistorial.Rows(i).Item(6) '& "                  " & actividad & " " & fechaHistorial


        '        Dim item As ListViewItem 'Creo el ListViewItem (item) 
        '        item = New ListViewItem(User1) 'Creo una nueva instancia de item pasandole el nombre como dato principal 

        '        If DatosHistorial.Rows(i).Item(9) = "M" Then
        '            item.ImageIndex = 0
        '        Else
        '            DatosHistorial.Rows(i).Item(9) = "F"
        '            item.ImageIndex = 1

        '        End If

        '        item.UseItemStyleForSubItems = False

        '        Try

        '            actividad = DatosHistorial.Rows(i).Item(2) & "  " ' & DatosHistorial.Rows(i).Item(3)
        '            fechaHistorial = Format(DatosHistorial.Rows(i).Item(7), "dd-MMM-yyyy") '& "   " & Format(DatosHistorial.Rows(i).Item(8), "hh:mm tt")


        '            item.SubItems.Add(fechaHistorial)
        '            item.SubItems.Add(actividad)
        '            ' item.SubItems.Add(DatosHistorial.Rows(i).Item(3))

        '            item.SubItems(1).ForeColor = Color.SteelBlue
        '            item.SubItems(2).ForeColor = Color.Blue

        '            'lstActivities.Columns(0).TextAlign = HorizontalAlignment.Right
        '            'lstActivities.Columns(1).TextAlign = HorizontalAlignment.Right
        '            'lstActivities.Columns(2).TextAlign = HorizontalAlignment.Right
        '            'lstActivities.Columns(3).TextAlign = HorizontalAlignment.Right


        '            'item.SubItems(1).ForeColor = Color.Brown
        '            ' item.SubItems.Add(Format(DatosHistorial.Rows(i).Item(7), "dd-MMM-yyyy hh:mm tt")).
        '            ' 'item.SubItems.Add(DatosHistorial.Rows(i).Item(2))

        '            'item.SubItems.Add(DatosHistorial.Rows(i).Item(3))
        '            ' item.SubItems.Add(DatosHistorial.Rows(i).Item(4))



        '        Catch ex As Exception
        '        End Try

        '        ' lstActivities.Items.Add(item)


        '        i = i + 1
        '    Loop



        'End Sub

        'Private Sub Solution(param)
        '    Dim frm As New frmReport

        '    AddOwnedForm(frm)

        '    frm.His_Id = param
        '    frm.CargarDatos(param)
        '    frm.Show()
        '    ' frmSolution.CargarDatos(param)
        '    ' frmSolution.Show()

        'End Sub
        'Private Sub Adjunto(param)

        '    Try
        '        If var.Planta = "Planta SLP" Then
        '            Process.Start("explorer.exe", "\\10.18.164.207\Adjuntos$\Reportes_tickets\" & Id & "\" & ArchivoAdjunto)

        '        Else
        '            Process.Start("explorer.exe", "\\10.18.172.30\Adjuntos\Reportes_tickets\" & Id & "\" & ArchivoAdjunto)
        '        End If




        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '    End Try

        '    ' frmSolution.CargarDatos(param)
        '    ' frmSolution.Show()
        'End Sub

        'Private Sub NewReport(HisId)
        '    'frmNewReport.Text = HisId

        '    Dim frm As New frmNewReport

        '    frm.lblNumber.Text = HisId
        '    frm.ShowDialog()

        '    CrearControles()


        '    'MessageBox.Show("Dynamic event happened!" & sender)
        'End Sub
        'Private Sub MarkAsSolution(sender, e)
        '    'Dim resp As Boolean
        '    Dim resp As Integer
        '    Dim q As Integer
        '    Dim ln As Integer
        '    Dim str() As String
        '    Dim nm As String
        '    ' Dim resp As Nullable(Of Integer)
        '    nm = sender.name
        '    str = nm.Split("_")
        '    Dim tp As String
        '    Dim param As String = ""

        '    tp = str(0)
        '    q = str(1)

        '    resp = MsgBox("Mark as solution?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)

        '    If resp = 6 Then
        '        sender.BackColor = Color.LightGreen
        '        param = "S"
        '    Else
        '        sender.BackColor = Color.WhiteSmoke
        '        param = "N"

        '    End If

        '    resp = CapaLogica.EditarSolucion(q, param)

        '    If resp = True Then
        '        'MessageBox.Show("Successfully Saved", "", MessageBoxButtons.OK, MessageBoxIcon.Information)

        '        CrearControles()

        '    End If
        '    If resp = True Then

        '    End If
        'End Sub
        'Private Sub AnswerYes(_btn As Object, e As EventArgs)



        'End Sub

        ''With pEtapa.Controls.Item("pAux" & q).Controls.Item("btnNo_" & q)
        ''    If .BackColor = Color.Red Then
        ''        .BackColor = Gris

        ''    End If
        ''End With

        ''Private Sub menu_year(ByVal intYear As Integer)
        ''    MsgBox(intYear)
        ''    'do something
        ''End Sub
        ''Private Sub txtFecha_Clicked(sender As Object, e As System.Windows.Forms.LinkClickedEventArgs)
        ''    System.Diagnostics.Process.Start(e.LinkText)
        ''End Sub

        ''Private Sub cboUsuario_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
        ''    'Me.txtUsuarioId.Text = cboUsuario.Items(cboUsuario.SelectedIndex).ItemData()
        ''    'Me.txtUsuario.Text = cboUsuario.Text

        ''End Sub

        ''Private findListView As New ListView()
        'Private Sub roundCorners(obj As Object)
        '    Dim DGP As New Drawing2D.GraphicsPath
        '    FormBorderStyle = FormBorderStyle.FixedSingle

        '    DGP.StartFigure()

        '    'TOP LEft 
        '    DGP.AddArc(New Rectangle(0, 0, 20, 20), 180, 90)
        '    DGP.AddLine(20, 0, obj.Width - 20, 0)

        '    'top right
        '    DGP.AddArc(New Rectangle(obj.Width - 40, 0, 40, 40), -90, 90)
        '    DGP.AddLine(obj.Width, 40, obj.Width, obj.Height - 40)

        '    'bottom right

        '    DGP.AddArc(New Rectangle(obj.Width - 40, obj.Height - 40, 40, 40), 0, 90)
        '    DGP.AddLine(obj.Width - 40, obj.Height, 40, obj.Height)

        '    'bottom left

        '    DGP.AddArc(New Rectangle(0, obj.Height - 40, 40, 40), 90, 90)
        '    'DGP.AddLine(obj.Width - 40, obj.Height, 40, obj.Height)
        '    DGP.CloseFigure()
        '    obj.Region = New Region(DGP)

        'End Sub
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

        'Private Sub cboTipo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)


        '    'If Me.cboTipo.Text <> Tipo Then

        '    '    DetectChanges("Tipo", Tipo, sender)

        '    'End If

        'End Sub

        'Private Sub cboStatus_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

        '    'If Me.cboStatus.Text <> Status Then

        '    '    DetectChanges("Status", Status, sender)

        '    'End If
        'End Sub

        'Private Sub txtComputerName_TextChanged(sender As System.Object, e As System.EventArgs)
        '    'If Me.txtComputerName.Text <> Nombre Then

        '    '    DetectChanges("Nombre", Nombre, sender)

        '    'End If
        'End Sub




        'Private Sub txtUsuarioId_TextChanged(sender As System.Object, e As System.EventArgs)

        '    'If Me.txtUsuarioId.Text <> UsuarioId Then

        '    '    DetectChanges("EmpleadoId", UsuarioId, sender)

        '    'End If
        'End Sub

        'Private Sub txtAnydesk_TextChanged(sender As System.Object, e As System.EventArgs)
        '    'If Me.txtAnydesk.Text <> Anydesk Then

        '    '    DetectChanges("Anydesk", Anydesk, sender)

        '    'End If
        'End Sub

        'Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
        '    Dim param As String

        '    Try

        '        lstModificaciones.Items.Clear()

        '        Dim frm As frmItems = CType(Owner, frmItems)


        '        frm.CargarDatos(frm.filtro)

        '        Me.Close()
        '        Me.Dispose()
        '    Catch ex As Exception

        '        Me.Close()
        '        Me.Dispose()
        '        Exit Sub

        '    End Try

        'End Sub

        'Private Sub txtmin_TextChanged(sender As System.Object, e As System.EventArgs)

        'End Sub

        'Private Sub nHora_ValueChanged(sender As System.Object, e As System.EventArgs)

        'End Sub

        'Private Sub nmin_ValueChanged(sender As System.Object, e As System.EventArgs)
        '    'txtTime.Text = Format(CType(nHora.Value, Decimal), "0#") & ":" & Format(CType(nmin.Value, Decimal), "0#")
        'End Sub
        'Private Sub dgvTasks_DoubleClick(sender As Object, e As System.EventArgs)
        '    Dim frm As New frmTask
        '    Dim TaskId As Integer

        '    ' sqlstring = " SELECT Tbl_Devices.,  Tbl_Devices., Tbl_Devices., Tbl_Devices."
        '    ' If dgvTasks.Rows.Count = 0 Then Exit Sub

        '    'TaskId = dgvTasks.CurrentRow.Cells(0).Value.ToString()

        '    AddOwnedForm(frm)
        '    frm.CargarDatos(TaskId)

        '    frm.ShowDialog()

        '    'Dim frm As New frmIncidentItem
        '    'Dim TicketId As Integer

        '    '' sqlstring = " SELECT Tbl_Devices.,  Tbl_Devices., Tbl_Devices., Tbl_Devices."

        '    'TicketId = dgvRequest.CurrentRow.Cells(0).Value.ToString()

        '    'AddOwnedForm(frm)
        '    'frm.CargarDatos(TicketId)

        '    'frm.ShowDialog()

        'End Sub



        'Private Sub txtUbicacion_TextChanged(sender As System.Object, e As System.EventArgs)
        '    Try
        '        DetectChanges("Ubicacion", Ubicacion, cboUbicacion.Text, "")
        '    Catch ex As Exception

        '    End Try
        'End Sub
        'Private Sub dgvTasks_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs)

        'End Sub


        'Private Sub cboClose_LostFocus(sender As Object, e As System.EventArgs)
        '    'Try
        '    '    If estadoCerrado <> cboClose.Text Then
        '    '        DetectChanges("EstadoCerrado", estadoCerrado, cboClose.Text)
        '    '    End If
        '    'Catch ex As Exception

        '    'End Try
        'End Sub
        'Private Sub cboApproval_LostFocus(sender As Object, e As System.EventArgs)
        '    Try
        '        'If Approval <> cboApproval.Text Then
        '        '    DetectChanges("Approval", Approval, cboApproval.Text)

        '        'End If
        '    Catch ex As Exception

        '    End Try
        'End Sub
        'Private Sub dtpDuedate_LostFocus(sender As Object, e As System.EventArgs)
        '    Try

        '        If fechaEntrega <> dtpDuedate.Value Then
        '            DetectChanges("fechaEntrega", fechaEntrega, Format(dtpDuedate.Value, "dd-MMM-yyyy"), "")

        '        End If
        '    Catch ex As Exception

        '    End Try
        'End Sub

        ''Private Sub cboUpdateActivity_Click(sender As System.Object, e As System.EventArgs)
        ''    Dim resp As Boolean
        ''    Dim NuevoEstado As New clsHistorial

        ''    resp = CapaLogica.UpdateTicket(lstModificaciones, Id)

        ''    If estado <> cboState.Text Then

        ''        NuevoEstado.EmpleadoId = var.UsuarioID
        ''        NuevoEstado.fecha = Now
        ''        NuevoEstado.IdReq = Id
        ''        NuevoEstado.Status = cboState.Text

        ''        resp = CapaLogica.NewState(NuevoEstado)

        ''        estado = cboState.Text






        ''    End If

        ''    If resp = True Then
        ''        MsgBox("se actualizo")
        ''    End If

        ''    CargarDatos(Id)

        ''End Sub

        ''Private Sub CmdNewTask_Click(sender As System.Object, e As System.EventArgs)



        ''End Sub

        ' ''Private Sub frmItemIncident_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        ' ''Dim p As PictureBox
        ' ''p = New PictureBox


        ' ''Dim Gp As Graphics
        ' ''Gp = p.CreateGraphics
        ' ''Gp.Clear(Color.FromKnownColor(KnownColor.Control))
        ' ''Gp.DrawEllipse(Pens.Blue, 10, 60, 60, 10)


        ' '' End Sub


        ''Private Sub cboUbicacion_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboUbicacion.SelectedIndexChanged
        ''    If Me.cboUbicacion.Text <> Ubicacion Then

        ''        DetectChanges("AreaId", Ubicacion, cboUbicacion.Items(cboUbicacion.SelectedIndex).ItemData(), "Location: " & cboUbicacion.Text)

        ''    End If
        ''End Sub

        ''Private Sub cboCategory1_LostFocus(sender As Object, e As System.EventArgs) Handles cboCategory1.LostFocus

        ''    Dim param As String = ""
        ''    Dim i, n As Integer



        ''    If Me.cboCategory1.Text = "" Then
        ''        Me.cboCategory2.Items.Clear()
        ''        Me.cboCategory2.Text = ""

        ''        Exit Sub
        ''    End If

        ''    Me.cboCategory2.Items.Clear()

        ''    'Categoria 2
        ''    Dim Categoria2 As DataTable
        ''    param = " Where Tbl_RT_Tipo.Tip_Id=" & cboCategory1.Items(cboCategory1.SelectedIndex).ItemData()
        ''    Categoria2 = CapaLogica.CatalogoCategoria2(param)
        ''    i = 0
        ''    n = Categoria2.Rows.Count

        ''    Do While i <= n - 1
        ''        Me.cboCategory2.Items.Add(New clsItem(Categoria2.Rows(i).Item(1), Categoria2.Rows(i).Item(0)))
        ''        i = i + 1
        ''    Loop
        ''    Me.cboCategory2.SelectedIndex = -1
        ''    Me.cboCategory2.Text = ""







        ''End Sub

        ''Private Sub cboCategory1_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCategory1.SelectedIndexChanged
        ''    Dim param As String = ""
        ''    Dim i, n As Integer


        ''    If Me.cboCategory1.Text <> Categoria1 Then
        ''        'param =
        ''        DetectChanges("Tip_Id", Tipo, cboCategory1.Items(cboCategory1.SelectedIndex).ItemData(), "Category 1: " & cboCategory1.Text)
        ''        Categoria1 = cboCategory1.Text


        ''        Me.cboCategory2.Items.Clear()

        ''        'Categoria 2
        ''        Dim Categoria2 As DataTable
        ''        param = " Where Tbl_RT_Tipo.Tip_Id=" & cboCategory1.Items(cboCategory1.SelectedIndex).ItemData()
        ''        Categoria2 = CapaLogica.CatalogoCategoria2(param)
        ''        i = 0
        ''        n = Categoria2.Rows.Count

        ''        Do While i <= n - 1
        ''            Me.cboCategory2.Items.Add(New clsItem(Categoria2.Rows(i).Item(1), Categoria2.Rows(i).Item(0)))
        ''            i = i + 1
        ''        Loop
        ''    End If

        ''    Me.cboCategory2.SelectedIndex = -1
        ''    Me.cboCategory2.Text = ""

        ''End Sub

        ''Private Sub cboCategory2_LostFocus(sender As Object, e As System.EventArgs) Handles cboCategory2.LostFocus
        ''    'If Trim(cboCategory2.Text) <> "" Then
        ''    '    CmdGuardar.Enabled = True
        ''    'Else
        ''    '    CmdGuardar.Enabled = False
        ''    'End If
        ''End Sub

        ''Private Sub cboCategory2_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCategory2.SelectedIndexChanged

        ''    If Me.cboCategory2.Text <> Categoria2 Then
        ''        DetectChanges("Cat_Id", Categoria2, cboCategory2.Items(cboCategory2.SelectedIndex).ItemData(), "Category 2: " & cboCategory2.Text)
        ''        Categoria2 = cboCategory2.Text
        ''    End If

        ''    If Trim(cboCategory2.Text) <> "" Then
        ''        CmdGuardar.Enabled = True
        ''    Else
        ''        CmdGuardar.Enabled = False
        ''    End If

        ''End Sub

        ''Private Sub CmdUpdate_Click(sender As System.Object, e As System.EventArgs) Handles CmdGuardar.Click
        ''    Dim resp As Boolean
        ''    Dim respcorreo As Boolean

        ''    'If cboState.Text <> "Canceled" Then
        ''    If UsuarioAsignado = "" Then
        ''        MsgBox("Unassigned Ticket", MsgBoxStyle.Exclamation, "Alert")
        ''        Exit Sub
        ''    End If
        ''    'End If

        ''    resp = CapaLogica.UpdateTicket(lstModificaciones, Id)



        ''    'Estado
        ''    If bandEstado = True Then

        ''        Dim itemState As New clsHistorial
        ''        itemState.IdReq = Id
        ''        itemState.fecha = Now
        ''        itemState.hora = Now
        ''        itemState.EmpleadoId = var.UsuarioID
        ''        itemState.parametro = "State"
        ''        itemState.descripcion = "State: " & cboState.Text
        ''        itemState.adjunto = "N"
        ''        itemState.minutos = 0


        ''        itemState.Status = cboState.Text

        ''        respcorreo = CapaLogica.NewState(itemState)

        ''        estado = cboState.Text

        ''        'generaCorreo(itemState)
        ''        generaCorreoSeguimiento(txtCorreo.Text, "")
        ''        bandEstado = False
        ''    End If


        ''    If resp = True Then

        ''        MsgBox("Saved Successfully ", MsgBoxStyle.Information, "Information")

        ''        CrearControles()
        ''        lblmod.Text = "( )"
        ''        lstModificaciones.Items.Clear()

        ''        'cerrar
        ''        Try
        ''            Dim frm As frmItems = CType(Owner, frmItems)


        ''            frm.CargarDatos(frm.filtro)

        ''            Me.Close()
        ''            Me.Dispose()
        ''        Catch ex As Exception

        ''            Me.Close()
        ''            Me.Dispose()
        ''            Exit Sub

        ''        End Try
        ''    End If



        ''End Sub

        ''Private Sub frmItemTicket_Shown(sender As Object, e As System.EventArgs) Handles Me.Shown

        ''    ' pEtapa.AutoScroll = True
        ''    '  pEtapa.VerticalScroll.Visible = True
        ''    ' pEtapa.Invalidate()

        ''    CrearControles()

        ''    '    pEtapa.VerticalScroll.Enabled = True

        ''End Sub

        ''Private Sub cboState_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboState.SelectedIndexChanged

        ''    If cboState.Text <> "Assigned" Then
        ''        CambioEstado(cboState.Text)

        ''    End If

        ''End Sub
        ''Private Sub CambioEstado(vEstado)
        ''    Try
        ''        If estado <> vEstado Then

        ''            DetectChanges("Enc_Estado", estado, vEstado, "")
        ''            estado = vEstado
        ''            bandEstado = True

        ''        End If

        ''    Catch ex As Exception

        ''    End Try
        ''End Sub
        ''Public Sub TimeWorked(fechaInicio, fechaFin)
        ''    ' Function sTiempo(dInicio As Date, dFin As Date) As String
        ''    Dim Tiempo As String
        ''    Dim vdias As Integer
        ''    Dim vHora As Integer
        ''    Dim vMin As Integer

        ''    If fechaInicio >= fechaFin Then
        ''        'MsgBox("fecha Invalida")
        ''        txtTimeWorked.ForeColor = Color.Red
        ''        bandTimeValue = False

        ''        ' Exit Sub
        ''    Else

        ''        bandTimeValue = True

        ''        ' txtTimeWorked.ForeColor = Color.Black
        ''        txtTimeWorked.ForeColor = Color.Black

        ''    End If


        ''    vHora = ((DateDiff("s", fechaInicio, fechaFin) \ 3600))
        ''    vMin = ((DateDiff("s", fechaInicio, fechaFin) \ 60) Mod 60)
        ''    txtTimeWorked.Text = Format(vHora, "00") & ":" & Format(vMin, "00")

        ''    'Tiempo = Str((DateDiff("s", fechaInicio, fechaFin) \ 86400) Mod 365) & " días, "
        ''    ' Tiempo = ((DateDiff("s", fechaInicio, fechaFin) \ 3600) Mod 24)
        ''    'Tiempo = ((DateDiff("s", fechaInicio, fechaFin) \ 60) Mod 60)

        ''    ' vdias = ((DateDiff("s", fechaInicio, fechaFin) \ 86400) Mod 365)
        ''    ' vHora = ((DateDiff("s", fechaInicio, fechaFin) \ 3600) Mod 24)
        ''    'Tiempo = Tiempo & Str(DateDiff("s", fechaInicio, fechaFin) Mod 60) & " segundos."
        ''    ' Lbl_Sec.Text = 0
        ''    ' sTiempo = Tiempo

        ''    'End Sub
        ''    ' Dim vHora As Integer = DateDiff(DateInterval.Hour, fechaInicio, fechaFin)
        ''    'Dim vMin As Integer = DateDiff(DateInterval.Minute, fechaInicio, fechaFin)
        ''    'Dim vHora As Integer = vMin / 60

        ''    ' txtTimeWorked.Text = Format(vHora, "00") & ":" & Format(vMin, "00")

        ''    ' If vMin >= 0 And vHora >= 0 Then
        ''    '  Else
        ''    'txtTimeWorked.Text = "00:00"
        ''    ' bandTimeValue = False

        ''    ' End If


        ''    'Dim vHora As Double = vMin / 60
        ''    ' Dim wY As Long = DateDiff(DateInterval.WeekOfYear, datTim1, datTim2)
        ''    'txtTime.Text = span.ToString

        ''    ' Dim span As TimeSpan = New TimeSpan(vHora, vMin, 0)
        ''    'txtTimeWorked.Text = span.ToString
        ''    'txtTimeWorked.Text = span.ToString


        ''End Sub



        ''Private Sub dtphoraFin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtphoraFin.ValueChanged
        ''    Dim fechaFin As DateTime
        ''    Dim fechaInicio As DateTime

        ''    fechaInicio = CDate(Format(dtpfechaInicio.Value, "dd-MM-yyyy") & " " & Format(dtpHoraInicio.Value, "hh:mm tt"))
        ''    fechaFin = CDate(Format(dtpfechaFin.Value, "dd-MM-yyyy") & " " & Format(dtphoraFin.Value, "hh:mm tt"))

        ''    TimeWorked(fechaInicio, fechaFin)

        ''End Sub

        ''Private Sub dtpHoraInicio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpHoraInicio.ValueChanged
        ''    Dim fechaFin As DateTime
        ''    Dim fechaInicio As DateTime

        ''    Try
        ''        fechaInicio = CDate(Format(dtpfechaInicio.Value, "dd-MM-yyyy") & " " & Format(dtpHoraInicio.Value, "hh:mm tt"))
        ''        fechaFin = CDate(Format(dtpfechaFin.Value, "dd-MM-yyyy") & " " & Format(dtphoraFin.Value, "hh:mm tt"))

        ''        TimeWorked(fechaInicio, fechaFin)
        ''    Catch ex As Exception

        ''    End Try

        ''End Sub

        ''Private Sub dtpfechaInicio_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpfechaInicio.ValueChanged
        ''    Dim fechaFin As DateTime
        ''    Dim fechaInicio As DateTime

        ''    dtpfechaFin.Value = dtpfechaInicio.Value

        ''    fechaInicio = CDate(Format(dtpfechaInicio.Value, "dd-MM-yyyy") & " " & Format(dtpHoraInicio.Value, "hh:mm tt"))
        ''    fechaFin = CDate(Format(dtpfechaFin.Value, "dd-MM-yyyy") & " " & Format(dtphoraFin.Value, "hh:mm tt"))

        ''    TimeWorked(fechaInicio, fechaFin)
        ''End Sub

        ''Private Sub dtpfechaFin_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpfechaFin.ValueChanged
        ''    Dim fechaFin As DateTime
        ''    Dim fechaInicio As DateTime

        ''    fechaInicio = CDate(Format(dtpfechaInicio.Value, "dd-MM-yyyy") & " " & Format(dtpHoraInicio.Value, "hh:mm tt"))
        ''    fechaFin = CDate(Format(dtpfechaFin.Value, "dd-MM-yyyy") & " " & Format(dtphoraFin.Value, "hh:mm tt"))

        ''    TimeWorked(fechaInicio, fechaFin)
        ''End Sub

        ''Private Sub txtTimeWorked_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTimeWorked.TextChanged

        ''End Sub

        ''Private Sub cmdAsignar_Click(sender As System.Object, e As System.EventArgs) Handles cmdAsignar.Click
        ''    Dim resp As Boolean

        ''    If cboEmpleados.Text = "" Then Exit Sub



        ''    If cboEmpleados.Text <> "" Then

        ''        Try
        ''            If UsuarioAsignado <> cboEmpleados.Text Then

        ''                DetectChanges("Enc_Emp_asignado", UsuarioAsignado, cboEmpleados.Items(cboEmpleados.SelectedIndex).ItemData(), "")
        ''                UsuarioAsignado = cboEmpleados.Text
        ''                CambioEstado("Assigned")
        ''            Else
        ''                Exit Sub
        ''            End If

        ''        Catch ex As Exception
        ''        End Try
        ''    End If

        ''    resp = CapaLogica.UpdateTicket(lstModificaciones, Id)

        ''    Dim itemState As New clsHistorial
        ''    itemState.IdReq = Id
        ''    itemState.fecha = Now
        ''    itemState.hora = Now
        ''    itemState.EmpleadoId = var.UsuarioID
        ''    itemState.parametro = "Assigned to"
        ''    itemState.descripcion = "Assigned to: " & UsuarioAsignado
        ''    itemState.Status = cboState.Text
        ''    itemState.adjunto = "N"
        ''    itemState.minutos = 0

        ''    resp = CapaLogica.NewState(itemState)

        ''    If resp = True Then
        ''        cboState.Text = "Assigned"

        ''        cboState.Enabled = True

        ''        MsgBox("Saved Successfully ", MsgBoxStyle.Information, "Information")

        ''        bandEstado = False

        ''        Dim EmpleadoIT As clsUsuario
        ''        Dim param As String = ""

        ''        '    If var.Planta = "Planta SLP" Then
        ''        param = " Where Empleado.Emp_Nombre='" & Me.cboEmpleados.Text & "'" 'And Empleado.Estado='A'"
        ''        'Else

        ''        'End If

        ''        EmpleadoIT = CapaLogica.BuscarEmpleado(param)

        ''        If Not IsDBNull(EmpleadoIT.CorreoUsuario) Then
        ''            'Me.cboEmpleados.Items.Add(New clsItem(EmpleadosIT.Rows(i).Item(1), EmpleadosIT.Rows(i).Item(0)))
        ''            '  NombreEmpleado = EmpleadosIT.Item(i).NombreDelEmpleado & " " & EmpleadosIT.Item(i).apellidoPatEmpleado & " " & EmpleadosIT.Item(i).apellidoMatEmpleado
        ''            '  Me.cboEmpleados.Items.Add(New clsItem(NombreEmpleado, EmpleadosIT.Item(i).EmpleadoID))

        ''            generaCorreo(EmpleadoIT.CorreoUsuario, EmpleadoIT.Usuario)

        ''        End If

        ''        CrearControles()
        ''        lblmod.Text = "( )"

        ''        lstModificaciones.Items.Clear()

        ''    End If



        ''End Sub
        ''Public Sub generaCorreo(para, usuario)
        ''    Dim txtCorreo As String = ""
        ''    Dim today As String = String.Format("{0:dd/MM/yyyy}", DateTime.Now)
        ''    Dim CorreoUsuario As String = ""
        ''    Try
        ''        txtCorreo = txtCorreo + "<table width=80% border=0 cellspacing=4 cellpadding=1 align=center height=131 <font face='Tahoma'>"
        ''        txtCorreo = txtCorreo + "<tr><td><h4 align=center><strong><size=3>TICKET ASIGNADO</strong></h3></td></tr>"
        ''        txtCorreo = txtCorreo + "<tr><td><h5 align=center>" & var.Planta & "</font></table><br>"

        ''        txtCorreo = txtCorreo + " <font face='Tahoma'><b>Hola  @" & usuario & "</b> se te ha asignado el siguiente Ticket: <br><br>"
        ''        txtCorreo = txtCorreo + " <b>Tipo: </b>" & TipoTicket & "<br><br>"
        ''        txtCorreo = txtCorreo + " <b>ID: </b>" & txtId.Text & "<br><br>"
        ''        txtCorreo = txtCorreo + "<b>Descripcion corta: </b>" & txtdescripcionCorta.Text & "<br><br>"
        ''        txtCorreo = txtCorreo + "<b>Descripcion: </b>" & txtDescripcion.Text & "<br><br>"

        ''        'Mail con texto
        ''        txtCorreo = txtCorreo + "<p><b>ELABORO: </b>" & txtSubmittedBy.Text & "</p>"
        ''        txtCorreo = txtCorreo + "<p><b>UBICACION: </b>" & cboUbicacion.Text & "</font></p>"

        ''        CorreoUsuario = para

        ''        EnviarCorreo(txtCorreo, CorreoUsuario, "")
        ''    Catch ex As Exception
        ''        MsgBox("error on email " & ex.Message, MsgBoxStyle.Exclamation, "Alert")

        ''    End Try
        ''End Sub
        ''Public Sub generaCorreoSeguimiento(para, usuario)
        ''    Dim txtCorreo As String = ""
        ''    Dim today As String = String.Format("{0:dd/MM/yyyy}", DateTime.Now)
        ''    Dim CorreoUsuario As String = ""
        ''    Try
        ''        txtCorreo = txtCorreo + "<table width=80% border=0 cellspacing=4 cellpadding=1 align=center height=131 <font face='Tahoma'>"
        ''        txtCorreo = txtCorreo + "<tr><td><h4 align=center><strong><size=3>TICKET</strong></h3></td></tr>"
        ''        txtCorreo = txtCorreo + "<tr><td><h5 align=center>" & var.Planta & "</font></table>"

        ''        txtCorreo = txtCorreo + "<font face='Tahoma'>"
        ''        txtCorreo = txtCorreo + " <b>Number: </b>" & txtId.Text & "<br><br>"

        ''        txtCorreo = txtCorreo + "<b>State: </b>" & cboState.Text & "<br><br>"
        ''        'Mail con texto
        ''        txtCorreo = txtCorreo + "<b>Short description: </b>" & txtdescripcionCorta.Text & "<br><br>"
        ''        txtCorreo = txtCorreo + "<p><b>Modified by: </b>" & var.UsuarioNombre & "</p>"
        ''        'txtCorreo = txtCorreo + "<b>Descripcion: </b>" & txtDescripcion.Text & "<br><br>"


        ''        txtCorreo = txtCorreo + "<p></font></p>"

        ''        CorreoUsuario = para

        ''        EnviarCorreo(txtCorreo, CorreoUsuario, "")
        ''    Catch ex As Exception
        ''        MsgBox("error on email " & ex.Message, MsgBoxStyle.Exclamation, "Alert")

        ''    End Try
        ''End Sub

        ''Public Sub EnviarCorreo(ByRef cuerpo As String, para As String, adjunto As String)

        ''    If adjunto <> "" Then
        ''        'IO.File.Copy("Q:\Materials\Readwrite\Checklist\" & "" & ".pdf", "\\10.18.172.30\adjuntos\" & "" & ".pdf")
        ''    End If

        ''    Dim elementosMail As New clsCorreo()
        ''    elementosMail.De = "notification.mx@us.sswtechnologies.com"
        ''    elementosMail.Para = para
        ''    elementosMail.Cc = "hireta@sswtechnologies.com, jlara@sswtechnologies.com, practicante-it-mxslp@sswtechnologies.com, jolvera@sswtechnologies.com"
        ''    elementosMail.Cco = ""
        ''    elementosMail.adjunto = adjunto
        ''    elementosMail.titulo = "Ticket IT  " & var.Planta & " " & txtdescripcionCorta.Text & "  ID: " & txtId.Text
        ''    elementosMail.mensaje = cuerpo
        ''    elementosMail.aplicacion = "Tickets"

        ''    Dim enviado As Boolean = CapaLogica.enviarCorreo(elementosMail)

        ''    If enviado = True Then
        ''        MessageBox.Show("Email send successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ''    End If

        ''End Sub


        ''Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)
        ''    frmNewReport.ShowDialog()
        ''End Sub


        ''Private Sub cboPriority_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboPriority.SelectedIndexChanged

        ''    If Me.cboPriority.Text <> Prioridad Then
        ''        Try
        ''            DetectChanges("Enc_Prioridad", Prioridad, cboPriority.Text, "Priority: " & cboPriority.Text)
        ''            Prioridad = cboPriority.Text
        ''        Catch ex As Exception

        ''        End Try
        ''    End If


        ''End Sub

        ''Private Sub dtpDuedate_ValueChanged(sender As System.Object, e As System.EventArgs) Handles dtpDuedate.ValueChanged
        ''    If Me.dtpDuedate.Value = fechaEntrega Then
        ''        Exit Sub
        ''    End If
        ''    Try
        ''        DetectChanges("Enc_Fecha_Entrega", fechaEntrega, Format(dtpDuedate.Value, "dd-MM-yyyy"), "Due Date: " & Format(dtpDuedate.Value, "dd-MMM-yyyy"))
        ''        Prioridad = cboPriority.Text
        ''    Catch ex As Exception

        ''    End Try

        ''    If dtpDuedate.Value < Today Then
        ''        picAlerta.Visible = True
        ''    Else
        ''        picAlerta.Visible = False

        ''    End If

        ''End Sub




        ''Private Sub cmdRegistros_Click(sender As System.Object, e As System.EventArgs) Handles cmdRegistros.Click
        ''    Dim frm As New frmDetalles


        ''    frm.cargarDatos(Id)
        ''    frm.ShowDialog()

        ''End Sub


        ''Private Sub cmdReport_Click(sender As System.Object, e As System.EventArgs) Handles cmdReport.Click
        ''    'frmNewReport.Text = HisId
        ''    Dim resp As Integer
        ''    Dim param As String = ""

        ''    resp = MsgBox("Add Report?", MsgBoxStyle.Question + MsgBoxStyle.YesNo)

        ''    If resp = 6 Then
        ''        'Nuevo Registro
        ''        Dim itemState As New clsHistorial
        ''        itemState.IdReq = Id
        ''        itemState.fecha = Now
        ''        itemState.hora = Now
        ''        itemState.EmpleadoId = var.UsuarioID
        ''        itemState.parametro = "Report"
        ''        itemState.adjunto = "N"
        ''        itemState.descripcion = "New report added"
        ''        itemState.minutos = 0
        ''        itemState.Status = ""

        ''        Dim newReport As Boolean
        ''        newReport = CapaLogica.NewState(itemState)

        ''        If newReport = True Then
        ''            MsgBox("Report added succesfully", MsgBoxStyle.Information)
        ''            CrearControles()

        ''        End If

        ''        ' param = " WHERE Tbl_RT_Historial.His_Id=" & Id
        ''    Else
        ''        Exit Sub
        ''    End If


        ''End Sub


        ''Private Sub cmdPost_Click(sender As System.Object, e As System.EventArgs) Handles cmdPost.Click
        ''    'Dim minutos As Integer
        ''    Dim resp As Boolean
        ''    Dim fechaInicio As DateTime
        ''    Dim fechaFin As DateTime
        ''    Dim diferencia As TimeSpan
        ''    Dim band As Boolean


        ''    If UsuarioAsignado = "" Then
        ''        MsgBox("Unassigned Ticket", MsgBoxStyle.Exclamation, "Alert")
        ''        Exit Sub
        ''    End If


        ''    band = Funciones.ValText("Work Notes", txtWorkNotes.Text)
        ''    If band = False Then
        ''        MsgBox("Required value " & "Work Notes", vbExclamation, "Warning")

        ''        'pnAdvertencia.Visible = True
        ''        ' lblRequired.Text = obj
        ''        Exit Sub
        ''    End If


        ''    ' band = Funciones.ValTime("Time Worked", txtTimeWorked.Text)
        ''    If bandTimeValue = False Then
        ''        MsgBox("Invalid Date Value ", vbExclamation, "Warning")
        ''        Exit Sub
        ''    End If


        ''    fechaFin = Format(dtpfechaFin.Value, "dd-MM-yyyy") & " " & Format(dtphoraFin.Value, "hh:mm:ss tt")
        ''    fechaInicio = Format(dtpfechaInicio.Value, "dd-MM-yyyy") & " " & Format(dtpHoraInicio.Value, "hh:mm:ss tt")
        ''    'fechaInicio = dtpfechaInicio.Value & " " & dtpHoraInicio.Value

        ''    diferencia = fechaFin - fechaInicio
        ''    'Console.WriteLine(minutos.TotalMinutes)

        ''    Dim Task As New clsTask
        ''    Task.Enc_Id = Me.txtId.Text
        ''    Task.descripcion = Me.txtWorkNotes.Text
        ''    Task.FechaInicio = dtpfechaInicio.Value
        ''    Task.HoraInicio = dtpHoraInicio.Value
        ''    Task.FechaTermino = dtpfechaFin.Value
        ''    Task.HoraTermino = dtphoraFin.Value
        ''    Task.EmpleadoId = var.UsuarioID
        ''    Task.PC = var.PC
        ''    Task.Minutos = diferencia.TotalMinutes
        ''    Task.parametro = "Work Notes"

        ''    resp = CapaLogica.NewWorkNotes(Task, "")

        ''    'Actualiza Time Worked de Ticket
        ''    Dim TimeTotalWorked As New TimeSpan
        ''    Dim lstTiempo As New ListView
        ''    TimeTotalWorked = TotalTime + diferencia


        ''    Dim item As ListViewItem 'Creo el ListViewItem (item) 
        ''    item = New ListViewItem() 'Creo una nueva instancia de item pasandole el nombre como dato principal 

        ''    item.SubItems.Add("Enc_Tiempo")
        ''    item.SubItems.Add("")
        ''    item.SubItems.Add(TimeTotalWorked.ToString)

        ''    lstTiempo.Items.Add(item)

        ''    resp = CapaLogica.UpdateTicket(lstTiempo, Id)

        ''    If TimeTotalWorked.Hours = 0 Then
        ''        txtTime.Text = TimeTotalWorked.Minutes & " minutes"
        ''    Else
        ''        txtTime.Text = TimeTotalWorked.Hours & " hours and " & TimeTotalWorked.Minutes & " minutes"
        ''    End If

        ''    TotalTime = TimeTotalWorked


        ''    lstTiempo.Items.Clear()

        ''    Dim itemState As New clsHistorial
        ''    itemState.IdReq = Id
        ''    itemState.fecha = Now
        ''    itemState.hora = Now
        ''    itemState.EmpleadoId = var.UsuarioID
        ''    itemState.parametro = "Work Notes"
        ''    itemState.adjunto = "N"
        ''    itemState.descripcion = Me.txtWorkNotes.Text
        ''    itemState.minutos = diferencia.TotalMinutes
        ''    itemState.Status = cboState.Text

        ''    resp = CapaLogica.NewState(itemState)

        ''    estado = cboState.Text

        ''    'generaCorreo(itemState)

        ''    If resp = True Then
        ''        MsgBox("Successfully Registered", MsgBoxStyle.Information, "Information")

        ''        CrearControles()
        ''        txtWorkNotes.Text = ""
        ''        txtTimeWorked.Text = ""
        ''    End If

        ''End Sub

        ''Private Sub cboCategory2_TextChanged(sender As Object, e As System.EventArgs) Handles cboCategory2.TextChanged
        '        If Trim(cboCategory2.Text) <> "" Then
        '            CmdGuardar.Enabled = True
        '        Else
        '            CmdGuardar.Enabled = False
        '        End If
        '    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click

        Me.Close()

    End Sub

    Private Sub lstOraciones_DoubleClick(sender As Object, e As System.EventArgs)

    End Sub

    Private Sub lstOraciones_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub CmdUp_Click(sender As System.Object, e As System.EventArgs)

    End Sub

        Private Sub RichTextBoxEx1_MouseClick(sender As Object, e As System.Windows.Forms.MouseEventArgs)
            MsgBox("test")

        End Sub

        Private Sub Button3_Click(sender As System.Object, e As System.EventArgs)
            Dim IdOracion As Integer


            ' sqlstring = "select * from  SubTemas "
            '    conexion.Open()
        'If cmbPersona.Text = "" Then Exit Sub
        'IdOracion = txtId.Text


            Dim frm As New frmNewConversation
            frm.IdOracion = IdOracion
        ' frm.IdPersona = cmbPersona.Text

            frm.ShowDialog()

        CrearControles("")





        End Sub

        Private Sub cmbConversation_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
            Dim frm As New FrmDetOracion


            ' Id = cmbConversation.Items(cmbConversation.SelectedIndex).ItemData()

        CrearControles("")

        End Sub

        Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click

        End Sub

      

        Private Sub txtTraduccion_TextChanged(sender As System.Object, e As System.EventArgs)
            'If Me.txtTraduccion.Text <> traduccion Then
            '    Try
            '        DetectChanges("Traduccion", traduccion, txtTraduccion.Text, "")
            '        traduccion = txtTraduccion.Text
            '    Catch ex As Exception

            '    End Try
            'End If
        End Sub

    Private Sub cmbPersona_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub Button3_Click_1(sender As System.Object, e As System.EventArgs)

    End Sub

        Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click

        End Sub

        Private Sub cmdAgregar_Click(sender As System.Object, e As System.EventArgs) Handles cmdAgregar.Click
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

            sqlstring = "Insert into Det_Conversation (Det_Orden, Con_Id)"
            sqlstring = sqlstring & " Values (@Det_Orden, '" & Id & "')"

            _comando.CommandText = sqlstring

            _comando.Parameters.AddWithValue("@Det_Orden", 100)

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

            ' _comando.Connection.Close()

            'If resp Then
            '    MsgBox("se guardo")

            '    CrearControles()

            'Else
            '    MsgBox("No se guardo")
            'End If

            Dim sql As String
            Dim IdDetNuevo As Integer

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

            Dim frm As New frmTransferir

            AddOwnedForm(frm)

            frm.Id = Id
            frm.IdDet = IdDetNuevo
            'frm.IdConversation = Id
            frm.ShowDialog()

            ' Dim IdOracionItem As Integer
            'Try
            '    Dim frm As FrmConversation = CType(Owner, FrmConversation)

            '    frm.CrearControles()
            '    Me.Close()

            'Catch ex As Exception

            '    Me.Close()
            '    Me.Dispose()
            '    Exit Sub

            'End Try


        End Sub

        Private Sub wait(ByVal seconds As Integer)
            For i As Integer = 0 To seconds * 100
                System.Threading.Thread.Sleep(10)
                Application.DoEvents()
            Next


        End Sub

        Private Sub cmdStop_Click(sender As System.Object, e As System.EventArgs) Handles cmdStop.Click

            If cmdStop.Text = "Stop" Then
                cmdStop.Text = "Speaking"
            Else
                cmdStop.Text = "Stop"

            End If

        End Sub

        Private Sub SpeakCompletedEventArgs()
            MsgBox("Speach Done")

        End Sub

    Private Sub cboVoice_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

#End Region


    Private Sub checkMostrarTexto_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Dim i As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim obj As New Label
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        '  If checkMostrarTexto.Text = "" Then Exit Sub

        ' If checkMostrarTexto.Text = "Mostrar Texto" Then

        For Each c In pEtapa.Controls

            nm = c.name

            'str = nm.Split("_")

            ' tp = str(0)
            'For Each cn In c
            '    nm = c.name
            '    cn.Controls.Item("txt_" & str(1)).Visible = True


            'Next


            For Each ctrl As Control In c.controls
                If TypeOf ctrl Is RichTextBox Then
                    ' Dim txtBox As TextBox = DirectCast(ctrl, TextBox)
                    ctrl.Visible = False
                End If
            Next

            ' pEtapa.Controls(c.name).Controls.Item("txt_" & str(1)).Refresh()
            ' pEtapa.Controls(c.name).Controls.Item("tra_" & str(1)).Visible = True
            'pEtapa.Controls(c.name).Controls.Item("tra_" & str(1)).Refresh()

        Next

        'checkMostrarTexto.Text = "Ocultar Texto"
        ' Else

        For Each c In pEtapa.Controls

            'nm = c.name

            'str = nm.Split("_")

            'tp = str(0)
            For Each ctrl As Control In c.controls
                If TypeOf ctrl Is RichTextBox Then
                    ' Dim txtBox As TextBox = DirectCast(ctrl, TextBox)
                    ctrl.Visible = True
                End If
            Next
            'pEtapa.Controls(c.name).Controls.Item("txt_" & str(1)).Visible = False
            'pEtapa.Controls(c.name).Controls.Item("txt_" & str(1)).Refresh()
            'pEtapa.Controls(c.name).Controls.Item("tra_" & str(1)).Visible = False
            'pEtapa.Controls(c.name).Controls.Item("tra_" & str(1)).Refresh()

        Next

        '  checkMostrarTexto.Text = "Mostrar Texto"
        'End If

    End Sub

    Private Sub cmdOraciones_Click(sender As System.Object, e As System.EventArgs)
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

        _comando.Connection.Open()

        For Each c In pEtapa.Controls

            nm = c.name

            str = nm.Split("_")

            tp = str(0)

            textoOriginal = pEtapa.Controls(c.name).Controls.Item("txt_" & str(1)).text

            textoModificado = Trim(textoOriginal.Replace("?", "")) ' Reemplaza el símbolo de ? por ""


            Dim sqlstring As String = ""

            '  If textoModificado = "" Then Exit Sub

            sqlstring = " SELECT Id, TextoPlano, Traduccion  FROM Oraciones"

            sqlstring = sqlstring & " Where TextoPlano LIKE " & "'%" & textoModificado & "%'"
            sqlstring = sqlstring & " ORDER BY Oraciones.TextoPlano ASC"

            _comando.CommandText = sqlstring

            Try
                objDataReader = _comando.ExecuteReader

                If objDataReader.HasRows Then

                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            objDataReader.Close()

        Next

        _comando.Connection.Close()





    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs)
        Dim frm As New frmTexto
        frm.Con_Id = Id
        frm.Show()

    End Sub

    Private Sub txtOrdenar_Click(sender As System.Object, e As System.EventArgs) Handles txtOrdenar.Click
        Dim frm As New frmMoverDetalleConversacion
        frm.Enc_Id = Id

        frm.Show()



    End Sub

    Private Sub FrmConversation_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint


    End Sub

    Public Sub DrawRectangleRectangle(ByVal e As PaintEventArgs)

        '' Create pen.
        'Dim blackPen As New Pen(Color.Black, 3)

        '' Create rectangle.
        'Dim rect As New Rectangle(0, 0, 200, 200)

        '' Draw rectangle to screen.
        'e.Graphics.DrawRectangle(blackPen, rect)
    End Sub

    Private Sub MyPanel_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs)
        ''  e.Graphics.DrawRectangle(Pens.Red, 5, 5, 20, 20)
        '' Create pen.
        'Dim blackPen As New Pen(Color.Red, 2)

        '' Create rectangle.
        'Dim rect As New Rectangle(0, 0, 20, 20)

        '' Draw rectangle to screen.

        'e.Graphics.DrawRectangle(blackPen, rect)
    End Sub

    Private Sub Button11_Click(sender As System.Object, e As System.EventArgs)
        Dim mypen As New Pen(Color.Red, 3)

        pEtapa.Controls.Item("pAux_" & 16260).CreateGraphics.DrawRectangle(mypen, 0, 0, 500, 50)

    End Sub

    Private Sub checkMostrarTest_CheckedChanged(sender As System.Object, e As System.EventArgs)

    End Sub


    Private Sub cmdtext_Click(sender As System.Object, e As System.EventArgs) Handles cmdtext.Click
        Dim frm As New frmTexto

        AddOwnedForm(frm)

        frm.Con_Id = Id
        frm.Show()


    End Sub

    Private Sub cmdRandom_Click(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub checkMostrarTestES_CheckedChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub checkMostrarTextoES_CheckedChanged(sender As System.Object, e As System.EventArgs)
        Dim i As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim obj As New Label
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        ' If checkMostrarTextoES.Text = "" Then Exit Sub

        'If checkMostrarTextoES.Text = "Mostrar Texto" Then

        For Each c In pEtapa.Controls

            nm = c.name

            For Each ctrl As Control In c.controls
                If TypeOf ctrl Is Label Then
                    ' Dim txtBox As TextBox = DirectCast(ctrl, TextBox)
                    ctrl.Visible = False
                End If
            Next

        Next

        ' checkMostrarTextoES.Text = "Ocultar Texto"
        ' Else

        For Each c In pEtapa.Controls


            For Each ctrl As Control In c.controls
                If TypeOf ctrl Is Label Then
                    ' Dim txtBox As TextBox = DirectCast(ctrl, TextBox)
                    ctrl.Visible = True
                End If
            Next

        Next

        ' checkMostrarTextoES.Text = "Mostrar Texto"
        ' End If
    End Sub

    Private Sub cmdImgTest_Click(sender As System.Object, e As System.EventArgs) Handles cmdImgTest.Click
        Dim pbi As New PictureBox

        pbi.Height = 100
        pbi.Width = 100
        pbi.Location = New Point(0, 0)

        pbi.BringToFront()

        Dim newpanel As New Panel

        Me.Controls.Add(newpanel)

        newpanel.Location = New Point(100, 100)


        newpanel.BringToFront()

        newpanel.Controls.Add(pbi)
    End Sub

    Private Sub cboGrupo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)

    End Sub

    Private Sub cmdfoco_Click(sender As System.Object, e As System.EventArgs) Handles cmdfoco.Click

    End Sub

    Private Sub cmdRefresh_Click(sender As System.Object, e As System.EventArgs) Handles cmdRefresh.Click
        Dim param As String


        Dim psi As New ProcessStartInfo()
        psi.FileName = "python"
        psi.Arguments = """C:\legacy\Programas\Voz_Natural\actualizaCuenta.py"""
        psi.UseShellExecute = False
        psi.RedirectStandardOutput = True
        psi.CreateNoWindow = True

        Dim p As Process = Process.Start(psi)
        Dim resultado As String = p.StandardOutput.ReadToEnd()
        p.WaitForExit()

        ' lblStatus.Text = resultado



        If cboTipo.Text = "" Then
            param = " Where Inicio='S'"
            param = param & " ORDER By OrdenInicio desc"
        Else
            param = " Where Con_tipo='" & cboTipo.Text & "'"
            param = param & " ORDER By OrdenInicio desc"

        End If
       
        CrearControles(param)

    End Sub

    Private Sub cboTipo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboTipo.SelectedIndexChanged
        Dim param As String

        If cboTipo.Text = "ALL" Then
            param = ""
        ElseIf cboTipo.Text = "Inicio" Then
            param = " Where Inicio='S'"
            param = param & " ORDER By OrdenInicio ASC"
        Else
            param = " Where Con_Tipo='" & cboTipo.Text & "'"
            param = param & " ORDER By  OrdenInicio desc"
        End If

        CrearControles(param)

    End Sub
   
    Private Sub txtBuscar_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtBuscar.TextChanged
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        Dim param As String

        If Len(txtBuscar.Text) < 3 Then Exit Sub
        'sqlstring = "SELECT Con_Id,Con_orden, Con_Titulo, Con_Cant, Con_avance, Con_tipo"
        'sqlstring = sqlstring & " from  Enc_Conversation"

        If txtBuscar.Text <> "" Then
            sqlstring = sqlstring & " Where Con_Titulo LIKE '%" + txtBuscar.Text + "%'"
        Else
            sqlstring = sqlstring & " Where Con_Titulo LIKE '%'" + txtBuscar.Text + "'%'"
        End If

        ' sqlstring = sqlstring & " ORDER By Con_orden ASC"

        CrearControles(sqlstring)

         
    End Sub

    
    Private Sub cmdInicio_Click(sender As System.Object, e As System.EventArgs) Handles cmdInicio.Click
        Dim param As String
 
        param = " Where Inicio='S'"
        param = param & " Order by OrdenInicio ASC"
        

        CrearControles(param)

    End Sub

    Private Sub cmdNuevoEncabezado_Click(sender As System.Object, e As System.EventArgs) Handles cmdNuevoEncabezado.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim IdPerson As Integer
        Dim resp As Boolean

        Dim titulo As String

        titulo = InputBox("Titulo?")

        sqlstring = "Insert into Enc_Conversation (Con_titulo, Inicio)"
        sqlstring = sqlstring & " Values ('" & titulo & "', 'S')"
        _comando.CommandText = sqlstring

        _comando.Connection.Open()

        Dim sql As String
        Dim IdNuevo As Integer
        Try
            i = _comando.ExecuteNonQuery

        Catch ex As Exception

        End Try


        Try
            If i > 0 Then
                sql = "SELECT @@IDENTITY FROM Enc_conversation"
                _comando = New SqlCommand(sql, _comando.Connection)
                Dim value As Object = _comando.ExecuteScalar
                IdNuevo = value.ToString
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        sqlstring = "Insert into Det_Conversation (Orden, Con_Id)"
        sqlstring = sqlstring & " Values (@Orden, '" & IdNuevo & "')"
        _comando.CommandText = sqlstring

        _comando.Parameters.Clear()

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


        _comando.Connection.Close()

    End Sub

    Private Sub pEtapa_Paint(sender As System.Object, e As System.Windows.Forms.PaintEventArgs) Handles pEtapa.Paint

    End Sub

    Private Sub cmdTemas_Click(sender As System.Object, e As System.EventArgs) Handles cmdTemas.Click
        FrmTemas.Show()
    End Sub

End Class
