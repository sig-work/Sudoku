﻿Imports Microsoft.VisualBasic

Public Class Gameboard
    Dim Cells(8, 8) As Cell
    Dim Box(2, 2) As ArrayList

    Public Sub New()

        Dim BoxX, BoxY As Integer

        'Iderate Through Cells.
        For Cols = 0 To 8
            For Rows = 0 To 8
                'Create the new Cell Object

                Cells(Cols, Rows) = New Cell

                'Determine the box that each Cell belongs to. 
                If Cols <= 2 Then
                    BoxX = 0
                ElseIf Cols >= 3 And Cols <= 5 Then
                    BoxX = 1
                ElseIf Cols >= 6 And Cols <= 8 Then
                    BoxX = 2
                End If

                If Rows <= 2 Then
                    BoxY = 0
                ElseIf Rows >= 3 And Rows <= 5 Then
                    BoxY = 1
                ElseIf Rows >= 6 And Rows <= 8 Then
                    BoxY = 2
                End If

                'Add the Cell to its parent box
                Box(BoxX, BoxY).Add(Cells(Cols, Rows))
                'Add a refrence to the parent box for each cell
                Cells(Cols, Rows).Parent_Box.X = BoxX
                Cells(Cols, Rows).Parent_Box.Y = BoxY
            Next
        Next

    End Sub

    Public Sub Import_New_Board()

    End Sub


End Class

Public Class Cell
    Public Parent_Box As Point
    Public Candidates(8) As ArrayList
End Class



















'Public Class Gameboard
'    '_________________________________________'
'    ''A BIT OF TERMONOLOGY''
'    'The gameboard refers to the whole of the Sudoku board
'    'The Gameboard consists of 9 Boxes. 3*3
'    'Each Box has 9 Cells in it
'    'Eeach Cell can have a max of 9 candidates - represented by 9 boxes
'    '________________________________________'

'    Dim OriginX, OriginY As Integer

'    Public Const CANDIDATE_SIZEpx As Integer = 14
'    Public Const CANDIDATE_PADDINGpx As Integer = 1

'    Public Const TOTAL_CELL_SIZEpx As Integer = 3 * CANDIDATE_SIZEpx + 2 * CANDIDATE_PADDINGpx
'    Public Const CELL_PADDINGpx As Integer = 12

'    Public Const TOTAL_BOX_SIZEpx = 3 * TOTAL_CELL_SIZEpx + 2 * CELL_PADDINGpx
'    Public Const BOX_PADDINGpx As Integer = 20

'    Public Const GAME_SIZEpx = (3 * TOTAL_BOX_SIZEpx) + (2 * BOX_PADDINGpx)
'    Public Const LINE_WIDTH As Integer = 5

'    Public Boxes(2, 2) As Box
'    Public Cell_Array(8, 8) As Cell

'    Public Sub New(Ox As Integer, Oy As Integer)
'        OriginX = Ox
'        OriginY = Oy
'        CreateGameBoard()
'        'Form1.Size = New Size(OriginX + (GAME_SIZEpx + 40), OriginY + (GAME_SIZEpx + 60))
'        Cell_Array = Cell.Temp_Cell_Array
'    End Sub

'    Private Sub CreateGameBoard()
'        Dim Box_Point As Point
'        For CountX = 0 To 2
'            For CountY = 0 To 2
'                Box_Point.X = CountX
'                Box_Point.Y = CountY
'                Boxes(CountX, CountY) = New Box(OriginX + (CountX * (TOTAL_BOX_SIZEpx + BOX_PADDINGpx)), OriginY + (CountY * (TOTAL_BOX_SIZEpx + BOX_PADDINGpx)), Box_Point)
'            Next
'        Next

'        'Create Lines in-between different boxes.
'        Dim Line_Vert_1, Line_Vert_2, Line_Hor_1, Line_Hor_2 As New Label

'        With Line_Vert_1
'            .Size = New Size(LINE_WIDTH, GAME_SIZEpx)
'            .Location = New Drawing.Point(OriginX + (TOTAL_BOX_SIZEpx + BOX_PADDINGpx / 2 - LINE_WIDTH / 2), OriginY)
'            .BackColor = Color.Black
'        End With
'        Form1.Controls.Add(Line_Vert_1)

'        With Line_Vert_2
'            .Size = New Size(LINE_WIDTH, GAME_SIZEpx)
'            .Location = New Drawing.Point(OriginX + (TOTAL_BOX_SIZEpx * 2 + BOX_PADDINGpx * 1.5 - LINE_WIDTH / 2), OriginY)
'            .BackColor = Color.Black
'        End With
'        Form1.Controls.Add(Line_Vert_2)

'        With Line_Hor_1
'            .Size = New Size(GAME_SIZEpx, LINE_WIDTH)
'            .Location = New Drawing.Point(OriginX, OriginY + (TOTAL_BOX_SIZEpx + BOX_PADDINGpx / 2 - LINE_WIDTH / 2))
'            .BackColor = Color.Black
'        End With
'        Form1.Controls.Add(Line_Hor_1)

'        With Line_Hor_2
'            .Size = New Size(GAME_SIZEpx, LINE_WIDTH)
'            .Location = New Drawing.Point(OriginX, OriginY + (TOTAL_BOX_SIZEpx * 2 + BOX_PADDINGpx * 1.5 - LINE_WIDTH / 2))
'            .BackColor = Color.Black
'        End With
'        Form1.Controls.Add(Line_Hor_2)

'    End Sub

'    Public Sub Import_NewBoard()
'        Dim TempCells = Database.ExportNewBoard()

'        For cols = 0 To 8
'            For rows = 0 To 8
'                Cell_Array(cols, rows).Import_Candidates(TempCells(cols, rows))
'            Next
'        Next

'    End Sub


'End Class

'Public Class Box

'    Dim Box_Point, Cell_Point As Point

'    Public Cells(2, 2) As Cell
'    Private OriginX, OriginY As Integer

'    Public Sub New(Ox As Integer, Oy As Integer, _BoxLocation As Point)
'        Box_Point = _BoxLocation
'        OriginX = Ox
'        OriginY = Oy
'        For CountX = 0 To 2
'            For CountY = 0 To 2
'                Cell_Point.X = (3 * Box_Point.X) + CountX
'                Cell_Point.Y = (3 * Box_Point.Y) + CountX
'                Cells(CountX, CountY) = New Cell(OriginX + (CountX * (Gameboard.TOTAL_CELL_SIZEpx + Gameboard.CELL_PADDINGpx)), OriginY + (CountY * (Gameboard.TOTAL_CELL_SIZEpx + Gameboard.CELL_PADDINGpx)), Cell_Point, Box_Point)
'            Next
'        Next

'    End Sub
'End Class

'Public Class Cell

'    'Properties used for calculation
'    Dim Parent_Box_Point As Point
'    Dim Cell_Point As Point
'    Dim Row As Integer
'    Dim Column As Integer
'    Public Shared Temp_Cell_Array(8, 8) As Cell

'    'Properties that are used for drawing
'    Dim OriginX, OriginY, count, defaultvalue As Integer
'    Public Candidates(2, 2) As Label
'    Public Valuelabel As New Label
'    Dim Val_Candidates As New ArrayList

'    Public Sub New(Ox As Integer, Oy As Integer, CellLocation As Point, _Parent_Box_Location As Point)
'        'Define Origin as Origin X and Origin Y
'        Parent_Box_Point = _Parent_Box_Location
'        Cell_Point = CellLocation
'        Temp_Cell_Array(CellLocation.X, CellLocation.Y) = Me
'        OriginX = Ox
'        OriginY = Oy
'        count = 1
'        For i = 1 To 9
'            Val_Candidates.Add(Convert.ToString(i))
'        Next

'        'Draw Candidates
'        For CountY = 0 To 2
'            For CountX = 0 To 2

'                Candidates(CountX, CountY) = New Label
'                defaultvalue = count
'                With Candidates(CountX, CountY)
'                    .BackColor = Color.GhostWhite
'                    .Size = New Size(Gameboard.CANDIDATE_SIZEpx, Gameboard.CANDIDATE_SIZEpx)
'                    .Location = New Drawing.Point(OriginX + (CountX * (Gameboard.CANDIDATE_SIZEpx + Gameboard.CANDIDATE_PADDINGpx)), OriginY + (CountY * (Gameboard.CANDIDATE_SIZEpx + Gameboard.CANDIDATE_PADDINGpx)))
'                    .Text = Convert.ToString(count)
'                    .TextAlign = ContentAlignment.MiddleCenter
'                End With

'                Form1.Controls.Add(Candidates(CountX, CountY))
'                'Adds an event to each label which calls Lbl_Click function
'                AddHandler Candidates(CountX, CountY).Click, AddressOf Me.Lbl_Click
'                count += 1
'            Next
'        Next

'        'Create and Draw valuelabel - DEFAUlT as Dissappeared.
'        With Valuelabel
'            .Size = New Size(Gameboard.TOTAL_CELL_SIZEpx, Gameboard.TOTAL_CELL_SIZEpx)
'            .BackColor = Color.DarkSlateGray
'            .Location = New Drawing.Point(OriginX, OriginY)
'            .Visible = False
'            .Enabled = False
'            .TextAlign = ContentAlignment.MiddleCenter
'            .Font = New Font("Symbol", 30, FontStyle.Bold)

'        End With
'        Form1.Controls.Add(Valuelabel)

'    End Sub

'    'Event Handler for labels
'    Private Sub Lbl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

'        'Converts the sender object into a label "x"
'        Dim x As Label = DirectCast(sender, Label)
'        'Removes x from Valus and Removes its text from the gameboard
'        Val_Candidates.Remove(x.Text)
'        x.Text = ""
'        'If there is only 1 value in the array.
'        If Val_Candidates.Count = 1 Then
'            For Cols = 0 To 2
'                For Rows = 0 To 2
'                    Candidates(Cols, Rows).Visible = False
'                    Candidates(Cols, Rows).Enabled = False
'                Next
'            Next

'            With Valuelabel
'                .Visible = True
'                .BackColor = Color.White
'                .Enabled = True
'                .BringToFront()
'                'Set Value Label as the remaining Val_Candidates
'                .Text = Val_Candidates(0)
'            End With
'        End If
'    End Sub

'    Public Sub Import_Candidates(Imported_Candidates As ArrayList)
'        For cols = 0 To 2
'            For rows = 0 To 2
'                For Each ele In Imported_Candidates
'                    If ele = defaultvalue Then
'                        Candidates(cols, rows).Text = defaultvalue
'                    End If
'                Next
'            Next
'        Next

'    End Sub

'______________________________________________________________________________________________________________________________
'End Class

'Public Class Database


'    Shared Baseboard(8, 8) As Integer
'    Shared TempCells(8, 8) As ArrayList

'    Public Shared Function ExportNewBoard() As ArrayList(,)

'        'Import BaseBoard
'        Baseboard = InputOutputGameboard.Import("C:\Users\Samn\source\repos\Sudoku\Sudoku\My Project\Boards")

'        'Build Fullboard 
'        For cols = 0 To 8
'            For rows = 0 To 8
'                'If the BaseBoard does not have a value of 0 (meaning empty) then fill candidates
'                If Baseboard(cols, rows) <> 0 Then
'                    TempCells(cols, rows).Add(Baseboard(cols, rows))
'                Else
'                    For i = 1 To 9
'                        TempCells(cols, rows).Add(i)
'                    Next
'                End If
'            Next
'        Next

'        'Remvoing possible candidates from 
'        For cols = 0 To 8
'            For rows = 0 To 8

'                If TempCells(cols, rows).Count = 1 Then
'                    RemoveCandiateFromBoxColRow(TempCells(cols, rows)(0), cols, rows)
'                End If

'            Next
'        Next

'        'Pass TempCells To gameboard
'        Return TempCells

'    End Function

'    Public Shared Sub RemoveCandiateFromBoxColRow(Candidate As Integer, col As Integer, row As Integer)

'        RemoveCandidateFromBox(Candidate, col, row)
'        RemoveCandidateFromColRow(Candidate, col, row)

'    End Sub

'    Private Shared Sub RemoveCandidateFromBox(Candidate As Integer, col As Integer, row As Integer)
'        Dim MaxRows, MinRows, MaxCols, MinCols As Integer
'        If col <= 2 Then
'            MinCols = 0
'            MaxCols = 2
'        ElseIf col >= 3 And col <= 5 Then
'            MinCols = 3
'            MaxCols = 5
'        ElseIf col >= 6 And col <= 8 Then
'            MinCols = 6
'            MaxCols = 8
'        End If

'        If row <= 2 Then
'            MinRows = 0
'            MaxRows = 2
'        ElseIf row >= 3 And col <= 5 Then
'            MinRows = 3
'            MaxRows = 5
'        ElseIf row >= 6 And col <= 8 Then
'            MinRows = 6
'            MaxRows = 8
'        End If

'        For cols = MinCols To MaxCols
'            For rows = MinRows To MaxRows
'                TempCells(cols, rows).Remove(Candidate)
'            Next
'        Next

'    End Sub

'    Private Shared Sub RemoveCandidateFromColRow(Candidate As Integer, col As Integer, row As Integer)

'        For cols = 0 To 8
'            TempCells(cols, row).Remove(Candidate)
'        Next

'        For rows = 0 To 8
'            TempCells(col, rows).Remove(Candidate)
'        Next

'    End Sub

'End Class

'______________________________________________________________________________________________________________________________
'Imports Microsoft.VisualBasic
'Imports System.IO
'Imports System.Random
'Public Class InputOutputGameboard
'    Shared Function Import(Directory As String) As Integer(,)
'        'Pull a board form a file and turn it into the Baseboard Array

'        Dim BaseBoard(8, 8) As Integer
'        Using reader As New StreamReader(GetRandomFile(Directory))

'            For cols = 0 To 8
'                For rows = 0 To 8
'                    BaseBoard(cols, rows) = reader.ReadLine()
'                Next
'            Next
'        End Using
'        Return BaseBoard
'        'Return BaseBoard

'    End Function

'    Private Shared Function GetRandomFile(FolderName As String) As String
'        Static r As New Random
'        Dim Files = New DirectoryInfo(FolderName).GetFiles()
'        Return Convert.ToString(Files(r.Next(0, Files.Length)))
'    End Function
'End Class