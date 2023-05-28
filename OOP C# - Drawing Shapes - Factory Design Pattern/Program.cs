// OS: Windows 10
// Re-design of my Assignment 02 
// Factory Method Factory Software Design Pattern 
// Bridge Style Software Design Pattern 

using System;
using System.IO;
using System.Collections.Generic;

// Note: This core program is from:  https://refactoring.guru/design-patterns/factory-method/csharp/example
// I did not write this program! Please refer to the code owner at link above.
// However, I have adapted the program to use the same Shape example used earlier.

namespace MyFactoryMethod
{
    public interface Color
    {
        public string showShapeColor();
    }

    public class BlueColor : Color
    {
        public string showShapeColor()
        {
            String color = "blue";
            //Console.WriteLine(color);
            return color;
        }
    }
    public class RedColor : Color
    {
        public string showShapeColor()
        {
            String color = "red";
            //Console.WriteLine(color);
            return color;
        }
    }
    public class GreenColor : Color
    {
        public string showShapeColor()
        {
            String color = "green";
            //Console.WriteLine(color);
            return color;
        }
    }
    public class YellowColor : Color
    {
        public string showShapeColor()
        {
            String color = "yellow";
            Console.WriteLine(color);
            return color;
        }
    }


    abstract class ShapeCreator
    {
        public abstract IShape FactoryMethod();
        public string Add()
        {
            // Call the factory method to create a Product object.
            var shape = FactoryMethod();
            return shape.AddShape();
        }

        protected Color color;

        public ShapeCreator(Color color)
        {
            this.color = color;
        }

        public abstract void draw();
    }

    class RectangleFactory : ShapeCreator
    {
        public RectangleFactory(Color color) : base(color) {}
        public override void draw()
        {
            color.showShapeColor();
        }
        public override IShape FactoryMethod()
        {
            String c = color.showShapeColor();
            return new RectangleShape(c);
        }
    }

    class CircleFactory : ShapeCreator
    {
        public CircleFactory(Color color) : base(color) {}
        public override void draw()
        {
            color.showShapeColor();
        }
        public override IShape FactoryMethod()
        {
            String c = color.showShapeColor();
            return new CircleShape(c);
        }
    }
    class EllipseFactory : ShapeCreator
    {
        public EllipseFactory(Color color) : base(color) {}
        public override void draw()
        {
            color.showShapeColor();
        }   
        public override IShape FactoryMethod()
        {
            String c = color.showShapeColor();
            return new EllipseShape(c);
        }
    }
    class LineFactory : ShapeCreator
    {
        public LineFactory(Color color) : base(color) {}
        public override void draw()
        {
            color.showShapeColor();
        } 
        public override IShape FactoryMethod()
        {
            String c = color.showShapeColor();
            return new LineShape(c);
        }
    }
    class PolylineFactory : ShapeCreator
    {
        public PolylineFactory(Color color) : base(color) {}
        public override void draw()
        {
            color.showShapeColor();
        } 
        public override IShape FactoryMethod()
        {
            String c = color.showShapeColor();
            return new PolylineShape(c);
        }
    }
    class PolygonFactory : ShapeCreator
    {
        public PolygonFactory(Color color) : base(color) {}
        public override void draw()
        {
            color.showShapeColor();
        } 
        public override IShape FactoryMethod()
        {
            String c = color.showShapeColor();
            return new PolygonShape(c);
        }
    }
    class PathFactory : ShapeCreator
    {
        public PathFactory(Color color) : base(color) {}
        public override void draw()
        {
            color.showShapeColor();
        } 
        public override IShape FactoryMethod()
        {
            String c = color.showShapeColor();
            return new PathShape(c);
        }
    }

    // The Product interface declares the operations that all concrete products
    // must implement.
    public interface IShape
    {
        public string AddShape();
    }

    // Concrete Products provide various implementations of the Product
    // interface.
    class RectangleShape : IShape
    {
        Random rand = new Random();
        public int X { get; set; }  // rect top left x-coordinate
        public int Y { get; set; }  // rect top left y-coordinate
        public int H { get; set; }  // rect height
        public int W { get; set; } // rect width
        public string Stroke { get; set; } //rect stroke
        public int StrokeWidth { get; set; } // rect strokewidth
        public string Fill { get; set; } //rect fill

        public RectangleShape(string color) { X = rand.Next(1, 200); Y = rand.Next(1, 200); H = rand.Next(1, 200); W = rand.Next(1, 200); Stroke = "black"; StrokeWidth = rand.Next(1, 5); Fill = color; } //default constructer
        public RectangleShape(int x, int y, int h, int w, string s, int sw, string f) { X = x; Y = y; H = h; W = w; Stroke = s; StrokeWidth = sw; Fill = f;} //user input
           
        public string AddShape()
        {
            // convert the object to an SVG element descriptor string for circle
            string dispSVG = String.Format(@"   <rect x=""{0}"" y=""{1}"" height=""{2}"" width=""{3}"" stroke=""{4}"" stroke-width=""{5}"" fill=""{6}""/>", X, Y, H, W, Stroke, StrokeWidth, Fill);
            return dispSVG;
        }
    }
    class CircleShape : IShape
    {
        Random rand = new Random();
        public int X { get; set; }  // circle centre x-coordinate
        public int Y { get; set; }  // circle centre y-coordinate
        public int R { get; set; }  // circle radius
        public string Stroke { get; set; } //circle stroke
        public int StrokeWidth { get; set; } // circle strokewidth
        public string Fill { get; set; } //circle fill

        public CircleShape(string color) { X = rand.Next(1, 200); Y = rand.Next(1, 200); R = rand.Next(1, 200); Stroke = "black"; StrokeWidth = rand.Next(1, 5); Fill = color;} //default constructer
        public CircleShape(int x, int y, int r, string s, int sw, string f) { X = x; Y = y; R = r; Stroke = s; StrokeWidth = sw; Fill = f;} //user input
           
        public string AddShape()
        {
            // convert the object to an SVG element descriptor string for circle
            string dispSVG = String.Format(@"   <circle cx=""{0}"" cy=""{1}"" r=""{2}"" stroke=""{3}"" stroke-width=""{4}"" fill=""{5}""/>", X, Y, R, Stroke, StrokeWidth, Fill);
            return dispSVG;
        }
    }

    class EllipseShape : IShape
    {
        Random rand = new Random();
        public int X { get; set; }  // ellipse centre x-coordinate
        public int Y { get; set; }  // ellipse centre y-coordinate
        public int RX { get; set; }  // ellipse x rad
        public int RY { get; set; } // ellipse y rad 
        public string Stroke { get; set; } //ellipse stroke
        public int StrokeWidth { get; set; } // ellipse strokewidth
        public string Fill { get; set; } //ellipse fill

        public EllipseShape(string color) { X = rand.Next(1, 200); Y = rand.Next(1, 200); RX = rand.Next(1, 200); RY = rand.Next(1, 200); Stroke = "black"; StrokeWidth = rand.Next(1, 5); Fill = color; }  //default constructer
        public EllipseShape(int x, int y, int rx, int ry, string s, int sw, string f) { X = x; Y = y; RX = rx; RY = ry ; Stroke = s; StrokeWidth = sw; Fill = f;} //user input
           
        public string AddShape()
        {
            // convert the object to an SVG element descriptor string for circle
            string dispSVG = String.Format(@"   <ellipse cx=""{0}"" cy=""{1}"" rx=""{2}"" ry=""{3}"" stroke=""{4}"" stroke-width=""{5}"" fill=""{6}""/>", X, Y, RX, RY, Stroke, StrokeWidth, Fill);
            return dispSVG;
        }
    }

    class LineShape : IShape
    {
        Random rand = new Random();
        public int X1 { get; set; } 
        public int Y1 { get; set; } 
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public string Stroke { get; set; } 
        public int StrokeWidth { get; set; }
        public string Fill { get; set; }

        public LineShape(string color) { X1 = rand.Next(1, 200); Y1 = rand.Next(1, 200); X2 = rand.Next(1, 200); Y2 = rand.Next(1, 200); Stroke = "black"; StrokeWidth = rand.Next(1, 5); Fill = color;} //default constructer
        public LineShape(int x1, int y1, int x2, int y2, string s, int sw, string f) { X1 = x1; Y1 = y1; X2 = x2; Y2 = y2; Stroke = s; StrokeWidth = sw; Fill = f;} //user input
           
        public string AddShape()
        {
            // convert the object to an SVG element descriptor string for circle
            string dispSVG = String.Format(@"   <line x1=""{0}"" y1=""{1}"" x2=""{2}"" y2=""{3}"" stroke=""{4}"" stroke-width=""{5}"" fill=""{6}""/>", X1, Y1, X2, Y2, Stroke, StrokeWidth, Fill);
            return dispSVG;
        }
    }

    class PolylineShape : IShape
    {
        Random rand = new Random();
        public string Points { get; set; }
        public string Stroke { get; set; } 
        public int StrokeWidth { get; set; }
        public string Fill { get; set; }
        public PolylineShape(string color) { Points = "0,40 40,40 40,80 80,80 80,120 120,120 120,160"; Stroke = "black"; StrokeWidth = rand.Next(1, 5); Fill = color;}  //default constructer
        //https://www.w3schools.com/graphics/svg_polyline.asp
        public PolylineShape(string points, string s, int sw, string f) { Points = points; Stroke = s; StrokeWidth = sw; Fill = f; } //user input
           
        public string AddShape()
        {
            // convert the object to an SVG element descriptor string for circle
            string dispSVG = String.Format(@"   <polyline points=""{0}"" stroke=""{1}"" stroke-width=""{2}"" fill=""{3}""/>", Points, Stroke, StrokeWidth, Fill);
            return dispSVG;
        }
    }

    class PolygonShape : IShape
    {
        Random rand = new Random();
        public string Points { get; set; }
        public string Stroke { get; set; }
        public int StrokeWidth { get; set; }
        public string Fill { get; set; }

        public PolygonShape(string color) { Points = "20,20 40,25 60,40 80,120 120,140 200,180"; Stroke = "black"; StrokeWidth = rand.Next(1, 5); Fill = color;} //default constructer
        //https://www.w3schools.com/graphics/svg_polygon.asp
        public PolygonShape(string points, string s, int sw, string f) { Points = points; Stroke = s; StrokeWidth = sw; Fill = f;} //user input
           
        public string AddShape()
        {
            // convert the object to an SVG element descriptor string for circle
            string dispSVG = String.Format(@"   <polygon d=""{0}"" stroke=""{1}"" stroke-width=""{2}"" fill=""{3}""/>", Points, Stroke, StrokeWidth, Fill);
            return dispSVG;
        }
    }

    class PathShape : IShape
    {
        Random rand = new Random();
        public string Points { get; set; }
        public string Stroke { get; set; }
        public int StrokeWidth { get; set; }
        public string Fill { get; set; }

        public PathShape(string color) { Points = "M150 150 L75 350 L225 350 Z"; Stroke = "black"; StrokeWidth = rand.Next(1, 5); Fill = color;} //default constructer
        //https://www.w3schools.com/graphics/svg_path.asp
        public PathShape(string points, string s, int sw, string f) { Points = points; Stroke = s; StrokeWidth = sw; Fill = f;} //user input
           
        public string AddShape()
        {
            // convert the object to an SVG element descriptor string for circle
            string dispSVG = String.Format(@"   <path d=""{0}"" stroke=""{1}"" stroke-width=""{2}"" fill=""{3}""/>", Points, Stroke, StrokeWidth, Fill);
            return dispSVG;
        }
    }


    class ShapeClient
    {
        public void Main()
        {
            Console.WriteLine("Select Shape to Launch App With: ");
            Console.WriteLine("Press H for Help: ");
            while (true)
            {
                string sc = Console.ReadLine();
                if (sc.Equals("q") || sc.Equals("Q"))
                {
                    Console.WriteLine("Quitting");
                    break;
                }
                else if (sc.Equals("h") || sc.Equals("H")){
                    Console.WriteLine("Commands: ");
                    Console.WriteLine("<Shape> <Color> -> A     Add <shape> to canvas");
                    Console.WriteLine("e.g. Rectangle B");
                    Console.WriteLine("C                Clear canvas");
                    Console.WriteLine("D                Display Canvas");
                    Console.WriteLine("S                Save Canvas to SVG file");
                    Console.WriteLine("Q                Quit");
                    Console.WriteLine();
                } else {
                    switch (sc)
                    {
                        //Interactive Functionality
                        case "Rectangle B":
                            Console.WriteLine("App: Launched with Blue Rectangle Shape:");
                            ShapeCreator blueRect = new RectangleFactory(new BlueColor());
                            ClientCode(blueRect);
                            break;
                        case "Rectangle R":
                            Console.WriteLine("App: Launched with Red Rectangle Shape:");
                            ShapeCreator redRect = new RectangleFactory(new RedColor());
                            ClientCode(redRect);
                            break;
                        case "Rectangle G":
                            Console.WriteLine("App: Launched with Green Rectangle Shape:");
                            ShapeCreator greenRect = new RectangleFactory(new GreenColor());
                            ClientCode(greenRect);
                            break;
                        case "Rectangle Y":
                            Console.WriteLine("App: Launched with Yellow Rectangle Shape:");
                            ShapeCreator yellowRect = new RectangleFactory(new YellowColor());
                            ClientCode(yellowRect);
                            break;

                        case "Circle B":
                            Console.WriteLine("App: Launched with Blue Circle Shape:");
                            ShapeCreator blueCirc = new CircleFactory(new BlueColor());
                            ClientCode(blueCirc);
                            break;
                        case "Circle R":
                            Console.WriteLine("App: Launched with Red Circle Shape:");
                            ShapeCreator redCirc = new CircleFactory(new RedColor());
                            ClientCode(redCirc);
                            break;
                        case "Circle G":
                            Console.WriteLine("App: Launched with Green Circle Shape:");
                            ShapeCreator greenCirc = new CircleFactory(new GreenColor());
                            ClientCode(greenCirc);
                            break;
                        case "Circle Y":
                            Console.WriteLine("App: Launched with Yellow Circle Shape:");
                            ShapeCreator yellowCirc = new CircleFactory(new YellowColor());
                            ClientCode(yellowCirc);
                            break;
                        
                        case "Ellipse B":
                            Console.WriteLine("App: Launched with Blue Ellipse Shape:");
                            ShapeCreator blueEllipse = new EllipseFactory(new BlueColor());
                            ClientCode(blueEllipse);
                            break;
                        case "Ellipse R":
                            Console.WriteLine("App: Launched with Red Ellipse Shape:");
                            ShapeCreator redEllipse = new EllipseFactory(new RedColor());
                            ClientCode(redEllipse);
                            break;
                        case "Ellipse G":
                            Console.WriteLine("App: Launched with Green Ellipse Shape:");
                            ShapeCreator greenEllipse = new EllipseFactory(new GreenColor());
                            ClientCode(greenEllipse);
                            break;
                        case "Ellipse Y":
                            Console.WriteLine("App: Launched with Yellow Ellipse Shape:");
                            ShapeCreator yellowEllipse = new EllipseFactory(new YellowColor());
                            ClientCode(yellowEllipse);
                            break;

                        case "Line B":
                            Console.WriteLine("App: Launched with Blue Line Shape:");
                            ShapeCreator blueLine = new LineFactory(new BlueColor());
                            ClientCode(blueLine);
                            break;
                        case "Line R":
                            Console.WriteLine("App: Launched with Red Line Shape:");
                            ShapeCreator redLine = new LineFactory(new RedColor());
                            ClientCode(redLine);
                            break;
                        case "Line G":
                            Console.WriteLine("App: Launched with Green Line Shape:");
                            ShapeCreator greenLine = new LineFactory(new GreenColor());
                            ClientCode(greenLine);
                            break;
                        case "Line Y":
                            Console.WriteLine("App: Launched with Yellow Line Shape:");
                            ShapeCreator yellowLine = new LineFactory(new YellowColor());
                            ClientCode(yellowLine);
                            break;

                        case "Polyline B":
                            Console.WriteLine("App: Launched with Blue Polyline Shape:");
                            ShapeCreator bluePolyline = new PolylineFactory(new BlueColor());
                            ClientCode(bluePolyline);
                            break;
                        case "Polyline R":
                            Console.WriteLine("App: Launched with Red Polyline Shape:");
                            ShapeCreator redPolyline = new PolylineFactory(new RedColor());
                            ClientCode(redPolyline);
                            break;
                        case "Polyline G":
                            Console.WriteLine("App: Launched with Green Polyline Shape:");
                            ShapeCreator greenPolyline = new PolylineFactory(new GreenColor());
                            ClientCode(greenPolyline);
                            break;
                        case "Polyline Y":
                            Console.WriteLine("App: Launched with Yellow Polyline Shape:");
                            ShapeCreator yellowPolyline = new PolylineFactory(new YellowColor());
                            ClientCode(yellowPolyline);
                            break;

                        case "Polygon B":
                            Console.WriteLine("App: Launched with Blue Polygon Shape:");
                            ShapeCreator bluePolygon = new PolygonFactory(new BlueColor());
                            ClientCode(bluePolygon);
                            break;
                        case "Polygon R":
                            Console.WriteLine("App: Launched with Red Polygon Shape:");
                            ShapeCreator redPolygon = new PolygonFactory(new RedColor());
                            ClientCode(redPolygon);
                            break;
                        case "Polygon G":
                            Console.WriteLine("App: Launched with Green Polygon Shape:");
                            ShapeCreator greenPolygon = new PolygonFactory(new GreenColor());
                            ClientCode(greenPolygon);
                            break;
                        case "Polygon Y":
                            Console.WriteLine("App: Launched with Yellow Polygon Shape:");
                            ShapeCreator yellowPolygon = new PolygonFactory(new YellowColor());
                            ClientCode(yellowPolygon);
                            break;

                        case "Path B":
                            Console.WriteLine("App: Launched with Blue Path Shape:");
                            ShapeCreator bluePath = new PathFactory(new BlueColor());
                            ClientCode(bluePath);
                            break;
                        case "Path R":
                            Console.WriteLine("App: Launched with Red Path Shape:");
                            ShapeCreator redPath = new PathFactory(new RedColor());
                            ClientCode(redPath);
                            break;
                        case "Path G":
                            Console.WriteLine("App: Launched with Green Path Shape:");
                            ShapeCreator greenPath = new PathFactory(new GreenColor());
                            ClientCode(greenPath);
                            break;
                        case "Path Y":
                            Console.WriteLine("App: Launched with Yellow Path Shape:");
                            ShapeCreator yellowPath = new PathFactory(new YellowColor());
                            ClientCode(yellowPath);
                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                }
            }
        }

        public void ClientCode(ShapeCreator creator)
        {
            List<String> Shapes = new List<String>();

            while (true) {
                string sc = Console.ReadLine();
                if (sc.Equals("q") || sc.Equals("Q"))
                {
                    Console.WriteLine("Quitting");
                    break;
                }
                else
                {
                    switch (sc)
                    {
                        case "A":
                            Shapes.Add(creator.Add());
                            Console.WriteLine("Added New Shape");
                        break;
                        case "S":
                            String path = @"./Shapes.svg";
                            //https://docs.microsoft.com/en-us/dotnet/api/system.io.file.create?view=net-5.0
                            File.WriteAllText(path,string.Empty); //clear exisiting code
                            using (StreamWriter sw = File.AppendText(path))
                            {
                                sw.WriteLine(@"<svg height=""2000"" width=""2000"" xmlns=""http://www.w3.org/2000/svg"">" + Environment.NewLine);
                                foreach(var item in Shapes)
                                {
                                    sw.WriteLine(item);
                                }
                            }
                            //add close tag to the end
                            using (StreamWriter sw = File.AppendText(path))
                            {
                                sw.WriteLine(Environment.NewLine + "</svg>");
                            }
                            Console.WriteLine("Canvas saved to SVG");
                            break;
                        case "C":
                            path = @"./Shapes.svg";
                            File.WriteAllText(path,string.Empty);
                            Shapes.Clear();
                            Console.WriteLine("Clearing Canvas");
                            break;
                        case "D":
                            foreach(var item in Shapes)
                            {
                                Console.WriteLine(item);
                            }
                            break;
                        case "Q":
                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(); new ShapeClient().Main();
        }
    }
}

