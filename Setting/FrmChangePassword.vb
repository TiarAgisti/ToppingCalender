Public Class FrmChangePassword
    Sub ClearText()
        txtOld.Clear()
        txtNew.Clear()
        txtConfirm.Clear()
    End Sub
    Sub PreCreateDisplay()
        ClearText()
    End Sub
    Sub ValidationPassword()
        Dim query As String
        Dim dac As DataAccess = New DataAccess
        query = "select count(userpassword) as count from users where usercode = '" & txtOld.Text & "'"
        Try
            If dac.ValidationValue(query) = False Then
                MsgBoxError("Passowrd not valid,please try again")
            Else
                txtNew.Focus()
            End If
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Sub
    Sub ConfirmationPassword()
        If txtNew.Text <> txtConfirm.Text Then
            MsgBoxError("Confirmation password not valid")
        Else
            btnSave.Focus()
        End If
    End Sub
    Function CheckIsEmpty() As Boolean
        If Trim(txtOld.Text) = String.Empty Then
            MsgBoxWarning("Please fill Old Password")
            txtOld.Focus()
            Return True
        ElseIf Trim(txtNew.Text) = String.Empty Then
            MsgBoxWarning("Please fill New password")
            txtNew.Focus()
            Return True
        ElseIf Trim(txtConfirm.Text) = String.Empty Then
            MsgBoxWarning("Please fill access level")
            txtConfirm.Focus()
            Return True
        Else
            Return False
        End If
    End Function
    Function UpdateData() As Boolean
        Dim stat As Boolean = False
        Dim query As String
        Dim dac As DataAccess = New DataAccess
        query = "Update users set userpassword='" & dac.Encrypted(txtConfirm.Text, keysEncryp) & "',updated_by='" & userCode & "'" & vbCrLf
        query += ",updated_date = '" & Format(Now, "yyyy-MM-dd") & "' where usercode = '" & userCode & "' and isactive = 1"
        Try
            If dac.InsertMasterData(query) = True Then
                stat = True
            End If
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        Return stat
    End Function

    Private Sub FrmChangePassword_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearText()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If CheckIsEmpty() = False Then
            If UpdateData() = True Then
                MsgBoxSaved()
                PreCreateDisplay()
            End If
        End If
    End Sub

    Private Sub txtOld_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOld.KeyPress
        If e.KeyChar = Chr(13) Then
            ValidationPassword()
        End If
    End Sub

    Private Sub txtOld_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtOld.Validated
        If txtOld.Text = "" Then
            txtOld.Text = ""
        Else
            ValidationPassword()
        End If
    End Sub

    Private Sub txtNew_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNew.KeyPress
        If e.KeyChar = Chr(13) Then
            txtConfirm.Focus()
        End If
    End Sub

    Private Sub txtConfirm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConfirm.KeyPress
        If e.KeyChar = Chr(13) Then
            ConfirmationPassword()
        End If
    End Sub

    Private Sub txtConfirm_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtConfirm.Validated
        If txtConfirm.Text = "" Then
            txtConfirm.Text = ""
        Else
            ConfirmationPassword()
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class