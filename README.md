# WxWorkBot

企业微信机器人，开箱即用

### `WxWorkBotClient`类直接使用

```C#
var webhookKey = "d77f7c20-90ba-462a-9251-36ecdd63c5d8";
var wxWorkBotClient = WxWorkBotClient.WithKey(webhookKey);
await wxWorkBotClient.SendText("测试");
```

### 依赖注入（Microsoft Dependency）

```C#
public void ConfigureServices(IServiceCollection services)
{
    var webhookKey = "d77f7c20-90ba-462a-9251-36ecdd63c5d8";
    services.AddWxWorkBotService(webhookKey);
}
```

然后构造函数直接构造实例并使用：

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
