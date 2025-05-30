using demo_wpf.ViewModels.Commons;
using demo_wpf.ViewModels.UiModels.Abstracts;
using demo_wpf.ViewModels.UiModels.Buttons.Abstrats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_wpf.ViewModels.UiModels.Buttons
{
    public class FourthButtonUiModel : AButtonUiModel
    {
        public FourthButtonUiModel(StateEventManager stateEventManager) : base(stateEventManager)
        {
            Title = "버튼4(Ui 요소 8)";
        }
        // Untarget
        public override bool HasRunningUi(out EventHandler changeUi)
        {
            changeUi = MakeUntargetedButtonUi;
            return true;
        }
        //Target
        public override bool HasPausedUi(out EventHandler changeUi)
        {
            changeUi = MakeTargetedButtonUi;
            return true;
        }
        //Target
        public override bool HasCompletedUi(out EventHandler changeUi)
        {
            changeUi = MakeTargetedButtonUi;
            return true;
        }
        //Untarget
        public override bool HasWaitingUi(out EventHandler changeUi)
        {
            changeUi = MakeUntargetedButtonUi;
            return true;
        }
    }
}
