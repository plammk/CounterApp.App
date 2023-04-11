using CounterApp.App.Components.Games;
using CounterApp.App.Services;
using CounterApp.Shared.Domain;
using Microsoft.AspNetCore.Components;
using System.Data;

namespace CounterApp.App.Pages
{
    public partial class EditGame
    {
        [Inject]
        public IGameDataService? GameDataService { get; set; }

        [Inject]
        public IPlayerDataService? PlayerDataService { get; set; }

        [Inject]
        NavigationManager NavManager { get; set; }
        
        [Parameter]
        public string GameId { get; set; }

        public Game? CurrGame { get; set; } = new Game();

        public Player Player { get; set; } = new Player();

        protected override async Task OnParametersSetAsync()
        {
            await SetCurrentGame();
        }

        protected async void HandleAddPlayer()
        {
            await PlayerDataService.AddPlayer(Player, int.Parse(GameId));
            await SetCurrentGame();
        }

        protected void HandleDelete()
        {
            GameDataService.DeleteGame(int.Parse(GameId));
            NavManager.NavigateTo("/");
        }

        protected async Task SetCurrentGame()
        {
            CurrGame = await GameDataService.GetGameById((int.Parse(GameId)));
            StateHasChanged();
        }

        protected async Task UpdatePlayersPoints(Player PlayerToUpdate)
        {
            await PlayerDataService.UpdatePlayersPoints(int.Parse(GameId), PlayerToUpdate);
            SetCurrentGame();
        }

        protected async void IncreasePlayersPoints(Player PlayerToUpdate,int points)
        {
            PlayerToUpdate.Points += points;
        }

        protected async void DecreasePlayersPoints(Player PlayerToUpdate,int points)
        {
            PlayerToUpdate.Points -= points;
        }

        protected async void DeletePlayer(int PlayerToDeleteId)
        {
            await PlayerDataService.DeletePlayer(int.Parse(GameId), PlayerToDeleteId);
            SetCurrentGame();
        }

        protected async void SaveGame()
        {
            foreach(var player in CurrGame.PlayersList)
            {
                await UpdatePlayersPoints(player);
            }

            NavManager.NavigateTo("/");
        }

    }
}
