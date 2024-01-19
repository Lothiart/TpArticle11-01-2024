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
        public async Task<Article> Read(int id)
        {
            return await _ArticleRepository.Read(id);
        }
        public async Task<List<Article>> ReadAll()
        {
             return await _ArticleRepository.ReadAll();
        }
        public async Task<bool> Create(Article article)
        {
            
            return await _ArticleRepository.Create(article);
            
        }
        public async Task<bool> Update(Article article)
        {
            //new Article(Id,Nom,Prenom,DateNaissance,Adresse,CodePostal,Ville);
            return await _ArticleRepository.Update(article);


        }
        public async Task<bool> Delete(int id)
        {
            return await _ArticleRepository.Delete(id);
        }
        public async Task<List<Article>> Search(string str)
        {
            return await _ArticleRepository.Search(str);
        }

    }
}

