using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Singleton
{
  /// <summary>
  ///  Singleton
  /// </summary>
  public class Logger
  {
    private static readonly Lazy<Logger> _instance
        = new Lazy<Logger>(() => new Logger());

    public static Logger Instance
    {
      get
      {
        return _instance.Value;
      }
    }

    protected Logger()
    {
    }

    /// <summary>
    /// SingletonOperation
    /// </summary>
    /// <param name="message"></param>
    public void Log(string message)
    {
      System.Console.WriteLine($"Message to log: {message}");
    }
  }
}