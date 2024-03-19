using Minesweeper.API.Models;
using Minesweeper.API.Models.Requests;
using Minesweeper.API.Models.Responses;

namespace Minesweeper.API.Managers
{
    public interface IGameManager
    {
        GameInfoResponse CreateGame(NewGameRequest request);

        GameInfoResponse TurnGame(GameTurnRequest request);
    }
}
