
Public Class SeguimientoTaller

    Private Sub SeguimientoTaller_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Llamada al metodo que permite cargar el arbol de opciones proveniente del Modulo.
        CargarComboArbol()

        'Validamos que el primer item seleccionado en el arbol sea el primero
        'ComboArbol.SelectedItem = "AMBULANCIAS"
        ComboArbol.SelectedIndex = 0

        'Llamada al metodo para cargar el datagridview con las placas de los vehiculos
        CargarGridSeguimientoTaller()
        CargarGridSeguimientoActual()

        'Llamada al metodo para alternar los colores de las filas
        AlternarFilasGeneral(DataGridView1)
        AlternarFilasGeneral(DataGridView2)
        AlternarFilasGeneral(DataGridView3)

        'Se llama al metodo para que cargue rapido los componentes
        EnableDoubleBuffered(DataGridView1)
        EnableDoubleBuffered(DataGridView2)
        EnableDoubleBuffered(DataGridView3)

        'Actualizamos la fecha a la actual del dia de hoy
        DateTimePicker1.Value = Today

        'Se selecciona la primera pagina del panel
        Panel7.SelectedIndex = 0

    End Sub

    Private Sub SeguimientoTaller_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Al cerrar el formulario por el boton "x" se ejecutan los metodos del boton salir

        If DataGridView1.RowCount > 0 Or DataGridView2.RowCount > 0 Then


            Tabla.Clear()
            DataSet.Clear()

            'Cierre formal del formulario liberando recursos
            Dispose()

        Else

            'Cierre formal de la ventana sin liberar recursos
            Close()

        End If

    End Sub

    Private Sub DataGridView1_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView1.DoubleClick
        'Evento que genera la apertura del formulario "RegistrarReporteTaller" para registrar nuevos reportes

        Try

            If DataGridView1.RowCount > 0 And DataGridView1.SelectedRows.Count = 1 Then

                'Enviamos el id correspondiente al textbox3 del formulario RegistrarReporteTaller
                RegistrarReporteTaller.TextBox3.Text = DataGridView1.Item("ID", DataGridView1.SelectedRows(0).Index).Value

                'Actualizamos el id de la serie correspondiente
                SerieTaller()

                'Colocamos la fecha actual
                RegistrarReporteTaller.DateTimePicker1.Value = Today
                RegistrarReporteTaller.DateTimePicker2.Value = Today

                'Despliegue del formulario
                RegistrarReporteTaller.ShowDialog()

                'Mantenemos posicion y enfoque en la fila seleccionada
                FilaTaller = DataGridView1.CurrentRow.Index
                ColumnaTaller = 1

            End If

        Catch ex As Exception


        End Try

    End Sub

    Private Sub DataGridView1_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView1.SelectionChanged
        'SelectionChanged o CellMouseClick: Propiedad del control DataGridview el cual permite hacer click
        'y seleccionar elementos por filas o columnas.
        'en este caso se selecciona el ID del vehiculo el cual es pasado a un control
        'TextBox pasa su posterior uso.

        Try

            Dim Nombre As String

            If DataGridView1.RowCount > 0 And DataGridView1.SelectedRows.Count = 1 Then

                'Seleccionamos y pasamos el valor al TextBox.
                'Usado para el detalle de ruta
                TextBox1.Text = DataGridView1.Item("ID", DataGridView1.SelectedRows(0).Index).Value

                'Pasamos la placa seleccionada a la variable
                Nombre = TextBox1.Text
                vehiculo.Text = Nombre

            End If

            'Luego de seleccionar el valor en el DataGridView1 llamamos al metodo 
            'CargarGridHistorial para cargar lo correspondiente.
            CargarGridHistorialTaller()

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        'Se usa el evento CellMouseClick para obtener el index de la fila seleccionada
        'y luego pasarlo al textbox para que pueda ser posicionado luego de guardar 

        Try

            If DataGridView1.RowCount > 0 And DataGridView1.SelectedRows.Count = 1 Then

                If e.Button = MouseButtons.Left Then

                    FilaTaller = DataGridView1.CurrentRow.Index
                    ColumnaTaller = 1

                End If

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        'CellFormatting: Evento del control DataGridview el cual permite cambiar 
        'y dar formato a las celdas, bien sea por color de texto, fondo, etc.

        Try

            Dim EstadoVehiculo As String

            If DataGridView1.Columns(e.ColumnIndex).Name.Equals("ColumnaEstado") Then

                EstadoVehiculo = (DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

                If EstadoVehiculo = "OPERATIVO" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen").Value = SinRevision

                End If

                If EstadoVehiculo = "PENDIENTE POR REVISIÓN" Then

                    e.CellStyle.ForeColor = Color.Blue
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen").Value = PendientePorRevision

                End If

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub DataGridView1_MouseDown(sender As Object, e As MouseEventArgs) Handles DataGridView1.MouseDown
        'Metodo o evento que permite seleccionar filas con el click derecho

        Dim Indice As Integer
        Dim Dato As DataGridView.HitTestInfo = DataGridView1.HitTest(e.X, e.Y)

        Try

            If e.Button = MouseButtons.Right Then

                If Dato.Type = DataGridViewHitTestType.Cell Then

                    If Dato.RowIndex >= 0 Then

                        Indice = Dato.RowIndex
                        DataGridView1.CurrentCell = DataGridView1.Rows(Dato.RowIndex).Cells(Dato.ColumnIndex)
                        DataGridView1.Rows(Dato.RowIndex).Selected = True

                        If DataGridView1.RowCount > 0 Or DataGridView1.SelectedRows.Count = 1 Then

                            DataGridView1.ContextMenuStrip = MenuTaller

                        Else

                            DataGridView1.ContextMenuStrip = Nothing

                        End If

                    End If

                    'Si seleccionamos con click derecho, obtenemos el index de la fila seleccionada y posicionamos el enfoque
                    FilaTaller = DataGridView1.CurrentRow.Index
                    ColumnaTaller = 1

                End If

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub DataGridView2_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView2.SelectionChanged
        'SelectionChanged o CellMouseClick:: Propiedad del control DataGridview el cual permite hacer click
        'y seleccionar elementos por celdas.

        Try

            If DataGridView2.SelectedRows.Count > 0 Then
                'Seleccionamos y pasamos los valores a los TextBox correspondientes.

                TextBox3.Text = DataGridView2.Item("ColumnaID", DataGridView2.SelectedRows(0).Index).Value

                TextBox4.Text = DataGridView2.Item("ColumnaEstadoReporte", DataGridView2.SelectedRows(0).Index).Value

                TextBox6.Text = DataGridView2.Item("ColumnaFechaIngreso", DataGridView2.SelectedRows(0).Index).Value

            Else

                TextBox3.Text = ""

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub DataGridView2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting
        'CellFormatting: Evento del control DataGridview el cual permite cambiar 
        'y dar formato a las celdas, bien sea por color de texto, fondo, etc.

        Try

            Dim EstadoReporte As String

            If DataGridView2.Columns(e.ColumnIndex).Name.Equals("ColumnaEstadoReporte") Then

                EstadoReporte = (DataGridView2.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

                If EstadoReporte = "ABIERTO" Then

                    e.CellStyle.ForeColor = Color.Blue
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen1").Value = Abierto

                End If

                If EstadoReporte = "CERRADO" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen1").Value = Cerrado

                End If

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub DataGridView2_DoubleClick(sender As Object, e As EventArgs) Handles DataGridView2.DoubleClick
        'Evento que genera la apertura del formulario "RegistrarReporteTaller" para registrar nuevos reportes

        Try

            If DataGridView2.RowCount > 0 And DataGridView2.SelectedRows.Count = 1 Then

                'Enviamos los datos seleccionados a los textbox de RegistrarReporteTaller

                If TextBox4.Text = "ABIERTO" Then

                    RegistrarReporteTaller.TextBox1.Text = DataGridView2.Item("ColumnaID", DataGridView2.SelectedRows(0).Index).Value

                    RegistrarReporteTaller.TextBox3.Text = DataGridView2.Item("ColumnaVehiculo", DataGridView2.SelectedRows(0).Index).Value

                    RegistrarReporteTaller.DateTimePicker1.Value = DataGridView2.Item("ColumnaFechaIngreso", DataGridView2.SelectedRows(0).Index).Value

                    RegistrarReporteTaller.Combo1.Text = DataGridView2.Item("ColumnaArea", DataGridView2.SelectedRows(0).Index).Value

                    RegistrarReporteTaller.TextBox4.Text = DataGridView2.Item("ColumnaFalla", DataGridView2.SelectedRows(0).Index).Value

                    RegistrarReporteTaller.BotonModificar.Enabled = True

                    RegistrarReporteTaller.BotonGuardar.Enabled = False

                    RegistrarReporteTaller.ShowDialog()

                ElseIf TextBox4.Text = "CERRADO" Then

                    MsgBox("No puede cerrar un reporte ya completado. Verifique la información.", MsgBoxStyle.Exclamation, "Error.")

                End If

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub DataGridView2_MouseDown(sender As Object, e As MouseEventArgs) Handles DataGridView2.MouseDown
        'Metodo o evento que permite seleccionar filas con el click derecho

        Dim Indice As Integer
        Dim Dato As DataGridView.HitTestInfo = DataGridView2.HitTest(e.X, e.Y)

        Try

            If e.Button = System.Windows.Forms.MouseButtons.Right Then

                If Dato.Type = DataGridViewHitTestType.Cell Then

                    If Dato.RowIndex >= 0 Then

                        Indice = Dato.RowIndex
                        DataGridView2.CurrentCell = DataGridView2.Rows(Dato.RowIndex).Cells(Dato.ColumnIndex)
                        DataGridView2.Rows(Dato.RowIndex).Selected = True
                        DataGridView2.ContextMenuStrip = MenuTaller2

                    End If

                End If

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub DataGridView3_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView3.CellFormatting
        'CellFormatting: Evento del control DataGridview el cual permite cambiar 
        'y dar formato a las celdas, bien sea por color de texto, fondo, etc.

        Try

            Dim EstadoReporte As String

            If DataGridView3.Columns(e.ColumnIndex).Name.Equals("ColumnaEstadoReporte2") Then

                EstadoReporte = (DataGridView3.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

                If EstadoReporte = "ABIERTO" Then

                    e.CellStyle.ForeColor = Color.Blue
                    DataGridView3.Rows(e.RowIndex).Cells("ColumnaImagen2").Value = Abierto

                End If

                If EstadoReporte = "CERRADO" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView3.Rows(e.RowIndex).Cells("ColumnaImagen2").Value = Cerrado

                End If

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub BotonModificar_Click(sender As Object, e As EventArgs) Handles BotonModificar.Click
        'Boton cerrar reporte

        Dim fecha2 = DateTimePicker1.Value.ToString("yyyy-MM-dd")
        Dim Mensaje As DialogResult

        Try

            'Si hay elementos Activos entonces se procede a cerrar el reporte
            If TextBox3.Text <> "" And TextBox4.Text = "ABIERTO" Then

                'Se valida la fecha a traves de la funcion
                If ValidarFecha() = True Then

                    Mensaje = MessageBox.Show("Esta seguro de guardar?", "Aviso.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                    'Si la respuesta es "Si"
                    If Mensaje = DialogResult.Yes Then

                        Dim db As New MySqlCommand("UPDATE registrotaller SET estado = 'CERRADO', fechasalida = '" & fecha2 & "' WHERE idregistrotaller = '" & TextBox3.Text & "' ", cnn)
                        db.ExecuteNonQuery()
                        MsgBox("Reporte cerrado con Exito.", MsgBoxStyle.Information, "Exito.")

                        'Actualizamos el vehiculo como "operativo" cuando se cierra un reporte
                        ActualizarVehiculo2()

                    End If

                    'Actualizamos los valores agregados
                    CargarGridSeguimientoTaller()
                    CargarGridHistorialTaller()

                    'Luego de guardar nos posicionamos en la fila ya seleccionada anteriormente
                    'para verificar la inclusion de la ruta en el datagridview2.
                    DataGridView1.CurrentCell = DataGridView1(ColumnaTaller, FilaTaller)

                    'Actualizamos la fecha a la actual del dia de hoy
                    DateTimePicker1.Value = Today

                End If

                'Si no hay elementos activos, no se puede cerrar el reporte
            ElseIf TextBox3.Text = "" Or TextBox4.Text = "CERRADO" Then

                MsgBox("No puede cerrar un reporte ya completado. Verifique la información.", MsgBoxStyle.Exclamation, "Error.")

            End If

        Catch ex As Exception

            MsgBox("Debe verificar los datos suministrados.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub BotonExportar_Click(sender As Object, e As EventArgs) Handles BotonExportar.Click
        'Boton Exportar a Excel

        Try

            If DataGridView2.RowCount > 0 Or DataGridView3.RowCount > 0 Then

                Dim Mensaje As DialogResult

                Mensaje = MessageBox.Show("Desea expotar el listado?", "Aviso.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                'Si la respuesta es "Si"
                If Mensaje = DialogResult.Yes Then

                    If Panel7.SelectedIndex = 0 Then

                        Exportar(DataGridView2)

                    ElseIf Panel7.SelectedIndex = 1 Then

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

    Private Sub BotonSalir_Click(sender As Object, e As EventArgs) Handles BotonSalir.Click
        'Boton salir

        If DataGridView1.RowCount > 0 Or DataGridView2.RowCount > 0 Then

            Tabla.Clear()
            DataSet.Clear()

            'Cierre formal del formulario liberando recursos
            Dispose()

        Else

            'Cierre formal de la ventana sin liberar recursos
            Close()

        End If

    End Sub

    Private Sub ComboArbol_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboArbol.SelectedIndexChanged
        'Evento donde seleccionamos el combobox y el elemento se va directamente al textbox
        'inmediatamente cargamos el datagridview para actualizar.

        Dim Nombre As String

        TextBox2.Text = ComboArbol.Text
        Nombre = TextBox2.Text
        flota.Text = Nombre

        CargarGridSeguimientoTaller()

    End Sub

    Private Sub DateTimePicker1_TextChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.TextChanged
        'Enviamos la fecha seleccionada al textbox

        TextBox7.Text = DateTimePicker1.Value.ToString("dd/MM/yyyy")

    End Sub

    Function ValidarFecha() As Boolean
        'Funcion que permite validar si la fecha es mayor o menor

        Dim Validar As Boolean = True

        If TextBox6.Text > TextBox7.Text Then

            MsgBox("La fecha de cierre no puede ser menor que la fecha de apertura.", MsgBoxStyle.Exclamation, "Error.")
            Validar = False

        End If

        Return Validar

    End Function

    Private Sub MenuAgregarReporte_Click(sender As Object, e As EventArgs) Handles MenuAgregarReporte.Click
        'Llamada al formulario RegistrarReporteTaller

        Try

            If DataGridView1.RowCount > 0 And DataGridView1.SelectedRows.Count = 1 Then

                'Enviamos el id correspondiente al textbox3 del formulario RegistrarReporteTaller
                RegistrarReporteTaller.TextBox3.Text = DataGridView1.Item("ID", DataGridView1.SelectedRows(0).Index).Value

                'Actualizamos el id de la serie correspondiente
                SerieTaller()

                'Colocamos la fecha actual
                RegistrarReporteTaller.DateTimePicker1.Value = Today
                RegistrarReporteTaller.DateTimePicker2.Value = Today

                'Despliegue del formulario
                RegistrarReporteTaller.ShowDialog()

                'Mantenemos posicion y enfoque en la fila seleccionada
                FilaTaller = DataGridView1.CurrentRow.Index
                ColumnaTaller = 1

            End If

        Catch ex As Exception


        End Try

    End Sub

    Private Sub MenuModificarReporte_Click(sender As Object, e As EventArgs) Handles MenuModificarReporte.Click
        'Evento que genera la apertura del formulario "RegistrarReporteTaller" para registrar nuevos reportes

        Try

            If DataGridView2.RowCount > 0 And DataGridView2.SelectedRows.Count = 1 Then

                'Enviamos los datos seleccionados a los textbox de RegistrarReporteTaller

                If TextBox4.Text = "ABIERTO" Then

                    RegistrarReporteTaller.TextBox1.Text = DataGridView2.Item("ColumnaID", DataGridView2.SelectedRows(0).Index).Value

                    RegistrarReporteTaller.TextBox3.Text = DataGridView2.Item("ColumnaVehiculo", DataGridView2.SelectedRows(0).Index).Value

                    RegistrarReporteTaller.DateTimePicker1.Value = DataGridView2.Item("ColumnaFechaIngreso", DataGridView2.SelectedRows(0).Index).Value

                    RegistrarReporteTaller.Combo1.Text = DataGridView2.Item("ColumnaArea", DataGridView2.SelectedRows(0).Index).Value

                    RegistrarReporteTaller.TextBox4.Text = DataGridView2.Item("ColumnaFalla", DataGridView2.SelectedRows(0).Index).Value

                    RegistrarReporteTaller.BotonModificar.Enabled = True

                    RegistrarReporteTaller.BotonGuardar.Enabled = False

                    RegistrarReporteTaller.ShowDialog()

                ElseIf TextBox4.Text = "CERRADO" Then

                    MsgBox("No puede cerrar un reporte ya completado. Verifique la información.", MsgBoxStyle.Exclamation, "Error.")

                End If

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Function ValidarEstadoRevision() As Boolean
        'Funcion que permite validar si la fecha es mayor o menor

        Dim Validar As Boolean = True

        If TextBox6.Text > TextBox7.Text Then


            Validar = False

        End If

        Return Validar

    End Function

    Private Sub Panel1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Panel7.SelectedIndexChanged
        'Evento donde se seleccionan los tabs del tabcontrol (paginas) y luego se cargan metodos dependiendo del index del tab

        If Panel7.SelectedIndex = 0 Then

            BotonModificar.Enabled = True

        End If

        If Panel7.SelectedIndex = 1 Then

            BotonModificar.Enabled = False

        End If

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        ConsultaSeguimientoTaller.Show()

    End Sub


End Class
