using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;



public class Blog : IBlogPost
{
    
    public int BlogId { get; set; }
    
    public string title { get; set;}
    public List<Post> Posts { get; set; } = new List<Post>();
    public Blog(){
       //Add Dumby data  
       Posts.Add(new Post {PostId = 1001, Title = "Pirates", Content = "Lets post some stuff about Pirates" });
       Posts.Add(new Post {PostId = 1002, Title = "Witches", Content = "Lets post some stuff about Witches" });
       Posts.Add(new Post {PostId = 1003, Title = "Knights", Content = "Lets post some stuff about Knights" });
       Posts.Add(new Post {PostId = 1004, Title = "Warewolves", Content = "Lets post some stuff about Warewolves" });
       Posts.Add(new Post {PostId = 1005, Title = "Vampires", Content = "Lets post some stuff about Vampires" });
       Posts.Add(new Post {PostId = 1006, Title = "Killer Clowns", Content = "Lets post some stuff about Killer Clowns" });
       Posts.Add(new Post {PostId = 1007, Title = "Ghosts", Content = "Lets post some stuff about Ghosts" });
       Posts.Add(new Post {PostId = 1008, Title = "Gules", Content = "Lets post some stuff about Gules" });
       Posts.Add(new Post {PostId = 1009, Title = "Pumpkins", Content = "Lets post some stuff about Pumpkins" });
       Posts.Add(new Post {PostId = 1010, Title = "Frakenstien", Content = "Lets post some stuff about Frakenstien" }); 
    }

    
    public void create(Post p){
        Posts.Add(p);
            
    }
    public IEnumerable<Post> getAll(){
        return Posts;
    }
    public IEnumerable<Post> getRecent(int numberOfrecords = 5){
        
        return Posts.OrderByDescending(x => x.createdAt).Take(numberOfrecords);
        
    }
    public Post get(int id){
        return Posts.First(p => p.PostId == id);
    }
    public Post update(int id, Post p){
        Post toUpdate = Posts.First(x => x.PostId == id);
        if(toUpdate != null){
            Posts.Remove(toUpdate);
            Posts.Add(p);
            return p; 
        }
        return null;
    }
    public void delete(int id){
        Post p = Posts.First(x => x.PostId == id);
        if(p != null){
            Posts.Remove(p);
        }
    }
}

