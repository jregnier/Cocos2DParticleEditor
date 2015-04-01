namespace Cocos2DParticleEditor.Presentation.Behaviors
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Interactivity;
    using Cocos2DParticleEditor.Application.Messaging;
    using GalaSoft.MvvmLight.Messaging;

    /// <summary>
    /// Represents a custom behavior used to show a save file dialog.
    /// </summary>
    public class ExportParticleSystemBehavior : Behavior<Button>
    {
        public MessageIdentifiers MessageIdentifier { get; set; }

        public string InitialFolder { get; set; }

        public string Title { get; set; }

        public string Filter { get; set; }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Click += AssociatedObject_Click;
        }

        private void AssociatedObject_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dialog = new Microsoft.Win32.SaveFileDialog();
            dialog.RestoreDirectory = true;
            dialog.Title = Title;
            dialog.Filter = Filter;

            if (dialog.ShowDialog() == true)
            {
                Messenger.Default.Send<ExportFileSelectedMessage>(
                    new ExportFileSelectedMessage(dialog.FileName) { Identifier = MessageIdentifier });
            }
        }

        protected override void OnDetaching()
        {
            AssociatedObject.Click -= AssociatedObject_Click;
            base.OnDetaching();
        }
    }
}