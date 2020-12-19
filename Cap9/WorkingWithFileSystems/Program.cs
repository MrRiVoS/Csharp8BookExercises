using System.IO;
using static System.Console;
using static System.IO.Directory;
using static System.IO.Path;
using static System.Environment;

namespace WorkingWithFileSystems
{
  class Program
  {
    static void Main(string[] args)
    {
      // OutPutFileSystemInfo();
      // WriteLine();
      // ShowDriveInfo();
      // WriteLine();
      // WorkWithDirectories();
      WorkWithFiles();
    }

    static void OutPutFileSystemInfo()
    {
      WriteLine("{0,-33} {1}", "Path.Separator", PathSeparator);
      WriteLine("{0,-33} {1}", "Path.DirectorySeparatorChar", DirectorySeparatorChar);
      WriteLine("{0,-33} {1}", "Directory.GetCurrentDirectory", GetCurrentDirectory());
      WriteLine("{0,-33} {1}", "Environment.CurrentDirectory", CurrentDirectory);
      WriteLine("{0,-33} {1}", "Environment.SystemSirectory", SystemDirectory);
      WriteLine("{0,-33} {1}", "Path.GetTempPath", GetTempPath());
      WriteLine("GetFolderPath(SpecialFolder");
      WriteLine("{0,-33} {1}", "  .System)", GetFolderPath(SpecialFolder.System));
      WriteLine("{0,-33} {1}", "  .ApplicationData)", GetFolderPath(SpecialFolder.ApplicationData));
      WriteLine("{0,-33} {1}", "  .MyDocuments", GetFolderPath(SpecialFolder.MyDocuments));
      WriteLine("{0,-33} {1}", "  .Personal", GetFolderPath(SpecialFolder.Personal));
    }

    static void ShowDriveInfo()
    {
      WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18} | {4,18}",
        "NAME", "TYPE", "FORMAT", "SIZE (BYTES)", "FREE SPACE");
      foreach (DriveInfo drive in DriveInfo.GetDrives())
      {
        if (drive.IsReady)
        {
          WriteLine("{0,-30} | {1,-10} | {2,-7} | {3,18:N0} | {4,18:N0}",
            drive.Name, drive.DriveType, drive.DriveFormat, drive.TotalSize, drive.AvailableFreeSpace);
        }
        else
        {
          WriteLine("{0,-30} | {1,-10}", drive.Name, drive.DriveType);
        }
      }
    }

    static void WorkWithDirectories()
    {
      // Define a directory path for a new folder
      // starting in the users folder
      var newFolder = Combine(GetFolderPath(SpecialFolder.Personal),"Code","Chapter09","NewFolder");
      WriteLine($"Working with: {newFolder}");

      // Check if it exists
      WriteLine($"Does it exist? {Exists(newFolder)}");

      // Create directory
      WriteLine("Creating it...");
      CreateDirectory(newFolder);
      WriteLine("Confirm the directory exists, and then press ENTER: ");
      ReadLine();

      // Delete directory
      WriteLine("deleting it...");
      Delete(newFolder, recursive: true);
      WriteLine($"Does it exist? {Exists(newFolder)}");
    }

    static void WorkWithFiles()
    {
      // Define a directory path to output files
      // starting in the user's folder
      var dir = Combine(GetFolderPath(SpecialFolder.Personal),"Code","Chapter09","OutputFiles");
      CreateDirectory(dir);

      // Define file paths
      string textFile = Combine(dir,"Dummy.txt");
      string backupFile = Combine(dir,"Dummy.bak");

      WriteLine($"Working with: {textFile}");

      // Chheck if a file exists
      WriteLine($"Does it exist? {File.Exists(textFile)}");

      // Create a new text file and write a line to it
      StreamWriter textWriter = File.CreateText(textFile);
      textWriter.WriteLine("Hello, C#!");
      textWriter.Close();  // close file and release resources

      WriteLine($"Does it exist? {File.Exists(textFile)}");

      // Copy the file and overwrite it if it already exists
      File.Copy(sourceFileName: textFile,
        destFileName: backupFile, overwrite: true);

      WriteLine($"Does {backupFile} exist? {File.Exists(backupFile)}");

      Write("Confirm the file exists and then press ENTER: ");
      ReadLine();

      // Delete file
      File.Delete(textFile);

      WriteLine($"Does it exist? {File.Exists(textFile)}");

      // Read from the text file backup
      WriteLine($"Reading contents of {backupFile}:");
      StreamReader textReader = File.OpenText(backupFile);
      WriteLine(textReader.ReadToEnd());
      textReader.Close();

      // Managing paths
      WriteLine($"Folder name: {GetDirectoryName(textFile)}");
      WriteLine($"File name: {GetFileName(textFile)}");
      WriteLine($"File name withou extension: {GetFileNameWithoutExtension(textFile)}");
      WriteLine($"File extension: {GetExtension(textFile)}");
      WriteLine($"Random file name: {GetRandomFileName()}");
      WriteLine($"Temporary file name: {GetTempFileName()}");
    }
  }
}
