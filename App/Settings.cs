namespace App
{
    public class Settings
    {
        public string AppId { get; set; }
        public string ApiKey { get; set; }
        public int TimeoutInSeconds { get; } = 30;
        public string ApiUrl => $"https://api.applicationinsights.io/v1/apps/{AppId}";
    }
}
