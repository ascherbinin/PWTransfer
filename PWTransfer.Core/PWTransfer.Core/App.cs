using MvvmCross.Core.ViewModels;
using MvvmCross.Localization;
using MvvmCross.Platform;
using MvvmCross.Platform.IoC;
using PWTransfer.Core.Contracts.Services;
using PWTransfer.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PWTransfer.Localization;

namespace PWTransfer.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            CreatableTypes()
                .EndingWith("Repository")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            Mvx.RegisterSingleton<IMvxTextProvider>
                (new ResxTextProvider(Strings.ResourceManager));

            RegisterAppStart(new AppStart());
        }
    }
}
