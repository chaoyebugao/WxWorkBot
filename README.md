# WxWorkBot


企业微信机器人，开箱即用。目前已实现：

 - 纯文本消息
 - Markdown消息

## 版本更新Tip
 - 1.3.0: 替换掉Flurl.Http，因为其可能会出现不能向后兼容的情况
 - 2.0.1: 有几个关键变化，见下面[2.0版本变化](#ver200change)

### 依赖注入（Microsoft Dependency）
先安装 WxWorkRobot: [![](https://img.shields.io/nuget/v/WxWorkRobot.svg)](https://www.nuget.org/packages/WxWorkRobot)

配置服务AddWxWorkBotService：
```C#
public void ConfigureServices(IServiceCollection services)
{
    //services.AddWxWorkBotService(
    //    webhookKey: "7b0a1288-1029-444e-9d50-22f1a9b17f47",
    //    sendingResponseLogLevel: Microsoft.Extensions.Logging.LogLevel.Information);

    services.AddWxWorkBotService(new WxWorkBotOptions()
    {
        WebhookKey = "7b0a1288-1029-444e-9d50-22f1a9b17f47",
        SendingResponseLogLevel = Microsoft.Extensions.Logging.LogLevel.Information,
    });
}
```
或appsettings.json中配置有：
``` Json
"WxWorkRobot": {
  "WebhookKey": "7b0a1288-1029-444e-9d50-22f1a9b17f47"
}
```
然后依然是AddWxWorkBotService:
```C#
public void ConfigureServices(IServiceCollection services)
{
    services.AddWxWorkBotService(Configuration);
}
```

构造函数直接构造实例并使用，参考使用示例：
```C#
public class SampleService
{
    private readonly WxWorkBotClient client;

    public SampleService(WxWorkBotClient client)
    {
        this.client = client;
    }

    public async Task SendTextTest()
    {
        await client.SendText("测试");
    }
}
```

如果想要使用非默认webhook key:
``` C#
private readonly WxWorkBotClient client;

public WxWorkBotClientTest(WxWorkBotClient client)
{
    this.client = client;
}

[Theory]
[InlineData("Test1")]
public async Task SendText(string text)
{
    // 覆盖默认webhook key
    client.SetKey("xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx");
    await client.SendText(text);
}
```

### 2.0版本变化 {#ver200change}
- WxWorkRobot.MsDependency包不再使用，直接合并为一个WxWorkRobot包
- 不再使用RestSharp或第三方HTTP客户端，RestSharp仍然可能有版本问题
- 使用[.NET 的 IHttpClientFactory](https://learn.microsoft.com/zh-cn/dotnet/core/extensions/httpclient-factory)的方式去发起HTTP请求
- 加入日志输出等选项，具体见[WxWorkBotOptions](https://github.com/chaoyebugao/WxWorkBot/blob/main/WxWorkRobot/Options/WxWorkBotOptions.cs)
