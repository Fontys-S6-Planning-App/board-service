using board_service.Models;

namespace board_service.Services.Interfaces;

public interface IBoardService
{
    public List<Board> GetAllBoards();
}