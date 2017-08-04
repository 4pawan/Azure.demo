#
# login.ps1
#
#https://www.mssqltips.com/sqlservertip/4794/using-powershell-to-restore-an-azure-sql-database/
#http://www.mikefal.net/2016/05/19/azure-sql-databases-with-powershell-exporting-and-importing/
#https://docs.microsoft.com/en-us/azure/sql-database/sql-database-get-started-powershell
#
#
#


# Prompts you for azure credentials
Add-AzureRmAccount 

# List my subscriptions
#$Subscription = Get-AzureRmSubscription

Write  "Id is $Subscription"

# Pick my Developer one
#Set-AzureRmContext -SubscriptionId $Subscription.Id

Get-AzureRmSubscription -SubscriptionId $Subscription | Select-AzureRmSubscription
Get-AzureSqlDatabaseServer -Verbose $Subscription | Select-AzureRmSubscription

#c26a8444-f72b-4b3d-b99b-c0e0ee3cb6cd


$cred = Get-Credential
$sqlcontext = New-AzureSqlDatabaseServerContext -ServerName 'server1111111' -Credential $cred

$key = (Get-AzureRmStorageAccountKey -ResourceGroupName 'RG1' -StorageAccountName 'pwnstorageaccount').Key1
$stctxt = New-AzureStorageContext -StorageAccountName 'pwnstorageaccount' -StorageAccountKey $key





Write-Host "Welcome to powershell"
Get-Command -Module "AzureRM*"
(Get-Command -Module "AzureRM*").Length
$name= Read-Host "Enter your name"
Write-Host "Welome"  $name

$cred = Get-Credential
Login-AzureRMAccount -Credential $cred


Get-Command -Noun "*ResourceGroup*" 
Get-help New-AzureRmResourceGroup  -Examples


Login-AzureRMAccount
$rname= "FirstRM"
New-AzureRmResourceGroup -Name $rname -Location "westindia"  
New-AzureRmStorageAccount -ResourceGroupName $rname -Name "pwn22072017" `
-SkuName standard_LRS -Location "westindia" -kind Storage


$cred = Get-Credential
#Login-AzureRMAccount
$server= New-AzureRmSqlServer -ServerName "pwnserver" -Location "westindia" -ResourceGroupName "FirstRM" -SqlAdministratorCredentials $cred
 
 New-AzureRmSqlDatabase -DatabaseName "myDB" -Edition Standard `
 -ServerName $server.ServerName -ResourceGroupName "FirstRM"


 New-AzureRmSqlServer -ResourceGroupName "FirstRM" -Location "Central US" -ServerName "pwnserver12" -ServerVersion "12.0" -SqlAdministratorCredentials (Get-Credential)




 $SqlServer = @{
  ResourceGroupName = 'FirstRM';
  Name = 'pwnserver';
  Location = 'westindia';
  SqlAdministratorCredentials = (Get-Credential);
  ServerVersion = '12.0';
  }
New-AzureRmSqlServer @SqlServer;


#=================================================================================================================
Add-AzureRmAccount
# The data center and resource name for your resources
$resourcegroupname = "FirstRM"
$location = "WestEurope"
# The logical server name: Use a random value or replace with your own value (do not capitalize)
$servername = "server-$(Get-Random)"
# Set an admin login and password for your database
# The login information for the server
$adminlogin = "ServerAdmin"
$password = "pass123!@#"
# The ip address range that you want to allow to access your server - change as appropriate
$startip = "0.0.0.0"
$endip = "0.0.0.0"
# The database name
$databasename = "mySampleDatabase"


New-AzureRmSqlServer -ResourceGroupName $resourcegroupname `
    -ServerName $servername `
    -Location $location `
    -SqlAdministratorCredentials $(New-Object -TypeName System.Management.Automation.PSCredential -ArgumentList $adminlogin, $(ConvertTo-SecureString -String $password -AsPlainText -Force))

#======================================================================================================================
New-AzureRmSqlDatabase  -ResourceGroupName $resourcegroupname `
    -ServerName $servername `
    -DatabaseName $databasename `
    -SampleName "AdventureWorksLT" `
    -RequestedServiceObjectiveName "S0"
#=====================================================================================================================
$Secure_String_Pwd = ConvertTo-SecureString "pass123!@#" -AsPlainText -Force
$exportRequest = New-AzureRmSqlDatabaseExport -ResourceGroupName $resourcegroupname -ServerName $servername `
  -DatabaseName $databasename -StorageKeytype 'StorageAccessKey' -StorageKey 'WycmVlc7OfudHoqhogmU4w8drzuMiTyZ3q0FYOY6f4kLebFYh79m3R0ZjvqujLTnMit0uEdaL33zUDq6ECJ/Bg==' -StorageUri 'https://pwn22072017.blob.core.windows.net/test123' `
  -AdministratorLogin $adminlogin -AdministratorLoginPassword $Secure_String_Pwd


write $exportRequest 
write $creds 

New-AzureRmSqlDatabaseExport -ResourceGroupName $resourcegroupname -ServerName $servername -DatabaseName $databasename -StorageKeyType "StorageAccessKey" -StorageKey "WycmVlc7OfudHoqhogmU4w8drzuMiTyZ3q0FYOY6f4kLebFYh79m3R0ZjvqujLTnMit0uEdaL33zUDq6ECJ/Bg==" -StorageUri "https://pwn22072017.blob.core.windows.net/test123" -AdministratorLogin $adminlogin -AdministratorLoginPassword $Secure_String_Pwd


Get-AzureStorageKey -StorageAccountName "pwn22072017"