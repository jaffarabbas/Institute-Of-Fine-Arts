using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Institute_Of_Fine_Arts_Database_Models;

namespace Web_Institute_Of_Fine_Arts_Database_Layer.DatabaseOperations
{
    public class StaffDBHandler
    {
        #region Singleton Methods

        private static StaffDBHandler DBHandler = new StaffDBHandler();
        private StaffDBHandler() { }
        public static StaffDBHandler GetDBHandler()
        {
            return DBHandler;
        }

        #endregion

        #region Compition db methods
        public int AddCompitition(COMPITITION_MODEL model)
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                if(model.COM_START_DATE.Date < model.COM_END_DATE.Date)
                {
                    COMPITITION com = new COMPITITION()
                    {
                        COM_ID = model.COM_ID,
                        COM_NAME = model.COM_NAME,
                        COM_START_DATE = model.COM_START_DATE,
                        COM_END_DATE = model.COM_END_DATE,
                        COM_STF_ID = model.COM_STF_ID
                    };

                    connection.COMPITITIONs.Add(com);
                    connection.SaveChanges();
                    return com.COM_ID;
                }
                else
                {
                    return -1;
                }
            }
        }

        //get all compition list
        public List<COMPITITION_MODEL> GetAllCompitition(int id)
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                var result = connection.COMPITITIONs
                    .Where(com => com.COM_STF_ID == id)
                    .Select(model => new COMPITITION_MODEL()
                {
                    COM_ID = model.COM_ID,
                    COM_NAME = model.COM_NAME,
                    COM_START_DATE = model.COM_START_DATE,
                    COM_END_DATE = model.COM_END_DATE,
                    COM_STF_ID = model.COM_STF_ID
                }).ToList();
                return result;
            }
        }

        public List<VW_SHOW_COMPITITION_ALL_DATA_MODEL> GetAllPendingWorkCompitition(int id)
        {   
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                var result = connection.VW_SHOW_COMPITITION_ALL_DATA
                    .Where(model => model.COM_ID == id)
                    .Select(com => new VW_SHOW_COMPITITION_ALL_DATA_MODEL()
                {
                    COM_ID = com.COM_ID,
                    COM_NAME = com.COM_NAME,
                    COM_START_DATE= com.COM_START_DATE,
                    COM_END_DATE= com.COM_END_DATE, 
                    COM_STF_ID= com.COM_STF_ID, 
                    STF_ID = com.STF_ID,
                    STF_NAME = com.STF_NAME,
                    STF_PROFILE = com.STF_PROFILE,
                    WOC_COM_ID = com.WOC_COM_ID,
                    WOC_ID = com.WOC_ID,
                    WOC_REG_ID = com.WOC_REG_ID,
                    WOC_WORK = com.WOC_WORK,
                }).ToList();
                return result;
            }
        }

        public List<VW_SHOW_RESULT_ALL_DATA_MODEL> GetAllCompletedWorkCompitition(int id)
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                var result = connection.VW_SHOW_RESULT_ALL_DATA
                    .Where(check => check.RES_ID == connection.RESULTs.Where(rs => rs.RES_COM_ID == id).FirstOrDefault().RES_ID)
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


        #endregion

        #region Result db methods

        public List<VW_SHOW_RESULT_CARD_DETIALS_MODEL> GetAllResult(int id)
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                var result = connection.VW_SHOW_RESULT_CARD_DETIALS
                    .Where(x => x.COM_STF_ID == connection.ASSIGNEDs.Where(check => check.ASI_STFL_ID == id).FirstOrDefault().ASI_STFL_ID)
                    .Select(model => new VW_SHOW_RESULT_CARD_DETIALS_MODEL()
                {
                    RES_ID = model.RES_ID,
                    COM_NAME = model.COM_NAME,
                    COM_ID = model.COM_ID,
                    COM_END_DATE = model.COM_END_DATE,
                    COM_START_DATE = model.COM_START_DATE,
                    COM_STF_ID = model.COM_STF_ID,
                    STF_NAME = model.STF_NAME
                }).ToList();
                return result;
            }
        }

        public int AddResult(int resWorkId, int comId, RESULT_ENTRIES_MODEL resModel)
        {
            DBHelperMethods dBHelperMethods = DBHelperMethods.GetDBHandler();
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                string grade = dBHelperMethods.AssignGrade(resModel.RES_MARKS);
                int resId = connection.RESULTs.Where(x => x.RES_COM_ID == comId).FirstOrDefault().RES_ID;
                RESULT_ENTRIES res = new RESULT_ENTRIES()
                {
                    RES_ID = resId,
                    RES_WORK_ID = resWorkId,
                    RES_DATE = DateTime.Now,
                    RES_GRADE = grade,
                    RES_MARKS = resModel.RES_MARKS,
                    RES_IS_ELIGIBLE = dBHelperMethods.IsEligible(grade),
                };
                connection.RESULT_ENTRIES.Add(res);
                connection.SaveChanges();
                return res.RES_ID;
            }
        }
        #endregion
    }
}
