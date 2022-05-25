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
        private int skillCounter = 0;
        public List<string> fornavne = new List<string>();
        public List<string> efternavne = new List<string>();
        public List<string> category = new List<string>();

        public MockEmployee()
        {
            fornavne.Add("Alfred ");
            fornavne.Add("Oscar ");
            fornavne.Add("Carl ");
            fornavne.Add("Sofia ");
            fornavne.Add("Laura ");

            efternavne.Add("Christensen");
            efternavne.Add("Clausen");
            efternavne.Add("Larsen");
            efternavne.Add("Nielsen");
            efternavne.Add("Jørgensen");
        }

        public string MockEmployeeName()
        {
            var random = new Random();
            var fornavnIndex = random.Next(fornavne.Count);
            var efternavnIndex = random.Next(efternavne.Count);

            var result = fornavne[fornavnIndex] + efternavne[efternavnIndex];
            return result;
        }

        public string MockSkillDescription()
        {
            var stringSkillDescription = "Skill Number " + skillCounter;
            skillCounter++;
            return stringSkillDescription;
        }
    }
}
