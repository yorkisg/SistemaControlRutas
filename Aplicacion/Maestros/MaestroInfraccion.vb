
Public Class MaestroInfraccion

    Private Sub MaestroInfraccion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Metodos que cargaran al momento de desplegar el formulario.

        'Se habilita la serie correlativa para el siguiente ID.
        Serie()

        'Validamos que en cada Textbox del formulario solo se agregue texto en mayusculas.
        TextBox1.CharacterCasing = CharacterCasing.Upper
        TextBox2.CharacterCasing = CharacterCasing.Upper
        TextBox7.CharacterCasing = CharacterCasing.Upper

    End Sub

    Private Sub MaestroInfraccion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Cierre del formulario

        LimpiarComponentes()
        Dispose()

    End Sub

    Private Sub MaestroInfraccion_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        'Evento que permite cerrar el formulario presionando la tecla esc

        If (e.KeyCode = Keys.Escape) Then

            LimpiarComponentes()
            Dispose()

        End If

    End Sub

    Private Sub BotonGuardar_Click(sender As Object, e As EventArgs) Handles BotonGuardar.Click
        'Boton registrar

        Dim fecha = DateTimePicker1.Value.ToString("yyyy-MM-dd")

        'Se valida que no haya algun campo vacio
        If ValidarComponentes() = True Then

            Dim db As New MySqlCommand("INSERT INTO registroinfraccion (idregistroinfraccion, vehiculo, personal, velocidad, estadovehiculo, fecha, hora) VALUES ('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox6.Text & "', '" & TextBox3.Text & "', '" & TextBox7.Text & "', '" & fecha & "', '" & TextBox5.Text & "')", Conexion)
            db.ExecuteNonQuery()
            MsgBox("Infracción registrada con Exito.", MsgBoxStyle.Information, "Exito.")

            'Se limpian todos los componentes del formulario para un nuevo uso.
            LimpiarComponentes()
            'Se habilita el metodo para incrementar el siguiente ID.
            Serie()

            'Actualizamos la lista
            'CargarGridHistorialInfraccionLiviano()

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
        BotonBuscar2.Enabled = True
        Dispose()

    End Sub

    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        'Evento KeyPress: permite agregar solo numeros en el textbox.

        If Char.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf Char.IsControl(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar = "." And Not TextBox3.Text.IndexOf(".") Then
            e.Handled = True
        ElseIf e.KeyChar = "." Then
            e.Handled = False
        Else
            e.Handled = True
        End If

    End Sub

    Private Sub LimpiarComponentes()
        'Metodo que permite limpiar todos los controles del formulario.

        'TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""

        RadioButton1.Checked = False
        RadioButton2.Checked = False

    End Sub

    Private Sub Serie()
        'Metodo que permite generar una serie correlativa de numeros enteros. 
        'Usado para generar automaticamente el ID.

        'Se obtiene el ultimo ID.
        Dim Command As New MySqlCommand("SELECT MAX(idregistroinfraccion) FROM registroinfraccion", Conexion)
        Dim numero As Integer

        'El ID obtenido de la BD se incrementa.
        numero = Command.ExecuteScalar
        numero = numero + 1

        'Se da formato al ID obtenido de la BD.
        TextBox1.Text = numero

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
        If String.IsNullOrEmpty(TextBox4.Text) Then
            ErrorProvider1.SetError(TextBox4, "No puede dejar campos en blanco.")
            Validar = False
        End If

        'Valida que el textbox no este nulo o vacio
        If String.IsNullOrEmpty(TextBox5.Text) Then
            ErrorProvider1.SetError(TextBox5, "No puede dejar campos en blanco.")
            Validar = False
        End If

        If RadioButton1.Checked = False And RadioButton2.Checked = False Then
            ErrorProvider1.SetError(RadioButton1, "No puede dejar campos en blanco.")
            ErrorProvider1.SetError(RadioButton2, "No puede dejar campos en blanco.")
            Validar = False
        End If

        Return Validar

    End Function

    Private Sub RadioButton1_Click(sender As Object, e As EventArgs) Handles RadioButton1.Click
        'Pasamos el texto del RadioButton al textbox para poder hacer insert into

        TextBox7.Text = "CARGADO"

    End Sub

    Private Sub RadioButton2_Click(sender As Object, e As EventArgs) Handles RadioButton2.Click
        'Pasamos el texto del RadioButton al textbox para poder hacer insert into

        TextBox7.Text = "VACIO"

    End Sub


End Class