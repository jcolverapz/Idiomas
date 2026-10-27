<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmOracionesDialogos
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
        Me.dgvOraciones = New System.Windows.Forms.DataGridView()
        Me.CmdCerrar = New System.Windows.Forms.Button()
        Me.txtCuenta = New System.Windows.Forms.TextBox()
        Me.cmdOrdenarAZ = New System.Windows.Forms.Button()
        Me.cmdStatus = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.cmdInsertarNuevos = New System.Windows.Forms.Button()
        Me.cmdHuerfanas = New System.Windows.Forms.Button()
        Me.cmdFrecuencia = New System.Windows.Forms.Button()
        Me.lblinfo = New System.Windows.Forms.Label()
        CType(Me.dgvOraciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvOraciones
        '
        Me.dgvOraciones.AllowUserToAddRows = False
        Me.dgvOraciones.AllowUserToDeleteRows = False
        Me.dgvOraciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOraciones.Cursor = System.Windows.Forms.Cursors.Arrow
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvOraciones.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvOraciones.Location = New System.Drawing.Point(6, 57)
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
        Me.dgvOraciones.Size = New System.Drawing.Size(1468, 629)
        Me.dgvOraciones.TabIndex = 41
        '
        'CmdCerrar
        '
        Me.CmdCerrar.Location = New System.Drawing.Point(8, 3)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(105, 29)
        Me.CmdCerrar.TabIndex = 42
        Me.CmdCerrar.Text = "Cerrar"
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'txtCuenta
        '
        Me.txtCuenta.Location = New System.Drawing.Point(12, 35)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(75, 20)
        Me.txtCuenta.TabIndex = 43
        '
        'cmdOrdenarAZ
        '
        Me.cmdOrdenarAZ.Location = New System.Drawing.Point(134, 5)
        Me.cmdOrdenarAZ.Name = "cmdOrdenarAZ"
        Me.cmdOrdenarAZ.Size = New System.Drawing.Size(71, 41)
        Me.cmdOrdenarAZ.TabIndex = 52
        Me.cmdOrdenarAZ.Text = "Orden por Score"
        Me.cmdOrdenarAZ.UseVisualStyleBackColor = True
        '
        'cmdStatus
        '
        Me.cmdStatus.Location = New System.Drawing.Point(211, 5)
        Me.cmdStatus.Name = "cmdStatus"
        Me.cmdStatus.Size = New System.Drawing.Size(84, 41)
        Me.cmdStatus.TabIndex = 53
        Me.cmdStatus.Text = "Cambiar Status Eliminar"
        Me.cmdStatus.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStatus})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 815)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1492, 22)
        Me.StatusStrip1.TabIndex = 54
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStatus
        '
        Me.ToolStatus.Name = "ToolStatus"
        Me.ToolStatus.Size = New System.Drawing.Size(39, 17)
        Me.ToolStatus.Text = "Status"
        '
        'cmdInsertarNuevos
        '
        Me.cmdInsertarNuevos.Location = New System.Drawing.Point(310, 5)
        Me.cmdInsertarNuevos.Name = "cmdInsertarNuevos"
        Me.cmdInsertarNuevos.Size = New System.Drawing.Size(85, 41)
        Me.cmdInsertarNuevos.TabIndex = 55
        Me.cmdInsertarNuevos.Text = "1.Crear Dialogo"
        Me.cmdInsertarNuevos.UseVisualStyleBackColor = True
        '
        'cmdHuerfanas
        '
        Me.cmdHuerfanas.Location = New System.Drawing.Point(401, 7)
        Me.cmdHuerfanas.Name = "cmdHuerfanas"
        Me.cmdHuerfanas.Size = New System.Drawing.Size(95, 39)
        Me.cmdHuerfanas.TabIndex = 56
        Me.cmdHuerfanas.Text = "2.Insert Dialogo"
        Me.cmdHuerfanas.UseVisualStyleBackColor = True
        '
        'cmdFrecuencia
        '
        Me.cmdFrecuencia.Location = New System.Drawing.Point(1258, 3)
        Me.cmdFrecuencia.Name = "cmdFrecuencia"
        Me.cmdFrecuencia.Size = New System.Drawing.Size(109, 34)
        Me.cmdFrecuencia.TabIndex = 57
        Me.cmdFrecuencia.Text = "Actualizar Uso"
        Me.cmdFrecuencia.UseVisualStyleBackColor = True
        '
        'lblinfo
        '
        Me.lblinfo.AutoSize = True
        Me.lblinfo.Location = New System.Drawing.Point(977, 724)
        Me.lblinfo.Name = "lblinfo"
        Me.lblinfo.Size = New System.Drawing.Size(39, 13)
        Me.lblinfo.TabIndex = 59
        Me.lblinfo.Text = "Label1"
        '
        'frmOracionesDialogos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1492, 837)
        Me.Controls.Add(Me.lblinfo)
        Me.Controls.Add(Me.cmdFrecuencia)
        Me.Controls.Add(Me.cmdHuerfanas)
        Me.Controls.Add(Me.cmdInsertarNuevos)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.cmdStatus)
        Me.Controls.Add(Me.cmdOrdenarAZ)
        Me.Controls.Add(Me.txtCuenta)
        Me.Controls.Add(Me.CmdCerrar)
        Me.Controls.Add(Me.dgvOraciones)
        Me.Name = "frmOracionesDialogos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmOracionesDialogos"
        CType(Me.dgvOraciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvOraciones As System.Windows.Forms.DataGridView
    Friend WithEvents CmdCerrar As System.Windows.Forms.Button
    Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents cmdOrdenarAZ As System.Windows.Forms.Button
    Friend WithEvents cmdStatus As System.Windows.Forms.Button
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStatus As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmdInsertarNuevos As System.Windows.Forms.Button
    Friend WithEvents cmdHuerfanas As System.Windows.Forms.Button
    Friend WithEvents cmdFrecuencia As System.Windows.Forms.Button
    Friend WithEvents lblinfo As System.Windows.Forms.Label
End Class
