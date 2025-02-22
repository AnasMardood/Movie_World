using System.ComponentModel.DataAnnotations;

namespace FilmCity98.ViewModels
{
    public class RoleFormViewModel
    {
        [Required, StringLength(256)]
        public string Name { get; set; }
    }
}