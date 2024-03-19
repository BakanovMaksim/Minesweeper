using Microsoft.AspNetCore.Mvc;

using Minesweeper.API.Filters;
using Minesweeper.API.Managers;
using Minesweeper.API.Models.Requests;
using Minesweeper.API.Models.Responses;

using System.ComponentModel.DataAnnotations;

namespace Minesweeper.API.Controllers
{
    [Route("api")]
    [ApiController]
    [RequestExceptionFilter]
    public class GameController : ControllerBase
    {
        private readonly IGameManager gameManager;

        public GameController(IGameManager gameManager)
        {
            this.gameManager = gameManager;
        }

        /// <summary>
        /// Начало новой игры
        /// </summary>
        /// <param name="request">Запрос для новой игры</param>
        /// <returns>Данные созданной игры</returns>
        [HttpPost]
        [Route("new")]
        public GameInfoResponse CreateGame([Required, FromBody] NewGameRequest request)
        {
            return gameManager.CreateGame(request);
        }

        /// <summary>
        /// Ход пользователя
        /// </summary>
        /// <param name="request">Запрос хода пользователя</param>
        /// <returns>Обновленные данные игры</returns>
        [HttpPost]
        [Route("turn")]
        public GameInfoResponse TurnGame([Required, FromBody] GameTurnRequest request)
        {
            return gameManager.TurnGame(request);
        }
    }
}
