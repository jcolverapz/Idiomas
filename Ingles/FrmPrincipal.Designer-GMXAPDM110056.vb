<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrincipal
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
        Me.CmdTemas = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Consulta2TableAdapter = New WindowsApplication1.Consulta2TableAdapters.Consulta2TableAdapter()
        Me.TableAdapterManager1 = New WindowsApplication1.Consulta2TableAdapters.TableAdapterManager()
        Me.GruposBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GruposTableAdapter = New WindowsApplication1.InglesDataSetTableAdapters.GruposTableAdapter()
        Me.Grupos_TemasTableAdapter = New WindowsApplication1.InglesDataSetTableAdapters.Grupos_TemasTableAdapter()
        Me.TableAdapterManager = New WindowsApplication1.InglesDataSetTableAdapters.TableAdapterManager()
        Me.ConceptosTableAdapter = New WindowsApplication1.InglesDataSetTableAdapters.ConceptosTableAdapter()
        Me.InglesDataSet = New WindowsApplication1.InglesDataSet()
        Me.Grupos_TemasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ConceptosBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CmdOraciones = New System.Windows.Forms.Button()
        Me.btnTexto = New System.Windows.Forms.Button()
        CType(Me.GruposBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InglesDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grupos_TemasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ConceptosBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CmdTemas
        '
        Me.CmdTemas.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdTemas.Location = New System.Drawing.Point(55, 47)
        Me.CmdTemas.Name = "CmdTemas"
        Me.CmdTemas.Size = New System.Drawing.Size(119, 47)
        Me.CmdTemas.TabIndex = 0
        Me.CmdTemas.Text = "Temas"
        Me.CmdTemas.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(893, 36)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(119, 47)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Avance"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(55, 112)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(119, 47)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "Vocabulario"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Consulta2TableAdapter
        '
        Me.Consulta2TableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager1
        '
        Me.TableAdapterManager1.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager1.Connection = Nothing
        Me.TableAdapterManager1.UpdateOrder = WindowsApplication1.Consulta2TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'GruposTableAdapter
        '
        Me.GruposTableAdapter.ClearBeforeFill = True
        '
        'Grupos_TemasTableAdapter
        '
        Me.Grupos_TemasTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.ConceptosTableAdapter = Me.ConceptosTableAdapter
        Me.TableAdapterManager.Copia_de_SubFrasesTableAdapter = Nothing
        Me.TableAdapterManager.Copia_de_TiposTableAdapter = Nothing
        Me.TableAdapterManager.Copia_de_VerbosTableAdapter = Nothing
        Me.TableAdapterManager.Errores_de_pegadoTableAdapter = Nothing
        Me.TableAdapterManager.FrasesTableAdapter = Nothing
        Me.TableAdapterManager.Grupos_oracionTableAdapter = Nothing
        Me.TableAdapterManager.Grupos_TemasTableAdapter = Me.Grupos_TemasTableAdapter
        Me.TableAdapterManager.Grupos1TableAdapter = Nothing
        Me.TableAdapterManager.GruposTableAdapter = Me.GruposTableAdapter
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
        'ConceptosTableAdapter
        '
        Me.ConceptosTableAdapter.ClearBeforeFill = True
        '
        'InglesDataSet
        '
        Me.InglesDataSet.DataSetName = "InglesDataSet"
        Me.InglesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'Grupos_TemasBindingSource
        '
        Me.Grupos_TemasBindingSource.DataMember = "Grupos_Temas"
        Me.Grupos_TemasBindingSource.DataSource = Me.InglesDataSet
        '
        'ConceptosBindingSource
        '
        Me.ConceptosBindingSource.DataMember = "Conceptos"
        Me.ConceptosBindingSource.DataSource = Me.InglesDataSet
        '
        'CmdOraciones
        '
        Me.CmdOraciones.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.CmdOraciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdOraciones.Location = New System.Drawing.Point(55, 174)
        Me.CmdOraciones.Name = "CmdOraciones"
        Me.CmdOraciones.Size = New System.Drawing.Size(119, 47)
        Me.CmdOraciones.TabIndex = 3
        Me.CmdOraciones.Text = "Oraciones"
        Me.CmdOraciones.UseVisualStyleBackColor = False
        '
        'btnTexto
        '
        Me.btnTexto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTexto.Location = New System.Drawing.Point(759, 36)
        Me.btnTexto.Name = "btnTexto"
        Me.btnTexto.Size = New System.Drawing.Size(119, 47)
        Me.btnTexto.TabIndex = 4
        Me.btnTexto.Text = "Texto"
        Me.btnTexto.UseVisualStyleBackColor = True
        '
        'FrmPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1302, 614)
        Me.Controls.Add(Me.btnTexto)
        Me.Controls.Add(Me.CmdOraciones)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.CmdTemas)
        Me.Name = "FrmPrincipal"
        Me.Text = "FrmPrincipal"
        CType(Me.GruposBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InglesDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grupos_TemasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ConceptosBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CmdTemas As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Consulta2TableAdapter As WindowsApplication1.Consulta2TableAdapters.Consulta2TableAdapter
    Friend WithEvents TableAdapterManager1 As WindowsApplication1.Consulta2TableAdapters.TableAdapterManager
    Friend WithEvents GruposTableAdapter As WindowsApplication1.InglesDataSetTableAdapters.GruposTableAdapter
    Friend WithEvents GruposBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InglesDataSet As WindowsApplication1.InglesDataSet
    Friend WithEvents Grupos_TemasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Grupos_TemasTableAdapter As WindowsApplication1.InglesDataSetTableAdapters.Grupos_TemasTableAdapter
    Friend WithEvents TableAdapterManager As WindowsApplication1.InglesDataSetTableAdapters.TableAdapterManager
    Friend WithEvents ConceptosTableAdapter As WindowsApplication1.InglesDataSetTableAdapters.ConceptosTableAdapter
    Friend WithEvents ConceptosBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CmdOraciones As System.Windows.Forms.Button
    Friend WithEvents btnTexto As System.Windows.Forms.Button
End Class
