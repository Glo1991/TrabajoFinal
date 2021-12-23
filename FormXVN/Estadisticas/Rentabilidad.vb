Imports CapaLN
Imports CapaNE
Public Class Rentabilidad
    Public fechadesde As String
    Public fechahasta As String
    Private Sub Rentabilidad_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        DateTimePicker1.Value = DateTimePicker1.Value.AddDays(-30)
        fechadesde = Format(DateTimePicker1.Value, "yyyy/MM/dd")
        fechahasta = Format(DateTimePicker2.Value, "yyyy/MM/dd")
        Dim ds As New DataSet
        Dim objEst As New EstadisticasLN
        ds = objEst.rentabilidad(fechadesde, fechahasta)

        inicio()


        Dim porcentaje As Double
        Dim Saldo As Double
        Dim costototal As Double
        If ds.Tables.Count > 0 Then

            For dv As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    Dim totalES As Double
                    totalES = ds.Tables(0).Rows(dv).Item(4) - ds.Tables(0).Rows(dv).Item(5)
                    Saldo = Saldo + ds.Tables(0).Rows(dv).Item(4)
                    porcentaje = (totalES * 100) / ds.Tables(0).Rows(dv).Item(5)

                    costototal = costototal + ds.Tables(0).Rows(dv).Item(5)
                    If ds.Tables(0).Rows(dv).Item(4) Like "NC?" Then
                        totalES = 0
                        porcentaje = 0
                        Saldo = Saldo - ds.Tables(0).Rows(dv).Item(4)
                    End If
                    If ds.Tables(0).Rows(dv).Item(5) = 0 Then

                        porcentaje = 100

                    End If

                    DataGridView1.Rows.Add(ds.Tables(0).Rows(dv).Item(0), ds.Tables(0).Rows(dv).Item(2), ds.Tables(0).Rows(dv).Item(3), ds.Tables(0).Rows(dv).Item(1), ds.Tables(0).Rows(dv).Item(4), ds.Tables(0).Rows(dv).Item(5), totalES.ToString("N2"), porcentaje.ToString("N2") & "%")

            Next
            Dim contador As Integer
            For dv As Integer = 0 To DataGridView1.Rows.Count - 1

                contador += 1
            Next
            Label2.Text = "$ " & Saldo.ToString("N2")
            Label4.Text = "$ " & costototal.ToString("N2")
            Label5.Text = "$ " & (Saldo - costototal).ToString("N2")
        End If

    End Sub

    Private Sub BtnCancelar_Click(sender As Object, e As EventArgs) Handles BtnCancelar.Click
        Me.Close()
    End Sub
    Public Sub inicio()
        DataGridView1.Columns(0).Width = 80
        DataGridView1.Columns(0).Width = 50
        DataGridView1.Columns(0).Width = 100
        'DataGridView1.Columns(0).Width = 200
        DataGridView1.Columns(0).Width = 80
        DataGridView1.Columns(0).Width = 80
        DataGridView1.Columns(0).Width = 80
        DataGridView1.Columns(0).Width = 80
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ds As New DataSet
        Dim objEst As New EstadisticasLN
        fechadesde = Format(DateTimePicker1.Value, "yyyy/MM/dd")
        fechahasta = Format(DateTimePicker2.Value, "yyyy/MM/dd")
        ds = objEst.rentabilidad(fechadesde, fechahasta)

        DataGridView1.Rows.Clear()

        inicio()
        Dim porcentaje As Double
        Dim Saldo As Double
        Dim costototal As Double
        If ds.Tables.Count > 0 Then
            For dv As Integer = 0 To ds.Tables(0).Rows.Count - 1
                Dim totalES As Double
                totalES = ds.Tables(0).Rows(dv).Item(4) - ds.Tables(0).Rows(dv).Item(5)
                Saldo = Saldo + ds.Tables(0).Rows(dv).Item(4)
                porcentaje = (totalES * 100) / ds.Tables(0).Rows(dv).Item(5)

                costototal = costototal + ds.Tables(0).Rows(dv).Item(5)
                If ds.Tables(0).Rows(dv).Item(4) Like "NC?" Then
                    totalES = 0
                    porcentaje = 0
                    Saldo = Saldo - ds.Tables(0).Rows(dv).Item(4)
                End If
                If ds.Tables(0).Rows(dv).Item(5) = 0 Then

                    porcentaje = 100

                End If


                DataGridView1.Rows.Add(ds.Tables(0).Rows(dv).Item(0), ds.Tables(0).Rows(dv).Item(2), ds.Tables(0).Rows(dv).Item(3), ds.Tables(0).Rows(dv).Item(1), ds.Tables(0).Rows(dv).Item(4), ds.Tables(0).Rows(dv).Item(5), totalES.ToString("N2"), porcentaje.ToString("N2") & "%")

            Next

            Label2.Text = "$ " & Saldo.ToString("N2")
            Label4.Text = "$ " & costototal.ToString("N2")
            Label5.Text = "$ " & (Saldo - costototal).ToString("N2")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        GraficoRentabilidad.Show()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        reporterentabilidad.Show()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub
End Class