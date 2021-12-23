Imports CapaNE
Imports CapaLN
Public Class RegistrarUsuario
    Dim objUsuarioLN As New UsuariosLN
    Private Sub RegistrarUsuario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblEstado.Visible = False
    End Sub
    Sub Inicio()
        ComboTipoDoc.Text = "Seleccione"
        cbotipoUsuario.Text = "Seleccione"

    End Sub

    Private Sub BtnGuardUs_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardUs.Click
        Dim idUsuar As Integer
        Dim resp As Integer
        If txtNom.Text = "" Then
            MessageBox.Show("Debe ingresar un Nombre")
        Else
            If txtApellido.Text = "" Then
                MessageBox.Show("Debe ingresar un Apellido")
            Else
                If txtusuar.Text = "" Then
                    MessageBox.Show("Debe ingresar un Nombre de Usuario")
                Else
                    Dim dsu As New DataSet
                    Dim objUs As New UsuariosLN
                    dsu = objUsuarioLN.buscarUsuario2(txtusuar.Text)
                    If dsu.Tables(0).Rows.Count > 0 Then
                        MessageBox.Show("El nombre de Usuario ya se encuentra registrado en el sistema")
                    Else
                        If txtNumDoc.Text = "" Then
                        MessageBox.Show("Debe ingresar un Número de Documento")
                    Else
                        If ComboTipoDoc.Text = "" Then
                            MessageBox.Show("Debe Seleccionar un Tipo de Documento")
                        Else
                            If cbotipoUsuario.Text = "" Then
                                MessageBox.Show("Debe seleccionar un Tipo de Usuario")
                            Else
                                If txtcontras.Text = "" Then
                                    MessageBox.Show("Debe ingresar una contraseña")
                                Else

                                    resp = MessageBox.Show("¿Confirma Guardar todos los datos ingresados?...", "Nuevo", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                                        If resp = vbYes Then
                                            Dim objUsuarioNe As ClaseUsuariosNE
                                            Dim ObjDoc As New ClaseDocumento

                                            objUsuarioNe = New ClaseUsuariosNE()
                                            objUsuarioNe.NomUsuario = txtusuar.Text
                                            objUsuarioNe.PAss = txtcontras.Text.ToUpper
                                            objUsuarioNe.TipoUsuario = cbotipoUsuario.Text
                                            objUsuarioNe.Nombre = txtNom.Text
                                            objUsuarioNe.Apellido = txtApellido.Text
                                            objUsuarioNe.IdUsuario = lblEstado.Text

                                            ObjDoc = New ClaseDocumento()
                                            ObjDoc.IdUSuario = txtusuar.Text
                                            ObjDoc.TipoDoc = ComboTipoDoc.Text
                                            ObjDoc.NumDoc = txtNumDoc.Text

                                            idUsuar = objUsuarioLN.InsertarDatosUSuario(objUsuarioNe)
                                            'ObjDoc.IdUSuario = idUsuar
                                            objUsuarioLN.insertarDocu(ObjDoc)
                                            MsgBox("Los datos ingresados se guardaron Correctamente")
                                        End If
                                        Dim ds As DataSet
                                        Dim objusuar As New UsuariosLN
                                        Dim form As New Usuarios
                                        ds = objusuarioLN.cargaGrilla
                                        Usuarios.dgvUsuarios.DataSource = ds.Tables(0)
                                        Me.Close()
                                        Inicio()
                                        txtApellido.Clear()
                                        txtusuar.Clear()
                                        txtNom.Clear()
                                        txtNumDoc.Clear()
                                        txtcontras.Clear()
                                        Me.Close()
                                    End If
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
    Private Sub TextBox1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress

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

    Private Sub txtNumDoc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumDoc.TextChanged
        txtNumDoc.MaxLength = 8
    End Sub

End Class