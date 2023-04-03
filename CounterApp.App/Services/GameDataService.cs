using CounterApp.Shared.Domain;
using System.Text;
using System.Text.Json;

namespace CounterApp.App.Services
{
    public class GameDataService : IGameDataService
    {
        private readonly HttpClient _httpClient;

        public GameDataService(HttpClient httpClient)
        {
              _httpClient = httpClient;
        }

        public async Task<IEnumerable<Game>> GetAllGames()
        {
            var list = await JsonSerializer.DeserializeAsync<IEnumerable<Game>>
                (await _httpClient.GetStreamAsync($"api/game"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            return list;
        }

        public async Task<Game> AddGame(Game game)
        {
            var gameJson = new StringContent(JsonSerializer.Serialize(game), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/game", gameJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Game>(await response.Content.ReadAsStreamAsync());
            }

            return null;  
        }
    }
}
