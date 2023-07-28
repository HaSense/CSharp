public interface IRouteStrategy
{
    void FindRoute(string start, string destination);
}

public class CarRouteStrategy : IRouteStrategy
{
    public void FindRoute(string start, string destination)
    {
        Console.WriteLine($"{start}에서 {destination}까지 자동차로 이동하는 경로를 찾았습니다.");
    }
}

public class WalkRouteStrategy : IRouteStrategy
{
    public void FindRoute(string start, string destination)
    {
        Console.WriteLine($"{start}에서 {destination}까지 도보로 이동하는 경로를 찾았습니다.");
    }
}

public class BikeRouteStrategy : IRouteStrategy
{
    public void FindRoute(string start, string destination)
    {
        Console.WriteLine($"{start}에서 {destination}까지 자전거로 이동하는 경로를 찾았습니다.");
    }
}

public class NavigationContext
{
    private IRouteStrategy _strategy;

    public NavigationContext(IRouteStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetRouteStrategy(IRouteStrategy strategy)
    {
        _strategy = strategy;
    }

    public void FindRoute(string start, string destination)
    {
        _strategy.FindRoute(start, destination);
    }
}

public class Client
{
    public static void Main(string[] args)
    {
        var carStrategy = new CarRouteStrategy();
        var walkStrategy = new WalkRouteStrategy();
        var bikeStrategy = new BikeRouteStrategy();

        var navigation = new NavigationContext(carStrategy);
        navigation.FindRoute("서울", "부산");

        navigation.SetRouteStrategy(walkStrategy);
        navigation.FindRoute("서울", "부산");

        navigation.SetRouteStrategy(bikeStrategy);
        navigation.FindRoute("서울", "부산");
    }
}
