using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rent.Models
{
    public class Aparts
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [DisplayName("Тип")]
        [Required(ErrorMessage = "Это поле не может быть пустым")]
        public string ApartType { get; set; }

        [DisplayName("Адрес")]
        [Required(ErrorMessage = "Это поле не может быть пустым")]
        public string ApartAddress { get; set; }

        [DisplayName("Описание")]
        [Required(ErrorMessage = "Это поле не может быть пустым")]
        public string ApartDescription { get; set; }

        [DisplayName("Цена")]
        [Required(ErrorMessage = "Это поле не может быть пустым")]
        public string ApartPrice { get; set; }

        [DisplayName("Площадь")]
        [Required(ErrorMessage = "Это поле не может быть пустым")]
        public string ApartArea { get; set; }


        [DisplayName("Дополнительное описание")]
        public string ApartExtraDescription { get; set; }

        [DisplayName("Ваши контакты")]
        public string UserContacts { get; set; }


        [DisplayName("Изображение")]
        public byte[] ApartImage { get; set; }

        [ScaffoldColumn(false)]
        public int UserId { get; set; }
    }
}