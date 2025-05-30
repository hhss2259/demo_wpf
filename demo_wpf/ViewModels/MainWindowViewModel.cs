using demo_wpf.ViewModels.Abstrats;
using demo_wpf.ViewModels.Commands;
using demo_wpf.ViewModels.Commons;
using demo_wpf.ViewModels.UiModels;
using demo_wpf.ViewModels.UiModels.Abstracts;
using demo_wpf.ViewModels.UiModels.Buttons;
using demo_wpf.ViewModels.UiModels.Buttons.Abstrats;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace demo_wpf.ViewModels
{
    public class MainWindowViewModel : ABaseViewModel
    {
        //UI 모델들
        private ABaseUiModel _firstUiModel;
        private ABaseUiModel _secondUiModel;
        private ABaseUiModel _thirdUiModel;
        private ABaseUiModel _fourthUiModel;

        private AButtonUiModel _firstButtonUiModel;
        private AButtonUiModel _secondButtonUiModel;
        private AButtonUiModel _thirdButtonUiModel;
        private AButtonUiModel _fourthButtonUiModel;
        private AButtonUiModel _fifthButtonUiModel;

        //Command
        public ICommand firstCommand { get; }  
        public ICommand secondCommand { get; }
        public ICommand thirdCommand { get; }
        public ICommand fourthCommand { get; }
        public ICommand fifthCommand { get; }

        //기본 상태 관리자
        private StateEventManager _defaultStateEventManger;

        public MainWindowViewModel()
        {
            //기본 상태 관리자 가져오기
            _defaultStateEventManger = GetDefaultStateEventManager();

            _firstUiModel = new FirstUiModel(_defaultStateEventManger);
            _secondUiModel = new SecondUiModel(_defaultStateEventManger);
            _thirdUiModel = new ThirdUiModel(_defaultStateEventManger);
            _fourthUiModel = new FourthUiModel(_defaultStateEventManger);

            _firstButtonUiModel = new FirstButtonUiModel(_defaultStateEventManger);
            _secondButtonUiModel = new SecondButtonUiModel(_defaultStateEventManger);
            _thirdButtonUiModel = new ThirdButtonUiModel(_defaultStateEventManger);
            _fourthButtonUiModel = new FourthButtonUiModel(_defaultStateEventManger);
            _fifthButtonUiModel = new FifthButtonUiModel(_defaultStateEventManger);

            //기본 상태 관리자의 상태 변경 
            _defaultStateEventManger.ChangeState(State.NotReady);

            //Command 초기화
            firstCommand = new RelayCommand((object? obj) => _defaultStateEventManger.ChangeState(State.Waiting));
            secondCommand = new RelayCommand((object? obj) => _defaultStateEventManger.ChangeState(State.Running));
            thirdCommand = new RelayCommand((object? obj) => _defaultStateEventManger.ChangeState(State.Ready));
            fourthCommand = new RelayCommand((object? obj) => _defaultStateEventManger.ChangeState(State.Waiting));
            fifthCommand = new RelayCommand((object? obj) => _defaultStateEventManger.ChangeState(State.Completed));
        }

        public ABaseUiModel FirstUiModel
        {
            get => _firstUiModel;
            set
            {
                _firstUiModel = value;
                OnPropertyChanged(nameof(FirstUiModel));
            }
        }
        public ABaseUiModel SecondUiModel
        {
            get => _secondUiModel;
            set
            {
                _secondUiModel = value;
                OnPropertyChanged(nameof(SecondUiModel));
            }
        }
        public ABaseUiModel ThirdUiModel
        {
            get => _thirdUiModel;
            set
            {
                _thirdUiModel = value;
                OnPropertyChanged(nameof(ThirdUiModel));
            }
        }
        public ABaseUiModel FourthUiModel
        {
            get => _fourthUiModel;
            set
            {
                _fourthUiModel = value;
                OnPropertyChanged(nameof(FourthUiModel));
            }
        }

        public AButtonUiModel FirstButtonUiModel
        {
            get => _firstButtonUiModel;
            set
            {
                _firstButtonUiModel = value;
                OnPropertyChanged(nameof(FirstButtonUiModel));
            }
        }
        public AButtonUiModel SecondButtonUiModel
        {
            get => _secondButtonUiModel;
            set
            {
                _secondButtonUiModel = value;
                OnPropertyChanged(nameof(SecondButtonUiModel));
            }
        }
        public AButtonUiModel ThirdButtonUiModel
        {
            get => _thirdButtonUiModel;
            set
            {
                _thirdButtonUiModel = value;
                OnPropertyChanged(nameof(ThirdButtonUiModel));
            }
        }
        public AButtonUiModel FourthButtonUiModel
        {
            get => _fourthButtonUiModel;
            set
            {
                _fourthButtonUiModel = value;
                OnPropertyChanged(nameof(FourthButtonUiModel));
            }
        }
        public AButtonUiModel FifthButtonUiModel
        {
            get => _fifthButtonUiModel;
            set
            {
                _fifthButtonUiModel = value;
                OnPropertyChanged(nameof(FifthButtonUiModel));
            }
        }
    }
}
