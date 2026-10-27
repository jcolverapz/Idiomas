<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDetEstructura
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDetEstructura))
        Me.cmdAbrirAudio = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.NumRate = New System.Windows.Forms.NumericUpDown()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtAudio = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtEsRespuesta = New System.Windows.Forms.TextBox()
        Me.txtTipo = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtObserv = New System.Windows.Forms.TextBox()
        Me.cmdCopiar = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cboConversation = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkFile = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtCuenta = New System.Windows.Forms.TextBox()
        Me.lstConversaciones = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Button5 = New System.Windows.Forms.Button()
        Me.txtHTML = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtOrden = New System.Windows.Forms.TextBox()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.cmbConversation = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTraduccion = New System.Windows.Forms.TextBox()
        Me.cmbGrupo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.cboState = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.lblTipo = New System.Windows.Forms.Label()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.cmdPlay = New System.Windows.Forms.Button()
        Me.cmdAudio = New System.Windows.Forms.Button()
        Me.cmdPapelera = New System.Windows.Forms.Button()
        Me.cmdImagen = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.cmdCargar = New System.Windows.Forms.Button()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.lblmod = New System.Windows.Forms.Label()
        Me.cmdAgregarOraciones = New System.Windows.Forms.Button()
        Me.CmdGuardar = New System.Windows.Forms.Button()
        Me.cmdExit = New System.Windows.Forms.Button()
        CType(Me.NumRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdAbrirAudio
        '
        Me.cmdAbrirAudio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdAbrirAudio.Location = New System.Drawing.Point(20, 52)
        Me.cmdAbrirAudio.Name = "cmdAbrirAudio"
        Me.cmdAbrirAudio.Size = New System.Drawing.Size(59, 41)
        Me.cmdAbrirAudio.TabIndex = 448
        Me.cmdAbrirAudio.Text = "Abrir Audio"
        Me.cmdAbrirAudio.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdAbrirAudio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAbrirAudio.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(45, 369)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(65, 16)
        Me.Label16.TabIndex = 464
        Me.Label16.Text = "Variantes"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(109, 328)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(37, 16)
        Me.Label15.TabIndex = 463
        Me.Label15.Text = "Rate"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'NumRate
        '
        Me.NumRate.Cursor = System.Windows.Forms.Cursors.Default
        Me.NumRate.DecimalPlaces = 1
        Me.NumRate.Font = New System.Drawing.Font("Consolas", 12.0!)
        Me.NumRate.Increment = New Decimal(New Integer() {1, 0, 0, 65536})
        Me.NumRate.Location = New System.Drawing.Point(156, 324)
        Me.NumRate.Name = "NumRate"
        Me.NumRate.Size = New System.Drawing.Size(73, 26)
        Me.NumRate.TabIndex = 462
        Me.NumRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(765, 331)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(43, 16)
        Me.Label14.TabIndex = 461
        Me.Label14.Text = "Audio"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtAudio
        '
        Me.txtAudio.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtAudio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAudio.Location = New System.Drawing.Point(808, 328)
        Me.txtAudio.Name = "txtAudio"
        Me.txtAudio.Size = New System.Drawing.Size(75, 22)
        Me.txtAudio.TabIndex = 460
        Me.txtAudio.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(619, 356)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(90, 16)
        Me.Label12.TabIndex = 459
        Me.Label12.Text = "EsRespuesta"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(619, 328)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(36, 16)
        Me.Label11.TabIndex = 458
        Me.Label11.Text = "Tipo"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtEsRespuesta
        '
        Me.txtEsRespuesta.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtEsRespuesta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEsRespuesta.Location = New System.Drawing.Point(715, 353)
        Me.txtEsRespuesta.Name = "txtEsRespuesta"
        Me.txtEsRespuesta.Size = New System.Drawing.Size(75, 22)
        Me.txtEsRespuesta.TabIndex = 457
        Me.txtEsRespuesta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtTipo
        '
        Me.txtTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTipo.Location = New System.Drawing.Point(662, 325)
        Me.txtTipo.Name = "txtTipo"
        Me.txtTipo.Size = New System.Drawing.Size(75, 22)
        Me.txtTipo.TabIndex = 456
        Me.txtTipo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(45, 269)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(100, 16)
        Me.Label10.TabIndex = 455
        Me.Label10.Text = "Observaciones"
        '
        'txtObserv
        '
        Me.txtObserv.BackColor = System.Drawing.Color.White
        Me.txtObserv.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObserv.Location = New System.Drawing.Point(156, 266)
        Me.txtObserv.MaxLength = 500
        Me.txtObserv.Multiline = True
        Me.txtObserv.Name = "txtObserv"
        Me.txtObserv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtObserv.Size = New System.Drawing.Size(420, 43)
        Me.txtObserv.TabIndex = 454
        '
        'cmdCopiar
        '
        Me.cmdCopiar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdCopiar.Location = New System.Drawing.Point(627, 473)
        Me.cmdCopiar.Name = "cmdCopiar"
        Me.cmdCopiar.Size = New System.Drawing.Size(59, 41)
        Me.cmdCopiar.TabIndex = 453
        Me.cmdCopiar.Text = "Copiar"
        Me.cmdCopiar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdCopiar.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(526, 482)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(66, 16)
        Me.Label8.TabIndex = 452
        Me.Label8.Text = "Copiar en"
        '
        'cboConversation
        '
        Me.cboConversation.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboConversation.FormattingEnabled = True
        Me.cboConversation.Location = New System.Drawing.Point(529, 527)
        Me.cboConversation.Name = "cboConversation"
        Me.cboConversation.Size = New System.Drawing.Size(440, 26)
        Me.cboConversation.TabIndex = 451
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(526, 508)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 16)
        Me.Label7.TabIndex = 450
        Me.Label7.Text = "Conversacion"
        '
        'chkFile
        '
        Me.chkFile.AutoSize = True
        Me.chkFile.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkFile.Location = New System.Drawing.Point(880, 166)
        Me.chkFile.Name = "chkFile"
        Me.chkFile.Size = New System.Drawing.Size(60, 21)
        Me.chkFile.TabIndex = 449
        Me.chkFile.Text = "Foco"
        Me.chkFile.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(685, 166)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 16)
        Me.Label6.TabIndex = 447
        Me.Label6.Text = "Cuenta"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCuenta
        '
        Me.txtCuenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuenta.Location = New System.Drawing.Point(741, 163)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(75, 22)
        Me.txtCuenta.TabIndex = 446
        Me.txtCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lstConversaciones
        '
        Me.lstConversaciones.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lstConversaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstConversaciones.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.lstConversaciones.Location = New System.Drawing.Point(25, 517)
        Me.lstConversaciones.Name = "lstConversaciones"
        Me.lstConversaciones.Size = New System.Drawing.Size(460, 95)
        Me.lstConversaciones.TabIndex = 445
        Me.lstConversaciones.UseCompatibleStateImageBehavior = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = ""
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = ""
        Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = ""
        Me.ColumnHeader3.Width = 500
        '
        'Button5
        '
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.Location = New System.Drawing.Point(366, 66)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(59, 41)
        Me.Button5.TabIndex = 444
        Me.Button5.Text = "formato"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button5.UseVisualStyleBackColor = True
        '
        'txtHTML
        '
        Me.txtHTML.BackColor = System.Drawing.Color.White
        Me.txtHTML.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHTML.Location = New System.Drawing.Point(25, 428)
        Me.txtHTML.MaxLength = 5000
        Me.txtHTML.Multiline = True
        Me.txtHTML.Name = "txtHTML"
        Me.txtHTML.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtHTML.Size = New System.Drawing.Size(946, 42)
        Me.txtHTML.TabIndex = 443
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(913, 318)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(77, 26)
        Me.Button1.TabIndex = 442
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(441, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 16)
        Me.Label2.TabIndex = 441
        Me.Label2.Text = "orden"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtOrden
        '
        Me.txtOrden.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtOrden.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtOrden.Location = New System.Drawing.Point(484, 54)
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(75, 22)
        Me.txtOrden.TabIndex = 440
        Me.txtOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(627, 205)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(344, 104)
        Me.WebBrowser1.TabIndex = 439
        '
        'cmbConversation
        '
        Me.cmbConversation.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbConversation.FormattingEnabled = True
        Me.cmbConversation.Location = New System.Drawing.Point(741, 131)
        Me.cmbConversation.Name = "cmbConversation"
        Me.cmbConversation.Size = New System.Drawing.Size(231, 24)
        Me.cmbConversation.TabIndex = 438
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(624, 135)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 16)
        Me.Label4.TabIndex = 437
        Me.Label4.Text = "Conversation"
        '
        'txtTraduccion
        '
        Me.txtTraduccion.BackColor = System.Drawing.Color.White
        Me.txtTraduccion.Font = New System.Drawing.Font("Arial Black", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTraduccion.Location = New System.Drawing.Point(156, 181)
        Me.txtTraduccion.MaxLength = 500
        Me.txtTraduccion.Multiline = True
        Me.txtTraduccion.Name = "txtTraduccion"
        Me.txtTraduccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTraduccion.Size = New System.Drawing.Size(420, 43)
        Me.txtTraduccion.TabIndex = 436
        '
        'cmbGrupo
        '
        Me.cmbGrupo.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGrupo.FormattingEnabled = True
        Me.cmbGrupo.Location = New System.Drawing.Point(741, 101)
        Me.cmbGrupo.Name = "cmbGrupo"
        Me.cmbGrupo.Size = New System.Drawing.Size(230, 24)
        Me.cmbGrupo.TabIndex = 435
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(623, 103)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 434
        Me.Label1.Text = "Grupo"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(45, 181)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(105, 16)
        Me.Label20.TabIndex = 433
        Me.Label20.Text = "Traduccion (ES)"
        '
        'cboState
        '
        Me.cboState.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboState.FormattingEnabled = True
        Me.cboState.Items.AddRange(New Object() {"APRENDIDO", "Falta APRENDER"})
        Me.cboState.Location = New System.Drawing.Point(741, 71)
        Me.cboState.Name = "cboState"
        Me.cboState.Size = New System.Drawing.Size(231, 24)
        Me.cboState.TabIndex = 432
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(624, 70)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(39, 16)
        Me.Label9.TabIndex = 431
        Me.Label9.Text = "State"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.White
        Me.txtDescripcion.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(156, 112)
        Me.txtDescripcion.MaxLength = 500
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDescripcion.Size = New System.Drawing.Size(412, 43)
        Me.txtDescripcion.TabIndex = 430
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(22, 498)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(106, 16)
        Me.Label5.TabIndex = 428
        Me.Label5.Text = "Conversaciones"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(45, 114)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 16)
        Me.Label13.TabIndex = 429
        Me.Label13.Text = "Estructura (EN)"
        '
        'lblTipo
        '
        Me.lblTipo.AutoSize = True
        Me.lblTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTipo.Location = New System.Drawing.Point(101, 60)
        Me.lblTipo.Name = "lblTipo"
        Me.lblTipo.Size = New System.Drawing.Size(33, 16)
        Me.lblTipo.TabIndex = 427
        Me.lblTipo.Text = "Item"
        Me.lblTipo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtId
        '
        Me.txtId.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.txtId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtId.Location = New System.Drawing.Point(144, 57)
        Me.txtId.Name = "txtId"
        Me.txtId.ReadOnly = True
        Me.txtId.Size = New System.Drawing.Size(75, 22)
        Me.txtId.TabIndex = 426
        Me.txtId.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(235, Byte), Integer))
        Me.Panel2.Controls.Add(Me.Button6)
        Me.Panel2.Controls.Add(Me.cmdPlay)
        Me.Panel2.Controls.Add(Me.cmdAudio)
        Me.Panel2.Controls.Add(Me.cmdPapelera)
        Me.Panel2.Controls.Add(Me.cmdImagen)
        Me.Panel2.Controls.Add(Me.Button2)
        Me.Panel2.Controls.Add(Me.cmdCargar)
        Me.Panel2.Controls.Add(Me.cmdNext)
        Me.Panel2.Controls.Add(Me.lblmod)
        Me.Panel2.Controls.Add(Me.cmdAgregarOraciones)
        Me.Panel2.Controls.Add(Me.CmdGuardar)
        Me.Panel2.Controls.Add(Me.cmdExit)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1039, 49)
        Me.Panel2.TabIndex = 465
        '
        'Button6
        '
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.Location = New System.Drawing.Point(532, 5)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(59, 41)
        Me.Button6.TabIndex = 389
        Me.Button6.Text = "Liberar Audio"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button6.UseVisualStyleBackColor = True
        '
        'cmdPlay
        '
        Me.cmdPlay.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdPlay.Location = New System.Drawing.Point(79, 3)
        Me.cmdPlay.Name = "cmdPlay"
        Me.cmdPlay.Size = New System.Drawing.Size(59, 41)
        Me.cmdPlay.TabIndex = 388
        Me.cmdPlay.Text = "Play"
        Me.cmdPlay.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        Me.cmdPlay.UseVisualStyleBackColor = True
        '
        'cmdAudio
        '
        Me.cmdAudio.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdAudio.Location = New System.Drawing.Point(137, 3)
        Me.cmdAudio.Name = "cmdAudio"
        Me.cmdAudio.Size = New System.Drawing.Size(59, 41)
        Me.cmdAudio.TabIndex = 387
        Me.cmdAudio.Text = "Agregar Audio"
        Me.cmdAudio.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdAudio.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAudio.UseVisualStyleBackColor = True
        '
        'cmdPapelera
        '
        Me.cmdPapelera.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdPapelera.Location = New System.Drawing.Point(267, 3)
        Me.cmdPapelera.Name = "cmdPapelera"
        Me.cmdPapelera.Size = New System.Drawing.Size(59, 41)
        Me.cmdPapelera.TabIndex = 386
        Me.cmdPapelera.Text = "Enviar a Papelera"
        Me.cmdPapelera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdPapelera.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdPapelera.UseVisualStyleBackColor = True
        '
        'cmdImagen
        '
        Me.cmdImagen.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdImagen.Location = New System.Drawing.Point(202, 3)
        Me.cmdImagen.Name = "cmdImagen"
        Me.cmdImagen.Size = New System.Drawing.Size(59, 41)
        Me.cmdImagen.TabIndex = 385
        Me.cmdImagen.Text = "Agregar Imagen"
        Me.cmdImagen.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdImagen.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdImagen.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Location = New System.Drawing.Point(591, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(59, 41)
        Me.Button2.TabIndex = 384
        Me.Button2.Text = "Copy"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button2.UseVisualStyleBackColor = True
        '
        'cmdCargar
        '
        Me.cmdCargar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdCargar.Location = New System.Drawing.Point(649, 5)
        Me.cmdCargar.Name = "cmdCargar"
        Me.cmdCargar.Size = New System.Drawing.Size(62, 41)
        Me.cmdCargar.TabIndex = 383
        Me.cmdCargar.Text = "Cargar"
        Me.cmdCargar.UseCompatibleTextRendering = True
        Me.cmdCargar.UseVisualStyleBackColor = True
        '
        'cmdNext
        '
        Me.cmdNext.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdNext.Image = CType(resources.GetObject("cmdNext.Image"), System.Drawing.Image)
        Me.cmdNext.Location = New System.Drawing.Point(795, 5)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(40, 41)
        Me.cmdNext.TabIndex = 382
        Me.cmdNext.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdNext.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'lblmod
        '
        Me.lblmod.AutoSize = True
        Me.lblmod.ForeColor = System.Drawing.Color.Black
        Me.lblmod.Location = New System.Drawing.Point(748, 18)
        Me.lblmod.Name = "lblmod"
        Me.lblmod.Size = New System.Drawing.Size(16, 13)
        Me.lblmod.TabIndex = 94
        Me.lblmod.Text = "[ ]"
        '
        'cmdAgregarOraciones
        '
        Me.cmdAgregarOraciones.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdAgregarOraciones.Location = New System.Drawing.Point(444, 5)
        Me.cmdAgregarOraciones.Name = "cmdAgregarOraciones"
        Me.cmdAgregarOraciones.Size = New System.Drawing.Size(82, 41)
        Me.cmdAgregarOraciones.TabIndex = 355
        Me.cmdAgregarOraciones.Text = "Agregar Oraciones"
        Me.cmdAgregarOraciones.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdAgregarOraciones.UseVisualStyleBackColor = True
        '
        'CmdGuardar
        '
        Me.CmdGuardar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdGuardar.Location = New System.Drawing.Point(875, 10)
        Me.CmdGuardar.Name = "CmdGuardar"
        Me.CmdGuardar.Size = New System.Drawing.Size(53, 32)
        Me.CmdGuardar.TabIndex = 91
        Me.CmdGuardar.Text = "Save"
        Me.CmdGuardar.UseVisualStyleBackColor = True
        '
        'cmdExit
        '
        Me.cmdExit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdExit.Location = New System.Drawing.Point(6, 5)
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(66, 36)
        Me.cmdExit.TabIndex = 0
        Me.cmdExit.Text = "Exit"
        Me.cmdExit.UseVisualStyleBackColor = True
        '
        'FrmDetEstructura
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1039, 672)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.cmdAbrirAudio)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.NumRate)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.txtAudio)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtEsRespuesta)
        Me.Controls.Add(Me.txtTipo)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtObserv)
        Me.Controls.Add(Me.cmdCopiar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboConversation)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.chkFile)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtCuenta)
        Me.Controls.Add(Me.lstConversaciones)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.txtHTML)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtOrden)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.cmbConversation)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtTraduccion)
        Me.Controls.Add(Me.cmbGrupo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.cboState)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.lblTipo)
        Me.Controls.Add(Me.txtId)
        Me.Name = "FrmDetEstructura"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "FrmDetEstructura"
        CType(Me.NumRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAbrirAudio As System.Windows.Forms.Button
    Public WithEvents Label16 As System.Windows.Forms.Label
    Public WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents NumRate As System.Windows.Forms.NumericUpDown
    Public WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtAudio As System.Windows.Forms.TextBox
    Public WithEvents Label12 As System.Windows.Forms.Label
    Public WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtEsRespuesta As System.Windows.Forms.TextBox
    Friend WithEvents txtTipo As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtObserv As System.Windows.Forms.TextBox
    Friend WithEvents cmdCopiar As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboConversation As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkFile As System.Windows.Forms.CheckBox
    Public WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents lstConversaciones As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents txtHTML As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Public WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtOrden As System.Windows.Forms.TextBox
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents cmbConversation As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTraduccion As System.Windows.Forms.TextBox
    Friend WithEvents cmbGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents cboState As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Public WithEvents lblTipo As System.Windows.Forms.Label
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents cmdPlay As System.Windows.Forms.Button
    Friend WithEvents cmdAudio As System.Windows.Forms.Button
    Friend WithEvents cmdPapelera As System.Windows.Forms.Button
    Friend WithEvents cmdImagen As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents cmdCargar As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents lblmod As System.Windows.Forms.Label
    Friend WithEvents cmdAgregarOraciones As System.Windows.Forms.Button
    Friend WithEvents CmdGuardar As System.Windows.Forms.Button
    Friend WithEvents cmdExit As System.Windows.Forms.Button
End Class
