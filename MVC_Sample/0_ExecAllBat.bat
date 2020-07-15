echo | call 1_DeleteDir.bat
echo | call 1_DeleteFile.bat

@echo on
timeout 5

rem echo | 3_BuildLibsAtOtherRepos.bat
rem echo | 3_BuildLibsAtOtherReposInTimeOfDev.bat

@echo on
timeout 5

echo | 6_Build_WSSrv_sample.bat
echo | 6_Build_WSSrvCore_sample.bat
echo | 10_ASPNETWebService.bat
echo | 10_ASPNETWebServiceCore.bat

@echo on
timeout 5
