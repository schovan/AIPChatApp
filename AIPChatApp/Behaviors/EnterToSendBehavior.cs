using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;
using System.Windows.Input;

namespace AIPChatApp.Behaviors
{
    public class EnterToSendBehavior : Behavior<TextBox>
    {
        public static readonly System.Windows.DependencyProperty CommandProperty =
            System.Windows.DependencyProperty.Register(nameof(Command), typeof(ICommand), typeof(EnterToSendBehavior), new System.Windows.PropertyMetadata(null));

        public ICommand Command
        {
            get => (ICommand)GetValue(CommandProperty);
            set => SetValue(CommandProperty, value);
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.PreviewKeyDown += AssociatedObject_PreviewKeyDown;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.PreviewKeyDown -= AssociatedObject_PreviewKeyDown;
            base.OnDetaching();
        }

        private void AssociatedObject_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (Keyboard.Modifiers == ModifierKeys.Shift)
                {
                    // Allow normal newline behavior
                    return;
                }

                e.Handled = true;
                if (Command != null && Command.CanExecute(null))
                {
                    Command.Execute(null);
                }
            }
        }
    }
}
