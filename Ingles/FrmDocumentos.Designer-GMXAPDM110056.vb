<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDocumentos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmDocumentos))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.InglesDataSet = New WindowsApplication1.InglesDataSet()
        Me.SubtemasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SubtemasTableAdapter = New WindowsApplication1.InglesDataSetTableAdapters.SubtemasTableAdapter()
        Me.TableAdapterManager = New WindowsApplication1.InglesDataSetTableAdapters.TableAdapterManager()
        Me.SubtemasBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.SubtemasBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.txtDocumento = New System.Windows.Forms.RichTextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        CType(Me.InglesDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SubtemasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SubtemasBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SubtemasBindingNavigator.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 34)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(151, 27)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(217, 34)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Nuevo"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(12, 67)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(151, 26)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Button3"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'InglesDataSet
        '
        Me.InglesDataSet.DataSetName = "InglesDataSet"
        Me.InglesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SubtemasBindingSource
        '
        Me.SubtemasBindingSource.DataMember = "Subtemas"
        Me.SubtemasBindingSource.DataSource = Me.InglesDataSet
        '
        'SubtemasTableAdapter
        '
        Me.SubtemasTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.ConceptosTableAdapter = Nothing
        Me.TableAdapterManager.Connection = Nothing
        Me.TableAdapterManager.Copia_de_SubFrasesTableAdapter = Nothing
        Me.TableAdapterManager.Copia_de_TiposTableAdapter = Nothing
        Me.TableAdapterManager.Copia_de_VerbosTableAdapter = Nothing
        Me.TableAdapterManager.Errores_de_pegadoTableAdapter = Nothing
        Me.TableAdapterManager.FrasesTableAdapter = Nothing
        Me.TableAdapterManager.Grupos_oracionTableAdapter = Nothing
        Me.TableAdapterManager.Grupos_TemasTableAdapter = Nothing
        Me.TableAdapterManager.Grupos1TableAdapter = Nothing
        Me.TableAdapterManager.GruposTableAdapter = Nothing
        Me.TableAdapterManager.Hoja1TableAdapter = Nothing
        Me.TableAdapterManager.irregularTableAdapter = Nothing
        Me.TableAdapterManager.OracionesTableAdapter = Nothing
        Me.TableAdapterManager.Palabras_UsadasTableAdapter = Nothing
        Me.TableAdapterManager.RaizTableAdapter = Nothing
        Me.TableAdapterManager.regularTableAdapter = Nothing
        Me.TableAdapterManager.RelacionadosTableAdapter = Nothing
        Me.TableAdapterManager.SinonimosTableAdapter = Nothing
        Me.TableAdapterManager.SubconceptosTableAdapter = Nothing
        Me.TableAdapterManager.Suboracion_conceptoTableAdapter = Nothing
        Me.TableAdapterManager.SuboracionTableAdapter = Nothing
        Me.TableAdapterManager.SubtipoTableAdapter = Nothing
        Me.TableAdapterManager.Tabla_RespaldoTableAdapter = Nothing
        Me.TableAdapterManager.Tabla10TableAdapter = Nothing
        Me.TableAdapterManager.Tabla1TableAdapter = Nothing
        Me.TableAdapterManager.Tabla2TableAdapter = Nothing
        Me.TableAdapterManager.Tabla3TableAdapter = Nothing
        Me.TableAdapterManager.Tabla4TableAdapter = Nothing
        Me.TableAdapterManager.TemasTableAdapter = Nothing
        Me.TableAdapterManager.TiposTableAdapter = Nothing
        Me.TableAdapterManager.UpdateOrder = WindowsApplication1.InglesDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        Me.TableAdapterManager.Verbos___ExcelTableAdapter = Nothing
        Me.TableAdapterManager.VerbosTableAdapter = Nothing
        '
        'SubtemasBindingNavigator
        '
        Me.SubtemasBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.SubtemasBindingNavigator.BindingSource = Me.SubtemasBindingSource
        Me.SubtemasBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.SubtemasBindingNavigator.DeleteItem = Me.BindingNavigatorDeleteItem
        Me.SubtemasBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.SubtemasBindingNavigatorSaveItem})
        Me.SubtemasBindingNavigator.Location = New System.Drawing.Point(0, 0)
        Me.SubtemasBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.SubtemasBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.SubtemasBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.SubtemasBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.SubtemasBindingNavigator.Name = "SubtemasBindingNavigator"
        Me.SubtemasBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.SubtemasBindingNavigator.Size = New System.Drawing.Size(751, 25)
        Me.SubtemasBindingNavigator.TabIndex = 3
        Me.SubtemasBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'SubtemasBindingNavigatorSaveItem
        '
        Me.SubtemasBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.SubtemasBindingNavigatorSaveItem.Enabled = False
        Me.SubtemasBindingNavigatorSaveItem.Image = CType(resources.GetObject("SubtemasBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.SubtemasBindingNavigatorSaveItem.Name = "SubtemasBindingNavigatorSaveItem"
        Me.SubtemasBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.SubtemasBindingNavigatorSaveItem.Text = "Guardar datos"
        '
        'txtDocumento
        '
        Me.txtDocumento.Location = New System.Drawing.Point(307, 94)
        Me.txtDocumento.Name = "txtDocumento"
        Me.txtDocumento.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDocumento.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.txtDocumento.Size = New System.Drawing.Size(417, 385)
        Me.txtDocumento.TabIndex = 4
        Me.txtDocumento.Text = ""
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(307, 57)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(95, 31)
        Me.Button4.TabIndex = 5
        Me.Button4.Text = "Button4"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CheckBox1.Location = New System.Drawing.Point(425, 67)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(78, 17)
        Me.CheckBox1.TabIndex = 6
        Me.CheckBox1.Text = "CheckBox1"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'FrmDocumentos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(751, 511)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.txtDocumento)
        Me.Controls.Add(Me.SubtemasBindingNavigator)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "FrmDocumentos"
        Me.Text = "FrmDocumentos"
        CType(Me.InglesDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SubtemasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SubtemasBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SubtemasBindingNavigator.ResumeLayout(False)
        Me.SubtemasBindingNavigator.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents InglesDataSet As WindowsApplication1.InglesDataSet
    Friend WithEvents SubtemasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SubtemasTableAdapter As WindowsApplication1.InglesDataSetTableAdapters.SubtemasTableAdapter
    Friend WithEvents TableAdapterManager As WindowsApplication1.InglesDataSetTableAdapters.TableAdapterManager
    Friend WithEvents SubtemasBindingNavigator As System.Windows.Forms.BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents SubtemasBindingNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtDocumento As System.Windows.Forms.RichTextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
End Class
