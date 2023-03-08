bHash is a hash cracking tool and dictionary converter designed for windows command line
========================================================================================


[Notes]
- Still In Development (latest release)
- Windows 11 Supported
- hash conversion can produce very large file sizes, its best to split dictionaries

#bhash


[Hashtypes as of now]
-*sha1*
-*sha256*
-*md5*
-*raw*


[Commands Examples]

- verbose mode | bhash [input] -v

- see help | *bhash -h*

- dictionary bruteforce | *bhash [hashtype] [hash] -d [chosen dictionaries]*

- directory bruteforce | *bhash [hashtype] [hash] -a [chosen directory]*

- random bruteforce | *bhash [hashtype] [hash] -r [threads] [max attempts per thread]*

- create hashlist for NTLM (indev) | *bhash NTLM -g [chosen dictionary] [output file]*
 
- update existing dictionary | *bhash -n [string] [file]*

- bruteforce a hashlist | *bhash scn [file] [-d or -a] [chosen dictionary or directory] [hashtype]*

- create a new dictionary | *bhash -c [outputfile] [compare-file] [threads] -h [hashtype]*


[Commands Copy Pastes]
- ex: bhash -h
- ex: bhash sha265 1b5c3 -d C:\examplefile1,C:\examplefile2
- ex: bhash sha265 1b5c3 -a C:\exampleDirectory
- ex: bhash sha265 1b5c3 -r 10 300000
- ex: bhash NTLM C:\examplefile C:\exampleoutput
- ex: bhash -n examplepassword123 C:\examplefile
- ex: bhash scn C:\example-dump.txt -d C:\examplefile1,C:\examplefile2 sha256
- ex: bhash scn C:\example-dump.txt -a C:\exampleDirectory sha256
- ex: bhash -c C:\example.txt C:\example_dictionary 5 -h raw


[Last Few Builds Notes]
- Added Write Function To Update Lists
- Set Option To Use All Dictionaries In A Directory
- Added Function To Create New Dictionaries
- Updated HashCracking Module, Included The Ability To Bruteforce A Hashlist, see [Commands Examples]
- Fixed Formatting And Added Verbose Output
- Lazy Code, Working On Cleanup
