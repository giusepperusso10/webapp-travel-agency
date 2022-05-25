using NetCore_01.Utils.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetCore_01.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage="Il campo titolo è obbligatorio")]
        [StringLength(20, ErrorMessage ="Il titolo non può avere più di 20 caratteri")]
        [MoreThanOneWordValidationAttribute]
        public string Title { get; set; }

        [Required(ErrorMessage = "Il campo descrizione è obbligatorio")]
        [Column(TypeName = "text")]
        public string Description { get; set; }

        [Required(ErrorMessage = "l'URL dell'immagine è obbligatoria")]
        [Url(ErrorMessage = "Mi dispiace l'URL inserito non è valido")]
        public string Image { get; set; }

        public int Price { get; set; }

        public Post()
        {

        }

        public Post(string title, string description, string image, int price)
        {
            this.Title = title;
            this.Description = description;
            this.Image = image;
            this.Price = price;
        }
    }
}
