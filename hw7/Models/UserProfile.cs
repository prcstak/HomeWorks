using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;

namespace dotnet_practice10_26.Models
{
    public class UserProfile
    {
        [StringLength( 10, MinimumLength = 2,ErrorMessage = "Необходимо ввести реальное имя")]
        [Display(Name="Имя")]
        public string FirstName { get; set; }
        
        [StringLength( 10, MinimumLength = 2,ErrorMessage = "Необходимо ввести реальную фамилию")]
        public string LastName { get; set; }
        
        [Range(0, 10000, ErrorMessage = "Возраст не меньше 0 лет")]
        [Display(Name = "Возраст")]
        public int Age { get; set; }
        
        [Display(Name = "Пол")]
        public Sex NoSex { get; set; }
        
    }

    public enum Sex
    {
        None,
        Male,
        Female
    }
    
}
