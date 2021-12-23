Imports CapaLN
Imports CapaNE
Public Class Reporteventasxarticulo
    Public idcategoria As String
    Public idmarca As String
    Public fechadesde As String
    Public fechahasta As String
    Private Sub VentasxArticulo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DateTimePicker1.Value = DateTimePicker1.Value.AddDays(-30)
        cargarComboCategoria()
        cargarComboMArcas()
        fechadesde = Format(DateTimePicker1.Value, "yyyy/MM/dd")
        fechahasta = Format(DateTimePicker2.Value, "yyyy/MM/dd")
        Dim ds As New DataSet
        Dim objEst As New EstadisticasLN
        ds = objEst.cargaGrillaArt(idcategoria, idmarca, fechadesde, fechahasta)
        DataGridView1.DataSource = ds.Tables(0)
        AlineamientoGrilla()
    End Sub
    Sub AlineamientoGrilla()
        DataGridView1.Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        'DataGridView1.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GraficoVentasxAr.Show()
    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
    Sub cargarComboCategoria()
        Dim ds As DataSet
        Dim objCategLN As New EstadisticasLN
        Dim objCategNE As New ClaseCategoria

        ds = New DataSet
        ds = objCategLN.cargarComboCategoria(objCategNE)
        CboCampo.DataSource = ds.Tables("tabCate")
        CboCampo.DisplayMember = "NomCategoria"
        CboCampo.ValueMember = "idCategoria"
        CboCampo.Text = "Seleccione"
    End Sub
    Sub cargarComboMArcas()
        Dim ds As DataSet
        Dim objMarcaLN As New EstadisticasLN
        Dim objMarcaNE As New ClaseMarca

        ds = New DataSet
        ds = objMarcaLN.cargarComboMarcas(objMarcaNE)
        ComboBox1.DataSource = ds.Tables("tabMarc")
        ComboBox1.DisplayMember = "Marca"
        ComboBox1.ValueMember = "idMarca"
        ComboBox1.Text = "Seleccione"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        fechadesde = Format(DateTimePicker1.Value, "yyyy/MM/dd")
        fechahasta = Format(DateTimePicker2.Value, "yyyy/MM/dd")

        Dim ds As New DataSet
        Dim objEst As New EstadisticasLN
        If ComboBox1.Text <> "Seleccione" Then
            idmarca = ComboBox1.SelectedValue
        End If
        If CboCampo.Text <> "Seleccione" Then
            idcategoria = CboCampo.SelectedValue
        End If
        ds = objEst.cargaGrillaArt(idcategoria, idmarca, fechadesde, fechahasta)
        DataGridView1.DataSource = ds.Tables(0)
        AlineamientoGrilla()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        cargarComboCategoria()
        cargarComboMArcas()
        DateTimePicker1.Value = Now
        DateTimePicker1.Value = DateTimePicker1.Value.AddDays(-30)

        fechadesde = Format(DateTimePicker1.Value, "yyyy/MM/dd")
        fechahasta = Format(DateTimePicker2.Value, "yyyy/MM/dd")
        idcategoria = ""
        idmarca = ""
        Dim ds As New DataSet
        Dim objEst As New EstadisticasLN
        ds = objEst.cargaGrillaArt(idcategoria, idmarca, fechadesde, fechahasta)
        DataGridView1.DataSource = ds.Tables(0)
        AlineamientoGrilla()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        ReporteVentasxArt.Show()
    End Sub
End Class