<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEscenas
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEscenas))
        Me.cmdImgTest = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.pEtapa = New System.Windows.Forms.FlowLayoutPanel()
        Me.ImageList5 = New System.Windows.Forms.ImageList(Me.components)
        Me.checkMostrarTestES = New System.Windows.Forms.CheckBox()
        Me.cmdRandom = New System.Windows.Forms.Button()
        Me.LblId = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.TextBox()
        Me.checkMostrarTest = New System.Windows.Forms.CheckBox()
        Me.cmdAudio = New System.Windows.Forms.Button()
        Me.test = New System.Windows.Forms.Button()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.cmdtext = New System.Windows.Forms.Button()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList4 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.txtEncId = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.cmdFavoritos = New System.Windows.Forms.Button()
        Me.txtFaltan = New System.Windows.Forms.Label()
        Me.cmdFaltan = New System.Windows.Forms.Button()
        Me.txtVelocidad = New System.Windows.Forms.Label()
        Me.cmdMostrarTrad = New System.Windows.Forms.Button()
        Me.cmdMostrarTexto = New System.Windows.Forms.Button()
        Me.txtVolumen = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TrackBarVolumen = New System.Windows.Forms.TrackBar()
        Me.TrackBarVelocidad = New System.Windows.Forms.TrackBar()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.lblmod = New System.Windows.Forms.Label()
        Me.CmdGuardar = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.pgrBar = New System.Windows.Forms.ProgressBar()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.MenuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OracionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.OrdenarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LeerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AgregarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FocoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AbrirCarpetaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.StatusTrip = New System.Windows.Forms.ToolStripStatusLabel()
        Me.TimerFade = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.TimerVideo = New System.Windows.Forms.Timer(Me.components)
        Me.TimerEnd = New System.Windows.Forms.Timer(Me.components)
        Me.cmdReproducidos = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        CType(Me.TrackBarVolumen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarVelocidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdImgTest
        '
        Me.cmdImgTest.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdImgTest.Location = New System.Drawing.Point(1061, 8)
        Me.cmdImgTest.Name = "cmdImgTest"
        Me.cmdImgTest.Size = New System.Drawing.Size(66, 20)
        Me.cmdImgTest.TabIndex = 400
        Me.cmdImgTest.Text = "cmdTestIMG"
        Me.cmdImgTest.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "wondicon-ui-free-speaker_111240.png")
        Me.ImageList1.Images.SetKeyName(1, "hide.png")
        Me.ImageList1.Images.SetKeyName(2, "NoLike.png")
        Me.ImageList1.Images.SetKeyName(3, "SiLike.png")
        Me.ImageList1.Images.SetKeyName(4, "estrella.png")
        Me.ImageList1.Images.SetKeyName(5, "estrellaGris.png")
        Me.ImageList1.Images.SetKeyName(6, "estrellaverde.png")
        '
        'pEtapa
        '
        Me.pEtapa.Location = New System.Drawing.Point(2, 87)
        Me.pEtapa.Name = "pEtapa"
        Me.pEtapa.Size = New System.Drawing.Size(1841, 793)
        Me.pEtapa.TabIndex = 400
        '
        'ImageList5
        '
        Me.ImageList5.ImageStream = CType(resources.GetObject("ImageList5.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList5.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList5.Images.SetKeyName(0, "icons8-usuario-50.ico")
        Me.ImageList5.Images.SetKeyName(1, "download__1_-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(2, "download-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(3, "Aaron-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(4, "melendez_1-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(5, "download__2_-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(6, "Andrews-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(7, "pixelcut-export (2).png")
        Me.ImageList5.Images.SetKeyName(8, "dra.-lea-jpg-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(9, "Morgan-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(10, "park-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(11, "asher-removebg-preview.png")
        '
        'checkMostrarTestES
        '
        Me.checkMostrarTestES.AutoSize = True
        Me.checkMostrarTestES.Checked = True
        Me.checkMostrarTestES.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkMostrarTestES.Location = New System.Drawing.Point(502, 35)
        Me.checkMostrarTestES.Name = "checkMostrarTestES"
        Me.checkMostrarTestES.Size = New System.Drawing.Size(109, 17)
        Me.checkMostrarTestES.TabIndex = 398
        Me.checkMostrarTestES.Text = "Mostrar Test ESP"
        Me.checkMostrarTestES.UseVisualStyleBackColor = True
        '
        'cmdRandom
        '
        Me.cmdRandom.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdRandom.Location = New System.Drawing.Point(1503, 6)
        Me.cmdRandom.Name = "cmdRandom"
        Me.cmdRandom.Size = New System.Drawing.Size(66, 36)
        Me.cmdRandom.TabIndex = 396
        Me.cmdRandom.TabStop = False
        Me.cmdRandom.Text = "Random"
        Me.cmdRandom.UseVisualStyleBackColor = True
        '
        'LblId
        '
        Me.LblId.AutoSize = True
        Me.LblId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblId.Location = New System.Drawing.Point(123, 35)
        Me.LblId.Name = "LblId"
        Me.LblId.Size = New System.Drawing.Size(12, 16)
        Me.LblId.TabIndex = 397
        Me.LblId.Text = "-"
        '
        'lblTitulo
        '
        Me.lblTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.lblTitulo.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(91, 3)
        Me.lblTitulo.Multiline = True
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(464, 28)
        Me.lblTitulo.TabIndex = 396
        '
        'checkMostrarTest
        '
        Me.checkMostrarTest.AutoSize = True
        Me.checkMostrarTest.Checked = True
        Me.checkMostrarTest.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkMostrarTest.Location = New System.Drawing.Point(402, 35)
        Me.checkMostrarTest.Name = "checkMostrarTest"
        Me.checkMostrarTest.Size = New System.Drawing.Size(85, 17)
        Me.checkMostrarTest.TabIndex = 395
        Me.checkMostrarTest.Text = "Mostrar Test"
        Me.checkMostrarTest.UseVisualStyleBackColor = True
        '
        'cmdAudio
        '
        Me.cmdAudio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdAudio.Location = New System.Drawing.Point(1233, 8)
        Me.cmdAudio.Name = "cmdAudio"
        Me.cmdAudio.Size = New System.Drawing.Size(56, 36)
        Me.cmdAudio.TabIndex = 393
        Me.cmdAudio.Text = "Audio"
        Me.cmdAudio.UseVisualStyleBackColor = True
        '
        'test
        '
        Me.test.Cursor = System.Windows.Forms.Cursors.Hand
        Me.test.Location = New System.Drawing.Point(1197, 9)
        Me.test.Name = "test"
        Me.test.Size = New System.Drawing.Size(30, 36)
        Me.test.TabIndex = 391
        Me.test.Text = "test"
        Me.test.UseVisualStyleBackColor = True
        '
        'cmdStop
        '
        Me.cmdStop.Location = New System.Drawing.Point(844, 6)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(58, 27)
        Me.cmdStop.TabIndex = 390
        Me.cmdStop.Text = "Stop"
        Me.cmdStop.UseVisualStyleBackColor = True
        '
        'cmdtext
        '
        Me.cmdtext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdtext.Location = New System.Drawing.Point(1127, 4)
        Me.cmdtext.Name = "cmdtext"
        Me.cmdtext.Size = New System.Drawing.Size(59, 32)
        Me.cmdtext.TabIndex = 388
        Me.cmdtext.Text = "Text to "
        Me.cmdtext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdtext.UseVisualStyleBackColor = True
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "iconfinder-document03-1622833_121957.png")
        Me.ImageList2.Images.SetKeyName(1, "document_add_256_icon-icons.com_75994.png")
        Me.ImageList2.Images.SetKeyName(2, "folder_add_icon-icons.com_74436.png")
        Me.ImageList2.Images.SetKeyName(3, "add_icon_129463.png")
        Me.ImageList2.Images.SetKeyName(4, "report-transformed.jpeg")
        Me.ImageList2.Images.SetKeyName(5, "lapiz.png")
        Me.ImageList2.Images.SetKeyName(6, "document_add_256_icon-icons.com_75994-transformed.png")
        Me.ImageList2.Images.SetKeyName(7, "documento.png")
        Me.ImageList2.Images.SetKeyName(8, "756exclamationmark_100528.png")
        Me.ImageList2.Images.SetKeyName(9, "Gallery_icon-icons.com_76885.png")
        Me.ImageList2.Images.SetKeyName(10, "checkbox_icon_216007.png")
        Me.ImageList2.Images.SetKeyName(11, "emblemdefault_103452.png")
        Me.ImageList2.Images.SetKeyName(12, "picture_photo_image_icon_131252.png")
        Me.ImageList2.Images.SetKeyName(13, "icon_Options.ico")
        Me.ImageList2.Images.SetKeyName(14, "PaperClip_4895 (3).png")
        Me.ImageList2.Images.SetKeyName(15, "burger_line_list_menu_nav_navigation_option_icon_123231.png")
        Me.ImageList2.Images.SetKeyName(16, "document_add_256_icon-icons.com_75994-transformed.png")
        Me.ImageList2.Images.SetKeyName(17, "666295.png")
        Me.ImageList2.Images.SetKeyName(18, "documento.png")
        '
        'ImageList4
        '
        Me.ImageList4.ImageStream = CType(resources.GetObject("ImageList4.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList4.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList4.Images.SetKeyName(0, "documento_-_Copy-transformed.png")
        Me.ImageList4.Images.SetKeyName(1, "avatar_people_person_profile_user_woman_icon_123359.png")
        Me.ImageList4.Images.SetKeyName(2, "user_icon-icons.com_74450 (1).ico")
        Me.ImageList4.Images.SetKeyName(3, "mask_wearing_avatar_woman_covid_coronavirus_air_pollution_icon_134540.png")
        Me.ImageList4.Images.SetKeyName(4, "userkdmfemale_person_woman_5920.png")
        Me.ImageList4.Images.SetKeyName(5, "Cool-Male-Avatars-03_34322.png")
        Me.ImageList4.Images.SetKeyName(6, "1455555019_users-9_icon-icons.com_53249.png")
        Me.ImageList4.Images.SetKeyName(7, "doctor256_24904.png")
        Me.ImageList4.Images.SetKeyName(8, "doctor_icon_134842.png")
        Me.ImageList4.Images.SetKeyName(9, "avatar_doctor_health_hospital_medical_icon_140096.png")
        Me.ImageList4.Images.SetKeyName(10, "1455555019_users-9_icon-icons.com_53249.png")
        Me.ImageList4.Images.SetKeyName(11, "iconfinder-7-avatar-2754582_120519.png")
        Me.ImageList4.Images.SetKeyName(12, "Cool-Male-Avatars-03_34322.png")
        Me.ImageList4.Images.SetKeyName(13, "business-color_business-contact-86_icon-icons.com_53469.png")
        Me.ImageList4.Images.SetKeyName(14, "1455555011_users-10_icon-icons.com_53271.png")
        Me.ImageList4.Images.SetKeyName(15, "1455555007_users-16_icon-icons.com_53274.png")
        Me.ImageList4.Images.SetKeyName(16, "Aaron Glassman.jpg")
        Me.ImageList4.Images.SetKeyName(17, "wondicon-ui-free-speaker_111240.png")
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Panel2.Controls.Add(Me.cmdReproducidos)
        Me.Panel2.Controls.Add(Me.txtEncId)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Controls.Add(Me.cmdFavoritos)
        Me.Panel2.Controls.Add(Me.txtFaltan)
        Me.Panel2.Controls.Add(Me.cmdFaltan)
        Me.Panel2.Controls.Add(Me.txtVelocidad)
        Me.Panel2.Controls.Add(Me.cmdMostrarTrad)
        Me.Panel2.Controls.Add(Me.cmdMostrarTexto)
        Me.Panel2.Controls.Add(Me.txtVolumen)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.TrackBarVolumen)
        Me.Panel2.Controls.Add(Me.TrackBarVelocidad)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.cmdRefresh)
        Me.Panel2.Controls.Add(Me.TextBox1)
        Me.Panel2.Controls.Add(Me.cmdImgTest)
        Me.Panel2.Controls.Add(Me.checkMostrarTestES)
        Me.Panel2.Controls.Add(Me.cmdRandom)
        Me.Panel2.Controls.Add(Me.LblId)
        Me.Panel2.Controls.Add(Me.lblTitulo)
        Me.Panel2.Controls.Add(Me.checkMostrarTest)
        Me.Panel2.Controls.Add(Me.cmdAudio)
        Me.Panel2.Controls.Add(Me.test)
        Me.Panel2.Controls.Add(Me.cmdStop)
        Me.Panel2.Controls.Add(Me.cmdtext)
        Me.Panel2.Controls.Add(Me.Button10)
        Me.Panel2.Controls.Add(Me.cboGrupo)
        Me.Panel2.Controls.Add(Me.lblmod)
        Me.Panel2.Controls.Add(Me.CmdGuardar)
        Me.Panel2.Controls.Add(Me.cmdExit)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 24)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1876, 57)
        Me.Panel2.TabIndex = 397
        '
        'txtEncId
        '
        Me.txtEncId.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtEncId.Location = New System.Drawing.Point(82, 33)
        Me.txtEncId.Name = "txtEncId"
        Me.txtEncId.Size = New System.Drawing.Size(36, 20)
        Me.txtEncId.TabIndex = 432
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Location = New System.Drawing.Point(773, 6)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(65, 25)
        Me.Button1.TabIndex = 431
        Me.Button1.Text = "Favoritos"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'cmdFavoritos
        '
        Me.cmdFavoritos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdFavoritos.Location = New System.Drawing.Point(626, 1)
        Me.cmdFavoritos.Name = "cmdFavoritos"
        Me.cmdFavoritos.Size = New System.Drawing.Size(79, 33)
        Me.cmdFavoritos.TabIndex = 430
        Me.cmdFavoritos.Text = "No_Favoritos"
        Me.cmdFavoritos.UseVisualStyleBackColor = True
        '
        'txtFaltan
        '
        Me.txtFaltan.AutoSize = True
        Me.txtFaltan.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFaltan.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.txtFaltan.Location = New System.Drawing.Point(646, 36)
        Me.txtFaltan.Name = "txtFaltan"
        Me.txtFaltan.Size = New System.Drawing.Size(60, 18)
        Me.txtFaltan.TabIndex = 427
        Me.txtFaltan.Text = "Faltan:"
        '
        'cmdFaltan
        '
        Me.cmdFaltan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdFaltan.Location = New System.Drawing.Point(565, 1)
        Me.cmdFaltan.Name = "cmdFaltan"
        Me.cmdFaltan.Size = New System.Drawing.Size(61, 33)
        Me.cmdFaltan.TabIndex = 426
        Me.cmdFaltan.Text = "Faltan"
        Me.cmdFaltan.UseVisualStyleBackColor = True
        '
        'txtVelocidad
        '
        Me.txtVelocidad.AutoSize = True
        Me.txtVelocidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVelocidad.Location = New System.Drawing.Point(1849, 38)
        Me.txtVelocidad.Name = "txtVelocidad"
        Me.txtVelocidad.Size = New System.Drawing.Size(15, 16)
        Me.txtVelocidad.TabIndex = 427
        Me.txtVelocidad.Text = "0"
        '
        'cmdMostrarTrad
        '
        Me.cmdMostrarTrad.Location = New System.Drawing.Point(292, 34)
        Me.cmdMostrarTrad.Name = "cmdMostrarTrad"
        Me.cmdMostrarTrad.Size = New System.Drawing.Size(84, 20)
        Me.cmdMostrarTrad.TabIndex = 425
        Me.cmdMostrarTrad.Text = "Mostrar Trad"
        Me.cmdMostrarTrad.UseVisualStyleBackColor = True
        '
        'cmdMostrarTexto
        '
        Me.cmdMostrarTexto.Location = New System.Drawing.Point(192, 34)
        Me.cmdMostrarTexto.Name = "cmdMostrarTexto"
        Me.cmdMostrarTexto.Size = New System.Drawing.Size(84, 20)
        Me.cmdMostrarTexto.TabIndex = 424
        Me.cmdMostrarTexto.Text = "Mostrar Texto"
        Me.cmdMostrarTexto.UseVisualStyleBackColor = True
        '
        'txtVolumen
        '
        Me.txtVolumen.AutoSize = True
        Me.txtVolumen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVolumen.Location = New System.Drawing.Point(1692, 28)
        Me.txtVolumen.Name = "txtVolumen"
        Me.txtVolumen.Size = New System.Drawing.Size(27, 16)
        Me.txtVolumen.TabIndex = 423
        Me.txtVolumen.Text = "0%"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(1706, 9)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 16)
        Me.Label10.TabIndex = 422
        Me.Label10.Text = "Volume"
        '
        'TrackBarVolumen
        '
        Me.TrackBarVolumen.Location = New System.Drawing.Point(1730, 8)
        Me.TrackBarVolumen.Maximum = 100
        Me.TrackBarVolumen.Name = "TrackBarVolumen"
        Me.TrackBarVolumen.Size = New System.Drawing.Size(113, 45)
        Me.TrackBarVolumen.TabIndex = 421
        Me.TrackBarVolumen.TickFrequency = 5
        Me.TrackBarVolumen.Value = 80
        '
        'TrackBarVelocidad
        '
        Me.TrackBarVelocidad.AutoSize = False
        Me.TrackBarVelocidad.Location = New System.Drawing.Point(1586, 23)
        Me.TrackBarVelocidad.Name = "TrackBarVelocidad"
        Me.TrackBarVelocidad.Size = New System.Drawing.Size(100, 27)
        Me.TrackBarVelocidad.TabIndex = 420
        Me.TrackBarVelocidad.Value = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(1603, 7)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 16)
        Me.Label9.TabIndex = 409
        Me.Label9.Text = "Velocidad"
        '
        'cmdRefresh
        '
        Me.cmdRefresh.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdRefresh.Location = New System.Drawing.Point(7, 31)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(66, 25)
        Me.cmdRefresh.TabIndex = 402
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(1372, 19)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(81, 20)
        Me.TextBox1.TabIndex = 401
        '
        'Button10
        '
        Me.Button10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button10.Location = New System.Drawing.Point(930, 5)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(66, 28)
        Me.Button10.TabIndex = 386
        Me.Button10.Text = "speak"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'cboGrupo
        '
        Me.cboGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGrupo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(1295, 16)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(184, 24)
        Me.cboGrupo.TabIndex = 385
        '
        'lblmod
        '
        Me.lblmod.AutoSize = True
        Me.lblmod.ForeColor = System.Drawing.Color.Black
        Me.lblmod.Location = New System.Drawing.Point(908, 18)
        Me.lblmod.Name = "lblmod"
        Me.lblmod.Size = New System.Drawing.Size(16, 13)
        Me.lblmod.TabIndex = 94
        Me.lblmod.Text = "[ ]"
        '
        'CmdGuardar
        '
        Me.CmdGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdGuardar.Enabled = False
        Me.CmdGuardar.Location = New System.Drawing.Point(1002, 7)
        Me.CmdGuardar.Name = "CmdGuardar"
        Me.CmdGuardar.Size = New System.Drawing.Size(53, 32)
        Me.CmdGuardar.TabIndex = 91
        Me.CmdGuardar.Text = "Save"
        Me.CmdGuardar.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdExit.Location = New System.Drawing.Point(7, 5)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(66, 25)
        Me.cmdExit.TabIndex = 0
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'ImageList3
        '
        Me.ImageList3.ImageStream = CType(resources.GetObject("ImageList3.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList3.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList3.Images.SetKeyName(0, "icon_Options.ico")
        Me.ImageList3.Images.SetKeyName(1, "burger_line_list_menu_nav_navigation_option_icon_123231.png")
        Me.ImageList3.Images.SetKeyName(2, "details_more_icon_214604.png")
        Me.ImageList3.Images.SetKeyName(3, "savetheapplication_guardar_2958 (1).png")
        Me.ImageList3.Images.SetKeyName(4, "documento.png")
        Me.ImageList3.Images.SetKeyName(5, "lapiz - Copy.png")
        Me.ImageList3.Images.SetKeyName(6, "attachment.png")
        Me.ImageList3.Images.SetKeyName(7, "comentario-positivo.png")
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 2000
        '
        'pgrBar
        '
        Me.pgrBar.Location = New System.Drawing.Point(63, 888)
        Me.pgrBar.Name = "pgrBar"
        Me.pgrBar.Size = New System.Drawing.Size(1843, 10)
        Me.pgrBar.TabIndex = 428
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.MenuToolStripMenuItem, Me.OrdenarToolStripMenuItem, Me.LeerToolStripMenuItem, Me.AgregarToolStripMenuItem, Me.FocoToolStripMenuItem, Me.AbrirCarpetaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1876, 24)
        Me.MenuStrip1.TabIndex = 429
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuToolStripMenuItem
        '
        Me.MenuToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OracionesToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        Me.MenuToolStripMenuItem.Size = New System.Drawing.Size(50, 20)
        Me.MenuToolStripMenuItem.Text = "Menu"
        '
        'OracionesToolStripMenuItem
        '
        Me.OracionesToolStripMenuItem.Name = "OracionesToolStripMenuItem"
        Me.OracionesToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.OracionesToolStripMenuItem.Text = "Oraciones"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(127, 22)
        Me.ExitToolStripMenuItem.Text = "Exit"
        '
        'OrdenarToolStripMenuItem
        '
        Me.OrdenarToolStripMenuItem.Name = "OrdenarToolStripMenuItem"
        Me.OrdenarToolStripMenuItem.Size = New System.Drawing.Size(62, 20)
        Me.OrdenarToolStripMenuItem.Text = "Ordenar"
        '
        'LeerToolStripMenuItem
        '
        Me.LeerToolStripMenuItem.Name = "LeerToolStripMenuItem"
        Me.LeerToolStripMenuItem.Size = New System.Drawing.Size(41, 20)
        Me.LeerToolStripMenuItem.Text = "Leer"
        '
        'AgregarToolStripMenuItem
        '
        Me.AgregarToolStripMenuItem.Name = "AgregarToolStripMenuItem"
        Me.AgregarToolStripMenuItem.Size = New System.Drawing.Size(61, 20)
        Me.AgregarToolStripMenuItem.Text = "Agregar"
        '
        'FocoToolStripMenuItem
        '
        Me.FocoToolStripMenuItem.Name = "FocoToolStripMenuItem"
        Me.FocoToolStripMenuItem.Size = New System.Drawing.Size(45, 20)
        Me.FocoToolStripMenuItem.Text = "Foco"
        '
        'AbrirCarpetaToolStripMenuItem
        '
        Me.AbrirCarpetaToolStripMenuItem.Name = "AbrirCarpetaToolStripMenuItem"
        Me.AbrirCarpetaToolStripMenuItem.Size = New System.Drawing.Size(89, 20)
        Me.AbrirCarpetaToolStripMenuItem.Text = "Abrir Carpeta"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Dock = System.Windows.Forms.DockStyle.None
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.StatusTrip})
        Me.StatusStrip1.Location = New System.Drawing.Point(2, 883)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(56, 22)
        Me.StatusStrip1.TabIndex = 430
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusTrip
        '
        Me.StatusTrip.Name = "StatusTrip"
        Me.StatusTrip.Size = New System.Drawing.Size(39, 17)
        Me.StatusTrip.Text = "Status"
        '
        'TimerFade
        '
        Me.TimerFade.Interval = 40
        '
        'TimerVideo
        '
        '
        'TimerEnd
        '
        Me.TimerEnd.Interval = 50
        '
        'cmdReproducidos
        '
        Me.cmdReproducidos.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdReproducidos.Location = New System.Drawing.Point(706, 1)
        Me.cmdReproducidos.Name = "cmdReproducidos"
        Me.cmdReproducidos.Size = New System.Drawing.Size(61, 33)
        Me.cmdReproducidos.TabIndex = 433
        Me.cmdReproducidos.Text = "No_Reprod"
        Me.cmdReproducidos.UseVisualStyleBackColor = True
        '
        'frmEscenas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1876, 903)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.pgrBar)
        Me.Controls.Add(Me.pEtapa)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "frmEscenas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmEscenas"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.TrackBarVolumen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarVelocidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdImgTest As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents pEtapa As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents ImageList5 As System.Windows.Forms.ImageList
    Friend WithEvents checkMostrarTestES As System.Windows.Forms.CheckBox
    Friend WithEvents cmdRandom As System.Windows.Forms.Button
    Friend WithEvents LblId As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.TextBox
    Friend WithEvents checkMostrarTest As System.Windows.Forms.CheckBox
    Friend WithEvents cmdAudio As System.Windows.Forms.Button
    Friend WithEvents test As System.Windows.Forms.Button
    Friend WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents cmdtext As System.Windows.Forms.Button
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents ImageList4 As System.Windows.Forms.ImageList
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents lblmod As System.Windows.Forms.Label
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents ImageList3 As System.Windows.Forms.ImageList
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents txtVelocidad As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents pgrBar As System.Windows.Forms.ProgressBar
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OracionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents StatusTrip As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents OrdenarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LeerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AgregarToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FocoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtVolumen As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TrackBarVolumen As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBarVelocidad As System.Windows.Forms.TrackBar
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmdMostrarTexto As System.Windows.Forms.Button
    Friend WithEvents cmdMostrarTrad As System.Windows.Forms.Button
    Friend WithEvents TimerFade As System.Windows.Forms.Timer
    Friend WithEvents cmdFaltan As System.Windows.Forms.Button
    Friend WithEvents txtFaltan As System.Windows.Forms.Label
    Friend WithEvents cmdFavoritos As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents AbrirCarpetaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents txtEncId As System.Windows.Forms.TextBox
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents TimerVideo As System.Windows.Forms.Timer
    Friend WithEvents TimerEnd As System.Windows.Forms.Timer
    Friend WithEvents cmdReproducidos As System.Windows.Forms.Button
End Class
