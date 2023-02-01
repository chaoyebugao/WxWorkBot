namespace WxWorkRobot.Tests
{
    public class WxWorkBotClientTest
    {
        [Theory]
        [InlineData("you-webhook-key-here")]
        public async Task SendText(string key)
        {
            var wxWorkBotClient = WxWorkBotClient.WithKey(key);

            await wxWorkBotClient.SendText("≤‚ ‘2");
        }
    }
}