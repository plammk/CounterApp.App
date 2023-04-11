using CounterApp.Shared.Domain;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace CounterApp.App.Services
{
    public class PlayerDataService : IPlayerDataService
    {
        private readonly HttpClient _httpClient;

        public PlayerDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Player>> GetAllPlayers(int id)
        {
            var response = await JsonSerializer.DeserializeAsync<IEnumerable<Player>>
                (await _httpClient.GetStreamAsync($"api/player/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
            if (response != null)
            {
                return response;
            }
            else
                return null;
        }

        public async Task<Player> AddPlayer(Player player, int id)
        {
            var playerJson = new StringContent(JsonSerializer.Serialize(player), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync($"api/player/{id}", playerJson);

            if (response.IsSuccessStatusCode)
            {
                var returned = await response.Content.ReadAsStreamAsync();
                return await JsonSerializer.DeserializeAsync<Player>(returned);
            }

            return null;
        }

        public async Task UpdatePlayersPoints(int gameId, Player player)
        {   
            await _httpClient.PutAsync($"api/player/{player.Id}/game/{gameId}/points/{player.Points}",null);
        }

        public async Task DeletePlayer(int gameId, int playerId)
        {
            await _httpClient.DeleteAsync($"api/player/{playerId}/game/{gameId}");
        }

    }
}
