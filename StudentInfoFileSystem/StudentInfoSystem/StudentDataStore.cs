using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StudentInfoSystem
{
    class StudentDataStore
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string emailID { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
        DateTime DOB { get; set; }
        public string currentCourse { get; set; }
        public string mentorName { get; set; }
        public string userID { get; set; }
        public string EmergencyContact { get; set; }

        public override string ToString()
        {
            
            return JsonConvert.SerializeObject(this);

        }
        public string displayobject()
        {
            string todisplay = this.ToString().Replace("\"", string.Empty);
            todisplay = todisplay.Replace("{",string.Empty);
            todisplay = todisplay.Replace("}", string.Empty);
            return todisplay.Replace(",", "\n");
        }

    }
}
