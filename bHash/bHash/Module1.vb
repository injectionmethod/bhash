Imports System.IO

Module Module1

    Sub Main()
        Dim cmdVars As String() = Environment.GetCommandLineArgs

        If cmdVars(1).StartsWith("md5") Then
            If cmdVars(3).StartsWith("-r") Then
                Hash = cmdVars(2)
                ThreadCount = Convert.ToInt32(cmdVars(4))
                Attempts = Convert.ToInt32(cmdVars(5)) * 5
                StageMD5Session("-r")
            ElseIf cmdVars(3).StartsWith("-d") Then
                If IO.File.Exists(cmdVars(4)) Then
                    Hash = cmdVars(2)
                    Dictionary = cmdVars(4)
                    StageMD5Session("-d")
                End If
            End If
        End If

        If cmdVars(1).StartsWith("sha256") Then
            If cmdVars(3).StartsWith("-r") Then
                Hash = cmdVars(2)
                ThreadCount = Convert.ToInt32(cmdVars(4))
                Attempts = Convert.ToInt32(cmdVars(5)) * 5
                StageSHA256Session("-r")
            ElseIf cmdVars(3).StartsWith("-d") Then
                If IO.File.Exists(cmdVars(4)) Then
                    Hash = cmdVars(2)
                    Dictionary = cmdVars(4)
                    StageSHA256Session("-d")
                End If
            End If
        End If

        If cmdVars(1).StartsWith("ntlm") Then
            If cmdVars(2).StartsWith("-g") Then
                method = cmdVars(3)
                Dictionary = cmdVars(4)
                WriteLocation = cmdVars(5)
                If IO.File.Exists(Dictionary) Then
                    CreateNTLMHashDictionaryFile()
                End If
            End If
        End If
    End Sub

End Module
