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

alter table Donation_final alter column [Deposit.Deposit_Category_idDeposit.Deposit_Cat] Varchar(10) null

alter table Donation_final alter column [Deposit.Blood_Type_idBlood_TYPE] Varchar(5) null
