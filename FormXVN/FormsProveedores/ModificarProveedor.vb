Imports CapaNE
Imports CapaLN
Public Class ModificarProveedor
    Public idAProv As Integer
   Dim objProvLN As New ProveedoresLN
    Dim objProvNe As New ClaseProveedor

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        If txtNombre.Text = "" Then
            MessageBox.Show("Debe ingresar una Razón Social")
        Else
            If txtNumCuit.Text = "" Then
                MessageBox.Show("Debe ingresar un número de Cuit")
            Else
                If cmbPais.Text = "" Then
                    MessageBox.Show("Debe Seleccionar un País")
                Else
                    If txtProvincia.Text = "" Then
                        MessageBox.Show("Debe ingresar una Provincia")
                    Else
                        If txtCiudad.Text = "" Then
                            MessageBox.Show("Debe ingresar una ciudad")
                        Else
                            If txtCel.Text = "" Then
                                MessageBox.Show("Debe ingresar un Teléfono Celular")
                            Else
                                Dim objProvLN As New ProveedoresLN
                                Dim objProvNe As New ClaseProveedor
                                Dim doc As New ClaseDocumento
                                Dim dire As New ClaseDireccion
                                objProvNe.NomRaz = txtNombre.Text
                                objProvNe.IdCuit = txtNumCuit.Text
                                objProvNe.TelFijo = txtTelFij.Text
                                objProvNe.telCelular = txtCel.Text
                                objProvNe.Email = txtemail.Text

                                dire.Pais = cmbPais.Text
                                dire.Provincia = txtProvincia.Text
                                dire.Ciudad = txtCiudad.Text
                                dire.Barrio = txtBarrio.Text
                                dire.Calle = txtCalle.Text
                                dire.NumCalle = txtNro.Text
                                dire.Piso = cmbPiso.Text
                                dire.Dpto = txtDepto.Text

                                objProvNe.idProv = idAProv
                                objProvLN.modificarProv(objProvNe)
                                dire.IdProv = idAProv
                                objProvLN.modificarDireProv(dire)

                                Me.Close()
                                Dim ds As DataSet

                                Dim form As New Clientes
                                ds = objProvLN.cargaGrilla
                                Proveedores.dgvProv.DataSource = ds.Tables(0)
                                Proveedores.dgvProv.Columns(5).Visible = False
                                Me.Close()
                            End If
                        End If
                    End If
                End If
            End If
        End If



    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
    Private Sub txtTelFij_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTelFij.TextChanged
        txtTelFij.MaxLength = 10
    End Sub

    Private Sub txtCel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCel.TextChanged
        txtCel.MaxLength = 10
    End Sub
    Private Sub txtCel_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCel.KeyPress

        'Condicional que evalua que la tecla pulsada sea un número 
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
            MessageBox.Show("Introduzca sólo valores númericos")
        End If
    End Sub
    Private Sub txtTelFij_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelFij.KeyPress

        'Condicional que evalua que la tecla pulsada sea un número 
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
            MessageBox.Show("Introduzca sólo valores númericos")
        End If
    End Sub

    Private Sub ModificarProveedor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class