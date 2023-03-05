using System;

namespace TextFile_DataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            const string strCmdText = "node -v";
            System.Diagnostics.Process.Start("CMD.exe", strCmdText);
        }
    }
}
