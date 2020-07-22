using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralDeErros.Core.Models
{
    public class Profile
    {
        public Profile()
        {
            this.Users = new HashSet<User>();
        }
        public int Id { get; set; }
        public string Type { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
