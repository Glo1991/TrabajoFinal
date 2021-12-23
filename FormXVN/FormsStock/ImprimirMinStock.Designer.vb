<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ImprimirMinStock
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
        'Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        'Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.StockBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.XVNDataSet = New FormXVN.XVNDataSet()
        Me.StockTableAdapter = New FormXVN.XVNDataSetTableAdapters.StockTableAdapter()
        CType(Me.StockBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XVNDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReportViewer1
        ''
        'Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        'ReportDataSource1.Name = "DataSet1"
        'ReportDataSource1.Value = Me.StockBindingSource
        'Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        'Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "FormXVN.Report1.rdlc"
        'Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        'Me.ReportViewer1.Name = "ReportViewer1"
        'Me.ReportViewer1.Size = New System.Drawing.Size(717, 479)
        'Me.ReportViewer1.TabIndex = 0
        '
        'StockBindingSource
        '
        Me.StockBindingSource.DataMember = "Stock"
        Me.StockBindingSource.DataSource = Me.XVNDataSet
        '
        'XVNDataSet
        '
        Me.XVNDataSet.DataSetName = "XVNDataSet"
        Me.XVNDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'StockTableAdapter
        '
        Me.StockTableAdapter.ClearBeforeFill = True
        '
        'ImprimirMinStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 479)
        'Me.Controls.Add(Me.ReportViewer1)
        Me.Name = "ImprimirMinStock"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Imprimir"
        CType(Me.StockBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XVNDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    'Friend WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents StockBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents XVNDataSet As FormXVN.XVNDataSet
    Friend WithEvents StockTableAdapter As FormXVN.XVNDataSetTableAdapters.StockTableAdapter
End Class
