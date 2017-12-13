# 2_Terminal_Hacker

This is just my version of the Terminal Hacker game project from Udemy's Unity course.

NB To convert Windows Line Endings back to Mac format, just:
sed -i '' -e $'s/$/\r\r/' filename
This fixed it but added newlines all over the file

Try:
sed -e 's/$/^M/' inputfile > outputfile, where ^M is a control character produced on the command line via Ctrl+V Ctrl+M

OR 

perl -pe 's/\r\n|\n|\r/\n/g'   inputfile > outputfile
