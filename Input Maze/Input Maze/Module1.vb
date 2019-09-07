Imports System.Drawing
Imports System.IO

Module Module1

    Sub Main()
        Dim list As New List(Of Cell)
        Dim imageLocation As String = "new maze 2 m 1.png"
        Console.ReadKey()
        Dim image As New Bitmap(imageLocation)
        For x = 1 To (image.Width - 1) Step 1
            For y = 1 To image.Height - 1 Step 1
                Dim pixel As Color = image.GetPixel(x, y)
                If pixel.GetBrightness <> 0 Then
                    list.Add(New Cell(x * 2, y))
                End If
            Next
        Next
        Console.BackgroundColor = ConsoleColor.White
        Console.ForegroundColor = ConsoleColor.White
        For Each node In list
            node.Print("██")
        Next
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