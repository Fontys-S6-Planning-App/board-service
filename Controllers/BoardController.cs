using board_service.DBContexts;
using board_service.Models;
using board_service.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace board_service.Controllers;

[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
[ApiController]
[Route("board")]
public class BoardController : ControllerBase
{
    private readonly IBoardService _boardService;
    
    public BoardController(IBoardService boardService)
    {
        _boardService = boardService;
    }

    [HttpGet]
    public IList<Board> Get()
    {
        return _boardService.GetAllBoards();
    }
    
}