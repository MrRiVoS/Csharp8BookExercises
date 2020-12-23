using System;
using System.IO;
using System.IO.Compression;
using System.Xml;
using static System.Console;
using static System.Environment;
using static System.IO.Path;


namespace WorkingWithStreams
{
  
  class Program
  {
  // Define an array of Viper pilot call signs
    static string[] callsigns = new string[]{
      "Husker", "Starbuck", "Apollo", "Boomer",
      "Bulldog", "Athena", "Helo", "Racetrack"
    };

    static void Main(string[] args)
    {
      // WorkWithText();
      // WorkWithXml();
      WorkWithCompression();
      WorkWithCompression(useBrotli: false);
    }

    static void WorkWithText()
    {
      // Define a file to write to
      string textFile = Combine(CurrentDirectory, "strams.txt");

      // Create a text file and return a helper writer
      StreamWriter text = File.CreateText(textFile);

      // Enumerate the strings, writing each one to the stream on a separate line
      foreach (string item in callsigns)
      {
        text.WriteLine(item);
      }
      text.Close(); // release resoirces

      // Output the contents of the file
      WriteLine("{0} contains {1:N0} bytes.", textFile, new FileInfo(textFile).Length);

      WriteLine(File.ReadAllText(textFile));
    }

    static void WorkWithXml()
    {
      FileStream xmlFileStream = null;
      XmlWriter xml = null;

      try
      {
        // Define a file to write to
        string xmlFile = Combine(CurrentDirectory, "streams.xml");

        // Create a file stream
        xmlFileStream = File.Create(xmlFile);

        // Wrap the file stream in an XML writew helper
        // and automaticaly ident nested elements
        xml = XmlWriter.Create(xmlFileStream, new XmlWriterSettings{Indent = true});

        // Write the XML declaration
        xml.WriteStartDocument();

        // Write a root element
        xml.WriteStartElement("callsings");

        // Enumerate the strings writing each one to the stream
        foreach (string item in callsigns)
        {
          xml.WriteElementString("callsing", item);
        }

        // Write the close root element
        xml.WriteEndElement();

        // Close helper and stream
        xml.Close();
        xmlFileStream.Close();

        // Output all the contents of the file
        WriteLine("{0} contains {1:N0} bytes.", xmlFileStream, new FileInfo(xmlFile).Length);
        WriteLine(File.ReadAllText(xmlFile));
        
      }
      catch (System.Exception ex)
      {
        // If the path doesn't exist, the exception will caught
        WriteLine($"{ex.GetType()} says {ex.Message}");
      }
      finally
      {
        if (xml != null)
        {
          xml.Dispose();
          WriteLine("The XML writer's unmanaged resources have been disposed.");
        }
        if (xmlFileStream != null)
        {
          xmlFileStream.Dispose();
          WriteLine("The file stream's unmanaged resources have been disposed.");
        }
      }
    }

    static void WorkWithCompression(bool useBrotli = true)
    {
      string fileExt = useBrotli ? "brotli" : "gzip";

      // Compress the XML outuput
      string filePath = Combine(CurrentDirectory, $"streams.{fileExt}");

      FileStream file = File.Create(filePath);

      Stream compressor;

      if (useBrotli)
      {
        compressor = new BrotliStream(file, CompressionMode.Compress);
      }
      else
      {
        compressor = new GZipStream(file, CompressionMode.Compress);
      }
      
      using (compressor)
      {
        using (XmlWriter xml = XmlWriter.Create(compressor))
        {
          xml.WriteStartDocument();
          xml.WriteStartElement("callsigns");

          foreach (string item in callsigns)
          {
            xml.WriteElementString("callsign", item);
          }
          // The normal call to WriteEndElement is not necessary because
          // when the XmlWriter disposes, it will automatically end any
          // elements of any depth
        }
      } // Also closes the underlying stream

      // Output all the contents of the compressed file
      WriteLine("{0} contains {1:N0} bytes.", filePath, new FileInfo(filePath).Length);
      WriteLine("The compressed contents:");
      WriteLine(File.ReadAllText(filePath));
      WriteLine();

      // Read a compressed file
      WriteLine("Reading compressed XML file:");
      file = File.Open(filePath, FileMode.Open);
      Stream decompressor;

      if (useBrotli)
      {
        decompressor = new BrotliStream(file, CompressionMode.Decompress);
      }
      else
      {
        decompressor = new GZipStream(file, CompressionMode.Decompress);
      }

      using (decompressor)
      {
        using(XmlReader reader = XmlReader.Create(decompressor))
        {
          while (reader.Read())  // Read the next XML node
          {
            // Check if we are on an element node named 'callsign'
            if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "callsign"))
            {
              reader.Read(); // Move to the next inside element
              WriteLine($"{reader.Value}"); // read its value
            }
          }
        }
      }
    }
  }
}
