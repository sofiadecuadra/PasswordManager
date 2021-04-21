using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorPasswordsDominio
{
    public class UserPasswordPair
    {
        public string Password { get; set; }
        public string Username
        {
            get { return Username; }
            set { Username = value.ToLower(); }
        }
        public string Site
        {
            get { return Site; }
            set { Site = value.ToLower(); }
        }
        public string Notes { get; set; }
    }
}
