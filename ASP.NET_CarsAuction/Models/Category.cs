using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.NET_CarsAuction.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите название категории")]
        [Display(Name = "Категория автомобиля")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите краткое описание")]
        [Display(Name = "Короткое описание")]
        public string Desc { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public Category()
        {
            Cars = new List<Car>();
        }
    }
}