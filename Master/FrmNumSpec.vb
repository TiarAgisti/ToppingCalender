Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class FrmNumSpec
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
        txtProc1.Clear()
        txtProc2.Clear()
        txtProc3.Clear()
        txtProc4.Clear()
        txtProc5.Clear()
        txtProc6.Clear()
        txtProd1.Clear()
        txtProd2.Clear()
        txtProd3.Clear()
        txtProd4.Clear()
        txtCari.Clear()
    End Sub
    Sub EnabledText(ByVal boolText As Boolean)
        txtCode.Enabled = boolText
        txtDesc.Enabled = boolText
        txtProc1.Enabled = boolText
        txtProc2.Enabled = boolText
        txtProc3.Enabled = boolText
        txtProc4.Enabled = boolText
        txtProc5.Enabled = boolText
        txtProc6.Enabled = boolText
        txtProd1.Enabled = boolText
        txtProd2.Enabled = boolText
        txtProd3.Enabled = boolText
        txtProd4.Enabled = boolText
    End Sub
    Sub HeaderGrid()
        dgv.Columns(0).HeaderText = "Number Spec"
        dgv.Columns(1).HeaderText = "Description"
        dgv.Columns(2).HeaderText = "Product 1"
        dgv.Columns(3).HeaderText = "Product 2"
        dgv.Columns(4).HeaderText = "Product 3"
        dgv.Columns(5).HeaderText = "Product 4"
        dgv.Columns(6).HeaderText = "Process 1"
        dgv.Columns(7).HeaderText = "Process 2"
        dgv.Columns(8).HeaderText = "Process 3"
        dgv.Columns(9).HeaderText = "Process 4"
        dgv.Columns(10).HeaderText = "Process 5"
        dgv.Columns(11).HeaderText = "Process 6"
    End Sub
    Sub RetrieveList()
        Dim dac As DataAccess = New DataAccess
        queryList = "select numberspec,description,product1,product2,product3,product4,process1,process2" & vbCrLf
        queryList += ",process3,process4,process5,process6 from numbersspec where isactive = 1"
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
        queryList = "select numberspec,description,product1,produdt2,product3,product4,process1,process2" & vbCrLf
        queryList += ",process3,process4,process5,process6 from numbersspec where isactive = 1" & vbCrLf
        queryList += "AND NumberSpec LIKE '%" & txtCari.Text & "%'"

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
        query = "Select Count(NumberSpec) as count from numbersspec where numberspec = '" & txtCode.Text & "'"
        Try
            dr = dac.ExecuteReader(query)
            dr.Read()
            If dr.Item("count") = 0 Then
                txtDesc.Focus()
            Else
                MsgBoxWarning("Number spec is available")
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
            MsgBoxWarning("Please fill number spec")
            txtCode.Focus()
        ElseIf Trim(txtDesc.Text) = String.Empty Then
            MsgBoxWarning("Please fill description")
            txtDesc.Focus()
        ElseIf Trim(txtProd1.Text) = String.Empty Then
            MsgBoxWarning("Please fill product1")
            txtProd1.Focus()
        ElseIf Trim(txtProd2.Text) = String.Empty Then
            MsgBoxWarning("Please fill product2")
            txtProd2.Focus()
        ElseIf Trim(txtProd3.Text) = String.Empty Then
            MsgBoxWarning("Please fill product3")
            txtProd3.Focus()
        ElseIf Trim(txtProd4.Text) = String.Empty Then
            MsgBoxWarning("Please fill product4")
            txtProd4.Focus()
        ElseIf Trim(txtProc1.Text) = String.Empty Then
            MsgBoxWarning("Please fill process1")
            txtProc1.Focus()
        ElseIf Trim(txtProc2.Text) = String.Empty Then
            MsgBoxWarning("Please fill process2")
            txtProc2.Focus()
        ElseIf Trim(txtProc3.Text) = String.Empty Then
            MsgBoxWarning("Please fill process3")
            txtProc3.Focus()
        ElseIf Trim(txtProc4.Text) = String.Empty Then
            MsgBoxWarning("Please fill process4")
            txtProc4.Focus()
        ElseIf Trim(txtProc5.Text) = String.Empty Then
            MsgBoxWarning("Please fill process5")
            txtProc5.Focus()
        ElseIf Trim(txtProc6.Text) = String.Empty Then
            MsgBoxWarning("Please fill process6")
            txtProc6.Focus()
        Else
            stat = False
        End If
        Return stat
    End Function
    Function SaveData() As Boolean
        Dim dac As DataAccess = New DataAccess
        Dim queryInsert As String

        queryInsert = "Insert into numbersspec values('" & txtCode.Text & "','" & txtDesc.Text & "','" & txtProd1.Text & "'" & vbCrLf
        queryInsert += ",'" & txtProd2.Text & "','" & txtProd3.Text & "','" & txtProd4.Text & "','" & txtProc1.Text & "'" & vbCrLf
        queryInsert += ",'" & txtProc2.Text & "','" & txtProc3.Text & "','" & txtProc4.Text & "','" & txtProc5.Text & "','" & txtProc6.Text & "'" & vbCrLf
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
        queryUpdate = "Update numbersspec set description = '" & txtDesc.Text & "'" & vbCrLf
        queryUpdate += ",product1 = '" & txtProd1.Text & "',product2 = '" & txtProd2.Text & "'" & vbCrLf
        queryUpdate += ",product3 = '" & txtProd3.Text & "',product4 = '" & txtProd4.Text & "'" & vbCrLf
        queryUpdate += ",process1 = '" & txtProc1.Text & "',process2 = '" & txtProc2.Text & "'" & vbCrLf
        queryUpdate += ",process3 = '" & txtProc3.Text & "',process4 = '" & txtProc4.Text & "'" & vbCrLf
        queryUpdate += ",process5 = '" & txtProc5.Text & "',process6 = '" & txtProc6.Text & "'" & vbCrLf
        queryUpdate += ",updated_by = '" & userCode & "',updated_date = '" & Format(Now, "yyyy-MM-dd") & "'" & vbCrLf
        queryUpdate += "Where numberspec = '" & txtCode.Text & "' And isactive = 1"
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
        queryUpdate = "Update numbersspec set isactive = 0,updated_by = '" & userCode & "'" & vbCrLf
        queryUpdate += ",updated_date = '" & Format(Now, "yyyy-MM-dd") & "' Where numberspec = '" & txtCode.Text & "' And isactive = 1"
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
            txtProd1.Focus()
        End If
    End Sub

    Private Sub txtProd1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProd1.KeyPress
        If e.KeyChar = Chr(13) Then
            txtProd2.Focus()
        End If
    End Sub

    Private Sub txtProd1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProd1.TextChanged
        ValidationNumber(txtProd1)
    End Sub

    Private Sub txtProd2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProd2.KeyPress
        If e.KeyChar = Chr(13) Then
            txtProd3.Focus()
        End If
    End Sub

    Private Sub txtProd2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProd2.TextChanged
        ValidationNumber(txtProd2)
    End Sub

    Private Sub txtProd3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProd3.KeyPress
        If e.KeyChar = Chr(13) Then
            txtProd4.Focus()
        End If
    End Sub

    Private Sub txtProd3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProd3.TextChanged
        ValidationNumber(txtProd3)
    End Sub

    Private Sub txtProd4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProd4.KeyPress
        If e.KeyChar = Chr(13) Then
            txtProc1.Focus()
        End If
    End Sub

    Private Sub txtProd4_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProd4.Validated
        ValidationNumber(txtProd4)
    End Sub

    Private Sub txtProc1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProc1.KeyPress
        If e.KeyChar = Chr(13) Then
            txtProc2.Focus()
        End If
    End Sub

    Private Sub txtProc1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProc1.TextChanged
        ValidationNumber(txtProc1)
    End Sub

    Private Sub txtProc2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProc2.KeyPress
        If e.KeyChar = Chr(13) Then
            txtProc3.Focus()
        End If
    End Sub

    Private Sub txtProc2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProc2.TextChanged
        ValidationNumber(txtProc2)
    End Sub

    Private Sub txtProc3_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProc3.KeyPress
        If e.KeyChar = Chr(13) Then
            txtProc4.Focus()
        End If
    End Sub

    Private Sub txtProc3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProc3.TextChanged
        ValidationNumber(txtProc3)
    End Sub

    Private Sub txtProc4_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProc4.KeyPress
        If e.KeyChar = Chr(13) Then
            txtProc5.Focus()
        End If
    End Sub

    Private Sub txtProc4_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProc4.TextChanged
        ValidationNumber(txtProc4)
    End Sub

    Private Sub txtProc5_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProc5.KeyPress
        If e.KeyChar = Chr(13) Then
            txtProc6.Focus()
        End If
    End Sub

    Private Sub txtProc5_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProc5.TextChanged
        ValidationNumber(txtProc5)
    End Sub

    Private Sub txtProc6_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtProc6.KeyPress
        If e.KeyChar = Chr(13) Then
            btnSave.Focus()
        End If
    End Sub
    Private Sub txtProc6_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProc6.TextChanged
        ValidationNumber(txtProc6)
    End Sub

    Private Sub FrmNumSpec_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
    End Sub

    Private Sub dgv_CellClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv.CellClick
        With dgv
            If .RowCount > 1 Then
                Dim dac As DataAccess = New DataAccess
                Dim row As Integer = .CurrentRow.Index
                txtCode.Text = .Item(0, row).Value
                txtDesc.Text = .Item(1, row).Value
                txtProd1.Text = .Item(2, row).Value
                txtProd2.Text = .Item(3, row).Value
                txtProd3.Text = .Item(4, row).Value
                txtProd4.Text = .Item(5, row).Value
                txtProc1.Text = .Item(6, row).Value
                txtProc2.Text = .Item(7, row).Value
                txtProc3.Text = .Item(8, row).Value
                txtProc4.Text = .Item(9, row).Value
                txtProc5.Text = .Item(10, row).Value
                txtProc6.Text = .Item(11, row).Value
                PrepareEdit()
            Else
                MsgBoxWarning("Data not available")
            End If
        End With
    End Sub
End Class