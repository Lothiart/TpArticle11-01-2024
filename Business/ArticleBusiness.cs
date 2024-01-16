using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories;
using Repositories.Contracts;
using Business.Contracts;
using Entities;
namespace Business
{
    public class ArticleBusiness : IArticleBusiness
    {
        public IArticleRepository _ArticleRepository;
        public ArticleBusiness(IArticleRepository ArticleRepository)
        {
            _ArticleRepository = ArticleRepository;
        }
        public async Task<Article> GetArticle(int id)
        {
            return await _ArticleRepository.GetArticle(id);
        }
        public async Task<List<Article>> GetAllArticle()
        {
             return await _ArticleRepository.GetAllArticle();
        }
        public async Task CreateArticle(Article article)
        {
            
            await _ArticleRepository.CreateArticle(article);
            
        }
        public async Task UpdateArticle(Article article)
        {
            //new Article(Id,Nom,Prenom,DateNaissance,Adresse,CodePostal,Ville);
            await _ArticleRepository.UpdateArticle(article);


        }
        public async Task DeleteArticle(int id)
        {
            await _ArticleRepository.DeleteArticle(id);
        }

    }
}

