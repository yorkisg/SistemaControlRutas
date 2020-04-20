

Module ModuloSeguimientoCarga

    'Variables globales.
    Public EnRutaVacio As Image
    Public EnRutaCargado As Image
    Public DeRegresoConRetorno As Image
    Public DeRegresoCargado As Image
    Public DeRegresoVacio As Image
    Public OrganizacionElTunal As Image
    Public PernoctaAutorizada As Image
    Public EnProcesoDeCarga As Image
    Public EnProcesoDeDescarga As Image
    Public CargadoEsperandoPorSalir As Image
    Public CargadoEsperandoDocumentos As Image
    Public EsperandoAutorizacionParaSalir As Image
    Public Detenido As Image
    Public Accidentado As Image
    Public ParadaIrregular As Image
    Public EnTaller As Image
    Public EsperandoPorSalir As Image
    Public EnElClienteEnElProveedor As Image
    Public RealizandoMovimientos As Image
    Public RutaCancelada As Image

    Public Operativo As Image
    Public EnReparacion As Image
    Public SinReporte As Image
    Public Robado As Image

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''CARGA DE ARBOLES''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub CargarArbolCarga()
        'Metodo donde generamos el arbol de opciones de acuerdo a las flotas, subflotas y grupos registrados en BD

        'Adaptadores
        Dim Padres As New MySqlDataAdapter("SELECT idsubflota, nombresubflota " _
                                        & " FROM subflota " _
                                        & " WHERE tiposubflota = 'CARGA' " _
                                        & " ORDER BY nombresubflota ASC", Conexion)

        Dim Hijos As New MySqlDataAdapter(" SELECT idgrupo, nombregrupo, subflota " _
                                        & " FROM grupo " _
                                        & " ORDER BY idgrupo ASC", Conexion)
        Dim Dataset As New DataSet

        'Llenar el DataSet
        Padres.Fill(Dataset, "Padres")
        Hijos.Fill(Dataset, "Hijos")

        'Creamos una relación a través del campo idflota (flota) común en ambos objetos DataTable.
        Dim ColumnaPadre As DataColumn = Dataset.Tables("Padres").Columns("idsubflota")

        Dim ColumnaHijo As DataColumn = Dataset.Tables("Hijos").Columns("subflota") 'clave foranea en tabla hijos (subflota)

        'se cambio a false por un error con los constrain
        Dim Relacion As New DataRelation("Padres_Hijos", ColumnaPadre, ColumnaHijo, False) '*********

        'Añadimos la relación al objeto DataSet.
        Dataset.Relations.Add(Relacion)

        With SeguimientoCarga.Arbol

            'Para que no se repinte el control TreeView hasta que se hayan creado los nodos.
            .BeginUpdate()

            'Limpiamos el control TreeView.
            .Nodes.Clear()

            'Añadimos un objeto TreeNode ra¡z para cada objeto Padre existente en el objeto DataTable llamado Padres.
            For Each padre As DataRow In Dataset.Tables("Padres").Rows

                'Creamos el nodo padre.
                Dim NodoPadre As New TreeNode(padre.Item("nombresubflota").ToString)

                'Lo añadimos a la colección Nodes del control TreeView.
                SeguimientoCarga.Arbol.Nodes.Add(NodoPadre)

                'Añadimos un objeto TreeNode hijo por cada objeto Hijo existente en el objeto Padre actual.
                For Each hijo In padre.GetChildRows("Padres_Hijos")

                    'Creamos el nodo hijo
                    Dim NodoHijo As New TreeNode(hijo.Item("nombregrupo").ToString)

                    'Lo añadimos al nodo padre
                    NodoPadre.Nodes.Add(NodoHijo)

                Next

            Next

            'Editamos la apariencia del arbol
            .Font = New Font("Calibri", 9)
            .ExpandAll()
            .EndUpdate()

        End With

    End Sub

    Public Sub CargarArbolCarga2()
        'Metodo donde generamos un arbol proveniente de dos tablas, padre e hijo (Subflota y Grupo)

        Dim Adaptador As New MySqlDataAdapter
        Dim Datatable = New DataTable

        Adaptador = New MySqlDataAdapter("SELECT nombresubflota FROM subflota " _
                                   & " WHERE tiposubflota = 'CARGA' " _
                                   & " ORDER BY nombresubflota ASC", Conexion)

        Adaptador.Fill(Datatable)

        SeguimientoCarga.Arbol.Nodes.Add("Nodo raiz")

        With SeguimientoCarga.Arbol

            .BeginUpdate()

            Dim i As Integer

            For i = 0 To Datatable.Rows.Count - 1

                SeguimientoCarga.Arbol.Nodes.Add(Datatable.Rows(i)("nombresubflota").ToString)

            Next

            'Editamos la apariencia del arbol
            .Font = New Font("Calibri", 9)
            .EndUpdate()

        End With

    End Sub

    Public Sub CargarArbolCarga3()
        'Metodo donde generamos el arbol de opciones de acuerdo a las flotas, subflotas y grupos registrados en BD
        'ARBOL CON PADRE, HIJO Y ABUELO (3 TABLAS)

        Dim Abuelos As New MySqlDataAdapter(" SELECT idflota, nombreflota FROM flota ", Conexion)

        'Adaptadores
        Dim Padres As New MySqlDataAdapter("SELECT idsubflota, nombresubflota, flota " _
                                        & " FROM subflota " _
                                        & " WHERE tiposubflota = 'CARGA' " _
                                        & " ORDER BY nombresubflota ASC", Conexion)

        Dim Hijos As New MySqlDataAdapter(" SELECT idgrupo, nombregrupo, subflota " _
                                        & " FROM grupo " _
                                        & " ORDER BY idgrupo ASC", Conexion)

        Dim Dataset As New DataSet

        'Llenar el DataSet
        Abuelos.Fill(Dataset, "Abuelos")
        Padres.Fill(Dataset, "Padres")
        Hijos.Fill(Dataset, "Hijos")

        'Creamos una relación a través del campo idflota (flota) común en ambos objetos DataTable.
        Dim ColumnaAbuelo As DataColumn = Dataset.Tables("Abuelos").Columns("idflota")

        Dim ColumnaPadre As DataColumn = Dataset.Tables("Padres").Columns("idsubflota")

        Dim ColumnaHijo As DataColumn = Dataset.Tables("Hijos").Columns("subflota") 'clave foranea en tabla hijos (subflota)

        'se cambio a false por un error con los constrain
        Dim Relacion As New DataRelation("Padres_Hijos", ColumnaPadre, ColumnaHijo, False) '*********
        Dim Relacion2 As New DataRelation("Abuelos_Padres", ColumnaAbuelo, ColumnaPadre, False) '*********

        'Añadimos la relación al objeto DataSet.
        Dataset.Relations.Add(Relacion)
        Dataset.Relations.Add(Relacion2)

        With SeguimientoCarga.Arbol

            'Para que no se repinte el control TreeView hasta que se hayan creado los nodos.
            .BeginUpdate()

            'Limpiamos el control TreeView.
            .Nodes.Clear()

            For Each abuelo As DataRow In Dataset.Tables("Abuelos").Rows

                Dim NodoAbuelo As New TreeNode(abuelo.Item("nombreflota").ToString)

                'Lo añadimos a la colección Nodes del control TreeView.
                SeguimientoCarga.Arbol.Nodes.Add(NodoAbuelo)

                'Añadimos un objeto TreeNode ra¡z para cada objeto Padre existente en el objeto DataTable llamado Padres.
                For Each padre As DataRow In Dataset.Tables("Padres").Rows

                    'Creamos el nodo padre.
                    Dim NodoPadre As New TreeNode(padre.Item("nombresubflota").ToString)

                    'Lo añadimos a la colección Nodes del control TreeView.
                    SeguimientoCarga.Arbol.Nodes.Add(NodoPadre)

                    'Añadimos un objeto TreeNode hijo por cada objeto Hijo existente en el objeto Padre actual.
                    For Each hijo In padre.GetChildRows("Padres_Hijos")

                        'Creamos el nodo hijo
                        Dim NodoHijo As New TreeNode(hijo.Item("nombregrupo").ToString)

                        'Lo añadimos al nodo padre
                        NodoPadre.Nodes.Add(NodoHijo)

                    Next

                Next

            Next

            'Editamos la apariencia del arbol
            .Font = New Font("Calibri", 9)
            .ExpandAll()
            .EndUpdate()

        End With

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''METODOS PARA CARGAR DATAGRIDVIEW DE CARGA'''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub CargarGridRutaCargaGrupo()
        'Metodo que genera la carga de datos en el DataGridview1 

        Dim sql As String = "SELECT idvehiculo, nombretipo, estadoactual, condicionvehiculo " _
                       & " FROM vehiculo, grupo, subflota, tipovehiculo " _
                       & " WHERE vehiculo.grupo = grupo.idgrupo " _
                       & " AND grupo.subflota = subflota.idsubflota " _
                       & " AND vehiculo.tipovehiculo = tipovehiculo.idtipo " _
                       & " AND nombregrupo = '" & SeguimientoCarga.TextBox4.Text & "' " _
                       & " AND condicionvehiculo <> 'ROBADO / EXTRAVIADO' " _
                       & " ORDER BY idvehiculo ASC "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()


        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "flota_vehiculo")
        Tabla = DataSet.Tables("flota_vehiculo")
        SeguimientoCarga.DataGridView1.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With SeguimientoCarga.DataGridView1
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 8) 'Fuente para Headers
        End With

        'Llamada al metodo para cargar imagenes
        CargarImagenesHistorialCarga()
        CargarImagenesEstadoVehiculoCarga()

        SeguimientoCarga.DataGridView1.ClearSelection()

    End Sub

    Public Sub CargarGridRutaCargaSubFlota()
        'Metodo que genera la carga de datos en el DataGridview1 
        'NO ESTA EN USO AUN

        Dim sql As String = "SELECT idvehiculo, nombretipo, estadoactual, condicionvehiculo " _
                       & " FROM vehiculo, grupo, subflota, tipovehiculo " _
                       & " WHERE vehiculo.grupo = grupo.idgrupo " _
                       & " AND grupo.subflota = subflota.idsubflota " _
                       & " AND vehiculo.tipovehiculo = tipovehiculo.idtipo " _
                       & " AND nombresubflota = '" & SeguimientoCarga.TextBox4.Text & "' " _
                       & " AND condicionvehiculo <> 'ROBADO / EXTRAVIADO' " _
                       & " ORDER BY idvehiculo ASC "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()


        'Llenado del datagridview.
        Adaptador.Fill(DataSet, "flota_vehiculo")
        Tabla = DataSet.Tables("flota_vehiculo")
        SeguimientoCarga.DataGridView1.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With SeguimientoCarga.DataGridView1
            .DefaultCellStyle.Font = New Font("Segoe UI", 8) 'Fuente para celdas
            .Font = New Font("Segoe UI", 8) 'Fuente para Headers
        End With

        'Llamada al metodo para cargar imagenes
        CargarImagenesHistorialCarga()
        CargarImagenesEstadoVehiculoCarga()

        SeguimientoCarga.DataGridView1.ClearSelection()

    End Sub

    Public Sub CargarGridHistorialCarga()
        'Metodo que genera la carga de datos en el DataGridview2 usando la clausula LIKE y LIMIT

        Dim sql As String = "SELECT idruta, idvehiculo, nombrepersonal, nombreproducto, nombresitiocarga, nombredestino, nombreestado, fecha, hora, estado " _
                       & " FROM ruta, vehiculo, personal, sitiocarga, destino, producto, estadoruta " _
                       & " WHERE ruta.vehiculo = vehiculo.idvehiculo " _
                       & " AND ruta.personal = personal.idpersonal " _
                       & " AND ruta.sitiocarga = sitiocarga.idsitiocarga " _
                       & " AND ruta.destino = destino.iddestino " _
                       & " AND ruta.producto = producto.idproducto " _
                       & " AND ruta.estadoruta = estadoruta.idestado " _
                       & " AND idvehiculo = '" & SeguimientoCarga.TextBox1.Text & "' " _
                       & " ORDER BY idruta DESC" _
                       & " LIMIT 30 "

        Dim connection As New MySqlConnection(ConnectionString)

        'Instancia y uso de variables.
        Command = New MySqlCommand(sql, connection)
        Adaptador = New MySqlDataAdapter(Command)
        DataSet = New DataSet()

        'Llenado del datagridview
        Adaptador.Fill(DataSet, "ruta_vehiculos")
        Tabla = DataSet.Tables("ruta_vehiculos")
        SeguimientoCarga.DataGridView2.DataSource = Tabla

        'Parametros para editar apariencia del datagridview.
        With SeguimientoCarga.DataGridView2
            .DefaultCellStyle.Font = New Font("Segoe UI", 7) 'Fuente para celdas
            .Font = New Font("Segoe UI", 8) 'Fuente para Headers
        End With

        'Llamada al metodo para cargar imagenes
        CargarImagenesHistorialCarga()

        SeguimientoCarga.DataGridView2.ClearSelection()

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''METODOS PARA OBTENER DATOS''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Sub ObtenerRutaCarga()
        'Obtenemos el ID mas alto de la ruta por el vehiculo seleccionado y este mismo es actualizado como "completado"

        Dim Adaptador As New MySqlDataAdapter
        Dim Tabla As New DataTable

        Adaptador = New MySqlDataAdapter("SELECT MAX(idruta) AS 'ID' FROM ruta WHERE vehiculo = '" & SeguimientoCarga.TextBox1.Text & "' ", Conexion)
        Adaptador.Fill(Tabla)

        For Each row As DataRow In Tabla.Rows
            SeguimientoCarga.TextBox21.Text = row("ID").ToString
        Next

    End Sub

    Public Sub ObtenerProductoRutaCarga()
        'Este metodo permite obtener el ID del producto

        Dim Adaptador As New MySqlDataAdapter
        Dim Tabla As New DataTable

        Adaptador = New MySqlDataAdapter("SELECT idproducto FROM producto WHERE nombreproducto = '" & SeguimientoCarga.TextBox6.Text & "' ", Conexion)
        Adaptador.Fill(Tabla)

        For Each row As DataRow In Tabla.Rows
            SeguimientoCarga.TextBox9.Text = row("idproducto").ToString
        Next

    End Sub

    Public Sub ObtenerSitioCargaRutaCarga()
        'Este metodo permite obtener el ID de la sitiocarga

        Dim Adaptador As New MySqlDataAdapter
        Dim Tabla As New DataTable

        Adaptador = New MySqlDataAdapter("SELECT idsitiocarga FROM sitiocarga WHERE nombresitiocarga = '" & SeguimientoCarga.TextBox3.Text & "' ", Conexion)
        Adaptador.Fill(Tabla)

        For Each row As DataRow In Tabla.Rows
            SeguimientoCarga.TextBox10.Text = row("idsitiocarga").ToString
        Next

    End Sub

    Public Sub ObtenerDestinoRutaCarga()
        'Este metodo permite obtener el ID de la sitiocarga

        Dim Adaptador As New MySqlDataAdapter
        Dim Tabla As New DataTable

        Adaptador = New MySqlDataAdapter("SELECT iddestino FROM destino WHERE nombredestino = '" & SeguimientoCarga.TextBox7.Text & "' ", Conexion)
        Adaptador.Fill(Tabla)

        For Each row As DataRow In Tabla.Rows
            SeguimientoCarga.TextBox13.Text = row("iddestino").ToString
        Next

    End Sub

    Public Sub ObtenerPersonalRutaCarga()
        'Este metodo permite obtener el ID del chofer

        Dim Adaptador As New MySqlDataAdapter
        Dim Tabla As New DataTable

        Adaptador = New MySqlDataAdapter("SELECT idpersonal FROM personal WHERE nombrepersonal = '" & SeguimientoCarga.TextBox8.Text & "' ", Conexion)
        Adaptador.Fill(Tabla)

        For Each row As DataRow In Tabla.Rows
            SeguimientoCarga.TextBox11.Text = row("idpersonal").ToString
        Next

    End Sub

    Public Sub ObtenerPersonalInfraccionCarga()
        'Este metodo permite obtener el ID del chofer

        Dim Adaptador As New MySqlDataAdapter
        Dim Tabla As New DataTable

        Adaptador = New MySqlDataAdapter("SELECT idpersonal FROM personal WHERE nombrepersonal = '" & MaestroInfraccion.TextBox4.Text & "' ", Conexion)
        Adaptador.Fill(Tabla)

        For Each row As DataRow In Tabla.Rows
            MaestroInfraccion.TextBox6.Text = row("idpersonal").ToString
        Next

    End Sub

    Public Sub ObtenerPersonaIncidenciaCarga()
        'Este metodo permite obtener el ID del chofer

        Dim Adaptador As New MySqlDataAdapter
        Dim Tabla As New DataTable

        Adaptador = New MySqlDataAdapter("SELECT idpersonal FROM personal WHERE nombrepersonal = '" & MaestroIncidencia.TextBox4.Text & "' ", Conexion)
        Adaptador.Fill(Tabla)

        For Each row As DataRow In Tabla.Rows
            MaestroIncidencia.TextBox6.Text = row("idpersonal").ToString
        Next

    End Sub

    Public Sub ObtenerVehiculoCarga()
        'Este metodo permite obtener los estados de los vehiculos para luego ser modificados
        'Se despliega el formulario MaestroVehiculo

        Dim Adaptador As New MySqlDataAdapter
        Dim Tabla As New DataTable

        Adaptador = New MySqlDataAdapter("SELECT nombregrupo, nombretipo, clasificacionvehiculo, condicionvehiculo, estadoactual " _
                                          & " FROM vehiculo, grupo, tipovehiculo " _
                                          & " WHERE vehiculo.grupo = grupo.idgrupo " _
                                          & " AND vehiculo.tipovehiculo = tipovehiculo.idtipo " _
                                          & " AND idvehiculo = '" & SeguimientoCarga.TextBox1.Text & "' ", Conexion)

        Adaptador.Fill(Tabla)

        For Each row As DataRow In Tabla.Rows

            MaestroVehiculo.ComboGrupo.Text = row("nombregrupo").ToString
            MaestroVehiculo.ComboTipo.Text = row("nombretipo").ToString
            MaestroVehiculo.ComboEstado.Text = row("estadoactual").ToString
            MaestroVehiculo.ComboCondicion.Text = row("condicionvehiculo").ToString
            MaestroVehiculo.ComboClasificacion.Text = row("clasificacionvehiculo").ToString

        Next

    End Sub

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''METODOS DE APOYO PARA LAS RUTAS E INFRACCIONES''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    Public Sub EliminarRutaCarga()
        'Metodo que permite eliminar la ruta seleccionada

        Dim Mensaje As DialogResult

        Mensaje = MessageBox.Show("Desea eliminar la ruta?", "Aviso.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        'Si la respuesta es "Si"
        If Mensaje = DialogResult.Yes Then

            'Se elimina el registro
            Dim db As New MySqlCommand("DELETE FROM ruta WHERE idruta = '" & SeguimientoCarga.TextBox24.Text & "' ", Conexion)
            db.ExecuteNonQuery()

            'Se carga el historial actualizado
            CargarGridHistorialCarga()

            'Se carga el listado actualizado
            CargarGridRutaCargaGrupo()
            'CargarGridRutaCargaSubFlota() 'SE IMPLEMENTARA LUEGO

            MsgBox("Ruta eliminada con Exito.", MsgBoxStyle.Information, "Exito.")

        End If

        'Si la seleccion es "No" Se elimina la seleccion de la fila.
        SeguimientoCarga.DataGridView2.ClearSelection()

    End Sub

    Public Sub ActualizarRutaCarga()
        'Actualizamos el estado de la ruta anterior como ruta "COMPLETADA"

        Dim db3 As New MySqlCommand("UPDATE ruta SET estado = 'COMPLETADA' WHERE idruta = '" & SeguimientoCarga.TextBox21.Text & "' ", Conexion)
        db3.ExecuteNonQuery()

        'Actualizamos el estado actual del vehiculo agregado a la ruta
        'de esta forma en el DataGridView1 mostramos el estado actual 
        Dim db2 As New MySqlCommand("UPDATE vehiculo SET estadoactual = '" & SeguimientoCarga.ComboBox1.Text & "' WHERE idvehiculo = '" & SeguimientoCarga.TextBox1.Text & "' ", Conexion)
        db2.ExecuteNonQuery()

    End Sub

    Public Sub ActualizarEstadoRuta()
        'Metodo que permite colocar el estado de la ruta en el textbox20

        If SeguimientoCarga.ComboBox1.Text = "VEHICULO GUARDADO" Or SeguimientoCarga.ComboBox1.Text = "RUTA CANCELADA" Then

            SeguimientoCarga.TextBox20.Text = "COMPLETADA"

        ElseIf SeguimientoCarga.ComboBox1.Text <> "VEHICULO GUARDADO" Then

            SeguimientoCarga.TextBox20.Text = "ACTIVA"

        End If

    End Sub

    Public Sub SerieRutaCarga()
        'Metodo que permite generar una serie correlativa de numeros enteros. 
        'Usado para generar automaticamente el ID

        'Se obtiene el ultimo ID
        Dim Command As New MySqlCommand("SELECT MAX(idruta) FROM ruta", Conexion)
        Dim numero As Integer

        'El ID obtenido de la BD se incrementa.
        numero = Command.ExecuteScalar
        numero = numero + 1

        'Se da formato al ID obtenido de la BD.
        SeguimientoCarga.TextBox2.Text = Format(numero, "000000000")

    End Sub

    Public Sub CargarComboEstadoRutaCarga()
        'Metodo que permite cargar el Combobox desde la BD.

        Dim Tabla As New DataTable
        Dim Adaptador As New MySqlDataAdapter

        Adaptador = New MySqlDataAdapter("SELECT * FROM estadoruta ORDER BY nombreestado ASC", Conexion)
        Adaptador.Fill(Tabla)

        SeguimientoCarga.ComboBox1.DataSource = Tabla
        SeguimientoCarga.ComboBox1.DisplayMember = "nombreestado"
        SeguimientoCarga.ComboBox1.ValueMember = "idestado"

        SeguimientoCarga.ComboBox1.DrawMode = DrawMode.OwnerDrawVariable 'PARA PODER PONER NUESTRAS IMAGENES
        SeguimientoCarga.ComboBox1.DropDownHeight = 480 'PARA QUE MUESTRE TODOS LOS ELEMENTOS. DEPENDE DEL NUMERO DE ELEMENTOS Y SU ALTURA

        'Generamos un ciclo para obtener cada nombre de la consulta guardada en el Tabla
        'cada valor obtenido es agregado al ArrayList declarado al inicio de la clase
        For Each dr As DataRow In Tabla.Rows

            'guardamos cada registro en el arreglo
            Arreglo.Add(dr("nombreestado"))

        Next

    End Sub

    Public Sub CargarImagenesHistorialCarga()
        'En este metodo especificamos cuales son las imagenes que se cargaran en el 
        'CellFormatting del DataGridView1

        'CARGAMOS E IMPLEMENTAMOS DESDE LA CARPETA RESOURCES SIN NECESIDAD DE COPIAR EN DEBUG Y RELEASE
        EnRutaVacio = My.Resources.EnRutaVacio
        EnRutaCargado = My.Resources.EnRutaCargado
        DeRegresoConRetorno = My.Resources.DeRegresoConRetorno
        DeRegresoCargado = My.Resources.DeRegresoCargado
        DeRegresoVacio = My.Resources.DeRegresoVacio
        OrganizacionElTunal = My.Resources.OrganizacionElTunal
        PernoctaAutorizada = My.Resources.PernoctaAutorizada
        EnProcesoDeCarga = My.Resources.EnProcesoDeCarga
        EnProcesoDeDescarga = My.Resources.EnProcesoDeDescarga
        CargadoEsperandoPorSalir = My.Resources.CargadoEsperandoPorSalir
        CargadoEsperandoDocumentos = My.Resources.CargadoEsperandoDocumentos
        EsperandoAutorizacionParaSalir = My.Resources.EsperandoAutorizacionParaSalir
        Detenido = My.Resources.Detenido
        Accidentado = My.Resources.Accidentado
        ParadaIrregular = My.Resources.ParadaIrregular
        EnTaller = My.Resources.EnTaller
        EsperandoPorSalir = My.Resources.EsperandoPorSalir
        EnElClienteEnElProveedor = My.Resources.EnElClienteEnElProveedor
        RealizandoMovimientos = My.Resources.RealizandoMovimientos
        RutaCancelada = My.Resources.RutaCancelada

    End Sub

    Public Sub CargarImagenesEstadoVehiculoCarga()
        'En este metodo especificamos cuales son las imagenes que se cargaran en el 
        'CellFormatting del DataGridView1

        Operativo = My.Resources.Operativo
        EnReparacion = My.Resources.EnReparacion
        SinReporte = My.Resources.SinReporte
        Robado = My.Resources.Robado

    End Sub

    Public Function VerificarPersonal(ByVal personal As String) As Boolean
        'Funcion booleana que permite validar si existe algun chofer registrado en otra ruta
        'para evitar registrar duplicados.
        'NO ESTA EN USO

        Dim sql As String = "SELECT COUNT(nombrepersonal) > 0, nombrepersonal FROM ruta, personal, estadoruta " _
                            & " WHERE ruta.personal = personal.idpersonal " _
                            & " AND ruta.estadoruta = estadoruta.idestado " _
                            & " AND idruta IN (SELECT MAX(idruta) FROM ruta GROUP BY vehiculo) " _
                            & " AND nombreestado NOT IN ('VEHICULO GUARDADO') " _
                            & " AND nombrepersonal = '" & personal & "' "

        Dim Comando As New MySqlCommand(sql, Conexion)
        Return Convert.ToBoolean(Comando.ExecuteScalar())

    End Function

    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''FUNCIONES DE LIMPIEZA'''''''''''''''''''''''''''''''''''''''''
    '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    Public Function ValidarComponentesRutaCarga() As Boolean
        'Funcion booleana que permite validar si algun campo quedo vacio.

        Dim Validar As Boolean = True

        'Limpia todos los mensajes de error mostrados en la interfaz de usuario
        SeguimientoCarga.ErrorProvider1.Clear()

        'Valida que el textbox no este nulo o vacio
        If String.IsNullOrEmpty(SeguimientoCarga.TextBox1.Text) Then
            SeguimientoCarga.ErrorProvider1.SetError(SeguimientoCarga.TextBox1, "No puede dejar campos en blanco.")
            Validar = False
        Else
            'Si el error ha sido superado, se debe borrar
            SeguimientoCarga.ErrorProvider1.SetError(SeguimientoCarga.TextBox1, "")
        End If

        If String.IsNullOrEmpty(SeguimientoCarga.TextBox2.Text) Then
            SeguimientoCarga.ErrorProvider1.SetError(SeguimientoCarga.TextBox2, "No puede dejar campos en blanco.")
            Validar = False
        Else
            'Si el error ha sido superado, se debe borrar
            SeguimientoCarga.ErrorProvider1.SetError(SeguimientoCarga.TextBox2, "")
        End If

        If String.IsNullOrEmpty(SeguimientoCarga.TextBox3.Text) Then
            SeguimientoCarga.ErrorProvider1.SetError(SeguimientoCarga.TextBox3, "No puede dejar campos en blanco.")
            Validar = False
        Else
            'Si el error ha sido superado, se debe borrar
            SeguimientoCarga.ErrorProvider1.SetError(SeguimientoCarga.TextBox3, "")
        End If

        If String.IsNullOrEmpty(SeguimientoCarga.TextBox6.Text) Then
            SeguimientoCarga.ErrorProvider1.SetError(SeguimientoCarga.TextBox6, "No puede dejar campos en blanco.")
            Validar = False
        Else
            'Si el error ha sido superado, se debe borrar
            SeguimientoCarga.ErrorProvider1.SetError(SeguimientoCarga.TextBox6, "")
        End If

        If String.IsNullOrEmpty(SeguimientoCarga.TextBox7.Text) Then
            SeguimientoCarga.ErrorProvider1.SetError(SeguimientoCarga.TextBox7, "No puede dejar campos en blanco.")
            Validar = False
        Else
            'Si el error ha sido superado, se debe borrar
            SeguimientoCarga.ErrorProvider1.SetError(SeguimientoCarga.TextBox7, "")
        End If

        If String.IsNullOrEmpty(SeguimientoCarga.TextBox8.Text) Then
            SeguimientoCarga.ErrorProvider1.SetError(SeguimientoCarga.TextBox8, "No puede dejar campos en blanco.")
            Validar = False
        Else
            'Si el error ha sido superado, se debe borrar
            SeguimientoCarga.ErrorProvider1.SetError(SeguimientoCarga.TextBox8, "")
        End If

        Return Validar

    End Function

    Public Sub LimpiarComponentesSeguimientoCarga()
        'Metodo para limpiar componentes dentro del formulario.

        SeguimientoCarga.TextBox3.Text = ""
        SeguimientoCarga.TextBox6.Text = ""
        SeguimientoCarga.TextBox7.Text = ""
        SeguimientoCarga.TextBox8.Text = ""
        SeguimientoCarga.TextBox9.Text = ""
        SeguimientoCarga.TextBox10.Text = ""
        SeguimientoCarga.TextBox11.Text = ""

        'Limpia todos los mensajes de error mostrados en la interfaz de usuario
        SeguimientoCarga.ErrorProvider1.Clear()
        SeguimientoCarga.ErrorProvider2.Clear()

        'SeguimientoLiviano.TextBox1.Text = ""

    End Sub

    Public Sub LimpiarArbolSeguimientoCarga()
        'Metodo que permite limpiar el arbol cada ves que se instancie la ventana RegistroRuta

        'Deshabilitamos visualmente el arbol
        SeguimientoCarga.Arbol.Visible = False
        'Limpiamos los nodos del arbol
        SeguimientoCarga.Arbol.Nodes.Clear()
        'Pintamos el arbol nuevamente
        SeguimientoCarga.Arbol.Visible = True

    End Sub


End Module
