Imports CapaNE
Imports CapaLN
Public Class ModificarPrecios
    Dim objPrecLN As New PreciosLN
    Dim objPrecNe As New ClasePrecios
    Public idPrecio As Integer
    Public idAProv As Integer
    Private Sub ModificarPrecios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox2.Enabled = False
        TextBox3.Enabled = False
        DateTimePicker1.Enabled = False
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Dim objPrecLN As New PreciosLN
        Dim objPrecNe As New ClasePrecios
        Dim objPrecHistLN As New PreciosHistLN
        Dim objPrecHistNe As New ClasePreciosHist
        'modificamos precio actual
        objPrecNe.IdPrecio = idPrecio
        objPrecNe.idProv = idAProv
        objPrecNe.Precio = TextBox1.Text
        objPrecNe.Fecha = DateTimePicker1.Text
        objPrecLN.modificarPrecio(objPrecNe)

        'insertamos en precio Historico
        objPrecHistNe.PrecioHist = PreciosProveedor.dgvPrecios.CurrentRow.Cells(1).Value
        objPrecHistNe.FechaPrecHist = PreciosProveedor.dgvPrecios.CurrentRow.Cells(3).Value
        objPrecHistNe.idProv = PreciosProveedor.dgvPrecios.CurrentRow.Cells(6).Value
        objPrecHistNe.idArticulo = PreciosProveedor.dgvPrecios.CurrentRow.Cells(5).Value
        objPrecHistLN.InsertarPrecioHist(objPrecHistNe)

        Dim ds As DataSet
        ds = objPrecLN.cargaGrilla
        PreciosProveedor.dgvPrecios.DataSource = ds.Tables(0)
        PreciosProveedor.dgvPrecios.Columns(4).Visible = False
        PreciosProveedor.dgvPrecios.Columns(5).Visible = False
        PreciosProveedor.dgvPrecios.Columns(6).Visible = False
        Me.Close()
    End Sub
End Class