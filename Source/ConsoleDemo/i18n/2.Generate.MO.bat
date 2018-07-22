@ECHO OFF

SET path_xgettext=..\..\..\External\Gnu.Gettext\bin

FOR /R %%i in (*.po) DO %path_xgettext%\msgfmt.exe -o %%~dpni.mo %%i