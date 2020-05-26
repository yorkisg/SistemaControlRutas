

Module ModuloSeguimientoLiviano


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''CARGA DEL ARBOL''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Sub CargarArbolLiviano()
        'Metodo de prueba donde generamos un arbol de un solo nivel (sin padre)

        Dim Adaptador As New MySqlDataAdapter
        Dim Datatable = New DataTable

        Adaptador = New MySqlDataAdapter("SELECT nombregrupo FROM grupo, subflota " _
                                   & " WHERE grupo.subflota = subflota.idsubflota " _
                                   & " AND tiposubflota = 'LIVIANO' " _
                                   & " ORDER BY nombregrupo ASC", Conexion)

        Adaptador.Fill(Datatable)

        With SeguimientoLiviano.Arbol

            .BeginUpdate()

            Dim i As Integer

            For i = 0 To Datatable.Rows.Count - 1

                SeguimientoLiviano.Arbol.Nodes.Add(Datatable.Rows(i)("nombregrupo").ToString)

            Next

            'Editamos la apariencia del arbol
            .Font = New Font("Calibri", 9)
            .EndUpdate()

        End With

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''METODOS PARA CARGAR DATAGRIDVIEW DE LIVIANOS'''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub CargarGridRutaLiviano()
        'Metodo que genera la carga de datos en el DataGridview1 

        Dim sql As String = "SELECT idvehiculo, nombretipo, condicionvehiculo, tasaconsumo FROM vehiculo, subflota, grupo, tipovehiculo " _
                       & " WHERE vehiculo.grupo = grupo.idgrupo " _
                       & " AND grupo.subflota = subflota.idsubflota " _
                       & " And vehiculo.tipovehiculo = tipovehiculo.idtipo " _
                       & " And nombregrupo = '" & SeguimientoLiviano.TextBox1.Text & "' " _
                       & " AND condicionvehiculo <> 'INACTIVO' " _
                       & " ORDER BY idvehiculo ASC "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "flota_vehiculo_liviano")
        Tabla = DataSet.Tables("flota_vehiculo_liviano")
        SeguimientoLiviano.DataGridView1.DataSource = DataSet.Tables("flota_vehiculo_liviano")

        'Parametros para editar apariencia del datagridview.
        With SeguimientoLiviano.DataGridView1
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 8) 'Fuente para Headers
        End With

        'Llamada al metodo para cargar imagenes
        CargarImagenesEstadoVehiculoCarga()

        SeguimientoLiviano.DataGridView1.ClearSelection()

    End Sub

    Public Sub CargarGridHistorialInfraccionLiviano()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausula LIKE y LIMIT

        Dim sql As String = "SELECT idregistroinfraccion, vehiculo, nombrepersonal, velocidad, estadovehiculo, fecha, hora " _
                       & " FROM registroinfraccion, personal " _
                       & " WHERE registroinfraccion.personal = personal.idpersonal " _
                       & " AND vehiculo = '" & SeguimientoLiviano.TextBox2.Text & "' " _
                       & " ORDER BY idregistroinfraccion DESC" _
                       & " LIMIT 30 "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview
        Adaptador.Fill(DataSet, "ruta_vehiculos2")
        Tabla = DataSet.Tables("ruta_vehiculos2")
        SeguimientoLiviano.DataGridView2.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With SeguimientoLiviano.DataGridView2
            .DefaultCellStyle.Font = New Font("Segoe UI", 7) 'Fuente para celdas
            .Font = New Font("Segoe UI", 8) 'Fuente para Headers
        End With

        'Llamada al metodo para cargar imagenes
        'CargarImagenes()

        SeguimientoLiviano.DataGridView2.ClearSelection()

    End Sub

    Public Sub CargarGridHistorialIncidenciaLiviano()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausula LIKE y LIMIT

        Dim sql As String = "SELECT idregistroincidencia, vehiculo, nombrepersonal, descripcion, clasificacion, fecha, hora " _
                       & " FROM registroincidencia, personal " _
                       & " WHERE registroincidencia.personal = personal.idpersonal " _
                       & " AND vehiculo = '" & SeguimientoLiviano.TextBox3.Text & "' " _
                       & " ORDER BY idregistroincidencia DESC " _
                       & " LIMIT 30 "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview
        Adaptador.Fill(DataSet, "ruta_vehiculos4")
        Tabla = DataSet.Tables("ruta_vehiculos4")
        SeguimientoLiviano.DataGridView3.DataSource = DataSet.Tables("ruta_vehiculos4")

        'Parametros para editar apariencia del datagridview.
        With SeguimientoLiviano.DataGridView3
            .DefaultCellStyle.Font = New Font("Segoe UI", 7) 'Fuente para celdas
            .Font = New Font("Segoe UI", 8) 'Fuente para Headers
        End With

        'Llamada al metodo para cargar imagenes
        'CargarImagenes()

        SeguimientoLiviano.DataGridView3.ClearSelection()

    End Sub

    Public Sub CargarGridHistorialConsumoLiviano()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausula LIKE y LIMIT

        Dim sql As String = "SELECT idregistroconsumo, vehiculo, nombrepersonal, cantidadconsumida, (kilometrajeactual-kilometrajeanterior) AS 'distancia', consumototal, fecha, hora " _
                       & " FROM registroconsumo, personal " _
                       & " WHERE registroconsumo.personal = personal.idpersonal " _
                       & " AND vehiculo = '" & SeguimientoLiviano.TextBox21.Text & "' " _
                       & " ORDER BY idregistroconsumo DESC " _
                       & " LIMIT 30 "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview
        Adaptador.Fill(DataSet, "consumos")
        Tabla = DataSet.Tables("consumos")
        SeguimientoLiviano.DataGridView4.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With SeguimientoLiviano.DataGridView4
            .DefaultCellStyle.Font = New Font("Segoe UI", 7) 'Fuente para celdas
            .Font = New Font("Segoe UI", 8) 'Fuente para Headers
        End With

        'Llamada al metodo para cargar imagenes
        'CargarImagenes()

        SeguimientoLiviano.DataGridView4.ClearSelection()

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''METODOS PARA OBTENER DATOS''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub ObtenerVehiculoLiviano()
        'Este metodo permite obtener los estados de los vehiculos para luego ser modificados
        'Se despliega el formulario MaestroVehiculo

        Dim Adaptador As New MySqlDataAdapter
        Dim Tabla As New DataTable

        Adaptador = New MySqlDataAdapter("SELECT nombregrupo, nombretipo, clasificacionvehiculo, condicionvehiculo, estadoactual " _
                                          & " FROM vehiculo, grupo, tipovehiculo " _
                                          & " WHERE vehiculo.grupo = grupo.idgrupo " _
                                          & " AND vehiculo.tipovehiculo = tipovehiculo.idtipo " _
                                          & " AND idvehiculo = '" & SeguimientoLiviano.TextBox2.Text & "' ", Conexion)

        Adaptador.Fill(Tabla)

        For Each row As DataRow In Tabla.Rows

            MaestroVehiculo.ComboGrupo.Text = row("nombregrupo").ToString
            MaestroVehiculo.ComboTipo.Text = row("nombretipo").ToString
            MaestroVehiculo.ComboEstado.Text = row("estadoactual").ToString
            MaestroVehiculo.ComboCondicion.Text = row("condicionvehiculo").ToString
            MaestroVehiculo.ComboClasificacion.Text = row("clasificacionvehiculo").ToString

        Next

    End Sub

    Public Sub ObtenerPersonalSeguimientoLivianoInfraccion()
        'Este metodo permite obtener el ID del chofer

        Dim Adaptador As New MySqlDataAdapter
        Dim Tabla As New DataTable

        Adaptador = New MySqlDataAdapter("SELECT idpersonal FROM personal WHERE nombrepersonal = '" & SeguimientoLiviano.TextBox16.Text & "' ", Conexion)

        Adaptador.Fill(Tabla)

        For Each row As DataRow In Tabla.Rows

            SeguimientoLiviano.TextBox6.Text = row("idpersonal").ToString

        Next

    End Sub

    Public Sub ObtenerPersonalSeguimientoLivianoIncidencia()
        'Este metodo permite obtener el ID del chofer

        Dim Adaptador As New MySqlDataAdapter
        Dim Tabla As New DataTable

        Adaptador = New MySqlDataAdapter("SELECT idpersonal FROM personal WHERE nombrepersonal = '" & SeguimientoLiviano.TextBox17.Text & "' ", Conexion)

        Adaptador.Fill(Tabla)

        For Each row As DataRow In Tabla.Rows

            SeguimientoLiviano.TextBox18.Text = row("idpersonal").ToString

        Next

    End Sub

    Public Sub ObtenerPersonalSeguimientoLivianoConsumo()
        'Este metodo permite obtener el ID del chofer

        Dim Adaptador As New MySqlDataAdapter
        Dim Tabla As New DataTable

        Adaptador = New MySqlDataAdapter("SELECT idpersonal FROM personal WHERE nombrepersonal = '" & SeguimientoLiviano.TextBox24.Text & "' ", Conexion)

        Adaptador.Fill(Tabla)

        For Each row As DataRow In Tabla.Rows

            SeguimientoLiviano.TextBox26.Text = row("idpersonal").ToString

        Next

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''METODOS DE APOYO PARA LAS RUTAS E INFRACCIONES''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub SerieInfraccionRutaLiviano()
        'Metodo que permite generar una serie correlativa de numeros enteros. 
        'Usado para generar automaticamente el ID.

        'Se obtiene el ultimo ID.
        Dim Command As New MySqlCommand("SELECT MAX(idregistroinfraccion) FROM registroinfraccion", Conexion)
        Dim numero As Integer

        'El ID obtenido de la BD se incrementa.
        numero = Command.ExecuteScalar
        numero = numero + 1

        'Se da formato al ID obtenido de la BD.
        SeguimientoLiviano.TextBox9.Text = Format(numero, ("000000000"))

    End Sub

    Public Sub SerieIncidenciaRutaLiviano()
        'Metodo que permite generar una serie correlativa de numeros enteros. 
        'Usado para generar automaticamente el ID.

        'Se obtiene el ultimo ID.
        Dim Command As New MySqlCommand("SELECT MAX(idregistroincidencia) FROM registroincidencia", Conexion)
        Dim numero As Integer

        'El ID obtenido de la BD se incrementa.
        numero = Command.ExecuteScalar
        numero = numero + 1

        'Se da formato al ID obtenido de la BD.
        SeguimientoLiviano.TextBox12.Text = Format(numero, ("000000000"))

    End Sub

    Public Sub SerieConsumoRutaLiviano()
        'Metodo que permite generar una serie correlativa de numeros enteros. 
        'Usado para generar automaticamente el ID.

        'Se obtiene el ultimo ID.
        Dim Command As New MySqlCommand("SELECT MAX(idregistroconsumo) FROM registroconsumo", Conexion)
        Dim numero As Integer

        'El ID obtenido de la BD se incrementa.
        numero = Command.ExecuteScalar
        numero = numero + 1

        'Se da formato al ID obtenido de la BD.
        SeguimientoLiviano.TextBox23.Text = Format(numero, ("000000000"))

    End Sub


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''FUNCIONES DE LIMPIEZA'''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Function ValidarComponentesInfraccionLiviano() As Boolean
        'Metodo que permite validar el ingreso de texto en los textbox

        Dim Validar As Boolean = True

        'Limpia todos los mensajes de error mostrados en la interfaz de usuario
        SeguimientoLiviano.ErrorProvider1.Clear()

        'Valida que el textbox no este nulo o vacio
        If String.IsNullOrEmpty(SeguimientoLiviano.TextBox2.Text) Then
            SeguimientoLiviano.ErrorProvider1.SetError(SeguimientoLiviano.TextBox2, "No puede dejar campos en blanco.")
            Validar = False
        End If

        'Valida que el textbox no este nulo o vacio
        If String.IsNullOrEmpty(SeguimientoLiviano.TextBox16.Text) Then
            SeguimientoLiviano.ErrorProvider1.SetError(SeguimientoLiviano.Label2, "No puede dejar campos en blanco.")
            Validar = False
        End If

        'Valida que el textbox no este nulo o vacio
        If String.IsNullOrEmpty(SeguimientoLiviano.TextBox4.Text) Then
            SeguimientoLiviano.ErrorProvider1.SetError(SeguimientoLiviano.TextBox4, "No puede dejar campos en blanco.")
            Validar = False
        End If

        Return Validar

    End Function

    Public Function ValidarComponentesIncidenciaLiviano() As Boolean
        'Metodo que permite validar el ingreso de texto en los textbox

        Dim Validar As Boolean = True

        'Limpia todos los mensajes de error mostrados en la interfaz de usuario
        SeguimientoLiviano.ErrorProvider2.Clear()

        'Valida que el textbox no este nulo o vacio
        If String.IsNullOrEmpty(SeguimientoLiviano.TextBox3.Text) Then
            SeguimientoLiviano.ErrorProvider2.SetError(SeguimientoLiviano.TextBox3, "No puede dejar campos en blanco.")
            Validar = False
        End If

        'Valida que el textbox no este nulo o vacio
        If String.IsNullOrEmpty(SeguimientoLiviano.TextBox7.Text) Then
            SeguimientoLiviano.ErrorProvider2.SetError(SeguimientoLiviano.TextBox7, "No puede dejar campos en blanco.")
            Validar = False
        End If

        'Valida que el textbox no este nulo o vacio
        If String.IsNullOrEmpty(SeguimientoLiviano.TextBox17.Text) Then
            SeguimientoLiviano.ErrorProvider2.SetError(SeguimientoLiviano.Label3, "No puede dejar campos en blanco.")
            Validar = False
        End If

        Return Validar

    End Function

    Public Function ValidarComponentesConsumoLiviano() As Boolean
        'Metodo que permite validar el ingreso de texto en los textbox

        Dim Validar As Boolean = True

        'Limpia todos los mensajes de error mostrados en la interfaz de usuario
        SeguimientoLiviano.ErrorProvider2.Clear()

        'Valida que el textbox no este nulo o vacio
        If String.IsNullOrEmpty(SeguimientoLiviano.TextBox21.Text) Then
            SeguimientoLiviano.ErrorProvider2.SetError(SeguimientoLiviano.TextBox21, "No puede dejar campos en blanco.")
            Validar = False
        End If

        'Valida que el textbox no este nulo o vacio
        If String.IsNullOrEmpty(SeguimientoLiviano.TextBox22.Text) Then
            SeguimientoLiviano.ErrorProvider2.SetError(SeguimientoLiviano.TextBox22, "No puede dejar campos en blanco.")
            Validar = False
        End If

        'Valida que el textbox no este nulo o vacio
        If String.IsNullOrEmpty(SeguimientoLiviano.TextBox24.Text) Then
            SeguimientoLiviano.ErrorProvider2.SetError(SeguimientoLiviano.Label7, "No puede dejar campos en blanco.")
            Validar = False
        End If

        Return Validar

    End Function

    Public Sub LimpiarComponentesInfraccionLiviano()
        'Metodo que permite borrar el contenido de los textbox

        SeguimientoLiviano.TextBox4.Text = ""
        SeguimientoLiviano.TextBox16.Text = ""
        SeguimientoLiviano.TextBox6.Text = ""

    End Sub

    Public Sub LimpiarComponentesIncidenciaLiviano()
        'Metodo que permite borrar el contenido de los textbox

        SeguimientoLiviano.TextBox7.Text = ""
        SeguimientoLiviano.TextBox17.Text = ""
        SeguimientoLiviano.TextBox18.Text = ""

    End Sub

    Public Sub LimpiarComponentesConsumoLiviano()
        'Metodo que permite borrar el contenido de los textbox

        SeguimientoLiviano.TextBox24.Text = ""
        SeguimientoLiviano.TextBox26.Text = ""
        SeguimientoLiviano.TextBox22.Text = ""

    End Sub

    Public Sub LimpiarArbolSeguimientoLiviano()
        'Metodo que permite limpiar el arbol cada ves que se instancie la ventana SeguimientoLiviano

        'Deshabilitamos visualmente el arbol
        SeguimientoLiviano.Arbol.Visible = False
        'Limpiamos los nodos del arbol
        SeguimientoLiviano.Arbol.Nodes.Clear()
        'Pintamos el arbol nuevamente
        SeguimientoLiviano.Arbol.Visible = True

    End Sub

    Public Sub EliminarItemLiviano()
        'Metodo que permite eliminar la ruta seleccionada

        Dim Mensaje As DialogResult

        Mensaje = MessageBox.Show("Desea eliminar este Item?", "Aviso.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'Si la respuesta es "Si"
        If Mensaje = DialogResult.Yes Then

            'Se elimina el registro
            Dim db As New MySqlCommand("DELETE FROM registroinfraccion WHERE idregistroinfraccion = '" & SeguimientoLiviano.TextBox19.Text & "' ", Conexion)
            db.ExecuteNonQuery()

            'Se carga el historial actualizado
            CargarGridHistorialInfraccionLiviano()

            'Se carga el listado actualizado
            'CargarGridRutaCarga()

            MsgBox("Item eliminado con Exito.", MsgBoxStyle.Information, "Exito.")

        End If

        'Si la seleccion es "No" Se elimina la seleccion de la fila.
        SeguimientoLiviano.DataGridView2.ClearSelection()

    End Sub


End Module
