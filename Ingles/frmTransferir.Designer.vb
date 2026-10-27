<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransferir
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
        Me.cmdGuardar = New System.Windows.Forms.Button()
        Me.CmdCerrar = New System.Windows.Forms.Button()
        Me.LvwAssigned = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.txtBuscar = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboGrupo = New System.Windows.Forms.ComboBox()
        Me.txtConversacion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTraduccion = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdNuevo = New System.Windows.Forms.Button()
        Me.cmdOrdenar = New System.Windows.Forms.Button()
        Me.cmdSaveDialogo = New System.Windows.Forms.Button()
        Me.cmdTransferir = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtEncabezado = New System.Windows.Forms.TextBox()
        Me.cmdEliminar = New System.Windows.Forms.Button()
        Me.cmdNuevoDetalle = New System.Windows.Forms.Button()
        Me.txtDetId = New System.Windows.Forms.TextBox()
        Me.cboConversation = New System.Windows.Forms.ComboBox()
        Me.cmdConsultaHuerfanos = New System.Windows.Forms.Button()
        Me.cmdAgregaaDialogo = New System.Windows.Forms.Button()
        Me.LvwUnassigned = New Ingles.ListViewCustomReorder.ListViewEx()
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cmdBuscador = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdGuardar
        '
        Me.cmdGuardar.Location = New System.Drawing.Point(807, 115)
        Me.cmdGuardar.Name = "cmdGuardar"
        Me.cmdGuardar.Size = New System.Drawing.Size(116, 33)
        Me.cmdGuardar.TabIndex = 45
        Me.cmdGuardar.Text = "Save"
        Me.cmdGuardar.UseVisualStyleBackColor = True
        '
        'CmdCerrar
        '
        Me.CmdCerrar.Location = New System.Drawing.Point(12, 12)
        Me.CmdCerrar.Name = "CmdCerrar"
        Me.CmdCerrar.Size = New System.Drawing.Size(105, 31)
        Me.CmdCerrar.TabIndex = 44
        Me.CmdCerrar.Text = "Cerrar"
        Me.CmdCerrar.UseVisualStyleBackColor = True
        '
        'LvwAssigned
        '
        Me.LvwAssigned.AllowDrop = True
        Me.LvwAssigned.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader12})
        Me.LvwAssigned.Font = New System.Drawing.Font("Tahoma", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LvwAssigned.Location = New System.Drawing.Point(6, 150)
        Me.LvwAssigned.Name = "LvwAssigned"
        Me.LvwAssigned.Size = New System.Drawing.Size(795, 748)
        Me.LvwAssigned.TabIndex = 46
        Me.LvwAssigned.UseCompatibleStateImageBehavior = False
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Width = 0
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Text"
        Me.ColumnHeader3.Width = 400
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Traduccion"
        Me.ColumnHeader4.Width = 400
        '
        'ColumnHeader12
        '
        Me.ColumnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.ColumnHeader12.Width = 100
        '
        'txtBuscar
        '
        Me.txtBuscar.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtBuscar.Font = New System.Drawing.Font("Arial Black", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuscar.Location = New System.Drawing.Point(6, 95)
        Me.txtBuscar.Name = "txtBuscar"
        Me.txtBuscar.Size = New System.Drawing.Size(221, 41)
        Me.txtBuscar.TabIndex = 48
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 69)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 16)
        Me.Label1.TabIndex = 339
        Me.Label1.Text = "Grupo"
        '
        'cboGrupo
        '
        Me.cboGrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboGrupo.FormattingEnabled = True
        Me.cboGrupo.Location = New System.Drawing.Point(63, 63)
        Me.cboGrupo.Name = "cboGrupo"
        Me.cboGrupo.Size = New System.Drawing.Size(463, 28)
        Me.cboGrupo.TabIndex = 340
        '
        'txtConversacion
        '
        Me.txtConversacion.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConversacion.Location = New System.Drawing.Point(807, 33)
        Me.txtConversacion.Name = "txtConversacion"
        Me.txtConversacion.Size = New System.Drawing.Size(67, 22)
        Me.txtConversacion.TabIndex = 48
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(804, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(91, 16)
        Me.Label2.TabIndex = 339
        Me.Label2.Text = "Conversacion"
        '
        'txtTraduccion
        '
        Me.txtTraduccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTraduccion.Font = New System.Drawing.Font("Arial Black", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTraduccion.Location = New System.Drawing.Point(323, 97)
        Me.txtTraduccion.Name = "txtTraduccion"
        Me.txtTraduccion.Size = New System.Drawing.Size(221, 41)
        Me.txtTraduccion.TabIndex = 342
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(272, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 16)
        Me.Label3.TabIndex = 339
        Me.Label3.Text = "Trad"
        '
        'cmdNuevo
        '
        Me.cmdNuevo.Location = New System.Drawing.Point(122, 12)
        Me.cmdNuevo.Name = "cmdNuevo"
        Me.cmdNuevo.Size = New System.Drawing.Size(105, 31)
        Me.cmdNuevo.TabIndex = 343
        Me.cmdNuevo.Text = "Nueva"
        Me.cmdNuevo.UseVisualStyleBackColor = True
        '
        'cmdOrdenar
        '
        Me.cmdOrdenar.Location = New System.Drawing.Point(938, 87)
        Me.cmdOrdenar.Name = "cmdOrdenar"
        Me.cmdOrdenar.Size = New System.Drawing.Size(94, 31)
        Me.cmdOrdenar.TabIndex = 344
        Me.cmdOrdenar.Text = "Ordenar"
        Me.cmdOrdenar.UseVisualStyleBackColor = True
        '
        'cmdSaveDialogo
        '
        Me.cmdSaveDialogo.Location = New System.Drawing.Point(1050, 69)
        Me.cmdSaveDialogo.Name = "cmdSaveDialogo"
        Me.cmdSaveDialogo.Size = New System.Drawing.Size(116, 48)
        Me.cmdSaveDialogo.TabIndex = 345
        Me.cmdSaveDialogo.Text = "Save Dialogo"
        Me.cmdSaveDialogo.UseVisualStyleBackColor = True
        '
        'cmdTransferir
        '
        Me.cmdTransferir.Location = New System.Drawing.Point(676, 111)
        Me.cmdTransferir.Name = "cmdTransferir"
        Me.cmdTransferir.Size = New System.Drawing.Size(125, 25)
        Me.cmdTransferir.TabIndex = 352
        Me.cmdTransferir.Text = "Transferir Todo"
        Me.cmdTransferir.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(630, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 16)
        Me.Label5.TabIndex = 355
        Me.Label5.Text = "Enc"
        '
        'txtEncabezado
        '
        Me.txtEncabezado.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEncabezado.Location = New System.Drawing.Point(633, 60)
        Me.txtEncabezado.Name = "txtEncabezado"
        Me.txtEncabezado.Size = New System.Drawing.Size(67, 22)
        Me.txtEncabezado.TabIndex = 354
        '
        'cmdEliminar
        '
        Me.cmdEliminar.Location = New System.Drawing.Point(1195, 64)
        Me.cmdEliminar.Name = "cmdEliminar"
        Me.cmdEliminar.Size = New System.Drawing.Size(99, 52)
        Me.cmdEliminar.TabIndex = 356
        Me.cmdEliminar.Text = "Eliminar"
        Me.cmdEliminar.UseVisualStyleBackColor = True
        '
        'cmdNuevoDetalle
        '
        Me.cmdNuevoDetalle.Location = New System.Drawing.Point(1052, 23)
        Me.cmdNuevoDetalle.Name = "cmdNuevoDetalle"
        Me.cmdNuevoDetalle.Size = New System.Drawing.Size(104, 40)
        Me.cmdNuevoDetalle.TabIndex = 357
        Me.cmdNuevoDetalle.Text = "Agregar Detalle"
        Me.cmdNuevoDetalle.UseVisualStyleBackColor = True
        '
        'txtDetId
        '
        Me.txtDetId.Font = New System.Drawing.Font("Arial", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDetId.Location = New System.Drawing.Point(1332, 95)
        Me.txtDetId.Name = "txtDetId"
        Me.txtDetId.Size = New System.Drawing.Size(67, 22)
        Me.txtDetId.TabIndex = 358
        '
        'cboConversation
        '
        Me.cboConversation.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboConversation.FormattingEnabled = True
        Me.cboConversation.Location = New System.Drawing.Point(706, 57)
        Me.cboConversation.Name = "cboConversation"
        Me.cboConversation.Size = New System.Drawing.Size(326, 28)
        Me.cboConversation.TabIndex = 359
        '
        'cmdConsultaHuerfanos
        '
        Me.cmdConsultaHuerfanos.Location = New System.Drawing.Point(233, 12)
        Me.cmdConsultaHuerfanos.Name = "cmdConsultaHuerfanos"
        Me.cmdConsultaHuerfanos.Size = New System.Drawing.Size(105, 43)
        Me.cmdConsultaHuerfanos.TabIndex = 360
        Me.cmdConsultaHuerfanos.Text = "huerfanos"
        Me.cmdConsultaHuerfanos.UseVisualStyleBackColor = True
        '
        'cmdAgregaaDialogo
        '
        Me.cmdAgregaaDialogo.Enabled = False
        Me.cmdAgregaaDialogo.Location = New System.Drawing.Point(1052, 122)
        Me.cmdAgregaaDialogo.Name = "cmdAgregaaDialogo"
        Me.cmdAgregaaDialogo.Size = New System.Drawing.Size(114, 26)
        Me.cmdAgregaaDialogo.TabIndex = 361
        Me.cmdAgregaaDialogo.Text = "Agrega a Dialogo"
        Me.cmdAgregaaDialogo.UseVisualStyleBackColor = True
        '
        'LvwUnassigned
        '
        Me.LvwUnassigned.AllowDrop = True
        Me.LvwUnassigned.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11})
        Me.LvwUnassigned.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LvwUnassigned.Location = New System.Drawing.Point(804, 150)
        Me.LvwUnassigned.Name = "LvwUnassigned"
        Me.LvwUnassigned.Size = New System.Drawing.Size(730, 748)
        Me.LvwUnassigned.TabIndex = 341
        Me.LvwUnassigned.UseCompatibleStateImageBehavior = False
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Width = 0
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Texto"
        Me.ColumnHeader8.Width = 200
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Trad"
        Me.ColumnHeader9.Width = 200
        '
        'ColumnHeader10
        '
        Me.ColumnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'cmdBuscador
        '
        Me.cmdBuscador.Location = New System.Drawing.Point(344, 12)
        Me.cmdBuscador.Name = "cmdBuscador"
        Me.cmdBuscador.Size = New System.Drawing.Size(105, 43)
        Me.cmdBuscador.TabIndex = 362
        Me.cmdBuscador.Text = "Buscador Py"
        Me.cmdBuscador.UseVisualStyleBackColor = True
        '
        'frmTransferir
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1546, 920)
        Me.Controls.Add(Me.cmdBuscador)
        Me.Controls.Add(Me.cmdAgregaaDialogo)
        Me.Controls.Add(Me.cmdConsultaHuerfanos)
        Me.Controls.Add(Me.cboConversation)
        Me.Controls.Add(Me.txtDetId)
        Me.Controls.Add(Me.cmdNuevoDetalle)
        Me.Controls.Add(Me.cmdEliminar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtEncabezado)
        Me.Controls.Add(Me.cmdTransferir)
        Me.Controls.Add(Me.cmdSaveDialogo)
        Me.Controls.Add(Me.cmdOrdenar)
        Me.Controls.Add(Me.cmdNuevo)
        Me.Controls.Add(Me.txtTraduccion)
        Me.Controls.Add(Me.LvwUnassigned)
        Me.Controls.Add(Me.cboGrupo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtConversacion)
        Me.Controls.Add(Me.txtBuscar)
        Me.Controls.Add(Me.LvwAssigned)
        Me.Controls.Add(Me.cmdGuardar)
        Me.Controls.Add(Me.CmdCerrar)
        Me.Name = "frmTransferir"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmTransferir"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdGuardar As System.Windows.Forms.Button
    Friend WithEvents CmdCerrar As System.Windows.Forms.Button
    Friend WithEvents LvwAssigned As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtBuscar As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboGrupo As System.Windows.Forms.ComboBox
    Friend WithEvents LvwUnassigned As Ingles.ListViewCustomReorder.ListViewEx
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents txtConversacion As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTraduccion As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdNuevo As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdOrdenar As System.Windows.Forms.Button
    Friend WithEvents cmdSaveDialogo As System.Windows.Forms.Button
    Friend WithEvents cmdTransferir As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtEncabezado As System.Windows.Forms.TextBox
    Friend WithEvents cmdEliminar As System.Windows.Forms.Button
    Friend WithEvents cmdNuevoDetalle As System.Windows.Forms.Button
    Friend WithEvents txtDetId As System.Windows.Forms.TextBox
    Friend WithEvents cboConversation As System.Windows.Forms.ComboBox
    Friend WithEvents cmdConsultaHuerfanos As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cmdAgregaaDialogo As System.Windows.Forms.Button
    Friend WithEvents cmdBuscador As System.Windows.Forms.Button
    ' Friend WithEvents LvwUnassigned As Ingles.ListViewCustomReorder.ListViewEx
   ' Friend WithEvents LvwUnassigned As Ingles.ListViewCustomReorder.ListViewEx
End Class
