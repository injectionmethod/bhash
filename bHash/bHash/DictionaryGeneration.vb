Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Module DictionaryGeneration
    Public Stream As StreamWriter
    Public WriteLocation As String
    Public method As String
    Public EnableHashing As Boolean
    Public HashingMethod As String
    Public Function CreateNTLMHashDictionaryFile()
        Console.WriteLine("Converting > " + Dictionary + " > " + method + " > " + WriteLocation)
        Dim sw As New IO.StreamWriter(WriteLocation) : sw.AutoFlush = True
        If Dictionary IsNot Nothing Then
            Using reader As New StreamReader(Dictionary)
                While Not reader.EndOfStream
                    Dim r = reader.ReadLine
                    If method = "sha256" Then
                        sw.WriteLine(GetSHA256Hash(r))
                    ElseIf method = "md5" Then
                        sw.WriteLine(GetMD5Hash(r))
                    End If
                End While
            End Using
        End If
        Console.WriteLine("Converted All Items In Dataset To " + method.ToUpper + "Hashes")
    End Function
    Public Function UpdateFile(a As String, b As String)
        If IO.File.Exists(b) Then
            Dim OriginalNameAltered = b + "S-S76-S"
            Dim sw As New StreamWriter(OriginalNameAltered) : sw.AutoFlush = True
            Console.WriteLine("{+} Updating File!")
            For Each c In IO.File.ReadAllLines(b)
                sw.WriteLine(c)
            Next
            sw.WriteLine(a)
            sw.Close()
            IO.File.Delete(b)
            IO.File.Copy(OriginalNameAltered, b)
            IO.File.Delete(OriginalNameAltered)
            Console.WriteLine("{+} File Updated")
            Console.WriteLine("{+} Added New Password: " + a)
            Console.WriteLine("{+} MD5 Hash: " + GetMD5Hash(a))
            Console.WriteLine("{+} SHA-256 Hash: " + GetSHA256Hash(a))
            Console.WriteLine("{+} SHA-1 Hash: " + GetSHA1Hash(a))
        End If
    End Function

    Public Function CreateNewDictionary()
        Dim b = 0
        Dim workable As Boolean = False
        While b < 1300000
            b += 1
            Dim final As String
            Dim _INITIATE_FIRST As String = RandomString(4, 8)
            For Each line In IO.File.ReadAllLines(Dictionary)
                If line.Contains(_INITIATE_FIRST) Then
                    workable = True
                End If
            Next
            Dim _INITIATE_SECOND As String = RandomString(4, 5)
            For Each line In IO.File.ReadAllLines(Dictionary)
                If line.Contains(_INITIATE_SECOND) Then
                    workable = True
                End If
            Next
            If workable = True Then
                final = _INITIATE_FIRST + _INITIATE_SECOND
                If EnableHashing = True Then
                    If HashingMethod = "md5" Then
                        Stream.WriteLine(GetMD5Hash(final))
                        Console.WriteLine("{+} " + GetMD5Hash(final))
                    ElseIf Hashingmethod = "sha256" Then
                        Stream.WriteLine(GetSHA256Hash(final))
                        Console.WriteLine("{+} " + GetSHA256Hash(final))
                    ElseIf Hashingmethod = "sha1" Then
                        Stream.WriteLine(GetSHA1Hash(final))
                        Console.WriteLine("{+} " + GetSHA1Hash(final))
                    ElseIf HashingMethod = "raw" Then
                        Stream.WriteLine(final)
                        Console.WriteLine("{+} " + final)
                    End If
                End If
            End If
        End While
        Found = True
    End Function
    Public Function RandomString(minCharacters As Integer, maxCharacters As Integer)
        Dim s As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz"
        Static r As New Random
        Dim chactersInString As Integer = r.Next(minCharacters, maxCharacters)
        Dim sb As New System.Text.StringBuilder
        For i As Integer = 1 To chactersInString
            Dim idx As Integer = r.Next(0, s.Length)
            sb.Append(s.Substring(idx, 1))
        Next
        Return sb.ToString()
    End Function
    Public Function GetMD5Hash(ByVal input As String) As String
        Dim md5Hasher As New MD5CryptoServiceProvider()
        Dim data As Byte() = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input))
        Dim sBuilder As New StringBuilder()

        For i As Integer = 0 To data.Length - 1
            sBuilder.Append(data(i).ToString("x2"))
        Next

        Return sBuilder.ToString()
    End Function
    Public Function GetSHA256Hash(ByVal input As String) As String
        Dim sha256 As SHA256 = SHA256Managed.Create()
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(input)
        Dim hashBytes As Byte() = sha256.ComputeHash(bytes)
        Dim hashBuilder As New StringBuilder()

        For i As Integer = 0 To hashBytes.Length - 1
            hashBuilder.Append(hashBytes(i).ToString("x2"))
        Next

        Return hashBuilder.ToString()
    End Function
    Public Function GetSHA1Hash(ByVal input As String) As String
        Dim sha1 As SHA1 = SHA1Managed.Create()
        Dim bytes As Byte() = Encoding.UTF8.GetBytes(input)
        Dim hashBytes As Byte() = sha1.ComputeHash(bytes)
        Dim hashBuilder As New StringBuilder()

        For i As Integer = 0 To hashBytes.Length - 1
            hashBuilder.Append(hashBytes(i).ToString("x2"))
        Next

        Return hashBuilder.ToString()
    End Function
End Module
