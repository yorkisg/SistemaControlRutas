
Module ModuloListado

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''CARGA DE LISTADOS ''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub CargarGridListadoPersonal()
        'Metodo para cargar el datagridview.

        'Conexion a la BD.
        Dim sql As String = "SELECT idpersonal, nombrepersonal, tipopersonal, if(telefono1 <> 'N/A', (concat(LEFT(telefono1,4),' - ', RIGHT(telefono1,7))), 'N/A') AS 'Telefono1', " _
            & " if(telefono2 <> 'N/A', (concat(LEFT(telefono2,4),' - ', RIGHT(telefono2,7))), 'N/A') AS 'Telefono2', estadopersonal FROM personal " _
            & " WHERE estadopersonal = '" & ListadoPersonal.TextBox1.Text & "' " _
            & " AND tipopersonal = '" & ListadoPersonal.TextBox2.Text & "' " _
            & " ORDER BY nombrepersonal ASC"

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "personal")
        Tabla = DataSet.Tables("personal")
        ListadoPersonal.DataGridView.DataSource = DataSet.Tables("personal")

        'Parametros para editar apariencia del datagridview.
        With ListadoPersonal.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        'Mostramos la cantidad de registros encontrados
        ListadoPersonal.Contador.Text = ListadoPersonal.DataGridView.RowCount

    End Sub

    Public Sub CargarGridListadoDestino()
        'Metodo para cargar el datagridview.

        'Conexion a la BD.
        Dim sql As String = "SELECT iddestino, nombredestino FROM destino" _
                            & " ORDER BY nombredestino ASC"

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "sitiocarga2")
        Tabla = DataSet.Tables("sitiocarga2")
        ListadoDestino.DataGridView.DataSource = DataSet.Tables("sitiocarga2")

        'Parametros para editar apariencia del datagridview.
        With ListadoDestino.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        'Mostramos la cantidad de registros encontrados
        ListadoDestino.Contador.Text = ListadoDestino.DataGridView.RowCount

    End Sub

    Public Sub CargarGridListadoEstado()
        'Metodo para cargar el datagridview.

        'Conexion a la BD.
        Dim sql As String = "SELECT idestado, nombreestado FROM estadoruta ORDER BY nombreestado ASC"
        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "estados")
        Tabla = DataSet.Tables("estados")
        ListadoEstado.DataGridView.DataSource = DataSet.Tables("estados")

        With ListadoEstado.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        'Mostramos la cantidad de registros encontrados
        ListadoEstado.Contador.Text = ListadoEstado.DataGridView.RowCount

    End Sub

    Public Sub CargarGridListadoFlota()
        'Metodo para cargar el datagridview.

        'Conexion a la BD.
        Dim sql As String = "SELECT idsubflota, nombresubflota, nombreflota, tiposubflota " _
                            & " FROM subflota, flota " _
                            & " WHERE subflota.flota = flota.idflota " _
                            & " ORDER BY nombresubflota ASC"

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "flotas")
        Tabla = DataSet.Tables("flotas")
        ListadoFlota.DataGridView.DataSource = DataSet.Tables("flotas")

        'Parametros para editar apariencia del datagridview.
        With ListadoFlota.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        'Mostramos la cantidad de registros encontrados
        ListadoFlota.Contador.Text = ListadoFlota.DataGridView.RowCount

    End Sub

    Public Sub CargarGridListadoProducto()
        'Metodo para cargar el datagridview.

        'Conexion a la BD.
        Dim sql As String = "SELECT idproducto, nombreproducto FROM producto" _
                            & " ORDER BY nombreproducto ASC "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "listasproductos")
        Tabla = DataSet.Tables("listasproductos")
        ListadoProducto.DataGridView.DataSource = DataSet.Tables("listasproductos")

        'Parametros para editar apariencia del datagridview.
        With ListadoProducto.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        'Mostramos la cantidad de registros encontrados
        ListadoProducto.Contador.Text = ListadoProducto.DataGridView.RowCount

    End Sub

    Public Sub CargarGridListadoSitioCarga()
        'Metodo para cargar el datagridview.

        'Conexion a la BD.
        Dim sql As String = "SELECT idsitiocarga, nombresitiocarga FROM sitiocarga" _
                            & " ORDER BY nombresitiocarga ASC "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "sitiocarga")
        Tabla = DataSet.Tables("sitiocarga")
        Listadositiocarga.DataGridView.DataSource = DataSet.Tables("sitiocarga")

        'Parametros para editar apariencia del datagridview.
        With Listadositiocarga.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        'Mostramos la cantidad de registros encontrados
        Listadositiocarga.Contador.Text = Listadositiocarga.DataGridView.RowCount

    End Sub

    Public Sub CargarGridListadoVehiculo()
        'Metodo para cargar el datagridview.

        'Conexion a la BD.
        Dim sql As String = " SELECT idvehiculo, nombretipo, nombregrupo, clasificacionvehiculo, estadoactual, condicionvehiculo " _
                            & " FROM vehiculo, tipovehiculo, subflota, grupo " _
                            & " WHERE vehiculo.tipovehiculo = tipovehiculo.idtipo " _
                            & " AND vehiculo.grupo = grupo.idgrupo " _
                            & " AND grupo.subflota = subflota.idsubflota " _
                            & " ORDER BY idvehiculo ASC "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "vehiculo")
        Tabla = DataSet.Tables("vehiculo")
        ListadoVehiculo.DataGridView.DataSource = DataSet.Tables("vehiculo")

        'Parametros para editar apariencia del datagridview.
        With ListadoVehiculo.DataGridView
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 9) 'Fuente para Headers
        End With

        'Mostramos la cantidad de registros encontrados
        ListadoVehiculo.Contador.Text = ListadoVehiculo.DataGridView.RowCount

        CargarImagenesEstadoVehiculoCarga()

    End Sub


End Module
