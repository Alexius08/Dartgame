Public Class Form1


    Dim dartlocator(2), center As Point, dartcount As Byte = 0, totaldartcount As Byte = 0, recentthrow As Byte = 0, remainingscore As Int16 = 501
    Dim x, y, crosshairsize, numrounds As Integer
    Dim accuracy As Single = 0.8
    Dim hasstopped As Boolean = True, isbusted As Boolean = False, isdone As Boolean = False, isplaying As Boolean = False, hasreadinstructions As Boolean = False
    Dim indicator(2) As System.Drawing.Brush
    Dim crosshairpen As New Pen(Color.Lime, 2), dartmarker(2, 3) As PointF, dartpen(2) As Pen
    Dim dartscore(2) As String
    Dim sectorheader() As Byte = {11, 14, 9, 12, 5, 20, 1, 18, 4, 13, 6, 10, 15, 2, 17, 3, 19, 7, 16, 8}
    Dim instruction() As String = _
    {"You begin with 501 points. The objective is to reduce the score to 0 points through hitting certain areas of the dartboard with varying point values.", _
    "The center of the dartboard contains two zones: the outer bull's eye and the inner bull's eye. The outer bull's eye is worth 25 points, while the inner bull's eye is worth 50 points.", _
    "A larger portion of the board is divided into 20 sectors. Each sector is marked with their value in points.", _
    "There are two rings in the board, both colored red and green. The inner ring triples the score of its section, while the outer ring doubles the score. The outer ring also marks the border of the play area. All darts that go outside the outer ring will score nothing.", _
    "Every turn, you can throw three darts. Click and hold the mouse button on your target. A bar will appear. Watch the bar before releasing the mouse button. The closer it is to being filled, the more accurate your throw will be.", _
    "Your last throw for the game must land either in the double ring or the inner bull's eye. If you throw a dart that:" & Environment.NewLine & _
    "1. reduces your score to 1;" & Environment.NewLine & _
    "2. reduces your score to 0, yet didn't land in the double ring or in the inner bull's eye; or" & Environment.NewLine & _
    "3. reduces your score to a negative value;" & Environment.NewLine & _
    "then, you go bust. You forfeit the rest of your turn and your score for that turn won't be counted."}
    Dim page As Byte, isfirstplay As Boolean = True
    Dim testdart, testdartmarker(3) As Point

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DartPins.Parent = DartBoard
        picDemo.Parent = DartBoard
        FocusLevel.Parent = DartPins
        CurrentScore.Parent = DartPins
        DartPins.Size = DartBoard.Size
        picDemo.Size = DartBoard.Size
        picDemo.Location = DartBoard.Location
        center.X = 277
        center.Y = 277
        crosshairsize = 250
        pnlSplash.Parent = picDemo
        pnlSplash.BackColor = Color.FromArgb(100, 255, 255, 255)
        numrounds = 0
    End Sub

    Private Sub DartPins_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DartPins.MouseClick
        Dim angle, distance, randomangle(2) As Single, currentthrow As Byte, dartsize As Byte = 60
        angle = Rnd()
        distance = Rnd() * crosshairsize * (1 - accuracy) * (1 - 0.9 * FocusLevel.Value / FocusLevel.Maximum)
        If dartcount <= 2 And Not isbusted Then
            dartlocator(dartcount).X = x - 4 + distance * Math.Sin(angle * Math.PI * 2)
            dartlocator(dartcount).Y = y - 4 + distance * Math.Cos(angle * Math.PI * 2)

            'CALCULATE COORDINATES OF DART PIN
            randomangle(dartcount) = Rnd() * Math.PI / 2
            dartmarker(dartcount, 0).X = dartlocator(dartcount).X + dartsize / 2 * Math.Sin(randomangle(dartcount))
            dartmarker(dartcount, 0).Y = dartlocator(dartcount).Y + dartsize / 2 * Math.Cos(randomangle(dartcount))
            dartmarker(dartcount, 1).X = dartlocator(dartcount).X + dartsize / 2 * Math.Cos(randomangle(dartcount))
            dartmarker(dartcount, 1).Y = dartlocator(dartcount).Y - dartsize / 2 * Math.Sin(randomangle(dartcount))
            dartmarker(dartcount, 2).X = dartlocator(dartcount).X - dartsize / 2 * Math.Sin(randomangle(dartcount))
            dartmarker(dartcount, 2).Y = dartlocator(dartcount).Y - dartsize / 2 * Math.Cos(randomangle(dartcount))
            dartmarker(dartcount, 3).X = dartlocator(dartcount).X - dartsize / 2 * Math.Cos(randomangle(dartcount))
            dartmarker(dartcount, 3).Y = dartlocator(dartcount).Y + dartsize / 2 * Math.Sin(randomangle(dartcount))

            Dim distancefromradius As Single = Math.Sqrt((center.X - dartlocator(dartcount).X) ^ 2 + (center.Y - dartlocator(dartcount).Y) ^ 2)
            Dim dartangle As Single = IIf(distancefromradius = 0, 0, Math.Acos((center.X - dartlocator(dartcount).X) / distancefromradius) * 180 / Math.PI)

            If distancefromradius <= 213 Then
                indicator(dartcount) = Brushes.Cyan
                dartpen(dartcount) = New Pen(Color.DarkCyan, 4)
            Else
                indicator(dartcount) = Brushes.Magenta
                dartpen(dartcount) = New Pen(Color.DarkMagenta, 4)
            End If

            Select Case distancefromradius
                Case Is < 8
                    dartscore(dartcount) = "Bull's eye"
                    currentthrow = 50
                Case Is < 19
                    dartscore(dartcount) = "Outer bull's eye"
                    currentthrow = 25
                Case 121 To 132
                    dartscore(dartcount) = "T" & sectorheader(Math.Truncate(IIf(center.Y - dartlocator(dartcount).Y > 0, dartangle + 9, (369 - dartangle) Mod 360)) \ 18)
                    currentthrow = 3 * sectorheader(Math.Truncate(IIf(center.Y - dartlocator(dartcount).Y > 0, dartangle + 9, (369 - dartangle) Mod 360)) \ 18)
                Case 199 To 209
                    dartscore(dartcount) = "D" & sectorheader(Math.Truncate(IIf(center.Y - dartlocator(dartcount).Y > 0, dartangle + 9, (369 - dartangle) Mod 360)) \ 18)
                    currentthrow = 2 * sectorheader(Math.Truncate(IIf(center.Y - dartlocator(dartcount).Y > 0, dartangle + 9, (369 - dartangle) Mod 360)) \ 18)
                Case Is < 199
                    dartscore(dartcount) = sectorheader(Math.Truncate(IIf(center.Y - dartlocator(dartcount).Y > 0, dartangle + 9, (369 - dartangle) Mod 360)) \ 18)
                    currentthrow = sectorheader(Math.Truncate(IIf(center.Y - dartlocator(dartcount).Y > 0, dartangle + 9, (369 - dartangle) Mod 360)) \ 18)
                Case Else
                    dartscore(dartcount) = "Outside"
                    currentthrow = 0
            End Select

            RecentThrows.Text = IIf(dartcount = 0, dartscore(dartcount), RecentThrows.Text & ", " & dartscore(dartcount))
            recentthrow = IIf(dartcount = 0, currentthrow, recentthrow + currentthrow)
            CurrentScore.Text = recentthrow

            Select Case remainingscore - recentthrow
                Case Is < 0, 1
                    isbusted = True
                Case 0
                    If Strings.GetChar(dartscore(dartcount), 1) = "D" OrElse Strings.GetChar(dartscore(dartcount), 1) = "B" Then
                        remainingscore = 0
                        Scoresheet.Rows.Add(New String() {recentthrow, remainingscore})
                        Scoresheet.FirstDisplayedScrollingRowIndex = numrounds
                        Scoresheet.Rows(numrounds).Selected = True
                        btnTry.Text = "Game over. Play again."
                        btnExit.Text = "Back to main menu"
                        isdone = True
                    Else
                        isbusted = True
                    End If
            End Select
            dartcount = dartcount + 1

        End If
        If dartcount = 3 Or isbusted Or isdone Then btnTry.Show()
        If isbusted Then btnTry.Text = "Busted. Try again."

        DartPins.Invalidate()
    End Sub

    Private Sub DartPins_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DartPins.MouseDown
        If dartcount <= 2 And Not isbusted And Not isdone Then
            FocusLevel.Show()
            If y < center.Y Then
                FocusLevel.Top = y + crosshairsize * (1 - accuracy) + FocusLevel.Height
            Else
                FocusLevel.Top = y - crosshairsize * (1 - accuracy) - 2 * FocusLevel.Height
            End If
            FocusLevel.Left = x - (FocusLevel.Width / 2)
            FocusLevel.Value = 0

            Dim sleeptime As Byte
            Do While FocusLevel.Visible
                Dim FocusLevelStep As SByte = 1, focuslevelincrease As Boolean
                Application.DoEvents()
                If FocusLevel.Value = 0 Then
                    focuslevelincrease = True
                ElseIf FocusLevel.Value = FocusLevel.Maximum Then
                    focuslevelincrease = False
                End If
                Select Case FocusLevel.Value
                    Case 0 To FocusLevel.Maximum / 4
                        sleeptime = 20
                    Case 1 + FocusLevel.Maximum / 4 To FocusLevel.Maximum / 2
                        sleeptime = 15
                    Case 1 + FocusLevel.Maximum / 2 To 3 * FocusLevel.Maximum / 4
                        sleeptime = 10
                    Case Else
                        sleeptime = 5
                End Select
                If Not focuslevelincrease Then FocusLevelStep = -FocusLevelStep
                FocusLevel.Increment(FocusLevelStep)
                Threading.Thread.Sleep(sleeptime)
            Loop
        End If
    End Sub

    Private Sub DartPins_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DartPins.MouseMove
        If Not FocusLevel.Visible Then
            accuracy = accuracy - 0.001
            hasstopped = False
            x = e.X
            y = e.Y
        End If

        'ENABLE WHEN CALIBRATING
        'Dim board As New Bitmap(DartBoard.Image)
        'Dim distancefromradius As Single = Math.Sqrt((center.X - e.X) ^ 2 + (center.Y - e.Y) ^ 2)
        'Dim angle As Single = IIf(distancefromradius = 0, 0, Math.Acos((center.X - e.X) / distancefromradius) * 180 / Math.PI)
        'btnExit.Text = board.GetPixel(e.X, e.Y).ToString & " " & Format(IIf(center.Y - e.Y > 0, angle + 9, (369 - angle) Mod 360), "000.00") & " " & Format(distancefromradius, "000.00")

        DartPins.Invalidate()
    End Sub

    Private Sub DartPins_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DartPins.MouseUp
        FocusLevel.Hide()
    End Sub

    Private Sub DartPins_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles DartPins.Paint
        'DISPLAY CENTER WHEN CALIBRATING
        'e.Graphics.DrawLine(Pens.Cyan, center.X, 0, center.X, DartPins.Height)
        'e.Graphics.DrawLine(Pens.Cyan, 0, center.Y, DartPins.Width, center.Y)

        Dim ctr As Byte
        If dartcount > 0 Then
            For ctr = 0 To 2
                Dim dartsize As Byte = 10
                If ctr < dartcount Then
                    'draw pins
                    e.Graphics.DrawLine(dartpen(ctr), dartmarker(ctr, 0), dartmarker(ctr, 2))
                    e.Graphics.DrawLine(dartpen(ctr), dartmarker(ctr, 1), dartmarker(ctr, 3))
                    e.Graphics.FillEllipse(indicator(ctr), dartlocator(ctr).X - (dartsize \ 2), dartlocator(ctr).Y - (dartsize \ 2), dartsize, dartsize)
                End If
            Next
        End If

        'DRAW CROSSHAIR
        e.Graphics.DrawEllipse(crosshairpen, x - crosshairsize * (1 - accuracy), y - crosshairsize * (1 - accuracy), crosshairsize * 2 * (1 - accuracy), crosshairsize * 2 * (1 - accuracy))
        e.Graphics.DrawLine(crosshairpen, x, y - crosshairsize * (1 - accuracy), x, y + crosshairsize * (1 - accuracy))
        e.Graphics.DrawLine(crosshairpen, x - crosshairsize * (1 - accuracy), y, x + crosshairsize * (1 - accuracy), y)
    End Sub

    Private Sub btnTry_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTry.Click
        Dim ctr As Byte
        totaldartcount = totaldartcount + dartcount

        For ctr = 0 To 2
            dartlocator(ctr).X = 0
            dartlocator(ctr).Y = 0
        Next
        DartPins.Invalidate()
        RecentThrows.Text = "No darts thrown."
        CurrentScore.Text = "0"
        If isdone Then
            Scoresheet.Rows.Clear()
            remainingscore = 501
            totaldartcount = 0
            numrounds = 0
            isdone = False
        Else
            If isbusted Then
                recentthrow = 0
                isbusted = False
            End If

            remainingscore = remainingscore - recentthrow

            'TRACK SCORE
            Scoresheet.Rows.Add(New String() {recentthrow, remainingscore})
            Scoresheet.FirstDisplayedScrollingRowIndex = numrounds
            Scoresheet.Rows(numrounds).Selected = True
            numrounds = numrounds + 1
        End If
        btnTry.Text = "Try again"
        btnTry.Hide()
        btnExit.Text = "Leave game"
        dartcount = 0
        recentthrow = 0
    End Sub

    Private Sub tmrMouseMove_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMouseMove.Tick
        If Not FocusLevel.Visible Then
            If hasstopped Then
                If accuracy < 0.8 Then accuracy = accuracy + 0.01
            Else
                hasstopped = True
            End If
        End If
        DartPins.Invalidate()
    End Sub

    Private Sub btnPlay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlay.Click
        If Not isfirstplay Then
            startgame()
        Else
            btnHelp_Click(sender, e)
        End If

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        If remainingscore > 0 Then
            If MsgBox("Abandon game?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
                showstartscreen()
            End If
        Else
            showstartscreen()
        End If
    End Sub

    Private Sub btnHelp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHelp.Click
        btnHelp.Hide()
        btnPlay.Hide()
        lblTitle.Hide()
        lblGameGuide.Show()
        picDemo.Show()
        page = 0
        lblGameGuide.Text = instruction(page)
        btnNext.Show()
        If isfirstplay Then btnSkip.Show()
        showtutorial(page)
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        page = page + 1
        lblGameGuide.Text = instruction(page)
        If page > 0 Then btnPrev.Show()
        If page = 5 Then
            btnNext.Hide()
            hasreadinstructions = True
        End If
        If hasreadinstructions Then btnSkip.Text = "Play"
        showtutorial(page)
    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        page = page - 1
        lblGameGuide.Text = instruction(page)
        If page < 5 Then btnNext.Show()
        If page = 0 Then btnPrev.Hide()
        showtutorial(page)
    End Sub

    Private Sub btnSkip_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSkip.Click
        startgame()
    End Sub

    Private Sub showstartscreen()
        DartPins.Hide()
        CurrentScore.Hide()
        CurrentScore.Text = "0"
        Scoresheet.Hide()
        RecentThrows.Hide()
        RecentThrows.Text = "No darts thrown"
        btnTry.Hide()
        btnTry.Text = "Try again"
        btnExit.Hide()
        Scoresheet.Rows.Clear()
        isbusted = False
        isdone = False
        remainingscore = 501
        recentthrow = 0
        dartcount = 0
        totaldartcount = 0
        Dim ctr As Byte
        For ctr = 0 To 2
            dartlocator(ctr).X = 0
            dartlocator(ctr).Y = 0
            Dim ctr2 As Byte
            For ctr2 = 0 To 3
                dartmarker(ctr, ctr2).X = 0
                dartmarker(ctr, ctr2).Y = 0
            Next
        Next
        Me.Width = 570
        numrounds = 0
        picDemo.Show()
        pnlSplash.Show()
        pnlSplash.Left = 66
        pnlSplash.Top = 210
        lblGameGuide.Hide()
        btnNext.Hide()
        btnPrev.Hide()
        btnSkip.Hide()
        btnHelp.Show()
        btnPlay.Show()
        lblTitle.Show()
    End Sub

    Private Sub startgame()
        DartBoard.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\base.png")
        showtutorial(0)
        picDemo.Image = Nothing
        picDemo.Hide()
        pnlSplash.Hide()
        DartPins.Show()
        CurrentScore.Show()
        Scoresheet.Show()
        RecentThrows.Show()
        btnExit.Show()
        hasreadinstructions = True
        isfirstplay = False
        Me.Width = 790
    End Sub

    Private Sub showtutorial(ByVal page)
        Select Case page
            Case 0
                DartBoard.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\base.png")
                picDemo.Invalidate()
                picDemo.Image = Nothing
                pnlSplash.Left = 66
                pnlSplash.Top = 210
            Case 1
                DartBoard.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\basefade.png")
                picDemo.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\bullseye.png")
            Case 2
                picDemo.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\gamearea.png")
            Case 3
                DartBoard.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\basefade.png")
                picDemo.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\rings.png")
                FocusLevel.Hide()
                picDemo.Invalidate()
                pnlSplash.Left = 66
                pnlSplash.Top = 210
            Case 4
                testdart.X = 0
                testdart.Y = 0
                DartBoard.Image = Image.FromFile(My.Application.Info.DirectoryPath & "\base.png")
                picDemo.Image = Nothing
                Dim randomdistance As Single = 213 * Rnd(), randomangle As Single = Math.PI * 2 * Rnd()
                x = center.X + randomdistance * Math.Sin(randomangle)
                y = center.Y + randomdistance * Math.Cos(randomangle)
                picDemo.Invalidate()
                FocusLevel.Parent = picDemo

                FocusLevel.Show()
                If y < center.Y Then
                    FocusLevel.Top = y + crosshairsize * (1 - accuracy) + FocusLevel.Height
                    pnlSplash.Top = FocusLevel.Top + 2 * FocusLevel.Height
                Else
                    FocusLevel.Top = y - crosshairsize * (1 - accuracy) - 2 * FocusLevel.Height
                    pnlSplash.Top = FocusLevel.Top - pnlSplash.Height
                End If
                FocusLevel.Left = x - (FocusLevel.Width / 2)
                FocusLevel.Value = 0

                Dim randomduration As Int16 = Rnd() * 5000, ctr As Int16
                Dim sleeptime As Byte

                Do
                    Dim FocusLevelStep As SByte = 1, focuslevelincrease As Boolean
                    Application.DoEvents()
                    If FocusLevel.Value = 0 Then
                        focuslevelincrease = True
                    ElseIf FocusLevel.Value = FocusLevel.Maximum Then
                        focuslevelincrease = False
                    End If
                    Select Case FocusLevel.Value
                        Case 0 To FocusLevel.Maximum / 4
                            sleeptime = 100
                        Case 1 + FocusLevel.Maximum / 4 To FocusLevel.Maximum / 2
                            sleeptime = 75
                        Case 1 + FocusLevel.Maximum / 2 To 3 * FocusLevel.Maximum / 4
                            sleeptime = 50
                        Case Else
                            sleeptime = 25
                    End Select
                    If Not focuslevelincrease Then FocusLevelStep = -FocusLevelStep
                    FocusLevel.Increment(FocusLevelStep)
                    Threading.Thread.Sleep(sleeptime)
                    ctr = ctr + sleeptime
                Loop Until ctr >= randomduration Or FocusLevel.Visible = False

                Dim angle As Single = Rnd(), distance As Single = Rnd() * crosshairsize * (1 - accuracy) * (1 - 0.9 * FocusLevel.Value / FocusLevel.Maximum)

                testdart.X = x - 4 + distance * Math.Sin(angle * Math.PI * 2)
                testdart.Y = y - 4 + distance * Math.Cos(angle * Math.PI * 2)

                Dim testdartangle As Single = Rnd() * Math.PI / 2, dartsize As Byte = 30
                testdartmarker(0).X = testdart.X + dartsize * Math.Sin(testdartangle)
                testdartmarker(0).Y = testdart.Y + dartsize * Math.Cos(testdartangle)
                testdartmarker(1).X = testdart.X + dartsize * Math.Cos(testdartangle)
                testdartmarker(1).Y = testdart.Y - dartsize * Math.Sin(testdartangle)
                testdartmarker(2).X = testdart.X - dartsize * Math.Sin(testdartangle)
                testdartmarker(2).Y = testdart.Y - dartsize * Math.Cos(testdartangle)
                testdartmarker(3).X = testdart.X - dartsize * Math.Cos(testdartangle)
                testdartmarker(3).Y = testdart.Y + dartsize * Math.Sin(testdartangle)
                picDemo.Invalidate()
                FocusLevel.Hide()
                FocusLevel.Parent = DartPins
            Case 5
                FocusLevel.Hide()
                picDemo.Invalidate()
                picDemo.Image = Nothing
                pnlSplash.Left = 66
                pnlSplash.Top = 210

        End Select
    End Sub

    Private Sub picDemo_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles picDemo.Paint
        If page = 4 Then
            Dim dartsize As Byte = 10, testdartpen As Pen = New Pen(Color.DarkCyan, 4), testdartcenter As Brush = Brushes.Cyan
            'draw pins in demo
            If testdart.X > 0 And testdart.Y > 0 Then
                e.Graphics.DrawLine(testdartpen, testdartmarker(0), testdartmarker(2))
                e.Graphics.DrawLine(testdartpen, testdartmarker(1), testdartmarker(3))
                e.Graphics.FillEllipse(testdartcenter, testdart.X - (dartsize \ 2), testdart.Y - (dartsize \ 2), dartsize, dartsize)

            End If
            e.Graphics.DrawEllipse(crosshairpen, x - crosshairsize * (1 - accuracy), y - crosshairsize * (1 - accuracy), crosshairsize * 2 * (1 - accuracy), crosshairsize * 2 * (1 - accuracy))
            e.Graphics.DrawLine(crosshairpen, x, y - crosshairsize * (1 - accuracy), x, y + crosshairsize * (1 - accuracy))
            e.Graphics.DrawLine(crosshairpen, x - crosshairsize * (1 - accuracy), y, x + crosshairsize * (1 - accuracy), y)

        End If
    End Sub
End Class
