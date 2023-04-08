using CounterApp.App.Services;
using CounterApp.Shared.Domain;
using Microsoft.AspNetCore.Components;

namespace CounterApp.App.Pages
{
    public partial class Games
    {
        [Inject]
        NavigationManager NavManager { get; set; }  

        private void HandleAddGame()
        {
            NavManager.NavigateTo("/add");
        }
    }
}
