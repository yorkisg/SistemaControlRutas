

Module ModuloEstadistica

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''CARGA DE DATOS''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub CargarEstadisticaHistorialRutaVehiculo()
        'Metodo para cargar el datagridview.
        'EstadisticaRuta

        'Conexion a la BD.
        Dim sql As String = "SELECT COUNT(*) AS 'Conteo', vehiculo AS 'Vehiculo' FROM ruta, estadoruta " _
                        & " WHERE ruta.estadoruta = estadoruta.idestado " _
                        & " AND nombreestado IN ('EN RUTA CARGADO','EN RUTA VACIO') " _
                        & " GROUP BY vehiculo " _
                        & " ORDER BY COUNT(*) DESC"

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "estadisticasrutavehiculo")
        Tabla = DataSet.Tables("estadisticasrutavehiculo")
        EstadisticaGeneral.DataGridView.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With EstadisticaGeneral.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        EstadisticaGeneral.DataGridView.ClearSelection()

    End Sub

    Public Sub CargarEstadisticaHistorialRutaChofer()
        'Metodo para cargar el datagridview.
        'EstadisticaRuta

        'Conexion a la BD.
        Dim sql As String = "SELECT COUNT(*) AS 'Conteo', nombrepersonal AS 'Personal' FROM ruta, personal, estadoruta " _
                        & " WHERE ruta.personal = personal.idpersonal AND ruta.estadoruta = estadoruta.idestado " _
                        & " AND nombreestado IN ('EN RUTA CARGADO','EN RUTA VACIO') " _
                        & " GROUP BY nombrepersonal " _
                        & " ORDER BY COUNT(*) DESC "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "estadisticasrutachofer")
        Tabla = DataSet.Tables("estadisticasrutachofer")
        EstadisticaGeneral.DataGridView1.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With EstadisticaGeneral.DataGridView1
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        EstadisticaGeneral.DataGridView1.ClearSelection()

    End Sub

    Public Sub CargarEstadisticaHistorialRutaFlota()
        'Metodo para cargar el datagridview.
        'EstadisticaRuta

        'Conexion a la BD.
        Dim sql As String = "SELECT COUNT(*) AS 'Conteo', nombresubflota AS 'Flota' FROM ruta, estadoruta, vehiculo, grupo, subflota " _
                & " WHERE ruta.estadoruta = estadoruta.idestado " _
                & " AND ruta.vehiculo = vehiculo.idvehiculo " _
                & " AND vehiculo.grupo = grupo.idgrupo " _
                & " AND grupo.subflota = subflota.idsubflota " _
                & " AND nombreestado IN ('EN RUTA CARGADO','EN RUTA VACIO') " _
                & " GROUP BY nombresubflota "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "estadisticasrutaflota")
        Tabla = DataSet.Tables("estadisticasrutaflota")
        EstadisticaGeneral.DataGridView2.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With EstadisticaGeneral.DataGridView2
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        EstadisticaGeneral.DataGridView2.ClearSelection()

    End Sub

    Public Sub CargarEstadisticaHistorialInfraccionVehiculo()
        'Metodo para cargar el datagridview.
        'EstadisticaInfraccion

        'Conexion a la BD.
        Dim sql As String = "SELECT COUNT(velocidad) AS 'Conteo', vehiculo AS 'Vehiculo' FROM registroinfraccion, vehiculo " _
                        & " WHERE registroinfraccion.vehiculo = vehiculo.idvehiculo " _
                        & " GROUP BY vehiculo " _
                        & " ORDER BY Conteo DESC"

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "estadisticasinfraccionvehiculo")
        Tabla = DataSet.Tables("estadisticasinfraccionvehiculo")
        EstadisticaGeneral.DataGridView7.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With EstadisticaGeneral.DataGridView7
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        EstadisticaGeneral.DataGridView7.ClearSelection()

    End Sub

    Public Sub CargarEstadisticaHistorialInfraccionChofer()
        'Metodo para cargar el datagridview.
        'EstadisticaInfraccion

        'Conexion a la BD.
        Dim sql As String = "SELECT COUNT(velocidad) AS 'Conteo', nombrepersonal AS 'Personal' FROM registroinfraccion, personal " _
                        & " WHERE registroinfraccion.personal = personal.idpersonal " _
                        & " GROUP BY nombrepersonal " _
                        & " ORDER BY Conteo DESC "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "estadisticasinfracionchofer")
        Tabla = DataSet.Tables("estadisticasinfracionchofer")
        EstadisticaGeneral.DataGridView6.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With EstadisticaGeneral.DataGridView6
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        EstadisticaGeneral.DataGridView6.ClearSelection()

    End Sub

    Public Sub CargarEstadisticaHistorialInfraccionFlota()
        'Metodo para cargar el datagridview.
        'EstadisticaInfraccion

        'Conexion a la BD.
        Dim sql As String = "SELECT COUNT(velocidad) AS 'Conteo', nombresubflota AS 'Flota' " _
                                & " FROM registroinfraccion, vehiculo, grupo, subflota " _
                                & " WHERE registroinfraccion.vehiculo = vehiculo.idvehiculo " _
                                & " AND vehiculo.grupo = grupo.idgrupo " _
                                & " AND grupo.subflota = subflota.idsubflota " _
                                & " GROUP BY nombresubflota " _
                                & " ORDER BY nombresubflota ASC "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "estadisticasinfraccionflota")
        Tabla = DataSet.Tables("estadisticasinfraccionflota")
        EstadisticaGeneral.DataGridView8.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With EstadisticaGeneral.DataGridView8
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        EstadisticaGeneral.DataGridView8.ClearSelection()

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

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "estadisticassitiodecarga")
        Tabla = DataSet.Tables("estadisticassitiodecarga")
        EstadisticaGeneral.DataGridView4.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With EstadisticaGeneral.DataGridView4
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        EstadisticaGeneral.DataGridView4.ClearSelection()

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

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "estadisticasdestino")
        Tabla = DataSet.Tables("estadisticasdestino")
        EstadisticaGeneral.DataGridView5.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With EstadisticaGeneral.DataGridView5
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        EstadisticaGeneral.DataGridView5.ClearSelection()

    End Sub


End Module
