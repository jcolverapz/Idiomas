Public Class FrmPrincipal

    Private Sub CmdTemas_Click(sender As System.Object, e As System.EventArgs) Handles CmdTemas.Click
        FrmTemas.Show()
        'FrmTemas.lblDescripcion.Text = txtDescripcion.Text
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        FrmAvance.Show()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        FrmVocabulario.Show()
    End Sub

    Private Sub ConceptosBindingNavigatorSaveItem_Click(sender As System.Object, e As System.EventArgs)
      

    End Sub

    Private Sub FrmPrincipal_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'InglesDataSet.Conceptos' Puede moverla o quitarla según sea necesario.
        Me.ConceptosTableAdapter.Fill(Me.InglesDataSet.Conceptos)
        'TODO: esta línea de código carga datos en la tabla 'InglesDataSet.Grupos_Temas' Puede moverla o quitarla según sea necesario.
        Me.Grupos_TemasTableAdapter.Fill(Me.InglesDataSet.Grupos_Temas)
        'TODO: esta línea de código carga datos en la tabla 'InglesDataSet.Grupos' Puede moverla o quitarla según sea necesario.
        Me.GruposTableAdapter.Fill(Me.InglesDataSet.Grupos)
        'TODO: esta línea de código carga datos en la tabla 'Consulta2._Consulta2' Puede moverla o quitarla según sea necesario.
        ' Me.Consulta2TableAdapter.Fill(Me.Consulta2._Consulta2)
        'TODO: esta línea de código carga datos en la tabla 'InglesDataSet.Conceptos' Puede moverla o quitarla según sea necesario.
        '   Me.ConceptosTableAdapter.Fill(Me.InglesDataSet.Conceptos)


    End Sub

    Private Sub ConceptosBindingNavigatorSaveItem_Click_1(sender As System.Object, e As System.EventArgs)
        Me.Validate()
        ' Me.ConceptosBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.InglesDataSet)

    End Sub

    Private Sub CmdOraciones_Click(sender As System.Object, e As System.EventArgs) Handles CmdOraciones.Click
        FrmOraciones.Show()
    End Sub
 
    Private Sub btnTexto_Click(sender As System.Object, e As System.EventArgs) Handles btnTexto.Click
        FrmDocumentos.Show()

    End Sub
End Class