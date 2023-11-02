using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExamenApi.Models.Util
{
    public class ResultSet
    {
        public bool IsError { get; set; }
        public Exception Error { get; set; }
    }
}