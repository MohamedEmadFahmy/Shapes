using System.Data.Common;
using System.ComponentModel.DataAnnotations;

namespace Shapes
{

    public abstract class Shape
    {
        public abstract double Calculate();
        public abstract string GetFormula();
    }

    public abstract class Shape2D : Shape
    {
        public double Height { get; set; }
        public double Width { get; set; }

        public override string GetFormula()
        {
            return "The formula for calculating the area: ";
        }
    }

    public abstract class Shape3D : Shape2D
    {
        public double Length { get; set; }
        public override string GetFormula()
        {
            return "The formula for calculating the volume: ";
        }
    }

    public abstract class CircularShape : Shape2D
    {
        public double Radius { get; set; }
    }

    public abstract class SphericalShape : Shape3D
    {
        public double Radius { get; set; }
    }

    public class Square : Shape2D
    {
        public override double Calculate()
        {
            return Height * Width;
        }
        public override string GetFormula()
        {
            return base.GetFormula() + "l x w";
        }
    }

    public class Circle : CircularShape
    {
        public override double Calculate()
        {
            return Math.PI * Radius * Radius;
        }
        public override string GetFormula()
        {
            return base.GetFormula() + "π x r x r";
        }
    }

    public class Cube : Shape3D
    {
        public override double Calculate()
        {
            return Height * Width * Length;
        }
        public override string GetFormula()
        {
            return base.GetFormula() + "l x w x h";
        }
    }

    public class Sphere : SphericalShape
    {
        public override double Calculate()
        {
            return (4.0 / 3.0) * Math.PI * Radius * Radius * Radius;
        }
        public override string GetFormula()
        {
            return base.GetFormula() + "4/3 x π x r x r x r";
        }
    }

    // Add more shapes here
    public class RectangularPrism : Shape3D
    {
        public override double Calculate()
        {
            return Height * Width * Length;
        }
        public override string GetFormula()
        {
            return base.GetFormula() + "l x w x h";
        }
    }

    public class Cylinder : SphericalShape
    {
        public override double Calculate()
        {
            return Math.PI * Radius * Radius * Height;
        }
        public override string GetFormula()
        {
            return base.GetFormula() + "π x r x r x h";
        }
    }

    public class Cone : SphericalShape
    {
        public override double Calculate()
        {
            return (1.0 / 3.0) * Math.PI * Radius * Radius * Height;
        }
        public override string GetFormula()
        {
            return base.GetFormula() + "(1/3) x π x r x r x h";
        }
    }

    public class Pyramid : Shape3D
    {
        public override double Calculate()
        {
            return (1.0 / 3.0) * Height * Width * Length;
        }
        public override string GetFormula()
        {
            return base.GetFormula() + "(1/3) x l x w x h";
        }
    }

    public class Rectangle : Shape2D
    {
        public override double Calculate()
        {
            return Height * Width;
        }
        public override string GetFormula()
        {
            return base.GetFormula() + "l x w";
        }
    }

    public class Triangle : Shape2D
    {
        public override double Calculate()
        {
            return 0.5 * Height * Width;
        }
        public override string GetFormula()
        {
            return base.GetFormula() + "(1/2) x l x w";
        }
    }

    public class Parallelogram : Shape2D
    {
        public double Base1 { get; set; }

        public override double Calculate()
        {
            return Base1 * Height;
        }

        public override string GetFormula()
        {
            return base.GetFormula() + "b x h";
        }
    }

    public class Trapezium : Shape2D
    {
        public double Base1 { get; set; }
        public double Base2 { get; set; }

        public override double Calculate()
        {
            return 0.5 * (Base1 + Base2) * Height;
        }

        public override string GetFormula()
        {
            return base.GetFormula() + "(1/2) x (b1 + b2) x h";
        }
    }


    public class Rhombus : Shape2D
    {
        public override double Calculate()
        {
            return (Height * Width) / 2.0;
        }

        public override string GetFormula()
        {
            return base.GetFormula() + "(w x h) / 2";
        }
    }

    public class Kite : Shape2D
    {

        public override double Calculate()
        {
            return (Height * Width) / 2.0;
        }

        public override string GetFormula()
        {
            return base.GetFormula() + "(w x h) / 2";
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Shape Calculator!");

            while (true)
            {
                Console.WriteLine("Enter the name of the shape (Square, Circle, Cube, Sphere, RectangularPrism, Cylinder, Cone, Pyramid, Rectangle, Triangle, Trapezium, Parallelogram, Rhombus, Kite, or 'Exit' to quit):");
                string shapeName = Console.ReadLine().Trim().ToLower();

                if (shapeName == "exit")
                {
                    break;
                }

                Shape shape = CreateShape(shapeName);

                if (shape == null)
                {
                    Console.WriteLine("Invalid shape name. Please enter a valid shape.");
                    continue;
                }

                double result = GetAreaOrVolume(shape);

                Console.WriteLine(shape.GetFormula());
                Console.WriteLine($"The {shapeName} has a {(shape is Shape2D ? "area" : "volume")} of {result}.");
                Console.WriteLine("---------------------");
                Console.WriteLine();
            }
        }

        public static Shape CreateShape(string shapeName)
        {
            switch (shapeName)
            {
                case "square":
                    return new Square();
                case "circle":
                    return new Circle();
                case "cube":
                    return new Cube();
                case "sphere":
                    return new Sphere();
                case "rectangularprism":
                    return new RectangularPrism();
                case "cylinder":
                    return new Cylinder();
                case "cone":
                    return new Cone();
                case "pyramid":
                    return new Pyramid();
                case "rectangle":
                    return new Rectangle();
                case "triangle":
                    return new Triangle();
                case "trapezium":
                    return new Trapezium();
                case "parallelogram":
                    return new Parallelogram();
                case "rhombus":
                    return new Rhombus();
                case "kite":
                    return new Kite();
                default:
                    return null;
            }
        }

        public static double GetAreaOrVolume(Shape shape)
        {
            if (shape == null)
            {
                return 0;
            }

            switch (shape)
            {
                // 2D Shapes
                case Square square:
                    Console.Write("Enter the height: ");
                    square.Height = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the width: ");
                    square.Width = Convert.ToDouble(Console.ReadLine());
                    return square.Calculate();

                case Circle circle:
                    Console.Write("Enter the radius: ");
                    circle.Radius = Convert.ToDouble(Console.ReadLine());
                    return circle.Calculate();

                case Triangle triangle:
                    Console.Write("Enter the height: ");
                    triangle.Height = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the base: ");
                    triangle.Width = Convert.ToDouble(Console.ReadLine());
                    return triangle.Calculate();

                case Parallelogram parallelogram:
                    Console.Write("Enter the height: ");
                    parallelogram.Height = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter base 1: ");
                    parallelogram.Base1 = Convert.ToDouble(Console.ReadLine());
                    return parallelogram.Calculate();

                case Trapezium trapezium:
                    Console.Write("Enter the height: ");
                    trapezium.Height = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter base 1: ");
                    trapezium.Base1 = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter width (base 2): ");
                    trapezium.Base2 = Convert.ToDouble(Console.ReadLine());
                    return trapezium.Calculate();

                case Rhombus rhombus:
                    Console.Write("Enter Width: ");
                    rhombus.Width = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter Height: ");
                    rhombus.Height = Convert.ToDouble(Console.ReadLine());
                    return rhombus.Calculate();

                case Kite kite:
                    Console.Write("Enter Width: ");
                    kite.Width = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter Height: ");
                    kite.Height = Convert.ToDouble(Console.ReadLine());
                    return kite.Calculate();

                // 3D Shapes
                case Cube cube:
                    Console.Write("Enter the height: ");
                    cube.Height = Convert.ToDouble(Console.ReadLine());
                    return cube.Calculate();

                case Sphere sphere:
                    Console.Write("Enter the radius: ");
                    sphere.Radius = Convert.ToDouble(Console.ReadLine());
                    return sphere.Calculate();

                case RectangularPrism rectangularPrism:
                    Console.Write("Enter the height: ");
                    rectangularPrism.Height = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the length: ");
                    rectangularPrism.Length = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the width: ");
                    rectangularPrism.Width = Convert.ToDouble(Console.ReadLine());
                    return rectangularPrism.Calculate();

                case Cylinder cylinder:
                    Console.Write("Enter the height: ");
                    cylinder.Height = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the radius: ");
                    cylinder.Radius = Convert.ToDouble(Console.ReadLine());
                    return cylinder.Calculate();

                case Cone cone:
                    Console.Write("Enter the height: ");
                    cone.Height = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the radius: ");
                    cone.Radius = Convert.ToDouble(Console.ReadLine());
                    return cone.Calculate();

                case Pyramid pyramid:
                    Console.Write("Enter the height: ");
                    pyramid.Height = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the base length: ");
                    pyramid.Length = Convert.ToDouble(Console.ReadLine());
                    Console.Write("Enter the base width: ");
                    pyramid.Width = Convert.ToDouble(Console.ReadLine());
                    return pyramid.Calculate();

                default:
                    return 0;
            }
        }


    }
}
