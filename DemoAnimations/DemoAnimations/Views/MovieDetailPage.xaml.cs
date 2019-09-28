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
    public partial class MovieDetailPage : ContentPage
    {
        MovieViewModel selectedMovie;
        List<MovieTimeViewModel> movieTimes;

        public MovieDetailPage(MovieViewModel movie)
        {
            InitializeComponent();

            SetMovieTimes();
            movie.MovieTimes = movieTimes;

            BindingContext = movie;
            selectedMovie = movie;

            SetTimer();
        }

        private void SetMovieTimes()
        {
            movieTimes = new List<MovieTimeViewModel>()
                {
                    new MovieTimeViewModel()
                    {
                        Hour = "11:00 am",
                        AvailableSeats = 30,
                        TotalSeats  = 32,
                        CinemaRoom = "4DX"
                    },
                    new MovieTimeViewModel()
                    {
                        Hour = "02:40 pm",
                        AvailableSeats = 15,
                        TotalSeats  = 28,
                        CinemaRoom = "2D"
                    },
                    new MovieTimeViewModel()
                    {
                        Hour = "05:30 pm",
                        AvailableSeats = 14,
                        TotalSeats  = 30,
                        CinemaRoom = "2D"
                    },
                    new MovieTimeViewModel()
                    {
                        Hour = "07:40 pm",
                        AvailableSeats = 4,
                        TotalSeats  = 30,
                        CinemaRoom = "IMAX"
                    },
                    new MovieTimeViewModel()
                    {
                        Hour = "10:00 pm",
                        AvailableSeats = 20,
                        TotalSeats  = 32,
                        CinemaRoom = "4DX"
                    },
                };
        }

        private void SetTimer()
        {
            int counter = 0;

            Device.StartTimer(TimeSpan.FromSeconds(3), () =>
            {
                foreach (var item in selectedMovie.MovieTimes)
                {
                    if (item.AvailableSeats >= 3)
                        item.AvailableSeats = item.AvailableSeats - 3;
                }

                counter++;
                return counter < 3;
            });
        }

        private async void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await Navigation.PushAsync(new ReservationPage());
        }

        private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            if (e.StatusType == GestureStatus.Running)
                pancakeView.TranslationY += e.TotalY;
        }
    }
}