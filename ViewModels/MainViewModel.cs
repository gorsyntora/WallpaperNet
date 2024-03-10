using Avalonia.Media;
using Avalonia.Media.Imaging;
using AvaloniaApp.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AvaloniaApp.ViewModels;

public partial class MainViewModel : ViewModelBase
{

    public ObservableCollection<ImageItem> GoodItems { get; set; } = new();
    public ICommand BuyMusicCommand { get; }
    public string Greeting => "Welcome to Avalonia!";
    private static HttpClient s_httpClient = new();
    public ObservableCollection<Layer> LayerList { get; set; } = new();

    [ObservableProperty]
    private Bitmap? _cover;



    public MainViewModel()
    {

        //BuyMusicCommand = new ICommand(() => { });

    }

    public async void BtnClicked()
    {
        // var bmp = await LoadCoverBitmapAsync("");
        var pixabay = "https://pixabay.com/api/?key=37309411-fe5f3d44facc80b63b845c092&q=yellow+flowers&image_type=photo";
        var response = await s_httpClient.GetAsync(pixabay);
        response.EnsureSuccessStatusCode();
        string responseBody = await response.Content.ReadAsStringAsync();

        Root? root = JsonSerializer.Deserialize<Root>(responseBody);

        foreach (var hit in root.hits)
        {

            var streamBmp = await LoadCoverBitmapAsync(hit.previewURL);

            var previewBmp = Bitmap.DecodeToWidth(streamBmp, 400);

            GoodItems.Add(new ImageItem(previewBmp, ""));

        }
        //   Cover = Bitmap.DecodeToWidth(bmp, 400);

    }

    public async void BtnGeoCalcClicked()
    {
        Console.WriteLine("Btn clicked");
     
     
     

        var spatialCalc = new Window2();
        spatialCalc.Show();

    }

  
    public async Task<Stream> LoadCoverBitmapAsync(string CoverUrl)
    {

        //  CoverUrl = "https://fon.litrelax.ru/uploads/posts/2023-01/1673729664_foni-club-p-kartinki-na-rabochii-stol-solyaris-7.jpg";
        var data = await s_httpClient.GetByteArrayAsync(CoverUrl);

        return new MemoryStream(data);

    }

    public partial class Muse : ViewModelBase
    {

        [ObservableProperty]
        public string _product;

        public Muse(string product)
        {
            Product = product;
        }
    }


}
