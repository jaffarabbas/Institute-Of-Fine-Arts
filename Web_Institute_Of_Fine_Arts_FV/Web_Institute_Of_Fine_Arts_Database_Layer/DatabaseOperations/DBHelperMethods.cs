using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Web_Institute_Of_Fine_Arts_Database_Layer.DatabaseOperations
{
    public class DBHelperMethods
    {
        #region Singleton Methods

        private static DBHelperMethods DBHandler = new DBHelperMethods();
        private DBHelperMethods() { }
        public static DBHelperMethods GetDBHandler()
        {
            return DBHandler;
        }

        #endregion

        //method to check file extension
        public bool CheckFileExtension(string extension)
        {
            return (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png");
        }
        //method to check file length
        public bool CheckFileLength(int length)
        {
            return (length <= 1000000);
        }
        //file name
        public string FileName(HttpPostedFileBase ImageFile)
        {
            return Path.GetFileNameWithoutExtension(ImageFile.FileName);
        }
        //file extention
        public string FileExtension(HttpPostedFileBase ImageFile)
        {
            return Path.GetExtension(ImageFile.FileName);
        }
        //file length
        public int FileLength(HttpPostedFileBase ImageFile)
        {
            return ImageFile.ContentLength;
        }
        //non zero id
        public int GetId(int id)
        {
            return id == 0 ? 1 : id;
        }
        //asign grade result
        public string AssignGrade(int marks)
        {
            if (marks <= 100 && marks >= 90)
            {
                return "A+";
            }
            else if (marks <= 89 && marks >= 76)
            {
                return "A";
            }
            else if (marks <= 75 && marks >= 66)
            {
                return "B";
            }
            else if (marks <= 65 && marks >= 56)
            {
                return "C";
            }
            else
            {
                return "F";
            }
        }
        //is eligible for exibition
        public bool IsEligible(string grade)
        {
            return grade == "A+";
        }
    }
}
