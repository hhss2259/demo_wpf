using demo_wpf.ViewModels.Commons;
using demo_wpf.ViewModels.UiModels.Buttons.Abstrats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_wpf.ViewModels.UiModels.Buttons
{
    public class FifthButtonUiModel : AButtonUiModel
    {
        public FifthButtonUiModel(StateEventManager stateEventManager) : base(stateEventManager)
        {
            Title = "시험 저장";
        }

        //Untarget
        public override bool HasRunningUi(out EventHandler changeUi)
        {
            changeUi = MakeUntargetedButtonUi;
            return true;
        }

        //Target
        public override bool HasPausedUi(out EventHandler changeUi)
        {
            changeUi = MakeUntargetedButtonUi;
            return true;
        }

        // Target
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
