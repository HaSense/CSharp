using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using gRPCServer_V1;

namespace gPRCClient_V1
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            // HTTP/2 지원 채널 생성
            using var channel = GrpcChannel.ForAddress("http://localhost:5000");
            var client = new Greeter.GreeterClient(channel);

            Console.WriteLine("[클라이언트] 서버에 메시지를 전송합니다...");
            var reply = await client.SayHelloAsync(new HelloRequest { Name = "테스트 사용자" });
            Console.WriteLine($"[클라이언트] 서버 응답: {reply.Message}");
        }
    }
}
