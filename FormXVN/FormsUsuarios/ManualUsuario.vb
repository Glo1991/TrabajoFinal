Imports System.IO
Public Class ManualUsuario
    Private Sub ManualUsuario_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim rutaDefault = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        'Dim fileDefault = "ManualUSuario.pdf"

        'Dim abrir As New OpenFileDialog
        'abrir.InitialDirectory = rutaDefault
        'abrir.Filter = "Archivos PDF|*.pdf"

        'If File.Exists(Path.Combine(rutaDefault, fileDefault)) Then
        '    'Nombre de archivo que se cargará por defecto, si existe en la ruta
        '    abrir.FileName = fileDefault
        'End If

        'If abrir.ShowDialog = DialogResult.OK Then
        '    AxAcroPDF1.LoadFile(abrir.FileName)
        'End If
        'ejecuto los caracteres que deseo extraer para generar el path
        Dim ejecutarrutacompleta = Microsoft.VisualBasic.Right(My.Application.Info.DirectoryPath.Length - 10, My.Application.Info.DirectoryPath.Length)

        'genero solo el path dela aplicacion poniendolo mas corto a modo que que has lo pedio anterior mente
        Dim RutaDeaplicacion As String = Microsoft.VisualBasic.Left(My.Application.Info.DirectoryPath, ejecutarrutacompleta)
        Dim OFD As New OpenFileDialog
        OFD.FileName = RutaDeaplicacion & "\Resources\ManualUSuario.pdf"
        AxAcroPDF1.LoadFile(OFD.FileName)


    End Sub
End Class