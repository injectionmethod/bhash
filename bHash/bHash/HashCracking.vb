Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Module HashCracking
    Public Hash
    Public Found As Boolean
    Public Attempts As Integer
    Public ThreadCount As Integer
    Public Dictionary As String
    Public DirectoryLocation As String
    Public UseAllMethod As Boolean


    'START MD5 METHODS
    Public Function GuessMD5HashByteBrute() As String
        Dim md5Hasher As New MD5CryptoServiceProvider()
        Dim rand As New Random()
        Dim attempt As Integer = 1

        While attempt <= Attempts
            If Found = False Then
                Dim inputBytes As Byte() = New Byte(rand.Next(1, 100)) {}
                rand.NextBytes(inputBytes)
                Dim hashBytes As Byte() = md5Hasher.ComputeHash(inputBytes)
                Dim hashString As String = BitConverter.ToString(hashBytes).Replace("-", "").ToLower()
                Console.WriteLine(hashString + " > Length:" + Encoding.Default.GetString(inputBytes).Length.ToString + " > Attempt #" + attempt.ToString + vbNewLine)
                If hashString = Hash Then
                    Console.WriteLine("Hash Found > " + Hash + " > " + Encoding.Default.GetString(inputBytes))
                    Found = True
                    Exit Function
                End If
                attempt += 1
            Else Exit Function
            End If
        End While

        Console.WriteLine("No matching string found within " & Attempts & " attempts.")
    End Function
    Public Function GuessMD5HashDictionaryBrute() As String
        Dim hash_recovered As Boolean = False

        Dim hash_string As String = Nothing

        For Each Upperletter As Char In Enumerable.Range(Convert.ToInt16("A"c), 26) _
                                     .Select(Function(i) Convert.ToChar(i))
            Dim U = GetMD5Hash(Upperletter.ToString)
            If U = Hash Then
                hash_recovered = True
                Found = True
                hash_string = "@/md5/cracked?=" + Hash + " > " + Upperletter
                Console.WriteLine(hash_string)
                Exit Function
            Else
                Console.WriteLine("{+} Guess 1 > Not Found")
            End If
        Next

        For Each Lowerletter As Char In Enumerable.Range(Convert.ToInt16("A"c), 26) _
                                     .Select(Function(i) Convert.ToChar(i))
            Dim L = GetMD5Hash(Lowerletter.ToString.ToLower)
            If L = Hash Then
                Found = True
                hash_string = "@/md5/cracked?=" + Hash + " > " + Lowerletter
                Console.WriteLine(hash_string)
                Exit Function
            Else
                Console.WriteLine("{+} Guess 2 > Not Found")
            End If
        Next

        If Dictionary IsNot Nothing Then
            If UseAllMethod = True Then
                For Each dict As String In IO.Directory.GetFiles(DirectoryLocation)
                    Using reader As New StreamReader(dict)
                        While Not reader.EndOfStream
                            If Found = False Then
                                Dim w = reader.ReadLine
                                Dim Word = GetMD5Hash(w)
                                If Word = Hash Then
                                    hash_recovered = True
                                    hash_string = "@/md5/cracked?=" + w + " > " + Word
                                    Console.WriteLine(hash_string)
                                    Found = True
                                Else
                                    Console.WriteLine(w + " > " + Word + " > " + Hash + " > !=Hash")
                                End If
                            Else
                                Exit Function
                            End If
                        End While
                    End Using
                Next
            Else
                For Each dict As String In Strings.Split(Dictionary, ",", -1)
                    Using reader As New StreamReader(dict)
                        While Not reader.EndOfStream
                            If Found = False Then
                                Dim w = reader.ReadLine
                                Dim Word = GetMD5Hash(w)
                                If Word = Hash Then
                                    hash_recovered = True
                                    hash_string = "@/md5/cracked?=" + w + " > " + Word
                                    Console.WriteLine(hash_string)
                                    Found = True
                                Else
                                    Console.WriteLine(w + " > " + Word + " > " + Hash + " > !=Hash")
                                End If
                            Else
                                Exit Function
                            End If
                        End While
                    End Using
                Next
            End If
        End If

        If Found = False Then
            Console.WriteLine("{+} No Hash Match Found")
        End If
    End Function
    'END MD5 METHODS

    'START SHA 256 METHODS
    Public Function GuessSHA256HashByteBrute() As String
        Dim rng As New Random()
        Dim alphabet As String = "abcdefghijklmnopqrstuvwxyz"
        Dim inputString As String
        Dim hashBytes() As Byte
        Dim hashString As String

        Dim sha256 As SHA256 = SHA256.Create()

        For i As Integer = 1 To Attempts
            If Found = False Then
                inputString = ""
                Dim stringLength As Integer = rng.Next(1, 10)
                For j As Integer = 1 To stringLength
                    Dim nextCharIndex As Integer = rng.Next(0, alphabet.Length)
                    inputString &= alphabet(nextCharIndex)
                Next
                hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputString))
                hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower()
                If hashString = Hash Then
                    Console.WriteLine(Hash + " > " + inputString)
                    Found = True
                Else
                    Console.WriteLine(hashString + " > Length:" + hashString.Length.ToString + " > Attempt #" + i.ToString + vbNewLine)
                End If
            Else
                Exit Function
            End If
        Next
        If Found = False Then
            Console.WriteLine("{+} No Hash Match Found")
        End If
    End Function
    Public Function GuessSHA256HashDictionaryBrute() As String
        Dim hash_recovered As Boolean = False

        Dim hash_string As String = Nothing

        For Each Upperletter As Char In Enumerable.Range(Convert.ToInt16("A"c), 26) _
                                     .Select(Function(i) Convert.ToChar(i))
            Dim U = GetSHA256Hash(Upperletter.ToString)
            If U = Hash Then
                hash_recovered = True
                Found = True
                hash_string = "@/sha256/cracked?=" + Hash + " > " + Upperletter
                Console.WriteLine(hash_string)
                Exit Function
            End If
        Next

        For Each Lowerletter As Char In Enumerable.Range(Convert.ToInt16("A"c), 26) _
                                     .Select(Function(i) Convert.ToChar(i))
            Dim L = GetSHA256Hash(Lowerletter.ToString.ToLower)
            If L = Hash Then
                Found = True
                hash_string = "@/sha256/cracked?=" + Hash + " > " + Lowerletter
                Console.WriteLine(hash_string)
                Exit Function
            End If
        Next

        If Dictionary IsNot Nothing Then
            If UseAllMethod = True Then
                For Each dict As String In IO.Directory.GetFiles(DirectoryLocation)
                    Using reader As New StreamReader(dict)
                        While Not reader.EndOfStream
                            If Found = False Then
                                Dim w = reader.ReadLine
                                Dim Word = GetSHA256Hash(w)
                                If Word = Hash Then
                                    hash_recovered = True
                                    hash_string = "@/sha256/cracked?=" + w + " > " + Word
                                    Console.WriteLine(hash_string)
                                    Found = True
                                Else
                                    Console.WriteLine(w + " > " + Word + " > " + Hash + " > !=Hash")
                                End If
                            Else
                                Exit Function
                            End If
                        End While
                    End Using
                Next
            Else
                For Each dict As String In Strings.Split(Dictionary, ",", -1)
                    Using reader As New StreamReader(dict)
                        While Not reader.EndOfStream
                            If Found = False Then
                                Dim w = reader.ReadLine
                                Dim Word = GetSHA256Hash(w)
                                If Word = Hash Then
                                    hash_recovered = True
                                    hash_string = "@/sha256/cracked?=" + w + " > " + Word
                                    Console.WriteLine(hash_string)
                                    Found = True
                                Else
                                    Console.WriteLine(w + " > " + Word + " > " + Hash + " > !=Hash")
                                End If
                            Else
                                Exit Function
                            End If
                        End While
                    End Using
                Next
            End If
        End If

        If Found = False Then
            Console.WriteLine("{+} No Hash Match Found")
        End If
    End Function
    'END SHA 256 METHODS

    'START SHA 1 METHODS
    Public Function GuessSHA1HashByteBrute() As String
        Dim rng As New Random()
        Dim alphabet As String = "abcdefghijklmnopqrstuvwxyz"
        Dim inputBytes() As Byte
        Dim hashBytes() As Byte
        Dim sha1 As SHA1 = SHA1.Create()

        For i As Integer = 1 To Attempts
            If Found = False Then
                Dim inputLength As Integer = rng.Next(1, 10)
                ReDim inputBytes(inputLength - 1)
                For j As Integer = 0 To inputLength - 1
                    Dim nextByteIndex As Integer = rng.Next(0, 256)
                    inputBytes(j) = CByte(nextByteIndex)
                Next
                hashBytes = sha1.ComputeHash(inputBytes)
                Dim hashString As String = BitConverter.ToString(hashBytes).Replace("-", "").ToLower()
                If hashString = Hash Then
                    Dim hash_string = "@/sha1/cracked?=" + hashString + " > " + Encoding.UTF8.GetString(inputBytes)
                    Console.WriteLine(hash_string)
                    Found = True
                Else
                    Console.WriteLine(hashString + " > Length:" + hashString.Length.ToString + " > Attempt #" + i.ToString + vbNewLine)
                End If
            End If
        Next
        If Found = False Then
            Console.WriteLine("{+} No Hash Match Found")
        End If
    End Function

    Public Function GuessSHA1HashDictionaryBrute() As String
        Dim hash_recovered As Boolean = False

        Dim hash_string As String = Nothing

        For Each Upperletter As Char In Enumerable.Range(Convert.ToInt16("A"c), 26) _
                                     .Select(Function(i) Convert.ToChar(i))
            Dim U = GetSHA256Hash(Upperletter.ToString)
            If U = Hash Then
                hash_recovered = True
                Found = True
                hash_string = "@/sha256/cracked?=" + Hash + " > " + Upperletter
                Console.WriteLine(hash_string)
                Exit Function
            End If
        Next

        For Each Lowerletter As Char In Enumerable.Range(Convert.ToInt16("A"c), 26) _
                                     .Select(Function(i) Convert.ToChar(i))
            Dim L = GetSHA256Hash(Lowerletter.ToString.ToLower)
            If L = Hash Then
                Found = True
                hash_string = "@/sha256/cracked?=" + Hash + " > " + Lowerletter
                Console.WriteLine(hash_string)
                Exit Function
            End If
        Next

        If Dictionary IsNot Nothing Then
            For Each dict As String In Strings.Split(Dictionary, ",", -1)
                Using reader As New StreamReader(dict)
                    While Not reader.EndOfStream
                        If Found = False Then
                            Dim w = reader.ReadLine
                            Dim Word = GetSHA256Hash(w)
                            If Word = Hash Then
                                hash_recovered = True
                                hash_string = "@/sha256/cracked?=" + w + " > " + Word
                                Console.WriteLine(hash_string)
                                Found = True
                            Else
                                Console.WriteLine(w + " > " + Word + " > " + Hash + " > !=Hash")
                            End If
                        Else
                            Exit Function
                        End If
                    End While
                End Using
            Next
        End If

        If Found = False Then
            Console.WriteLine("{+} No Hash Match Found")
        End If
    End Function
    'END SHA 1 METHODS

    'START NTLM METHODS

    'END NTLM METHODS
End Module
