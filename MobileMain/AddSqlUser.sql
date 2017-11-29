Use [ReflexMobile]
go

declare @sql varchar(max), @sql_user varchar(100)

select @sql_user = '_UserPlaceHolder_' 

-- Server Security
if not exists(
select loginname, *
from master.dbo.syslogins
where name = @sql_user and dbname='master')
begin
select @sql = '
create login ['+@sql_user+'] from windows with default_language=[us_english]
exec master.dbo.sp_addsrvrolemember ['+@sql_user+'], [sysadmin]
exec master.dbo.sp_addsrvrolemember ['+@sql_user+'], [dbcreator] '
exec(@sql)
end

-- Database Security
if not exists(
select name
from sys.database_principals
where type='U' and SUSER_SNAME(sid) = @sql_user)
begin
select @sql = '
create user ['+@sql_user+'] for login ['+@sql_user+'] with default_schema=[dbo]
alter role [db_datareader] add member ['+@sql_user+']
alter role [db_datawriter] add member ['+@sql_user+']
alter role [db_owner] add member ['+@sql_user+'] '
exec(@sql)
end
