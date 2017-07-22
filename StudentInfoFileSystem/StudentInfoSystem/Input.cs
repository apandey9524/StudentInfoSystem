using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace StudentInfoSystem
{
    public class Input
    {
        #region Get Numerical Choice for Main Menu
        private int GetChoice()
        {
            const int menuOptions = 4;  // if in future menu items are added only this needs to be updated to check value of numerical choice input
            int NumericalChoice;
            Console.WriteLine("\nEnter a numerical choice " +
                                "\t\n1.Add a Student's record"+
                                "\t\n2.View a Student's Record"+
                                "\t\n3.View All Records" +
                                "\t\n4.Exit");

            if (!Int32.TryParse(Console.ReadLine(),out NumericalChoice)&&(NumericalChoice>0&&NumericalChoice<=menuOptions))
            {
                NumericalChoice=GetChoice();
            }
            return NumericalChoice;
        }
        #endregion
        #region Validation methods      
        string GetValidEmail()
        {
            string email=Console.ReadLine();
            if(!Regex.IsMatch(email, @"^[a-zA-Z0-9]+@[a-zA-Z0-9]+\.[a-z]{2,3}$"))
            {
                Console.WriteLine("Invalid Input Try Again");
                email = GetValidEmail();
            }
            return email;
        }
        string GetValidMobileNumber()
        {
            string result=string.Empty;
            string number = Console.ReadLine();
            if (!Regex.IsMatch(number, "^[0-9]{10}$"))
            {
                Console.WriteLine("Invalid Input Try Again");
                result = GetValidMobileNumber();
            }
            return result;
        }
        DateTime GetValidDOB()
        {
            DateTime result ;
            string DOB = Console.ReadLine();
            if (!DateTime.TryParse(DOB,out result))
            {
                Console.WriteLine("Invalid Input Try Again");
                result = GetValidDOB();
            }
            return result;
        }
        


        #endregion
        #region Add Show Update Record Methods
        StudentDataStore AddNewStudentRecord()
        {
            StudentDataStore studentdata = new StudentDataStore();

            Console.WriteLine("Enter Student First Name");
            studentdata.firstName = Console.ReadLine();
            Console.WriteLine("Enter Student Last Name");
            studentdata.lastName = Console.ReadLine();
            Console.WriteLine("Enter Student Email");
            studentdata.emailID = GetValidEmail();
            Console.WriteLine("Enter Mobile Number");
            studentdata.phone = GetValidMobileNumber();
            Console.WriteLine("Enter Student Address");
            studentdata.address = Console.ReadLine();
            Console.WriteLine("Enter Current Course Name");
            studentdata.currentCourse = Console.ReadLine();
            Console.WriteLine("Enter Mentors Name");
            studentdata.mentorName = Console.ReadLine();
            Console.WriteLine("Enter Emergency Contact Number");
            studentdata.EmergencyContact = GetValidMobileNumber();
            studentdata.userID = studentdata.firstName[0]+ studentdata.lastName[0]+studentdata.phone;
            Console.WriteLine("!------------!!----Please Note your Student ID"+studentdata.userID+"----!------------!!");
            return studentdata;
        }
        void ShowStudentRecord(String result)
        {
            
            Console.WriteLine(result);
            Console.WriteLine("---------------------------------------------");
        }
#endregion
        #region Main Menu
        public void menu()
        {
            FileOperations fileoperationsobject = new FileOperations();
            switch(this.GetChoice())
            {
                case 1:fileoperationsobject.StoreToFile( this.AddNewStudentRecord());
                    break;

                case 2:Console.WriteLine("Enter Student ID");
                    string userid = Console.ReadLine();
                    if (File.Exists(FileOperations.DirPath + @"\" + userid+".txt"))
                    {
                        ShowStudentRecord(fileoperationsobject.ReadFromFile(userid).displayobject());
                    }
                    else
                    {
                        Console.WriteLine("No student is registered with given user ID");
                        
                    }
                    
                    break;

                case 3:
                    foreach (string file in Directory.GetFiles(FileOperations.DirPath))
                    {
                        fileoperationsobject.ReadFromFileFromCompletePath(file);
                        
                    }
                    break;

                case 4:Environment.Exit(0);
                    break;

                default:Console.WriteLine("Invalid Choice!");menu();break;

            }
            menu();
        }
#endregion
    }
}
