using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class UserInput
    {
       [Required(ErrorMessage = "Обязательное поле")]
       public string UserName { get; set; }
       public int HitPoints { get; set; }
       public int AttackModifier { get; set; }
       public int AttackPerRound { get; set; }
       [RegularExpression("\\d[d](4|6|8|20)", ErrorMessage = "dice types d4/6/8/20")]
       [Required(ErrorMessage = "Обязательное поле")]
       public string Damage { get; set; }
       public int DamageModifier { get; set; }
       public int Weapon { get; set; }
       public int AC { get; set; }
    }
}