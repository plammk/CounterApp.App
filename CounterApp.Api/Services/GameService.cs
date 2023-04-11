﻿using CounterApp.Api.Models;
using CounterApp.Shared.Domain;

namespace CounterApp.Api.Services
{
    public class GameService : IGameService
    {
        public List<Game> _list;

        public GameService()
        {
            if (_list == null)
            {
                _list = new List<Game>();
            }
        }

        public List<Game> List { get { return _list; } }

        private int _currGameId=1;
        
        public IEnumerable<Game> GetAllGames()
        {
            return _list;
        }
        public IEnumerable<Player> GetAllPlayers(int gameId)
        {
            foreach (var game in _list)
            {
                if (game.Id == gameId)
                {
                    return game.PlayersList;
                }
            }

            return null;
        }

        public Game AddGame(Game game)
        {
            game.Id = _currGameId;
            _currGameId++;
            _list.Add(game);
                     
            return game;
        }


        public Player AddPlayer(Player player, int id)
        {
            foreach (var game in _list)
            {
                if (game.Id == id)
                {
                    player.Id = game.CurrPlayerId;
                    game.CurrPlayerId++;
                    game.PlayersList.Add(player);
                }
            }

            return player;
        }

        public void UpdatePlayersPoints(int gameId, Player playerToUpdate)
        {
            foreach(var game in _list)
            {
                if(game.Id == gameId)
                {
                    foreach(var player in game.PlayersList)
                    {
                        if (player.Id == playerToUpdate.Id) 
                        {
                            player.Points = playerToUpdate.Points;
                        }
                    }
                }
            }
        }

        public Game GetGameById(int id)
        {
            foreach(var game in _list)
            {   
                if(game.Id == id)
                {
                    return game;
                }
            }
            return null;
        }

        public Game DeleteGame(int gameId)
        {
            foreach(var game in _list)
            {
                if(game.Id == gameId)
                {
                    List.Remove(game);
                    return game;                   
                }
            }
            return null;
        }
    }
}
