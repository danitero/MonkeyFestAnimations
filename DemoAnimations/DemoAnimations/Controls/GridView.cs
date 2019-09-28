using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DemoAnimations.Controls
{
    public class GridView : StackLayout
    {
        Grid gridContent;
        int currentColumn;
        int currentRow;

        public event EventHandler<EventArgs> ItemTapped;

        public static readonly BindableProperty TappedCommandProperty =
            BindableProperty.Create(nameof(TappedCommand), typeof(ICommand), typeof(GridView), default(ICommand));

        public ICommand TappedCommand
        {
            get { return (ICommand)GetValue(TappedCommandProperty); }
            set { SetValue(TappedCommandProperty, value); }
        }

        public DataTemplate ItemTemplate { get; set; }


        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<object>), typeof(GridView), default(IEnumerable<object>), propertyChanged: OnItemsSourcePropertyChanged);

        public IEnumerable<object> ItemsSource
        {
            get { return (IEnumerable<object>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }


        public static readonly BindableProperty ColumnCountProperty =
            BindableProperty.Create(nameof(ColumnCount), typeof(int), typeof(GridView), 1);

        public int ColumnCount
        {
            get { return (int)GetValue(ColumnCountProperty); }
            set { SetValue(ColumnCountProperty, value); }
        }

        public static readonly BindableProperty ItemsSpacingProperty =
            BindableProperty.Create(nameof(ItemsSpacing), typeof(double), typeof(GridView), default(double));

        public double ItemsSpacing
        {
            get { return (double)GetValue(ItemsSpacingProperty); }
            set { SetValue(ItemsSpacingProperty, value); }
        }

        private async static void OnItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var gridView = bindable as GridView;

            if (gridView != null)
            {
                gridView.Children.Clear();

                if (newValue == null)
                    return;

                gridView.gridContent = new Grid()
                {
                    ColumnSpacing = gridView.Spacing,
                    RowSpacing = gridView.Spacing,
                    VerticalOptions = LayoutOptions.Start
                };

                var items = (newValue as IEnumerable<object>).ToList();
                var rowsCount = Math.Ceiling(Convert.ToDouble(items.Count / gridView.ColumnCount));

                for (int i = 0; i < rowsCount; i++)
                    gridView.gridContent.RowDefinitions.Add(new RowDefinition());

                for (int i = 0; i < gridView.ColumnCount; i++)
                    gridView.gridContent.ColumnDefinitions.Add(new ColumnDefinition());

                gridView.currentColumn = 0;
                gridView.currentRow = 0;

                gridView.Children.Add(gridView.gridContent);

                foreach (var item in newValue as IEnumerable<object>)
                {
                    var view = gridView.ItemTemplate.CreateContent() as View;
                    view.BindingContext = item;

                    if (gridView.currentColumn == gridView.ColumnCount)
                    {
                        gridView.currentColumn = 0;
                        gridView.currentRow++;
                    }

                    Grid.SetColumn(view, gridView.currentColumn);
                    Grid.SetRow(view, gridView.currentRow);

                    if (gridView.TappedCommand != null)
                    {
                        view.GestureRecognizers.Add(new TapGestureRecognizer()
                        {
                            Command = gridView.TappedCommand,
                            CommandParameter = item
                        });
                    }

                    if (gridView.ItemTapped != null)
                    {
                        var tapGesture = new TapGestureRecognizer();

                        tapGesture.Tapped += (s, e) =>
                        {
                            gridView.ItemTapped.Invoke(item, new EventArgs());
                        };

                        view.GestureRecognizers.Add(tapGesture);
                    }

                    gridView.gridContent.Children.Add(view);

                    gridView.currentColumn++;
                }

                gridView.OnItemsSourceChanged(oldValue as IEnumerable<object>, newValue as IEnumerable<object>);
            }
        }

        private void OnItemsSourceChanged(IEnumerable<object> oldValue, IEnumerable<object> newValue)
        {
            var newValueCollectionChanged = newValue as INotifyCollectionChanged;

            if (newValueCollectionChanged != null)
            {
                newValueCollectionChanged.CollectionChanged += NewValueCollectionChanged_CollectionChanged;
            }
        }

        async void NewValueCollectionChanged_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    foreach (var item in e.NewItems)
                    {
                        var view = ItemTemplate.CreateContent() as View;
                        view.BindingContext = item;

                        if (currentColumn == ColumnCount)
                        {
                            currentColumn = 0;
                            currentRow++;
                        }

                        Grid.SetColumn(view, currentColumn);
                        Grid.SetRow(view, currentRow);

                        if (TappedCommand != null)
                            view.GestureRecognizers.Add(new TapGestureRecognizer()
                            {
                                Command = TappedCommand,
                                CommandParameter = item
                            });

                        gridContent.Children.Add(view);

                        currentColumn++;
                    }

                    ReorderItems();
                    break;
                case NotifyCollectionChangedAction.Remove:
                    foreach (var item in e.OldItems)
                    {
                        var oldView = gridContent.Children.FirstOrDefault(c => c.BindingContext == item);

                        if (oldView != null)
                        {
                            if (currentColumn == 0)
                            {
                                currentColumn = ColumnCount;
                                currentRow--;
                            }

                            gridContent.Children.Remove(oldView);

                            currentColumn--;
                        }
                    }

                    ReorderItems();
                    break;
                case NotifyCollectionChangedAction.Move:
                case NotifyCollectionChangedAction.Replace:
                case NotifyCollectionChangedAction.Reset:
                    var collection = ((IEnumerable<object>)sender).ToList();

                    if (collection != null)
                    {
                        ItemsSource = collection;
                    }
                    break;
            }

        }

        private void ReorderItems()
        {
            var rowsCount = Math.Ceiling(Convert.ToDouble(gridContent.Children.Count / ColumnCount));

            gridContent.RowDefinitions.Clear();
            gridContent.ColumnDefinitions.Clear();

            for (int i = 0; i < rowsCount; i++)
                gridContent.RowDefinitions.Add(new RowDefinition());

            for (int i = 0; i < ColumnCount; i++)
                gridContent.ColumnDefinitions.Add(new ColumnDefinition());

            currentColumn = 0;
            currentRow = 0;

            foreach (var child in gridContent.Children)
            {
                if (currentColumn == ColumnCount)
                {
                    currentColumn = 0;
                    currentRow++;
                }

                Grid.SetColumn(child, currentColumn);
                Grid.SetRow(child, currentRow);

                currentColumn++;
            }
        }
    }
}
