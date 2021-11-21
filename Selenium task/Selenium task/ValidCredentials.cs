using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenQA.Selenium; // This is Selenium namespace using OpenQA.Selenium.Chrome;//Use this namespace when you are automating in google chrome using System.Threading; 
using OpenQA.Selenium.Support.UI;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;
using System.IO;
using OfficeOpenXml;

namespace Selenium_task
{

    class ValidCredentials
    {
        private string userName;
        private string password;
        private string url;


        public string getUrl()
        {
            return url;
        }

        public string getUser()
        {
            return userName;
        }

        public string getPassword()
        {
            return password;
        }

        public void setUserPassword()
        {
            string path = "data.xlsx";
            FileInfo fileInfo = new FileInfo(path);

            ExcelPackage package = new ExcelPackage(fileInfo);
            ExcelWorksheet worksheet = package.Workbook.Worksheets.FirstOrDefault();

            // get number of rows and columns in the sheet
            int rows = worksheet.Dimension.Rows; 
            int columns = worksheet.Dimension.Columns;


            string contentOfUrl = worksheet.Cells[2, 1].Value.ToString();
            this.url = contentOfUrl;
            string contentOfUser = worksheet.Cells[2, 2].Value.ToString();
            this.userName = contentOfUser;
            string contentOfPass = worksheet.Cells[2, 3].Value.ToString();
            this.password = contentOfPass;


        }
    }


}
