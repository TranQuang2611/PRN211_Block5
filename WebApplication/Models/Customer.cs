using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    
    public class Customer
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "This string is empty")]
        public string Code { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "This string is empty")]    
        public string Name { get; set; }

        public int Age { get; set; }

        public Customer()
        {
            
        }

        public Customer(string code, string name, int age)
        {
            Code = code;
            Name = name;
            Age = age;
        }

        public override string ToString()
        {
            return Code + "\t" + Name + "\t" + Age;
        }
    }
}
