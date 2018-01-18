Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class FrmTreatment
    Dim queryList As String
    Sub PrepareButtonAdd()
        btnAdd.Enabled = True
        btnSave.Enabled = False
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnCancel.Enabled = False
    End Sub
    Sub PrepareButtonSave()
        btnAdd.Enabled = False
        btnSave.Enabled = True
        btnEdit.Enabled = False
        btnDelete.Enabled = False
        btnCancel.Enabled = True
    End Sub
    Sub PrepareButtonEdit()
        btnAdd.Enabled = False
        btnSave.Enabled = False
        btnEdit.Enabled = True
        btnDelete.Enabled = True
        btnCancel.Enabled = True
    End Sub
    Sub ClearText()
        txtCode.Clear()
        txtDesc.Clear()
        txtCari.Clear()
    End Sub
    Sub EnabledText(ByVal boolText As Boolean)
        txtCode.Enabled = boolText
        txtDesc.Enabled = boolText
    End Sub
    Sub HeaderGrid()
        dgv.Columns(0).HeaderText = "Treatment Code"
        dgv.Columns(1).HeaderText = "Description"
    End Sub
    Sub RetrieveList()
        Dim dac As DataAccess = New DataAccess
        queryList = "Select treatmentcode,description from treatment where isactive = 1"
        Try
            dgv.DataSource = dac.RetrieveListData(queryList)
            dgv.ReadOnly = True
            HeaderGrid()
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Sub
    Sub RetrieveListSearch()
        Dim dac As DataAccess = New DataAccess
        queryList = "Select treatmentcode,description from treatment where isactive = 1" & vbCrLf
        queryList += "And treatmentcode LIKE '%" & txtCari.Text & "%'"
        Try
            dgv.DataSource = dac.RetrieveListData(queryList)
            dgv.ReadOnly = True
            HeaderGrid()
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Sub
    Sub PreCreateDisplay()
        ClearText()
        EnabledText(False)
        PrepareButtonAdd()
        RetrieveList()
    End Sub
    Sub PrepareSave()
        EnabledText(True)
        PrepareButtonSave()
        txtCode.Enabled = True
        txtCode.Focus()
    End Sub
    Sub PrepareEdit()
        EnabledText(True)
        PrepareButtonEdit()
        txtCode.Enabled = False
        txtDesc.Focus()
    End Sub
    Sub CheckCode()
        Dim dac As DataAccess = New DataAccess
        Dim dr As MySqlDataReader
        Dim query As String
        query = "Select Count(treatmentcode) as count from treatment where treatmentcode = '" & txtCode.Text & "'"
        Try
            dr = dac.ExecuteReader(query)
            dr.Read()
            If dr.Item("count") = 0 Then
                txtDesc.Focus()
            Else
                MsgBoxWarning("Treatment code is available")
                txtCode.Clear()
            End If
            dr.Close()
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Sub
    Function CheckIsEmpty() As Boolean
        Dim stat As Boolean = True
        If Trim(txtCode.Text) = String.Empty Then
            MsgBoxWarning("Please fill treatment code")
            txtCode.Focus()
        ElseIf Trim(txtDesc.Text) = String.Empty Then
            MsgBoxWarning("Please fill description")
            txtDesc.Focus()
        Else
            stat = False
        End If
        Return stat
    End Function
    Function SaveData() As Boolean
        Dim dac As DataAccess = New DataAccess
        Dim queryInsert As String

        queryInsert = "Insert into treatment values('" & txtCode.Text & "','" & txtDesc.Text & "'" & vbCrLf
        queryInsert += ",1,'" & userCode & "','" & Format(Now, "yyyy-MM-dd") & "','" & userCode & "'" & vbCrLf
        queryInsert += ",'" & Format(Now, "yyyy-MM-dd") & "')"

        Try
            If dac.InsertMasterData(queryInsert) = True Then
                Return True
            End If
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Function
    Function UpdateData() As Boolean
        Dim dac As DataAccess = New DataAccess
        Dim queryUpdate As String
        queryUpdate = "Update treatment set description = '" & txtDesc.Text & "'" & vbCrLf
        queryUpdate += ",updated_by = '" & userCode & "'" & vbCrLf
        queryUpdate += ",updated_date = '" & Format(Now, "yyyy-MM-dd") & "' Where treatmentcode = '" & txtCode.Text & "' And isactive = 1"
        Try
            If dac.InsertMasterData(queryUpdate) = True Then
                Return True
            End If
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Function
    Function DeletedData() As Boolean
        Dim dac As DataAccess = New DataAccess
        Dim queryUpdate As String
        queryUpdate = "Update treatment set isactive = 0,updated_by = '" & userCode & "'" & vbCrLf
        queryUpdate += ",updated_date = '" & Format(Now, "yyyy-MM-dd") & "' Where treatmentcode = '" & txtCode.Text & "' And isactive = 1"
        Try
            If dac.InsertMasterData(queryUpdate) = True Then
                Return True
            End If
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Function

    Private Sub txtCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCode.KeyPress
        If e.KeyChar = Chr(13) Then
            CheckCode()
        End If
    End Sub

    Private Sub txtCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCode.Validated
        If txtCode.Text = "" Then
            txtCode.Text = ""
        Else
            CheckCode()
        End If
    End Sub

    Private Sub txtDesc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesc.KeyPress
        If e.KeyChar = Chr(13) Then
            btnSave.Focus()
        End If
    End Sub

    Private Sub FrmTreatment_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PreCreateDisplay()
        Text = title
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        PrepareSave()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim result As DialogResult = MsgBoxQuestionSave()
        If CheckIsEmpty() = False Then
            If result = MsgBoxResult.Yes Then
                If SaveData() = True Then
                    MsgBoxSaved()
                    PreCreateDisplay()
                End If
            End If
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim result As DialogResult = MsgBoxQuestionUpdate()
        If CheckIsEmpty() = False Then
            If result = MsgBoxResult.Yes Then
                If UpdateData() = True Then
                    MsgBoxUpdated()
                    PreCreateDisplay()
                End If
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        PreCreateDisplay()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim result As DialogResult = MsgBoxQuestionDelete()
        If result = MsgBoxResult.Yes Then
            If DeletedData() = True Then
                MsgBoxDeleted()
                PreCreateDisplay()
            End If
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        RetrieveListSearch()
        btnCancel.Enabled = True
    End Sub

    Private Sub dgv_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellClick
        With dgv
            If .RowCount > 1 Then
                Dim dac As DataAccess = New DataAccess
                Dim row As Integer = .CurrentRow.Index
                txtCode.Text = .Item(0, row).Value
                txtDesc.Text = .Item(1, row).Value
                PrepareEdit()
            Else
                MsgBoxWarning("Data not available")
            End If
        End With
    End Sub

   
End Class