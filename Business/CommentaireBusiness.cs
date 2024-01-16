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
        public async Task<Commentaire> GetCommentaire(int id)
        {
            return await _CommentaireRepository.GetCommentaire(id);
        }
        public async Task<List<Commentaire>> GetAllCommentaire(int MyArticle)
        {
            return await _CommentaireRepository.GetAllCommentaire(MyArticle);
        }
        public async Task CreateCommentaire(Commentaire Commentaire)
        {

            await _CommentaireRepository.CreateCommentaire(Commentaire);

        }
        public async Task UpdateCommentaire(Commentaire Commentaire)
        {
            //new Commentaire(Id,Nom,Prenom,DateNaissance,Adresse,CodePostal,Ville);
            await _CommentaireRepository.UpdateCommentaire(Commentaire);


        }
        public async Task DeleteCommentaire(int id)
        {
            await _CommentaireRepository.DeleteCommentaire(id);
        }

    }
}

