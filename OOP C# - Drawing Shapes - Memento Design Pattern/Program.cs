//OS: Windows 10
//Momento Software Design Pattern

// I don’t believe one design pattern worked better than the other for my solution as they both were successful in achieving the target functionality i.e. undo-redo & others. The memento design pattern would by my preference of which design I think would be the more efficient if I were to scale each of the components of the solution e.g. more commands to edit the shape sizes and styles, z-indexing or the canvas size. I believe this because there are much fewer classes in the memento than the command design. In the memento there are only 3 core classes containing the methods that execute all the major functionality for their respective class, whereas in the software design each shape must extend an abstract shape class and every command must extend an abstract command class which could prove challenging for scaling.
// Some personal challenges I experienced implementing both design patterns were that I first struggled to understand the operation flow of the command design pattern in the way that each command is a method wrapped in an object and executed by the invoker. After researching the pattern and examining the demo code, I came to have a better understanding of it and the purpose of each class. I experienced the same challenges upon starting to implement the memento, even more so since I had to search for examples online that didn’t relate to my solution. However after some research I was able to grasp the concept of memento much easier than software.


using System;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

namespace assignment_04_18321563
{
    class Program
    {
        public class Rectangle
        {
            public int X { get; private set; }  //top left x-coordinate
            public int Y { get; private set; }  //top left y-coordinate
            public int H { get; private set; }  //height
            public int W { get; private set; }  //width

            public Rectangle(int x, int y, int h, int w) { X = x; Y = y; H = h; W = w; }

            public override string ToString()
            {
                // convert the object to an SVG element descriptor string for rectangle
                string dispSVG = String.Format(@"   <rect x=""{0}"" y=""{1}"" height=""{2}"" width=""{3}"" stroke=""black"" stroke-width=""2"" fill=""yellow""/>", X, Y, H, W);
                return dispSVG;
            }
        }
        public class Circle
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

        public class Ellipse
        {
            public int X { get; private set; }  //centre x-coordinate
            public int Y { get; private set; }  //centre y-coordinate
            public int RX { get; private set; } //x radius
            public int RY { get; private set; } //y radius

            public Ellipse(int x, int y, int rx, int ry) { X = x; Y = y; RX = rx; RY = ry; }
            public override string ToString()
            {
                // convert the object to an SVG element descriptor string for ellipse
                string dispSVG = String.Format(@"   <ellipse cx=""{0}"" cy=""{1}"" rx=""{2}"" ry=""{3}"" stroke=""black"" stroke-width=""2"" fill=""red""/>", X, Y, RX, RY);
                return dispSVG;
            }
        }

        public class Line
        {
            public int X1 { get; private set; }  //first point x-coordinate
            public int Y1 { get; private set; }  //first point y-coordinate
            public int X2 { get; private set; }  //second point x-coordinate
            public int Y2 { get; private set; }  //second point y-coordinate

            public Line(int x1, int y1, int x2, int y2) { X1 = x1; Y1 = y1; X2 = x2; Y2 = y2; }

            public override string ToString()
            {
                // convert the object to an SVG element descriptor string for line
                string dispSVG = String.Format(@"   <line x1=""{0}"" y1=""{1}"" x2=""{2}"" y2=""{3}"" stroke=""black"" stroke-width=""2"" fill=""green""/>", X1, Y1, X2, Y2);
                return dispSVG;
            }
        }

        public class Polyline
        {
            public string Points { get; set; }
            public Polyline() { Points = "0,40 40,40 40,80 80,80 80,120 120,120 120,160"; } //default constructer
            //https://www.w3schools.com/graphics/svg_polyline.asp
            public Polyline(string points) { Points = points; }

            public override string ToString()
            {
                // convert the object to an SVG element descriptor string for polyline
                string dispSVG = String.Format(@"   <polyline points=""{0}"" stroke=""black"" stroke-width=""2"" fill=""yellow""/>", Points);
                return dispSVG;
            }
        }

        public class Polygon
        {
            public string Points { get; set; }
            public Polygon() { Points = "20,20 40,25 60,40 80,120 120,140 200,180"; } //default constructer
            //https://www.w3schools.com/graphics/svg_polygon.asp
            public Polygon(string points) { Points = points; }

            public override string ToString()
            {
                // convert the object to an SVG element descriptor string for polygon
                string dispSVG = String.Format(@"   <polygon points=""{0}"" stroke=""black"" stroke-width=""2"" fill=""green""/>", Points);
                return dispSVG;
            }
        }

        public class Path
        {
            public string Points { get; set; }
            public Path() { Points = "M150 150 L75 350 L225 350 Z"; } //default constructer
            //https://www.w3schools.com/graphics/svg_path.asp
            public Path(string points) { Points = points; }

            public override string ToString()
            {
                // convert the object to an SVG element descriptor string for path
                string dispSVG = String.Format(@"   <path d=""{0}"" stroke=""black"" stroke-width=""2"" fill=""blue""/>", Points);
                return dispSVG;
            }
        }


        //Originator class - creates memento
        class Originator
        {
            private ArrayList _shapeList = new ArrayList();
            //Add method
            public void Add(string shape)
            {
                ArrayList s = ShapeList;
                s.Add(shape);
                this.ShapeList = s;
            }
            //Undo method
            public void RemoveAt()
            {
                ArrayList s = ShapeList;
                int len = s.Count - 1;
                s.RemoveAt(len);
                this.ShapeList = s;
            }
            public int Count()
            {
                ArrayList s = ShapeList;
                int len = s.Count - 2;
                return len;
            }
            public ArrayList ShapeList
            {
                get { return _shapeList; }
                set
                {
                    _shapeList = value;
                }
            }

            //Stores current memento snapshot before undo
            public Memento SaveMemento()
            {
                Console.WriteLine("Saving current state...");
                ArrayList _copyList = (ArrayList)_shapeList.Clone();
                return new Memento(_copyList);
            }
            //Restore from last memento snapshot (redo)
            public void RestoreMemento(Memento memento)
            {
                Console.WriteLine("Restoring previous state...");
                this.ShapeList = memento.ShapeList;
            }

            public List<string> ListShapes()
            {
                List<string> list = new List<string>();
                foreach(var item in ShapeList){
                    list.Add(item.ToString());
                }
                return list;
            }

            public void GetShapes(){
                foreach(var item in ShapeList){
                    Console.WriteLine(item);
                }
            }
        }

        //Holds snapshot of originator state
        class Memento
        {
            private ArrayList _copyList = new ArrayList();
            //Stores a clone of originators shapeList
            public Memento(ArrayList shapeList)
            {
                this._copyList = (ArrayList)shapeList.Clone();
            }
            //Get and set snapshot of ShapeList
            public ArrayList ShapeList
            {
                get
                {
                    return _copyList;
                }
                set
                {
                    _copyList = value;
                }
            }
        }


        //The caretaker keeps a list of saved memento states - no functionality
        class Caretaker
        {
            private Memento _memento;

            private List<Memento> memoList = new List<Memento>();

            public Memento Memento
            {
                set { _memento = value; }
                get { return _memento; }
            }
            //adds memento to memoList
            public void AddMemento(Memento m)
            {
                memoList.Add(m);
            }
            //resets memento list
            public void ClearMemento()
            {
                memoList.Clear();
            }
            //gets and removes and last memento in memoList
            public Memento GetMemento()
            {
                var temp = memoList[memoList.Count - 1];
                memoList.RemoveAt(memoList.Count - 1);
                return temp;
            }
        }


        static void Main()
        {
            Originator canvas = new Originator();   //create new originator object (the canvas)
            ArrayList mem = new ArrayList();    //array list to add shapes to
            Memento m = new Memento(mem);   //create new memento for state snapshots
            List<Memento> holder = new List<Memento>();     //list to hold memento snapshots
            Random rnd = new Random();  //random number generator

            Console.WriteLine("Please enter a command: (H for Help)" + Environment.NewLine);

            //keep taking in input until user quits
            while (true)
            {
                string sc = Console.ReadLine();
                if (sc.Equals("q") || sc.Equals("Q"))
                {
                    Console.WriteLine("Quitting!");
                    break;
                }
                else
                {
                    switch (sc)
                    {
                        //Interactive Functionality
                        case "A Rectangle":
                            Rectangle rect = new Rectangle(rnd.Next(1, 250), rnd.Next(1, 250), rnd.Next(1, 250), rnd.Next(1, 250));
                            string rectString = rect.ToString();
                            canvas.Add(rectString);
                            m = canvas.SaveMemento();
                            Console.WriteLine("Rectangle added to canvas");
                            break;
                        case "A Circle":
                            Circle circle = new Circle(rnd.Next(1, 250), rnd.Next(1, 250), rnd.Next(1, 250));
                            string circleString = circle.ToString();
                            canvas.Add(circleString);
                            m = canvas.SaveMemento();
                            Console.WriteLine("Circle added to canvas");
                            break;
                        case "A Ellipse":
                            Ellipse ellipse = new Ellipse(rnd.Next(1, 250), rnd.Next(1, 250), rnd.Next(1, 250), rnd.Next(1, 250));
                            string ellipseString = ellipse.ToString();
                            canvas.Add(ellipseString);
                            m = canvas.SaveMemento();
                            Console.WriteLine("Ellipse added to canvas");
                            break;
                        case "A Line":
                            Line line = new Line(rnd.Next(1, 250), rnd.Next(1, 250), rnd.Next(1, 250), rnd.Next(1, 250));
                            string lineString = line.ToString();
                            canvas.Add(lineString);
                            m = canvas.SaveMemento();
                            Console.WriteLine("Line added to canvas");
                            break;
                        case "A Polyline":
                            Polyline polyline = new Polyline();
                            string polylineString = polyline.ToString();
                            canvas.Add(polylineString);
                            m = canvas.SaveMemento();
                            Console.WriteLine("Polyline added to canvas");
                            break;
                        case "A Polygon":
                            Polygon polygon = new Polygon();
                            string polygonString = polygon.ToString();
                            canvas.Add(polygonString);
                            m = canvas.SaveMemento();
                            Console.WriteLine("Polygon added to canvas");
                            break;
                        case "A Path":
                            Path path = new Path();
                            string pathString = path.ToString();
                            canvas.Add(pathString);
                            m = canvas.SaveMemento();
                            Console.WriteLine("Path added to canvas");
                            break;
                        case "U":
                            m = canvas.SaveMemento();
                            canvas.RemoveAt();
                            Console.WriteLine("Undoing previous operation...");
                            break;
                        case "R":
                            canvas.SaveMemento();
                            canvas.RestoreMemento(m);
                            Console.WriteLine("Redoing previous operation...");
                            break;
                        case "C":
                            canvas = new Originator();
                            Console.WriteLine("Canvas Cleared!");
                            break;
                        case "D":
                            canvas.GetShapes();
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
                            String filePath = @"./Shapes.svg";

                            List<string> Shapes = canvas.ListShapes(); //store shapes in new list

                            //https://docs.microsoft.com/en-us/dotnet/api/system.io.file.create?view=net-5.0
                            using (FileStream fs = File.Create(filePath))
                            {
                                //Insert open svg tag into first line
                                byte[] info = new UTF8Encoding(true).GetBytes(@"<svg height=""2000"" width=""2000"" xmlns=""http://www.w3.org/2000/svg"">" + Environment.NewLine);
                                //Add shapes
                                fs.Write(info, 0, info.Length);
                            }
                            //Add close tag to the end
                            using (StreamWriter sw = File.AppendText(filePath))
                            {
                                foreach(string item in Shapes){
                                    sw.WriteLine(item);
                                }
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
