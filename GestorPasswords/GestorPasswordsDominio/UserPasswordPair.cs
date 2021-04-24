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

        private string username;
        public string Username
        {
            get { return username; }
            set {
                this.LastModifiedDate = DateTime.Now;
                username = value.ToLower(); 
            }
        }
        private string site;
        public string Site
        {
            get { return site; }
            set { site = value.ToLower(); }
        }
        public string Notes { get; set; }

        public DateTime LastModifiedDate { get; private set; }
    }
}