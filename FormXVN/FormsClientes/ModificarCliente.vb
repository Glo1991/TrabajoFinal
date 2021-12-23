Imports CapaNE
Imports CapaLN
Public Class ModificarCliente

    Public idAlumnaaa As Integer

    Dim objAlumnaLN As New ClienteLN
    Dim objAlumnaNe As New ClaseCliente

    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Dim objAlumnaLN As New ClienteLN
        Dim objAlumnaNe As New ClaseCliente
        Dim doc As New ClaseDocumento
        Dim dire As New ClaseDireccion
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
                        objAlumnaNe.NomAlum = txtNombre.Text
                        objAlumnaNe.ApellAlum = txtApellido.Text
                        objAlumnaNe.FechaNac = dtpFecNac.Text
                        objAlumnaNe.FechaIngreso = dtpFecIng.Text
                        objAlumnaNe.TelFijo = txtTelFij.Text
                        objAlumnaNe.telCelular = txtCel.Text
                        objAlumnaNe.Email = txtemail.Text
                        objAlumnaNe.EdadAlum = txtEdad.Text

                        doc.TipoDoc = cmbTipoDni.Text
                        doc.NumDoc = txtNumDoc.Text

                        dire.Pais = cmbPais.Text
                        dire.Provincia = txtProvincia.Text
                        dire.Ciudad = txtCiudad.Text
                        dire.Barrio = txtBarrio.Text
                        dire.Calle = txtCalle.Text
                        dire.NumCalle = txtNro.Text
                        dire.Piso = cmbPiso.Text
                        dire.Dpto = txtDepto.Text
                        dire.Lote = txtLote.Text
                        dire.Manzana = txtmanzana.Text


                        objAlumnaNe.IdCliente = idAlumnaaa
                        objAlumnaLN.modificarAlum(objAlumnaNe)
                        doc.IDCliente = idAlumnaaa
                        objAlumnaLN.modificarDocum(doc)
                        dire.IdCliente = idAlumnaaa
                        objAlumnaLN.modificarDireAlu(dire)

                        Me.Close()
                        Dim ds As DataSet

                        Dim frm As New Clientes
                        frm.MdiParent = XVN
                        'frm.Show()
                        ds = objAlumnaLN.cargaGrilla
                        frm.dgvAlumnos.DataSource = ds.Tables(0)
                        frm.dgvAlumnos.Columns(7).Visible = False
                        Me.Close()
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
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
    Private Sub TextBox3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCel.KeyPress

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
    Private Sub TextBox5_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelFij.KeyPress

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

    Private Sub ModificarCliente_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class