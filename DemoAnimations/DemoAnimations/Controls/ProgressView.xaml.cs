using System;
using System.Runtime.CompilerServices;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoAnimations.Controls
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProgressView : ContentView
    {
        public ProgressView()
        {
            InitializeComponent();
        }

        private void SetValue()
        {
            completeBar.WidthRequest = (Width / Total) * Value;
        }

        public static readonly BindableProperty ValueProperty =
            BindableProperty.Create(nameof(Value), typeof(double), typeof(ProgressView), default(double), propertyChanged: OnValuePropertyChanged);

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly BindableProperty TotalProperty =
            BindableProperty.Create(nameof(Total), typeof(double), typeof(ProgressView), 100d);

        public double Total
        {
            get { return (double)GetValue(TotalProperty); }
            set { SetValue(TotalProperty, value); }
        }

        private static void OnValuePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var progressView = bindable as ProgressView;

            if (progressView.Width > 0)
                progressView.SetValue();
        }

        public static readonly BindableProperty TextProperty =
            BindableProperty.Create(nameof(Text), typeof(string), typeof(ProgressView), default(string), propertyChanged: OnTextPropertyChanged);

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        private static void OnTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var progressView = bindable as ProgressView;
            progressView.SetText(newValue.ToString());
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (propertyName == ProgressView.WidthProperty.PropertyName)
            {
                if (Width > 0)
                    SetValue();
            }

            if (propertyName == ProgressView.HeightProperty.PropertyName)
            {
                if (Height > 0)
                    SetCornerRadius();
            }
        }

        private void SetCornerRadius()
        {
            var cornerRadius = Height / 2;
            completeBar.CornerRadius = cornerRadius;
            remainingBar.CornerRadius = cornerRadius;
        }

        private void SetText(string text)
        {
            percentageText.Text = text;
        }
    }
}