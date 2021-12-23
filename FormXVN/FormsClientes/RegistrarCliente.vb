Imports CapaNE
Imports CapaLN
Public Class RegistrarCliente
    Public idAlumnaaa As Integer

    Dim objAlumnaLN As New ClienteLN
    Dim objAlumnaNe As New ClaseCliente
    Function Calculo_Edad(ByVal fechaSeleccionada As Date) As Single
        Dim edad As Single

        If fechaSeleccionada = dtpFecNac.Value Then
            edad = DateDiff(DateInterval.Year, fechaSeleccionada, Date.Today)
            If dtpFecNac.Value = Nothing Then
                edad = Nothing
            End If
        End If
        Return edad
    End Function
    Private Sub BtnNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnNuevo.Click
        Dim idAlumna As Integer
        Dim resp As Integer
        If txtNombre.Text = "" Then
            MessageBox.Show("Debe ingresar un Nombre")
        Else
            If txtApellido.Text = "" Then
                MessageBox.Show("Debe ingresar un Apellido")
            Else
                If cmbTipoDni.Text = "" Then
                    MessageBox.Show("Debe seleccionar un Tipo de Documento")
                Else
                    If txtNumDoc.Text = "" Then
                        MessageBox.Show("Debe ingresar un Número de Documento")
                    Else
                        If txtEdad.Text = "" Then
                            MessageBox.Show("Debe seleccionar una fecha de nacimiento válida")
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
                                        Dim ds2 As New DataSet
                                        Dim objcl As New ClienteLN
                                        ds2 = objcl.BuscarDoc(txtNumDoc.Text)
                                        If ds2.Tables(0).Rows.Count Then
                                            MessageBox.Show("El número de Documento ya se encuentra Registrado")
                                        Else

                                            resp = MessageBox.Show("¿Confirma Guardar todos los datos ingresados?...", "Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                        If resp = vbYes Then
                                                    If txtEdad.Text = "" Then
                                                        MsgBox("Error en la registración")
                                                    Else
                                                        Dim objAlumnaNe As ClaseCliente
                                                        Dim ObjDoc As New ClaseDocumento
                                                        Dim objDire As New ClaseDireccion
                                                        objAlumnaNe = New ClaseCliente()
                                                        objAlumnaNe.NomAlum = txtNombre.Text
                                                        objAlumnaNe.ApellAlum = txtApellido.Text.ToUpper
                                                        objAlumnaNe.FechaNac = CDate(dtpFecNac.Text)
                                                        objAlumnaNe.FechaIngreso = CDate(dtpFecIng.Text)
                                                        objAlumnaNe.TelFijo = txtTelFij.Text
                                                        objAlumnaNe.telCelular = txtCel.Text
                                                        objAlumnaNe.Email = txtemail.Text
                                                        objAlumnaNe.EdadAlum = txtEdad.Text
                                                        ObjDoc = New ClaseDocumento()
                                                        ObjDoc.TipoDoc = cmbTipoDni.Text
                                                        ObjDoc.NumDoc = txtNumDoc.Text
                                                        objDire = New ClaseDireccion()
                                                        objDire.Pais = cmbPais.Text
                                                        objDire.Provincia = txtProvincia.Text
                                                        objDire.Ciudad = txtCiudad.Text
                                                        objDire.Barrio = txtBarrio.Text
                                                        objDire.Calle = txtCalle.Text
                                                        objDire.NumCalle = txtNro.Text
                                                        objDire.Piso = cmbPiso.Text
                                                        objDire.Dpto = txtDepto.Text
                                                        objDire.Lote = txtLote.Text
                                                        objDire.Manzana = txtmanzana.Text

                                                        idAlumna = objAlumnaLN.InsertarAlumna(objAlumnaNe)
                                                        ObjDoc.IDCliente = idAlumna
                                                        objAlumnaLN.insertarDocumAlum(ObjDoc)
                                                        objDire.IdCliente = idAlumna
                                                        objAlumnaLN.insertarDireAlum(objDire)
                                                        MsgBox("Los datos ingresados se guardaron Correctamente")
                                                        Dim ds As DataSet
                                                        Dim objalumn As New ClienteLN

                                                        ds = objalumn.cargaGrilla
                                                        Clientes.dgvAlumnos.DataSource = ds.Tables(0)
                                                        Clientes.dgvAlumnos.Columns(7).Visible = False

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
                End If
            End If
        End If
    End Sub


    Private Sub RegistrarAlumna_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtEdad.Enabled = False
        dtpFecIng.Enabled = False
    End Sub

    Private Sub BtnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub

    Private Sub txtNumDoc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumDoc.TextChanged
        txtNumDoc.MaxLength = 8
    End Sub
    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress

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

    Private Sub dtpFecNac_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpFecNac.ValueChanged
        Dim años As Integer
        'años = Calculo_Edad(dtpFecNac.Value)
        'txtEdad.Text = años 
        'txtEdad.Enabled = False
        'dtpFecNac.MaxDate = Date.Today
        'dtpFecNac.MinDate = DateAdd(DateInterval.Year, 18, Date.Today)
        If (Date.Today.Year - dtpFecNac.Value.Year) >= 18 Then
            años = Calculo_Edad(dtpFecNac.Value)
            txtEdad.Text = años
            txtEdad.Enabled = False
        Else
            MessageBox.Show("Cliente menor de 18 años, no es posible registrar")
            txtEdad.Clear()
            txtEdad.Enabled = False
        End If

    End Sub

    Private Sub txtEdad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtEdad.TextChanged
        If txtEdad.Text <= 18 Or txtEdad.Text = "" Then
            cmbPais.Enabled = False
            txtProvincia.Enabled = False
            txtCiudad.Enabled = False
            txtBarrio.Enabled = False
            txtCalle.Enabled = False
            txtNro.Enabled = False
            cmbPiso.Enabled = False
            txtDepto.Enabled = False
            txtLote.Enabled = False
            txtmanzana.Enabled = False
            txtTelFij.Enabled = False
            txtCel.Enabled = False
            txtemail.Enabled = False
            txtEdad.Enabled = False
            txtNumDoc.Text = Nothing
        Else
            cmbPais.Enabled = True
            txtProvincia.Enabled = True
            txtCiudad.Enabled = True
            txtBarrio.Enabled = True
            txtCalle.Enabled = True
            txtNro.Enabled = True
            cmbPiso.Enabled = True
            txtDepto.Enabled = True
            txtLote.Enabled = True
            txtmanzana.Enabled = True
            txtTelFij.Enabled = True
            txtCel.Enabled = True
            txtemail.Enabled = True
            txtEdad.Enabled = True
        End If

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

    Private Sub txtApellido_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApellido.KeyPress
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


End Class