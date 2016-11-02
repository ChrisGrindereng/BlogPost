using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;


[Route("/posts")]
public class BlogController : Controller {
    private IBlogPost blog;
    public BlogController(IBlogPost b){
    blog = b;
    }

    [HttpGet]
    public IActionResult ReadAll(){
        return View(blog);
    }

    [HttpGet("{id}")]
    public IActionResult ReadOne(int id){
        var post = blog.get(id);
        if (post == null)
            return NotFound();    
        
        return View(post);
            
    }

    [HttpGet ("{id}/edit")]
    public IActionResult Edit(int id ){
        var post = blog.get(id);
        if (post == null)
             return Redirect("/posts");
        
        return View(post);

    }

    [HttpPost("{id}/edit")]
    public IActionResult Upsert([FromForm] Post post, int id){
        var p = blog.get(id);
        if(p != null) 
            blog.delete(id);

        post.PostId = id;
        blog.create(post);
        return RedirectToAction("ReadAll");
    }

    [HttpGet("new")]
    public IActionResult Create(){
        return View();
    }

    [HttpPost("new")]
    public IActionResult HandleCreate([FromForm] Post post, int id){
        blog.create(post);
        return RedirectToAction("ReadAll");
    }

    [HttpPost("{id}/delete")]
    public IActionResult Delete(int id){
        blog.delete(id);
        return RedirectToAction("ReadAll");
    }

}