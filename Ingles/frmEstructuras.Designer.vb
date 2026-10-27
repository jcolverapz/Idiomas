<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmEstructuras
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmdAgregarADialogo = New System.Windows.Forms.Button()
        Me.cmdPDF = New System.Windows.Forms.Button()
        Me.cmdPalabras = New System.Windows.Forms.Button()
        Me.cmdAprendidos = New System.Windows.Forms.Button()
        Me.cmdFalta = New System.Windows.Forms.Button()
        Me.cmdFoco = New System.Windows.Forms.Button()
        Me.txtAvance = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtaprendidos = New System.Windows.Forms.Label()
        Me.pbavance = New System.Windows.Forms.ProgressBar()
        Me.cmdBorrarPuntos = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtTraduccion = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cmdObjetivo = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.rtb = New System.Windows.Forms.RichTextBox()
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.lblCuenta = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdOrdenarAZ = New System.Windows.Forms.Button()
        Me.cmdGrupos = New System.Windows.Forms.Button()
        Me.cmdOrdenar = New System.Windows.Forms.Button()
        Me.cmdOrden = New System.Windows.Forms.Button()
        Me.lblSubtema = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgvOraciones = New System.Windows.Forms.DataGridView()
        Me.CmdCerrar = New System.Windows.Forms.Button()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvDetalles = New System.Windows.Forms.DataGridView()
        Me.cmdBorrar = New System.Windows.Forms.Button()
        CType(Me.dgvOraciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdAgregarADialogo
        '
        Me.cmdAgregarADialogo.Location = New System.Drawing.Point(996, 141)
        Me.cmdAgregarADialogo.Name = "cmdAgregarADialogo"
        Me.cmdAgregarADialogo.Size = New System.Drawing.Size(105, 22)
        Me.cmdAgregarADialogo.TabIndex = 441
        Me.cmdAgregarADialogo.Text = "Agregar a Dialogo"
        Me.cmdAgregarADialogo.UseVisualStyleBackColor = True
        '
        'cmdPDF
        '
        Me.cmdPDF.Location = New System.Drawing.Point(996, 95)
        Me.cmdPDF.Name = "cmdPDF"
        Me.cmdPDF.Size = New System.Drawing.Size(105, 41)
        Me.cmdPDF.TabIndex = 440
        Me.cmdPDF.Text = "Reporte PDF"
        Me.cmdPDF.UseVisualStyleBackColor = True
        '
        'cmdPalabras
        '
        Me.cmdPalabras.Location = New System.Drawing.Point(427, 54)
        Me.cmdPalabras.Name = "cmdPalabras"
        Me.cmdPalabras.Size = New System.Drawing.Size(105, 29)
        Me.cmdPalabras.TabIndex = 439
        Me.cmdPalabras.Text = "Cuenta Palabras"
        Me.cmdPalabras.UseVisualStyleBackColor = True
        '
        'cmdAprendidos
        '
        Me.cmdAprendidos.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdAprendidos.Location = New System.Drawing.Point(915, 133)
        Me.cmdAprendidos.Name = "cmdAprendidos"
        Me.cmdAprendidos.Size = New System.Drawing.Size(72, 32)
        Me.cmdAprendidos.TabIndex = 438
        Me.cmdAprendidos.Text = "Aprendidos"
        Me.cmdAprendidos.UseVisualStyleBackColor = False
        '
        'cmdFalta
        '
        Me.cmdFalta.Location = New System.Drawing.Point(776, 56)
        Me.cmdFalta.Name = "cmdFalta"
        Me.cmdFalta.Size = New System.Drawing.Size(84, 39)
        Me.cmdFalta.TabIndex = 437
        Me.cmdFalta.Text = "Falta en Conversacion"
        Me.cmdFalta.UseVisualStyleBackColor = True
        '
        'cmdFoco
        '
        Me.cmdFoco.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdFoco.Location = New System.Drawing.Point(831, 133)
        Me.cmdFoco.Name = "cmdFoco"
        Me.cmdFoco.Size = New System.Drawing.Size(75, 32)
        Me.cmdFoco.TabIndex = 436
        Me.cmdFoco.Text = "foco"
        Me.cmdFoco.UseVisualStyleBackColor = False
        '
        'txtAvance
        '
        Me.txtAvance.AutoSize = True
        Me.txtAvance.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAvance.Location = New System.Drawing.Point(839, 102)
        Me.txtAvance.Name = "txtAvance"
        Me.txtAvance.Size = New System.Drawing.Size(32, 23)
        Me.txtAvance.TabIndex = 435
        Me.txtAvance.Text = "00"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(538, 89)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(105, 41)
        Me.Button5.TabIndex = 434
        Me.Button5.Text = "cuenta"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(773, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 23)
        Me.Label7.TabIndex = 433
        Me.Label7.Text = "00"
        '
        'txtaprendidos
        '
        Me.txtaprendidos.AutoSize = True
        Me.txtaprendidos.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtaprendidos.Location = New System.Drawing.Point(646, 100)
        Me.txtaprendidos.Name = "txtaprendidos"
        Me.txtaprendidos.Size = New System.Drawing.Size(109, 23)
        Me.txtaprendidos.TabIndex = 432
        Me.txtaprendidos.Text = "aprendidos"
        '
        'pbavance
        '
        Me.pbavance.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbavance.Location = New System.Drawing.Point(0, 814)
        Me.pbavance.Name = "pbavance"
        Me.pbavance.Size = New System.Drawing.Size(1341, 15)
        Me.pbavance.TabIndex = 431
        '
        'cmdBorrarPuntos
        '
        Me.cmdBorrarPuntos.Location = New System.Drawing.Point(538, 57)
        Me.cmdBorrarPuntos.Name = "cmdBorrarPuntos"
        Me.cmdBorrarPuntos.Size = New System.Drawing.Size(90, 32)
        Me.cmdBorrarPuntos.TabIndex = 430
        Me.cmdBorrarPuntos.Text = "Eliminar Chars"
        Me.cmdBorrarPuntos.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(322, 137)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 24)
        Me.Label6.TabIndex = 412
        Me.Label6.Text = "Trad"
        '
        'txtTraduccion
        '
        Me.txtTraduccion.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTraduccion.Location = New System.Drawing.Point(382, 136)
        Me.txtTraduccion.Name = "txtTraduccion"
        Me.txtTraduccion.Size = New System.Drawing.Size(174, 30)
        Me.txtTraduccion.TabIndex = 410
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(907, 67)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 429
        Me.Label4.Text = "Aprendidos"
        '
        'cmdObjetivo
        '
        Me.cmdObjetivo.Location = New System.Drawing.Point(776, 12)
        Me.cmdObjetivo.Name = "cmdObjetivo"
        Me.cmdObjetivo.Size = New System.Drawing.Size(71, 41)
        Me.cmdObjetivo.TabIndex = 428
        Me.cmdObjetivo.Text = "Objetivo"
        Me.cmdObjetivo.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(649, 52)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(79, 43)
        Me.Button4.TabIndex = 427
        Me.Button4.TabStop = False
        Me.Button4.Text = "Update"
        Me.Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button4.UseVisualStyleBackColor = True
        '
        'rtb
        '
        Me.rtb.Location = New System.Drawing.Point(1191, 65)
        Me.rtb.Name = "rtb"
        Me.rtb.Size = New System.Drawing.Size(64, 102)
        Me.rtb.TabIndex = 426
        Me.rtb.Text = ""
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Location = New System.Drawing.Point(1107, 59)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New System.Drawing.Size(78, 104)
        Me.WebBrowser1.TabIndex = 425
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdUpdate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdate.Location = New System.Drawing.Point(649, 9)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(79, 41)
        Me.cmdUpdate.TabIndex = 424
        Me.cmdUpdate.TabStop = False
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuenta.Location = New System.Drawing.Point(773, 139)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(32, 23)
        Me.lblCuenta.TabIndex = 423
        Me.lblCuenta.Text = "00"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(646, 137)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 23)
        Me.Label3.TabIndex = 422
        Me.Label3.Text = "Cuenta"
        '
        'cmdOrdenarAZ
        '
        Me.cmdOrdenarAZ.Location = New System.Drawing.Point(350, 18)
        Me.cmdOrdenarAZ.Name = "cmdOrdenarAZ"
        Me.cmdOrdenarAZ.Size = New System.Drawing.Size(71, 41)
        Me.cmdOrdenarAZ.TabIndex = 421
        Me.cmdOrdenarAZ.Text = "A-Z"
        Me.cmdOrdenarAZ.UseVisualStyleBackColor = True
        '
        'cmdGrupos
        '
        Me.cmdGrupos.Location = New System.Drawing.Point(538, 12)
        Me.cmdGrupos.Name = "cmdGrupos"
        Me.cmdGrupos.Size = New System.Drawing.Size(90, 41)
        Me.cmdGrupos.TabIndex = 420
        Me.cmdGrupos.Text = "Grupos"
        Me.cmdGrupos.UseVisualStyleBackColor = True
        '
        'cmdOrdenar
        '
        Me.cmdOrdenar.Location = New System.Drawing.Point(221, 3)
        Me.cmdOrdenar.Name = "cmdOrdenar"
        Me.cmdOrdenar.Size = New System.Drawing.Size(105, 41)
        Me.cmdOrdenar.TabIndex = 419
        Me.cmdOrdenar.Text = "Ordenar"
        Me.cmdOrdenar.UseVisualStyleBackColor = True
        '
        'cmdOrden
        '
        Me.cmdOrden.Location = New System.Drawing.Point(427, 12)
        Me.cmdOrden.Name = "cmdOrden"
        Me.cmdOrden.Size = New System.Drawing.Size(105, 41)
        Me.cmdOrden.TabIndex = 418
        Me.cmdOrden.Text = "Update Orden"
        Me.cmdOrden.UseVisualStyleBackColor = True
        '
        'lblSubtema
        '
        Me.lblSubtema.AutoSize = True
        Me.lblSubtema.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtema.Location = New System.Drawing.Point(1012, 67)
        Me.lblSubtema.Name = "lblSubtema"
        Me.lblSubtema.Size = New System.Drawing.Size(66, 16)
        Me.lblSubtema.TabIndex = 417
        Me.lblSubtema.Text = "Subtema"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1015, 13)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(145, 37)
        Me.Button3.TabIndex = 416
        Me.Button3.Text = "Subtema x Oracion"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1175, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(91, 37)
        Me.Button2.TabIndex = 415
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(111, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 41)
        Me.Button1.TabIndex = 414
        Me.Button1.Text = "Nueva"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label2.Font = New System.Drawing.Font("Consolas", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(11, 136)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 22)
        Me.Label2.TabIndex = 413
        Me.Label2.Text = "Buscar"
        '
        'txtBuscar
        '
        Me.txtBuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtBuscar.Font = New System.Drawing.Font("Arial Black", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(93, 126)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(220, 41)
        Me.txtBuscar.TabIndex = 411
        Me.txtBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(867, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 24)
        Me.Label5.TabIndex = 409
        Me.Label5.Text = "Oraciones"
        '
        'dgvOraciones
        '
        Me.dgvOraciones.AllowUserToAddRows = False
        Me.dgvOraciones.AllowUserToDeleteRows = False
        Me.dgvOraciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOraciones.Cursor = System.Windows.Forms.Cursors.Arrow
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvOraciones.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvOraciones.Location = New System.Drawing.Point(10, 169)
        Me.dgvOraciones.MultiSelect = False
        Me.dgvOraciones.Name = "dgvOraciones"
        Me.dgvOraciones.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOraciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvOraciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOraciones.Size = New System.Drawing.Size(1203, 319)
        Me.dgvOraciones.TabIndex = 408
        '
        'CmdCerrar
        '
        Me.CmdCerrar.Location = New System.Drawing.Point(4, 3)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(105, 41)
        Me.CmdCerrar.TabIndex = 407
        Me.CmdCerrar.Text = "Cerrar"
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'cboGrupo
        '
        Me.cboGrupo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(12, 86)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(463, 28)
        Me.cboGrupo.TabIndex = 406
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 24)
        Me.Label1.TabIndex = 405
        Me.Label1.Text = "Grupo"
        '
        'dgvDetalles
        '
        Me.dgvDetalles.AllowUserToAddRows = False
        Me.dgvDetalles.AllowUserToDeleteRows = False
        Me.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalles.Cursor = System.Windows.Forms.Cursors.Arrow
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetalles.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDetalles.Location = New System.Drawing.Point(10, 494)
        Me.dgvDetalles.MultiSelect = False
        Me.dgvDetalles.Name = "dgvDetalles"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalles.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalles.Size = New System.Drawing.Size(1203, 301)
        Me.dgvDetalles.TabIndex = 442
        '
        'cmdBorrar
        '
        Me.cmdBorrar.Location = New System.Drawing.Point(1224, 494)
        Me.cmdBorrar.Name = "cmdBorrar"
        Me.cmdBorrar.Size = New System.Drawing.Size(105, 41)
        Me.cmdBorrar.TabIndex = 443
        Me.cmdBorrar.Text = "Borrar"
        Me.cmdBorrar.UseVisualStyleBackColor = True
        '
        'frmEstructuras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1341, 829)
        Me.Controls.Add(Me.cmdBorrar)
        Me.Controls.Add(Me.dgvDetalles)
        Me.Controls.Add(Me.cmdAgregarADialogo)
        Me.Controls.Add(Me.cmdPDF)
        Me.Controls.Add(Me.cmdPalabras)
        Me.Controls.Add(Me.cmdAprendidos)
        Me.Controls.Add(Me.cmdFalta)
        Me.Controls.Add(Me.cmdFoco)
        Me.Controls.Add(Me.txtAvance)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtaprendidos)
        Me.Controls.Add(Me.pbavance)
        Me.Controls.Add(Me.cmdBorrarPuntos)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtTraduccion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdObjetivo)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.rtb)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Controls.Add(Me.cmdUpdate)
        Me.Controls.Add(Me.lblCuenta)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmdOrdenarAZ)
        Me.Controls.Add(Me.cmdGrupos)
        Me.Controls.Add(Me.cmdOrdenar)
        Me.Controls.Add(Me.cmdOrden)
        Me.Controls.Add(Me.lblSubtema)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.dgvOraciones)
        Me.Controls.Add(Me.CmdCerrar)
        Me.Controls.Add(Me.cboGrupo)
        Me.Controls.Add(Me.Label1)
        Me.Name = "frmEstructuras"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmEstructuras"
        CType(Me.dgvOraciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdAgregarADialogo As System.Windows.Forms.Button
    Friend WithEvents cmdPDF As System.Windows.Forms.Button
    Friend WithEvents cmdPalabras As System.Windows.Forms.Button
    Friend WithEvents cmdAprendidos As System.Windows.Forms.Button
    Friend WithEvents cmdFalta As System.Windows.Forms.Button
    Friend WithEvents cmdFoco As System.Windows.Forms.Button
    Friend WithEvents txtAvance As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtaprendidos As System.Windows.Forms.Label
    Friend WithEvents pbavance As System.Windows.Forms.ProgressBar
    Friend WithEvents cmdBorrarPuntos As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtTraduccion As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmdObjetivo As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents rtb As System.Windows.Forms.RichTextBox
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents lblCuenta As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdOrdenarAZ As System.Windows.Forms.Button
    Friend WithEvents cmdGrupos As System.Windows.Forms.Button
    Friend WithEvents cmdOrdenar As System.Windows.Forms.Button
    Friend WithEvents cmdOrden As System.Windows.Forms.Button
    Friend WithEvents lblSubtema As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgvOraciones As System.Windows.Forms.DataGridView
    Friend WithEvents CmdCerrar As System.Windows.Forms.Button
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvDetalles As System.Windows.Forms.DataGridView
    Friend WithEvents cmdBorrar As System.Windows.Forms.Button
End Class
