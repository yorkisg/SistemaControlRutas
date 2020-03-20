
Public Class EstadisticaRuta

    Private Sub EstadisticaRuta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Metodos que cargaran al momento de desplegar el formulario.

        'Se llama el metodo para alternar colores entre filas
        AlternarFilasGeneral(DataGridView)
        AlternarFilasGeneral(DataGridView1)
        AlternarFilasGeneral(DataGridView2)

        'Se llama al metodo para que cargue rapido el datagridview
        EnableDoubleBuffered(DataGridView)
        EnableDoubleBuffered(DataGridView1)
        EnableDoubleBuffered(DataGridView2)

        'Se llama a los metodos en el Load del formulario para que los datagridview carguen los datos inmediatamente
        CargarEstadisticaHistorialRutaVehiculo()
        CargarEstadisticaHistorialRutaChofer()
        CargarEstadisticaHistorialRutaFlota()

        'Se llama al metodo para que cargue el grafico
        GenerarChartEstadisticaRuta()

        'Se elimina la seleccion del datagridview
        DataGridView.ClearSelection()
        DataGridView1.ClearSelection()
        DataGridView2.ClearSelection()

    End Sub

    Private Sub EstadisticaRuta_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Cierre del formulario

        Dispose()

    End Sub

    Private Sub BotonExportar_Click(sender As Object, e As EventArgs) Handles BotonExportar.Click
        'Boton Exportar a Excel

        Try

            If DataGridView.RowCount > 0 Or DataGridView1.RowCount > 0 Or DataGridView2.RowCount > 0 Then

                Dim Mensaje As DialogResult

                Mensaje = MessageBox.Show("Desea expotar el listado?", "Aviso.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                'Si la respuesta es "Si"
                If Mensaje = DialogResult.Yes Then

                    ExportarAExcell(DataGridView)
                    ExportarAExcell(DataGridView1)
                    ExportarAExcell(DataGridView2)

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

        'Si el datagridview contiene datos, obtenemos recursos 
        'liberando los datatable y dataset implementados.
        If DataGridView.RowCount > 0 Or DataGridView1.RowCount > 0 Or DataGridView2.RowCount > 0 Then

            Dispose()

        Else

            Close()

        End If

    End Sub


End Class