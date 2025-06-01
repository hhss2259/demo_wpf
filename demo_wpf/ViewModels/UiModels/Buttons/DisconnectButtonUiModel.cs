using demo_wpf.ViewModels.Commons;
using demo_wpf.ViewModels.UiModels.Buttons.Abstrats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_wpf.ViewModels.UiModels.Buttons
{
    public class DisconnectButtonUiModel : AButtonUiModel
    {
        public DisconnectButtonUiModel(StateEventManager stateEventManager) : base(stateEventManager)
        {
            Title = "장치 연결 해제";
        }
        //Target
        public override bool HasNotReadyUi(out EventHandler changeUi)
        {
            changeUi = MakeUntargetedButtonUi;
            return true;
        }
        //Untarget
        public override bool HasReadyUi(out EventHandler changeUi)
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

        //Untarget
        public override bool HasRunningUi(out EventHandler changeUi)
        {
            changeUi = MakeUntargetedButtonUi;
            return true;
        }
        //Untarget
        public override bool HasPausedUi(out EventHandler changeUi)
        {
            changeUi = MakeUntargetedButtonUi;
            return true;
        }
        //Untarget
        public override bool HasCompletedUi(out EventHandler changeUi)
        {
            changeUi = MakeUntargetedButtonUi;
            return true;
        } 
    }
}
