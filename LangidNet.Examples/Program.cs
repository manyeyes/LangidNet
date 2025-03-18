// See https://github.com/manyeyes for more information
// Copyright (c)  2023 by manyeyes
using LangidNet;

namespace ManyVitsTts.Examples
{
    internal static partial class Program
    {
        public static string applicationBase = AppDomain.CurrentDomain.BaseDirectory;
        [STAThread]
        private static void Main()
        {
            TestLangid();
        }
        public static void TestLangid()
        {
            Console.WriteLine("Please enter text:");
            while (true)
            {
                string text = Console.ReadLine();
                string ldpyFilePath = "";//applicationBase + "/" + "ldpy.model";
                LangidNet.LangidRecognizer langidRecognizer = new LangidNet.LangidRecognizer(ldpyFilePath: ldpyFilePath);
                LangidNet.TextStream stream = langidRecognizer.CreateTextStream();
                stream.AddText(text);
                LangidNet.Model.LangidRecognizerResultEntity langidRecognizerResultEntity = new LangidNet.Model.LangidRecognizerResultEntity();
                langidRecognizerResultEntity = langidRecognizer.GetResult(stream);
                Console.WriteLine(langidRecognizerResultEntity.Language);
            }
        }
    }
}


