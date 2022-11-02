/*
insert into dbo.Salary(min_salary,min_salary,dept)
values
(30000,60000,'Tester'),
(80000,120000,'HR'),
(60000,80000,'SDE');

select * from dbo.Salary;

create table Emp(
	emp_name varchar(20),
	dept varchar(20),
	salary int
)

insert into dbo.Emp(emp_name,dept,salary)
values
('Abhishek Manna','HR',40000),
('Sayan Mondol','SDE',120000),
('Sandipan Pal','Tester',20000);

*/

create or alter trigger dbo.Wagetrigger
on dbo.Emp
instead of insert
as
begin
declare @sal int
declare @sal_max int
declare @sal_min int
declare @emp_dept varchar(20)
select @emp_dept=dept,@sal= salary from inserted
select @sal_max = max_salary, @sal_min =min_salary from dbo.Wage where dept = @emp_dept
if @sal<@sal_max and @sal>@sal_min
begin
insert into dbo.Emp select * from inserted
end
else
begin
raiserror('Wage limit exceeded',16,1)
return
end
end


insert into dbo.Emp(emp_name,dept,salary)
values
('Ayan Roy','SDE',70000);

select * from Emp;