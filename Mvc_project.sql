Create database MVC_Project
go
use MVC_Project
go
create table student2
( 
id int primary key,
name varchar(100),
class varchar(100),
fee money
);
insert into student2 values(1,'Karim','six',1000),(2,'Rahim','six',1000),
(3,'Rahman','seven',2000)

select * from student2

Alter table student2 add picturepath nvarchar(500)

Create table sales
(
Bookid int primary key identity(1,1),
Name varchar(100), 
Quantity int,
SaleDate datetime
)