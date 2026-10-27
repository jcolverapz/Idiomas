Imports System.Data
Imports System.Data.OleDb
Public Class Gastos

    'propiedades

    Private oda As New OleDbDataAdapter
    Private ods As New DataSet
    Private consulta As String
    Public conexion As New OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\jolvera.SSWTECHNOLOGIES\OneDrive - SSW Holding Company, LLC\Documents\Personal\VS2010-Proyectos\Gastos\Database.accdb")


    Public Function actualizar()
        'Try
        '        conexion.Open()
        '        MsgBox("Conectado a la base de datos")

        '    Catch ex As Exception
        '        MsgBox("no hay conexion")
        '        conexion.Close()

        '    End Try
        consulta = "select * from Enc_Gastos"

        oda = New OleDbDataAdapter(consulta, conexion)
        ods.Tables.Add("Enc_Gastos")
        oda.Fill(ods.Tables("Enc_Gastos"))
        ' FrmTemas.dgvEncDatos.DataSource = ods.Tables("Enc_Gastos").DefaultView
        ' Form2.dgvEncDatos.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        ' FrmTemas.dgvEncDatos.Columns(0).Visible = False

        ' FrmTemas.dgvEncDatos.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        Return consulta
    End Function


    'Datagrid.Columns[0].AutoSizeMode =DataGridViewAutoSizeColumnMode.Fill
    'dgvEncDatos.Columns(0).AutoSizeMode = True
    'dgvEncDatos.Columns(0).MinimumWidth = True
    ' dgvEncDatos.Columns(0).MinimumWidth = 40
       
    'dgvEncDatos.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells

   

    
       
End Class
