using System.Data.Sql;
using System.Data.SqlClient;
using Entities;
using Microsoft.Data.SqlClient;
using Repositories.Contracts;
using Business.Contracts;
using Microsoft.EntityFrameworkCore;
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



        public async Task<Commentaire> GetCommentaire(int id)
        {

            //try
            //{


            return await _context.Comments.FirstOrDefaultAsync(a => a.Id == id);



            //    }
            //    catch (Exception e) { Console.WriteLine("erreur : " + e.Message); }

        }
        public async Task<List<Commentaire>> GetAllCommentaire(int MyArticle)
        {
            //return await _context.Comments.ToListAsync();
            List<Commentaire> comments = new List<Commentaire>();

            foreach (var comment in _context.Comments)
            {
                if (comment.MyArticle == MyArticle)
                {
                    comments.Add(comment);
                }
            }

            return comments;
            
        }
        public async Task CreateCommentaire(Commentaire Commentaire)
        {
            
            Commentaire.DateCreation = DateTime.Now;
            Commentaire.DateModification = DateTime.Now;
            await _context.Comments.AddAsync(Commentaire);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateCommentaire(Commentaire Commentaire)
        {
            try
            {
                var CommentaireToEdit = await _context.Comments.FirstOrDefaultAsync(a => a.Id == Commentaire.Id);
                CommentaireToEdit.DateModification = DateTime.Now;
                CommentaireToEdit.Contenu = Commentaire.Contenu;
                CommentaireToEdit.MyArticle = Commentaire.MyArticle;
                Commentaire = CommentaireToEdit;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

            }
        }
        public async Task DeleteCommentaire(int Id)
        {
            _context.Comments.Remove(await GetCommentaire(Id));
            await _context.SaveChangesAsync();
        }

        //public Commentaire Rechercher(int id)
        //{


        //}

    }




}

