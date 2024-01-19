using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TpArticle11_01_2024.Models;

using Entities;
using Business.Contracts;
using System.Xml.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;
using Business;

namespace TpArticle11_01_2024.Controllers
{
    public class ArticleController : Controller
    {
        
     

        private IArticleBusiness _articleBusiness;
        private ICommentaireBusiness _CommentaireBusiness;
        public ArticleController(IArticleBusiness articleBusiness, ICommentaireBusiness commentaireBusiness)
        {
            this._articleBusiness = articleBusiness;
            this._CommentaireBusiness = commentaireBusiness;
        }

        public ActionResult Index()
        {
           
                //// Obtenir le dernier article publié
                //var article = _articleBusiness.Articles.OrderByDescending(article => article.DateDeCreation).FirstOrDefault();

                //// Retourner la page d'accueil
                //return View(article);
            return View();

        }

       
       
        public async Task<ActionResult> Details(Article article)
        {


            
            var comments = await _CommentaireBusiness.ReadAll(article.Id);
            var Article = await _articleBusiness.Read(article.Id);
            ViewBag.ArticleId = article.Id;
            return View(new ArticleViewModel { Article = Article, Comments = comments });
            //return View( await _CommentaireBusiness.GetAllCommentaire());

        }
        
        public async Task<ActionResult> Read()
        {
            //return View(Articles);
            
             //return View(await _articleBusiness.GetAllArticle());
            return View(await _articleBusiness.ReadAll());
        }
       
        public ActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Article article)
        {
            //Articles.Add(article);
            //return RedirectToAction("Read");
            //try
            //{
            await _articleBusiness.Create(article);
            //}
            //catch (Exception ex)
            //{
            //    return (ex.);
            //}
            return RedirectToAction("Read");

        }


        public async Task<ActionResult> Update(Article article)
        {
            await _articleBusiness.Update(article);
            return View(article);

        }

        public async Task<ActionResult> UpdateValid(Article article)
        {
            //Articles.FirstOrDefault(m => m.Id == article.Id).Theme = article.Theme;
            //Articles.FirstOrDefault(m => m.Id == article.Id).DateModification = DateTime.Now;
            //Articles.FirstOrDefault(m => m.Id == article.Id).Contenu = article.Contenu;
            //return RedirectToAction("Read");
            await _articleBusiness.Update(article);
            return RedirectToAction("Read");

        }

       
        public async Task<ActionResult> Delete(int id)
        {
            //Articles.Remove(Articles.FirstOrDefault(m => m.Id == id));
            await _articleBusiness.Delete(id);
            return RedirectToAction("Read");
        }
        public async Task<IActionResult> SearchAjax(string str)
        {
            return PartialView("_displayArticlesPartial", await _articleBusiness.Search(str));
        }
        [HttpGet]
        public async Task<IActionResult> Recherche(string str = "", int pageNumber = 1)
        {
            TempData["Page"] = pageNumber;

            var arts = await _articleBusiness.ReadAll();

            if (str == "")
            {

            }
            else
            {
                arts = await _articleBusiness.Search(str);

            }


            return View(arts.OrderBy(a => a.DateCreation).ToList());
        }
        [HttpPost]
        public async Task<IActionResult> RechercheAjax(string str = "", int pageNumber = 1)
        {
            TempData["Page"] = pageNumber;

            var arts = await _articleBusiness.ReadAll();

            if (str == "")
            {

            }
            else
            {
                arts = await _articleBusiness.Search(str);

            }


            return PartialView("_SearchArticlesPartial", arts.OrderBy(a => a.DateCreation).ToList());
        }


    }
}
