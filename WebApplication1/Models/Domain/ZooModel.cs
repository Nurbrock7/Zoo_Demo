using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models.Domain
{
    public class ZooModel
    {
        
        internal Guid id;
        
  
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Colour { get; set; }
        public string Species { get; set; }
        public DateTime DateOfBirth { get; set; }


    }
}
