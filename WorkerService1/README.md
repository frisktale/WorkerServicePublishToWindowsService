# Asp.NET Core 部署到Windows服务
使用serilog时需要指定文件目录，否则日志文件会写入`System32` 文件夹下。  
```csharp
.WriteTo.File(Path.Combine(AppContext.BaseDirectory, "serilogTest.txt")))
```
下为部署到windows服务时，几种方法返回的路径
```
env.ContentRootPath : D:\workspace\WorkerService1\WorkerService1\bin\Release\net6.0\publish\
AppContext.BaseDirectory : D:\workspace\WorkerService1\WorkerService1\bin\Release\net6.0\publish\
Directory.GetCurrentDirectory() : C:\WINDOWS\system32
AppDomain.CurrentDomain.BaseDirectory : D:\workspace\WorkerService1\WorkerService1\bin\Release\net6.0\publish\
```
