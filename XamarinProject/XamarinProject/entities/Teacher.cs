using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XamarinProject.entities
{
    [Table("Teachers")]
    public class Teacher
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        [MaxLength(50), Unique]
        public string userName { get; set; }
        [MaxLength(250)]
        public string password { get; set; }

        public Teacher()
        {
        }

        public Teacher(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }
    }
}
