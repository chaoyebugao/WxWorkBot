namespace WxWorkRobot.Tests
{
    public class WxWorkBotClientTest
    {
        private readonly WxWorkBotClient client;

        public WxWorkBotClientTest(WxWorkBotClient client)
        {
            this.client = client;
        }

        [Theory]
        [InlineData("Test pure text")]
        public async Task SendText(string text)
        {
            await client.SendText(text);
        }

        [Theory]
        [InlineData("Test pure text - other key")]
        public async Task SendText_OtherKey(string text)
        {
            //在实例范围内修改回调Key
            //client.SetKey("b19d3e0f-e7a6-4823-bf5b-462b8fa21d85");

            //在方法范围内修改回调Key
            await client.SendText(text, "b19d3e0f-e7a6-4823-bf5b-462b8fa21d85");
        }


        [Theory]
        [InlineData("# Test Markdown")]
        public async Task SendMarkdown(string markdown)
        {
            await client.SendMarkdown(markdown);
        }

        [Theory]
        [InlineData("# Test Markdown - other key")]
        public async Task SendMarkdown_OtherKey(string markdown)
        {
            //在实例范围内修改回调Key
            //client.SetKey("b19d3e0f-e7a6-4823-bf5b-462b8fa21d85");

            //在方法范围内修改回调Key
            await client.SendMarkdown(markdown, "b19d3e0f-e7a6-4823-bf5b-462b8fa21d85");
        }
    }
}