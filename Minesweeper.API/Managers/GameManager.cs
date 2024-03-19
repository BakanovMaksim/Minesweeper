using Microsoft.Extensions.Caching.Memory;

using Minesweeper.API.Infrastructure;
using Minesweeper.API.Models;
using Minesweeper.API.Models.Requests;
using Minesweeper.API.Models.Responses;
using Minesweeper.Core.Models;
using Minesweeper.Core.Services;

namespace Minesweeper.API.Managers
{
    public class GameManager : IGameManager
    {
        private readonly IMemoryCache memoryCache;
        private readonly IGameDrawingService gameDrawingService;
        private readonly IGameCreatingService gameCreatingService;
        private readonly IGameProcessingService gameProcessingService;
        private readonly IGameValidationManager gameValidationManager;

        private readonly ICollection<GameStatus> completedGameStatuses = new[]
        {
            GameStatus.Failed,
            GameStatus.Successful,
        };

        public GameManager(
            IMemoryCache memoryCache,
            IGameDrawingService gameDrawingService,
            IGameCreatingService gameCreatingService,
            IGameProcessingService gameProcessingService,
            IGameValidationManager gameValidationManager)
        {
            this.memoryCache = memoryCache;
            this.gameDrawingService = gameDrawingService;
            this.gameCreatingService = gameCreatingService;
            this.gameProcessingService = gameProcessingService;
            this.gameValidationManager = gameValidationManager;
        }

        public GameInfoResponse CreateGame(NewGameRequest request)
        {
            gameValidationManager
                .ValidateFieldWidth(request.Width)
                .ValidateFieldHeight(request.Height)
                .ValidateFieldMinesCount(request.MinesCount, request.Width, request.Height);

            var field = gameCreatingService.GetNewField(request.Width, request.Height, request.MinesCount);
            var fieldView = gameDrawingService.GetNewField(request.Width, request.Height);

            var gameId = Guid.NewGuid();

            var cacheData = new GameFieldCacheData
            {
                GameId = gameId,
                Width = request.Width,
                Height = request.Height,
                MinesCount = request.MinesCount,
                Field = field,
            };

            memoryCache.Set(gameId, cacheData, TimeSpan.FromMinutes(10));

            return MapToGameInfoResponse(
                gameId,
                request.Width,
                request.Height,
                request.MinesCount,
                fieldView);
        }

        public GameInfoResponse TurnGame(GameTurnRequest request)
        {
            var cacheData = memoryCache.Get<GameFieldCacheData>(request.GameId);

            var currentCell = cacheData?.Field.GetValueOrDefault(request.Row, request.Col);

            gameValidationManager
                .ValidateGameFieldExisted(request.GameId, cacheData?.Field)
                .ValidateGameFieldCellExisted(currentCell)
                .ValidateGameFieldCellOpened(currentCell);

            gameProcessingService.OpenCell(
                cacheData.Field,
                request.Row,
                request.Col,
                cacheData.Width,
                cacheData.Height);

            var gameStatus = gameProcessingService.GetGameStatus(
                currentCell,
                cacheData.Field,
                cacheData.Width,
                cacheData.Height,
                cacheData.MinesCount);

            var completed = completedGameStatuses.Contains(gameStatus);
            if (completed)
            {
                memoryCache.Remove(request.GameId);
            }

            var fieldView = gameDrawingService.GetProcessedField(cacheData.Field, gameStatus);

            return MapToGameInfoResponse(
                cacheData.GameId,
                cacheData.Width,
                cacheData.Height,
                cacheData.MinesCount,
                fieldView,
                completed);
        }

        private static GameInfoResponse MapToGameInfoResponse(
            Guid gameId,
            int width,
            int height,
            int minesCount,
            string[][] field,
            bool completed = false)
        {
            return new()
            {
                GameId = gameId,
                Width = width,
                Height = height,
                MinesCount = minesCount,
                Completed = completed,
                Field = field,
            };
        }
    }
}
