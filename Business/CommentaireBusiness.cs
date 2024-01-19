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
    public class CommentaireBusiness : ICommentaireBusiness
    {
        public ICommentaireRepository _CommentaireRepository;
        public CommentaireBusiness(ICommentaireRepository CommentaireRepository)
        {
            _CommentaireRepository = CommentaireRepository;
        }
        public async Task<Commentaire> Read(int id)
        {
            return await _CommentaireRepository.Read(id);
        }
        public async Task<List<Commentaire>> ReadAll(int MyArticle)
        {
            return await _CommentaireRepository.ReadAll(MyArticle);
        }
        public async Task<bool> Create(Commentaire Commentaire)
        {

            return await _CommentaireRepository.Create(Commentaire);

        }
        public async Task<bool> Update(Commentaire Commentaire)
        {
            //new Commentaire(Id,Nom,Prenom,DateNaissance,Adresse,CodePostal,Ville);
            return await _CommentaireRepository.Update(Commentaire);


        }
        public async Task<bool> Delete(int id)
        {
            return await _CommentaireRepository.Delete(id);
        }

    }
}

