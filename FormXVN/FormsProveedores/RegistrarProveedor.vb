Imports CapaNE
Imports CapaLN
Public Class RegistrarProveedor
    Dim idProv As Integer
    Dim objProvLN As New ProveedoresLN
    Dim objProvNe As New ClaseProveedor

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Dim idProv As Integer
        Dim resp As Integer
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
                                Dim ds3 As New DataSet
                                Dim objp As New ProveedoresLN
                                ds3 = objp.BuscarCUIT(txtNumCuit.Text)
                                If ds3.Tables(0).Rows.Count > 0 Then
                                    MessageBox.Show("El CUIT ya fue registrado. Verifique por favor")
                                Else
                                    If txtNumCuit.TextLength < 11 Then
                                        MessageBox.Show("Debe ingresar un número de Cuit válido")
                                    Else
                                        resp = MessageBox.Show("¿Confirma Guardar todos los datos ingresados?...", "Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                        If resp = vbYes Then
                                            Dim objProvNe As New ClaseProveedor
                                            Dim objDire As New ClaseDireccion
                                            objProvNe = New ClaseProveedor()
                                            objProvNe.IdCuit = txtNumCuit.Text
                                            objProvNe.NomRaz = txtNombre.Text
                                            objProvNe.TelFijo = txtTelFij.Text
                                            objProvNe.telCelular = txtCel.Text
                                            objProvNe.Email = txtemail.Text
                                            objDire = New ClaseDireccion()
                                            objDire.Pais = cmbPais.Text
                                            objDire.Provincia = txtProvincia.Text
                                            objDire.Ciudad = txtCiudad.Text
                                            objDire.Barrio = txtBarrio.Text
                                            objDire.Calle = txtCalle.Text
                                            objDire.NumCalle = txtNro.Text
                                            objDire.Piso = cmbPiso.Text
                                            objDire.Dpto = txtDepto.Text

                                            idProv = objProvLN.InsertarProv(objProvNe)
                                            objDire.IdProv = idProv
                                            objProvLN.insertarDireProv(objDire)
                                            MsgBox("Los datos ingresados se guardaron Correctamente")
                                            Dim ds As DataSet
                                            Dim objProv As New ProveedoresLN

                                            ds = objProv.cargaGrilla
                                            Proveedores.dgvProv.DataSource = ds.Tables(0)
                                            Proveedores.dgvProv.Columns(5).Visible = False

                                            Me.Close()
                                        End If
                                    End If
                                End If
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

    Private Sub txtNombre_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre.KeyPress
        'Condicional que evalua que la tecla pulsada sea un número 
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
            MessageBox.Show("Introduzca sólo letras")
        End If
    End Sub

    Private Sub txtProvincia_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProvincia.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
            MessageBox.Show("Introduzca sólo letras")
        End If
    End Sub


    Private Sub txtCiudad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCiudad.KeyPress
        If Char.IsLetter(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
            MessageBox.Show("Introduzca sólo letras")
        End If
    End Sub

    Private Sub txtNro_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNro.KeyPress
        If Char.IsNumber(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsSeparator(e.KeyChar) Then
            e.Handled = False
        Else : e.Handled = True
            MessageBox.Show("Introduzca sólo letras")
        End If
    End Sub

    Private Sub txtNumCuit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumCuit.TextChanged
        txtNumCuit.MaxLength = 11
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumCuit.KeyPress

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

    Private Sub txtTelFij_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTelFij.TextChanged
        txtTelFij.MaxLength = 10
    End Sub

    Private Sub txtCel_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCel.TextChanged
        txtCel.MaxLength = 10
    End Sub

    Private Sub RegistrarProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class