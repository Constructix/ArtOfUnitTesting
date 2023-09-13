// See https://aka.ms/new-console-template for more information

using ArtOfUnitTesting;
using ArtOfUnitTesting.Implementers;

var fileManager = new FileExtensionManager();
var logAnalyser = new LogAnalyser(fileManager);

Console.WriteLine(logAnalyser.IsValidLogFileName(@"D:\Temp\Orders.dat"));
Console.WriteLine(logAnalyser.IsValidLogFileName(@"D:\Temp\Orders1.dat"));

try
{
    Console.WriteLine(logAnalyser.IsValidLogFileName(@""));
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}


