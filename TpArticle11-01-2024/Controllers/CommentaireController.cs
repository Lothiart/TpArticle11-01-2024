using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TpArticle11_01_2024.Models;

using Entities;

using Business.Contracts;

namespace TpArticle11_01_2024.Controllers
{
    public class CommentaireController : Controller
    {

        private ICommentaireBusiness _CommentaireBusiness;
        private IArticleBusiness _ArticleBusiness;
        public CommentaireController(ICommentaireBusiness CommentaireBusiness,IArticleBusiness ArticleBusiness)
        {
            this._CommentaireBusiness = CommentaireBusiness;
            this._ArticleBusiness = ArticleBusiness;
        }

        public ActionResult Index()
        {
            return View();
        }


        public async Task<ActionResult> Details(int id)
        {

            //Commentaire Commentaire = Commentaires.FirstOrDefault(m => m.Id == id);

            //return View(Commentaire);
            return View(await _CommentaireBusiness.GetCommentaire(id));


        }
        //public async Task<ActionResult> Read()
        //{
        //    //return View(Commentaires);

        //    return PartialView("_ReadCommentairePartial",await _CommentaireBusiness.GetAllCommentaire());

        //}

        public ActionResult Create(int MyArticle)
        {
            Commentaire MyCom = new Commentaire();
            
            MyCom.MyArticle = MyArticle;
            
            return View(MyCom);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Commentaire Commentaire)
        {
            //Commentaires.Add(Commentaire);
            //return RedirectToAction("Read");
            //try
            //{
            await _CommentaireBusiness.CreateCommentaire(Commentaire);
            //}
            //catch (Exception ex)
            //{
            //    return (ex.);
            //}

            return View(Commentaire);
                //RedirectToAction("Details","Article",await _ArticleBusiness.GetArticle(Commentaire.MyArticle));

        }


        public async Task<ActionResult> Update(Commentaire Commentaire)
        {
            await _CommentaireBusiness.UpdateCommentaire(Commentaire);
            return View(Commentaire);

        }

        public async Task<ActionResult> UpdateValid(Commentaire Commentaire)
        {
            //Commentaires.FirstOrDefault(m => m.Id == Commentaire.Id).Theme = Commentaire.Theme;
            //Commentaires.FirstOrDefault(m => m.Id == Commentaire.Id).DateModification = DateTime.Now;
            //Commentaires.FirstOrDefault(m => m.Id == Commentaire.Id).Contenu = Commentaire.Contenu;
            //return RedirectToAction("Read");
            await _CommentaireBusiness.UpdateCommentaire(Commentaire);
            return RedirectToAction("Details", "Article", Commentaire.MyArticle);

        }


        public async Task<ActionResult> Delete(int id)
        {

           Commentaire Com = await _CommentaireBusiness.GetCommentaire(id);
            Article article = await _ArticleBusiness.GetArticle(Com.MyArticle);
                
            await _CommentaireBusiness.DeleteCommentaire(id);
            
            return RedirectToAction("Details", "Article", article);
        }
        public ActionResult DeleteAjax(int id)
        {
            // Supprimer le commentaire de la base de données
            _CommentaireBusiness.DeleteCommentaire(id);
            

            // Retourner une réponse JSON
            return Json(new { success = true });
        }

    }
}
