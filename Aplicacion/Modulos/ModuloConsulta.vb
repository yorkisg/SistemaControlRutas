
Module ModuloConsulta

    'Variables globales.
    Public Bandera As Image
    Public Critico As Image
    Public Muerte As Image
    Public Velocidad As Image
    Public Exceso As Image
    Public Consumo As Image

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''CONSULTAS GENERALES'''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub CargarGridPersonal()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausura BETWEEN

        Dim Command As New MySqlCommand("SELECT idruta, idvehiculo, nombrepersonal, nombreproducto, nombresitiocarga, nombredestino, nombreestado, fecha, hora " _
                           & " FROM ruta, vehiculo, personal, sitiocarga, destino, producto, estadoruta " _
                           & " WHERE ruta.vehiculo = vehiculo.idvehiculo " _
                           & " AND ruta.personal = personal.idpersonal " _
                           & " AND ruta.sitiocarga = sitiocarga.idsitiocarga " _
                           & " AND ruta.destino = destino.iddestino " _
                           & " AND ruta.producto = producto.idproducto " _
                           & " AND ruta.estadoruta = estadoruta.idestado " _
                           & " AND nombrepersonal = '" & ConsultaGeneralRuta.TextBox1.Text & "' " _
                           & " AND nombreestado IN ('EN RUTA VACIO', 'EN RUTA CARGADO') " _
                           & " AND fecha BETWEEN @fecha1 AND @fecha2 " _
                           & " ORDER BY idruta DESC, fecha DESC, hora DESC ", Conexion)

        'Para trabajar con fechas y campos tipo "DATE" se usan los parametos
        Command.Parameters.Add("@fecha1", MySqlDbType.Date).Value = ConsultaGeneralRuta.DateTimePicker1.Value
        Command.Parameters.Add("@fecha2", MySqlDbType.Date).Value = ConsultaGeneralRuta.DateTimePicker2.Value

        'Llenado del datagridview
        Dim adaptador As New MySqlDataAdapter(Command)
        Dim Tabla As New DataTable
        adaptador.Fill(Tabla)
        ConsultaGeneralRuta.DataGridView.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ConsultaGeneralRuta.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        ConsultaGeneralRuta.DataGridView.ClearSelection()

    End Sub

    Public Sub CargarGridProducto()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausura BETWEEN

        Dim Command As New MySqlCommand("SELECT idruta, idvehiculo, nombrepersonal, nombreproducto, nombresitiocarga, nombredestino, nombreestado, fecha, hora " _
                           & " FROM ruta, vehiculo, personal, sitiocarga, destino, producto, estadoruta " _
                           & " WHERE ruta.vehiculo = vehiculo.idvehiculo " _
                           & " AND ruta.personal = personal.idpersonal " _
                           & " AND ruta.sitiocarga = sitiocarga.idsitiocarga " _
                           & " AND ruta.destino = destino.iddestino " _
                           & " AND ruta.producto = producto.idproducto " _
                           & " AND ruta.estadoruta = estadoruta.idestado " _
                           & " AND nombreproducto = '" & ConsultaGeneralRuta.TextBox2.Text & "' " _
                           & " AND nombreestado IN ('EN RUTA VACIO', 'EN RUTA CARGADO') " _
                           & " AND fecha BETWEEN @fecha1 AND @fecha2 " _
                           & " ORDER BY idruta DESC, fecha DESC, hora DESC ", Conexion)

        'Para trabajar con fechas y campos tipo "DATE" se usan los parametos
        Command.Parameters.Add("@fecha1", MySqlDbType.Date).Value = ConsultaGeneralRuta.DateTimePicker1.Value
        Command.Parameters.Add("@fecha2", MySqlDbType.Date).Value = ConsultaGeneralRuta.DateTimePicker2.Value

        'Llenado del datagridview
        Dim adaptador As New MySqlDataAdapter(Command)
        Dim Tabla As New DataTable
        adaptador.Fill(Tabla)
        ConsultaGeneralRuta.DataGridView.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ConsultaGeneralRuta.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        ConsultaGeneralRuta.DataGridView.ClearSelection()

    End Sub

    Public Sub CargarGridVehiculo()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausura BETWEEN

        Dim Command As New MySqlCommand("SELECT idruta, idvehiculo, nombrepersonal, nombreproducto, nombresitiocarga, nombredestino, fecha, hora " _
                           & " FROM ruta, vehiculo, personal, sitiocarga, destino, producto, estadoruta " _
                           & " WHERE ruta.vehiculo = vehiculo.idvehiculo " _
                           & " AND ruta.personal = personal.idpersonal " _
                           & " AND ruta.sitiocarga = sitiocarga.idsitiocarga " _
                           & " AND ruta.destino = destino.iddestino " _
                           & " AND ruta.producto = producto.idproducto " _
                           & " AND ruta.estadoruta = estadoruta.idestado " _
                           & " AND nombreestado IN ('EN RUTA VACIO', 'EN RUTA CARGADO') " _
                           & " AND idvehiculo = '" & ConsultaGeneralRuta.TextBox3.Text & "' " _
                           & " AND fecha BETWEEN @fecha1 AND @fecha2 " _
                           & " ORDER BY idruta DESC, fecha DESC, hora DESC ", Conexion)

        'Para trabajar con fechas y campos tipo "DATE" se usan los parametos
        Command.Parameters.Add("@fecha1", MySqlDbType.Date).Value = ConsultaGeneralRuta.DateTimePicker1.Value
        Command.Parameters.Add("@fecha2", MySqlDbType.Date).Value = ConsultaGeneralRuta.DateTimePicker2.Value

        'Llenado del datagridview
        Dim adaptador As New MySqlDataAdapter(Command)
        Dim Tabla As New DataTable
        adaptador.Fill(Tabla)
        ConsultaGeneralRuta.DataGridView.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ConsultaGeneralRuta.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        ConsultaGeneralRuta.DataGridView.ClearSelection()

    End Sub

    Public Sub CargarGridConsultaRuta()
        'Metodo que genera la carga de datos en el DataGridview usando la clausura BETWEEN

        Dim Command As New MySqlCommand("SELECT idruta, idvehiculo, nombrepersonal, nombreproducto, nombresitiocarga, nombredestino, nombreestado, fecha, hora " _
                           & " FROM ruta, vehiculo, personal, sitiocarga, destino, producto, estadoruta " _
                           & " WHERE ruta.vehiculo = vehiculo.idvehiculo " _
                           & " AND ruta.personal = personal.idpersonal " _
                           & " AND ruta.sitiocarga = sitiocarga.idsitiocarga " _
                           & " AND ruta.destino = destino.iddestino " _
                           & " AND ruta.producto = producto.idproducto " _
                           & " AND ruta.estadoruta = estadoruta.idestado " _
                           & " AND nombreestado IN ('EN RUTA VACIO', 'EN RUTA CARGADO') " _
                           & " AND fecha BETWEEN @fecha1 AND @fecha2 " _
                           & " ORDER BY idruta DESC, fecha DESC, hora DESC ", Conexion)

        'Para trabajar con fechas y campos tipo "DATE" se usan los parametos
        Command.Parameters.Add("@fecha1", MySqlDbType.Date).Value = ConsultaGeneralRuta.DateTimePicker1.Value
        Command.Parameters.Add("@fecha2", MySqlDbType.Date).Value = ConsultaGeneralRuta.DateTimePicker2.Value

        'Llenado del datagridview
        Dim adaptador As New MySqlDataAdapter(Command)
        Dim Tabla As New DataTable
        adaptador.Fill(Tabla)
        ConsultaGeneralRuta.DataGridView.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ConsultaGeneralRuta.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        ConsultaGeneralRuta.DataGridView.ClearSelection()

    End Sub

    Public Sub CargarGridUbicacion()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausura BETWEEN

        Dim Command As New MySqlCommand("SELECT idruta, idvehiculo, nombrepersonal, nombreproducto, nombresitiocarga, nombredestino, nombreestado, fecha, hora " _
                           & " FROM ruta, vehiculo, personal, sitiocarga, destino, producto, estadoruta " _
                           & " WHERE ruta.vehiculo = vehiculo.idvehiculo " _
                           & " AND ruta.personal = personal.idpersonal " _
                           & " AND ruta.sitiocarga = sitiocarga.idsitiocarga " _
                           & " AND ruta.destino = destino.iddestino " _
                           & " AND ruta.producto = producto.idproducto " _
                           & " AND ruta.estadoruta = estadoruta.idestado " _
                           & " AND nombresitiocarga = '" & ConsultaGeneralRuta.TextBox4.Text & "' " _
                           & " AND nombreestado IN ('EN RUTA VACIO', 'EN RUTA CARGADO') " _
                           & " AND fecha BETWEEN @fecha1 AND @fecha2 " _
                           & " ORDER BY idruta DESC, fecha DESC, hora DESC ", Conexion)

        'Para trabajar con fechas y campos tipo "DATE" se usan los parametos
        Command.Parameters.Add("@fecha1", MySqlDbType.Date).Value = ConsultaGeneralRuta.DateTimePicker1.Value
        Command.Parameters.Add("@fecha2", MySqlDbType.Date).Value = ConsultaGeneralRuta.DateTimePicker2.Value

        'Llenado del datagridview
        Dim adaptador As New MySqlDataAdapter(Command)
        Dim Tabla As New DataTable
        adaptador.Fill(Tabla)
        ConsultaGeneralRuta.DataGridView.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ConsultaGeneralRuta.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        ConsultaGeneralRuta.DataGridView.ClearSelection()

    End Sub

    Public Sub CargarGridDestino()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausura BETWEEN

        Dim Command As New MySqlCommand("SELECT idruta, idvehiculo, nombrepersonal, nombreproducto, nombresitiocarga, nombredestino, nombreestado, fecha, hora " _
                           & " FROM ruta, vehiculo, personal, sitiocarga, destino, producto, estadoruta " _
                           & " WHERE ruta.vehiculo = vehiculo.idvehiculo " _
                           & " AND ruta.personal = personal.idpersonal " _
                           & " AND ruta.sitiocarga = sitiocarga.idsitiocarga " _
                           & " AND ruta.destino = destino.iddestino " _
                           & " AND ruta.producto = producto.idproducto " _
                           & " AND ruta.estadoruta = estadoruta.idestado " _
                           & " AND nombredestino = '" & ConsultaGeneralRuta.TextBox5.Text & "' " _
                           & " AND nombreestado IN ('EN RUTA VACIO', 'EN RUTA CARGADO') " _
                           & " AND fecha BETWEEN @fecha1 AND @fecha2 " _
                           & " ORDER BY idruta DESC, fecha DESC, hora DESC ", Conexion)

        'Para trabajar con fechas y campos tipo "DATE" se usan los parametos
        Command.Parameters.Add("@fecha1", MySqlDbType.Date).Value = ConsultaGeneralRuta.DateTimePicker1.Value
        Command.Parameters.Add("@fecha2", MySqlDbType.Date).Value = ConsultaGeneralRuta.DateTimePicker2.Value

        'Llenado del datagridview
        Dim adaptador As New MySqlDataAdapter(Command)
        Dim Tabla As New DataTable
        adaptador.Fill(Tabla)
        ConsultaGeneralRuta.DataGridView.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ConsultaGeneralRuta.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        ConsultaGeneralRuta.DataGridView.ClearSelection()

    End Sub

    Public Sub CargarConsultaRutaVehiculo()
        'Metodo para cargar el datagridview.
        'ConsultaRuta

        'Conexion a la BD.
        Dim sql As String = "SELECT COUNT(*) AS 'Conteo', vehiculo AS 'Vehiculo' FROM ruta, estadoruta " _
                        & " WHERE ruta.estadoruta = estadoruta.idestado " _
                        & " AND nombreestado IN ('EN RUTA CARGADO','EN RUTA VACIO') " _
                        & " AND MONTH(fecha) = MONTH(CURDATE())" _
                        & " GROUP BY vehiculo " _
                        & " ORDER BY Conteo DESC"

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "ConsultaRuta1")
        Tabla = DataSet.Tables("ConsultaRuta1")
        ConsultaGeneralRuta.DataGridView1.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ConsultaGeneralRuta.DataGridView1
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        ConsultaGeneralRuta.DataGridView1.ClearSelection()

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''CONSULTA INFRACCIONES'''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub CargarGridConsultaVehiculoInfraccion()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausura BETWEEN
        'ConsultaInfraccion

        Dim Command As New MySqlCommand("SELECT idregistroinfraccion, vehiculo, nombrepersonal, velocidad, estadovehiculo, fecha, hora " _
                           & " FROM registroinfraccion, personal " _
                           & " WHERE registroinfraccion.personal = personal.idpersonal " _
                           & " AND vehiculo = '" & ConsultaInfraccion.TextBox1.Text & "' " _
                           & " AND fecha BETWEEN @fecha1 AND @fecha2 " _
                           & " ORDER BY idregistroinfraccion DESC, fecha DESC, hora DESC ", Conexion)

        'Para trabajar con fechas y campos tipo "DATE" se usan los parametos
        Command.Parameters.Add("@fecha1", MySqlDbType.Date).Value = ConsultaInfraccion.DateTimePicker1.Value
        Command.Parameters.Add("@fecha2", MySqlDbType.Date).Value = ConsultaInfraccion.DateTimePicker2.Value

        'Llenado del datagridview
        Dim adaptador As New MySqlDataAdapter(Command)
        Dim Tabla As New DataTable
        adaptador.Fill(Tabla)
        ConsultaInfraccion.DataGridView.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ConsultaInfraccion.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        ConsultaInfraccion.DataGridView.ClearSelection()

    End Sub

    Public Sub CargarGridConsultaInfraccion()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausura BETWEEN
        'ConsultaInfraccion

        Dim Command As New MySqlCommand("SELECT idregistroinfraccion, vehiculo, nombrepersonal, velocidad, estadovehiculo, fecha, hora " _
                           & " FROM registroinfraccion, personal, vehiculo " _
                           & " WHERE registroinfraccion.personal = personal.idpersonal " _
                           & " AND registroinfraccion.vehiculo = vehiculo.idvehiculo " _
                           & " AND fecha BETWEEN @fecha1 AND @fecha2 " _
                           & " ORDER BY idregistroinfraccion DESC, fecha DESC, hora DESC ", Conexion)

        'Para trabajar con fechas y campos tipo "DATE" se usan los parametos
        Command.Parameters.Add("@fecha1", MySqlDbType.Date).Value = ConsultaInfraccion.DateTimePicker1.Value
        Command.Parameters.Add("@fecha2", MySqlDbType.Date).Value = ConsultaInfraccion.DateTimePicker2.Value

        'Llenado del datagridview
        Dim adaptador As New MySqlDataAdapter(Command)
        Dim Tabla As New DataTable
        adaptador.Fill(Tabla)
        ConsultaInfraccion.DataGridView.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ConsultaInfraccion.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        ConsultaInfraccion.DataGridView.ClearSelection()

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''CONSULTA INCIDENCIAS''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub CargarGridConsultaVehiculoIncidencia()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausura BETWEEN
        'ConsultaInfraccion

        Dim Command As New MySqlCommand("Select idregistroincidencia, vehiculo, nombrepersonal, descripcion, tipo, fecha, hora " _
                           & " FROM registroincidencia, personal " _
                           & " WHERE registroincidencia.personal = personal.idpersonal " _
                           & " And vehiculo = '" & ConsultaIncidencia.TextBox1.Text & "' " _
                           & " AND fecha BETWEEN @fecha1 AND @fecha2 " _
                           & " ORDER BY idregistroincidencia DESC, fecha DESC, hora DESC ", Conexion)

        'Para trabajar con fechas y campos tipo "DATE" se usan los parametos
        Command.Parameters.Add("@fecha1", MySqlDbType.Date).Value = ConsultaIncidencia.DateTimePicker1.Value
        Command.Parameters.Add("@fecha2", MySqlDbType.Date).Value = ConsultaIncidencia.DateTimePicker2.Value

        'Llenado del datagridview
        Dim adaptador As New MySqlDataAdapter(Command)
        Dim Tabla As New DataTable
        adaptador.Fill(Tabla)
        ConsultaIncidencia.DataGridView.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ConsultaIncidencia.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        ConsultaIncidencia.DataGridView.ClearSelection()

    End Sub

    Public Sub CargarGridConsultaIncidencia()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausura BETWEEN
        'ConsultaInfraccion

        Dim Command As New MySqlCommand("SELECT idregistroincidencia, vehiculo, nombrepersonal, descripcion, tipo, fecha, hora " _
                           & " FROM registroincidencia, personal, vehiculo " _
                           & " WHERE registroincidencia.personal = personal.idpersonal " _
                           & " AND registroincidencia.vehiculo = vehiculo.idvehiculo " _
                           & " AND fecha BETWEEN @fecha1 AND @fecha2 " _
                           & " ORDER BY idregistroincidencia DESC, fecha DESC, hora DESC ", Conexion)

        'Para trabajar con fechas y campos tipo "DATE" se usan los parametos
        Command.Parameters.Add("@fecha1", MySqlDbType.Date).Value = ConsultaIncidencia.DateTimePicker1.Value
        Command.Parameters.Add("@fecha2", MySqlDbType.Date).Value = ConsultaIncidencia.DateTimePicker2.Value

        'Llenado del datagridview
        Dim adaptador As New MySqlDataAdapter(Command)
        Dim Tabla As New DataTable
        adaptador.Fill(Tabla)
        ConsultaIncidencia.DataGridView.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ConsultaIncidencia.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        ConsultaIncidencia.DataGridView.ClearSelection()

    End Sub


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''CONSULTA CONSUMIBLES''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub CargarGridConsultaChoferConsumible()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausura BETWEEN

        Dim Command As New MySqlCommand("SELECT vehiculo, nombrepersonal, cantidadconsumida, consumototal, (cantidadconsumida-consumototal) AS 'diferencia', (kilometrajeactual-kilometrajeanterior) AS 'distancia', fecha, hora " _
                           & " FROM registroconsumo, personal " _
                           & " WHERE registroconsumo.personal = personal.idpersonal " _
                           & " AND nombrepersonal = '" & ConsultaConsumible.TextBox1.Text & "' " _
                           & " AND fecha BETWEEN @fecha1 AND @fecha2 " _
                           & " ORDER BY fecha DESC, hora DESC ", Conexion)

        'Para trabajar con fechas y campos tipo "DATE" se usan los parametos
        Command.Parameters.Add("@fecha1", MySqlDbType.Date).Value = ConsultaConsumible.DateTimePicker1.Value
        Command.Parameters.Add("@fecha2", MySqlDbType.Date).Value = ConsultaConsumible.DateTimePicker2.Value

        'Llenado del datagridview
        Dim adaptador As New MySqlDataAdapter(Command)
        Dim Tabla As New DataTable
        adaptador.Fill(Tabla)
        ConsultaConsumible.DataGridView.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ConsultaConsumible.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        ConsultaConsumible.DataGridView.ClearSelection()

    End Sub

    Public Sub CargarGridConsultaVehiculoConsumible()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausura BETWEEN

        Dim Command As New MySqlCommand("SELECT vehiculo, nombrepersonal, cantidadconsumida, consumototal, (cantidadconsumida-consumototal) AS 'diferencia', (kilometrajeactual-kilometrajeanterior) AS 'distancia', fecha, hora " _
                           & " FROM registroconsumo, personal " _
                           & " WHERE registroconsumo.personal = personal.idpersonal " _
                           & " AND vehiculo = '" & ConsultaConsumible.TextBox3.Text & "' " _
                           & " AND fecha BETWEEN @fecha1 AND @fecha2 " _
                           & " ORDER BY fecha DESC, hora DESC ", Conexion)

        'Para trabajar con fechas y campos tipo "DATE" se usan los parametos
        Command.Parameters.Add("@fecha1", MySqlDbType.Date).Value = ConsultaConsumible.DateTimePicker1.Value
        Command.Parameters.Add("@fecha2", MySqlDbType.Date).Value = ConsultaConsumible.DateTimePicker2.Value

        'Llenado del datagridview
        Dim adaptador As New MySqlDataAdapter(Command)
        Dim Tabla As New DataTable
        adaptador.Fill(Tabla)
        ConsultaConsumible.DataGridView.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ConsultaConsumible.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        ConsultaConsumible.DataGridView.ClearSelection()

    End Sub

    Public Sub CargarGridConsultaConsumible()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausura BETWEEN
        'ConsultaInfraccion

        Dim Command As New MySqlCommand("SELECT vehiculo, nombrepersonal, cantidadconsumida, consumototal, (cantidadconsumida-consumototal) AS 'diferencia', (kilometrajeactual-kilometrajeanterior) AS 'distancia', fecha, hora " _
                           & " FROM registroconsumo, personal " _
                           & " WHERE registroconsumo.personal = personal.idpersonal " _
                           & " AND fecha BETWEEN @fecha1 AND @fecha2 " _
                           & " ORDER BY fecha DESC, hora DESC ", Conexion)

        'Para trabajar con fechas y campos tipo "DATE" se usan los parametos
        Command.Parameters.Add("@fecha1", MySqlDbType.Date).Value = ConsultaConsumible.DateTimePicker1.Value
        Command.Parameters.Add("@fecha2", MySqlDbType.Date).Value = ConsultaConsumible.DateTimePicker2.Value

        'Llenado del datagridview
        Dim adaptador As New MySqlDataAdapter(Command)
        Dim Tabla As New DataTable
        adaptador.Fill(Tabla)
        ConsultaConsumible.DataGridView.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ConsultaConsumible.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        ConsultaConsumible.DataGridView.ClearSelection()

    End Sub


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''REPORTE GENERAL ''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub CargarGridListadoReporteInfraccion()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausura BETWEEN
        'ListadoReporteInfraccion

        Dim Command As New MySqlCommand("SELECT nombrepersonal AS 'Personal', vehiculo AS 'Vehiculo', COUNT(idregistroinfraccion) AS 'Cantidad de Infracciones', " _
                    & " MAX(velocidad) AS 'Maxima Velocidad', ROUND(AVG(velocidad), 2) as 'Promedio del Periodo', nombregrupo AS 'Grupo' " _
                    & " FROM registroinfraccion, personal, vehiculo, grupo " _
                    & " WHERE personal.idpersonal = registroinfraccion.personal " _
                    & " AND registroinfraccion.vehiculo = vehiculo.idvehiculo " _
                    & " AND vehiculo.grupo = grupo.idgrupo " _
                    & " AND fecha BETWEEN @fecha1 AND @fecha2 " _
                    & " AND clasificacionvehiculo = '" & ReporteGeneral.ComboTipo.Text & "' " _
                    & " GROUP BY nombrepersonal " _
                    & " ORDER BY COUNT(idregistroinfraccion) DESC, MAX(velocidad) DESC " _
                    & " LIMIT 15 ", Conexion)

        'Para trabajar con fechas y campos tipo "DATE" se usan los parametos
        Command.Parameters.Add("@fecha1", MySqlDbType.Date).Value = ReporteGeneral.DateTimePicker1.Value
        Command.Parameters.Add("@fecha2", MySqlDbType.Date).Value = ReporteGeneral.DateTimePicker2.Value

        'Llenado del datagridview
        Dim Adaptador As New MySqlDataAdapter(Command)
        Dim Tabla As New DataTable
        Adaptador.Fill(Tabla)
        ReporteGeneral.DataGridView2.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ReporteGeneral.DataGridView2
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        ReporteGeneral.DataGridView2.ClearSelection()
        CargarImagenesReporteVelocidad()

    End Sub

    Public Sub CargarListadoInfraccion()
        'Metodo para cargar el datagridview.

        Dim sql As String = "SELECT COUNT(idregistroinfraccion) AS 'Conteo', idvehiculo AS 'Vehiculo' " _
                            & " FROM registroinfraccion, vehiculo " _
                            & " WHERE registroinfraccion.vehiculo = vehiculo.idvehiculo " _
                            & " AND MONTH(fecha) = MONTH(CURDATE()) " _
                            & " AND clasificacionvehiculo = '" & ReporteGeneral.ComboTipo.Text & "' " _
                            & " GROUP BY idvehiculo " _
                            & " ORDER BY COUNT(idregistroinfraccion) DESC " _
                            & " LIMIT 15 "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview
        Adaptador.Fill(DataSet, "reporte")
        Tabla = DataSet.Tables("reporte")
        ReporteGeneral.DataGridView3.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ReporteGeneral.DataGridView3
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        ReporteGeneral.DataGridView3.ClearSelection()

    End Sub

    Public Sub CargarGridListadoReporteConsumible()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausura BETWEEN
        'ListadoReporteInfraccion

        Dim Command As New MySqlCommand("SELECT nombrepersonal, idvehiculo, cantidadconsumida, consumototal, (cantidadconsumida-consumototal) AS 'diferencia', (kilometrajeactual-kilometrajeanterior) AS 'distancia', nombregrupo " _
                       & " FROM registroconsumo, personal, grupo, vehiculo " _
                       & " WHERE registroconsumo.personal = personal.idpersonal " _
                       & " AND registroconsumo.vehiculo = vehiculo.idvehiculo " _
                       & " AND vehiculo.grupo = grupo.idgrupo " _
                       & " AND fecha BETWEEN @fecha1 AND @fecha2 " _
                       & " ORDER BY cantidadconsumida DESC " _
                       & " LIMIT 15 ", Conexion)

        'Para trabajar con fechas y campos tipo "Date" se usan los parametos
        Command.Parameters.Add("@fecha1", MySqlDbType.Date).Value = ReporteGeneral.DateTimePicker1.Value
        Command.Parameters.Add("@fecha2", MySqlDbType.Date).Value = ReporteGeneral.DateTimePicker2.Value

        'Llenado del datagridview
        Dim Adaptador As New MySqlDataAdapter(Command)
        Dim Tabla As New DataTable
        Adaptador.Fill(Tabla)
        ReporteGeneral.DataGridView.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ReporteGeneral.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        ReporteGeneral.DataGridView.ClearSelection()
        CargarImagenesReporteConsumo()

    End Sub

    Public Sub CargarListadoConsumible()
        'Metodo para cargar el datagridview.

        Dim sql As String = "SELECT nombrepersonal, idvehiculo AS 'Vehiculo', SUM(cantidadconsumida) AS 'Conteo' " _
                            & " FROM registroconsumo, vehiculo, personal " _
                            & " WHERE registroconsumo.vehiculo = vehiculo.idvehiculo " _
                            & " AND registroconsumo.personal = personal.idpersonal " _
                            & " AND MONTH(fecha) = MONTH(CURDATE()) " _
                            & " GROUP BY idvehiculo " _
                            & " ORDER BY SUM(cantidadconsumida) DESC " _
                            & " LIMIT 15 "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview
        Adaptador.Fill(DataSet, "reportes2")
        Tabla = DataSet.Tables("reportes2")
        ReporteGeneral.DataGridView1.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ReporteGeneral.DataGridView1
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        ReporteGeneral.DataGridView1.ClearSelection()

    End Sub


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''LISTADO GENERAL DE RUTAS''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub CargarGridGeneralVehiculo()
        'Metodo que genera la carga de datos en el DataGridview2.

        Dim sql As String = "SELECT vehiculo, nombrepersonal, nombreproducto, nombresitiocarga, nombredestino, nombreestado " _
                         & " FROM ruta, personal, subflota, grupo, vehiculo, destino, producto, sitiocarga, estadoruta  " _
                         & " WHERE ruta.personal = personal.idpersonal " _
                         & " AND ruta.vehiculo = vehiculo.idvehiculo  " _
                         & " AND vehiculo.grupo = grupo.idgrupo " _
                         & " AND grupo.subflota = subflota.idsubflota  " _
                         & " AND ruta.destino = destino.iddestino  " _
                         & " AND ruta.producto = producto.idproducto  " _
                         & " AND ruta.sitiocarga = sitiocarga.idsitiocarga  " _
                         & " AND ruta.estadoruta = estadoruta.idestado " _
                         & " AND estado = 'ACTIVA' " _
                         & " AND nombreestado NOT IN ('EN TALLER') " _
                         & " ORDER BY nombreproducto ASC, nombresitiocarga ASC, nombreestado ASC "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview
        Adaptador.Fill(DataSet, "listadoactual")
        Tabla = DataSet.Tables("listadoactual")
        ListadoGeneralRutas.DataGridView.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ListadoGeneralRutas.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        'Mostramos la cantidad de registros encontrados
        ListadoGeneralRutas.Contador.Text = ListadoGeneralRutas.DataGridView.RowCount

        'Quitamos la seleccion de cualquier fila del datagridview
        ListadoGeneralRutas.DataGridView.ClearSelection()

        CargarImagenesHistorialCarga()

    End Sub

    Public Sub CargarGridGeneralVehiculoGrupo()
        'Metodo que genera la carga de datos en el DataGridview2.

        Dim sql As String = "Select vehiculo, nombrepersonal, nombreproducto, nombresitiocarga, nombredestino, nombreestado " _
                         & " FROM ruta, personal, subflota, grupo, vehiculo, destino, producto, sitiocarga, estadoruta  " _
                         & " WHERE ruta.personal = personal.idpersonal " _
                         & " And ruta.vehiculo = vehiculo.idvehiculo  " _
                         & " and vehiculo.grupo = grupo.idgrupo " _
                         & " And grupo.subflota = subflota.idsubflota  " _
                         & " And ruta.destino = destino.iddestino  " _
                         & " And ruta.producto = producto.idproducto  " _
                         & " And ruta.sitiocarga = sitiocarga.idsitiocarga  " _
                         & " And ruta.estadoruta = estadoruta.idestado " _
                         & " And estado = 'ACTIVA' " _
                         & " AND nombreestado NOT IN ('EN TALLER') " _
                         & " AND nombregrupo = '" & ListadoGeneralRutas.TextBox1.Text & "' " _
                         & " ORDER BY nombreproducto ASC, nombresitiocarga ASC, nombreestado ASC "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview
        Adaptador.Fill(DataSet, "listadoactual2")
        Tabla = DataSet.Tables("listadoactual2")
        ListadoGeneralRutas.DataGridView.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ListadoGeneralRutas.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        'Mostramos la cantidad de registros encontrados
        ListadoGeneralRutas.Contador2.Text = ListadoGeneralRutas.DataGridView.RowCount

        'Quitamos la seleccion de cualquier fila del datagridview
        ListadoGeneralRutas.DataGridView.ClearSelection()

        CargarImagenesHistorialCarga()

    End Sub

    Public Sub CargarGridResumenVehiculo()
        'Metodo que genera la carga de datos en el DataGridview

        Dim sql As String = "SELECT COUNT(vehiculo) AS 'Unidades', nombreproducto AS 'Producto', nombresitiocarga AS 'Sitio de Carga', " _
                & " nombredestino AS 'Destino', nombreestado AS 'Estado' " _
                & " FROM ruta, producto, sitiocarga, destino, grupo, subflota, vehiculo, estadoruta " _
                & " WHERE ruta.producto = producto.idproducto " _
                & " AND ruta.destino = destino.iddestino    " _
                & " AND ruta.sitiocarga = sitiocarga.idsitiocarga    " _
                & " AND ruta.vehiculo = vehiculo.idvehiculo    " _
                & " and vehiculo.grupo = grupo.idgrupo " _
                & " And grupo.subflota = subflota.idsubflota  " _
                & " AND ruta.estadoruta = estadoruta.idestado  " _
                & " AND estado = 'ACTIVA'  " _
                & " AND nombreestado NOT IN ('EN TALLER') " _
                & " GROUP BY nombreestado, nombreproducto, nombresitiocarga, nombredestino   " _
                & " ORDER BY nombreproducto ASC, nombresitiocarga ASC, nombredestino ASC, nombreestado ASC "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview
        Adaptador.Fill(DataSet, "listadoresumen")
        Tabla = DataSet.Tables("listadoresumen")
        ListadoGeneralRutas.DataGridView1.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ListadoGeneralRutas.DataGridView1
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        'Traemos los numeros desde el Datagridview hacia los textbox.  
        ListadoGeneralRutas.Contador.Text = (Int(Sumar("ColumnaUnidades", ListadoGeneralRutas.DataGridView1)))

        'Quitamos la seleccion de cualquier fila del datagridview
        ListadoGeneralRutas.DataGridView1.ClearSelection()

        CargarImagenesHistorialCarga()

    End Sub

    Public Sub CargarGridResumenVehiculoGrupo()
        'Metodo que genera la carga de datos en el DataGridview

        Dim sql As String = "SELECT COUNT(vehiculo) AS 'Unidades', nombreproducto AS 'Producto',  nombresitiocarga AS 'Sitio de Carga', " _
                & " nombredestino AS 'Destino', nombreestado AS 'Estado' " _
                & " FROM ruta, producto, sitiocarga, destino, grupo, subflota, vehiculo, estadoruta " _
                & " WHERE ruta.producto = producto.idproducto " _
                & " AND ruta.destino = destino.iddestino    " _
                & " AND ruta.sitiocarga = sitiocarga.idsitiocarga    " _
                & " AND ruta.vehiculo = vehiculo.idvehiculo    " _
                & " and vehiculo.grupo = grupo.idgrupo " _
                & " And grupo.subflota = subflota.idsubflota  " _
                & " AND ruta.estadoruta = estadoruta.idestado  " _
                & " AND estado = 'ACTIVA'  " _
                & " AND nombreestado NOT IN ('EN TALLER') " _
                & " AND nombregrupo = '" & ListadoGeneralRutas.TextBox1.Text & "' " _
                & " GROUP BY nombreestado, nombreproducto, nombresitiocarga, nombredestino   " _
                & " ORDER BY nombreproducto ASC, nombresitiocarga ASC, nombredestino ASC, nombreestado ASC "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview
        Adaptador.Fill(DataSet, "listadoresumen2")
        Tabla = DataSet.Tables("listadoresumen2")
        ListadoGeneralRutas.DataGridView1.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ListadoGeneralRutas.DataGridView1
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        'Traemos los numeros desde el Datagridview hacia los textbox.  
        ListadoGeneralRutas.Contador2.Text = (Int(Sumar("ColumnaUnidades", ListadoGeneralRutas.DataGridView1)))

        'Quitamos la seleccion de cualquier fila del datagridview
        ListadoGeneralRutas.DataGridView1.ClearSelection()

        CargarImagenesHistorialCarga()

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''GUIA TELEFONICA'''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub CargarGridGuiaPersonalCarga()
        'Metodo para cargar el datagridview de la Guia Telefonica

        'Conexion a la BD.
        Dim sql As String = "SELECT idpersonal, nombrepersonal, tipopersonal, if(telefono1 <> 'N/A', (concat(LEFT(telefono1,4),' - ', RIGHT(telefono1,7))), 'N/A') AS 'Telefono1', " _
            & " if(telefono2 <> 'N/A', (concat(LEFT(telefono2,4),' - ', RIGHT(telefono2,7))), 'N/A') AS 'Telefono2', estadopersonal FROM personal " _
            & " WHERE estadopersonal = '" & GuiaTelefonica.TextBox1.Text & "' " _
            & " AND tipopersonal = 'CARGA' " _
            & " ORDER BY nombrepersonal ASC"

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "guiachofer")
        Tabla = DataSet.Tables("guiachofer")
        GuiaTelefonica.DataGridView1.DataSource = DataSet.Tables("guiachofer")

        'Parametros para editar apariencia del datagridview.
        With GuiaTelefonica.DataGridView1
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        GuiaTelefonica.DataGridView1.ClearSelection()

    End Sub

    Public Sub CargarGridGuiaPersonalLiviano()
        'Metodo para cargar el datagridview de la Guia Telefonica

        'Conexion a la BD.
        Dim sql As String = "SELECT idpersonal, nombrepersonal, tipopersonal, if(telefono1 <> 'N/A', (concat(LEFT(telefono1,4),' - ', RIGHT(telefono1,7))), 'N/A') AS 'Telefono1', " _
            & " if(telefono2 <> 'N/A', (concat(LEFT(telefono2,4),' - ', RIGHT(telefono2,7))), 'N/A') AS 'Telefono2', estadopersonal FROM personal " _
            & " WHERE estadopersonal = '" & GuiaTelefonica.TextBox1.Text & "' " _
            & " AND tipopersonal = 'LIVIANO' " _
            & " ORDER BY nombrepersonal ASC"

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "guiachofer2")
        Tabla = DataSet.Tables("guiachofer2")
        GuiaTelefonica.DataGridView2.DataSource = DataSet.Tables("guiachofer2")

        'Parametros para editar apariencia del datagridview.
        With GuiaTelefonica.DataGridView2
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        GuiaTelefonica.DataGridView2.ClearSelection()

    End Sub

    Public Sub CargarGridGuiaPersonal()
        'Metodo para cargar el datagridview.

        'Conexion a la BD.
        Dim sql As String = "SELECT idpersonal, nombrepersonal, tipopersonal, if(telefono1 <> 'N/A', (concat(LEFT(telefono1,4),' - ', RIGHT(telefono1,7))), 'N/A') AS 'Telefono1', " _
            & " if(telefono2 <> 'N/A', (concat(LEFT(telefono2,4),' - ', RIGHT(telefono2,7))), 'N/A') AS 'Telefono2', estadopersonal FROM personal " _
            & " WHERE estadopersonal = '" & GuiaTelefonica.TextBox1.Text & "' " _
            & " AND tipopersonal = 'PERSONAL' " _
            & " ORDER BY nombrepersonal ASC"

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "guiapersonal")
        Tabla = DataSet.Tables("guiapersonal")
        GuiaTelefonica.DataGridView5.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With GuiaTelefonica.DataGridView5
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        GuiaTelefonica.DataGridView5.ClearSelection()

    End Sub


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''CONSULTAR ''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Function Sumar(ByVal nombre_Columna As String, ByVal DataGridView As DataGridView) As Double
        'Metodo que permite sumar columnas en los DataGridView

        Dim total As Double = 0

        ' recorrer las filas y obtener los items de la columna indicada en "nombre_Columna"  
        Try
            For i As Integer = 0 To DataGridView.RowCount - 1
                total = total + CDbl(DataGridView.Item(nombre_Columna.ToLower, i).Value)
            Next

        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

        ' retornar el valor  
        Return total

    End Function

    Public Sub CargarResumenMateriaPrima()
        'Metodo que genera la carga de datos en el DataGridview

        Dim sql As String = " SELECT COUNT(vehiculo) AS 'Unidades', nombreestado AS 'Estado' " _
                        & " FROM ruta, estadoruta, producto, sitiocarga " _
                        & " WHERE ruta.producto = producto.idproducto " _
                        & " AND ruta.estadoruta = estadoruta.idestado " _
                        & " AND ruta.sitiocarga = sitiocarga.idsitiocarga " _
                        & " AND estado = 'ACTIVA'   " _
                        & " AND idproducto = '" & CuadroResumenMateriaPrima.TextBox4.Text & "'  " _
                        & " AND idsitiocarga = '" & CuadroResumenMateriaPrima.TextBox1.Text & "'  " _
                        & " GROUP BY nombreestado   " _
                        & " ORDER BY nombreestado ASC "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview
        Adaptador.Fill(DataSet, "resumenmaiz")
        Tabla = DataSet.Tables("resumenmaiz")
        CuadroResumenMateriaPrima.DataGridView.DataSource = DataSet.Tables("resumenmaiz")

        'Parametros para editar apariencia del datagridview.
        With CuadroResumenMateriaPrima.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        'Se elimina la seleccion del datagridview
        CuadroResumenMateriaPrima.DataGridView.ClearSelection()

    End Sub

    Public Sub ObtenerPersonalGuiaTelefonica()
        'Este metodo permite obtener el ID del chofer y sus datos

        Dim Adaptador As New MySqlDataAdapter
        Dim Tabla As New DataTable

        Adaptador = New MySqlDataAdapter("SELECT idpersonal, nombrepersonal, tipopersonal, telefono1, telefono2, estadopersonal " _
                                       & " FROM personal WHERE idpersonal = '" & GuiaTelefonica.TextBox2.Text & "' ", Conexion)
        Adaptador.Fill(Tabla)

        For Each row As DataRow In Tabla.Rows

            MaestroPersonal.TextBox1.Text = row("idpersonal").ToString
            MaestroPersonal.TextBox2.Text = row("nombrepersonal").ToString
            MaestroPersonal.ComboTipoPersona.Text = row("tipopersonal").ToString
            MaestroPersonal.TextBox3.Text = row("telefono1").ToString
            MaestroPersonal.TextBox4.Text = row("telefono2").ToString
            MaestroPersonal.ComboEstadoPersona.Text = row("estadopersonal").ToString

        Next

    End Sub

    Public Sub ObtenerPersonalListado()
        'Este metodo permite obtener el ID del chofer y sus datos

        Dim Adaptador As New MySqlDataAdapter
        Dim Tabla As New DataTable

        Adaptador = New MySqlDataAdapter("SELECT idpersonal, nombrepersonal, tipopersonal, telefono1, telefono2, estadopersonal " _
                                       & " FROM personal WHERE idpersonal = '" & ListadoPersonal.TextBox1.Text & "' ", Conexion)
        Adaptador.Fill(Tabla)

        For Each row As DataRow In Tabla.Rows

            MaestroPersonal.TextBox1.Text = row("idpersonal").ToString
            MaestroPersonal.TextBox2.Text = row("nombrepersonal").ToString
            MaestroPersonal.ComboTipoPersona.Text = row("tipopersonal").ToString
            MaestroPersonal.TextBox3.Text = row("telefono1").ToString
            MaestroPersonal.TextBox4.Text = row("telefono2").ToString
            MaestroPersonal.ComboEstadoPersona.Text = row("estadopersonal").ToString

        Next

    End Sub

    Public Sub CargarImagenesReporteVelocidad()
        'En este metodo especificamos cuales son las imagenes que se cargaran en el 
        'CellFormatting del DataGridView1
        'Cargamos las imágenes

        Bandera = My.Resources.Bandera
        Velocidad = My.Resources.Velocidad
        Critico = My.Resources.Critico
        Muerte = My.Resources.Muerte

    End Sub

    Public Sub CargarImagenesReporteConsumo()
        'En este metodo especificamos cuales son las imagenes que se cargaran en el 
        'CellFormatting del DataGridView1
        'Cargamos las imágenes

        Exceso = My.Resources.Consumo7
        Consumo = My.Resources.Consumo5

    End Sub


End Module
