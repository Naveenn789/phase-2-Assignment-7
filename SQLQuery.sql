create database LibraryDb

use LibraryDb

create table Books
(BookId int primary key,
Tittle nvarchar(50) ,
Author nvarchar(50),
Genre nvarchar(50),
Quqntity int)

insert into Books values (1,'Venom','Hardy','Horror',8)
insert into Books values (2,'ToMoon','Oklawa','Sci-fi',3)
insert into Books values (3,'Batman','BruceWanye','Action',2)
insert into Books values (4,'Avatar','J.Cameron','Action',5)
insert into Books values (5,'Dracula','Cresta','Horror',1)

select * from Books

