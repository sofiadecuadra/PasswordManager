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

        private string Username_;
        public string Username
        {
            get { return Username_; }
            set {
                this.LastModifiedDate = DateTime.Now;
                Username_ = value.ToLower(); 
            }
        }
        private string Site_;
        public string Site
        {
            get { return Site_; }
            set { Site_ = value.ToLower(); }
        }
        public string Notes { get; set; }

        public DateTime LastModifiedDate { get; private set; }
    }
}