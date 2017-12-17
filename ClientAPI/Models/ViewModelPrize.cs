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

        public ViewModelPrize()
        {

        }
 
    }
    
}