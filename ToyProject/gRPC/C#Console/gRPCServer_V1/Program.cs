
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Builder;

namespace gRPCServer_V1
{
    // gRPC 서비스 구현
    public class GreeterService : Greeter.GreeterBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            Console.WriteLine($"[서버] 클라이언트로부터 받은 메시지: {request.Name}");
            return Task.FromResult(new HelloReply
            {
                Message = $"안녕하세요, {request.Name}님!"
            });
        }
    }
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            var host = Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.ConfigureKestrel(options =>
                    {
                        // HTTP/2 프로토콜 활성화
                        options.ListenLocalhost(5000, o => o.Protocols = HttpProtocols.Http2);
                    });
                    webBuilder.ConfigureServices(services =>
                    {
                        services.AddGrpc();
                    });
                    webBuilder.Configure(app =>
                    {
                        app.UseRouting();
                        app.UseEndpoints(endpoints =>
                        {
                            endpoints.MapGrpcService<GreeterService>();
                        });
                    });
                })
                .Build();

            Console.WriteLine("gRPC 서버가 실행 중입니다. 포트: 5000");
            await host.RunAsync();
        }
    }

}
