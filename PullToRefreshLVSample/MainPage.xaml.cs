using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PullToRefreshLVSample
{
    public partial class MainPage : ContentPage
    {
        Random rnd = new Random();
        string[] namesArray = { "Leomaris", "Peter", "Maria", "George",
                                "Samuel", "Jose", "Stephanie" , "Marcus" };
        string[] colorArray = { "#ffb1fd", "#cdddfe", "#ccfece" };

         
        List <string> names = new List <string> ();  
        public MainPage()
        {
            InitializeComponent();
            LoadData();

            lvNames.RefreshCommand = new Command(() => { 
                lvNames.IsRefreshing = true;
                LoadData();
            });
        }
        public void LoadData()
        {
            lvNames.ItemsSource = null;
            names.Clear();
            for (int i = 0; i < 8; i++)
            {
                names.Add(namesArray[rnd.Next(0, namesArray.Length)]);

            }
           
            lvNames.BackgroundColor = Color.FromHex(colorArray[rnd.Next(0, colorArray.Length)]);
            lvNames.ItemsSource = names;
            lvNames.IsRefreshing = false; 
        }
    }
}
