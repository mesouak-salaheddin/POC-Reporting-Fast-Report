namespace FR_project.Models
{
    public class Commande
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ClientId { get; set; }   
        public int Quantity { get; set; }
        public DateOnly DateCommande { get; set; }

    }
}