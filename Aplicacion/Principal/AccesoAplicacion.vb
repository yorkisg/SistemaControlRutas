
Public Class AccesoAplicacion

    Private Sub Acceso_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Instancia principal de la conexion de la BD.
        ConectarBaseDeDatos()

        'Validamos que en cada Textbox del formulario solo se agregue texto en mayusculas.
        TextBox1.CharacterCasing = CharacterCasing.Upper

        'Instancia del metodo que evita que el ejecutable se abra 2 veces
        Instancia()

    End Sub

    Private Sub AccesoAplicacion_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Cierre formal del formulario

        'Desconexion de la BD y cierre de la aplicacion.
        DesconectarBaseDeDatos()

        Close()

    End Sub

    Private Sub BotonEntrar_Click(sender As Object, e As EventArgs) Handles BotonEntrar.Click
        'Boton Login

        Acceso()

    End Sub

    Private Sub Acceso()
        'Metodo que hace una consulta a la BD para accesar a la aplicacion

        Dim sql As String = "SELECT * FROM usuario WHERE usuario=@usuario"

        Dim connection As New MySqlConnection(ConnectionString)

        Command = New MySqlCommand(sql, connection)
        Command.Parameters.Add("@usuario", MySqlDbType.String).Value = TextBox1.Text
        Adaptador = New MySqlDataAdapter(Command)

        Dim dt As DataTable = New DataTable()
        Adaptador.Fill(dt)

        If dt.Rows.Count > 0 Then

            If dt.Rows(0).Item("password") <> TextBox2.Text Then

                MsgBox("Contraseña incorrecta.", MsgBoxStyle.Exclamation, "Error.")
                LimpiarComponentes()

            Else

                Dim rol As String = dt.Rows(0)("rol").ToString()

                If rol = "ANALISTA" Then

                    'Enviamos el usuario al label "rolusuario" para posteriormente enviarlo al toolstrip de menuprincipal
                    rolusuario.Text = "ANALISTA"

                ElseIf rol = "ADMINISTRADOR" Then

                    'Enviamos el usuario al label "rolusuario" para posteriormente enviarlo al toolstrip de menuprincipal
                    rolusuario.Text = "ADMINISTRADOR"

                ElseIf rol = "VISITANTE" Then

                    'Enviamos el usuario al label "rolusuario" para posteriormente enviarlo al toolstrip de menuprincipal
                    rolusuario.Text = "VISITANTE"

                End If

                MsgBox("Bienvenido al Sistema de Gestión de Rutas.", MsgBoxStyle.Information, "Bienvenido.")

                'Una vez aceptado el mensaje de bienvenida, se despliega el menu principal y se cierra la conexion del login
                Dim formulario As MenuPrincipal = New MenuPrincipal
                formulario.Show()

                Hide()

            End If

        Else

            MsgBox("Usuario incorrecto.", MsgBoxStyle.Exclamation, "Error.")
            LimpiarComponentes()

        End If

    End Sub

    Private Sub BotonSalir_Click(sender As Object, e As EventArgs) Handles BotonSalir.Click
        'Boton Salir

        'Desconexion de la BD y cierre de la aplicacion.
        DesconectarBaseDeDatos()

        Close()

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
        If String.IsNullOrEmpty(TextBox1.Text) Then
            ErrorProvider1.SetError(TextBox1, "No puede dejar campos en blanco.")
            Validar = False
        End If

        Return Validar

    End Function

    Private Sub LimpiarComponentes()
        'Metodo que permite limpiar todos los controles del formulario.

        TextBox1.Text = ""
        TextBox2.Text = ""

    End Sub

    Private Sub TextBox2_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox2.KeyDown
        'Evento que permite escribir en los textbox y presionar el boton login con la tecla enter

        If e.KeyCode = Keys.Enter Then

            BotonEntrar_Click(Me, EventArgs.Empty)

        End If

    End Sub


End Class