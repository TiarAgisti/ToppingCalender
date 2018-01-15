Imports System.Windows.Forms
Public Class FrmRptSchedule
    Dim query As String
    Dim dt As DataTable

    Sub PrintAllShift()
        Dim dac As New DataAccess
        Dim myReport As New CrScheduleShift
        query = "SELECT schdet.*, sch.ScheduleDate,sch.Revision" & vbCrLf
        query += "FROM scheduledetails as schdet" & vbCrLf
        query += "inner join schedules as sch ON sch.ScheduleCode = schdet.ScheduleCode"

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

    Sub PrintShift1()
        Dim dac As New DataAccess
        Dim myReport As New CrScheduleShift1
        query = "SELECT schdet.*, sch.ScheduleDate,sch.Revision" & vbCrLf
        query += "FROM scheduledetails as schdet" & vbCrLf
        query += "inner join schedules as sch ON sch.ScheduleCode = schdet.ScheduleCode"

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

    Sub PrintShift2()
        Dim dac As New DataAccess
        Dim myReport As New CrScheduleShift2
        query = "SELECT schdet.*, sch.ScheduleDate,sch.Revision" & vbCrLf
        query += "FROM scheduledetails as schdet" & vbCrLf
        query += "inner join schedules as sch ON sch.ScheduleCode = schdet.ScheduleCode"

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

    Sub PrintShift3()
        Dim dac As New DataAccess
        Dim myReport As New CrScheduleShift3
        query = "SELECT schdet.*, sch.ScheduleDate,sch.Revision" & vbCrLf
        query += "FROM scheduledetails as schdet" & vbCrLf
        query += "inner join schedules as sch ON sch.ScheduleCode = schdet.ScheduleCode"

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

    Sub PrintPeriode()
        Dim dac As New DataAccess
        Dim myReport As New CrScheduleShift
        query = "SELECT schdet.*, sch.ScheduleDate,sch.Revision" & vbCrLf
        query += "FROM scheduledetails as schdet" & vbCrLf
        query += "inner join schedules as sch ON sch.ScheduleCode = schdet.ScheduleCode" & vbCrLf
        query += "Where (sch.ScheduleDate BETWEEN '" & Format(dtpAwal.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpAkhir.Value, "yyyy-MM-dd") & "')"

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

    Sub PrintPeriode2()
        Dim dac As New DataAccess
        Dim myReport As New CrScheduleShift
        query = "SELECT schdet.*, sch.ScheduleDate,sch.Revision" & vbCrLf
        query += "FROM scheduledetails as schdet" & vbCrLf
        query += "inner join schedules as sch ON sch.ScheduleCode = schdet.ScheduleCode" & vbCrLf
        query += "Where (sch.ScheduleDate BETWEEN '" & Format(dtpAwal1.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpAkhir1.Value, "yyyy-MM-dd") & "')"

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
    Sub PrintPeriodeshift1()
        Dim dac As New DataAccess
        Dim myReport As New CrScheduleShift1
        query = "SELECT schdet.*, sch.ScheduleDate,sch.Revision" & vbCrLf
        query += "FROM scheduledetails as schdet" & vbCrLf
        query += "inner join schedules as sch ON sch.ScheduleCode = schdet.ScheduleCode" & vbCrLf
        query += "Where (sch.ScheduleDate BETWEEN '" & Format(dtpAwal1.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpAkhir1.Value, "yyyy-MM-dd") & "')"

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

    Sub PrintPeriodeShift2()
        Dim dac As New DataAccess
        Dim myReport As New CrScheduleShift2
        query = "SELECT schdet.*, sch.ScheduleDate,sch.Revision" & vbCrLf
        query += "FROM scheduledetails as schdet" & vbCrLf
        query += "inner join schedules as sch ON sch.ScheduleCode = schdet.ScheduleCode" & vbCrLf
        query += "Where (sch.ScheduleDate BETWEEN '" & Format(dtpAwal1.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpAkhir1.Value, "yyyy-MM-dd") & "')"

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

    Sub PrintPeriodeshift3()
        Dim dac As New DataAccess
        Dim myReport As New CrScheduleShift3
        query = "SELECT schdet.*, sch.ScheduleDate,sch.Revision" & vbCrLf
        query += "FROM scheduledetails as schdet" & vbCrLf
        query += "inner join schedules as sch ON sch.ScheduleCode = schdet.ScheduleCode" & vbCrLf
        query += "Where (sch.ScheduleDate BETWEEN '" & Format(dtpAwal1.Value, "yyyy-MM-dd") & "' AND '" & Format(dtpAkhir1.Value, "yyyy-MM-dd") & "')"

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
            PrintAllShift()
        ElseIf cmbShift.Text = "1" Then
            PrintShift1()
        ElseIf cmbShift.Text = "2" Then
            PrintShift2()
        ElseIf cmbShift.Text = "3" Then
            PrintShift3()
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub btnProcess3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess3.Click
        PrintPeriode()
    End Sub

    Private Sub btnProcess2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess2.Click
        If cmbShift1.Text = "All" Then
            PrintPeriode2()
        ElseIf cmbShift1.Text = "1" Then
            PrintPeriodeshift1()
        ElseIf cmbShift1.Text = "2" Then
            PrintPeriodeShift2()
        ElseIf cmbShift1.Text = "3" Then
            PrintPeriodeshift3()
        End If
    End Sub

    Private Sub FrmRptSchedule_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmbShift.Text = ""
        cmbShift1.Text = ""
    End Sub
End Class