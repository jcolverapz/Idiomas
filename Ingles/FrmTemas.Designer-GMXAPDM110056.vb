<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTemas
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmTemas))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboTipos = New System.Windows.Forms.ComboBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtfrec = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.CmdCerrar = New System.Windows.Forms.Button()
        Me.ConceptosTableAdapter1 = New WindowsApplication1.InglesDataSetTableAdapters.ConceptosTableAdapter()
        Me.Consulta2TableAdapter = New WindowsApplication1.Consulta2TableAdapters.Consulta2TableAdapter()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboGrupos = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.CmdAbrir = New System.Windows.Forms.Button()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Consulta2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Consulta2 = New WindowsApplication1.Consulta2()
        Me.DataSet2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet2 = New WindowsApplication1.DataSet2()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Consulta2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Consulta2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet2BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataSet2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(318, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(109, 40)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Muestra Todo"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 62)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 24)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Grupos_Temas"
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(707, 38)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 41)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(448, 49)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "categoria"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(448, 62)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Descripcion"
        '
        'cboTipos
        '
        Me.cboTipos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTipos.FormattingEnabled = True
        Me.cboTipos.Location = New System.Drawing.Point(12, 89)
        Me.cboTipos.Name = "cboTipos"
        Me.cboTipos.Size = New System.Drawing.Size(403, 28)
        Me.cboTipos.TabIndex = 18
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(519, 59)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(158, 20)
        Me.txtDescripcion.TabIndex = 17
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(793, 35)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 41)
        Me.Button3.TabIndex = 28
        Me.Button3.Text = "Actualizar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(296, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Buscar"
        '
        'txtfrec
        '
        Me.txtfrec.Location = New System.Drawing.Point(517, 82)
        Me.txtfrec.Name = "txtfrec"
        Me.txtfrec.Size = New System.Drawing.Size(52, 20)
        Me.txtfrec.TabIndex = 29
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New System.Drawing.Point(509, 115)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(413, 41)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 32
        Me.PictureBox1.TabStop = False
        '
        'CmdCerrar
        '
        Me.CmdCerrar.Location = New System.Drawing.Point(12, 12)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(105, 41)
        Me.CmdCerrar.TabIndex = 33
        Me.CmdCerrar.Text = "Cerrar"
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'ConceptosTableAdapter1
        '
        Me.ConceptosTableAdapter1.ClearBeforeFill = True
        '
        'Consulta2TableAdapter
        '
        Me.Consulta2TableAdapter.ClearBeforeFill = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(8, 186)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 24)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "Temas"
        '
        'cboGrupos
        '
        Me.cboGrupos.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrupos.FormattingEnabled = True
        Me.cboGrupos.Location = New System.Drawing.Point(12, 147)
        Me.cboGrupos.Name = "cboGrupos"
        Me.cboGrupos.Size = New System.Drawing.Size(403, 28)
        Me.cboGrupos.TabIndex = 37
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 120)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 24)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Grupos"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(850, 160)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(99, 42)
        Me.Button2.TabIndex = 39
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'CmdAbrir
        '
        Me.CmdAbrir.Location = New System.Drawing.Point(112, 185)
        Me.CmdAbrir.Name = "CmdAbrir"
        Me.CmdAbrir.Size = New System.Drawing.Size(98, 32)
        Me.CmdAbrir.TabIndex = 41
        Me.CmdAbrir.Text = "Abrir"
        Me.CmdAbrir.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(342, 197)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(147, 20)
        Me.txtBuscar.TabIndex = 42
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(548, 179)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(138, 33)
        Me.Button4.TabIndex = 43
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'TreeView1
        '
        Me.TreeView1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.Location = New System.Drawing.Point(16, 237)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(495, 352)
        Me.TreeView1.TabIndex = 44
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(715, 172)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(105, 37)
        Me.Button5.TabIndex = 45
        Me.Button5.Text = "Button5"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(974, 159)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 57)
        Me.Button6.TabIndex = 46
        Me.Button6.Text = "Button6"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "pass3.ico")
        Me.ImageList1.Images.SetKeyName(1, "salir2.ico")
        Me.ImageList1.Images.SetKeyName(2, "abrir.ico")
        '
        'Consulta2BindingSource
        '
        Me.Consulta2BindingSource.DataMember = "Consulta2"
        Me.Consulta2BindingSource.DataSource = Me.Consulta2
        '
        'Consulta2
        '
        Me.Consulta2.DataSetName = "Consulta2"
        Me.Consulta2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'DataSet2BindingSource
        '
        Me.DataSet2BindingSource.DataSource = Me.DataSet2
        Me.DataSet2BindingSource.Position = 0
        '
        'DataSet2
        '
        Me.DataSet2.DataSetName = "DataSet2"
        Me.DataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'FrmTemas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1134, 800)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.CmdAbrir)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboGrupos)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CmdCerrar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtfrec)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboTipos)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "FrmTemas"
        Me.Text = "Form2"
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Consulta2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Consulta2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet2BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataSet2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboTipos As System.Windows.Forms.ComboBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtfrec As System.Windows.Forms.TextBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents CmdCerrar As System.Windows.Forms.Button
    Friend WithEvents ConceptosTableAdapter1 As WindowsApplication1.InglesDataSetTableAdapters.ConceptosTableAdapter
    Friend WithEvents DataSet2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSet2 As WindowsApplication1.DataSet2
    Friend WithEvents Consulta2 As WindowsApplication1.Consulta2
    Friend WithEvents Consulta2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Consulta2TableAdapter As WindowsApplication1.Consulta2TableAdapters.Consulta2TableAdapter
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboGrupos As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents CmdAbrir As System.Windows.Forms.Button
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
End Class
