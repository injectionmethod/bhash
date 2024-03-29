bHash is a hash cracking tool and dictionary converter designed for windows command line
========================================================================================


[Hashtypes as of now]
- *sha1*
- *sha256*
- *md5*
- *raw*

[Notes]
- Still In Development (latest release)
- Windows 11 Supported


[Commands Examples]

- verbose mode | bhash [input] -v

- see help | *bhash -h*

- dictionary bruteforce | *bhash [hashtype] [hash] -d [chosen dictionaries]*

- directory bruteforce | *bhash [hashtype] [hash] -a [chosen directory]*

- random bruteforce | *bhash [hashtype] [hash] -r [threads] [max attempts per thread]*

- create hashlist (indev) | *bhash convert -g [hashtype] [chosen dictionary] [output file]*
 
- update existing dictionary | *bhash -n [string] [file]*

- bruteforce a hashlist | *bhash scn [file] [-d or -a] [chosen dictionary or directory] [hashtype]*

- create a new dictionary | *bhash -c [outputfile] [compare-file] [threads] -h [hashtype]*


![image](https://user-images.githubusercontent.com/80434330/226054615-96cf56a2-55b4-4401-8ce3-bd3dab3d64da.png)


[Commands Copy Pastes]
- ex: bhash -h
- ex: bhash sha256 1b5c3 -d C:\examplefile1,C:\examplefile2
- ex: bhash sha256 1b5c3 -a C:\exampleDirectory
- ex: bhash sha256 1b5c3 -r 10 300000
- ex: bhash convert -g sha256 C:\examplefile C:\exampleoutput
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


[Wordlist Information]
- https://github.com/injectionmethod/bhash/blob/main/No%20wordlists%3F
