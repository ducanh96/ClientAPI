using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientAPI.Models
{
    public class ResponsePrize
    {
        public int code { get; set; }
        public ViewModelPrize data { get; set; }
    }
}