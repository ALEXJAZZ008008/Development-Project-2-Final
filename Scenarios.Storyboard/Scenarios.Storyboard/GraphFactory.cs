using Microsoft.Msagl.Drawing;
using Microsoft.Msagl.Layout.Layered;
using Scenarios.Storyboard.ViewModels;

namespace Scenarios.Storyboard
{
    public static class GraphFactory
    {
        public static Graph CreateGraph(StoryboardViewModel storyboardViewModel)
        {
            Graph graph = new Graph
            {
            };

            foreach (var scenario in storyboardViewModel.Scenarios)
            {
                Node node = new Node(scenario.Name);
            }

            foreach (var scenario in storyboardViewModel.Scenarios)
            {

                if (scenario.Decision.DecisionText != null)
                {
                    if (graph.EdgeCount == 0)
                    {
                        Node startNode = new Node(scenario.Name);
                        startNode.Attr.FillColor = Color.Green;
                        graph.AddNode(startNode);
                    }
                    Node decisionNode = new Node(scenario.Decision.DecisionText);
                    decisionNode.Attr.Shape = Shape.Diamond;
                    decisionNode.Attr.FillColor = Color.Black;
                    decisionNode.Label.FontColor = Color.White;
                    graph.AddNode(decisionNode);
                    graph.AddEdge(scenario.Name, decisionNode.Id);

                    foreach (var choice in scenario.Decision.Choices)
                    {
                        graph.AddEdge(decisionNode.Id, choice.Text, choice.DestinationScenario.Name);

                    }
                }
            }
            graph.Attr.LayerDirection = LayerDirection.TB;

            return graph;
        }
    }
}
