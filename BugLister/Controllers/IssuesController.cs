using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BugLister.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BugLister.Controllers
{
  public class IssuesController : Controller
  {
    private readonly BugListerContext _db;

    public IssuesController(BugListerContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Issue> model = _db.Issues.Include(Issues => Issues.Language).ToList();
      return View(model);
    }
    public ActionResult Create()
    {
      ViewBag.LanguageId = new SelectList(_db.Languages, "LanguageId", "Name");
      return View();
    }
    [HttpPost]
    public ActionResult Create(Issue issue)
    {
      _db.Issues.Add(issue);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Issue thisIssue = _db.Issues.FirstOrDefault(Issues => Issues.IssueId == id);
      ViewBag.Name = _db.Languages.FirstOrDefault(languages => languages.LanguageId == thisIssue.LanguageId);
      return View(thisIssue);
    }
    public ActionResult Edit(int id)
    {
      var thisIssue = _db.Issues.FirstOrDefault(Issues => Issues.IssueId == id);
      ViewBag.LanguageId = new SelectList(_db.Languages, "LanguageId", "Name");
      return View(thisIssue);
    }
    [HttpPost]
    public ActionResult Edit(Issue issue)
    {
      _db.Entry(issue).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Delete(int id)
    {
      var thisIssue = _db.Issues.FirstOrDefault(Issues => Issues.IssueId == id);
      return View(thisIssue);
    }
    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      var thisIssue = _db.Issues.FirstOrDefault(Issues => Issues.IssueId == id);
      _db.Issues.Remove(thisIssue);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult Search(string search)
    {

      // List<Animal> allAnimals = _db.Animals.ToList();
      // List<Animal> model = new List<Animal> { };
      // foreach (Animal animal in allAnimals)
      // {
      //   string temp = animal.Name.ToUpper();
      //   string temp2 = name.ToUpper();

      //   if (temp.Contains(temp2))
      //   {
      //     model.Add(animal);
      //   }
      // }
      return View(model);
    }
  }
}