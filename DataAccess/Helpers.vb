﻿Module Helpers
    Public title As String = "Application Topping Calender"
    Public userCode As String
    Public userName As String
    Public userAccess As String
    Public keysEncryp As String = "1234567890qwerty"
    Public Sub MsgBoxWarning(ByVal msg As String)
        MsgBox(msg, MsgBoxStyle.Exclamation, title)
    End Sub
    Public Sub MsgBoxInformation(ByVal msg As String)
        MsgBox(msg, MsgBoxStyle.Information, title)
    End Sub
    Public Sub MsgBoxError(ByVal msg As String)
        MsgBox(msg, MsgBoxStyle.Critical, title)
    End Sub
    Public Sub MsgBoxSaved()
        MsgBoxInformation("Data has been saved")
    End Sub
    Public Sub MsgBoxUpdated()
        MsgBoxInformation("Data has been updated")
    End Sub
    Public Sub MsgBoxApproved()
        MsgBoxInformation("Data has been Approved")
    End Sub
    Public Sub MsgBoxVoid()
        MsgBoxInformation("Data has been Voided")
    End Sub
    Public Sub MsgBoxDeleted()
        MsgBoxInformation("Data has been deleted")
    End Sub
    Public Function MsgBoxQuestion() As DialogResult
        Dim result2 As DialogResult = MessageBox.Show("Are you sure data will be deleted?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Return result2
    End Function
    Public Function MsgBoxQuestionExit() As DialogResult
        Dim result As DialogResult = MessageBox.Show("Are you sure want to exit application?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Return result
    End Function
    Public Function MsgBoxQuestionSave() As DialogResult
        Dim result As DialogResult = MessageBox.Show("Are you sure want to save?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Return result
    End Function
    Public Function MsgBoxQuestionUpdate() As DialogResult
        Dim result As DialogResult = MessageBox.Show("Are you sure want to update?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Return result
    End Function
    Public Function MsgBoxQuestionDelete() As DialogResult
        Dim result As DialogResult = MessageBox.Show("Are you sure want to delete?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Return result
    End Function
    Public Function MsgBoxQuestionApprove() As DialogResult
        Dim result As DialogResult = MessageBox.Show("Are you sure want to approve?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Return result
    End Function
    Public Function MsgBoxQuestionVoid() As DialogResult
        Dim result As DialogResult = MessageBox.Show("Are you sure want to void?", title, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        Return result
    End Function
    Public Sub ValidationNumber(ByVal txt As TextBox)
        If txt.Text = "" Then
            txt.Text = ""
        Else
            If Not IsNumeric(txt.Text) Then
                txt.Clear()
            End If
        End If
    End Sub
End Module
