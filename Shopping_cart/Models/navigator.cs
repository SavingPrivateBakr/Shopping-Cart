namespace Shopping_cart.Models
{
    public class navigator
    {
        public static double Navigation(int id)
        {
            if (id == 0)
            {
                Tuna tuna = new Tuna();
                return tuna.price;
                
            }
            return 0;
        }
    }
}
