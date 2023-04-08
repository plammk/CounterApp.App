using CounterApp.App.Services;
using CounterApp.Shared.Domain;
using Microsoft.AspNetCore.Components;
using System.Runtime.CompilerServices;

namespace CounterApp.App.Components.Games
{
    public partial class ListGames
    {
        [Inject]
        public IGameDataService? GameDataService { get; set; }
       
        public List<Game>? GamesList { get; set; } = default!;

        protected override async Task OnInitializedAsync()
        {
            GamesList = (await GameDataService.GetAllGames()).ToList();
        } 
        
        private async Task HandleDelete(int gameId)
        {
            GameDataService.DeleteGame(gameId);
        }
    }
}
