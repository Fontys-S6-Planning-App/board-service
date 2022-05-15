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
    
    public void Add(Board board)
    {
        _context.Boards.Add(board);
        _context.SaveChanges();
    }
    
    public void Update(Board board)
    {
        _context.Boards.Update(board);
        _context.SaveChanges();
    }
    
    public void Delete(int id)
    {
        var board = _context.Boards.Find(id);
        if(board == null)
        {
            throw new Exception("Board not found");
        }
        _context.Boards.Remove(board);
        _context.SaveChanges();
    }
}