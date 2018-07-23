@ECHO OFF

FOR /D %%i in (Locales\*.*) DO echo f | xcopy /Y %%~dpi\%%~ni\LC_MESSAGES\Demo.mo ..\Assets\Locales\Demo.%%~ni.mo
