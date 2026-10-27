<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOracionesRead
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOracionesRead))
        Me.cmdExit = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TrackBarVolumen = New System.Windows.Forms.TrackBar()
        Me.TrackBarVelocidad = New System.Windows.Forms.TrackBar()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtOracionEN = New System.Windows.Forms.TextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.test = New System.Windows.Forms.Button()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.cmdLeer = New System.Windows.Forms.Button()
        Me.cmdAgregar = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmbGrupo = New System.Windows.Forms.ComboBox()
        Me.ImageList5 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblTotal = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pEtapa = New System.Windows.Forms.FlowLayoutPanel()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmbPersona = New System.Windows.Forms.ComboBox()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmdOrdenar = New System.Windows.Forms.Button()
        Me.lbltitulo = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.cmbVoices = New System.Windows.Forms.ComboBox()
        Me.lblmod = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.CmdGuardar = New System.Windows.Forms.Button()
        Me.ImageList4 = New System.Windows.Forms.ImageList(Me.components)
        Me.lblVelocidad = New System.Windows.Forms.Label()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.CmdUp = New System.Windows.Forms.Button()
        Me.lstOraciones = New System.Windows.Forms.ListView()
        Me.txtCuenta = New System.Windows.Forms.TextBox()
        Me.txtOk = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAvance = New System.Windows.Forms.TextBox()
        Me.checkMostrarTexto = New System.Windows.Forms.CheckBox()
        Me.Panel1.SuspendLayout()
        CType(Me.TrackBarVolumen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarVelocidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdExit
        '
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdExit.Location = New System.Drawing.Point(12, 12)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(66, 36)
        Me.cmdExit.TabIndex = 1
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me.Button6)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Button7)
        Me.Panel1.Controls.Add(Me.Button8)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Location = New System.Drawing.Point(1398, 385)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(379, 49)
        Me.Panel1.TabIndex = 411
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
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(112, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 22)
        Me.Label7.TabIndex = 381
        Me.Label7.Text = "Title"
        '
        'TrackBarVolumen
        '
        Me.TrackBarVolumen.Location = New System.Drawing.Point(1493, 65)
        Me.TrackBarVolumen.Maximum = 100
        Me.TrackBarVolumen.Name = "TrackBarVolumen"
        Me.TrackBarVolumen.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBarVolumen.Size = New System.Drawing.Size(45, 152)
        Me.TrackBarVolumen.TabIndex = 410
        Me.TrackBarVolumen.TickFrequency = 5
        Me.TrackBarVolumen.Value = 80
        '
        'TrackBarVelocidad
        '
        Me.TrackBarVelocidad.Location = New System.Drawing.Point(1544, 54)
        Me.TrackBarVelocidad.Minimum = -10
        Me.TrackBarVelocidad.Name = "TrackBarVelocidad"
        Me.TrackBarVelocidad.Size = New System.Drawing.Size(172, 45)
        Me.TrackBarVelocidad.TabIndex = 409
        '
        'Button3
        '
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.Location = New System.Drawing.Point(1587, 328)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(40, 41)
        Me.Button3.TabIndex = 407
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1382, 470)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 16)
        Me.Label3.TabIndex = 406
        Me.Label3.Text = "Oracion"
        '
        'txtOracionEN
        '
        Me.txtOracionEN.BackColor = System.Drawing.Color.White
        Me.txtOracionEN.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOracionEN.Location = New System.Drawing.Point(1373, 309)
        Me.txtOracionEN.MaxLength = 500
        Me.txtOracionEN.Multiline = True
        Me.txtOracionEN.Name = "txtOracionEN"
        Me.txtOracionEN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtOracionEN.Size = New System.Drawing.Size(295, 43)
        Me.txtOracionEN.TabIndex = 405
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.ListView1.Location = New System.Drawing.Point(1387, 578)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(93, 46)
        Me.ListView1.TabIndex = 402
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.Visible = False
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Width = 50
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "wondicon-ui-free-speaker_111240.png")
        '
        'test
        '
        Me.test.Cursor = System.Windows.Forms.Cursors.Hand
        Me.test.Location = New System.Drawing.Point(1149, 7)
        Me.test.Name = "test"
        Me.test.Size = New System.Drawing.Size(66, 36)
        Me.test.TabIndex = 391
        Me.test.Text = "test"
        Me.test.UseVisualStyleBackColor = True
        '
        'cmdStop
        '
        Me.cmdStop.Location = New System.Drawing.Point(925, 8)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.Size = New System.Drawing.Size(40, 34)
        Me.cmdStop.TabIndex = 390
        Me.cmdStop.Text = "Stop"
        Me.cmdStop.UseVisualStyleBackColor = True
        '
        'cmdLeer
        '
        Me.cmdLeer.Location = New System.Drawing.Point(752, 6)
        Me.cmdLeer.Name = "cmdLeer"
        Me.cmdLeer.Size = New System.Drawing.Size(77, 38)
        Me.cmdLeer.TabIndex = 389
        Me.cmdLeer.Text = "Leer"
        Me.cmdLeer.UseVisualStyleBackColor = True
        '
        'cmdAgregar
        '
        Me.cmdAgregar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdAgregar.Location = New System.Drawing.Point(1083, 4)
        Me.cmdAgregar.Name = "cmdAgregar"
        Me.cmdAgregar.Size = New System.Drawing.Size(59, 41)
        Me.cmdAgregar.TabIndex = 388
        Me.cmdAgregar.Text = "Agregar"
        Me.cmdAgregar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAgregar.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button10.Location = New System.Drawing.Point(995, 1)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(66, 36)
        Me.Button10.TabIndex = 386
        Me.Button10.Text = "speak"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1584, 368)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(47, 14)
        Me.Label4.TabIndex = 408
        Me.Label4.Text = "Agregar"
        '
        'cmbGrupo
        '
        Me.cmbGrupo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGrupo.FormattingEnabled = True
        Me.cmbGrupo.Location = New System.Drawing.Point(1535, 470)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(230, 24)
        Me.cmbGrupo.TabIndex = 397
        '
        'ImageList5
        '
        Me.ImageList5.ImageStream = CType(resources.GetObject("ImageList5.ImageStream"), System.Windows.Forms.ImageListStreamer)
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
        'lblTotal
        '
        Me.lblTotal.AutoSize = True
        Me.lblTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotal.Location = New System.Drawing.Point(1370, 65)
        Me.lblTotal.Name = "lblTotal"
        Me.lblTotal.Size = New System.Drawing.Size(25, 16)
        Me.lblTotal.TabIndex = 396
        Me.lblTotal.Text = "Ok"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(1659, 158)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(47, 14)
        Me.Label5.TabIndex = 395
        Me.Label5.Text = "Agregar"
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.Location = New System.Drawing.Point(-65, -17)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(33, 16)
        Me.lblTipo.TabIndex = 392
        Me.lblTipo.Text = "Item"
        Me.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtId
        '
        Me.txtId.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.Location = New System.Drawing.Point(-22, -20)
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(75, 22)
        Me.txtId.TabIndex = 391
        Me.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button1
        '
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(1662, 118)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 41)
        Me.Button1.TabIndex = 394
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pEtapa
        '
        Me.pEtapa.Location = New System.Drawing.Point(4, 54)
        Me.pEtapa.Name = "pEtapa"
        Me.pEtapa.Size = New System.Drawing.Size(1350, 714)
        Me.pEtapa.TabIndex = 393
        '
        'cmbPersona
        '
        Me.cmbPersona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPersona.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPersona.FormattingEnabled = True
        Me.cmbPersona.Items.AddRange(New Object() {"Unknown", "Dr. Murphy", "Dr. Aaron Glassman", "Dra. Lim", "Dr. Melendez", "Dr. Kalu", "Dr.Andrews", "Dra. Claire", "Lia", "Dr. Morgan", "Dr. Park", "Dr. Asher"})
        Me.cmbPersona.Location = New System.Drawing.Point(1579, 91)
        Me.cmbPersona.Name = "cmbPersona"
        Me.cmbPersona.Size = New System.Drawing.Size(105, 24)
        Me.cmbPersona.TabIndex = 401
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(1514, 99)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 16)
        Me.Label2.TabIndex = 400
        Me.Label2.Text = "Persona"
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 0
        '
        'cmdOrdenar
        '
        Me.cmdOrdenar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdOrdenar.Location = New System.Drawing.Point(598, 5)
        Me.cmdOrdenar.Name = "cmdOrdenar"
        Me.cmdOrdenar.Size = New System.Drawing.Size(66, 36)
        Me.cmdOrdenar.TabIndex = 385
        Me.cmdOrdenar.Text = "Ordenar"
        Me.cmdOrdenar.UseVisualStyleBackColor = True
        '
        'lbltitulo
        '
        Me.lbltitulo.AutoSize = True
        Me.lbltitulo.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltitulo.Location = New System.Drawing.Point(73, 13)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(50, 22)
        Me.lbltitulo.TabIndex = 381
        Me.lbltitulo.Text = "Title"
        '
        'txtBuscar
        '
        Me.txtBuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(1516, 118)
        Me.txtBuscar.MaxLength = 500
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtBuscar.Size = New System.Drawing.Size(288, 22)
        Me.txtBuscar.TabIndex = 398
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(1433, 460)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(66, 36)
        Me.Button2.TabIndex = 389
        Me.Button2.Text = "down"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
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
        'ToolStatus
        '
        Me.ToolStatus.Name = "ToolStatus"
        Me.ToolStatus.Size = New System.Drawing.Size(39, 17)
        Me.ToolStatus.Text = "Status"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Panel2.Controls.Add(Me.checkMostrarTexto)
        Me.Panel2.Controls.Add(Me.Button9)
        Me.Panel2.Controls.Add(Me.cboGrupo)
        Me.Panel2.Controls.Add(Me.test)
        Me.Panel2.Controls.Add(Me.cmdStop)
        Me.Panel2.Controls.Add(Me.cmdLeer)
        Me.Panel2.Controls.Add(Me.cmdAgregar)
        Me.Panel2.Controls.Add(Me.Button10)
        Me.Panel2.Controls.Add(Me.cmbVoices)
        Me.Panel2.Controls.Add(Me.cmdOrdenar)
        Me.Panel2.Controls.Add(Me.lblmod)
        Me.Panel2.Controls.Add(Me.Button4)
        Me.Panel2.Controls.Add(Me.CmdGuardar)
        Me.Panel2.Controls.Add(Me.lbltitulo)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1813, 49)
        Me.Panel2.TabIndex = 390
        '
        'Button9
        '
        Me.Button9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button9.Location = New System.Drawing.Point(3, 6)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(66, 36)
        Me.Button9.TabIndex = 393
        Me.Button9.Text = "Exit"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'cboGrupo
        '
        Me.cboGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(129, 11)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(463, 28)
        Me.cboGrupo.TabIndex = 392
        '
        'cmbVoices
        '
        Me.cmbVoices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbVoices.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbVoices.FormattingEnabled = True
        Me.cmbVoices.Location = New System.Drawing.Point(1300, 15)
        Me.cmbVoices.Name = "cmbVoices"
        Me.cmbVoices.Size = New System.Drawing.Size(167, 24)
        Me.cmbVoices.TabIndex = 385
        '
        'lblmod
        '
        Me.lblmod.AutoSize = True
        Me.lblmod.ForeColor = System.Drawing.Color.Black
        Me.lblmod.Location = New System.Drawing.Point(888, 17)
        Me.lblmod.Name = "lblmod"
        Me.lblmod.Size = New System.Drawing.Size(16, 13)
        Me.lblmod.TabIndex = 94
        Me.lblmod.Text = "[ ]"
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Location = New System.Drawing.Point(683, 2)
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
        Me.CmdGuardar.Location = New System.Drawing.Point(829, 7)
        Me.CmdGuardar.Name = "CmdGuardar"
        Me.CmdGuardar.Size = New System.Drawing.Size(53, 32)
        Me.CmdGuardar.TabIndex = 91
        Me.CmdGuardar.Text = "Save"
        Me.CmdGuardar.UseVisualStyleBackColor = True
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
        'lblVelocidad
        '
        Me.lblVelocidad.AutoSize = True
        Me.lblVelocidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVelocidad.Location = New System.Drawing.Point(1712, 54)
        Me.lblVelocidad.Name = "lblVelocidad"
        Me.lblVelocidad.Size = New System.Drawing.Size(27, 16)
        Me.lblVelocidad.TabIndex = 412
        Me.lblVelocidad.Text = "0%"
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
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 773)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1813, 22)
        Me.StatusStrip1.TabIndex = 404
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'CmdUp
        '
        Me.CmdUp.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdUp.Location = New System.Drawing.Point(1385, 515)
        Me.CmdUp.Name = "CmdUp"
        Me.CmdUp.Size = New System.Drawing.Size(66, 36)
        Me.CmdUp.TabIndex = 403
        Me.CmdUp.Text = "Up"
        Me.CmdUp.UseVisualStyleBackColor = True
        Me.CmdUp.Visible = False
        '
        'lstOraciones
        '
        Me.lstOraciones.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lstOraciones.Location = New System.Drawing.Point(1544, 150)
        Me.lstOraciones.Name = "lstOraciones"
        Me.lstOraciones.Size = New System.Drawing.Size(260, 155)
        Me.lstOraciones.TabIndex = 399
        Me.lstOraciones.UseCompatibleStateImageBehavior = False
        '
        'txtCuenta
        '
        Me.txtCuenta.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuenta.Location = New System.Drawing.Point(1420, 91)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(47, 25)
        Me.txtCuenta.TabIndex = 413
        Me.txtCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtOk
        '
        Me.txtOk.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOk.Location = New System.Drawing.Point(1420, 64)
        Me.txtOk.Name = "txtOk"
        Me.txtOk.Size = New System.Drawing.Size(47, 25)
        Me.txtOk.TabIndex = 415
        Me.txtOk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1371, 94)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 16)
        Me.Label1.TabIndex = 414
        Me.Label1.Text = "Total"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial Narrow", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(1473, 124)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(21, 20)
        Me.Label8.TabIndex = 417
        Me.Label8.Text = "%"
        '
        'txtAvance
        '
        Me.txtAvance.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.txtAvance.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAvance.Location = New System.Drawing.Point(1420, 120)
        Me.txtAvance.Name = "txtAvance"
        Me.txtAvance.Size = New System.Drawing.Size(47, 25)
        Me.txtAvance.TabIndex = 416
        Me.txtAvance.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'checkMostrarTexto
        '
        Me.checkMostrarTexto.AutoSize = True
        Me.checkMostrarTexto.Checked = True
        Me.checkMostrarTexto.CheckState = System.Windows.Forms.CheckState.Checked
        Me.checkMostrarTexto.Location = New System.Drawing.Point(1234, 15)
        Me.checkMostrarTexto.Name = "checkMostrarTexto"
        Me.checkMostrarTexto.Size = New System.Drawing.Size(60, 17)
        Me.checkMostrarTexto.TabIndex = 418
        Me.checkMostrarTexto.Text = "Ocultar"
        Me.checkMostrarTexto.UseVisualStyleBackColor = True
        '
        'frmOracionesRead
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1813, 795)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtAvance)
        Me.Controls.Add(Me.txtOk)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCuenta)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.TrackBarVolumen)
        Me.Controls.Add(Me.TrackBarVelocidad)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtOracionEN)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmbGrupo)
        Me.Controls.Add(Me.lblTotal)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.pEtapa)
        Me.Controls.Add(Me.cmbPersona)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.lblVelocidad)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.CmdUp)
        Me.Controls.Add(Me.lstOraciones)
        Me.Controls.Add(Me.cmdExit)
        Me.Name = "frmOracionesRead"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmOracionesRead"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TrackBarVolumen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarVelocidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExit As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TrackBarVolumen As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBarVelocidad As System.Windows.Forms.TrackBar
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtOracionEN As System.Windows.Forms.TextBox
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents test As System.Windows.Forms.Button
    Friend WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents cmdLeer As System.Windows.Forms.Button
    Friend WithEvents cmdAgregar As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents ImageList5 As System.Windows.Forms.ImageList
    Friend WithEvents lblTotal As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents pEtapa As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmbPersona As System.Windows.Forms.ComboBox
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdOrdenar As System.Windows.Forms.Button
    Friend WithEvents lbltitulo As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents ImageList3 As System.Windows.Forms.ImageList
    Friend WithEvents ToolStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmbVoices As System.Windows.Forms.ComboBox
    Friend WithEvents lblmod As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
    Friend WithEvents ImageList4 As System.Windows.Forms.ImageList
    Friend WithEvents lblVelocidad As System.Windows.Forms.Label
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents CmdUp As System.Windows.Forms.Button
    Friend WithEvents lstOraciones As System.Windows.Forms.ListView
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents txtOk As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtAvance As System.Windows.Forms.TextBox
    Friend WithEvents checkMostrarTexto As System.Windows.Forms.CheckBox
End Class
