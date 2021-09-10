create database companyDB;
-- creating tables

create table companies(
	id int primary key identity,
	name text not null,
);

create table companySucursal(
	company int not null,
	phone varchar(12) not null,
	address text not null,
	city varchar(4) not null,
	zip varchar(6) not null,
	id int primary key identity,
	name text not null,
	status varchar(4) not null
);

create table customers(
	name text not null, 
	id int primary key identity,
	status varchar(4) not null,
	dateIn datetime not null,
	email text not null
);

create table customerAdresses(
	address text not null,
	customer int not null,
	city varchar(4) not null,
	zip varchar(6) not null,
	status varchar(4) not null,
	id int primary key identity,
	dateIn datetime not null
);


create table customerPhones(
	id int primary key identity,
	phone varchar(12) not null,
	customer int not null,
	dateIn datetime not null,
	status varchar(4) not null
);


create table userCompany(
	company int not null,
	id int primary key identity,
	userCode varchar(10) not null,
	password varchar(20) not null,
	status varchar(4) not null,
	companyRol varchar(2) not null
)

create table companyRoles(
	id varchar(2) primary key,
	name varchar(20) not null
);

create table status(
	id varchar(4) primary key,
	name varchar(20) not null,
	domain varchar(4) not null
);

create table domains(
	id varchar(4) primary key,
	name varchar(20) not null
);

create table countries(
	id varchar(4) primary key,
	name text not null
);

create table cities(
	id varchar(4) primary key, 
	name text not null,
	country varchar(4) not null
);

create table customerCompanies(
	id int primary key identity,
	customer int not null,
	company int not null,
	dateIn datetime not null
);
-- constraints 



alter table companySucursal
add constraint companysucursal_companyFK 
foreign key(company) references companies(id);
	
alter table companySucursal
add constraint companysucursal_cityFK 
foreign key(city) references cities(id);
	
alter table companySucursal
add constraint companysucursal_statusFK 
foreign key(status) references status(id);


alter table customers
add constraint customer_statusFK
foreign key(status) references status(id)

alter table customerAdresses
add constraint customerAdresses_customerFK
foreign key (customer) references customers(id);

alter table customerAdresses
add constraint customerAdresses_cityFK
foreign key (city) references cities(id);

alter table customerPhones
add constraint customerPhones_customerFK
foreign key(customer) references customers(id);

alter table customerPhones
add constraint customerPhones_statusFK
foreign key (status) references status(id)

alter table userCompany
add constraint userCompany_companyFK
foreign key (company) references companies(id)

alter table userCompany
add constraint userCompany_statusFK	
foreign key (status) references status(id)

alter table userCompany
add constraint userCompany_companyRolFK	
foreign key (companyRol) references companyroles(id);

alter table status
add constraint status_domainFK	
foreign key (domain) references domains(id);

alter table cities
add constraint cities_countryFK	
foreign key (country) references countries(id);

alter table customerCompanies
add constraint customerCompanies_customerFK	
foreign key (customer) references customers(id);
	
alter table customerCompanies
add constraint customerCompanies_companyFK	
foreign key (company) references companies(id);

-- insertion

insert into countries(id, name)values('RD','REPUBLICA DOMINICANA');
insert into cities(id, name, country)values('SD','SANTO DOMINGO','RD');
insert into cities(id, name, country)values('SFM','SAN FRANCISCO DE MACORIS','RD');
insert into cities(id, name, country)values('STG','SANTIAGO','RD');
insert into cities(id, name, country)values('SJ','SAN SAN JUAN','RD');

insert into domains(id, name) values ('CUST', 'CUSTOMER');
insert into domains(id, name) values ('COMP', 'COMPANY');
insert into domains(id, name) values ('ALL', 'ALL');

insert companyRoles(id, name) values ('AD','ADMIN');
insert companyRoles(id, name) values ('SU','SUPERVISOR');
insert companyRoles(id, name) values ('TE','TECNICAL');
insert companyRoles(id, name) values ('OP','OPERATOR');

insert into status(id, name, domain) values ('DEL', 'ELIMINADO', 'ALL')
insert into status(id, name, domain) values ('INAC', 'INACTIVO', 'ALL')
insert into status(id, name, domain) values ('ACT', 'ACTIVO', 'ALL')
insert into status(id, name, domain) values ('CLS', 'CERRADO', 'COMP')
insert into status(id, name, domain) values ('OPN', 'ABIERTO', 'COMP')

insert userCompany (company, userCode,password, status, companyRol) values (1, 'MV001122', '123456', 'ACT', 'AD')

insert into customers(name, status, dateIn, email) values ('michael rafael ventura bautista',  'ACT', GETDATE(), 'michaelrafaelventura01@gmail.com');


insert into customerAdresses(address, customer, city, zip, status, dateIn) values ('C/ CENOFONTE #4, LOS MANATIES', 1, 'SD', '11105', 'ACT', GETDATE());

insert into customerPhones(phone, customer, status, dateIn) values ('8096549874', 1, 'ACT',GETDATE());

insert customerCompanies (customer, company, dateIn) values (1,1, GETDATE())

-- procedures
execute createCompany @name = 'BANCA DON JUAN', @phone = '8405677560', @address = 'c/ la frana #4, los paneles', @city = 'SD', @zip = '11045', @branchName = 'la principal'
select * from companies

alter procedure createCompany @name text, @phone varchar(12), @address text, @city varchar(4), @zip varchar(6), @branchName text 
as
begin
	insert into companies(name) 
	values (@name);
	DECLARE @company int;
	SET @company = (select id from companies where name like @name);
	insert into companySucursal(company, phone, address, city, zip, name, status) 
	values (@company, @phone, @address, @city, @zip, @branchName, 'OPN');
end

create procedure modifyCompany @company int, @name text, @phone varchar(12), @address text, @city varchar(4), @zip varchar(6), @branchName text
as
begin
	update companies set name = @name
	where id = @company
	update companySucursal 
	set  phone = @phone, address = @address, city = @city, zip = @zip, name = @branchName
	where company = @company
end

execute modifyCompany @company = 2, @name = 'PLASTICOS DON PEPE', @phone ='8405677120', @address = 'C/ PRENA #4, LOS MINA', @city = 'SD', @zip = '11104', @branchName = 'LA PRIMERA'
select * from companies
select * from companySucursal

create procedure activateCompany @company int, @status varchar(4)
as 
begin
	update companySucursal set status = @status
	where company = @company
end

execute activateCompany @company = 2, @status = 'OPN'



create procedure createCustomer @name text, @email text, @address text, @city varchar(4), @zip varchar(6), @phone varchar(12), @company int as 
begin
	insert into customers(name, status, dateIn, email) values (@name,  'ACT', GETDATE(), @email);
	declare @customer int = (select id from customers where name like @name and email like @email);
	insert into customerAdresses(address, customer, city, zip, status, dateIn) values (@address, @customer, @city, @zip, 'ACT', GETDATE());
	insert into customerPhones(phone, customer, status, dateIn) values (@phone, @customer, 'ACT',GETDATE());
	insert customerCompanies (customer, company, dateIn) values (1,1, GETDATE())
end

create procedure AddCustomerAddress @company int, @address text, @city varchar(4), @zip varchar(6), @customer int as
begin
	insert into customerAdresses(address, customer, city, zip, status, dateIn) values (@address, @customer, @city, @zip, 'ACT', GETDATE());
end

create procedure AddCustomerPhone @company int, @customer int,  @phone varchar(12) as
begin
	insert into customerPhones(phone, customer, status, dateIn) values (@phone, @customer, 'ACT',GETDATE());
end

create procedure ModifyCustomerAddress @id int, @address text, @zip varchar(6), @city varchar(4) as 
begin
	update customerAdresses set address = @address, zip = @zip, city = @city where codigo = @id
end


create procedure ModifyCustomerPhone @id int, @phone varchar(12) as
begin
	update customerPhones set phone = @phone where id = @id
end

create procedure modifyCustomer @id int, @name text, @email text as 
begin
	update customers set name = @name,  email = @email
	WHERE id = @id
end

create procedure deleteCustomer  @id int as 
begin
	update customers set status = 'DEL' where id = @id;
	update customerAdresses set status = 'DEL' where customer = @id;
	update customerPhones set status = 'DEL' where customer = @id;
end

create procedure activateCustomer @id int , @status varchar(4) as 
begin
	update customers set status = @status where id = @id;
end

create procedure activateCustomerPhone @id int , @status varchar(4) as
begin
	update customerPhones set status = @status where id = @id;
end

create procedure activateCustomerAddress @id int , @status varchar(4) as
begin 
	update customerAdresses set status = @status where codigo = @id;
end

create procedure createUserCompany @company int, @userCode varchar(10), @password varchar(20), @status varchar(4), @companyRol varchar(2) as
begin
	insert userCompany(company, userCode, password, status, companyRol)values(@company, @userCode, @password, @status, @companyRol)
end

create procedure modifyUserCompany @id int, @company int, @userCode varchar(10), @password varchar(20), @status varchar(4), @companyRol varchar(2) as
begin
	update userCompany set company = @company, userCode = @userCode, password = @password, status = @status, companyRol = @companyRol
	where id = @id
end

create procedure activateUserCompany @id int, @status varchar(4) as
begin
	update userCompany set status = @status
	where id = @id
end

select * from userCompany

select * from [dbo].[userCompany]
select * from [dbo].[companies] as company

create view VW_companies_branches as
SELECT 
	branch.id as id,
	company.name as name,
	branch.name as branchName,
	branch.phone as phone,
	branch.address as address,
	branch.zip as zip,
	city.name as cityName,
	city.id as cityID,
	country.name as countryName,
	country.id as countryID,
	status.name as statusName,
	status.id as statusID
FROM [dbo].[companySucursal] as branch
inner join companies as company on branch.company = company.id
inner join cities as city on branch.city = city.id
inner join countries as country on city.country = country.id
inner join status on branch.status = status.id

select * from VW_companies_branches
SELECT * FROM [dbo].[companyRoles] as role
select * from companySucursal
select * from [dbo].[status] 
SELECT * FROM [dbo].[cities] as city
SELECT * FROM [dbo].[countries] as country

create view VW_customers as
SELECT 
	customer.id as id,
	customer.name as name,
	customer.email as email,
	status.name as statusName,
	status.id as statusID,
	CONVERT(varchar(12), customer.dateIn, 103) as datein 
FROM [dbo].[customers] as customer
inner join status on customer.status = status.id

create view VW_customer_addresses as
SELECT 
	address.codigo as id,
	address.address as phone,
	address.zip,
	city.name as cityName,
	city.id as cityID,
	country.name as countryName,
	country.id as countryID,
	CONVERT(varchar(12), address.dateIn, 103) as datein,
	status.name as statusName,
	status.id as statusID,
	customer.id as customerID,
	customer.name as name,
	customer.email as email
FROM [dbo].[customerAdresses] as address
inner join status on address.status = status.id
inner join customers as customer on address.customer = customer.id
inner join cities as city on address.city = city.id
inner join countries as country on city.country = country.id

create view VW_Customers_Phones as
SELECT 
	phone.id as id,
	phone.phone as phone,
	CONVERT(varchar(12), phone.dateIn, 103) as datein,
	status.name as statusName,
	status.id as statusID,
	customer.id as customerID,
	customer.name as name,
	customer.email as email
FROM [dbo].[customerPhones] as phone
inner join status on phone.status = status.id
inner join customers as customer on phone.customer = customer.id

create view VW_Customer_Companies as
SELECT 
	relation.dateIn as dateIn,
	relation.id as id,
	customer.name as customerName,
	customer.email as customerEmail,
	customer.id customerID,
	company.name company,
	company.id as companyID
FROM [dbo].[customerCompanies] relation
inner join customers as customer on relation.customer = customer.id
inner join companies as company on relation.company = company.id

create view VW_User_Company as
SELECT 
	company.id as companyID,
	company.name as company,
	usrComp.id as id,
	usrComp.userCode as userCode,
	usrComp.password as password,
	role.name as rol,
	role.id as rolID,
	status.id as statusID,
	status.name	as status
FROM [dbo].[userCompany] as usrComp
inner join companies as company on usrComp.company = company.id
inner join companyRoles as role on usrComp.companyRol = role.id
inner join status on usrComp.status = status.id

select * from VW_customers
select * from VW_companies_branches

select * from VW_customer_addresses
select * from VW_customers_phones
select * from VW_Customer_Companies
select * from VW_User_Company
where userCode like 'MV001122' and password like '123456' and companyID = 1




