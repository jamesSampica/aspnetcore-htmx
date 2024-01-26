using Hydro;

namespace MyApp.Pages.Components;

public class Counter : HydroComponent
{
    public int Count { get; set; }
    
    public void Add()
    {
        Count++;
    }
}