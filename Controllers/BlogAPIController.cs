using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Mvc;

[Route("API/posts")]
public class BlogAPIController : Controller {

        private IBlogPost blogpost;

        public BlogAPIController(IBlogPost b){
            blogpost = b;
        }

    [HttpGet()]
    public IActionResult ReadAll(int id){
        if(id == default(int))
           return Ok(blogpost.getAll());

        return Ok(blogpost.get(id));
    }

    

    [HttpPost]
    public IActionResult Create([FromBody]Post p){
        blogpost.create(p);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        blogpost.delete(id);
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult Update([FromBody]Post p, int id){
        if(blogpost.update(id, p) == null){
            return NotFound();
        }
        return Ok();
    }

}