using System.ComponentModel.DataAnnotations;

namespace DotNetCoreBoilerplate.Models
{
    public class CustomerDTO
    {
        //[Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string button { get; set; }
    }
}