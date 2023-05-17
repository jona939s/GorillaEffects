using ComputerInterface.Interfaces;
using ComputerInterface.ViewLib;
using System;

namespace GorillaVFX.computerInterface.Views
{
    internal class mainView : ComputerView
    {
        // I will do this when I get back on. Prefable we will have settings to dick tate particle levels and things like that.
        internal class mainEntry : IComputerModEntry
        {
            public string EntryName => Main.NAME;
            public Type EntryViewType => typeof(Views.mainView);
        }
    }
}
