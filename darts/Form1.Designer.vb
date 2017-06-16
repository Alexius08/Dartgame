<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.DartBoard = New System.Windows.Forms.PictureBox()
        Me.DartPins = New System.Windows.Forms.PictureBox()
        Me.btnTry = New System.Windows.Forms.Button()
        Me.tmrMouseMove = New System.Windows.Forms.Timer(Me.components)
        Me.Scoresheet = New System.Windows.Forms.DataGridView()
        Me.RoundScore = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScoreLeft = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RecentThrows = New System.Windows.Forms.Label()
        Me.FocusLevel = New System.Windows.Forms.ProgressBar()
        Me.CurrentScore = New System.Windows.Forms.Label()
        Me.pnlSplash = New System.Windows.Forms.Panel()
        Me.btnSkip = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.lblGameGuide = New System.Windows.Forms.Label()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.btnPlay = New System.Windows.Forms.Button()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.picDemo = New System.Windows.Forms.PictureBox()
        CType(Me.DartBoard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DartPins, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Scoresheet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlSplash.SuspendLayout()
        CType(Me.picDemo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DartBoard
        '
        Me.DartBoard.Image = CType(resources.GetObject("DartBoard.Image"), System.Drawing.Image)
        Me.DartBoard.Location = New System.Drawing.Point(0, 0)
        Me.DartBoard.Name = "DartBoard"
        Me.DartBoard.Size = New System.Drawing.Size(555, 555)
        Me.DartBoard.TabIndex = 0
        Me.DartBoard.TabStop = False
        '
        'DartPins
        '
        Me.DartPins.BackColor = System.Drawing.Color.Transparent
        Me.DartPins.Location = New System.Drawing.Point(0, 0)
        Me.DartPins.Name = "DartPins"
        Me.DartPins.Size = New System.Drawing.Size(126, 136)
        Me.DartPins.TabIndex = 1
        Me.DartPins.TabStop = False
        Me.DartPins.Visible = False
        '
        'btnTry
        '
        Me.btnTry.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnTry.Location = New System.Drawing.Point(584, 299)
        Me.btnTry.Name = "btnTry"
        Me.btnTry.Size = New System.Drawing.Size(179, 44)
        Me.btnTry.TabIndex = 2
        Me.btnTry.Text = "Try again"
        Me.btnTry.UseVisualStyleBackColor = False
        Me.btnTry.Visible = False
        '
        'tmrMouseMove
        '
        Me.tmrMouseMove.Enabled = True
        '
        'Scoresheet
        '
        Me.Scoresheet.AllowUserToAddRows = False
        Me.Scoresheet.AllowUserToDeleteRows = False
        Me.Scoresheet.AllowUserToResizeRows = False
        Me.Scoresheet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Scoresheet.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.RoundScore, Me.ScoreLeft})
        Me.Scoresheet.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.Scoresheet.Location = New System.Drawing.Point(584, 70)
        Me.Scoresheet.MultiSelect = False
        Me.Scoresheet.Name = "Scoresheet"
        Me.Scoresheet.ReadOnly = True
        Me.Scoresheet.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.Scoresheet.Size = New System.Drawing.Size(190, 121)
        Me.Scoresheet.TabIndex = 3
        Me.Scoresheet.Visible = False
        '
        'RoundScore
        '
        Me.RoundScore.HeaderText = "Score this round"
        Me.RoundScore.Name = "RoundScore"
        Me.RoundScore.ReadOnly = True
        Me.RoundScore.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.RoundScore.Width = 60
        '
        'ScoreLeft
        '
        Me.ScoreLeft.HeaderText = "Remaining score"
        Me.ScoreLeft.Name = "ScoreLeft"
        Me.ScoreLeft.ReadOnly = True
        Me.ScoreLeft.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ScoreLeft.Width = 60
        '
        'RecentThrows
        '
        Me.RecentThrows.AutoSize = True
        Me.RecentThrows.Location = New System.Drawing.Point(581, 210)
        Me.RecentThrows.MaximumSize = New System.Drawing.Size(170, 0)
        Me.RecentThrows.Name = "RecentThrows"
        Me.RecentThrows.Size = New System.Drawing.Size(82, 13)
        Me.RecentThrows.TabIndex = 4
        Me.RecentThrows.Text = "No darts thrown"
        Me.RecentThrows.Visible = False
        '
        'FocusLevel
        '
        Me.FocusLevel.ForeColor = System.Drawing.Color.LawnGreen
        Me.FocusLevel.Location = New System.Drawing.Point(283, 413)
        Me.FocusLevel.Maximum = 16
        Me.FocusLevel.Name = "FocusLevel"
        Me.FocusLevel.Size = New System.Drawing.Size(112, 22)
        Me.FocusLevel.TabIndex = 5
        Me.FocusLevel.Visible = False
        '
        'CurrentScore
        '
        Me.CurrentScore.BackColor = System.Drawing.Color.Transparent
        Me.CurrentScore.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentScore.Location = New System.Drawing.Point(442, 9)
        Me.CurrentScore.Name = "CurrentScore"
        Me.CurrentScore.Size = New System.Drawing.Size(115, 43)
        Me.CurrentScore.TabIndex = 6
        Me.CurrentScore.Text = "0"
        Me.CurrentScore.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.CurrentScore.Visible = False
        '
        'pnlSplash
        '
        Me.pnlSplash.BackColor = System.Drawing.Color.Transparent
        Me.pnlSplash.Controls.Add(Me.btnSkip)
        Me.pnlSplash.Controls.Add(Me.btnNext)
        Me.pnlSplash.Controls.Add(Me.btnPrev)
        Me.pnlSplash.Controls.Add(Me.lblGameGuide)
        Me.pnlSplash.Controls.Add(Me.btnHelp)
        Me.pnlSplash.Controls.Add(Me.btnPlay)
        Me.pnlSplash.Controls.Add(Me.lblTitle)
        Me.pnlSplash.Location = New System.Drawing.Point(66, 210)
        Me.pnlSplash.Name = "pnlSplash"
        Me.pnlSplash.Size = New System.Drawing.Size(430, 197)
        Me.pnlSplash.TabIndex = 7
        '
        'btnSkip
        '
        Me.btnSkip.Location = New System.Drawing.Point(337, 154)
        Me.btnSkip.Name = "btnSkip"
        Me.btnSkip.Size = New System.Drawing.Size(60, 40)
        Me.btnSkip.TabIndex = 6
        Me.btnSkip.Text = "Skip"
        Me.btnSkip.UseVisualStyleBackColor = True
        Me.btnSkip.Visible = False
        '
        'btnNext
        '
        Me.btnNext.Location = New System.Drawing.Point(195, 154)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(60, 40)
        Me.btnNext.TabIndex = 5
        Me.btnNext.Text = "Next"
        Me.btnNext.UseVisualStyleBackColor = True
        Me.btnNext.Visible = False
        '
        'btnPrev
        '
        Me.btnPrev.Location = New System.Drawing.Point(55, 154)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(60, 40)
        Me.btnPrev.TabIndex = 4
        Me.btnPrev.Text = "Previous"
        Me.btnPrev.UseVisualStyleBackColor = True
        Me.btnPrev.Visible = False
        '
        'lblGameGuide
        '
        Me.lblGameGuide.AutoSize = True
        Me.lblGameGuide.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGameGuide.Location = New System.Drawing.Point(3, 10)
        Me.lblGameGuide.MaximumSize = New System.Drawing.Size(420, 0)
        Me.lblGameGuide.Name = "lblGameGuide"
        Me.lblGameGuide.Size = New System.Drawing.Size(0, 18)
        Me.lblGameGuide.TabIndex = 3
        Me.lblGameGuide.Visible = False
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(322, 90)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(75, 43)
        Me.btnHelp.TabIndex = 2
        Me.btnHelp.Text = "Instructions"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'btnPlay
        '
        Me.btnPlay.Location = New System.Drawing.Point(55, 90)
        Me.btnPlay.Name = "btnPlay"
        Me.btnPlay.Size = New System.Drawing.Size(89, 43)
        Me.btnPlay.TabIndex = 1
        Me.btnPlay.Text = "Play"
        Me.btnPlay.UseVisualStyleBackColor = True
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(167, 15)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(88, 25)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "DARTS"
        Me.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(587, 361)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(176, 45)
        Me.btnExit.TabIndex = 8
        Me.btnExit.Text = "Leave game"
        Me.btnExit.UseVisualStyleBackColor = True
        Me.btnExit.Visible = False
        '
        'picDemo
        '
        Me.picDemo.BackColor = System.Drawing.Color.Transparent
        Me.picDemo.Location = New System.Drawing.Point(302, 86)
        Me.picDemo.Name = "picDemo"
        Me.picDemo.Size = New System.Drawing.Size(126, 136)
        Me.picDemo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picDemo.TabIndex = 9
        Me.picDemo.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(560, 559)
        Me.Controls.Add(Me.FocusLevel)
        Me.Controls.Add(Me.pnlSplash)
        Me.Controls.Add(Me.picDemo)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.CurrentScore)
        Me.Controls.Add(Me.RecentThrows)
        Me.Controls.Add(Me.Scoresheet)
        Me.Controls.Add(Me.btnTry)
        Me.Controls.Add(Me.DartPins)
        Me.Controls.Add(Me.DartBoard)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Darts"
        CType(Me.DartBoard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DartPins, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Scoresheet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlSplash.ResumeLayout(False)
        Me.pnlSplash.PerformLayout()
        CType(Me.picDemo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DartBoard As System.Windows.Forms.PictureBox
    Friend WithEvents DartPins As System.Windows.Forms.PictureBox
    Friend WithEvents btnTry As System.Windows.Forms.Button
    Friend WithEvents tmrMouseMove As System.Windows.Forms.Timer
    Friend WithEvents Scoresheet As System.Windows.Forms.DataGridView
    Friend WithEvents RoundScore As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ScoreLeft As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RecentThrows As System.Windows.Forms.Label
    Friend WithEvents FocusLevel As System.Windows.Forms.ProgressBar
    Friend WithEvents CurrentScore As System.Windows.Forms.Label
    Friend WithEvents pnlSplash As System.Windows.Forms.Panel
    Friend WithEvents btnHelp As System.Windows.Forms.Button
    Friend WithEvents btnPlay As System.Windows.Forms.Button
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents lblGameGuide As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnPrev As System.Windows.Forms.Button
    Friend WithEvents btnSkip As System.Windows.Forms.Button
    Friend WithEvents picDemo As System.Windows.Forms.PictureBox

End Class
