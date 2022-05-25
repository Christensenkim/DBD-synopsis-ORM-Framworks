using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MockData
{
    public class MockProduct
    {
        public List<string> fornavne = new List<string>();
        public List<string> efternavne = new List<string>();
        public List<string> category = new List<string>();

        public MockProduct()
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

            category.Add("Tech Guy");
            category.Add("Social Master");
            category.Add("Coding Genius");
            category.Add("SuperMario Expert");
            category.Add("Cleaning Connoisseur");
        }

        public string MockProductsName()
        {
            var random = new Random();
            var fornavnIndex = random.Next(fornavne.Count);
            var efternavnIndex = random.Next(efternavne.Count);

            var result = fornavne[fornavnIndex] + efternavne[efternavnIndex];
            return result;
        }

        public string MockProductsCategory()
        {
            var random = new Random();
            var categoryIndex = random.Next(category.Count);

            return category[categoryIndex];
        }

        public bool MockProductsDiscontinued()
        {
            var discontinued = new Random().Next(100) <= 50;
            return discontinued;
        }
    }
}
