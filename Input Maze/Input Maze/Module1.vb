Imports System.Drawing
Imports System.IO

Module Module1

    Sub Main()
        Console.CursorVisible = False
        Dim list As New List(Of Cell)
        Dim multiplier As Integer = 8
        Dim imageLocation As String = "reading test 4 m 8.png"
        Console.ReadKey()
        Dim PathOnMaze As Boolean = False
        Dim image As New Bitmap(imageLocation)
        For y = 1 To image.Height Step multiplier * 2
            For x = 1 To image.Width Step multiplier * 2
                Dim pixel As Color = image.GetPixel(x, y)
                If pixel.GetBrightness = 1 Then
                    Dim b As Integer = pixel.GetBrightness
                    list.Add(New Cell(x / multiplier, y / (multiplier * 2)))
                    Console.BackgroundColor = ConsoleColor.White
                    Console.ForegroundColor = ConsoleColor.White
                    Console.SetCursorPosition(x / multiplier, y / (multiplier * 2))
                    Console.Write("XX")
                End If
                If pixel.GetBrightness <> 0 And pixel.GetBrightness <> 1 Then
                    PathOnMaze = True
                    Dim c As ConsoleColor = ConsoleColor.Green
                    Console.BackgroundColor = c
                    Console.ForegroundColor = c
                    Console.SetCursorPosition(x / multiplier, y / (multiplier * 2))
                    Console.Write("XX")
                End If
            Next
        Next
        Console.BackgroundColor = ConsoleColor.White
        Console.ForegroundColor = ConsoleColor.White
        If Not PathOnMaze Then
            Console.BackgroundColor = ConsoleColor.Red
            Console.ForegroundColor = ConsoleColor.Red
            list(0).Print("XX")
            Console.BackgroundColor = ConsoleColor.Green
            Console.ForegroundColor = ConsoleColor.Green
            list(list.Count - 1).Print("XX")
        End If
        Console.ReadKey()
    End Sub
    Function Brightnes(ByVal c As Color) As Double
        Dim num1 As Double = c.R ^ 2 * 0.241
        Dim num2 As Double = c.G ^ 2 * 0.691
        Dim num3 As Double = c.B ^ 2 * 0.068
        Return Math.Sqrt(num1 + num2 + num3)
    End Function
End Module
Class Cell
    Dim xcord, ycord As Integer
    Public Usable As Boolean
    Public Sub New(ByVal xpoint As Integer, ByVal ypoint As Integer)
        xcord = xpoint
        ycord = ypoint
    End Sub
    Public Function X()
        Return xcord
    End Function
    Public Function Y()
        Return ycord
    End Function
    Public Sub Print(ByVal str As String)
        'Console.ForegroundColor = Colour
        Console.SetCursorPosition(Me.X, Me.Y)
        Console.Write(str)
    End Sub
End Class