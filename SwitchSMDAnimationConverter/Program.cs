using System;
using System.Threading;
using System.IO;

namespace SwitchSMDAnimationConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = @"
   _____ __  __ _____     _____                          _            
  / ____|  \/  |  __ \   / ____|                        | |           
 | (___ | \  / | |  | | | |     ___  _ ____   _____ _ __| |_ ___ _ __ 
  \___ \| |\/| | |  | | | |    / _ \| '_ \ \ / / _ \ '__| __/ _ \ '__|
  ____) | |  | | |__| | | |___| (_) | | | \ V /  __/ |  | ||  __/ |   
 |_____/|_|  |_|_____/   \_____\___/|_| |_|\_/ \___|_|   \__\___|_|     
";
            string credits = @"
    Made by Trippixyz!

";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(title);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(credits);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Pls Drag your SMD file into the Application:\n");
            string filename = Console.ReadLine().Trim('\"');
            string filelocation = System.IO.Path.GetDirectoryName(filename);
            if (Directory.Exists(filelocation))
            {
                string name = System.IO.Path.GetFileName(filename);
                Console.WriteLine("\nFilename:\n" + name);
                Thread.Sleep(1000);
                Console.WriteLine("Converting...");
                filelocation = System.IO.Path.Combine(filelocation, "animation");
                string filecontent = System.IO.File.ReadAllText(filename);
                string toolname = "Blender";
                if (filecontent.Contains(","))
                {
                    filecontent = filecontent.Replace(",", ".");   //Toolbox Animation Converts to Blender Animation
                    toolname = "Blender";
                }
                else
                {
                    filecontent = filecontent.Replace(".", ",");   //Blender Animation Converts to Toolbox Animation
                    toolname = "Toolbox";
                }
                if (!File.Exists(filelocation))
                {
                    System.IO.Directory.CreateDirectory(filelocation);
                    File.WriteAllText(filelocation + "\\" + name, filecontent);
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Thread.Sleep(500);
                Console.WriteLine("Succesfully converted the SMD animation to work with " + toolname);
                Console.WriteLine("\nExport Path:\n");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(filelocation + "\\" + name);
                Console.WriteLine("\n\nPress any key to close the application");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error:");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("(001) Invalid Path!!!\n");
                Console.WriteLine("The Application will now close");
                Thread.Sleep(2500);
                System.Environment.Exit(0);
            }
            Console.ReadKey();
        }
    }
}
