using System.Diagnostics;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Instrumenting
{
  class Program
  {
    static void Main(string[] args)
    {

      // Write to a text file in the project folder
      Trace.Listeners.Add(new TextWriterTraceListener(File.Create("log.txt")));

      // Text writer is buffered, so this option calls
      // Flush() on all listeners after writing
      Trace.AutoFlush = true;

      Debug.WriteLine("Debug says: 'I'm watching'!");
      Trace.WriteLine("Trace says: 'I'm watching'!");

      var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

      IConfigurationRoot configuration = builder.Build();

      var ts = new TraceSwitch(
        displayName: "PacktSwitch",
        description: "This switch is set via a JSON config file."
      );

      configuration.GetSection("PacktSwitch").Bind(ts);

      Trace.WriteLine(ts.TraceError, "Trace error");
      Trace.WriteLine(ts.TraceWarning, "Trace warning");
      Trace.WriteLine(ts.TraceInfo, "Trace information");
      Trace.WriteLine(ts.TraceVerbose, "Trace verbose");
    }
  }
}
