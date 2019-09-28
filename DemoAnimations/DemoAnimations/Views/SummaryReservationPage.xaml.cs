using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoAnimations.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SummaryReservationPage : ContentPage
    {
        public SummaryReservationPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            popup.IsVisible = true;
        }
    }
}