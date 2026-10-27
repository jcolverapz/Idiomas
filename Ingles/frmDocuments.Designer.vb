<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDocuments
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CmdCerrar = New System.Windows.Forms.Button()
        Me.dgvDocuments = New System.Windows.Forms.DataGridView()
        Me.cmdEditar = New System.Windows.Forms.Button()
        Me.cmdPlay = New System.Windows.Forms.Button()
        CType(Me.dgvDocuments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(228, 11)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 41)
        Me.Button1.TabIndex = 46
        Me.Button1.Text = "New"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CmdCerrar
        '
        Me.CmdCerrar.Location = New System.Drawing.Point(12, 11)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(105, 41)
        Me.CmdCerrar.TabIndex = 45
        Me.CmdCerrar.Text = "Cerrar"
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'dgvDocuments
        '
        Me.dgvDocuments.AllowUserToAddRows = False
        Me.dgvDocuments.AllowUserToDeleteRows = False
        Me.dgvDocuments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDocuments.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDocuments.Location = New System.Drawing.Point(12, 58)
        Me.dgvDocuments.MultiSelect = False
        Me.dgvDocuments.Name = "dgvDocuments"
        Me.dgvDocuments.ReadOnly = True
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDocuments.RowHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDocuments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDocuments.Size = New System.Drawing.Size(981, 722)
        Me.dgvDocuments.TabIndex = 44
        '
        'cmdEditar
        '
        Me.cmdEditar.Location = New System.Drawing.Point(352, 11)
        Me.cmdEditar.Name = "cmdEditar"
        Me.cmdEditar.Size = New System.Drawing.Size(105, 41)
        Me.cmdEditar.TabIndex = 47
        Me.cmdEditar.Text = "Editar"
        Me.cmdEditar.UseVisualStyleBackColor = True
        '
        'cmdPlay
        '
        Me.cmdPlay.Location = New System.Drawing.Point(1013, 58)
        Me.cmdPlay.Name = "cmdPlay"
        Me.cmdPlay.Size = New System.Drawing.Size(87, 36)
        Me.cmdPlay.TabIndex = 48
        Me.cmdPlay.Text = "Play"
        Me.cmdPlay.UseVisualStyleBackColor = True
        '
        'frmDocuments
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1420, 807)
        Me.Controls.Add(Me.cmdPlay)
        Me.Controls.Add(Me.cmdEditar)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CmdCerrar)
        Me.Controls.Add(Me.dgvDocuments)
        Me.Name = "frmDocuments"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmDocuments"
        CType(Me.dgvDocuments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CmdCerrar As System.Windows.Forms.Button
    Friend WithEvents dgvDocuments As System.Windows.Forms.DataGridView
    Friend WithEvents cmdEditar As System.Windows.Forms.Button
    Friend WithEvents cmdPlay As System.Windows.Forms.Button
End Class
