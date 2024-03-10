using Avalonia.Media.Imaging;
using AvaloniaApp.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaloniaApp
{
    public partial class ImageItem: ViewModelBase
    {

        [ObservableProperty]
        private Bitmap? _bitmap;

        [ObservableProperty]
        private string? _name;

        public ImageItem(Bitmap? bitmap, string? name)
        {
            _bitmap = bitmap;
            _name = name;
        }
    }
}
