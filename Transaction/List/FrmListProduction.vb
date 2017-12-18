Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class FrmListProduction
    Dim queryList As String = "Select ProductionCode,ProductionDate,ExpDate,ScheduleCode,Shift,Case When Status = 1 Then 'New'" & _
                                "When Status = 2 Then 'Revision' When Status = 3 Then 'Approved' Else 'Void' End StatDesc" & _
                                "From Productions"

    Sub HeaderGrid()
        dgv.Columns(0).HeaderText = "Production Code"
        dgv.Columns(1).HeaderText = "Date"
        dgv.Columns(1).DefaultCellStyle.Format = "dd-MMM-yyyy"
        dgv.Columns(2).HeaderText = "Expired Date"
        dgv.Columns(2).DefaultCellStyle.Format = "dd-MMM-yyyy"
        dgv.Columns(3).HeaderText = "Schedule Code"
        dgv.Columns(4).HeaderText = "Shift"
        dgv.Columns(5).HeaderText = "Status"
    End Sub

    Sub RetriveList()
        Dim dac As DataAccess = New DataAccess
        Try
            dgv.DataSource = dac.RetrieveListData(queryList)
            dgv.ReadOnly = True
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
        dac = Nothing
    End Sub

    Sub RetrieveListSearch()
        If rdCode.Checked = True Then
            If Trim(txtCode.Text) = "" Then
                MsgBoxWarning("Please fill Production Code")
                Exit Sub
            Else
                queryList += " And ProductionCode = '" & txtCode.Text & "'"
            End If

        End If

        If rdDate.Checked = True Then
            queryList += " And ProductionDate = '" & Format(dtpDate.Value, "yyyy-MM-dd") & "'"
        End If

        Dim dac As DataAccess = New DataAccess
        Try
            dgv.DataSource = dac.RetrieveListData(queryList)
            dgv.ReadOnly = True
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        RetrieveListSearch()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        RetriveList()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        FrmProduction.statView = "New"
        FrmProduction.ShowDialog()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim row As Integer = dgv.CurrentRow.Index
        FrmProduction.statView = "Update"
        FrmProduction.strCode = dgv.Item(0, row).Value
        FrmProduction.ShowDialog()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class