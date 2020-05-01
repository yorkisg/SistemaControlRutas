
Public Class EstadisticaGeneral

    Private Sub EstadisticaGeneral_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Se llama al metodo para que cargue rapido los componentes
        EnableDoubleBuffered(DataGridView)
        EnableDoubleBuffered(DataGridView1)
        EnableDoubleBuffered(DataGridView2)
        EnableDoubleBuffered(DataGridView4)
        EnableDoubleBuffered(DataGridView5)
        EnableDoubleBuffered(DataGridView6)
        EnableDoubleBuffered(DataGridView7)
        EnableDoubleBuffered(DataGridView8)

        'Llamada al metodo para alternar los colores de las filas
        AlternarFilasGeneral(DataGridView)
        AlternarFilasGeneral(DataGridView1)
        AlternarFilasGeneral(DataGridView2)
        AlternarFilasGeneral(DataGridView4)
        AlternarFilasGeneral(DataGridView5)
        AlternarFilasGeneral(DataGridView6)
        AlternarFilasGeneral(DataGridView7)
        AlternarFilasGeneral(DataGridView8)

        CargarEstadisticaHistorialRutaVehiculo()
        CargarEstadisticaHistorialRutaChofer()
        CargarEstadisticaHistorialRutaFlota()
        CargarEstadisticaHistorialSitioDeCarga()
        CargarEstadisticaHistorialDestino()
        CargarEstadisticaHistorialInfraccionVehiculo()
        CargarEstadisticaHistorialInfraccionChofer()
        CargarEstadisticaHistorialInfraccionFlota()

    End Sub

    Private Sub EstadisticaGeneral_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Cierre del formulario

        If DataGridView1.RowCount > 0 Or DataGridView2.RowCount > 0 Or DataGridView5.RowCount > 0 Then
            'Si el datagridview contiene datos, obtenemos recursos 
            'liberando los datatable y dataset implementados.

            Tabla.Clear()
            DataSet.Clear()
            Dispose()

        Else

            Close()

        End If

    End Sub

    Private Sub BotonExportar_Click(sender As Object, e As EventArgs) Handles BotonExportar.Click
        'Boton Exportar a Excel

        Try

            If DataGridView1.RowCount > 0 Or DataGridView2.RowCount > 0 Or DataGridView5.RowCount > 0 Then

                Dim Mensaje As DialogResult

                Mensaje = MessageBox.Show("Desea expotar el listado?", "Aviso.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                'Si la respuesta es "Si"
                If Mensaje = DialogResult.Yes Then

                    If Panel.SelectedIndex = 0 Then

                        Exportar(DataGridView1)

                    ElseIf Panel.SelectedIndex = 1 Then

                        Exportar(DataGridView2)

                    ElseIf Panel.SelectedIndex = 2 Then

                        Exportar(DataGridView5)

                    End If

                End If

            Else

                MsgBox("No hay datos que exportar.", MsgBoxStyle.Exclamation, "Error.")

            End If

        Catch ex As Exception

            MsgBox("No se logró exportar nada, debe verificar con el administrador del sistema.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub BotonSalir_Click(sender As Object, e As EventArgs) Handles BotonSalir.Click
        'Boton salir

        If DataGridView1.RowCount > 0 Or DataGridView2.RowCount > 0 Or DataGridView5.RowCount > 0 Then
            'Si el datagridview contiene datos, obtenemos recursos 
            'liberando los datatable y dataset implementados.

            Tabla.Clear()
            DataSet.Clear()
            Dispose()

        Else

            Close()

        End If

    End Sub


End Class
