<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListAudios
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
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cmdErrores = New System.Windows.Forms.Button()
        Me.cmdSeleccionar = New System.Windows.Forms.Button()
        Me.cmdAtras = New System.Windows.Forms.Button()
        Me.tbVolume = New System.Windows.Forms.TrackBar()
        Me.chkMostrarOcultar = New System.Windows.Forms.CheckBox()
        Me.numFontSize = New System.Windows.Forms.NumericUpDown()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.tbVelocidad = New System.Windows.Forms.TrackBar()
        Me.txtCurrentPosition = New System.Windows.Forms.Label()
        Me.lblSpeedValue = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmdPause = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdPlay = New System.Windows.Forms.Button()
        Me.cmdMover = New System.Windows.Forms.Button()
        Me.dgvOraciones = New System.Windows.Forms.DataGridView()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.cmdTexto = New System.Windows.Forms.Button()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.lblCuenta = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        CType(Me.tbVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFontSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tbVelocidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvOraciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdErrores
        '
        Me.cmdErrores.Location = New System.Drawing.Point(206, 43)
        Me.cmdErrores.Name = "cmdErrores"
        Me.cmdErrores.Size = New System.Drawing.Size(76, 24)
        Me.cmdErrores.TabIndex = 87
        Me.cmdErrores.Text = "Errores"
        Me.cmdErrores.UseVisualStyleBackColor = True
        '
        'cmdSeleccionar
        '
        Me.cmdSeleccionar.Location = New System.Drawing.Point(123, 46)
        Me.cmdSeleccionar.Name = "cmdSeleccionar"
        Me.cmdSeleccionar.Size = New System.Drawing.Size(76, 24)
        Me.cmdSeleccionar.TabIndex = 88
        Me.cmdSeleccionar.Text = "Seleccionar"
        Me.cmdSeleccionar.UseVisualStyleBackColor = True
        '
        'cmdAtras
        '
        Me.cmdAtras.Location = New System.Drawing.Point(281, 7)
        Me.cmdAtras.Name = "cmdAtras"
        Me.cmdAtras.Size = New System.Drawing.Size(72, 33)
        Me.cmdAtras.TabIndex = 85
        Me.cmdAtras.Text = "Atras"
        Me.cmdAtras.UseVisualStyleBackColor = True
        '
        'tbVolume
        '
        Me.tbVolume.AutoSize = False
        Me.tbVolume.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbVolume.LargeChange = 1
        Me.tbVolume.Location = New System.Drawing.Point(12, 81)
        Me.tbVolume.Maximum = 100
        Me.tbVolume.Name = "tbVolume"
        Me.tbVolume.Size = New System.Drawing.Size(195, 31)
        Me.tbVolume.TabIndex = 86
        Me.tbVolume.Value = 50
        '
        'chkMostrarOcultar
        '
        Me.chkMostrarOcultar.AutoSize = True
        Me.chkMostrarOcultar.Checked = True
        Me.chkMostrarOcultar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMostrarOcultar.Location = New System.Drawing.Point(306, 57)
        Me.chkMostrarOcultar.Name = "chkMostrarOcultar"
        Me.chkMostrarOcultar.Size = New System.Drawing.Size(90, 17)
        Me.chkMostrarOcultar.TabIndex = 83
        Me.chkMostrarOcultar.Text = "Ocultar Texto"
        Me.chkMostrarOcultar.UseVisualStyleBackColor = True
        '
        'numFontSize
        '
        Me.numFontSize.Location = New System.Drawing.Point(1286, 33)
        Me.numFontSize.Name = "numFontSize"
        Me.numFontSize.Size = New System.Drawing.Size(48, 20)
        Me.numFontSize.TabIndex = 82
        Me.numFontSize.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(446, 5)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(45, 27)
        Me.cmdSave.TabIndex = 81
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'tbVelocidad
        '
        Me.tbVelocidad.AutoSize = False
        Me.tbVelocidad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbVelocidad.LargeChange = 1
        Me.tbVelocidad.Location = New System.Drawing.Point(245, 92)
        Me.tbVelocidad.Minimum = 5
        Me.tbVelocidad.Name = "tbVelocidad"
        Me.tbVelocidad.Size = New System.Drawing.Size(195, 31)
        Me.tbVelocidad.TabIndex = 80
        Me.tbVelocidad.Value = 10
        '
        'txtCurrentPosition
        '
        Me.txtCurrentPosition.AutoSize = True
        Me.txtCurrentPosition.Location = New System.Drawing.Point(402, 54)
        Me.txtCurrentPosition.Name = "txtCurrentPosition"
        Me.txtCurrentPosition.Size = New System.Drawing.Size(13, 13)
        Me.txtCurrentPosition.TabIndex = 78
        Me.txtCurrentPosition.Text = "0"
        '
        'lblSpeedValue
        '
        Me.lblSpeedValue.AutoSize = True
        Me.lblSpeedValue.Location = New System.Drawing.Point(324, 68)
        Me.lblSpeedValue.Name = "lblSpeedValue"
        Me.lblSpeedValue.Size = New System.Drawing.Size(13, 13)
        Me.lblSpeedValue.TabIndex = 79
        Me.lblSpeedValue.Text = "0"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1283, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Font Size"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "Volume"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(252, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "Slow"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(446, 92)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 13)
        Me.Label3.TabIndex = 77
        Me.Label3.Text = "1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(217, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 13)
        Me.Label2.TabIndex = 76
        Me.Label2.Text = "0.5"
        '
        'cmdPause
        '
        Me.cmdPause.Location = New System.Drawing.Point(192, 5)
        Me.cmdPause.Name = "cmdPause"
        Me.cmdPause.Size = New System.Drawing.Size(87, 36)
        Me.cmdPause.TabIndex = 69
        Me.cmdPause.Text = "Pause"
        Me.cmdPause.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(6, 5)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(87, 36)
        Me.cmdClose.TabIndex = 68
        Me.cmdClose.Text = "Cerrar"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdPlay
        '
        Me.cmdPlay.Location = New System.Drawing.Point(99, 5)
        Me.cmdPlay.Name = "cmdPlay"
        Me.cmdPlay.Size = New System.Drawing.Size(87, 36)
        Me.cmdPlay.TabIndex = 67
        Me.cmdPlay.Text = "Play"
        Me.cmdPlay.UseVisualStyleBackColor = True
        '
        'cmdMover
        '
        Me.cmdMover.Location = New System.Drawing.Point(826, 73)
        Me.cmdMover.Name = "cmdMover"
        Me.cmdMover.Size = New System.Drawing.Size(109, 32)
        Me.cmdMover.TabIndex = 91
        Me.cmdMover.Text = "Mover"
        Me.cmdMover.UseVisualStyleBackColor = True
        '
        'dgvOraciones
        '
        Me.dgvOraciones.AllowUserToAddRows = False
        Me.dgvOraciones.AllowUserToDeleteRows = False
        Me.dgvOraciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOraciones.Cursor = System.Windows.Forms.Cursors.Arrow
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvOraciones.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgvOraciones.Location = New System.Drawing.Point(504, 118)
        Me.dgvOraciones.MultiSelect = False
        Me.dgvOraciones.Name = "dgvOraciones"
        Me.dgvOraciones.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvOraciones.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgvOraciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvOraciones.Size = New System.Drawing.Size(798, 765)
        Me.dgvOraciones.TabIndex = 92
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Label6.Font = New System.Drawing.Font("Consolas", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(501, 82)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(70, 22)
        Me.Label6.TabIndex = 94
        Me.Label6.Text = "Buscar"
        '
        'txtBuscar
        '
        Me.txtBuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBuscar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.txtBuscar.Font = New System.Drawing.Font("Arial Black", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(577, 71)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(220, 41)
        Me.txtBuscar.TabIndex = 93
        Me.txtBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cboGrupo
        '
        Me.cboGrupo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(577, 12)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(463, 28)
        Me.cboGrupo.TabIndex = 96
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(497, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 24)
        Me.Label7.TabIndex = 95
        Me.Label7.Text = "Grupo"
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(359, 5)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(72, 33)
        Me.Button3.TabIndex = 97
        Me.Button3.Text = "Refresh"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'cmdTexto
        '
        Me.cmdTexto.Location = New System.Drawing.Point(1070, 12)
        Me.cmdTexto.Name = "cmdTexto"
        Me.cmdTexto.Size = New System.Drawing.Size(109, 32)
        Me.cmdTexto.TabIndex = 98
        Me.cmdTexto.Text = "Cargar"
        Me.cmdTexto.UseVisualStyleBackColor = True
        '
        'cmdEliminar
        '
        Me.cmdEliminar.Location = New System.Drawing.Point(437, 39)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(77, 39)
        Me.cmdEliminar.TabIndex = 99
        Me.cmdEliminar.Text = "Eliminar"
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.ListView1.Font = New System.Drawing.Font("Arial Black", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.Location = New System.Drawing.Point(12, 118)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(465, 765)
        Me.ListView1.TabIndex = 100
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 0
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 100
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Width = 300
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.Location = New System.Drawing.Point(604, 49)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(13, 13)
        Me.lblCuenta.TabIndex = 101
        Me.lblCuenta.Text = "0"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(540, 49)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 102
        Me.Label9.Text = "Cantidad"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(1070, 48)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(109, 32)
        Me.Button4.TabIndex = 103
        Me.Button4.Text = "Cargar Faltantes"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(1202, 48)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(68, 35)
        Me.Button5.TabIndex = 104
        Me.Button5.Text = "Agregar a Dialogo"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'frmListAudios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1516, 899)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.lblCuenta)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Controls.Add(Me.cmdTexto)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.cboGrupo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.dgvOraciones)
        Me.Controls.Add(Me.cmdMover)
        Me.Controls.Add(Me.cmdErrores)
        Me.Controls.Add(Me.cmdSeleccionar)
        Me.Controls.Add(Me.cmdAtras)
        Me.Controls.Add(Me.tbVolume)
        Me.Controls.Add(Me.chkMostrarOcultar)
        Me.Controls.Add(Me.numFontSize)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.tbVelocidad)
        Me.Controls.Add(Me.txtCurrentPosition)
        Me.Controls.Add(Me.lblSpeedValue)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmdPause)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdPlay)
        Me.Name = "frmListAudios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmListAudios"
        CType(Me.tbVolume, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFontSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tbVelocidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvOraciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(false)
        Me.PerformLayout

End Sub
    Friend WithEvents cmdErrores As System.Windows.Forms.Button
    Friend WithEvents cmdSeleccionar As System.Windows.Forms.Button
    Friend WithEvents cmdAtras As System.Windows.Forms.Button
    Friend WithEvents tbVolume As System.Windows.Forms.TrackBar
    Friend WithEvents chkMostrarOcultar As System.Windows.Forms.CheckBox
    Friend WithEvents numFontSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents tbVelocidad As System.Windows.Forms.TrackBar
    Friend WithEvents txtCurrentPosition As System.Windows.Forms.Label
    Friend WithEvents lblSpeedValue As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdPause As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdPlay As System.Windows.Forms.Button
    Friend WithEvents cmdMover As System.Windows.Forms.Button
    Friend WithEvents dgvOraciones As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents cmdTexto As System.Windows.Forms.Button
    Friend WithEvents cmdEliminar As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents lblCuenta As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
End Class
