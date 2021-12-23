Imports CapaNE
Imports CapaLN
Public Class OrdenDeTRabajo
    Public idAlumnaaa As Integer
    Dim objAlumnaLN As New ClienteLN
    Dim objAlumnaNe As New ClaseCliente

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        BuscClienteVtas.Show()
    End Sub

    Private Sub OrdenDeTRabajo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextBox7.Enabled = False
        TextBox3.Enabled = False
        TextBox4.Enabled = False
        TextBox5.Enabled = False
    End Sub
    'Private Sub CheckBox()
    '    Dim objOrdOT As New ClaseOrdenDeTRabajo
    '    Dim option As String 
    '    If CheckBox1.Checked Then
    '        objOrdOT.Cargador = "SI"
    '    Else
    '        objOrdOT.Cargador = "NO"
    '    End If
    '    If CheckBox2.Checked Then
    '        objOrdOT.Bateria = "SI"
    '    Else
    '        objOrdOT.Bateria = "NO"
    '    End If
    '    If CheckBox3.Checked Then
    '        objOrdOT.Funda = "SI"
    '    Else
    '        objOrdOT.Funda = "NO"
    '    End If
    '    If CheckBox4.Checked Then
    '        objOrdOT.Maletin = "SI"
    '    Else
    '        objOrdOT.Maletin = "NO"
    '    End If
    '    If CheckBox5.Checked Then
    '        objOrdOT.Cables = "SI"
    '    Else
    '        objOrdOT.Cables = "NO"
    '    End If
    'End Sub

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Dim objOrdOTNE As New ClaseOrdenDeTRabajo
        Dim objOrdOTLN As New OrdenDeTrabajoLN
        Dim objEstadoOTNE As New ClaseEstadoOT
        Dim resp As Integer
        Dim idOrdOT As Integer
        If TextBox2.Text = "" Then
            MessageBox.Show("Debe ingresar un Motivo de consulta")
        Else
            If TextBox6.Text = "" Then
                MessageBox.Show("Debe ingresar un Dispositivo a reparar")
            Else

                resp = MessageBox.Show("¿Confirma Guardar todos los datos ingresados?...", "Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If resp = vbYes Then

                    objOrdOTNE = New ClaseOrdenDeTRabajo
                    objOrdOTNE.Fecha = DateTimePicker1.Value
                    objOrdOTNE.NumDocCL = idAlumnaaa
                    objOrdOTNE.MotivoCon = TextBox2.Text
                    objOrdOTNE.DispositARep = TextBox6.Text
                    objOrdOTNE.activa = 1


                    If CheckBox1.Checked Then
                        objOrdOTNE.Cargador = "SI"
                    Else
                        objOrdOTNE.Cargador = "NO"
                    End If

                    If CheckBox2.Checked Then
                        objOrdOTNE.Bateria = "SI"
                    Else
                        objOrdOTNE.Bateria = "NO"
                    End If

                    If CheckBox3.Checked Then
                        objOrdOTNE.Funda = "SI"
                    Else
                        objOrdOTNE.Funda = "NO"
                    End If

                    If CheckBox4.Checked Then
                        objOrdOTNE.Maletin = "SI"
                    Else
                        objOrdOTNE.Maletin = "NO"
                    End If

                    If CheckBox5.Checked Then
                        objOrdOTNE.Cables = "SI"
                    Else
                        objOrdOTNE.Cables = "NO"
                    End If
                    objOrdOTNE.IdEstadoOT = "2"
                    idOrdOT = objOrdOTLN.InsertarOT(objOrdOTNE)
                    MsgBox("Los datos ingresados se guardaron Correctamente")
                    Dim ds As DataSet
                    Dim objComp As New OrdenDeTrabajoLN
                    ds = objComp.cargaGrilla
                    BuscarOrdTrab.dgvAlumnas.DataSource = ds.Tables(0)
                    BuscarOrdTrab.CambioColorGRilla()
                    Dim objCbioEstLN As New OrdenDeTrabajoLN
                    Dim objCbioEstNE As New ClaseCambioEstadOT
                    objCbioEstNE.idOT = idOrdOT
                    objCbioEstNE.idEstadoOT = "2"
                    objCbioEstNE.fechaCmbioEstOT = DateTimePicker1.Value
                    objCbioEstNE.Observaciones = TextBox2.Text
                    objCbioEstLN.InsertarCambioEstOT(objCbioEstNE)
                    Me.Close()
                End If
            End If
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
End Class