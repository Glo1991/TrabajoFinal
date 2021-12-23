<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegistrarUsuario
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RegistrarUsuario))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbotipoUsuario = New System.Windows.Forms.ComboBox()
        Me.txtNom = New System.Windows.Forms.TextBox()
        Me.BtnGuardUs = New System.Windows.Forms.Button()
        Me.txtApellido = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtusuar = New System.Windows.Forms.TextBox()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.txtcontras = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.ComboTipoDoc = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.gbBusqueda = New System.Windows.Forms.GroupBox()
        Me.gbBusqueda.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 37)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 215)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 18)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Tipo"
        '
        'cbotipoUsuario
        '
        Me.cbotipoUsuario.FormattingEnabled = True
        Me.cbotipoUsuario.Items.AddRange(New Object() {"Administrador", "Limitada"})
        Me.cbotipoUsuario.Location = New System.Drawing.Point(109, 210)
        Me.cbotipoUsuario.Margin = New System.Windows.Forms.Padding(4)
        Me.cbotipoUsuario.Name = "cbotipoUsuario"
        Me.cbotipoUsuario.Size = New System.Drawing.Size(199, 26)
        Me.cbotipoUsuario.TabIndex = 16
        '
        'txtNom
        '
        Me.txtNom.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNom.Location = New System.Drawing.Point(109, 26)
        Me.txtNom.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(199, 24)
        Me.txtNom.TabIndex = 23
        '
        'BtnGuardUs
        '
        Me.BtnGuardUs.Image = CType(resources.GetObject("BtnGuardUs.Image"), System.Drawing.Image)
        Me.BtnGuardUs.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnGuardUs.Location = New System.Drawing.Point(177, 349)
        Me.BtnGuardUs.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnGuardUs.Name = "BtnGuardUs"
        Me.BtnGuardUs.Size = New System.Drawing.Size(122, 66)
        Me.BtnGuardUs.TabIndex = 24
        Me.BtnGuardUs.Text = "Guardar"
        Me.BtnGuardUs.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnGuardUs.UseVisualStyleBackColor = True
        '
        'txtApellido
        '
        Me.txtApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApellido.Location = New System.Drawing.Point(109, 62)
        Me.txtApellido.Margin = New System.Windows.Forms.Padding(4)
        Me.txtApellido.Name = "txtApellido"
        Me.txtApellido.Size = New System.Drawing.Size(199, 24)
        Me.txtApellido.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 252)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 18)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Contraseña"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 109)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(60, 18)
        Me.Label5.TabIndex = 27
        Me.Label5.Text = "Usuario"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 72)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 18)
        Me.Label6.TabIndex = 28
        Me.Label6.Text = "Apellido"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 180)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 18)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Num de Doc"
        '
        'txtusuar
        '
        Me.txtusuar.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtusuar.Location = New System.Drawing.Point(109, 100)
        Me.txtusuar.Margin = New System.Windows.Forms.Padding(4)
        Me.txtusuar.Name = "txtusuar"
        Me.txtusuar.Size = New System.Drawing.Size(199, 24)
        Me.txtusuar.TabIndex = 30
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Location = New System.Drawing.Point(109, 170)
        Me.txtNumDoc.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(199, 24)
        Me.txtNumDoc.TabIndex = 31
        '
        'txtcontras
        '
        Me.txtcontras.Location = New System.Drawing.Point(109, 248)
        Me.txtcontras.Margin = New System.Windows.Forms.Padding(4)
        Me.txtcontras.Name = "txtcontras"
        Me.txtcontras.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtcontras.Size = New System.Drawing.Size(199, 24)
        Me.txtcontras.TabIndex = 32
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 145)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(89, 18)
        Me.Label8.TabIndex = 34
        Me.Label8.Text = "Tipo de Doc"
        '
        'ComboTipoDoc
        '
        Me.ComboTipoDoc.FormattingEnabled = True
        Me.ComboTipoDoc.Items.AddRange(New Object() {"Dni", "LC", "LE", "Pasaporte"})
        Me.ComboTipoDoc.Location = New System.Drawing.Point(109, 133)
        Me.ComboTipoDoc.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboTipoDoc.Name = "ComboTipoDoc"
        Me.ComboTipoDoc.Size = New System.Drawing.Size(199, 26)
        Me.ComboTipoDoc.TabIndex = 35
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(321, 349)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(122, 66)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "Cancelar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.ForeColor = System.Drawing.Color.DarkRed
        Me.Label27.Location = New System.Drawing.Point(320, 22)
        Me.Label27.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(18, 24)
        Me.Label27.TabIndex = 74
        Me.Label27.Text = "*"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkRed
        Me.Label3.Location = New System.Drawing.Point(320, 62)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 24)
        Me.Label3.TabIndex = 75
        Me.Label3.Text = "*"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.DarkRed
        Me.Label9.Location = New System.Drawing.Point(320, 104)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(18, 24)
        Me.Label9.TabIndex = 76
        Me.Label9.Text = "*"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.DarkRed
        Me.Label10.Location = New System.Drawing.Point(320, 140)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(18, 24)
        Me.Label10.TabIndex = 77
        Me.Label10.Text = "*"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.DarkRed
        Me.Label11.Location = New System.Drawing.Point(320, 173)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(18, 24)
        Me.Label11.TabIndex = 78
        Me.Label11.Text = "*"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.DarkRed
        Me.Label12.Location = New System.Drawing.Point(320, 208)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(18, 24)
        Me.Label12.TabIndex = 79
        Me.Label12.Text = "*"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.DarkRed
        Me.Label13.Location = New System.Drawing.Point(320, 245)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(18, 24)
        Me.Label13.TabIndex = 80
        Me.Label13.Text = "*"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.DarkRed
        Me.Label14.Location = New System.Drawing.Point(140, 313)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(18, 24)
        Me.Label14.TabIndex = 81
        Me.Label14.Text = "*"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 320)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(124, 18)
        Me.Label15.TabIndex = 82
        Me.Label15.Text = "Los campos con "
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(171, 320)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(118, 18)
        Me.Label16.TabIndex = 83
        Me.Label16.Text = "son obligatorios."
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(9, 486)
        Me.lblEstado.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(16, 18)
        Me.lblEstado.TabIndex = 84
        Me.lblEstado.Text = "1"
        '
        'gbBusqueda
        '
        Me.gbBusqueda.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbBusqueda.Controls.Add(Me.lblEstado)
        Me.gbBusqueda.Controls.Add(Me.Label16)
        Me.gbBusqueda.Controls.Add(Me.Label15)
        Me.gbBusqueda.Controls.Add(Me.Label14)
        Me.gbBusqueda.Controls.Add(Me.Label13)
        Me.gbBusqueda.Controls.Add(Me.Label12)
        Me.gbBusqueda.Controls.Add(Me.Label11)
        Me.gbBusqueda.Controls.Add(Me.Label10)
        Me.gbBusqueda.Controls.Add(Me.Label9)
        Me.gbBusqueda.Controls.Add(Me.Label3)
        Me.gbBusqueda.Controls.Add(Me.Label27)
        Me.gbBusqueda.Controls.Add(Me.Button1)
        Me.gbBusqueda.Controls.Add(Me.ComboTipoDoc)
        Me.gbBusqueda.Controls.Add(Me.Label8)
        Me.gbBusqueda.Controls.Add(Me.txtcontras)
        Me.gbBusqueda.Controls.Add(Me.txtNumDoc)
        Me.gbBusqueda.Controls.Add(Me.txtusuar)
        Me.gbBusqueda.Controls.Add(Me.Label7)
        Me.gbBusqueda.Controls.Add(Me.Label6)
        Me.gbBusqueda.Controls.Add(Me.Label5)
        Me.gbBusqueda.Controls.Add(Me.Label2)
        Me.gbBusqueda.Controls.Add(Me.txtApellido)
        Me.gbBusqueda.Controls.Add(Me.BtnGuardUs)
        Me.gbBusqueda.Controls.Add(Me.txtNom)
        Me.gbBusqueda.Controls.Add(Me.cbotipoUsuario)
        Me.gbBusqueda.Controls.Add(Me.Label4)
        Me.gbBusqueda.Controls.Add(Me.Label1)
        Me.gbBusqueda.Location = New System.Drawing.Point(305, 30)
        Me.gbBusqueda.Margin = New System.Windows.Forms.Padding(4)
        Me.gbBusqueda.Name = "gbBusqueda"
        Me.gbBusqueda.Padding = New System.Windows.Forms.Padding(4)
        Me.gbBusqueda.Size = New System.Drawing.Size(454, 432)
        Me.gbBusqueda.TabIndex = 10
        Me.gbBusqueda.TabStop = False
        Me.gbBusqueda.Text = "Usuarios"
        '
        'RegistrarUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1076, 664)
        Me.Controls.Add(Me.gbBusqueda)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "RegistrarUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Registrar Usuario"
        Me.gbBusqueda.ResumeLayout(False)
        Me.gbBusqueda.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbotipoUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents txtNom As System.Windows.Forms.TextBox
    Friend WithEvents BtnGuardUs As System.Windows.Forms.Button
    Friend WithEvents txtApellido As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtusuar As System.Windows.Forms.TextBox
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents txtcontras As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ComboTipoDoc As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblEstado As System.Windows.Forms.Label
    Friend WithEvents gbBusqueda As System.Windows.Forms.GroupBox
End Class
