using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClientAPI.Models
{
    public class ResponseStatiscal
    {
        public int code { get; set; }
        public List<ViewModelStatiscal> data { get; set; }
    }
}