Public Class FrmRptScrap
    Dim query As String
    Dim dt As DataTable
    Sub PrintScrapShiftAll()
        Dim dac As New DataAccess
        Dim myReport As New CrScrap
        query = "SELECT scdet.*,scp.ScrapDate ,scp.machinecode,scp.shift,scp.productioncode" & vbCrLf
        query += "FROM scrapproductiondetails as scdet inner join scrapproductions as scp ON scp.ScrapCode = scdet.ScrapCode"
        Try
            Cursor.Current = Cursors.WaitCursor
            dt = dac.RetrieveListData(query)
            myReport.SetDataSource(dt)
            crv.ReportSource = myReport
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub

    Sub PrintScrapShift()
        Dim dac As New DataAccess
        Dim myReport As New CrScrap
        query = "SELECT scdet.*,scp.ScrapDate ,scp.machinecode,scp.shift,scp.productioncode" & vbCrLf
        query += "FROM scrapproductiondetails as scdet inner join scrapproductions as scp ON scp.ScrapCode = scdet.ScrapCode where scp.shift = '" & cmbShift.Text & "'"
        Try
            Cursor.Current = Cursors.WaitCursor
            dt = dac.RetrieveListData(query)
            myReport.SetDataSource(dt)
            crv.ReportSource = myReport
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub

    Sub PrintScrapShiftPeriodeAll()
        Dim dac As New DataAccess
        Dim myReport As New CrScrap
        query = "SELECT scdet.*,scp.ScrapDate ,scp.machinecode,scp.shift,scp.productioncode" & vbCrLf
        query += "FROM scrapproductiondetails as scdet inner join scrapproductions as scp ON scp.ScrapCode = scdet.ScrapCode" & vbCrLf
        query += "Where (scp.ScrapDate BETWEEN '" & Format(dtpAwal.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpAkhir.Value, "yyyy-MM-dd") & "')"
        Try
            Cursor.Current = Cursors.WaitCursor
            dt = dac.RetrieveListData(query)
            myReport.SetDataSource(dt)
            crv.ReportSource = myReport
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub

    Sub PrintScrapShiftPeriode()
        Dim dac As New DataAccess
        Dim myReport As New CrScrap
        query = "SELECT scdet.*,scp.ScrapDate ,scp.machinecode,scp.shift,scp.productioncode" & vbCrLf
        query += "FROM scrapproductiondetails as scdet inner join scrapproductions as scp ON scp.ScrapCode = scdet.ScrapCode" & vbCrLf
        query += "Where (scp.ScrapDate BETWEEN '" & Format(dtpAwal.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpAkhir.Value, "yyyy-MM-dd") & "') And scp.shift = '" & cmbShift1.Text & "'"
        Try
            Cursor.Current = Cursors.WaitCursor
            dt = dac.RetrieveListData(query)
            myReport.SetDataSource(dt)
            crv.ReportSource = myReport
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub

    Sub PrintScrapPeriode()
        Dim dac As New DataAccess
        Dim myReport As New CrScrap
        query = "SELECT scdet.*,scp.ScrapDate ,scp.machinecode,scp.shift,scp.productioncode" & vbCrLf
        query += "FROM scrapproductiondetails as scdet inner join scrapproductions as scp ON scp.ScrapCode = scdet.ScrapCode" & vbCrLf
        query += "Where (scp.ScrapDate BETWEEN '" & Format(dtpAwal.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpAkhir.Value, "yyyy-MM-dd") & "')"
        Try
            Cursor.Current = Cursors.WaitCursor
            dt = dac.RetrieveListData(query)
            myReport.SetDataSource(dt)
            crv.ReportSource = myReport
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            MsgBoxError(ex.Message)
        End Try
    End Sub

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        If cmbShift.Text = "All" Then
            PrintScrapShiftAll()
        Else
            PrintScrapShift()
        End If
    End Sub

    Private Sub FrmRptScrap_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmbShift.Text = ""
        cmbShift1.Text = ""
    End Sub

    Private Sub btnProcess1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess1.Click
        If cmbShift1.Text = "All" Then
            PrintScrapShiftPeriodeAll()
        Else
            PrintScrapShiftPeriode()
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Close()
    End Sub
End Class