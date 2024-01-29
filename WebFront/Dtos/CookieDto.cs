using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebFront.Dtos
{
    public class CookieDto
    {
        public string? SessionId { get; set; }
        public string? GroupId { get; set; }
        public string? HubConnectionId { get; set; }
    }
}
