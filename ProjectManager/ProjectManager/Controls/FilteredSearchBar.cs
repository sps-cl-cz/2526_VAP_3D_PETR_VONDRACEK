using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Microsoft.Maui.Controls;

namespace ProjectManager.Controls
{
    public class FilteredSearchBar : SearchBar
    {
        public static BindableProperty ItemsSourceProperty = BindableProperty.Create(
            nameof(ItemsSource), typeof(IEnumerable), typeof(FilteredSearchBar), propertyChanged: OnItemsSourceChanged);

        private static void OnItemsSourceChanged(BindableObject bindable, object oldValue, object newValue)
        {
            if (bindable is FilteredSearchBar searchBar)
            {
                if (oldValue is INotifyCollectionChanged oldCollection)
                {
                    oldCollection.CollectionChanged -= (e, s) => searchBar.ApplyFilter();
                }

                if (newValue is INotifyCollectionChanged newCollection)
                {
                    newCollection.CollectionChanged += (e, s) => searchBar.ApplyFilter();
                }
                searchBar.ApplyFilter();
            }
        }

        void ApplyFilter()
        {
            FilteredItems.Clear();
            foreach (var item in ItemsSource)
            {
                string? itemString = item?.ToString();
                if (!string.IsNullOrEmpty(Filter))
                {
                    itemString = item.GetType().GetProperty(Filter)?.GetValue(item)?.ToString();
                }

                itemString = itemString?.ToLower() ?? "";
                if (itemString.Contains(Text?.ToLower() ?? ""))
                {
                    FilteredItems.Add(item);
                }
            }
        }

        public FilteredSearchBar()
        {
            FilteredItems = new ObservableCollection<object>();
            SearchButtonPressed += (sender, e) => ApplyFilter();
        }

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            ApplyFilter();
        }

        public static BindableProperty FilteredItemsProperty = BindableProperty.Create(
            nameof(FilteredItems), typeof(ObservableCollection<object>), typeof(FilteredSearchBar), defaultValue: new ObservableCollection<object>());

        public ObservableCollection<object> FilteredItems
        {
            get => (ObservableCollection<object>)GetValue(FilteredItemsProperty);
            set => SetValue(FilteredItemsProperty, value);
        }

        public string Filter
        {
            get => (string)GetValue(FilterProperty);
            set => SetValue(FilterProperty, value);
        }

        public static BindableProperty FilterProperty = BindableProperty.Create(
            nameof(Filter), typeof(string), typeof(FilteredSearchBar), defaultValue: "");

        IEnumerable ItemsSource 
        {
            get => (IEnumerable)GetValue(ItemsSourceProperty); 
            set => SetValue(ItemsSourceProperty, value);
        }


    }
}
