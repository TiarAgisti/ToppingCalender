Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class FrmSchedule
    Public Shared statView As String
    Public Shared strScheduleCode As String
    Dim intbaris As Integer

    Sub GenerateCode()
        Dim query As String = "Select ScheduleCode Form Schedule Order By ScheduleCode Desc LIMIT 1"
        Dim dac As DataAccess = New DataAccess
        Dim dr As MySqlDataReader
        Dim strCode As String
        Dim intCount As Long
        Dim intSearch As Long
        Try

            dr = dac.ExecuteReader(query)
            dr.Read()
            If Not dr.HasRows Then
                strCode = "SCH/" & DateTime.Now.Year & "/" & "0000001"
            Else
                intSearch = Microsoft.VisualBasic.Right(dr.GetString(0), 6)
                If Microsoft.VisualBasic.Left(dr.GetString(0), 8) <> "SCH/" & DateTime.Now.Year & "/" Then
                    strCode = "PO/" & DateTime.Now.Year & "/" & "0000001"
                Else
                    intCount = Microsoft.VisualBasic.Right(dr.GetString(0), 6) + 1
                    strCode = "PO/" & DateTime.Now.Year & "/" & Microsoft.VisualBasic.Right("000000" & intCount, 6)
                End If
            End If
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub

    Sub PopulateTreatmentCode()
        Dim queryTreatment As String = "Select TreatmentCode From Treatment where isactive = 1"
        Dim displayData As String = "TreatmentCode"
        Dim valueData As String = "TreatmentCode"
        Dim dac As DataAccess = New DataAccess
        Try
            dac.PopulateComBoBox(cmbTreatment, queryTreatment, displayData, valueData)
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Sub

    Sub PopulateMachineCode()
        Dim queryMachine As String = "Select MachineCode from Machine_productions Where Isactive = 1"
        Dim displayData As String = "MachineCode"
        Dim valueData As String = "MachineCode"
        Dim dac As DataAccess = New DataAccess
        Try
            dac.PopulateComBoBox(cmbMachine, queryMachine, displayData, valueData)
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Sub

    Sub ValidatedTreatmentCode()
        Dim query As String = "Select TreatmentCode From Treatment where TreatmentCode = '" & cmbTreatment.Text & "' And IsActive = 1"
        Dim dac As DataAccess = New DataAccess
        Try
            If dac.ValidationValue(query) = False Then
                MsgBoxWarning("Treatment Code not available")
                cmbTreatment.Text = ""
                cmbTreatment.Focus()
            End If
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub

    Sub ValidatedMachineCode()
        Dim query As String = "Select MachineCode From Machine_productions where MachineCode = '" & cmbMachine.Text & "' And IsActive = 1"
        Dim dac As DataAccess = New DataAccess
        Try
            If dac.ValidationValue(query) = False Then
                MsgBoxWarning("Machine Code not available")
                cmbMachine.Text = ""
                cmbMachine.Focus()
            End If
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub

    Sub ClearDetails()
        cmbTreatment.Text = ""
        txtConsDay.Clear()
        txtConsShift.Clear()
        cmbMachine.Text = ""
        txtExpected.Clear()
    End Sub

    Sub ClearShift1()
        txtActual1.Clear()
        txtCons1.Clear()
        txtSch1.Clear()
        txtRoll1.Clear()
        txtMeter1.Clear()
        txtDesc1.Clear()
    End Sub

    Sub ClearShift2()
        txtActual2.Clear()
        txtCons2.Clear()
        txtSchRoll2.Clear()
        txtRoll2.Clear()
        txtMeter2.Clear()
        txtDesc2.Clear()
    End Sub

    Sub ClearShift3()
        txtActual3.Clear()
        txtCons3.Clear()
        txtSchRoll3.Clear()
        txtRoll3.Clear()
        txtMeter3.Clear()
        txtDesc3.Clear()
    End Sub

    Sub GridDetails()
        Try
            With dgv
                .Columns.Add(0, "Treatment")
                .Columns.Add(1, "Cons Day")
                .Columns.Add(2, "Cons Shift")
                .Columns.Add(3, "Machine")
                .Columns.Add(4, "Expected Speed")
                .Columns.Add(5, "Actual Shift 1")
                .Columns.Add(6, "Cons Shift 1")
                .Columns.Add(7, "SCH Roll Shift 1")
                .Columns.Add(8, "Roll Shift 1")
                .Columns.Add(9, "Meter Shift 1")
                .Columns.Add(10, "Description Shift 1")
                .Columns.Add(11, "Actual Shift 2")
                .Columns.Add(12, "Cons Shift 2")
                .Columns.Add(13, "SCH Roll Shift 2")
                .Columns.Add(14, "Roll Shift 2")
                .Columns.Add(15, "Meter Shift 2")
                .Columns.Add(16, "Description Shift 2")
                .Columns.Add(17, "Actual Shift 2")
                .Columns.Add(18, "Cons Shift 2")
                .Columns.Add(19, "SCH Roll Shift 2")
                .Columns.Add(20, "Roll Shift 2")
                .Columns.Add(21, "Meter Shift 2")
                .Columns.Add(22, "Description Shift 2")
            End With
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub

    Sub AddGrid()
        Try
            With dgv
                .Rows.Add()
                .Item(0, intbaris).Value = cmbTreatment.SelectedValue
                .Item(1, intbaris).Value = txtConsDay.Text
                .Item(2, intbaris).Value = txtConsShift.Text
                .Item(3, intbaris).Value = cmbMachine.SelectedValue
                .Item(4, intbaris).Value = txtExpected.Text
                .Item(5, intbaris).Value = txtActual1.Text
                .Item(6, intbaris).Value = txtCons1.Text
                .Item(7, intbaris).Value = txtSch1.Text
                .Item(8, intbaris).Value = txtRoll1.Text
                .Item(9, intbaris).Value = txtMeter1.Text
                .Item(10, intbaris).Value = txtDesc1.Text
                .Item(11, intbaris).Value = txtActual2.Text
                .Item(12, intbaris).Value = txtCons2.Text
                .Item(13, intbaris).Value = txtSchRoll2.Text
                .Item(14, intbaris).Value = txtRoll2.Text
                .Item(15, intbaris).Value = txtMeter2.Text
                .Item(16, intbaris).Value = txtDesc2.Text
                .Item(17, intbaris).Value = txtActual3.Text
                .Item(18, intbaris).Value = txtCons3.Text
                .Item(19, intbaris).Value = txtSchRoll3.Text
                .Item(20, intbaris).Value = txtRoll3.Text
                .Item(21, intbaris).Value = txtMeter3.Text
                .Item(22, intbaris).Value = txtDesc3.Text
                intbaris = intbaris + 1
            End With
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub

    Sub DeleteGridDetails()
        dgv.Rows.RemoveAt(dgv.CurrentCell.RowIndex)
        intbaris = intbaris - 1
    End Sub

    Sub PrepareButton(ByVal statBool As Boolean)
        btnApproved.Enabled = statBool
        btnVoid.Enabled = statBool
    End Sub

    Sub RetrieveHeader()
        Dim queryHeader As String
        Dim dac As DataAccess = New DataAccess
        queryHeader = "Select ScheduleCode,ScheduleDate,Revision From Schedules Where ScheduleCode = '" & strScheduleCode & "'"
        Dim dr As MySqlDataReader
        Try
            dr = dac.ExecuteReader(queryHeader)
            dr.Read()
            If dr.HasRows Then
                txtCode.Text = dr.Item("ScheduleCode")
                dtpDate.Value = dr.Item("ScheduleDate")
                txtRev.Text = dr.Item("Revision")
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
        queryDetails = "Select * From ScheduleDetails Where ScheduleCode = '" & strScheduleCode & "'"
        Dim dr As MySqlDataReader
        Try
            PopulateTreatmentCode()
            PopulateMachineCode()
            GridDetails()
            dr = dac.ExecuteReader(queryDetails)
            While dr.Read
                If Not IsDBNull(dr.Item("NoPO")) Then
                    With dgv
                        .Rows.Add()
                        .Item(0, intbaris).Value = dr.Item("TreatmentCode")
                        .Item(1, intbaris).Value = dr.Item("ConsDay")
                        .Item(2, intbaris).Value = dr.Item("ConsShift")
                        .Item(3, intbaris).Value = dr.Item("MachineCode")
                        .Item(4, intbaris).Value = dr.Item("ExpectedSpeed")
                        .Item(5, intbaris).Value = dr.Item("ActualSpeedShift1")
                        .Item(6, intbaris).Value = dr.Item("ConsShift1")
                        .Item(7, intbaris).Value = dr.Item("SCHRollShift1")
                        .Item(8, intbaris).Value = dr.Item("RollShift1")
                        .Item(9, intbaris).Value = dr.Item("MeterShift1")
                        .Item(10, intbaris).Value = dr.Item("DescShift1")
                        .Item(11, intbaris).Value = dr.Item("ActualSpeedShift2")
                        .Item(12, intbaris).Value = dr.Item("ConsShift2")
                        .Item(13, intbaris).Value = dr.Item("SCHRollShift2")
                        .Item(14, intbaris).Value = dr.Item("RollShift2")
                        .Item(15, intbaris).Value = dr.Item("MeterShift2")
                        .Item(16, intbaris).Value = dr.Item("DescShift2")
                        .Item(17, intbaris).Value = dr.Item("ActualSpeedShift3")
                        .Item(18, intbaris).Value = dr.Item("ConsShift3")
                        .Item(19, intbaris).Value = dr.Item("SCHRollShift3")
                        .Item(20, intbaris).Value = dr.Item("RollShift3")
                        .Item(21, intbaris).Value = dr.Item("MeterShift3")
                        .Item(22, intbaris).Value = dr.Item("DescShift2")
                        intbaris = intbaris + 1
                    End With
                End If
            End While
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub

    Sub PreCreateDisplay()
        ClearDetails()
        ClearShift1()
        ClearShift2()
        ClearShift3()
        GenerateCode()
        PopulateTreatmentCode()
        PopulateMachineCode()
        GridDetails()
        Text = title
        Format(dtpDate.Value, "dd-MMM-yyyy")
        PrepareButton(False)
    End Sub

    Sub PreUpdateDisplay()
        RetrieveHeader()
        RetrieveDetails()
        PrepareButton(True)
    End Sub

    Function CheckIsEmpty() As Boolean
        Dim stat As Boolean = True
        If Trim(txtCode.Text) = String.Empty Then
            MsgBoxWarning("Application cant generated code,please contact IT")
            Close()
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
        If Trim(cmbTreatment.Text) = String.Empty Then
            MsgBoxWarning("Please choose treatment")
            cmbTreatment.Focus()
        ElseIf Trim(txtConsDay.Text) = String.Empty Then
            MsgBoxWarning("Please fill cons day")
            txtConsDay.Focus()
        ElseIf Trim(txtConsShift.Text) = String.Empty Then
            MsgBoxWarning("Please fill cons shift")
            txtConsShift.Focus()
        ElseIf Trim(cmbMachine.Text) = String.Empty Then
            MsgBoxWarning("Please choose machine")
            cmbMachine.Focus()
        ElseIf Trim(txtExpected.Text) = String.Empty Then
            MsgBoxWarning("Please fill expected")
            txtExpected.Focus()
        Else
            stat = False
        End If
    End Function

    Function SaveData() As Boolean
        Dim insertHeader As String
        Dim insertDetails As String
        Dim dac As DataAccess = New DataAccess
        Dim sqlList As List(Of String) = New List(Of String)

        insertHeader = "insert into schedules values('" & txtCode.Text & "','" & Format(dtpDate.Value, "yyyy-MM-dd") & "','" & txtRev.Text & "','1'" & vbCrLf
        insertHeader += ",'" & Format(Now, "yyyy-MM-dd") & "','" & userCode & "','" & Format(Now, "yyyy-MM-dd") & "','" & userCode & "')"
        sqlList.Add(insertHeader)

        For detail = 0 To Me.dgv.Rows.Count - 2
            insertDetails = "Insert into ScheduleDetails values('" & txtCode.Text & "','" & Me.dgv.Rows(detail).Cells(0).Value & "','" & Me.dgv.Rows(detail).Cells(1).Value & "'" & vbCrLf
            insertDetails += ",'" & Me.dgv.Rows(detail).Cells(2).Value & "','" & Me.dgv.Rows(detail).Cells(3).Value & "','" & Me.dgv.Rows(detail).Cells(4).Value & "'" & vbCrLf
            insertDetails += ",'" & Me.dgv.Rows(detail).Cells(5).Value & "','" & Me.dgv.Rows(detail).Cells(6).Value & "','" & Me.dgv.Rows(detail).Cells(7).Value & "'" & vbCrLf
            insertDetails += ",'" & Me.dgv.Rows(detail).Cells(8).Value & "','" & Me.dgv.Rows(detail).Cells(9).Value & "','" & Me.dgv.Rows(detail).Cells(10).Value & "'" & vbCrLf
            insertDetails += ",'" & Me.dgv.Rows(detail).Cells(11).Value & "','" & Me.dgv.Rows(detail).Cells(12).Value & "','" & Me.dgv.Rows(detail).Cells(13).Value & "'" & vbCrLf
            insertDetails += ",'" & Me.dgv.Rows(detail).Cells(14).Value & "','" & Me.dgv.Rows(detail).Cells(15).Value & "','" & Me.dgv.Rows(detail).Cells(16).Value & "'" & vbCrLf
            insertDetails += ",'" & Me.dgv.Rows(detail).Cells(17).Value & "','" & Me.dgv.Rows(detail).Cells(18).Value & "','" & Me.dgv.Rows(detail).Cells(19).Value & "'" & vbCrLf
            insertDetails += ",'" & Me.dgv.Rows(detail).Cells(20).Value & "','" & Me.dgv.Rows(detail).Cells(21).Value & "','" & Me.dgv.Rows(detail).Cells(22).Value & "')"
            sqlList.Add(insertDetails)
        Next


        Try
            If dac.InsertMasterDetail(sqlList) = True Then
                Return True
            End If
            dac = Nothing
        Catch ex As Exception
            Return False
            dac = Nothing
            MsgBoxError(ex.Message)
        End Try
    End Function

    Function UpdateData() As Boolean
        Dim updateHeader As String
        Dim deleteDetails As String
        Dim insertDetails As String
        Dim dac As DataAccess = New DataAccess
        Dim sqlList As List(Of String) = New List(Of String)
        Dim rev As Integer = txtRev.Text
        Dim countRev As Integer
        countRev = rev + 1

        updateHeader = "Update Schedules Set Rev = '" & countRev & "',status = 2,Updated_by = '" & userCode & "',Updated_date = '" & Format(Now, "yyyy-MM-dd") & "'" & vbCrLf
        updateHeader += "Where ScheduleCode = '" & txtCode.Text & "'"
        sqlList.Add(updateHeader)

        deleteDetails = "Delete From ScheduleDetails Where Schedulecode = '" & txtCode.Text & "'"
        sqlList.Add(deleteDetails)

        For detail = 0 To Me.dgv.Rows.Count - 2
            insertDetails = "Insert into ScheduleDetails values('" & txtCode.Text & "','" & Me.dgv.Rows(detail).Cells(0).Value & "','" & Me.dgv.Rows(detail).Cells(1).Value & "'" & vbCrLf
            insertDetails += ",'" & Me.dgv.Rows(detail).Cells(2).Value & "','" & Me.dgv.Rows(detail).Cells(3).Value & "','" & Me.dgv.Rows(detail).Cells(4).Value & "'" & vbCrLf
            insertDetails += ",'" & Me.dgv.Rows(detail).Cells(5).Value & "','" & Me.dgv.Rows(detail).Cells(6).Value & "','" & Me.dgv.Rows(detail).Cells(7).Value & "'" & vbCrLf
            insertDetails += ",'" & Me.dgv.Rows(detail).Cells(8).Value & "','" & Me.dgv.Rows(detail).Cells(9).Value & "','" & Me.dgv.Rows(detail).Cells(10).Value & "'" & vbCrLf
            insertDetails += ",'" & Me.dgv.Rows(detail).Cells(11).Value & "','" & Me.dgv.Rows(detail).Cells(12).Value & "','" & Me.dgv.Rows(detail).Cells(13).Value & "'" & vbCrLf
            insertDetails += ",'" & Me.dgv.Rows(detail).Cells(14).Value & "','" & Me.dgv.Rows(detail).Cells(15).Value & "','" & Me.dgv.Rows(detail).Cells(16).Value & "'" & vbCrLf
            insertDetails += ",'" & Me.dgv.Rows(detail).Cells(17).Value & "','" & Me.dgv.Rows(detail).Cells(18).Value & "','" & Me.dgv.Rows(detail).Cells(19).Value & "'" & vbCrLf
            insertDetails += ",'" & Me.dgv.Rows(detail).Cells(20).Value & "','" & Me.dgv.Rows(detail).Cells(21).Value & "','" & Me.dgv.Rows(detail).Cells(22).Value & "')"
            sqlList.Add(insertDetails)
        Next


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

    Function ApprovedData() As Boolean
        Dim insertHeader As String
        Dim dac As DataAccess = New DataAccess

        insertHeader = "Update Schedules set status = 3,Updated_by = '" & userCode & "',Updated_date = '" & Format(Now, "yyyy-MM-dd") & "' Where ScheduleCode = '" & txtCode.Text & "'"
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
        Dim insertHeader As String
        Dim dac As DataAccess = New DataAccess

        insertHeader = "Update Schedules set status = 0,Updated_by = '" & userCode & "',Updated_date = '" & Format(Now, "yyyy-MM-dd") & "' Where ScheduleCode = '" & txtCode.Text & "'"
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


    Private Sub FrmSchedule_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Select Case statView
            Case "New"
                PreCreateDisplay()
            Case "Update"
                PreUpdateDisplay()
        End Select
    End Sub


    Private Sub txtConsDay_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConsDay.KeyPress
        If e.KeyChar = Chr(13) Then
            txtConsShift.Focus()
        End If
    End Sub

    Private Sub txtConsDay_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtConsDay.TextChanged
        ValidationNumber(txtConsDay)
    End Sub


    Private Sub txtConsShift_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConsShift.KeyPress
        If e.KeyChar = Chr(13) Then
            txtExpected.Focus()
        End If
    End Sub

    Private Sub txtConsShift_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtConsShift.TextChanged
        ValidationNumber(txtConsShift)
    End Sub


    Private Sub txtExpected_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtExpected.KeyPress
        If e.KeyChar = Chr(13) Then
            cmbTreatment.Focus()
        End If
    End Sub

    Private Sub txtExpected_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExpected.TextChanged
        ValidationNumber(txtExpected)
    End Sub


    Private Sub cmbTreatment_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTreatment.Validated
        If cmbTreatment.Text = "" Then
            cmbTreatment.Text = ""
        Else
            ValidatedTreatmentCode()
        End If
    End Sub

    Private Sub cmbMachine_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMachine.Validated
        If cmbMachine.Text = "" Then
            cmbMachine.Text = ""
        Else
            ValidatedMachineCode()
        End If
    End Sub

    Private Sub txtActual1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtActual1.KeyPress
        If e.KeyChar = Chr(13) Then
            txtCons1.Focus()
        End If
    End Sub

    Private Sub txtActual1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtActual1.TextChanged
        ValidationNumber(txtActual1)
    End Sub

    Private Sub txtCons1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCons1.KeyPress

    End Sub

    Private Sub txtCons1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCons1.TextChanged
        ValidationNumber(txtCons1)
    End Sub

    Private Sub txtSch1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSch1.KeyPress
        If e.KeyChar = Chr(13) Then
            txtRoll1.Focus()
        End If
    End Sub

    Private Sub txtSch1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSch1.TextChanged
        ValidationNumber(txtSch1)
    End Sub

    Private Sub txtRoll1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRoll1.KeyPress
        If e.KeyChar = Chr(13) Then
            txtMeter1.Focus()
        End If
    End Sub

    Private Sub txtRoll1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRoll1.TextChanged
        ValidationNumber(txtRoll1)
    End Sub

    Private Sub txtMeter1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMeter1.KeyPress
        If e.KeyChar = Chr(13) Then
            txtDesc1.Focus()
        End If
    End Sub

    Private Sub txtMeter1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMeter1.TextChanged
        ValidationNumber(txtMeter1)
    End Sub

    Private Sub txtDesc1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesc1.KeyPress
        If e.KeyChar = Chr(13) Then
            txtActual2.Focus()
        End If
    End Sub

    Private Sub txtActual2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtActual2.KeyPress
        If e.KeyChar = Chr(13) Then
            txtCons2.Focus()
        End If
    End Sub

    Private Sub txtActual2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtActual2.TextChanged
        ValidationNumber(txtActual2)
    End Sub

    Private Sub txtCons2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCons2.KeyPress
        If e.KeyChar = Chr(13) Then
            txtSchRoll2.Focus()
        End If
    End Sub

    Private Sub txtCons2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCons2.TextChanged
        ValidationNumber(txtCons2)
    End Sub

    Private Sub txtSchRoll2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSchRoll2.KeyPress
        If e.KeyChar = Chr(13) Then
            txtRoll2.Focus()
        End If
    End Sub

    Private Sub txtSchRoll2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSchRoll2.TextChanged
        ValidationNumber(txtSchRoll2)
    End Sub

    Private Sub txtRoll2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRoll2.KeyPress
        If e.KeyChar = Chr(13) Then
            txtMeter2.Focus()
        End If
    End Sub

    Private Sub txtRoll2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRoll2.TextChanged
        ValidationNumber(txtRoll2)
    End Sub

    Private Sub txtMeter2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMeter2.KeyPress
        If e.KeyChar = Chr(13) Then
            txtDesc2.Focus()
        End If
    End Sub

    Private Sub txtMeter2_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMeter2.TextChanged
        ValidationNumber(txtMeter2)
    End Sub

    Private Sub txtDesc2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesc2.KeyPress
        If e.KeyChar = Chr(13) Then
            txtActual3.Focus()
        End If
    End Sub

    Private Sub txtActual3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtActual3.KeyPress
        If e.KeyChar = Chr(13) Then
            txtCons3.Focus()
        End If
    End Sub

    Private Sub txtActual3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtActual3.TextChanged
        ValidationNumber(txtActual3)
    End Sub

    Private Sub txtCons3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCons3.KeyPress
        If e.KeyChar = Chr(13) Then
            txtSchRoll3.Focus()
        End If
    End Sub

    Private Sub txtCons3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCons3.TextChanged
        ValidationNumber(txtCons3)
    End Sub

    Private Sub txtSchRoll3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSchRoll3.KeyPress
        If e.KeyChar = Chr(13) Then
            txtRoll3.Focus()
        End If
    End Sub

    Private Sub txtSchRoll3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSchRoll3.TextChanged
        ValidationNumber(txtSchRoll3)
    End Sub

    Private Sub txtRoll3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRoll3.KeyPress
        If e.KeyChar = Chr(13) Then
            txtMeter3.Focus()
        End If
    End Sub

    Private Sub txtRoll3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRoll3.TextChanged
        ValidationNumber(txtRoll3)
    End Sub

    Private Sub txtMeter3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMeter3.KeyPress
        If e.KeyChar = Chr(13) Then
            txtDesc3.Focus()
        End If
    End Sub

    Private Sub txtMeter3_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMeter3.TextChanged
        ValidationNumber(txtMeter3)
    End Sub

    Private Sub txtDesc3_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDesc3.KeyPress
        If e.KeyChar = Chr(13) Then
            btnAdd.Focus()
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If CheckIsEmptyDetails() = False Then
            AddGrid()
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If dgv.RowCount > 1 Then
            DeleteGridDetails()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If CheckIsEmpty() = False Then
            If SaveData() = True Then
                MsgBoxSaved()
                PreCreateDisplay()
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If CheckIsEmpty() = False Then
            If SaveData() = True Then
                MsgBoxSaved()
                PreCreateDisplay()
            End If
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnApproved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApproved.Click
        If ApprovedData() = True Then
            MsgBoxApproved()
        End If
    End Sub

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        If VoidData() = True Then
            MsgBoxVoid()
        End If
    End Sub
End Class