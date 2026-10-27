<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPlayer
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
        Me.cmdPlay = New System.Windows.Forms.Button()
        Me.cmdClose = New System.Windows.Forms.Button()
        Me.cmdPause = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.lbltitulo = New System.Windows.Forms.Label()
        Me.tbVelocidad = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.numFontSize = New System.Windows.Forms.NumericUpDown()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.chkMostrarOcultar = New System.Windows.Forms.CheckBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.cmdAtras = New System.Windows.Forms.Button()
        Me.lblSpeedValue = New System.Windows.Forms.Label()
        Me.txtCurrentPosition = New System.Windows.Forms.Label()
        Me.tbVolume = New System.Windows.Forms.TrackBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdSeleccionar = New System.Windows.Forms.Button()
        Me.cmdErrores = New System.Windows.Forms.Button()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.RichTextBox3 = New System.Windows.Forms.RichTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        CType(Me.tbVelocidad, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFontSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.tbVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdPlay
        '
        Me.cmdPlay.Location = New System.Drawing.Point(105, 12)
        Me.cmdPlay.Name = "cmdPlay"
        Me.cmdPlay.Size = New System.Drawing.Size(87, 36)
        Me.cmdPlay.TabIndex = 49
        Me.cmdPlay.Text = "Play"
        Me.cmdPlay.UseVisualStyleBackColor = True
        '
        'cmdClose
        '
        Me.cmdClose.Location = New System.Drawing.Point(12, 12)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(87, 36)
        Me.cmdClose.TabIndex = 50
        Me.cmdClose.Text = "Cerrar"
        Me.cmdClose.UseVisualStyleBackColor = True
        '
        'cmdPause
        '
        Me.cmdPause.Location = New System.Drawing.Point(198, 12)
        Me.cmdPause.Name = "cmdPause"
        Me.cmdPause.Size = New System.Drawing.Size(87, 36)
        Me.cmdPause.TabIndex = 52
        Me.cmdPause.Text = "Pause"
        Me.cmdPause.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(533, 14)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(117, 31)
        Me.Button1.TabIndex = 54
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(942, 46)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(116, 28)
        Me.Button2.TabIndex = 55
        Me.Button2.Text = "Button2"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'lbltitulo
        '
        Me.lbltitulo.AutoSize = True
        Me.lbltitulo.Location = New System.Drawing.Point(12, 51)
        Me.lbltitulo.Name = "lbltitulo"
        Me.lbltitulo.Size = New System.Drawing.Size(39, 13)
        Me.lbltitulo.TabIndex = 56
        Me.lbltitulo.Text = "Label1"
        '
        'tbVelocidad
        '
        Me.tbVelocidad.AutoSize = False
        Me.tbVelocidad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbVelocidad.LargeChange = 1
        Me.tbVelocidad.Location = New System.Drawing.Point(673, 33)
        Me.tbVelocidad.Minimum = 5
        Me.tbVelocidad.Name = "tbVelocidad"
        Me.tbVelocidad.Size = New System.Drawing.Size(195, 31)
        Me.tbVelocidad.TabIndex = 57
        Me.tbVelocidad.Value = 10
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(680, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Slow"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(670, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 13)
        Me.Label2.TabIndex = 56
        Me.Label2.Text = "0.5"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(846, 68)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(13, 13)
        Me.Label3.TabIndex = 56
        Me.Label3.Text = "1"
        '
        'cmdSave
        '
        Me.cmdSave.Location = New System.Drawing.Point(57, 51)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(66, 27)
        Me.cmdSave.TabIndex = 60
        Me.cmdSave.Text = "Save"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'numFontSize
        '
        Me.numFontSize.Location = New System.Drawing.Point(979, 25)
        Me.numFontSize.Name = "numFontSize"
        Me.numFontSize.Size = New System.Drawing.Size(48, 20)
        Me.numFontSize.TabIndex = 61
        Me.numFontSize.Value = New Decimal(New Integer() {10, 0, 0, 0})
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(976, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 56
        Me.Label4.Text = "Font Size"
        '
        'chkMostrarOcultar
        '
        Me.chkMostrarOcultar.AutoSize = True
        Me.chkMostrarOcultar.Checked = True
        Me.chkMostrarOcultar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkMostrarOcultar.Location = New System.Drawing.Point(312, 57)
        Me.chkMostrarOcultar.Name = "chkMostrarOcultar"
        Me.chkMostrarOcultar.Size = New System.Drawing.Size(90, 17)
        Me.chkMostrarOcultar.TabIndex = 62
        Me.chkMostrarOcultar.Text = "Ocultar Texto"
        Me.chkMostrarOcultar.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Controls.Add(Me.Panel1)
        Me.Panel3.Controls.Add(Me.Panel2)
        Me.Panel3.Location = New System.Drawing.Point(12, 84)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1247, 748)
        Me.Panel3.TabIndex = 63
        '
        'cmdAtras
        '
        Me.cmdAtras.Location = New System.Drawing.Point(291, 13)
        Me.cmdAtras.Name = "cmdAtras"
        Me.cmdAtras.Size = New System.Drawing.Size(72, 33)
        Me.cmdAtras.TabIndex = 64
        Me.cmdAtras.Text = "Atras"
        Me.cmdAtras.UseVisualStyleBackColor = True
        '
        'lblSpeedValue
        '
        Me.lblSpeedValue.AutoSize = True
        Me.lblSpeedValue.Location = New System.Drawing.Point(752, 9)
        Me.lblSpeedValue.Name = "lblSpeedValue"
        Me.lblSpeedValue.Size = New System.Drawing.Size(13, 13)
        Me.lblSpeedValue.TabIndex = 56
        Me.lblSpeedValue.Text = "0"
        '
        'txtCurrentPosition
        '
        Me.txtCurrentPosition.AutoSize = True
        Me.txtCurrentPosition.Location = New System.Drawing.Point(530, 58)
        Me.txtCurrentPosition.Name = "txtCurrentPosition"
        Me.txtCurrentPosition.Size = New System.Drawing.Size(13, 13)
        Me.txtCurrentPosition.TabIndex = 56
        Me.txtCurrentPosition.Text = "0"
        '
        'tbVolume
        '
        Me.tbVolume.AutoSize = False
        Me.tbVolume.Cursor = System.Windows.Forms.Cursors.Hand
        Me.tbVolume.LargeChange = 1
        Me.tbVolume.Location = New System.Drawing.Point(1064, 33)
        Me.tbVolume.Maximum = 100
        Me.tbVolume.Name = "tbVolume"
        Me.tbVolume.Size = New System.Drawing.Size(195, 31)
        Me.tbVolume.TabIndex = 65
        Me.tbVolume.Value = 50
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(1077, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 56
        Me.Label5.Text = "Volume"
        '
        'cmdSeleccionar
        '
        Me.cmdSeleccionar.Location = New System.Drawing.Point(129, 51)
        Me.cmdSeleccionar.Name = "cmdSeleccionar"
        Me.cmdSeleccionar.Size = New System.Drawing.Size(76, 24)
        Me.cmdSeleccionar.TabIndex = 66
        Me.cmdSeleccionar.Text = "Seleccionar"
        Me.cmdSeleccionar.UseVisualStyleBackColor = True
        '
        'cmdErrores
        '
        Me.cmdErrores.Location = New System.Drawing.Point(211, 51)
        Me.cmdErrores.Name = "cmdErrores"
        Me.cmdErrores.Size = New System.Drawing.Size(76, 24)
        Me.cmdErrores.TabIndex = 66
        Me.cmdErrores.Text = "Errores"
        Me.cmdErrores.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Panel4.Controls.Add(Me.RichTextBox3)
        Me.Panel4.Location = New System.Drawing.Point(11, 569)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(1210, 173)
        Me.Panel4.TabIndex = 68
        '
        'RichTextBox3
        '
        Me.RichTextBox3.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.RichTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox3.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RichTextBox3.Location = New System.Drawing.Point(13, 11)
        Me.RichTextBox3.Name = "RichTextBox3"
        Me.RichTextBox3.Size = New System.Drawing.Size(1182, 150)
        Me.RichTextBox3.TabIndex = 1
        Me.RichTextBox3.Text = ""
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel1.Controls.Add(Me.RichTextBox1)
        Me.Panel1.Location = New System.Drawing.Point(11, 18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1213, 286)
        Me.Panel1.TabIndex = 65
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel2.Controls.Add(Me.RichTextBox2)
        Me.Panel2.Location = New System.Drawing.Point(11, 311)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1210, 253)
        Me.Panel2.TabIndex = 64
        '
        'RichTextBox2
        '
        Me.RichTextBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.RichTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox2.Location = New System.Drawing.Point(14, 12)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.Size = New System.Drawing.Size(1182, 226)
        Me.RichTextBox2.TabIndex = 1
        Me.RichTextBox2.Text = ""
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Location = New System.Drawing.Point(14, 14)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(1182, 258)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'frmPlayer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1283, 839)
        Me.Controls.Add(Me.cmdErrores)
        Me.Controls.Add(Me.cmdSeleccionar)
        Me.Controls.Add(Me.tbVolume)
        Me.Controls.Add(Me.cmdAtras)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.chkMostrarOcultar)
        Me.Controls.Add(Me.numFontSize)
        Me.Controls.Add(Me.cmdSave)
        Me.Controls.Add(Me.tbVelocidad)
        Me.Controls.Add(Me.txtCurrentPosition)
        Me.Controls.Add(Me.lblSpeedValue)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbltitulo)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.cmdPause)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.cmdPlay)
        Me.Name = "frmPlayer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "frmPlayer"
        CType(Me.tbVelocidad, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFontSize, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        CType(Me.tbVolume, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdPlay As System.Windows.Forms.Button
    Friend WithEvents cmdClose As System.Windows.Forms.Button
    Friend WithEvents cmdPause As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents lbltitulo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tbVelocidad As System.Windows.Forms.TrackBar
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents numFontSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents chkMostrarOcultar As System.Windows.Forms.CheckBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents cmdAtras As System.Windows.Forms.Button
    Friend WithEvents lblSpeedValue As System.Windows.Forms.Label
    Friend WithEvents txtCurrentPosition As System.Windows.Forms.Label
    Friend WithEvents tbVolume As System.Windows.Forms.TrackBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmdSeleccionar As System.Windows.Forms.Button
    Friend WithEvents cmdErrores As System.Windows.Forms.Button
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents RichTextBox3 As System.Windows.Forms.RichTextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RichTextBox2 As System.Windows.Forms.RichTextBox
End Class
