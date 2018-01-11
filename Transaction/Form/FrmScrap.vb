Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class FrmScrap
    Public Shared statView As String
    Public Shared strCode As String
    Dim intbaris As Integer

    Sub GeneratedCode()
        Dim query As String = "Select ScrapCode From ScrapProductions Order By ScrapCode Desc LIMIT 1"
        Dim dac As DataAccess = New DataAccess
        Dim dr As MySqlDataReader
        Dim strCode As String
        Dim intCount As Long
        Dim intSearch As Long
        Try
            dr = dac.ExecuteReader(query)
            dr.Read()
            If Not dr.HasRows Then
                strCode = "SCR/" & DateTime.Now.Year & "/" & "000001"
            Else
                intSearch = Microsoft.VisualBasic.Right(dr.GetString(0), 6)
                If Microsoft.VisualBasic.Left(dr.GetString(0), 9) <> "SCR/" & DateTime.Now.Year & "/" Then
                    strCode = "SCR/" & DateTime.Now.Year & "/" & "0000001"
                Else
                    intCount = Microsoft.VisualBasic.Right(dr.GetString(0), 6) + 1
                    strCode = "SCR/" & DateTime.Now.Year & "/" & Microsoft.VisualBasic.Right("000000" & intCount, 6)
                End If
            End If
            txtCode.Text = strCode
            dr.Close()
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Sub

    Sub PopulateProductionCode()
        Dim query As String = "Select ProductionCode From Productions where status = 3 and ProductionCode not in(select ProductionCode From scrapproductions Where Status <> 0)"
        Dim displayData As String = "ProductionCode"
        Dim valueData As String = "ProductionCode"
        Dim dac As DataAccess = New DataAccess
        Try
            dac.PopulateComBoBox(cmbProduct, query, displayData, valueData)
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Sub

    Sub PopulateMachine()
        Dim query As String = "Select machinecode From Machine_Productions where IsActive = 1"
        Dim displayData As String = "machinecode"
        Dim valueData As String = "machinecode"
        Dim dac As DataAccess = New DataAccess
        Try
            dac.PopulateComBoBox(cmbMachine, query, displayData, valueData)
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Sub

    Sub GridDetail()
        dgv.Columns.Clear()
        Try
            With dgv
                .Columns.Add(0, "Treatment")
                .Columns.Add(1, "No Roll")
                .Columns.Add(2, "SPL")
                .Columns.Add(3, "ST")
                .Columns.Add(4, "MP")
                .Columns.Add(5, "BT")
                .Columns.Add(6, "OC")
                .Columns.Add(7, "SG")
                .Columns.Add(8, "SC")
                .Columns.Add(9, "LR")
                .Columns.Add(10, "KP")
                .Columns.Add(11, "LL")
                .Columns.Add(12, "TTL")
                .Columns.Add(13, "Prod(Meter)")
                .Columns.Add(14, "No.Liner")
                .Columns.Add(15, "Keterangan")
            End With
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub

    Sub RetrieveProduction()
        Dim query As String
        Dim dac As DataAccess = New DataAccess
        Dim dr As MySqlDataReader

        query = "Select NoRoll,TreatmentCode From productiondetails where ProductionCode = '" & cmbProduct.Text & "'"
        Try
            dr = dac.ExecuteReader(query)
            While dr.Read
                If Not IsDBNull(dr.Item("TreatmentCode")) Then
                    With dgv
                        .Rows.Add()
                        .Item(0, intbaris).Value = dr.Item("NoRoll")
                        .Item(1, intbaris).Value = dr.Item("TreatmentCode")
                        .Item(2, intbaris).Value = 0
                        .Item(3, intbaris).Value = 0
                        .Item(4, intbaris).Value = 0
                        .Item(5, intbaris).Value = 0
                        .Item(6, intbaris).Value = 0
                        .Item(7, intbaris).Value = 0
                        .Item(8, intbaris).Value = 0
                        .Item(9, intbaris).Value = 0
                        .Item(10, intbaris).Value = 0
                        .Item(11, intbaris).Value = 0
                        .Item(12, intbaris).Value = 0
                        .Item(13, intbaris).Value = 0
                        .Item(14, intbaris).Value = 0
                        .Item(15, intbaris).Value = 0
                    End With
                End If
            End While
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub

    Function SaveData() As Boolean
        Dim insertHeader As String
        Dim insertDetail As String
        Dim sqlList As List(Of String) = New List(Of String)
        Dim dac As DataAccess = New DataAccess

        insertHeader = "insert into scrapproductions values('" & txtCode.Text & "','" & Format(dtpDate.Value, "yyyy-MM-dd") & "','" & cmbMachine.SelectedValue & "'" & vbCrLf
        insertHeader += ",'" & cmbShift.Text & "','" & cmbProduct.SelectedValue & "',1,'" & userCode & "','" & Format(Now, "yyyy-MM-dd") & "','" & userCode & "','" & Format(Now, "yyyy-MM-dd") & "')"
        sqlList.Add(insertHeader)

        For detail = 0 To Me.dgv.Rows.Count - 2
            insertDetail = "insert into scrapproductiondetails values('" & txtCode.Text & "','" & Me.dgv.Rows(detail).Cells(1).Value & "','" & Me.dgv.Rows(detail).Cells(0).Value & "'" & vbCrLf
            insertDetail += ",'" & Me.dgv.Rows(detail).Cells(2).Value & "','" & Me.dgv.Rows(detail).Cells(3).Value & "','" & Me.dgv.Rows(detail).Cells(4).Value & "'" & vbCrLf
            insertDetail += ",'" & Me.dgv.Rows(detail).Cells(5).Value & "','" & Me.dgv.Rows(detail).Cells(6).Value & "','" & Me.dgv.Rows(detail).Cells(7).Value & "'" & vbCrLf
            insertDetail += ",'" & Me.dgv.Rows(detail).Cells(8).Value & "','" & Me.dgv.Rows(detail).Cells(9).Value & "','" & Me.dgv.Rows(detail).Cells(10).Value & "'" & vbCrLf
            insertDetail += ",'" & Me.dgv.Rows(detail).Cells(11).Value & "','" & Me.dgv.Rows(detail).Cells(12).Value & "','" & Me.dgv.Rows(detail).Cells(13).Value & "'" & vbCrLf
            insertDetail += ",'" & Me.dgv.Rows(detail).Cells(14).Value & "','" & Me.dgv.Rows(detail).Cells(15).Value & "')"
            sqlList.Add(insertDetail)
        Next

        Try
            If dac.InsertMasterDetail(sqlList) Then
                Return True
            End If
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Function

    Function CheckIsEmpty() As Boolean
        Dim stat As Boolean = True
        If Trim(txtCode.Text) = String.Empty Then
            MsgBoxWarning("Application cant generated code,please contact IT")
            Close()
        ElseIf Trim(cmbShift.Text) = String.Empty Then
            MsgBoxWarning("Please choose shift")
            cmbShift.Focus()
        ElseIf dgv.RowCount = 1 Then
            MsgBoxWarning("Please fill details")
            cmbProduct.Focus()
        Else
            stat = False
        End If
        Return stat
    End Function

    Function ApprovedData() As Boolean
        Dim insertHeader As String
        Dim dac As DataAccess = New DataAccess
        insertHeader = "Update ScrapProductions set status = 3,Updated_by = '" & userCode & "',Updated_date = '" & Format(Now, "yyyy-MM-dd") & "' Where ScrapCode = '" & txtCode.Text & "'"
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

        insertHeader = "Update ScrapProductions set status = 0,Updated_by = '" & userCode & "',Updated_date = '" & Format(Now, "yyyy-MM-dd") & "' Where ScrapCode = '" & txtCode.Text & "'"
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

    Sub PrepareButton(ByVal statBool As Boolean)
        btnApproved.Enabled = statBool
        btnVoid.Enabled = statBool
    End Sub

    Sub RetrieveHeader()
        Dim queryHeader As String
        Dim dac As DataAccess = New DataAccess
        queryHeader = "Select ScrapCode,ScrapDate,MachineCode,Shift,ProductionCode From ScrapProductions Where ScrapCode = '" & strCode & "'"
        Dim dr As MySqlDataReader
        Try
            PopulateProductionCode()
            PopulateMachine()
            dr = dac.ExecuteReader(queryHeader)
            dr.Read()
            If dr.HasRows Then
                txtCode.Text = dr.Item("ScrapCode")
                dtpDate.Value = dr.Item("ScrapDate")
                cmbShift.Text = dr.Item("shift")
                cmbMachine.SelectedValue = dr.Item("MachineCode")
                cmbProduct.SelectedValue = dr.Item("ProductionCode")
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
        queryDetails = "Select * From scrapproductiondetails where scrapcode = '" & strCode & "'"
        Try
            GridDetail()
            dr = dac.ExecuteReader(queryDetails)
            While dr.Read
                If Not IsDBNull(dr.Item("ScrapCode")) Then
                    With dgv
                        .Rows.Add()
                        .Item(0, intbaris).Value = dr.Item("NoRoll")
                        .Item(1, intbaris).Value = dr.Item("TreatmentCode")
                        .Item(2, intbaris).Value = dr.Item("SPL")
                        .Item(3, intbaris).Value = dr.Item("ST")
                        .Item(4, intbaris).Value = dr.Item("MP")
                        .Item(5, intbaris).Value = dr.Item("BT")
                        .Item(6, intbaris).Value = dr.Item("OC")
                        .Item(7, intbaris).Value = dr.Item("SG")
                        .Item(8, intbaris).Value = dr.Item("SC")
                        .Item(9, intbaris).Value = dr.Item("LR")
                        .Item(10, intbaris).Value = dr.Item("KP")
                        .Item(11, intbaris).Value = dr.Item("LL")
                        .Item(12, intbaris).Value = dr.Item("TTL")
                        .Item(13, intbaris).Value = dr.Item("ProdMeter")
                        .Item(14, intbaris).Value = dr.Item("NumberLiner")
                        .Item(15, intbaris).Value = dr.Item("Description")
                    End With
                End If
            End While
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub

    Sub PreCreateDisplay()
        GeneratedCode()
        PopulateMachine()
        PopulateProductionCode()
        GridDetail()
        PrepareButton(False)
    End Sub


    Sub PreUpdateDisplay()
        PrepareButton(True)
        RetrieveHeader()
        RetrieveDetails()
    End Sub

    Private Sub FrmScrap_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        intbaris = 0
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

    Private Sub btnProses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProses.Click
        If statView = "New" Then
            RetrieveProduction()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If statView = "New" Then
            If CheckIsEmpty() = False Then
                If SaveData() = True Then
                    MsgBoxSaved()
                    Close()
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

    Private Sub btnApproved_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApproved.Click
        If statView = "Update" Then
            If ApprovedData() = True Then
                MsgBoxApproved()
                Close()
            End If
        End If
    End Sub

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        If statView = "Update" Then
            If VoidData() = True Then
                MsgBoxVoid()
                Close()
            End If
        End If
    End Sub
End Class