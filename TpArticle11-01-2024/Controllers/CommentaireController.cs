using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TpArticle11_01_2024.Models;

using Entities;

using Business.Contracts;
using Business;

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
            return View(await _CommentaireBusiness.Read(id));


        }
        //public async Task<ActionResult> Read()
        //{
        //    //return View(Commentaires);

        //    return PartialView("_ReadCommentairePartial",await _CommentaireBusiness.GetAllCommentaire());

        //}

        public ActionResult Create(int ArticleId)
        {
            Commentaire MyCom = new Commentaire();
            
            MyCom.ArticleId = ArticleId;
            ViewBag.ArticleId = ArticleId;
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
            await _CommentaireBusiness.Create(Commentaire);
            //}
            //catch (Exception ex)
            //{
            //    return (ex.);
            //}

            return RedirectToAction("Details", "Article", new { id = Commentaire.ArticleId });
            //RedirectToAction("Details","Article",await _ArticleBusiness.GetArticle(Commentaire.ArticleId));

        }


        public async Task<ActionResult> Update(Commentaire Commentaire)
        {


            //await _CommentaireBusiness.Update(Commentaire);

            var com =await _CommentaireBusiness.Read(Commentaire.Id);
            return View(com);

        }

        public async Task<ActionResult> UpdateValid(Commentaire Commentaire)
        {
            //Commentaires.FirstOrDefault(m => m.Id == Commentaire.Id).Theme = Commentaire.Theme;
            //Commentaires.FirstOrDefault(m => m.Id == Commentaire.Id).DateModification = DateTime.Now;
            //Commentaires.FirstOrDefault(m => m.Id == Commentaire.Id).Contenu = Commentaire.Contenu;
            //return RedirectToAction("Read");
            await _CommentaireBusiness.Update(Commentaire);
            return RedirectToAction("Details", "Article",await _ArticleBusiness.Read(Commentaire.ArticleId));

        }


        public async Task<ActionResult> Delete(int id)
        {

           Commentaire Com = await _CommentaireBusiness.Read(id);
            Article article = await _ArticleBusiness.Read(Com.ArticleId);
                
            await _CommentaireBusiness.Delete(id);
            
            return RedirectToAction("Details", "Article", article);

        }
        //public ActionResult DeleteAjax(int id)
        //{
        //    // Supprimer le commentaire de la base de données
        //    _CommentaireBusiness.DeleteCommentaire(id);
            

        //    // Retourner une réponse JSON
        //    return Json(new { success = true });
        //}
        [HttpPost]
        public async Task<IActionResult> DeleteFullAjax(int commentaireId)
        {
            bool res = false;
            if (await _CommentaireBusiness.Delete(commentaireId))
            {
                res = true;
                TempData["Message"] = "Suppr. Ajax et delete row";
            }
            else
            {

                TempData["Message"] = "";

            }

            return Json(res);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteAspAjax(int commentaireId)
        {
            var com = await _CommentaireBusiness.Read(commentaireId);
            int articleId = com.ArticleId;

            if (await _CommentaireBusiness.Delete(commentaireId))
            {
                TempData["Message"] = "Suppr. Ajax et MAJ vue partielle";
            }
            else
            {
                TempData["Message"] = "";
            }

            var coms = (await _CommentaireBusiness.ReadAll(articleId));

            return PartialView("_DisplayCommentairesPartial", coms);
        }

    }
}
