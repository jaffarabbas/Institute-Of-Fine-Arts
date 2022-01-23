using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Institute_Of_Fine_Arts_Database_Models;

namespace Web_Institute_Of_Fine_Arts_Database_Layer.DatabaseOperations
{
    public class AdminDBHandler
    {
        #region Singleton Methods
        private static AdminDBHandler DBHandler = new AdminDBHandler();
        private AdminDBHandler() { }
        public static AdminDBHandler GetDBHandler()
        {
            return DBHandler;
        }
        #endregion

        #region Cource DBHandler
        public List<COURS_MODEL> GetAllCourse()
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                var result = connection.COURSES.Select(model => new COURS_MODEL()
                {
                    CR_ID = model.CR_ID,
                    CR_NAME = model.CR_NAME,
                }).ToList();
                return result;
            }
        }

        public List<COURS_MODEL> GetAllUnPopulatedCourse()
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                var result = connection.COURSES
                    .Where(check => !connection.ASSIGNEDs
                    .Select(reCheck => reCheck.ASI_CR_ID)
                    .Contains(check.CR_ID))
                    .Select(model => new COURS_MODEL()
                {
                    CR_ID = model.CR_ID,
                    CR_NAME = model.CR_NAME,
                }).ToList();
                return result;
            }
        }

        public int AddCourses(COURS_MODEL courseModel)
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                COURS course = new COURS()
                {
                    CR_ID = courseModel.CR_ID,
                    CR_NAME = courseModel.CR_NAME
                };
                connection.COURSES.Add(course);
                connection.SaveChanges();
                return course.CR_ID;
            }
        }
        #endregion

        #region Student DB Handlers

        public List<VW_SHOW_STUDENTS_ALL_DETIALS_MODEL> GetAllStudents()
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                var result = connection.VW_SHOW_STUDENTS_ALL_DETIALS.Select(model => new VW_SHOW_STUDENTS_ALL_DETIALS_MODEL()
                {
                    STDL_ID = model.STDL_ID,
                    STDL_NAME = model.STDL_NAME,
                    STDL_PASSWORD = model.STDL_PASSWORD,
                    STDL_PROFILE = model.STDL_PROFILE,
                    SD_STDL_ID = model.SD_STDL_ID,
                    STD_ADDRESS = model.STD_ADDRESS,
                    STD_DATE_OF_BIRTH = model.STD_DATE_OF_BIRTH,
                    STD_EMAIL = model.STD_EMAIL,
                    STD_PHONE = model.STD_PHONE
                }).ToList();
                return result;
            }
        }

        public int AddStudents(VW_SHOW_STUDENTS_ALL_DETIALS_MODEL model)
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                //image extracting
                DBHelperMethods dBHelperMethods = DBHelperMethods.GetDBHandler();

                string filename = dBHelperMethods.FileName(model.ImageFile);
                string extension = dBHelperMethods.FileExtension(model.ImageFile);
                int length = dBHelperMethods.FileLength(model.ImageFile);

                if (dBHelperMethods.CheckFileExtension(extension))
                {
                    if (dBHelperMethods.CheckFileLength(length))
                    {
                        filename = filename + extension;
                        STUDENT_LOGIN stdlModel = new STUDENT_LOGIN()
                        {
                            STDL_PROFILE = "~/Images/" + filename,
                            STDL_ID = model.STDL_ID,
                            STDL_NAME = model.STDL_NAME,
                            STDL_PASSWORD = model.STDL_PASSWORD,
                        };
                        connection.STUDENT_LOGIN.Add(stdlModel);

                        STUDENT_DETAILS stdlDetials = new STUDENT_DETAILS()
                        {
                            SD_STDL_ID = stdlModel.STDL_ID,
                            STD_ADDRESS = model.STD_ADDRESS,
                            STD_DATE_OF_BIRTH = model.STD_DATE_OF_BIRTH,
                            STD_EMAIL = model.STD_EMAIL,
                            STD_PHONE = model.STD_PHONE,
                        };
                        connection.STUDENT_DETAILS.Add(stdlDetials);
                        connection.SaveChanges();
                        return stdlModel.STDL_ID;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -2;
                }
            }
        }

        public List<STUDENT_LOGIN_MODEL> GetAllUnRegisteredStudents()
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                var result = connection.STUDENT_LOGIN
                    .Where(check => !connection.REGISTRATIONs
                    .Select(reCheck => reCheck.REG_STDL_ID)
                    .Contains(check.STDL_ID))
                    .Select(model => new STUDENT_LOGIN_MODEL()
                {
                    STDL_ID = model.STDL_ID,
                    STDL_NAME = model.STDL_NAME,
                    STDL_PASSWORD = model.STDL_PASSWORD,
                    STDL_PROFILE = model.STDL_PROFILE,
                }).ToList();
                return result;
            }
        }

        public List<REGISTRATION_MODEL> GetAllRegistrationList()
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                var result = connection.REGISTRATIONs.Select(model => new REGISTRATION_MODEL()
                {
                    REG_ID = model.REG_ID,
                    REG_CR_ID = model.REG_CR_ID,
                    REG_DATE = model.REG_DATE,
                    REG_STDL_ID = model.REG_STDL_ID,
                }).ToList();
                return result;
            }
        }

        public List<VW_SHOW_STUDENTS_ALL_DATA_MODEL> GetAllStudentData()
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                var result = connection.VW_SHOW_STUDENTS_ALL_DATA.Select(model => new VW_SHOW_STUDENTS_ALL_DATA_MODEL()
                {
                    STDL_ID = model.STDL_ID,
                    SD_STDL_ID = model.SD_STDL_ID,
                    STDL_NAME = model.STDL_NAME,
                    STDL_PASSWORD = model.STDL_PASSWORD,
                    STDL_PROFILE = model.STDL_PROFILE,
                    STD_ADDRESS = model.STD_ADDRESS,
                    STD_DATE_OF_BIRTH = model.STD_DATE_OF_BIRTH,
                    STD_EMAIL = model.STD_EMAIL,
                    STD_PHONE = model.STD_PHONE,
                    REG_ID = model.REG_ID,
                    REG_CR_ID = model.REG_CR_ID,
                    REG_DATE = model.REG_DATE,
                    REG_STDL_ID = model.REG_STDL_ID,
                }).ToList();
                return result;
            }
        }

        public int AddRegisterStudent(REGISTRATION_MODEL regesteration)
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                REGISTRATION res = new REGISTRATION()
                {
                    REG_ID = regesteration.REG_ID,
                    REG_CR_ID = regesteration.REG_CR_ID,
                    REG_DATE = DateTime.Now,
                    REG_STDL_ID = regesteration.REG_STDL_ID
                };
                connection.REGISTRATIONs.Add(res);
                connection.SaveChanges();
                return res.REG_ID;
            }
        }

        #endregion

        #region Staff DB Handler

        public List<VW_SHOW_STAFF_ALL_DETIALS_MODEL> GetAllStaff()
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                var result = connection.VW_SHOW_STAFF_ALL_DETIALS
                    .Select(model => new VW_SHOW_STAFF_ALL_DETIALS_MODEL()
                {
                    STF_ID = model.STF_ID,
                    STF_NAME = model.STF_NAME,
                    STF_PASSWORD = model.STF_PASSWORD,
                    STF_PROFILE = model.STF_PROFILE,
                    STFD_ID = model.STFD_ID,
                    STFD_ADDRESS = model.STFD_ADDRESS,
                    STFD_DATE_OF_BIRTH = model.STFD_DATE_OF_BIRTH,
                    STFD_EDUCATION = model.STFD_EDUCATION,
                    STFD_EMAIL = model.STFD_EMAIL,
                    STFD_PHONE = model.STFD_PHONE,
                    STFD_SALARY = model.STFD_SALARY,
                }).ToList();
                return result;
            }
        }

        public int AddStaff(VW_SHOW_STAFF_ALL_DETIALS_MODEL model)
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                //image extracting
                DBHelperMethods dBHelperMethods = DBHelperMethods.GetDBHandler();

                string filename = dBHelperMethods.FileName(model.ImageFile);
                string extension = dBHelperMethods.FileExtension(model.ImageFile);
                int length = dBHelperMethods.FileLength(model.ImageFile);

                if (dBHelperMethods.CheckFileExtension(extension))
                {
                    if (dBHelperMethods.CheckFileLength(length))
                    {
                        filename = filename + extension;
                        STAFF_LOGIN stflModel = new STAFF_LOGIN()
                        {
                            STF_PROFILE = "~/Images/" + filename,
                            STF_ID = model.STF_ID,
                            STF_NAME = model.STF_NAME,
                            STF_PASSWORD = model.STF_PASSWORD,
                        };
                        connection.STAFF_LOGIN.Add(stflModel);
                        STAFF_DETAILS stfdModel = new STAFF_DETAILS()
                        {
                            STFD_ID = stflModel.STF_ID,
                            STFD_ADDRESS = model.STFD_ADDRESS,
                            STFD_DATE_OF_BIRTH = model.STFD_DATE_OF_BIRTH,
                            STFD_EDUCATION = model.STFD_EDUCATION,
                            STFD_EMAIL = model.STFD_EMAIL,
                            STFD_PHONE = model.STFD_PHONE,
                            STFD_SALARY = model.STFD_SALARY,
                        };
                        connection.STAFF_DETAILS.Add(stfdModel);
                        connection.SaveChanges();
                        return stflModel.STF_ID;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return -2;
                }
            }
        }

        public List<VW_SHOW_STAFF_ALL_DETIALS_MODEL> GetAllUnAssignedStaff()
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                var result = connection.VW_SHOW_STAFF_ALL_DETIALS
                    .Where(check => !connection.ASSIGNEDs
                    .Select(reCheck => reCheck.ASI_STFL_ID)
                    .Contains(check.STF_ID))
                    .Select(model => new VW_SHOW_STAFF_ALL_DETIALS_MODEL()
                {
                    STF_ID = model.STF_ID,
                    STF_NAME = model.STF_NAME,
                    STF_PASSWORD = model.STF_PASSWORD,
                    STF_PROFILE = model.STF_PROFILE,
                    STFD_ID = model.STFD_ID,
                    STFD_ADDRESS = model.STFD_ADDRESS,
                    STFD_DATE_OF_BIRTH = model.STFD_DATE_OF_BIRTH,
                    STFD_EDUCATION = model.STFD_EDUCATION,
                    STFD_EMAIL = model.STFD_EMAIL,
                    STFD_PHONE = model.STFD_PHONE,
                    STFD_SALARY = model.STFD_SALARY,
                }).ToList();
                return result;
            }
        }
        public int AddAssignedStaff(ASSIGNED_MODEL model)
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                ASSIGNED assinedModel = new ASSIGNED()
                {
                    ASI_ID = model.ASI_ID,
                    ASI_CR_ID = model.ASI_CR_ID,
                    ASI_DATE = DateTime.Now,
                    ASI_STFL_ID = model.ASI_STFL_ID,
                };
                connection.ASSIGNEDs.Add(assinedModel);
                connection.SaveChanges();
                return assinedModel.ASI_ID;
            }
        }

        public List<VW_SHOW_STAFF_ALL_DATA_MODEL> GetAllAssigend()
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                var result = connection.VW_SHOW_STAFF_ALL_DATA.Select(model => new VW_SHOW_STAFF_ALL_DATA_MODEL()
                {
                    ASI_ID = model.ASI_ID,
                    ASI_CR_ID = model.ASI_CR_ID,
                    ASI_DATE = model.ASI_DATE,
                    ASI_STFL_ID = model.ASI_STFL_ID,
                    STF_ID = model.STF_ID,
                    STF_NAME = model.STF_NAME,
                    STF_PASSWORD = model.STF_PASSWORD,
                    STF_PROFILE = model.STF_PROFILE,
                    STFD_ID = model.STFD_ID,
                    STFD_ADDRESS = model.STFD_ADDRESS,
                    STFD_DATE_OF_BIRTH = model.STFD_DATE_OF_BIRTH,
                    STFD_EDUCATION = model.STFD_EDUCATION,
                    STFD_EMAIL = model.STFD_EMAIL,
                    STFD_PHONE = model.STFD_PHONE,
                    STFD_SALARY = model.STFD_SALARY,
                }).ToList();
                return result;
            }
        }

        #endregion

        #region Exibition

        public int AddExibition(EXIBITION_MODEL exibitionModel)
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                EXIBITION exe = new EXIBITION()
                {
                    EXB_ID = exibitionModel.EXB_ID,
                    EXB_NAME = exibitionModel.EXB_NAME,
                    EXB_START_DATE = exibitionModel.EXB_START_DATE,
                    EXB_END_DATE = exibitionModel.EXB_END_DATE
                };
                connection.EXIBITIONs.Add(exe);
                connection.SaveChanges();
                return exe.EXB_ID;
            }
        }

        public List<EXIBITION_MODEL> GetAllExibition()
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                var result = connection.EXIBITIONs.Select(model => new EXIBITION_MODEL()
                {
                    EXB_ID=model.EXB_ID,
                    EXB_END_DATE=model.EXB_END_DATE,
                    EXB_START_DATE=model.EXB_START_DATE,
                    EXB_NAME=model.EXB_NAME,
                }).ToList();
                return result;
            }
        }

        public List<VW_SHOW_RESULT_ALL_DATA_MODEL> GetAllEligibleStudentList()
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                var result = connection.VW_SHOW_RESULT_ALL_DATA
                    .Where(check => check.RES_IS_ELIGIBLE == true)
                    .Select(modelItem => new VW_SHOW_RESULT_ALL_DATA_MODEL()
                    {
                        RES_ID = modelItem.RES_ID,
                        COM_NAME = modelItem.COM_NAME,
                        RES_DATE = modelItem.RES_DATE,
                        RES_GRADE = modelItem.RES_GRADE,
                        RES_IS_ELIGIBLE = modelItem.RES_IS_ELIGIBLE,
                        RES_MARKS = modelItem.RES_MARKS,
                        RES_WORK_ID = modelItem.RES_WORK_ID,
                        STDL_ID = modelItem.STDL_ID,
                        STDL_NAME = modelItem.STDL_NAME,
                        WOC_WORK = modelItem.WOC_WORK
                    }).ToList();

                return result;
            }
        }

        public int AddExibitionEntries(int exeId,int id,EXIBITION_ENTRIES_MODEL exee)
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                int regId = connection.REGISTRATIONs.Where(x => x.REG_STDL_ID == id).FirstOrDefault().REG_ID;
                EXIBITION_ENTRIES exeModel = new EXIBITION_ENTRIES()
                {
                    EXB_EN_RES_ID = regId,
                    EXB_EN_EXB_ID = exeId,
                    PRICE = exee.PRICE,
                };
                connection.EXIBITION_ENTRIES.Add(exeModel);
                int check = connection.SaveChanges();
                return check;
            }
        }

        public List<VW_SHOW_ALL_EXIBITION_DATA_MODEL> GetAllExibitionItemData(int exeId)
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                var result = connection.VW_SHOW_ALL_EXIBITION_DATA
                    .Where(check => check.EXB_ID == exeId)
                    .Select(modelItem => new VW_SHOW_ALL_EXIBITION_DATA_MODEL()
                    {
                        EXB_ID = modelItem.EXB_ID,
                        EXB_NAME = modelItem.EXB_NAME,
                        EXB_START_DATE = modelItem.EXB_START_DATE,
                        EXB_END_DATE = modelItem.EXB_END_DATE,
                        PRICE = modelItem.PRICE,
                        STDL_NAME = modelItem.STDL_NAME,
                        STD_EMAIL = modelItem.STD_EMAIL,
                        STDL_PROFILE = modelItem.STDL_PROFILE,
                        WOC_WORK = modelItem.WOC_WORK,
                        EXB_EN_EXB_ID = modelItem.EXB_EN_EXB_ID,
                        EXB_EN_RES_ID = modelItem.EXB_EN_EXB_ID
                    }).ToList();

                return result;
            }
        }
        #endregion
    }
}
