
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Configuration

Module ModuloEstadistica

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''CARGA DE DATOS''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub CargarEstadisticaHistorialReparacion()
        'Metodo para cargar el datagridview.
        'EstadisticaHistorialVehiculo

        'Conexion a la BD.
        Dim sql As String = "SELECT vehiculo AS 'Vehiculo', COUNT(*) AS 'Conteo', estadohistorial AS 'Estado' " _
                            & " FROM historialvehiculo " _
                            & " WHERE estadohistorial = 'EN REPARACIÓN' " _
                            & " GROUP BY vehiculo " _
                            & " ORDER BY Conteo DESC"

        Dim connection As New MySqlConnection(connectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "estadisticashistorial1")
        Tabla = DataSet.Tables("estadisticashistorial1")
        EstadisticaHistorialVehiculo.DataGridView.DataSource = DataSet.Tables("estadisticashistorial1")

        'Parametros para editar apariencia del datagridview.
        With EstadisticaHistorialVehiculo.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    Public Sub CargarEstadisticaHistorialSinReporte()
        'Metodo para cargar el datagridview.
        'EstadisticaHistorialVehiculo

        'Conexion a la BD.
        Dim sql As String = "SELECT vehiculo AS 'Vehiculo', COUNT(*) AS 'Conteo', estadohistorial AS 'Estado' " _
                            & " FROM historialvehiculo " _
                            & " WHERE estadohistorial = 'UNIDAD SIN REPORTE DE GPS' " _
                            & " GROUP BY vehiculo " _
                            & " ORDER BY Conteo DESC"

        Dim connection As New MySqlConnection(connectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "estadisticashistorial2")
        Tabla = DataSet.Tables("estadisticashistorial2")
        EstadisticaHistorialVehiculo.DataGridView.DataSource = DataSet.Tables("estadisticashistorial2")

        'Parametros para editar apariencia del datagridview.
        With EstadisticaHistorialVehiculo.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    Public Sub CargarEstadisticaHistorialEnServicio()
        'Metodo para cargar el datagridview.
        'EstadisticaHistorialVehiculo

        'Conexion a la BD.
        Dim sql As String = "SELECT vehiculo AS 'Vehiculo', COUNT(*) AS 'Conteo', estadohistorial AS 'Estado' " _
                            & " FROM historialvehiculo " _
                            & " WHERE estadohistorial = 'EN SERVICIO' " _
                            & " GROUP BY vehiculo " _
                            & " ORDER BY Conteo DESC"

        Dim connection As New MySqlConnection(connectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "estadisticashistorial3")
        Tabla = DataSet.Tables("estadisticashistorial3")
        EstadisticaHistorialVehiculo.DataGridView.DataSource = DataSet.Tables("estadisticashistorial3")

        'Parametros para editar apariencia del datagridview.
        With EstadisticaHistorialVehiculo.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    Public Sub CargarEstadisticaHistorialExtraviado()
        'Metodo para cargar el datagridview.
        'EstadisticaHistorialVehiculo

        'Conexion a la BD.
        Dim sql As String = "SELECT vehiculo AS 'Vehiculo', COUNT(*) AS 'Conteo', estadohistorial AS 'Estado' " _
                            & " FROM historialvehiculo " _
                            & " WHERE estadohistorial = 'ROBADO / EXTRAVIADO' " _
                            & " GROUP BY vehiculo " _
                            & " ORDER BY Conteo DESC"

        Dim connection As New MySqlConnection(connectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "estadisticashistorial4")
        Tabla = DataSet.Tables("estadisticashistorial4")
        EstadisticaHistorialVehiculo.DataGridView.DataSource = DataSet.Tables("estadisticashistorial4")

        'Parametros para editar apariencia del datagridview.
        With EstadisticaHistorialVehiculo.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    Public Sub CargarEstadisticaHistorialSinGPS()
        'Metodo para cargar el datagridview.
        'EstadisticaHistorialVehiculo

        'Conexion a la BD.
        Dim sql As String = "SELECT vehiculo AS 'Vehiculo', COUNT(*) AS 'Conteo', estadohistorial AS 'Estado' " _
                            & " FROM historialvehiculo " _
                            & " WHERE estadohistorial = 'UNIDAD SIN DISPOSITIVO GPS' " _
                            & " GROUP BY vehiculo " _
                            & " ORDER BY Conteo DESC"

        Dim connection As New MySqlConnection(connectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "estadisticashistorial5")
        Tabla = DataSet.Tables("estadisticashistorial5")
        EstadisticaHistorialVehiculo.DataGridView.DataSource = DataSet.Tables("estadisticashistorial5")

        'Parametros para editar apariencia del datagridview.
        With EstadisticaHistorialVehiculo.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    Public Sub CargarEstadisticaHistorialRutaVehiculo()
        'Metodo para cargar el datagridview.
        'EstadisticaRuta

        'Conexion a la BD.
        Dim sql As String = "SELECT COUNT(*) AS 'Conteo', vehiculo AS 'Vehiculo' FROM ruta, estadoruta " _
                        & " WHERE ruta.estadoruta = estadoruta.idestado " _
                        & " AND nombreestado IN ('EN RUTA CARGADO','EN RUTA VACIO') " _
                        & " GROUP BY vehiculo " _
                        & " ORDER BY COUNT(*) DESC"

        Dim connection As New MySqlConnection(connectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "estadisticasrutavehiculo")
        Tabla = DataSet.Tables("estadisticasrutavehiculo")
        EstadisticaRuta.DataGridView.DataSource = DataSet.Tables("estadisticasrutavehiculo")

        'Parametros para editar apariencia del datagridview.
        With EstadisticaRuta.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    Public Sub CargarEstadisticaHistorialRutaChofer()
        'Metodo para cargar el datagridview.
        'EstadisticaRuta

        'Conexion a la BD.
        Dim sql As String = "SELECT COUNT(*) AS 'Conteo', nombrechofer AS 'Chofer' FROM ruta, chofer, estadoruta " _
                        & " WHERE ruta.chofer = chofer.idchofer AND ruta.estadoruta = estadoruta.idestado " _
                        & " AND nombreestado IN ('EN RUTA CARGADO','EN RUTA VACIO') " _
                        & " GROUP BY nombrechofer " _
                        & " ORDER BY COUNT(*) DESC "

        Dim connection As New MySqlConnection(connectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "estadisticasrutachofer")
        Tabla = DataSet.Tables("estadisticasrutachofer")
        EstadisticaRuta.DataGridView1.DataSource = DataSet.Tables("estadisticasrutachofer")

        'Parametros para editar apariencia del datagridview.
        With EstadisticaRuta.DataGridView1
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    Public Sub CargarEstadisticaHistorialRutaFlota()
        'Metodo para cargar el datagridview.
        'EstadisticaRuta

        'Conexion a la BD.
        Dim sql As String = "SELECT COUNT(*) AS 'Conteo', nombresubflota AS 'Flota' FROM ruta, estadoruta, vehiculo, subflota " _
                & " WHERE ruta.estadoruta = estadoruta.idestado AND ruta.vehiculo = vehiculo.idvehiculo " _
                & " AND vehiculo.subflota = subflota.idsubflota " _
                & " AND nombreestado IN ('EN RUTA CARGADO','EN RUTA VACIO') " _
                & " GROUP BY nombresubflota "

        Dim connection As New MySqlConnection(connectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "estadisticasrutaflota")
        Tabla = DataSet.Tables("estadisticasrutaflota")
        EstadisticaRuta.DataGridView2.DataSource = DataSet.Tables("estadisticasrutaflota")

        'Parametros para editar apariencia del datagridview.
        With EstadisticaRuta.DataGridView2
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    Public Sub CargarEstadisticaHistorialInfraccionVehiculo()
        'Metodo para cargar el datagridview.
        'EstadisticaInfraccion

        'Conexion a la BD.
        Dim sql As String = "SELECT COUNT(velocidad) AS 'Conteo', vehiculo AS 'Vehiculo' FROM registroinfraccion, vehiculo " _
                        & " WHERE registroinfraccion.vehiculo = vehiculo.idvehiculo " _
                        & " GROUP BY vehiculo " _
                        & " ORDER BY Conteo DESC"

        Dim connection As New MySqlConnection(connectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "estadisticasinfraccionvehiculo")
        Tabla = DataSet.Tables("estadisticasinfraccionvehiculo")
        EstadisticaInfraccion.DataGridView.DataSource = DataSet.Tables("estadisticasinfraccionvehiculo")

        'Parametros para editar apariencia del datagridview.
        With EstadisticaInfraccion.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    Public Sub CargarEstadisticaHistorialInfraccionChofer()
        'Metodo para cargar el datagridview.
        'EstadisticaInfraccion

        'Conexion a la BD.
        Dim sql As String = "SELECT COUNT(velocidad) AS 'Conteo', nombrechofer AS 'Chofer' FROM registroinfraccion, chofer " _
                        & " WHERE registroinfraccion.chofer = chofer.idchofer " _
                        & " GROUP BY nombrechofer " _
                        & " ORDER BY Conteo DESC "

        Dim connection As New MySqlConnection(connectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "estadisticasinfracionchofer")
        Tabla = DataSet.Tables("estadisticasinfracionchofer")
        EstadisticaInfraccion.DataGridView1.DataSource = DataSet.Tables("estadisticasinfracionchofer")

        'Parametros para editar apariencia del datagridview.
        With EstadisticaInfraccion.DataGridView1
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    Public Sub CargarEstadisticaHistorialInfraccionFlota()
        'Metodo para cargar el datagridview.
        'EstadisticaInfraccion

        'Conexion a la BD.
        Dim sql As String = "SELECT COUNT(velocidad) AS 'Conteo', nombresubflota AS 'Flota' " _
                                & " FROM registroinfraccion, vehiculo, subflota " _
                                & " WHERE registroinfraccion.vehiculo = vehiculo.idvehiculo " _
                                & " AND vehiculo.subflota = subflota.idsubflota " _
                                & " GROUP BY nombresubflota " _
                                & " ORDER BY nombresubflota ASC "

        Dim connection As New MySqlConnection(connectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "estadisticasinfraccionflota")
        Tabla = DataSet.Tables("estadisticasinfraccionflota")
        EstadisticaInfraccion.DataGridView2.DataSource = DataSet.Tables("estadisticasinfraccionflota")

        'Parametros para editar apariencia del datagridview.
        With EstadisticaInfraccion.DataGridView2
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    Public Sub CargarEstadisticaHistorialSitioDeCarga()
        'Metodo para cargar el datagridview.
        'EstadisticasitiocargaDestino

        'Conexion a la BD.
        Dim sql As String = "SELECT nombresitiocarga AS 'Sitio de Carga', COUNT(nombresitiocarga) AS 'Conteo' " _
                            & " FROM ruta, sitiocarga, estadoruta " _
                            & " WHERE ruta.sitiocarga = sitiocarga.idsitiocarga " _
                            & " AND ruta.estadoruta = estadoruta.idestado " _
                            & " AND nombreestado IN ('EN RUTA VACIO', 'EN RUTA CARGADO')  " _
                            & " GROUP BY nombresitiocarga " _
                            & " ORDER BY Conteo DESC "

        Dim connection As New MySqlConnection(connectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "estadisticassitiodecarga")
        Tabla = DataSet.Tables("estadisticassitiodecarga")
        EstadisticasitiocargaDestino.DataGridView1.DataSource = DataSet.Tables("estadisticassitiodecarga")

        'Parametros para editar apariencia del datagridview.
        With EstadisticasitiocargaDestino.DataGridView1
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    Public Sub CargarEstadisticaHistorialDestino()
        'Metodo para cargar el datagridview.
        'EstadisticasitiocargaDestino

        'Conexion a la BD.
        Dim sql As String = "SELECT nombredestino AS 'Despacho', COUNT(nombredestino) AS 'Conteo' " _
                            & " FROM ruta, destino, estadoruta " _
                            & " WHERE ruta.destino = destino.iddestino " _
                            & " AND ruta.estadoruta = estadoruta.idestado " _
                            & " AND nombreestado IN ('EN RUTA VACIO', 'EN RUTA CARGADO')  " _
                            & " GROUP BY nombredestino " _
                            & " ORDER BY Conteo DESC "

        Dim connection As New MySqlConnection(connectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "estadisticasdestino")
        Tabla = DataSet.Tables("estadisticasdestino")
        EstadisticasitiocargaDestino.DataGridView.DataSource = DataSet.Tables("estadisticasdestino")

        'Parametros para editar apariencia del datagridview.
        With EstadisticasitiocargaDestino.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    Public Sub CargarEstadisticaHistorialProducto()
        'Metodo para cargar el datagridview.
        'EstadisticaProducto

        'Conexion a la BD.
        Dim sql As String = "SELECT nombreproducto AS 'Producto', COUNT(nombreproducto) AS 'Conteo' " _
                            & " FROM ruta, producto, estadoruta " _
                            & " WHERE ruta.producto = producto.idproducto " _
                            & " AND ruta.estadoruta = estadoruta.idestado " _
                            & " AND nombreestado IN ('EN RUTA VACIO', 'EN RUTA CARGADO')  " _
                            & " GROUP BY nombreproducto " _
                            & " ORDER BY Conteo DESC "

        Dim connection As New MySqlConnection(connectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "estadisticaproducto")
        Tabla = DataSet.Tables("estadisticaproducto")
        EstadisticaProducto.DataGridView.DataSource = DataSet.Tables("estadisticaproducto")

        'Parametros para editar apariencia del datagridview.
        With EstadisticaProducto.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''CARGA DE GRAFICOS'''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub GenerarChartEstadisticaProducto()
        'Metodo que permite generar un grafico de acuerdo a los valores obtenidos desde la BD
        'EstadisticaProducto

        Dim connection As New MySqlConnection(connectionString)

        Dim sql As String = "SELECT nombreproducto AS 'Producto', COUNT(nombreproducto) AS 'Conteo' " _
                        & " FROM ruta, producto, estadoruta " _
                        & " WHERE ruta.producto = producto.idproducto " _
                        & " AND ruta.estadoruta = estadoruta.idestado " _
                        & " AND nombreestado IN ('EN RUTA VACIO', 'EN RUTA CARGADO')  " _
                        & " GROUP BY nombreproducto " _
                        & " ORDER BY Conteo DESC " _
                        & " LIMIT 5"

        Dim Adaptador As New MySqlDataAdapter(sql, cnn)
        Dim Dataset As New DataSet()
        Adaptador.Fill(Dataset, "historialproducto")

        'Enlace de datos con las barras (series)
        EstadisticaProducto.Chart1.Series("Producto").XValueMember = "Producto"
        EstadisticaProducto.Chart1.Series("Producto").YValueMembers = "Conteo"

        'Para ocultar las grillas
        EstadisticaProducto.Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        EstadisticaProducto.Chart1.ChartAreas(0).AxisX.MinorGrid.Enabled = False
        EstadisticaProducto.Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        EstadisticaProducto.Chart1.ChartAreas(0).AxisY.MinorGrid.Enabled = False

        'Establecemos el grafico en 3D
        EstadisticaProducto.Chart1.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

        'Para cambiar la fuente de los ejes Y, X
        EstadisticaProducto.Chart1.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Segoe UI", 8)
        EstadisticaProducto.Chart1.ChartAreas(0).AxisY.LabelStyle.Font = New Font("Segoe UI", 9)

        'Color de las barras (series)
        EstadisticaProducto.Chart1.Series(0).Color = Color.IndianRed

        EstadisticaProducto.Chart1.ChartAreas("ChartArea1").AxisX.IsLabelAutoFit = False
        EstadisticaProducto.Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.Angle = -55

        'Limpiamos y actualizamos el grafico como tal
        EstadisticaProducto.Chart1.Series(0).Points.Clear()
        EstadisticaProducto.Chart1.DataSource = ""

        'Enlace de datos
        EstadisticaProducto.Chart1.DataSource = Dataset.Tables("historialproducto")


    End Sub

    Public Sub GenerarChartEstadisticaHistorial()
        'Metodo que permite generar un grafico de acuerdo a los valores obtenidos desde la BD
        'EstadisticaHistorialVehiculo

        Dim connection As New MySqlConnection(connectionString)

        Dim sql As String = "SELECT COUNT(estadohistorial) AS 'Conteo', estadohistorial AS 'Estado' " _
                            & " FROM historialvehiculo " _
                            & " WHERE estadohistorial IN ('EN REPARACIÓN','UNIDAD SIN REPORTE DE GPS', 'EN SERVICIO', " _
                            & " 'ROBADO / EXTRAVIADO', 'UNIDAD SIN DISPOSITIVO GPS') " _
                            & " GROUP BY estadohistorial "

        Dim Adaptador As New MySqlDataAdapter(sql, cnn)
        Dim Dataset As New DataSet()
        Adaptador.Fill(Dataset, "historialvehiculo33")

        'Enlace de datos con las barras (series)
        EstadisticaHistorialVehiculo.Chart1.Series("Ingresos a Taller").XValueMember = "Estado"
        EstadisticaHistorialVehiculo.Chart1.Series("Ingresos a Taller").YValueMembers = "Conteo"

        'Para ocultar las grillas
        EstadisticaHistorialVehiculo.Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        EstadisticaHistorialVehiculo.Chart1.ChartAreas(0).AxisX.MinorGrid.Enabled = False
        EstadisticaHistorialVehiculo.Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        EstadisticaHistorialVehiculo.Chart1.ChartAreas(0).AxisY.MinorGrid.Enabled = False

        'Establecemos el grafico en 3D
        EstadisticaHistorialVehiculo.Chart1.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

        'Para cambiar la fuente de los ejes Y, X
        EstadisticaHistorialVehiculo.Chart1.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Segoe UI", 9)
        EstadisticaHistorialVehiculo.Chart1.ChartAreas(0).AxisY.LabelStyle.Font = New Font("Segoe UI", 9)

        'Color de las barras (series)
        EstadisticaHistorialVehiculo.Chart1.Series(0).Color = Color.IndianRed

        EstadisticaHistorialVehiculo.Chart1.ChartAreas("ChartArea1").AxisX.IsLabelAutoFit = False
        EstadisticaHistorialVehiculo.Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.Angle = -55

        'Limpiamos y actualizamos el grafico como tal
        EstadisticaHistorialVehiculo.Chart1.Series(0).Points.Clear()
        EstadisticaHistorialVehiculo.Chart1.DataSource = ""

        'Enlace de datos
        EstadisticaHistorialVehiculo.Chart1.DataSource = Dataset.Tables("historialvehiculo33")

    End Sub

    Public Sub GenerarChartEstadisticaInfraccion()
        'Metodo que permite generar un grafico de acuerdo a los valores obtenidos desde la BD
        'EstadisticaInfraccion

        Dim connection As New MySqlConnection(connectionString)

        Dim sql As String = "SELECT COUNT(velocidad) AS 'Conteo', nombresubflota AS 'Flota' " _
                                & " FROM registroinfraccion, vehiculo, subflota " _
                                & " WHERE registroinfraccion.vehiculo = vehiculo.idvehiculo " _
                                & " AND vehiculo.subflota = subflota.idsubflota " _
                                & " GROUP BY nombresubflota " _
                                & " ORDER BY nombresubflota ASC "

        Dim Adaptador As New MySqlDataAdapter(sql, cnn)
        Dim Dataset As New DataSet()
        Adaptador.Fill(Dataset, "historialinfracciones")

        'Enlace de datos con las barras (series)
        EstadisticaInfraccion.Chart1.Series("Infracciones por Flotas").XValueMember = "Flota"
        EstadisticaInfraccion.Chart1.Series("Infracciones por Flotas").YValueMembers = "Conteo"

        'Para ocultar las grillas
        EstadisticaInfraccion.Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        EstadisticaInfraccion.Chart1.ChartAreas(0).AxisX.MinorGrid.Enabled = False
        EstadisticaInfraccion.Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        EstadisticaInfraccion.Chart1.ChartAreas(0).AxisY.MinorGrid.Enabled = False

        'Establecemos el grafico en 3D
        EstadisticaInfraccion.Chart1.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

        'Para cambiar la fuente de los ejes Y, X
        EstadisticaInfraccion.Chart1.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Segoe UI", 8)
        EstadisticaInfraccion.Chart1.ChartAreas(0).AxisY.LabelStyle.Font = New Font("Segoe UI", 9)

        'Color de las barras (series)
        EstadisticaInfraccion.Chart1.Series(0).Color = Color.IndianRed

        EstadisticaInfraccion.Chart1.ChartAreas("ChartArea1").AxisX.IsLabelAutoFit = False
        EstadisticaInfraccion.Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.Angle = -55

        'Limpiamos y actualizamos el grafico como tal
        EstadisticaInfraccion.Chart1.Series(0).Points.Clear()
        EstadisticaInfraccion.Chart1.DataSource = ""

        'Enlace de datos
        EstadisticaInfraccion.Chart1.DataSource = Dataset.Tables("historialinfracciones")


    End Sub

    Public Sub GenerarChartEstadisticaRuta()
        'Metodo que permite generar un grafico de acuerdo a los valores obtenidos desde la BD
        'EstadisticaRuta

        Dim connection As New MySqlConnection(connectionString)

        Dim sql As String = "SELECT COUNT(*) AS 'Conteo', nombresubflota AS 'Flota' FROM ruta, estadoruta, vehiculo, subflota " _
                & " WHERE ruta.estadoruta = estadoruta.idestado AND ruta.vehiculo = vehiculo.idvehiculo " _
                & " AND vehiculo.subflota = subflota.idsubflota " _
                & " AND nombreestado IN ('EN RUTA CARGADO','EN RUTA VACIO') " _
                & " GROUP BY nombresubflota "

        Dim Adaptador As New MySqlDataAdapter(sql, cnn)
        Dim Dataset As New DataSet()
        Adaptador.Fill(Dataset, "historialrutas")

        'Enlace de datos con las barras (series)
        EstadisticaRuta.Chart1.Series("Historial de Rutas").XValueMember = "Flota"
        EstadisticaRuta.Chart1.Series("Historial de Rutas").YValueMembers = "Conteo"

        'Para ocultar las grillas
        EstadisticaRuta.Chart1.ChartAreas(0).AxisX.MajorGrid.Enabled = False
        EstadisticaRuta.Chart1.ChartAreas(0).AxisX.MinorGrid.Enabled = False
        EstadisticaRuta.Chart1.ChartAreas(0).AxisY.MajorGrid.Enabled = False
        EstadisticaRuta.Chart1.ChartAreas(0).AxisY.MinorGrid.Enabled = False

        'Establecemos el grafico en 3D
        EstadisticaRuta.Chart1.ChartAreas("ChartArea1").Area3DStyle.Enable3D = True

        'Para cambiar la fuente de los ejes Y, X
        EstadisticaRuta.Chart1.ChartAreas(0).AxisX.LabelStyle.Font = New Font("Segoe UI", 8)
        EstadisticaRuta.Chart1.ChartAreas(0).AxisY.LabelStyle.Font = New Font("Segoe UI", 9)

        'Color de las barras (series)
        EstadisticaRuta.Chart1.Series(0).Color = Color.IndianRed

        EstadisticaRuta.Chart1.ChartAreas("ChartArea1").AxisX.IsLabelAutoFit = False
        EstadisticaRuta.Chart1.ChartAreas("ChartArea1").AxisX.LabelStyle.Angle = -55

        'Limpiamos y actualizamos el grafico como tal
        EstadisticaRuta.Chart1.Series(0).Points.Clear()
        EstadisticaRuta.Chart1.DataSource = ""

        'Enlace de datos
        EstadisticaRuta.Chart1.DataSource = Dataset.Tables("historialrutas")

    End Sub


End Module
