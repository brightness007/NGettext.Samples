@ECHO OFF

SET path_xgettext=..\..\..\External\Gnu.Gettext\bin

dir ..\*.cs /S /B > Strings.filelist

%path_xgettext%\xgettext.exe  --from-code=UTF-8 -L C# --omit-header -o POT\Demo.pot -f Strings.filelist
