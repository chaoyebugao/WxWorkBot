
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
        public async Task SendText(string text)
        {
            client.SetKey("a693c72d-8c65-4462-81b0-20220970a3b6");
            await client.SendText(text);
        }

        [Theory]
        [InlineData("# ≤‚ ‘œ¬")]
        public async Task SendMarkdown(string content)
        {
            await client.SendMarkdown(content);
        }
    }
}