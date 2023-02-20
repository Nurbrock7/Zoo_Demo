namespace Zoo_App.Models
{
    public class UpdateAnimalViewModel
    {
        internal Guid id;


        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Colour { get; set; }
        public string Species { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
