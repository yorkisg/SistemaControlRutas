
Module ModuloSeguimientoTaller

    Public FilaTaller As Integer
    Public ColumnaTaller As Integer

    Public Abierto As Image
    Public Cerrado As Image
    Public SinRevision As Image
    Public PendientePorRevision As Image

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''CARGA DE ARBOL''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub CargarComboArbol()
        'Metodo que permite cargar el Combobox desde la BD.

        Dim Tabla As New DataTable
        Dim Adaptador As New MySqlDataAdapter

        Adaptador = New MySqlDataAdapter("SELECT idsubflota, nombresubflota FROM subflota " _
                                & " WHERE nombresubflota IN ('CONCHA DE ARROZ','GRANEL','HUEVOS','LECHE CRUDA','AMBULANCIAS','MERCABAR','TRANSPORTES','EMBUTIDOS') " _
                                & " ORDER BY nombresubflota ASC", Conexion)

        Adaptador.Fill(Tabla)

        SeguimientoTaller.ComboArbol.ComboBox.DataSource = Tabla
        SeguimientoTaller.ComboArbol.ComboBox.DisplayMember = "nombresubflota"
        SeguimientoTaller.ComboArbol.ComboBox.ValueMember = "idsubflota"

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''CARGA DE DATOS''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub CargarGridSeguimientoTaller()
        'Metodo que genera la carga de datos en el DataGridview1 

        Dim sql As String = "SELECT idvehiculo, nombretipo, estadorevision " _
                       & " FROM vehiculo, subflota, flota, tipovehiculo " _
                       & " WHERE vehiculo.subflota = subflota.idsubflota " _
                       & " AND subflota.flota = flota.idflota " _
                       & " AND vehiculo.tipovehiculo = tipovehiculo.idtipo " _
                       & " AND nombresubflota = '" & SeguimientoTaller.TextBox2.Text & "' " _
                       & " AND estadoactual <> 'ROBADO / EXTRAVIADO' " _
                       & " ORDER BY idvehiculo ASC "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "seguimientotaller")
        Tabla = DataSet.Tables("seguimientotaller")
        SeguimientoTaller.DataGridView1.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With SeguimientoTaller.DataGridView1
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 8) 'Fuente para Headers
        End With

        'Cargamos las imagenes de los estados
        CargarImagenesEstadoRevision()

        'Eliminamos la seleccion de cualquier fila
        'SeguimientoTaller.DataGridView1.ClearSelection()

    End Sub

    Public Sub CargarGridHistorialTaller()
        'Metodo que genera la carga de datos en el DataGridview1 

        Dim sql As String = "SELECT idregistrotaller, vehiculo, fechaingreso, fechasalida, area, nombrefalla, estado " _
                         & " FROM registrotaller, falla " _
                         & " WHERE registrotaller.falla = falla.idfalla " _
                         & " AND vehiculo = '" & SeguimientoTaller.TextBox1.Text & "' " _
                         & " ORDER BY idregistrotaller DESC "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "seguimientotaller2")
        Tabla = DataSet.Tables("seguimientotaller2")
        SeguimientoTaller.DataGridView2.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With SeguimientoTaller.DataGridView2
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 8) 'Fuente para Headers
        End With

        CargarImagenesEstadoReporte()

        SeguimientoTaller.DataGridView2.ClearSelection()

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''OTROS METODOS'''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub ActualizarVehiculo()
        'Metodo que permite actualizar el estado del vehiculo una ves generado un reporte de taller

        Dim db As New MySqlCommand("UPDATE vehiculo SET estadorevision = 'PENDIENTE POR REVISIÓN' WHERE idvehiculo = '" & RegistrarReporteTaller.TextBox3.Text & "' ", Conexion)
        db.ExecuteNonQuery()

    End Sub

    Public Sub ActualizarVehiculo2()
        'Metodo que permite actualizar el estado del vehiculo una ves cerrado un reporte de taller

        'Si el reporte esta abierto, entonces se updatea el estado del vehiculo
        If SeguimientoTaller.TextBox4.Text = "ABIERTO" Then

            Dim db As New MySqlCommand("UPDATE vehiculo SET estadorevision = 'OPERATIVO' WHERE idvehiculo = '" & SeguimientoTaller.TextBox1.Text & "' ", Conexion)
            db.ExecuteNonQuery()

        End If

    End Sub

    Public Sub CargarImagenesEstadoReporte()
        'En este metodo especificamos cuales son las imagenes que se cargaran en el 
        'CellFormatting del DataGridView1

        'Cargamos las imágenes de la columna de estados de reportes
        'Abierto = Image.FromFile(Application.StartupPath & "\Recursos\Abierto1.png")
        'Cerrado = Image.FromFile(Application.StartupPath & "\Recursos\Cerrado.png")

        Abierto = My.Resources.Abierto1
        Cerrado = My.Resources.Cerrado

    End Sub

    Public Sub CargarImagenesEstadoRevision()
        'En este metodo especificamos cuales son las imagenes que se cargaran en el 
        'CellFormatting del DataGridView1

        'Cargamos las imágenes de la columna de estados de reportes
        'SinRevision = Image.FromFile(Application.StartupPath & "\Recursos\SinRevision.png")
        'PendientePorRevision = Image.FromFile(Application.StartupPath & "\Recursos\PendientePorRevision.png")

        SinRevision = My.Resources.SinRevision
        PendientePorRevision = My.Resources.PendientePorRevision

    End Sub

    Public Sub SerieTaller()
        'Metodo que permite generar una serie correlativa de numeros enteros. 
        'Usado para generar automaticamente el ID.

        'Se obtiene el ultimo ID del chofer.
        Dim Command As New MySqlCommand("SELECT MAX(idregistrotaller) FROM registrotaller", Conexion)
        Dim numero As Integer

        'El ID obtenido de la BD se incrementa.
        numero = Command.ExecuteScalar
        numero = numero + 1

        'Se da formato al ID obtenido de la BD.
        RegistrarReporteTaller.TextBox1.Text = Format(numero, "000000000")

    End Sub

    Public Sub CargarGridSeguimientoActual()
        'Metodo que genera la carga de datos en el DataGridview1 

        Dim sql As String = "SELECT idregistrotaller, vehiculo, nombresubflota, fechaingreso, fechasalida, area, nombrefalla, estado " _
                            & " FROM registrotaller, vehiculo, subflota, falla " _
                            & " WHERE registrotaller.vehiculo = vehiculo.idvehiculo  " _
                            & " AND registrotaller.falla = falla.idfalla " _
                            & " AND vehiculo.subflota = subflota.idsubflota " _
                            & " AND estado = 'ABIERTO' " _
                            & " ORDER BY idregistrotaller DESC "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "seguimientotaller3")
        Tabla = DataSet.Tables("seguimientotaller3")
        SeguimientoTaller.DataGridView3.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With SeguimientoTaller.DataGridView3
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 8) 'Fuente para Headers
        End With

        CargarImagenesEstadoReporte()

        SeguimientoTaller.DataGridView3.ClearSelection()

    End Sub

    Public Sub ObtenerFalla()
        'Este metodo permite obtener el ID de la falla

        Dim Adaptador As New MySqlDataAdapter
        Dim Tabla As New DataTable

        Adaptador = New MySqlDataAdapter("SELECT idfalla FROM falla WHERE nombrefalla = '" & RegistrarReporteTaller.TextBox4.Text & "' ", Conexion)
        Adaptador.Fill(Tabla)

        For Each row As DataRow In Tabla.Rows
            RegistrarReporteTaller.TextBox2.Text = row("idfalla").ToString
        Next

    End Sub


End Module
