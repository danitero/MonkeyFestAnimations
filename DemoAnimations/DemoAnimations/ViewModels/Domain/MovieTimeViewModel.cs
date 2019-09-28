using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DemoAnimations.ViewModels.Domain
{
    public class MovieTimeViewModel : BindableObject
    {
        public string Hour { get; set; }
        public int TotalSeats { get; set; }
        public string CinemaRoom { get; set; }

        private int availableSeats;

        public int AvailableSeats
        {
            get { return availableSeats; }
            set
            {
                availableSeats = value;
                OnPropertyChanged(nameof(AvailableSeats));
            }
        }

    }
}
