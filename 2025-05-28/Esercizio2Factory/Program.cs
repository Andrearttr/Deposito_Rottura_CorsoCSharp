using System;
using System.Security.Cryptography.X509Certificates;

public interface IShape
{
    void Draw();
}

public class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("\n  * *  ");
        Console.WriteLine("*     *");
        Console.WriteLine("*     *");
        Console.WriteLine("  * *  ");
    }
}

public class Square : IShape
{
    public void Draw()
    {
        Console.WriteLine("\n* * * *");
        Console.WriteLine("*     *");
        Console.WriteLine("*     *");
        Console.WriteLine("* * * *");
    }
}

public abstract class ShapeCreator
{
    public abstract IShape CreateShape();
}

public class ConcreteCircleCreator : ShapeCreator
{
    public override IShape CreateShape()
    {
        return new Circle();
    }
}

public class ConcreteSquareCreator : ShapeCreator
{
    public override IShape CreateShape()
    {
        return new Square();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("\nQuale forma vuoi costruire (circle, square): ");
        string type = Input.String();

        ShapeCreator shapeCreator = null;

        switch (type.ToLower())
        {
            case "circle":
                shapeCreator = new ConcreteCircleCreator();
                break;

            case "square":
                shapeCreator = new ConcreteSquareCreator();
                break;

            default:
                Console.WriteLine("Forma non riconosciuta");
                break;
        }

        if (shapeCreator != null)
        {
            IShape shape = shapeCreator.CreateShape();
            shape.Draw();
        }
    }
}