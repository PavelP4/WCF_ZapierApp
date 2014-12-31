REM ========= applicationhost.config =============      
REM <sites>
REM <site name="ZapService.Host" id="2">
REM <application path="/">
REM <virtualDirectory path="/" physicalPath="D:\Repos\WCF_ZapierApp\ZapService.Host" />
REM </application>
REM <bindings>
REM <binding protocol="http" bindingInformation=":8800:192.168.107.132" />
REM </bindings>
REM </site>
REM </sites>

cd "c:\Program Files (x86)\IIS Express\"
iisexpress.exe /config:"c:\Users\maslovskiip\Documents\IISExpress\config\applicationhost.config"