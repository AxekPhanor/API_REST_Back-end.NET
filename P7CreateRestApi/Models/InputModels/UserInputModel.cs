using System.ComponentModel.DataAnnotations;

namespace P7CreateRestApi.Models.InputModels
{
    public class UserInputModel
    {
        [Required(ErrorMessage = "Le champs UserName est requis")]
        [MinLength(4)]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Le champs Password est requis")]
        [MinLength(8)]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^\w\d\s]).*$")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Le champs FullName est requis")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Le champs Role est requis")]
        [RegularExpression("^(Admin|User)$", ErrorMessage = "Le rôle doit être 'Admin' ou 'User'")]
        public string Role { get; set; }
    }
}
