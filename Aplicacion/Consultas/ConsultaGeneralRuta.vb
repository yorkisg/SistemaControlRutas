
Public Class ConsultaGeneralRuta

    Private Sub ConsultaGeneralRuta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Metodos que cargaran al momento de desplegar el formulario.

        'Se llama el metodo para alternar colores entre filas
        AlternarFilasGeneral(DataGridView)
        AlternarFilasGeneral(DataGridView1)

        'Se coloca la fecha actual
        DateTimePicker1.Value = Today
        DateTimePicker2.Value = Today

        'Se llama al metodo para que cargue rapido el datagridview
        EnableDoubleBuffered(DataGridView)
        EnableDoubleBuffered(DataGridView1)

        'EN CONSTRUCCION
        CargarConsultaRutaVehiculo()

    End Sub

    Private Sub ConsultaPersonal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Cierre del formulario

        Dispose()

    End Sub

    Private Sub BotonFiltrar_Click(sender As Object, e As EventArgs) Handles BotonFiltrar.Click
        'Boton Filtrar

        Try

            'La fecha inicial no puede ser mayor que la fecha final
            If DateTimePicker1.Value <= DateTimePicker2.Value Then

                If TextBox1.Text <> "" Then

                    CargarGridPersonal()

                ElseIf TextBox2.Text <> "" Then

                    CargarGridProducto()

                ElseIf TextBox3.Text <> "" Then

                    CargarGridVehiculo()

                ElseIf TextBox4.Text <> "" Then

                    CargarGridUbicacion()

                ElseIf TextBox5.Text <> "" Then

                    CargarGridDestino()

                ElseIf TextBox1.Text = "" And TextBox2.Text = "" And TextBox3.Text = "" And TextBox4.Text = "" And TextBox5.Text = "" Then

                    CargarGridConsultaRuta()
                    'MsgBox("Debe seleccionar un criterio para la consulta.", MsgBoxStyle.Exclamation, "Error.")

                End If

                'Mostramos la cantidad de registros encontrados
                Contador.Text = DataGridView.RowCount

            Else

                MsgBox("La fecha inicial no puede ser mayor a la fecha final.", MsgBoxStyle.Exclamation, "Error.")

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub BotonBuscar_Click(sender As Object, e As EventArgs) Handles BotonBuscar.Click
        'Llamada al formulario ListadoChofer

        ListadoPersonal.ShowDialog()

        'Eliminamos el texto en otros textbox para validar que no busque sobre otro criterio
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""

    End Sub

    Private Sub BotonBuscar2_Click(sender As Object, e As EventArgs) Handles BotonBuscar2.Click
        'Llamada al formulario ListadoProducto

        ListadoProducto.ShowDialog()

        'Eliminamos el texto en otros textbox para validar que no busque sobre otro criterio
        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""

    End Sub

    Private Sub BotonBuscar3_Click(sender As Object, e As EventArgs) Handles BotonBuscar3.Click
        'Llamada al formulario ListadoVehiculo

        ListadoVehiculo.ShowDialog()

        'Eliminamos el texto en otros textbox para validar que no busque sobre otro criterio
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""

    End Sub

    Private Sub BotonBuscar4_Click(sender As Object, e As EventArgs) Handles BotonBuscar4.Click
        'Llamada al formulario ListadoVehiculo

        Listadositiocarga.ShowDialog()

        'Eliminamos el texto en otros textbox para validar que no busque sobre otro criterio
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""

    End Sub

    Private Sub BotonBuscar5_Click(sender As Object, e As EventArgs) Handles BotonBuscar5.Click
        'Llamada al formulario ListadoVehiculo

        ListadoDestino.ShowDialog()

        'Eliminamos el texto en otros textbox para validar que no busque sobre otro criterio
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""

    End Sub

    Private Sub BotonLimpiar_Click(sender As Object, e As EventArgs) Handles BotonLimpiar.Click
        'Boton limpiar componentes

        LimpiarComponentes()

    End Sub

    Private Sub BotonExportar_Click(sender As Object, e As EventArgs) Handles BotonExportar.Click
        'Boton Exportar a Excel

        Try

            If DataGridView.RowCount > 0 Then

                Dim Mensaje As DialogResult

                Mensaje = MessageBox.Show("Desea expotar el listado?", "Aviso.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                'Si la respuesta es "Si"
                If Mensaje = DialogResult.Yes Then

                    Exportar(DataGridView)

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

            LimpiarComponentes()

            Dispose()

        Else

            Close()

        End If

    End Sub

    Private Sub LimpiarComponentes()

        'Abrimos el ciclo que recorre todas las filas del datagridview
        For i As Integer = 0 To DataGridView.RowCount - 1
            'Eliminamos elemento por elemento
            DataGridView.Rows.Remove(DataGridView.CurrentRow)
        Next

        For i As Integer = 0 To DataGridView1.RowCount - 1
            'Eliminamos elemento por elemento
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        Next

        'Limpiamos los demas componentes
        TextBox1.Text = ""
        BotonBuscar.Enabled = True
        Contador.Text = ""

    End Sub


End Class