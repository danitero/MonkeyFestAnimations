using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DemoAnimations.ViewModels.Domain
{
    public class MovieViewModel: BindableObject
    {
        public string Name { get; set; }
        public string Duration { get; set; }
        public string Gender { get; set; }
        public string Description { get; set; }
        public string AgeRestriction { get; set; }
        public string PosterImage { get; set; }
        public string CoverImage { get; set; }
        public List<MovieTimeViewModel> MovieTimes { get; set; }
    }
}
