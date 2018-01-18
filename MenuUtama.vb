Public Class MenuUtama
    
    Sub MenuLeader()
        menuMaster.Visible = False
        menuUser.Visible = False
        menuCompound.Visible = False
        menuTreatment.Visible = False
        menuNumSpec.Visible = False
        menuNylon.Visible = False
        menuMachine.Visible = False
        menuTrans.Visible = True
        menuSchedule.Visible = True
        menuProd.Visible = True
        menuScrap.Visible = True
        menuReport.Visible = True
        menuRptProd.Visible = True
        menuRptSche.Visible = True
        menuRptScrap.Visible = True
    End Sub
    Sub MenuAdmin()
        menuMaster.Visible = False
        menuUser.Visible = False
        menuCompound.Visible = False
        menuTreatment.Visible = False
        menuNumSpec.Visible = False
        menuNylon.Visible = False
        menuMachine.Visible = False
        menuTrans.Visible = False
        menuSchedule.Visible = False
        menuProd.Visible = False
        menuScrap.Visible = False
        menuReport.Visible = True
        menuRptProd.Visible = True
        menuRptSche.Visible = True
        menuRptScrap.Visible = True
    End Sub
    Sub MenuOperator()
        menuMaster.Visible = False
        menuUser.Visible = False
        menuCompound.Visible = False
        menuTreatment.Visible = False
        menuNumSpec.Visible = False
        menuNylon.Visible = False
        menuMachine.Visible = False
        menuTrans.Visible = True
        menuSchedule.Visible = True
        menuProd.Visible = True
        menuScrap.Visible = True
        menuReport.Visible = False
        menuReport.Visible = False
        menuRptProd.Visible = False
        menuRptSche.Visible = False
        menuRptScrap.Visible = False
    End Sub
    '
    Sub MenuPPC()
        menuMaster.Visible = True
        menuUser.Visible = True
        menuCompound.Visible = True
        menuTreatment.Visible = True
        menuNumSpec.Visible = True
        menuNylon.Visible = True
        menuMachine.Visible = True
        menuTrans.Visible = True
        menuSchedule.Visible = True
        menuProd.Visible = False
        menuScrap.Visible = False
        menuReport.Visible = False
        menuRptProd.Visible = False
        menuRptSche.Visible = False
        menuRptScrap.Visible = False
    End Sub

    Sub PrepeareDisplay()
        user.Text = userName & "(" & userAccess & ")"
        tgl.Text = Format(Now, "dd-MMM-yyyy")
        
        'Me.IsMdiContainer = True
        If userAccess = "Admin" Then
            MenuAdmin()
        ElseIf userAccess = "Leader" Then
            MenuLeader()
        ElseIf userAccess = "Production" Then
            MenuOperator()
        ElseIf userAccess = "PPC" Then
            MenuPPC()
        End If
    End Sub

    Private Sub MenuUtama_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub
    Private Sub MenuUtama_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PrepeareDisplay()
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

    
    Private Sub menuCompound_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuCompound.Click
        FrmCompound.ShowDialog()
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

    Private Sub menuRptSche_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuRptSche.Click
        FrmRptSchedule.ShowDialog()
    End Sub

    Private Sub menuRptProd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuRptProd.Click
        FrmRptProduction.ShowDialog()
    End Sub

    Private Sub menuRptScrap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles menuRptScrap.Click
        FrmScrap.ShowDialog()
    End Sub
End Class