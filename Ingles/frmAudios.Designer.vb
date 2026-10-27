<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAudios
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
        Me.cmdCerrar = New System.Windows.Forms.Button()
        Me.cboTipo = New System.Windows.Forms.ComboBox()
        Me.dgvOraciones = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New Ingles.Sample.DataGridViewProgressColumn()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridViewProgressColumn1 = New Ingles.Sample.DataGridViewProgressColumn()
        CType(Me.dgvOraciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCerrar
        '
        Me.cmdCerrar.Location = New System.Drawing.Point(12, 12)
        Me.cmdCerrar.Name = "cmdCerrar"
        Me.cmdCerrar.Size = New System.Drawing.Size(122, 54)
        Me.cmdCerrar.TabIndex = 0
        Me.cmdCerrar.Text = "Button1"
        Me.cmdCerrar.UseVisualStyleBackColor = True
        '
        'cboTipo
        '
        Me.cboTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipo.FormattingEnabled = True
        Me.cboTipo.Location = New System.Drawing.Point(12, 92)
        Me.cboTipo.Name = "cboTipo"
        Me.cboTipo.Size = New System.Drawing.Size(248, 26)
        Me.cboTipo.TabIndex = 48
        '
        'dgvOraciones
        '
        Me.dgvOraciones.AllowUserToAddRows = False
        Me.dgvOraciones.AllowUserToDeleteRows = False
        Me.dgvOraciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvOraciones.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column5})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvOraciones.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvOraciones.Location = New System.Drawing.Point(12, 124)
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
        Me.dgvOraciones.Size = New System.Drawing.Size(981, 348)
        Me.dgvOraciones.TabIndex = 47
        '
        'Column1
        '
        Me.Column1.DataPropertyName = "Id"
        Me.Column1.HeaderText = "Column1"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        '
        'Column2
        '
        Me.Column2.DataPropertyName = "Descripcion"
        Me.Column2.HeaderText = "Column2"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.DataPropertyName = "Avance"
        Me.Column5.HeaderText = "Avance"
        Me.Column5.Name = "Column5"
        Me.Column5.ProgressBarColor = System.Drawing.Color.Chartreuse
        Me.Column5.ReadOnly = True
        Me.Column5.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column5.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(382, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(127, 13)
        Me.Label1.TabIndex = 399
        Me.Label1.Text = "Audios con Transcripcion"
        '
        'DataGridViewProgressColumn1
        '
        Me.DataGridViewProgressColumn1.DataPropertyName = "Con_avance"
        Me.DataGridViewProgressColumn1.HeaderText = "Avance"
        Me.DataGridViewProgressColumn1.Name = "DataGridViewProgressColumn1"
        Me.DataGridViewProgressColumn1.ProgressBarColor = System.Drawing.Color.Chartreuse
        Me.DataGridViewProgressColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewProgressColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'frmAudios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1101, 684)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboTipo)
        Me.Controls.Add(Me.dgvOraciones)
        Me.Controls.Add(Me.cmdCerrar)
        Me.Name = "frmAudios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmAudios"
        CType(Me.dgvOraciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCerrar As System.Windows.Forms.Button
    Friend WithEvents cboTipo As System.Windows.Forms.ComboBox
    Friend WithEvents dgvOraciones As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As Ingles.Sample.DataGridViewProgressColumn
    Friend WithEvents DataGridViewProgressColumn1 As Ingles.Sample.DataGridViewProgressColumn
End Class
