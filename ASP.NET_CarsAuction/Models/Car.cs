using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace ASP.NET_CarsAuction.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите название автомобиля")]
        [Display(Name = "Название автомобиля")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите краткое описание")]
        [Display(Name = "Короткое описание")]
        public string ShortDesc { get; set; }

        [Display(Name = "Длинное описание")]
        public string LongDesc { get; set; }

        [Required(ErrorMessage = "Укажите цену автомобиля")]
        [Range(0,1000000000)]
        [Display(Name = "Текущая ставка")]
        [DataType(DataType.Currency)]
        public int Price { get; set; }

        [Required(ErrorMessage = "Укажите путь к изображению")]
        [Display(Name = "Путь к изображению")]
        public string Img { get; set; }

        [Required(ErrorMessage = "Укажите категорию авто")]
        [Display(Name = "Категория авто(1-седан 2-купе 3-универсал)")]
        public int? CategoryId { get; set; }
        public virtual Category Categoty { get; set; }
        public bool IsCheck { get; set; }
        public DateTime DateTimeLot { get; set; }
        public string UserName { get; set; }
        public Car()
        { 
            DateTimeLot = DateTime.Now;
            IsCheck = false;
        }
    }
}