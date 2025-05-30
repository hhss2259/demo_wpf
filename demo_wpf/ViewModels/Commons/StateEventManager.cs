using demo_wpf.ViewModels.UiModels.Abstracts;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_wpf.ViewModels.Commons
{
    public class StateEventManager
    {
        //상태
        protected State ThisState;

        //Event
        protected event EventHandler StateChanged_NotReady;
        protected event EventHandler StateChanged_Ready;
        protected event EventHandler StateChanged_Waiting;
        protected event EventHandler StateChanged_Running;
        protected event EventHandler StateChanged_Paused;
        protected event EventHandler StateChanged_Completed;

        public void ChangeState(State state)
        {
            ThisState = state;
            switch (ThisState)
            {
                case State.NotReady:
                    StateChanged_NotReady.Invoke(GetType(), new EventArgs());
                    break;
                case State.Ready:
                    StateChanged_Ready.Invoke(GetType(), new EventArgs());
                    break;
                case State.Waiting:
                    StateChanged_Waiting.Invoke(GetType(), new EventArgs());
                    break;
                case State.Running:
                    StateChanged_Running.Invoke(GetType(), new EventArgs());
                    break;
                case State.Paused:
                    StateChanged_Paused.Invoke(GetType(), new EventArgs());
                    break;
                case State.Completed:
                    StateChanged_Completed.Invoke(GetType(), new EventArgs());
                    break;
                default:
                    break;
            }
        }
        public void RegisterStateChangedEventListener(ABaseUiModel uiModel)
        {
            if (uiModel.HasNotReadyUi(out EventHandler notReadyHandler))
            {
                StateChanged_NotReady += notReadyHandler;
            }
            if (uiModel.HasReadyUi(out EventHandler readyHandler))
            {
                StateChanged_Ready += readyHandler;
            }
            if (uiModel.HasWaitingUi(out EventHandler waitingHandler))
            {
                StateChanged_Waiting += waitingHandler;
            }
            if (uiModel.HasRunningUi(out EventHandler runningHandler))
            {
                StateChanged_Running += runningHandler;
            }
            if (uiModel.HasPausedUi(out EventHandler pausedHandler))
            {
                StateChanged_Paused += pausedHandler;
            }
            if (uiModel.HasCompletedUi(out EventHandler completedHandler))
            {
                StateChanged_Completed += completedHandler;
            }
        }

    }
}
