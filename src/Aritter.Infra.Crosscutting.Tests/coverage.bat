@echo off

SET dotnet="C:/Program Files/dotnet/dotnet.exe"  
SET opencover=C:\Users\andersonritter\.nuget\packages\OpenCover\4.6.519\tools\OpenCover.Console.exe 
SET reportgenerator=C:\Users\andersonritter\.nuget\packages\ReportGenerator\2.5.5\tools\ReportGenerator.exe

SET targetargs="test"  
SET filter="+[*]* -[*]*.Tests"  
SET coveragefile=Coverage.xml  
SET coveragedir=Coverage

REM Run code coverage analysis  
%opencover% -oldStyle -register:user -target:%dotnet% -output:%coveragefile% -targetargs:%targetargs% -filter:%filter% -skipautoprops -hideskipped:All

REM Generate the report  
%reportgenerator% -targetdir:%coveragedir% -reporttypes:Html;Badges -reports:%coveragefile% -verbosity:Error

REM Open the report  
start "report" "%coveragedir%\index.htm"