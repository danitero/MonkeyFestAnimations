using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DemoAnimations
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ObservableCollection<string> list;

        public MainPage()
        {
            InitializeComponent();

            list = new ObservableCollection<string>()
            {
                "http://i.imgur.com/KngRsfL.jpg",
                "http://i.imgur.com/KngRsfL.jpg",
                "http://i.imgur.com/KngRsfL.jpg",
                "http://i.imgur.com/KngRsfL.jpg",
                "http://i.imgur.com/KngRsfL.jpg",
                "http://i.imgur.com/KngRsfL.jpg",
                "http://i.imgur.com/KngRsfL.jpg",
                //"2",
                //"3","4",
                "http://i.imgur.com/KngRsfL.jpg",
                //"6","7",
                //"8",
                //"9","10",
                //"11",
                //"12","13",
                //"14",
                //"15","16",
                //"17",
                //"18","19",
                //"20",
                //"21","22",
                //"23",
                //"24","25",
                //"26",
                //"27","28",
                //"29",
                //"30","31",
                //"32",
                //"33","34",
                //"35",
                //"36","37",
                //"38",
                //"39","40",
                //"41",
                //"42","43",
                //"44",
                //"45","46",
                //"47",
                //"48"
            };

            list.CollectionChanged += List_CollectionChanged;

            BindingContext = list;
        }

        private void List_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:

                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Move:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    break;
            }
        }

        int lastItemAppearedIndex;

        private void ListView_ItemAppearing(object sender, ItemVisibilityEventArgs e)
        {
            var listView = (ListView)sender;
            var element = e.Item;

            IEnumerable<PropertyInfo> pInfos = (listView as ItemsView<Cell>).GetType().GetRuntimeProperties();

            var templatedItems = pInfos.FirstOrDefault(info => info.Name == "TemplatedItems");

            if (templatedItems != null)
            {
                var cells = templatedItems.GetValue(listView);
                Xamarin.Forms.ITemplatedItemsList<Xamarin.Forms.Cell> listCell = cells as Xamarin.Forms.ITemplatedItemsList<Xamarin.Forms.Cell>;
                ViewCell currentCell = listCell[e.ItemIndex] as ViewCell;

                if (e.ItemIndex > lastItemAppearedIndex)
                {
                    currentCell.View.TranslationY = 50;
                    //currentCell.View.Opacity = 0;

                    currentCell.View.TranslateTo(currentCell.View.X, 0, 500, Easing.SinOut);
                    //currentCell.View.FadeTo(1, 600); 
                }
                else
                {
                    currentCell.View.TranslationY = -50;
                    //currentCell.View.Opacity = 0;

                    currentCell.View.TranslateTo(currentCell.View.X, 0, 500, Easing.SinOut);
                    //currentCell.View.FadeTo(1, 600); 
                }

                lastItemAppearedIndex = e.ItemIndex;
            }
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            list.Add("Hola");
        }
    }
}
