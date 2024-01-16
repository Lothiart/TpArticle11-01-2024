using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts
{
    public interface ICommentaireBusiness
    {
        public Task<Commentaire> GetCommentaire(int id);
        public Task<List<Commentaire>> GetAllCommentaire(int MyArticle);
        public Task CreateCommentaire(Commentaire Commentaire);
        public Task UpdateCommentaire(Commentaire Commentaire);
        public Task DeleteCommentaire(int id);
    }
}
