Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Module DictionaryGeneration
    Public WriteLocation As String
    Public method As String
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
        Console.WriteLine("Converted All Items In Dataset")
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
