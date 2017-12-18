Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class FrmLogin
    Sub ClearText()
        txtCode.Clear()
        txtPassword.Clear()
    End Sub
    Function CheckIsEmpty() As Boolean
        If Trim(txtCode.Text) = String.Empty Then
            MsgBoxWarning("Please fill user code")
            txtCode.Focus()
            Return True
        ElseIf Trim(txtPassword.Text) = String.Empty Then
            MsgBoxWarning("Please fill password")
            txtPassword.Focus()
            Return True
        Else
            Return False
        End If
    End Function

    Sub ValidasiLogin()
        Dim dac As DataAccess = New DataAccess
        Dim query As String
        query = "Select UserCode,UserName,UserPassword,AccessLevel from users where usercode = '" & txtCode.Text & "' and UserPassword = '" & dac.Encrypted(txtPassword.Text, keysEncryp) & "'"
        Try
            Dim drUsers As MySqlDataReader
            drUsers = dac.ExecuteReader(query)
            drUsers.Read()
            If drUsers.HasRows Then
                userCode = drUsers.Item("UserCode")
                userName = drUsers.Item("UserName")
                userAccess = drUsers.Item("AccessLevel")
                MsgBoxInformation("Login successfully")
                MenuUtama.Show()
                Hide()
            Else
                MsgBoxWarning("Login failed,please check username or password")
                txtCode.Focus()
            End If
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        ValidasiLogin()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub txtCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCode.KeyPress
        If e.KeyChar = Chr(13) Then
            txtPassword.Focus()
        End If
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = Chr(13) Then
            btnLogin.Focus()
        End If
    End Sub
End Class