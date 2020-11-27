using MaterialDesignCustomEffect.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MaterialDesignCustomEffect
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<ComboBoxCombinationView>();
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();

            var regionMan = Container.Resolve<IRegionManager>();
            regionMan.RegisterViewWithRegion("MainRegion", typeof(ComboBoxCombinationView));
        }
    }
}
