using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileTestApp.Models
{
    [Table("Users")]
    public class User
    {
        [AutoIncrement, PrimaryKey]
        public int Id {  get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }
}
