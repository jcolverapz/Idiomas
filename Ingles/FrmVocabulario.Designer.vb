<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmVocabulario
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.cboGrupoTema = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.CmdCerrar = New System.Windows.Forms.Button()
        Me.dgvTipos = New System.Windows.Forms.DataGridView()
        Me.dgvConceptos = New System.Windows.Forms.DataGridView()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtCant = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboTipos = New System.Windows.Forms.ComboBox()
        Me.chkTransparente = New System.Windows.Forms.CheckBox()
        Me.txtbuscar = New System.Windows.Forms.TextBox()
        Me.chkContentWord = New System.Windows.Forms.CheckBox()
        Me.chkUsadas = New System.Windows.Forms.CheckBox()
        Me.cmdAprendidas = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.dgvTipos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvConceptos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboGrupoTema
        '
        Me.cboGrupoTema.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrupoTema.FormattingEnabled = True
        Me.cboGrupoTema.Location = New System.Drawing.Point(98, 67)
        Me.cboGrupoTema.Name = "cboGrupoTema"
        Me.cboGrupoTema.Size = New System.Drawing.Size(248, 26)
        Me.cboGrupoTema.TabIndex = 21
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(162, -35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 24)
        Me.Label1.TabIndex = 20
        Me.Label1.Text = "Temas"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(534, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 18)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Vocabulario"
        '
        'CmdCerrar
        '
        Me.CmdCerrar.Location = New System.Drawing.Point(12, 12)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(105, 41)
        Me.CmdCerrar.TabIndex = 34
        Me.CmdCerrar.Text = "Cerrar"
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'dgvTipos
        '
        Me.dgvTipos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvTipos.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvTipos.Location = New System.Drawing.Point(999, 12)
        Me.dgvTipos.Name = "dgvTipos"
        Me.dgvTipos.Size = New System.Drawing.Size(265, 108)
        Me.dgvTipos.TabIndex = 35
        '
        'dgvConceptos
        '
        Me.dgvConceptos.AllowUserToAddRows = False
        Me.dgvConceptos.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConceptos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(225, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvConceptos.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvConceptos.Location = New System.Drawing.Point(1, 131)
        Me.dgvConceptos.MultiSelect = False
        Me.dgvConceptos.Name = "dgvConceptos"
        Me.dgvConceptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvConceptos.Size = New System.Drawing.Size(1435, 666)
        Me.dgvConceptos.TabIndex = 36
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(939, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 18)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Tipos"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(848, 95)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 24)
        Me.Label5.TabIndex = 45
        Me.Label5.Text = "Cant"
        '
        'txtCant
        '
        Me.txtCant.Font = New System.Drawing.Font("Consolas", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCant.Location = New System.Drawing.Point(920, 95)
        Me.txtCant.Name = "txtCant"
        Me.txtCant.Size = New System.Drawing.Size(64, 25)
        Me.txtCant.TabIndex = 44
        Me.txtCant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(123, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(105, 41)
        Me.Button1.TabIndex = 46
        Me.Button1.Text = "New"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 70)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(50, 18)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Grupo"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(493, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(37, 18)
        Me.Label7.TabIndex = 48
        Me.Label7.Text = "Tipo"
        '
        'cboTipos
        '
        Me.cboTipos.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipos.FormattingEnabled = True
        Me.cboTipos.Items.AddRange(New Object() {"Mas Usadas"})
        Me.cboTipos.Location = New System.Drawing.Point(537, 61)
        Me.cboTipos.Name = "cboTipos"
        Me.cboTipos.Size = New System.Drawing.Size(248, 24)
        Me.cboTipos.TabIndex = 47
        '
        'chkTransparente
        '
        Me.chkTransparente.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkTransparente.AutoSize = True
        Me.chkTransparente.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkTransparente.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkTransparente.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkTransparente.Location = New System.Drawing.Point(532, 104)
        Me.chkTransparente.Name = "chkTransparente"
        Me.chkTransparente.Size = New System.Drawing.Size(102, 23)
        Me.chkTransparente.TabIndex = 49
        Me.chkTransparente.Text = "No Transparentes"
        Me.chkTransparente.UseVisualStyleBackColor = False
        '
        'txtbuscar
        '
        Me.txtbuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtbuscar.Font = New System.Drawing.Font("Cooper Black", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtbuscar.Location = New System.Drawing.Point(98, 98)
        Me.txtbuscar.Name = "txtbuscar"
        Me.txtbuscar.Size = New System.Drawing.Size(222, 32)
        Me.txtbuscar.TabIndex = 44
        Me.txtbuscar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'chkContentWord
        '
        Me.chkContentWord.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkContentWord.AutoSize = True
        Me.chkContentWord.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkContentWord.Checked = True
        Me.chkContentWord.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkContentWord.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkContentWord.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White
        Me.chkContentWord.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White
        Me.chkContentWord.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkContentWord.Location = New System.Drawing.Point(426, 104)
        Me.chkContentWord.Name = "chkContentWord"
        Me.chkContentWord.Size = New System.Drawing.Size(100, 23)
        Me.chkContentWord.TabIndex = 50
        Me.chkContentWord.Text = "No Content Word"
        Me.chkContentWord.UseVisualStyleBackColor = False
        '
        'chkUsadas
        '
        Me.chkUsadas.Appearance = System.Windows.Forms.Appearance.Button
        Me.chkUsadas.AutoSize = True
        Me.chkUsadas.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkUsadas.FlatAppearance.CheckedBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.chkUsadas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.chkUsadas.Location = New System.Drawing.Point(326, 104)
        Me.chkUsadas.Name = "chkUsadas"
        Me.chkUsadas.Size = New System.Drawing.Size(76, 23)
        Me.chkUsadas.TabIndex = 51
        Me.chkUsadas.Text = "Mas Usadas"
        Me.chkUsadas.UseVisualStyleBackColor = False
        '
        'cmdAprendidas
        '
        Me.cmdAprendidas.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.cmdAprendidas.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAprendidas.Location = New System.Drawing.Point(640, 104)
        Me.cmdAprendidas.Name = "cmdAprendidas"
        Me.cmdAprendidas.Size = New System.Drawing.Size(105, 24)
        Me.cmdAprendidas.TabIndex = 52
        Me.cmdAprendidas.Text = "Falta"
        Me.cmdAprendidas.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 101)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 24)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Buscar"
        '
        'FrmVocabulario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1497, 809)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cmdAprendidas)
        Me.Controls.Add(Me.chkUsadas)
        Me.Controls.Add(Me.chkContentWord)
        Me.Controls.Add(Me.chkTransparente)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboTipos)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtbuscar)
        Me.Controls.Add(Me.txtCant)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.dgvConceptos)
        Me.Controls.Add(Me.dgvTipos)
        Me.Controls.Add(Me.CmdCerrar)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboGrupoTema)
        Me.Controls.Add(Me.Label1)
        Me.Name = "FrmVocabulario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "FrmVocabulario"
        CType(Me.dgvTipos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvConceptos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cboGrupoTema As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CmdCerrar As System.Windows.Forms.Button
    Friend WithEvents dgvTipos As System.Windows.Forms.DataGridView
    Friend WithEvents dgvConceptos As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtCant As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboTipos As System.Windows.Forms.ComboBox
    Friend WithEvents chkTransparente As System.Windows.Forms.CheckBox
    Friend WithEvents txtbuscar As System.Windows.Forms.TextBox
    Friend WithEvents chkContentWord As System.Windows.Forms.CheckBox
    Friend WithEvents chkUsadas As System.Windows.Forms.CheckBox
    Friend WithEvents cmdAprendidas As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
