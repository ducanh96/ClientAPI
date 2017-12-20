using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientAPI.Models
{
    /// <summary>
    /// lop co du lieu json cac giai la list string
    /// </summary>
    public class ViewModelPrize
    {
        public string LottezyId { get; set; }
        public string LottezyName { get; set; }
        public string date { get; set; }
        public List<string> FirstPrize { get; set; }
        public List<string> SecondPrize { get; set; }
        public List<string> ThirdPrize { get; set; }
        public List<string> FourthPrize { get; set; }
        public List<string> FifthPrize { get; set; }
        public List<string> SixthPrize { get; set; }
        public List<string> SeventhPrize { get; set; }
        public List<string> SpecialPrize { get; set; }
        public List<string> First { get; set; }
        public List<string> Second { get; set; }
        public List<string> Third { get; set; }
        public List<string> Fourth { get; set; }
        public List<string> Fifth { get; set; }
        public List<string> Sixth { get; set; }
        public List<string> Seventh { get; set; }
        public List<string> Special { get; set; }


    }
    
}