using CounterApp.Shared.Domain;
using System.Net.Http.Json;
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

        List<Game> GamesList { get; set; } = new List<Game>();

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
                var returned = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Game>(returned);
            }

            return null;  
        }

        public async Task<Game> GetGameById(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<Game>($"api/game/{id}");

            return response;
        }

        public async Task DeleteGame(int gameId)
        {
            await _httpClient.DeleteAsync($"api/game/{gameId}");
        }
    }
}
