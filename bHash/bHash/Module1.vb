Imports System.IO

Module Module1

    Sub Main()



        Dim cmdVars As String() = Environment.GetCommandLineArgs

        If cmdVars.Contains("-v") Then
            Verbose = True
        End If

        If cmdVars(1).StartsWith("-n") Then
            UpdateFile(cmdVars(2), cmdVars(3))
        End If

        'example format because u will forget > bhash -c C:/Lists/example.txt [outputfile] [threads] -h none
        If cmdVars(1).StartsWith("-c") Then
            Dictionary = cmdVars(2)
            DirectoryLocation = cmdVars(3)
            Stream = New IO.StreamWriter(DirectoryLocation) : Stream.AutoFlush = True
            Dim b = 0

            If cmdVars(5).StartsWith("-h") Then
                EnableHashing = True
                HashingMethod = cmdVars(6)
            End If

            While b < cmdVars(4)
                b += 1
                Dim th As New Threading.Thread(AddressOf CreateNewDictionary)
                th.Start()
            End While
            While Found = False

            End While
            Exit Sub
        End If



        If cmdVars(1).StartsWith("md5") Then
            If cmdVars(3).StartsWith("-r") Then
                Hash = cmdVars(2)
                ThreadCount = Convert.ToInt32(cmdVars(4))
                Attempts = Convert.ToInt32(cmdVars(5)) * 5
                StageMD5Session("-r")
            ElseIf cmdVars(3).StartsWith("-d") Then
                Hash = cmdVars(2)
                Dictionary = cmdVars(4)
                StageMD5Session("-d")
            ElseIf cmdVars(3).StartsWith("-a") Then
                Hash = cmdVars(2)
                Dictionary = "null"
                DirectoryLocation = cmdVars(4).ToString
                UseAllMethod = True
                StageMD5Session("-d")
            End If
        End If

        If cmdVars(1).StartsWith("sha256") Then
            If cmdVars(3).StartsWith("-r") Then
                Hash = cmdVars(2)
                ThreadCount = Convert.ToInt32(cmdVars(4))
                Attempts = Convert.ToInt32(cmdVars(5)) * 5
                StageSHA256Session("-r")
            ElseIf cmdVars(3).StartsWith("-d") Then
                Hash = cmdVars(2)
                Dictionary = cmdVars(4).ToString
                StageSHA256Session("-d")
            ElseIf cmdVars(3).StartsWith("-a") Then
                Hash = cmdVars(2)
                Dictionary = "null"
                DirectoryLocation = cmdVars(4).ToString
                UseAllMethod = True
                StageSHA256Session("-d")
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


        'EXAMPLE BECAUSE YOU WILL FORGET bhash scn [file] -a [dictionary(s)] sha256
        If cmdVars(1).StartsWith("scn") Then
            If cmdVars(3).StartsWith("-a") Then
                UseAllMethod = True
                DirectoryLocation = cmdVars(4)
            ElseIf cmdVars(3).StartsWith("-d") Then
                Dictionary = cmdVars(4)
            End If
            method = cmdVars(5)
            BruteForceHashList(cmdVars(2), method)
        End If
    End Sub

End Module
