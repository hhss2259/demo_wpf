using demo_wpf.ViewModels.Commons;
using demo_wpf.ViewModels.UiModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_wpf.ViewModels.UiModels
{
    public class ThirdUiModel : ABaseUiModel
    {
        private string _title = "시험2";
        private string _text;
        private double _opacity;
        private bool _isEnabled;

        private Func<string, EventHandler> makeTargetedUiHandler;
        private Func<string, EventHandler> makeUntargetedUiHandler;

        public Action<string> MakeLog;

        public ThirdUiModel(StateEventManager stateEventManager)
        {
            makeTargetedUiHandler = (string? text) =>
            {
                return (object? obj, EventArgs args) =>
                {
                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        Text = text;
                    }
                    Opacity = 1;
                    IsEnabled = true;
                };
            };
            makeUntargetedUiHandler = (string? text) =>
            {
                return (object? obj, EventArgs args) =>
                {
                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        Text = text;
                    }
                    Opacity = 0.6;
                    IsEnabled = false;
                };
            };

            MakeLog = (string step) => {

                if (step is string currentStep)
                {
                    if (currentStep.ToString() == "[테스트 시작]")
                    {
                        Text = currentStep;
                    }
                    else
                    {
                        Text = Text + $"\n{currentStep}";
                    }
                }
            };
            stateEventManager.RegisterStateChangedEventListener(this);
        }


        public override bool HasNotReadyUi(out EventHandler changeUi)
        {
            changeUi = makeUntargetedUiHandler("[대기]");
            return true;
        }
        public override bool HasReadyUi(out EventHandler changeUi)
        {
            changeUi = makeUntargetedUiHandler("[대기]");
            return true;
        }
        public override bool HasWaitingUi(out EventHandler changeUi)
        {
            changeUi = makeTargetedUiHandler("[준비 완료]");
            return true;
        }
        public override bool HasRunningUi(out EventHandler changeUi)
        {
            changeUi = makeUntargetedUiHandler(string.Empty);
            return true;
        }
        public override bool HasPausedUi(out EventHandler changeUi)
        {
            changeUi = makeUntargetedUiHandler(string.Empty);
            return true;
        }
        public override bool HasCompletedUi(out EventHandler changeUi)
        {
            changeUi = makeUntargetedUiHandler(string.Empty);
            return true;
        }
        public string Text
        {
            get => _text;
            set
            {
                _text = value;
                OnPropertyChanged(nameof(Text));
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
