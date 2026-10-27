<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDuplicados
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.CmdClose = New System.Windows.Forms.Button()
        Me.CmdDuplicados = New System.Windows.Forms.Button()
        Me.dgvGeneral = New System.Windows.Forms.DataGridView()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.dgvDetalles = New System.Windows.Forms.DataGridView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.pbAvance = New System.Windows.Forms.ProgressBar()
        Me.txtCuenta = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.dgvGeneral, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmdClose
        '
        Me.CmdClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdClose.Location = New System.Drawing.Point(12, 12)
        Me.CmdClose.Name = "CmdClose"
        Me.CmdClose.Size = New System.Drawing.Size(119, 47)
        Me.CmdClose.TabIndex = 2
        Me.CmdClose.Text = "Close"
        Me.CmdClose.UseVisualStyleBackColor = True
        '
        'CmdDuplicados
        '
        Me.CmdDuplicados.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdDuplicados.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdDuplicados.Location = New System.Drawing.Point(195, 12)
        Me.CmdDuplicados.Name = "CmdDuplicados"
        Me.CmdDuplicados.Size = New System.Drawing.Size(119, 47)
        Me.CmdDuplicados.TabIndex = 3
        Me.CmdDuplicados.Text = "Duplicados"
        Me.CmdDuplicados.UseVisualStyleBackColor = True
        '
        'dgvGeneral
        '
        Me.dgvGeneral.AllowUserToAddRows = False
        Me.dgvGeneral.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGeneral.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvGeneral.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvGeneral.Location = New System.Drawing.Point(12, 65)
        Me.dgvGeneral.Name = "dgvGeneral"
        Me.dgvGeneral.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGeneral.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvGeneral.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGeneral.Size = New System.Drawing.Size(968, 354)
        Me.dgvGeneral.TabIndex = 4
        '
        'cmdEliminar
        '
        Me.cmdEliminar.Location = New System.Drawing.Point(869, 444)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(111, 44)
        Me.cmdEliminar.TabIndex = 5
        Me.cmdEliminar.Text = "Eliminar"
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'dgvDetalles
        '
        Me.dgvDetalles.AllowUserToAddRows = False
        Me.dgvDetalles.AllowUserToDeleteRows = False
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalles.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetalles.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvDetalles.Location = New System.Drawing.Point(12, 494)
        Me.dgvDetalles.Name = "dgvDetalles"
        Me.dgvDetalles.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetalles.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvDetalles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetalles.Size = New System.Drawing.Size(968, 276)
        Me.dgvDetalles.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 442)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 20)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Detalles"
        '
        'txtBuscar
        '
        Me.txtBuscar.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(12, 463)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(142, 25)
        Me.txtBuscar.TabIndex = 45
        Me.txtBuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pbAvance
        '
        Me.pbAvance.Location = New System.Drawing.Point(12, 424)
        Me.pbAvance.Name = "pbAvance"
        Me.pbAvance.Size = New System.Drawing.Size(968, 14)
        Me.pbAvance.TabIndex = 46
        '
        'txtCuenta
        '
        Me.txtCuenta.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuenta.Location = New System.Drawing.Point(786, 463)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.Size = New System.Drawing.Size(77, 25)
        Me.txtCuenta.TabIndex = 45
        Me.txtCuenta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(719, 464)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(61, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Cuenta"
        '
        'frmDuplicados
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1026, 782)
        Me.Controls.Add(Me.pbAvance)
        Me.Controls.Add(Me.txtCuenta)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvDetalles)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Controls.Add(Me.dgvGeneral)
        Me.Controls.Add(Me.CmdDuplicados)
        Me.Controls.Add(Me.CmdClose)
        Me.Name = "frmDuplicados"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmDuplicados"
        CType(Me.dgvGeneral, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CmdClose As System.Windows.Forms.Button
    Friend WithEvents CmdDuplicados As System.Windows.Forms.Button
    Friend WithEvents dgvGeneral As System.Windows.Forms.DataGridView
    Friend WithEvents cmdEliminar As System.Windows.Forms.Button
    Friend WithEvents dgvDetalles As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents pbAvance As System.Windows.Forms.ProgressBar
    Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
