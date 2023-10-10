using Microsoft.AspNetCore.Components;

namespace QuantumPM_Task.Tests
{
    public class TestNav: NavigationManager
    {
        public TestNav()
        {
            Initialize("https://unit-test.example/", "https://unit-test.example/");
        }

        protected override void NavigateToCore(string uri, bool forceLoad)
        {
            NotifyLocationChanged(false);
        }
    }
}
