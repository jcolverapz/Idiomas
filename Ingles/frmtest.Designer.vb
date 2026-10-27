<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmtest
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmtest))
        Me.txtOracionES = New System.Windows.Forms.TextBox()
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.Button5 = New System.Windows.Forms.Button()
        Me.TrackBarVelocidad = New System.Windows.Forms.TrackBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.cmbVoices = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txtOracionEN = New System.Windows.Forms.TextBox()
        Me.ImageList5 = New System.Windows.Forms.ImageList(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblmod = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.CmdGuardar = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.lbltitulo = New System.Windows.Forms.Label()
        Me.cmbGrupo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.ImageList4 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmbPersona = New System.Windows.Forms.ComboBox()
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.CmdUp = New System.Windows.Forms.Button()
        Me.TrackBarVolumen = New System.Windows.Forms.TrackBar()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pEtapa = New System.Windows.Forms.Panel()
        CType(Me.TrackBarVelocidad,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel2.SuspendLayout
        Me.StatusStrip1.SuspendLayout
        CType(Me.TrackBarVolumen,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'txtOracionES
        '
        Me.txtOracionES.BackColor = System.Drawing.Color.White
        Me.txtOracionES.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtOracionES.Location = New System.Drawing.Point(1024, 337)
        Me.txtOracionES.MaxLength = 500
        Me.txtOracionES.Multiline = true
        Me.txtOracionES.Name = "txtOracionES"
        Me.txtOracionES.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOracionES.Size = New System.Drawing.Size(295, 43)
        Me.txtOracionES.TabIndex = 407
        '
        'ImageList3
        '
        Me.ImageList3.ImageStream = CType(resources.GetObject("ImageList3.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageList3.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList3.Images.SetKeyName(0, "icon_Options.ico")
        Me.ImageList3.Images.SetKeyName(1, "burger_line_list_menu_nav_navigation_option_icon_123231.png")
        Me.ImageList3.Images.SetKeyName(2, "details_more_icon_214604.png")
        Me.ImageList3.Images.SetKeyName(3, "savetheapplication_guardar_2958 (1).png")
        Me.ImageList3.Images.SetKeyName(4, "documento.png")
        Me.ImageList3.Images.SetKeyName(5, "lapiz - Copy.png")
        Me.ImageList3.Images.SetKeyName(6, "attachment.png")
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Location = New System.Drawing.Point(610, 6)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(66, 36)
        Me.Button5.TabIndex = 385
        Me.Button5.Text = "down"
        Me.Button5.UseVisualStyleBackColor = true
        '
        'TrackBarVelocidad
        '
        Me.TrackBarVelocidad.Location = New System.Drawing.Point(1245, -1)
        Me.TrackBarVelocidad.Minimum = -10
        Me.TrackBarVelocidad.Name = "TrackBarVelocidad"
        Me.TrackBarVelocidad.Size = New System.Drawing.Size(172, 45)
        Me.TrackBarVelocidad.TabIndex = 408
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label4.Location = New System.Drawing.Point(1395, 319)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 14)
        Me.Label4.TabIndex = 406
        Me.Label4.Text = "Agregar"
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"),System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(1398, 279)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(40, 41)
        Me.Button3.TabIndex = 405
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = true
        '
        'cmbVoices
        '
        Me.cmbVoices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVoices.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cmbVoices.FormattingEnabled = true
        Me.cmbVoices.Location = New System.Drawing.Point(395, 20)
        Me.cmbVoices.Name = "cmbVoices"
        Me.cmbVoices.Size = New System.Drawing.Size(197, 24)
        Me.cmbVoices.TabIndex = 385
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label3.Location = New System.Drawing.Point(1021, 260)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 16)
        Me.Label3.TabIndex = 404
        Me.Label3.Text = "Oracion"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "wondicon-ui-free-speaker_111240.png")
        '
        'txtOracionEN
        '
        Me.txtOracionEN.BackColor = System.Drawing.Color.White
        Me.txtOracionEN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtOracionEN.Location = New System.Drawing.Point(1024, 279)
        Me.txtOracionEN.MaxLength = 500
        Me.txtOracionEN.Multiline = true
        Me.txtOracionEN.Name = "txtOracionEN"
        Me.txtOracionEN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOracionEN.Size = New System.Drawing.Size(295, 43)
        Me.txtOracionEN.TabIndex = 403
        '
        'ImageList5
        '
        Me.ImageList5.ImageStream = CType(resources.GetObject("ImageList5.ImageStream"),System.Windows.Forms.ImageListStreamer)
        Me.ImageList5.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList5.Images.SetKeyName(0, "icons8-usuario-50.ico")
        Me.ImageList5.Images.SetKeyName(1, "download__1_-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(2, "Aaron-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(3, "download-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(4, "melendez_1-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(5, "download__2_-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(6, "Andrews-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(7, "pixelcut-export (2).png")
        Me.ImageList5.Images.SetKeyName(8, "dra.-lea-jpg-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(9, "Morgan-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(10, "park-removebg-preview.png")
        Me.ImageList5.Images.SetKeyName(11, "asher-removebg-preview.png")
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(230,Byte),Integer), CType(CType(233,Byte),Integer), CType(CType(235,Byte),Integer))
        Me.Panel2.Controls.Add(Me.cmbVoices)
        Me.Panel2.Controls.Add(Me.Button5)
        Me.Panel2.Controls.Add(Me.lblmod)
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Controls.Add(Me.CmdGuardar)
        Me.Panel2.Controls.Add(Me.cmdExit)
        Me.Panel2.Controls.Add(Me.lbltitulo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Font = New System.Drawing.Font("Consolas", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1449, 53)
        Me.Panel2.TabIndex = 388
        '
        'lblmod
        '
        Me.lblmod.AutoSize = true
        Me.lblmod.ForeColor = System.Drawing.Color.Black
        Me.lblmod.Location = New System.Drawing.Point(900, 18)
        Me.lblmod.Name = "lblmod"
        Me.lblmod.Size = New System.Drawing.Size(46, 24)
        Me.lblmod.TabIndex = 94
        Me.lblmod.Text = "[ ]"
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
        Me.Button4.UseVisualStyleBackColor = true
        '
        'CmdGuardar
        '
        Me.CmdGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdGuardar.Enabled = false
        Me.CmdGuardar.Location = New System.Drawing.Point(841, 8)
        Me.CmdGuardar.Name = "CmdGuardar"
        Me.CmdGuardar.Size = New System.Drawing.Size(53, 32)
        Me.CmdGuardar.TabIndex = 91
        Me.CmdGuardar.Text = "Save"
        Me.CmdGuardar.UseVisualStyleBackColor = true
        '
        'cmdExit
        '
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdExit.Location = New System.Drawing.Point(7, 6)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(66, 36)
        Me.cmdExit.TabIndex = 0
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = true
        '
        'lbltitulo
        '
        Me.lbltitulo.AutoSize = true
        Me.lbltitulo.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lbltitulo.Location = New System.Drawing.Point(112, 14)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(50, 22)
        Me.lbltitulo.TabIndex = 381
        Me.lbltitulo.Text = "Title"
        '
        'cmbGrupo
        '
        Me.cmbGrupo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cmbGrupo.FormattingEnabled = true
        Me.cmbGrupo.Location = New System.Drawing.Point(1093, -38)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(230, 24)
        Me.cmbGrupo.TabIndex = 395
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label1.Location = New System.Drawing.Point(975, -34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 394
        Me.Label1.Text = "Grupo"
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label5.Location = New System.Drawing.Point(1318, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 14)
        Me.Label5.TabIndex = 393
        Me.Label5.Text = "Agregar"
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"),System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(1321, 67)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 41)
        Me.Button1.TabIndex = 392
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = true
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = true
        Me.lblTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lblTipo.Location = New System.Drawing.Point(47, -56)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(33, 16)
        Me.lblTipo.TabIndex = 390
        Me.lblTipo.Text = "Item"
        Me.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtId
        '
        Me.txtId.BackColor = System.Drawing.Color.FromArgb(CType(CType(230,Byte),Integer), CType(CType(233,Byte),Integer), CType(CType(235,Byte),Integer))
        Me.txtId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtId.Location = New System.Drawing.Point(90, -59)
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = true
        Me.txtId.Size = New System.Drawing.Size(75, 22)
        Me.txtId.TabIndex = 389
        Me.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ImageList4
        '
        Me.ImageList4.ImageStream = CType(resources.GetObject("ImageList4.ImageStream"),System.Windows.Forms.ImageListStreamer)
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
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label2.Location = New System.Drawing.Point(1051, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 16)
        Me.Label2.TabIndex = 398
        Me.Label2.Text = "Persona"
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"),System.Windows.Forms.ImageListStreamer)
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
        'cmbPersona
        '
        Me.cmbPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPersona.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cmbPersona.FormattingEnabled = true
        Me.cmbPersona.Items.AddRange(New Object() {"Unknown", "Dr. Murphy", "Dr. Aaron Glassman", "Dra. Lim", "Dr. Melendez", "Dr. Kalu", "Dr.Andrews", "Dra. Claire", "Lia", "Dr. Morgan", "Dr. Park", "Dr. Asher"})
        Me.cmbPersona.Location = New System.Drawing.Point(1116, 30)
        Me.cmbPersona.Name = "cmbPersona"
        Me.cmbPersona.Size = New System.Drawing.Size(105, 24)
        Me.cmbPersona.TabIndex = 399
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.ListView1.Location = New System.Drawing.Point(1147, 542)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(93, 46)
        Me.ListView1.TabIndex = 400
        Me.ListView1.UseCompatibleStateImageBehavior = false
        Me.ListView1.Visible = false
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Width = 50
        '
        'txtBuscar
        '
        Me.txtBuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(1024, 60)
        Me.txtBuscar.MaxLength = 500
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBuscar.Size = New System.Drawing.Size(288, 22)
        Me.txtBuscar.TabIndex = 396
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 641)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1449, 22)
        Me.StatusStrip1.TabIndex = 402
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStatus
        '
        Me.ToolStatus.Name = "ToolStatus"
        Me.ToolStatus.Size = New System.Drawing.Size(39, 17)
        Me.ToolStatus.Text = "Status"
        '
        'CmdUp
        '
        Me.CmdUp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdUp.Location = New System.Drawing.Point(1220, 500)
        Me.CmdUp.Name = "CmdUp"
        Me.CmdUp.Size = New System.Drawing.Size(66, 36)
        Me.CmdUp.TabIndex = 401
        Me.CmdUp.Text = "Up"
        Me.CmdUp.UseVisualStyleBackColor = true
        Me.CmdUp.Visible = false
        '
        'TrackBarVolumen
        '
        Me.TrackBarVolumen.Location = New System.Drawing.Point(1393, 69)
        Me.TrackBarVolumen.Maximum = 100
        Me.TrackBarVolumen.Name = "TrackBarVolumen"
        Me.TrackBarVolumen.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBarVolumen.Size = New System.Drawing.Size(45, 152)
        Me.TrackBarVolumen.TabIndex = 409
        Me.TrackBarVolumen.TickFrequency = 5
        Me.TrackBarVolumen.Value = 80
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(1148, 500)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(66, 36)
        Me.Button2.TabIndex = 387
        Me.Button2.Text = "down"
        Me.Button2.UseVisualStyleBackColor = true
        Me.Button2.Visible = false
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Location = New System.Drawing.Point(654, 177)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(66, 36)
        Me.Button6.TabIndex = 411
        Me.Button6.Text = "down"
        Me.Button6.UseVisualStyleBackColor = true
        '
        'Panel1
        '
        Me.Panel1.Location = New System.Drawing.Point(7, 60)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(612, 444)
        Me.Panel1.TabIndex = 412
        '
        'pEtapa
        '
        Me.pEtapa.Location = New System.Drawing.Point(701, 329)
        Me.pEtapa.Name = "pEtapa"
        Me.pEtapa.Size = New System.Drawing.Size(203, 149)
        Me.pEtapa.TabIndex = 413
        '
        'frmtest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1449, 663)
        Me.Controls.Add(Me.pEtapa)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.txtOracionES)
        Me.Controls.Add(Me.TrackBarVelocidad)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtOracionEN)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.cmbGrupo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbPersona)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.CmdUp)
        Me.Controls.Add(Me.TrackBarVolumen)
        Me.Controls.Add(Me.Button2)
        Me.Name = "frmtest"
        Me.Text = "frmtest"
        CType(Me.TrackBarVelocidad,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel2.ResumeLayout(false)
        Me.Panel2.PerformLayout
        Me.StatusStrip1.ResumeLayout(false)
        Me.StatusStrip1.PerformLayout
        CType(Me.TrackBarVolumen,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents txtOracionES As System.Windows.Forms.TextBox
    Friend WithEvents ImageList3 As System.Windows.Forms.ImageList
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents TrackBarVelocidad As System.Windows.Forms.TrackBar
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents cmbVoices As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents txtOracionEN As System.Windows.Forms.TextBox
    Friend WithEvents ImageList5 As System.Windows.Forms.ImageList
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents lblmod As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents lbltitulo As System.Windows.Forms.Label
    Friend WithEvents cmbGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Public WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents ImageList4 As System.Windows.Forms.ImageList
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents cmbPersona As System.Windows.Forms.ComboBox
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents CmdUp As System.Windows.Forms.Button
    Friend WithEvents TrackBarVolumen As System.Windows.Forms.TrackBar
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pEtapa As System.Windows.Forms.Panel
End Class
