namespace WxWorkRobot.MsDependency.Tests
{
    public class WxWorkBotClientTest
    {
        private readonly WxWorkBotClient client;

        public WxWorkBotClientTest(WxWorkBotClient client)
        {
            this.client = client;
        }

        [Theory]
        [InlineData("Test1")]
        [InlineData("Test2")]
        public async Task SendText(string text)
        {
            await client.SendText(text);
        }
    }
}