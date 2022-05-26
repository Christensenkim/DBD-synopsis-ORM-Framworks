using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockData
{
    public class MockEmployee
    {
        private int skillCounter = 1;
        private int firstNameCounter = 1;
        private int lastNameCounter = 1;
        public List<string> fornavne = new List<string>();
        public List<string> efternavne = new List<string>();
        public List<string> category = new List<string>();

        public MockEmployee()
        {

        }

        public string MockEmployeeFirstName()
        {
            var firstName = "FirstName" + firstNameCounter + " ";
            firstNameCounter++;
            return firstName;
        }

        public string MockEmployeeLastName()
        {
            var lastName = "LastName" + lastNameCounter;
            lastNameCounter++;
            return lastName;
        }

        public string MockSkillDescription()
        {
            var stringSkillDescription = "Skill Number " + skillCounter;
            skillCounter++;
            return stringSkillDescription;
        }
    }
}
