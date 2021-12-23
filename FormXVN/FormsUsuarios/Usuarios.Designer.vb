<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Usuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Usuarios))
        Me.Buscar = New System.Windows.Forms.GroupBox()
        Me.txtNumDoc = New System.Windows.Forms.TextBox()
        Me.cboTipoDoc = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.LblBusqueda = New System.Windows.Forms.TextBox()
        Me.ComboBoxBuscar = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.gbTurnos = New System.Windows.Forms.GroupBox()
        Me.dgvUsuarios = New System.Windows.Forms.DataGridView()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnInactivar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Buscar.SuspendLayout()
        Me.gbTurnos.SuspendLayout()
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Buscar
        '
        Me.Buscar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Buscar.Controls.Add(Me.txtNumDoc)
        Me.Buscar.Controls.Add(Me.cboTipoDoc)
        Me.Buscar.Controls.Add(Me.Label1)
        Me.Buscar.Controls.Add(Me.Button2)
        Me.Buscar.Controls.Add(Me.LblBusqueda)
        Me.Buscar.Controls.Add(Me.ComboBoxBuscar)
        Me.Buscar.Controls.Add(Me.Label3)
        Me.Buscar.Controls.Add(Me.Button1)
        Me.Buscar.Location = New System.Drawing.Point(18, 17)
        Me.Buscar.Margin = New System.Windows.Forms.Padding(4)
        Me.Buscar.Name = "Buscar"
        Me.Buscar.Padding = New System.Windows.Forms.Padding(4)
        Me.Buscar.Size = New System.Drawing.Size(955, 132)
        Me.Buscar.TabIndex = 12
        Me.Buscar.TabStop = False
        Me.Buscar.Text = "Buscar"
        '
        'txtNumDoc
        '
        Me.txtNumDoc.Location = New System.Drawing.Point(333, 84)
        Me.txtNumDoc.Margin = New System.Windows.Forms.Padding(4)
        Me.txtNumDoc.Name = "txtNumDoc"
        Me.txtNumDoc.Size = New System.Drawing.Size(199, 24)
        Me.txtNumDoc.TabIndex = 41
        '
        'cboTipoDoc
        '
        Me.cboTipoDoc.FormattingEnabled = True
        Me.cboTipoDoc.Items.AddRange(New Object() {"Dni", "Lc", "LE", "Pasaporte"})
        Me.cboTipoDoc.Location = New System.Drawing.Point(105, 84)
        Me.cboTipoDoc.Margin = New System.Windows.Forms.Padding(4)
        Me.cboTipoDoc.Name = "cboTipoDoc"
        Me.cboTipoDoc.Size = New System.Drawing.Size(199, 26)
        Me.cboTipoDoc.TabIndex = 40
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 96)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 18)
        Me.Label1.TabIndex = 39
        Me.Label1.Text = "Tipo de Dni"
        '
        'Button2
        '
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.Location = New System.Drawing.Point(699, 40)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(112, 72)
        Me.Button2.TabIndex = 38
        Me.Button2.Text = "Cancelar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button2.UseVisualStyleBackColor = True
        '
        'LblBusqueda
        '
        Me.LblBusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.LblBusqueda.Location = New System.Drawing.Point(333, 40)
        Me.LblBusqueda.Margin = New System.Windows.Forms.Padding(4)
        Me.LblBusqueda.Name = "LblBusqueda"
        Me.LblBusqueda.Size = New System.Drawing.Size(199, 24)
        Me.LblBusqueda.TabIndex = 37
        '
        'ComboBoxBuscar
        '
        Me.ComboBoxBuscar.FormattingEnabled = True
        Me.ComboBoxBuscar.Items.AddRange(New Object() {"Nombre de Usuario", "N° de Documento"})
        Me.ComboBoxBuscar.Location = New System.Drawing.Point(105, 40)
        Me.ComboBoxBuscar.Margin = New System.Windows.Forms.Padding(4)
        Me.ComboBoxBuscar.Name = "ComboBoxBuscar"
        Me.ComboBoxBuscar.Size = New System.Drawing.Size(199, 26)
        Me.ComboBoxBuscar.TabIndex = 36
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 52)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 18)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Buscar por"
        '
        'Button1
        '
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button1.Location = New System.Drawing.Point(548, 38)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(112, 73)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Buscar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button1.UseVisualStyleBackColor = True
        '
        'gbTurnos
        '
        Me.gbTurnos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gbTurnos.Controls.Add(Me.dgvUsuarios)
        Me.gbTurnos.Location = New System.Drawing.Point(18, 156)
        Me.gbTurnos.Margin = New System.Windows.Forms.Padding(4)
        Me.gbTurnos.Name = "gbTurnos"
        Me.gbTurnos.Padding = New System.Windows.Forms.Padding(4)
        Me.gbTurnos.Size = New System.Drawing.Size(955, 376)
        Me.gbTurnos.TabIndex = 11
        Me.gbTurnos.TabStop = False
        Me.gbTurnos.Text = "Usuarios"
        '
        'dgvUsuarios
        '
        Me.dgvUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvUsuarios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvUsuarios.Location = New System.Drawing.Point(4, 21)
        Me.dgvUsuarios.Margin = New System.Windows.Forms.Padding(4)
        Me.dgvUsuarios.Name = "dgvUsuarios"
        Me.dgvUsuarios.ReadOnly = True
        Me.dgvUsuarios.RowHeadersWidth = 51
        Me.dgvUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvUsuarios.Size = New System.Drawing.Size(947, 351)
        Me.dgvUsuarios.TabIndex = 0
        '
        'Button3
        '
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button3.Location = New System.Drawing.Point(360, 25)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(138, 73)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Modificar"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button3.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Image = CType(resources.GetObject("btnModificar.Image"), System.Drawing.Image)
        Me.btnModificar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnModificar.Location = New System.Drawing.Point(661, 25)
        Me.btnModificar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(138, 73)
        Me.btnModificar.TabIndex = 4
        Me.btnModificar.Text = "Nuevo"
        Me.btnModificar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnInactivar
        '
        Me.btnInactivar.Image = CType(resources.GetObject("btnInactivar.Image"), System.Drawing.Image)
        Me.btnInactivar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnInactivar.Location = New System.Drawing.Point(522, 25)
        Me.btnInactivar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnInactivar.Name = "btnInactivar"
        Me.btnInactivar.Size = New System.Drawing.Size(125, 73)
        Me.btnInactivar.TabIndex = 2
        Me.btnInactivar.Text = "Estado"
        Me.btnInactivar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnInactivar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.Button4)
        Me.GroupBox1.Controls.Add(Me.btnModificar)
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.btnInactivar)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 540)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4)
        Me.GroupBox1.Size = New System.Drawing.Size(955, 107)
        Me.GroupBox1.TabIndex = 13
        Me.GroupBox1.TabStop = False
        '
        'Button4
        '
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button4.Location = New System.Drawing.Point(809, 25)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(138, 73)
        Me.Button4.TabIndex = 75
        Me.Button4.Text = "Cancelar"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Usuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1076, 664)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Buscar)
        Me.Controls.Add(Me.gbTurnos)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Usuarios"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Usuarios"
        Me.Buscar.ResumeLayout(False)
        Me.Buscar.PerformLayout()
        Me.gbTurnos.ResumeLayout(False)
        CType(Me.dgvUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Buscar As System.Windows.Forms.GroupBox
    Friend WithEvents txtNumDoc As System.Windows.Forms.TextBox
    Friend WithEvents cboTipoDoc As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents LblBusqueda As System.Windows.Forms.TextBox
    Friend WithEvents ComboBoxBuscar As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents gbTurnos As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents dgvUsuarios As System.Windows.Forms.DataGridView
    Friend WithEvents btnModificar As System.Windows.Forms.Button
    Friend WithEvents btnInactivar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button4 As Button
End Class
