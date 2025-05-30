using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_wpf.ViewModels.UiModels.Abstracts
{
    public abstract class ABaseUiModel : INotifyPropertyChanged
    {
        //특정 상태에 사용하고 싶은 UI가 있다면 이 메소드를 오버라이드하여 구현
        public virtual bool HasNotReadyUi(out EventHandler changeUi) { changeUi = (object? obj, EventArgs args) => { }; return false; }
        public virtual bool HasReadyUi(out EventHandler changeUi) { changeUi = (object? obj, EventArgs args) => { }; return false; }
        public virtual bool HasWaitingUi(out EventHandler changeUi) { changeUi = (object? obj, EventArgs args) => { }; return false; }
        public virtual bool HasRunningUi(out EventHandler changeUi) { changeUi = (object? obj, EventArgs args) => { }; return false; }
        public virtual bool HasPausedUi(out EventHandler changeUi) { changeUi = (object? obj, EventArgs args) => { }; return false; }
        public virtual bool HasCompletedUi(out EventHandler changeUi) { changeUi = (object? obj, EventArgs args) => { }; return false; }


        //INotifyPropertyChanged 구현
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
