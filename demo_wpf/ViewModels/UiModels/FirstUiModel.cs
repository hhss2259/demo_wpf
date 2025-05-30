using demo_wpf.ViewModels.Commons;
using demo_wpf.ViewModels.UiModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_wpf.ViewModels.UiModels
{
    public class FirstUiModel : ABaseUiModel
    {

        private EventHandler MakeTargetedUi;
        private EventHandler MakeUntargetedUi;

        private string _title = "Ui 요소 1";   
        private bool _isEnabled = false;
        private double _opacity = 0.6;

        public FirstUiModel (StateEventManager stateEventManager) 
        {
            MakeUntargetedUi = (object? obj, EventArgs args) => { this.Opacity = 0.6; this.IsEnabled = false; };
            MakeTargetedUi = (object? obj, EventArgs args) => { this.Opacity = 1; this.IsEnabled = true; };

            //상태 이벤트 매니저에 UI 모델 등록
            stateEventManager.RegisterStateChangedEventListener(this);
        }

        public override bool HasNotReadyUi(out EventHandler changeUi)
        {
            changeUi = MakeUntargetedUi;
            return true;
        }
        public override bool HasReadyUi(out EventHandler changeUi)
        {
            changeUi = MakeTargetedUi;
            return true;
        }
        public override bool HasWaitingUi(out EventHandler changeUi)
        {
            changeUi = MakeUntargetedUi;
            return true;
        }

        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {   
                _isEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
            }
        }
        public double Opacity
        {
            get => _opacity;
            set
            {
                _opacity = value;
                OnPropertyChanged(nameof(Opacity));
            }
        }
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
    }
}
