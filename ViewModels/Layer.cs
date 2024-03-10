using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;


namespace AvaloniaApp.ViewModels
{
    public partial class Layer : ViewModelBase
    {
        private static Random rnd = new Random();
    

                [ObservableProperty]
        private string _name;
        [ObservableProperty]
        private string _coordinateSys;

                public Layer(string name)
        {
            Name = name;
           

            CoordinateSys = "WSD -84";
        }
    }
}