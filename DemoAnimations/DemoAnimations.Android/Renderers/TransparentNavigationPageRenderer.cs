using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DemoAnimations.Controls;
using DemoAnimations.Droid.Renderers;
using DemoAnimations.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Platform.Android.AppCompat;

[assembly: ExportRenderer(typeof(MainNavigationPage), typeof(TransparentNavigationPageRenderer))]
namespace DemoAnimations.Droid.Renderers
{
    public class TransparentNavigationPageRenderer : NavigationPageRenderer
    {
        public TransparentNavigationPageRenderer(Context context) : base(context)
        {
        }

        IPageController PageController => Element as IPageController;
        MainNavigationPage MainNavigationPage => Element as MainNavigationPage;

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            MainNavigationPage.IgnoreLayoutChange = true;
            base.OnLayout(changed, l, t, r, b);
            MainNavigationPage.IgnoreLayoutChange = false;

            int containerHeight = b - t;

            PageController.ContainerArea = new Rectangle(0, 0, Context.FromPixels(r - l), Context.FromPixels(containerHeight));

            for (var i = 0; i < ChildCount; i++)
            {
                var child = GetChildAt(i);

                if (child is Android.Support.V7.Widget.Toolbar)
                {
                    continue;
                }

                child.Layout(0, 0, r, b);
            }
        }
    }
}