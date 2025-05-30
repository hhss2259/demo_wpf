using demo_wpf.ViewModels.Commons;
using demo_wpf.ViewModels.UiModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_wpf.ViewModels.UiModels
{
    public class FourthUiModel : ABaseUiModel
    {
        private string _title = "Ui 요소 4";
        private double _opacity;
        private bool _isEnabled;

        private Func<EventHandler> makeTargetedUiHandler;
        private Func<EventHandler> makeUntargetedUiHandler;

        public FourthUiModel(StateEventManager stateEventManager)
        {
            makeUntargetedUiHandler = () => { return (object? obj, EventArgs args) => { Opacity = 1; IsEnabled = true; }; };
            makeTargetedUiHandler = () => { return (object? obj, EventArgs args) => { Opacity = 0.6; IsEnabled = false; }; };

            stateEventManager.RegisterStateChangedEventListener(this);
        }

        public override bool HasNotReadyUi(out EventHandler changeUi)
        {
            changeUi = makeUntargetedUiHandler();
            changeUi += (object? obj, EventArgs args) => { /*추가 Ui 수정*/};
            return true;
        }
        public override bool HasReadyUi(out EventHandler changeUi)
        {
            changeUi = makeTargetedUiHandler();
            changeUi += (object? obj, EventArgs args) => { /*추가 Ui 수정*/ };
            return true;
        }
        public override bool HasWaitingUi(out EventHandler changeUi)
        {
            changeUi = (object? obj, EventArgs args) => {/*추가 Ui 수정*/ };
            return true;
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

        public double Opacity
        {
            get => _opacity;
            set
            {
                _opacity = value;
                OnPropertyChanged(nameof(Opacity));
            }
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

    }

}
