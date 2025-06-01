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
using System.Windows;
using System.Windows.Input;

namespace demo_wpf.ViewModels
{
    public class MainWindowViewModel : ABaseViewModel
    {
        //Ui 요소 모델
        private FirstUiModel _firstUiModel;
        private SecondUiModel _secondUiModel;
        private ThirdUiModel _thirdUiModel;
        private FourthUiModel _fourthUiModel;

        //Ui 버튼 모델
        private FirstButtonUiModel _firstButtonUiModel;
        private SecondButtonUiModel _secondButtonUiModel;
        private ThirdButtonUiModel _thirdButtonUiModel;
        private FourthButtonUiModel _fourthButtonUiModel;
        private FifthButtonUiModel _fifthButtonUiModel;

        private ConnectButtonUiModel _connectButtonUiModel;
        private DisconnectButtonUiModel _disconnectButtonUiModel;



        //Command
        public ICommand FirstCommand { get; }
        public ICommand SecondCommand { get; }
        public ICommand ThirdCommand { get; }
        public ICommand FourthCommand { get; }
        public ICommand FifthCommand { get; }

        public ICommand ConnectCommand { get; }

        public ICommand DisconnectCommand { get; }


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
            _connectButtonUiModel = new ConnectButtonUiModel(_defaultStateEventManger);
            _disconnectButtonUiModel = new DisconnectButtonUiModel(_defaultStateEventManger);


            //기본 상태 관리자의 상태 변경 
            _defaultStateEventManger.ChangeState(State.NotReady);

            //Command 초기화
            FirstCommand = new RelayCommand((object? obj) => 
            {
                _defaultStateEventManger.ChangeState(State.Waiting);
            });
            SecondCommand = new RelayCommand( async (object? obj) =>
            {
                _defaultStateEventManger.ChangeState(State.Running);
                await Task.Delay(1000); // Simulate some delay
                SecondUiModel.MakeLog("테스트 완료");
                await Task.Delay(1000); // Simulate some delay
                ThirdUiModel.MakeLog("테스트 완료");
                _defaultStateEventManger.ChangeState(State.Completed);
            });
            ThirdCommand = new RelayCommand((object? obj) => _defaultStateEventManger.ChangeState(State.Ready));
            FourthCommand = new RelayCommand((object? obj) =>   _defaultStateEventManger.ChangeState(State.Waiting));
            FifthCommand = new RelayCommand( async (object? obj) =>
            {
                await Task.Delay(300);
                MessageBox.Show("테스트 완료");  
                _defaultStateEventManger.ChangeState(State.Waiting);
            });
            
            ConnectCommand = new RelayCommand((object? obj) => _defaultStateEventManger.ChangeState(State.Ready));
            DisconnectCommand = new RelayCommand((object? obj) => _defaultStateEventManger.ChangeState(State.NotReady));
        }

        public FirstUiModel FirstUiModel
        {
            get => _firstUiModel;
            set
            {
                _firstUiModel = value;
                OnPropertyChanged(nameof(FirstUiModel));
            }
        }
        public SecondUiModel SecondUiModel
        {
            get => _secondUiModel;
            set
            {
                _secondUiModel = value;
                OnPropertyChanged(nameof(SecondUiModel));
            }
        }
        public ThirdUiModel ThirdUiModel
        {
            get => _thirdUiModel;
            set
            {
                _thirdUiModel = value;
                OnPropertyChanged(nameof(ThirdUiModel));
            }
        }
        public FourthUiModel FourthUiModel
        {
            get => _fourthUiModel;
            set
            {
                _fourthUiModel = value;
                OnPropertyChanged(nameof(FourthUiModel));
            }
        }

        public FirstButtonUiModel FirstButtonUiModel
        {
            get => _firstButtonUiModel;
            set
            {
                _firstButtonUiModel = value;
                OnPropertyChanged(nameof(FirstButtonUiModel));
            }
        }
        public SecondButtonUiModel SecondButtonUiModel
        {
            get => _secondButtonUiModel;
            set
            {
                _secondButtonUiModel = value;
                OnPropertyChanged(nameof(SecondButtonUiModel));
            }
        }
        public ThirdButtonUiModel ThirdButtonUiModel
        {
            get => _thirdButtonUiModel;
            set
            {
                _thirdButtonUiModel = value;
                OnPropertyChanged(nameof(ThirdButtonUiModel));
            }
        }
        public FourthButtonUiModel FourthButtonUiModel
        {
            get => _fourthButtonUiModel;
            set
            {
                _fourthButtonUiModel = value;
                OnPropertyChanged(nameof(FourthButtonUiModel));
            }
        }
        public FifthButtonUiModel FifthButtonUiModel
        {
            get => _fifthButtonUiModel;
            set
            {
                _fifthButtonUiModel = value;
                OnPropertyChanged(nameof(FifthButtonUiModel));
            }
        }

        public ConnectButtonUiModel ConnectButtonUiModel
        {
            get => _connectButtonUiModel;
            set
            {
                _connectButtonUiModel = value;
                OnPropertyChanged(nameof(ConnectButtonUiModel));
            }
        }

        public DisconnectButtonUiModel DisconnectButtonUiModel
        {
            get => _disconnectButtonUiModel;
            set
            {
                _disconnectButtonUiModel = value;
                OnPropertyChanged(nameof(DisconnectButtonUiModel));
            }
        }
    }
}
