using System.Data.Sql;
using System.Data.SqlClient;
using Entities;
using Microsoft.Data.SqlClient;
using Repositories.Contracts;
using Business.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
namespace Repositories
{
    public class CommentaireRepository : ICommentaireRepository
    {
        private Context _context;
        private ICommentaireBusiness _CommentaireBusiness;
        public CommentaireRepository(Context context)
        {

            _context = context;

        }



        public async Task<Commentaire> Read(int id)
        {

            //try
            //{


            return await _context.Comments.FirstOrDefaultAsync(a => a.Id == id);



            //    }
            //    catch (Exception e) { Console.WriteLine("erreur : " + e.Message); }

        }
        public async Task<List<Commentaire>> ReadAll(int MyArticle)
        {
            //return await _context.Comments.ToListAsync();
            List<Commentaire> comments = new List<Commentaire>();

            foreach (var comment in _context.Comments)
            {
                if (comment.ArticleId == MyArticle)
                {
                    comments.Add(comment);
                }
            }

            return comments;
            
        }
        public async Task<bool> Create(Commentaire Commentaire)
        {
            try { 
            Commentaire.DateCreation = DateTime.Now;
            Commentaire.DateModification = DateTime.Now;
            await _context.Comments.AddAsync(Commentaire);
            await _context.SaveChangesAsync();
            return true;
        }
            catch (Exception ex)
            {
                return false;
            }
}
        public async Task<bool> Update(Commentaire Commentaire)
        {
            try
            {
                var CommentaireToEdit = await _context.Comments.FirstOrDefaultAsync(a => a.Id == Commentaire.Id);
                CommentaireToEdit.DateModification = DateTime.Now;
                CommentaireToEdit.Contenu = Commentaire.Contenu;
                CommentaireToEdit.ArticleId = Commentaire.ArticleId;
                Commentaire = CommentaireToEdit;
                await _context.SaveChangesAsync();
                    return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> Delete(int Id)
        {
            try { 
            _context.Comments.Remove(await Read(Id));
            await _context.SaveChangesAsync();
            return true;
        }
            catch (Exception ex)
            {
                return false;
            }
}

        //public Commentaire Rechercher(int id)
        //{


        //}

    }




}

