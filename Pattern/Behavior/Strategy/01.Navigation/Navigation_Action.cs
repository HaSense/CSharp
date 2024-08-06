using System;

public class Client
{
    public static void Main(string[] args)
    {
        // 전략을 람다식으로 정의
        Action<string, string> carStrategy = (start, destination) =>
            Console.WriteLine($"{start}에서 {destination}까지 자동차로 이동하는 경로를 찾았습니다.");
        
        Action<string, string> walkStrategy = (start, destination) =>
            Console.WriteLine($"{start}에서 {destination}까지 도보로 이동하는 경로를 찾았습니다.");
        
        Action<string, string> bikeStrategy = (start, destination) =>
            Console.WriteLine($"{start}에서 {destination}까지 자전거로 이동하는 경로를 찾았습니다.");

        // NavigationContext 생성 및 전략 설정
        Action<string, string> navigation = carStrategy;
        navigation("서울", "부산");

        navigation = walkStrategy;
        navigation("서울", "부산");

        navigation = bikeStrategy;
        navigation("서울", "부산");
    }
}
