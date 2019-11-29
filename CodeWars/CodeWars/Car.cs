using System;

public class Car : ICar
{
    public IFuelTankDisplay fuelTankDisplay;

    private IEngine engine;

    private IFuelTank fuelTank;


    public Car()
    {
        //engine.   //how do get tank to ref out to ther obj
        fuelTank.Refuel(20);

    }

    public Car(double fuelLevel)
    {
        fuelTank.Refuel(fuelLevel);
    }

    public bool EngineIsRunning
    {
        get { return engine.IsRunning; }
    }

    public void EngineStart()
    {
        engine.Start();
        RunningIdle();
    }

    public void EngineStop()
    {
        engine.Stop();
    }

    public void Refuel(double liters)
    {
        fuelTank.Refuel(liters);
    }

    public void RunningIdle()
    {
         engine.Consume(0.0003);
    }
}

public class Engine : IEngine
{
    bool isRunning;
    IFuelTank tank; //how do we get the tank ref

    public void TankRef(IFuelTank t) {
        tank = t;
    }
    

    public bool IsRunning {
        get { return isRunning; }
    }

    public void Consume(double liters)
    {
        tank.Consume(liters);
    }

    public void Start()
    {
        isRunning = true;
    }

    public void Stop()
    {
        isRunning = false;
    }
}

public class FuelTank : IFuelTank
{
    double fillLevel;

    public double FillLevel
    {
        get { return fillLevel; }
        set { fillLevel = value; }
    }


    public bool IsOnReserve
    {
        get {
            if (fillLevel < 5)
                return true;
            else
                return false;
        }
    }

    public bool IsComplete {
        get
        {
            if (fillLevel == 60)
                return true;
            else
                return false;
        }
    }


    public void Consume(double liters)
    {
        fillLevel -= liters;
    }

    public void Refuel(double liters)
    {
        //add up to 60
        fillLevel += liters;
        if (fillLevel > 60)
            fillLevel = 60;
    }
}

public class FuelTankDisplay : IFuelTankDisplay
{
    public FuelTank tank;

    double fillLevel; //2 decimal places.

    public double FillLevel {
        get { return FillLevel; }
    }

    public bool IsOnReserve { get { this. }  }
    

    public bool IsComplete { get { } }
}