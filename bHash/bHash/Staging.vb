Module Staging
    Public Function StageMD5Session(method As String)
        If method = "-r" Then
            MD5BruteStageThreadLoader()
        ElseIf method = "-d" Then
            GuessMD5HashDictionaryBrute()
        End If
    End Function
    Public Function StageSHA256Session(method As String)
        If method = "-r" Then
            SHA256BruteStageThreadLoader()
        ElseIf method = "-d" Then
            GuessSHA256HashDictionaryBrute()
        End If
    End Function
    Public Function StageSHA1Session(method As String)
        If method = "-r" Then
            SHA1BruteStageThreadLoader()
        ElseIf method = "-d" Then
            GuessSHA256HashDictionaryBrute()
        End If
    End Function
    Public Function StageNTLMSession(method As String)
        If method = "g" Then
            CreateNTLMHashDictionaryFile()
        End If
    End Function
    Public Sub MD5BruteStageThreadLoader()
        Dim b As Integer = 0
        Console.WriteLine("Launching " + ThreadCount.ToString + " Worker Threads")
        While b < ThreadCount
            b += 1
            Threading.Thread.Sleep(300)
            Dim th As New Threading.Thread(AddressOf GuessMD5HashByteBrute)
            th.Start()
            Threading.Thread.Sleep(300)
        End While
    End Sub
    Public Sub SHA1BruteStageThreadLoader()
        Dim b As Integer = 0
        Console.WriteLine("Launching " + ThreadCount.ToString + " Worker Threads")
        While b < ThreadCount
            b += 1
            Threading.Thread.Sleep(300)
            Dim th As New Threading.Thread(AddressOf GuessSHA1HashByteBrute)
            th.Start()
            Threading.Thread.Sleep(300)
        End While
    End Sub
    Public Sub SHA256BruteStageThreadLoader()
        Dim b As Integer = 0
        Console.WriteLine("Launching " + ThreadCount.ToString + " Worker Threads")
        While b < ThreadCount
            b += 1
            Threading.Thread.Sleep(300)
            Dim th As New Threading.Thread(AddressOf GuessSHA256HashByteBrute)
            th.Start()
            Threading.Thread.Sleep(300)
        End While
    End Sub
End Module
