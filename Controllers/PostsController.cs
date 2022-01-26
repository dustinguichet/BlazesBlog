#nullable disable
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazeBlog.Data;
using BlazeBlog.Models;

namespace BlazeBlog.Controllers
{
public class PostsController : Controller
{
    
    private readonly ILogger<PostsController> _logger;
    private readonly PostsDbContext _context;

    public PostsController(PostsDbContext context,ILogger<PostsController> logger)
    {
        _context = context;
        _logger=logger;
    }

    // GET: Posts
    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {
        return View(await _context.Posts.ToListAsync());
    }

    // GET: Posts/Details/5
    [AllowAnonymous]
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var post = await _context.Posts
            .FirstOrDefaultAsync(m => m.PostId == id);
        if (post == null)
        {
            return NotFound();
        }

        return View(post);
    }

    [Authorize]
    // GET: Posts/Create
    public IActionResult Create() => View();

    // POST: Posts/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> Create(//[Bind("PostId,PostTitle,PostContent,TimeStamp")]
                                            Post post)
    {
            _logger.LogCritical($"Title='{post.Title}'");
        if (User.Identity.IsAuthenticated)
        {
                post.UserName = User.Identity.Name;
                          //User?.Claims?.FirstOrDefault(x => x.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name")?.Value;
          ModelState.Clear();
          ModelState.MarkFieldValid("UserName");
        }
        else
        {
            post.UserName = "Unkown";
        }

        if (ModelState.IsValid)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(post);
    }

    
    // GET: Posts/Edit/5
    [Authorize]
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var post = await _context.Posts.FindAsync(id);
        if (post == null)
        {
            return NotFound();
        }
        return View(post);
    }

    // POST: Posts/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> Edit(int id, //[Bind("PostId,PostTitle,PostContent,TimeStamp")]
                                                  Post post)
    {
        if (User.Identity.IsAuthenticated)
        {
            post.UserName = User.Identity.Name;
            ModelState.Clear();
            ModelState.MarkFieldValid("UserName");
        }
        else
        {
            post.UserName = "Unknown";
        }

        if (id != post.PostId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(post);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(post.PostId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
            }
            if (post.UserName != User.Identity.Name)
            {
                return View("NotValidUser");
            }
            return View(post);
        }
    
    // GET: Posts/Delete/5
    [Authorize]
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var post = await _context.Posts
            .FirstOrDefaultAsync(m => m.PostId == id);
        if (post == null)
        {
            return NotFound();
        }
        if(post.UserName != User.Identity.Name)
        {
                return View("NotValidUser");
        }

        return View(post);
    }

    // POST: Posts/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    [Authorize]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var blog = await _context.Posts.FindAsync(id);
        if(blog.UserName != User.Identity.Name)
        {
                return View("NotValidUser");
        }
        _context.Posts.Remove(blog);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool PostExists(int id)
    {
            return _context.Posts.Any(e => e.PostId == id);
    }
}
}
