Imports CapaNE
Imports CapaLN
Public Class Modificar_Estado_OT
    Public idAlumnaaa As Integer
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Modificar_Estado_OT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cargarComboEstadoOT()
    End Sub
    Sub cargarComboEstadoOT()
        Dim ds As DataSet
        Dim objEstadoOTkLN As New OrdenDeTrabajoLN
        Dim objEstadoOTkNE As New ClaseEstadoOT

        ds = New DataSet
        ds = objEstadoOTkLN.cargarComboEstadoOT(objEstadoOTkNE)
        ComboBox1.DataSource = ds.Tables("tabCat")
        ComboBox1.DisplayMember = "EstadoOT"
        ComboBox1.ValueMember = "idEstadoOT"
        ComboBox1.Text = "Seleccione"
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim objEstadoOTkLN As New OrdenDeTrabajoLN
        Dim objEstadoOTkNE As New ClaseOrdenDeTRabajo
        objEstadoOTkNE.idOrdenTRab = TextBox1.Text
        objEstadoOTkNE.IdEstadoOT = ComboBox1.SelectedValue
        objEstadoOTkLN.modificarEstadoOT(objEstadoOTkNE)

        Dim objCambioEstOT As New ClaseCambioEstadOT
        objCambioEstOT.idEstadoOT = ComboBox1.SelectedValue
        objCambioEstOT.idOT = TextBox1.Text
        objCambioEstOT.Observaciones = TxtObsv.Text
        objCambioEstOT.fechaCmbioEstOT = DateTimePicker2.Value
        objEstadoOTkLN.InsertarCambioEstOT(objCambioEstOT)

        Me.Close()
        Dim ds As DataSet
        ds = objEstadoOTkLN.cargaGrilla
        BuscarOrdTrab.dgvAlumnas.DataSource = ds.Tables(0)
        BuscarOrdTrab.dgvAlumnas.Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        BuscarOrdTrab.CambioColorGRilla()
        BuscarOrdTrab.SumaEquipos()
        BuscarOrdTrab.MostrarAlerta()
        Me.Close()
    End Sub
End Class