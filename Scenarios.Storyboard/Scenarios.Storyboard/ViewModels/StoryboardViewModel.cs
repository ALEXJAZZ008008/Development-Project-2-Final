using MahApps.Metro.Controls.Dialogs;
using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.WpfGraphControl;
using Scenarios.Core;
using Scenarios.Storyboard.Adapters;
using Scenarios.Storyboard.Commands;
using Scenarios.Storyboard.ViewModels.Factories;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Scenarios.Storyboard.ViewModels
{
    public class StoryboardViewModel :  NavigablePageViewModel 
    {
        private readonly IDialogCoordinator _dialogCoordinator;
        private bool _sidePanelVisible = false;
        private ScenarioViewModel _selectedScenario;

        private readonly IScenarioViewModelFactory _scenarioFactory;
        private readonly IUnityPlayer _unityPlayer;
        private readonly IScenarioListStore _scenarioListStore;

        private string _storyboardName;

        protected StoryboardViewModel()
        {

        }


        public StoryboardViewModel(IScenarioViewModelFactory scenarioFactory, 
            IDialogCoordinator dialogCoordinator,
            IUnityPlayer unityPlayer, 
            IScenarioListStore scenarioListStore)
        {
            _scenarioFactory = scenarioFactory ?? 
                throw new ArgumentNullException(nameof(scenarioFactory));

            _dialogCoordinator = dialogCoordinator ??
                throw new ArgumentNullException(nameof(dialogCoordinator));

            _scenarioListStore = scenarioListStore ??
                throw new ArgumentNullException(nameof(scenarioListStore));

            Scenarios = new ObservableCollection<ScenarioViewModel>();

            _unityPlayer = unityPlayer;

            AddNewScenarioCommand = new DelegateCommand(AddNewScenario);
            RemoveScenarioCommand = new DelegateCommand(RemoveScenario);
            CreateJsonCommand = new DelegateCommand(CreateJson);
            SaveStoryboardCommand = new DelegateCommand(SaveStoryboard);
            DisplayGraphWindowCommand = new DelegateCommand(DisplayGraphWindow);
        }

        public string Name
        {
            get => _storyboardName;

            set
            {
                _storyboardName = value;
                OnPropertyChanged();
            }
        }
        
        public ScenarioViewModel SelectedScenario
        {
            get => _selectedScenario;

            set
            {
                _selectedScenario = value;
                OnPropertyChanged();

                if (_selectedScenario != null && Scenarios.Count > 0)
                {
                    SidePanelVisible = true;
                }
            }
        }
        
        
        public ObservableCollection<ScenarioViewModel> Scenarios { get; set; }

        public ICommand CreateJsonCommand { get; }

        public ICommand AddNewScenarioCommand { get; }

        public ICommand RemoveScenarioCommand { get; }

        public ICommand SaveStoryboardCommand { get; }

        public ICommand DisplayGraphWindowCommand { get; }

        public bool SidePanelVisible
        {
            get => _sidePanelVisible;

            set
            {
                _sidePanelVisible = value;
                OnPropertyChanged();
            }
        }

        private void AddNewScenario(object parameter)
        {
            ScenarioViewModel scenarioToAdd =
                _scenarioFactory.Create(this);
            
            Scenarios.Add(scenarioToAdd);
        }

        private void RemoveScenario(object parameter)
        {
            Scenarios.Remove(SelectedScenario);
        }

        private void CreateJson(object parameter)
        {
            API.ScenarioList scenarioList =
                StoryboardViewModelToScenarioListAdapter.Convert(this);

            string output = "";

            API.JSONParser.TObjectToJSON(ref output, scenarioList);

            #if Debug
                MessageBox.Show(output);
            #endif

            _unityPlayer.PlayInUnity(scenarioList);
        }

        private void SaveStoryboard(object parameter)
        {
            if (Name != null)
            {
                API.ScenarioList scenarioList =
                    StoryboardViewModelToScenarioListAdapter.Convert(this);

                _scenarioListStore.Store(scenarioList);
            }
            else
            {
                MessageBox.Show("Please name the storyboard.");
            }

            MessageBox.Show($"Saved {Name}");
        }

        private void DisplayGraphWindow(object parameter)
        {
            GraphViewer graphViewer = new GraphViewer();
            DockPanel graphViewerPanel = new DockPanel();
            Grid mainGrid = new Grid();
            mainGrid.Children.Add(graphViewerPanel);
            graphViewer.BindToPanel(graphViewerPanel);

            Window window = new Window();
            window.Content = mainGrid;
            window.Loaded += (a, b) =>
            {
                Graph graph = GraphFactory.CreateGraph(this);
                graphViewer.Graph = graph;
            };

            window.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnOpening(object parameter)
        {
            if (Name == null)
            {
                Task.Factory.StartNew(async () =>
                {
                    Name = await _dialogCoordinator.ShowInputAsync(this,
                                                 "Storyboard Name",
                                                 "Please input a friendly name for your new Storyboard");
                });
            }
        }

    }
}
