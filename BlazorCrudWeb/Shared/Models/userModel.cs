using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorCrudWeb.Shared.Models
{
    public class userModel
    {
        public String UserName { get; set; }
        public String Password { get; set; }
        public String PasswordRepeat { get; set; }
        public String Email { get; set; }
        public bool Agreement { get; set; }
    }
}
