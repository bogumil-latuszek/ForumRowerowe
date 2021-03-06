using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ForumRowerowe.Models;

namespace ForumRowerowe.Controllers
{
    public class FirstController : Controller
    {
        private IForumCrudRepository repository;
        public FirstController(IForumCrudRepository repository)
        {
            this.repository = repository;
        }
        
        public IActionResult Index()
        {
            return View(repository.FindAll());

            //return View("ShowAllPosts", ListOfPosts); legacy func
        }

        // GET: Post/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Post/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("PostID,Content")] Models.Post post)
        {
            if (ModelState.IsValid)
            {
                repository.AddPosts(post);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

        // GET: Post/Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            int Id = id.GetValueOrDefault();
            var post = repository.FindPost(Id);
            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            repository.DeletePosts(id);
            return RedirectToAction(nameof(Index));
        }

        // GET: Post/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            int Id = id.GetValueOrDefault();
            var post = repository.FindPost(Id);
            return View(post);
        }

        // POST: Post/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit( [ Bind("PostID,Content")] Models.Post post)
        {

            if (ModelState.IsValid)
            {
                repository.UpdatePosts(post);
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
