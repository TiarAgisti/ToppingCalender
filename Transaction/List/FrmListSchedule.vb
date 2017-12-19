Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class FrmListSchedule
    Dim queryList As String = "Select ScheduleCode,ScheduleDate,Revision,Case When Status = 1 Then 'New'" & _
                                "When Status = 2 Then 'Revision' When Status = 3 Then 'Approved' When Status = 4 Then 'Production' Else 'Void' End StatDesc" & _
                                "From Schedules"
    Sub HeaderGrid()
        dgv.Columns(0).HeaderText = "Schedule Code"
        dgv.Columns(1).HeaderText = "Date"
        dgv.Columns(1).DefaultCellStyle.Format = "dd-MMM-yyyy"
        dgv.Columns(2).HeaderText = "Revision"
        dgv.Columns(3).HeaderText = "Status"
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
        If rdSchedule.Checked = True Then
            If Trim(txtCode.Text) = "" Then
                MsgBoxWarning("Please fill Schedule Code")
                Exit Sub
            Else
                queryList += " And ScheduleCode = '" & txtCode.Text & "'"
            End If

        End If

        If rdDate.Checked = True Then
            queryList += " And ScheduleDate = '" & Format(dtpDate.Value, "yyyy-MM-dd") & "'"
        End If

        Dim dac As DataAccess = New DataAccess
        Try
            dgv.DataSource = dac.RetrieveListData(queryList)
            dgv.ReadOnly = True
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        FrmSchedule.statView = "New"
        FrmSchedule.ShowDialog()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim row As Integer = dgv.CurrentRow.Index
        FrmSchedule.statView = "Update"
        FrmSchedule.strScheduleCode = dgv.Item(0, row).Value
        FrmSchedule.ShowDialog()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        RetrieveListSearch()
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        RetriveList()
    End Sub
End Class