namespace Shopping_cart.Models
{
    public interface ICustomer
    {
        public string GetID(string id);


        public double GetTotal(string id);


        public void CreateID(string id);
        public void SaveChanges(string id, double total);
    


    }
}
