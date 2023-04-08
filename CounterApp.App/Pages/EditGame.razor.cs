using CounterApp.App.Services;
using CounterApp.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace CounterApp.App.Pages
{
    public partial class EditGame
    {
        [Inject]
        public IGameDataService? GameDataService { get; set; }

        [Inject]
        NavigationManager NavManager { get; set; } 
        
        [Parameter]
        public string GameId { get; set; }

        public Game? Game { get; set; } = new Game();

        protected override async Task OnInitializedAsync()
        {
            Game = await GameDataService.GetGameById((int.Parse(GameId)));
        }

        protected void HandleDelete()
        {
            GameDataService.DeleteGame(int.Parse(GameId));
            NavManager.NavigateTo("/");
        }
    }
}
