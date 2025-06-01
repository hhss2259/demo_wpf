using demo_wpf.ViewModels.Commons;
using demo_wpf.ViewModels.UiModels.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_wpf.ViewModels.UiModels.Buttons.Abstrats
{
    public abstract class AButtonUiModel : ABaseUiModel
    {
        protected string _title = string.Empty;
        protected double _opacity = 0.6;
        protected string _background = string.Empty;
        protected string _foreground = string.Empty;
        protected bool _isEnabled = false;

        protected EventHandler MakeTargetedButtonUi;
        protected EventHandler MakeUntargetedButtonUi;

        public AButtonUiModel(StateEventManager stateEventManager)
        {
            MakeUntargetedButtonUi = (object? obj, EventArgs args) =>
            {
                Opacity = 0.6;
                IsEnabled = false;
            };

            MakeTargetedButtonUi = (object? obj, EventArgs args) =>
            {
                Opacity = 1;
                IsEnabled = true;
            };

            stateEventManager.RegisterStateChangedEventListener(this);
        }

        public override bool HasNotReadyUi(out EventHandler changeUi)
        {
            changeUi = MakeUntargetedButtonUi;
            return true;
        }

        public string Title
        {
            get => _title; set
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
        public
            string Background
        {
            get => _background;
            set
            {
                _background = value;
                OnPropertyChanged(nameof(Background));
            }
        }
        public string Foreground
        {
            get => _foreground;
            set
            {
                _foreground = value;
                OnPropertyChanged(nameof(Foreground));
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
