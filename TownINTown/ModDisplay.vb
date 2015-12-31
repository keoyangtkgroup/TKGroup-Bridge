Module ModDisplay
    Public Sub ShowDisplay(ByVal PortcomB As String, ByVal Bps As Integer, ByVal Text As String)
        Try
            Dim ComPort As New System.IO.Ports.SerialPort
            With ComPort
                If .IsOpen = True Then .Close()
                .PortName = PortcomB
                .BaudRate = Bps
                .Parity = IO.Ports.Parity.None
                .DataBits = 8
                .StopBits = IO.Ports.StopBits.One
                .Open()
                If Text.Length = 7 Then
                    Text = " " & Text
                ElseIf Text.Length = 6 Then
                    Text = "  " & Text
                ElseIf Text.Length = 5 Then
                    Text = "   " & Text
                ElseIf Text.Length = 4 Then
                    Text = "    " & Text
                ElseIf Text.Length = 3 Then
                    Text = "     " & Text
                ElseIf Text.Length = 2 Then
                    Text = "      " & Text
                ElseIf Text.Length = 1 Then
                    Text = "       " & Text
                End If
                .WriteLine(Chr(1) & "A" & Text & Chr(13) & Chr(4))
                .Close()
            End With
        Catch ex As Exception

        End Try
    End Sub
End Module
