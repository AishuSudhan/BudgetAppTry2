using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetAppTry2.Models
{
    
    

        public enum IconCategory
        {
            Entertainment,
            Tuition,
            Insurance,
            Utility,
            Medical
        }
    internal class ExpenseCategoryIcon
    {

        public IconCategory Iconcategory { get; set; }
        public string ImageFile { get; set; }

        public string Name { get; set; }
        public string Filename { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
       /* public ExpenseCategoryIcon(string text,IconCategory category)
            {
            Text = text;
            Iconcategory = category;
            ImageFile = $"Resources/drawable/{category}.png";
            
            }*/
        }

    }




    

