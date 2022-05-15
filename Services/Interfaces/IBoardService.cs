using board_service.Models;

namespace board_service.Services.Interfaces;

public interface IBoardService
{
    public List<Board> GetAllBoards();
    public void AddBoard(Board board);
    public void UpdateBoard(Board board);
    public void DeleteBoard(int id);
}