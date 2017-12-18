<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSchedule
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSchedule))
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtRev = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.dtpDate = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtCode = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.txtExpected = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.cmbMachine = New System.Windows.Forms.ComboBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtConsShift = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtConsDay = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbTreatment = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtDesc1 = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtMeter1 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtRoll1 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtSch1 = New System.Windows.Forms.TextBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtCons1 = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtActual1 = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtDesc2 = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtMeter2 = New System.Windows.Forms.TextBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtRoll2 = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtSchRoll2 = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtCons2 = New System.Windows.Forms.TextBox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtActual2 = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtDesc3 = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.txtMeter3 = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtRoll3 = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.txtSchRoll3 = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.txtCons3 = New System.Windows.Forms.TextBox
        Me.Label26 = New System.Windows.Forms.Label
        Me.txtActual3 = New System.Windows.Forms.TextBox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.dgv = New System.Windows.Forms.DataGridView
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.btnApproved = New System.Windows.Forms.Button
        Me.btnVoid = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(823, 39)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Schedule Production"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.txtRev)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.dtpDate)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.txtCode)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(823, 58)
        Me.Panel1.TabIndex = 5
        '
        'txtRev
        '
        Me.txtRev.Enabled = False
        Me.txtRev.Location = New System.Drawing.Point(716, 20)
        Me.txtRev.Name = "txtRev"
        Me.txtRev.Size = New System.Drawing.Size(72, 20)
        Me.txtRev.TabIndex = 10
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(661, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(27, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Rev"
        '
        'dtpDate
        '
        Me.dtpDate.Enabled = False
        Me.dtpDate.Location = New System.Drawing.Point(433, 20)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(197, 20)
        Me.dtpDate.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(397, 23)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Date"
        '
        'txtCode
        '
        Me.txtCode.Enabled = False
        Me.txtCode.Location = New System.Drawing.Point(97, 20)
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(275, 20)
        Me.txtCode.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(11, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Schedule Code"
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.txtExpected)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.cmbMachine)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.txtConsShift)
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.txtConsDay)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.cmbTreatment)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 97)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(823, 82)
        Me.Panel2.TabIndex = 6
        '
        'txtExpected
        '
        Me.txtExpected.Location = New System.Drawing.Point(605, 47)
        Me.txtExpected.MaxLength = 6
        Me.txtExpected.Name = "txtExpected"
        Me.txtExpected.Size = New System.Drawing.Size(98, 20)
        Me.txtExpected.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(602, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(86, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Expected Speed"
        '
        'cmbMachine
        '
        Me.cmbMachine.FormattingEnabled = True
        Me.cmbMachine.Location = New System.Drawing.Point(350, 46)
        Me.cmbMachine.Name = "cmbMachine"
        Me.cmbMachine.Size = New System.Drawing.Size(211, 21)
        Me.cmbMachine.TabIndex = 16
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(296, 49)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(48, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Machine"
        '
        'txtConsShift
        '
        Me.txtConsShift.Location = New System.Drawing.Point(350, 20)
        Me.txtConsShift.MaxLength = 6
        Me.txtConsShift.Name = "txtConsShift"
        Me.txtConsShift.Size = New System.Drawing.Size(98, 20)
        Me.txtConsShift.TabIndex = 14
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(296, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(55, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Cons Shift"
        '
        'txtConsDay
        '
        Me.txtConsDay.Location = New System.Drawing.Point(72, 47)
        Me.txtConsDay.MaxLength = 6
        Me.txtConsDay.Name = "txtConsDay"
        Me.txtConsDay.Size = New System.Drawing.Size(98, 20)
        Me.txtConsDay.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(13, 50)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Cons Day"
        '
        'cmbTreatment
        '
        Me.cmbTreatment.FormattingEnabled = True
        Me.cmbTreatment.Location = New System.Drawing.Point(72, 20)
        Me.cmbTreatment.Name = "cmbTreatment"
        Me.cmbTreatment.Size = New System.Drawing.Size(211, 21)
        Me.cmbTreatment.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(11, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 13)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Treatment"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtDesc1)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtMeter1)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.txtRoll1)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.txtSch1)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtCons1)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtActual1)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 179)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(823, 83)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SHIFT 1"
        '
        'txtDesc1
        '
        Me.txtDesc1.Location = New System.Drawing.Point(446, 54)
        Me.txtDesc1.MaxLength = 100
        Me.txtDesc1.Name = "txtDesc1"
        Me.txtDesc1.Size = New System.Drawing.Size(343, 20)
        Me.txtDesc1.TabIndex = 26
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(378, 57)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(60, 13)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "Description"
        '
        'txtMeter1
        '
        Me.txtMeter1.Location = New System.Drawing.Point(446, 28)
        Me.txtMeter1.MaxLength = 6
        Me.txtMeter1.Name = "txtMeter1"
        Me.txtMeter1.Size = New System.Drawing.Size(98, 20)
        Me.txtMeter1.TabIndex = 24
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(378, 31)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(34, 13)
        Me.Label14.TabIndex = 23
        Me.Label14.Text = "Meter"
        '
        'txtRoll1
        '
        Me.txtRoll1.Location = New System.Drawing.Point(265, 54)
        Me.txtRoll1.MaxLength = 6
        Me.txtRoll1.Name = "txtRoll1"
        Me.txtRoll1.Size = New System.Drawing.Size(98, 20)
        Me.txtRoll1.TabIndex = 22
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(197, 57)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(25, 13)
        Me.Label13.TabIndex = 21
        Me.Label13.Text = "Roll"
        '
        'txtSch1
        '
        Me.txtSch1.Location = New System.Drawing.Point(265, 28)
        Me.txtSch1.MaxLength = 6
        Me.txtSch1.Name = "txtSch1"
        Me.txtSch1.Size = New System.Drawing.Size(98, 20)
        Me.txtSch1.TabIndex = 20
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(197, 31)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(50, 13)
        Me.Label12.TabIndex = 19
        Me.Label12.Text = "SCH Roll"
        '
        'txtCons1
        '
        Me.txtCons1.Location = New System.Drawing.Point(93, 54)
        Me.txtCons1.MaxLength = 6
        Me.txtCons1.Name = "txtCons1"
        Me.txtCons1.Size = New System.Drawing.Size(89, 20)
        Me.txtCons1.TabIndex = 18
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 57)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(55, 13)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Cons Shift"
        '
        'txtActual1
        '
        Me.txtActual1.Location = New System.Drawing.Point(93, 28)
        Me.txtActual1.MaxLength = 6
        Me.txtActual1.Name = "txtActual1"
        Me.txtActual1.Size = New System.Drawing.Size(89, 20)
        Me.txtActual1.TabIndex = 16
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 31)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(71, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Actual Speed"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtDesc2)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txtMeter2)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.txtRoll2)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txtSchRoll2)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.txtCons2)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.txtActual2)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 262)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(823, 80)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "SHIFT 2"
        '
        'txtDesc2
        '
        Me.txtDesc2.Location = New System.Drawing.Point(446, 54)
        Me.txtDesc2.MaxLength = 100
        Me.txtDesc2.Name = "txtDesc2"
        Me.txtDesc2.Size = New System.Drawing.Size(343, 20)
        Me.txtDesc2.TabIndex = 26
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(378, 57)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 13)
        Me.Label16.TabIndex = 25
        Me.Label16.Text = "Description"
        '
        'txtMeter2
        '
        Me.txtMeter2.Location = New System.Drawing.Point(446, 28)
        Me.txtMeter2.MaxLength = 6
        Me.txtMeter2.Name = "txtMeter2"
        Me.txtMeter2.Size = New System.Drawing.Size(98, 20)
        Me.txtMeter2.TabIndex = 24
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(378, 31)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(34, 13)
        Me.Label17.TabIndex = 23
        Me.Label17.Text = "Meter"
        '
        'txtRoll2
        '
        Me.txtRoll2.Location = New System.Drawing.Point(265, 54)
        Me.txtRoll2.MaxLength = 6
        Me.txtRoll2.Name = "txtRoll2"
        Me.txtRoll2.Size = New System.Drawing.Size(98, 20)
        Me.txtRoll2.TabIndex = 22
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(197, 57)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(25, 13)
        Me.Label18.TabIndex = 21
        Me.Label18.Text = "Roll"
        '
        'txtSchRoll2
        '
        Me.txtSchRoll2.Location = New System.Drawing.Point(265, 28)
        Me.txtSchRoll2.MaxLength = 6
        Me.txtSchRoll2.Name = "txtSchRoll2"
        Me.txtSchRoll2.Size = New System.Drawing.Size(98, 20)
        Me.txtSchRoll2.TabIndex = 20
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(197, 31)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(50, 13)
        Me.Label19.TabIndex = 19
        Me.Label19.Text = "SCH Roll"
        '
        'txtCons2
        '
        Me.txtCons2.Location = New System.Drawing.Point(93, 54)
        Me.txtCons2.MaxLength = 6
        Me.txtCons2.Name = "txtCons2"
        Me.txtCons2.Size = New System.Drawing.Size(89, 20)
        Me.txtCons2.TabIndex = 18
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(16, 57)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(55, 13)
        Me.Label20.TabIndex = 17
        Me.Label20.Text = "Cons Shift"
        '
        'txtActual2
        '
        Me.txtActual2.Location = New System.Drawing.Point(93, 28)
        Me.txtActual2.MaxLength = 6
        Me.txtActual2.Name = "txtActual2"
        Me.txtActual2.Size = New System.Drawing.Size(89, 20)
        Me.txtActual2.TabIndex = 16
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(16, 31)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(71, 13)
        Me.Label21.TabIndex = 15
        Me.Label21.Text = "Actual Speed"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtDesc3)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Controls.Add(Me.txtMeter3)
        Me.GroupBox3.Controls.Add(Me.Label23)
        Me.GroupBox3.Controls.Add(Me.txtRoll3)
        Me.GroupBox3.Controls.Add(Me.Label24)
        Me.GroupBox3.Controls.Add(Me.txtSchRoll3)
        Me.GroupBox3.Controls.Add(Me.Label25)
        Me.GroupBox3.Controls.Add(Me.txtCons3)
        Me.GroupBox3.Controls.Add(Me.Label26)
        Me.GroupBox3.Controls.Add(Me.txtActual3)
        Me.GroupBox3.Controls.Add(Me.Label27)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 342)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(823, 88)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "SHIFT 3"
        '
        'txtDesc3
        '
        Me.txtDesc3.Location = New System.Drawing.Point(446, 54)
        Me.txtDesc3.MaxLength = 100
        Me.txtDesc3.Name = "txtDesc3"
        Me.txtDesc3.Size = New System.Drawing.Size(343, 20)
        Me.txtDesc3.TabIndex = 26
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(378, 57)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(60, 13)
        Me.Label22.TabIndex = 25
        Me.Label22.Text = "Description"
        '
        'txtMeter3
        '
        Me.txtMeter3.Location = New System.Drawing.Point(446, 28)
        Me.txtMeter3.MaxLength = 6
        Me.txtMeter3.Name = "txtMeter3"
        Me.txtMeter3.Size = New System.Drawing.Size(98, 20)
        Me.txtMeter3.TabIndex = 24
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(378, 31)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(34, 13)
        Me.Label23.TabIndex = 23
        Me.Label23.Text = "Meter"
        '
        'txtRoll3
        '
        Me.txtRoll3.Location = New System.Drawing.Point(265, 54)
        Me.txtRoll3.MaxLength = 6
        Me.txtRoll3.Name = "txtRoll3"
        Me.txtRoll3.Size = New System.Drawing.Size(98, 20)
        Me.txtRoll3.TabIndex = 22
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(197, 57)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(25, 13)
        Me.Label24.TabIndex = 21
        Me.Label24.Text = "Roll"
        '
        'txtSchRoll3
        '
        Me.txtSchRoll3.Location = New System.Drawing.Point(265, 28)
        Me.txtSchRoll3.MaxLength = 6
        Me.txtSchRoll3.Name = "txtSchRoll3"
        Me.txtSchRoll3.Size = New System.Drawing.Size(98, 20)
        Me.txtSchRoll3.TabIndex = 20
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(197, 31)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(50, 13)
        Me.Label25.TabIndex = 19
        Me.Label25.Text = "SCH Roll"
        '
        'txtCons3
        '
        Me.txtCons3.Location = New System.Drawing.Point(93, 54)
        Me.txtCons3.MaxLength = 6
        Me.txtCons3.Name = "txtCons3"
        Me.txtCons3.Size = New System.Drawing.Size(89, 20)
        Me.txtCons3.TabIndex = 18
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(16, 57)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(55, 13)
        Me.Label26.TabIndex = 17
        Me.Label26.Text = "Cons Shift"
        '
        'txtActual3
        '
        Me.txtActual3.Location = New System.Drawing.Point(93, 28)
        Me.txtActual3.MaxLength = 6
        Me.txtActual3.Name = "txtActual3"
        Me.txtActual3.Size = New System.Drawing.Size(89, 20)
        Me.txtActual3.TabIndex = 16
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(16, 31)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(71, 13)
        Me.Label27.TabIndex = 15
        Me.Label27.Text = "Actual Speed"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.btnDelete)
        Me.Panel3.Controls.Add(Me.btnAdd)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel3.Location = New System.Drawing.Point(0, 430)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(823, 48)
        Me.Panel3.TabIndex = 10
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.Location = New System.Drawing.Point(54, 7)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(37, 36)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.Location = New System.Drawing.Point(16, 7)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(34, 36)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'dgv
        '
        Me.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgv.Dock = System.Windows.Forms.DockStyle.Top
        Me.dgv.Location = New System.Drawing.Point(0, 478)
        Me.dgv.Name = "dgv"
        Me.dgv.Size = New System.Drawing.Size(823, 266)
        Me.dgv.TabIndex = 11
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.btnApproved)
        Me.Panel4.Controls.Add(Me.btnVoid)
        Me.Panel4.Controls.Add(Me.btnExit)
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.btnCancel)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(0, 744)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(823, 71)
        Me.Panel4.TabIndex = 12
        '
        'btnApproved
        '
        Me.btnApproved.Location = New System.Drawing.Point(654, 12)
        Me.btnApproved.Name = "btnApproved"
        Me.btnApproved.Size = New System.Drawing.Size(75, 29)
        Me.btnApproved.TabIndex = 4
        Me.btnApproved.Text = "Approved"
        Me.btnApproved.UseVisualStyleBackColor = True
        '
        'btnVoid
        '
        Me.btnVoid.Location = New System.Drawing.Point(735, 12)
        Me.btnVoid.Name = "btnVoid"
        Me.btnVoid.Size = New System.Drawing.Size(75, 29)
        Me.btnVoid.TabIndex = 3
        Me.btnVoid.Text = "Void"
        Me.btnVoid.UseVisualStyleBackColor = True
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExit.Location = New System.Drawing.Point(178, 15)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 29)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "Exit"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(18, 15)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 29)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Text = "Save"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancel.Location = New System.Drawing.Point(97, 15)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 29)
        Me.btnCancel.TabIndex = 0
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'FrmSchedule
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ClientSize = New System.Drawing.Size(823, 815)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.dgv)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSchedule"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmSchedule"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        CType(Me.dgv, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents txtRev As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dtpDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents txtConsDay As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbTreatment As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbMachine As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtConsShift As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtExpected As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDesc1 As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtMeter1 As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtRoll1 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSch1 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtCons1 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtActual1 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDesc2 As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtMeter2 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtRoll2 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtSchRoll2 As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtCons2 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtActual2 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtDesc3 As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtMeter3 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtRoll3 As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtSchRoll3 As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txtCons3 As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents txtActual3 As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents dgv As System.Windows.Forms.DataGridView
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnApproved As System.Windows.Forms.Button
    Friend WithEvents btnVoid As System.Windows.Forms.Button
End Class
