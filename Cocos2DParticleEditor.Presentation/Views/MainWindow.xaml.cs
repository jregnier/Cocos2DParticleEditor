using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cocos2D;
using GalaSoft.MvvmLight.Messaging;

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
    }
}
