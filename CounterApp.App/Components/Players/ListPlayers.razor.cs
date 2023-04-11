using CounterApp.App.Services;
using CounterApp.Shared.Domain;
using Microsoft.AspNetCore.Components;
using System.Runtime.InteropServices;

namespace CounterApp.App.Components.Players
{
    public partial class ListPlayers
    {
        [Inject]
        public IPlayerDataService? PlayerDataService { get; set; }

        [Parameter]
        public Game? Game { get; set; }   
        
        public List<Player> Players { get; set; }

        protected override void OnInitialized()
        {
            Players = Game.PlayersList;
            StateHasChanged();
        }
        
        public void Refresh()
        {
            StateHasChanged();
        }
    }
}
