Imports CapaNE
Imports CapaLN
Imports System
Imports System.Net
Imports System.Net.Mail
Imports System.Data.SqlClient
Public Class EnviarMail
    Public idOrdTrab As Integer
    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim _Message As New MailMessage()
        Dim _SMTP As New SmtpClient

        _SMTP.Credentials = New NetworkCredential(TextBox4.Text, TextBox5.Text)
        _SMTP.EnableSsl = True
        _SMTP.Host = TextBox6.Text
        _SMTP.Port = TextBox7.Text
        _Message.From = New MailAddress(TextBox4.Text)
        _Message.To.Add(TextBox1.Text)
        _Message.Priority = MailPriority.High
        _Message.Body = TextBox3.Text
        _Message.Subject = TextBox2.Text

        _SMTP.Send(_Message)

        Dim objALertLN As New OrdenDeTrabajoLN
        Dim objAlertNE As New ClaseOrdenDeTRabajo
        objAlertNE.idOrdenTRab = idOrdTrab
        objAlertNE.AlertEntrEquip = Date.Now
        objALertLN.modificarAlerta(objAlertNE)
        Me.Close()

    End Sub

    Private Sub EnviarMail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim objemailLN As New OrdenDeTrabajoLN
        Dim ds As New DataSet
        ds = objemailLN.cargarconfiguraciones()
        If ds.Tables(0).Rows.Count >= 1 Then
            TextBox4.Text = ds.Tables(0).Rows(0).Item(0)
            TextBox5.Text = ds.Tables(0).Rows(0).Item(1)
            TextBox6.Text = ds.Tables(0).Rows(0).Item(2)
            TextBox7.Text = ds.Tables(0).Rows(0).Item(3)
        End If
        If XVN.Label3.Text = "Limitada" Then
            TextBox4.Enabled = False
            TextBox5.Enabled = False
            TextBox6.Enabled = False
            TextBox7.Enabled = False
            BtnNuevo.Enabled = False
        End If
    End Sub

    Private Sub BtnNuevo_Click(sender As Object, e As EventArgs) Handles BtnNuevo.Click

        Dim objemail As New ClaseEmail
        Dim objemailLN As New OrdenDeTrabajoLN
        Dim ds As New DataSet
        If TextBox4.Text <> "" And TextBox5.Text <> "" And TextBox6.Text <> "" And TextBox7.Text <> "" Then
            objemail.mail = TextBox4.Text
            objemail.contrasena = TextBox5.Text
            objemail.smtp = TextBox6.Text
            objemail.puerto = TextBox7.Text
            objemailLN.InsertarModifConfigEMAIL(objemail)

            MessageBox.Show("Los datos se guardaron correctamente")
        Else
            MessageBox.Show("Debe ingresar todos los datos")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
End Class