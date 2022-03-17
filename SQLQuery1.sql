Create database MVC_Project
use MVC_Project

create table student2
( 
id int primary key,
name varchar(100),
class varchar(100),
fee money,
picturepath nvarchar(500)
);

insert into student2 values
(3,'Masud','Seven',3000,''),(4,'Asad','Ten',1000,''),(5,'Motiur','Six',2000,'')


Create table sales(Bookid int primary key identity(1,1), Name varchar(100), Quantity int, SaleDate datetime)

select * from student2
select * from sales

Create table [user](
Id int not null primary key identity,
username varchar(100) not null,
password varchar(100) not null

)

select * from aspnetusers


select * from [user]
go

insert into [user] values('Md.Parvez','Parvez123'),('Juhin','Juhin123')



Create table Students
(
studentid int primary key,
studentname varchar(100),
class varchar(100),
gender nvarchar(50),
[date] date,
image_path nvarchar(500)
)

Create table Department
(
departmentid int primary key,
departmentname varchar(100)
)

Create table Teachers
(
teacherid int primary key,
teachername varchar(100),
departmentid int references Department(departmentid)
)

Create table Course
(
courseid int primary key,
coursename varchar(100),
studentid int references Students(studentid),
teacherid int references Teachers(teacherid)
)


select * from Students
select * from Course
select * from Teachers
select * from Department


Drop table if exists Product
Create table Product
(
product_id varchar(100) primary key,
product_name varchar(100),
purchase_price int,
)

Drop table if exists Sales
Create table Sales
(
sale_id varchar(100) primary key,
product_id varchar(100) references Product(product_id),
Qty int,
sales_price int,
Total_price money

)

select * from Product
select * from Sales

Drop table if exists Employee
Create table Employee
(
 id int primary key identity,
 name varchar(100),
 designation varchar(100),
 image_path varchar(Max)
)

select * from Employee