declare @companyId int;
declare @server varchar(50);
declare @database varchar(50); 
declare @sql varchar(max)

set @companyId = 1;
set @server = 'CSMSQL2014';
set @database = 'TR_KELLER_CSM_QA'; 

------------------------------------------------------------------------ Company
set @sql = 'delete Company where Id = @companyId;
insert Company(MatchId, CompanyName, [Server], [Database], IsDefault, LastSyncTime) 
select ID, CompanyName, ''@server'', ''@database'', 1, getdate() from [@server].[@database].dbo.Company';

set @sql = replace(@sql, '@companyId', @companyId);
set @sql = replace(@sql, '@server', @server);
set @sql = replace(@sql, '@database', @database);

print @sql
exec (@sql)

select * from Company

----------------------------------------------------------------------- WorkClass
set @sql = 'delete WorkClass where companyId = @companyId;
insert WorkClass(MatchId, companyId, Code, [Desc], RegularBillRate, OvertimeBillRate, DoubletimeBillRate, TravelBillRate) 
select Id, @companyId, wc_code, wc_desc, Regular, OverTime, DoubleTime, Travel from [@server].[@database].dbo.work_class';

set @sql = replace(@sql, '@companyId', @companyId);
set @sql = replace(@sql, '@server', @server);
set @sql = replace(@sql, '@database', @database);

print @sql
exec (@sql)

select * from WorkClass


------------------------------------------------------------------------ TimeCode
set @sql = 'delete TimeCode where companyId = @companyId;
insert TimeCode(MatchId, companyId, [Desc], ValueType, BillingRateType) 
select Id, @companyId, Description, ValueType, BillingRateType from [@server].[@database].dbo.WS_EMP_Time_Code';

set @sql = replace(@sql, '@companyId', @companyId);
set @sql = replace(@sql, '@server', @server);
set @sql = replace(@sql, '@database', @database);

print @sql
exec (@sql)

select * from TimeCode

------------------------------------------------------------------------ Level1Code
set @sql = 'delete Level1Code where companyId = @companyId;
insert Level1Code(MatchId, CompanyId, Code, [Desc]) 
select lv1ID, @companyId, lv1_code, lv1_desc from [@server].[@database].dbo.Level1_Codes';

set @sql = replace(@sql, '@companyId', @companyId);
set @sql = replace(@sql, '@server', @server);
set @sql = replace(@sql, '@database', @database);

print @sql
exec (@sql)

select * from Level1Code

------------------------------------------------------------------------ Level2Code
set @sql = 'delete Level2Code where companyId = @companyId;
insert Level2Code(MatchId, companyId, Level1Id, Code, [Desc]) 
select lv2ID, @companyId, lv1ID, lv2_code, lv2_desc from [@server].[@database].dbo.Level2_Codes';

set @sql = replace(@sql, '@companyId', @companyId);
set @sql = replace(@sql, '@server', @server);
set @sql = replace(@sql, '@database', @database);

print @sql
exec (@sql)

select * from Level2Code

------------------------------------------------------------------------ Employee
set @sql = 'delete Employee where companyId = @companyId;
insert Employee(EmpNum, CompanyId, FirstName, LastName, WorkClassCode) 
select emp_no, @companyId, emp_first_name, emp_last_name, wc_code from [@server].[@database].dbo.Employee where emp_co=@companyId';

set @sql = replace(@sql, '@companyId', @companyId);
set @sql = replace(@sql, '@server', @server);
set @sql = replace(@sql, '@database', @database);

print @sql
exec (@sql)

select * from Employee

------------------------------------------------------------------------ EquipmentClass
set @sql = 'delete EquipmentClass where companyId = @companyId;
insert EquipmentClass(CompanyId, Code, [Desc]) 
select @companyId, facl_code, facl_desc from [@server].[@database].dbo.fa_class';

set @sql = replace(@sql, '@companyId', @companyId);
set @sql = replace(@sql, '@server', @server);
set @sql = replace(@sql, '@database', @database);

print @sql
exec (@sql)

select * from EquipmentClass

------------------------------------------------------------------------ Equipment
set @sql = 'delete Equipment where companyId = @companyId;
insert Equipment(EqpNum, CompanyId, AssetCode, [Desc], ClassCode) 
select eqi_num, @companyId, eqi_code, eqi_desc1, eqi_class from [@server].[@database].dbo.Equip_ID';

set @sql = replace(@sql, '@companyId', @companyId);
set @sql = replace(@sql, '@server', @server);
set @sql = replace(@sql, '@database', @database);

print @sql
exec (@sql)

select * from Equipment

------------------------------------------------------------------------ Project
set @sql = 'delete Project where companyId = @companyId;
insert Project(MatchId, CompanyId, Name, Code, CustomerId, CustomerCode, CustomerName, CustomerAddress, SiteLocation, StartDate, EstCompletionDate, Billable) 
select pri_id, @companyId, pri_name, pri_code, ph.customer_id, c.customer_Code, c.Name, c.Bill_Address_1, pri_site1, pri_start_date, pri_est_completion_date, billable 
from [@server].[@database].dbo.proj_header ph
join [@server].[@database].dbo.customers c on c.customer_id = ph.customer_id';

set @sql = replace(@sql, '@companyId', @companyId);
set @sql = replace(@sql, '@server', @server);
set @sql = replace(@sql, '@database', @database);

print @sql
exec (@sql)

select * from Project

------------------------------------------------------------------------ ProjectWorkClass
set @sql = 'delete ProjectWorkClass where companyId = @companyId;
insert ProjectWorkClass(MatchId, CompanyId, ProjectId, WorkClassCode, RegularBillRate, OvertimeBillRate, DoubletimeBillRate, TravelBillRate, Schedulable, CeilingCost, RegularHours, TravelHours) 
select cwc_id, @companyId, pri_id, WC_Code, Standard, OverTime, Doubletime, TravelTime, isnull(sch_enabled, ''false''), CeilingCost, sch_bud_hrs_reg, sch_bud_hrs_tt  
from [@server].[@database].dbo.costing_work_class';

set @sql = replace(@sql, '@companyId', @companyId);
set @sql = replace(@sql, '@server', @server);
set @sql = replace(@sql, '@database', @database);

print @sql
exec (@sql)

select * from ProjectWorkClass

------------------------------------------------------------------------ ProjectEquipmentClass
set @sql = 'delete ProjectEquipmentClass where companyId = @companyId;
insert ProjectEquipmentClass(MatchId, companyId, ProjectId, ClassCode, Schedulable, UseOverride, BillRate, BillCycle) 
select cer_id, @companyId, pri_id, eqi_Class, isnull(sch_enabled, ''false''), case UseEquipOverride when ''T'' then 1 else ''0'' end, rate, isnull(TimeCode, ''U'')
from [@server].[@database].dbo.costing_equipment_class m join [@server].[@database].dbo.unit_time_measurement u on m.UOM=u.Id';

set @sql = replace(@sql, '@companyId', @companyId);
set @sql = replace(@sql, '@server', @server);
set @sql = replace(@sql, '@database', @database);

print @sql
exec (@sql)

select * from ProjectEquipmentClass

------------------------------------------------------------------------ ProjectOvertimeLimit
set @sql = 'delete ProjectOvertimeLimit where companyId = @companyId;
insert ProjectOvertimeLimit(MatchId, companyId, ProjectId, Code, [Desc], DailyLimit, DailyDoubleLimit, WeeklyLimit, WeeklyDoubleLimit) 
select ol_id, @companyId, pri_id, ol_code, ol_desc, ol_ot, ol_dt, ol_week_ot, ol_week_dt
from [@server].[@database].dbo.ot_limit';

set @sql = replace(@sql, '@companyId', @companyId);
set @sql = replace(@sql, '@server', @server);
set @sql = replace(@sql, '@database', @database);

print @sql
exec (@sql)

select * from ProjectOvertimeLimit

------------------------------------------------------------------------ LemLogHeader
set @sql = 'delete LemLogHeader where companyId = @companyId;
insert LemLogHeader(MatchId, CompanyId, LogDate, LogStatus, ProjectId, LemNum, TimeStamp) 
select h.id, @companyId, LogDate, LogStatus, pri_ID, format(p.Code, ''d8'') +''-''+format(h.id, ''d4''), getdate() from [@server].[@database].dbo.WS_PCDL_LogHeader h
join project p on p.MatchId=h.pri_ID';

set @sql = replace(@sql, '@companyId', @companyId);
set @sql = replace(@sql, '@server', @server);
set @sql = replace(@sql, '@database', @database);

print @sql
exec (@sql)

select * from LemLogHeader

------------------------------------------------------------------------ LabourTimeEntry
set @sql = 'delete LabourTimeEntry where companyId = @companyId;
insert LabourTimeEntry(MatchId, CompanyId, LogHeaderId, EmpNum, Level1Id, Level2Id, Billable, WorkClassId, Comments, TotalHours, BillAmount, TimeStamp) 
select t.id, @companyId, h.id, t.emp_no, lv1_id, lv2_id, 1, t.Work_Class_ID, Comments, hrs_total, dollars_total, getdate() 
from [@server].[@database].dbo.WS_EMP_TimeClock t join [@server].[@database].dbo.[WS_PCDL_LogEntry] l on t.WS_PCDL_LH_ID=l.DL_LogEntry_ID 
join LemLogHeader h on h.MatchID=WS_PCDL_logHeaderID and h.CompanyId=@companyId';

set @sql = replace(@sql, '@companyId', @companyId);
set @sql = replace(@sql, '@server', @server);
set @sql = replace(@sql, '@database', @database);

print @sql
exec (@sql)

select * from LabourTimeEntry

----------------------------------------------------------------------- LabourTimeDetail
set @sql = 'delete LabourTimeDetail where companyId = @companyId;
insert LabourTimeDetail(MatchId, CompanyId, EntryId, TimeCodeId, WorkHours, TimeStamp) 
select c.Id, @companyId, e.Id, time_code_id, HoursWorked, getdate()  from [@server].[@database].dbo.WS_EMP_TimeClockHours c
join LabourTimeEntry e on e.MatchId=c.WS_ETC_ID and e.CompanyId=@companyId';

set @sql = replace(@sql, '@companyId', @companyId);
set @sql = replace(@sql, '@server', @server);
set @sql = replace(@sql, '@database', @database);

print @sql
exec (@sql)

select * from LabourTimeDetail

----------------------------------------------------------------------- LabourTemplate
set @sql = 'delete LabourTemplate where companyId = @companyId;
insert LabourTemplate(MatchId, CompanyId, EmpNum, ProjectWorkClassId, StartDate, EndDate) 
select cwce_id, @companyId, emp_no, cwc_id, start_date, end_date from [@server].[@database].dbo.costing_work_class_emp';

set @sql = replace(@sql, '@companyId', @companyId);
set @sql = replace(@sql, '@server', @server);
set @sql = replace(@sql, '@database', @database);

print @sql
exec (@sql)

select * from LabourTemplate

----------------------------------------------------------------------- EquipmentTemplate
set @sql = 'delete EquipmentTemplate where companyId = @companyId;
insert EquipmentTemplate(MatchId, CompanyId, EquipId, ProjectEquipClassId, StartDate, EndDate) 
select cece_id, @companyId, eqi_id, cer_id, start_date, end_date from [@server].[@database].dbo.costing_equipment_class_equip';

set @sql = replace(@sql, '@companyId', @companyId);
set @sql = replace(@sql, '@server', @server);
set @sql = replace(@sql, '@database', @database);

print @sql
exec (@sql)

select * from EquipmentTemplate


