/*
Goal: Write a simple Hellow World CLI

Usage:

Return the string after `-t`
- ./xy -t test 

*/
using System;
using System.Collections.Generic;
namespace HelloWorld.App;
public class Program

{
    protected static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        Console.WriteLine(Process(args));

        // TODO: Prepare / Clean sting
        // TODO: Parse args
        // TODO: Process args
        // TODO: Return (print to console) the result <-- 
    }

    protected static string Process(string[] input)
    {
        // --> Pre-process stage
        if (input.Length == 0)
        {
            return "Got empty input";
        }
        if (input.Length % 2 != 0)
        {
            return "Got non-matching input";
        }

        // --> Parse stage
        // if the second to last is no token, we can assume the user did
        // input something invalid
        List<Command> commands_total = [];
        for (int index_second_to_last = 0; index_second_to_last < input.Length - 1; index_second_to_last++)
        {
            if (input[index_second_to_last].StartsWith('-'))
            {
                Command command = new()
                {
                    Type = input[index_second_to_last],
                    Content = input[index_second_to_last + 1]
                };
                commands_total.Add(command);
            }
        }

        if (commands_total.Count == 0)
        {
            return "Got token without any flag or empty list";
        }

        // --> Process stage
        string result = "";
        foreach (Command command in commands_total){
            result += command.Type switch
            {
                "-u" => command.Content.ToUpper(),
                "-l" => command.Content.ToLower(),
                _ => "",
            };
        }

        return result; 
    }
}

public struct Command
{
    public string Type { get; set; }
    public string Content { get; set; }
}