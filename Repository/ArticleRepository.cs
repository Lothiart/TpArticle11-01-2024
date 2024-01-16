using System.Data.Sql;
using System.Data.SqlClient;
using Entities;
using Microsoft.Data.SqlClient;
using Repositories.Contracts;
using Business.Contracts;
using Microsoft.EntityFrameworkCore;
namespace Repositories 
{
    public class ArticleRepository : IArticleRepository
    {
        private Context _context;
        private IArticleBusiness _articleBusiness;
        public ArticleRepository(Context context)
        {

            _context = context;

        }
        
        
        public async Task<Article> GetArticle(int id)
        {
           
            //try
            //{
                
                
                return await _context.Articles.FirstOrDefaultAsync(a => a.Id == id);
                


        //    }
        //    catch (Exception e) { Console.WriteLine("erreur : " + e.Message); }
            
        }
        public async Task<List<Article>> GetAllArticle()
        {
           
            
            return await _context.Articles.ToListAsync();
            
        }
        public async Task CreateArticle(Article article)
        {
            //article.Id = _context.Articles.Count() + 1;
              article.DateCreation = DateTime.Now;
              article.DateModification = DateTime.Now;
             await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateArticle(Article article)
        {
            try
            {
                var articleToEdit = await _context.Articles.FirstOrDefaultAsync(a => a.Id == article.Id);
                articleToEdit.DateModification = DateTime.Now;
                articleToEdit.Contenu = article.Contenu;
                articleToEdit.Theme = article.Theme;
                article = articleToEdit;
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
               
            }
        }
        public async Task DeleteArticle(int Id)
        {
            _context.Articles.Remove(await GetArticle(Id));
            await _context.SaveChangesAsync();
        }

        //public article Rechercher(int id)
        //{


        //}

    }




}

