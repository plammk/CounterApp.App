using CounterApp.Shared.Domain;

namespace CounterApp.Api.Models
{
    public class GamesList : IGamesList
    {
        public List<Game> _list;

        public GamesList()
        {
            if (_list == null)
            {
                _list = new List<Game>();
            }
        }
    }
}
