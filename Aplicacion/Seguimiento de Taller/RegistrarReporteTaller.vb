
Public Class RegistrarReporteTaller

    Private Sub RegistrarReporteTaller_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Para escribir las incidencias en mayuscula
        TextBox4.CharacterCasing = CharacterCasing.Upper

    End Sub

    Private Sub RegistrarReporteTaller_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Cierre del formulario

        LimpiarComponentes()
        Dispose()

    End Sub

    Private Sub BotonGuardar_Click(sender As Object, e As EventArgs) Handles BotonGuardar.Click
        'Boton guardar

        Try

            Dim fecha = DateTimePicker1.Value.ToString("yyyy-MM-dd")
            Dim fecha2 = DateTimePicker2.Value.ToString("yyyy-MM-dd")

            If ValidarComponentes() = True Then

                'Registro formal de la ruta con todos sus atributos
                Dim db As New MySqlCommand("INSERT INTO registrotaller (idregistrotaller, vehiculo, fechaingreso, fechasalida, area, falla, estado) VALUES ('" & TextBox1.Text & "', '" & TextBox3.Text & "', '" & fecha & "', '" & fecha2 & "', '" & TextBox5.Text & "', '" & TextBox2.Text & "', 'ABIERTO')", Conexion)
                db.ExecuteNonQuery()

                'Actualizamos el estado del vehiculo
                ActualizarVehiculo()

                MsgBox("Reporte registrado con Exito.", MsgBoxStyle.Information, "Exito.")

                'Se ejecutan los metodos
                LimpiarComponentes()
                SerieTaller()

                'Actualizamos los listados
                CargarGridSeguimientoTaller()
                CargarGridHistorialTaller()
                CargarGridSeguimientoActual()

                'Luego de guardar nos posicionamos en la fila ya seleccionada anteriormente
                'para verificar la inclusion de la ruta en el datagridview2.
                SeguimientoTaller.DataGridView1.CurrentCell = SeguimientoTaller.DataGridView1(ColumnaTaller, FilaTaller)

                'Luego de guardar cerramos la ventana
                Close()

            End If

        Catch ex As Exception

            MsgBox("Debe verificar la información suministrada.", MsgBoxStyle.Exclamation, "Error.")

        End Try

    End Sub

    Private Sub BotonModificar_Click(sender As Object, e As EventArgs) Handles BotonModificar.Click
        'Boton modificar

        Dim db As New MySqlCommand("UPDATE registrotaller SET area = '" & TextBox5.Text & "', falla = '" & TextBox2.Text & "', estado = 'ABIERTO' WHERE idregistrotaller = '" & TextBox1.Text & "' ", Conexion)
        db.ExecuteNonQuery()
        MsgBox("Reporte modificado con Exito.", MsgBoxStyle.Information, "Exito.")

        'Se desactiva el uso del boton modificar.
        BotonModificar.Enabled = False
        'Se activa el uso del boton guardar.
        BotonGuardar.Enabled = True

        'Se limpian todos los componentes del formulario para un nuevo uso.
        LimpiarComponentes()

        'Actualizamos los listados
        CargarGridHistorialTaller()

        'Luego de modificar cerramos la ventana
        Close()

    End Sub

    Private Sub BotonSalir_Click(sender As Object, e As EventArgs) Handles BotonSalir.Click
        'Boton salir

        BotonGuardar.Enabled = True
        Close()

    End Sub

    Private Sub Combo1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Combo1.SelectedIndexChanged
        'Se envia el texto seleccionado en el combobox al textbox

        TextBox5.Text = Combo1.SelectedItem()

    End Sub

    Private Sub LimpiarComponentes()
        'Metodo que permite limpiar todos los elementos del formulario

        TextBox1.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""

    End Sub

    Private Function ValidarComponentes() As Boolean
        'Metodo que permite validar el ingreso de texto en los textbox

        Dim Validar As Boolean = True

        'Limpia todos los mensajes de error mostrados en la interfaz de usuario
        ErrorProvider1.Clear()

        'Valida que el textbox no este nulo o vacio
        If String.IsNullOrEmpty(TextBox1.Text) Then
            ErrorProvider1.SetError(TextBox1, "No puede dejar campos en blanco.")
            Validar = False
        End If

        'Valida que el textbox no este nulo o vacio
        If String.IsNullOrEmpty(TextBox3.Text) Then
            ErrorProvider1.SetError(TextBox3, "No puede dejar campos en blanco.")
            Validar = False
        End If

        'Valida que el textbox no este nulo o vacio
        If String.IsNullOrEmpty(TextBox4.Text) Then
            ErrorProvider1.SetError(TextBox4, "No puede dejar campos en blanco.")
            Validar = False
        End If

        'Valida que el textbox no este nulo o vacio
        If String.IsNullOrEmpty(TextBox5.Text) Then
            ErrorProvider1.SetError(TextBox5, "No puede dejar campos en blanco.")
            Validar = False
        End If

        Return Validar

    End Function

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        'Para trabajar la misma fecha en ambos datetimepicker

        DateTimePicker2.Value = DateTimePicker1.Value

    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged
        'Prueba

        Dim cmd As New MySqlCommand("SELECT nombrefalla FROM falla", Conexion)
        Dim DataTable As New DataTable
        Dim Adaptador As New MySqlDataAdapter(cmd)

        Dim Dato As New AutoCompleteStringCollection
        Adaptador.Fill(DataTable)

        For i = 0 To DataTable.Rows.Count - 1

            Dato.Add(DataTable.Rows(i)("nombrefalla").ToString())

        Next

        TextBox4.AutoCompleteSource = AutoCompleteSource.CustomSource
        TextBox4.AutoCompleteCustomSource = Dato
        TextBox4.AutoCompleteMode = AutoCompleteMode.Suggest

        'Obtenemos el id de la falla
        ObtenerFalla()

    End Sub


End Class