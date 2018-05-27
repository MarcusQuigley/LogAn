namespace Quigley.LogAn.Tests.Stubs
{
    public class MockWebService : IWebService
    {
        public string LastError { get; private set; }
        public void LogError(string message)
        {
            LastError = message;
        }
    }
}
