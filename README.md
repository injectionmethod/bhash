# bhash
bHash is a simple hash cracking tool and and NTLM attack dictionary converter

- Windows Supported
- note: hash conversion can produce very large file sizes, its best to split dictionaries

[Hashtypes as of now]
-*sha1*
-*sha256*
-*md5*

[Commands Examples]
- dictionary bruteforce | *bhash [hashtype] [hash] -d [chosen dictionaries]*

- directory bruteforce | *bhash [hashtype] [hash] -a [chosen directory]*

- random bruteforce | *bhash [hashtype] [hash] -r [threads] [max attempts per thread]*

- create hashlist for NTLM (indev) | *bhash NTLM -g [chosen dictionary] [output file]*
 
- update existing dictionary | *bhash -n [string] [file]*

[Commands Copy Pastes]
- ex: bhash sha265 1b5c3 -d C:\examplefile1,C:\examplefile2
- ex: bhash sha265 1b5c3 -a C:\exampleDirectory
- ex: bhash sha265 1b5c3 -r 10 300000
- ex: bhash NTLM C:\examplefile C:\exampleoutput
- ex: bhash -n examplepassword123 C:\examplefile

Last Build Notes:
- Added Write Function To Update Lists
- Set Option To Use All Dictionaries In A Directory
- Lazy Code, Working On Cleanup
