Imports System
Imports System.IO
Imports CapaLN
Imports CapaNE
Imports capaDA
Imports System.Data.SqlClient
Public Class BackupRestore
    Private con2 As New SqlConnection
    Private com As New SqlCommand



    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()

    End Sub

    Private Sub BackupRestore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TextBox1.Enabled = False
        MessageBox.Show("Este módulo debería ser consultado o manupulado por el Administrador del Sistema")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        SaveFileDialog1.Filter = "SQL backup files|*.bak"
        SaveFileDialog1.FileName = TextBox1.Text & "-" & Today.Date.ToString("dd-MM-yyyyy") & "-" & TimeOfDay.ToString("h-mm") & ".bak"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox2.Text = SaveFileDialog1.FileName
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox2.Text = "" Then
            MessageBox.Show("Debe seleccionar una ruta para guardar el backup")
        Else



            Try
                'Verifica que exista la carpeta, en caso contrario la crea
                'If Not Directory.Exists("C:\BackupIC2") Then
                '    Directory.CreateDirectory("C:\BackupIC2")
                'End If

                Process.Start("cmd", "/k" & "sqlcmd -S localhost -E -Q ""BACKUP DATABASE [" & "INSUMOSCOMPUTACION" & "] TO DISK='" & TextBox2.Text & "'""")
                'Process.Start("cmd", "exit")
                MessageBox.Show("Se realizó el Backup")
            Catch ex As Exception
                MessageBox.Show(Err.Description)
            End Try
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        OpenFileDialog1.Filter = "SQL Backup Files|*.bak"
        OpenFileDialog1.FileName = ""

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            TextBox3.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim conString As String = "server=localhost ; database=master;Integrated Security=True"

        'Dim conexion As New SqlClient.SqlConnection
        'conexion.ConnectionString = conString

        'conexion.Open()
        Dim sql As String = " DECLARE @DBName VARCHAR(50)
DECLARE @spidstr VARCHAR(8000)
DECLARE @ConnKilled SMALLINT
 
SET @ConnKilled = 0
SET @spidstr = ''
SET @DBName = 'INSUMOSCOMPUTACION'
 
IF Db_id(@DBName) < 4
BEGIN
	PRINT 'Connections to system databases cannot be killed'
 
	RETURN
END
 
SELECT @spidstr = COALESCE(@spidstr, ',') + 'kill ' + CONVERT(VARCHAR, spid) + '; '
FROM master..sysprocesses
WHERE dbid = Db_id(@DBName)
 
IF Len(@spidstr) > 0
BEGIN
	EXEC (@spidstr)
 
	SELECT @ConnKilled = Count(1)
	FROM master..sysprocesses
	WHERE dbid = Db_id(@DBName)
END"

        Using cn As New SqlConnection(conString)
            cn.Open()
            Dim cmd As New SqlCommand(sql, cn)
            cmd.ExecuteNonQuery()
        End Using

        'Process.Start("cmd", "/k" & "Sqlcmd -S localhost -E -Q ""RESTORE DATABASE [" & TextBox4.Text & "] FROM DISK = '" & TextBox3.Text & "' WITH MOVE 'XVN' TO 'C:\INSUMOSCOMPUTACION\" & TextBox4.Text & ".mdf', MOVE 'XVN_log' TO 'C:\INSUMOSCOMPUTACION\" & TextBox4.Text & "_log.ldf'""")

        Process.Start("cmd", "/k" & "Sqlcmd -S localhost -E -Q ""RESTORE DATABASE [INSUMOSCOMPUTACION] FROM DISK = '" & TextBox3.Text & "'""")
        MessageBox.Show("Se restauró la base")
    End Sub


End Class