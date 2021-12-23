<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModificarUsuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ModificarUsuario))
        Me.gbBusqueda = New System.Windows.Forms.GroupBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.ComboTipoDoc = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtcontras = New System.Windows.Forms.TextBox()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.txtusuar = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtApellido = New System.Windows.Forms.TextBox()
        Me.BtnGuardUs = New System.Windows.Forms.Button()
        Me.txtNom = New System.Windows.Forms.TextBox()
        Me.cbotipoUsuario = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.gbBusqueda.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbBusqueda
        '
        Me.gbBusqueda.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.gbBusqueda.Location = New System.Drawing.Point(323, 52)
        Me.gbBusqueda.Margin = New System.Windows.Forms.Padding(4)
        Me.gbBusqueda.Name = "gbBusqueda"
        Me.gbBusqueda.Padding = New System.Windows.Forms.Padding(4)
        Me.gbBusqueda.Size = New System.Drawing.Size(422, 482)
        Me.gbBusqueda.TabIndex = 11
        Me.gbBusqueda.TabStop = False
        Me.gbBusqueda.Text = "Usuario"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(253, 317)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(122, 66)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "Cancelar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
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
        'txtcontras
        '
        Me.txtcontras.Location = New System.Drawing.Point(109, 248)
        Me.txtcontras.Margin = New System.Windows.Forms.Padding(4)
        Me.txtcontras.Name = "txtcontras"
        Me.txtcontras.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtcontras.Size = New System.Drawing.Size(199, 24)
        Me.txtcontras.TabIndex = 32
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Location = New System.Drawing.Point(109, 170)
        Me.txtNumDoc.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(199, 24)
        Me.txtNumDoc.TabIndex = 31
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
        'txtApellido
        '
        Me.txtApellido.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtApellido.Location = New System.Drawing.Point(109, 62)
        Me.txtApellido.Margin = New System.Windows.Forms.Padding(4)
        Me.txtApellido.Name = "txtApellido"
        Me.txtApellido.Size = New System.Drawing.Size(199, 24)
        Me.txtApellido.TabIndex = 25
        '
        'BtnGuardUs
        '
        Me.BtnGuardUs.Image = CType(resources.GetObject("BtnGuardUs.Image"), System.Drawing.Image)
        Me.BtnGuardUs.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnGuardUs.Location = New System.Drawing.Point(109, 317)
        Me.BtnGuardUs.Margin = New System.Windows.Forms.Padding(4)
        Me.BtnGuardUs.Name = "BtnGuardUs"
        Me.BtnGuardUs.Size = New System.Drawing.Size(122, 66)
        Me.BtnGuardUs.TabIndex = 24
        Me.BtnGuardUs.Text = "Guardar"
        Me.BtnGuardUs.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnGuardUs.UseVisualStyleBackColor = True
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
        'ModificarUsuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1076, 664)
        Me.Controls.Add(Me.gbBusqueda)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "ModificarUsuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Modificar Usuario"
        Me.gbBusqueda.ResumeLayout(False)
        Me.gbBusqueda.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents ComboTipoDoc As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtcontras As System.Windows.Forms.TextBox
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents txtusuar As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtApellido As System.Windows.Forms.TextBox
    Friend WithEvents BtnGuardUs As System.Windows.Forms.Button
    Friend WithEvents txtNom As System.Windows.Forms.TextBox
    Friend WithEvents cbotipoUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
