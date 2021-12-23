Imports CapaNE
Imports CapaLN
Public Class CompraDetalle
    Dim objCompraLN As New ComprasLN
    Dim objCompraNe As New ClaseCompras
    Public idCompraa As Integer
    Public idItemm As Integer
 
    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub CompraDetalle_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox1.Enabled = False
        TextBox5.Enabled = False
        txtNombre.Enabled = False
        txtNumDoc.Enabled = False
        dtpFecIng.Enabled = False
        TextBox2.Enabled = False
        DataGridView1.Enabled = False
        DataGridView1.Columns(4).Visible = False
        DataGridView1.Columns(5).Visible = False
        DataGridView1.Columns(0).Width = 300
        Dim ds As New DataSet
        Dim objComprasLN As New ComprasLN
        ds = objCompraLN.buscarAnulado(idCompraa)
        If ds.Tables(0).Rows.Count <> 0 Then
            If ds.Tables(0).Rows(0).Item(0).ToString = 1 Then
                Label2.Visible = True
            Else
                Label2.Visible = False
            End If
        End If
    End Sub
End Class