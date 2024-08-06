using System;

public delegate void RouteStrategy(string start, string destination);

public class NavigationContext
{
    private RouteStrategy _strategy;

    public NavigationContext(RouteStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetRouteStrategy(RouteStrategy strategy)
    {
        _strategy = strategy;
    }

    public void FindRoute(string start, string destination)
    {
        _strategy(start, destination);
    }
}

public class Client
{
    public static void Main(string[] args)
    {
        RouteStrategy carStrategy = (start, destination) =>
        {
            Console.WriteLine($"{start}에서 {destination}까지 자동차로 이동하는 경로를 찾았습니다.");
        };

        RouteStrategy walkStrategy = (start, destination) =>
        {
            Console.WriteLine($"{start}에서 {destination}까지 도보로 이동하는 경로를 찾았습니다.");
        };

        RouteStrategy bikeStrategy = (start, destination) =>
        {
            Console.WriteLine($"{start}에서 {destination}까지 자전거로 이동하는 경로를 찾았습니다.");
        };

        var navigation = new NavigationContext(carStrategy);
        navigation.FindRoute("서울", "부산");

        navigation.SetRouteStrategy(walkStrategy);
        navigation.FindRoute("서울", "부산");

        navigation.SetRouteStrategy(bikeStrategy);
        navigation.FindRoute("서울", "부산");
    }
}
