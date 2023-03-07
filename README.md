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
- update existing dictionary | *bhash NTLM -n [string] [file]*

Last Build Notes:
- Added Write Function To Update Lists
- Set Option To Use All Dictionaries In A Directory
- Lazy Code, Working On Cleanup
