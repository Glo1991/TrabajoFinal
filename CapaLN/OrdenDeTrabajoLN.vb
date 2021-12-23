Imports CapaNE
Imports capaDA
Public Class OrdenDeTrabajoLN
    Private objOT As MetodosOTDA
    Public Sub New()
        objOT = New MetodosOTDA
    End Sub
    Public Function cargaGrilla() As DataSet
        Return objOT.CargarGrilla()
    End Function
    Public Function cargaGrillaEspCli() As DataSet
        Return objOT.CargarGrillaEsperCliente()
    End Function
    Public Function InsertarOT(ByVal objOrdT As ClaseOrdenDeTRabajo) As Integer
        Dim id As Integer
        id = objOT.InsertaOT(objOrdT)
        Return id
    End Function
    Public Function buscarIdCliene(ByVal objOrdT As String) As DataSet
        Return objOT.BuscarIDCliente(objOrdT)
    End Function
    Public Function buscarMail(ByVal objOrdT As String) As DataSet
        Return objOT.BuscarEmail(objOrdT)
    End Function
    Public Function buscaridOT(ByVal objOrdT As String) As DataSet
        Return objOT.BuscarIDordT(objOrdT)
    End Function
    Public Function cargarGrillaApellido(ByVal fechadesde As String, ByVal fechahasta As String, ByVal numOT As String, ByVal idestadoOT As String, ByVal cliente As String) As DataSet
        Return objOT.CargarGrillaApellido(fechadesde, fechahasta, numOT, idestadoOT, cliente)
    End Function
    Public Function cargarGrillaApellidoEsperand(ByVal apellido As String) As DataSet
        Return objOT.CargarGrillaApellidoEsperand(apellido)
    End Function
    Public Function cargarGrillaFecha(ByVal fecha1 As Date, ByVal fecha2 As Date) As DataSet
        Return objOT.CargarGrillaFecha(fecha1, fecha2)
    End Function
    Public Function cargarGrillaFechaEsperand(ByVal fecha1 As String, ByVal fecha2 As String) As DataSet
        Return objOT.CargarGrillaFechaEsperand(fecha1, fecha2)
    End Function
    Public Function cargarGrillaNumOT(ByVal numOT As String) As DataSet
        Return objOT.CargarGrillaNumOT(numOT)
    End Function
    Public Function cargarGrillaNumOTEsperand(ByVal numOT As String) As DataSet
        Return objOT.CargarGrillaNumOTEsperand(numOT)
    End Function
    Public Function buscaridEStadoOT(ByVal objEstOrdT As String) As DataSet
        Return objOT.BuscarIDEstadoOT(objEstOrdT)
    End Function
    Public Function cargarComboEstadoOT(ByVal objEstOrdT As ClaseEstadoOT) As DataSet
        Return objOT.cargarComboEstadoOt()
    End Function
    Public Sub modificarEstadoOT(ByVal objEstOrdT As ClaseOrdenDeTRabajo)
        objOT.modificarEstadoOT(objEstOrdT)
    End Sub
    Public Sub modificarAlerta(ByVal alerta As ClaseOrdenDeTRabajo)
        objOT.modificarAlerta(alerta)
    End Sub
    Public Function InsertarCambioEstOT(ByVal objOrdT As ClaseCambioEstadOT) As Integer
        Dim id As Integer
        id = objOT.InsertaCAmbioEstOT(objOrdT)
        Return id
    End Function
    Public Function cargarGrillaCbioEstOT(ByVal numOT As String) As DataSet
        Return objOT.CargarGrillaCbioEstOT(numOT)
    End Function
    Public Function cargarGrillaApellidoFecha(ByVal apellido As String, ByVal fecha1 As String, ByVal fecha2 As String) As DataSet
        Return objOT.CargarGrillaApellidoFecha(apellido, fecha1, fecha2)
    End Function
    Public Function cargarGrillaNroOrdenFecha(ByVal NroORden As Integer, ByVal fecha1 As String, ByVal fecha2 As String) As DataSet
        Return objOT.CargarGrillaNroOrdenFecha(NroORden, fecha1, fecha2)
    End Function
    Public Function cargarGrillaApellidoFechaEsperando(ByVal apellido As String, ByVal fecha1 As String, ByVal fecha2 As String) As DataSet
        Return objOT.CargarGrillaApellidoFechaEsperand(apellido, fecha1, fecha2)
    End Function
    Public Function cargarGrillaNroOrdenFechaEsperand(ByVal NroORden As Integer, ByVal fecha1 As String, ByVal fecha2 As String) As DataSet
        Return objOT.CargarGrillaNroOrdenFechaEsperand(NroORden, fecha1, fecha2)
    End Function
    Public Function InsertarModifConfigEMAIL(ByVal email As ClaseEmail)
        Dim id As Integer
        id = objOT.InsertarModifConfigEMAIL(email)
        Return id
    End Function
    Public Function cargarconfiguraciones() As DataSet
        Return objOT.cargarconfiguraciones()
    End Function
    Public Function vinculoPROT(ByVal idOT As Integer) As DataSet
        Return objOT.vinculoPROT(idOT)
    End Function
    Public Function estadoEntregar() As DataSet
        Return objOT.estadoEntregar()
    End Function

End Class
