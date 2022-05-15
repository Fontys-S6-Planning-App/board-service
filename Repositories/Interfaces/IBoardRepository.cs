using board_service.Models;

namespace board_service.Repositories.Interfaces;

public interface IBoardRepository
{
    List<Board> GetAll();
    void Add(Board board);
    void Update(Board board);
    void Delete(int id);
}