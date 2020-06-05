
Public Class ListadoPersonal

    Private Sub ListadoPersonal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Metodos que cargaran al momento de desplegar el formulario.

        'Se llama el metodo para alternar colores entre filas
        AlternarFilasGeneral(DataGridView)

        'Se llama al metodo en el Load del formulario para que el datagridview cargue los datos inmediatamente
        CargarGridListadoPersonal()

        'Se llama al metodo para que cargue rapido el datagridview
        EnableDoubleBuffered(DataGridView)

        'Decimos que el primer elemento activo del combo es "Activo"
        ComboEstadoPersona.SelectedItem = "ACTIVO"

        'Decimos que el primer elemento activo del combo es "Activo"
        ComboTipoPersona.SelectedItem = "CARGA"

        'si la llamada proviene del seguimiento liviano entonces cargamos los choferes livianos
        If SeguimientoLiviano.Visible = True Then

            ComboTipoPersona.SelectedItem = "LIVIANO"

        End If

        ActiveControl = TextBox.Control

    End Sub

    Private Sub ListadoPersonal_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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

            If SeguimientoCarga.Visible = True Then
                'si el formulario "RegistroRuta" esta activo, se carga la informacion seleccionada del datagridview

                SeguimientoCarga.TextBox11.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                SeguimientoCarga.TextBox8.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                'Se cierra el formulario ListadoChofer
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If MaestroPersonal.Visible = True Then
                'si el formulario "MaestroChofer" esta activo, se carga la informacion seleccionada del datagridview
                'Llamamos al metodo para obtener los datos del chofer y luego editarlos en el MaestroChofer

                'Guardamos el id en el textbox
                TextBox1.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value()

                'Enviamos datos al formulario
                ObtenerPersonalListado()
                MaestroPersonal.Show()

                MaestroPersonal.BotonModificar.Enabled = True
                MaestroPersonal.BotonGuardar.Enabled = False

                'Se cierra el formulario ListadoChofer
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If ConsultaGeneralRuta.Visible = True Then
                'si el formulario "ConsultaPersonal" esta activo, se carga la informacion seleccionada del datagridview

                ConsultaGeneralRuta.TextBox1.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                'Se cierra el formulario ListadoChofer
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If ConsultaConsumible.Visible = True Then
                'si el formulario "ConsultaPersonal" esta activo, se carga la informacion seleccionada del datagridview

                ConsultaConsumible.TextBox1.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                'Se cierra el formulario ListadoChofer
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If MaestroInfraccion.Visible = True Then
                'si el formulario "MaestroInfraccion" esta activo, se carga la informacion seleccionada del datagridview

                MaestroInfraccion.TextBox6.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                MaestroInfraccion.TextBox4.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                'Se cierra el formulario ListadoChofer
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If MaestroIncidencia.Visible = True Then
                'si el formulario "MaestroInfraccion" esta activo, se carga la informacion seleccionada del datagridview

                MaestroIncidencia.TextBox6.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                MaestroIncidencia.TextBox4.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                'Se cierra el formulario ListadoChofer
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If SeguimientoLiviano.Visible = True Then
                'si el formulario "MaestroChofer" esta activo, se carga la informacion seleccionada del datagridview

                'Si la pestaña de infracciones esta seleccionada enviamos los datos al chofer de infracciones
                If SeguimientoLiviano.Panel5.SelectedIndex = 0 Then

                    SeguimientoLiviano.TextBox6.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                    SeguimientoLiviano.TextBox16.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                    'Si la pestaña de incidencias esta seleccionada enviamos los datos al chofer de incidencias
                ElseIf SeguimientoLiviano.Panel5.SelectedIndex = 1 Then

                    SeguimientoLiviano.TextBox18.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                    SeguimientoLiviano.TextBox17.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                ElseIf SeguimientoLiviano.Panel5.SelectedIndex = 2 Then

                    SeguimientoLiviano.TextBox26.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                    SeguimientoLiviano.TextBox24.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                End If

                'Se cierra el formulario ListadoPersona
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

        Dim cmd As New MySqlCommand("SELECT idpersonal, nombrepersonal, tipopersonal, if(telefono1 <> 'N/A', (concat(LEFT(telefono1,4),' - ', RIGHT(telefono1,7))), 'N/A') AS 'Telefono1', " _
            & " if(telefono2 <> 'N/A', (concat(LEFT(telefono2,4),' - ', RIGHT(telefono2,7))), 'N/A') AS 'Telefono2', estadopersonal FROM personal " _
            & " WHERE estadopersonal = '" & TextBox1.Text & "' " _
            & " AND tipopersonal = '" & TextBox2.Text & "' " _
            & " AND nombrepersonal LIKE '%" & busqueda & "%' " _
            & " ORDER BY nombrepersonal ASC", Conexion)

        Dim Tabla As New DataTable
        Dim Adaptador As New MySqlDataAdapter(cmd)

        Adaptador.Fill(Tabla)

        Return Tabla

    End Function

    Private Sub DataGridView_CellMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DataGridView.CellMouseDoubleClick
        'Al dar dobleclick en cualquier fila
        'se lleva la informacion correspondiente al siguiente formulario

        If DataGridView.RowCount > 0 Then

            If SeguimientoCarga.Visible = True Then
                'si el formulario "RegistroRuta" esta activo, se carga la informacion seleccionada del datagridview

                SeguimientoCarga.TextBox11.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                SeguimientoCarga.TextBox8.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                'Se cierra el formulario ListadoChofer
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If MaestroPersonal.Visible = True Then
                'si el formulario "MaestroChofer" esta activo, se carga la informacion seleccionada del datagridview
                'Llamamos al metodo para obtener los datos del chofer y luego editarlos en el MaestroChofer

                'Guardamos el id en el textbox
                TextBox1.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value()

                'Enviamos datos al formulario
                ObtenerPersonalListado()
                MaestroPersonal.Show()

                MaestroPersonal.BotonModificar.Enabled = True
                MaestroPersonal.BotonGuardar.Enabled = False

                'Se cierra el formulario ListadoChofer
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If ConsultaGeneralRuta.Visible = True Then
                'si el formulario "ConsultaPersonal" esta activo, se carga la informacion seleccionada del datagridview

                ConsultaGeneralRuta.TextBox1.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                'Se cierra el formulario ListadoChofer
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If ConsultaConsumible.Visible = True Then
                'si el formulario "ConsultaPersonal" esta activo, se carga la informacion seleccionada del datagridview

                ConsultaConsumible.TextBox1.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                'Se cierra el formulario ListadoChofer
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If MaestroInfraccion.Visible = True Then
                'si el formulario "MaestroInfraccion" esta activo, se carga la informacion seleccionada del datagridview

                MaestroInfraccion.TextBox6.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                MaestroInfraccion.TextBox4.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                'Se cierra el formulario ListadoChofer
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If MaestroIncidencia.Visible = True Then
                'si el formulario "MaestroInfraccion" esta activo, se carga la informacion seleccionada del datagridview

                MaestroIncidencia.TextBox6.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                MaestroIncidencia.TextBox4.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                'Se cierra el formulario ListadoChofer
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If SeguimientoLiviano.Visible = True Then
                'si el formulario "MaestroChofer" esta activo, se carga la informacion seleccionada del datagridview

                'Si la pestaña de infracciones esta seleccionada enviamos los datos al chofer de infracciones
                If SeguimientoLiviano.Panel5.SelectedIndex = 0 Then

                    SeguimientoLiviano.TextBox6.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                    SeguimientoLiviano.TextBox16.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                    'Si la pestaña de incidencias esta seleccionada enviamos los datos al chofer de incidencias
                ElseIf SeguimientoLiviano.Panel5.SelectedIndex = 1 Then

                    SeguimientoLiviano.TextBox18.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                    SeguimientoLiviano.TextBox17.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                ElseIf SeguimientoLiviano.Panel5.SelectedIndex = 2 Then

                    SeguimientoLiviano.TextBox26.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                    SeguimientoLiviano.TextBox24.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                End If

            End If

            'Se cierra el formulario ListadoPersona
            Tabla.Clear()
            DataSet.Clear()
            Dispose()

        End If

    End Sub

    Private Sub ComboEstadoPersona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboEstadoPersona.SelectedIndexChanged
        'Evento donde seleccionamos el combobox y el elemento se va directamente al textbox
        'inmediatamente cargamos el datagridview para refrescar.

        TextBox1.Text = ComboEstadoPersona.Text
        CargarGridListadoPersonal()

    End Sub

    Private Sub ComboTipoPersona_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboTipoPersona.SelectedIndexChanged
        'Evento donde seleccionamos el combobox y el elemento se va directamente al textbox
        'inmediatamente cargamos el datagridview para refrescar.

        TextBox2.Text = ComboTipoPersona.Text
        CargarGridListadoPersonal()

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

            Dim TipoChofer As String

            'Indicamos sobre cual columna trabajaremos.
            If DataGridView.Columns(e.ColumnIndex).Name.Equals("ColumnaClasificacion") Then

                TipoChofer = (DataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

                If TipoChofer = "CARGA" Then

                    e.CellStyle.ForeColor = Color.Blue

                End If

                If TipoChofer = "LIVIANO" Then

                    e.CellStyle.ForeColor = Color.Green

                End If

                If TipoChofer = "PERSONAL" Then

                    e.CellStyle.ForeColor = Color.Orange

                End If

            End If

        Catch ex As Exception

            MsgBox("No se pudo completar la operación.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub TextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox.KeyDown
        'Evento que permite enfocar el datagridview al presionar la flecha abajo

        If e.KeyCode = Keys.Down Then

            'Enfoque del datagridview
            DataGridView.Focus()

        End If

        'Si la tecla presionada es enter
        If e.KeyCode = Keys.Enter Then

            'Evitamos q se salte una linea al teclear enter
            e.SuppressKeyPress = True

            If DataGridView.RowCount > 0 Then

                If SeguimientoCarga.Visible = True Then
                    'si el formulario "RegistroRuta" esta activo, se carga la informacion seleccionada del datagridview

                    SeguimientoCarga.TextBox11.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                    SeguimientoCarga.TextBox8.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                    'Se cierra el formulario ListadoChofer
                    Tabla.Clear()
                    DataSet.Clear()
                    Dispose()

                End If

                If MaestroPersonal.Visible = True Then
                    'si el formulario "MaestroChofer" esta activo, se carga la informacion seleccionada del datagridview
                    'Llamamos al metodo para obtener los datos del chofer y luego editarlos en el MaestroChofer

                    'Guardamos el id en el textbox
                    TextBox1.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value()

                    'Enviamos datos al formulario
                    ObtenerPersonalListado()
                    MaestroPersonal.Show()

                    MaestroPersonal.BotonModificar.Enabled = True
                    MaestroPersonal.BotonGuardar.Enabled = False

                    'Se cierra el formulario ListadoChofer
                    Tabla.Clear()
                    DataSet.Clear()
                    Dispose()

                End If

                If ConsultaGeneralRuta.Visible = True Then
                    'si el formulario "ConsultaPersonal" esta activo, se carga la informacion seleccionada del datagridview

                    ConsultaConsumible.TextBox1.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                    'Se cierra el formulario ListadoChofer
                    Tabla.Clear()
                    DataSet.Clear()
                    Dispose()

                End If

                If ConsultaConsumible.Visible = True Then
                    'si el formulario "ConsultaPersonal" esta activo, se carga la informacion seleccionada del datagridview

                    ConsultaConsumible.TextBox1.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                    'Se cierra el formulario ListadoChofer
                    Tabla.Clear()
                    DataSet.Clear()
                    Dispose()

                End If

                If MaestroInfraccion.Visible = True Then
                    'si el formulario "MaestroInfraccion" esta activo, se carga la informacion seleccionada del datagridview

                    MaestroInfraccion.TextBox6.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                    MaestroInfraccion.TextBox4.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                    'Se cierra el formulario ListadoChofer
                    Tabla.Clear()
                    DataSet.Clear()
                    Dispose()

                End If

                If MaestroIncidencia.Visible = True Then
                    'si el formulario "MaestroInfraccion" esta activo, se carga la informacion seleccionada del datagridview

                    MaestroIncidencia.TextBox6.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                    MaestroIncidencia.TextBox4.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                    'Se cierra el formulario ListadoChofer
                    Tabla.Clear()
                    DataSet.Clear()
                    Dispose()

                End If

                If SeguimientoLiviano.Visible = True Then
                    'si el formulario "MaestroChofer" esta activo, se carga la informacion seleccionada del datagridview

                    'Si la pestaña de infracciones esta seleccionada enviamos los datos al chofer de infracciones
                    If SeguimientoLiviano.Panel5.SelectedIndex = 0 Then

                        SeguimientoLiviano.TextBox6.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                        SeguimientoLiviano.TextBox16.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                        'Si la pestaña de incidencias esta seleccionada enviamos los datos al chofer de incidencias
                    ElseIf SeguimientoLiviano.Panel5.SelectedIndex = 1 Then

                        SeguimientoLiviano.TextBox18.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                        SeguimientoLiviano.TextBox17.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                    ElseIf SeguimientoLiviano.Panel5.SelectedIndex = 2 Then

                        SeguimientoLiviano.TextBox26.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                        SeguimientoLiviano.TextBox24.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                    End If

                End If

                'Se cierra el formulario ListadoPersona
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

        End If


    End Sub

    Private Sub DataGridView_KeyDown(sender As Object, e As KeyEventArgs) Handles DataGridView.KeyDown
        'Evento que permite seleccionar la fila tecleando enter

        'Si la tecla presionada es enter
        If e.KeyCode = Keys.Enter Then

            'Evitamos q se salte una linea al teclear enter
            e.SuppressKeyPress = True

            If DataGridView.RowCount > 0 Then

                If SeguimientoCarga.Visible = True Then
                    'si el formulario "RegistroRuta" esta activo, se carga la informacion seleccionada del datagridview

                    SeguimientoCarga.TextBox11.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                    SeguimientoCarga.TextBox8.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                    'Se cierra el formulario ListadoChofer
                    Tabla.Clear()
                    DataSet.Clear()
                    Dispose()

                End If

                If MaestroPersonal.Visible = True Then
                    'si el formulario "MaestroChofer" esta activo, se carga la informacion seleccionada del datagridview
                    'Llamamos al metodo para obtener los datos del chofer y luego editarlos en el MaestroChofer

                    'Guardamos el id en el textbox
                    TextBox1.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value()

                    'Enviamos datos al formulario
                    ObtenerPersonalListado()
                    MaestroPersonal.Show()

                    MaestroPersonal.BotonModificar.Enabled = True
                    MaestroPersonal.BotonGuardar.Enabled = False

                    'Se cierra el formulario ListadoChofer
                    Tabla.Clear()
                    DataSet.Clear()
                    Dispose()

                End If

                If ConsultaGeneralRuta.Visible = True Then
                    'si el formulario "ConsultaPersonal" esta activo, se carga la informacion seleccionada del datagridview

                    ConsultaConsumible.TextBox1.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                    'Se cierra el formulario ListadoChofer
                    Tabla.Clear()
                    DataSet.Clear()
                    Dispose()

                End If

                If ConsultaConsumible.Visible = True Then
                    'si el formulario "ConsultaPersonal" esta activo, se carga la informacion seleccionada del datagridview

                    ConsultaConsumible.TextBox1.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                    'Se cierra el formulario ListadoChofer
                    Tabla.Clear()
                    DataSet.Clear()
                    Dispose()

                End If

                If MaestroInfraccion.Visible = True Then
                    'si el formulario "MaestroInfraccion" esta activo, se carga la informacion seleccionada del datagridview

                    MaestroInfraccion.TextBox6.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                    MaestroInfraccion.TextBox4.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                    'Se cierra el formulario ListadoChofer
                    Tabla.Clear()
                    DataSet.Clear()
                    Dispose()

                End If

                If MaestroIncidencia.Visible = True Then
                    'si el formulario "MaestroInfraccion" esta activo, se carga la informacion seleccionada del datagridview

                    MaestroIncidencia.TextBox6.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                    MaestroIncidencia.TextBox4.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                    'Se cierra el formulario ListadoChofer
                    Tabla.Clear()
                    DataSet.Clear()
                    Dispose()

                End If

                If SeguimientoLiviano.Visible = True Then
                    'si el formulario "MaestroChofer" esta activo, se carga la informacion seleccionada del datagridview

                    'Si la pestaña de infracciones esta seleccionada enviamos los datos al chofer de infracciones
                    If SeguimientoLiviano.Panel5.SelectedIndex = 0 Then

                        SeguimientoLiviano.TextBox6.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                        SeguimientoLiviano.TextBox16.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                        'Si la pestaña de incidencias esta seleccionada enviamos los datos al chofer de incidencias
                    ElseIf SeguimientoLiviano.Panel5.SelectedIndex = 1 Then

                        SeguimientoLiviano.TextBox18.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                        SeguimientoLiviano.TextBox17.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                    ElseIf SeguimientoLiviano.Panel5.SelectedIndex = 2 Then

                        SeguimientoLiviano.TextBox26.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                        SeguimientoLiviano.TextBox24.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                    End If

                End If

                'Se cierra el formulario ListadoPersona
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

        End If

    End Sub


End Class