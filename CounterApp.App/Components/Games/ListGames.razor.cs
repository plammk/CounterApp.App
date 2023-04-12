using CounterApp.App.Pages;
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

        [Inject]
        public NavigationManager? NavigationManager { get; set; }
        [Parameter]
        public List<Game>? GamesList { get; set; } = default!;

        protected override async Task OnParametersSetAsync()
        {
            await SetGamesList();
        }

        protected async Task SetGamesList()
        {
            GamesList = (await GameDataService.GetAllGames()).ToList();
        } 

        protected async Task HandleDelete(int gameId)
        {
            await GameDataService.DeleteGame(gameId);
            await SetGamesList();
            StateHasChanged();
            ShouldRender();
        }

        protected async Task NavigateToGameOverview(int gameId)
        {
            NavigationManager.NavigateTo($"/overview/{gameId}");
        }


    }
}
