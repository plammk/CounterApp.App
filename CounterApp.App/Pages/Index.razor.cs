
using CounterApp.App.Services;
using CounterApp.Shared.Domain;
using Microsoft.AspNetCore.Components;
using System.Data;
using System.Net;
using System.Text;
using System.Text.Json;

namespace CounterApp.App.Pages
{
    public partial class Index
    {
        [Inject]
        public IGameDataService? GameDataService { get; set; }

        private Game Game { get; set; } = new Game();
                
        public List<Game>? Games { get; set; } = default!;
       
        protected async override Task OnInitializedAsync()
        {
            Games = (await GameDataService.GetAllGames()).ToList();          
        }
        protected async Task HandleSubmit()
        {
            var addedGame = await GameDataService.AddGame(Game);
            StateHasChanged();
        }
        
    }
  

}
