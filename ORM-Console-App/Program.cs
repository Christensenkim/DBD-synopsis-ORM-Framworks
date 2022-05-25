// See https://aka.ms/new-console-template for more information
using Entity_Framework;
using Hibernate;
using ORM_Console_App;

var tester = new Tester();
var run = true;

while (run)
{
    Console.WriteLine("Top Secret ORM Speed test");
    Console.WriteLine("1 - Insert test");
    Console.WriteLine("2 - Delete test");
    Console.WriteLine("3 - Update test");
    Console.WriteLine("4 - Read test");
    Console.WriteLine("  ");
    Console.WriteLine("0 - Exit");
    var option = Console.ReadLine();
    switch (option)
    {
        case "1":
            tester.Insert_Test();
            break;
        case "2":
            tester.Delete_Test();
            break;
        case "3":
            tester.Update_Test();
            break;
        case "4":
            tester.Read_Test();
            break;
        case "0":
            run = false;
            break;
        default:
            Console.WriteLine("Cool Story bro");
            break;
    }
}