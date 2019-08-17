using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TEST_170819.Models
{
    public class FixRequest
    {
        public string UserId { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public DateTime GetDateTime  { get; set; }
        public string CorrelationId { get; set; }
    }
}