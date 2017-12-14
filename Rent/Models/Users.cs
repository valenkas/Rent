using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Rent.Models
{
    public class Users
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Это поле не может быть пустым")]
        [DisplayName("Логин")]
        public string UserLogin { get; set; }


        [DataType("Password")]
        [Required(ErrorMessage = "Это поле не может быть пустым")]
        [DisplayName("Пароль")]
        public string UserPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("UserPassword", ErrorMessage ="Введённые данные не совпадают в данными в поле 'Пароль'")]
        [Required(ErrorMessage = "Это поле не может быть пустым")]
        [DisplayName("Повторите ввод пароля")]
        public string UserConfirmPassword { get; set; }

        [Required(ErrorMessage = "Это поле не может быть пустым")]
        [DisplayName("Имя")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Это поле не может быть пустым")]
        [DisplayName("Фамилия")]
        public string UserSurname { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Это поле не может быть пустым")]
        [DisplayName("Номер телефона")]
        public string UserTelephoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("Email")]
        public string UserEmail { get; set; }
    }
}