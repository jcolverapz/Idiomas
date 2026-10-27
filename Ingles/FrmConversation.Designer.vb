<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmConversation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmConversation))
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ToolStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.CmdUp = New System.Windows.Forms.Button()
        Me.lstOraciones = New System.Windows.Forms.ListView()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList4 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblmod = New System.Windows.Forms.Label()
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdImgTest = New System.Windows.Forms.Button()
        Me.cmdfoco = New System.Windows.Forms.Button()
        Me.checkMostrarTextoES = New System.Windows.Forms.CheckBox()
        Me.checkMostrarTestES = New System.Windows.Forms.CheckBox()
        Me.cmdRandom = New System.Windows.Forms.Button()
        Me.LblId = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblTitulo = New System.Windows.Forms.TextBox()
        Me.checkMostrarTest = New System.Windows.Forms.CheckBox()
        Me.checkMostrarTexto = New System.Windows.Forms.CheckBox()
        Me.cmdAudio = New System.Windows.Forms.Button()
        Me.cboPagina = New System.Windows.Forms.ComboBox()
        Me.test = New System.Windows.Forms.Button()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.cmdLeer = New System.Windows.Forms.Button()
        Me.cmdtext = New System.Windows.Forms.Button()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.txtOrdenar = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.CmdGuardar = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.cmdOraciones = New System.Windows.Forms.Button()
        Me.cmbGrupo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pEtapa = New System.Windows.Forms.FlowLayoutPanel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.txtOracionEN = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ImageList5 = New System.Windows.Forms.ImageList(Me.components)
        Me.TrackBarVelocidad = New System.Windows.Forms.TrackBar()
        Me.TrackBarVolumen = New System.Windows.Forms.TrackBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.lblVelocidad = New System.Windows.Forms.Label()
        Me.txtAvance = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtVolumen = New System.Windows.Forms.Label()
        Me.cmbPersona = New System.Windows.Forms.ComboBox()
        Me.Button11 = New System.Windows.Forms.Button()
        Me.StatusStrip1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pEtapa.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarVelocidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarVolumen, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.ListView1.Location = New System.Drawing.Point(1477, 496)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(93, 46)
        Me.ListView1.TabIndex = 375
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.Visible = False
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Width = 50
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1449, 181)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 16)
        Me.Label2.TabIndex = 373
        Me.Label2.Text = "Persona"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 0
        '
        'txtBuscar
        '
        Me.txtBuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(1451, 200)
        Me.txtBuscar.MaxLength = 500
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBuscar.Size = New System.Drawing.Size(288, 22)
        Me.txtBuscar.TabIndex = 371
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(1478, 454)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(66, 36)
        Me.Button2.TabIndex = 355
        Me.Button2.Text = "down"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'ToolStatus
        '
        Me.ToolStatus.Name = "ToolStatus"
        Me.ToolStatus.Size = New System.Drawing.Size(39, 17)
        Me.ToolStatus.Text = "Status"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 780)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1826, 22)
        Me.StatusStrip1.TabIndex = 379
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'CmdUp
        '
        Me.CmdUp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdUp.Location = New System.Drawing.Point(1550, 454)
        Me.CmdUp.Name = "CmdUp"
        Me.CmdUp.Size = New System.Drawing.Size(66, 36)
        Me.CmdUp.TabIndex = 376
        Me.CmdUp.Text = "Up"
        Me.CmdUp.UseVisualStyleBackColor = True
        Me.CmdUp.Visible = False
        '
        'lstOraciones
        '
        Me.lstOraciones.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lstOraciones.Location = New System.Drawing.Point(1636, 496)
        Me.lstOraciones.Name = "lstOraciones"
        Me.lstOraciones.Size = New System.Drawing.Size(148, 155)
        Me.lstOraciones.TabIndex = 372
        Me.lstOraciones.UseCompatibleStateImageBehavior = False
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
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Panel2.Controls.Add(Me.cmdImgTest)
        Me.Panel2.Controls.Add(Me.cmdfoco)
        Me.Panel2.Controls.Add(Me.checkMostrarTextoES)
        Me.Panel2.Controls.Add(Me.checkMostrarTestES)
        Me.Panel2.Controls.Add(Me.cmdRandom)
        Me.Panel2.Controls.Add(Me.LblId)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.lblTitulo)
        Me.Panel2.Controls.Add(Me.checkMostrarTest)
        Me.Panel2.Controls.Add(Me.checkMostrarTexto)
        Me.Panel2.Controls.Add(Me.cmdAudio)
        Me.Panel2.Controls.Add(Me.cboPagina)
        Me.Panel2.Controls.Add(Me.test)
        Me.Panel2.Controls.Add(Me.cmdStop)
        Me.Panel2.Controls.Add(Me.cmdLeer)
        Me.Panel2.Controls.Add(Me.cmdtext)
        Me.Panel2.Controls.Add(Me.cmdAgregar)
        Me.Panel2.Controls.Add(Me.Button10)
        Me.Panel2.Controls.Add(Me.cboGrupo)
        Me.Panel2.Controls.Add(Me.txtOrdenar)
        Me.Panel2.Controls.Add(Me.lblmod)
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Controls.Add(Me.CmdGuardar)
        Me.Panel2.Controls.Add(Me.cmdExit)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1826, 57)
        Me.Panel2.TabIndex = 356
        '
        'cmdImgTest
        '
        Me.cmdImgTest.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdImgTest.Location = New System.Drawing.Point(1062, 33)
        Me.cmdImgTest.Name = "cmdImgTest"
        Me.cmdImgTest.Size = New System.Drawing.Size(66, 20)
        Me.cmdImgTest.TabIndex = 400
        Me.cmdImgTest.Text = "cmdTestIMG"
        Me.cmdImgTest.UseVisualStyleBackColor = True
        '
        'cmdfoco
        '
        Me.cmdfoco.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdfoco.Location = New System.Drawing.Point(1587, 8)
        Me.cmdfoco.Name = "cmdfoco"
        Me.cmdfoco.Size = New System.Drawing.Size(66, 36)
        Me.cmdfoco.TabIndex = 397
        Me.cmdfoco.TabStop = False
        Me.cmdfoco.Text = "Foco"
        Me.cmdfoco.UseVisualStyleBackColor = True
        '
        'checkMostrarTextoES
        '
        Me.checkMostrarTextoES.AutoSize = True
        Me.checkMostrarTextoES.Location = New System.Drawing.Point(282, 35)
        Me.checkMostrarTextoES.Name = "checkMostrarTextoES"
        Me.checkMostrarTextoES.Size = New System.Drawing.Size(108, 17)
        Me.checkMostrarTextoES.TabIndex = 399
        Me.checkMostrarTextoES.Text = "Mostrar Texto ES"
        Me.checkMostrarTextoES.UseVisualStyleBackColor = True
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
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(79, 34)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(21, 16)
        Me.Label11.TabIndex = 397
        Me.Label11.Text = "ID"
        '
        'lblTitulo
        '
        Me.lblTitulo.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.lblTitulo.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitulo.Location = New System.Drawing.Point(91, 3)
        Me.lblTitulo.Multiline = True
        Me.lblTitulo.Name = "lblTitulo"
        Me.lblTitulo.Size = New System.Drawing.Size(526, 28)
        Me.lblTitulo.TabIndex = 396
        '
        'checkMostrarTest
        '
        Me.checkMostrarTest.AutoSize = True
        Me.checkMostrarTest.Checked = True
        Me.checkMostrarTest.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkMostrarTest.Location = New System.Drawing.Point(392, 35)
        Me.checkMostrarTest.Name = "checkMostrarTest"
        Me.checkMostrarTest.Size = New System.Drawing.Size(85, 17)
        Me.checkMostrarTest.TabIndex = 395
        Me.checkMostrarTest.Text = "Mostrar Test"
        Me.checkMostrarTest.UseVisualStyleBackColor = True
        '
        'checkMostrarTexto
        '
        Me.checkMostrarTexto.AutoSize = True
        Me.checkMostrarTexto.Location = New System.Drawing.Point(174, 36)
        Me.checkMostrarTexto.Name = "checkMostrarTexto"
        Me.checkMostrarTexto.Size = New System.Drawing.Size(91, 17)
        Me.checkMostrarTexto.TabIndex = 394
        Me.checkMostrarTexto.Text = "Mostrar Texto"
        Me.checkMostrarTexto.UseVisualStyleBackColor = True
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
        'cboPagina
        '
        Me.cboPagina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPagina.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPagina.FormattingEnabled = True
        Me.cboPagina.Items.AddRange(New Object() {"1-600", "601-1200"})
        Me.cboPagina.Location = New System.Drawing.Point(1659, 15)
        Me.cboPagina.Name = "cboPagina"
        Me.cboPagina.Size = New System.Drawing.Size(125, 24)
        Me.cboPagina.TabIndex = 392
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
        Me.cmdStop.Location = New System.Drawing.Point(844, 7)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(58, 34)
        Me.cmdStop.TabIndex = 390
        Me.cmdStop.Text = "Stop"
        Me.cmdStop.UseVisualStyleBackColor = True
        '
        'cmdLeer
        '
        Me.cmdLeer.Location = New System.Drawing.Point(764, 5)
        Me.cmdLeer.Name = "cmdLeer"
        Me.cmdLeer.Size = New System.Drawing.Size(77, 38)
        Me.cmdLeer.TabIndex = 389
        Me.cmdLeer.Text = "Leer"
        Me.cmdLeer.UseVisualStyleBackColor = True
        '
        'cmdtext
        '
        Me.cmdtext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdtext.Location = New System.Drawing.Point(1126, 5)
        Me.cmdtext.Name = "cmdtext"
        Me.cmdtext.Size = New System.Drawing.Size(59, 32)
        Me.cmdtext.TabIndex = 388
        Me.cmdtext.Text = "Text to "
        Me.cmdtext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdtext.UseVisualStyleBackColor = True
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdAgregar.Location = New System.Drawing.Point(1061, 3)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(59, 30)
        Me.cmdAgregar.TabIndex = 388
        Me.cmdAgregar.Text = "Agregar"
        Me.cmdAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAgregar.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button10.Location = New System.Drawing.Point(930, 5)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(66, 36)
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
        'txtOrdenar
        '
        Me.txtOrdenar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtOrdenar.Location = New System.Drawing.Point(623, 6)
        Me.txtOrdenar.Name = "txtOrdenar"
        Me.txtOrdenar.Size = New System.Drawing.Size(66, 36)
        Me.txtOrdenar.TabIndex = 385
        Me.txtOrdenar.TabStop = False
        Me.txtOrdenar.Text = "Ordenar"
        Me.txtOrdenar.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(695, 3)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(59, 41)
        Me.Button4.TabIndex = 355
        Me.Button4.Text = "Nueva Oracion"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button4.UseVisualStyleBackColor = True
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
        Me.cmdExit.Location = New System.Drawing.Point(7, 6)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(66, 36)
        Me.cmdExit.TabIndex = 0
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'cmdOraciones
        '
        Me.cmdOraciones.Location = New System.Drawing.Point(1479, 548)
        Me.cmdOraciones.Name = "cmdOraciones"
        Me.cmdOraciones.Size = New System.Drawing.Size(65, 42)
        Me.cmdOraciones.TabIndex = 395
        Me.cmdOraciones.Text = "Revisar Oraciones"
        Me.cmdOraciones.UseVisualStyleBackColor = True
        '
        'cmbGrupo
        '
        Me.cmbGrupo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGrupo.FormattingEnabled = True
        Me.cmbGrupo.Location = New System.Drawing.Point(1134, 18)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(230, 24)
        Me.cmbGrupo.TabIndex = 369
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1016, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 368
        Me.Label1.Text = "Grupo"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(1619, 425)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 14)
        Me.Label5.TabIndex = 367
        Me.Label5.Text = "Agregar"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(1622, 449)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 41)
        Me.Button1.TabIndex = 366
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pEtapa
        '
        Me.pEtapa.Controls.Add(Me.Panel3)
        Me.pEtapa.Location = New System.Drawing.Point(7, 63)
        Me.pEtapa.Name = "pEtapa"
        Me.pEtapa.Size = New System.Drawing.Size(1412, 714)
        Me.pEtapa.TabIndex = 364
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.Transparent
        Me.Panel3.Controls.Add(Me.PictureBox1)
        Me.Panel3.Location = New System.Drawing.Point(3, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(487, 392)
        Me.Panel3.TabIndex = 397
        Me.Panel3.Visible = False
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(487, 392)
        Me.PictureBox1.TabIndex = 397
        Me.PictureBox1.TabStop = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "wondicon-ui-free-speaker_111240.png")
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.Location = New System.Drawing.Point(88, 0)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(33, 16)
        Me.lblTipo.TabIndex = 358
        Me.lblTipo.Text = "Item"
        Me.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtId
        '
        Me.txtId.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.Location = New System.Drawing.Point(131, -3)
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(75, 22)
        Me.txtId.TabIndex = 357
        Me.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtOracionEN
        '
        Me.txtOracionEN.BackColor = System.Drawing.Color.White
        Me.txtOracionEN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOracionEN.Location = New System.Drawing.Point(1614, 280)
        Me.txtOracionEN.MaxLength = 500
        Me.txtOracionEN.Multiline = True
        Me.txtOracionEN.Name = "txtOracionEN"
        Me.txtOracionEN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOracionEN.Size = New System.Drawing.Size(73, 43)
        Me.txtOracionEN.TabIndex = 380
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1611, 326)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 16)
        Me.Label3.TabIndex = 381
        Me.Label3.Text = "Oracion"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1737, 385)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 14)
        Me.Label4.TabIndex = 383
        Me.Label4.Text = "Agregar"
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(1740, 345)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(40, 41)
        Me.Button3.TabIndex = 382
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = True
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
        'TrackBarVelocidad
        '
        Me.TrackBarVelocidad.AutoSize = False
        Me.TrackBarVelocidad.Location = New System.Drawing.Point(1425, 103)
        Me.TrackBarVelocidad.Minimum = -10
        Me.TrackBarVelocidad.Name = "TrackBarVelocidad"
        Me.TrackBarVelocidad.Size = New System.Drawing.Size(172, 27)
        Me.TrackBarVelocidad.TabIndex = 385
        Me.TrackBarVelocidad.Value = -3
        '
        'TrackBarVolumen
        '
        Me.TrackBarVolumen.Location = New System.Drawing.Point(1769, 133)
        Me.TrackBarVolumen.Maximum = 100
        Me.TrackBarVolumen.Name = "TrackBarVolumen"
        Me.TrackBarVolumen.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBarVolumen.Size = New System.Drawing.Size(45, 152)
        Me.TrackBarVolumen.TabIndex = 386
        Me.TrackBarVolumen.TickFrequency = 5
        Me.TrackBarVolumen.Value = 80
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Button7)
        Me.Panel1.Controls.Add(Me.Button8)
        Me.Panel1.Controls.Add(Me.Button9)
        Me.Panel1.Location = New System.Drawing.Point(1595, 350)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(129, 49)
        Me.Panel1.TabIndex = 387
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(395, 20)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(197, 24)
        Me.ComboBox1.TabIndex = 385
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Location = New System.Drawing.Point(610, 6)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(66, 36)
        Me.Button6.TabIndex = 385
        Me.Button6.Text = "down"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(900, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(16, 13)
        Me.Label6.TabIndex = 94
        Me.Label6.Text = "[ ]"
        '
        'Button7
        '
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.Location = New System.Drawing.Point(695, 3)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(59, 41)
        Me.Button7.TabIndex = 355
        Me.Button7.Text = "Nueva Oracion"
        Me.Button7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button8.Enabled = False
        Me.Button8.Location = New System.Drawing.Point(841, 8)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(53, 32)
        Me.Button8.TabIndex = 91
        Me.Button8.Text = "Save"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button9.Location = New System.Drawing.Point(13, 7)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(66, 36)
        Me.Button9.TabIndex = 0
        Me.Button9.Text = "Exit"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'lblVelocidad
        '
        Me.lblVelocidad.AutoSize = True
        Me.lblVelocidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVelocidad.Location = New System.Drawing.Point(1605, 111)
        Me.lblVelocidad.Name = "lblVelocidad"
        Me.lblVelocidad.Size = New System.Drawing.Size(27, 16)
        Me.lblVelocidad.TabIndex = 388
        Me.lblVelocidad.Text = "0%"
        '
        'txtAvance
        '
        Me.txtAvance.Location = New System.Drawing.Point(1693, 61)
        Me.txtAvance.Name = "txtAvance"
        Me.txtAvance.Size = New System.Drawing.Size(44, 20)
        Me.txtAvance.TabIndex = 389
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(1633, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(54, 16)
        Me.Label8.TabIndex = 373
        Me.Label8.Text = "Avance"
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Location = New System.Drawing.Point(1750, 56)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(76, 41)
        Me.Button5.TabIndex = 390
        Me.Button5.Text = "Agregar Oraciones"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(1475, 65)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(70, 16)
        Me.Label9.TabIndex = 373
        Me.Label9.Text = "Velocidad"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(1747, 114)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(54, 16)
        Me.Label10.TabIndex = 373
        Me.Label10.Text = "Volume"
        '
        'txtVolumen
        '
        Me.txtVolumen.AutoSize = True
        Me.txtVolumen.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtVolumen.Location = New System.Drawing.Point(1774, 288)
        Me.txtVolumen.Name = "txtVolumen"
        Me.txtVolumen.Size = New System.Drawing.Size(27, 16)
        Me.txtVolumen.TabIndex = 388
        Me.txtVolumen.Text = "0%"
        '
        'cmbPersona
        '
        Me.cmbPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPersona.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPersona.FormattingEnabled = True
        Me.cmbPersona.Items.AddRange(New Object() {"Unknown", "Dr. Murphy", "Dra. Lim", "Dr. Aaron Glassman", "Dr. Melendez", "Dr. Kalu", "Dr.Andrews", "Dra. Claire", "Lia", "Dr. Morgan", "Dr. Park", "Dr. Asher"})
        Me.cmbPersona.Location = New System.Drawing.Point(1436, 318)
        Me.cmbPersona.Name = "cmbPersona"
        Me.cmbPersona.Size = New System.Drawing.Size(148, 24)
        Me.cmbPersona.TabIndex = 412
        '
        'Button11
        '
        Me.Button11.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button11.Location = New System.Drawing.Point(1451, 249)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(66, 36)
        Me.Button11.TabIndex = 401
        Me.Button11.Text = "Lee texto"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'FrmConversation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1826, 802)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.cmbPersona)
        Me.Controls.Add(Me.cmdOraciones)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.txtAvance)
        Me.Controls.Add(Me.txtVolumen)
        Me.Controls.Add(Me.lblVelocidad)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TrackBarVolumen)
        Me.Controls.Add(Me.TrackBarVelocidad)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtOracionEN)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.CmdUp)
        Me.Controls.Add(Me.lstOraciones)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.cmbGrupo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.pEtapa)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.txtId)
        Me.Name = "FrmConversation"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Conversation"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.pEtapa.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarVelocidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarVolumen, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ToolStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents CmdUp As System.Windows.Forms.Button
    Friend WithEvents lstOraciones As System.Windows.Forms.ListView
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents ImageList4 As System.Windows.Forms.ImageList
    Friend WithEvents lblmod As System.Windows.Forms.Label
    Friend WithEvents ImageList3 As System.Windows.Forms.ImageList
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents cmbGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents pEtapa As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Public WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents txtOracionEN As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ImageList5 As System.Windows.Forms.ImageList
    Friend WithEvents txtOrdenar As System.Windows.Forms.Button
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents TrackBarVelocidad As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBarVolumen As System.Windows.Forms.TrackBar
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents cmdAgregar As System.Windows.Forms.Button
    Friend WithEvents cmdLeer As System.Windows.Forms.Button
    Friend WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents test As System.Windows.Forms.Button
    Friend WithEvents lblVelocidad As System.Windows.Forms.Label
    Friend WithEvents cboPagina As System.Windows.Forms.ComboBox
    Friend WithEvents cmdAudio As System.Windows.Forms.Button
    Friend WithEvents checkMostrarTexto As System.Windows.Forms.CheckBox
    Friend WithEvents txtAvance As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmdOraciones As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents checkMostrarTest As System.Windows.Forms.CheckBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtVolumen As System.Windows.Forms.Label
    Friend WithEvents lblTitulo As System.Windows.Forms.TextBox
    Friend WithEvents cmdtext As System.Windows.Forms.Button
    Friend WithEvents LblId As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmdRandom As System.Windows.Forms.Button
    Friend WithEvents checkMostrarTestES As System.Windows.Forms.CheckBox
    Friend WithEvents checkMostrarTextoES As System.Windows.Forms.CheckBox
    Friend WithEvents cmdfoco As System.Windows.Forms.Button
    Friend WithEvents cmdImgTest As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents cmbPersona As System.Windows.Forms.ComboBox
    Friend WithEvents Button11 As System.Windows.Forms.Button
End Class
