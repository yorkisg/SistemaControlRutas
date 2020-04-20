
Public Class ListadoGeneralRutas

    Private Sub ListadoGeneralRutas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Metodos que cargaran al momento de desplegar el formulario.

        'Se llama el metodo para alternar colores entre filas
        AlternarFilasGeneral(DataGridView)
        AlternarFilasGeneral(DataGridView1)

        'Se llama al metodo para que cargue rapido el datagridview
        EnableDoubleBuffered(DataGridView)
        EnableDoubleBuffered(DataGridView1)

        'Quitamos la seleccion de cualquier fila del datagridview
        DataGridView.ClearSelection()
        DataGridView1.ClearSelection()

        'Se cargan los elementos generales
        'CargarGridGeneralVehiculo()
        'CargarGridResumenVehiculo()

        'Carga del combobox de los grupos
        CargarComboGrupo()

    End Sub

    Private Sub ListadoGeneralVehiculo_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Cierre del formulario

        Dispose()

    End Sub

    Private Sub BotonExportar_Click(sender As Object, e As EventArgs) Handles BotonExportar.Click
        'Boton Exportar a Excel

        Try

            If DataGridView.RowCount > 0 Or DataGridView1.RowCount > 0 Then

                Dim Mensaje As DialogResult

                Mensaje = MessageBox.Show("Desea expotar el listado?", "Aviso.", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

                'Si la respuesta es "Si"
                If Mensaje = DialogResult.Yes Then

                    Exportar(DataGridView)
                    Exportar(DataGridView1)

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

        If DataGridView.RowCount > 0 Or DataGridView1.RowCount > 0 Then
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

    Private Sub DataGridView_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView.CellFormatting
        'CellFormatting: Propiedad del control DataGridview el cual permite cambiar 
        'y dar formato a las celdas, bien sea por color de texto, fondo, etc.

        Dim TipoEstado As String

        'Indicamos sobre cual columna trabajaremos.
        If DataGridView.Columns(e.ColumnIndex).Name.Equals("ColumnaEstado") Then

            'Captura el valor de la celda 
            TipoEstado = (DataGridView.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

            'Verificamos los valores del estado y asignamos los colores e iconos.
            If TipoEstado = "EN RUTA VACIO" Or TipoEstado = "EN RUTA CARGADO" Then

                'Colocamos color a la celda de acuerdo al valor obtenido
                e.CellStyle.ForeColor = Color.Green

            End If

            If TipoEstado = "DE REGRESO CARGADO" Or TipoEstado = "DE REGRESO VACIO" Then

                'Colocamos color a la celda de acuerdo al valor obtenido
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

    End Sub

    Private Sub DataGridView1_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles DataGridView1.CellFormatting
        'CellFormatting: Propiedad del control DataGridview el cual permite cambiar 
        'y dar formato a las celdas, bien sea por color de texto, fondo, etc.

        Dim TipoEstado As String

        'Indicamos sobre cual columna trabajaremos.
        If DataGridView1.Columns(e.ColumnIndex).Name.Equals("ColumnaEstado2") Then

            'Captura el valor de la celda 
            TipoEstado = (DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value)

            'Verificamos los valores del estado y asignamos los colores e iconos.
            If TipoEstado = "EN RUTA VACIO" Or TipoEstado = "EN RUTA CARGADO" Then

                'Colocamos color a la celda de acuerdo al valor obtenido
                e.CellStyle.ForeColor = Color.Green

            End If

            If TipoEstado = "DE REGRESO CARGADO" Or TipoEstado = "DE REGRESO VACIO" Then

                'Colocamos color a la celda de acuerdo al valor obtenido
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

    End Sub

    Private Sub LimpiarComponentes()
        'Metodo que permite limpiar todos los controles del formulario.

        'Abrimos el ciclo que recorre todas las filas del datagridview
        For i As Integer = 0 To DataGridView.RowCount - 1
            'Eliminamos elemento por elemento
            DataGridView.Rows.Remove(DataGridView.CurrentRow)
        Next

        For i As Integer = 0 To DataGridView1.RowCount - 1
            'Eliminamos elemento por elemento
            DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
        Next

    End Sub

    Private Sub CargarComboGrupo()
        'Metodo que permite cargar el Combobox desde la BD.

        Dim Tabla As New DataTable
        Dim Adaptador As New MySqlDataAdapter

        Adaptador = New MySqlDataAdapter("SELECT idgrupo, nombregrupo " _
                                    & " FROM subflota, grupo " _
                                    & " WHERE grupo.subflota = subflota.idsubflota " _
                                    & " AND tiposubflota = 'CARGA' ", Conexion)

        Adaptador.Fill(Tabla)

        'Este codigo inserta un valor no perteneciente al DATATABLE q trae la informacion de la BD
        Dim row As DataRow = Tabla.NewRow()
        row(0) = 0

        'Este es el valor que insertamos
        row(1) = "--- TODOS LOS GRUPOS ---"
        Tabla.Rows.InsertAt(row, 0)

        With ComboGrupo.ComboBox

            .DataSource = Tabla
            .DisplayMember = "nombregrupo"
            .ValueMember = "idgrupo"
            .SelectedIndex = 0

        End With

    End Sub

    Private Sub ComboGrupo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboGrupo.SelectedIndexChanged

        'Enviamos el texto seleccionado del combobox al textbox
        TextBox1.Text = ComboGrupo.ComboBox.Text

        'si el item seleccionado es el primero
        If TextBox1.Text = "--- TODOS LOS GRUPOS ---" Then

            'Se cargan los elementos generales
            CargarGridGeneralVehiculo()
            CargarGridResumenVehiculo()

        ElseIf TextBox1.Text <> "--- TODOS LOS GRUPOS ---" Then

            'Se cargan los elementos por grupo
            CargarGridGeneralVehiculoGrupo()
            CargarGridResumenVehiculoGrupo()

        End If

    End Sub


End Class