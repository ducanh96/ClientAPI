using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientAPI.Models
{
    public class ResponseLocationPrize
    {
        public int code { get; set; }
        public List<ViewModelLocationPrize> data { get; set; }
    }
}