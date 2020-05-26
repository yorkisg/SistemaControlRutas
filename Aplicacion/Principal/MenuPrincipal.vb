
Public Class MenuPrincipal

    Public Contador As Integer = 0

    Private Sub Principal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Instancia principal de la conexion de la BD.
        ConectarBaseDeDatos()

        'Obtenemos el usuario logueado
        usuariorol.Text = AccesoAplicacion.rolusuario.Text

        'Validamos el rol logueado y damos permisos
        ValidarRol()

        'Instancia del metodo que evita que el ejecutable se abra 2 veces
        Instancia()

        'Se carga la fecha y hora del sistema al iniciar la aplicacion
        InicializarTimer()

    End Sub

    Private Sub InicializarTimer()
        'Se carga la fecha y hora del sistema al iniciar la aplicacion

        Timer1.Interval = 1000
        Timer1.Start()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Control Timer: se lleva el tiempo para que la hora y la fecha pueda ser actualizada constantemente

        'Contamos y enviamos el tiempo al label
        Contador = Contador + 1
        Label1.Text = Contador

        'Si el tiempo llega a 300 seg (5min) se cierra la aplicacion
        If Contador = 300 Then

            'Close()

        End If

        'Vehiculos
        MaestroVehiculo.TextBox5.Text = DateTime.Now.ToShortTimeString()
        MaestroVehiculo.DateTimePicker1.Value = Today

        'Infracciones
        MaestroInfraccion.TextBox5.Text = DateTime.Now.ToShortTimeString()
        MaestroInfraccion.DateTimePicker1.Value = Today

        'Cuadro resumen
        CuadroResumenMateriaPrima.TextBox5.Text = DateTime.Now.ToShortTimeString()
        CuadroResumenMateriaPrima.DateTimePicker1.Value = Today

        'Incidencias
        MaestroIncidencia.TextBox5.Text = DateTime.Now.ToShortTimeString()
        MaestroIncidencia.DateTimePicker1.Value = Today

    End Sub

    Private Sub ReiniciarTiempo()
        'Se detiene el tiempo, reiniciamos el contador y volvemos a iniciar el conteo del tiempo

        'Timer1.Stop()

        'Contador = 0

        'Timer1.Start()

    End Sub

    Private Sub Principal_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        'funciona
        'AL OBTENER EL FOCUS DEL FORMULARIO SE REINICIA EL TIEMPO

        ReiniciarTiempo()

    End Sub

    Private Sub MenuPrincipal2_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuPrincipal2.ItemClicked
        'funciona 
        'AL DAR CLICK EN EL MENU SE REINICIA EL TIEMPO

        ReiniciarTiempo()

    End Sub

    Private Sub MenuPrincipal2_MouseClick(sender As Object, e As MouseEventArgs) Handles MenuPrincipal2.MouseClick
        'funciona 
        'AL DAR CLICK EN EL MENU SE REINICIA EL TIEMPO

        ReiniciarTiempo()

    End Sub

    Private Sub MenuPrincipal2_MouseMove(sender As Object, e As MouseEventArgs) Handles MenuPrincipal2.MouseMove
        'funciona 
        'AL MOVER EL MOUSE EN EL MENU SE REINICIA EL TIEMPO

        ReiniciarTiempo()

    End Sub

    Private Sub ValidarRol()
        'Metodo para validar el rol del usuario y dar permisos

        If usuariorol.Text = "ANALISTA" Then

            'Grupo de menus
            MenuMaestros.Enabled = True
            MenuGestionRutas.Enabled = True
            MenuConsultas.Enabled = False
            MenuEstadisticas.Enabled = False
            MenuConfiguracion.Enabled = False

            'submenus
            MenuSeguimientoCarga.Enabled = True
            MenuSeguimientoLiviano.Enabled = True
            MenuSeguimientoTransporte.Enabled = True
            MenuSeguimientoTaller.Enabled = True

        End If

        If usuariorol.Text = "ADMINISTRADOR" Then

            'Grupo de menus
            MenuMaestros.Enabled = True
            MenuGestionRutas.Enabled = True
            MenuConsultas.Enabled = True
            MenuEstadisticas.Enabled = True
            MenuConfiguracion.Enabled = True

            'submenus
            MenuSeguimientoCarga.Enabled = True
            MenuSeguimientoLiviano.Enabled = True
            MenuSeguimientoTransporte.Enabled = True
            MenuSeguimientoTaller.Enabled = True

        End If

        If usuariorol.Text = "VISITANTE" Then

            'Grupo de menus
            MenuMaestros.Enabled = False
            MenuGestionRutas.Enabled = True
            MenuConsultas.Enabled = False
            MenuEstadisticas.Enabled = False
            MenuConfiguracion.Enabled = False

            'submenus
            MenuSeguimientoCarga.Enabled = False
            MenuSeguimientoLiviano.Enabled = False
            MenuSeguimientoTransporte.Enabled = False
            MenuSeguimientoTaller.Enabled = True

        End If

    End Sub

    Private Sub MenuSalir2_Click(sender As Object, e As EventArgs) Handles MenuSalir2.Click

        'Desconexion de la BD y cierre de la aplicacion.
        DesconectarBaseDeDatos()

        'Dispose o Close, cualquiera de los dos sirve
        Close()

        AccesoAplicacion.Close()

        ' Application.Exit()

    End Sub

    Private Sub MenuPersonal_Click(sender As Object, e As EventArgs) Handles MenuPersonal.Click
        'Formulario MaestroPersonal

        MaestroPersonal.ShowDialog()

    End Sub

    Private Sub MenuProductos_Click(sender As Object, e As EventArgs) Handles MenuProductos.Click
        'Formulario MaestroProducto

        MaestroProducto.ShowDialog()

    End Sub

    Private Sub Menusitiocargaes_Click(sender As Object, e As EventArgs) Handles Menusitiocargaes.Click
        'Formulario Maestrositiocarga

        MaestroSitioCarga.ShowDialog()

    End Sub

    Private Sub MenuVehiculos_Click(sender As Object, e As EventArgs) Handles MenuVehiculos.Click
        'Formulario MaestroVehiculo

        MaestroVehiculo.ShowDialog()

    End Sub

    Private Sub MenuSeguimientoCarga_Click(sender As Object, e As EventArgs) Handles MenuSeguimientoCarga.Click
        'Formulario SeguimientoCarga

        SeguimientoCarga.Show()


    End Sub

    Private Sub MenuSeguimientoLiviano_Click(sender As Object, e As EventArgs) Handles MenuSeguimientoLiviano.Click
        'Formulario SeguimientoLiviano

        SeguimientoLiviano.Show()

    End Sub

    Private Sub MenuSeguimientoTaller_Click(sender As Object, e As EventArgs) Handles MenuSeguimientoTaller.Click
        'Formulario SeguimientoTaller

        SeguimientoTaller.Show()

    End Sub

    Private Sub MenuConsultarChofer_Click(sender As Object, e As EventArgs) Handles MenuConsultarChofer.Click
        'Formulario ConsultaChofer

        ConsultaGeneralRuta.ShowDialog()

    End Sub

    Private Sub MenuConsultarInfracciones_Click(sender As Object, e As EventArgs) Handles MenuConsultarInfracciones.Click
        'Formulario ConsultaInfraccion

        ConsultaInfraccion.ShowDialog()

    End Sub

    Private Sub MenuConsultarIncidencias_Click(sender As Object, e As EventArgs) Handles MenuConsultarIncidencias.Click
        'Formulario ListadoReporteInfraccion

        ConsultaIncidencia.ShowDialog()

    End Sub

    Private Sub MenuGuiaTelefonica_Click(sender As Object, e As EventArgs) Handles MenuGuiaTelefonica.Click
        'Formulario GuiaTelefonica

        GuiaTelefonica.Show()

    End Sub

    Private Sub MenuConsultaGrupoProducto_Click(sender As Object, e As EventArgs) Handles MenuConsultaGrupoProducto.Click
        'Formulario ResumenMateriaPrima

        CuadroResumenMateriaPrima.ShowDialog()

    End Sub

    Private Sub MenuListadoCompelto_Click(sender As Object, e As EventArgs) Handles MenuListadoCompelto.Click
        'Formulario ListadoGeneralVehiculo

        ListadoGeneralRutas.ShowDialog()

    End Sub

    Private Sub MenuFlotas_Click(sender As Object, e As EventArgs) Handles MenuFlotas.Click
        'Formulario Flotas

        MaestroFlota.ShowDialog()

    End Sub

    Private Sub MenuEstados_Click(sender As Object, e As EventArgs) Handles MenuEstados.Click
        'Formulario MaestroEstado

        MaestroEstado.ShowDialog()

    End Sub

    Private Sub MenuHistorialDeRutas_Click(sender As Object, e As EventArgs) Handles MenuHistorialDeRutas.Click
        'Formulario EstadisticaRuta

        EstadisticaGeneral.ShowDialog()

    End Sub

    Private Sub MenuListadoDeInfractores_Click(sender As Object, e As EventArgs) Handles MenuListadoDeInfractores.Click
        'Formulario ListadoReporteInfraccion

        ReporteInfraccion.ShowDialog()

    End Sub

    Private Sub MenuConfiguracion_Click(sender As Object, e As EventArgs) Handles MenuConfiguracion.Click

        'AccesoAdministrador.ShowDialog()

    End Sub

    Private Sub MenuListadoConsumible_Click(sender As Object, e As EventArgs) Handles MenuListadoConsumible.Click
        'Formulario ListadoReporteInfraccion

        ReporteConsumible.ShowDialog()

    End Sub

End Class

