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
       Posts.Add(new Post {PostId = 1001, Title = "", Content = "Lets post some stuff about " });
       Posts.Add(new Post {PostId = 1002, Title = "", Content = "Lets post some stuff about " });
       Posts.Add(new Post {PostId = 1003, Title = "", Content = "Lets post some stuff about " });
       Posts.Add(new Post {PostId = 1004, Title = "", Content = "Lets post some stuff about " });
       Posts.Add(new Post {PostId = 1005, Title = "", Content = "Lets post some stuff about " });
       Posts.Add(new Post {PostId = 1006, Title = "", Content = "Lets post some stuff about " });
       Posts.Add(new Post {PostId = 1007, Title = "", Content = "Lets post some stuff about " });
       Posts.Add(new Post {PostId = 1008, Title = "", Content = "Lets post some stuff about " });
       Posts.Add(new Post {PostId = 1009, Title = "", Content = "Lets post some stuff about " });
       Posts.Add(new Post {PostId = 1010, Title = "", Content = "Lets post some stuff about " }); 
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

