Imports Entidades
Imports Negocios
Imports System.Data
Imports System.Data.OleDb
Imports System.Data.Sql
Imports System.Data.SqlClient
'Imports RichTextBoxEx
Imports System.IO
Imports Microsoft.Office.Interop.Word
Imports Microsoft.Office.Interop

Imports SpeechLib
Imports System.Speech.Synthesis
  
Imports System
Imports System.Media
Imports System.Windows.Forms

Public Class frmDetSubtema

    Public Id As Integer
    Public IdOracion As Integer
    Public subtemaId As Integer
    Public duracion As String = ""
    Public nodo As Integer
    Public Enc_Id As Integer
    Public Complemento As String = ""

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

   

    'Otras
    Public NombreEmpleado As String = ""
    Public ApellidoEmpleado As String = ""
    Public Anydesk As String = ""
    Public estadoCerrado As String = ""
    Public UsuarioCorreo As String = ""
    Public descripcion As String = ""
    Public descripcionCorta As String = ""
    Public estado As String = ""
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

    'Variables
    'Variables
    Public Subtema As String = ""
    Public estatus As Boolean
    Public filename As String = ""
    Public carpeta As String = ""
    Public ruta As String = ""
    Public archivo As String = ""
    Public orden As String = ""
    Public TemaId As Integer
    Public Avance As Double
    Dim avanceActual As Double
    Dim aprendidos As Integer
    Dim n As Integer

    'Traduccion
    Public TextoPlano As String = ""
    Public Oracion As String = ""
    Public secuencia As Integer
    Public tema As String

    Public traduccion As String = ""

    Public bandTimeValue As Boolean
    Public bandEstado As Boolean
    Public lstModificaciones As New ListView

    'Public Id As Integer
    'Public IdOracion As Integer
    Public paused As Boolean = False
    Public _file As Boolean

    Public speech As SpVoice = New SpVoice()
    Public speechRate As Integer = -1 ' Rango desde -10 hasta 10 
    Public volume As Integer = 80 ' Rango desde 0 hasta 100.

    Dim objtextCopy As TextBox

    Dim objtextCurr As Label
    Dim objtextOver As Label


    Private Sub frmDetSubtema_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'WebBrowser1.Document.BackColor = Color.White

        ' RichTextBoxEx1.Controls.Item("rtb").LoadFile = "C:\Legacy\Test.rtf"
        Dim test As Boolean

        '() 'Load("C:Legacy\Rtf\.rtf")
        ' Dim obj As New RichTextBoxEx.RichTextBoxEx
        '
        'obj.Controls.Item("rtb").Focus()

        CrearControles()

        CargarDatos(Id)

        CargarDatosNuevos()

        'Grupos Temas
        Dim Grupos As New DataTable

        ' Dim param As String = " WHERE Oraciones.Id=" & Id
        Dim resp As Integer

        Dim i, n As Integer
        ' Dim IdOracion As Integer
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sql As String

        ' Dim dt As New DataTable
        Dim da As New SqlDataAdapter

        sqlstring = "SELECT       Id, Tema"
        sqlstring = sqlstring & " FROM Temas"

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

        cboTipo.Items.Add("ALL")
        cboTipo.Items.Add("Saludo")
        cboTipo.Items.Add("Presentacion")
        cboTipo.Items.Add("Iniciando")
        cboTipo.Items.Add("Conversacion")
        cboTipo.Items.Add("Leccion")
        cboTipo.Items.Add("Serie")


    End Sub

    Private Sub CargarDatosNuevos()
        ' Dim txtTraduccion As TextBox
        Dim txtTraduccion As Label
        'Dim txtMinutos As TextBox
        Dim btnSolution As Button
        Dim btnUp As Button
        Dim btnDown As Button
        Dim btnDelete As Button

        Dim btnTask As Button
        Dim btnLeer As Button
        Dim btnCopiar As Button
        Dim txtParam As Label
        Dim btnAuxNo As Label

        Dim yPos As Integer
        Dim lblY As Integer

        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim criterio As String
        Dim DatosTickets As DataTable
        Dim param As String = ""
        Dim i As Integer
        Dim ticketId, ticketTipo As String

        Dim usuarios As List(Of String)
        Dim fechas As List(Of String)
        Dim Comentarios As List(Of String)
        Dim parametros As List(Of String)


        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String = ""

        sqlstring = " SELECT       SubtemaxOracion.ID, SubtemaxOracion.SubtemaId, SubtemaxOracion.OracionId, SubtemaxOracion.Orden, Oraciones.TextoPlano, Oraciones.Traduccion, Oraciones.STL"
        sqlstring = sqlstring & " FROM            SubtemaxOracion INNER JOIN"
        sqlstring = sqlstring & "                   Oraciones ON SubtemaxOracion.OracionId = Oraciones.Id"
        sqlstring = sqlstring & " WHERE  SubtemaxOracion.SubtemaId='" & Id & "'"

        sqlstring = sqlstring & " ORDER BY  SubtemaxOracion.ID ASC"

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)

            _comando.Connection.Close()

            If dt.Rows.Count > 0 Then
                DataGridView1.DataSource = dt

            End If
        Catch ex As Exception

        End Try




    End Sub
    Public Sub CargarDatos(Id)
        Dim param As String
        ' Dim param As String = " WHERE Tbl_RT_Enc.Enc_Id=" & 86
        ' Dim DatosTicket As DataTable
        Dim resp As Integer
        ' Dim Empleados As DataTable
        Dim i, n As Integer
        Dim IdOracion As Integer
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sql As String

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter


        param = " WHERE s.Id=" & Id

        sqlstring = " SELECT      s.Id, s.Subtema, s.TemaID, s.estatus, s.Descripcion, s.Comentario, s.Complemento, s.Marcado, s.Avance, s.Nodo, "
        sqlstring = sqlstring & " s.Secuencia, s.Tipo, s.Orden, s.imp, s.Estado, s.Cuenta, t.Tema, t.Grupo, s.Duracion, s.archivo, s.Con_Id"


        sqlstring = sqlstring & " FROM            Subtemas s LEFT JOIN"
        sqlstring = sqlstring & "                   Temas t ON s.TemaID = t.Id"
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
            Subtema = dt.Rows(0).Item(1)
        End If
        txtDescripcion.Text = Subtema

        If Not IsDBNull(dt.Rows(0).Item(12)) Then
            orden = dt.Rows(0).Item(12)
        End If
        txtOrden.Text = orden

        If Not IsDBNull(dt.Rows(0).Item(16)) Then
            tema = dt.Rows(0).Item(16)
        End If
        cmbGrupo.Text = tema

        If Not IsDBNull(dt.Rows(0).Item(9)) Then
            nodo = dt.Rows(0).Item(9)
        End If
        txtNodo.Text = nodo

        If Not IsDBNull(dt.Rows(0).Item(10)) Then
            secuencia = dt.Rows(0).Item(10)
        End If
        txtSecuencia.Text = secuencia

        If Not IsDBNull(dt.Rows(0).Item(4)) Then
            traduccion = dt.Rows(0).Item(4)
        End If

        'estatus
        If Not IsDBNull(dt.Rows(0).Item(3)) Then
            If dt.Rows(0).Item(3) = True Then
                estado = "APRENDI"
            Else
                estado = "Falta APRENDER"
            End If
        End If
        cboState.Text = estado

        If Not IsDBNull(dt.Rows(0).Item(8)) Then
            Avance = dt.Rows(0).Item(8) * 100
        End If
        txtAvance.Text = Avance

        If Not IsDBNull(dt.Rows(0).Item(18)) Then
            duracion = dt.Rows(0).Item(18)
        End If
        txtDuracion.Text = duracion

        If Not IsDBNull(dt.Rows(0).Item(19)) Then
            _file = dt.Rows(0).Item(19)
        End If
        chkFile.Checked = _file

        If Not IsDBNull(dt.Rows(0).Item(6)) Then
            Complemento = dt.Rows(0).Item(6)
        End If
        txtComplemento.Text = Complemento

        If Not IsDBNull(dt.Rows(0).Item(20)) Then
            Enc_Id = dt.Rows(0).Item(20)
        End If
        txtEnc_Id.Text = Enc_Id

    End Sub
    Public Sub CrearControles()
        Dim pAux As Panel
        'Dim txtNombre As TextBox
        Dim txtNombre As Label
        ' Dim txtTraduccion As TextBox
        Dim txtTraduccion As Label
        'Dim txtMinutos As TextBox
        Dim btnSolution As Button
        Dim btnUp As Button
        Dim btnDown As Button
        Dim btnDelete As Button

        Dim btnTask As Button
        Dim btnLeer As Button
        Dim btnCopiar As Button
        Dim txtParam As Label
        Dim btnAuxNo As Label

        Dim yPos As Integer
        Dim lblY As Integer

        Dim ds As New DataSet
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim criterio As String
        Dim DatosTickets As DataTable
        Dim param As String = ""
        Dim i As Integer
        Dim ticketId, ticketTipo As String

        Dim usuarios As List(Of String)
        Dim fechas As List(Of String)
        Dim Comentarios As List(Of String)
        Dim parametros As List(Of String)


        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String = ""


        Exit Sub

        sqlstring = "  SELECT        Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Det_Conversation.Det_Orden, Det_Conversation.Con_Id, Oraciones.TextoPlano, Det_Conversation.Det_Person, Det_Conversation.Det_Par, Oraciones.Traduccion, "
        sqlstring = sqlstring & " Oraciones.STL, Oraciones.Exam"
        sqlstring = sqlstring & " FROM            Det_Conversation INNER JOIN"
        sqlstring = sqlstring & "                   Oraciones ON Det_Conversation.Det_OracionId = Oraciones.Id INNER JOIN"
        sqlstring = sqlstring & "                  Enc_Conversation ON Det_Conversation.Con_Id = Enc_Conversation.Con_Id INNER JOIN"
        sqlstring = sqlstring & "                  Subtemas ON Enc_Conversation.SubtemaId = Subtemas.Id"
        sqlstring = sqlstring & " WHERE  Subtemas.Id='" & Id & "'"
        sqlstring = sqlstring & "ORDER BY Det_Conversation.Det_Orden"

       

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
        yPos = 10

        i = 0

        pEtapa.Controls.Clear()

        Dim List As New List(Of String)

        pEtapa.AutoScroll = True

        Dim person1 As Integer
        Dim person2 As Integer

        Dim p As PictureBox
        Dim bmp As Bitmap
        Dim g As Graphics

        Dim nm As String
        Dim myPen As Pen
        Dim pb As PictureBox
        Dim btnStatus As Button

        For i = 0 To n - 1

            nm = dt.Rows(i).Item(0)

            pAux = New Panel
            pAux.Name = "pAux_" & nm
            'pAux.Name = "pAux" & i

            pAux.Height = 50
            pAux.Width = 900
            'pAux.AutoSize = True
            'pAux.Size = New System.Drawing.Size(pAux.Width, 0)
            pAux.Location = New Point(0, yPos)
            pAux.BackColor = Color.Beige
            ' pAux.BorderStyle = BorderStyle.FixedSingle
            pAux.BorderStyle = BorderStyle.Fixed3D
            '  pAux.BorderStyle = BorderStyle.FixedSingle
            ' pAux.Width = 500
            ' pEtapa.Controls.Add(pAux, 0, i)
            Try
                pEtapa.Controls.Add(pAux)

            Catch ex As Exception

            End Try

            'Oracion

            'txtNombre = New TextBox
            txtNombre = New Label
            txtNombre.Name = "txt_" & dt.Rows(i).Item(0)
            ' txtNombre.Name = "txt0"
            'txtNombre.HideSelection = False
            If Not IsDBNull(dt.Rows(i).Item(4)) Then
                txtNombre.Text = dt.Rows(i).Item(4)
            End If
            txtNombre.BorderStyle = BorderStyle.None
            txtNombre.Font = New System.Drawing.Font("Arial", 11, FontStyle.Regular)

            If dt.Rows(i).Item(1) = IdOracion Then
                txtNombre.Font = New System.Drawing.Font("Arial", 11, FontStyle.Bold)
                txtNombre.ForeColor = Color.Blue

            End If

            txtNombre.AutoSize = True
            ' txtNombre.Width = 500
            txtNombre.Location = New Point(45, 5)
            '   txtNombre.BackColor = Color.LightGray
            txtNombre.Height = txtNombre.PreferredHeight
            txtNombre.Width = 600
            AddHandler txtNombre.Click, AddressOf RefreshTexto

            pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtNombre)


            ' Traduccion
            If Not IsDBNull(dt.Rows(i).Item(7)) Then
                ' txtTraduccion = New TextBox
                txtTraduccion = New Label
                ' txtMinutos.Text = Format(dt.Rows(i).Item(7), "dd/MMM hh:mm tt") & " Time Worked: " & dt.Rows(i).Item(13) & " min " '& vbCrLf & vbCrLf & dt.Rows(i).Item(3)
                txtTraduccion.Name = "tra_" & dt.Rows(i).Item(0)

                txtTraduccion.Text = dt.Rows(i).Item(7)
                txtTraduccion.BorderStyle = BorderStyle.None
                txtTraduccion.Font = New System.Drawing.Font("Arial", 9, FontStyle.Regular)
                txtTraduccion.ForeColor = Color.DimGray
                txtTraduccion.AutoSize = True
                txtTraduccion.Width = 500
                '   txtNombre.BackColor = Color.LightGray
                ' txtMinutos.Location = New Point(45, 10)
                txtTraduccion.Location = New Point(80, txtNombre.Bottom + 5)
                ' txtMinutos.Location = New Point(45, txtNombre.Bottom + 10)

                ' txtNombre.MaximumSize = New Size(txtNombre.Width, 0)
                txtTraduccion.Height = txtNombre.PreferredHeight
                ' txtNombre.TextAlign = ContentAlignment.MiddleLeft

                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(txtTraduccion)
            End If

            'Eliminar
            btnDelete = New Button
            btnDelete.Name = "btnDelete_" & dt.Rows(i).Item(0)
            btnDelete.Width = 25 : btnDelete.Height = 25 ': btnTask.Text = "Report"
            btnDelete.Location = New Point(pAux.Right - 40, 1)
            ' btnDown.Image = ImageList3.Images.Item(1)
            btnDelete.Text = "X"

            'btnDown.TextImageRelation = TextImageRelation.ImageAboveText
            'AddHandler btnDelete.Click, Sub() Delete(dt.Rows(i).Item(4))
            AddHandler btnDelete.Click, AddressOf Delete

            pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnDelete)

            'Editar
            btnTask = New Button
            btnTask.Name = "btnTask_" & dt.Rows(i).Item(1)
            btnTask.Width = 25 : btnDelete.Height = 25 ': btnTask.Text = "Report"
            btnTask.Location = New Point(pAux.Right - 40, btnDelete.Bottom + 1)
            ' btnDown.Image = ImageList3.Images.Item(1)
            btnTask.Text = "Edit"

            'btnDown.TextImageRelation = TextImageRelation.ImageAboveText
            'AddHandler btnDelete.Click, Sub() Delete(dt.Rows(i).Item(4))
            AddHandler btnTask.Click, AddressOf Editar

            pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnTask)


            'Leer
            btnLeer = New Button
            btnLeer.Name = dt.Rows(i).Item(0)
            btnLeer.Width = 25 : btnLeer.Height = 25 ': btnTask.Text = "Report"
            btnLeer.Location = New Point(btnTask.Left - 30, 1)
            'btnLeer.Text = "L"
            btnLeer.Image = ImageList4.Images.Item(3)

            'btnDown.TextImageRelation = TextImageRelation.ImageAboveText
            'AddHandler btnDelete.Click, Sub() Delete(dt.Rows(i).Item(4))
            AddHandler btnLeer.Click, AddressOf LeerTexto
            ' AddHandler btnLeer.Click, AddressOf CambiarColor
            Try
                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnLeer)

            Catch ex As Exception

            End Try

            'Copiar
            btnCopiar = New Button
            btnCopiar.Name = dt.Rows(i).Item(0)
            btnCopiar.Width = 25 : btnCopiar.Height = 25 ': btnTask.Text = "Report"
            btnCopiar.Location = New Point(btnLeer.Left - 30, 1)
            'btnLeer.Text = "L"
            btnCopiar.Image = ImageList2.Images.Item(17)

            'btnDown.TextImageRelation = TextImageRelation.ImageAboveText
            'AddHandler btnDelete.Click, Sub() Delete(dt.Rows(i).Item(4))
            AddHandler btnCopiar.Click, AddressOf CopiarTexto
            ' AddHandler btnLeer.Click, AddressOf CambiarColor
            Try
                pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnCopiar)

            Catch ex As Exception

            End Try



            'Status
            btnStatus = New Button
            btnStatus.Name = "btnStatus_" & dt.Rows(i).Item(0)
            btnStatus.Width = 35 : btnDelete.Height = 25
            btnStatus.Location = New Point(btnCopiar.Left, btnCopiar.Bottom + 0.5)

            If dt.Rows(i).Item(8) = False Then
                btnStatus.Text = "NO"
                btnStatus.BackColor = Color.LightSalmon
                myPen = New Pen(Color.LightSalmon, 1)
            Else
                btnStatus.Text = "SI"
                btnStatus.BackColor = Color.LightGreen
                myPen = New Pen(Color.LightGreen, 1)
                aprendidos += 1

            End If

            AddHandler btnStatus.Click, AddressOf StatusControl
            pEtapa.Controls.Item("pAux_" & nm).Controls.Add(btnStatus)

            ' g = pEtapa.Controls("pAux_" & 16260).CreateGraphics
            pb = New PictureBox
            pb.Name = "pb_" & dt.Rows(i).Item(0)
            pb.Width = 1200
            pb.Height = 50
            bmp = New Bitmap(1200, 50)
            pb.Image = bmp

            g = Graphics.FromImage(pb.Image)
            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
            g.DrawRectangle(myPen, 0, 0, 1195, 45)

            pEtapa.Controls.Item("pAux_" & nm).Controls.Add(pb)

            yPos = yPos + 80

        Next i



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
        Dim IdOracionItem As Integer
        Dim mypen As Pen

        nm = sender.Name
        str = nm.Split("_")
        tp = str(0)

        IdDet = str(1)

        'sqlstring = " SELECT         Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Oraciones.STL"
        'sqlstring = sqlstring & " FROM            Det_Conversation INNER JOIN Oraciones"
        'sqlstring = sqlstring & "              Oraciones ON Det_Conversation.Det_OracionId = Oraciones.Id"
        'sqlstring = sqlstring & " WHERE  Det_Conversation.Det_Con='" & IdDet & "'"

        sqlstring = " SELECT       SubtemaxOracion.ID, SubtemaxOracion.SubtemaId, SubtemaxOracion.OracionId, SubtemaxOracion.Orden, Oraciones.TextoPlano, Oraciones.Traduccion, Oraciones.STL"
        sqlstring = sqlstring & " FROM            SubtemaxOracion INNER JOIN"
        sqlstring = sqlstring & "                   Oraciones ON SubtemaxOracion.OracionId = Oraciones.Id"
        sqlstring = sqlstring & " WHERE  SubtemaxOracion.ID='" & IdDet & "'"

        sqlstring = sqlstring & " ORDER BY  SubtemaxOracion.ID ASC"

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

                IdOracionItem = objDataReader(2)

            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        _comando.Connection.Close()



        Dim Exam As String
        Exam = pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txt_" & IdDet).Text

        Try

            If sender.text = "NO" Then
                Status = True
                sender.backcolor = Color.LightGreen
                sender.text = "SI"
                aprendidos += 1
                'pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txt_" & IdDet).BackColor = Color.LightGreen
                mypen = New Pen(Color.LightGreen, 1)
            Else
                Status = False
                sender.backcolor = Color.LightSalmon
                sender.text = "NO"
                ' pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("txt_" & IdDet).BackColor = Color.LightSalmon
                mypen = New Pen(Color.LightSalmon, 1)
                aprendidos -= 1

            End If

            sqlstring = "UPDATE Oraciones SET STL = @STL"
            sqlstring = sqlstring & " WHERE Id = @Id"

            _comando.Parameters.AddWithValue("@Id", IdOracionItem)
            _comando.Parameters.AddWithValue("@STL", Status)


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
         
        pEtapa.Controls.Item("pAux_" & IdDet).Controls.Item("pb_" & IdDet).CreateGraphics.DrawRectangle(mypen, 0, 0, 1195, 45)

        'Actualiza Avance
        avanceActual = Math.Round((aprendidos / n) * 100, 0)
        DetectChanges("Cuenta", "", avanceActual, "")
        CmdGuardar_Click(sender, e)

        txtAvance.Text = avanceActual

         
    End Sub
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

            CrearControles()


        Catch ex As Exception
            MsgBox(ex.Message)
        Finally

        End Try

    End Sub
    Private Sub Delete(sender, e)
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

        sqlstring = "Delete From SubtemaxOracion "
        sqlstring = sqlstring & "  WHERE  Id = '" & IdOracion & "' "


        _comando.CommandText = sqlstring
        _comando.Connection.Open()


        Try

            i = _comando.ExecuteNonQuery

            If i > 0 Then
                'MsgBox("se guardo")
            Else
                'MsgBox("No se guardo")
            End If

            CrearControles()

        Catch ex As Exception
            MsgBox(ex.Message)
            _comando.Connection.Close()

        Finally

        End Try
    End Sub
    Private Sub Editar(sender, e)
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
        ' Dim resp As Nullable(Of Integer)
        ' obj = sender

        nm = sender.Name

        str = nm.Split("_")

        tp = str(0)

        IdOracion = str(1)

        Dim Id As Integer
        Dim TipoTicket As String
        Dim frm As New FrmDetOracion

        AddOwnedForm(frm)

        frm.IdOracion = IdOracion
        frm.CargarDatos(IdOracion)
        frm.ShowDialog()

        CrearControles()

        ''''''
        ' Editar
        ' Console.WriteLine(obj.Image)

        'IdPerson = cmbPersona.SelectedIndex

        ' resp = MsgBox("Confirmar?", MsgBoxStyle.YesNo)

        'If resp = 6 Then

        ' sqlstring = "Update Det_Conversation SET Det_Person='" & IdPerson & "'"
        '  sqlstring = sqlstring & "  WHERE Det_Con = '" & IdDet & "'"

        '_comando.CommandText = sqlstring
        '_comando.Connection.Open()


        'Try
        '    'i = _comando.ExecuteNonQuery

        '    If i > 0 Then
        '        'MsgBox("se guardo")
        '        'obj.Image = ImageList5.Images(IdPerson)
        '        'obj.Text = "test"

        '    Else
        '        'MsgBox("No se guardo")
        '    End If
        'Catch ex As Exception

        'End Try


        '' Else





        '''''
        'sqlstring = "Upda From Det_Conversation "
        'sqlstring = sqlstring & "  WHERE Con_Id = '" & Id & "' And Det_Con='" & IdOracion & "'"


        '_comando.CommandText = sqlstring
        '_comando.Connection.Open()


        'Try

        '    i = _comando.ExecuteNonQuery

        '    If i > 0 Then
        '        'MsgBox("se guardo")
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
        Dim obj As New TextBox
        ' Dim resp As Nullable(Of Integer)
        obj = sender

        nm = sender.Name

        str = nm.Split("_")
        tp = str(0)

        'IdOracion = str(1)

        sqlstring = " SELECT         Det_Conversation.Det_Con, Det_Conversation.Det_OracionId, Det_Conversation.Det_Orden, Det_Conversation.Con_Id, Oraciones.TextoPlano, Det_Person, Det_Par, Oraciones.traduccion"
        sqlstring = sqlstring & " FROM            Det_Conversation INNER JOIN"
        sqlstring = sqlstring & "              Oraciones ON Det_Conversation.Det_OracionId = Oraciones.Id"
        sqlstring = sqlstring & " WHERE  Det_Conversation.Det_Con='" & nm & "'"
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


        Try
            obj.Text = dt.Rows(0).Item(4)
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


        'Dim Id As Integer
        'Dim TipoTicket As String
        'Dim frm As New FrmDetOracion

        ' AddOwnedForm(frm)

        ' sqlstring = " SELECT Tbl_Devices.,  Tbl_Devices., Tbl_Devices., Tbl_Devices."

        ' Id = dgvOraciones.CurrentRow.Cells(5).Value.ToString()
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
        ''End If
        'frm.IdOracion = IdOracion
        'frm.CargarDatos(IdOracion)
        'frm.ShowDialog()

        ' CrearControles()

        ''''''
        ' Editar
        ' Console.WriteLine(obj.Image)

        'IdPerson = cmbPersona.SelectedIndex

        ' resp = MsgBox("Confirmar?", MsgBoxStyle.YesNo)

        'If resp = 6 Then

        ' sqlstring = "Update Det_Conversation SET Det_Person='" & IdPerson & "'"
        '  sqlstring = sqlstring & "  WHERE Det_Con = '" & IdDet & "'"

        '_comando.CommandText = sqlstring


        ' Else





        '''''
        'sqlstring = "Upda From Det_Conversation "
        'sqlstring = sqlstring & "  WHERE Con_Id = '" & Id & "' And Det_Con='" & IdOracion & "'"


        '_comando.CommandText = sqlstring
        '_comando.Connection.Open()


        'Try

        '    i = _comando.ExecuteNonQuery

        '    If i > 0 Then
        '        'MsgBox("se guardo")
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

    Private Sub SeleccionarPersona(sender, e)
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

        ' Dim resp As Nullable(Of Integer)
        nm = sender.name
        str = nm.Split("_")

        tp = str(0)
        IdDet = str(1)

        Dim Id As Integer
        Dim IdPerson As Integer
        Dim TipoTicket As String
        ' Dim frm As New FrmDetOracion
        Dim resp As Integer
        Dim obj As PictureBox
        'AddOwnedForm(frm)
        obj = sender

        ' Console.WriteLine(obj.Image)

        ' IdPerson = cmbPersona.SelectedIndex

        ' resp = MsgBox("Confirmar?", MsgBoxStyle.YesNo)

        'If resp = 6 Then

        sqlstring = "Update Det_Conversation SET Det_Person='" & IdPerson & "'"
        sqlstring = sqlstring & "  WHERE Det_Con = '" & IdDet & "'"

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


        ' Else

        'End If



        'CrearControles()





        '    CrearControles()

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    _comando.Connection.Close()

        'Finally

        'End Try
    End Sub
    Private Sub LeerTexto(sender, e)
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

        'Voice : Microsoft David - English (United States)
        'Voice:  Microsoft(James - English(Australia))
        'Voice:  Microsoft(Linda - English(Canada))
        'Voice:  Microsoft(Richard - English(Canada))
        'Voice:  Microsoft(Catherine - English(Australia))
        'Voice : Microsoft Mark - English (United States)
        'Voice : Microsoft Zira - English (United States)

        'speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(cmbVoices.SelectedIndex)

        '    speech.Resume()
        '    paused = False

        'speech.Rate = speechRate
        'speech.Volume = volume

        '' speech.Speak(dt.Rows(0).Item(4), SpeechVoiceSpeakFlags.SVSFlagsAsync)
        '' speech.Speak("Text", SpeechVoiceSpeakFlags.SVSFlagsAsync)
        'speech.Speak(dt.Rows(0).Item(4), SpeechVoiceSpeakFlags.SVSFVoiceMask)
        Dim speak As New SpeechSynthesizer
        ' speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(cmbVoices.SelectedIndex)

        If (paused) = True Then
            speech.Resume()
            paused = False

        Else
            speech.Rate = speechRate
            speech.Volume = volume
        End If

        Dim _voice As String = ""
        Try

        Catch ex As Exception

        End Try
      
        Dim person As Integer
        person = 3
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
        ' Dim pVoice As ISpVoice = CType(voice, ISpVoice)
        If Not IsNothing(objtextOver) Then
            'objtextOver.Font = New Font("arial", 9, FontStyle.Regular)
            objtextOver.BackColor = Color.Beige
            objtextOver.Refresh()

        End If

        Try
            ' objtextCurrent = pEtapa.Controls.Item("pAux_" & nm).Controls.Item("txt_" & nm)
            ' objtextCurrent.Font = New Font("Consolas", 11, FontStyle.Bold)

            objtextCurr = pEtapa.Controls.Item("pAux_" & nm).Controls.Item("txt_" & nm)
            ' objtextCurr = pEtapa.Controls.Item("pAux0").Controls.Item("txt0")
            ' objtextCurr.Font = New Font("arial", 12, FontStyle.Bold)
            'objtextCurr.Font = New Font("Consolas", 11, FontStyle.Bold)
            objtextCurr.BackColor = Color.Yellow
            'objtextCurrent.Visible = True
            objtextCurr.Refresh()
            objtextOver = objtextCurr
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim otc As SpObjectTokenCategory = New SpObjectTokenCategory()
        otc.SetId("HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Speech_OneCore\Voices")

        Dim tokenEnum As ISpeechObjectTokens = otc.EnumerateTokens()
        Dim nTokenCount As Integer = tokenEnum.Count

        Dim n As UInteger = 0
        Dim pVoice As ISpVoice = CType(speech, ISpVoice)

        ' pVoice.SetVoice(CType(sot, ISpObjectToken))
        pVoice.SetVoice(CType(tokenEnum(_voice), ISpObjectToken))
       
        Try
            pVoice.Speak(objtextCurr.Text, 0, n)

        Catch ex As Exception
        End Try


       

     



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
    'Private Sub MoveDown(sender, e)
    '    Dim _comando As SqlCommand = MetodosDatos.CrearComando()
    '    Dim sqlstring As String
    '    Dim IdOracion As Integer
    '    Dim dt As New DataTable
    '    Dim da As New SqlDataAdapter
    '    Dim i As Integer
    '    Dim pos As Integer
    '    Dim n As Integer

        '    Dim itemOver As ListViewItem
        '    Dim itemCurr As ListViewItem
        '    Dim itemSel As Integer
        '    Dim indice As Integer
        '    Dim nm As String
        '    Dim str() As String

        '    Dim q As Integer

        '    ' Dim resp As Nullable(Of Integer)
        '    nm = sender.name
        '    Str = nm.Split("_")
        '    Dim tp As String
        '    Dim param As String = ""

        '    tp = Str(0)
        '    indice = str(1)


        '    n = ListView1.Items.Count

        '    If indice = -1 Then Exit Sub


        '    itemCurr = ListView1.Items(indice)


        '    If indice = ListView1.Items.Count - 1 Then

        '        'ListView1.Items.Remove(itemCurr)

        '    Else

        '        If indice >= ListView1.Items.Count - 1 Then

        '            ListView1.Items.Remove(itemCurr)

        '        Else

        '            ListView1.Items.Remove(itemCurr)
        '            ListView1.Items.Insert(indice + 1, itemCurr)

        '        End If


        '    End If
        '    ListView1.Refresh()

        '    _comando.Connection.Open()

        '    For Each r In ListView1.Items

        '        Console.WriteLine(r.SubItems(0).Text)
        '        Console.WriteLine(r.SubItems(1).Text)
        '        Console.WriteLine(r.SubItems(2).Text)
        '        Console.WriteLine(r.index)

        '        _comando.Parameters.Clear()

        '        '   item = New ListViewItem(lstAgregar.SelectedItems(0).Text()) 'Creo una nueva instancia de item pasandole el nombre como dato principal 




        '        If r.SubItems(2).text = "Null" Then
        '            sqlstring = "UPDATE Det_Conversation SET Det_Orden = @Det_Orden"
        '            sqlstring = sqlstring & " WHERE Id = @Id"
        '            '_comando.Parameters.AddWithValue("@Det_Orden", pos + 1)

        '        Else
        '            sqlstring = "UPDATE Det_Conversation SET Det_Orden = @Det_Orden"
        '            sqlstring = sqlstring & " WHERE Det_Con = @Det_Con"

        '            '  _comando.Parameters.AddWithValue("@" & r.SubItems(1).Text, r.SubItems(3).Text)
        '            _comando.Parameters.AddWithValue("@Det_Orden", r.index)

        '        End If
        '        _comando.Parameters.AddWithValue("@Det_Con", r.SubItems(2).Text)


        '        _comando.CommandText = sqlstring


        '        i = _comando.ExecuteNonQuery


        '    Next
        '    _comando.Connection.Close()

        '    If i > 0 Then
        '    Else
        '        MsgBox("No se actualizo")
        '    End If
        '    'Bitacora
        '    'IdOracion = lstOraciones.SelectedItems(0).Text


        '    CrearControles()

        '    '_comando.CommandText = sqlstring

        '    'Try

        '    '    i = _comando.ExecuteNonQuery

        '    '    If i > 0 Then
        '    '        MsgBox("se guardo")
        '    '    Else
        '    '        MsgBox("No se guardo")
        '    '    End If

        '    '    CrearControles()

        '    'Catch ex As Exception
        '    '    MsgBox(ex.Message)
        '    'Finally

        '    'End Try
        'End Sub
        'Private Sub MoveUp(sender, e)
        '    Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        '    Dim sqlstring As String
        '    Dim IdOracion As Integer
        '    Dim dt As New DataTable
        '    Dim da As New SqlDataAdapter
        '    Dim i As Integer
        '    Dim indice As Integer
        '    Dim itemCurr As ListViewItem
        '    Dim itemOver As ListViewItem
        '    Dim itemSel As Integer
        '    Dim nm As String
        '    Dim str() As String
        '    Dim tp As String
        '    Dim param As String = ""
        '    Dim q As Integer

        '    ' Dim resp As Nullable(Of Integer)
        '    nm = sender.name
        '    Str = nm.Split("_")

        '    tp = Str(0)
        '    indice = Str(1)

        '    itemCurr = ListView1.Items(indice)


        '    'If indice = ListView1.Items.Count - 1 Then

        '    'ListView1.Items.Remove(itemCurr)
        '    '   If ListView1.SelectedItems(0).Index = -1 Then Exit Sub

        '    '  indice = ListView1.SelectedItems(0).Index
        '    'itemCurr = ListView1.SelectedItems(0)
        '    itemCurr = ListView1.Items(indice)

        '    If indice = ListView1.Items.Count - 1 Then
        '        ListView1.Items.Remove(itemCurr)
        '        ListView1.Items.Insert(indice - 1, itemCurr)
        '    Else

        '        If indice = 0 Then
        '            ' ListView1.Items.Remove(itemCurr)
        '        Else
        '            ListView1.Items.Remove(itemCurr)
        '            ListView1.Items.Insert(indice - 1, itemCurr)
        '        End If
        '    End If

        '    ListView1.Refresh()


        '    _comando.Connection.Open()


        '    For Each r In ListView1.Items


        '        _comando.Parameters.Clear()

        '        If r.SubItems(2).text = "Null" Then
        '            sqlstring = "UPDATE Det_Conversation SET Det_Orden = @Det_Orden"
        '            sqlstring = sqlstring & " WHERE Id = @Id"

        '        Else
        '            sqlstring = "UPDATE Det_Conversation SET Det_Orden = @Det_Orden"
        '            sqlstring = sqlstring & " WHERE Det_Con = @Det_Con"

        '            _comando.Parameters.AddWithValue("@Det_Orden", r.index)

        '        End If
        '        _comando.Parameters.AddWithValue("@Det_Con", r.SubItems(2).Text)



        '        Try
        '            _comando.CommandText = sqlstring

        '            i = _comando.ExecuteNonQuery


        '        Catch ex As Exception
        '            MsgBox(ex.Message)
        '        Finally

        '        End Try


        '    Next


        '    'If i > 0 Then
        '    '    MsgBox("se guardo")
        '    'Else
        '    '    MsgBox("No se guardo")
        '    'End If

        '    CrearControles()







        'End Sub
        'Private Sub Delete(sender, e)
        '    Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        '    Dim sqlstring As String
        '    Dim IdOracion As Integer
        '    Dim dt As New DataTable
        '    Dim da As New SqlDataAdapter
        '    Dim i As Integer
        '    Dim indice As Integer
        '    Dim nm As String
        '    Dim str() As String
        '    Dim tp As String
        '    Dim param As String = ""
        '    Dim q As Integer

        '    ' Dim resp As Nullable(Of Integer)
        '    nm = sender.name
        '    str = nm.Split("_")

        '    tp = str(0)
        '    IdOracion = str(1)

        '    sqlstring = "Delete From Det_Conversation "
        '    sqlstring = sqlstring & "  WHERE Con_Id = '" & Id & "' And Det_Con='" & IdOracion & "'"


        '    _comando.CommandText = sqlstring
        '    _comando.Connection.Open()


        '    Try

        '        i = _comando.ExecuteNonQuery

        '        If i > 0 Then
        '            'MsgBox("se guardo")
        '        Else
        '            'MsgBox("No se guardo")
        '        End If

        '        CrearControles()

        '    Catch ex As Exception
        '        MsgBox(ex.Message)
        '        _comando.Connection.Close()

        '    Finally

        '    End Try
        'End Sub
        'Private Sub Editar(sender, e)
    Private Sub CopiarTexto(sender, e)
        Dim i As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer
        Dim objText As New Label
        Dim objTrad As New Label

        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()

        'Objetivo: ¿¿¿¿?????

        nm = sender.Name

        str = nm.Split("_")
        tp = str(0)

        'speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(cmbVoices.SelectedIndex)
        'If (paused) = True Then
        'Else
        ' speech.Resume()
        'paused = False
        ' End If

        'speech.Rate = speechRate
        'speech.Volume = volume
        '' speech.Speak(dt.Rows(0).Item(4), SpeechVoiceSpeakFlags.SVSFlagsAsync)
        '' speech.Speak("Text", SpeechVoiceSpeakFlags.SVSFlagsAsync)
        'speech.Speak(dt.Rows(0).Item(4), SpeechVoiceSpeakFlags.SVSFVoiceMask)


        ''''leer lento
        'Private Sub Button10_Click(sender As System.Object, e As System.EventArgs) Handles Button10.Click
        'Dim dt As New DataTable
        'Dim da As New SqlDataAdapter
        ' Dim i As Integer
        'Dim indice As Integer
        'Dim nm As String
        'Dim str() As String
        ' Dim tp As String
        ' Dim param As String = ""
        ' Dim q As Integer
        ' Dim obj As New Label
        'Dim obj As New Label
        ' Dim resp As Nullable(Of Integer)
        'obj = sender
        '  Dim dt As New DataTable
        '  Dim da As New SqlDataAdapter
        '   Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        'obj = sender

        'nm = sender.Name

        'str = nm.Split("_")
        'tp = str(0)

        'IdOracion = str(1)

        'If Not IsNothing(objtextOver) Then
        'objtextOver.Font = New Font("arial", 9, FontStyle.Regular)

        ' End If
        Dim TextoCopiado As String = ""
        Try

            objTrad.Text = ""

            objText = pEtapa.Controls.Item("pAux_" & nm).Controls.Item("txt_" & nm)

            Clipboard.Clear()

            'Pega un texto al Portapapeles
           

         
            If Not IsNothing(pEtapa.Controls.Item("pAux_" & nm).Controls.Item("txt" & nm)) Then
                objTrad = pEtapa.Controls.Item("pAux_" & nm).Controls.Item("txt" & nm)
                TextoCopiado = objText.Text
            End If
            If Not IsNothing(pEtapa.Controls.Item("pAux_" & nm).Controls.Item("tra" & nm)) Then
                objTrad = pEtapa.Controls.Item("pAux_" & nm).Controls.Item("tra" & nm)
                TextoCopiado = TextoCopiado & vbCrLf & objTrad.Text
            End If
            TextoCopiado = TextoCopiado & vbCrLf & " "

            Clipboard.SetText(TextoCopiado)


            ' objtextCurr = pEtapa.Controls.Item("pAux0").Controls.Item("txt0")
            '  objtextCurr.Font = New Font("arial", 12, FontStyle.Bold)

            ' objtextOver = objtextCurr

            ' Dim speak As New SpeechSynthesizer
            ' speech.Voice = speech.GetVoices(String.Empty, String.Empty).Item(cmbVoices.SelectedIndex)



            'speech.Rate = speechRate
            'speech.Volume = volume
            'speech.Speak(objtextCurr.Text, SpeechVoiceSpeakFlags.SVSFlagsAsync)

            ' Synth_PhonemeReached(sender, e)
            ' Dim sentences As New List(Of String)()
            ' Dim start As Integer = 0
            ' Dim position As Integer



            '  End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


        ' obj.Font = New Font("arial", 12, FontStyle.Bold)
        '  Call FontColor(nm)


        ' lblString.Text = "This is an example"
        'pEtapa.Controls.Item("pAux" & i).Controls("txtNombre_1")
        '    With pEtapa.Controls.Item("pAux" & q).Controls.Item("txtNombre_1" & q)
        'With pEtapa.Controls.Item("pAux" & nm).Controls.Item("txt_" & nm)
        ' If .BackColor = Color.Red Then
        '.BackColor = Color.Gray
        '' lblScore.Text = CInt(lblScore.Text) - 1
        '  End If
        ' .BackColor = Color.Green
        'If .BackColor = Color.Red Then
        ' lblScore.Text = CInt(lblScore.Text) - 1
        ' End If


        '' End With

        'Palabra por palabra
        'Dim objtext As TextBox
        '' objtext = pEtapa.Controls.Item("pAux0").Controls.Item("txt0")
        'objtext = pEtapa.Controls.Item("pAux" & nm).Controls.Item("txt" & nm)
        'objtext.HideSelection = False


        'For Each word As String In objtext.Text.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
        '    position = objtext.Text.IndexOf(word, start)

        '    objtext.SelectionStart = position
        '    objtext.SelectionLength = Len(word)
        '    start = Len(word)
        '    speech.Speak(word, SpeechVoiceSpeakFlags.SVSFDefault)

        'Next



        ' For Each word As String In TextBox1.Text.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
        'For Each word As String In pEtapa.Controls.Item("pAux0").Controls.Item("text_1").Text.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
        'For Each word As String In objtext.Text.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
        'For Each word As String In lblString.Text.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)


        '
        'Dim s As String = "This is the first sentence in a string. " &
        '          "More sentences will follow. For example, " &
        '          "this is the third sentence. This is the " &
        '          "fourth. And this is the fifth and final " &
        '          "sentence."



        ' Extract sentences from the string.
        'Do
        'If position >= 0 Then
        'sentences.Add(objtext.Text.Substring(start, position - start + 1).Trim())




        ' position = objtext.Text.IndexOf(word, start)

        'objtext.SelectionStart = position
        'objtext.SelectionLength = Len(word)
        'start = Len(word)

        'Dim vectoraux() As String
        ''vectoraux = TextBox1.Text.Split("<=,>=,>,<,+,-,/,*")
        'vectoraux = objtext.Text.Split({" "c}, StringSplitOptions.RemoveEmptyEntries)
        ''Dim numBox As TextBox = CType(word, TextBox)
        '  numBox.SelectAll()
        ' numBox.Focus()
        ' For Each r In vectoraux

        '  Next

        ''''''''
        'sobra:
        'position = position + Len(word)
        '  i = i + 1
        'End If
        'Loop While position > 0
        'objtext.ForeColor = Color.Red
        'word.Select(0, Len(word))



        ' Console.WriteLine(word)
        'TextBox1.
        'speak.SpeakAsync(word)

        'Select Case word
        '    Case "run"
        '        'Code
        '    Case "ok"
        '        'Code
        'End Select
        'Next

        'speech.Speak(dt.Rows(0).Item(4), SpeechVoiceSpeakFlags.SVSFVoiceMask)






        'objtext.ForeColor = Color.Blue



    End Sub


    Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        'Dim sqlstring As String
        'Dim IdOracion As Integer
        'Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i As Integer
        Dim indice As Integer
        Dim nm As String
        Dim str() As String
        Dim tp As String
        Dim param As String = ""
        Dim q As Integer

        ' Dim resp As Nullable(Of Integer)
        'nm = sender.name
        'str = nm.Split("_")

        'tp = str(0)
        'IdOracion = str(1)

        'sqlstring = "Upda From Det_Conversation "
        'sqlstring = sqlstring & "  WHERE Con_Id = '" & Id & "' And Det_Con='" & IdOracion & "'"


        '_comando.CommandText = sqlstring
        '_comando.Connection.Open()


        'Try

        '    i = _comando.ExecuteNonQuery

        '    If i > 0 Then
        '        'MsgBox("se guardo")
        '    Else
        '        'MsgBox("No se guardo")
        '    End If

        '    CrearControles()

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    _comando.Connection.Close()

        'Finally

        'End Try
        'End Sub

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

        Private Sub cmdExit_Click(sender As System.Object, e As System.EventArgs) Handles cmdExit.Click
            'Me.Close()
            Dim param As String

            Try

                lstModificaciones.Items.Clear()

            Dim frm As FrmTemas = CType(Owner, FrmTemas)


            'sqlstring = " SELECT Subtemas.Id, Subtemas.orden, Subtemas.Subtema, Subtemas.estatus,Temas.Grupo, Grupos_Temas.Grupos_Temas, Subtemas.TemaID, Subtemas.Estado, Subtemas.secuencia,Subtemas.Cuenta, Subtemas.Cuenta as Avance"
            '' sqlstring = " SELECT Subtemas.Id, Subtemas.orden, Subtemas.Subtema, Subtemas.Cuenta,  Subtemas.TemaID"
            'sqlstring = sqlstring & " FROM (Subtemas INNER JOIN Temas ON Subtemas.TemaID = Temas.Id) INNER JOIN Grupos_Temas ON Temas.Grupo = Grupos_Temas.Id "
            'sqlstring = sqlstring & " Where TemaID= " & frm.IdTema
            'sqlstring = sqlstring & " ORDER BY Subtemas.orden ASC"


            'frm.cargarDatos()
            frm.CargarSubtemas(frm.filtro)
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
            'Try
            ' conexion.Open()
            ' lstOraciones.Items.Clear()

            ' buscar = Trim(Me.txtBuscar.Text)
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
            '    Console.Write(sql)
            '    cmd.Connection = conexion
            '    cmd.CommandText = sql
            '    da.SelectCommand = cmd
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

        Private Sub lstOraciones_DoubleClick(sender As Object, e As System.EventArgs)

        End Sub

        Private Sub lstOraciones_SelectedIndexChanged(sender As System.Object, e As System.EventArgs)
            'Id = lstOraciones.SelectedItems(0).Text

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

        Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
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

        Private Sub cmbConversation_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbConversation.SelectedIndexChanged
            Dim frm As New FrmDetOracion


            Id = cmbConversation.Items(cmbConversation.SelectedIndex).ItemData()

            ' CrearControles()

        End Sub

        Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
            frmNewOracion.Show()

        End Sub

        Private Sub CmdGuardar_Click(sender As System.Object, e As System.EventArgs) Handles CmdGuardar.Click
            Dim resp As Boolean
            Dim respcorreo As Boolean


            'resp = CapaLogica.UpdateTicket(lstModificaciones, Id)

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
                sqlstring = "UPDATE Subtemas SET " & r.SubItems(1).Text & " = Null"
                    sqlstring = sqlstring & " WHERE Id = @Id"

                Else
                sqlstring = "UPDATE Subtemas SET " & r.SubItems(1).Text & " = @" & r.SubItems(1).Text
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
        'Me.Close()
        Dim param As String

        Try

            lstModificaciones.Items.Clear()

            Dim frm As FrmTemas = CType(Owner, FrmTemas)

            ' frm.CargarSubtemas(frm.filtro)
            Me.Close()
            Me.Dispose()
        Catch ex As Exception

            ' Me.Close()
            ' Me.Dispose()
            Exit Sub

        End Try





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

        Private Sub txtDescripcion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDescripcion.TextChanged
        If Me.txtDescripcion.Text <> Subtema Then
            Try
                DetectChanges("Subtema", Subtema, txtDescripcion.Text, "")
                Subtema = txtDescripcion.Text
            Catch ex As Exception

            End Try
        End If
        End Sub

    Private Sub RichTextBoxEx1_Load(sender As System.Object, e As System.EventArgs)

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
                DetectChanges("estatus", ESTATUS, ESTATUS, "")
                    estado = cboState.Text
                Catch ex As Exception

                End Try
            End If
        End Sub

    Private Sub Button2_Click_1(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim Id As Integer
        Dim frm As New frmSubtema
        Dim filename As String = ""

        AddOwnedForm(frm)

        frm.ruta = "C:\Legacy\Ingles\Temas\"
        frm.carpeta = carpeta
        frm.archivo = archivo
        frm.SubtemaId = subtemaId
        frm.txtSubtema.Text = Subtema
        frm.CargarDatos(Id)
        frm.Location = New Point(950, 0)
        frm.Show()
        
         
    End Sub

    Private Sub txtOrden_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtOrden.TextChanged, txtLeccion.TextChanged
        If Me.txtOrden.Text <> orden Then
            Try
                DetectChanges("Orden", orden, txtOrden.Text, "")
                orden = txtOrden.Text
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub cmbGrupo_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbGrupo.SelectedIndexChanged
        Dim TemaIdNuevo As Integer
        TemaIdNuevo = cmbGrupo.Items(cmbGrupo.SelectedIndex).ItemData()

        If TemaId <> TemaIdNuevo Then
            Try


                DetectChanges("TemaId", "", TemaIdNuevo, "")
                TemaIdNuevo = TemaId
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub txtNodo_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtNodo.TextChanged

        If Me.txtNodo.Text = "" Then Exit Sub
        If Me.txtNodo.Text <> nodo Then
            Try
                DetectChanges("nodo", "", txtNodo.Text, "")
                nodo = txtNodo.Text
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim IdOracion As Integer


        ' sqlstring = "select * from  SubTemas "
        '    conexion.Open()
        '  If cmbPersona.Text = "" Then Exit Sub
        '  IdOracion = txtId.Text


        Dim frm As New FrmOraciones
        frm.SubtemaId = Id
        frm.lblSubtema.Text = txtDescripcion.Text
        '  frm.IdPersona = cmbPersona.Text

        frm.ShowDialog()

        CrearControles()

        'FrmOraciones.Show())

    End Sub

    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click

    End Sub

    Private Sub txtAvance_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtAvance.TextChanged

        If txtAvance.Text = "" Then Exit Sub

        Dim valor As Double
        valor = txtAvance.Text

        Try
            If valor <> Avance Then
                DetectChanges("avance", "", valor / 100, "")
                Avance = txtAvance.Text

            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub txtDuracion_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDuracion.TextChanged
        If Me.txtDuracion.Text <> duracion Then
            Try
                DetectChanges("Duracion", duracion, txtDuracion.Text, "")
                duracion = txtDuracion.Text
            Catch ex As Exception

            End Try
        End If

    End Sub

    Private Sub chkFile_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkFile.CheckedChanged


        If _file <> chkFile.Checked Then
            Try
                DetectChanges("archivo", "", chkFile.Checked, "")
                _file = chkFile.Checked
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub txtSecuencia_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSecuencia.TextChanged
        If Me.txtSecuencia.Text <> secuencia Then
            Try
                DetectChanges("Secuencia", "", txtSecuencia.Text, "")
                secuencia = txtSecuencia.Text
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub CmdWord_Click(sender As System.Object, e As System.EventArgs) Handles CmdWord.Click
        Dim resp As Integer
        Dim RutaArchivo As String
        Dim RutaArchivoWord As String

        'ruta = "C:\Users\jolvera.SSWTECHNOLOGIES\OneDrive - SSW Holding Company, LLC\Documents\_ingles\Temas\"
        ruta = "C:\Legacy\Ingles\Temas\"

        Try

            'Console.Write(filename)
            filename = Trim(txtDescripcion.Text)
            'filename = "test"
            RutaArchivo = ruta & carpeta & "\" & filename & ".rtf"
            'RutaArchivo = ruta & carpeta & "\" & filename & ".rtf"
            RutaArchivoWord = ruta & carpeta & "\" & filename & ".doc"
            'Console.WriteLine(RutaArchivo)

            'If System.IO.File.Exists(RutaArchivo) Then
            'objWord.Documents.Open(filename)
            'objWord.Visible = True
            '  Process.Start("explorer.exe", RutaArchivo)
            ' Else
            ' resp = MsgBox("No existe el archivo?" & vbCrLf & "¿ Crear Nuevo ?", vbOKCancel + vbQuestion)

            ' If resp = 6 Then


            'ruta = "C:\Users\jolvera.SSWTECHNOLOGIES\OneDrive - SSW Holding Company, LLC\Documents\_ingles\Temas\"
            'ruta = "C:\Legacy\Ingles\Temas\"
            ' resp = MsgBox("No existe el archivo?" & vbCrLf & "¿ Crear Nuevo ?", vbOKCancel + vbQuestion)
            If resp = 6 Then
            End If

            Try
                'filename = Trim(TreeView1.SelectedNode.Text)
                'filename = "test"
            Catch ex As Exception
            End Try


            'Console.WriteLine(RutaArchivo)
            'Dim objWord As New Word.Application ' Dim objDoc As Words.a
            Dim objWord As Object
            objWord = CreateObject("Word.Application")

            If System.IO.File.Exists(RutaArchivo) Then
                objWord.Documents.Open(RutaArchivo)
            Else
                objWord.Documents.Add()

            End If

            ' Process.Start("explorer.exe", RutaArchivoWord)

            ' Else
            ' objWord.Documents.Add(RutaArchivo)
            'objWord.Documents.Open(RutaArchivo & ".doc")
            '   objWord.ActiveDocument.pro()
            objWord.Visible = True
            'objWord.SaveFile(filename)

            ' Dim objDoc As Word.Document
            'objWord.Documents.Save("Test")
            '  objWord.ActiveDocument.SaveAs(filename:="" & "C:\Legacy\Ingles\Temas\" & carpeta & "\" & archivo & ".doc")

            objWord.ActiveDocument.ShowGrammaticalErrors = False
            objWord.ActiveDocument.ShowSpellingErrors = False
            '    objWord.ActiveDocument.SaveAs(filename:=






            'Dim objWord As Object

            ' objWord = New Word.Application ' Dim objDoc As Words.a
            ' objWord.Documents.Open(RutaArchivo)

            ' objWord.Documents.Open("C:\Legacy\Ingles\Temas\" & carpeta & "\" & archivo & ".doc")
            'objWord.Documents.Open("C:\Legacy\Ingles\Temas\" & carpeta & "\" & archivo & ".doc")

            'objWord = CreateObject("Word.Application")
            ' objWord.Visible = True

            ' Dim obj As New RichTextBox
            ' obj.Text = archivo
            ' obj.AppendText(archivo)
            '  obj.Font = New Font("arial", 12, FontStyle.Bold)
            '  g.DrawString("AB", New Font("Segoe UI", 10, FontStyle.Bold), arrayColorPen(c), rect1, stringFormat)

            '  objWord.SaveFile(filename)

            ' objWord = CreateObject("Word.Application")
            ' objWord.Visible = True
            ' Dim objDoc As Word.Document

            ' objDoc = objWord.Documents.Add
            'Insert some text in document
            'Dim objPara As Word.Paragraph
            'objPara = objDoc.Content.Paragraphs.Add
            'objPara.Range.Text = archivo
            'objPara.Range.Font.Bold = True
            'objPara.Format.SpaceAfter = 30
            'objPara.Range.InsertParagraphAfter()
            'objWord.Documents.Save("Test")
            'objWord.ActiveDocument.SaveAs(filename:="" & "C:\Legacy\Ingles\Temas\" & carpeta & "\" & archivo & ".doc")
            'End If
            'End If


        Catch ex As Exception

        End Try



        ' If resp = 1 Then

        ' objWord.SaveToFile("WordDocument.docx",)
        ' Else
        'MsgBox("No Creado")

        ' End If



        ' Resp = MsgBox("¿ Crear Nuevo ?", )

        ' If Resp = 1 Then


        'objDoc = objWord.Documents.Add
        'Insert some text in document
        'Dim objPara As Word.Paragraph
        'objPara = objDoc.Content.Paragraphs.Add
        'objPara.Range.Text = archivo
        'objPara.Range.Font.Bold = True



        ' End If


        'If Resp = 1 Then
        'bitacora(IdSubTema)

        'NO poner comas en el nombre del archivo


    End Sub

    Private Sub txtComplemento_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtComplemento.TextChanged
        If Me.txtComplemento.Text <> Complemento Then
            Try
                DetectChanges("Complemento", Complemento, txtComplemento.Text, "")
                Complemento = txtComplemento.Text
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub cmdTransferir_Click(sender As System.Object, e As System.EventArgs) Handles cmdTransferir.Click
        Dim _comando As SqlCommand = MetodosDatos.CrearComando()
        Dim sqlstring As String
        Dim IdOracion As Integer
        Dim dt As New DataTable
        Dim da As New SqlDataAdapter
        Dim i, j As Integer
        Dim IdPerson As Integer
        Dim resp As Boolean
        IdPerson = 3

        If txtIdConversationNew.Text = "" Then Exit Sub


        sqlstring = " SELECT       SubtemaxOracion.ID, SubtemaxOracion.SubtemaId, SubtemaxOracion.OracionId, SubtemaxOracion.Orden, Oraciones.TextoPlano, Oraciones.Traduccion, Oraciones.STL"
        sqlstring = sqlstring & " FROM            SubtemaxOracion INNER JOIN"
        sqlstring = sqlstring & "                   Oraciones ON SubtemaxOracion.OracionId = Oraciones.Id"
        sqlstring = sqlstring & " WHERE  SubtemaxOracion.SubtemaId='" & Id & "'"

        sqlstring = sqlstring & " ORDER BY  SubtemaxOracion.ID ASC"

        Try
            _comando.CommandText = sqlstring
            _comando.Connection.Open()

            da.SelectCommand = _comando

            da.Fill(dt)

            _comando.Connection.Close()
        Catch ex As Exception

        End Try

        n = dt.Rows.Count
        _comando.Connection.Open()

        For Each rw In dt.Rows

            'Console.WriteLine(r.index)
            'Console.WriteLine(r.SubItems(0).Text)
            ' Console.WriteLine(r.SubItems(1).Text)
            'Console.WriteLine(r.SubItems(2).Text)
            'Console.¿WriteLine(r.SubItems(3).Text)
            '  Console.WriteLine(r.SubItems(4).Text)

            _comando.Parameters.Clear()

            sqlstring = "Insert into det_Conversation (Det_OracionId, Det_Orden, Con_Id, Det_Person)"
            sqlstring = sqlstring & " Values ('" & rw.Item(2) & "', @Det_Orden, '" & txtIdConversationNew.Text & "', '" & IdPerson & "')"

            _comando.CommandText = sqlstring

            _comando.Parameters.AddWithValue("@Det_Orden", rw.Item(3))

            Try

                j = _comando.ExecuteNonQuery

                If j > 0 Then
                    resp = True
                Else
                    resp = False
                End If

                'dw.SubItems(4).Text = "0"

            Catch ex As Exception
                MsgBox(ex.Message)
            Finally

            End Try

        Next

        _comando.Connection.Close()
        If resp Then
            MsgBox("se guardo")
            CargarDatosNuevos()

        Else
            MsgBox("No se guardo")
        End If




    End Sub

    Private Sub cmdNuevaConversacion_Click(sender As System.Object, e As System.EventArgs) Handles cmdNuevaConversacion.Click
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

        Dim titulo As String

        titulo = Trim(txtDescripcion.Text)

        sqlstring = "Insert into Enc_Conversation (Con_Titulo, Con_tipo, SubtemaId)"
        sqlstring = sqlstring & " Values ('" & titulo & "', '" & cboTipo.Text & "', '" & Id & "')"

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

    Private Sub txtEnc_Id_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtEnc_Id.TextChanged

        If txtEnc_Id.Text = "" Then Exit Sub
          

        Try
            If txtEnc_Id.Text <> Enc_Id Then
                DetectChanges("Con_Id", "", txtEnc_Id.Text, "")
                Enc_Id = txtEnc_Id.Text

            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
