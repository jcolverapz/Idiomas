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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboTipos = New System.Windows.Forms.ComboBox()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtOrden = New System.Windows.Forms.TextBox()
        Me.CmdCerrar = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cboGrupos = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CmdAbrir = New System.Windows.Forms.Button()
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Porcentaje = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNivel = New System.Windows.Forms.TextBox()
        Me.txtId = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.CmdNuevoTema = New System.Windows.Forms.Button()
        Me.txtSubtema = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.optSubtema = New System.Windows.Forms.RadioButton()
        Me.optId = New System.Windows.Forms.RadioButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.optContract = New System.Windows.Forms.RadioButton()
        Me.optExpand = New System.Windows.Forms.RadioButton()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.optSubtemaNodo = New System.Windows.Forms.RadioButton()
        Me.optIdNodo = New System.Windows.Forms.RadioButton()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lblNode = New System.Windows.Forms.Label()
        Me.CmdNode = New System.Windows.Forms.Button()
        Me.txtBuscarTree = New System.Windows.Forms.TextBox()
        Me.CmdNivel = New System.Windows.Forms.Button()
        Me.txtDuracion = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboAvance = New System.Windows.Forms.ComboBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.cmdDetalle = New System.Windows.Forms.Button()
        Me.cmdConversacion = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.ConceptosTableAdapter1 = New Ingles.InglesDataSetTableAdapters.ConceptosTableAdapter()
        Me.Consulta2TableAdapter = New Ingles.Consulta2TableAdapters.Consulta2TableAdapter()
        Me.Consulta2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Consulta2 = New Ingles.Consulta2()
        Me.DataSet2BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataSet2 = New Ingles.DataSet2()
        Me.DataGridViewProgressColumn1 = New Ingles.Sample.DataGridViewProgressColumn()
        Me.cmdConversaciones = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
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
        Me.Label1.Size = New System.Drawing.Size(68, 24)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Canal"
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(707, 12)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 41)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(459, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(36, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Orden"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(459, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Grupo"
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
        Me.txtDescripcion.Location = New System.Drawing.Point(530, 25)
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(158, 20)
        Me.txtDescripcion.TabIndex = 17
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(793, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(80, 41)
        Me.Button3.TabIndex = 28
        Me.Button3.Text = "Actualizar"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(318, 217)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Buscar"
        '
        'txtOrden
        '
        Me.txtOrden.Location = New System.Drawing.Point(528, 50)
        Me.txtOrden.Name = "txtOrden"
        Me.txtOrden.Size = New System.Drawing.Size(52, 20)
        Me.txtOrden.TabIndex = 29
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("MS Reference Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 210)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(117, 24)
        Me.Label5.TabIndex = 36
        Me.Label5.Text = "SubTemas"
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
        'CmdAbrir
        '
        Me.CmdAbrir.Location = New System.Drawing.Point(214, 202)
        Me.CmdAbrir.Name = "CmdAbrir"
        Me.CmdAbrir.Size = New System.Drawing.Size(98, 32)
        Me.CmdAbrir.TabIndex = 41
        Me.CmdAbrir.Text = "Abrir"
        Me.CmdAbrir.UseVisualStyleBackColor = True
        '
        'txtBuscar
        '
        Me.txtBuscar.Location = New System.Drawing.Point(364, 214)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(147, 20)
        Me.txtBuscar.TabIndex = 42
        '
        'TreeView1
        '
        Me.TreeView1.AllowDrop = True
        Me.TreeView1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.Location = New System.Drawing.Point(1091, 47)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New System.Drawing.Size(779, 922)
        Me.TreeView1.TabIndex = 44
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(237, 12)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 40)
        Me.Button6.TabIndex = 46
        Me.Button6.Text = "Cargar Arbol"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "-slow-motion-video_90036.png")
        Me.ImageList1.Images.SetKeyName(1, "salir2.ico")
        Me.ImageList1.Images.SetKeyName(2, "abrir.ico")
        Me.ImageList1.Images.SetKeyName(3, "datos.ico")
        '
        'ProgressBar1
        '
        Me.ProgressBar1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 181)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(403, 18)
        Me.ProgressBar1.TabIndex = 48
        '
        'Porcentaje
        '
        Me.Porcentaje.AutoSize = True
        Me.Porcentaje.Location = New System.Drawing.Point(421, 182)
        Me.Porcentaje.Name = "Porcentaje"
        Me.Porcentaje.Size = New System.Drawing.Size(39, 13)
        Me.Porcentaje.TabIndex = 49
        Me.Porcentaje.Text = "Label7"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(459, 75)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 51
        Me.Label7.Text = "Nivel"
        '
        'txtNivel
        '
        Me.txtNivel.Location = New System.Drawing.Point(530, 72)
        Me.txtNivel.Name = "txtNivel"
        Me.txtNivel.Size = New System.Drawing.Size(52, 20)
        Me.txtNivel.TabIndex = 53
        '
        'txtId
        '
        Me.txtId.Location = New System.Drawing.Point(528, 2)
        Me.txtId.Name = "txtId"
        Me.txtId.Size = New System.Drawing.Size(52, 20)
        Me.txtId.TabIndex = 55
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(459, 5)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(18, 13)
        Me.Label8.TabIndex = 54
        Me.Label8.Text = "ID"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(0, Byte), Integer))
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DataGridView1.Location = New System.Drawing.Point(12, 240)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(1073, 705)
        Me.DataGridView1.TabIndex = 56
        '
        'CmdNuevoTema
        '
        Me.CmdNuevoTema.Location = New System.Drawing.Point(123, 12)
        Me.CmdNuevoTema.Name = "CmdNuevoTema"
        Me.CmdNuevoTema.Size = New System.Drawing.Size(80, 41)
        Me.CmdNuevoTema.TabIndex = 57
        Me.CmdNuevoTema.Text = "Nuevo Tema"
        Me.CmdNuevoTema.UseVisualStyleBackColor = True
        '
        'txtSubtema
        '
        Me.txtSubtema.Location = New System.Drawing.Point(462, 147)
        Me.txtSubtema.Name = "txtSubtema"
        Me.txtSubtema.Size = New System.Drawing.Size(325, 20)
        Me.txtSubtema.TabIndex = 58
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(464, 131)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 13)
        Me.Label9.TabIndex = 59
        Me.Label9.Text = "Subtema"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.optSubtema)
        Me.Panel1.Controls.Add(Me.optId)
        Me.Panel1.Location = New System.Drawing.Point(876, 167)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(209, 67)
        Me.Panel1.TabIndex = 70
        '
        'optSubtema
        '
        Me.optSubtema.AutoSize = True
        Me.optSubtema.Location = New System.Drawing.Point(12, 40)
        Me.optSubtema.Name = "optSubtema"
        Me.optSubtema.Size = New System.Drawing.Size(104, 17)
        Me.optSubtema.TabIndex = 67
        Me.optSubtema.Text = "Sort By Subtema"
        Me.optSubtema.UseVisualStyleBackColor = True
        '
        'optId
        '
        Me.optId.AutoSize = True
        Me.optId.Checked = True
        Me.optId.Location = New System.Drawing.Point(12, 13)
        Me.optId.Name = "optId"
        Me.optId.Size = New System.Drawing.Size(71, 17)
        Me.optId.TabIndex = 66
        Me.optId.TabStop = True
        Me.optId.Text = "Sort By Id"
        Me.optId.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.optContract)
        Me.Panel2.Controls.Add(Me.optExpand)
        Me.Panel2.Location = New System.Drawing.Point(1101, 6)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(220, 35)
        Me.Panel2.TabIndex = 71
        '
        'optContract
        '
        Me.optContract.AutoSize = True
        Me.optContract.Location = New System.Drawing.Point(121, 11)
        Me.optContract.Name = "optContract"
        Me.optContract.Size = New System.Drawing.Size(65, 17)
        Me.optContract.TabIndex = 71
        Me.optContract.Text = "Contract"
        Me.optContract.UseVisualStyleBackColor = True
        '
        'optExpand
        '
        Me.optExpand.AutoSize = True
        Me.optExpand.Checked = True
        Me.optExpand.Location = New System.Drawing.Point(33, 11)
        Me.optExpand.Name = "optExpand"
        Me.optExpand.Size = New System.Drawing.Size(61, 17)
        Me.optExpand.TabIndex = 70
        Me.optExpand.TabStop = True
        Me.optExpand.Text = "Expand"
        Me.optExpand.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.optSubtemaNodo)
        Me.Panel3.Controls.Add(Me.optIdNodo)
        Me.Panel3.Location = New System.Drawing.Point(1527, 2)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(217, 27)
        Me.Panel3.TabIndex = 76
        '
        'optSubtemaNodo
        '
        Me.optSubtemaNodo.AutoSize = True
        Me.optSubtemaNodo.Location = New System.Drawing.Point(108, 6)
        Me.optSubtemaNodo.Name = "optSubtemaNodo"
        Me.optSubtemaNodo.Size = New System.Drawing.Size(104, 17)
        Me.optSubtemaNodo.TabIndex = 77
        Me.optSubtemaNodo.Text = "Sort By Subtema"
        Me.optSubtemaNodo.UseVisualStyleBackColor = True
        '
        'optIdNodo
        '
        Me.optIdNodo.AutoSize = True
        Me.optIdNodo.Checked = True
        Me.optIdNodo.Location = New System.Drawing.Point(5, 6)
        Me.optIdNodo.Name = "optIdNodo"
        Me.optIdNodo.Size = New System.Drawing.Size(88, 17)
        Me.optIdNodo.TabIndex = 76
        Me.optIdNodo.TabStop = True
        Me.optIdNodo.Text = "Sort By Nodo"
        Me.optIdNodo.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1005, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(80, 41)
        Me.Button2.TabIndex = 77
        Me.Button2.Text = "Actualizar"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(1333, 5)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(41, 13)
        Me.Label10.TabIndex = 78
        Me.Label10.Text = "Current"
        '
        'lblNode
        '
        Me.lblNode.AutoSize = True
        Me.lblNode.Location = New System.Drawing.Point(1335, 30)
        Me.lblNode.Name = "lblNode"
        Me.lblNode.Size = New System.Drawing.Size(19, 13)
        Me.lblNode.TabIndex = 79
        Me.lblNode.Text = "_n"
        '
        'CmdNode
        '
        Me.CmdNode.Location = New System.Drawing.Point(1380, 2)
        Me.CmdNode.Name = "CmdNode"
        Me.CmdNode.Size = New System.Drawing.Size(80, 29)
        Me.CmdNode.TabIndex = 80
        Me.CmdNode.Text = "Expand Node"
        Me.CmdNode.UseVisualStyleBackColor = True
        '
        'txtBuscarTree
        '
        Me.txtBuscarTree.Location = New System.Drawing.Point(1005, 62)
        Me.txtBuscarTree.Name = "txtBuscarTree"
        Me.txtBuscarTree.Size = New System.Drawing.Size(80, 20)
        Me.txtBuscarTree.TabIndex = 81
        '
        'CmdNivel
        '
        Me.CmdNivel.Location = New System.Drawing.Point(1783, 9)
        Me.CmdNivel.Name = "CmdNivel"
        Me.CmdNivel.Size = New System.Drawing.Size(80, 35)
        Me.CmdNivel.TabIndex = 82
        Me.CmdNivel.Text = "CmdNivel"
        Me.CmdNivel.UseVisualStyleBackColor = True
        '
        'txtDuracion
        '
        Me.txtDuracion.Location = New System.Drawing.Point(793, 147)
        Me.txtDuracion.Name = "txtDuracion"
        Me.txtDuracion.Size = New System.Drawing.Size(77, 20)
        Me.txtDuracion.TabIndex = 83
        Me.txtDuracion.Text = "0"
        Me.txtDuracion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(790, 129)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(50, 13)
        Me.Label11.TabIndex = 84
        Me.Label11.Text = "Duracion"
        '
        'cboAvance
        '
        Me.cboAvance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAvance.FormattingEnabled = True
        Me.cboAvance.Items.AddRange(New Object() {"0<50%", "50<99%", "100%"})
        Me.cboAvance.Location = New System.Drawing.Point(629, 210)
        Me.cboAvance.Name = "cboAvance"
        Me.cboAvance.Size = New System.Drawing.Size(107, 21)
        Me.cboAvance.TabIndex = 85
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(323, 58)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(104, 21)
        Me.Button4.TabIndex = 86
        Me.Button4.Text = "todo"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'cmdDetalle
        '
        Me.cmdDetalle.Location = New System.Drawing.Point(772, 202)
        Me.cmdDetalle.Name = "cmdDetalle"
        Me.cmdDetalle.Size = New System.Drawing.Size(98, 32)
        Me.cmdDetalle.TabIndex = 87
        Me.cmdDetalle.Text = "Detalle"
        Me.cmdDetalle.UseVisualStyleBackColor = True
        '
        'cmdConversacion
        '
        Me.cmdConversacion.Location = New System.Drawing.Point(888, 11)
        Me.cmdConversacion.Name = "cmdConversacion"
        Me.cmdConversacion.Size = New System.Drawing.Size(80, 41)
        Me.cmdConversacion.TabIndex = 88
        Me.cmdConversacion.Text = "INSERT Id Conversation"
        Me.cmdConversacion.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(142, 205)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(58, 24)
        Me.Button5.TabIndex = 89
        Me.Button5.Text = "Button5"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'ConceptosTableAdapter1
        '
        Me.ConceptosTableAdapter1.ClearBeforeFill = True
        '
        'Consulta2TableAdapter
        '
        Me.Consulta2TableAdapter.ClearBeforeFill = True
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
        'DataGridViewProgressColumn1
        '
        Me.DataGridViewProgressColumn1.HeaderText = "Cuenta"
        Me.DataGridViewProgressColumn1.Name = "DataGridViewProgressColumn1"
        Me.DataGridViewProgressColumn1.ProgressBarColor = System.Drawing.Color.White
        '
        'cmdConversaciones
        '
        Me.cmdConversaciones.Location = New System.Drawing.Point(707, 61)
        Me.cmdConversaciones.Name = "cmdConversaciones"
        Me.cmdConversaciones.Size = New System.Drawing.Size(95, 41)
        Me.cmdConversaciones.TabIndex = 90
        Me.cmdConversaciones.Text = "Conversaciones"
        Me.cmdConversaciones.UseVisualStyleBackColor = True
        '
        'FrmTemas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1875, 981)
        Me.Controls.Add(Me.cmdConversaciones)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.cmdConversacion)
        Me.Controls.Add(Me.cmdDetalle)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.cboAvance)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtDuracion)
        Me.Controls.Add(Me.CmdNivel)
        Me.Controls.Add(Me.txtBuscarTree)
        Me.Controls.Add(Me.CmdNode)
        Me.Controls.Add(Me.lblNode)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtSubtema)
        Me.Controls.Add(Me.CmdNuevoTema)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.txtId)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtNivel)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Porcentaje)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.CmdAbrir)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cboGrupos)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.CmdCerrar)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtOrden)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboTipos)
        Me.Controls.Add(Me.txtDescripcion)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Button1)
        Me.Name = "FrmTemas"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Form2"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
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
    Friend WithEvents txtOrden As System.Windows.Forms.TextBox
    Friend WithEvents CmdCerrar As System.Windows.Forms.Button
    Friend WithEvents ConceptosTableAdapter1 As Ingles.InglesDataSetTableAdapters.ConceptosTableAdapter
    Friend WithEvents DataSet2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DataSet2 As Ingles.DataSet2
    Friend WithEvents Consulta2 As Ingles.Consulta2
    Friend WithEvents Consulta2BindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Consulta2TableAdapter As Ingles.Consulta2TableAdapters.Consulta2TableAdapter
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cboGrupos As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CmdAbrir As System.Windows.Forms.Button
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents Porcentaje As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtNivel As System.Windows.Forms.TextBox
    Friend WithEvents txtId As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewProgressColumn1 As Ingles.Sample.DataGridViewProgressColumn
    Friend WithEvents CmdNuevoTema As System.Windows.Forms.Button
    Friend WithEvents txtSubtema As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents optSubtema As System.Windows.Forms.RadioButton
    Friend WithEvents optId As System.Windows.Forms.RadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents optContract As System.Windows.Forms.RadioButton
    Friend WithEvents optExpand As System.Windows.Forms.RadioButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents optSubtemaNodo As System.Windows.Forms.RadioButton
    Friend WithEvents optIdNodo As System.Windows.Forms.RadioButton
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents lblNode As System.Windows.Forms.Label
    Friend WithEvents CmdNode As System.Windows.Forms.Button
    Friend WithEvents txtBuscarTree As System.Windows.Forms.TextBox
    Friend WithEvents CmdNivel As System.Windows.Forms.Button
    Friend WithEvents txtDuracion As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboAvance As System.Windows.Forms.ComboBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents cmdDetalle As System.Windows.Forms.Button
    Friend WithEvents cmdConversacion As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents cmdConversaciones As System.Windows.Forms.Button
End Class
