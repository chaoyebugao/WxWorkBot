namespace WxWorkRobot.Tests
{
    public class WxWorkBotClientTest
    {
        [Theory]
        [InlineData("71610d83-e679-45a9-9e14-335f235307ee")]
        public async Task SendText(string key)
        {
            var wxWorkBotClient = WxWorkBotClient.WithKey(key);

            await wxWorkBotClient.SendText("≤‚ ‘2");
        }
    }
}