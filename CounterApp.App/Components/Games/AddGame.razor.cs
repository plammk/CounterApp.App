using CounterApp.App.Services;
using CounterApp.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace CounterApp.App.Components.Games
{
    public partial class AddGame
    {
        [Inject]
        public IGameDataService? GameDataService { get; set; }
        [Inject]
        NavigationManager NavManager { get; set; }

        private Game Game { get; set; } = new Game();

        protected async Task HandleSubmit()
        {
            await GameDataService.AddGame(Game);
            NavManager.NavigateTo("/");
        }
    }
}
