using CounterApp.Api.Controllers;
using CounterApp.Api.Models;
using CounterApp.App.Services;
using CounterApp.Shared.Domain;
using Microsoft.AspNetCore.Components;
using System.Runtime.ExceptionServices;

namespace CounterApp.Api.Services
{
    public class PlayerService : IPlayerService
    {
        private GamesList _gamesList;

        public IEnumerable<Player> GetAllPlayers(int gameId)
        {
            foreach (var game in _gamesList._list)
            {
                if (game.Id == gameId)
                {
                    return game.PlayersList;
                }
            }

            return null;
        }
    }
}
