
Public Class SeguimientoLiviano

    Dim Fila As Integer
    Dim Columna As Integer

    Private Sub SeguimientoLiviano_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Metodos que cargaran al momento de desplegar el formulario.

        InicializarTimer()

        'Llamada al metodo que permite cargar el listview de opciones proveniente del Modulo.
        CargarArbolLiviano()

        'Validamos que el primer item seleccionado en el arbol sea el primero
        Arbol.SelectedNode = Arbol.Nodes(0)

        'Se habilita la serie correlativa para el ID de las rutas.
        SerieInfraccionRutaLiviano()
        SerieIncidenciaRutaLiviano()
        SerieConsumoRutaLiviano()

        'Llamada al metodo para alternar los colores de las filas
        AlternarFilasGeneral(DataGridView1)
        AlternarFilasGeneral(DataGridView2)
        AlternarFilasGeneral(DataGridView3)
        AlternarFilasGeneral(DataGridView4)

        'Se llama al metodo para que cargue rapido los componentes
        EnableDoubleBuffered(DataGridView1)
        EnableDoubleBuffered(DataGridView2)
        EnableDoubleBuffered(DataGridView3)
        EnableDoubleBuffered(DataGridView4)

        'Letras en mayusculas
        TextBox7.CharacterCasing = CharacterCasing.Upper

        DateTimePicker1.Value = Today
        DateTimePicker2.Value = Today

    End Sub

    Private Sub SeguimientoLiviano_FormClosing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
        'Al cerrar el formulario por el boton "x" se ejecutan los metodos del boton salir

        If DataGridView1.RowCount > 0 Or DataGridView2.RowCount > 0 Then

            'Llamada al metodo para poder limpiar el arbol y los componentes
            LimpiarArbolSeguimientoLiviano()
            LimpiarComponentesInfraccionLiviano()
            LimpiarComponentesIncidenciaLiviano()

            Tabla.Clear()
            DataSet.Clear()

            'Cierre formal del formulario liberando recursos
            Dispose()

        Else

            'Cierre formal de la ventana sin liberar recursos
            Close()

        End If

    End Sub

    Private Sub InicializarTimer()
        'Metodo que inicializa el timer

        Timer1.Start()
        Timer1.Interval = 1000

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Control Timer: se lleva el tiempo para que la hora y la fecha pueda ser actualizada constantemente

        'Control de rutas: Livianos
        SerieInfraccionRutaLiviano()
        SerieIncidenciaRutaLiviano()
        SerieConsumoRutaLiviano()

        TextBox5.Text = DateTime.Now.ToShortTimeString()
        TextBox8.Text = DateTime.Now.ToShortTimeString()
        TextBox20.Text = DateTime.Now.ToShortTimeString()

    End Sub

    Private Sub Arbol_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles Arbol.AfterSelect
        'AfterSelect: propiedad del control TreeView (Arbol) en el cual se seleccionan
        'los elementos provenientes de la base de batos y se carga el metodo
        'CargarGrid el cual genera el ID del vehiculo perteneciente a la flota seleccionada
        'a traves de la clausura LIKE en la sentencia SQL
        'MENU DE OPCIONES DINAMICO (SIN NODO PADRE). SE PUEDEN AGREGAR NUEVAS FLOTAS.

        Try

            Dim Nombre As String

            'Enviamos el nombre de la flota al textbox mediante la propiedad node.text
            TextBox1.Text = e.Node.Text

            'Una ves conocido el nombre de la flota, se procede a cargar los vehiculos asociados a el.
            CargarGridRutaLiviano()

            'Enviamos el texto seleccionado a la variable, label, etc.
            Nombre = TextBox1.Text
            flota.Text = Nombre

            'Enviamos el texto seleccionado al titulo del tabcontrol.
            Panel4.Text = "FLOTA: " & Nombre

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.1", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        'CellFormatting: Evento del control DataGridview el cual permite cambiar 
        'y dar formato a las celdas, bien sea por color de texto, fondo, etc.

        Try

            Dim EstadoVehiculo As String

            If DataGridView1.Columns(e.ColumnIndex).Name.Equals("ColumnaEstadoVehiculo") Then

                EstadoVehiculo = (DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

                If EstadoVehiculo = "OPERATIVO" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen").Value = Operativo

                End If

                If EstadoVehiculo = "EN SERVICIO" Or EstadoVehiculo = "EN REPARACIÓN" Then

                    e.CellStyle.ForeColor = Color.Blue
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen").Value = EnReparacion

                End If

                If EstadoVehiculo = "UNIDAD SIN REPORTE DE GPS" Or EstadoVehiculo = "UNIDAD SIN DISPOSITIVO GPS" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen").Value = SinReporte

                End If

                If EstadoVehiculo = "ROBADO / EXTRAVIADO" Or EstadoVehiculo = "INACTIVO" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen").Value = Robado

                End If

                If EstadoVehiculo = "GPS PRESENTANDO FALLAS" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen").Value = Falla

                End If

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.2", MsgBoxStyle.Exclamation, "Error.")

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
                TextBox2.Text = DataGridView1.Item("ColumnaID", DataGridView1.SelectedRows(0).Index).Value
                TextBox3.Text = DataGridView1.Item("ColumnaID", DataGridView1.SelectedRows(0).Index).Value
                TextBox21.Text = DataGridView1.Item("ColumnaID", DataGridView1.SelectedRows(0).Index).Value

                LimpiarComponentesInfraccionLiviano()
                LimpiarComponentesIncidenciaLiviano()
                LimpiarComponentesConsumoLiviano()

            End If

            'Enviamos el texto seleccionado a la variable, label, etc.
            Nombre = TextBox2.Text
            vehiculo.Text = Nombre

            'Luego de seleccionar el valor en el DataGridView1 llamamos al metodo 
            'CargarGridHistorial para cargar lo correspondiente.
            CargarGridHistorialInfraccionLiviano()
            CargarGridHistorialIncidenciaLiviano()
            CargarGridHistorialConsumoLiviano()


        Catch ex As Exception

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

                            DataGridView1.ContextMenuStrip = MenuOpciones

                        Else

                            DataGridView1.ContextMenuStrip = Nothing

                        End If

                    End If

                    'Si seleccionamos con click derecho, obtenemos el index de la fila seleccionada y posicionamos el enfoque
                    Fila = DataGridView1.CurrentRow.Index
                    Columna = 1

                End If

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub DataGridView2_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView2.SelectionChanged
        'SelectionChanged o CellMouseClick: Propiedad del control DataGridview el cual permite hacer click
        'y seleccionar elementos por filas o columnas.
        'en este caso se selecciona el ID del vehiculo el cual es pasado a un control
        'TextBox pasa su posterior uso.

        Try

            If DataGridView2.RowCount > 0 And DataGridView2.SelectedRows.Count = 1 Then

                'Seleccionamos y pasamos el valor al TextBox.
                TextBox16.Text = DataGridView2.Item("ColumnaChofer", DataGridView2.SelectedRows(0).Index).Value
                ObtenerPersonalSeguimientoLivianoInfraccion()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridView2_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView2.MouseClick
        'Metodo o evento que permite generar menu contextual con click derecho

        Try

            If DataGridView2.RowCount > 0 Or DataGridView2.SelectedRows.Count = 1 Then

                DataGridView2.ContextMenuStrip = MenuRuta2

            Else

                DataGridView2.ContextMenuStrip = Nothing

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

            If e.Button = MouseButtons.Right Then

                If Dato.Type = DataGridViewHitTestType.Cell Then

                    If Dato.RowIndex >= 0 Then

                        Indice = Dato.RowIndex
                        DataGridView2.CurrentCell = DataGridView2.Rows(Dato.RowIndex).Cells(Dato.ColumnIndex)
                        DataGridView2.Rows(Dato.RowIndex).Selected = True
                        DataGridView2.ContextMenuStrip = MenuRuta2

                    End If

                End If

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub DataGridView3_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView3.SelectionChanged
        'SelectionChanged o CellMouseClick: Propiedad del control DataGridview el cual permite hacer click
        'y seleccionar elementos por filas o columnas.
        'en este caso se selecciona el ID del vehiculo el cual es pasado a un control
        'TextBox pasa su posterior uso.

        Try

            If DataGridView3.RowCount > 0 And DataGridView3.SelectedRows.Count = 1 Then

                'Seleccionamos y pasamos el valor al TextBox.
                TextBox17.Text = DataGridView3.Item("ColumnaChofer2", DataGridView3.SelectedRows(0).Index).Value
                ObtenerPersonalSeguimientoLivianoIncidencia()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridView4_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView4.SelectionChanged
        'SelectionChanged o CellMouseClick: Propiedad del control DataGridview el cual permite hacer click
        'y seleccionar elementos por filas o columnas.
        'en este caso se selecciona el ID del vehiculo el cual es pasado a un control
        'TextBox pasa su posterior uso.

        Try

            If DataGridView4.RowCount > 0 And DataGridView4.SelectedRows.Count = 1 Then

                TextBox24.Text = DataGridView4.Item("ColumnaChofer3", DataGridView4.SelectedRows(0).Index).Value
                ObtenerPersonalSeguimientoLivianoConsumo()

            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub BotonSalir_Click(sender As Object, e As EventArgs) Handles BotonSalir.Click
        'Boton salir

        If DataGridView1.RowCount > 0 Or DataGridView2.RowCount > 0 Then

            'Llamada al metodo para poder limpiar el arbol y los componentes
            LimpiarArbolSeguimientoLiviano()
            LimpiarComponentesInfraccionLiviano()
            LimpiarComponentesIncidenciaLiviano()

            Tabla.Clear()
            DataSet.Clear()

            'Cierre formal del formulario liberando recursos
            Dispose()

        Else

            'Cierre formal de la ventana sin liberar recursos
            Close()

        End If

    End Sub

    Private Sub BotonGuardar1_Click(sender As Object, e As EventArgs) Handles BotonGuardar1.Click
        'Boton registrar Infraccion

        Try

            Dim fecha = DateTimePicker1.Value.ToString("yyyy-MM-dd")

            'Se valida que no haya algun campo vacio
            If ValidarComponentesInfraccionLiviano() = True Then

                Dim db As New MySqlCommand("INSERT INTO registroinfraccion (idregistroinfraccion, vehiculo, personal, velocidad, estadovehiculo, fecha, hora) VALUES ('" & TextBox9.Text & "', '" & TextBox2.Text & "', '" & TextBox6.Text & "', '" & TextBox4.Text & "', '" & TextBox11.Text & "', '" & fecha & "', '" & TextBox5.Text & "')", Conexion)
                db.ExecuteNonQuery()
                MsgBox("Infracción registrada con Exito.", MsgBoxStyle.Information, "Exito.")

                'Se limpian todos los componentes del formulario para un nuevo uso.
                LimpiarComponentesInfraccionLiviano()
                'Se habilita el metodo para incrementar el siguiente ID.
                SerieInfraccionRutaLiviano()

                CargarGridHistorialInfraccionLiviano()

            End If

        Catch ex As Exception

            MsgBox("Debe verificar los datos de la infracción.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub BotonGuardar2_Click(sender As Object, e As EventArgs) Handles BotonGuardar2.Click
        'Boton registrar Incidencia

        Try

            Dim fecha = DateTimePicker1.Value.ToString("yyyy-MM-dd")

            'Se valida que no haya algun campo vacio
            If ValidarComponentesIncidenciaLiviano() = True Then

                Dim db As New MySqlCommand("INSERT INTO registroincidencia (idregistroincidencia, vehiculo, personal, descripcion, clasificacion, fecha, hora) VALUES ('" & TextBox12.Text & "', '" & TextBox3.Text & "', '" & TextBox18.Text & "', '" & TextBox7.Text & "', '" & TextBox13.Text & "', '" & fecha & "', '" & TextBox8.Text & "')", Conexion)
                db.ExecuteNonQuery()
                MsgBox("Incidencia registrada con Exito.", MsgBoxStyle.Information, "Exito.")

                'Se limpian todos los componentes del formulario para un nuevo uso.
                LimpiarComponentesIncidenciaLiviano()
                'Se habilita el metodo para incrementar el siguiente ID.
                SerieIncidenciaRutaLiviano()

                CargarGridHistorialIncidenciaLiviano()

            End If

        Catch ex As Exception

            MsgBox("Debe verificar los datos de la incidencia.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub BotonGuardar3_Click(sender As Object, e As EventArgs) Handles BotonGuardar3.Click
        'Boton registrar Incidencia

        Try

            Dim fecha = DateTimePicker1.Value.ToString("yyyy-MM-dd")

            'Se valida que no haya algun campo vacio
            If ValidarComponentesConsumoLiviano() = True Then

                Dim db As New MySqlCommand("INSERT INTO registroconsumo (idregistroconsumo, vehiculo, personal, cantidad, fecha, hora) VALUES ('" & TextBox23.Text & "', '" & TextBox21.Text & "', '" & TextBox26.Text & "', '" & TextBox22.Text & "', '" & fecha & "', '" & TextBox20.Text & "')", Conexion)
                db.ExecuteNonQuery()
                MsgBox("Consumo registrado con Exito.", MsgBoxStyle.Information, "Exito.")

                'Se limpian todos los componentes del formulario para un nuevo uso.
                LimpiarComponentesConsumoLiviano()
                'Se habilita el metodo para incrementar el siguiente ID.
                SerieConsumoRutaLiviano()

                CargarGridHistorialConsumoLiviano()

            End If

        Catch ex As Exception

            MsgBox("Debe verificar los datos del consumo.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub BotonGuiaTelefonica_Click(sender As Object, e As EventArgs) Handles BotonGuiaTelefonica.Click
        'Llamada al formulario "GuiaTelefonica"

        GuiaTelefonica.Show()

    End Sub

    Private Sub BotonBuscar_Click(sender As Object, e As EventArgs) Handles BotonBuscar1.Click
        'Llama al formulario ListadoPersona.

        ListadoPersonal.ComboEstadoPersona.Enabled = False
        ListadoPersonal.ShowDialog()

    End Sub

    Private Sub BotonBuscar2_Click(sender As Object, e As EventArgs) Handles BotonBuscar2.Click
        'Llama al formulario ListadoPersona.

        ListadoPersonal.ComboEstadoPersona.Enabled = False
        ListadoPersonal.ComboTipoPersona.SelectedItem = "LIVIANO"
        ListadoPersonal.ShowDialog()


    End Sub

    Private Sub BotonBuscar3_Click(sender As Object, e As EventArgs) Handles BotonBuscar3.Click
        'Llama al formulario ListadoPersona.

        ListadoPersonal.ComboEstadoPersona.Enabled = False
        ListadoPersonal.ComboTipoPersona.SelectedItem = "LIVIANO"
        ListadoPersonal.ShowDialog()

    End Sub

    Private Sub BotonListado_Click(sender As Object, e As EventArgs) Handles BotonListado.Click
        'Llamada al formulario "ListadoVehiculoCarretera" para chequear cual es el total de vehiculos en carretera actualizado.

        ListadoGeneralRutas.ShowDialog()

    End Sub

    Private Sub BotonConsulta2_Click(sender As Object, e As EventArgs) Handles BotonConsulta2.Click
        'Llama al formulario ReporteInfraccion.

        ReporteInfraccion.ShowDialog()

    End Sub

    Private Sub MenuAgregarInfracción_Click(sender As Object, e As EventArgs) Handles MenuAgregarInfracción.Click
        'Llamada al formulario MaestroInfraccion

        Try

            If DataGridView1.RowCount > 0 And DataGridView1.SelectedRows.Count = 1 Then

                MaestroInfraccion.TextBox2.Text = TextBox2.Text
                MaestroInfraccion.TextBox4.Text = TextBox15.Text
                MaestroInfraccion.TextBox7.Text = TextBox11.Text
                MaestroInfraccion.TextBox8.Text = TextBox10.Text
                MaestroInfraccion.BotonBuscar.Enabled = False
                MaestroInfraccion.BotonBuscar2.Enabled = False

                MaestroInfraccion.RadioButton2.Checked = True

                ObtenerPersonalInfraccionCarga()
                MaestroInfraccion.ShowDialog()

                'Posicionamos el currencell en el vehiculo que clickeamos anteriormente
                DataGridView1.CurrentCell = DataGridView1(Columna, Fila)

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub MenuAgregarIncidencia_Click(sender As Object, e As EventArgs) Handles MenuAgregarIncidencia.Click
        'Llamada al formulario MaestroIncidencia

        Try

            If DataGridView1.RowCount > 0 And DataGridView1.SelectedRows.Count = 1 Then

                MaestroIncidencia.TextBox2.Text = TextBox3.Text
                MaestroIncidencia.TextBox4.Text = TextBox15.Text
                MaestroIncidencia.TextBox7.Text = TextBox13.Text
                MaestroIncidencia.BotonBuscar.Enabled = False
                MaestroIncidencia.BotonBuscar2.Enabled = False

                ObtenerPersonaIncidenciaCarga()
                MaestroIncidencia.ShowDialog()

                'Posicionamos el currencell en el vehiculo que clickeamos anteriormente
                DataGridView1.CurrentCell = DataGridView1(Columna, Fila)

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub MenuEditarVehiculo_Click(sender As Object, e As EventArgs) Handles MenuEditarVehiculo.Click
        'Evento que permite hacer dobleclick y llevarse el id del vehiculo y manejar 
        'la botonera del formulario MaestroVehiculo para poder editar los estados.

        Try

            If DataGridView1.RowCount > 0 And DataGridView1.SelectedRows.Count = 1 Then

                MaestroVehiculo.TextBox1.Text = TextBox2.Text
                MaestroVehiculo.TextBox1.Enabled = False
                MaestroVehiculo.ComboGrupo.Enabled = True
                MaestroVehiculo.ComboTipo.Enabled = True
                MaestroVehiculo.ComboCondicion.Enabled = True
                MaestroVehiculo.ComboEstado.Enabled = False
                MaestroVehiculo.ComboClasificacion.Enabled = True
                MaestroVehiculo.BotonModificar.Enabled = True
                MaestroVehiculo.BotonGuardar.Enabled = False
                MaestroVehiculo.BotonBuscar.Enabled = False
                MaestroVehiculo.ShowDialog()

                'Posicionamos el currencell en el vehiculo que clickeamos anteriormente
                DataGridView1.CurrentCell = DataGridView1(Columna, Fila)

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        'Evento KeyPress: permite agregar solo numeros en el textbox.

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not TextBox4.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub Panel5_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Panel5.SelectedIndexChanged
        'Evento donde se seleccionan los tabs del tabcontrol (paginas) y luego se cargan metodos dependiendo del index del tab

        If Panel5.SelectedIndex = 0 Then

            Panel6.SelectedIndex = 0

        End If

        If Panel5.SelectedIndex = 1 Then

            Panel6.SelectedIndex = 1

        End If

        If Panel5.SelectedIndex = 2 Then

            Panel6.SelectedIndex = 2

        End If

    End Sub

    Private Sub Panel6_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Panel6.SelectedIndexChanged
        'Evento donde se seleccionan los tabs del tabcontrol (paginas) y luego se cargan metodos dependiendo del index del tab

        If Panel6.SelectedIndex = 0 Then

            Panel5.SelectedIndex = 0

        End If

        If Panel6.SelectedIndex = 1 Then

            Panel5.SelectedIndex = 1

        End If

        If Panel6.SelectedIndex = 2 Then

            Panel5.SelectedIndex = 2

        End If

    End Sub

    Private Sub BotonVehiculo_Click(sender As Object, e As EventArgs) Handles BotonVehiculo.Click
        'Llamada al formulario MaestroIncidencia

        MaestroVehiculo.ShowDialog()

    End Sub

    Private Sub BotonPersonal_Click(sender As Object, e As EventArgs) Handles BotonPersonal.Click
        'Llamada al formulario MaestroPersonal

        MaestroPersonal.BotonBuscar.Enabled = False
        MaestroPersonal.ShowDialog()

    End Sub

    Private Sub MenuEliminar_Click(sender As Object, e As EventArgs) Handles MenuEliminar.Click
        'Metodo que permite eliminar items del historial

        Try

            If DataGridView2.RowCount > 0 And DataGridView2.SelectedRows.Count = 1 Then

                EliminarItemLiviano()

                'Luego de eliminar nos posicionamos en la fila ya seleccionada anteriormente
                'DataGridView1.CurrentCell = DataGridView1(Columna, Fila)

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub


End Class