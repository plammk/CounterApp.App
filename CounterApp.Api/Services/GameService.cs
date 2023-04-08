using CounterApp.Shared.Domain;

namespace CounterApp.Api.Services
{
    public class GameService : IGameService
    {
        private List<Game> _list;

        public GameService() 
        { 
            if(_list == null)
            {
                _list = new List<Game>();
            }           
        }

        public List<Game> List { get { return _list; } }

        private int _currId=1;
        
        public IEnumerable<Game> GetAllGames()
        {
            return _list;
        }

        public Game AddGame(Game game)
        {
            game.Id = _currId;
            _currId++;
            _list.Add(game);
                     
            return game;
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
