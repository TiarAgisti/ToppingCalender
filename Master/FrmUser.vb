Public Class FrmUser
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
    Sub EmptyText()
        txtCode.Clear()
        txtName.Clear()
        txtPassword.Clear()
        cmbAccess.Text = ""
        cmbCari.Text = ""
    End Sub
    Sub EnabledText(ByVal boolStat As Boolean)
        txtName.Enabled = boolStat
        txtPassword.Enabled = boolStat
        cmbAccess.Enabled = boolStat
    End Sub
    Sub HeaderGrid()
        dgv.Columns(0).HeaderText = "User Code"
        dgv.Columns(1).HeaderText = "User Name"
        dgv.Columns(2).HeaderText = "User Password"
        dgv.Columns(2).Visible = False
        dgv.Columns(3).HeaderText = "Access Level"
    End Sub
    Sub RetrieveListUsers()
        Dim dac As DataAccess = New DataAccess
        queryList = "Select usercode,username,userpassword,accesslevel from users where isactive = 1"
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
        queryList = "Select usercode,username,userpassword,accesslevel from users where isactive = 1"
        If cmbCari.Text = "User Name" Then
            queryList += " And username LIKE '%" & txtCari.Text & "%'"
        ElseIf cmbCari.Text = "Access Level" Then
            queryList += " And accesslevel LIKE '%" & txtCari.Text & "%'"
        End If

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
        EmptyText()
        EnabledText(False)
        PrepareButtonAdd()
        RetrieveListUsers()
    End Sub
    Sub PrepareSave()
        EnabledText(True)
        PrepareButtonSave()
        txtName.Focus()
    End Sub
    Sub PrepareEdit()
        EnabledText(True)
        PrepareButtonEdit()
        txtName.Focus()
    End Sub
    Sub GenerateCode()
        Dim dac As DataAccess = New DataAccess
        Dim queryCode As String
        queryCode = "Select usercode from users order by usercode desc LIMIT 1"
        Try
            txtCode.Text = dac.GeneratedCode(queryCode, "USR")
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub
    Function CheckIsEmpty() As Boolean
        If Trim(txtName.Text) = String.Empty Then
            MsgBoxWarning("Please fill user name")
            txtName.Focus()
            Return True
        ElseIf Trim(txtPassword.Text) = String.Empty Then
            MsgBoxWarning("Please fill user password")
            txtPassword.Focus()
            Return True
        ElseIf Trim(cmbAccess.Text) = String.Empty Then
            MsgBoxWarning("Please fill access level")
            cmbAccess.Focus()
            Return True
        Else
            Return False
        End If
    End Function
    Function SaveData() As Boolean
        Dim dac As DataAccess = New DataAccess
        If userCode = "" Then
            userCode = "System"
        End If
        Dim encrypPassword As String
        encrypPassword = dac.Encrypted(txtPassword.Text, keysEncryp)

        Dim queryInsert As String
        queryInsert = "Insert into users values('" & txtCode.Text & "','" & txtName.Text & "','" & encrypPassword & "'" & vbCrLf
        queryInsert += ",'" & cmbAccess.Text & "',1,'" & userCode & "','" & Format(Now, "yyyy-MM-dd") & "','" & userCode & "'" & vbCrLf
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
        If userCode = "" Then
            userCode = "System"
        End If
        Dim encrypPassword As String
        encrypPassword = dac.Encrypted(txtPassword.Text, keysEncryp)
        Dim queryUpdate As String
        queryUpdate = "Update users set username = '" & txtName.Text & "',userpassword = '" & encrypPassword & "'" & vbCrLf
        queryUpdate += ",accesslevel = '" & cmbAccess.Text & "',updated_by = '" & userCode & "'" & vbCrLf
        queryUpdate += ",updated_date = '" & Format(Now, "yyyy-MM-dd") & "' Where usercode = '" & txtCode.Text & "' And isactive = 1"
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
        If userCode = "" Then
            userCode = "System"
        End If
        Dim encrypPassword As String
        encrypPassword = dac.Encrypted(txtPassword.Text, keysEncryp)
        Dim queryUpdate As String
        queryUpdate = "Update users set isactive = 0,updated_by = '" & userCode & "'" & vbCrLf
        queryUpdate += ",updated_date = '" & Format(Now, "yyyy-MM-dd") & "' Where usercode = '" & txtCode.Text & "' And isactive = 1"
        Try
            If dac.InsertMasterData(queryUpdate) = True Then
                Return True
            End If
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Function
    Private Sub FrmUser_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PreCreateDisplay()
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

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        PreCreateDisplay()
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

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim result As DialogResult = MsgBoxQuestionDelete()
        If result = MsgBoxResult.Yes Then
            If DeletedData() = True Then
                MsgBoxDeleted()
                PreCreateDisplay()
            End If
        End If
    End Sub

    Private Sub dgv_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellClick
        With dgv
            If .RowCount > 1 Then
                Dim dac As DataAccess = New DataAccess
                Dim row As Integer = .CurrentRow.Index
                txtCode.Text = .Item(0, row).Value
                txtName.Text = .Item(1, row).Value
                txtPassword.Text = dac.Decrypted(.Item(2, row).Value, keysEncryp)
                cmbAccess.Text = .Item(3, row).Value
                PrepareEdit()
            Else
                MsgBoxWarning("Data not available")
            End If
        End With
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        PrepareSave()
        GenerateCode()
    End Sub

    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        RetrieveListSearch()
        btnCancel.Enabled = True
    End Sub
End Class