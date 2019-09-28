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
        IViewLocationFetcher viewLocationFetcher;

        public MovieCell()
        {
            InitializeComponent();

            viewLocationFetcher = DependencyService.Get<IViewLocationFetcher>();

            MessagingCenter.Subscribe<ScrollMessage, double>(this, ScrollMessage.ScrollChanged,
               (sender, scrollInfo) =>
               {
                   if (cellCanvas != null)
                      cellCanvas.InvalidateSurface();
               });
        }

        protected async override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            txtName.TranslationX = 100;
            txtName.Opacity = 0;
            txtDuration.TranslationX = 100;
            txtDuration.Opacity = 0;
            frmAge.TranslationX = 100;
            frmAge.Opacity = 0;
            frmGender.TranslationX = 100;
            frmGender.Opacity = 0;

            await Task.Delay(150);

            txtName.TranslateTo(0, 0, 300, Easing.SinOut);
            txtName.FadeTo(1, 300, Easing.SinOut);

            await Task.Delay(150);

            txtDuration.TranslateTo(0, 0, 300, Easing.SinOut);
            txtDuration.FadeTo(1, 300, Easing.SinOut);

            await Task.Delay(150);

            frmAge.TranslateTo(0, 0, 300, Easing.SinOut);
            frmAge.FadeTo(1, 300, Easing.SinOut);

            await Task.Delay(100);

            frmGender.TranslateTo(0, 0, 300, Easing.SinOut);
            frmGender.FadeTo(1, 300, Easing.SinOut);
        }

        private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            var cellposition = viewLocationFetcher.GetCoordinates(View);

            SKPaint paint = new SKPaint()
            {
                Color = Color.FromHex("#22000000").ToSKColor()
            };

            using (SKPath path = new SKPath())
            {
                path.MoveTo(0, 0);
                path.LineTo((info.Width * .5f) - cellposition.Y, 0);
                path.LineTo((info.Width * .75f) - cellposition.Y, info.Height);
                path.LineTo(0, info.Height);
                path.Close();
                canvas.DrawPath(path, paint);
            }

            paint.Color = Color.FromHex("#22ffffff").ToSKColor();

            using (SKPath path = new SKPath())
            {
                path.MoveTo((info.Width * .5f) - cellposition.Y, 0);
                path.LineTo(info.Width, 0);
                path.LineTo(info.Width, info.Height);
                path.LineTo((info.Width * .75f) - cellposition.Y, info.Height);
                path.Close();
                canvas.DrawPath(path, paint);
            }
        }
    }
}