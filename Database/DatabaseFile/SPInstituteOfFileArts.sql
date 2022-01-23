--*********************Institue of Fine Arts Database*********************



--*********************STORED PROCEDURE*********************

CREATE PROCEDURE SP_INSERT_INTO_COURCE_BY_ADMIN  @CR_NAME NVARCHAR(20) 
AS
BEGIN
	INSERT INTO COURSES VALUES (@CR_NAME) 
END
GO

EXEC SP_SHOW_STUDENTS_ALL_DATA
delete from VW_COURSES

EXEC SP_INSERT_INTO_COURCE_BY_ADMIN 'GALLERY' , 2 , 'P2' 
EXEC SP_INSERT_INTO_COURCE_BY_ADMIN 'newGALLERY' , 2 , 'P2' 

CREATE PROCEDURE SP_INSERT_INTO_STUDENT_BY_ADMIN @STDL_NAME NVARCHAR(50),  @STDL_PASSWORD NVARCHAR(50), @STDL_PROFILE NVARCHAR(MAX) , @STD_ADDRESS NVARCHAR(200), @STD_EMAIL NVARCHAR(100) , @STD_PHONE NVARCHAR(50) ,  @STD_DATE_OF_BIRTH DATE
AS
BEGIN
	DECLARE @FINAL_ID INT
	INSERT INTO STUDENT_LOGIN VALUES (@STDL_NAME, @STDL_PASSWORD, @STDL_PROFILE)
	SET @FINAL_ID = (SELECT STDL_ID FROM STUDENT_LOGIN WHERE STDL_NAME = @STDL_NAME)
	INSERT INTO STUDENT_DETAILS VALUES (@FINAL_ID,@STD_ADDRESS,@STD_EMAIL,@STD_PHONE,@STD_DATE_OF_BIRTH)
END
GO

--CREATE PROCEDURE SP_INSERT_INTO_STUDENT_BY_ADMIN @STDL_NAME NVARCHAR(50),  @STDL_PASSWORD NVARCHAR(50), @STDL_PROFILE NVARCHAR(MAX) , @STD_ADDRESS NVARCHAR(200), @STD_EMAIL NVARCHAR(100) , @STD_PHONE NVARCHAR(50) ,  @STD_DATE_OF_BIRTH DATE , @REG_COURCE_NAME NVARCHAR(20)
--AS
--BEGIN
--	DECLARE @REG_ID NVARCHAR(20)
--	DECLARE @ID INT
--	DECLARE @PREFIX VARCHAR(20) = 'STUDENT_'
--	DECLARE @FINAL_ID VARCHAR(20)
--	SELECT @ID = ISNULL(MAX(_STLID), 0)+1 FROM VW_STUDENT_LOGIN
--	SELECT @FINAL_ID = @PREFIX+ RIGHT(CAST(@id AS VARCHAR(20)), 20)
--	INSERT INTO VW_STUDENT_LOGIN VALUES (@STDL_NAME, @STDL_PASSWORD, @STDL_PROFILE,@FINAL_ID)
--	INSERT INTO VW_STUDENT_DETAILS VALUES (@FINAL_ID,@STD_ADDRESS,@STD_EMAIL,@STD_PHONE,@STD_DATE_OF_BIRTH)
--	SET @REG_ID = (SELECT REG_ID FROM VW_REGISTRATION WHERE REG_STDL_ID = @FINAL_ID)
--	EXECUTE SP_UPDATE_REGISTRATION_AFTER_TRIGGER @REG_COURCE_NAME , @REG_ID
--END
--GO

exec SP_REGISTRATION

EXEC SP_INSERT_INTO_STUDENT_BY_ADMIN 'ASDAS','ASDAS','ASDASD','SFSD','SDFSD','01115','2021-10-02','CS1'

SELECT * FROM VW_STUDENT_LOGIN

SELECT * FROM VW_STUDENT_DETAILS

SELECT * FROM VW_ADMINISTRATION

SELECT * FROM VW_REGISTRATION

DELETE FROM VW_ADMINISTRATION

SELECT * FROM VW_STAFF_LOGIN
SELECT * FROM VW_STAFF_DETAILS
SELECT * FROM VW_ASSIGNED
SELECT * FROM VW_ADMINISTRATION

DELETE FROM VW_PROGRAM

DELETE FROM VW_COURSES

DELETE FROM VW_STUDENT_LOGIN

DELETE FROM VW_STAFF_LOGIN

DELETE FROM VW_STAFF_DETAILS

DELETE FROM VW_STUDENT_DETAILS

DELETE FROM VW_ADMINISTRATION

DELETE FROM VW_REGISTRATION

INSERT INTO VW_ADMIN_LOGIN VALUES('ADMIN','JAFFARempire','~/','ADMIN_1')
DELETE FROM VW_ADMIN_LOGIN
DBCC CHECKIDENT ('STUDENT_LOGIN', RESEED, 0)  
DBCC CHECKIDENT ('REGISTRATION', RESEED, 0)  
DBCC CHECKIDENT ('ADMIN_LOGIN', RESEED, 0)  

exec SP_ADMIN_LOGIN
CREATE PROCEDURE SP_INSERT_INTO_STAFF_BY_ADMIN @STF_NAME NVARCHAR(50), @STF_PASSWORD NVARCHAR(50), @STF_PROFILE NVARCHAR(MAX),  @STFD_EDUCATION NVARCHAR(200), @STFD_ADDRESS NVARCHAR(200),  @STFD_EMAIL NVARCHAR(100), @STFD_PHONE NVARCHAR(50), @STFD_DATE_OF_BIRTH DATE, @STFD_SALARY DECIMAL(10,2) , @ASI_COURCE_NAME NVARCHAR(20)
AS
BEGIN
	DECLARE @ASI_ID NVARCHAR(20)
	DECLARE @ID INT
	DECLARE @PREFIX VARCHAR(20) = 'STAFF_'
	DECLARE @FINAL_ID VARCHAR(20)
	SELECT @ID = ISNULL(MAX(_STDID), 0)+1 FROM VW_STAFF_LOGIN
	SELECT @FINAL_ID = @PREFIX+ RIGHT(CAST(@id AS VARCHAR(20)), 20)
	INSERT INTO VW_STAFF_LOGIN VALUES(@STF_NAME, @STF_PASSWORD , @STF_PROFILE, @FINAL_ID)
	INSERT INTO VW_STAFF_DETAILS VALUES (@FINAL_ID,@STFD_EDUCATION, @STFD_ADDRESS, @STFD_EMAIL, @STFD_PHONE, @STFD_DATE_OF_BIRTH, @STFD_SALARY)
	SET @ASI_ID = (SELECT ASI_ID FROM ASSIGNED WHERE ASI_STFL_ID = @FINAL_ID)
	EXECUTE SP_UPDATE_ASSINED_AFTER_TRIGGER @ASI_COURCE_NAME , @ASI_ID
END
GO

EXEC SP_INSERT_INTO_STAFF_BY_ADMIN 'ASDAS','ASDAS','ASDASD','SFSD','SDFSD','SDFSD','01115','2021-10-02',5000.00,'CS1'


CREATE PROCEDURE SP_INSERT_INTO_FEES_BY_ADMIN  @FS_REG_ID NVARCHAR(20), @FS_AMOUNT DECIMAL(20, 2), @FS_PAID BIT , @FS_LAST_DATE DATE
AS
BEGIN
	DECLARE @ID INT
	DECLARE @PREFIX VARCHAR(20) = 'FS'
	DECLARE @FINAL_ID VARCHAR(20)
	SELECT @ID = ISNULL(MAX(_FEEID), 0)+1 FROM VW_FEES
	SELECT @FINAL_ID = @PREFIX+ RIGHT(CAST(@id AS VARCHAR(20)), 20)
	INSERT INTO VW_FEES VALUES (@FS_REG_ID, @FS_AMOUNT, @FS_PAID, @FS_LAST_DATE, @FINAL_ID)
END
GO

CREATE PROCEDURE SP_UPDATE_FEES @ID NVARCHAR(MAX)
AS
BEGIN
	UPDATE VW_FEES SET FS_PAID = 1 WHERE FS_ID = @ID
END
GO

INSERT INTO VW_FEES VALUES ('REG_2',1000,0,'2021-12-01','FS1')
EXEC SP_INSERT_INTO_FEES_BY_ADMIN 'REG_1',1000,0,'2021-12-01'

CREATE PROCEDURE SP_UPDATE_PROFILE_OF_ADMIN_BY_ADMIN @AD_ID NVARCHAR(20) ,  @AD_NAME NVARCHAR(50) , @AD_PASSWORD NVARCHAR(50) , @AD_PROFILE NVARCHAR(MAX)
AS
BEGIN 
	UPDATE VW_ADMIN_LOGIN SET AD_NAME = @AD_NAME , AD_PASSWORD = @AD_PASSWORD , AD_PROFILE = @AD_PROFILE WHERE AD_ID = @AD_ID
END
GO

EXEC SP_UPDATE_PROFILE_OF_ADMIN_BY_ADMIN 'ADMIN_1','ADMIN','JAFFAR','~/'

CREATE PROCEDURE SP_UPDATE_PROFILE_OF_STUDENT_BY_ADMIN @STDL_ID NVARCHAR(20) , @STDL_NAME NVARCHAR(50),  @STDL_PASSWORD NVARCHAR(50), @STDL_PROFILE NVARCHAR(MAX) , @STD_ADDRESS NVARCHAR(200), @STD_EMAIL NVARCHAR(100) , @STD_PHONE NVARCHAR(50) ,  @STD_DATE_OF_BIRTH DATE , @REG_COURCE_NAME NVARCHAR(20)
AS
BEGIN
	UPDATE VW_STUDENT_LOGIN SET STDL_NAME = @STDL_NAME , STDL_PASSWORD = @STDL_PASSWORD , STDL_PROFILE = @STDL_PROFILE WHERE STDL_ID = @STDL_ID
	UPDATE VW_STUDENT_DETAILS SET STD_ADDRESS = @STD_ADDRESS , STD_EMAIL = @STD_EMAIL , STD_PHONE = @STD_PHONE , STD_DATE_OF_BIRTH = @STD_DATE_OF_BIRTH WHERE SD_STDL_ID = @STDL_ID
	UPDATE VW_REGISTRATION SET REG_CR_ID = @REG_COURCE_NAME WHERE REG_STDL_ID = @STDL_ID
END
GO

EXEC SP_UPDATE_PROFILE_OF_STUDENT_BY_ADMIN 'STUDENT_1','JAFFAR','ASDDDDDAS','ASDDDDDDDDDDASD','SFSFFFFFFFFFFFFD','SDGGGGGGGFSD','01155515','2021-12-02','CS1'

CREATE PROCEDURE SP_UPDATE_PROFILE_OF_STAFF_BY_ADMIN  @STF_ID NVARCHAR(20) , @STF_NAME NVARCHAR(50), @STF_PASSWORD NVARCHAR(50), @STF_PROFILE NVARCHAR(MAX),  @STFD_EDUCATION NVARCHAR(200), @STFD_ADDRESS NVARCHAR(200),  @STFD_EMAIL NVARCHAR(100), @STFD_PHONE NVARCHAR(50), @STFD_DATE_OF_BIRTH DATE, @STFD_SALARY DECIMAL(10,2) , @ASI_COURCE_NAME NVARCHAR(20)
AS
BEGIN
	UPDATE VW_STAFF_LOGIN SET STF_NAME = @STF_NAME , STF_PASSWORD = @STF_PASSWORD , STF_PROFILE = @STF_PROFILE WHERE STF_ID = @STF_ID
	UPDATE VW_STAFF_DETAILS SET STFD_EDUCATION = @STFD_EDUCATION , STFD_ADDRESS = @STFD_ADDRESS , STFD_EMAIL = @STFD_EMAIL , STFD_PHONE = @STFD_PHONE , STFD_DATE_OF_BIRTH = @STFD_DATE_OF_BIRTH , STFD_SALARY = @STFD_SALARY 
	UPDATE VW_ASSIGNED SET ASI_CR_ID = @ASI_COURCE_NAME WHERE ASI_STFL_ID = @STF_ID
END
GO

EXEC SP_UPDATE_PROFILE_OF_STAFF_BY_ADMIN 'STAFF_1','JFF','ARRSDAS','ADDDSDASD','SFSHFFD','SDFHHSD','GGG','0115515','2021-12-02',8000.00,'CS2'


EXECUTE SP_STAFF_LOGIN
EXECUTE SP_STAFF_DETAILS
EXECUTE SP_ASSIGNED
EXECUTE SP_ADMINISTRATION

EXECUTE SP_STUDENT_LOGIN
EXECUTE SP_STAFF_DETAILS

EXECUTE SP_DELETE_TABLES 'ASSIGNED'

CREATE PROCEDURE SP_DELETE_PROFILE_OF_STUDENT_BY_ADMIN @STDL_ID NVARCHAR(20)
AS
BEGIN
	DELETE FROM VW_MANAGER WHERE MG_EXB_ID = (SELECT EXB_ID FROM VW_EXIBITION WHERE EXB_SCR_ID = (SELECT SCR_ID FROM VW_SCHOLARSHIP WHERE SCR_RES_ID = (SELECT RES_ID FROM VW_RESULT WHERE RES_RES_ID = (SELECT REG_ID FROM REGISTRATION WHERE REG_STDL_ID = @STDL_ID)) ))
	DELETE FROM VW_EXIBITION WHERE EXB_SCR_ID = (SELECT SCR_ID FROM VW_SCHOLARSHIP WHERE SCR_RES_ID = (SELECT RES_ID FROM VW_RESULT WHERE RES_RES_ID = (SELECT REG_ID FROM REGISTRATION WHERE REG_STDL_ID = @STDL_ID)) )
	DELETE FROM VW_SCHOLARSHIP WHERE SCR_RES_ID = (SELECT RES_ID FROM VW_RESULT WHERE RES_RES_ID = (SELECT REG_ID FROM REGISTRATION WHERE REG_STDL_ID = @STDL_ID)) 
	DELETE FROM VW_FAILED_PROJECTS WHERE FP_RES_ID = (SELECT RES_ID FROM VW_RESULT WHERE RES_RES_ID = (SELECT REG_ID FROM REGISTRATION WHERE REG_STDL_ID = @STDL_ID)) 
	DELETE FROM VW_RESULT WHERE RES_RES_ID = (SELECT REG_ID FROM REGISTRATION WHERE REG_STDL_ID = @STDL_ID) 
	DELETE FROM VW_WORK_OF_COMPITITION WHERE WOC_REG_ID = (SELECT REG_ID FROM REGISTRATION WHERE REG_STDL_ID = @STDL_ID) 
	DELETE FROM VW_DEFAULTER WHERE DEF_FS_ID = (SELECT FS_ID FROM VW_FEES WHERE FS_REG_ID = (SELECT REG_ID FROM REGISTRATION WHERE REG_STDL_ID = @STDL_ID)) 
	DELETE FROM VW_FEES WHERE FS_REG_ID = (SELECT REG_ID FROM REGISTRATION WHERE REG_STDL_ID = @STDL_ID) 
	DELETE FROM VW_STUDENT_LOGIN WHERE STDL_ID = @STDL_ID
	DELETE FROM VW_STUDENT_DETAILS WHERE SD_STDL_ID = @STDL_ID
END
GO

EXECUTE SP_STUDENT_LOGIN
EXECUTE SP_STUDENT_DETAILS
EXECUTE SP_REGISTRATION
EXECUTE SP_ADMINISTRATION
EXECUTE SP_FEES

EXEC SP_DELETE_PROFILE_OF_STUDENT_BY_ADMIN 'STUDENT_9'

CREATE PROCEDURE SP_DELETE_PROFILE_OF_STAFF_BY_ADMIN @STF_ID NVARCHAR(20)
AS
BEGIN
	DELETE FROM VW_MANAGER WHERE MG_EXB_ID = (SELECT EXB_ID FROM VW_EXIBITION WHERE EXB_SCR_ID = (SELECT SCR_ID FROM VW_SCHOLARSHIP WHERE SCR_RES_ID = (SELECT RES_ID FROM VW_RESULT WHERE RES_WORK_ID = (SELECT WOC_ID FROM VW_WORK_OF_COMPITITION WHERE WOC_COM_ID = (SELECT COM_ID FROM VW_COMPITITION WHERE COM_STF_ID = (SELECT STF_ID FROM VW_STAFF_LOGIN WHERE STF_ID = @STF_ID))))))
	DELETE FROM VW_EXIBITION WHERE EXB_SCR_ID = (SELECT SCR_ID FROM VW_SCHOLARSHIP WHERE SCR_RES_ID = (SELECT RES_ID FROM VW_RESULT WHERE RES_WORK_ID = (SELECT WOC_ID FROM VW_WORK_OF_COMPITITION WHERE WOC_COM_ID = (SELECT COM_ID FROM VW_COMPITITION WHERE COM_STF_ID = (SELECT STF_ID FROM VW_STAFF_LOGIN WHERE STF_ID = @STF_ID)))))
	DELETE FROM VW_SCHOLARSHIP WHERE SCR_RES_ID = (SELECT RES_ID FROM VW_RESULT WHERE RES_WORK_ID = (SELECT WOC_ID FROM VW_WORK_OF_COMPITITION WHERE WOC_COM_ID = (SELECT COM_ID FROM VW_COMPITITION WHERE COM_STF_ID = (SELECT STF_ID FROM VW_STAFF_LOGIN WHERE STF_ID = @STF_ID)))) 
	DELETE FROM VW_FAILED_PROJECTS WHERE FP_RES_ID = (SELECT RES_ID FROM VW_RESULT WHERE RES_WORK_ID = (SELECT WOC_ID FROM VW_WORK_OF_COMPITITION WHERE WOC_COM_ID = (SELECT COM_ID FROM VW_COMPITITION WHERE COM_STF_ID = (SELECT STF_ID FROM VW_STAFF_LOGIN WHERE STF_ID = @STF_ID))))
	DELETE FROM VW_RESULT WHERE RES_WORK_ID = (SELECT WOC_ID FROM VW_WORK_OF_COMPITITION WHERE WOC_COM_ID = (SELECT COM_ID FROM VW_COMPITITION WHERE COM_STF_ID = (SELECT STF_ID FROM VW_STAFF_LOGIN WHERE STF_ID = @STF_ID))) 
	DELETE FROM VW_WORK_OF_COMPITITION WHERE WOC_COM_ID = (SELECT COM_ID FROM VW_COMPITITION WHERE COM_STF_ID = (SELECT STF_ID FROM VW_STAFF_LOGIN WHERE STF_ID = @STF_ID))
    DELETE FROM VW_COMPITITION WHERE COM_STF_ID = (SELECT STF_ID FROM VW_STAFF_LOGIN WHERE STF_ID = @STF_ID)
	DELETE FROM VW_STAFF_LOGIN WHERE STF_ID = @STF_ID
	DELETE FROM VW_STAFF_DETAILS WHERE ST_STFD_ID = @STF_ID
END
GO

EXEC SP_DELETE_PROFILE_OF_STAFF_BY_ADMIN 'STAFF_1'

--****************STORED PROCEDURE OF STAFF ****************

CREATE PROCEDURE SP_UPDATE_PROFILE_BY_STAFF @STF_ID NVARCHAR(20) , @STF_NAME NVARCHAR(50), @STF_PASSWORD NVARCHAR(50), @STF_PROFILE NVARCHAR(MAX),  @STFD_EDUCATION NVARCHAR(200), @STFD_ADDRESS NVARCHAR(200),  @STFD_EMAIL NVARCHAR(100), @STFD_PHONE NVARCHAR(50), @STFD_DATE_OF_BIRTH DATE, @STFD_SALARY DECIMAL(10,2) , @ASI_COURCE_NAME NVARCHAR(20)
AS
BEGIN
	UPDATE VW_STAFF_LOGIN SET STF_NAME = @STF_NAME , STF_PASSWORD = @STF_PASSWORD , STF_PROFILE = @STF_PROFILE WHERE STF_ID = @STF_ID
	UPDATE VW_STAFF_DETAILS SET STFD_EDUCATION = @STFD_EDUCATION , STFD_ADDRESS = @STFD_ADDRESS , STFD_EMAIL = @STFD_EMAIL , STFD_PHONE = @STFD_PHONE , STFD_DATE_OF_BIRTH = @STFD_DATE_OF_BIRTH , STFD_SALARY = @STFD_SALARY 
END
GO

CREATE PROCEDURE SP_UPDATE_PROFILE_OF_STUDENT_BTY_STAFF @STDL_ID NVARCHAR(20) , @STDL_NAME NVARCHAR(50),  @STDL_PASSWORD NVARCHAR(50), @STDL_PROFILE NVARCHAR(MAX) , @STD_ADDRESS NVARCHAR(200), @STD_EMAIL NVARCHAR(100) , @STD_PHONE NVARCHAR(50) ,  @STD_DATE_OF_BIRTH DATE , @REG_COURCE_NAME NVARCHAR(20)
AS
BEGIN
	UPDATE VW_STUDENT_LOGIN SET STDL_NAME = @STDL_NAME , STDL_PASSWORD = @STDL_PASSWORD , STDL_PROFILE = @STDL_PROFILE WHERE STDL_ID = @STDL_ID
	UPDATE VW_STUDENT_DETAILS SET STD_ADDRESS = @STD_ADDRESS , STD_EMAIL = @STD_EMAIL , STD_PHONE = @STD_PHONE , STD_DATE_OF_BIRTH = @STD_DATE_OF_BIRTH WHERE SD_STDL_ID = @STDL_ID
	UPDATE VW_REGISTRATION SET REG_CR_ID = @REG_COURCE_NAME
END
GO

CREATE PROCEDURE SP_INSERT_INTO_COMPITION_BY_STAFF  @COM_NAME NVARCHAR(50) , @COM_START_DATE DATETIME , @COM_END_DATE DATETIME , @COM_STF_ID NVARCHAR(20) , @COM_AWARD NVARCHAR(50) , @COM_FORMAT NVARCHAR(50)
AS
BEGIN
	DECLARE @ID INT
	DECLARE @PREFIX VARCHAR(20) = 'COM_'
	DECLARE @FINAL_ID VARCHAR(20)
	SELECT @ID = ISNULL(MAX(_COMID), 0)+1 FROM VW_COMPITITION
	SELECT @FINAL_ID = @PREFIX+ RIGHT(CAST(@id AS VARCHAR(20)), 20)
	INSERT INTO VW_COMPITITION VALUES (@COM_NAME , @COM_START_DATE , @COM_END_DATE , @COM_STF_ID , @COM_AWARD , @COM_FORMAT , @FINAL_ID)
END
GO

CREATE PROCEDURE SP_INSERT_INTO_RESULT_BY_STAFF @RES_COM_ID NVARCHAR(20) , @RES_RES_ID NVARCHAR(20) , @RES_MARKS DECIMAL(10, 2) , @RES_WORK_ID NVARCHAR(20) , @RES_DATE DATETIME
AS
BEGIN
	DECLARE @ID INT
	DECLARE @PREFIX VARCHAR(20) = 'RESULT_'
	DECLARE @FINAL_ID VARCHAR(20)
	SELECT @ID = ISNULL(MAX(_REUID), 0)+1 FROM VW_RESULT
	SELECT @FINAL_ID = @PREFIX+ RIGHT(CAST(@id AS VARCHAR(20)), 20)
	INSERT INTO VW_RESULT VALUES(@RES_COM_ID, @RES_RES_ID, @RES_MARKS , dbo.FU_CREATE_RESULT_PERCENTAGE(@RES_MARKS,100.00) , @RES_WORK_ID , CURRENT_TIMESTAMP , dbo.FU_CREATE_RESULT_GRADE (dbo.FU_CREATE_RESULT_PERCENTAGE(@RES_MARKS,100.00)),@FINAL_ID)
END
GO

--****************STORED PROCEDURE OF STUDENT ****************

CREATE PROCEDURE SP_UPDATE_PROFILE_BY_STUDENT @STDL_ID NVARCHAR(20) , @STDL_NAME NVARCHAR(50),  @STDL_PASSWORD NVARCHAR(50), @STDL_PROFILE NVARCHAR(MAX) , @STD_ADDRESS NVARCHAR(200), @STD_EMAIL NVARCHAR(100) , @STD_PHONE NVARCHAR(50) ,  @STD_DATE_OF_BIRTH DATE 
AS
BEGIN
	UPDATE VW_STUDENT_LOGIN SET STDL_NAME = @STDL_NAME , STDL_PASSWORD = @STDL_PASSWORD , STDL_PROFILE = @STDL_PROFILE WHERE STDL_ID = @STDL_ID
	UPDATE VW_STUDENT_DETAILS SET STD_ADDRESS = @STD_ADDRESS , STD_EMAIL = @STD_EMAIL , STD_PHONE = @STD_PHONE , STD_DATE_OF_BIRTH = @STD_DATE_OF_BIRTH WHERE SD_STDL_ID = @STDL_ID
END
GO

CREATE PROCEDURE SP_INSERT_INTO_WORK_COMPITION_BY_STUDENT @WOC_REG_ID NVARCHAR(20), @WOC_COM_ID NVARCHAR(20), @WOC_WORK NVARCHAR(MAX)
AS
BEGIN
	DECLARE @ID INT
	DECLARE @PREFIX VARCHAR(20) = 'WOC_'
	DECLARE @FINAL_ID VARCHAR(20)
	SELECT @ID = ISNULL(MAX(_WORID), 0)+1 FROM VW_WORK_OF_COMPITITION
	SELECT @FINAL_ID = @PREFIX+ RIGHT(CAST(@id AS VARCHAR(20)), 20)
	INSERT INTO VW_WORK_OF_COMPITITION VALUES (@WOC_REG_ID , @WOC_COM_ID , @WOC_WORK,@FINAL_ID)
END
GO

--****************STORED PROCEDURE OF MANAGER****************

CREATE PROCEDURE SP_UPDATE_PROFILE_BY_MANAGER @MG_ID NVARCHAR(20) , @MG_NAME NVARCHAR(50) , @MG_PASSWORD NVARCHAR(50) , @MG_PROFILE NVARCHAR(MAX)
AS
BEGIN
	UPDATE VW_MANAGER_LOGIN SET @MG_NAME = @MG_NAME , @MG_PASSWORD = @MG_PASSWORD , @MG_PROFILE = @MG_PROFILE WHERE MG_ID = @MG_ID
END
GO

CREATE PROCEDURE SP_INSERT_INTO_EXIBITION_BY_MANAGER  @EXB_NAME NVARCHAR(50) , @EXB_START_DATE DATETIME , @EXB_END_DATE DATETIME , @EXB_TYPE NVARCHAR(20) , @EXB_SCR_ID NVARCHAR(20)
AS
BEGIN
	DECLARE @ID INT
	DECLARE @PREFIX VARCHAR(20) = 'EXI_'
	DECLARE @FINAL_ID VARCHAR(20)
	SELECT @ID = ISNULL(MAX(_EXIID), 0)+1 FROM VW_EXIBITION
	SELECT @FINAL_ID = @PREFIX+ RIGHT(CAST(@id AS VARCHAR(20)), 20)
	INSERT INTO VW_EXIBITION VALUES (@EXB_NAME , @EXB_START_DATE , @EXB_END_DATE , @EXB_TYPE , @EXB_SCR_ID,@FINAL_ID)
END 
GO

CREATE PROCEDURE SP_UPDATE_INTO_EXIBITION_BY_MANAGER @EXB_ID NVARCHAR(20) , @EXB_NAME NVARCHAR(50) , @EXB_START_DATE DATETIME , @EXB_END_DATE DATETIME , @EXB_TYPE NVARCHAR(20) , @EXB_SCR_ID NVARCHAR(20)
AS
BEGIN
	UPDATE VW_EXIBITION SET EXB_NAME = @EXB_NAME, EXB_START_DATE = @EXB_START_DATE , EXB_END_DATE = @EXB_END_DATE , EXB_TYPE = @EXB_TYPE, EXB_SCR_ID = @EXB_SCR_ID WHERE EXB_ID = @EXB_ID
END 
GO

CREATE PROCEDURE SP_DELETE_FROM_EXIBITION_BY_MANAGER  @EXB_ID NVARCHAR(20) 
AS
BEGIN
	DELETE FROM VW_EXIBITION WHERE EXB_ID = @EXB_ID
END 
GO

CREATE PROCEDURE SP_UPDATE_REGISTRATION_AFTER_TRIGGER @COURSE_ID VARCHAR(20) , @REGISTRATION_ID VARCHAR(20)
AS
BEGIN
	UPDATE VW_REGISTRATION SET REG_CR_ID = @COURSE_ID WHERE REG_ID = @REGISTRATION_ID
END
GO

CREATE PROCEDURE SP_UPDATE_ASSINED_AFTER_TRIGGER @COURSE_ID VARCHAR(20) , @STAFF_ID VARCHAR(20)
AS
BEGIN
	UPDATE ASSIGNED SET ASI_CR_ID = @COURSE_ID WHERE ASI_ID = @STAFF_ID
END
GO

--****************Update Support Stored procedures For trigger****************

CREATE PROCEDURE SP_SET_DEFAULTER_FROM_FEES @PLENTY DECIMAL(10,2)
AS
BEGIN  
	INSERT INTO DEFAULTER(DEF_FS_ID,DEF_PLENTY) ((SELECT FS_ID,@PLENTY FROM FEES WHERE FS_LAST_DATE < GETDATE() AND FS_PAID = 0 AND FS_ID NOT IN (SELECT DEF_FS_ID FROM DEFAULTER)))
	UPDATE FEES SET FS_AMOUNT += 1000.00  WHERE FS_ID IN (SELECT DEF_FS_ID FROM DEFAULTER)
END
GO



--****************Select Stored procedures****************


--****************Adminlogin****************

CREATE PROCEDURE SP_ADMIN_LOGIN
AS
BEGIN
	SELECT * FROM VW_ADMIN_LOGIN
END
GO
--****************Managerlogin****************

CREATE PROCEDURE SP_MANAGER_LOGIN
AS
BEGIN
	SELECT * FROM VW_MANAGER_LOGIN
END
GO
--****************Student Detials****************

CREATE PROCEDURE SP_STUDENT_DETAILS
AS
BEGIN
	SELECT * FROM VW_STUDENT_DETAILS
END
GO
--****************Staff Detials****************

CREATE PROCEDURE SP_STAFF_DETAILS
AS
BEGIN
	SELECT * FROM VW_STAFF_DETAILS 
END
GO
--****************Contact****************

CREATE PROCEDURE SP_CONTACT 
AS
BEGIN
	SELECT * FROM VW_CONTACT
END
GO
--****************FeedBack****************

CREATE PROCEDURE SP_FEEDBACK 
AS
BEGIN
	SELECT * FROM VW_FEEDBACK    
END
GO
--****************Students****************

CREATE PROCEDURE SP_STUDENT_LOGIN
AS
BEGIN
	SELECT * FROM VW_STUDENT_LOGIN    
END
GO
--****************Staff****************

CREATE PROCEDURE SP_STAFF_LOGIN 
AS
BEGIN
	SELECT * FROM VW_STAFF_LOGIN    
END
GO

--****************Compitition****************

CREATE PROCEDURE SP_COMPITITION 
AS
BEGIN
	SELECT * FROM VW_COMPITITION   
END
GO

--****************Program****************

CREATE PROCEDURE SP_PROGRAM 
AS
BEGIN
	SELECT * FROM VW_PROGRAM    
END
GO
--****************Courses****************

CREATE PROCEDURE SP_COURSES 
AS
BEGIN
	SELECT * FROM VW_COURSES    
END
GO

--****************Registration****************

CREATE PROCEDURE SP_REGISTRATION 
AS
BEGIN
	SELECT * FROM VW_REGISTRATION    
END
GO
    
    

--****************Assigned****************

CREATE PROCEDURE SP_ASSIGNED 
AS
BEGIN
	SELECT * FROM VW_ASSIGNED    
END
GO
        

--****************Administration****************

CREATE PROCEDURE SP_ADMINISTRATION 
AS
BEGIN
	SELECT * FROM VW_ADMINISTRATION    
END
GO
     

--****************Work of Compition****************

CREATE PROCEDURE SP_WORK_OF_COMPITITION 
AS
BEGIN
	SELECT * FROM VW_WORK_OF_COMPITITION   
END
GO
     
--****************Attendence****************

CREATE PROCEDURE SP_ATTENDENCE 
AS
BEGIN
	SELECT * FROM VW_ATTENDENCE    
END
GO

--****************Result****************

CREATE PROCEDURE SP_RESULT 
AS
BEGIN
	SELECT * FROM VW_RESULT    
END
GO

--****************Scholarship****************

CREATE PROCEDURE SP_SCHOLARSHIP 
AS
BEGIN
	SELECT * FROM VW_SCHOLARSHIP    
END
GO
--****************Failed Projects****************

CREATE PROCEDURE SP_FAILED_PROJECTS 
AS
BEGIN
	SELECT * FROM VW_FAILED_PROJECTS   
END
GO

--****************Exibition****************

CREATE PROCEDURE SP_EXIBITION 
AS
BEGIN
	SELECT * FROM VW_EXIBITION    
END
GO
--****************Manager****************

CREATE PROCEDURE SP_MANAGER 
AS
BEGIN
	SELECT * FROM VW_MANAGER   
END
GO

--****************Fees****************

CREATE PROCEDURE SP_FEES 
AS
BEGIN
	SELECT * FROM VW_FEES    
END
GO

--****************Defaulter****************

CREATE PROCEDURE SP_DEFAULTER  
AS
BEGIN
	SELECT * FROM VW_DEFAULTER
END
GO

--****************Table data showing data in tables in application using joins etc USING stored procedures****************

--****************ADMIN VIEW FOR VIEWING DATA****************

CREATE PROCEDURE SP_SHOW_STUDENTS_ALL_DATA 
AS
BEGIN
	SELECT * FROM VW_SHOW_STUDENTS_ALL_DATA 
END
GO

CREATE PROCEDURE SP_SHOW_STAFF_ALL_DATA
AS
BEGIN
	SELECT * FROM VW_SHOW_STAFF_ALL_DATA
END
GO

CREATE PROCEDURE SP_SHOW_COMPITITION_ALL_DATA
AS
BEGIN
	SELECT * FROM VW_SHOW_COMPITITION_ALL_DATA
END
GO

CREATE PROCEDURE SP_SHOW_RESULT_ALL_DATA
AS
BEGIN
	SELECT * FROM VW_SHOW_RESULT_ALL_DATA
END
GO

CREATE PROCEDURE SP_SHOW_CONTACT_ALL_DATA
AS
BEGIN
	SELECT * FROM VW_SHOW_CONTACT_ALL_DATA
END
GO


CREATE PROCEDURE SP_SHOW_FEES_ALL_DATA
AS
BEGIN
	SELECT * FROM VW_SHOW_FEES_ALL_DATA
END
GO

--****************STUDENT VIEW FOR VIEWING DATA****************
CREATE PROCEDURE SP_SHOW_STUDENT_ALL_DATA_FROM_SUDENT_SIDE
AS
BEGIN
	SELECT * FROM VW_SHOW_STUDENT_ALL_DATA_FROM_SUDENT_SIDE
END
GO


CREATE PROCEDURE SP_SHOW_COMPITION_ALL_DATA_FROM_STUDENT_SIDE
AS
BEGIN
	SELECT * FROM VW_SHOW_COMPITION_ALL_DATA_FROM_STUDENT_SIDE
END
GO

CREATE PROCEDURE SP_SHOW_RESULT_ALL_DATA_FROM_STUDENT_SIDE
AS
BEGIN
	SELECT * FROM VW_SHOW_RESULT_ALL_DATA_FROM_STUDENT_SIDE
END
GO

CREATE PROCEDURE SP_SHOW_EXIBITION_ALL_DATA_FROM_STUDENT_SIDE
AS
BEGIN
	SELECT * FROM VW_SHOW_EXIBITION_ALL_DATA_FROM_STUDENT_SIDE
END
GO

CREATE PROCEDURE SP_SHOW_FEES_ALL_DATA_STUDENT_SIDE
AS
BEGIN
	SELECT * FROM VW_SHOW_FEES_ALL_DATA_STUDENT_SIDE
END
GO

--****************Staff VIEW FOR VIEWING DATA****************

CREATE PROCEDURE SP_SHOW_STAFF_ALL_DATA_FROM_STAFF
AS
BEGIN
	SELECT * FROM VW_SHOW_STAFF_ALL_DATA_FROM_STAFF
END
GO

CREATE PROCEDURE SP_SHOW_COMPITITION_ALL_DATA_FROM_STAFF
AS
BEGIN
	SELECT * FROM VW_SHOW_COMPITITION_ALL_DATA_FROM_STAFF
END
GO

CREATE PROCEDURE SP_SHOW_STUDENTS_ALL_DATA_FROM_STAFF
AS
BEGIN
	SELECT * FROM VW_SHOW_STUDENTS_ALL_DATA_FROM_STAFF
END
GO


CREATE PROCEDURE SP_SHOW_RESULT_ALL_DATA_FROM_STAFF
AS
BEGIN
	SELECT * FROM VW_SHOW_RESULT_ALL_DATA_FROM_STAFF
END
GO

--****************MANAGER VIEW FOR VIEWING DATA****************

CREATE PROCEDURE SP_SHOW_EXIBITION_ALL_DATA_FROM_MANAGER_SIDE
AS
BEGIN
	SELECT * FROM VW_SHOW_EXIBITION_ALL_DATA_FROM_MANAGER_SIDE
END
GO

CREATE PROCEDURE SP_SHOW_FEEDBACK_ALL_DATA
AS
BEGIN
	SELECT * FROM VW_SHOW_FEEDBACK_ALL_DATA
END
GO

--****************GLOBAL INSERTING SP****************

CREATE PROCEDURE SP_GLOBAL_SELECT_FROM_TABLE @TABLE VARCHAR(MAX)
AS
BEGIN
	DECLARE @SQL VARCHAR(MAX)
	SELECT @SQL = 'SELECT * FROM '+@TABLE
	EXEC(@SQL)
END
GO

CREATE PROCEDURE SP_GLOBAL_DELETE_FROM_TABLE @TABLE VARCHAR(MAX) , @COL NVARCHAR(MAX) , @ID  NVARCHAR(MAX)
AS
BEGIN
	DECLARE @SQL VARCHAR(MAX)
	SELECT @SQL = 'DELETE FROM '+@TABLE+' WHERE '+@COL+' = '+@ID;
	EXEC(@SQL)
END
GO

CREATE PROCEDURE SP_SEARCH_INTO_TABLES(@INPUT VARCHAR(MAX), @SORTBY VARCHAR(MAX), @TABLE VARCHAR(MAX)) AS
BEGIN
    DECLARE
    @SQL VARCHAR(MAX)
    SELECT @SQL = 'SELECT * FROM '+@TABLE+' WHERE '+@SORTBY+' LIKE '+CHAR(39)+'%'+@INPUT+CHAR(39)+'%';
	EXEC (@SQL);
END

CREATE PROCEDURE SP_DELETE_TABLES(@TABLE VARCHAR(MAX)) AS
BEGIN
    DECLARE
    @SQL VARCHAR(MAX)
    SELECT @SQL = 'DELETE FROM '+@TABLE;
	EXEC (@SQL);
END


CREATE PROCEDURE SP_DROP_TABLES(@TABLE VARCHAR(MAX)) AS
BEGIN
    DECLARE
    @SQL VARCHAR(MAX)
    SELECT @SQL = 'DROP TABLE '+@TABLE;
	EXEC (@SQL);
END


CREATE PROCEDURE SP_TRUNCATE_TABLES(@TABLE VARCHAR(MAX)) AS
BEGIN
    DECLARE
    @SQL VARCHAR(MAX)
    SELECT @SQL = 'TRUNCATE TABLE '+@TABLE;
	EXEC (@SQL);
END


CREATE PROCEDURE SP_COUNT_TABLE_LENGTH @TABLE NVARCHAR(MAX)
AS
BEGIN
	DECLARE
    @SQL VARCHAR(MAX)
    SELECT @SQL = 'SELECT COUNT(*) '+@TABLE;
	EXEC (@SQL); 
END
GO


EXEC SP_COUNT_TABLE_LENGTH 'VW_ADMIN_LOGIN'


EXECUTE SP_ADMIN_LOGIN
EXECUTE SP_MANAGER_LOGIN
EXECUTE SP_STUDENT_DETAILS
EXECUTE SP_STAFF_DETAILS
EXECUTE SP_CONTACT 
EXECUTE SP_FEEDBACK 
EXECUTE SP_STUDENT_LOGIN
EXECUTE SP_STAFF_LOGIN 
EXECUTE SP_COMPITITION 
EXECUTE SP_PROGRAM 
EXECUTE SP_COURSES 
EXECUTE SP_REGISTRATION 
EXECUTE SP_ASSIGNED 
EXECUTE SP_ADMINISTRATION 
EXECUTE SP_WORK_OF_COMPITITION 
EXECUTE SP_ATTENDENCE 
EXECUTE SP_RESULT 
EXECUTE SP_SCHOLARSHIP 
EXECUTE SP_FAILED_PROJECTS 
EXECUTE SP_EXIBITION 
EXECUTE SP_MANAGER 
EXECUTE SP_FEES 
EXECUTE SP_DEFAULTER  
EXECUTE SP_SHOW_STUDENTS_ALL_DATA 
EXECUTE SP_SHOW_STAFF_ALL_DATA
EXECUTE SP_SHOW_COMPITITION_ALL_DATA
EXECUTE SP_SHOW_RESULT_ALL_DATA
EXECUTE SP_SHOW_CONTACT_ALL_DATA
EXECUTE SP_SHOW_FEES_ALL_DATA
EXECUTE SP_SHOW_STUDENT_ALL_DATA_FROM_SUDENT_SIDE
EXECUTE SP_SHOW_COMPITION_ALL_DATA_FROM_STUDENT_SIDE
EXECUTE SP_SHOW_RESULT_ALL_DATA_FROM_STUDENT_SIDE
EXECUTE SP_SHOW_EXIBITION_ALL_DATA_FROM_STUDENT_SIDE
EXECUTE SP_SHOW_FEES_ALL_DATA_STUDENT_SIDE
EXECUTE SP_SHOW_STAFF_ALL_DATA_FROM_STAFF
EXECUTE SP_SHOW_COMPITITION_ALL_DATA_FROM_STAFF
EXECUTE SP_SHOW_STUDENTS_ALL_DATA_FROM_STAFF
EXECUTE SP_SHOW_RESULT_ALL_DATA_FROM_STAFF
EXECUTE SP_SHOW_EXIBITION_ALL_DATA_FROM_MANAGER_SIDE
EXECUTE SP_SHOW_FEEDBACK_ALL_DATA

drop procedure SP_ADMIN_LOGIN
drop procedure SP_MANAGER_LOGIN
drop procedure SP_STUDENT_DETAILS
drop procedure SP_STAFF_DETAILS
drop procedure SP_CONTACT 
drop procedure SP_FEEDBACK 
drop procedure SP_STUDENT_LOGIN
drop procedure SP_STAFF_LOGIN 
drop procedure SP_COMPITITION 
drop procedure SP_PROGRAM 
drop procedure SP_COURSES 
drop procedure SP_REGISTRATION 
drop procedure SP_ASSIGNED 
drop procedure SP_ADMINISTRATION 
drop procedure SP_WORK_OF_COMPITITION 
drop procedure SP_ATTENDENCE 
drop procedure SP_RESULT 
drop procedure SP_SCHOLARSHIP 
drop procedure SP_FAILED_PROJECTS 
drop procedure SP_EXIBITION 
drop procedure SP_MANAGER 
drop procedure SP_FEES 
drop procedure SP_DEFAULTER  
drop procedure SP_SHOW_STUDENTS_ALL_DATA 
drop procedure SP_SHOW_STAFF_ALL_DATA
drop procedure SP_SHOW_COMPITITION_ALL_DATA
drop procedure SP_SHOW_RESULT_ALL_DATA
drop procedure SP_SHOW_CONTACT_ALL_DATA
drop procedure SP_SHOW_FEES_ALL_DATA
drop procedure SP_SHOW_STUDENT_ALL_DATA_FROM_SUDENT_SIDE
drop procedure SP_SHOW_COMPITION_ALL_DATA_FROM_STUDENT_SIDE
drop procedure SP_SHOW_RESULT_ALL_DATA_FROM_STUDENT_SIDE
drop procedure SP_SHOW_EXIBITION_ALL_DATA_FROM_STUDENT_SIDE
drop procedure SP_SHOW_FEES_ALL_DATA_STUDENT_SIDE
drop procedure SP_SHOW_STAFF_ALL_DATA_FROM_STAFF
drop procedure SP_SHOW_COMPITITION_ALL_DATA_FROM_STAFF
drop procedure SP_SHOW_STUDENTS_ALL_DATA_FROM_STAFF
drop procedure SP_SHOW_RESULT_ALL_DATA_FROM_STAFF
drop procedure SP_SHOW_EXIBITION_ALL_DATA_FROM_MANAGER_SIDE
drop procedure SP_SHOW_FEEDBACK_ALL_DATA
DROP PROCEDURE SP_INSERT_INTO_PROGRAM_BY_ADMIN 
DROP PROCEDURE SP_INSERT_INTO_COURCE_BY_ADMIN  
DROP PROCEDURE SP_INSERT_INTO_STUDENT_BY_ADMIN 
DROP PROCEDURE SP_INSERT_INTO_STAFF_BY_ADMIN 
DROP PROCEDURE SP_INSERT_INTO_FEES_BY_ADMIN  
DROP PROCEDURE SP_INSERT_INTO_COMPITION_BY_STAFF
DROP PROCEDURE SP_INSERT_INTO_RESULT_BY_STAFF 
DROP PROCEDURE SP_INSERT_INTO_WORK_COMPITION_BY_STUDENT
DROP PROCEDURE SP_INSERT_INTO_EXIBITION_BY_MANAGER
DROP PROCEDURE SP_UPDATE_PROFILE_OF_ADMIN_BY_ADMIN 
DROP PROCEDURE SP_UPDATE_PROFILE_OF_STUDENT_BY_ADMIN
DROP PROCEDURE SP_UPDATE_PROFILE_OF_STAFF_BY_ADMIN 
DROP PROCEDURE SP_UPDATE_PROFILE_BY_STAFF  
DROP PROCEDURE SP_UPDATE_PROFILE_OF_STUDENT_BTY_STAFF
DROP PROCEDURE SP_UPDATE_PROFILE_BY_STUDENT 
DROP PROCEDURE SP_UPDATE_PROFILE_BY_MANAGER 
DROP PROCEDURE SP_UPDATE_INTO_EXIBITION_BY_MANAGER 
DROP PROCEDURE SP_UPDATE_REGISTRATION_AFTER_TRIGGER
DROP PROCEDURE SP_UPDATE_ASSINED_AFTER_TRIGGER
DROP PROCEDURE SP_DELETE_FROM_EXIBITION_BY_MANAGER
DROP PROCEDURE SP_DELETE_PROFILE_OF_STAFF_BY_ADMIN
DROP PROCEDURE SP_DELETE_PROFILE_OF_STUDENT_BY_ADMIN
DROP SP_INSER_INTO_COMPITION_BY_STAFF
DROP PROCEDURE UPDATE_ASSINED_AFTER_TRIGGER




 DBCC CHECKIDENT ('ADMIN_LOGIN' , RESEED, 0)   
 DBCC CHECKIDENT ('MANAGER_LOGIN' , RESEED, 0)   
 DBCC CHECKIDENT ('STUDENT_DETAILS' , RESEED, 0)   
 DBCC CHECKIDENT ('STAFF_DETAILS' , RESEED, 0)   
 DBCC CHECKIDENT ('CONTACT ' , RESEED, 0)   
 DBCC CHECKIDENT ('FEEDBACK ' , RESEED, 0)   
 DBCC CHECKIDENT ('STUDENT_LOGIN' , RESEED, 0)   
 DBCC CHECKIDENT ('STAFF_LOGIN ' , RESEED, 0)   
 DBCC CHECKIDENT ('COMPITITION ' , RESEED, 0)   
 DBCC CHECKIDENT ('PROGRAM ' , RESEED, 0)   
 DBCC CHECKIDENT ('COURSES ' , RESEED, 0)   
 DBCC CHECKIDENT ('REGISTRATION ' , RESEED, 0)   
 DBCC CHECKIDENT ('ASSIGNED ' , RESEED, 0)   
 DBCC CHECKIDENT ('ADMINISTRATION ' , RESEED, 0)   
 DBCC CHECKIDENT ('WORK_OF_COMPITITION ' , RESEED, 0)   
 DBCC CHECKIDENT ('ATTENDENCE ' , RESEED, 0)   
 DBCC CHECKIDENT ('RESULT ' , RESEED, 0)   
 DBCC CHECKIDENT ('SCHOLARSHIP ' , RESEED, 0)   
 DBCC CHECKIDENT ('FAILED_PROJECTS ' , RESEED, 0)   
 DBCC CHECKIDENT ('EXIBITION ' , RESEED, 0)   
 DBCC CHECKIDENT ('MANAGER ' , RESEED, 0)   
 DBCC CHECKIDENT ('FEES ' , RESEED, 0)   
 DBCC CHECKIDENT ('DEFAULTER ' , RESEED, 0)  

---DCL grant, revoke

CREATE LOGIN first_ WITH PASSWORD = 'test';
create user first_us for login first_;

grant connect to first_us;

Grant select on courses to first_us;
Grant select on program to first_us;

---assign database role to user
EXEC sp_addrolemember '[db_accessadmin]', 'first_us';
-- ALTER ROLE student add member sample_user;

--TCL commit, rollback savepoint