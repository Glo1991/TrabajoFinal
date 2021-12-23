Public Class PRacticaProfesionalizante
    Private Sub PRacticaProfesionalizante_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ejecutarrutacompleta = Microsoft.VisualBasic.Right(My.Application.Info.DirectoryPath.Length - 10, My.Application.Info.DirectoryPath.Length)

        'genero solo el path dela aplicacion poniendolo mas corto a modo que que has lo pedio anterior mente
        Dim RutaDeaplicacion As String = Microsoft.VisualBasic.Left(My.Application.Info.DirectoryPath, ejecutarrutacompleta)
        Dim OFD As New OpenFileDialog
        OFD.FileName = RutaDeaplicacion & "\Resources\PracticaProfesionalizandte.pdf"
        AxAcroPDF1.LoadFile(OFD.FileName)
    End Sub
End Class