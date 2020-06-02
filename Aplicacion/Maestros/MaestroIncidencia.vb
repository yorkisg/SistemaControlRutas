
Public Class MaestroIncidencia

    Private Sub MaestroIncidencia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Metodos que cargaran al momento de desplegar el formulario.

        'Se habilita la serie correlativa para el siguiente ID.
        Serie()

        'Validamos que en cada Textbox del formulario solo se agregue texto en mayusculas.
        TextBox3.CharacterCasing = CharacterCasing.Upper

    End Sub

    Private Sub MaestroIncidencia_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Cierre del formulario

        LimpiarComponentes()
        Dispose()

    End Sub

    Private Sub BotonGuardar_Click(sender As Object, e As EventArgs) Handles BotonGuardar.Click
        'Boton registrar

        Dim fecha = DateTimePicker1.Value.ToString("yyyy-MM-dd")

        'Se valida que no haya algun campo vacio
        If ValidarComponentes() = True Then

            Dim db As New MySqlCommand("INSERT INTO registroincidencia (idregistroincidencia, vehiculo, personal, descripcion, tipo, clasificacion, fecha, hora) " _
            & " VALUES ('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox6.Text & "', '" & TextBox3.Text & "', '" & TextBox8.Text & "', '" & TextBox7.Text & "', '" & fecha & "', '" & TextBox5.Text & "')", Conexion)

            db.ExecuteNonQuery()
            MsgBox("Incidencia registrada con Exito.", MsgBoxStyle.Information, "Exito.")

            'Se limpian todos los componentes del formulario para un nuevo uso.
            LimpiarComponentes()
            'Se habilita el metodo para incrementar el siguiente ID.
            Serie()

            'Si la llamada proviene del formulario RegistroRuta, entonces se cierra al modificar el registro seleccionado
            If SeguimientoCarga.Visible = True Or SeguimientoLiviano.Visible = True Then

                Dispose()

            End If

        End If

    End Sub

    Private Sub BotonBuscar_Click(sender As Object, e As EventArgs) Handles BotonBuscar.Click
        'Boton buscar

        ListadoVehiculo.ShowDialog()

    End Sub

    Private Sub BotonBuscar2_Click(sender As Object, e As EventArgs) Handles BotonBuscar2.Click
        'Boton buscar

        ListadoPersonal.ShowDialog()

    End Sub

    Private Sub BotonSalir_Click(sender As Object, e As EventArgs) Handles BotonSalir.Click
        'Boton salir

        LimpiarComponentes()
        BotonBuscar.Enabled = True
        Dispose()

    End Sub

    Private Sub Serie()
        'Metodo que permite generar una serie correlativa de numeros enteros. 
        'Usado para generar automaticamente el ID.

        'Se obtiene el ultimo ID.
        Dim Command As New MySqlCommand("SELECT MAX(idregistroincidencia) FROM registroincidencia", Conexion)
        Dim numero As Integer

        'El ID obtenido de la BD se incrementa.
        numero = Command.ExecuteScalar
        numero = numero + 1

        'Se da formato al ID obtenido de la BD.
        TextBox1.Text = Format(numero, ("000000000"))

    End Sub

    Private Sub LimpiarComponentes()
        'Metodo que permite limpiar todos los controles del formulario.

        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""

    End Sub

    Function ValidarComponentes() As Boolean

        Dim Validar As Boolean = True

        'Limpia todos los mensajes de error mostrados en la interfaz de usuario
        ErrorProvider1.Clear()

        'Valida que el textbox no este nulo o vacio
        If String.IsNullOrEmpty(TextBox2.Text) Then
            ErrorProvider1.SetError(TextBox2, "No puede dejar campos en blanco.")
            Validar = False
        End If

        'Valida que el textbox no este nulo o vacio
        If String.IsNullOrEmpty(TextBox3.Text) Then
            ErrorProvider1.SetError(TextBox3, "No puede dejar campos en blanco.")
            Validar = False
        End If

        'Valida que el textbox no este nulo o vacio
        If String.IsNullOrEmpty(TextBox6.Text) Then
            ErrorProvider1.SetError(TextBox6, "No puede dejar campos en blanco.")
            Validar = False
        End If

        If String.IsNullOrEmpty(ComboTipo.Text) Then
            ErrorProvider1.SetError(ComboTipo, "No puede dejar campos en blanco.")
            Validar = False
        End If

        Return Validar

    End Function

    Private Sub ComboTipo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboTipo.SelectedIndexChanged
        'Para enviar el texto seleccionado al textbox

        TextBox8.Text = ComboTipo.SelectedItem

    End Sub

    Private Sub TextBox3_TextChanged(sender As Object, e As EventArgs) Handles TextBox3.TextChanged
        'Para contar los caracteres en el textbox

        Label9.Text = Len(TextBox3.Text)

    End Sub


End Class