
Public Class ListadoVehiculo

    Private Sub ListadoVehiculo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Metodos que cargaran al momento de desplegar el formulario.

        'Se llama el metodo para alternar colores entre filas
        AlternarFilasGeneral(DataGridView)

        'Se llama al metodo en el Load del formulario para que el datagridview cargue los datos inmediatamente
        CargarGridListadoVehiculo()

        'Se llama al metodo para que cargue rapido el datagridview
        EnableDoubleBuffered(DataGridView)

    End Sub

    Private Sub ListadoVehiculo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Cierre del formulario

        If DataGridView.RowCount > 0 Then
            'Si el datagridview contiene datos, obtenemos recursos 
            'liberando los datatable y dataset implementados.

            LimpiarComponentes()
            Tabla.Clear()
            DataSet.Clear()
            Dispose()

        Else

            Dispose()

        End If

    End Sub

    Private Sub BotonGuardar_Click(sender As Object, e As EventArgs) Handles BotonGuardar.Click
        'Boton aceptar

        If DataGridView.RowCount > 0 Then

            If MaestroVehiculo.Visible = True Then
                'si el formulario "MaestroVehiculo" esta activo, se carga la informacion seleccionada del datagridview.

                MaestroVehiculo.TextBox1.Text = DataGridView.Item("ColumnaIDVehiculo", DataGridView.SelectedRows(0).Index).Value
                MaestroVehiculo.ComboTipo.Text = DataGridView.Item("ColumnaTipo", DataGridView.SelectedRows(0).Index).Value
                MaestroVehiculo.ComboFlota.Text = DataGridView.Item("ColumnaSublota", DataGridView.SelectedRows(0).Index).Value
                MaestroVehiculo.ComboCondicion.Text = DataGridView.Item("ColumnaCondicion", DataGridView.SelectedRows(0).Index).Value
                MaestroVehiculo.ComboEstado.Text = DataGridView.Item("ColumnaEstadoActual", DataGridView.SelectedRows(0).Index).Value
                MaestroVehiculo.ComboClasificacion.Text = DataGridView.Item("ColumnaClasificacion", DataGridView.SelectedRows(0).Index).Value

                'Se activa el uso del boton modificar del formulario "MaestroVehiculo"
                MaestroVehiculo.BotonModificar.Enabled = True
                'Se desactiva el uso del boton guardar del formulario "MaestroVehiculo"
                MaestroVehiculo.BotonGuardar.Enabled = False
                'Se desactiva el uso del textbox1.
                MaestroVehiculo.TextBox1.Enabled = False

                'Se cierra el formulario ListadoVehiculo
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If ConsultaVehiculo.Visible = True Then
                'si el formulario "ConsultaVehiculo" esta activo, se carga la informacion seleccionada del datagridview

                ConsultaVehiculo.TextBox1.Text = DataGridView.Item("ColumnaIDVehiculo", DataGridView.SelectedRows(0).Index).Value

                'Se cierra el formulario ListadoVehiculo
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If ConsultaHistorialVehiculo.Visible = True Then
                'si el formulario "ConsultaVehiculo" esta activo, se carga la informacion seleccionada del datagridview

                ConsultaHistorialVehiculo.TextBox1.Text = DataGridView.Item("ColumnaIDVehiculo", DataGridView.SelectedRows(0).Index).Value

                'Se cierra el formulario ListadoVehiculo
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If MaestroInfraccion.Visible = True Then
                'si el formulario "MaestroInfraccion" esta activo, se carga la informacion seleccionada del datagridview

                MaestroInfraccion.TextBox2.Text = DataGridView.Item("ColumnaIDVehiculo", DataGridView.SelectedRows(0).Index).Value

                'Se cierra el formulario ListadoVehiculo
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If MaestroIncidencia.Visible = True Then
                'si el formulario "MaestroInfraccion" esta activo, se carga la informacion seleccionada del datagridview

                MaestroIncidencia.TextBox2.Text = DataGridView.Item("ColumnaIDVehiculo", DataGridView.SelectedRows(0).Index).Value

                'Se cierra el formulario ListadoVehiculo
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If ConsultaInfraccion.Visible = True Then
                'si el formulario "ConsultaInfraccion" esta activo, se carga la informacion seleccionada del datagridview

                ConsultaInfraccion.TextBox1.Text = DataGridView.Item("ColumnaIDVehiculo", DataGridView.SelectedRows(0).Index).Value

                'Se cierra el formulario ListadoVehiculo
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If RegistrarReporteTaller.Visible = True Then
                'si el formulario "ConsultaInfraccion" esta activo, se carga la informacion seleccionada del datagridview

                RegistrarReporteTaller.TextBox3.Text = DataGridView.Item("ColumnaIDVehiculo", DataGridView.SelectedRows(0).Index).Value

                'Se cierra el formulario ListadoVehiculo
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

        End If

    End Sub

    Private Sub BotonExportar_Click(sender As Object, e As EventArgs) Handles BotonExportar.Click
        'Boton Exportar a Excel

        Try

            If DataGridView.RowCount > 0 Then

                Dim Mensaje As DialogResult

                Mensaje = MessageBox.Show("Desea expotar el listado?", "Aviso.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                'Si la respuesta es "Si"
                If Mensaje = DialogResult.Yes Then

                    Exportar(DataGridView)

                End If

            Else

                MsgBox("No hay datos que exportar.", MsgBoxStyle.Exclamation, "Error.")

            End If

        Catch ex As Exception

            MsgBox("No se logró exportar nada, debe verificar con el administrador del sistema.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub BotonSalir_Click(sender As Object, e As EventArgs) Handles BotonSalir.Click
        'Boton salir

        If DataGridView.RowCount > 0 Then
            'Si el datagridview contiene datos, obtenemos recursos 
            'liberando los datatable y dataset implementados.

            LimpiarComponentes()
            Tabla.Clear()
            DataSet.Clear()
            Dispose()

        Else

            Dispose()

        End If

    End Sub

    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs) Handles TextBox.TextChanged
        'TextBox que permite filtrar de acuerdo a lo establecido en la funcion "Filtrar".

        If Filtrar(TextBox.Text).Rows.Count > 0 Then
            DataGridView.DataSource = Filtrar(TextBox.Text)
        End If

    End Sub

    Function Filtrar(ByVal busqueda As String) As DataTable
        'Funcion que carga los datos de acuerdo a lo ingresado en el TextBox

        Dim cmd As New MySqlCommand(" SELECT idvehiculo, nombretipo, nombresubflota, clasificacionvehiculo, estadoactual, condicionvehiculo " _
                            & " FROM vehiculo, tipovehiculo, subflota " _
                            & " WHERE vehiculo.tipovehiculo = tipovehiculo.idtipo" _
                            & " AND vehiculo.subflota = subflota.idsubflota" _
                            & " AND idvehiculo LIKE '%" & busqueda & "%' ", cnn)

        Dim Tabla As New DataTable
        Dim Adaptador As New MySqlDataAdapter(cmd)
        Adaptador.Fill(Tabla)
        Return Tabla

    End Function

    Private Sub DataGridView_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView.CellMouseDoubleClick
        'Al dar dobleclick en cualquier fila
        'se lleva la informacion correspondiente al siguiente formulario

        If DataGridView.RowCount > 0 Then

            If MaestroVehiculo.Visible = True Then
                'si el formulario "MaestroVehiculo" esta activo, se carga la informacion seleccionada del datagridview.

                MaestroVehiculo.TextBox1.Text = DataGridView.Item("ColumnaIDVehiculo", DataGridView.SelectedRows(0).Index).Value
                MaestroVehiculo.ComboTipo.Text = DataGridView.Item("ColumnaTipo", DataGridView.SelectedRows(0).Index).Value
                MaestroVehiculo.ComboFlota.Text = DataGridView.Item("ColumnaSublota", DataGridView.SelectedRows(0).Index).Value
                MaestroVehiculo.ComboCondicion.Text = DataGridView.Item("ColumnaCondicion", DataGridView.SelectedRows(0).Index).Value
                MaestroVehiculo.ComboEstado.Text = DataGridView.Item("ColumnaEstadoActual", DataGridView.SelectedRows(0).Index).Value
                MaestroVehiculo.ComboClasificacion.Text = DataGridView.Item("ColumnaClasificacion", DataGridView.SelectedRows(0).Index).Value

                'Se activa el uso del boton modificar del formulario "MaestroVehiculo"
                MaestroVehiculo.BotonModificar.Enabled = True
                'Se desactiva el uso del boton guardar del formulario "MaestroVehiculo"
                MaestroVehiculo.BotonGuardar.Enabled = False
                'Se desactiva el uso del textbox1.
                MaestroVehiculo.TextBox1.Enabled = False

                'Se cierra el formulario ListadoVehiculo
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If ConsultaVehiculo.Visible = True Then
                'si el formulario "ConsultaVehiculo" esta activo, se carga la informacion seleccionada del datagridview

                ConsultaVehiculo.TextBox1.Text = DataGridView.Item("ColumnaIDVehiculo", DataGridView.SelectedRows(0).Index).Value

                'Se cierra el formulario ListadoVehiculo
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If ConsultaHistorialVehiculo.Visible = True Then
                'si el formulario "ConsultaVehiculo" esta activo, se carga la informacion seleccionada del datagridview

                ConsultaHistorialVehiculo.TextBox1.Text = DataGridView.Item("ColumnaIDVehiculo", DataGridView.SelectedRows(0).Index).Value

                'Se cierra el formulario ListadoVehiculo
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If MaestroInfraccion.Visible = True Then
                'si el formulario "MaestroInfraccion" esta activo, se carga la informacion seleccionada del datagridview

                MaestroInfraccion.TextBox2.Text = DataGridView.Item("ColumnaIDVehiculo", DataGridView.SelectedRows(0).Index).Value

                'Se cierra el formulario ListadoVehiculo
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If MaestroIncidencia.Visible = True Then
                'si el formulario "MaestroInfraccion" esta activo, se carga la informacion seleccionada del datagridview

                MaestroIncidencia.TextBox2.Text = DataGridView.Item("ColumnaIDVehiculo", DataGridView.SelectedRows(0).Index).Value

                'Se cierra el formulario ListadoVehiculo
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If ConsultaInfraccion.Visible = True Then
                'si el formulario "ConsultaInfraccion" esta activo, se carga la informacion seleccionada del datagridview

                ConsultaInfraccion.TextBox1.Text = DataGridView.Item("ColumnaIDVehiculo", DataGridView.SelectedRows(0).Index).Value

                'Se cierra el formulario ListadoVehiculo
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If RegistrarReporteTaller.Visible = True Then
                'si el formulario "ConsultaInfraccion" esta activo, se carga la informacion seleccionada del datagridview

                RegistrarReporteTaller.TextBox3.Text = DataGridView.Item("ColumnaIDVehiculo", DataGridView.SelectedRows(0).Index).Value

                'Se cierra el formulario ListadoVehiculo
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

        End If

    End Sub

    Private Sub LimpiarComponentes()
        'Metodo que permite limpiar todos los controles del formulario.

        'Abrimos el ciclo que recorre todas las filas del datagridview
        For i As Integer = 0 To DataGridView.RowCount - 1
            'Eliminamos elemento por elemento
            DataGridView.Rows.Remove(DataGridView.CurrentRow)
        Next

    End Sub

    Private Sub DataGridView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView.CellFormatting
        'CellFormatting: Evento del control DataGridview el cual permite cambiar 
        'y dar formato a las celdas, bien sea por color de texto, fondo, etc.

        Try

            Dim TipoEstado As String
            Dim EstadoVehiculo As String
            Dim TipoVehiculo As String

            'Indicamos sobre cual columna trabajaremos.
            If DataGridView.Columns(e.ColumnIndex).Name.Equals("ColumnaEstadoActual") Then

                TipoEstado = (DataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

                'Verificamos los valores del estado y asignamos los colores e iconos.
                If TipoEstado = "EN RUTA VACIO" Or TipoEstado = "EN RUTA CARGADO" Then

                    e.CellStyle.ForeColor = Color.Green

                End If

                If TipoEstado = "DE REGRESO CARGADO" Or TipoEstado = "DE REGRESO VACIO" Then

                    e.CellStyle.ForeColor = Color.Red

                End If

                If TipoEstado = "VEHICULO GUARDADO" Then

                    e.CellStyle.ForeColor = Color.Purple

                End If

                If TipoEstado = "PERNOCTA AUTORIZADA" Then

                    e.CellStyle.ForeColor = Color.Green

                End If

                If TipoEstado = "EN PROCESO DE CARGA" Then

                    e.CellStyle.ForeColor = Color.Green

                End If

                If TipoEstado = "EN PROCESO DE DESCARGA" Then

                    e.CellStyle.ForeColor = Color.Green

                End If

                If TipoEstado = "CARGADO ESPERANDO POR SALIR" Then

                    e.CellStyle.ForeColor = Color.Green

                End If

                If TipoEstado = "CARGADO ESPERANDO DOCUMENTOS" Then

                    e.CellStyle.ForeColor = Color.Green

                End If

                If TipoEstado = "ESPERANDO AUTORIZACIÓN PARA SALIR" Then

                    e.CellStyle.ForeColor = Color.Green

                End If

                If TipoEstado = "DETENIDO" Then

                    e.CellStyle.ForeColor = Color.Red

                End If

                If TipoEstado = "ACCIDENTADO" Then

                    e.CellStyle.ForeColor = Color.Red

                End If

                If TipoEstado = "PARADA IRREGULAR" Then

                    e.CellStyle.ForeColor = Color.Red

                End If

                If TipoEstado = "EN TALLER" Then

                    e.CellStyle.ForeColor = Color.Red

                End If

                If TipoEstado = "ESPERANDO POR SALIR" Then

                    e.CellStyle.ForeColor = Color.Green

                End If

                If TipoEstado = "EN EL CLIENTE" Or TipoEstado = "EN EL PROVEEDOR" Then

                    e.CellStyle.ForeColor = Color.Blue

                End If

                If TipoEstado = "REALIZANDO MOVIMIENTOS Ó ACARREOS" Then

                    e.CellStyle.ForeColor = Color.Green

                End If

                If TipoEstado = "RUTA CANCELADA" Then

                    e.CellStyle.ForeColor = Color.Red

                End If

            End If

            If DataGridView.Columns(e.ColumnIndex).Name.Equals("ColumnaCondicion") Then

                EstadoVehiculo = (DataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

                If EstadoVehiculo = "OPERATIVO" Then

                    e.CellStyle.ForeColor = Color.Green
                    DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = Operativo

                End If

                If EstadoVehiculo = "EN SERVICIO" Or EstadoVehiculo = "EN REPARACIÓN" Then

                    e.CellStyle.ForeColor = Color.Blue
                    DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = EnReparacion

                End If

                If EstadoVehiculo = "UNIDAD SIN REPORTE DE GPS" Or EstadoVehiculo = "UNIDAD SIN DISPOSITIVO GPS" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = SinReporte

                End If

                If EstadoVehiculo = "ROBADO / EXTRAVIADO" Or EstadoVehiculo = "INACTIVO" Then

                    e.CellStyle.ForeColor = Color.Red
                    DataGridView.Rows(e.RowIndex).Cells("ColumnaImagen").Value = Robado

                End If

            End If

            If DataGridView.Columns(e.ColumnIndex).Name.Equals("ColumnaClasificacion") Then

                TipoVehiculo = (DataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

                If TipoVehiculo = "CARGA" Then

                    e.CellStyle.ForeColor = Color.Blue

                End If

                If TipoVehiculo = "LIVIANO" Then

                    e.CellStyle.ForeColor = Color.Green

                End If

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub


End Class