

Module ModuloConsulta

    'Variables globales.

    Public Bandera As Image
    Public Critico As Image

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''CONSULTAR CHOFER''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub CargarGridChofer()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausura BETWEEN

        Dim Command As New MySqlCommand("SELECT idruta, idvehiculo, nombrechofer, nombreproducto, nombresitiocarga, nombredestino, nombreestado, fecha, hora " _
                           & " FROM ruta, vehiculo, chofer, sitiocarga, destino, producto, estadoruta " _
                           & " WHERE ruta.vehiculo = vehiculo.idvehiculo " _
                           & " AND ruta.chofer = chofer.idchofer " _
                           & " AND ruta.sitiocarga = sitiocarga.idsitiocarga " _
                           & " AND ruta.destino = destino.iddestino " _
                           & " AND ruta.producto = producto.idproducto " _
                           & " AND ruta.estadoruta = estadoruta.idestado " _
                           & " AND nombrechofer = '" & ConsultaChofer.TextBox1.Text & "' " _
                           & " AND nombreestado IN ('EN RUTA VACIO', 'EN RUTA CARGADO') " _
                           & " AND fecha BETWEEN @fecha1 AND @fecha2 " _
                           & " ORDER BY idruta DESC, fecha DESC, hora DESC ", cnn)

        'Para trabajar con fechas y campos tipo "DATE" se usan los parametos
        Command.Parameters.Add("@fecha1", MySqlDbType.Date).Value = ConsultaChofer.DateTimePicker1.Value
        Command.Parameters.Add("@fecha2", MySqlDbType.Date).Value = ConsultaChofer.DateTimePicker2.Value

        'Llenado del datagridview
        Dim adaptador As New MySqlDataAdapter(Command)
        Dim Tabla As New DataTable
        adaptador.Fill(Tabla)
        ConsultaChofer.DataGridView.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ConsultaChofer.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    Public Sub CargarGridChoferTop5()
        'Metodo para cargar el datagridview de la Guia Telefonica

        'Conexion a la BD.
        Dim sql As String = "SELECT DISTINCT vehiculo, MAX(fecha) AS 'Fecha2', nombreproducto " _
                            & " FROM ruta, chofer, producto  " _
                            & " WHERE ruta.chofer = chofer.idchofer " _
                            & " AND ruta.producto = producto.idproducto " _
                            & " AND nombrechofer = '" & ConsultaChofer.TextBox1.Text & "' " _
                            & " GROUP BY vehiculo, nombreproducto " _
                            & " ORDER BY Fecha2 DESC "

        Dim connection As New MySqlConnection(connectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "top5chofer")
        Tabla = DataSet.Tables("top5chofer")
        ConsultaChofer.DataGridView1.DataSource = DataSet.Tables("top5chofer")

        'Parametros para editar apariencia del datagridview.
        With ConsultaChofer.DataGridView1
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''CONSULTAR PRODUCTO''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub CargarGridProducto()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausura BETWEEN

        Dim Command As New MySqlCommand("SELECT idruta, idvehiculo, nombrechofer, nombreproducto, nombresitiocarga, nombredestino, nombreestado, fecha, hora " _
                           & " FROM ruta, vehiculo, chofer, sitiocarga, destino, producto, estadoruta " _
                           & " WHERE ruta.vehiculo = vehiculo.idvehiculo " _
                           & " AND ruta.chofer = chofer.idchofer " _
                           & " AND ruta.sitiocarga = sitiocarga.idsitiocarga " _
                           & " AND ruta.destino = destino.iddestino " _
                           & " AND ruta.producto = producto.idproducto " _
                           & " AND ruta.estadoruta = estadoruta.idestado " _
                           & " AND nombreproducto = '" & ConsultaProducto.TextBox1.Text & "' " _
                           & " AND nombreestado IN ('EN RUTA VACIO', 'EN RUTA CARGADO') " _
                           & " AND fecha BETWEEN @fecha1 AND @fecha2 " _
                           & " ORDER BY idruta DESC, fecha DESC, hora DESC ", cnn)

        'Para trabajar con fechas y campos tipo "DATE" se usan los parametos
        Command.Parameters.Add("@fecha1", MySqlDbType.Date).Value = ConsultaProducto.DateTimePicker1.Value
        Command.Parameters.Add("@fecha2", MySqlDbType.Date).Value = ConsultaProducto.DateTimePicker2.Value

        'Llenado del datagridview
        Dim adaptador As New MySqlDataAdapter(Command)
        Dim Tabla As New DataTable
        adaptador.Fill(Tabla)
        ConsultaProducto.DataGridView.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ConsultaProducto.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    Public Sub CargarGridProductoAgrupado()
        'Metodo para cargar el datagridview de la Guia Telefonica

        'Conexion a la BD.
        Dim sql As String = "SELECT COUNT(vehiculo) AS 'Conteo', MAX(fecha) AS 'Fecha2' " _
                            & " FROM ruta, producto, estadoruta  " _
                            & " WHERE ruta.estadoruta = estadoruta.idestado " _
                            & " AND ruta.producto = producto.idproducto " _
                            & " AND nombreproducto = '" & ConsultaProducto.TextBox1.Text & "' " _
                            & " AND nombreestado IN ('EN RUTA VACIO', 'EN RUTA CARGADO') " _
                            & " GROUP BY fecha " _
                            & " ORDER BY fecha DESC "

        Dim connection As New MySqlConnection(connectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "productoagrupado")
        Tabla = DataSet.Tables("productoagrupado")
        ConsultaProducto.DataGridView1.DataSource = DataSet.Tables("productoagrupado")

        'Parametros para editar apariencia del datagridview.
        With ConsultaProducto.DataGridView1
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''CONSULTAR VEHICULO''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub CargarGridVehiculo()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausura BETWEEN

        Dim Command As New MySqlCommand("SELECT idruta, idvehiculo, nombrechofer, nombreproducto, nombresitiocarga, nombredestino, fecha, hora " _
                           & " FROM ruta, vehiculo, chofer, sitiocarga, destino, producto, estadoruta " _
                           & " WHERE ruta.vehiculo = vehiculo.idvehiculo " _
                           & " AND ruta.chofer = chofer.idchofer " _
                           & " AND ruta.sitiocarga = sitiocarga.idsitiocarga " _
                           & " AND ruta.destino = destino.iddestino " _
                           & " AND ruta.producto = producto.idproducto " _
                           & " AND ruta.estadoruta = estadoruta.idestado " _
                           & " AND nombreestado IN ('EN RUTA VACIO', 'EN RUTA CARGADO') " _
                           & " AND idvehiculo = '" & ConsultaVehiculo.TextBox1.Text & "' " _
                           & " AND fecha BETWEEN @fecha1 AND @fecha2 " _
                           & " ORDER BY idruta DESC, fecha DESC, hora DESC ", cnn)

        'Para trabajar con fechas y campos tipo "DATE" se usan los parametos
        Command.Parameters.Add("@fecha1", MySqlDbType.Date).Value = ConsultaVehiculo.DateTimePicker1.Value
        Command.Parameters.Add("@fecha2", MySqlDbType.Date).Value = ConsultaVehiculo.DateTimePicker2.Value

        'Llenado del datagridview
        Dim adaptador As New MySqlDataAdapter(Command)
        Dim Tabla As New DataTable
        adaptador.Fill(Tabla)
        ConsultaVehiculo.DataGridView.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ConsultaVehiculo.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''CONSULTAR RUTA''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub CargarGridConsultaRuta()
        'Metodo que genera la carga de datos en el DataGridview usando la clausura BETWEEN

        Dim Command As New MySqlCommand("SELECT idruta, idvehiculo, nombrechofer, nombreproducto, nombresitiocarga, nombredestino, nombreestado, fecha, hora " _
                           & " FROM ruta, vehiculo, chofer, sitiocarga, destino, producto, estadoruta " _
                           & " WHERE ruta.vehiculo = vehiculo.idvehiculo " _
                           & " AND ruta.chofer = chofer.idchofer " _
                           & " AND ruta.sitiocarga = sitiocarga.idsitiocarga " _
                           & " AND ruta.destino = destino.iddestino " _
                           & " AND ruta.producto = producto.idproducto " _
                           & " AND ruta.estadoruta = estadoruta.idestado " _
                           & " AND nombreestado IN ('EN RUTA VACIO', 'EN RUTA CARGADO') " _
                           & " AND fecha BETWEEN @fecha1 AND @fecha2 " _
                           & " ORDER BY idruta DESC, fecha DESC, hora DESC ", cnn)

        'Para trabajar con fechas y campos tipo "DATE" se usan los parametos
        Command.Parameters.Add("@fecha1", MySqlDbType.Date).Value = ConsultaRuta.DateTimePicker1.Value
        Command.Parameters.Add("@fecha2", MySqlDbType.Date).Value = ConsultaRuta.DateTimePicker2.Value

        'Llenado del datagridview
        Dim adaptador As New MySqlDataAdapter(Command)
        Dim Tabla As New DataTable
        adaptador.Fill(Tabla)
        ConsultaRuta.DataGridView.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ConsultaRuta.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    Public Sub GenerarChartConsultaRuta()
        'Metodo que permite generar un grafico de acuerdo a los valores obtenidos desde la BD
        'ConsultaRuta

        Dim connection As New MySqlConnection(connectionString)

        Dim sql As String = "SELECT COUNT(*) AS 'Conteo', nombresubflota AS 'Flota' FROM ruta, estadoruta, vehiculo, subflota " _
                & " WHERE ruta.estadoruta = estadoruta.idestado AND ruta.vehiculo = vehiculo.idvehiculo " _
                & " AND vehiculo.subflota = subflota.idsubflota " _
                & " AND nombreestado IN ('EN RUTA CARGADO','EN RUTA VACIO') " _
                & " AND MONTH(fecha) = MONTH(CURDATE())" _
                & " GROUP BY nombresubflota "

        Dim Adaptador As New MySqlDataAdapter(sql, cnn)
        Dim Dataset As New DataSet()
        Adaptador.Fill(Dataset, "historialrutas2")

        'Enlace de datos con las barras (series)
        ConsultaRuta.Chart1.Series("Rutas").XValueMember = "Flota"
        ConsultaRuta.Chart1.Series("Rutas").YValueMembers = "Conteo"

        'Para ocultar las grillas
        ConsultaRuta.Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        ConsultaRuta.Chart1.ChartAreas(0).AxisX.MinorGrid.Enabled = False
        ConsultaRuta.Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        ConsultaRuta.Chart1.ChartAreas(0).AxisY.MinorGrid.Enabled = False

        'Establecemos el grafico en 3D
        ConsultaRuta.Chart1.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

        'Para cambiar la fuente de los ejes Y, X
        ConsultaRuta.Chart1.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Segoe UI", 8)
        ConsultaRuta.Chart1.ChartAreas(0).AxisY.LabelStyle.Font = New Font("Segoe UI", 9)

        'Color de las barras (series)
        ConsultaRuta.Chart1.Series(0).Color = Color.IndianRed

        ConsultaRuta.Chart1.ChartAreas("ChartArea1").AxisX.IsLabelAutoFit = False
        ConsultaRuta.Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.Angle = -55

        'Limpiamos y actualizamos el grafico como tal
        ConsultaRuta.Chart1.Series(0).Points.Clear()
        ConsultaRuta.Chart1.DataSource = ""

        'Enlace de datos
        ConsultaRuta.Chart1.DataSource = Dataset.Tables("historialrutas2")

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

        Dim connection As New MySqlConnection(connectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "ConsultaRuta1")
        Tabla = DataSet.Tables("ConsultaRuta1")
        ConsultaRuta.DataGridView1.DataSource = DataSet.Tables("ConsultaRuta1")

        'Parametros para editar apariencia del datagridview.
        With ConsultaRuta.DataGridView1
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''CONSULTA INFRACCIONES'''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub CargarGridConsultaVehiculoInfraccion()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausura BETWEEN
        'ConsultaInfraccion

        Dim Command As New MySqlCommand("SELECT idregistroinfraccion, vehiculo, nombrechofer, velocidad, estadovehiculo, fecha, hora " _
                           & " FROM registroinfraccion, chofer " _
                           & " WHERE registroinfraccion.chofer = chofer.idchofer " _
                           & " AND vehiculo = '" & ConsultaInfraccion.TextBox1.Text & "' " _
                           & " AND fecha BETWEEN @fecha1 AND @fecha2 " _
                           & " ORDER BY idregistroinfraccion DESC, fecha DESC, hora DESC ", cnn)

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

    End Sub

    Public Sub CargarGridConsultaInfraccion()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausura BETWEEN
        'ConsultaInfraccion

        Dim Command As New MySqlCommand("SELECT idregistroinfraccion, vehiculo, nombrechofer, velocidad, estadovehiculo, fecha, hora " _
                           & " FROM registroinfraccion, chofer, vehiculo " _
                           & " WHERE registroinfraccion.chofer = chofer.idchofer " _
                           & " AND registroinfraccion.vehiculo = vehiculo.idvehiculo " _
                           & " AND clasificacionvehiculo = '" & ConsultaInfraccion.TextBox2.Text & "' " _
                           & " AND fecha BETWEEN @fecha1 AND @fecha2 " _
                           & " ORDER BY idregistroinfraccion DESC, fecha DESC, hora DESC ", cnn)

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

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    ''''''''''''''''''''''''CONSULTA HISTORIAL DE CAMBIOS DE ESTADO '''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub CargarGridHistorialVehiculo()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausura BETWEEN

        Dim Command As New MySqlCommand("SELECT idhistorialvehiculo, vehiculo, estadohistorial, fecha, hora " _
                           & " FROM historialvehiculo " _
                           & " WHERE vehiculo = '" & ConsultaHistorialVehiculo.TextBox1.Text & "' " _
                           & " AND fecha BETWEEN @fecha1 AND @fecha2 " _
                           & " ORDER BY idhistorialvehiculo DESC, fecha DESC, hora DESC ", cnn)

        'Para trabajar con fechas y campos tipo "DATE" se usan los parametos
        Command.Parameters.Add("@fecha1", MySqlDbType.Date).Value = ConsultaHistorialVehiculo.DateTimePicker1.Value
        Command.Parameters.Add("@fecha2", MySqlDbType.Date).Value = ConsultaHistorialVehiculo.DateTimePicker2.Value

        'Llenado del datagridview
        Dim adaptador As New MySqlDataAdapter(Command)
        Dim Tabla As New DataTable
        adaptador.Fill(Tabla)
        ConsultaHistorialVehiculo.DataGridView.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ConsultaHistorialVehiculo.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    Public Sub CargarGridHistorialVehiculoGeneral()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausura BETWEEN

        Dim Command As New MySqlCommand("SELECT idhistorialvehiculo, vehiculo, estadohistorial, fecha, hora " _
                           & " FROM historialvehiculo " _
                           & " WHERE fecha BETWEEN @fecha1 AND @fecha2 " _
                           & " AND estadohistorial = 'EN REPARACIÓN' " _
                           & " ORDER BY idhistorialvehiculo DESC, fecha DESC, hora DESC ", cnn)

        'Para trabajar con fechas y campos tipo "DATE" se usan los parametos
        Command.Parameters.Add("@fecha1", MySqlDbType.Date).Value = ConsultaHistorialVehiculo.DateTimePicker1.Value
        Command.Parameters.Add("@fecha2", MySqlDbType.Date).Value = ConsultaHistorialVehiculo.DateTimePicker2.Value

        'Llenado del datagridview
        Dim adaptador As New MySqlDataAdapter(Command)
        Dim Tabla As New DataTable
        adaptador.Fill(Tabla)
        ConsultaHistorialVehiculo.DataGridView.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ConsultaHistorialVehiculo.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''REPORTE INFRACCIONES DE VELOCIDAD ''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub CargarGridListadoReporteInfraccion()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausura BETWEEN
        'ListadoReporteInfraccion

        Dim Command As New MySqlCommand("SELECT nombrechofer AS 'Chofer', COUNT(idregistroinfraccion) AS 'Cantidad de Infracciones', " _
                    & " MAX(velocidad) AS 'Maxima Velocidad', ROUND(AVG(velocidad), 2) as 'Promedio del Periodo', nombresubflota AS 'Flota' " _
                    & " FROM registroinfraccion, chofer, vehiculo, subflota " _
                    & " WHERE chofer.idchofer = registroinfraccion.chofer " _
                    & " AND registroinfraccion.vehiculo = vehiculo.idvehiculo " _
                    & " AND vehiculo.subflota = subflota.idsubflota " _
                    & " AND fecha BETWEEN @fecha1 AND @fecha2 " _
                    & " AND clasificacionvehiculo = '" & ReporteInfraccion.TextBox3.Text & "' " _
                    & " GROUP BY nombrechofer " _
                    & " ORDER BY COUNT(idregistroinfraccion) DESC, MAX(velocidad) DESC " _
                    & " LIMIT 15 ", cnn)

        'Para trabajar con fechas y campos tipo "DATE" se usan los parametos
        Command.Parameters.Add("@fecha1", MySqlDbType.Date).Value = ReporteInfraccion.DateTimePicker1.Value
        Command.Parameters.Add("@fecha2", MySqlDbType.Date).Value = ReporteInfraccion.DateTimePicker2.Value

        'Llenado del datagridview
        Dim adaptador As New MySqlDataAdapter(Command)
        Dim Tabla As New DataTable
        adaptador.Fill(Tabla)
        ReporteInfraccion.DataGridView.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With ReporteInfraccion.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    Public Sub CargarListadoInfraccion()
        'Metodo para cargar el datagridview.




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

    Public Sub CargarGridGeneralVehiculo()
        'Metodo que genera la carga de datos en el DataGridview2.

        Dim sql As String = "Select vehiculo, nombrechofer, nombreproducto, nombresitiocarga, nombredestino, nombresubflota, nombreestado " _
                         & " FROM ruta, chofer, subflota, vehiculo, destino, producto, sitiocarga, estadoruta  " _
                         & " WHERE ruta.chofer = chofer.idchofer " _
                         & " And ruta.vehiculo = vehiculo.idvehiculo  " _
                         & " And vehiculo.subflota = subflota.idsubflota  " _
                         & " And ruta.destino = destino.iddestino  " _
                         & " And ruta.producto = producto.idproducto  " _
                         & " And ruta.sitiocarga = sitiocarga.idsitiocarga  " _
                         & " And ruta.estadoruta = estadoruta.idestado " _
                         & " And estado = 'ACTIVA' " _
                         & " AND nombreestado NOT IN ('EN TALLER') " _
                         & " ORDER BY nombresubflota ASC, nombreproducto ASC, nombresitiocarga ASC, nombreestado ASC "

        Dim connection As New MySqlConnection(connectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview
        Adaptador.Fill(DataSet, "listadoactual")
        Tabla = DataSet.Tables("listadoactual")
        ConsultaGeneralVehiculo.DataGridView.DataSource = DataSet.Tables("listadoactual")

        'Parametros para editar apariencia del datagridview.
        With ConsultaGeneralVehiculo.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        'Mostramos la cantidad de registros encontrados
        ConsultaGeneralVehiculo.Contador.Text = ConsultaGeneralVehiculo.DataGridView.RowCount

    End Sub

    Public Sub CargarGridGuiaChoferCarga()
        'Metodo para cargar el datagridview de la Guia Telefonica

        'Conexion a la BD.
        Dim sql As String = "SELECT idchofer, nombrechofer, tipochofer, if(telefono1 <> 'N/A', (concat(LEFT(telefono1,4),' - ', RIGHT(telefono1,7))), 'N/A') AS 'Telefono1', " _
            & " if(telefono2 <> 'N/A', (concat(LEFT(telefono2,4),' - ', RIGHT(telefono2,7))), 'N/A') AS 'Telefono2', estadochofer FROM chofer " _
            & " WHERE estadochofer = '" & GuiaTelefonica.TextBox1.Text & "' " _
            & " AND tipochofer = 'CARGA' " _
            & " ORDER BY nombrechofer ASC"

        Dim connection As New MySqlConnection(connectionString)

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

    End Sub

    Public Sub CargarGridGuiaChoferLiviano()
        'Metodo para cargar el datagridview de la Guia Telefonica

        'Conexion a la BD.
        Dim sql As String = "SELECT idchofer, nombrechofer, tipochofer, if(telefono1 <> 'N/A', (concat(LEFT(telefono1,4),' - ', RIGHT(telefono1,7))), 'N/A') AS 'Telefono1', " _
            & " if(telefono2 <> 'N/A', (concat(LEFT(telefono2,4),' - ', RIGHT(telefono2,7))), 'N/A') AS 'Telefono2', estadochofer FROM chofer " _
            & " WHERE estadochofer = '" & GuiaTelefonica.TextBox1.Text & "' " _
            & " AND tipochofer = 'LIVIANO' " _
            & " ORDER BY nombrechofer ASC"

        Dim connection As New MySqlConnection(connectionString)

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

    End Sub

    Public Sub CargarGridGuiaPersona()
        'Metodo para cargar el datagridview.

        'Conexion a la BD.
        Dim sql As String = "SELECT idpersona, nombrepersona, if(telefono1 <> 'N/A', (concat(LEFT(telefono1,4),' - ', RIGHT(telefono1,7))), 'N/A') AS 'Telefono1', " _
                            & " if(telefono2 <> 'N/A', (concat(LEFT(telefono2,4),' - ', RIGHT(telefono2,7))), 'N/A') AS 'Telefono2', descripcion " _
                            & " FROM personal " _
                            & " ORDER BY nombrepersona ASC"

        Dim connection As New MySqlConnection(connectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "guiapersonal")
        Tabla = DataSet.Tables("guiapersonal")
        GuiaTelefonica.DataGridView3.DataSource = DataSet.Tables("guiapersonal")

        'Parametros para editar apariencia del datagridview.
        With GuiaTelefonica.DataGridView3
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    Public Sub CargarGridResumenVehiculo()
        'Metodo que genera la carga de datos en el DataGridview

        Dim sql As String = "SELECT COUNT(vehiculo) AS 'Unidades', nombreproducto AS 'Producto',  nombresitiocarga AS 'Sitio de Carga', " _
                & " nombredestino AS 'Destino', nombreestado AS 'Estado',  " _
                & " nombresubflota AS 'Flota'  " _
                & " FROM ruta, producto, sitiocarga, destino, subflota, vehiculo, estadoruta " _
                & " WHERE ruta.producto = producto.idproducto " _
                & " AND ruta.destino = destino.iddestino    " _
                & " AND ruta.sitiocarga = sitiocarga.idsitiocarga    " _
                & " AND ruta.vehiculo = vehiculo.idvehiculo    " _
                & " AND vehiculo.subflota = subflota.idsubflota  " _
                & " AND ruta.estadoruta = estadoruta.idestado  " _
                & " AND estado = 'ACTIVA'  " _
                & " AND nombreestado NOT IN ('EN TALLER') " _
                & " GROUP BY nombreestado, nombreproducto, nombresitiocarga, nombredestino, nombresubflota   " _
                & " ORDER BY nombresubflota, nombreproducto ASC, nombresitiocarga ASC, nombredestino ASC, nombreestado ASC "

        Dim connection As New MySqlConnection(connectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview
        Adaptador.Fill(DataSet, "listadoresumen")
        Tabla = DataSet.Tables("listadoresumen")
        ConsultaResumenVehiculo.DataGridView.DataSource = DataSet.Tables("listadoresumen")

        'Parametros para editar apariencia del datagridview.
        With ConsultaResumenVehiculo.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        'Traemos los numeros desde el Datagridview hacia los textbox.  
        ConsultaResumenVehiculo.Contador.Text = (Int(Sumar("ColumnaUnidades", ConsultaResumenVehiculo.DataGridView)))

    End Sub

    Public Sub CargarResumenMateriaPrima()
        'Metodo que genera la carga de datos en el DataGridview

        Dim sql As String = " SELECT COUNT(vehiculo) AS 'Unidades', nombreestado AS 'Estado' " _
                        & " FROM ruta, estadoruta, producto " _
                        & " WHERE ruta.producto = producto.idproducto " _
                        & " AND ruta.estadoruta = estadoruta.idestado   " _
                        & " AND estado = 'ACTIVA'   " _
                        & " AND idproducto = '" & CuadroResumenMateriaPrima.TextBox4.Text & "'  " _
                        & " GROUP BY nombreestado   " _
                        & " ORDER BY nombreestado ASC "

        Dim connection As New MySqlConnection(connectionString)

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

    Public Sub ObtenerChoferGuiaTelefonica()
        'Este metodo permite obtener el ID del chofer y sus datos

        Dim Adaptador As New MySqlDataAdapter
        Dim Tabla As New DataTable

        Adaptador = New MySqlDataAdapter("SELECT idchofer, nombrechofer, tipochofer, telefono1, telefono2, estadochofer " _
                                          & " FROM chofer WHERE idchofer = '" & GuiaTelefonica.TextBox2.Text & "' ", cnn)
        Adaptador.Fill(Tabla)

        For Each row As DataRow In Tabla.Rows

            MaestroChofer.TextBox1.Text = row("idchofer").ToString
            MaestroChofer.TextBox2.Text = row("nombrechofer").ToString
            MaestroChofer.ComboTipoChofer.Text = row("tipochofer").ToString
            MaestroChofer.TextBox3.Text = row("telefono1").ToString
            MaestroChofer.TextBox4.Text = row("telefono2").ToString
            MaestroChofer.ComboEstadoChofer.Text = row("estadochofer").ToString

        Next

    End Sub

    Public Sub ObtenerPersonaGuiaTelefonica()
        'Este metodo permite obtener el ID del chofer y sus datos

        Dim Adaptador As New MySqlDataAdapter
        Dim Tabla As New DataTable

        Adaptador = New MySqlDataAdapter("SELECT idpersona, nombrepersona, telefono1, telefono2, descripcion " _
                                          & " FROM personal WHERE idpersona = '" & GuiaTelefonica.TextBox2.Text & "' ", cnn)
        Adaptador.Fill(Tabla)

        For Each row As DataRow In Tabla.Rows

            MaestroPersona.TextBox1.Text = row("idpersona").ToString
            MaestroPersona.TextBox2.Text = row("nombrepersona").ToString
            MaestroPersona.TextBox3.Text = row("telefono1").ToString
            MaestroPersona.TextBox4.Text = row("telefono2").ToString
            MaestroPersona.ComboDescripcion.Text = row("descripcion").ToString

        Next

    End Sub

    Public Sub ObtenerChoferListado()
        'Este metodo permite obtener el ID del chofer y sus datos

        Dim Adaptador As New MySqlDataAdapter
        Dim Tabla As New DataTable

        Adaptador = New MySqlDataAdapter("SELECT idchofer, nombrechofer, tipochofer, telefono1, telefono2, estadochofer " _
                                          & " FROM chofer WHERE idchofer = '" & ListadoChofer.TextBox3.Text & "' ", cnn)
        Adaptador.Fill(Tabla)

        For Each row As DataRow In Tabla.Rows

            MaestroChofer.TextBox1.Text = row("idchofer").ToString
            MaestroChofer.TextBox2.Text = row("nombrechofer").ToString
            MaestroChofer.ComboTipoChofer.Text = row("tipochofer").ToString
            MaestroChofer.TextBox3.Text = row("telefono1").ToString
            MaestroChofer.TextBox4.Text = row("telefono2").ToString
            MaestroChofer.ComboEstadoChofer.Text = row("estadochofer").ToString

        Next

    End Sub

    Public Sub CargarImagenesReporteVelocidad()
        'En este metodo especificamos cuales son las imagenes que se cargaran en el 
        'CellFormatting del DataGridView1
        'SIN USARSE AUN
        'Cargamos las imágenes

        Bandera = My.Resources.Bandera
        Critico = My.Resources.Critico

    End Sub


End Module
