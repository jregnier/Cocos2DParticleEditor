/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:Cocos2DParticleEditor.Presentation"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using Autofac;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace Cocos2DParticleEditor.Application.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        private IContainer _container;
        public IContainer Container
        {
            get { return _container; }
        }

        public ViewModelLocator()
        {
            var _builder = new ContainerBuilder();
            _builder.RegisterType<MainViewModel>();
            _container = _builder.Build();
        }

        public MainViewModel Main { get { return _container.Resolve<MainViewModel>(); } }
        
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}