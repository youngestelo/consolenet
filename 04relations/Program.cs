//
//  Композиция
//

//  Unit John = new Unit("John", new Point(10, 5));
//  John.GetInformation();

//  Unit William = new Unit("William", 20, 30);
//  William.Move(20, 10);
//  William.GetInformation();

//  class Point
//  {
//     private int X;
//     private int Y;


//     public Point(int X = 0, int Y = 0)
//     { this.X = X; this.Y = Y; }

//     public void Set(int X = 0, int Y = 0)
//     { this.X = X; this.Y = Y; }


//     public void GetInformation()
//     { Console.WriteLine($"Position: {X}, {Y}\n"); }
//  }

//  class Unit
//  {
//       private readonly string Title;
//       private readonly Point Position;


//       public Unit(string Title, Point Position)
//       { this.Title = Title; this.Position = Position; }

//       public Unit(string Title, int X, int Y)
//       { this.Title = Title; this.Position = new Point(X, Y); }


//       public void Move(int X, int Y) => Position.Set(X, Y);

//       public void GetInformation()
//       { Console.WriteLine($"Title: {Title}"); Position.GetInformation(); }


//       ~Unit() => Console.WriteLine("Unit has been deleted!");
//  }
//



//  class Point
//  {
//      private int X;
//      private int Y;


//      public Point(int X = 0, int Y = 0)
//      { this.X = X; this.Y = Y; }

//      public Point(Point Sample)
//      { X = Sample.X; Y = Sample.Y; }


//      public void Set(int X = 0, int Y = 0)
//      { this.X = X; this.Y = Y; }
//  }

//  class PositionInit
//  {
//      public Point InitPoint(Point Sample)
//      { return new Point(Sample); }
//  }

//  class Unit
//  {
//      private readonly string Title;
//      private PositionInit Init;
//      private Point Position;


//      public Unit(string Title, Point Position)
//      { 
//          this.Title = Title; 
//          Init = new PositionInit(); 
//          this.Position = Init.InitPoint(Position); 
//      }


//      public void Move(int X, int Y) => Position.Set(X, Y);


//      ~Unit() => Console.WriteLine("Unit has been deleted!");
//  }





//
//  Агрегация
//

//  Teacher Dumbledore = new Teacher("Dumbledore");
//  Teacher McGonagall = new Teacher("McGonagall");

//  Group Slytherin = new Group("Slytherin");
//  Slytherin.setTeacher(McGonagall);

//  Group Gryffindor = new Group("Gryffindor");
//  Gryffindor.setTeacher(Dumbledore);


//  class Teacher
//  {
//      private string Name;

//      public Teacher(string Name)
//      { this.Name = Name; }

//      public string getName() => Name;
//  }

//  class Group
//  {
//      private readonly string Title;
//      private Teacher currentTeacher;

//      public Group(string Title)
//      { this.Title = Title; }

//      public void setTeacher(Teacher currentTeacher)
//      { this.currentTeacher = currentTeacher; }
//  }



//  Engine Zip = new Engine("Zip");
//  Engine Rar = new Engine("Rar");
//  Engine Deflate = new Engine("Deflate");

//  ArchiveManager Manager = new ArchiveManager("/user/bin");

//  Manager.setEngine(Zip);
//  Manager.Compress();

//  Manager.setEngine(Deflate);
//  Manager.Compress();

//  class Engine
//  {
//      private readonly string Alg;

//      public Engine(string Alg)
//      { this.Alg = Alg; }

//      public void Run(string filePath)
//      { Console.WriteLine($"Alg {Alg} is used for file {filePath}"); }
//  }

//  class ArchiveManager
//  {
//      private readonly string filePath;
//      private Engine? _Engine;

//      public ArchiveManager(string filePath)
//      { this.filePath = filePath; _Engine = null; }

//      public void setEngine(Engine _Engine)
//      { this._Engine = _Engine; }

//      public void Compress()
//      {
//          if (_Engine is null) Console.WriteLine("Invalid compress engine!");
//          else _Engine.Run(filePath);
//      }
//  }





//
//  Ассоциация
//

//  class Teacher // Унарная однонаправленная ассоциация
//  { private Group? _Group = null; }

//  class Group
//  { }



//  class Teacher // Унарная двунаправленная ассоциация
//  { private Group? _Group = null; }

//  class Group
//  { private Teacher? _Teacher = null; }



//  class Teacher // N-арная однонаправленная ассоциация
//  { private List<Group>? _Groups = null; }

//  class Group
//  { }



//  class Teacher // N-арная двунаправленная ассоциация
//  { private List<Group>? _Groups = null; }

//  class Group
//  { private List<Teacher>? _Teachers = null; }