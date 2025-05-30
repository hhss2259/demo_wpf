using demo_wpf.ViewModels.Commons;
using demo_wpf.ViewModels.UiModels.Buttons.Abstrats;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_wpf.ViewModels.UiModels.Buttons
{
    public class FirstButtonUiModel : AButtonUiModel
    {
        public FirstButtonUiModel(StateEventManager stateEventManager) : base(stateEventManager)
        {
            Title = "버튼1(Ui 요소 5)";
        }
        //Target
        public override bool HasReadyUi(out EventHandler changeUi)
        {
            changeUi = MakeTargetedButtonUi;

            return true;
        }
        //Untarget
        public override bool HasWaitingUi(out EventHandler changeUi)
        {
            changeUi = MakeUntargetedButtonUi;
            Debug.WriteLine("SaveOptionButton : HasWaitingUi");
            return true;
        }
    }
}
