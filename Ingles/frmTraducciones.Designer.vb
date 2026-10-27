<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTraducciones
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
        Me.cmdExportarWord = New System.Windows.Forms.Button()
        Me.dgvOraciones = New System.Windows.Forms.DataGridView()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtTraduccion = New System.Windows.Forms.TextBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.cmdBuscar = New System.Windows.Forms.Button()
        Me.cmdTextoSplit = New System.Windows.Forms.Button()
        CType(Me.dgvOraciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdExportarWord
        '
        Me.cmdExportarWord.Location = New System.Drawing.Point(278, 10)
        Me.cmdExportarWord.Name = "cmdExportarWord"
        Me.cmdExportarWord.Size = New System.Drawing.Size(148, 42)
        Me.cmdExportarWord.TabIndex = 0
        Me.cmdExportarWord.Text = "Exportar Word"
        Me.cmdExportarWord.UseVisualStyleBackColor = True
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
        Me.dgvOraciones.Location = New System.Drawing.Point(4, 69)
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
        Me.dgvOraciones.Size = New System.Drawing.Size(694, 596)
        Me.dgvOraciones.TabIndex = 41
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(8, 5)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(95, 49)
        Me.cmdClose.TabIndex = 42
        Me.cmdClose.Text = "Close"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1332, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 42)
        Me.Button1.TabIndex = 43
        Me.Button1.Text = "Exportar Word"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(897, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 24)
        Me.Label4.TabIndex = 406
        Me.Label4.Text = "Ingles"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(1304, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 24)
        Me.Label5.TabIndex = 408
        Me.Label5.Text = "Español"
        '
        'txtTraduccion
        '
        Me.txtTraduccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTraduccion.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTraduccion.Location = New System.Drawing.Point(1199, 93)
        Me.txtTraduccion.Multiline = True
        Me.txtTraduccion.Name = "txtTraduccion"
        Me.txtTraduccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTraduccion.Size = New System.Drawing.Size(391, 574)
        Me.txtTraduccion.TabIndex = 407
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(704, 8)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(103, 36)
        Me.Button2.TabIndex = 409
        Me.Button2.Text = "Split"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1433, 10)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(126, 39)
        Me.Button3.TabIndex = 410
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader21, Me.ColumnHeader22, Me.ColumnHeader23})
        Me.ListView1.Font = New System.Drawing.Font("Consolas", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListView1.Location = New System.Drawing.Point(704, 93)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(489, 574)
        Me.ListView1.TabIndex = 411
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'ColumnHeader21
        '
        Me.ColumnHeader21.Text = "No"
        Me.ColumnHeader21.Width = 30
        '
        'ColumnHeader22
        '
        Me.ColumnHeader22.Width = 300
        '
        'ColumnHeader23
        '
        Me.ColumnHeader23.Text = "No"
        Me.ColumnHeader23.Width = 300
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(1580, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 24)
        Me.Label1.TabIndex = 413
        Me.Label1.Text = "Español"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(1402, 54)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(103, 36)
        Me.Button4.TabIndex = 414
        Me.Button4.Text = "Split"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'cmdBuscar
        '
        Me.cmdBuscar.Location = New System.Drawing.Point(127, 8)
        Me.cmdBuscar.Name = "cmdBuscar"
        Me.cmdBuscar.Size = New System.Drawing.Size(145, 42)
        Me.cmdBuscar.TabIndex = 415
        Me.cmdBuscar.Text = "Buscar"
        Me.cmdBuscar.UseVisualStyleBackColor = True
        '
        'cmdTextoSplit
        '
        Me.cmdTextoSplit.Location = New System.Drawing.Point(704, 45)
        Me.cmdTextoSplit.Name = "cmdTextoSplit"
        Me.cmdTextoSplit.Size = New System.Drawing.Size(148, 42)
        Me.cmdTextoSplit.TabIndex = 416
        Me.cmdTextoSplit.Text = "Split"
        Me.cmdTextoSplit.UseVisualStyleBackColor = True
        '
        'frmTraducciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1835, 707)
        Me.Controls.Add(Me.cmdTextoSplit)
        Me.Controls.Add(Me.cmdBuscar)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTraduccion)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.dgvOraciones)
        Me.Controls.Add(Me.cmdExportarWord)
        Me.Name = "frmTraducciones"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmTraducciones"
        CType(Me.dgvOraciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdExportarWord As System.Windows.Forms.Button
    Friend WithEvents dgvOraciones As System.Windows.Forms.DataGridView
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTraduccion As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents cmdBuscar As System.Windows.Forms.Button
    Friend WithEvents cmdTextoSplit As System.Windows.Forms.Button
End Class
