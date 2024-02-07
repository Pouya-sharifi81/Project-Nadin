using Nadin_Domain.Models.user;
using Nadin_Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nadin_Domain.Models.Pruducts
{
    public class Product
    {
        public Guid productId { get; set; }

        public Guid UserId { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool IsAvailable { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }

        public static Product CreateProduct(Guid userProfileId, string name, string email, string phone, DateTime date
            , bool isAvailible)
        {
            var objectValid = new Product()
            {
                UserId = userProfileId,
                Name = name,
                Email = email,
                Date = date,
                Phone = phone,
                IsAvailable = isAvailible,
            };

            return objectValid;


        }
        public void UpdateProduct(string name , string phone , string email , bool isavailble , DateTime date)
        {
            Name = name;
           Email = email;
           Phone = phone;
            Date = date;
            Phone = phone;
            IsAvailable = isavailble;
        }
    }
}
