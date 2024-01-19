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
        
        
        public async Task<Article> Read(int id)
        {
           
            //try
            //{
                
                
                return await _context.Articles.FirstOrDefaultAsync(a => a.Id == id);
                


        //    }
        //    catch (Exception e) { Console.WriteLine("erreur : " + e.Message); }
            
        }
        public async Task<List<Article>> ReadAll()
        {
           
            
            return await _context.Articles.ToListAsync();
            
        }
        public async Task<bool> Create(Article article)
        {
            //article.Id = _context.Articles.Count() + 1;
            try { 
              article.DateCreation = DateTime.Now;
              article.DateModification = DateTime.Now;
             await _context.Articles.AddAsync(article);
            await _context.SaveChangesAsync();
            return true;
            }catch
            (Exception ex)
            {
                return false; 
            }
            
        }
        public async Task<bool> Update(Article article)
        {
            try
            {
                var articleToEdit = await _context.Articles.FirstOrDefaultAsync(a => a.Id == article.Id);
                articleToEdit.DateModification = DateTime.Now;
                articleToEdit.Contenu = article.Contenu;
                articleToEdit.Theme = article.Theme;
                article = articleToEdit;
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
            _context.Articles.Remove(await Read(Id));
            await _context.SaveChangesAsync();
            return true;
        }
            catch (Exception ex)
            {
                return false;
            }
}

        //public article Rechercher(int id)
        //{


        //}

    }




}

