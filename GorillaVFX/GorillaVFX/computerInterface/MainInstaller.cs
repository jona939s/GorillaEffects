using ComputerInterface.Interfaces;
using Zenject;

namespace GorillaVFX.computerInterface
{
    internal class MainInstaller : Installer
    {
        public override void InstallBindings()
        {
            Container.Bind<IComputerModEntry>().To<Views.mainView.mainEntry>().AsSingle();
        }
    }
}
