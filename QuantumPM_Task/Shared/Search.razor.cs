using Microsoft.AspNetCore.Components;

namespace QuantumPM_Task.Shared
{
    public partial class Search
    {
        [Parameter] public EventCallback<ChangeEventArgs> SearchItemCallBack { get; set; }
    }
}
