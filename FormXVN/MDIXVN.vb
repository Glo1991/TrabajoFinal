Imports System.Windows.Forms
Imports capaDA

Public Class XVN

    Private Sub ShowNewForm(ByVal sender As Object, ByVal e As EventArgs)
        ' Cree una nueva instancia del formulario secundario.
        Dim ChildForm As New System.Windows.Forms.Form
        ' Conviértalo en un elemento secundario de este formulario MDI antes de mostrarlo.
        ChildForm.MdiParent = Me

        m_ChildFormNumber += 1
        ChildForm.Text = "Ventana " & m_ChildFormNumber

        ChildForm.Show()
    End Sub

    Private Sub OpenFile(ByVal sender As Object, ByVal e As EventArgs)
        Dim OpenFileDialog As New OpenFileDialog
        OpenFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        OpenFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"
        If (OpenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = OpenFileDialog.FileName
            ' TODO: agregue código aquí para abrir el archivo.
        End If
    End Sub

    Private Sub SaveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Dim SaveFileDialog As New SaveFileDialog
        SaveFileDialog.InitialDirectory = My.Computer.FileSystem.SpecialDirectories.MyDocuments
        SaveFileDialog.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*"

        If (SaveFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK) Then
            Dim FileName As String = SaveFileDialog.FileName
            ' TODO: agregue código aquí para guardar el contenido actual del formulario en un archivo.
        End If
    End Sub


    Private Sub ExitToolsStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.Close()
    End Sub

    Private Sub CutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    End Sub

    Private Sub CopyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Utilice My.Computer.Clipboard para insertar el texto o las imágenes seleccionadas en el Portapapeles
    End Sub

    Private Sub PasteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        'Utilice My.Computer.Clipboard.GetText() o My.Computer.Clipboard.GetData para recuperar la información del Portapapeles.
    End Sub

    'Private Sub ToolBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Me.ToolStrip.Visible = Me.ToolBarToolStripMenuItem.Checked
    'End Sub

    'Private Sub StatusBarToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
    '    Me.StatusStrip.Visible = Me.StatusBarToolStripMenuItem.Checked
    'End Sub

    Private Sub CascadeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Private Sub TileVerticalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub

    Private Sub TileHorizontalToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub

    Private Sub ArrangeIconsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        Me.LayoutMdi(MdiLayout.ArrangeIcons)
    End Sub

    Private Sub CloseAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
        ' Cierre todos los formularios secundarios del principal.
        For Each ChildForm As Form In Me.MdiChildren
            ChildForm.Close()
        Next
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub AdministradorDeUsuariosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim frm As New Usuarios()
        'frm.MdiParent = Me
        'frm.Show()

        Usuarios.Show()
    End Sub

    Private Sub CerrarSesiónToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CerrarSesiónToolStripMenuItem.Click
        Dim resp As Integer
        resp = MessageBox.Show("Seguro quiere cerrar sesión?...", "Borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resp = vbYes Then

            Login.txtpassword.Clear()
            'Login.txtlogin.Clear()
            Login.Show()
            Me.Hide()
            'Login.txtpassword.Clear()
        End If
    End Sub
    'Private Sub MDIPilates_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
    '    End
    'End Sub

    Private Sub AdministradorDeClientesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim frm As New Clientes()
        'frm.MdiParent = Me
        'frm.Show()

        Clientes.Show()
    End Sub

    Private Sub AdministradorDeProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim frm As New Proveedores()
        'frm.MdiParent = Me
        'frm.Show()

        Proveedores.Show()
    End Sub

    Private Sub AdministrarStockToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdministrarStockToolStripMenuItem.Click

        'Dim frm As New Sotck()
        'frm.MdiParent = Me
        'frm.Show()

        Sotck.Show()
    End Sub

    Private Sub AdministrarComprasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim frm As New Compras()
        'frm.MdiParent = Me
        'frm.Show()

        Compras.Show()
    End Sub

    Private Sub AdministrarOrdenesDeTrabajoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim frm As New BuscarOrdTrab()
        'frm.MdiParent = Me
        'frm.Show()

        BuscarOrdTrab.Show()
    End Sub

    Private Sub AdministradorDePreciosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim frm As New PreciosProveedor()
        'frm.MdiParent = Me
        'frm.Show()

        PreciosProveedor.Show()
    End Sub

    Private Sub ListaDePreciosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim frm As New PreciosVentas()
        'frm.MdiParent = Me
        'frm.Show()

        PreciosVentas.Show()
    End Sub

    Private Sub AdministradorDeVentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim frm As New Ventas()
        'frm.MdiParent = Me
        'frm.Show()

        Ventas.Show()
    End Sub

    Private Sub VentasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim frm As New Ventas()
        'frm.MdiParent = Me
        'frm.Show()

        Ventas.Show()
    End Sub

    Private Sub ListaDePreciosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim frm As New ListaDePreciosULim()
        'frm.MdiParent = Me
        'frm.Show()

        ListaDePreciosULim.Show()
    End Sub

    Private Sub ComprasToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ListaDePreciosDeProveedoresToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim frm As New PreciosProveedor()
        'frm.MdiParent = Me
        'frm.Show()

        PreciosProveedor.Show()
    End Sub

    Private Sub AdministradorDeUsuariosToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdministradorDeUsuariosToolStripMenuItem1.Click
        'Dim frm As New Usuarios()
        'frm.MdiParent = Me
        'frm.Show()

        Usuarios.Show()
    End Sub


    Private Sub AdministradorDePreciosToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'Dim frm As New PreciosVentas()
        'frm.MdiParent = Me
        'frm.Show()

        PreciosVentas.Show()
    End Sub

    Private Sub VentasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VentasToolStripMenuItem.Click

    End Sub



    Private Sub AdministrarComprasToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AdministrarComprasToolStripMenuItem.Click
        'Dim frm As New Compras()
        'frm.MdiParent = Me
        'frm.Show()

        Compras.Show()
    End Sub

    Private Sub ListaOrdDeTrabajoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListaOrdDeTrabajoToolStripMenuItem.Click
        'Dim frm As New BuscarOrdTrab()
        'frm.MdiParent = Me
        'frm.Show()
        BuscarOrdTrab.Show()
    End Sub

    Private Sub NuevaOrdenDeTrabajoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuevaOrdenDeTrabajoToolStripMenuItem.Click
        'Dim frm As New OrdenDeTRabajo()
        'frm.MdiParent = Me
        'frm.Show()

        OrdenDeTRabajo.Show()
    End Sub

    Private Sub AdministradorDeArticulosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'Dim frm As New Articulos()
        'frm.MdiParent = Me
        'frm.Show()

        Articulos.Show()
    End Sub

    Private Sub MarcasToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'Dim frm As New Marcas()
        'frm.MdiParent = Me
        'frm.Show()

        Marcas.Show()
    End Sub

    Private Sub CategoríasToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'Dim frm As New Categoria()
        'frm.MdiParent = Me
        'frm.Show()

        Categoria.Show()
    End Sub

    Private Sub HistoricoDeArtículoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles HistoricoDeArtículoToolStripMenuItem.Click
        'Dim frm As New HistoricoStock()
        'frm.MdiParent = Me
        'frm.Show()
        HistoricoStock.Show()
    End Sub


    Private Sub RegistrarCompraToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarCompraToolStripMenuItem.Click
        RegistrarCompra.Show()
    End Sub

    Private Sub StockMínimoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles StockMínimoToolStripMenuItem.Click
        VerMinStock.Show()
    End Sub

    Private Sub ModifcaciónMasivaToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ModificacionMasiva.Show()
    End Sub

    Private Sub ListaDePreciosToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles ListaDePreciosToolStripMenuItem.Click
        ListaDePreciosULim.Show()
    End Sub

    Private Sub ListaDeServiciosToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ListaServicios.Show()
    End Sub

    Private Sub NuevoPresupuestoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NuevoPresupuestoToolStripMenuItem.Click
        NuevoPresupuestos.Show()
    End Sub

    Private Sub PlanillaDePresupuestosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlanillaDePresupuestosToolStripMenuItem.Click
        PlanillaPresupuestos.Show()
    End Sub

    Private Sub AdministradorDeArticulosToolStripMenuItem1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub MarcasToolStripMenuItem1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub CategoriasToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Categoria.Show()
    End Sub

    Private Sub ModificaciónMasivaToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ServiciosToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        ListaServicios.Show()
    End Sub

    Private Sub AdministradorDeArticulosToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles AdministradorDeArticulosToolStripMenuItem.Click
        Articulos.Show()
    End Sub

    Private Sub ModificaciónMasivaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ModificaciónMasivaToolStripMenuItem1.Click
        ModificacionMasiva.Show()
    End Sub

    Private Sub AdministradorDeMarcasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdministradorDeMarcasToolStripMenuItem.Click
        Marcas.Show()
    End Sub

    Private Sub AdministradorDeMarcasToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AdministradorDeMarcasToolStripMenuItem1.Click
        Categoria.Show()
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        Clientes.Show()
    End Sub

    Private Sub ProveedoresToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ProveedoresToolStripMenuItem1.Click
        Proveedores.Show()
    End Sub

    Private Sub AdministradorDeServiciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdministradorDeServiciosToolStripMenuItem.Click
        ListaServicios.Show()
    End Sub

    Private Sub AgregarComprobanteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarComprobanteToolStripMenuItem.Click
        RegistrarVenta.Show()
    End Sub

    Private Sub PlanillaDeComprobantesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlanillaDeComprobantesToolStripMenuItem.Click
        Ventas.Show()
    End Sub

    Private Sub PlanillaDeCajaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PlanillaDeCajaToolStripMenuItem.Click
        PlanillaCaja.Show()
    End Sub

    Private Sub VentaDeArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles VentaDeArtículosToolStripMenuItem.Click
        Reporteventasxarticulo.Show()
    End Sub

    Private Sub ComprasPorArtículosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComprasPorArtículosToolStripMenuItem.Click
        ComprasxArticulo.Show()
    End Sub

    Private Sub RentabilidadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RentabilidadToolStripMenuItem.Click
        Rentabilidad.Show()
    End Sub

    Private Sub ManualDeUsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ManualDeUsuarioToolStripMenuItem.Click
        ManualUsuario.Show()
    End Sub

    Private Sub CambiarContraseñaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambiarContraseñaToolStripMenuItem.Click
        ModificarUsuario.cambic = 1
        ModificarUsuario.Show()
    End Sub

    Private Sub BackupYRestoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupYRestoreToolStripMenuItem.Click
        BackupRestore.Show()
    End Sub

    Private Sub ConfiguracionDeBaseToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub PuntosDeVentasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PuntosDeVentasToolStripMenuItem.Click
        PuntoVenta.Show()
    End Sub

    Private Sub XVN_Load(sender As Object, e As EventArgs)

    End Sub

    Private Sub XVN_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        End
    End Sub

    Private Sub AdministraciónDeProyectosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdministraciónDeProyectosToolStripMenuItem.Click
        AdministracionProyectos.Show()
    End Sub

    Private Sub PracticaProfesionalizanteToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PracticaProfesionalizanteToolStripMenuItem.Click
        PRacticaProfesionalizante.Show()
    End Sub
End Class
