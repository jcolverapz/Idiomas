<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmOraciones
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgvOraciones = New System.Windows.Forms.DataGridView()
        Me.CmdCerrar = New System.Windows.Forms.Button()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.lblSubtema = New System.Windows.Forms.Label()
        Me.cmdOrden = New System.Windows.Forms.Button()
        Me.cmdOrdenar = New System.Windows.Forms.Button()
        Me.cmdGrupos = New System.Windows.Forms.Button()
        Me.cmdOrdenarAZ = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblCuenta = New System.Windows.Forms.Label()
        Me.cmdUpdate = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.cmdObjetivo = New System.Windows.Forms.Button()
        Me.ShapeContainer1 = New Microsoft.VisualBasic.PowerPacks.ShapeContainer()
        Me.RectangleShape1 = New Microsoft.VisualBasic.PowerPacks.RectangleShape()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTraduccion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmdBorrarPuntos = New System.Windows.Forms.Button()
        Me.pbavance = New System.Windows.Forms.ProgressBar()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtaprendidos = New System.Windows.Forms.Label()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.txtAvance = New System.Windows.Forms.Label()
        Me.cmdFoco = New System.Windows.Forms.Button()
        Me.cmdFalta = New System.Windows.Forms.Button()
        Me.cmdAprendidos = New System.Windows.Forms.Button()
        Me.cmdPalabras = New System.Windows.Forms.Button()
        Me.cmdPDF = New System.Windows.Forms.Button()
        Me.cmdAgregarADialogo = New System.Windows.Forms.Button()
        Me.cmdActualizarEstructura = New System.Windows.Forms.Button()
        Me.txtEstructura = New System.Windows.Forms.TextBox()
        Me.cmdUpdateTipo = New System.Windows.Forms.Button()
        Me.cmdFiltroEscuchados = New System.Windows.Forms.Button()
        Me.cmdIPA = New System.Windows.Forms.Button()
        Me.lsvSugerencia = New System.Windows.Forms.ListView()
        Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader25 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader26 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmdEnviarPython = New System.Windows.Forms.Button()
        Me.cboTema = New System.Windows.Forms.ComboBox()
        CType(Me.dgvOraciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(867, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(114, 24)
        Me.Label5.TabIndex = 41
        Me.Label5.Text = "Oraciones"
        '
        'dgvOraciones
        '
        Me.dgvOraciones.AllowUserToAddRows = False
        Me.dgvOraciones.AllowUserToDeleteRows = False
        Me.dgvOraciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOraciones.Cursor = System.Windows.Forms.Cursors.Arrow
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvOraciones.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvOraciones.Location = New System.Drawing.Point(10, 160)
        Me.dgvOraciones.MultiSelect = False
        Me.dgvOraciones.Name = "dgvOraciones"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOraciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvOraciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOraciones.Size = New System.Drawing.Size(1365, 629)
        Me.dgvOraciones.TabIndex = 40
        '
        'CmdCerrar
        '
        Me.CmdCerrar.Location = New System.Drawing.Point(9, 2)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(105, 34)
        Me.CmdCerrar.TabIndex = 39
        Me.CmdCerrar.Text = "Cerrar"
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'cboGrupo
        '
        Me.cboGrupo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(9, 58)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(412, 28)
        Me.cboGrupo.TabIndex = 38
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS Reference Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 19)
        Me.Label1.TabIndex = 37
        Me.Label1.Text = "Grupo"
        '
        'txtBuscar
        '
        Me.txtBuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtBuscar.Font = New System.Drawing.Font("Arial Black", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(94, 118)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(220, 41)
        Me.txtBuscar.TabIndex = 42
        Me.txtBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label2.Font = New System.Drawing.Font("Consolas", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(16, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(70, 22)
        Me.Label2.TabIndex = 43
        Me.Label2.Text = "Buscar"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(118, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 34)
        Me.Button1.TabIndex = 44
        Me.Button1.Text = "Nueva"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1175, 7)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(91, 37)
        Me.Button2.TabIndex = 45
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1015, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(145, 37)
        Me.Button3.TabIndex = 46
        Me.Button3.Text = "Subtema x Oracion"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'lblSubtema
        '
        Me.lblSubtema.AutoSize = True
        Me.lblSubtema.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSubtema.Location = New System.Drawing.Point(1012, 58)
        Me.lblSubtema.Name = "lblSubtema"
        Me.lblSubtema.Size = New System.Drawing.Size(66, 16)
        Me.lblSubtema.TabIndex = 47
        Me.lblSubtema.Text = "Subtema"
        '
        'cmdOrden
        '
        Me.cmdOrden.Location = New System.Drawing.Point(740, 48)
        Me.cmdOrden.Name = "cmdOrden"
        Me.cmdOrden.Size = New System.Drawing.Size(105, 41)
        Me.cmdOrden.TabIndex = 48
        Me.cmdOrden.Text = "Update Orden"
        Me.cmdOrden.UseVisualStyleBackColor = True
        '
        'cmdOrdenar
        '
        Me.cmdOrdenar.Location = New System.Drawing.Point(228, 2)
        Me.cmdOrdenar.Name = "cmdOrdenar"
        Me.cmdOrdenar.Size = New System.Drawing.Size(105, 34)
        Me.cmdOrdenar.TabIndex = 49
        Me.cmdOrdenar.Text = "Ordenar"
        Me.cmdOrdenar.UseVisualStyleBackColor = True
        '
        'cmdGrupos
        '
        Me.cmdGrupos.Location = New System.Drawing.Point(538, 3)
        Me.cmdGrupos.Name = "cmdGrupos"
        Me.cmdGrupos.Size = New System.Drawing.Size(90, 41)
        Me.cmdGrupos.TabIndex = 50
        Me.cmdGrupos.Text = "Grupos"
        Me.cmdGrupos.UseVisualStyleBackColor = True
        '
        'cmdOrdenarAZ
        '
        Me.cmdOrdenarAZ.Location = New System.Drawing.Point(335, 4)
        Me.cmdOrdenarAZ.Name = "cmdOrdenarAZ"
        Me.cmdOrdenarAZ.Size = New System.Drawing.Size(71, 32)
        Me.cmdOrdenarAZ.TabIndex = 51
        Me.cmdOrdenarAZ.Text = "A-Z"
        Me.cmdOrdenarAZ.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(646, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 23)
        Me.Label3.TabIndex = 52
        Me.Label3.Text = "Cuenta"
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCuenta.Location = New System.Drawing.Point(773, 130)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(32, 23)
        Me.lblCuenta.TabIndex = 53
        Me.lblCuenta.Text = "00"
        '
        'cmdUpdate
        '
        Me.cmdUpdate.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdUpdate.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpdate.Location = New System.Drawing.Point(649, 0)
        Me.cmdUpdate.Name = "cmdUpdate"
        Me.cmdUpdate.Size = New System.Drawing.Size(79, 41)
        Me.cmdUpdate.TabIndex = 386
        Me.cmdUpdate.TabStop = False
        Me.cmdUpdate.Text = "Update"
        Me.cmdUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdUpdate.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(649, 43)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(79, 43)
        Me.Button4.TabIndex = 389
        Me.Button4.TabStop = False
        Me.Button4.Text = "Update"
        Me.Button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.Button4.UseVisualStyleBackColor = True
        '
        'cmdObjetivo
        '
        Me.cmdObjetivo.Location = New System.Drawing.Point(1304, 1)
        Me.cmdObjetivo.Name = "cmdObjetivo"
        Me.cmdObjetivo.Size = New System.Drawing.Size(71, 41)
        Me.cmdObjetivo.TabIndex = 390
        Me.cmdObjetivo.Text = "Objetivo"
        Me.cmdObjetivo.UseVisualStyleBackColor = True
        '
        'ShapeContainer1
        '
        Me.ShapeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.ShapeContainer1.Margin = New System.Windows.Forms.Padding(0)
        Me.ShapeContainer1.Name = "ShapeContainer1"
        Me.ShapeContainer1.Shapes.AddRange(New Microsoft.VisualBasic.PowerPacks.Shape() {Me.RectangleShape1})
        Me.ShapeContainer1.Size = New System.Drawing.Size(1844, 815)
        Me.ShapeContainer1.TabIndex = 391
        Me.ShapeContainer1.TabStop = False
        '
        'RectangleShape1
        '
        Me.RectangleShape1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.RectangleShape1.BackStyle = Microsoft.VisualBasic.PowerPacks.BackStyle.Opaque
        Me.RectangleShape1.BorderColor = System.Drawing.Color.Silver
        Me.RectangleShape1.Location = New System.Drawing.Point(879, 52)
        Me.RectangleShape1.Name = "RectangleShape1"
        Me.RectangleShape1.Size = New System.Drawing.Size(20, 20)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS Reference Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(907, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 16)
        Me.Label4.TabIndex = 392
        Me.Label4.Text = "Aprendidos"
        '
        'txtTraduccion
        '
        Me.txtTraduccion.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTraduccion.Location = New System.Drawing.Point(382, 127)
        Me.txtTraduccion.Name = "txtTraduccion"
        Me.txtTraduccion.Size = New System.Drawing.Size(174, 30)
        Me.txtTraduccion.TabIndex = 42
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(322, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 24)
        Me.Label6.TabIndex = 43
        Me.Label6.Text = "Trad"
        '
        'cmdBorrarPuntos
        '
        Me.cmdBorrarPuntos.Location = New System.Drawing.Point(538, 44)
        Me.cmdBorrarPuntos.Name = "cmdBorrarPuntos"
        Me.cmdBorrarPuntos.Size = New System.Drawing.Size(90, 32)
        Me.cmdBorrarPuntos.TabIndex = 393
        Me.cmdBorrarPuntos.Text = "Eliminar Chars"
        Me.cmdBorrarPuntos.UseVisualStyleBackColor = True
        '
        'pbavance
        '
        Me.pbavance.Location = New System.Drawing.Point(17, 788)
        Me.pbavance.Name = "pbavance"
        Me.pbavance.Size = New System.Drawing.Size(1203, 15)
        Me.pbavance.TabIndex = 394
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(773, 93)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 23)
        Me.Label7.TabIndex = 396
        Me.Label7.Text = "00"
        '
        'txtaprendidos
        '
        Me.txtaprendidos.AutoSize = True
        Me.txtaprendidos.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtaprendidos.Location = New System.Drawing.Point(646, 91)
        Me.txtaprendidos.Name = "txtaprendidos"
        Me.txtaprendidos.Size = New System.Drawing.Size(109, 23)
        Me.txtaprendidos.TabIndex = 395
        Me.txtaprendidos.Text = "aprendidos"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(538, 76)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(105, 41)
        Me.Button5.TabIndex = 397
        Me.Button5.Text = "cuenta"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'txtAvance
        '
        Me.txtAvance.AutoSize = True
        Me.txtAvance.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAvance.Location = New System.Drawing.Point(839, 93)
        Me.txtAvance.Name = "txtAvance"
        Me.txtAvance.Size = New System.Drawing.Size(32, 23)
        Me.txtAvance.TabIndex = 398
        Me.txtAvance.Text = "00"
        '
        'cmdFoco
        '
        Me.cmdFoco.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdFoco.Location = New System.Drawing.Point(831, 124)
        Me.cmdFoco.Name = "cmdFoco"
        Me.cmdFoco.Size = New System.Drawing.Size(75, 32)
        Me.cmdFoco.TabIndex = 399
        Me.cmdFoco.Text = "foco"
        Me.cmdFoco.UseVisualStyleBackColor = False
        '
        'cmdFalta
        '
        Me.cmdFalta.Location = New System.Drawing.Point(1272, 56)
        Me.cmdFalta.Name = "cmdFalta"
        Me.cmdFalta.Size = New System.Drawing.Size(84, 39)
        Me.cmdFalta.TabIndex = 400
        Me.cmdFalta.Text = "Falta en Conversacion"
        Me.cmdFalta.UseVisualStyleBackColor = True
        '
        'cmdAprendidos
        '
        Me.cmdAprendidos.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdAprendidos.Location = New System.Drawing.Point(915, 124)
        Me.cmdAprendidos.Name = "cmdAprendidos"
        Me.cmdAprendidos.Size = New System.Drawing.Size(72, 32)
        Me.cmdAprendidos.TabIndex = 401
        Me.cmdAprendidos.Text = "Aprendidos"
        Me.cmdAprendidos.UseVisualStyleBackColor = False
        '
        'cmdPalabras
        '
        Me.cmdPalabras.Location = New System.Drawing.Point(427, 45)
        Me.cmdPalabras.Name = "cmdPalabras"
        Me.cmdPalabras.Size = New System.Drawing.Size(105, 29)
        Me.cmdPalabras.TabIndex = 402
        Me.cmdPalabras.Text = "Cuenta Palabras"
        Me.cmdPalabras.UseVisualStyleBackColor = True
        '
        'cmdPDF
        '
        Me.cmdPDF.Location = New System.Drawing.Point(427, 2)
        Me.cmdPDF.Name = "cmdPDF"
        Me.cmdPDF.Size = New System.Drawing.Size(105, 41)
        Me.cmdPDF.TabIndex = 403
        Me.cmdPDF.Text = "Reporte PDF"
        Me.cmdPDF.UseVisualStyleBackColor = True
        '
        'cmdAgregarADialogo
        '
        Me.cmdAgregarADialogo.Location = New System.Drawing.Point(1251, 136)
        Me.cmdAgregarADialogo.Name = "cmdAgregarADialogo"
        Me.cmdAgregarADialogo.Size = New System.Drawing.Size(105, 22)
        Me.cmdAgregarADialogo.TabIndex = 404
        Me.cmdAgregarADialogo.Text = "Agregar a Dialogo"
        Me.cmdAgregarADialogo.UseVisualStyleBackColor = True
        '
        'cmdActualizarEstructura
        '
        Me.cmdActualizarEstructura.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdActualizarEstructura.Font = New System.Drawing.Font("Arial", 9.25!)
        Me.cmdActualizarEstructura.Location = New System.Drawing.Point(562, 116)
        Me.cmdActualizarEstructura.Name = "cmdActualizarEstructura"
        Me.cmdActualizarEstructura.Size = New System.Drawing.Size(79, 41)
        Me.cmdActualizarEstructura.TabIndex = 405
        Me.cmdActualizarEstructura.TabStop = False
        Me.cmdActualizarEstructura.Text = "Update Estructura"
        Me.cmdActualizarEstructura.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.cmdActualizarEstructura.UseVisualStyleBackColor = True
        '
        'txtEstructura
        '
        Me.txtEstructura.Font = New System.Drawing.Font("Arial Black", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstructura.Location = New System.Drawing.Point(915, 91)
        Me.txtEstructura.Name = "txtEstructura"
        Me.txtEstructura.Size = New System.Drawing.Size(72, 30)
        Me.txtEstructura.TabIndex = 406
        Me.txtEstructura.Text = "0"
        Me.txtEstructura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdUpdateTipo
        '
        Me.cmdUpdateTipo.Location = New System.Drawing.Point(739, 2)
        Me.cmdUpdateTipo.Name = "cmdUpdateTipo"
        Me.cmdUpdateTipo.Size = New System.Drawing.Size(106, 45)
        Me.cmdUpdateTipo.TabIndex = 407
        Me.cmdUpdateTipo.Text = "Update Tipo"
        Me.cmdUpdateTipo.UseVisualStyleBackColor = True
        '
        'cmdFiltroEscuchados
        '
        Me.cmdFiltroEscuchados.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdFiltroEscuchados.Location = New System.Drawing.Point(993, 117)
        Me.cmdFiltroEscuchados.Name = "cmdFiltroEscuchados"
        Me.cmdFiltroEscuchados.Size = New System.Drawing.Size(85, 39)
        Me.cmdFiltroEscuchados.TabIndex = 408
        Me.cmdFiltroEscuchados.Text = "Mas escuchados"
        Me.cmdFiltroEscuchados.UseVisualStyleBackColor = False
        '
        'cmdIPA
        '
        Me.cmdIPA.Location = New System.Drawing.Point(1161, 54)
        Me.cmdIPA.Name = "cmdIPA"
        Me.cmdIPA.Size = New System.Drawing.Size(105, 41)
        Me.cmdIPA.TabIndex = 409
        Me.cmdIPA.Text = "Convertir IPA"
        Me.cmdIPA.UseVisualStyleBackColor = True
        '
        'lsvSugerencia
        '
        Me.lsvSugerencia.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader24, Me.ColumnHeader25, Me.ColumnHeader26, Me.ColumnHeader1})
        Me.lsvSugerencia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvSugerencia.Location = New System.Drawing.Point(1381, 12)
        Me.lsvSugerencia.Name = "lsvSugerencia"
        Me.lsvSugerencia.Size = New System.Drawing.Size(460, 777)
        Me.lsvSugerencia.TabIndex = 410
        Me.lsvSugerencia.UseCompatibleStateImageBehavior = False
        '
        'ColumnHeader24
        '
        Me.ColumnHeader24.Width = 0
        '
        'ColumnHeader25
        '
        Me.ColumnHeader25.Width = 0
        '
        'ColumnHeader26
        '
        Me.ColumnHeader26.Width = 200
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 100
        '
        'cmdEnviarPython
        '
        Me.cmdEnviarPython.Location = New System.Drawing.Point(1251, 101)
        Me.cmdEnviarPython.Name = "cmdEnviarPython"
        Me.cmdEnviarPython.Size = New System.Drawing.Size(105, 25)
        Me.cmdEnviarPython.TabIndex = 411
        Me.cmdEnviarPython.Text = "Python"
        Me.cmdEnviarPython.UseVisualStyleBackColor = True
        '
        'cboTema
        '
        Me.cboTema.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboTema.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTema.FormattingEnabled = True
        Me.cboTema.Location = New System.Drawing.Point(9, 88)
        Me.cboTema.Name = "cboTema"
        Me.cboTema.Size = New System.Drawing.Size(412, 28)
        Me.cboTema.TabIndex = 412
        '
        'FrmOraciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1844, 815)
        Me.Controls.Add(Me.cboTema)
        Me.Controls.Add(Me.cmdEnviarPython)
        Me.Controls.Add(Me.lsvSugerencia)
        Me.Controls.Add(Me.cmdIPA)
        Me.Controls.Add(Me.cmdFiltroEscuchados)
        Me.Controls.Add(Me.cmdUpdateTipo)
        Me.Controls.Add(Me.txtEstructura)
        Me.Controls.Add(Me.cmdActualizarEstructura)
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
        Me.Controls.Add(Me.ShapeContainer1)
        Me.Name = "FrmOraciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "FrmOraciones"
        CType(Me.dgvOraciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dgvOraciones As System.Windows.Forms.DataGridView
    Friend WithEvents CmdCerrar As System.Windows.Forms.Button
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents lblSubtema As System.Windows.Forms.Label
    Friend WithEvents cmdOrden As System.Windows.Forms.Button
    Friend WithEvents cmdOrdenar As System.Windows.Forms.Button
    Friend WithEvents cmdGrupos As System.Windows.Forms.Button
    Friend WithEvents cmdOrdenarAZ As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblCuenta As System.Windows.Forms.Label
    Friend WithEvents cmdUpdate As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents cmdObjetivo As System.Windows.Forms.Button
    Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTraduccion As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmdBorrarPuntos As System.Windows.Forms.Button
    Friend WithEvents pbavance As System.Windows.Forms.ProgressBar
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtaprendidos As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents txtAvance As System.Windows.Forms.Label
    Friend WithEvents cmdFoco As System.Windows.Forms.Button
    Friend WithEvents cmdFalta As System.Windows.Forms.Button
    Friend WithEvents cmdAprendidos As System.Windows.Forms.Button
    Friend WithEvents cmdPalabras As System.Windows.Forms.Button
    Friend WithEvents cmdPDF As System.Windows.Forms.Button
    Friend WithEvents cmdAgregarADialogo As System.Windows.Forms.Button
    Friend WithEvents cmdActualizarEstructura As System.Windows.Forms.Button
    Friend WithEvents txtEstructura As System.Windows.Forms.TextBox
    Friend WithEvents cmdUpdateTipo As System.Windows.Forms.Button
    Friend WithEvents cmdFiltroEscuchados As System.Windows.Forms.Button
    Friend WithEvents cmdIPA As System.Windows.Forms.Button
    Friend WithEvents lsvSugerencia As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader24 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader25 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader26 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdEnviarPython As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cboTema As System.Windows.Forms.ComboBox
End Class
