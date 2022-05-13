using board_service.Models;

namespace board_service.Repositories.Interfaces;

public interface IBoardRepository
{
    List<Board> GetAll();
}