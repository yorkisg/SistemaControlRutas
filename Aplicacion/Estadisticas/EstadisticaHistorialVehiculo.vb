
Public Class EstadisticaHistorialVehiculo

    Private Sub EstadisticaHistorialVehiculo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Metodos que cargaran al momento de desplegar el formulario.

        'Se llama el metodo para alternar colores entre filas
        AlternarFilasGeneral(DataGridView)

        'Se llama al metodo para que cargue rapido el datagridview
        EnableDoubleBuffered(DataGridView)

        'Se coloca true el radiobutton1
        RadioButton1.Checked = True

        'Se llama al metodo para que cargue el grafico
        GenerarChartEstadisticaHistorial()

        'Se elimina la seleccion del datagridview
        DataGridView.ClearSelection()

    End Sub

    Private Sub EstadisticaHistorialVehiculo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Cierre del formulario

        Dispose()

    End Sub

    Private Sub BotonExportar_Click(sender As Object, e As EventArgs) Handles BotonExportar.Click
        'Boton Exportar a Excel

        Try

            If DataGridView.RowCount > 0 Then

                Dim Mensaje As DialogResult

                Mensaje = MessageBox.Show("Desea expotar el listado?", "Aviso.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                'Si la respuesta es "Si"
                If Mensaje = DialogResult.Yes Then

                    ExportarAExcell(DataGridView)

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
        If DataGridView.RowCount > 0 Then

            'LimpiarComponentes()

            Dispose()

        Else

            Close()

        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        'Al seleccionar el radiobutton, cargamos el siguiente metodo

        CargarEstadisticaHistorialReparacion()

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        'Al seleccionar el radiobutton, cargamos el siguiente metodo

        CargarEstadisticaHistorialSinReporte()

    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        'Al seleccionar el radiobutton, cargamos el siguiente metodo

        CargarEstadisticaHistorialEnServicio()

    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        'Al seleccionar el radiobutton, cargamos el siguiente metodo

        CargarEstadisticaHistorialExtraviado()

    End Sub

    Private Sub RadioButton5_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton5.CheckedChanged
        'Al seleccionar el radiobutton, cargamos el siguiente metodo

        CargarEstadisticaHistorialSinGPS()

    End Sub


End Class