DBMS-Final-Project-18
=====================
Semester Project for Database Systems Fall 2018
-----------------------------------------------

**Project Requirements**


-**Triggers**

  1) A trigger is added to safegaurd the Donations present inside a system. Whenever a donation is deleted, it triggers and raises error.

-**Views**

  1) A credential view is created by the name of "Pass_Change" which has the Name, Username and Password of the Staff Member


-**Stored Procedures**

  1) "Search Donation" which takes argument @Blood_Type and returns all non expired and not donated pints of blood present in the system.

  2) "Search Donors" which takes "First_Name" and returns people which have that First name, present in the system.

  3) "Fulfill" is created to fulfill the requests raised. It takes 3 arguments @quantity,@blood_type,@requestID. And fulfills the request. Additionally it is taken care of by the UI that a request of one type can only be created if it is present in the system.

-**Data Population**

  1) We created a Python script  which helped us create data entries for our Main Transaction table "Donations_final".
Currently That Table has more than 1 Million entries. Which was later on Bulk-Inserted into the Database by Mazeyar.

