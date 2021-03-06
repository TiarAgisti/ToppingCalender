﻿Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class FrmListScrap
    Dim queryList As String
    Sub HeaderGrid()
        dgv.Columns(0).HeaderText = "Scrap Code"
        dgv.Columns(0).Width = 150
        dgv.Columns(1).HeaderText = "Date"
        dgv.Columns(1).DefaultCellStyle.Format = "dd-MMM-yyyy"
        dgv.Columns(2).HeaderText = "Machine Code"
        dgv.Columns(2).Width = 150
        dgv.Columns(3).HeaderText = "Shift"
        dgv.Columns(4).HeaderText = "Production Code"
        dgv.Columns(4).Width = 150
        dgv.Columns(5).HeaderText = "Status"
    End Sub
    Sub RetriveList()
        Dim dac As DataAccess = New DataAccess
        queryList = "Select ScrapCode,ScrapDate,MachineCode,Shift,ProductionCode,Case When Status = 1 Then 'New'" & vbCrLf
        queryList += "When Status = 2 Then 'Revision' When Status = 3 Then 'Approved' Else 'Void' End StatDesc" & vbCrLf
        queryList += "From ScrapProductions"
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
        queryList = "Select ScrapCode,ScrapDate,MachineCode,Shift,ProductionCode,Case When Status = 1 Then 'New'" & vbCrLf
        queryList += "When Status = 2 Then 'Revision' When Status = 3 Then 'Approved' Else 'Void' End StatDesc" & vbCrLf
        queryList += "From ScrapProductions" & vbCrLf

        If rdCode.Checked = True Then
            If Trim(txtCode.Text) = "" Then
                MsgBoxWarning("Please fill Production Code")
                Exit Sub
            Else
                queryList += "Where ScrapCode = '" & txtCode.Text & "'"
            End If

        End If

        If rdDate.Checked = True Then
            queryList += "Where ScrapDate = '" & Format(dtpDate.Value, "yyyy-MM-dd") & "'"
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
        FrmScrap.statView = "New"
        FrmScrap.ShowDialog()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim row As Integer = dgv.CurrentRow.Index
        FrmScrap.statView = "Update"
        FrmScrap.strCode = dgv.Item(0, row).Value
        FrmScrap.ShowDialog()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub FrmListScrap_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        RetriveList()
    End Sub
End Class