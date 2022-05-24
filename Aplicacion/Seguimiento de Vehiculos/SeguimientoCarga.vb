﻿
Public Class SeguimientoCarga

    Dim Fila As Integer
    Dim Columna As Integer
    Dim Contador As Integer = 0

    Private Sub SeguimientoCarga_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        'Metodos que cargaran al momento de desplegar el formulario.

        'Metodo que inicializa el timer
        Timer1.Start()
        Timer1.Interval = 1000

        'Llamada al metodo que permite cargar el arbol de opciones proveniente del Modulo.
        CargarArbolCarga()

        'Validamos que el primer item seleccionado en el arbol sea el primero
        Arbol.SelectedNode = Arbol.Nodes(0).Nodes(0) 'SELECCIONAMOS EL PRIMER HIJO
        'Arbol.SelectedNode = Arbol.Nodes(0) 'SELECCIONAMOS EL PRIMER PADRE

        'Se habilita la serie correlativa para el ID de las rutas.
        SerieRutaCarga()

        'Carga del combobox por valores de BD.
        CargarComboEstadoRutaCarga()

        'Se llama al metodo para que cargue rapido los componentes
        EnableDoubleBuffered(Arbol)
        EnableDoubleBuffered(ComboBox1)
        EnableDoubleBuffered(DataGridView1)
        EnableDoubleBuffered(DataGridView2)

        'Llamada al metodo para alternar los colores de las filas
        AlternarFilasGeneral(DataGridView1)
        AlternarFilasGeneral(DataGridView2)

        'Cargamos la cantidad de vehiculos en ruta actualizado
        ObtenerCantidadVehiculos()

    End Sub

    Private Sub SeguimientoCarga_FormClosing(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.FormClosing
        'Al cerrar el formulario por el boton "x" se ejecutan los metodos del boton salir

        If DataGridView1.RowCount > 0 Or DataGridView2.RowCount > 0 Then

            'Llamada al metodo para poder limpiar el arbol
            LimpiarArbolSeguimientoCarga()
            LimpiarComponentesSeguimientoCarga()

            Tabla.Clear()
            DataSet.Clear()

            'Cierre formal del formulario liberando recursos
            Dispose()

        Else

            'Cierre formal del formulario liberando recursos
            Dispose()

        End If

    End Sub

    Private Sub SeguimientoCarga_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        'Evento que permite cerrar el formulario presionando la tecla esc

        If (e.KeyCode = Keys.Escape) Then

            ComboBox1.Dispose()

            If DataGridView1.RowCount > 0 Or DataGridView2.RowCount > 0 Then

                'Llamada al metodo para poder limpiar el arbol
                LimpiarArbolSeguimientoCarga()
                LimpiarComponentesSeguimientoCarga()

                Tabla.Clear()
                DataSet.Clear()

                'Cierre formal del formulario liberando recursos
                Dispose()

            Else

                'Cierre formal del formulario liberando recursos
                Dispose()

            End If

        End If

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Control Timer: se lleva el tiempo para que la hora y la fecha pueda ser actualizada constantemente

        'Contamos y enviamos el tiempo al label
        Contador += 1
        Tiempo.Text = Contador

        'Si el tiempo llega a 300 seg (5min) se cierra la aplicacion
        If Contador = 600 Then

            If DataGridView1.RowCount > 0 Or DataGridView2.RowCount > 0 Then

                'Llamada al metodo para poder limpiar el arbol
                LimpiarArbolSeguimientoCarga()
                LimpiarComponentesSeguimientoCarga()

                Tabla.Clear()
                DataSet.Clear()

                'Cierre formal del formulario liberando recursos
                Dispose()

            Else

                'Cierre formal del formulario liberando recursos
                Dispose()

            End If

        End If

        'Control de rutas: carga
        SerieRutaCarga()

        TextBox15.Text = DateTime.Now.ToShortTimeString()
        DateTimePicker1.Value = Today

    End Sub

    Private Sub ReiniciarTiempo()
        'Se detiene el tiempo, reiniciamos el contador y volvemos a iniciar el conteo del tiempo

        Timer1.Stop()

        Contador = 0

        Timer1.Start()

    End Sub

    Private Sub SeguimientoCarga_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        'Al mover el mouse sobre el formulario se reinicia el tiempo y evitamos el cierre de la aplicacion

        ReiniciarTiempo()

    End Sub

    Private Sub SeguimientoCarga_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        'Al dar click sobre el formulario se reinicia el tiempo y evitamos el cierre de la aplicacion

        ReiniciarTiempo()

    End Sub

    Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
        'Al mover el mouse sobre el panel se reinicia el tiempo y evitamos el cierre de la aplicacion

        ReiniciarTiempo()

    End Sub

    Private Sub MenuPrincipal_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuPrincipal.ItemClicked
        'Al dar click en el menu se reinicia el tiempo y evitamos el cierre de la aplicacion

        ReiniciarTiempo()

    End Sub

    Private Sub MenuPrincipal_MouseClick(sender As Object, e As MouseEventArgs) Handles MenuPrincipal.MouseClick
        'Al dar click en el menu se reinicia el tiempo y evitamos el cierre de la aplicacion

        ReiniciarTiempo()

    End Sub

    Private Sub MenuPrincipal_MouseMove(sender As Object, e As MouseEventArgs) Handles MenuPrincipal.MouseMove
        'Al mover el mouse sobre el menu se reinicia el tiempo y evitamos el cierre de la aplicacion

        ReiniciarTiempo()

    End Sub

    Private Sub Arbol_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles Arbol.AfterSelect
        'AfterSelect: propiedad del control TreeView (Arbol) en el cual se seleccionan
        'los elementos provenientes de la base de batos y se carga el metodo
        'CargarGrid el cual genera el ID del vehiculo perteneciente a la flota seleccionada
        'a traves de la clausura LIKE en la sentencia SQL
        'MENU DE OPCIONES DINAMICO. SE PUEDEN AGREGAR NUEVAS FLOTAS.

        Try

            Dim Nombre As String

            'Enviamos el nombre de la flota al textbox4 mediante la propiedad node.text
            TextBox4.Text = e.Node.Text

            'se carga solamente el grupo seleccionado
            CargarGridRutaCargaGrupo()

            'Enviamos el texto seleccionado a la variable, label, etc.
            Nombre = TextBox4.Text
            flota.Text = Nombre

            'Enviamos el texto seleccionado al titulo del tabcontrol.
            Panel1.Text = "FLOTA: " & Nombre

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.1", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub Arbol_BeforeCollapse(sender As Object, e As TreeViewCancelEventArgs) Handles Arbol.BeforeCollapse
        'Evento que permite que el arbol no se contraiga

        'e.Cancel = True

    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        'CellFormatting: Evento del control DataGridview el cual permite cambiar 
        'y dar formato a las celdas, bien sea por color de texto, fondo, etc.

        Try

            Dim TipoEstado As String
            Dim EstadoVehiculo As String

            'Indicamos sobre cual columna trabajaremos.
            If DataGridView1.Columns(e.ColumnIndex).Name.Equals("ColumnaEstadoVehiculo") Then

                TipoEstado = (DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

                'Verificamos los valores del estado y asignamos los colores e iconos.
                If TipoEstado = "EN RUTA VACIO" Or TipoEstado = "EN RUTA CARGADO" Then

                    e.CellStyle.ForeColor = Color.Green
                    'Colocamos imagen a la celda de acuerdo al valor obtenido
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen1").Value = EnRutaVacio

                End If

                If TipoEstado = "DE REGRESO CARGADO" Or TipoEstado = "DE REGRESO VACIO" Then

                    e.CellStyle.ForeColor = Color.Red
                    'Colocamos imagen a la celda de acuerdo al valor obtenido
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen1").Value = DeRegresoVacio

                End If

                If TipoEstado = "VEHICULO GUARDADO" Then

                    e.CellStyle.ForeColor = Color.Purple
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen1").Value = OrganizacionElTunal

                End If

                If TipoEstado = "PERNOCTA AUTORIZADA" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen1").Value = PernoctaAutorizada

                End If

                If TipoEstado = "EN PROCESO DE CARGA" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen1").Value = EnProcesoDeCarga

                End If

                If TipoEstado = "EN PROCESO DE DESCARGA" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen1").Value = EnProcesoDeDescarga

                End If

                If TipoEstado = "CARGADO ESPERANDO POR SALIR" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen1").Value = CargadoEsperandoPorSalir

                End If

                If TipoEstado = "CARGADO ESPERANDO DOCUMENTOS" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen1").Value = CargadoEsperandoDocumentos

                End If

                If TipoEstado = "ESPERANDO AUTORIZACIÓN PARA SALIR" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen1").Value = EsperandoAutorizacionParaSalir

                End If

                If TipoEstado = "DETENIDO" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen1").Value = Detenido

                End If

                If TipoEstado = "ACCIDENTADO" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen1").Value = Accidentado

                End If

                If TipoEstado = "PARADA IRREGULAR" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen1").Value = ParadaIrregular

                End If

                If TipoEstado = "EN TALLER" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen1").Value = EnTaller

                End If

                If TipoEstado = "ESPERANDO POR SALIR" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen1").Value = EsperandoPorSalir

                End If

                If TipoEstado = "EN EL CLIENTE" Or TipoEstado = "EN EL PROVEEDOR" Then

                    e.CellStyle.ForeColor = Color.Blue
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen1").Value = EnElClienteEnElProveedor

                End If

                If TipoEstado = "REALIZANDO MOVIMIENTOS Ó ACARREOS" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen1").Value = RealizandoMovimientos

                End If

                If TipoEstado = "RUTA CANCELADA" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen1").Value = RutaCancelada

                End If

            End If

            If DataGridView1.Columns(e.ColumnIndex).Name.Equals("ColumnaEstadoVehiculo2") Then

                EstadoVehiculo = (DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

                If EstadoVehiculo = "OPERATIVO" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen2").Value = Operativo

                End If

                If EstadoVehiculo = "EN SERVICIO" Or EstadoVehiculo = "EN REPARACIÓN" Then

                    e.CellStyle.ForeColor = Color.Blue
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen2").Value = EnReparacion

                End If

                If EstadoVehiculo = "UNIDAD SIN REPORTE DE GPS" Or EstadoVehiculo = "UNIDAD SIN DISPOSITIVO GPS" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen2").Value = SinReporte

                End If

                If EstadoVehiculo = "ROBADO / EXTRAVIADO" Or EstadoVehiculo = "INACTIVO" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen2").Value = Robado

                End If

                If EstadoVehiculo = "GPS PRESENTANDO FALLAS" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView1.Rows(e.RowIndex).Cells("ColumnaImagen2").Value = Falla

                End If

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.2", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub DataGridView1_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView1.CellMouseClick
        'Se usa el evento CellMouseClick para obtener el index de la fila seleccionada
        'y luego pasarlo al textbox para que pueda ser posicionado luego de guardar 

        Try

            If DataGridView1.RowCount > 0 And DataGridView1.SelectedRows.Count = 1 Then

                If e.Button = MouseButtons.Left Then

                    Fila = DataGridView1.CurrentRow.Index
                    Columna = 1

                End If

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.3", MsgBoxStyle.Exclamation, "Error.")

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
                TextBox1.Text = DataGridView1.Item("ColumnaID", DataGridView1.SelectedRows(0).Index).Value
                TextBox16.Text = DataGridView1.Item("ColumnaEstadoVehiculo2", DataGridView1.SelectedRows(0).Index).Value

                'Si se esta registrando informacion en otro ID de vehiculo y no se guarda
                'al seleccionar el siguiente ID limpiamos los componentes para un nuevo uso.
                LimpiarComponentesSeguimientoCarga()
                SerieRutaCarga()

                'Enviamos el texto seleccionado a la variable, label, etc.
                Nombre = TextBox1.Text
                vehiculo.Text = Nombre

            End If

            'Luego de seleccionar el valor en el DataGridView1 llamamos al metodo 
            'CargarGridHistorial para cargar lo correspondiente.
            'Historial de movimientos por vehiculo.
            CargarGridHistorialCarga()

            'Colocamos el historial en la primera pagina
            'Inicio()

            BotonInicio.Enabled = False
            BotonSiguiente.Enabled = False
            BotonAnterior.Enabled = True

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.4", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub DataGridView1_CellErrorTextNeeded(ByVal sender As Object, ByVal e As DataGridViewCellErrorTextNeededEventArgs) Handles DataGridView1.CellErrorTextNeeded
        'Evento CellErrorTextNeeded: se coloca un icono de advertencia o 
        'error en la celda seleccionada si cumple o no la condicion previa.

        Try

            Dim EstadoVehiculo2 As String

            If DataGridView1.Columns(e.ColumnIndex).Name.Equals("ColumnaEstadoVehiculo2") Then

                EstadoVehiculo2 = (DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

                If EstadoVehiculo2 = "EN REPARACIÓN" Then

                    e.ErrorText = "Vehículo en Reparación"

                End If

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.5", MsgBoxStyle.Exclamation, "Error.")

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

                            DataGridView1.ContextMenuStrip = MenuNovedadesVehiculo

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

            MsgBox("No se pudo completar la operación.6", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub DataGridView2_MouseClick(sender As Object, e As MouseEventArgs) Handles DataGridView2.MouseClick
        'Metodo o evento que permite generar menu contextual con click derecho

        Try

            If DataGridView2.RowCount > 0 Or DataGridView2.SelectedRows.Count = 1 Then

                DataGridView2.ContextMenuStrip = MenuRuta

            Else

                DataGridView2.ContextMenuStrip = Nothing

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.7", MsgBoxStyle.Exclamation, "Error.")

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
                        DataGridView2.ContextMenuStrip = MenuRuta

                    End If

                End If

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.8", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub DataGridView2_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView2.CellFormatting
        'CellFormatting: Propiedad del control DataGridview el cual permite cambiar 
        'y dar formato a las celdas, bien sea por color de texto, fondo, etc.

        Try

            Dim TipoEstado As String
            Dim TipoEstadoRuta As String

            'Indicamos sobre cual columna trabajaremos.
            If DataGridView2.Columns(e.ColumnIndex).Name.Equals("ColumnaEstado") Then

                'Captura el valor de la celda 
                TipoEstado = (DataGridView2.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

                'Verificamos los valores del estado y asignamos los colores e iconos.
                If TipoEstado = "EN RUTA VACIO" Or TipoEstado = "EN RUTA CARGADO" Then

                    'Colocamos color a la celda de acuerdo al valor obtenido
                    e.CellStyle.ForeColor = Color.Green
                    'Colocamos imagen a la celda de acuerdo al valor obtenido
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen").Value = EnRutaVacio

                End If

                If TipoEstado = "DE REGRESO CARGADO" Or TipoEstado = "DE REGRESO VACIO" Then

                    'Colocamos color a la celda de acuerdo al valor obtenido
                    e.CellStyle.ForeColor = Color.Red
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen").Value = DeRegresoVacio

                End If

                If TipoEstado = "VEHICULO GUARDADO" Then

                    e.CellStyle.ForeColor = Color.Purple
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen").Value = OrganizacionElTunal

                End If

                If TipoEstado = "PERNOCTA AUTORIZADA" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen").Value = PernoctaAutorizada

                End If

                If TipoEstado = "EN PROCESO DE CARGA" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen").Value = EnProcesoDeCarga

                End If

                If TipoEstado = "EN PROCESO DE DESCARGA" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen").Value = EnProcesoDeDescarga

                End If

                If TipoEstado = "CARGADO ESPERANDO POR SALIR" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen").Value = CargadoEsperandoPorSalir

                End If

                If TipoEstado = "CARGADO ESPERANDO DOCUMENTOS" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen").Value = CargadoEsperandoDocumentos

                End If

                If TipoEstado = "ESPERANDO AUTORIZACIÓN PARA SALIR" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen").Value = EsperandoAutorizacionParaSalir

                End If

                If TipoEstado = "DETENIDO" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen").Value = Detenido

                End If

                If TipoEstado = "ACCIDENTADO" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen").Value = Accidentado

                End If

                If TipoEstado = "PARADA IRREGULAR" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen").Value = ParadaIrregular

                End If

                If TipoEstado = "EN TALLER" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen").Value = EnTaller

                End If

                If TipoEstado = "ESPERANDO POR SALIR" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen").Value = EsperandoPorSalir

                End If

                If TipoEstado = "EN EL CLIENTE" Or TipoEstado = "EN EL PROVEEDOR" Then

                    e.CellStyle.ForeColor = Color.Blue
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen").Value = EnElClienteEnElProveedor

                End If

                If TipoEstado = "REALIZANDO MOVIMIENTOS Ó ACARREOS" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen").Value = RealizandoMovimientos

                End If

                If TipoEstado = "RUTA CANCELADA" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen").Value = RutaCancelada

                End If

            End If

            If DataGridView2.Columns(e.ColumnIndex).Name.Equals("ColumnaEstado2") Then

                'Captura el valor de la celda 
                TipoEstadoRuta = (DataGridView2.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

                If TipoEstadoRuta = "ACTIVA" Then

                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen3").Value = Activa
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen3").ToolTipText = "RUTA ACTIVA"

                End If

                If TipoEstadoRuta = "COMPLETADA" Then

                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen3").Value = Completada
                    DataGridView2.Rows(e.RowIndex).Cells("ColumnaImagen3").ToolTipText = "RUTA COMPLETADA"

                End If

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.9", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub DataGridView2_SelectionChanged(sender As Object, e As EventArgs) Handles DataGridView2.SelectionChanged
        'SelectionChanged o CellMouseClick:: Propiedad del control DataGridview el cual permite hacer click
        'y seleccionar elementos por celdas.

        Try

            If DataGridView2.SelectedRows.Count > 0 Then
                'Seleccionamos y pasamos los valores a los TextBox correspondientes.

                'ComboBox1.Text = DataGridView2.Rows(DataGridView2.CurrentRow.Index).Cells(7).Value()
                ComboBox1.Text = DataGridView2.Item("ColumnaEstado", DataGridView2.SelectedRows(0).Index).Value

                TextBox24.Text = DataGridView2.Item("ColumnaID2", DataGridView2.SelectedRows(0).Index).Value
                'Llamamos al metodo ObtenerRutaCarga para obtener el ID de la ruta.
                ObtenerRutaCarga()

                TextBox6.Text = DataGridView2.Item("ColumnaProducto", DataGridView2.SelectedRows(0).Index).Value
                'Llamamos al metodo ObtenerProducto para obtener el ID del producto.
                ObtenerProductoRutaCarga()

                TextBox3.Text = DataGridView2.Item("ColumnaUbicacion", DataGridView2.SelectedRows(0).Index).Value
                'Llamamos al metodo Obtenersitiocarga para obtener el ID de la sitiocarga.
                ObtenerSitioCargaRutaCarga()

                TextBox7.Text = DataGridView2.Item("ColumnaDestino", DataGridView2.SelectedRows(0).Index).Value
                'Llamamos al metodo ObtenerDestino para obtener el ID de la sitiocarga.
                ObtenerDestinoRutaCarga()

                TextBox8.Text = DataGridView2.Item("ColumnaChofer", DataGridView2.SelectedRows(0).Index).Value
                'Llamamos al metodo ObtenerPersonalRutaCarga para obtener el ID del chofer.
                ObtenerPersonalRutaCarga()

                ActualizarEstadoRuta()

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.10", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub BotonBuscar1_Click(sender As Object, e As EventArgs) Handles BotonBuscar1.Click
        'Llama al formulario ListadoProducto.

        ListadoProducto.ShowDialog()

    End Sub

    Private Sub BotonBuscar2_Click(sender As Object, e As EventArgs) Handles BotonBuscar2.Click
        'Llama al formulario Listadositiocarga.

        ListadoSitioCarga.ShowDialog()

    End Sub

    Private Sub BotonBuscar3_Click(sender As Object, e As EventArgs) Handles BotonBuscar3.Click
        'Llama al formulario ListadoChofer.

        ListadoPersonal.ComboEstadoPersona.Enabled = False
        ListadoPersonal.ShowDialog()


    End Sub

    Private Sub BotonBuscar4_Click(sender As Object, e As EventArgs) Handles BotonBuscar4.Click
        'Llama al formulario ListadoDestino.

        ListadoDestino.ShowDialog()

    End Sub

    Private Sub BotonGuardar_Click(sender As Object, e As EventArgs) Handles BotonGuardar.Click
        'Boton guardar

        Try

            Dim fecha = DateTimePicker1.Value.ToString("yyyy-MM-dd")

            If ValidarComponentesRutaCarga() = True Then

                'Registro formal de la ruta con todos sus atributos
                Dim db As New MySqlCommand("INSERT INTO ruta (idruta, vehiculo, personal, sitiocarga, destino, producto, fecha, estadoruta, hora, estado) VALUES ('" & TextBox2.Text & "', '" & TextBox1.Text & "', '" & TextBox11.Text & "', '" & TextBox10.Text & "', '" & TextBox13.Text & "', '" & TextBox9.Text & "', '" & fecha & "', '" & TextBox12.Text & "', '" & TextBox15.Text & "', '" & TextBox20.Text & "')", Conexion)
                db.ExecuteNonQuery()

                ActualizarRutaCarga()

                'Llamada a metodos secundarios.
                CargarGridHistorialCarga()

                'Colocamos el historial en la primera pagina
                'Inicio()

                'Se habilita el metodo para incrementar el siguiente ID de las rutas.
                SerieRutaCarga()

                CargarGridRutaCargaGrupo()
                'CargarGridRutaCargaSubFlota() 'SE IMPLEMENTARA LUEGO

                ObtenerCantidadVehiculos()

                'Luego de guardar nos posicionamos en la fila ya seleccionada anteriormente
                'para verificar la inclusion de la ruta en el datagridview2.
                DataGridView1.CurrentCell = DataGridView1(Columna, Fila)

                MsgBox("Ruta registrada con Exito.", MsgBoxStyle.Information, "Exito.")

            End If

        Catch ex As Exception

            MsgBox("Debe verificar los datos de la ruta.11", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub Botonguardar3_Click(sender As Object, e As EventArgs) Handles botonguardar3.Click
        'Boton guardar

        Try

            Dim fecha = DateTimePicker1.Value.ToString("yyyy-MM-dd")

            If ValidarComponentesRutaCarga() = True Then

                'Registro formal de la ruta con todos sus atributos
                Dim db As New MySqlCommand("INSERT INTO ruta (idruta, vehiculo, personal, sitiocarga, destino, producto, fecha, estadoruta, hora, estado) VALUES ('" & TextBox2.Text & "', '" & TextBox1.Text & "', '" & TextBox11.Text & "', '" & TextBox10.Text & "', '" & TextBox13.Text & "', '" & TextBox9.Text & "', '" & fecha & "', '" & TextBox12.Text & "', '" & TextBox15.Text & "', '" & TextBox20.Text & "')", Conexion)
                db.ExecuteNonQuery()

                ActualizarRutaCarga()

                'Llamada a metodos secundarios.
                CargarGridHistorialCarga()

                'Colocamos el historial en la primera pagina
                'Inicio()

                'Se habilita el metodo para incrementar el siguiente ID de las rutas.
                SerieRutaCarga()

                CargarGridRutaCargaGrupo()
                'CargarGridRutaCargaSubFlota() 'SE IMPLEMENTARA LUEGO

                ObtenerCantidadVehiculos()

                'Luego de guardar nos posicionamos en la fila ya seleccionada anteriormente
                'para verificar la inclusion de la ruta en el datagridview2.
                DataGridView1.CurrentCell = DataGridView1(Columna, Fila)

                MsgBox("Ruta registrada con Exito.", MsgBoxStyle.Information, "Exito.")

            End If

        Catch ex As Exception

            MsgBox("Debe verificar los datos de la ruta.11", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub BotonGuiaTelefonica_Click(sender As Object, e As EventArgs) Handles BotonGuiaTelefonica.Click
        'Llamada al formulario "GuiaTelefonica"

        GuiaTelefonica.Show()

    End Sub

    Private Sub BotonSalir_Click(sender As Object, e As EventArgs) Handles BotonSalir.Click
        'Boton salir

        If DataGridView1.RowCount > 0 Or DataGridView2.RowCount > 0 Then

            'Llamada al metodo para poder limpiar el arbol
            LimpiarArbolSeguimientoCarga()
            LimpiarComponentesSeguimientoCarga()

            Tabla.Clear()
            DataSet.Clear()

            'Cierre formal del formulario liberando recursos
            Dispose()

        Else

            'Cierre formal de la ventana sin liberar recursos
            Close()

        End If

    End Sub

    Private Sub BotonAgregar1_Click(sender As Object, e As EventArgs) Handles BotonAgregar1.Click
        'Llamada al formulario "MaestroProducto" para poder registrar o modificar registros.

        MaestroProducto.BotonBuscar.Enabled = False
        MaestroProducto.ShowDialog()


    End Sub

    Private Sub BotonAgregar2_Click(sender As Object, e As EventArgs) Handles BotonAgregar2.Click
        'Llamada al formulario "Maestrositiocarga" para poder registrar o modificar.

        MaestroSitioCarga.BotonBuscar.Enabled = False
        MaestroSitioCarga.ShowDialog()

    End Sub

    Private Sub BotonAgregar3_Click(sender As Object, e As EventArgs) Handles BotonAgregar3.Click
        'Llamada al formulario "MaestroPersonal" para poder registrar o modificar.

        MaestroPersonal.BotonBuscar.Enabled = False
        MaestroPersonal.ShowDialog()

    End Sub

    Private Sub BotonAgregar4_Click(sender As Object, e As EventArgs) Handles BotonAgregar4.Click
        'Llamada al formulario "Maestrositiocarga" para poder registrar o modificar.

        MaestroSitioCarga.BotonBuscar.Enabled = False
        MaestroSitioCarga.ShowDialog()

    End Sub

    Private Sub BotonListado_Click(sender As Object, e As EventArgs) Handles BotonListado.Click
        'Llamada al formulario "ListadoVehiculoCarretera" para chequear cual es el total de vehiculos en carretera actualizado.

        ListadoGeneralRutas.ShowDialog()

    End Sub

    Private Sub BotonCuadroResumen_Click(sender As Object, e As EventArgs) Handles BotonCuadroResumen.Click
        'Llamada al formulario ResumenMateriaPrima

        CuadroResumenMateriaPrima.Show()

    End Sub

    Private Sub BotonConsulta2_Click(sender As Object, e As EventArgs) Handles BotonConsulta2.Click
        'Llamada al formulario ReporteInfraccion

        ReporteGeneral.ShowDialog()

    End Sub

    Private Sub BotonSiguiente_Click(sender As Object, e As EventArgs) Handles BotonSiguiente.Click
        'Boton siguiente, permite navegar en el historial del vehiculo hacia las primeras rutas

        ' Siguiente()

        If DataGridView2.RowCount <> 0 Then

            BotonAnterior.Enabled = True

        End If

        'Si vamos al inicio del historial se bloquean los botones
        If Iteracion = 0 Then

            BotonSiguiente.Enabled = False
            BotonInicio.Enabled = False

        End If

    End Sub

    Private Sub BotonAnterior_Click(sender As Object, e As EventArgs) Handles BotonAnterior.Click
        'Boton anterior, permite navegar en el historial del vehiculo hacia las ultimas rutas

        'Anterior()

        If DataGridView2.RowCount = 0 Then

            BotonAnterior.Enabled = False

        End If

        BotonSiguiente.Enabled = True
        BotonInicio.Enabled = True

    End Sub

    Private Sub BotonInicio_Click(sender As Object, e As EventArgs) Handles BotonInicio.Click
        'Boton inicio, lleva a la primera pagina

        Inicio()

        If DataGridView2.RowCount <> 0 Then

            BotonInicio.Enabled = False
            BotonAnterior.Enabled = True
            BotonSiguiente.Enabled = False

        End If

    End Sub

    Private Sub BotonFinal_Click(sender As Object, e As EventArgs) Handles BotonFinal.Click
        'Boton final

        Final()

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        'Este metodo permite obtener el ID de cada item seleccionado. 

        Try

            Dim Adaptador2 As New MySqlDataAdapter
            Dim Tabla2 As New DataTable

            Adaptador2 = New MySqlDataAdapter("SELECT idestado FROM estadoruta WHERE nombreestado = '" & ComboBox1.Text & "' ", Conexion)
            Adaptador2.Fill(Tabla2)

            For Each row As DataRow In Tabla2.Rows
                TextBox12.Text = row("idestado").ToString
            Next

            ActualizarEstadoRuta()
            VerificarEstadoVehiculo()

            'Aprovechamos la seleccion de items en el combo para detectar el movimiento y reiniciar el tiempo
            ReiniciarTiempo()

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.13", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Public Sub ComboBox1_DrawItem(sender As Object, e As System.Windows.Forms.DrawItemEventArgs) Handles ComboBox1.DrawItem
        'Evento que dibuja el texto y las imagenes cargadas en el combobox

        Try

            e.DrawBackground()

            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                'Si hay un elemento seleccionado se dibuja la seleccion, el texto y la imagen

                'Dibuja la seleccion
                e.Graphics.FillRectangle(Brushes.DeepSkyBlue, e.Bounds)

                'Dibuja el texto
                e.Graphics.DrawString(Arreglo(e.Index), e.Font, Brushes.Black, e.Bounds.Left + ImageList2.ImageSize.Width + 16, e.Bounds.Top)

                'Dibuja la imagen
                e.Graphics.DrawImage(ImageList2.Images(e.Index), e.Bounds.Left, e.Bounds.Top)

                'e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                e.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic

            Else
                'Si no se selecciona nada, se dibuja el texto y la imagen

                'Dibuja la imagen
                e.Graphics.DrawImage(ImageList2.Images(e.Index), e.Bounds.Left, e.Bounds.Top)
                'Dibuja el texto
                e.Graphics.DrawString(Arreglo(e.Index), e.Font, Brushes.Black, e.Bounds.Left + ImageList2.ImageSize.Width + 16, e.Bounds.Top)

                'e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
                e.Graphics.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
                e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic

            End If

            e.DrawFocusRectangle()

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.14", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Public Sub ComboBox1_MeasureItem(sender As Object, e As System.Windows.Forms.MeasureItemEventArgs) Handles ComboBox1.MeasureItem

        Try

            'Esto es para darle espacio a los elementos mostrados en el ComboBox
            e.ItemHeight = ImageList2.ImageSize.Height + 3

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.15", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub TextBox7_TextChanged(sender As Object, e As EventArgs) Handles TextBox7.TextChanged
        'Validacion que permite no cargar dos veces la misma sitiocarga en sitio de carga y destino

        If TextBox3.Text = "" And TextBox7.Text = "" Then

            'En caso de no tener rutas registradas en el historial, los textbox se mantienen vacios
            TextBox3.Text = ""
            TextBox7.Text = ""

        ElseIf TextBox3.Text = TextBox7.Text Then

            'En caso de que se seleccione la misma sitiocarga en sitio de carga y destino, se muestra el mensaje
            MsgBox("El sitio de carga no puede ser igual al destino, por favor verifique la información.", MsgBoxStyle.Exclamation, "Aviso.")
            TextBox7.Text = ""

        End If

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        'Validacion que permite no cargar dos veces la misma sitiocarga en sitio de carga y destino

        If TextBox3.Text = "" And TextBox7.Text = "" Then

            'En caso de no tener rutas registradas en el historial, los textbox se mantienen vacios
            TextBox3.Text = ""
            TextBox7.Text = ""

        ElseIf TextBox3.Text = TextBox7.Text Then

            'En caso de que se seleccione la misma sitiocarga en sitio de carga y destino, se muestra el mensaje
            MsgBox("El sitio de carga no puede ser igual al destino, por favor verifique la información.", MsgBoxStyle.Exclamation, "Aviso.")
            TextBox7.Text = ""

        End If

    End Sub

    Private Sub MenuCambiarEstado_Click(sender As Object, e As EventArgs) Handles MenuCambiarEstado.Click
        'Evento que permite hacer dobleclick y llevarse el id del vehiculo y manejar 
        'la botonera del formulario MaestroVehiculo para poder editar los estados.

        Try

            If DataGridView1.RowCount > 0 And DataGridView1.SelectedRows.Count = 1 Then

                MaestroVehiculo.TextBox1.Text = TextBox1.Text
                MaestroVehiculo.TextBox1.Enabled = False
                MaestroVehiculo.ComboGrupo.Enabled = False
                MaestroVehiculo.ComboTipo.Enabled = False
                MaestroVehiculo.ComboCondicion.Enabled = True
                MaestroVehiculo.ComboEstado.Enabled = False
                MaestroVehiculo.ComboClasificacion.Enabled = False
                MaestroVehiculo.BotonModificar.Enabled = True
                MaestroVehiculo.BotonGuardar.Enabled = False
                MaestroVehiculo.BotonBuscar.Enabled = False
                MaestroVehiculo.ShowDialog()

                'Posicionamos el currencell en el vehiculo que clickeamos anteriormente
                DataGridView1.CurrentCell = DataGridView1(Columna, Fila)

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.16", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub MenuAgregarInfracción_Click(sender As Object, e As EventArgs) Handles MenuAgregarInfracción.Click
        'Llamada al formulario MaestroInfraccion

        Try

            Dim Celda As String = DataGridView1.Item("ColumnaEstadoVehiculo", DataGridView1.SelectedRows(0).Index).Value

            If DataGridView1.RowCount > 0 And DataGridView1.SelectedRows.Count = 1 Then

                'If Celda = "EN RUTA VACIO" Or Celda = "EN RUTA CARGADO" Or Celda = "DE REGRESO CARGADO" Or Celda = "DE REGRESO VACIO" Then

                MaestroInfraccion.TextBox2.Text = TextBox1.Text
                MaestroInfraccion.TextBox4.Text = TextBox8.Text
                MaestroInfraccion.TextBox8.Text = TextBox5.Text
                MaestroInfraccion.BotonBuscar.Enabled = False
                MaestroInfraccion.BotonBuscar2.Enabled = False

                ObtenerPersonalInfraccionCarga()
                MaestroInfraccion.ShowDialog()

                'Posicionamos el currencell en el vehiculo que clickeamos anteriormente
                DataGridView1.CurrentCell = DataGridView1(Columna, Fila)

                'Else

                ' MsgBox("No puede registrar infracciones de velocidad a vehiculos que no esten en carretera.", MsgBoxStyle.Exclamation, "Error.")

                'End If

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.17", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub MenuEliminar_Click(sender As Object, e As EventArgs) Handles MenuEliminar.Click
        'Metodo que permite eliminar rutas del historial

        Try

            If DataGridView2.RowCount > 0 And DataGridView2.SelectedRows.Count = 1 Then

                EliminarRutaCarga()

                'Luego de eliminar nos posicionamos en la fila ya seleccionada anteriormente
                DataGridView1.CurrentCell = DataGridView1(Columna, Fila)

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.18", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub VerificarEstadoVehiculo()
        'Metodo que permite validar si el vehiculo esta en reparacion, salta el mensaje de alarma para avisar que debe ser
        'cambiado a "operativo"

        If TextBox16.Text = "EN REPARACIÓN" Then

            If ComboBox1.Text = "EN RUTA VACIO" Or ComboBox1.Text = "EN RUTA CARGADO" Or ComboBox1.Text = "DE REGRESO CARGADO" Or ComboBox1.Text = "DE REGRESO VACIO" Then

                MsgBox("Vehiculo en Reparación. Verifique la información.", MsgBoxStyle.Exclamation, "Aviso.")

            End If

        End If

    End Sub


End Class