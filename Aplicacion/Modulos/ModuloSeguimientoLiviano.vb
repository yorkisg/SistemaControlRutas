

Module ModuloSeguimientoLiviano


    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''CARGA DEL ARBOL''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub CargarArbolLiviano()
        'Metodo de prueba donde generamos un arbol de un solo nivel (sin padre)

        Dim Adaptador As New MySqlDataAdapter
        Dim Datatable = New DataTable

        Adaptador = New MySqlDataAdapter("SELECT nombresubflota FROM subflota " _
                                   & " WHERE tiposubflota = 'LIVIANO' " _
                                   & " ORDER BY nombresubflota ASC", cnn)

        Adaptador.Fill(Datatable)

        With SeguimientoLiviano.Arbol

            .BeginUpdate()

            Dim i As Integer

            For i = 0 To Datatable.Rows.Count - 1

                SeguimientoLiviano.Arbol.Nodes.Add(Datatable.Rows(i)("nombresubflota").ToString)

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

        Dim sql As String = "SELECT idvehiculo, nombretipo, condicionvehiculo FROM vehiculo, subflota, tipovehiculo " _
                       & " WHERE vehiculo.subflota = subflota.idsubflota " _
                       & " AND vehiculo.tipovehiculo = tipovehiculo.idtipo " _
                       & " AND nombresubflota = '" & SeguimientoLiviano.TextBox1.Text & "' " _
                       & " AND condicionvehiculo <> 'INACTIVO' " _
                       & " ORDER BY idvehiculo ASC "

        Dim connection As New MySqlConnection(connectionString)

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

        Dim sql As String = "SELECT idregistroinfraccion, vehiculo, nombrechofer, velocidad, estadovehiculo, fecha, hora " _
                       & " FROM registroinfraccion, chofer " _
                       & " WHERE registroinfraccion.chofer = chofer.idchofer " _
                       & " AND vehiculo = '" & SeguimientoLiviano.TextBox2.Text & "' " _
                       & " ORDER BY idregistroinfraccion DESC" _
                       & " LIMIT 30 "

        Dim connection As New MySqlConnection(connectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview
        Adaptador.Fill(DataSet, "ruta_vehiculos2")
        Tabla = DataSet.Tables("ruta_vehiculos2")
        SeguimientoLiviano.DataGridView2.DataSource = DataSet.Tables("ruta_vehiculos2")

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

        Dim sql As String = "SELECT idregistroincidencia, vehiculo, nombrechofer, descripcion, clasificacion, fecha, hora " _
                       & " FROM registroincidencia, chofer " _
                       & " WHERE registroincidencia.chofer = chofer.idchofer " _
                       & " AND vehiculo = '" & SeguimientoLiviano.TextBox14.Text & "' " _
                       & " ORDER BY idregistroincidencia DESC " _
                       & " LIMIT 30 "

        Dim connection As New MySqlConnection(connectionString)

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

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''METODOS PARA OBTENER DATOS''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub ObtenerVehiculoLiviano()
        'Este metodo permite obtener los estados de los vehiculos para luego ser modificados
        'Se despliega el formulario MaestroVehiculo

        Dim Adaptador2 As New MySqlDataAdapter
        Dim Tabla2 As New DataTable

        Adaptador2 = New MySqlDataAdapter("SELECT nombresubflota, nombretipo, clasificacionvehiculo, condicionvehiculo, estadoactual " _
                                          & " FROM vehiculo, subflota, tipovehiculo " _
                                          & " WHERE vehiculo.subflota = subflota.idsubflota " _
                                          & " AND vehiculo.tipovehiculo = tipovehiculo.idtipo " _
                                          & " AND idvehiculo = '" & SeguimientoLiviano.TextBox2.Text & "' ", cnn)

        Adaptador2.Fill(Tabla2)

        For Each row As DataRow In Tabla2.Rows

            MaestroVehiculo.ComboFlota.Text = row("nombresubflota").ToString
            MaestroVehiculo.ComboTipo.Text = row("nombretipo").ToString
            MaestroVehiculo.ComboEstado.Text = row("estadoactual").ToString
            MaestroVehiculo.ComboCondicion.Text = row("condicionvehiculo").ToString
            MaestroVehiculo.ComboClasificacion.Text = row("clasificacionvehiculo").ToString

        Next

    End Sub

    Public Sub ObtenerChoferSeguimientoLivianoInfraccion()
        'Este metodo permite obtener el ID del chofer

        Dim Adaptador As New MySqlDataAdapter
        Dim Tabla As New DataTable

        Adaptador = New MySqlDataAdapter("SELECT idchofer FROM chofer WHERE nombrechofer = '" & SeguimientoLiviano.TextBox16.Text & "' ", cnn)

        Adaptador.Fill(Tabla)

        For Each row As DataRow In Tabla.Rows

            SeguimientoLiviano.TextBox6.Text = row("idchofer").ToString

        Next

    End Sub

    Public Sub ObtenerChoferSeguimientoLivianoIncidencia()
        'Este metodo permite obtener el ID del chofer

        Dim Adaptador As New MySqlDataAdapter
        Dim Tabla As New DataTable

        Adaptador = New MySqlDataAdapter("SELECT idchofer FROM chofer WHERE nombrechofer = '" & SeguimientoLiviano.TextBox17.Text & "' ", cnn)

        Adaptador.Fill(Tabla)

        For Each row As DataRow In Tabla.Rows

            SeguimientoLiviano.TextBox18.Text = row("idchofer").ToString

        Next

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''METODOS DE APOYO PARA LAS RUTAS E INFRACCIONES''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub SerieInfraccionRutaLiviano()
        'Metodo que permite generar una serie correlativa de numeros enteros. 
        'Usado para generar automaticamente el ID.

        'Se obtiene el ultimo ID.
        Dim Command As New MySqlCommand("SELECT MAX(idregistroinfraccion) FROM registroinfraccion", cnn)
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
        Dim Command As New MySqlCommand("SELECT MAX(idregistroincidencia) FROM registroincidencia", cnn)
        Dim numero As Integer

        'El ID obtenido de la BD se incrementa.
        numero = Command.ExecuteScalar
        numero = numero + 1

        'Se da formato al ID obtenido de la BD.
        SeguimientoLiviano.TextBox12.Text = Format(numero, ("000000000"))

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
            SeguimientoLiviano.ErrorProvider1.SetError(SeguimientoLiviano.TextBox16, "No puede dejar campos en blanco.")
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
            Dim db As New MySqlCommand("DELETE FROM registroinfraccion WHERE idregistroinfraccion = '" & SeguimientoLiviano.TextBox19.Text & "' ", cnn)
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
