using board_service.Models;
using board_service.Repositories.Interfaces;
using board_service.Services.Interfaces;

namespace board_service.Services;

public class BoardService : IBoardService
{
    private readonly IBoardRepository _boardRepository;
    public BoardService(IBoardRepository boardRepository)
    {
        _boardRepository = boardRepository;
    }
    
    public List<Board> GetAllBoards()
    {
        return _boardRepository.GetAll();
    }
}