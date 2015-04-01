using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using Xceed.Wpf.Toolkit.PropertyGrid.Editors;

namespace Cocos2DParticleEditor.Domain.CustomPropertyEditors
{
    /// <summary>
    /// Interaction logic for FileLocationEditor.xaml
    /// </summary>
    public partial class FileLocationEditor : UserControl, ITypeEditor
    {
        public FileLocationEditor()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(FileLocationEditor),
                                                                                        new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        private void openFileDialog_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();


            if (dialog.ShowDialog() == true)
            {
                Value = dialog.FileName;
            }
        }

        public FrameworkElement ResolveEditor(Xceed.Wpf.Toolkit.PropertyGrid.PropertyItem propertyItem)
        {
            Binding binding = new Binding("Value");
            binding.Source = propertyItem;
            binding.Mode = propertyItem.IsReadOnly ? BindingMode.OneWay : BindingMode.TwoWay;
            BindingOperations.SetBinding(this, FileLocationEditor.ValueProperty, binding);
            return this;
        }
    }
}
