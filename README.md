# bhash
bHash is a simple hash cracking tool and and NTLM attack dictionary converter

- Windows Supported
- note: ntlm hash conversion can produce very large file sizes, its best to split dictionaries

[Hashtypes as of now]
-*sha1*
-*sha256*
-*md5*

[Commands Examples]
- *bhash [hashtype] hash -d [chosen dictionary]*
- *bhash [hashtype] hash -r [threads] [max attempts per thread]*
- *bhash NTLM -g [chosen dictionary] [output file]*
