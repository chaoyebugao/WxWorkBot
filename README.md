# WxWorkBot


企业微信机器人，开箱即用，无第三方依赖；目前已实现：

 - 纯文本消息
 - Markdown消息
 - 支持初始化回调Key，实例范围内修改回调Key，方法范围内修改回调Key，以在不同层面支持多个Bot

## 版本更新Tip
 - 2.0.4: 直接使用插值拼接消息，不再依赖Json序列化组件
 - 2.0.3: 支持方法级别设置回调Key
 - 2.0.2: 有几个关键变化，见下面[2.0版本变化](#20版本变化)
 - 1.3.0: 替换掉Flurl.Http，因为其可能会出现不能向后兼容的情况

### 依赖注入
先安装 WxWorkRobot: [![](https://img.shields.io/nuget/v/WxWorkRobot.svg)](https://www.nuget.org/packages/WxWorkRobot)

配置服务AddWxWorkBotService：
```C#
public void ConfigureServices(IServiceCollection services)
{
    //从配置文件加载配置进行依赖注入
    services.AddWxWorkBotService(context.Configuration);

    //直接指定参数
    //services.AddWxWorkBotService(
    //    webhookKey: "7b0a1288-1029-444e-9d50-22f1a9b17f47",
    //    sendingResponseLogLevel: Microsoft.Extensions.Logging.LogLevel.Information);

    //使用Option
    //services.AddWxWorkBotService(new WxWorkBotOptions()
    //{
    //    WebhookKey = "7b0a1288-1029-444e-9d50-22f1a9b17f47",
    //    SendingResponseLogLevel = Microsoft.Extensions.Logging.LogLevel.Information,
    //});
}
```
如果从配置文件加载配置进行依赖注入，`appsettings.json`中要配置有（其他支持配置的选项还有WebhookUrlTemplate/SendingResponseLogLevel）：
``` Json
"WxWorkRobot": {
  "WebhookKey": "7b0a1288-1029-444e-9d50-22f1a9b17f47"
}
```

### 使用

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

如果想要使用非默认调用Key（非初始化的调用Key）:
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
    //在实例范围内修改回调Key
    //client.SetKey("b19d3e0f-e7a6-4823-bf5b-462b8fa21d85");

    //在方法范围内修改回调Key
    await client.SendText(text, "b19d3e0f-e7a6-4823-bf5b-462b8fa21d85");
}
```

### 2.0版本变化
- WxWorkRobot.MsDependency包不再使用，直接合并为一个WxWorkRobot包
- 不再使用RestSharp或第三方HTTP客户端，RestSharp仍然可能有版本问题
- 使用[.NET 的 IHttpClientFactory](https://learn.microsoft.com/zh-cn/dotnet/core/extensions/httpclient-factory)的方式去发起HTTP请求
- 加入日志输出等选项，具体见[WxWorkBotOptions](https://github.com/chaoyebugao/WxWorkBot/blob/main/WxWorkRobot/Options/WxWorkBotOptions.cs)
- 支持方法级别设置回调Key
