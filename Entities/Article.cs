using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
namespace Entities
{
    public class Article
    {
       
        public int Id { get; set; }

        [Remote("IsThemeUnique", "Article", ErrorMessage = "Error: Thème déja enregistré")]
        public string Theme { get; set; }
        [Required]
        [StringLength(30, ErrorMessage = "Max 30 caractères")]
        public string Auteur { get; set; }

        public DateTime DateCreation { get; set; } = DateTime.Now;

        public DateTime DateModification { get; set; }

        public string Contenu { get; set; }

        public List<Commentaire>? Commentaires { get; set; }

    }
}
