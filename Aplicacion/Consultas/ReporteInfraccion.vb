
Public Class ReporteInfraccion

    Private Sub ListadoReporteInfraccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        'Seleccionamos "Carga" al inicio del formulario
        RadioButton1.Checked = True

    End Sub

    Private Sub ListadoReporteInfraccion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Cierre del formulario

        Dispose()

    End Sub

    Private Sub BotonConsultar2_Click(sender As Object, e As EventArgs) Handles BotonConsultar2.Click
        'Boton Filtrar

        Try

            Dim FechaDesde As String
            Dim FechaHasta As String

            'La fecha inicial no puede ser mayor que la fecha final
            If DateTimePicker1.Value <= DateTimePicker2.Value Then

                CargarGridListadoReporteInfraccion()
                CargarListadoInfraccion()

                CargarImagenesReporteVelocidad()

                'Pasamos la placa seleccionada a la variable
                FechaDesde = TextBox1.Text & " - "
                FechaHasta = TextBox2.Text

                'Colocamos la palabra concatenada con la variable para formar el titulo del tabpage
                GroupBox2.Text = "PRIMEROS 15 INFRACTORES DEL PERÍODO: " & FechaDesde & FechaHasta & " - " & TextBox4.Text

            Else

                MsgBox("La fecha inicial no puede ser mayor a la fecha final.", MsgBoxStyle.Exclamation, "Error.")

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub BotonLimpiar2_Click(sender As Object, e As EventArgs) Handles BotonLimpiar2.Click
        'Boton limpiar componentes

        LimpiarComponentes()

    End Sub

    Private Sub BotonExportar2_Click(sender As Object, e As EventArgs) Handles BotonExportar2.Click
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

    Private Sub BotonSalir2_Click(sender As Object, e As EventArgs) Handles BotonSalir2.Click
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

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        'Colocamos la fecha seleccionada en el textbox

        TextBox1.Text = DateTimePicker1.Value.ToString("dd-MM-yyyy")

    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        'Colocamos la fecha seleccionada en el textbox

        TextBox2.Text = DateTimePicker2.Value.ToString("dd-MM-yyyy")

    End Sub

    Private Sub DataGridView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView.CellFormatting
        'CellFormatting: Propiedad del control DataGridview el cual permite cambiar 
        'y dar formato a las celdas, bien sea por color de texto, fondo, etc.

        Dim TipoFlota As String

        If DataGridView.Columns(e.ColumnIndex).Name.Equals("ColumnaFlota") Then

            TipoFlota = (DataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

            If TipoFlota = "PRODUCTOS CÁRNICOS" Or TipoFlota = "GANADO EN PIE" Or TipoFlota = "GRASA Y DESPERDICIOS" Then

                e.CellStyle.ForeColor = Color.Red

            End If

            If TipoFlota = "MATERIA PRIMA" Then

                e.CellStyle.ForeColor = Color.Green

            End If

            If TipoFlota = "HUEVOS" Or TipoFlota = "REFRIGERADOS" Or TipoFlota = "NO REFRIGERADOS" Then

                e.CellStyle.ForeColor = Color.Blue

            End If

            If TipoFlota = "CONCHA DE ARROZ" Or TipoFlota = "LECHE CRUDA" Or TipoFlota = "DESECHOS DE GALLETAS" Then

                e.CellStyle.ForeColor = Color.BlueViolet

            End If

        End If

        Dim Velocidad As Double

        If DataGridView.Columns(e.ColumnIndex).Name.Equals("ColumnaVelocidad") Then

            Velocidad = (DataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

            If Velocidad >= "90" And Velocidad < "130" Then

                DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = Bandera

            End If

            If Velocidad >= "130" Then

                DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = Critico

            End If

        End If

    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        'Enviamos el texto seleccionado al textbox

        TextBox3.Text = "CARGA"
        TextBox4.Text = RadioButton1.Text

    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        'Enviamos el texto seleccionado al textbox

        TextBox3.Text = "LIVIANO"
        TextBox4.Text = RadioButton2.Text

    End Sub

    Private Sub DataGridView_CellErrorTextNeeded(ByVal sender As Object, ByVal e As DataGridViewCellErrorTextNeededEventArgs) Handles DataGridView.CellErrorTextNeeded
        'Evento CellErrorTextNeeded: se coloca un icono de advertencia o 
        'error en la celda seleccionada si cumple o no la condicion previa.

        Try

            'Dim Velocidad As Double

            If DataGridView.Columns(e.ColumnIndex).Name.Equals("ColumnaVelocidad") Then

                'Velocidad = (DataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

                ' If Velocidad >= "130" Then

                'e.ErrorText = "Exceso de Velocidad Crítico"

                ' DataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Style.BackColor = Color.MistyRose

                ' End If

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub


End Class