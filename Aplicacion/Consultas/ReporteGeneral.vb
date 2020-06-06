
Public Class ReporteGeneral

    Private Sub ReporteGeneral_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Metodos que cargaran al momento de desplegar el formulario.

        'Se llama el metodo para alternar colores entre filas
        AlternarFilasGeneral(DataGridView)
        AlternarFilasGeneral(DataGridView1)
        AlternarFilasGeneral(DataGridView2)
        AlternarFilasGeneral(DataGridView3)

        'Se coloca la fecha actual
        DateTimePicker1.Value = Today
        DateTimePicker2.Value = Today

        'Se llama al metodo para que cargue rapido el datagridview
        EnableDoubleBuffered(DataGridView)
        EnableDoubleBuffered(DataGridView1)
        EnableDoubleBuffered(DataGridView2)
        EnableDoubleBuffered(DataGridView3)

        'Decimos que el primer elemento activo del combo es "Activo"
        ComboTipo.SelectedItem = "CARGA"

    End Sub

    Private Sub ReporteGeneral_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Cierre del formulario

        'Si el datagridview contiene datos, obtenemos recursos 
        'liberando los datatable y dataset implementados.
        If DataGridView.RowCount > 0 Or DataGridView1.RowCount > 0 Or DataGridView2.RowCount > 0 Or DataGridView3.RowCount > 0 Then

            LimpiarComponentes()

            Dispose()

        Else

            Dispose()

        End If

    End Sub

    Private Sub ReporteConsumible_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        'Evento que permite cerrar el formulario presionando la tecla esc

        If (e.KeyCode = Keys.Escape) Then
            'Cierre del formulario

            'Si el datagridview contiene datos, obtenemos recursos 
            'liberando los datatable y dataset implementados.
            If DataGridView.RowCount > 0 Or DataGridView1.RowCount > 0 Or DataGridView2.RowCount > 0 Or DataGridView3.RowCount > 0 Then

                LimpiarComponentes()

                Dispose()

            Else

                Close()

            End If

        End If

    End Sub

    Private Sub BotonConsultar2_Click(sender As Object, e As EventArgs) Handles BotonConsultar2.Click
        'Boton Filtrar

        Try

            Dim FechaDesde As String = TextBox1.Text & " - "
            Dim FechaHasta As String = TextBox2.Text

            'La fecha inicial no puede ser mayor que la fecha final
            If DateTimePicker1.Value <= DateTimePicker2.Value Then

                'Colocamos la palabra concatenada con la variable para formar el titulo del tabpage
                GroupBox1.Text = "PRIMEROS 15 INFRACTORES DEL PERÍODO: " & FechaDesde & FechaHasta & " - " & TextBox3.Text
                GroupBox2.Text = "PRIMEROS 15 CONSUMOS: " & FechaDesde & FechaHasta & " - " & TextBox3.Text

                CargarGridListadoReporteInfraccion()
                CargarListadoInfraccion()

                CargarGridListadoReporteConsumible()
                CargarListadoConsumible()




            Else

                MsgBox("La fecha inicial no puede ser mayor a la fecha final.", MsgBoxStyle.Exclamation, "Error.")

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub BotonExportar2_Click(sender As Object, e As EventArgs) Handles BotonExportar2.Click
        'Boton Exportar a Excel

        Try

            If DataGridView.RowCount > 0 Or DataGridView1.RowCount > 0 Or DataGridView2.RowCount > 0 Or DataGridView3.RowCount > 0 Then

                Dim Mensaje As DialogResult

                Mensaje = MessageBox.Show("Desea expotar el listado?", "Aviso.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                'Si la respuesta es "Si"
                If Mensaje = DialogResult.Yes Then

                    If Panel.SelectedIndex = 0 Then

                        Exportar(DataGridView)
                        Exportar(DataGridView1)

                    ElseIf Panel.SelectedIndex = 1 Then

                        Exportar(DataGridView2)
                        Exportar(DataGridView3)

                    End If

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
        If DataGridView.RowCount > 0 Or DataGridView1.RowCount > 0 Or DataGridView2.RowCount > 0 Or DataGridView3.RowCount > 0 Then

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

        'Abrimos el ciclo que recorre todas las filas del datagridview
        For i As Integer = 0 To DataGridView1.RowCount - 1
            'Eliminamos elemento por elemento
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        Next

        'Abrimos el ciclo que recorre todas las filas del datagridview
        For i As Integer = 0 To DataGridView2.RowCount - 1
            'Eliminamos elemento por elemento
            DataGridView2.Rows.Remove(DataGridView2.CurrentRow)
        Next

        'Abrimos el ciclo que recorre todas las filas del datagridview
        For i As Integer = 0 To DataGridView3.RowCount - 1
            'Eliminamos elemento por elemento
            DataGridView3.Rows.Remove(DataGridView3.CurrentRow)
        Next

    End Sub

    Private Sub ComboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboTipo.SelectedIndexChanged
        'Evento donde seleccionamos el combobox y el elemento se va directamente al textbox

        TextBox3.Text = ComboTipo.Text

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        'Colocamos la fecha seleccionada en el textbox

        TextBox1.Text = DateTimePicker1.Value.ToString("dd-MM-yyyy")

    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker2.ValueChanged
        'Colocamos la fecha seleccionada en el textbox

        TextBox2.Text = DateTimePicker2.Value.ToString("dd-MM-yyyy")

    End Sub

    Private Sub DataGridView2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting
        'CellFormatting: Propiedad del control DataGridview el cual permite cambiar 
        'y dar formato a las celdas, bien sea por color de texto, fondo, etc.

        Dim TipoFlota As String

        If DataGridView2.Columns(e.ColumnIndex).Name.Equals("ColumnaGrupo") Then

            TipoFlota = (DataGridView2.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

            If TipoFlota = "PRODUCTOS CÁRNICOS" Or TipoFlota = "GANADO EN PIE" Or TipoFlota = "GRASA Y DESPERDICIOS" Or TipoFlota = "AMBULANCIAS" Then

                e.CellStyle.ForeColor = Color.Red

            End If

            If TipoFlota = "MATERIA PRIMA" Or TipoFlota = "CHEVROLET" Then

                e.CellStyle.ForeColor = Color.Green

            End If

            If TipoFlota = "HUEVOS" Or TipoFlota = "REFRIGERADOS" Or TipoFlota = "NO REFRIGERADOS" Or TipoFlota = "TOYOTA" Then

                e.CellStyle.ForeColor = Color.Blue

            End If

            If TipoFlota = "CONCHA DE ARROZ" Or TipoFlota = "LECHE CRUDA" Or TipoFlota = "DESECHOS DE GALLETAS" Or TipoFlota = "FORD" Or TipoFlota = "ALIMEX" Or TipoFlota = "ZULIANA DE CAMIONES" Then

                e.CellStyle.ForeColor = Color.BlueViolet

            End If

        End If

        Dim Exceso As Double

        If DataGridView2.Columns(e.ColumnIndex).Name.Equals("ColumnaMaximaVelocidad") Then

            Exceso = (DataGridView2.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

            If Exceso >= "90" And Exceso < "130" Then

                DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen22").Value = Velocidad

            End If

            If Exceso >= "130" Then

                DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen22").Value = Muerte
                e.CellStyle.BackColor = Color.LightPink

            End If

        End If

    End Sub

    Private Sub DataGridView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView.CellFormatting
        'CellFormatting: Propiedad del control DataGridview el cual permite cambiar 
        'y dar formato a las celdas, bien sea por color de texto, fondo, etc.

        Dim TipoFlota As String
        Dim Consumible As Double

        If DataGridView.Columns(e.ColumnIndex).Name.Equals("ColumnaFlota") Then

            TipoFlota = (DataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

            If TipoFlota = "PRODUCTOS CÁRNICOS" Or TipoFlota = "GANADO EN PIE" Or TipoFlota = "GRASA Y DESPERDICIOS" Or TipoFlota = "AMBULANCIAS" Then

                e.CellStyle.ForeColor = Color.Red

            End If

            If TipoFlota = "MATERIA PRIMA" Or TipoFlota = "CHEVROLET" Then

                e.CellStyle.ForeColor = Color.Green

            End If

            If TipoFlota = "HUEVOS" Or TipoFlota = "REFRIGERADOS" Or TipoFlota = "NO REFRIGERADOS" Or TipoFlota = "TOYOTA" Then

                e.CellStyle.ForeColor = Color.Blue

            End If

            If TipoFlota = "CONCHA DE ARROZ" Or TipoFlota = "LECHE CRUDA" Or TipoFlota = "DESECHOS DE GALLETAS" Or TipoFlota = "FORD" Or TipoFlota = "ALIMEX" Or TipoFlota = "ZULIANA DE CAMIONES" Then

                e.CellStyle.ForeColor = Color.BlueViolet

            End If

        End If

        If DataGridView.Columns(e.ColumnIndex).Name.Equals("ColumnaCantidadSurtida") Then

            Consumible = (DataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

            If Consumible >= "5" And Consumible < "70" Then

                DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = Consumo

            End If

            If Consumible >= "70" Then

                DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = Exceso
                'DataGridView.Rows(e.RowIndex).Cells("ColumnaDiferencia").Style.BackColor = Color.LightPink

                e.CellStyle.BackColor = Color.LightPink

            End If

        End If

    End Sub

    Private Sub Panel_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Panel.SelectedIndexChanged
        'Evento donde se seleccionan los tabs del tabcontrol (paginas) y luego se cargan metodos dependiendo del index del tab

        If Panel.SelectedIndex = 0 Then

            DataGridView2.ClearSelection()
            DataGridView3.ClearSelection()

        ElseIf Panel.SelectedIndex = 1 Then

            DataGridView.ClearSelection()
            DataGridView1.ClearSelection()

        End If

    End Sub


End Class