using Microsoft.AspNetCore.Mvc;
using PingPong.Models;

namespace PingPong.Controllers
{

    
    public class PlayerController : Controller
    {
        PingPongTestContext context = new PingPongTestContext();

       
        public IActionResult Index()
        {
            return View(context.Players.ToList());
        }
       
        public IActionResult Details(int id)
        {
            Player player = context.Players.Find(id);
            return View(player);
        }
        [HttpGet("Player/Create")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost("Create")]
        public IActionResult Create(Player player)
        {
            context.Players.Add(player);
            return RedirectToAction("Index");
        }
        [HttpGet("Player/WinProbability")]
        public IActionResult WinProbability()
        {
            return View(context.Players.ToList());
        }
        [HttpPost]
        public IActionResult WinProbabilityResults(int p1, int p2)
        {
            Player player1 = context.Players.Find(p1);
            Player player2 = context.Players.Find(p2);
            return RedirectToAction("Index");
        }
    }
}
