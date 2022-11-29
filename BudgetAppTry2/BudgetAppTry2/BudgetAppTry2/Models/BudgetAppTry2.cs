using System;
using System.Collections.Generic;
using System.Text;


namespace BudgetAppTry2.Models
{
   
    public class BudgetAppTry
    {
        public string Name { get; set; }
        public string Amount { get; set; }
        public DateTime Date { get; set; }
        public string BudgetAmount { get; set; }
        public string FileName { get; set; }

        public string BudgetIcon { get; set; }

       //public string Filename { get; set; }
      /*  public IconCategory Iconcategory { get; set; }
        public string ImageFile { get; set; }
        public BudgetAppTry(string file,IconCategory iconCategory)
        {
            Filename = file;
            Iconcategory = iconCategory;
            ImageFile = $"Assets/{iconCategory}.png";

        }*/
    }
    
}
