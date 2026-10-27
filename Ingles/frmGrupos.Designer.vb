<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmGrupos
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.dgvGrupos = New System.Windows.Forms.DataGridView()
        Me.CmdCerrar = New System.Windows.Forms.Button()
        Me.cmdOrdenar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvGrupos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 16)
        Me.Label2.TabIndex = 46
        Me.Label2.Text = "Buscar"
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(63, 86)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(294, 20)
        Me.txtBuscar.TabIndex = 45
        '
        'dgvGrupos
        '
        Me.dgvGrupos.AllowUserToAddRows = False
        Me.dgvGrupos.AllowUserToDeleteRows = False
        Me.dgvGrupos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvGrupos.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvGrupos.Location = New System.Drawing.Point(12, 112)
        Me.dgvGrupos.MultiSelect = False
        Me.dgvGrupos.Name = "dgvGrupos"
        Me.dgvGrupos.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGrupos.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvGrupos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGrupos.Size = New System.Drawing.Size(841, 701)
        Me.dgvGrupos.TabIndex = 44
        '
        'CmdCerrar
        '
        Me.CmdCerrar.Location = New System.Drawing.Point(12, 12)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(105, 41)
        Me.CmdCerrar.TabIndex = 47
        Me.CmdCerrar.Text = "Cerrar"
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'cmdOrdenar
        '
        Me.cmdOrdenar.Location = New System.Drawing.Point(566, 12)
        Me.cmdOrdenar.Name = "cmdOrdenar"
        Me.cmdOrdenar.Size = New System.Drawing.Size(105, 41)
        Me.cmdOrdenar.TabIndex = 48
        Me.cmdOrdenar.Text = "Ordenar"
        Me.cmdOrdenar.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(455, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 41)
        Me.Button1.TabIndex = 49
        Me.Button1.Text = "Nueva"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtDescripcion
        '
        Me.txtDescripcion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDescripcion.Location = New System.Drawing.Point(139, 31)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(305, 22)
        Me.txtDescripcion.TabIndex = 381
        Me.txtDescripcion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(147, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 16)
        Me.Label1.TabIndex = 382
        Me.Label1.Text = "Grupo"
        '
        'frmGrupos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1114, 825)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdOrdenar)
        Me.Controls.Add(Me.CmdCerrar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.dgvGrupos)
        Me.Name = "frmGrupos"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmGrupos"
        CType(Me.dgvGrupos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents dgvGrupos As System.Windows.Forms.DataGridView
    Friend WithEvents CmdCerrar As System.Windows.Forms.Button
    Friend WithEvents cmdOrdenar As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
