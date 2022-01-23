using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Institute_Of_Fine_Arts_Database_Models;

namespace Web_Institute_Of_Fine_Arts_Database_Layer.DatabaseOperations
{
    public class StudentDBHandler 
    {
        #region Singleton Methods

        private static StudentDBHandler DBHandler = new StudentDBHandler();
        private StudentDBHandler() { }
        public static StudentDBHandler GetDBHandler()
        {
            return DBHandler;
        }

        #endregion

        public int RandomKey()
        {
            //check if work table is empty
            using(var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                if (!connection.WORK_OF_COMPITITION.Any())
                {
                    return 1;
                }
                else
                {
                    //generate a int value with max(value) + 1
                    return connection.WORK_OF_COMPITITION.Max(model => model.WOC_ID) + 1;
                }
            }
        }
        #region Compitition Controllers
        public List<VW_SHOW_COMPITITION_DETAILS_TO_STUDENTS_MODEL> GetCompitionList(int id)
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                var result = connection.VW_SHOW_COMPITITION_DETAILS_TO_STUDENTS
                    .Where(x => x.CR_ID == connection.REGISTRATIONs.Where(check => check.REG_STDL_ID == id).FirstOrDefault().REG_CR_ID)
                    .Select(mainList => new VW_SHOW_COMPITITION_DETAILS_TO_STUDENTS_MODEL()
                    {
                        COM_ID = mainList.COM_ID,
                        STF_NAME = mainList.STF_NAME,
                        CR_NAME = mainList.CR_NAME,
                        COM_STF_ID = mainList.COM_STF_ID,
                        CR_ID = mainList.CR_ID,
                        COM_START_DATE = mainList.COM_START_DATE,
                        COM_END_DATE = mainList.COM_END_DATE,
                        COM_NAME = mainList.COM_NAME,
                    }).ToList();

                             
                return result;
            }
        }

        public int InsertWorkCompition(int id,int comId,WORK_OF_COMPITITION_MODEL model)
        {
            using(var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                //get registraion id
                int RegId = Convert.ToInt32(connection.REGISTRATIONs.Where(x => x.REG_STDL_ID == id).FirstOrDefault().REG_ID);
                bool checkStudentSubmission = connection.WORK_OF_COMPITITION.Any(x => x.WOC_REG_ID == RegId);

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
                        WORK_OF_COMPITITION workCom = new WORK_OF_COMPITITION();
                        workCom.WOC_WORK = "~/Images/" + filename;
                        workCom.WOC_REG_ID = RegId;
                        workCom.WOC_COM_ID = Convert.ToInt32(comId);
                        if (!checkStudentSubmission)
                        {
                            workCom.WOC_ID = RandomKey();
                            connection.WORK_OF_COMPITITION.Add(workCom);
                        }
                        else
                        {
                            //linq query to upadte the image link
                            var data = (from woc in connection.WORK_OF_COMPITITION where woc.WOC_REG_ID == RegId select woc).SingleOrDefault();
                            if (data != null)
                            {
                                data.WOC_WORK = "~/Images/" + filename;
                            }
                        }
                        connection.SaveChanges();
                        return dBHelperMethods.GetId(workCom.WOC_ID);
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
        #endregion
    }
}
