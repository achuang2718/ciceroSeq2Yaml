using System;
using DataStructures;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using YamlDotNet.Serialization;

namespace CiceroParser
{
    class Program
    {
        static void Main(string[] args)
        // Deserializes a Cicero sequence file and writes each TimeStep into a ciceroSeq.yaml file.
        // Takes two command lines args:
        // - Cicero sequence filepath
        // - yaml file destination folder

        // Run from command line with two command line args:
        // >>> CiceroParser\CiceroParser\bin\Release\netcoreapp3.1\CiceroParser.exe MYSEQFILEPATH MYYAMLDESTINATIONFOLDER
        {
            // Open and deserialize .seq file
            string FileName = args[0];
            Stream openFileStream = File.OpenRead(FileName);
            BinaryFormatter deserializer = new BinaryFormatter();
            var seqData = (SequenceData)deserializer.Deserialize(openFileStream);
            openFileStream.Close();

            // Write to yaml file
            FileStream fileStream = new FileStream(args[1] + @"\ciceroSeq.yaml",
                FileMode.Create, FileAccess.Write);
            StreamWriter fileWriter = new StreamWriter(fileStream);
            foreach (TimeStep step in seqData.TimeSteps)
            {
                var stringBuilder = new StringBuilder();
                var serializer = new Serializer();
                stringBuilder.AppendLine(serializer.Serialize(step));
                Console.WriteLine(stringBuilder);
                fileWriter.WriteLine(stringBuilder);
            }
            fileWriter.Flush();
            fileWriter.Close();
        }
    }
}
