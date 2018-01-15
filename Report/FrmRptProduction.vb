Public Class FrmRptProduction
    Dim query As String
    Dim dt As DataTable

    Sub PrintProductionShiftAll()
        Dim dac As New DataAccess
        Dim myReport As New CrRptProduction

        query = "SELECT prd.ProductionCode,prd.ProductionDate,prd.ExpDate,prd.ScheduleCode,prd.shift" & vbCrLf
        query += ",prddet.NoRoll,prddet.TreatmentCode,prddet.NumberSpec,prddet.supplier,prddet.NylonCode,prddet.DateInNylon,prddet.CompountCode" & vbCrLf
        query += ",prddet.Sign,prddet.actual,prddet.qtymeter,prddet.information" & vbCrLf
        query += "FROM productions as prd" & vbCrLf
        query += "inner join productiondetails as prddet on prd.ProductionCode = prddet.ProductionCode"

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

    Sub PrintProductionShift()
        Dim dac As New DataAccess
        Dim myReport As New CrRptProduction

        query = "SELECT prd.ProductionCode,prd.ProductionDate,prd.ExpDate,prd.ScheduleCode,prd.shift" & vbCrLf
        query += ",prddet.NoRoll,prddet.TreatmentCode,prddet.NumberSpec,prddet.supplier,prddet.NylonCode,prddet.DateInNylon,prddet.CompountCode" & vbCrLf
        query += ",prddet.Sign,prddet.actual,prddet.qtymeter,prddet.information" & vbCrLf
        query += "FROM productions as prd" & vbCrLf
        query += "inner join productiondetails as prddet on prd.ProductionCode = prddet.ProductionCode" & vbCrLf
        query += "Where prd.shift = '" & cmbShift.Text & "'"

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

    Sub PrintProductionShiftPeriodeAll()
        Dim dac As New DataAccess
        Dim myReport As New CrRptProduction

        query = "SELECT prd.ProductionCode,prd.ProductionDate,prd.ExpDate,prd.ScheduleCode,prd.shift" & vbCrLf
        query += ",prddet.NoRoll,prddet.TreatmentCode,prddet.NumberSpec,prddet.supplier,prddet.NylonCode,prddet.DateInNylon,prddet.CompountCode" & vbCrLf
        query += ",prddet.Sign,prddet.actual,prddet.qtymeter,prddet.information" & vbCrLf
        query += "FROM productions as prd" & vbCrLf
        query += "inner join productiondetails as prddet on prd.ProductionCode = prddet.ProductionCode" & vbCrLf
        query += "Where (prd.ProductionDate BETWEEN '" & Format(dtpAwal.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpAkhir.Value, "yyyy-MM-dd") & "')"

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

    Sub PrintProductionShiftPeriode()
        Dim dac As New DataAccess
        Dim myReport As New CrRptProduction

        query = "SELECT prd.ProductionCode,prd.ProductionDate,prd.ExpDate,prd.ScheduleCode,prd.shift" & vbCrLf
        query += ",prddet.NoRoll,prddet.TreatmentCode,prddet.NumberSpec,prddet.supplier,prddet.NylonCode,prddet.DateInNylon,prddet.CompountCode" & vbCrLf
        query += ",prddet.Sign,prddet.actual,prddet.qtymeter,prddet.information" & vbCrLf
        query += "FROM productions as prd" & vbCrLf
        query += "inner join productiondetails as prddet on prd.ProductionCode = prddet.ProductionCode" & vbCrLf
        query += "Where (prd.ProductionDate BETWEEN '" & Format(dtpAwal.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpAkhir.Value, "yyyy-MM-dd") & "') And prd.shift = '" & cmbShift1.Text & "'"

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

    Sub PrintProductionPeriode()
        Dim dac As New DataAccess
        Dim myReport As New CrRptProduction

        query = "SELECT prd.ProductionCode,prd.ProductionDate,prd.ExpDate,prd.ScheduleCode,prd.shift" & vbCrLf
        query += ",prddet.NoRoll,prddet.TreatmentCode,prddet.NumberSpec,prddet.supplier,prddet.NylonCode,prddet.DateInNylon,prddet.CompountCode" & vbCrLf
        query += ",prddet.Sign,prddet.actual,prddet.qtymeter,prddet.information" & vbCrLf
        query += "FROM productions as prd" & vbCrLf
        query += "inner join productiondetails as prddet on prd.ProductionCode = prddet.ProductionCode" & vbCrLf
        query += "Where (prd.ProductionDate BETWEEN '" & Format(dtpAwal1.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpAkhir1.Value, "yyyy-MM-dd") & "')"

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

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub FrmRptProduction_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmbShift.Text = ""
        cmbShift1.Text = ""
    End Sub

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        If cmbShift.Text = "All" Then
            PrintProductionShiftAll()
        Else
            PrintProductionShiftPeriode()
        End If
    End Sub

    Private Sub btnProcess1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess1.Click
        If cmbShift1.Text = "All" Then
            PrintProductionShiftPeriodeAll()
        Else
            PrintProductionShift()
        End If
    End Sub

    Private Sub cmbShift_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmbShift.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub btnProcess2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess2.Click

    End Sub
End Class