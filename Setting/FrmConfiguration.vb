Public Class FrmConfiguration
    Sub DisplaySetting()
        txtServer.Text = My.Settings.serverName
        txtDatabase.Text = My.Settings.databaseName
        txtUser.Text = My.Settings.userID
        txtPassword.Text = My.Settings.passwordUser
    End Sub

    Sub SaveSetting()
        My.Settings.serverName = txtServer.Text
        My.Settings.databaseName = txtDatabase.Text
        My.Settings.userID = txtUser.Text
        My.Settings.passwordUser = txtPassword.Text
        My.Settings.Save()
    End Sub

    Function CheckIsEmpty() As Boolean
        If Trim(txtServer.Text) = String.Empty Then
            MsgBoxWarning("Please fill server name")
            Return True
        ElseIf Trim(txtDatabase.Text) = String.Empty Then
            MsgBoxWarning("Please fill database")
            Return True
        ElseIf Trim(txtUser.Text) = String.Empty Then
            MsgBoxWarning("Please fill user id")
            Return True
        ElseIf Trim(txtPassword.Text) = String.Empty Then
            MsgBoxWarning("Please fill password")
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub txtServer_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtServer.KeyPress
        If e.KeyChar = Chr(13) Then
            txtDatabase.Focus()
        End If
    End Sub

    Private Sub txtDatabase_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDatabase.KeyPress
        If e.KeyChar = Chr(13) Then
            txtUser.Focus()
        End If
    End Sub

    Private Sub txtUser_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUser.KeyPress
        If e.KeyChar = Chr(13) Then
            txtPassword.Focus()
        End If
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If e.KeyChar = Chr(13) Then
            btnConnect.Focus()
        End If
    End Sub

    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        If CheckIsEmpty() = False Then
            Dim dac As DataAccess = New DataAccess
            SaveSetting()
            If dac.TestConnection = True Then
                MsgBoxInformation("Connection Succesfully")
            Else
                MsgBoxInformation("Connection failed")
            End If
            dac = Nothing
        End If
    End Sub

    Private Sub FrmConfiguration_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        DisplaySetting()
        Me.Text = title
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class