Public Class MenuUtama
    Dim boolMenuMaster As Boolean
    Dim boolMenuTrans As Boolean
    Dim boolMenuReport As Boolean
    Dim boolMenuSetting As Boolean

    Sub StatusMenuMaster(ByVal status As Boolean)
        menuUser.Visible = status
        menuMachine.Visible = status
        menuTreatment.Visible = status
        menuNylon.Visible = status
        menuNumSpec.Visible = status
        menuCompound.Visible = status
    End Sub

    Sub StatusMenuTransaction(ByVal status As Boolean)
        menuSchedule.Visible = status
        menuProd.Visible = status
        menuScrap.Visible = status
    End Sub

    Sub StatusMenuReport(ByVal status As Boolean)
        menuRptProd.Visible = status
        menuRptSche.Visible = status
        menuRptScrap.Visible = status
    End Sub

    Sub StatusMenuSetting(ByVal status As Boolean)
        menuChangePass.Visible = status
    End Sub
    Sub MenuLeader()
        menuMaster.Visible = False
        menuTrans.Visible = True
        menuReport.Visible = True
    End Sub
    Sub MenuAdmin()
        menuMaster.Visible = True
        menuTrans.Visible = True
        menuReport.Visible = True
    End Sub
    Sub MenuOperator()
        menuMaster.Visible = False
        menuTrans.Visible = True
        menuReport.Visible = False
    End Sub

    Sub PrepeareDisplay()
        user.Text = userName & "(" & userAccess & ")"
        tgl.Text = Format(Now, "dd-MMM-yyyy")
        boolMenuMaster = False
        boolMenuTrans = False
        boolMenuReport = False
        boolMenuSetting = False

        StatusMenuMaster(boolMenuMaster)
        StatusMenuTransaction(boolMenuTrans)
        StatusMenuReport(boolMenuReport)
        StatusMenuSetting(boolMenuSetting)
        'Me.IsMdiContainer = True
        If userAccess = "Admin" Then
            MenuAdmin()
        ElseIf userAccess = "Leader" Then
            MenuLeader()
        ElseIf userAccess = "Production" Then
            MenuOperator()
        End If
    End Sub

    Private Sub MenuUtama_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub
    Private Sub MenuUtama_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PrepeareDisplay()
    End Sub
    Private Sub menuMaster_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuMaster.Click
        If boolMenuMaster = False Then
            boolMenuMaster = True
        Else
            boolMenuMaster = False
        End If
        StatusMenuMaster(boolMenuMaster)
    End Sub

    Private Sub menuUser_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuUser.Click
        FrmUser.ShowDialog()
    End Sub

    Private Sub menuTreatment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuTreatment.Click
        FrmTreatment.ShowDialog()
    End Sub

    Private Sub menuNylon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuNylon.Click
        FrmNylon.ShowDialog()
    End Sub

    Private Sub menuTrans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuTrans.Click
        If boolMenuTrans = False Then
            boolMenuTrans = True
        Else
            boolMenuTrans = False
        End If
        StatusMenuTransaction(boolMenuTrans)
    End Sub

    Private Sub menuReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuReport.Click
        If boolMenuReport = False Then
            boolMenuReport = True
        Else
            boolMenuReport = False
        End If
        StatusMenuReport(boolMenuReport)
    End Sub

    Private Sub menuCompound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuCompound.Click
        FrmCompound.ShowDialog()
    End Sub

    Private Sub menuSetting_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuSetting.Click
        If boolMenuSetting = False Then
            boolMenuSetting = True
        Else
            boolMenuSetting = False
        End If
        StatusMenuSetting(boolMenuSetting)
    End Sub

    Private Sub menuChangePass_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuChangePass.Click
        FrmChangePassword.ShowDialog()
    End Sub

    Private Sub menuExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuExit.Click
        Dim result As DialogResult = MsgBoxQuestionExit()
        If result = MsgBoxResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub menuSchedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuSchedule.Click
        FrmListSchedule.ShowDialog()
    End Sub

    Private Sub menuProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuProd.Click
        FrmListProduction.ShowDialog()
    End Sub

    Private Sub menuScrap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuScrap.Click
        FrmListScrap.ShowDialog()
    End Sub

    Private Sub menuNumSpec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuNumSpec.Click
        FrmNumSpec.ShowDialog()
    End Sub

    Private Sub menuMachine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuMachine.Click
        FrmMachine.ShowDialog()
    End Sub
End Class