use TestDB
GO

select * from [Application.Credentials]

select COUNT(*) from [People.Donor] where CNIC = '4210143031979'

Alter Table [Transaction.Donation] add Add_Date Date

select * from [Transaction.Donation]
drop table [Transaction.Donation]


CREATE TABLE [Donation] (
  [idTransaction.Donation] INTEGER  NOT NULL   IDENTITY ,
  [Depository.Main_Depository_idDepository] INTEGER  NOT NULL  ,
  [Deposit.Deposit_Category_idDeposit.Deposit_Cat] Varchar(50)  NOT NULL  ,
  [Deposit.Blood_Type_idBlood_TYPE] INTEGER  NOT NULL  ,
  [People.Donor_idPeople.Donor] INTEGER  NOT NULL  ,
  [People.Staff_idStaff] INTEGER  NOT NULL  ,
  IsApproved BIT  NOT NULL  ,
  Expiry DATE  NOT NULL  ,
  Donation_Date DATE  NOT NULL    ,
PRIMARY KEY([idTransaction.Donation])          ,
  FOREIGN KEY([People.Donor_idPeople.Donor])
    REFERENCES [People.Donor]([idPeople.Donor]),
  FOREIGN KEY([People.Staff_idStaff])
    REFERENCES [People.Staff](idStaff),
  FOREIGN KEY([Deposit.Deposit_Category_idDeposit.Deposit_Cat])
    REFERENCES [Deposit.Deposit_Category]([idDeposit.Deposit_Cat]),
  FOREIGN KEY([Depository.Main_Depository_idDepository])
    REFERENCES [Depository.Main_Depository](idDepository));
GO


CREATE INDEX [Donation_FKIndex1] ON [Donation] ([People.Donor_idPeople.Donor]);
GO
CREATE INDEX [Donation_FKIndex2] ON [Donation] ([People.Staff_idStaff]);
GO
CREATE INDEX [Donation_FKIndex3] ON [Donation] ([Deposit.Blood_Type_idBlood_TYPE]);
GO
CREATE INDEX [Donation_FKIndex4] ON [Donation] ([Deposit.Deposit_Category_idDeposit.Deposit_Cat]);
GO
CREATE INDEX [Donation_FKIndex5] ON [Donation] ([Depository.Main_Depository_idDepository]);
GO


CREATE INDEX IFK_Rel_05 ON [Donation] ([People.Donor_idPeople.Donor]);
GO
CREATE INDEX IFK_Rel_09 ON [Donation] ([People.Staff_idStaff]);
GO
CREATE INDEX IFK_Rel_21 ON [Donation] ([Deposit.Blood_Type_idBlood_TYPE]);
GO
CREATE INDEX IFK_Rel_22 ON [Donation] ([Deposit.Deposit_Category_idDeposit.Deposit_Cat]);
GO
CREATE INDEX IFK_Rel_23 ON [Donation] ([Depository.Main_Depository_idDepository]);
GO

SET IDENTITY_INSERT dbo.Donation ON;  
GO  
begin transaction
SET IDENTITY_INSERT dbo.[Donation] ON; 
insert into Donation ([idTransaction.Donation],
					  [Depository.Main_Depository_idDepository],
					  [Deposit.Deposit_Category_idDeposit.Deposit_Cat],
					  [Deposit.Blood_Type_idBlood_TYPE],
					  [People.Donor_idPeople.Donor],
					  [People.Staff_idStaff],
					  IsApproved,Expiry,Donation_Date) 
			 values (100,
					 1,
					 'Blood',
					 'A+',
					 1011,
					 3,
					 1,
					 '20181212',
					 '20181118');
SET IDENTITY_INSERT dbo.[Donation] OFF; 
commit

select * from [Deposit.Deposit_Category]

alter table Donation alter column [Deposit.Blood_Type_idBlood_TYPE] varchar(50)


/*ALTER TABLE [dbo.Donation] DROP CONSTRAINT [IFK_Rel_21];
-- Perform more appropriate alters
ALTER TABLE [dbo.Donation] alter column [Deposit.Blood_Type_idBlood_TYPE] varchar(50) ADD FOREIGN KEY (FK_Details_tbl_User_tbl) 
    REFERENCES User_tbl(appId);
-- Perform all appropriate alters to bring the key constraints back*/









insert into [Deposit.Blood_Type] (idBlood_TYPE) values ('A+')
insert into [Deposit.Blood_Type] (idBlood_TYPE) values ('B+')
insert into [Deposit.Blood_Type] (idBlood_TYPE) values ('AB+')
insert into [Deposit.Blood_Type] (idBlood_TYPE) values ('O+')
insert into [Deposit.Blood_Type] (idBlood_TYPE) values ('A-')
insert into [Deposit.Blood_Type] (idBlood_TYPE) values ('B-')
insert into [Deposit.Blood_Type] (idBlood_TYPE) values ('AB-')
insert into [Deposit.Blood_Type] (idBlood_TYPE) values ('O-')

delete from [Deposit.Blood_Type] where idBlood_TYPE like '%]'




--Updates on Tester DB 3rd November '18

select * from [Transaction.Donation]

alter table [Donation] add IsDonated bit

alter table [Donation] add IsExpired bit

select * from dbo.Donation



ALTER TABLE dbo.Donation   
DROP CONSTRAINT Donation_FKIndex3;   
GO  


select * from [Depository.Main_Depository]

select * from [People.Staff]

/*
CREATE TABLE [dbo].[Donation_final](
	[idTransaction.Donation] [int] IDENTITY(1,1) NOT NULL,
	[Depository.Main_Depository_idDepository] [int] NOT NULL,
	[Deposit.Deposit_Category_idDeposit.Deposit_Cat] [varchar](20) NOT NULL,
	[Deposit.Blood_Type_idBlood_TYPE] [varchar](5) NOT NULL,
	[People.Donor_idPeople.Donor] [int] NOT NULL,
	[People.Staff_idStaff] [int] NOT NULL,
	[IsApproved] [bit] NOT NULL,
	[Expiry] [date] NOT NULL,
	[Donation_Date] [date] NOT NULL,
	[IsDonated] [bit] NULL,
	[IsExpired] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[idTransaction.Donation] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Donation]  WITH CHECK ADD FOREIGN KEY([Deposit.Deposit_Category_idDeposit.Deposit_Cat])
REFERENCES [dbo].[Deposit.Deposit_Category] ([idDeposit.Deposit_Cat])
GO

ALTER TABLE [dbo].[Donation]  WITH CHECK ADD FOREIGN KEY([Depository.Main_Depository_idDepository])
REFERENCES [dbo].[Depository.Main_Depository] ([idDepository])
GO

ALTER TABLE [dbo].[Donation]  WITH CHECK ADD FOREIGN KEY([People.Donor_idPeople.Donor])
REFERENCES [dbo].[People.Donor] ([idPeople.Donor])
GO

ALTER TABLE [dbo].[Donation]  WITH CHECK ADD FOREIGN KEY([People.Staff_idStaff])
REFERENCES [dbo].[People.Staff] ([idStaff])
GO
*/




set Identity_Insert Donation_final on


insert into Donation_final([Depository.Main_Depository_idDepository],[Deposit.Deposit_Category_idDeposit.Deposit_Cat],[Deposit.Blood_Type_idBlood_TYPE],[People.Donor_idPeople.Donor],[People.Staff_idStaff],IsApproved,Expiry,Donation_Date,IsDonated,IsExpired) Values(1,'Blood','O+',1013,3,1,'20181202',GETDATE(),0,0)


SET identity_insert Donation_final off;

select * from [People.Donor]

select * from Donation_final


select d.[idTransaction.Donation][Donation_ID],dd.First_Name +' '+ dd.Last_Name [Name of Donor],d.Donation_Date,d.[Deposit.Blood_Type_idBlood_TYPE][Type],d.[Deposit.Deposit_Category_idDeposit.Deposit_Cat] [Donation Category],CASE WHEN d.IsApproved = 0 then 'No' when d.IsApproved = 1 then 'Yes'  end [Approved],CASE WHEN d.IsExpired = 0 then 'No' when d.IsExpired = 1 then 'Yes'  end[Expired], d.Expiry[ValidTill] from Donation_final d inner join [People.Donor] dd on dd.[idPeople.Donor] = d.[People.Donor_idPeople.Donor]


select * from [People.Donor]

update Donation_final set [People.Donor_idPeople.Donor] = 1011
/*
alter table Donation_final alter column [Deposit.Deposit_Category_idDeposit.Deposit_Cat] Varchar(10) null

alter table Donation_final alter column [Deposit.Blood_Type_idBlood_TYPE] Varchar(5) null

alter table Donation_final alter column [People.Donor_idPeople.Donor] int null
*/

begin transaction
insert into 
Donation_final([Depository.Main_Depository_idDepository],[Deposit.Deposit_Category_idDeposit.Deposit_Cat],
[Deposit.Blood_Type_idBlood_TYPE],[People.Donor_idPeople.Donor],
[People.Staff_idStaff],IsApproved,Expiry,
Donation_Date,IsDonated,IsExpired) 
Values(1,'Blood','O+',1013,3,1,'20181202',GETDATE(),0,0)
commit

select [Deposit.Blood_Type_idBlood_TYPE],COUNT(*) from Donation_final where [Deposit.Blood_Type_idBlood_TYPE] = 'O+' group by [Deposit.Blood_Type_idBlood_TYPE]

select b.idBranch,b.Branch_Name from [Application.Credentials] c
inner join [People.Staff] s on c.[People.Staff_idStaff] = s.idStaff
inner join [Branch] b on b.idBranch = s.Branch_idBranch
where c.[User_name] = 'sarf'

begin transaction
insert into 
Donation_final([Depository.Main_Depository_idDepository],[Deposit.Deposit_Category_idDeposit.Deposit_Cat],
[Deposit.Blood_Type_idBlood_TYPE],[People.Donor_idPeople.Donor],
[People.Staff_idStaff],IsApproved,Expiry,
Donation_Date,IsDonated,IsExpired) 
Values(1,'Blood','A+',1015,3,1,GETDATE()+20,GETDATE(),0,0)
commit

alter table Donation_final drop column IsScreened 

select * from Donation_final
where IsDonated = 0

update Donation_final set IsDonated = 1 where [idTransaction.Donation] >= 13 

select * from Donation_final where IsDonated=0 and Expiry>GETDATE()


select * from Donation_final 
where [Deposit.Blood_Type_idBlood_TYPE] = 'O+' and IsDonated = 0 and Expiry > GETDATE() 
order by Donation_Date

USE [TestDB]
GO

/****** Object:  Table [dbo].[Request]    Script Date: 19-Dec-18 1:55:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Request](
	[idTransaction.Request] [int] IDENTITY(1,1) NOT NULL,
	[Deposit.Deposit_Category_idDeposit.Deposit_Cat] [varchar](10) NULL,
	[Deposit.Blood_Type_idBlood_TYPE] [varchar](5) NULL,
	[People.Donor_idPeople.Donor] [int] NULL,
	[IsCompleted] [bit] NOT NULL,
	[Request_Date] [date] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idTransaction.Request] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD FOREIGN KEY([People.Donor_idPeople.Donor])
REFERENCES [dbo].[People.Donor] ([idPeople.Donor])
GO
ALTER TABLE [dbo].[Request]  WITH CHECK ADD FOREIGN KEY([Deposit.Blood_Type_idBlood_TYPE])
REFERENCES [dbo].[Deposit.Blood_Type] (idBlood_TYPE)
GO
ALTER TABLE [dbo].[Request]  ADD FOREIGN KEY([Deposit.Deposit_Category_idDeposit.Deposit_Cat])
REFERENCES [dbo].[Deposit.Deposit_Category] ([idDeposit.Deposit_Cat])
GO

alter table request add Quantity int

select * from Request
insert into Request ([idTransaction.Request],[Deposit.Deposit_Category_idDeposit.Deposit_Cat],[Deposit.Blood_Type_idBlood_TYPE],[People.Donor_idPeople.Donor],IsCompleted,Request_Date,Quantity)
values (1,'Blood','O+',1011,0,GETDATE(),1)

ALTER PROC chk_quantity @type Varchar(10) 
AS
begin transaction
SELECT COUNT(*) from Donation_final where [Deposit.Blood_Type_idBlood_TYPE] = @type and IsDonated = 0 and Expiry>GetDate()
commit;


CREATE PROCEDURE fulfill @request int, @btype varchar(5), @quantity int
AS
BEGIN
  BEGIN Transaction

    ;with tg as (
    select TOP (@quantity) * from Donation_final
    where IsDonated = 0 and Expiry>GetDate() and [Deposit.Blood_Type_idBlood_TYPE] = @btype
    order by Donation_Date
    )
    update tg set IsDonated = 1
    update Request set IsCompleted = 1 where [idTransaction.Request] = @request
  COMMIT
END


select * from Request
exec fulfill 1,'O+',1

select * from Donation_final where [Deposit.Blood_Type_idBlood_TYPE] = 'O+' and Expiry > GETDATE()

select COUNT(*) from [Donation_final] where [Deposit.Blood_Type_idBlood_TYPE] = 'O+' and Expiry>GETDATE() and IsDonated = 0


select CAST(r.[idTransaction.Request]as varchar)+'-'+cast(r.[People.Donor_idPeople.Donor] as varchar)[Request ID],dd.First_Name+' '+dd.Last_Name[Requested By],r.[Deposit.Blood_Type_idBlood_TYPE][Blood Group],r.[Deposit.Deposit_Category_idDeposit.Deposit_Cat][Request Type],r.Quantity,r.Request_Date[Requested On],r.IsCompleted[Completed] from Request r inner join [People.Donor] dd on dd.[idPeople.Donor] = r.[People.Donor_idPeople.Donor]

select * from Request where IsCompleted =0

create proc search_donation @btype varchar(5)
AS
BEGIN
select CAST(dd.[idPeople.Donor] as varchar)+'-'+CAST(d.[idTransaction.Donation] as varchar)[Donation_ID],dd.First_Name +' '+ dd.Last_Name[Name of Donor],d.Donation_Date,d.[Deposit.Blood_Type_idBlood_TYPE][Type],d.[Deposit.Deposit_Category_idDeposit.Deposit_Cat] [Donation Category],CASE WHEN d.IsApproved = 0 then 'No' when d.IsApproved = 1 then 'Yes'  end [Approved],CASE WHEN GetDate()<Expiry then 'No' when GetDate()>Expiry then 'Yes'  end[Expired], d.Expiry[ValidTill] from Donation_final d inner join [People.Donor] dd on dd.[idPeople.Donor] = d.[People.Donor_idPeople.Donor]  where IsDonated=0 and Expiry>GETDATE() and [Deposit.Blood_Type_idBlood_TYPE] = @btype
END

exec search_donation 'O-'
select * from [People.Donor]

create proc search_donor @fname varchar(20)
as
begin
select [idPeople.Donor] [ID], First_Name+' '+Last_Name [Name],Blood_Group
from [People.Donor] where First_Name LIKE '%' + @fname + '%'
end
SET identity_insert [People.Donor] ON
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1020,2,'Saqib','Rehman','1995-03-1','2018-11-7',4321254345671,1,'B-')

insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1021,2,'Alina','Farooq','1996-03-10','2018-11-17',4334153845671,0,'AB-')


insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1022,2,'Umama','Ansari','1995-07-20','2018-12-2',434548781151,0,'AB-')

insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1023,2,'Altaf','Salman','1982-07-16','2018-12-2',45678941234,1,'A+')

insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1024,2,'Saeed','Khan','1991-01-5','2018-12-2',43224679841,1,'AB+')

insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1025,2,'Shabbir','Jaan','1980-07-16','2018-12-2',41245657871,1,'A-')

insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1026,2,'Rashida','Hussain','1994-04-16','2018-12-2',4321254447758,0,'O+')

insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1027,2,'Sadaf','Khan','1979-01-19','2018-12-2',41785412364,0,'AB+')

insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1028,2,'Arisha','Aijaz','1995-07-9','2018-12-1',432445889945,0,'AB+')

insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1029,2,'Wajiha','Ghazanfar','1999-04-5','2018-12-1',48471596311,0,'AB-')

insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1030,2,'Zulfiqar','Babar','1983-10-7','2018-12-1',44578965122,1,'AB+')

insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1031,2,'Maryam','Khan','1991-01-01','2018-12-1',432144784670,0,'AB+')

insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1032,2,'Shahrukh','Nazeer','1987-10-11','2018-12-1',4786941671,1,'A-')

insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1033,2,'Asif','Rehman','1988-05-30','2018-12-1',486141654651,1,'A+')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1034,2,'Kawish','Jawed','1990-01-19','2018-12-1',467914853197,1,'O+')

insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1035,2,'Abir','Khan','1991-12-01','2018-12-1',412457951423,1,'A+')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1036,2,'Muneeb','Salman','1989-07-03','2018-12-1',437789542123,1,'A+')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1037,2,'Habban','Raza','1988-06-24','2018-12-1',410215479641,1,'A-')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1038,2,'Shiraz','Aqib','1997-04-2','2018-12-1',432114852471,1,'A-')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1039,2,'Sanaina','Yasir','1999-03-1','2018-12-1',461517896451,0,'A-')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1040,2,'Kamal','Hasan','1991-08-11','2018-12-1',4324589566874,0,'B+')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1041,2,'Aeliya','Chaudhary','1988-04-16','2018-11-30',4345124345141,0,'B-')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1041,2,'Khan','Shabbir','1989-11-15','2018-11-30',431649782500,1,'B-')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1042,2,'Minal','Sadiq','1987-11-12','2018-11-30',4972548623014,0,'AB+')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1043,2,'Rehan','Shujaat','1979-01-3','2018-11-30',4947812324589,1,'AB+')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1044,2,'Danish','Nawaz','1981-07-22','2018-11-30',4567845128965,1,'AB-')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1045,2,'Mahrukh','Khaliq','1990-07-2','2018-11-30',7845895678452,0,'AB-')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1046,2,'Abdul','Baari','1996-01-01','2018-11-30',4978561278561,1,'O+')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1047,2,'Mudassir Ali','Tariq','1997-11-11','2018-11-30',3345614801811,1,'O+')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1048,2,'Zulfiqar','Nawaz','1988-03-1','2018-11-30',123190911246,1,'O-')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1049,2,'Zeba','Rehman','1996-10-12','2018-11-30',4152637485962,0,'O-')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1050,2,'Asad','Usman','1980-11-11','2018-10-17',4859623074964,1,'A+')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1051,2,'Osman','Ghazi','1993-05-19','2018-10-17',7845128956237,1,'A+')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1052,2,'Usama','Qazi','1979-11-14','2018-10-17',4179963741850,1,'A+')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1053,2,'Yasir','Aleem','1997-01-13','2018-7-11',4157963102478,1,'A-')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1054,2,'Saqlain','Hayder','1991-11-13','2018-11-7',4268741259631,1,'B+')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1055,2,'Feroz','Khan','1980-02-2','2018-10-27',4679895612321,1,'B+')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1056,2,'Shahid','Khan','1999-04-11','2018-11-17',4152637485961,1,'B+')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1056,2,'Mubashir','Rehman','1996-03-19','2018-11-7',4578986532127,1,'AB+')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1057,2,'Shehla','Zubair','1987-06-10','2018-11-7',41741489647149,0,'AB+')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1058,2,'Fariya','Sikandar','1985-07-14','2018-06-15',457896587411,0,'AB-')
 
insert into [People.Donor] ([idPeople.Donor],Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration], CNIC, Gender,Blood_Group)
Values (1059,2,'Rehana','Altaf','1991-05-17','2018-06-15',4789654112564,0,'AB-')
 



