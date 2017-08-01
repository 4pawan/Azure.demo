#
# login.ps1
#
#https://www.mssqltips.com/sqlservertip/4794/using-powershell-to-restore-an-azure-sql-database/
#http://www.mikefal.net/2016/05/19/azure-sql-databases-with-powershell-exporting-and-importing/
#
#
#
#


$cred = Get-Credential
$sqlcontext = New-AzureSqlDatabaseServerContext -ServerName 'server1111111' -Credential $cred

$key = (Get-AzureRmStorageAccountKey -ResourceGroupName 'RG1' -StorageAccountName 'pwnstorageaccount').Key1
$stctxt = New-AzureStorageContext -StorageAccountName 'pwnstorageaccount' -StorageAccountKey $key