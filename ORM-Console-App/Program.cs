﻿// See https://aka.ms/new-console-template for more information
using Entity_Framework;
using Hibernate;
using ORM_Console_App;

var tester = new Tester();
var run = true;

while (run)
{
    Console.WriteLine("Top Secret ORM Speed test");
    Console.WriteLine("1 - insert test");
    Console.WriteLine("2 - delete test");
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
        case "0":
            run = false;
            break;
        default:
            Console.WriteLine("Cool Story bro");
            break;
    }
}