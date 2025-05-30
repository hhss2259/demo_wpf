using demo_wpf.ViewModels.Commons;
using demo_wpf.ViewModels.UiModels.Buttons.Abstrats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_wpf.ViewModels.UiModels.Buttons
{
    public  class ThirdButtonUiModel : AButtonUiModel
    {
        public ThirdButtonUiModel(StateEventManager stateEventManager) : base(stateEventManager)
        {
            Title = "버튼3(Ui 요소 7)";
        }
        // Untarget
        public override bool HasReadyUi(out EventHandler changeUi)
        {
            changeUi = MakeUntargetedButtonUi;
            return true;
        }
        // Target
        public override bool HasWaitingUi(out EventHandler changeUi)
        {
            changeUi = MakeTargetedButtonUi;
            return true;
        }
        //UnTarget
        public override bool HasRunningUi(out EventHandler changeUi)
        {
            changeUi = MakeUntargetedButtonUi;
            return true;
        }
    }
}
