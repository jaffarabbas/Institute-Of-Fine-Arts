
SELECT * FROM REGISTRATION

select * from VW_SHOW_STUDENTS_ALL_DATA
select * from COURSES
insert into REGISTRATION values (1,1)



select * from STAFF_LOGIN
DELETE FROM STAFF_LOGIN
DBCC CHECKIDENT ('STAFF_LOGIN', RESEED, 0)
DBCC CHECKIDENT ('ASSIGNED', RESEED, 0)


select * from WORK_OF_COMPITITION
DELETE FROM WORK_OF_COMPITITION
DBCC CHECKIDE  ('WORK_OF_COMPITITION', RESEED, 0)

Alter Table WORK_OF_COMPITITION  
Add tempId Int Identity(1, 1)  
Go  
Alter Table WORK_OF_COMPITITION Drop Column WOC_ID  
Go  
Exec sp_rename 'WORK_OF_COMPITITION.tempId', 'WOC_ID', 'Column'  


SELECT * FROM VW_SHOW_STAFF_ALL_DETIALS
SELECT * FROM VW_SHOW_STAFF_ALL_DATA

SELECT * FROM ASSIGNED

SELECT * FROM REGISTRATION

select * from COMPITITION

select * from VW_SHOW_COMPITITION_ALL_DATA

select * from VW_SHOW_COMPITION_ALL_DATA_FROM_STUDENT_ DE

select * from COMPITITION 

select * from WORK_OF_COMPITITION

select * from STUDENT_LOGIN 

select * from RESULT

select * from RESULT_ENTRIES


--show compitition to students
select c.*,st.STF_NAME,cr.CR_NAME from COMPITITION c 
inner join ASSIGNED s on c.COM_STF_ID = s.ASI_STFL_ID
inner join STAFF_LOGIN st on st.STF_ID = s.ASI_STFL_ID
inner join REGISTRATION r on r.REG_CR_ID = s.ASI_CR_ID
inner join COURSES cr on cr.CR_ID = s.ASI_CR_ID

SELECT RES.RES_ID , COM.* , STFL.STF_NAME  OM RESULT RES 
INNER JOIN COMPITITION COM ON COM.COM_ID = RES.RES_ID
INNER JOIN STAFF_LOGIN STFL ON STFL.STF_ID = COM.COM_STF_ID 

SELECT * FROM RESULT_ENTRIES

select * from WORK_OF_COMPITITION

select * from REGISTRATION

delete from WORK_OF_COMPITITION where WOC_ID = 0

select * from RESULT_ENTRIES

select * from VW_SHOW_RESULT_CARD_DETIALS

select * from WORK_OF_COMPITITION

select * from RESULT

alter TABLE RESULT_ENTRIES
ALTER COLUMN RES_MARKS int NOT NULL

delete from RESULT_ TRIES where RES_ID = 1

insert into RESULT_ENTRIES(RES_ID,RES_WORK_ID,RES_MARKS,RES_DATE,RES_GRADE,RES_IS_ELIGIBLE) values(1,1,90.44,getdate(),'A+',1)

select * from STUDENT_LOGIN

select * from STUDENT_DETAILS

SELECT * from ASSIGNED

select * from STUDENT_LOGIN

select * from REGISTRATION

select * from COURSES

select * from STAFF_LOGIN

select * from ASSIGNED

select * from COURSES



INSERT STUDENT_LOGIN VALUES('jaffar','123','~/img')
select * from STUDENT_LOGIN
INSERT STUDENT_DETAILS VALUES(1,'SDF','DFS','03012',GETDATE())

delete from STUDENT_LOGIN where STDL_ID = 3

select * from VW_SHOW_STUDENTS_ALL_DATA

select * from VW_SHOW_COMPITITION_ALL_DATA

select * from VW_SHOW_COMPITITION_DETAILS_TO_STUDENTS

select * from VW_SHOW_COMPITITION_DETAILS_TO_STUDENTS s
--inner join COURSES c on c.CR_ID = s.CR_ID 
inner join REGISTRATION r on r.REG R_ID = s.CR_ID
--inner join STUDENT_LOGIN sl on r.REG_STDL_ID = sl.STDL_ID

select * from VW_SHOW_COMPITITION_DETAILS_TO_STUDENTS where CR_ID in (select REG_CR_ID from REGISTRATION where COM_STF_ID in (select ASI_STFL_ID from ASSIGNED))

select * from VW_SHOW_COMPITITION_DETAILS_TO_STUDENTS where CR_ID = 1

SELECT * FROM COMPITITION

SELECT * FROM WORK_OF_COMPITITION

select * from REGISTRATION

select * from STUDENT_LOGIN

insert into REGISTRATION(REG_STDL_ID,REG_CR_ID,REG_DATE) values(2,1,getdate())

alter table REGISTRATION 
alter column REG_CR_ID int not null

alter table ASSIGNED
alter column ASI_CR_ID int not null

select * from WORK_OF_COMPITITION

DELETE FROM COMPITITION WHERE COM_ID = 2
insert into WORK_OF_COMPITITION values(2,8,1,'~/Images/18738438_709632655888755_132956476813204679_o.jpg')

update WORK_OF_COMPITITION 
set WOC_WORK = '~/Images/2560x1440-the-last-samurai-minimal-4k_1618126622.jpg'
where WOC_ID = 2	

SELECT c.*,st.STF_NAME,cr.CR_NAME from COMPITITION c 
INNER JOIN ASSIGNED s ON c.COM_STF_ID = s.ASI_STFL_ID
INNER JOIN STAFF_LOGIN st ON st.STF_ID = s.ASI_STFL_ID
INNER JOIN COURSES cr ON cr.CR_ID = s.ASI_CR_ID

select * from ASSIGNED

select * from STAFF_LOGIN

select * from REGISTRATION

select * from COURSES

SELECT * FROM VW_SHOW_COMPITITION_DETAILS_TO_STUDENTS 

select * from VW_SHOW_COMPITITION_ALL_DATA

select * from VW_SHOW_COMPITITION_DETAILS_TO_STUDENTS s
inner join REGISTRATION r on r.REG_CR_ID = s.CR_ID
inner join ASSIGNED a on a.ASI_CR_ID = r.REG_CR_ID

select * from VW_SHOW_COMPITITION_DETAILS_TO_STUDENTS where CR_ID in (select REG_CR_ID from REGISTRATION where REG_STDL_ID = 4)

select * from VW_SHOW_RESULT_ALL_DATA

select * from RESULT_ENTRIES

SELECT STL.STDL_ID,STL.STDL_NAME , COM.COM_NAME, WCOM.WOC_WORK,RESE.*
FROM RESULT_ENTRIES RESE 
INNER JOIN RESULT RES ON RESE.RES_ID = RES.RES_ID
INNER JOIN WORK_OF_COMPITITION WCOM ON RES.RES_COM_ID = WCOM.WOC_COM_ID
INNER JOIN REGISTRATION RE ON WCOM.WOC_REG_ID = RE.REG_ID
INNER JOIN STUDENT_LOGIN STL ON RE.REG_STDL_ID = STL.STDL_ID
INNER JOIN COMPITITION COM ON COM.COM_ID = RES.RES_COM_ID

select * from VW_SHOW_RESULT_CARD_DETIALS where RES_ID in (select RES_ID from RESULT_ENTRIES)

select * from VW_SHOW_RESULT_ALL_DATA 

select * from COMPITITION

select * from VW_SHOW_COMPITITION_ALL_DATA e where e.WOC_ID not in (select WOC_ID from RESULT_ENTRIES)

select * from RESULT_ENTRIES

select * from EXIBITION

select * from EXIBITION_ENTRIES


DELETE FROM EXIBITION_ENTRIES
DBCC CHECKIDENT ('EXIBITION_ENTRIES', RESEED, 0)

DELETE FROM EXIBITION
DBCC CHECKIDENT ('EXIBITION', RESEED, 0)


DELETE FROM RESULT_ENTRIES
DBCC CHECKIDENT ('RESULT_ENTRIES', RESEED, 0)

DELETE FROM RESULT
DBCC CHECKIDENT ('RESULT', RESEED, 0)


DELETE FROM WORK_OF_COMPITITION
DBCC CHECKIDENT ('WORK_COMPITITION', RESEED, 0)

DELETE FROM COMPITITION
DBCC CHECKIDENT ('COMPITITION', RESEED, 0)

DELETE FROM REGISTRATION
DBCC CHECKIDE ('REGISTRATION', RESEED, 0)

DELETE FROM ASSIGNED
DBCC CHECKIDENT ('ASSIGNED', RESEED, 0)

DELETE FROM STUDENT_LOGIN
DBCC CHECKIDENT ('STUDENT_LOGIN', RESEED, 0)

DELETE FROM COURSES
DBCC CHECKIDENT ('COURSES', RESEED, 0)

DELETE FROM STAFF_LOGIN
DBCC CHECKIDENT ('STAFF_LOGIN', RESEED, 0)

select * from ADMIN_LOGIN







