using System;
using System.Threading.Tasks;
using System.Windows.Forms.Integration;
using Cocos2DParticleEditor.Application.Messaging;
using GalaSoft.MvvmLight.Messaging;
using MahApps.Metro.Controls.Dialogs;

namespace Cocos2DParticleEditor.Presentation
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow
    {
        //private Game1 game;

        public MainWindow()
        {
            InitializeComponent();

            Messenger.Default.Send<GenericMessage<IntPtr>>(new GenericMessage<IntPtr>(RenderPanel.Handle));

            ElementHost.EnableModelessKeyboardInterop(this);
        }

        private void MetroWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Messenger.Default.Send<ExitGameMessage>(new ExitGameMessage());
        }
    }
}