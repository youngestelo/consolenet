 
List<Log> Logs = new List<Log>();

IHandle objectDatabase = new projectDatabase("Main Data Centre", Logs);
IHandle objectMail     = new projectMail("Co-Workers Mail System", Logs);
IHandle objectCopier   = new projectCopier("Server Centre Copier", Logs);

objectDatabase.setNextHandle(objectMail).setNextHandle(objectCopier);


try
{
    objectDatabase.invokeHandle();
}
catch (Exception tempException)
{ 
    Console.WriteLine($"Fatal error on chain! {tempException.Message}"); 
}

foreach (Log tempLog in Logs)
{
    Console.ForegroundColor = tempLog.logSuccess ? ConsoleColor.Green : ConsoleColor.Red;
    Console.WriteLine($"{tempLog.logCaption}\nFrom: {tempLog.logHandle}\nSuccess: {tempLog.logSuccess}\n");
    Console.ResetColor();
}


class Log
{
    public string? logHandle  { get; set; }
    public string? logCaption { get; set; }
    public bool    logSuccess { get; set; }

    public Log(string? logHandle, string? logCaption, bool logSuccess)
    { 
        this.logHandle = logHandle; 
        this.logCaption = logCaption; 
        this.logSuccess = logSuccess; 
    }
}


interface IHandle
{
    public IHandle setNextHandle(IHandle Next);

    protected static bool attemptToInvoke() => Convert.ToBoolean(Random.Shared.Next(0, 2));

    public void    invokeHandle();
    public void    rollbackHandle();
}

abstract class Handle : IHandle
{
    protected IHandle? nextHandle { get; set; } = null;
    protected string? objectName;
    protected List<Log> Logs;

    public Handle(string? objectName, List<Log> Logs)
    { this.objectName = objectName; this.Logs = Logs; }
    
    public IHandle setNextHandle(IHandle Next)
    { nextHandle = Next; return nextHandle; }

    public abstract void invokeHandle();
    public abstract void rollbackHandle();
}


class projectDatabase : Handle
{
    public projectDatabase(string? objectName, List<Log> Logs) : base(objectName, Logs) {}

    public override void invokeHandle()
    {
        try 
        {
            if (IHandle.attemptToInvoke()) Logs.Add(new Log(objectName, "Database initialized successfully!", true));
            else Logs.Add(new Log(objectName, "Failed to initialize database!", false));

            nextHandle?.invokeHandle();
        }
        catch (Exception)
        { rollbackHandle(); throw; }
    }

    public override void rollbackHandle()
    { Console.WriteLine("Chain failed while initializing database"); }
}

class projectMail : Handle
{
    public projectMail(string? objectName, List<Log> Logs) : base(objectName, Logs) {}

    public override void invokeHandle()
    {
        try
        {
            if (IHandle.attemptToInvoke()) Logs.Add(new Log(objectName, "Mail sent successfully to default@mail.com!", true));
            else Logs.Add(new Log(objectName, "Mail sending to default@gmail.com failed!", false));

            nextHandle?.invokeHandle();
        }
        catch (Exception)
        { rollbackHandle(); throw; }
    }

    public override void rollbackHandle()
    { Console.WriteLine("Chain failed while sending mail!"); }
}

class projectCopier : Handle
{
    public projectCopier(string? objectName, List<Log> Logs) : base(objectName, Logs) {}

    public override void invokeHandle()
    {
        try
        {
            if (IHandle.attemptToInvoke()) Logs.Add(new Log(objectName, "File successfully copied!", true));
            else Logs.Add(new Log(objectName, "Failed to copy files!", false));

            nextHandle?.invokeHandle();
        }
        catch (Exception)
        { rollbackHandle(); throw; }
    }

    public override void rollbackHandle()
    { Console.WriteLine("Chain failed while copying files!"); }
}