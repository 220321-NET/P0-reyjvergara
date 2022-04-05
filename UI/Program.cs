﻿using DL;
using BL;

namespace FumoAlgo
{
    class Project0{
        static void Main(String[] args)
        {
            Console.WriteLine("Welcome to the project");
            FumoAlgoMenu FAMenu = new FumoAlgoMenu();
            FAMenu.MainMenuStart();
        }
        
    }
}
// program.cs is main entry point
// *.csproj denotes that the folder contains a C# project, also has configurations
// *.cs is C# code
// namespace is logical grouping of code - stitch together related types and classes
// assembly - physical grouping of code done through .dll or .exe
// project - basic executable unit of code, folder that has the *.csproj
// solution - grouping of projects, noted by .sln
