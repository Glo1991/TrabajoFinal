<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Habilitar_o_Deshabilitar_Usuario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Habilitar_o_Deshabilitar_Usuario))
        Me.gbBusqueda = New System.Windows.Forms.GroupBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtTipoUsuar = New System.Windows.Forms.TextBox()
        Me.txtTipoDoc = New System.Windows.Forms.TextBox()
        Me.btnInactivar = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.txtusuar = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtApellido = New System.Windows.Forms.TextBox()
        Me.txtNom = New System.Windows.Forms.TextBox()
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
        Me.gbBusqueda.Controls.Add(Me.TextBox1)
        Me.gbBusqueda.Controls.Add(Me.Label2)
        Me.gbBusqueda.Controls.Add(Me.txtTipoUsuar)
        Me.gbBusqueda.Controls.Add(Me.txtTipoDoc)
        Me.gbBusqueda.Controls.Add(Me.btnInactivar)
        Me.gbBusqueda.Controls.Add(Me.Label3)
        Me.gbBusqueda.Controls.Add(Me.Button1)
        Me.gbBusqueda.Controls.Add(Me.Label8)
        Me.gbBusqueda.Controls.Add(Me.txtNumDoc)
        Me.gbBusqueda.Controls.Add(Me.txtusuar)
        Me.gbBusqueda.Controls.Add(Me.Label7)
        Me.gbBusqueda.Controls.Add(Me.Label6)
        Me.gbBusqueda.Controls.Add(Me.Label5)
        Me.gbBusqueda.Controls.Add(Me.txtApellido)
        Me.gbBusqueda.Controls.Add(Me.txtNom)
        Me.gbBusqueda.Controls.Add(Me.Label4)
        Me.gbBusqueda.Controls.Add(Me.Label1)
        Me.gbBusqueda.Location = New System.Drawing.Point(324, 60)
        Me.gbBusqueda.Margin = New System.Windows.Forms.Padding(4)
        Me.gbBusqueda.Name = "gbBusqueda"
        Me.gbBusqueda.Padding = New System.Windows.Forms.Padding(4)
        Me.gbBusqueda.Size = New System.Drawing.Size(405, 412)
        Me.gbBusqueda.TabIndex = 12
        Me.gbBusqueda.TabStop = False
        Me.gbBusqueda.Text = "Usuario"
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.ForeColor = System.Drawing.Color.Black
        Me.TextBox1.Location = New System.Drawing.Point(109, 258)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(199, 24)
        Me.TextBox1.TabIndex = 42
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 262)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 18)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Estado"
        '
        'txtTipoUsuar
        '
        Me.txtTipoUsuar.Location = New System.Drawing.Point(109, 210)
        Me.txtTipoUsuar.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTipoUsuar.Name = "txtTipoUsuar"
        Me.txtTipoUsuar.Size = New System.Drawing.Size(199, 24)
        Me.txtTipoUsuar.TabIndex = 40
        '
        'txtTipoDoc
        '
        Me.txtTipoDoc.Location = New System.Drawing.Point(109, 134)
        Me.txtTipoDoc.Margin = New System.Windows.Forms.Padding(4)
        Me.txtTipoDoc.Name = "txtTipoDoc"
        Me.txtTipoDoc.Size = New System.Drawing.Size(199, 24)
        Me.txtTipoDoc.TabIndex = 39
        '
        'btnInactivar
        '
        Me.btnInactivar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnInactivar.Location = New System.Drawing.Point(109, 336)
        Me.btnInactivar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnInactivar.Name = "btnInactivar"
        Me.btnInactivar.Size = New System.Drawing.Size(125, 66)
        Me.btnInactivar.TabIndex = 38
        Me.btnInactivar.Text = "Habilitar/" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Deshabilitar"
        Me.btnInactivar.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(336, 22)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 18)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Label3"
        Me.Label3.Visible = False
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(258, 336)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(122, 66)
        Me.Button1.TabIndex = 36
        Me.Button1.Text = "Cancelar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
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
        'txtApellido
        '
        Me.txtApellido.Location = New System.Drawing.Point(109, 62)
        Me.txtApellido.Margin = New System.Windows.Forms.Padding(4)
        Me.txtApellido.Name = "txtApellido"
        Me.txtApellido.Size = New System.Drawing.Size(199, 24)
        Me.txtApellido.TabIndex = 25
        '
        'txtNom
        '
        Me.txtNom.Location = New System.Drawing.Point(109, 26)
        Me.txtNom.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNom.Name = "txtNom"
        Me.txtNom.Size = New System.Drawing.Size(199, 24)
        Me.txtNom.TabIndex = 23
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
        'Habilitar_o_Deshabilitar_Usuario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1076, 664)
        Me.Controls.Add(Me.gbBusqueda)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Habilitar_o_Deshabilitar_Usuario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Habilitar o Deshabiliar Usuario"
        Me.gbBusqueda.ResumeLayout(False)
        Me.gbBusqueda.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbBusqueda As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTipoUsuar As System.Windows.Forms.TextBox
    Friend WithEvents txtTipoDoc As System.Windows.Forms.TextBox
    Friend WithEvents btnInactivar As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents txtusuar As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtApellido As System.Windows.Forms.TextBox
    Friend WithEvents txtNom As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
