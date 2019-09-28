using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xamarin.Forms;

namespace DemoAnimations.Interfaces
{
    public interface IViewLocationFetcher
    {
        PointF GetCoordinates(VisualElement view);
    }
}
