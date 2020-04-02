
Public Class ConsultaInfraccion

    Private Sub ConsultaInfraccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Metodos que cargaran al momento de desplegar el formulario.

        'Se llama el metodo para alternar colores entre filas
        AlternarFilasGeneral(DataGridView)

        'Se coloca la fecha actual
        DateTimePicker1.Value = Today
        DateTimePicker2.Value = Today

        'Se llama al metodo para que cargue rapido el datagridview
        EnableDoubleBuffered(DataGridView)

        'Seleccionamos "Carga" al inicio del formulario
        RadioButton1.Checked = True

    End Sub

    Private Sub ConsultaHistorialVehiculo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Cierre del formulario

        Dispose()

    End Sub

    Private Sub BotonFiltrar_Click(sender As Object, e As EventArgs) Handles BotonFiltrar.Click
        'Boton Filtrar

        Try

            'La fecha inicial no puede ser mayor que la fecha final
            If DateTimePicker1.Value <= DateTimePicker2.Value Then

                If TextBox1.Text <> "" Then

                    CargarGridConsultaVehiculoInfraccion()

                ElseIf TextBox1.Text = "" Then

                    CargarGridConsultaInfraccion()

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
        'Llamada al formulario ListadoVehiculo

        ListadoVehiculo.ShowDialog()

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

        'Limpiamos los demas componentes
        TextBox1.Text = ""
        BotonBuscar.Enabled = True
        Contador.Text = ""

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        'Enviamos el texto seleccionado al textbox

        TextBox2.Text = RadioButton1.Text

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        'Enviamos el texto seleccionado al textbox

        TextBox2.Text = RadioButton2.Text

    End Sub

    Private Sub DataGridView_CellErrorTextNeeded(ByVal sender As Object, ByVal e As DataGridViewCellErrorTextNeededEventArgs) Handles DataGridView.CellErrorTextNeeded
        'Evento CellErrorTextNeeded: se coloca un icono de advertencia o 
        'error en la celda seleccionada si cumple o no la condicion previa.

        Try

            Dim Velocidad As Double

            If DataGridView.Columns(e.ColumnIndex).Name.Equals("ColumnaVelocidad") Then

                Velocidad = (DataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

                If Velocidad >= "130" Then

                    e.ErrorText = "Exceso de Velocidad Crítico"

                    DataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.MistyRose

                End If

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub


End Class