using Itmo.ObjectOrientedProgramming.Lab1;
using JetBrains.Annotations;
using Xunit;

namespace Lab1.Tests;

[TestSubject(typeof(Train))]
public class TrainTest
{
    [Fact]
    public void TestCase1()
    {
        var train = new Train(1, 10);
        var arr = new Railway[2];
        arr[0] = new PowerRail(10, 1);
        arr[1] = new Railway(10);
        var route = new Route(4.0, arr);
        Assert.True(route.GoThroughRoute(train, 1));
    }

    [Fact]
    public void TestCase2()
    {
        var train = new Train(1, 10);
        var arr = new Railway[2];
        arr[0] = new PowerRail(10, 1);
        arr[1] = new Railway(10);
        var route = new Route(3.9, arr);
        Assert.False(route.GoThroughRoute(train, 1));
    }

    [Fact]
    public void TestCase3()
    {
        var train = new Train(1, 10);
        var arr = new Railway[4];
        arr[0] = new PowerRail(10, 1);
        arr[1] = new Railway(10);
        arr[2] = new Station(10, 4.0);
        arr[3] = new Railway(10);
        var route = new Route(4.0, arr);
        Assert.True(route.GoThroughRoute(train, 1));
    }

    [Fact]
    public void TestCase4()
    {
        var train = new Train(1, 10);
        var arr = new Railway[3];
        arr[0] = new PowerRail(10, 1);
        arr[1] = new Station(10, 3.9);
        arr[2] = new Railway(10);
        var route = new Route(4.0, arr);
        Assert.False(route.GoThroughRoute(train, 1));
    }

    [Fact]
    public void TestCase5()
    {
        var train = new Train(1, 10);
        var arr = new Railway[4];
        arr[0] = new PowerRail(10, 1);
        arr[1] = new Railway(10);
        arr[2] = new Station(10, 5.0);
        arr[3] = new Railway(10);
        var route = new Route(3.0, arr);
        Assert.False(route.GoThroughRoute(train, 1));
    }

    [Fact]
    public void TestCase6()
    {
        var train = new Train(1, 10);
        var arr = new Railway[8];
        arr[0] = new PowerRail(10, 10);
        arr[1] = new Railway(10);
        arr[2] = new PowerRail(10, -1);
        arr[3] = new Station(10, 8.0);
        arr[4] = new Railway(10);
        arr[5] = new PowerRail(10, 2);
        arr[6] = new Railway(10);
        arr[7] = new PowerRail(10, -1);
        var route = new Route(8.0, arr);
        Assert.True(route.GoThroughRoute(train, 1));
    }

    [Fact]
    public void TestCase7()
    {
        var train = new Train(1, 10);
        var arr = new Railway[1];
        arr[0] = new Railway(10);
        var route = new Route(100.0, arr);
        Assert.False(route.GoThroughRoute(train, 1));
    }

    [Fact]
    public void TestCase8()
    {
        var train = new Train(1, 10);
        var arr = new Railway[2];
        arr[0] = new PowerRail(10, 1);
        arr[1] = new PowerRail(10, -2);
        var route = new Route(100.0, arr);
        Assert.False(route.GoThroughRoute(train, 1));
    }
}