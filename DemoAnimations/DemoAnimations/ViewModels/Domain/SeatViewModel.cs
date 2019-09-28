using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DemoAnimations.ViewModels.Domain
{
    public class SeatViewModel : BindableObject
    {
        public bool HasChair { get; set; }
        public bool IsAvailable { get; set; }
        public string Row { get; set; }

        private bool isSelected;

        public bool IsSelected
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }

    }
}
