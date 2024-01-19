using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public  interface ICommentaireRepository
    {
        public Task<Commentaire> Read(int id);

        public Task<List<Commentaire>> ReadAll(int MyArticle);

        public Task<bool> Create(Commentaire Commentaire);

        public Task<bool> Update(Commentaire Commentaire);


        public Task<bool> Delete(int Id);


    }
}
