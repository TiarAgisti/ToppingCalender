Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class FrmProduction
    Public Shared statView As String
    Public Shared strCode As String
    Dim noRoll As Integer
    Dim intbaris As Integer

    Sub GeneratedCode()
        Dim query As String = "Select ProductionCode From Productions Order By ProductionCode Desc LIMIT 1"
        Dim dac As DataAccess = New DataAccess
        Dim dr As MySqlDataReader
        Dim strCode As String
        Dim intCount As Long
        Dim intSearch As Long
        Try
            dr = dac.ExecuteReader(query)
            dr.Read()
            If Not dr.HasRows Then
                strCode = "PRD/" & DateTime.Now.Year & "/" & "000001"
            Else
                intSearch = Microsoft.VisualBasic.Right(dr.GetString(0), 6)
                If Microsoft.VisualBasic.Left(dr.GetString(0), 9) <> "PRD/" & DateTime.Now.Year & "/" Then
                    strCode = "PRD/" & DateTime.Now.Year & "/" & "0000001"
                Else
                    intCount = Microsoft.VisualBasic.Right(dr.GetString(0), 6) + 1
                    strCode = "PRD/" & DateTime.Now.Year & "/" & Microsoft.VisualBasic.Right("000000" & intCount, 6)
                End If
            End If
            txtCode.Text = strCode
            dr.Close()
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Sub
    Sub PopulateScheduleCode()
        Dim query As String = "Select ScheduleCode From Schedules where status = 3"
        Dim displayData As String = "ScheduleCode"
        Dim valueData As String = "ScheduleCode"
        Dim dac As DataAccess = New DataAccess
        Try
            dac.PopulateComBoBox(cmbSchedule, query, displayData, valueData)
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Sub

    Sub PopulateTreatmentCodeBySchedule()
        Dim query As String = "Select TreatmentCode From ScheduleDetails as schdet" & vbCrLf
        query += "inner join Schedules as sch ON sch.ScheduleCode = schdet.ScheduleCode where sch.status = 3 and schdet.ScheduleCode = '" & cmbSchedule.Text & "'"
        Dim displayData As String = "TreatmentCode"
        Dim valueData As String = "TreatmentCode"
        Dim dac As DataAccess = New DataAccess
        Try
            dac.PopulateComBoBox(cmbTreatment, query, displayData, valueData)
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Sub

    Sub PopulateNumberSpec()
        Dim query As String = "Select NumberSpec From NumbersSpec where Isactive = 1"
        Dim displayData As String = "NumberSpec"
        Dim valueData As String = "NumberSpec"
        Dim dac As DataAccess = New DataAccess
        Try
            dac.PopulateComBoBox(cmbNumSpec, query, displayData, valueData)
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Sub

    Sub PopulateNylon()
        Dim query As String = "Select NylonCode From Nylon where Isactive = 1"
        Dim displayData As String = "NylonCode"
        Dim valueData As String = "NylonCode"
        Dim dac As DataAccess = New DataAccess
        Try
            dac.PopulateComBoBox(cmbNylon, query, displayData, valueData)
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Sub

    Sub PopulateCompound()
        Dim query As String = "Select CompountCode From Compounts where Isactive = 1"
        Dim displayData As String = "CompountCode"
        Dim valueData As String = "CompountCode"
        Dim dac As DataAccess = New DataAccess
        Try
            dac.PopulateComBoBox(cmbCompound, query, displayData, valueData)
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Sub

    Sub GetNumberSpec()
        Dim query As String
        query = "Select product1,product2,product3,product4,process1,process2,process3,process4,process5,process6 " & vbCrLf
        query += "From NumbersSpec Where NumberSpec = '" & cmbNumSpec.SelectedValue & "'"
        Dim dac As DataAccess = New DataAccess
        Dim dr As MySqlDataReader
        Try
            dr = dac.ExecuteReader(query)
            dr.Read()
            If dr.HasRows Then
                txtProd1.Text = dr.Item("product1")
                txtProd2.Text = dr.Item("product2")
                txtProd3.Text = dr.Item("product3")
                txtProd4.Text = dr.Item("product4")
                txtProc1.Text = dr.Item("process1")
                txtProc2.Text = dr.Item("process2")
                txtProc3.Text = dr.Item("process3")
                txtProc4.Text = dr.Item("process4")
                txtProc5.Text = dr.Item("process5")
                txtProc6.Text = dr.Item("process6")
            Else
                MsgBoxWarning("Number Spec not valid")
                cmbNumSpec.Text = ""
                cmbNumSpec.Focus()
            End If
            dr.Close()
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Sub

    Sub GetNylon()
        Dim query As String = "Select NoRollNylon From Nylon Where NylonCode = '" & cmbNylon.Text & "'"
        Dim dac As DataAccess = New DataAccess
        Dim dr As MySqlDataReader
        Try
            dr = dac.ExecuteReader(query)
            dr.Read()
            If dr.HasRows Then
                txtRollNylon.Text = dr.Item("NoRollNylon")
            Else
                MsgBoxWarning("Nylon not valid")
                cmbNylon.Text = ""
                cmbNylon.Focus()
            End If
            dr.Close()
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Sub

    Sub GetCompound()
        Dim query As String = "Select CompountBatch,CompountDesc,CompountExpDate From Compounts Where CompountCode = '" & cmbCompound.Text & "'"
        Dim dac As DataAccess = New DataAccess
        Dim dr As MySqlDataReader
        Try
            dr = dac.ExecuteReader(query)
            dr.Read()
            If dr.HasRows Then
                txtBatch.Text = dr.Item("CompountBatch")
                txtDesc.Text = dr.Item("CompountDesc")
                dtpExpDate.Value = dr.Item("CompountExpDate")
            Else
                MsgBoxWarning("Compound not valid")
                cmbCompound.Text = ""
                cmbCompound.Focus()
            End If
            dr.Close()
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Sub

    Sub GridDetails()
        dgv.Columns.Clear()
        Try
            With dgv
                .Columns.Add(0, "No Roll")
                .Columns.Add(1, "Treatment")
                .Columns.Add(2, "Number Spec")
                .Columns.Add(3, "Product 1")
                .Columns.Add(4, "Product 2")
                .Columns.Add(5, "Product 3")
                .Columns.Add(6, "Product 4")
                .Columns.Add(7, "Process 1")
                .Columns.Add(8, "Process 2")
                .Columns.Add(9, "Process 3")
                .Columns.Add(10, "Process 4")
                .Columns.Add(11, "Process 5")
                .Columns.Add(12, "Process 6")
                .Columns.Add(13, "Supplier")
                .Columns.Add(14, "Date In Nylon")
                .Columns.Add(15, "Nylon")
                .Columns.Add(16, "No Roll Nylon")
                .Columns.Add(17, "Compound")
                .Columns.Add(18, "Batch")
                .Columns.Add(19, "Tgl/Bln/Grp/Line")
                .Columns.Add(20, "Expired Date")
                .Columns.Add(21, "Qty Actual")
                .Columns.Add(22, "Qty Meter")
                .Columns.Add(23, "Information")
            End With
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub

    Sub GenerateNoRoll()
        Dim query As String = "Select NoRoll From ProductionDetails Where Month = '" & Now.Month & "' and Year = '" & Now.Year & "' Order By ProductionCode Desc LIMIT 1"
        Dim dac As DataAccess = New DataAccess
        Dim dr As MySqlDataReader
        Try
            dr = dac.ExecuteReader(query)
            dr.Read()
            If dr.HasRows Then
                noRoll = dr.Item("NoRoll") + 1
            Else
                noRoll = 1
            End If
            dr.Close()
            txtNoRoll.Text = noRoll
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Sub

    Sub ClearProduct()
        txtProd1.Clear()
        txtProd2.Clear()
        txtProd3.Clear()
        txtProd4.Clear()
    End Sub

    Sub ClearProcess()
        txtProc1.Clear()
        txtProc2.Clear()
        txtProc3.Clear()
        txtProc4.Clear()
        txtProc5.Clear()
        txtProc6.Clear()
    End Sub

    Sub ClearCompound()
        cmbCompound.Text = ""
        txtBatch.Clear()
        txtDesc.Clear()
    End Sub

    Sub ClearHeader()
        cmbSchedule.Text = ""
        cmbShift.Text = ""
    End Sub

    Sub ClearDetails()
        txtNoRoll.Clear()
        cmbTreatment.Text = ""
        cmbNumSpec.Text = ""
        txtSupp.Clear()
        cmbNylon.Text = ""
        txtRollNylon.Clear()
    End Sub

    Function CheckIsEmpty() As Boolean
        Dim stat As Boolean = True
        If Trim(txtCode.Text) = String.Empty Then
            MsgBoxWarning("Application cant generated code,please contact IT")
            Close()
        ElseIf Trim(cmbSchedule.Text) = String.Empty Then
            MsgBoxWarning("Please choose schedule")
            cmbSchedule.Focus()
        ElseIf Trim(cmbShift.Text) = String.Empty Then
            MsgBoxWarning("Please choose shift")
            cmbShift.Focus()
        ElseIf dgv.RowCount = 1 Then
            MsgBoxWarning("Please fill details")
            cmbTreatment.Focus()
        Else
            stat = False
        End If
        Return stat
    End Function

    Function CheckIsEmptyDetails() As Boolean
        Dim stat As Boolean = True
        If Trim(txtNoRoll.Text) = String.Empty Then
            MsgBoxWarning("Application cant generated code,please contact IT")
            Close()
        ElseIf Trim(cmbTreatment.Text) = String.Empty Then
            MsgBoxWarning("Please choose treatment")
            cmbTreatment.Focus()
        ElseIf Trim(cmbNumSpec.Text) = String.Empty Then
            MsgBoxWarning("Please choose number spec")
            cmbNumSpec.Focus()
        ElseIf Trim(txtSupp.Text) = String.Empty Then
            MsgBoxWarning("Please fill supplier")
            txtSupp.Focus()
        ElseIf Trim(cmbNylon.Text) = String.Empty Then
            MsgBoxWarning("Please choose nylon")
            cmbNylon.Focus()
        ElseIf Trim(cmbCompound.Text) = String.Empty Then
            MsgBoxWarning("Please choose compound")
            cmbCompound.Focus()
        ElseIf Trim(txtQtyAct.Text) = String.Empty Then
            MsgBoxWarning("Please fill qty actual")
            txtQtyAct.Focus()
        ElseIf Trim(txtQtyMtr.Text) = String.Empty Then
            MsgBoxWarning("Please fill qty meter")
            txtQtyMtr.Focus()
        Else
            stat = False
        End If
    End Function

    Sub AddGrid()
        Try
            With dgv
                .Rows.Add()
                .Item(0, intbaris).Value = txtNoRoll.Text
                .Item(1, intbaris).Value = cmbTreatment.SelectedValue
                .Item(2, intbaris).Value = cmbNumSpec.SelectedValue
                .Item(3, intbaris).Value = txtProd1.Text
                .Item(4, intbaris).Value = txtProd2.Text
                .Item(5, intbaris).Value = txtProd3.Text
                .Item(6, intbaris).Value = txtProd4.Text
                .Item(7, intbaris).Value = txtProc1.Text
                .Item(8, intbaris).Value = txtProc2.Text
                .Item(9, intbaris).Value = txtProc3.Text
                .Item(10, intbaris).Value = txtProc4.Text
                .Item(11, intbaris).Value = txtProc5.Text
                .Item(12, intbaris).Value = txtProc6.Text
                .Item(13, intbaris).Value = txtSupp.Text
                .Item(14, intbaris).Value = dtpInNylon.Value
                .Item(15, intbaris).Value = cmbNylon.SelectedValue
                .Item(16, intbaris).Value = txtRollNylon.Text
                .Item(17, intbaris).Value = cmbCompound.SelectedValue
                .Item(18, intbaris).Value = txtBatch.Text
                .Item(19, intbaris).Value = txtDesc.Text
                .Item(20, intbaris).Value = dtpExpDate.Value
                .Item(21, intbaris).Value = txtQtyAct.Text
                .Item(22, intbaris).Value = txtQtyMtr.Text
                .Item(23, intbaris).Value = txtInfo.Text
                intbaris = intbaris + 1
            End With
            ClearDetails()
            ClearCompound()
            ClearProcess()
            ClearProduct()
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub

    Sub DeleteGridDetails()
        dgv.Rows.RemoveAt(dgv.CurrentCell.RowIndex)
        intbaris = intbaris - 1
    End Sub

    Function SaveData() As Boolean
        Dim insertHeader As String
        Dim insertDetail As String
        Dim updateSchedule As String
        Dim sqlList As List(Of String) = New List(Of String)
        Dim dac As DataAccess = New DataAccess

        insertHeader = "insert into Productions values('" & txtCode.Text & "','" & Format(dtpDate.Value, "yyyy-MM-dd") & "','" & Format(dtpExpDateProd.Value, "yyyy-MM-dd") & "'" & vbCrLf
        insertHeader += ",'" & cmbShift.Text & "','" & cmbSchedule.SelectedValue & "',1,'" & userCode & "','" & Format(Now, "yyyy-MM-dd") & "'" & vbCrLf
        insertHeader += ",'" & userCode & "','" & Format(Now, "yyyy-MM-dd") & "')"
        sqlList.Add(insertHeader)

        For detail = 0 To Me.dgv.Rows.Count - 2
            insertDetail = "insert into productiondetails values('" & txtCode.Text & "','" & Me.dgv.Rows(detail).Cells(0).Value & "','" & Me.dgv.Rows(detail).Cells(1).Value & "'" & vbCrLf
            insertDetail += ",'" & Me.dgv.Rows(detail).Cells(2).Value & "','" & Me.dgv.Rows(detail).Cells(13).Value & "','" & Me.dgv.Rows(detail).Cells(15).Value & "'" & vbCrLf
            insertDetail += ",'" & Format(Me.dgv.Rows(detail).Cells(14).Value, "yyyy-MM-dd") & "','" & Me.dgv.Rows(detail).Cells(17).Value & "','1','" & Me.dgv.Rows(detail).Cells(21).Value & "'" & vbCrLf
            insertDetail += ",'" & Me.dgv.Rows(detail).Cells(22).Value & "','" & Me.dgv.Rows(detail).Cells(23).Value & "','" & Now.Month & "','" & Now.Year & "')"
            sqlList.Add(insertDetail)
        Next

        updateSchedule = "Update Schedules Set Status = 4 Where ScheduleCode = '" & cmbSchedule.Text & "'"
        sqlList.Add(updateSchedule)

        Try
            If dac.InsertMasterDetail(sqlList) Then
                Return True
            End If
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Function

    Function SignData() As Boolean
        Dim updateDetails As String
        Dim dac As DataAccess = New DataAccess
        Dim row As Integer = dgv.CurrentRow.Index
        updateDetails = "Update ProductionDetails set Sign = 3 Where ProductionCode = '" & txtCode.Text & "'" & vbCrLf
        updateDetails += "And NoRoll = '" & dgv.Item(0, row).Value & "' And TreatmentCode = '" & dgv.Item(1, row).Value & "'"

        Try
            If dac.InsertMasterData(updateDetails) Then
                Return True
            End If
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Function

    Function ApprovedData() As Boolean
        Dim insertHeader As String
        Dim dac As DataAccess = New DataAccess

        insertHeader = "Update Productions set status = 3,Updated_by = '" & userCode & "',Updated_date = '" & Format(Now, "yyyy-MM-dd") & "' Where ProductionCode = '" & txtCode.Text & "'"

        Try
            If dac.InsertMasterData(insertHeader) = True Then
                Return True
            End If
        Catch ex As Exception
            Return False
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Function

    Function VoidData() As Boolean
        Dim insertHeader, updateSchedule As String
        Dim sqlList As List(Of String) = New List(Of String)
        Dim dac As DataAccess = New DataAccess

        insertHeader = "Update Productions set status = 0,Updated_by = '" & userCode & "',Updated_date = '" & Format(Now, "yyyy-MM-dd") & "' Where ProductionCode = '" & txtCode.Text & "'"
        sqlList.Add(insertHeader)
        updateSchedule = "Update Schedules Set Status = 3 Where ScheduleCode = '" & cmbSchedule.Text & "'"
        sqlList.Add(updateSchedule)
        Try
            If dac.InsertMasterDetail(sqlList) = True Then
                Return True
            End If
        Catch ex As Exception
            Return False
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Function

    Sub RetrieveHeader()
        Dim queryHeader As String
        Dim dac As DataAccess = New DataAccess
        queryHeader = "Select ProductionCode,ProductionDate,ExpDate,shift,ScheduleCode From Productions Where ProductionCode = '" & strCode & "'"
        Dim dr As MySqlDataReader
        Try
            PopulateScheduleCode()
            dr = dac.ExecuteReader(queryHeader)
            dr.Read()
            If dr.HasRows Then
                txtCode.Text = dr.Item("ProductionCode")
                dtpDate.Value = dr.Item("ProductionDate")
                dtpExpDateProd.Value = dr.Item("ExpDate")
                cmbShift.Text = dr.Item("shift")
                cmbSchedule.SelectedValue = dr.Item("ScheduleCode")
            End If
            dr.Close()
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Sub

    Sub RetrieveDetails()
        Dim queryDetails As String
        Dim dac As DataAccess = New DataAccess
        Dim dr As MySqlDataReader

        queryDetails = "SELECT proddet.*,nsp.product1,nsp.product2" & vbCrLf
        queryDetails += ",nsp.product3,nsp.product4,nsp.process1,nsp.process2" & vbCrLf
        queryDetails += ",nsp.process3,nsp.process4,nsp.process5,nsp.process6" & vbCrLf
        queryDetails += ",nyl.NoRollNylon,cmp.CompountBatch,cmp.CompountDesc,cmp.CompountExpDate" & vbCrLf
        queryDetails += "FROM productiondetails as proddet" & vbCrLf
        queryDetails += "inner join numbersspec as nsp ON nsp.NumberSpec = proddet.NumberSpec" & vbCrLf
        queryDetails += "inner join nylon as nyl ON nyl.NylonCode = proddet.NylonCode" & vbCrLf
        queryDetails += "inner join compounts as cmp ON cmp.CompountCode = proddet.CompountCode Where ProductionCode = '" & strCode & "'" & vbCrLf
        Try
            PopulateTreatmentCodeBySchedule()
            PopulateNumberSpec()
            PopulateNylon()
            PopulateCompound()

            GridDetails()
            dr = dac.ExecuteReader(queryDetails)
            While dr.Read
                If Not IsDBNull(dr.Item("ProductionCode")) Then
                    With dgv
                        .Rows.Add()
                        .Item(0, intbaris).Value = dr.Item("NoRoll")
                        .Item(1, intbaris).Value = dr.Item("TreatmentCode")
                        .Item(2, intbaris).Value = dr.Item("NumberSpec")
                        .Item(3, intbaris).Value = dr.Item("Product1")
                        .Item(4, intbaris).Value = dr.Item("Product2")
                        .Item(5, intbaris).Value = dr.Item("Product3")
                        .Item(6, intbaris).Value = dr.Item("Product4")
                        .Item(7, intbaris).Value = dr.Item("Process1")
                        .Item(8, intbaris).Value = dr.Item("Process2")
                        .Item(9, intbaris).Value = dr.Item("Process3")
                        .Item(10, intbaris).Value = dr.Item("Process4")
                        .Item(11, intbaris).Value = dr.Item("Process5")
                        .Item(12, intbaris).Value = dr.Item("Process6")
                        .Item(13, intbaris).Value = dr.Item("Supplier")
                        .Item(14, intbaris).Value = CStr(dr.Item("DateInNylon"))
                        .Item(15, intbaris).Value = dr.Item("NylonCode")
                        .Item(16, intbaris).Value = dr.Item("NoRollNylon")
                        .Item(17, intbaris).Value = dr.Item("CompountCode")
                        .Item(18, intbaris).Value = dr.Item("CompountBatch")
                        .Item(19, intbaris).Value = dr.Item("CompountDesc")
                        .Item(20, intbaris).Value = dr.Item("CompountExpDate")
                        .Item(21, intbaris).Value = dr.Item("Actual")
                        .Item(22, intbaris).Value = dr.Item("QtyMeter")
                        .Item(23, intbaris).Value = dr.Item("Information")
                        intbaris = intbaris + 1
                    End With
                End If
            End While
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub

    Sub PrintTreatment()
        Dim dac As New DataAccess
        Dim myReport As New CrTreatment
        Dim query As String
        Dim dt As DataTable
        Dim row As Integer = dgv.CurrentRow.Index

        query = "SELECT prd.ProductionCode,prd.ProductionDate,prd.ExpDate" & vbCrLf
        query += ",prddet.NoRoll,prddet.TreatmentCode" & vbCrLf
        query += "FROM productions as prd" & vbCrLf
        query += "inner join productiondetails as prddet on prd.ProductionCode = prddet.ProductionCode" & vbCrLf
        query += "where prddet.NoRoll = '" & dgv.Item(0, row).Value & "' And prddet.TreatmentCode = '" & dgv.Item(1, row).Value & "'"

        Try
            Cursor.Current = Cursors.WaitCursor
            dt = dac.RetrieveListData(query)
            myReport.SetDataSource(dt)
            With FrmView
                .crv.ReportSource = myReport
                .ShowDialog()
            End With

            Cursor.Current = Cursors.Default
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub

    Sub PrepareButton(ByVal statBool As Boolean)
        btnPrint.Enabled = statBool
        btnSign.Enabled = statBool
        btnApproved.Enabled = statBool
        btnVoid.Enabled = statBool
    End Sub

    Sub DateAddExpDate()
        dtpExpDateProd.Value = DateAdd(DateInterval.Day, 3, dtpDate.Value)
    End Sub

    Sub PreCreateDisplay()
        ClearHeader()
        ClearDetails()
        ClearCompound()
        ClearProcess()
        ClearProduct()
        GeneratedCode()
        GenerateNoRoll()
        GridDetails()
        PopulateCompound()
        PopulateNumberSpec()
        PopulateNylon()
        PopulateScheduleCode()
        PrepareButton(False)
        DateAddExpDate()
    End Sub

    Sub PreUpdateDisplay()
        RetrieveHeader()
        RetrieveDetails()
        ClearDetails()
        ClearCompound()
        ClearProcess()
        ClearProduct()
        PrepareButton(True)
    End Sub

    Private Sub FrmProduction_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        intbaris = 0
        Select Case statView
            Case "New"
                PreCreateDisplay()
            Case "Update"
                PreUpdateDisplay()
        End Select
    End Sub

    Private Sub cmbTreatment_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbTreatment.KeyDown
        If e.KeyCode = Keys.Enter Then
            cmbNumSpec.Focus()
        End If
    End Sub

    Private Sub txtSupp_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSupp.KeyPress
        If e.KeyChar = Chr(13) Then
            dtpInNylon.Focus()
        End If
    End Sub

    Private Sub cmbNylon_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbNylon.KeyDown
        If e.KeyCode = Keys.Enter Then
            GetNylon()
            cmbCompound.Focus()
        End If
    End Sub

    Private Sub cmbCompound_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbCompound.KeyDown
        If e.KeyCode = Keys.Enter Then
            GetCompound()
            txtQtyAct.Focus()
        End If
    End Sub

    Private Sub txtQtyAct_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQtyAct.KeyPress
        If e.KeyChar = Chr(13) Then
            txtQtyMtr.Focus()
        End If
    End Sub

    Private Sub txtQtyAct_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQtyAct.TextChanged
        ValidationNumber(txtQtyAct)
    End Sub

    Private Sub txtQtyMtr_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQtyMtr.KeyPress
        If e.KeyChar = Chr(13) Then
            txtInfo.Focus()
        End If
    End Sub

    Private Sub txtQtyMtr_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtQtyMtr.TextChanged
        ValidationNumber(txtQtyMtr)
    End Sub

    Private Sub txtInfo_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtInfo.KeyPress
        If e.KeyChar = Chr(13) Then
            btnAdd.Focus()
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If CheckIsEmptyDetails() = False Then
            AddGrid()
            noRoll = noRoll + 1
            txtNoRoll.Text = noRoll
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If dgv.RowCount > 1 Then
            DeleteGridDetails()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If statView = "New" Then
            Dim result As DialogResult = MsgBoxQuestionSave()
            If CheckIsEmpty() = False Then
                If result = MsgBoxResult.Yes Then
                    If SaveData() = True Then
                        MsgBoxSaved()
                        PreCreateDisplay()
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Select Case statView
            Case "New"
                PreCreateDisplay()
            Case "Update"
                PreUpdateDisplay()
        End Select
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        PrintTreatment()
    End Sub

    Private Sub btnSign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSign.Click
        If statView = "Update" Then
            If SignData() = True Then
                MsgBoxInformation("Data has been sign")
            End If
        End If
    End Sub

    Private Sub btnApproved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApproved.Click
        If statView = "Update" Then
            Dim result As DialogResult = MsgBoxQuestionApprove()
            If result = MsgBoxResult.Yes Then
                If ApprovedData() = True Then
                    MsgBoxApproved()
                    Close()
                End If
            End If
        End If
    End Sub

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        If statView = "Update" Then
            Dim result As DialogResult = MsgBoxQuestionVoid()
            If result = MsgBoxResult.Yes Then
                If VoidData() = True Then
                    MsgBoxVoid()
                    Close()
                End If
            End If
        End If
    End Sub

    Private Sub cmbSchedule_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbSchedule.KeyDown
        If e.KeyCode = Keys.Enter Then
            PopulateTreatmentCodeBySchedule()
            cmbTreatment.Focus()
        End If
    End Sub

    Private Sub cmbNumSpec_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbNumSpec.KeyDown
        If e.KeyCode = Keys.Enter Then
            GetNumberSpec()
            txtSupp.Focus()
        End If
    End Sub

    Private Sub cmbSchedule_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbSchedule.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub cmbTreatment_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbTreatment.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub cmbNumSpec_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbNumSpec.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub cmbNylon_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbNylon.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub dtpInNylon_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles dtpInNylon.KeyPress
        If e.KeyChar = Chr(13) Then
            cmbNylon.Focus()
        End If
    End Sub

    Private Sub dtpDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDate.ValueChanged
        DateAddExpDate()
    End Sub
End Class