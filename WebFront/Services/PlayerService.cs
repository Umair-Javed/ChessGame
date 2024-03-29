﻿using WebFront.Enums;
using WebFront.Interfaces;
using WebFront.Models;
using WebFront.MongoDbEntities;

namespace WebFront.Services
{
    // Represents a service for managing player-related operations.
    public class PlayerService : IPlayerService
    {
        #region Initialization

        // Initializes a player with the specified name and player type.
        public PlayerModel? InitializePlayer(string name, PlayerType type)
        {
            return new PlayerModel
            {
                IsCoinExposed = false,
                IsMyTurn = type == PlayerType.MAIN ? false : true,
                Name = name,
                Type = type,
                UserIcon = $"/Content/Images/Player{(int)type}/0.png"
            };
        }

        // Initializes a player with existing session information.
        public PlayerModel? InitializePlayerWithExistingSession(GameSession session, PlayerType type)
        {
            return new PlayerModel
            {
                Name = type == PlayerType.MAIN ? session.MainPlayerId : session.OpponentId,
                Type = type,
                IsMyTurn = ((session.Turn == PlayerType.MAIN) && type == PlayerType.MAIN) ? false : true,
                UserIcon = $"/Content/Images/Player{(int)type}/0.png"
            };
        }

        #endregion

        #region Coin Generation

        // Generates a shuffled list of coin models.
        public List<CoinsModel> GenerateShuffledList()
        {
            Random random = new Random();
            List<int> numbers = new List<int> { 1, 1, 1, 1, 1, 2, 2, 3, 3, 4, 4, 5, 5, 6, 6, 7 };

            List<CoinsModel> combinedList = numbers
                .SelectMany(number => new[]
                {
                new CoinsModel { Number = number, Type = PlayerType.MAIN, ImgPath = $"/Content/Images/Player1/{number}.png" },
                new CoinsModel { Number = number, Type = PlayerType.OPPONENT, ImgPath = $"/Content/Images/Player2/{number}.png" }
                })
                .OrderBy(_ => random.Next())
                .ToList();

            return combinedList;
        }
        #endregion
    }

}
