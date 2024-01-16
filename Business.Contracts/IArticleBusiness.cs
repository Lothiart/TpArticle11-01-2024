using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace Business.Contracts
{
    public interface IArticleBusiness
    {


        public Task<Article> GetArticle(int id);
        public Task<List<Article>> GetAllArticle();
        public Task CreateArticle(Article article);
        public Task UpdateArticle(Article article);
        public Task DeleteArticle(int id);
    }
}
