<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTextoToDgv
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
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtTraduccion = New System.Windows.Forms.TextBox()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(),System.Windows.Forms.ColumnHeader)
        Me.txtTexto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dgvGeneral = New System.Windows.Forms.DataGridView()
        Me.cmdSplit = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.cmdExportar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtDetId = New System.Windows.Forms.TextBox()
        Me.cmdOrdenar = New System.Windows.Forms.Button()
        Me.lbltitulo = New System.Windows.Forms.Label()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.pbar = New System.Windows.Forms.ProgressBar()
        Me.Panel3.SuspendLayout
        Me.Panel2.SuspendLayout
        CType(Me.dgvGeneral,System.ComponentModel.ISupportInitialize).BeginInit
        Me.Panel1.SuspendLayout
        Me.SuspendLayout
        '
        'cboGrupo
        '
        Me.cboGrupo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cboGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.cboGrupo.FormattingEnabled = true
        Me.cboGrupo.Location = New System.Drawing.Point(215, 27)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(262, 28)
        Me.cboGrupo.TabIndex = 399
        '
        'Panel3
        '
        Me.Panel3.AutoScroll = true
        Me.Panel3.Controls.Add(Me.pbar)
        Me.Panel3.Controls.Add(Me.Label5)
        Me.Panel3.Controls.Add(Me.Label4)
        Me.Panel3.Controls.Add(Me.txtTraduccion)
        Me.Panel3.Controls.Add(Me.ListView1)
        Me.Panel3.Controls.Add(Me.txtTexto)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel3.Location = New System.Drawing.Point(0, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1004, 740)
        Me.Panel3.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = true
        Me.Label5.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label5.Location = New System.Drawing.Point(674, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 24)
        Me.Label5.TabIndex = 406
        Me.Label5.Text = "Español"
        '
        'Label4
        '
        Me.Label4.AutoSize = true
        Me.Label4.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label4.Location = New System.Drawing.Point(183, 3)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 24)
        Me.Label4.TabIndex = 405
        Me.Label4.Text = "Ingles"
        '
        'txtTraduccion
        '
        Me.txtTraduccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTraduccion.Font = New System.Drawing.Font("Consolas", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtTraduccion.Location = New System.Drawing.Point(515, 27)
        Me.txtTraduccion.Multiline = true
        Me.txtTraduccion.Name = "txtTraduccion"
        Me.txtTraduccion.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTraduccion.Size = New System.Drawing.Size(473, 429)
        Me.txtTraduccion.TabIndex = 102
        '
        'ListView1
        '
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.ListView1.Font = New System.Drawing.Font("Arial Black", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.ListView1.Location = New System.Drawing.Point(12, 462)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(473, 253)
        Me.ListView1.TabIndex = 101
        Me.ListView1.UseCompatibleStateImageBehavior = false
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Width = 50
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 100
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Width = 300
        '
        'txtTexto
        '
        Me.txtTexto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtTexto.Font = New System.Drawing.Font("Consolas", 12!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.txtTexto.Location = New System.Drawing.Point(12, 27)
        Me.txtTexto.Multiline = true
        Me.txtTexto.Name = "txtTexto"
        Me.txtTexto.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtTexto.Size = New System.Drawing.Size(473, 429)
        Me.txtTexto.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = true
        Me.Label3.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label3.Location = New System.Drawing.Point(135, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 24)
        Me.Label3.TabIndex = 398
        Me.Label3.Text = "Grupo"
        '
        'Label2
        '
        Me.Label2.AutoSize = true
        Me.Label2.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label2.Location = New System.Drawing.Point(1140, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 17)
        Me.Label2.TabIndex = 401
        Me.Label2.Text = "Descripcion"
        '
        'TextBox1
        '
        Me.TextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255,Byte),Integer), CType(CType(255,Byte),Integer), CType(CType(192,Byte),Integer))
        Me.TextBox1.Location = New System.Drawing.Point(483, 32)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(234, 20)
        Me.TextBox1.TabIndex = 400
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(723, 32)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(47, 20)
        Me.txtId.TabIndex = 399
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(1143, 28)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(190, 20)
        Me.txtDescripcion.TabIndex = 398
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dgvGeneral)
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 58)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1554, 740)
        Me.Panel2.TabIndex = 399
        '
        'dgvGeneral
        '
        Me.dgvGeneral.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Consolas", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvGeneral.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvGeneral.Location = New System.Drawing.Point(1010, 6)
        Me.dgvGeneral.Name = "dgvGeneral"
        Me.dgvGeneral.Size = New System.Drawing.Size(532, 722)
        Me.dgvGeneral.TabIndex = 2
        '
        'cmdSplit
        '
        Me.cmdSplit.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdSplit.Location = New System.Drawing.Point(827, 11)
        Me.cmdSplit.Name = "cmdSplit"
        Me.cmdSplit.Size = New System.Drawing.Size(66, 36)
        Me.cmdSplit.TabIndex = 396
        Me.cmdSplit.Text = "Split"
        Me.cmdSplit.UseVisualStyleBackColor = true
        '
        'Label1
        '
        Me.Label1.AutoSize = true
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label1.Location = New System.Drawing.Point(489, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(140, 22)
        Me.Label1.TabIndex = 396
        Me.Label1.Text = "Conversacion"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.cmdExportar)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.txtDetId)
        Me.Panel1.Controls.Add(Me.cmdOrdenar)
        Me.Panel1.Controls.Add(Me.cboGrupo)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.txtId)
        Me.Panel1.Controls.Add(Me.txtDescripcion)
        Me.Panel1.Controls.Add(Me.cmdSplit)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.lbltitulo)
        Me.Panel1.Controls.Add(Me.Button9)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1554, 58)
        Me.Panel1.TabIndex = 398
        '
        'cmdExportar
        '
        Me.cmdExportar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdExportar.Location = New System.Drawing.Point(899, 11)
        Me.cmdExportar.Name = "cmdExportar"
        Me.cmdExportar.Size = New System.Drawing.Size(66, 36)
        Me.cmdExportar.TabIndex = 405
        Me.cmdExportar.Text = "Exportar"
        Me.cmdExportar.UseVisualStyleBackColor = true
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(1358, 9)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(103, 42)
        Me.Button1.TabIndex = 404
        Me.Button1.Text = "Update Orden"
        Me.Button1.UseVisualStyleBackColor = true
        '
        'txtDetId
        '
        Me.txtDetId.Location = New System.Drawing.Point(1090, 28)
        Me.txtDetId.Name = "txtDetId"
        Me.txtDetId.Size = New System.Drawing.Size(47, 20)
        Me.txtDetId.TabIndex = 403
        '
        'cmdOrdenar
        '
        Me.cmdOrdenar.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdOrdenar.Location = New System.Drawing.Point(1010, 11)
        Me.cmdOrdenar.Name = "cmdOrdenar"
        Me.cmdOrdenar.Size = New System.Drawing.Size(66, 36)
        Me.cmdOrdenar.TabIndex = 402
        Me.cmdOrdenar.Text = "Ordenar"
        Me.cmdOrdenar.UseVisualStyleBackColor = true
        '
        'lbltitulo
        '
        Me.lbltitulo.AutoSize = true
        Me.lbltitulo.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.lbltitulo.Location = New System.Drawing.Point(183, 4)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(195, 22)
        Me.lbltitulo.TabIndex = 396
        Me.lbltitulo.Text = "Copy and Pase Text"
        '
        'Button9
        '
        Me.Button9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button9.Location = New System.Drawing.Point(12, 11)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(66, 36)
        Me.Button9.TabIndex = 395
        Me.Button9.Text = "Exit"
        Me.Button9.UseVisualStyleBackColor = true
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(773, 10)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(54, 40)
        Me.Button2.TabIndex = 406
        Me.Button2.Text = "Grupo y dialogos"
        Me.Button2.UseVisualStyleBackColor = true
        '
        'pbar
        '
        Me.pbar.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pbar.Location = New System.Drawing.Point(0, 726)
        Me.pbar.Name = "pbar"
        Me.pbar.Size = New System.Drawing.Size(1004, 14)
        Me.pbar.TabIndex = 407
        '
        'frmTextoToDgv
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1554, 798)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmTextoToDgv"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmTextoToDgv"
        Me.Panel3.ResumeLayout(false)
        Me.Panel3.PerformLayout
        Me.Panel2.ResumeLayout(false)
        CType(Me.dgvGeneral,System.ComponentModel.ISupportInitialize).EndInit
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents txtTexto As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents cmdSplit As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lbltitulo As System.Windows.Forms.Label
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents cmdOrdenar As System.Windows.Forms.Button
    Friend WithEvents dgvGeneral As System.Windows.Forms.DataGridView
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtDetId As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtTraduccion As System.Windows.Forms.TextBox
    Friend WithEvents cmdExportar As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents pbar As System.Windows.Forms.ProgressBar
End Class
