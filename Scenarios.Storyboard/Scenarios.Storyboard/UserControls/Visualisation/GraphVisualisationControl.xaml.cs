using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.WpfGraphControl;
using Scenarios.Storyboard.Commands;
using Scenarios.Storyboard.ViewModels;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Scenarios.Storyboard.UserControls.Visualisation
{
    /// <summary>
    /// Interaction logic for GraphVisualisationControl.xaml
    /// </summary>
    public partial class GraphVisualisationControl : UserControl
    {
        public static readonly DependencyProperty StoryboardProperty =
            DependencyProperty.Register("Storyboard",
                                        typeof(StoryboardViewModel),
                                        typeof(GraphVisualisationControl));

        public static readonly DependencyProperty DisplayGraphCommandProperty =
    DependencyProperty.Register("DisplayGraphCommand",
                                typeof(StoryboardViewModel),
                                typeof(GraphVisualisationControl));

        public GraphVisualisationControl()
        {
            InitializeComponent();
            DisplayGraphCommand = new DelegateCommand(CreateAndLayoutAndDisplayGraph);
        }

        public ICommand DisplayGraphCommand
        {
            get => (ICommand)GetValue(DisplayGraphCommandProperty);

            set => SetValue(DisplayGraphCommandProperty, value);
        }

        public StoryboardViewModel Storyboard
        {
            get => (StoryboardViewModel)GetValue(StoryboardProperty);

            set => SetValue(StoryboardProperty, value);
        }

        private void CreateAndLayoutAndDisplayGraph(object parameter)
        {
            try
            {
                GraphViewer graphViewer = new GraphViewer();
                DockPanel graphViewerPanel = new DockPanel();
                Foo.Children.Add(graphViewerPanel);
                graphViewer.BindToPanel(graphViewerPanel);
                Graph graph = GraphFactory.CreateGraph(Storyboard);
                graphViewer.Graph = graph;
                UpdateLayout();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString(), "Graph Visualisation Load Failed", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
