using DemoAnimations.ViewModels.Domain;
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
    public partial class ReservationPage : ContentPage
    {
        public ReservationPage()
        {
            InitializeComponent();
            GetSeats();
            BindingContext = this;
        }

        public List<SeatViewModel> Seats { get; set; }

        private void GetSeats()
        {
            Seats = new List<SeatViewModel>()
            {
                new SeatViewModel() { HasChair = false, IsAvailable = true, IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "A7", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "A6", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = false, Row = "A5", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = false, Row = "A4", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "A3", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "A2", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "A1", IsSelected = false },
                new SeatViewModel() { HasChair = false, IsAvailable = true, IsSelected = false },
                new SeatViewModel() { HasChair = false, IsAvailable = true, IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "B7", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "B6", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "B5", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = false, Row = "B4", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = false, Row = "B3", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = false, Row = "B2", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "B1", IsSelected = false },
                new SeatViewModel() { HasChair = false, IsAvailable = true, IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "C9", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "C8", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "C7", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "C6", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "C5", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "C4", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "C3", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "C2", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "C1", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = false, Row = "D9", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = false, Row = "D8", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = false, Row = "D7", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "D6", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "D5", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "D4", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "D3", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "D2", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "D1", IsSelected = false },
                new SeatViewModel() { HasChair = false, IsAvailable = true, IsSelected = false },
                new SeatViewModel() { HasChair = false, IsAvailable = true, IsSelected = false },
                new SeatViewModel() { HasChair = false, IsAvailable = true, IsSelected = false },
                new SeatViewModel() { HasChair = false, IsAvailable = true, IsSelected = false },
                new SeatViewModel() { HasChair = false, IsAvailable = true, IsSelected = false },
                new SeatViewModel() { HasChair = false, IsAvailable = true, IsSelected = false },
                new SeatViewModel() { HasChair = false, IsAvailable = true, IsSelected = false },
                new SeatViewModel() { HasChair = false, IsAvailable = true, IsSelected = false },
                new SeatViewModel() { HasChair = false, IsAvailable = true, IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "E9", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "E8", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "E7", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "E6", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "E5", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "E4", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "E3", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "E2", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = false, Row = "E1", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "F9", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "F8", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "F7", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "F6", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "F5", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "F4", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "F3", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "F2", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "F1", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "G9", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "G8", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "G7", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = false, Row = "G6", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = false, Row = "G5", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "G4", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "G3", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "G2", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "G1", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "H9", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "H8", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "H7", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "H6", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "H5", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "H4", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "H3", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "H2", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "H1", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "I9", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = false, Row = "I8", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = false, Row = "I7", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = false, Row = "I6", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "I5", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "I4", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "I3", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "I2", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "I1", IsSelected = false },
                new SeatViewModel() { HasChair = false, IsAvailable = true, IsSelected = false },
                new SeatViewModel() { HasChair = false, IsAvailable = true, IsSelected = false },
                new SeatViewModel() { HasChair = false, IsAvailable = true, IsSelected = false },
                new SeatViewModel() { HasChair = false, IsAvailable = true, IsSelected = false },
                new SeatViewModel() { HasChair = false, IsAvailable = true, IsSelected = false },
                new SeatViewModel() { HasChair = false, IsAvailable = true, IsSelected = false },
                new SeatViewModel() { HasChair = false, IsAvailable = true, IsSelected = false },
                new SeatViewModel() { HasChair = false, IsAvailable = true, IsSelected = false },
                new SeatViewModel() { HasChair = false, IsAvailable = true, IsSelected = false },
                new SeatViewModel() { HasChair = false, IsAvailable = true, IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "J7", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "J6", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "J5", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = false, Row = "J4", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = false, Row = "J3", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = false, Row = "J2", IsSelected = false },
                new SeatViewModel() { HasChair = true, IsAvailable = true, Row = "J1", IsSelected = false },
                new SeatViewModel() { HasChair = false, IsAvailable = true, IsSelected = false }
            };
        }

        private void GridView_ItemTapped(object sender, EventArgs e)
        {
            var selectedSeat = sender as SeatViewModel;

            if (selectedSeat.IsAvailable)
                selectedSeat.IsSelected = !selectedSeat.IsSelected;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SummaryReservationPage());
        }
    }
}