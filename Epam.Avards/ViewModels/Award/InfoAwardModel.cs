using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Epam.Awards.ViewModels.Award
{
    public class InfoAwardModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Введите название")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Максимальная длина названия 50 символов")]
        [RegularExpression("([A-Za-z0-9 -]+)", ErrorMessage = "только латинские символы, цифры, пробелы и дефисы")]
        public string Title { get; set; }
        [StringLength(250, MinimumLength = 1, ErrorMessage = "Максимальная длина описания 250 символов")]
        public string Description { get; set; }
    }
}