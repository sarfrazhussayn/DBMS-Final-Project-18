use TestDB
GO
select top 1 * from [People.Donor]


ALTER TABLE [People.Donor]
  ADD Blood_Group VARCHAR(5);
update [People.Donor] set Blood_Group = 'A+' where [idPeople.Donor] = 5
update [People.Donor] set Blood_Group = 'AB+' where [idPeople.Donor] = 6
update [People.Donor] set Blood_Group = 'A+' where [idPeople.Donor] = 7
update [People.Donor] set Blood_Group = 'O-' where [idPeople.Donor] = 8
update [People.Donor] set Blood_Group = 'AB+' where [idPeople.Donor] = 9
update [People.Donor] set Blood_Group = 'B+' where [idPeople.Donor] = 10
-- Donor record in Data Gridview
select [idPeople.Donor] [ID],First_Name +' '+Last_Name [Name],CASE WHEN Gender = 1 then 'Male' WHEN Gender = 0 then 'Female' END [Gender], Blood_Group [Blood Group], CNIC, DATEDIFF(YEAR,DOB,CAST(GETDATE() as DATE)) [Age] from [People.Donor] 

select * from [People.Staff]
-- Staff Records in Data Gridview
select idStaff [Staff ID],First_Name +' '+ Last_Name [Full Name], [People.Staff_Category_idPeople.Staff_Category] [Employee Category],b.Branch_Name [Branch], Date_of_Joining [Employee Since] from [People.Staff] inner join Branch b on b.idBranch = Branch_idBranch where IsActive = 1

select * from [People.Donor]
insert into [People.Donor] (Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration],CNIC,Gender,Blood_Group) 
values(2,'William','Jones','1979/10/10','2018/01/17','4210154787451',1,'B-')
select * from [People.Donor]
insert into [People.Donor] (Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration],CNIC,Gender,Blood_Group) 
values(2,'Henry','Kent','1991/02/16','2018/01/17','4210787154451',1,'B+')

select * from [People.Address] 
insert into [People.Address] ([People.Donor_idPeople.Donor],Address_Line1,Address_Line2,Address_Line3,Address_Type,City,Zip_PostCode)
values (1011,'House No. B-12, Block 11, Gulshan-e-Iqbal','Near KFC','','Home','Karachi',78541)

select * from [Donor.Phone]
insert into [Donor.Phone] ([People.Donor_idPeople.Donor],Phone_No,Phone_Type)
values (5,'02135478496','Home')
insert into [Donor.Phone] ([People.Donor_idPeople.Donor],Phone_No,Phone_Type)
values (6,'02136950756','Home')
insert into [Donor.Phone] ([People.Donor_idPeople.Donor],Phone_No,Phone_Type)
values (7,'02134598754','Home')
insert into [Donor.Phone] ([People.Donor_idPeople.Donor],Phone_No,Phone_Type)
values (8,'0219954784','Home')
insert into [Donor.Phone] ([People.Donor_idPeople.Donor],Phone_No,Phone_Type)
values (9,'03311234567','Mobile')
insert into [Donor.Phone] ([People.Donor_idPeople.Donor],Phone_No,Phone_Type)
values (10,'0421212458','Home')
insert into [Donor.Phone] ([People.Donor_idPeople.Donor],Phone_No,Phone_Type)
values (1011,'02133349785','Home')
insert into [Donor.Phone] ([People.Donor_idPeople.Donor],Phone_No,Phone_Type)
values (1012,'02138495627','Home')
insert into [Donor.Phone] ([People.Donor_idPeople.Donor],Phone_No,Phone_Type)
values (5,'03001212498','Mobile')



insert into [People.Donor] (Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration],CNIC,Gender,Blood_Group) 
values(2,'Saqib','Alvi','1992/10/09','2018/01/18','4210178945612',1,'O+')
GO
insert into [People.Address] ([People.Donor_idPeople.Donor],Address_Line1,Address_Line2,Address_Line3,Address_Type,City,Zip_PostCode)
values (1013,'House No. D-12, Block 5, Gulshan-e-Iqbal','Near SSUET','','Home','Karachi',78540)
GO
insert into [Donor.Phone] ([People.Donor_idPeople.Donor],Phone_No,Phone_Type)
values (1013,'02134821415','Home')
select donor.[idPeople.Donor],donor.First_Name,ph.Phone_No,ad.Address_Line1+' '+Ad.Address_Line2 [Address] from [People.Donor] donor
inner join [People.Address] ad on ad.[People.Donor_idPeople.Donor] = donor.[idPeople.Donor]
inner join [Donor.Phone] ph on ph.[People.Donor_idPeople.Donor] = donor.[idPeople.Donor]

begin transaction declare @donorId int;insert into [People.Donor] (Branch_idBranch,First_Name,Last_Name,DOB,[Date of Registration],CNIC,Gender,Blood_Group) values (2,'Ifrah','Junaid','1997/08/18','2018/10/19','4220132145612',1,'AB+'); select @donorId = SCOPE_IDENTITY(); insert into [People.Address] ([People.Donor_idPeople.Donor],Address_Line1,Address_Line2,Address_Line3,Address_Type,City,Zip_PostCode) values (@donorId,'House No. A-59, Block 13, Gulistan-e-Jauhar','Near Rabia City','','Home','Karachi',78539); insert into [Donor.Phone] ([People.Donor_idPeople.Donor],Phone_No,Phone_Type) values (@donorId,'034155224789','Mobile');commit
 update [People.Donor] set Gender = 0 where First_Name = 'Ifrah'
 GO

 select * from [People.Donor]