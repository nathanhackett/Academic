//OS: Windows 10
//Command Software Design Pattern

//The CSDP is implemented by the use of concretecommand classes, abstract command classes
//which executes the commands, an invoker/client class which asks for the command to be executed

using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace assignment_03_18321563
{
    class Program
    {
        //all the shapes extend the shape abstract command class
        public class Rectangle : Shape
        {
            public int X { get; private set; }  //top left x-coordinate
            public int Y { get; private set; }  //top left y-coordinate
            public int H { get; private set; }  //height
            public int W { get; private set; }  //width
            
            public Rectangle(int x, int y, int h, int w) { X = x; Y = y; H = h; W = w; }

            public override string ToString()
            {
                // convert the object to an SVG element descriptor string for circle
                string dispSVG = String.Format(@"   <rect x=""{0}"" y=""{1}"" height=""{2}"" width=""{3}"" stroke=""black"" stroke-width=""2"" fill=""yellow""/>", X, Y, H, W);
                return dispSVG;
            }
        }
        public class Circle : Shape
        {
            public int X { get; private set; }  //centre x-coordinate
            public int Y { get; private set; }  //centre y-coordinate
            public int R { get; private set; }  //radius

            public Circle(int x, int y, int r) { X = x; Y = y; R = r; }

            public override string ToString()
            {
                // convert the object to an SVG element descriptor string for circle
                string dispSVG = String.Format(@"   <circle cx=""{0}"" cy=""{1}"" r=""{2}"" stroke=""black"" stroke-width=""2"" fill=""red""/>", X, Y, R);
                return dispSVG;
            }
        }

        public class Ellipse : Shape
        {
            public int X { get; private set; }  //centre x-coordinate
            public int Y { get; private set; }  //centre y-coordinate
            public int RX { get; private set; } //x radius
            public int RY { get; private set; } //y radius

            public Ellipse(int x, int y, int rx, int ry) { X = x; Y = y; RX = rx; RY = ry; }
            public override string ToString()
            {
                // convert the object to an SVG element descriptor string for circle
                string dispSVG = String.Format(@"   <ellipse cx=""{0}"" cy=""{1}"" rx=""{2}"" ry=""{3}"" stroke=""black"" stroke-width=""2"" fill=""red""/>", X, Y, RX, RY);
                return dispSVG;
            }
        }

        public class Line : Shape
        {
            public int X1 { get; private set; }  //first point x-coordinate
            public int Y1 { get; private set; }  //first point y-coordinate
            public int X2 { get; private set; }  //second point x-coordinate
            public int Y2 { get; private set; }  //second point y-coordinate

            public Line(int x1, int y1, int x2, int y2) { X1 = x1; Y1 = y1; X2 = x2; Y2 = y2; }

            public override string ToString()
            {
                // convert the object to an SVG element descriptor string for circle
                string dispSVG = String.Format(@"   <line x1=""{0}"" y1=""{1}"" x2=""{2}"" y2=""{3}"" stroke=""black"" stroke-width=""2"" fill=""green""/>", X1, Y1, X2, Y2);
                return dispSVG;
            }
        }

        public class Polyline : Shape
        {
            public string Points { get; set; }
            public Polyline() { Points = "0,40 40,40 40,80 80,80 80,120 120,120 120,160"; } //default constructer
            //https://www.w3schools.com/graphics/svg_polyline.asp
            public Polyline(string points) { Points = points; }

            public override string ToString()
            {
                // convert the object to an SVG element descriptor string for circle
                string dispSVG = String.Format(@"   <polyline points=""{0}"" stroke=""black"" stroke-width=""2"" fill=""yellow""/>", Points);
                return dispSVG;
            }
        }

        public class Polygon : Shape
        {
            public string Points { get; set; }
            public Polygon() { Points = "20,20 40,25 60,40 80,120 120,140 200,180"; } //default constructer
            //https://www.w3schools.com/graphics/svg_polygon.asp
            public Polygon(string points) { Points = points; }

            public override string ToString()
            {
                // convert the object to an SVG element descriptor string for circle
                string dispSVG = String.Format(@"   <polygon points=""{0}"" stroke=""black"" stroke-width=""2"" fill=""green""/>", Points);
                return dispSVG;
            }
        }

        public class Path : Shape
        {
            public string Points { get; set; }
            public Path() { Points = "M150 150 L75 350 L225 350 Z"; } //default constructer
            //https://www.w3schools.com/graphics/svg_path.asp
            public Path(string points) { Points = points; }

            public override string ToString()
            {
                // convert the object to an SVG element descriptor string for circle
                string dispSVG = String.Format(@"   <path d=""{0}"" stroke=""black"" stroke-width=""2"" fill=""blue""/>", Points);
                return dispSVG;
            }
        }

        public class Canvas
        {
            private Stack<Shape> canvas = new Stack<Shape>();
            public void Add(Shape s)
            {
                canvas.Push(s);
                Console.WriteLine("Added Shape to canvas: {0}" + Environment.NewLine, s);
            }

            public Shape Remove()
            {
                Shape s = canvas.Pop();
                Console.WriteLine("Removed Shape from canvas: {0}" + Environment.NewLine, s);
                return s;
            }
            public Canvas()
            {
                Console.WriteLine("\nCreated a new Canvas!");
                Console.WriteLine();
            }

            public override string ToString()
            {
                String str = "Canvas (" + canvas.Count + " elements): " + Environment.NewLine;
                foreach (Shape s in canvas)
                {
                    str += "   >" + s + Environment.NewLine;
                }
                return str;
            }
        }

        //abstract command class for executing shape operations
        public abstract class Shape
        {
            public override string ToString()
            {
                return "Shape!";
            }
        }



        //Invoker
        public class User{
            private Stack<Command> undo;
            private Stack<Command> redo;

            public int UndoCount { get => undo.Count; }
            public int RedoCount { get => redo.Count; }
            public User()
            {
                Reset();
                Console.WriteLine("Created a new User!" + Environment.NewLine);
            }
            public void Reset()
            {
                undo = new Stack<Command>();
                redo = new Stack<Command>();
            }
            public void Action(Command command)
            {
                // first update the undo - redo stacks
                undo.Push(command);  // save the command to the undo command
                redo.Clear();        // once a new command is issued, the redo stack clears

                // next determine  action from the Command object type
                // this is going to be AddShapeCommand or DeleteShapeCommand
                Type t = command.GetType();
                if (t.Equals(typeof(AddShapeCommand)))
                {
                    Console.WriteLine("Command Received: Add new Shape!" + Environment.NewLine);
                    command.Do();
                }
                if (t.Equals(typeof(DeleteShapeCommand)))
                {
                    Console.WriteLine("Command Received: Delete last Shape!" + Environment.NewLine);
                    command.Do();
                }
            }
            // Undo
            public void Undo()
            {
                Console.WriteLine("Undoing operation!"); Console.WriteLine();
                if (undo.Count > 0)
                {
                    Command c = undo.Pop(); c.Undo(); redo.Push(c);
                }
            }
            // Redo
            public void Redo()
            {
                Console.WriteLine("Redoing operation!"); Console.WriteLine();
                if (redo.Count > 0)
                {
                    Command c = redo.Pop(); c.Do(); undo.Push(c);
                }
            }
        }
        //abstract class for executing command
        public abstract class Command
        {
            public abstract void Do();     // what happens when we execute (do)
            public abstract void Undo();   // what happens when we unexecute (undo)
        }
        // Add Shape Command - it is a ConcreteCommand Class (extends Command)
        public class AddShapeCommand : Command
        {
            Shape shape;
            Canvas canvas;

            public AddShapeCommand(Shape s, Canvas c)
            {
                shape = s;
                canvas = c;
            }

            // Adds a shape to the canvas as "Do" action
            public override void Do()
            {
                canvas.Add(shape);
            }
            // Removes a shape from the canvas as "Undo" action
            public override void Undo()
            {
                shape = canvas.Remove();
            }

        }

        // Delete Shape Command - it is a ConcreteCommand Class (extends Command)
        public class DeleteShapeCommand : Command
        {

            Shape shape;
            Canvas canvas;

            public DeleteShapeCommand(Canvas c)
            {
                canvas = c;
            }

            // Removes a shape from the canvas as "Do" action
            public override void Do()
            {
                shape = canvas.Remove();
            }

            // Restores a shape to the canvas a an "Undo" action
            public override void Undo()
            {
                canvas.Add(shape);
            }
        }




        static void Main(string[] args)
        {
            Random rnd = new Random(); // random number generator
            List<String> Shapes = new List<String>(); //create list to hold shapes

            Canvas canvas = new Canvas(); //create new canvas
            
            User user = new User(); //create new user class
            Console.WriteLine("Please enter a command: (H for Help)" + Environment.NewLine);

            //string sc = Console.ReadLine();
            while (true) {
                string sc = Console.ReadLine();
                if (sc.Equals("q") || sc.Equals("Q")){
                    Console.WriteLine("Quitting!");
                    break;
                } else {
                    switch(sc)
                    {
                        //Interactive Functionality
                        case "A Rectangle":
                        user.Action(new AddShapeCommand(new Rectangle(rnd.Next(1, 250), rnd.Next(1, 250), rnd.Next(1, 250), rnd.Next(1, 250)), canvas));
                            Console.WriteLine("Rectangle added to canvas");
                            break;
                        case "A Circle":
                        user.Action(new AddShapeCommand(new Circle(rnd.Next(1, 250), rnd.Next(1, 250), rnd.Next(1, 250)), canvas));
                            Console.WriteLine("Circle added to canvas");
                            break;
                        case "A Ellipse":
                        user.Action(new AddShapeCommand(new Ellipse(rnd.Next(1, 250), rnd.Next(1, 250), rnd.Next(1, 250), rnd.Next(1, 250)), canvas));
                            Console.WriteLine("Ellipse added to canvas");
                            break;
                        case "A Line":
                        user.Action(new AddShapeCommand(new Line(rnd.Next(1, 250), rnd.Next(1, 250), rnd.Next(1, 250), rnd.Next(1, 250)), canvas));
                            Console.WriteLine("Line added to canvas");
                            break;
                        case "A Polyline":
                        user.Action(new AddShapeCommand(new Polyline(), canvas));
                            Console.WriteLine("Polyline added to canvas");
                            break;
                        case "A Polygon":
                        user.Action(new AddShapeCommand(new Polygon(), canvas));
                            Console.WriteLine("Polygon added to canvas");
                            break;
                        case "A Path":
                        user.Action(new AddShapeCommand(new Path(), canvas));
                            Console.WriteLine("Path added to canvas");
                            break;
                        case "U":
                            user.Undo();
                            break;
                        case "R":
                            user.Redo();
                            break;
                        case "C":
                            user.Reset();
                            break;
                        case "D":
                            Console.WriteLine(canvas);
                            break;
                        case "H":
                            Console.WriteLine("Commands: ");
                            Console.WriteLine("A <shape>   Add <shape> to canvas");
                            Console.WriteLine("U           Undo last operation");
                            Console.WriteLine("R           Redo last operation");
                            Console.WriteLine("C           Clear canvas");
                            Console.WriteLine("D           Display Canvas");
                            Console.WriteLine("S           Save canvas to SVG file");
                            Console.WriteLine("Q           Quit");
                            break;
                        case "S":
                            String path = @"./Shapes.svg";
                            //https://docs.microsoft.com/en-us/dotnet/api/system.io.file.create?view=net-5.0
                            using (FileStream fs = File.Create(path))
                            {
                                // insert open svg tag into first line
                                byte[] info = new UTF8Encoding(true).GetBytes(@"<svg height=""2000"" width=""2000"" xmlns=""http://www.w3.org/2000/svg"">" + canvas);
                                // Add some information to the file.
                                fs.Write(info, 0, info.Length);
                            }
                            //add close tag to the end
                            using (StreamWriter sw = File.AppendText(path))
                            {
                                sw.WriteLine("</svg>");
                            }
                            Console.WriteLine("Canvas saved to SVG");
                            break;
                        default:
                            Console.WriteLine("Invalid Input");
                            break;
                    }
                }
            }
        }
    }
}
