del .\Signed\ServiceStack.Redis.* /F
"C:\Program Files (x86)\Microsoft SDKs\Windows\v7.0A\Bin\ildasm.exe" .\ServiceStack.Redis.dll /out:.\Signed\ServiceStack.Redis.il
"C:\Windows\Microsoft.NET\Framework\v2.0.50727\ilasm.exe" .\Signed\ServiceStack.Redis.il /dll /key=.\ServiceStackRedisKey.snk /output=.\Signed\ServiceStack.Redis.dll

pause