
Public Class MaestroSitioCarga

    Private Sub Maestrositiocarga_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Metodos que cargaran al momento de desplegar el formulario.

        'Se habilita la serie correlativa para el siguiente ID.
        Serie()

        'Se inhabilita el boton modificar.
        BotonModificar.Enabled = False

        'Validamos que en cada Textbox del formulario solo se agregue texto en mayusculas.
        TextBox1.CharacterCasing = CharacterCasing.Upper
        TextBox2.CharacterCasing = CharacterCasing.Upper

        'Apoyo para poder registrar dos veces el mismo ID en tres tablas diferentes
        TextBox3.Text = TextBox1.Text

    End Sub

    Private Sub MaestroSitioCarga_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Cierre del formulario

        LimpiarComponentes()
        BotonBuscar.Enabled = True
        Dispose()

    End Sub

    Private Sub MaestroSitioCarga_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles MyBase.KeyDown
        'Evento que permite cerrar el formulario presionando la tecla esc

        If (e.KeyCode = Keys.Escape) Then
            'Cierre del formulario

            LimpiarComponentes()
            BotonBuscar.Enabled = True
            Dispose()

        End If

    End Sub

    Private Sub BotonGuardar_Click(sender As Object, e As EventArgs) Handles BotonGuardar.Click
        'Boton registrar

        'Se valida que no haya algun campo vacio
        If ValidarComponentes() = True Then

            Dim db As New MySqlCommand("INSERT INTO sitiocarga (idsitiocarga, nombresitiocarga) VALUES ('" & TextBox1.Text & "', '" & TextBox2.Text & "')", Conexion)
            db.ExecuteNonQuery()

            Dim db2 As New MySqlCommand("INSERT INTO destino (iddestino, nombredestino) VALUES ('" & TextBox3.Text & "', '" & TextBox2.Text & "')", Conexion)
            db2.ExecuteNonQuery()

            MsgBox("Ubicación registrada con Exito.", MsgBoxStyle.Information, "Exito.")

            'Se limpian todos los componentes del formulario para un nuevo uso.
            LimpiarComponentes()
            'Se habilita el metodo para incrementar el siguiente ID.
            Serie()

        End If

        'Si la llamada proviene del formulario RegistroRuta, entonces se cierra al modificar el registro seleccionado
        If SeguimientoCarga.Visible = True Then

            Dispose()

        End If

    End Sub

    Private Sub BotonModificar_Click(sender As Object, e As EventArgs) Handles BotonModificar.Click
        'Boton modificar

        'Se valida que no haya algun campo vacio
        If ValidarComponentes() = True Then

            Dim db As New MySqlCommand("UPDATE sitiocarga SET nombresitiocarga = '" & TextBox2.Text & "' WHERE idsitiocarga = '" & TextBox1.Text & "' ", Conexion)
            db.ExecuteNonQuery()

            Dim db2 As New MySqlCommand("UPDATE destino SET nombredestino = '" & TextBox2.Text & "' WHERE iddestino = '" & TextBox1.Text & "' ", Conexion)
            db2.ExecuteNonQuery()

            MsgBox("Ubicación modificada con Exito.", MsgBoxStyle.Information, "Exito.")

            'Se desactiva el uso del boton modificar.
            BotonModificar.Enabled = False
            'Se activa el uso del boton guardar.
            BotonGuardar.Enabled = True
            'Se limpian todos los componentes del formulario para un nuevo uso.
            LimpiarComponentes()
            'Se habilita el metodo para incrementar el siguiente ID.
            Serie()

        End If

    End Sub

    Private Sub BotonBuscar_Click(sender As Object, e As EventArgs) Handles BotonBuscar.Click
        'Boton buscar

        Listadositiocarga.ShowDialog()

    End Sub

    Private Sub BotonSalir_Click(sender As Object, e As EventArgs) Handles BotonSalir.Click
        'Boton salir

        LimpiarComponentes()
        BotonBuscar.Enabled = True
        Dispose()

    End Sub

    Private Sub LimpiarComponentes()
        'Metodo que permite limpiar todos los controles del formulario.

        'TextBox1.Text = ""
        TextBox2.Text = ""

    End Sub

    Private Sub Serie()
        'Metodo que permite generar una serie correlativa de numeros enteros. 
        'Usado para generar automaticamente el ID de un producto.

        'Se obtiene el ultimo ID del chofer.
        Dim Command As New MySqlCommand("SELECT MAX(idsitiocarga) FROM sitiocarga", Conexion)
        Dim numero As Integer

        'El ID obtenido de la BD se incrementa.
        numero = Command.ExecuteScalar
        numero = numero + 1

        'Se da formato al ID obtenido de la BD.
        TextBox1.Text = Format(numero, "000000000")

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

        Return Validar

    End Function

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        'Evento de apoyo para poder guardar tres veces el mismo ID

        TextBox3.Text = TextBox1.Text

    End Sub


End Class
