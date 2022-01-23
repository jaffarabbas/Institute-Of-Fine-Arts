using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web_Institute_Of_Fine_Arts_Database_Models;

namespace Web_Institute_Of_Fine_Arts_Database_Layer.DatabaseOperations
{
    public class LoginDBHandler
    {
        #region Singleton Methods

        private static LoginDBHandler DBHandler = new LoginDBHandler();
        private LoginDBHandler() { }
        public static LoginDBHandler GetDBHandler()
        {
            return DBHandler;
        }

        #endregion

        #region Admin Login Handler
        public ADMIN_LOGIN_MODEL AdminLoginHandler(ADMIN_LOGIN_MODEL adminLogin)
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                //linq query
                var result = connection.ADMIN_LOGIN.Where(a => a.AD_NAME.Equals(adminLogin.AD_NAME) && a.AD_PASSWORD.Equals(adminLogin.AD_PASSWORD)).Select(model => new ADMIN_LOGIN_MODEL
                {
                    AD_ID = model.AD_ID,
                    AD_NAME = model.AD_NAME,
                    AD_PROFILE = model.AD_PROFILE,
                }).FirstOrDefault();
                return result;
            }
        }
        #endregion

        #region Student Login Handler
        public STUDENT_LOGIN_MODEL StudentLoginHandler(STUDENT_LOGIN_MODEL studentLogin)
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                var result = connection.STUDENT_LOGIN.Where(a => a.STDL_NAME.Equals(studentLogin.STDL_NAME) && a.STDL_PASSWORD.Equals(studentLogin.STDL_PASSWORD)).Select(model => new STUDENT_LOGIN_MODEL
                {
                    STDL_ID = model.STDL_ID,
                    STDL_NAME = model.STDL_NAME,
                    STDL_PROFILE = model.STDL_PROFILE,
                }).FirstOrDefault();
                return result;
            }
        }
        #endregion

        #region Staff Login Handler
        public STAFF_LOGIN_MODEL StaffLoginHandler(STAFF_LOGIN_MODEL staffLogin)
        {
            using (var connection = new DB_INSTITUTE_OF_FINE_ARTSEntities())
            {
                var result = connection.STAFF_LOGIN.Where(a => a.STF_NAME.Equals(staffLogin.STF_NAME) && a.STF_PASSWORD.Equals(staffLogin.STF_PASSWORD)).Select(model => new STAFF_LOGIN_MODEL
                {
                    STF_ID = model.STF_ID,
                    STF_NAME = model.STF_NAME,
                    STF_PROFILE = model.STF_PROFILE,
                }).FirstOrDefault();
                return result;
            }
        }
        #endregion
    }
}
