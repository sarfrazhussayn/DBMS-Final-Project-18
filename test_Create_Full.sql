
CREATE TABLE [Donor.Diseases] (
  [idDonor.Diseases] VARCHAR(50)  NOT NULL   ,
  disease_disc VARCHAR(255)  NOT NULL    ,
PRIMARY KEY([idDonor.Diseases]));
GO




CREATE TABLE [Deposit.Deposit_Category] (
  [idDeposit.Deposit_Cat] VARCHAR(50)  NOT NULL   ,
PRIMARY KEY([idDeposit.Deposit_Cat]));
GO




CREATE TABLE [People.Staff_Category] (
  [idPeople.Staff_Category] VARCHAR(50)  NOT NULL   ,
  Description VARCHAR(255)      ,
PRIMARY KEY([idPeople.Staff_Category]));
GO




CREATE TABLE [Donor.Medicines] (
  [idDonor.Medicines] VARCHAR(50)  NOT NULL   ,
  Manufacturer VARCHAR(50)      ,
PRIMARY KEY([idDonor.Medicines]));
GO




CREATE TABLE Address (
  idAddress INTEGER  NOT NULL   IDENTITY ,
  Address_Line_1 VARCHAR(50)    ,
  Address_Line_2 VARCHAR(50)    ,
  Address_Line_3 VARCHAR(50)    ,
  City VARCHAR(50)    ,
  Zip_PostCode VARCHAR(50)      ,
PRIMARY KEY(idAddress));
GO




CREATE TABLE [Deposit.Blood_Type] (
  idBlood_TYPE VARCHAR(50)  NOT NULL   ,
PRIMARY KEY(idBlood_TYPE));
GO




CREATE TABLE Branch (
  idBranch INTEGER  NOT NULL   IDENTITY ,
  Address_idAddress INTEGER  NOT NULL  ,
  Branch_Name VARCHAR(50)  NOT NULL  ,
  Branch_Details VARCHAR(50)  NOT NULL    ,
PRIMARY KEY(idBranch)  ,
  FOREIGN KEY(Address_idAddress)
    REFERENCES Address(idAddress));
GO


CREATE INDEX Branch_FKIndex1 ON Branch (Address_idAddress);
GO


CREATE INDEX IFK_Rel_19 ON Branch (Address_idAddress);
GO


CREATE TABLE [Depository.Main_Depository] (
  idDepository INTEGER  NOT NULL   IDENTITY ,
  Branch_idBranch INTEGER      ,
PRIMARY KEY(idDepository)  ,
  FOREIGN KEY(Branch_idBranch)
    REFERENCES Branch(idBranch));
GO


CREATE INDEX [Depository.Main_Depository_FKIndex1] ON [Depository.Main_Depository] (Branch_idBranch);
GO


CREATE INDEX IFK_Rel_21 ON [Depository.Main_Depository] (Branch_idBranch);
GO


CREATE TABLE [People.Staff] (
  idStaff INTEGER  NOT NULL   IDENTITY ,
  [People.Staff_Category_idPeople.Staff_Category] VARCHAR(50)  NOT NULL  ,
  Branch_idBranch INTEGER  NOT NULL  ,
  First_Name VARCHAR(50)  NOT NULL  ,
  Last_Name VARCHAR(50)  NOT NULL  ,
  DOB DATE  NOT NULL  ,
  Date_of_Joining DATE  NOT NULL  ,
  IsActive BIT  NOT NULL  ,
  Salary INTEGER  NOT NULL  ,
  Remarks VARCHAR(255)      ,
PRIMARY KEY(idStaff)  ,
  FOREIGN KEY(Branch_idBranch)
    REFERENCES Branch(idBranch),
  FOREIGN KEY([People.Staff_Category_idPeople.Staff_Category])
    REFERENCES [People.Staff_Category]([idPeople.Staff_Category]));
GO


CREATE INDEX [People.Staff_FKIndex1] ON [People.Staff] (Branch_idBranch);
GO


CREATE INDEX IFK_Rel_15 ON [People.Staff] (Branch_idBranch);
GO
CREATE INDEX IFK_Rel_20 ON [People.Staff] ([People.Staff_Category_idPeople.Staff_Category]);
GO


CREATE TABLE [People.Donor] (
  [idPeople.Donor] INTEGER  NOT NULL   IDENTITY ,
  Address_idAddress INTEGER  NOT NULL  ,
  Branch_idBranch INTEGER  NOT NULL  ,
  First_Name VARCHAR(50)    ,
  Last_Name VARCHAR(50)    ,
  DOB DATE    ,
  [Date of Registration] DATE    ,
  CNIC VARCHAR(13)    ,
  Gender BIT      ,
PRIMARY KEY([idPeople.Donor])    ,
  FOREIGN KEY(Branch_idBranch)
    REFERENCES Branch(idBranch),
  FOREIGN KEY(Address_idAddress)
    REFERENCES Address(idAddress));
GO


CREATE INDEX [People.Donor_FKIndex1] ON [People.Donor] (Branch_idBranch);
GO
CREATE INDEX [People.Donor_FKIndex2] ON [People.Donor] (Address_idAddress);
GO


CREATE INDEX IFK_Rel_16 ON [People.Donor] (Branch_idBranch);
GO
CREATE INDEX IFK_Rel_18 ON [People.Donor] (Address_idAddress);
GO


CREATE TABLE [Donor.Medical_Condition] (
  [idDonor.Medical_Condition] INTEGER  NOT NULL   IDENTITY ,
  [Donor.Diseases_idDonor.Diseases] VARCHAR(50)  NOT NULL  ,
  [People.Donor_idPeople.Donor] INTEGER  NOT NULL    ,
PRIMARY KEY([idDonor.Medical_Condition])    ,
  FOREIGN KEY([People.Donor_idPeople.Donor])
    REFERENCES [People.Donor]([idPeople.Donor]),
  FOREIGN KEY([Donor.Diseases_idDonor.Diseases])
    REFERENCES [Donor.Diseases]([idDonor.Diseases]));
GO


CREATE INDEX [Donor.Medical_Condition_FKIndex1] ON [Donor.Medical_Condition] ([People.Donor_idPeople.Donor]);
GO
CREATE INDEX [Donor.Medical_Condition_FKIndex2] ON [Donor.Medical_Condition] ([Donor.Diseases_idDonor.Diseases]);
GO


CREATE INDEX IFK_Rel_10 ON [Donor.Medical_Condition] ([People.Donor_idPeople.Donor]);
GO
CREATE INDEX IFK_Rel_11 ON [Donor.Medical_Condition] ([Donor.Diseases_idDonor.Diseases]);
GO


CREATE TABLE [Donor.Prescription] (
  [idDonor.Prescription] INTEGER  NOT NULL   IDENTITY ,
  [People.Donor_idPeople.Donor] INTEGER  NOT NULL  ,
  [Donor.Medicines_idDonor.Medicines] VARCHAR(50)  NOT NULL  ,
  Dose CHAR(3)  NOT NULL  ,
  Valid_From DATE  NOT NULL  ,
  Valid_Till DATE  NOT NULL    ,
PRIMARY KEY([idDonor.Prescription])    ,
  FOREIGN KEY([People.Donor_idPeople.Donor])
    REFERENCES [People.Donor]([idPeople.Donor]),
  FOREIGN KEY([Donor.Medicines_idDonor.Medicines])
    REFERENCES [Donor.Medicines]([idDonor.Medicines]));
GO


CREATE INDEX [Donor.Prescription_FKIndex1] ON [Donor.Prescription] ([People.Donor_idPeople.Donor]);
GO
CREATE INDEX [Donor.Prescription_FKIndex2] ON [Donor.Prescription] ([Donor.Medicines_idDonor.Medicines]);
GO


CREATE INDEX IFK_Rel_12 ON [Donor.Prescription] ([People.Donor_idPeople.Donor]);
GO
CREATE INDEX IFK_Rel_13 ON [Donor.Prescription] ([Donor.Medicines_idDonor.Medicines]);
GO


CREATE TABLE [Donor.Phone] (
  [People.Donor_idPeople.Donor] INTEGER  NOT NULL  ,
  Phone_No VARCHAR(50)  NOT NULL  ,
  Phone_Type VARCHAR(50)  NOT NULL    ,
  FOREIGN KEY([People.Donor_idPeople.Donor])
    REFERENCES [People.Donor]([idPeople.Donor]));
GO


CREATE INDEX [Donor.Phone_FKIndex1] ON [Donor.Phone] ([People.Donor_idPeople.Donor]);
GO


CREATE INDEX IFK_Rel_13 ON [Donor.Phone] ([People.Donor_idPeople.Donor]);
GO


CREATE TABLE [Application.Credentials] (
  User_name VARCHAR(50)  NOT NULL    ,
  [People.Staff_idStaff] INTEGER  NOT NULL  ,
  Hashed_Password VARCHAR(50)  NOT NULL  ,
  DateCreated DATE  NOT NULL    ,
PRIMARY KEY(User_name)  ,
  FOREIGN KEY([People.Staff_idStaff])
    REFERENCES [People.Staff](idStaff));
GO


CREATE INDEX [Application.Credentials_FKIndex1] ON [Application.Credentials] ([People.Staff_idStaff]);
GO


CREATE INDEX IFK_Rel_14 ON [Application.Credentials] ([People.Staff_idStaff]);
GO


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



CREATE TABLE [Depository.Deposit] (
  idDepost INTEGER  NOT NULL   IDENTITY ,
  [Donation_idTransaction.Donation] INTEGER  NOT NULL  ,
  [People.Staff_idStaff] INTEGER  NOT NULL  ,
  [Deposit.Blood_Type_idBlood_TYPE] VARCHAR(50)  NOT NULL  ,
  [Deposit.Deposit_Category_idDeposit.Deposit_Cat] VARCHAR(50)  NOT NULL  ,
  [Depository.Main_Depository_idDepository] INTEGER    ,
  Valid_Till DATE  NOT NULL  ,
  Valid_From DATE  NOT NULL    ,
PRIMARY KEY(idDepost)          ,
  FOREIGN KEY([Depository.Main_Depository_idDepository])
    REFERENCES [Depository.Main_Depository](idDepository),
  FOREIGN KEY([Deposit.Blood_Type_idBlood_TYPE])
    REFERENCES [Deposit.Blood_Type](idBlood_TYPE),
  FOREIGN KEY([Donation_idTransaction.Donation])
    REFERENCES [Donation]([idTransaction.Donation]),
  FOREIGN KEY([Deposit.Deposit_Category_idDeposit.Deposit_Cat])
    REFERENCES [Deposit.Deposit_Category]([idDeposit.Deposit_Cat]),
  FOREIGN KEY([People.Staff_idStaff])
    REFERENCES [People.Staff](idStaff));
GO


CREATE INDEX Depost_FKIndex1 ON [Depository.Deposit] ([Depository.Main_Depository_idDepository]);
GO
CREATE INDEX [Depository.Deposit_FKIndex3] ON [Depository.Deposit] ([Donation_idTransaction.Donation]);
GO
CREATE INDEX [Depository.Deposit_FKIndex4] ON [Depository.Deposit] ([Deposit.Deposit_Category_idDeposit.Deposit_Cat]);
GO
CREATE INDEX [Depository.Deposit_FKIndex2] ON [Depository.Deposit] ([People.Staff_idStaff]);
GO
CREATE INDEX [Depository.Deposit_FKIndex5] ON [Depository.Deposit] ([Deposit.Blood_Type_idBlood_TYPE]);
GO


CREATE INDEX IFK_Rel_03 ON [Depository.Deposit] ([Depository.Main_Depository_idDepository]);
GO
CREATE INDEX IFK_Rel_04 ON [Depository.Deposit] ([Deposit.Blood_Type_idBlood_TYPE]);
GO
CREATE INDEX IFK_Rel_06 ON [Depository.Deposit] ([Donation_idTransaction.Donation]);
GO
CREATE INDEX IFK_Rel_08 ON [Depository.Deposit] ([Deposit.Deposit_Category_idDeposit.Deposit_Cat]);
GO
CREATE INDEX IFK_Rel_22 ON [Depository.Deposit] ([People.Staff_idStaff]);
GO



CREATE TABLE [People.Address] (
  [idPeople.Address] INTEGER  NOT NULL   IDENTITY ,
  [People.Donor_idPeople.Donor] INTEGER  NOT NULL  ,
  Address_Line1 VARCHAR(50)  NOT NULL  ,
  Address_Line2 VARCHAR(50)  NOT NULL  ,
  Address_Line3 VARCHAR(50)    ,
  City VARCHAR(50)  NOT NULL  ,
  Zip_PostCode VARCHAR(20)  NOT NULL  ,
  Address_Type VARCHAR(20)  NOT NULL    ,
PRIMARY KEY([idPeople.Address])  ,
  FOREIGN KEY([People.Donor_idPeople.Donor])
    REFERENCES [People.Donor]([idPeople.Donor]));
GO


CREATE INDEX [People.Address_FKIndex1] ON [People.Address] ([People.Donor_idPeople.Donor]);
GO


CREATE INDEX IFK_Rel_20 ON [People.Address] ([People.Donor_idPeople.Donor]);
GO

