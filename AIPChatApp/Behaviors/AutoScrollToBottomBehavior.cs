using Microsoft.Xaml.Behaviors;
using System.Collections.Specialized;
using System.Windows.Controls;
using System.Windows;

namespace AIPChatApp.Behaviors
{
    public class AutoScrollToBottomBehavior : Behavior<ScrollViewer>
    {
        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register(nameof(ItemsSource), typeof(INotifyCollectionChanged), typeof(AutoScrollToBottomBehavior), new PropertyMetadata(null, OnItemsSourceChanged));

        public INotifyCollectionChanged ItemsSource
        {
            get => (INotifyCollectionChanged)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        private static void OnItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is AutoScrollToBottomBehavior behavior)
            {
                if (e.OldValue is INotifyCollectionChanged oldCollection)
                {
                    oldCollection.CollectionChanged -= behavior.OnCollectionChanged;
                }
                if (e.NewValue is INotifyCollectionChanged newCollection)
                {
                    newCollection.CollectionChanged += behavior.OnCollectionChanged;
                }
            }
        }

        private void OnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add && AssociatedObject != null)
            {
                Application.Current.Dispatcher.Invoke(async () =>
                {
                    await Task.Delay(50);
                    AssociatedObject.ScrollToBottom();
                });
            }
        }
    }
}
