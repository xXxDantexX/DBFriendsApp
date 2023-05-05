using System;
using SQLite;
using System.Collections.Generic;
using System.Text;


namespace DBFriendsApp.Models
{
    [Table("Friends")]
    public class Friend
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDate { get; set; }


        public string Age
        {
            get
            {
                if (BirthDate == default(DateTime))
                {
                    return string.Empty;
                }
                var today = DateTime.Today;
                var age = today.Year - BirthDate.Year;
                if (BirthDate > today.AddYears(-age))
                {
                    age--;
                }
                return age.ToString();
            }
        }
    }
}
