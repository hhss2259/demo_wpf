using demo_wpf.ViewModels.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demo_wpf.ViewModels.Abstrats
{
    public abstract class ABaseViewModel : INotifyPropertyChanged
    {
        //StateEventMannager 관리
        Dictionary<string, StateEventManager> stateEventManagers = new Dictionary<string, StateEventManager>();

        //생성자에서 Default StateEventManager를 초기화하여 제공
        public ABaseViewModel()
        {
            StateEventManager  defaultStateEventManager = new StateEventManager();
            stateEventManagers.Add("Default", defaultStateEventManager);
        }

        //Default StateEventManager 외에 다른  StateEventManager를 추가할 수 있는 메소드
        protected StateEventManager CreateStateManager(string name)
        {
            StateEventManager stateEventManager = new StateEventManager();
            if (stateEventManagers.TryAdd(name, stateEventManager))
            {
                return stateEventManager;
            }else
            {
                throw new ArgumentException($"StateEventManager with name '{name}' already exists.");
            }
        }
        //DefaultStataEventManager를 가져오는 메소드
        protected StateEventManager GetDefaultStateEventManager()
        {
            return GetStateEventManager("Default");
        }

        //이름으로 StateEventManager를 가져오는 메소드
        protected StateEventManager GetStateEventManager(string? name)
        {
            if (name == null || name == string.Empty)
            {
                name = "Default";
            }

            if (stateEventManagers.TryGetValue(name, out StateEventManager? stateEventManager))
            {
                return stateEventManager;
            }
            else
            {
                throw new KeyNotFoundException($"StateEventManager with name '{name}' not found.");
            }
        }

        //INotifyPropertyChanged 구현
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
