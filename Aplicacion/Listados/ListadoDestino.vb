
Public Class ListadoDestino

    Private Sub ListadoDestino_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Metodos que cargaran al momento de desplegar el formulario.

        'Se llama el metodo para alternar colores entre filas
        AlternarFilasGeneral(DataGridView)

        'Se llama al metodo en el Load del formulario para que el datagridview cargue los datos inmediatamente
        CargarGridListadoDestino()

        'Se llama al metodo para que cargue rapido el datagridview
        EnableDoubleBuffered(DataGridView)

    End Sub

    Private Sub ListadoDestino_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
                'si el formulario "RegistroRuta" esta activo, se carga la informacion seleccionada del datagridview.

                SeguimientoCarga.TextBox13.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                SeguimientoCarga.TextBox7.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                'Se cierra el formulario Listadositiocarga.
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If MaestroSitioCarga.Visible = True Then
                'si el formulario "Maestrositiocarga" esta activo, se carga la informacion seleccionada del datagridview.

                MaestroSitioCarga.TextBox1.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                MaestroSitioCarga.TextBox2.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                'Se activa el uso del boton modificar del formulario "Maestrositiocarga"
                MaestroSitioCarga.BotonModificar.Enabled = True
                'Se desactiva el uso del boton guardar del formulario "Maestrositiocarga"
                MaestroSitioCarga.BotonGuardar.Enabled = False

                'Se cierra el formulario Listadositiocarga.
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

                    ExportarAExcell(DataGridView)

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

        Dim cmd As New MySqlCommand("SELECT iddestino, nombredestino FROM destino WHERE nombredestino LIKE '%" & busqueda & "%' ", cnn)

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

                'si el formulario "RegistroRuta" esta activo, se carga la informacion seleccionada del datagridview.

                SeguimientoCarga.TextBox13.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                SeguimientoCarga.TextBox7.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                'Se cierra el formulario Listadositiocarga.
                Tabla.Clear()
                DataSet.Clear()
                Dispose()

            End If

            If MaestroSitioCarga.Visible = True Then
                'si el formulario "Maestrositiocarga" esta activo, se carga la informacion seleccionada del datagridview.

                MaestroSitioCarga.TextBox1.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(0).Value
                MaestroSitioCarga.TextBox2.Text = DataGridView.Rows(DataGridView.CurrentRow.Index).Cells(1).Value

                'Se activa el uso del boton modificar del formulario "Maestrositiocarga"
                MaestroSitioCarga.BotonModificar.Enabled = True
                'Se desactiva el uso del boton guardar del formulario "Maestrositiocarga"
                MaestroSitioCarga.BotonGuardar.Enabled = False

                'Se cierra el formulario Listadositiocarga.
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


End Class
