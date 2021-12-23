Imports CapaNE
Imports CapaLN
Public Class Login
    Public idUsuarioo As Integer
    Private Sub btningresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btningresar.Click
        Dim objUsuarioadmLN As New UsuariosLN
        Dim objusuarlimLN As New UsuariosLN
        Dim objUsuarioNE As New ClaseUsuariosNE
        Dim objusuarlimNe As New ClaseUsuariosNE
        Dim ds As New DataSet
        objUsuarioNE.NomUsuario = txtlogin.Text

        objUsuarioNE.PAss = txtpassword.Text
        Dim objUsuarioadmLN2 As New UsuariosLN



        If objUsuarioadmLN.VAlidarUsuar(objUsuarioNE) = True And Label3.Text = "Administrador" And Label4.Text = "1" Then
            Dim ds1 As New DataSet
            ds1 = objUsuarioadmLN2.buscarUsuario2(txtlogin.Text)
            Me.Hide()
            XVN.Label1.Text = ds1.Tables(0).Rows(0).Item(1)
            XVN.Label2.Text = ds1.Tables(0).Rows(0).Item(4) + " " + ds1.Tables(0).Rows(0).Item(5)
            XVN.Label3.Text = ds1.Tables(0).Rows(0).Item(3)
            Permisos()
            XVN.Show()
        ElseIf objusuarlimLN.VAlidarUsuar(objUsuarioNE) = True And Label3.Text = "Limitada" And Label4.Text = "1" Then

            Me.Hide()

            Dim ds1 As New DataSet
            ds1 = objUsuarioadmLN2.buscarUsuario2(txtlogin.Text)
            XVN.Label1.Text = ds1.Tables(0).Rows(0).Item(1)
            XVN.Label2.Text = ds1.Tables(0).Rows(0).Item(4) + " " + ds1.Tables(0).Rows(0).Item(5)
            XVN.Label3.Text = ds1.Tables(0).Rows(0).Item(3)
            Permisos()
            XVN.ShowDialog()

        ElseIf objUsuarioadmLN.VAlidarUsuar(objUsuarioNE) = False And Label4.Text = "2" Then

            MsgBox("Su Usuario se encuentra Inactivo")
            txtpassword.Text = ""
        ElseIf objUsuarioadmLN.VAlidarUsuar(objUsuarioNE) = False Then
            MsgBox("Usuario y/o contraseña incorrectos")
            txtpassword.Text = ""
        End If

    End Sub

    Private Sub txtlogin_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtlogin.TextChanged
        Dim objUsuarioLN As New UsuariosLN
        Dim ds As New DataSet
        Dim dsestado As New DataSet
        Dim objUsuarioNe As New ClaseUsuariosNE

        objUsuarioNe.NomUsuario = txtlogin.Text

        If objUsuarioLN.ExisteUsuar(objUsuarioNe) = True Then
            ds = objUsuarioLN.buscarTipoUsuario(txtlogin.Text)
            Label3.Visible = True
            Label3.Text = ds.Tables(0).Rows(0)(3).ToString
            dsestado = objUsuarioLN.buscarTipoUsuario(txtlogin.Text)
            Label4.Text = dsestado.Tables(0).Rows(0)(6).ToString
        Else
            Label3.Text = Nothing

        End If
    End Sub

    Private Sub Btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Btncancelar.Click
        Me.Close()
        End
    End Sub

    Private Sub Login_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label3.Visible = False
        Label4.Visible = False
    End Sub
    Public Sub Permisos()
        If XVN.Label3.Text = "Limitada" Then
            XVN.AdministradorDeUsuariosToolStripMenuItem1.Enabled = False
            XVN.ModificaciónMasivaToolStripMenuItem1.Enabled = False
            'XVN.AdministrarVentasToolStripMenuItem.Enabled = False
            XVN.BackupYRestoreToolStripMenuItem.Enabled = False
            'XVN.PuntosDeVentasToolStripMenuItem.Enabled = False
            'BuscarOrdTrab.Button6.Enabled = False
        Else
            XVN.AdministradorDeUsuariosToolStripMenuItem1.Enabled = True
            XVN.ModificaciónMasivaToolStripMenuItem1.Enabled = True
            'XVN.AdministrarVentasToolStripMenuItem.Enabled = True
            XVN.BackupYRestoreToolStripMenuItem.Enabled = True
            XVN.PuntosDeVentasToolStripMenuItem.Enabled = True
            'BuscarOrdTrab.Button6.Enabled = True
        End If
    End Sub

    Private Sub txtpassword_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtpassword.KeyPress
        If (AscW(e.KeyChar) = 13) Then
            e.Handled = True ' Para que no suene el pitido al pulsar la tecla Enter.
            Dim objUsuarioadmLN As New UsuariosLN
            Dim objusuarlimLN As New UsuariosLN
            Dim objUsuarioNE As New ClaseUsuariosNE
            Dim objusuarlimNe As New ClaseUsuariosNE
            Dim ds As New DataSet
            objUsuarioNE.NomUsuario = txtlogin.Text
            objusuarlimNe.NomUsuario = txtlogin.Text
            objusuarlimNe.PAss = txtpassword.Text
            objUsuarioNE.PAss = txtpassword.Text
            Dim objUsuarioadmLN2 As New UsuariosLN



            If objUsuarioadmLN.VAlidarUsuar(objUsuarioNE) = True And Label3.Text = "Administrador" And Label4.Text = "1" Then
                Dim ds1 As New DataSet
                ds1 = objUsuarioadmLN2.buscarUsuario2(txtlogin.Text)
                Me.Hide()
                XVN.Label1.Text = ds1.Tables(0).Rows(0).Item(1)
                XVN.Label2.Text = ds1.Tables(0).Rows(0).Item(4) + " " + ds1.Tables(0).Rows(0).Item(5)
                XVN.Label3.Text = ds1.Tables(0).Rows(0).Item(3)
                Permisos()
                XVN.Show()
            ElseIf objusuarlimLN.VAlidarUsuar(objUsuarioNE) = True And Label3.Text = "Limitada" And Label4.Text = "1" Then

                Me.Hide()

                Dim ds1 As New DataSet
                ds1 = objUsuarioadmLN2.buscarUsuario2(txtlogin.Text)
                XVN.Label1.Text = ds1.Tables(0).Rows(0).Item(1)
                XVN.Label2.Text = ds1.Tables(0).Rows(0).Item(4) + " " + ds1.Tables(0).Rows(0).Item(5)
                XVN.Label3.Text = ds1.Tables(0).Rows(0).Item(3)
                Permisos()
                XVN.ShowDialog()

            ElseIf objUsuarioadmLN.VAlidarUsuar(objUsuarioNE) = False And Label4.Text = "2" Then

                MsgBox("Su Usuario se encuentra Inactivo")
                txtpassword.Text = ""
            ElseIf objUsuarioadmLN.VAlidarUsuar(objUsuarioNE) = False Then
                MsgBox("Usuario y/o contraseña incorrectos")
                txtpassword.Text = ""
            End If

        End If
    End Sub
End Class