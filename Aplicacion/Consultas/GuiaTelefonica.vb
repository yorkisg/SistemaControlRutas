
Public Class GuiaTelefonica

    Private Sub GuiaTelefonica_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Metodos que cargaran al momento de desplegar el formulario.

        'Se llama el metodo para alternar colores entre filas
        AlternarFilasGeneral(DataGridView1)
        AlternarFilasGeneral(DataGridView2)
        AlternarFilasGeneral(DataGridView3)

        'Se llama al metodo para que cargue rapido el datagridview
        EnableDoubleBuffered(DataGridView1)
        EnableDoubleBuffered(DataGridView2)
        EnableDoubleBuffered(DataGridView3)

        'Decimos que el primer elemento activo del combo es "Activo"
        ComboEstadoChofer.SelectedItem = "ACTIVO"

    End Sub

    Private Sub GuiaTelefonica_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Cierre del formulario

        If DataGridView1.RowCount > 0 Or DataGridView3.RowCount > 0 Then
            'Si el datagridview contiene datos, obtenemos recursos 
            'liberando los datatable y dataset implementados.

            LimpiarComponentes()
            Tabla.Clear()
            DataSet.Clear()
            Dispose()

        Else

            Close()

        End If

    End Sub

    Private Sub BotonExportar_Click(sender As Object, e As EventArgs) Handles BotonExportar.Click
        'Boton Exportar a Excel

        Try

            If DataGridView1.RowCount > 0 Or DataGridView3.RowCount > 0 Then

                Dim Mensaje As DialogResult

                Mensaje = MessageBox.Show("Desea expotar el listado?", "Aviso.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                'Si la respuesta es "Si"
                If Mensaje = DialogResult.Yes Then

                    If Panel8.SelectedIndex = 0 Then

                        Exportar(DataGridView1)

                    ElseIf Panel8.SelectedIndex = 1 Then

                        Exportar(DataGridView2)

                    ElseIf Panel8.SelectedIndex = 2 Then

                        Exportar(DataGridView3)

                    End If

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

        If DataGridView1.RowCount > 0 Or DataGridView3.RowCount > 0 Then
            'Si el datagridview contiene datos, obtenemos recursos 
            'liberando los datatable y dataset implementados.

            LimpiarComponentes()
            Tabla.Clear()
            DataSet.Clear()
            Dispose()

        Else

            Close()

        End If

    End Sub

    Private Sub TextBox_TextChanged(sender As Object, e As EventArgs) Handles TextBox.TextChanged
        'TextBox que permite filtrar de acuerdo a lo establecido en la funcion "Filtrar".

        'Al seleccionar la primera pestaña filtramos de acuerdo al chofer
        If Panel8.SelectedIndex = 0 Then

            If Filtrar1(TextBox.Text).Rows.Count > 0 Then
                DataGridView1.DataSource = Filtrar1(TextBox.Text)
            End If

            'Al seleccionar la segunda pestaña filtramos de acuerdo al personal
        ElseIf Panel8.SelectedIndex = 1 Then

            If Filtrar2(TextBox.Text).Rows.Count > 0 Then
                DataGridView2.DataSource = Filtrar2(TextBox.Text)
            End If

            'Al seleccionar la segunda pestaña filtramos de acuerdo al personal
        ElseIf Panel8.SelectedIndex = 2 Then

            If Filtrar3(TextBox.Text).Rows.Count > 0 Then
                DataGridView3.DataSource = Filtrar3(TextBox.Text)
            End If

        End If

    End Sub

    Function Filtrar1(ByVal busqueda As String) As DataTable
        'Funcion que carga los datos de acuerdo a lo ingresado en el TextBox
        'Para filtrar choferes

        Dim cmd As New MySqlCommand("SELECT idchofer, nombrechofer, if(telefono1 <> 'N/A', (concat(LEFT(telefono1,4),' - ', RIGHT(telefono1,7))), 'N/A') AS 'Telefono1', " _
            & " if(telefono2 <> 'N/A', (concat(LEFT(telefono2,4),' - ', RIGHT(telefono2,7))), 'N/A') AS 'Telefono2', estadochofer FROM chofer " _
            & " WHERE nombrechofer LIKE '%" & busqueda & "%' " _
            & " AND tipochofer = 'CARGA' " _
            & " AND (estadochofer LIKE ('" & TextBox1.Text & "%')) ", cnn)

        Dim dt As New DataTable
        Dim da As New MySqlDataAdapter(cmd)

        da.Fill(dt)
        Return dt

    End Function

    Function Filtrar2(ByVal busqueda As String) As DataTable
        'Funcion que carga los datos de acuerdo a lo ingresado en el TextBox
        'Para filtrar choferes

        Dim cmd As New MySqlCommand("SELECT idchofer, nombrechofer, if(telefono1 <> 'N/A', (concat(LEFT(telefono1,4),' - ', RIGHT(telefono1,7))), 'N/A') AS 'Telefono1', " _
            & " if(telefono2 <> 'N/A', (concat(LEFT(telefono2,4),' - ', RIGHT(telefono2,7))), 'N/A') AS 'Telefono2', estadochofer FROM chofer " _
            & " WHERE nombrechofer LIKE '%" & busqueda & "%' " _
            & " AND tipochofer = 'LIVIANO' " _
            & " AND (estadochofer LIKE ('" & TextBox1.Text & "%')) ", cnn)

        Dim dt As New DataTable
        Dim da As New MySqlDataAdapter(cmd)

        da.Fill(dt)
        Return dt

    End Function

    Function Filtrar3(ByVal busqueda2 As String) As DataTable
        'Funcion que carga los datos de acuerdo a lo ingresado en el TextBox
        'Para filtrar personal

        Dim cmd As New MySqlCommand("SELECT idpersona, nombrepersona, if(telefono1 <> 'N/A', (concat(LEFT(telefono1,4),' - ', RIGHT(telefono1,7))), 'N/A') AS 'Telefono1', " _
                            & " if(telefono2 <> 'N/A', (concat(LEFT(telefono2,4),' - ', RIGHT(telefono2,7))), 'N/A') AS 'Telefono2', descripcion " _
                            & " FROM personal " _
                            & " WHERE nombrepersona LIKE '%" & busqueda2 & "%' ", cnn)

        Dim dt As New DataTable
        Dim da As New MySqlDataAdapter(cmd)

        da.Fill(dt)
        Return dt

    End Function

    Private Sub ComboEstadoChofer_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboEstadoChofer.SelectedIndexChanged
        'Evento donde seleccionamos el combobox y el elemento se va directamente al textbox
        'inmediatamente cargamos el datagridview para refrescar.

        TextBox1.Text = ComboEstadoChofer.Text
        CargarGridGuiaChoferCarga()
        CargarGridGuiaChoferLiviano()

    End Sub

    Private Sub Panel8_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Panel8.SelectedIndexChanged
        'Evento donde se seleccionan los tabs del tabcontrol (paginas) y luego se cargan metodos dependiendo del index del tab

        If Panel8.SelectedIndex = 0 Then

            ComboEstadoChofer.Enabled = True
            TextBox.Text = ""
            CargarGridGuiaChoferCarga()

        ElseIf Panel8.SelectedIndex = 1 Then

            ComboEstadoChofer.Enabled = True
            TextBox.Text = ""
            CargarGridGuiaChoferLiviano()

        ElseIf Panel8.SelectedIndex = 2 Then

            ComboEstadoChofer.Enabled = False
            TextBox.Text = ""
            CargarGridGuiaPersona()

        End If

    End Sub

    Private Sub LimpiarComponentes()
        'Metodo que permite limpiar todos los controles del formulario.

        'Abrimos el ciclo que recorre todas las filas del datagridview
        For i As Integer = 0 To DataGridView1.RowCount - 1
            'Eliminamos elemento por elemento
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        Next

        'Abrimos el ciclo que recorre todas las filas del datagridview
        For i As Integer = 0 To DataGridView3.RowCount - 1
            'Eliminamos elemento por elemento
            DataGridView3.Rows.Remove(DataGridView3.CurrentRow)
        Next

    End Sub

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        'Llamamos al metodo para obtener los datos del chofer y luego editarlos en el MaestroChofer

        'Guardamos el id en el textbox
        TextBox2.Text = DataGridView1.Rows(DataGridView1.CurrentRow.Index).Cells(0).Value()

        'Enviamos datos al formulario
        ObtenerChoferGuiaTelefonica()

        MaestroChofer.BotonModificar.Enabled = True
        MaestroChofer.BotonGuardar.Enabled = False

        MaestroChofer.ShowDialog()

    End Sub

    Private Sub DataGridView2_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView2.CellDoubleClick
        'Llamamos al metodo para obtener los datos del chofer y luego editarlos en el MaestroChofer

        'Guardamos el id en el textbox
        TextBox2.Text = DataGridView2.Rows(DataGridView2.CurrentRow.Index).Cells(0).Value()

        'Enviamos datos al formulario
        ObtenerChoferGuiaTelefonica()

        MaestroChofer.BotonModificar.Enabled = True
        MaestroChofer.BotonGuardar.Enabled = False

        MaestroChofer.ShowDialog()

    End Sub

    Private Sub DataGridView3_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView3.CellDoubleClick
        'Llamamos al metodo para obtener los datos del chofer y luego editarlos en el MaestroChofer

        'Guardamos el id en el textbox
        TextBox2.Text = DataGridView3.Rows(DataGridView3.CurrentRow.Index).Cells(0).Value()

        'Enviamos datos al formulario
        ObtenerPersonaGuiaTelefonica()

        MaestroPersona.BotonModificar.Enabled = True
        MaestroPersona.BotonGuardar.Enabled = False

        MaestroPersona.ShowDialog()

    End Sub


End Class