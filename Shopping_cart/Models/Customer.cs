using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Shopping_cart.Models.Databases;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shopping_cart.Models
{
    public class Customer : ICustomer
    {
        Dbcontextr db ;
        public Customer(Dbcontextr db)
        {
            this.db = db;
        }

        public void CreateID(string id)
        {
           
            Customer newCustomer = new Customer(db)
            {
                Id = id,
                Total = 0,
            };


            db.Add(newCustomer);

            db.SaveChanges();

        }
    

        public string GetID(string id)
        {
           
            Customer dd = db.Customer.FirstOrDefault(w => w.Id == id);
            if (dd == null)
            {
             
                CreateID(id);
            }
            return id;
        }

        public double GetTotal(string id)
        {
            Customer dd = db.Customer.FirstOrDefault(w => w.Id == id);
            if (dd == null)
            {

                CreateID(id);
                dd = db.Customer.FirstOrDefault(w => w.Id == id);
            }
            return dd.Total;
        }

        public void SaveChanges(string id, double total)
        {
            Customer dd = db.Customer.FirstOrDefault(w => w.Id == id);
            dd.Total += total;
            db.SaveChanges();
        }

         [DatabaseGenerated(DatabaseGeneratedOption.None)]
       
        public string Id { get; set; }
        public double Total { get; set; }

        public List<Food> FoodID;
    }
}






