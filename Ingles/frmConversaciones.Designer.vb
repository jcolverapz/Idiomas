<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConversaciones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConversaciones))
        Me.ToolStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.cboPagina = New System.Windows.Forms.ComboBox()
        Me.cmdRefresh = New System.Windows.Forms.Button()
        Me.ImageList4 = New System.Windows.Forms.ImageList(Me.components)
        Me.test = New System.Windows.Forms.Button()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.cmdtext = New System.Windows.Forms.Button()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.lblmod = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.cmdAudio = New System.Windows.Forms.Button()
        Me.CmdGuardar = New System.Windows.Forms.Button()
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.txtOrdenar = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.cmdNuevoEncabezado = New System.Windows.Forms.Button()
        Me.cmdInicio = New System.Windows.Forms.Button()
        Me.cmdImgTest = New System.Windows.Forms.Button()
        Me.cmdfoco = New System.Windows.Forms.Button()
        Me.lblTitulo = New System.Windows.Forms.TextBox()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ImageList5 = New System.Windows.Forms.ImageList(Me.components)
        Me.txtBuscarDialogo = New System.Windows.Forms.TextBox()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.pEtapa = New System.Windows.Forms.FlowLayoutPanel()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.cmdTemas = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStatus
        '
        Me.ToolStatus.Name = "ToolStatus"
        Me.ToolStatus.Size = New System.Drawing.Size(39, 17)
        Me.ToolStatus.Text = "Status"
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
        'cmdRefresh
        '
        Me.cmdRefresh.Location = New System.Drawing.Point(693, 5)
        Me.cmdRefresh.Name = "cmdRefresh"
        Me.cmdRefresh.Size = New System.Drawing.Size(77, 38)
        Me.cmdRefresh.TabIndex = 389
        Me.cmdRefresh.Text = "Refresh"
        Me.cmdRefresh.UseVisualStyleBackColor = True
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
        Me.cmdStop.Location = New System.Drawing.Point(1391, 9)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(58, 34)
        Me.cmdStop.TabIndex = 390
        Me.cmdStop.Text = "Stop"
        Me.cmdStop.UseVisualStyleBackColor = True
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
        'lblmod
        '
        Me.lblmod.AutoSize = True
        Me.lblmod.ForeColor = System.Drawing.Color.Black
        Me.lblmod.Location = New System.Drawing.Point(911, 18)
        Me.lblmod.Name = "lblmod"
        Me.lblmod.Size = New System.Drawing.Size(16, 13)
        Me.lblmod.TabIndex = 94
        Me.lblmod.Text = "[ ]"
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(1326, 4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(59, 41)
        Me.Button4.TabIndex = 355
        Me.Button4.Text = "Nueva Oracion"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button4.UseVisualStyleBackColor = True
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
        'CmdGuardar
        '
        Me.CmdGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdGuardar.Location = New System.Drawing.Point(1002, 7)
        Me.CmdGuardar.Name = "CmdGuardar"
        Me.CmdGuardar.Size = New System.Drawing.Size(53, 32)
        Me.CmdGuardar.TabIndex = 91
        Me.CmdGuardar.Text = "Save"
        Me.CmdGuardar.UseVisualStyleBackColor = True
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
        'cmdExit
        '
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdExit.Location = New System.Drawing.Point(7, 6)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(66, 25)
        Me.cmdExit.TabIndex = 0
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
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
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Panel2.Controls.Add(Me.cmdTemas)
        Me.Panel2.Controls.Add(Me.cmdNuevoEncabezado)
        Me.Panel2.Controls.Add(Me.cmdInicio)
        Me.Panel2.Controls.Add(Me.cmdImgTest)
        Me.Panel2.Controls.Add(Me.cmdfoco)
        Me.Panel2.Controls.Add(Me.lblTitulo)
        Me.Panel2.Controls.Add(Me.cmdAudio)
        Me.Panel2.Controls.Add(Me.cboPagina)
        Me.Panel2.Controls.Add(Me.test)
        Me.Panel2.Controls.Add(Me.cmdStop)
        Me.Panel2.Controls.Add(Me.cmdRefresh)
        Me.Panel2.Controls.Add(Me.cmdtext)
        Me.Panel2.Controls.Add(Me.cmdAgregar)
        Me.Panel2.Controls.Add(Me.Button10)
        Me.Panel2.Controls.Add(Me.txtOrdenar)
        Me.Panel2.Controls.Add(Me.lblmod)
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Controls.Add(Me.CmdGuardar)
        Me.Panel2.Controls.Add(Me.cmdExit)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1915, 57)
        Me.Panel2.TabIndex = 428
        '
        'cmdNuevoEncabezado
        '
        Me.cmdNuevoEncabezado.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdNuevoEncabezado.Location = New System.Drawing.Point(1479, 8)
        Me.cmdNuevoEncabezado.Name = "cmdNuevoEncabezado"
        Me.cmdNuevoEncabezado.Size = New System.Drawing.Size(66, 36)
        Me.cmdNuevoEncabezado.TabIndex = 402
        Me.cmdNuevoEncabezado.TabStop = False
        Me.cmdNuevoEncabezado.Text = "Nuevo Encabezado"
        Me.cmdNuevoEncabezado.UseVisualStyleBackColor = True
        '
        'cmdInicio
        '
        Me.cmdInicio.Location = New System.Drawing.Point(771, 4)
        Me.cmdInicio.Name = "cmdInicio"
        Me.cmdInicio.Size = New System.Drawing.Size(77, 38)
        Me.cmdInicio.TabIndex = 401
        Me.cmdInicio.Text = "Inicio"
        Me.cmdInicio.UseVisualStyleBackColor = True
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
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 854)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1915, 22)
        Me.StatusStrip1.TabIndex = 445
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "wondicon-ui-free-speaker_111240.png")
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
        'txtBuscarDialogo
        '
        Me.txtBuscarDialogo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBuscarDialogo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscarDialogo.Location = New System.Drawing.Point(524, 63)
        Me.txtBuscarDialogo.Name = "txtBuscarDialogo"
        Me.txtBuscarDialogo.Size = New System.Drawing.Size(208, 22)
        Me.txtBuscarDialogo.TabIndex = 460
        Me.txtBuscarDialogo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboTipo
        '
        Me.cboTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(7, 61)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(258, 26)
        Me.cboTipo.TabIndex = 458
        '
        'pEtapa
        '
        Me.pEtapa.AllowDrop = True
        Me.pEtapa.Location = New System.Drawing.Point(3, 93)
        Me.pEtapa.Name = "pEtapa"
        Me.pEtapa.Size = New System.Drawing.Size(1900, 758)
        Me.pEtapa.TabIndex = 461
        '
        'txtBuscar
        '
        Me.txtBuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(282, 65)
        Me.txtBuscar.MaxLength = 500
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBuscar.Size = New System.Drawing.Size(236, 22)
        Me.txtBuscar.TabIndex = 462
        '
        'cmdTemas
        '
        Me.cmdTemas.Location = New System.Drawing.Point(852, 3)
        Me.cmdTemas.Name = "cmdTemas"
        Me.cmdTemas.Size = New System.Drawing.Size(57, 38)
        Me.cmdTemas.TabIndex = 403
        Me.cmdTemas.Text = "Temas"
        Me.cmdTemas.UseVisualStyleBackColor = True
        '
        'frmConversaciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1915, 876)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.pEtapa)
        Me.Controls.Add(Me.txtBuscarDialogo)
        Me.Controls.Add(Me.cboTipo)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "frmConversaciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmConversaciones"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents cboPagina As System.Windows.Forms.ComboBox
    Friend WithEvents cmdRefresh As System.Windows.Forms.Button
    Friend WithEvents ImageList4 As System.Windows.Forms.ImageList
    Friend WithEvents test As System.Windows.Forms.Button
    Friend WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents cmdtext As System.Windows.Forms.Button
    Friend WithEvents cmdAgregar As System.Windows.Forms.Button
    Friend WithEvents lblmod As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents cmdAudio As System.Windows.Forms.Button
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
    Friend WithEvents ImageList3 As System.Windows.Forms.ImageList
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents txtOrdenar As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdImgTest As System.Windows.Forms.Button
    Friend WithEvents cmdfoco As System.Windows.Forms.Button
    Friend WithEvents lblTitulo As System.Windows.Forms.TextBox
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ImageList5 As System.Windows.Forms.ImageList
    Friend WithEvents txtBuscarDialogo As System.Windows.Forms.TextBox
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents pEtapa As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents cmdInicio As System.Windows.Forms.Button
    Friend WithEvents cmdNuevoEncabezado As System.Windows.Forms.Button
    Friend WithEvents cmdTemas As System.Windows.Forms.Button
End Class
