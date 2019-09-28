using DemoAnimations.Interfaces;
using DemoAnimations.Messages;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoAnimations.Cells
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieCell : ViewCell
    {
        public MovieCell()
        {
            InitializeComponent();
        }
    }
}