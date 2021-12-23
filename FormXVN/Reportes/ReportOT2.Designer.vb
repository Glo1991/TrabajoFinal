<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ReportOT2
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
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource3 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim ReportDataSource4 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DataSet1 = New FormXVN.DataSet1()
        Me.cabezaOTBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cabezaOTTableAdapter = New FormXVN.DataSet1TableAdapters.cabezaOTTableAdapter()
        Me.cuerpoOTBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cuerpoOTTableAdapter = New FormXVN.DataSet1TableAdapters.cuerpoOTTableAdapter()
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cabezaOTBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cuerpoOTBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource3.Name = "DataSet1"
        ReportDataSource3.Value = Me.cabezaOTBindingSource
        ReportDataSource4.Name = "DataSet2"
        ReportDataSource4.Value = Me.cuerpoOTBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource3)
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource4)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "FormXVN.ReporteOT.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ServerReport.BearerToken = Nothing
        Me.ReportViewer1.Size = New System.Drawing.Size(1076, 664)
        Me.ReportViewer1.TabIndex = 0
        '
        'DataSet1
        '
        Me.DataSet1.DataSetName = "DataSet1"
        Me.DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'cabezaOTBindingSource
        '
        Me.cabezaOTBindingSource.DataMember = "cabezaOT"
        Me.cabezaOTBindingSource.DataSource = Me.DataSet1
        '
        'cabezaOTTableAdapter
        '
        Me.cabezaOTTableAdapter.ClearBeforeFill = True
        '
        'cuerpoOTBindingSource
        '
        Me.cuerpoOTBindingSource.DataMember = "cuerpoOT"
        Me.cuerpoOTBindingSource.DataSource = Me.DataSet1
        '
        'cuerpoOTTableAdapter
        '
        Me.cuerpoOTTableAdapter.ClearBeforeFill = True
        '
        'ReportOT2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1076, 664)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ReportOT2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte Orden de trabajo"
        CType(Me.DataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cabezaOTBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cuerpoOTBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents cabezaOTBindingSource As BindingSource
    Friend WithEvents DataSet1 As DataSet1
    Friend WithEvents cuerpoOTBindingSource As BindingSource
    Friend WithEvents cabezaOTTableAdapter As DataSet1TableAdapters.cabezaOTTableAdapter
    Friend WithEvents cuerpoOTTableAdapter As DataSet1TableAdapters.cuerpoOTTableAdapter
End Class
