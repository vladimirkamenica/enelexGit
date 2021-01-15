using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using enelex3.View;

namespace enelex3.ConvertToGrahView
{
    public static class GraphViewConvert
    {
        public static ObservableCollection<GraphView> MeasureToGraphView(ObservableCollection<MeasuresView> measureView)
        {
            ObservableCollection<GraphView> graphView = new ObservableCollection<GraphView>();
            graphView.Clear();
            
       
           foreach(var measure in measureView)
            {
                GraphView x = new GraphView();
                x.Id = measure.ID;
                x.Ge = measure.Ge;
                x.Lab = measure.Lab;
                graphView.Add(x);
            }
            return graphView;
        }

        public static ObservableCollection<GraphView> SaveMeasureToGraphView(ObservableCollection<SaveMeasureViewGroup> measureView)
        {
            ObservableCollection<GraphView> graphView = new ObservableCollection<GraphView>();
            graphView.Clear();

            foreach (var measure in measureView.Select(x=> x.Details))
            {
                
                foreach(var xx in measure)
                {
                    GraphView x = new GraphView();
                    x.Id = xx.Id;
                    x.Ge = xx.Ge;
                    x.Lab = xx.Lab;
                    graphView.Add(x);

                }

              
            }
            return graphView;
        }
    }
}
