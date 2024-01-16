using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Commentaire
    {

        public int Id { get; set; }

        
        [Required]
        [StringLength(20, ErrorMessage = "Max 20 caractères")]
        public string Auteur { get; set; }

        public DateTime DateCreation { get; set; }

        public DateTime DateModification { get; set; }

        [StringLength(20,ErrorMessage = "Max 100 caractères")]
        public string Contenu { get; set; }


        public int MyArticle { get; set; }
    }
}
