# WxWorkBot

企业微信机器人，开箱即用。目前已实现：

 - 纯文本消息
 - Markdown消息

### `WxWorkBotClient`类直接使用

先安装 WxWorkRobot 包: [![](https://img.shields.io/nuget/v/WxWorkRobot.svg)](https://www.nuget.org/packages/WxWorkRobot)，然后参考使用示例：

```C#
var webhookKey = "d77f7c20-90ba-462a-9251-36ecdd63c5d8";
var wxWorkBotClient = WxWorkBotClient.WithKey(webhookKey);
await wxWorkBotClient.SendText("测试");
```

### 依赖注入（Microsoft Dependency）
先安装 WxWorkRobot.MsDependency包: [![](https://img.shields.io/nuget/v/WxWorkRobot.MsDependency.svg)](https://www.nuget.org/packages/WxWorkRobot.MsDependency)

配置服务AddWxWorkBotService：
```C#
public void ConfigureServices(IServiceCollection services)
{
    var webhookKey = "d77f7c20-90ba-462a-9251-36ecdd63c5d8";
    services.AddWxWorkBotService(webhookKey);
}
```
或appsettings.json中配置有：
``` Json
"WxWorkRobot": {
  "WebhookKey": "d77f7c20-90ba-462a-9251-36ecdd63c5d8"
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
