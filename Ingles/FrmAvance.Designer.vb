<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAvance
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dgvListaDatos = New System.Windows.Forms.DataGridView()
        Me.txtIdTema = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.cboTema = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.lblDescripcion = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.cboStatus = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.dgvSubtemas = New System.Windows.Forms.DataGridView()
        Me.Label8 = New System.Windows.Forms.Label()
        CType(Me.dgvListaDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.dgvSubtemas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(463, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(76, 32)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dgvListaDatos
        '
        Me.dgvListaDatos.AllowUserToAddRows = False
        Me.dgvListaDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvListaDatos.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvListaDatos.Location = New System.Drawing.Point(12, 119)
        Me.dgvListaDatos.Name = "dgvListaDatos"
        Me.dgvListaDatos.Size = New System.Drawing.Size(634, 289)
        Me.dgvListaDatos.TabIndex = 1
        '
        'txtIdTema
        '
        Me.txtIdTema.Location = New System.Drawing.Point(260, 54)
        Me.txtIdTema.Name = "txtIdTema"
        Me.txtIdTema.Size = New System.Drawing.Size(44, 20)
        Me.txtIdTema.TabIndex = 2
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(83, 36)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(158, 20)
        Me.txtDescripcion.TabIndex = 3
        '
        'btnActualizar
        '
        Me.btnActualizar.Location = New System.Drawing.Point(316, 610)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(75, 37)
        Me.btnActualizar.TabIndex = 4
        Me.btnActualizar.Text = "actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(239, 610)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(71, 37)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'cboTema
        '
        Me.cboTema.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTema.FormattingEnabled = True
        Me.cboTema.Location = New System.Drawing.Point(16, 80)
        Me.cboTema.Name = "cboTema"
        Me.cboTema.Size = New System.Drawing.Size(288, 28)
        Me.cboTema.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Descripcion"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(545, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "ID"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 64)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(34, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Tema"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 64)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Cantidad"
        '
        'txtCantidad
        '
        Me.txtCantidad.Location = New System.Drawing.Point(84, 61)
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.Size = New System.Drawing.Size(71, 20)
        Me.txtCantidad.TabIndex = 11
        Me.txtCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(35, 90)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 13)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Status"
        '
        'btnBack
        '
        Me.btnBack.Location = New System.Drawing.Point(12, 3)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(66, 33)
        Me.btnBack.TabIndex = 17
        Me.btnBack.Text = "Regresar"
        Me.btnBack.UseVisualStyleBackColor = True
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.Location = New System.Drawing.Point(753, 27)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(57, 20)
        Me.lblDescripcion.TabIndex = 18
        Me.lblDescripcion.Text = "Label7"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dtpFecha)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.cboTipo)
        Me.Panel1.Controls.Add(Me.cboStatus)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.txtCantidad)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.txtDescripcion)
        Me.Panel1.Location = New System.Drawing.Point(239, 414)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(277, 192)
        Me.Panel1.TabIndex = 19
        '
        'dtpFecha
        '
        Me.dtpFecha.Location = New System.Drawing.Point(88, 123)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(173, 20)
        Me.dtpFecha.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(44, 15)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(28, 13)
        Me.Label7.TabIndex = 19
        Me.Label7.Text = "Tipo"
        '
        'cboTipo
        '
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(84, 11)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(106, 21)
        Me.cboTipo.TabIndex = 18
        '
        'cboStatus
        '
        Me.cboStatus.FormattingEnabled = True
        Me.cboStatus.Location = New System.Drawing.Point(84, 89)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(71, 21)
        Me.cboStatus.TabIndex = 17
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 122)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "fecha venc."
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 553)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(95, 34)
        Me.Button2.TabIndex = 20
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(397, 612)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(68, 32)
        Me.Button3.TabIndex = 21
        Me.Button3.Text = "Eliminar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(113, 553)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(106, 32)
        Me.Button4.TabIndex = 22
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'dgvSubtemas
        '
        Me.dgvSubtemas.AllowUserToAddRows = False
        Me.dgvSubtemas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvSubtemas.Location = New System.Drawing.Point(670, 65)
        Me.dgvSubtemas.Name = "dgvSubtemas"
        Me.dgvSubtemas.Size = New System.Drawing.Size(563, 343)
        Me.dgvSubtemas.TabIndex = 24
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(336, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 25)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Avance"
        '
        'FrmAvance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1314, 713)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dgvSubtemas)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblDescripcion)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboTema)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.txtIdTema)
        Me.Controls.Add(Me.dgvListaDatos)
        Me.Controls.Add(Me.Button1)
        Me.Name = "FrmAvance"
        Me.Text = "Form1"
        CType(Me.dgvListaDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dgvSubtemas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents dgvListaDatos As System.Windows.Forms.DataGridView
    Friend WithEvents txtIdTema As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents cboTema As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCantidad As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnBack As System.Windows.Forms.Button
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents dtpFecha As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvSubtemas As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label

End Class
