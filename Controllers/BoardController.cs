using board_service.DBContexts;
using board_service.Models;
using Microsoft.AspNetCore.Mvc;

namespace board_service.Controllers;

[ApiController]
[Route("board")]
public class BoardController : ControllerBase
{
    private MyDbContext _myDbContext;
    
    public BoardController(MyDbContext myDbContext)
    {
        _myDbContext = myDbContext;
    }
    
    [HttpGet]
    public IList<Board> Get()
    {
        return _myDbContext.Boards.ToList();
    }
    
}