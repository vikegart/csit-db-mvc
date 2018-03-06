using Epam.Avards.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Epam.Awards.ViewModels.User
{
    public class NewUserModel
    {
        [Required(ErrorMessage = "Введите имя")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Максимальная длина логина 50 символов")]
        [RegularExpression("(^[а-яА-ЯёЁa-zA-Z0-9_]+$)", ErrorMessage = "латиница кириллица")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataAttrValidator]
        [Required(ErrorMessage = "Установите дату")]
        public DateTime Birthdate { get; set; }
    }
}