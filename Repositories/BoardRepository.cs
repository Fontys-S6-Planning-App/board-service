using board_service.DBContexts;
using board_service.Models;
using board_service.Repositories.Interfaces;

namespace board_service;

public class BoardRepository: IBoardRepository
{
    private readonly BoardContext _context;
    
    public BoardRepository(BoardContext context)
    {
        _context = context;
    }

    public List<Board> GetAll()
    {
        return _context.Boards.ToList();
    }
}