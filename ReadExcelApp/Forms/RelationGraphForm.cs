using Microsoft.Msagl.Drawing;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace ReadExcelApp.Forms
{
    public partial class RelationGraphForm : Form
    {
        public RelationGraphForm()
        {
            InitializeComponent();
            getRelation();
            /*string sp = "exec dbo.CDR_A_Num '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "'";*/
            /*DataTable dt = getRelation();*/
            /*List<string> uniqueList = dt.AsEnumerable().Select(x => x[1].ToString()).Distinct().ToList();

            *//*System.Windows.Forms.Form form = new System.Windows.Forms.Form();*//*
            //create a viewer object 
            //Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");

            foreach (string num in uniqueList)
            {
                if (num.Length >= 10)
                {
                    Microsoft.Msagl.Drawing.Edge e = graph.AddEdge(Common.a_numForAnalysis, num);
                    //e.Attr.LineWidth = dt.Select("B_Num = '"+num+"'").Count();
                    e.LabelText = dt.Select("B_Num = '" + num + "'").Count().ToString();
                }

            }

            graph.Attr.LayerDirection = Microsoft.Msagl.Drawing.LayerDirection.LR;


            *//*//create the graph content 
            graph.AddEdge("A", "B");
            graph.AddEdge("B", "C");
            graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;*//*
            //bind the graph to the viewer 
            gViewer.Graph = graph;
            //associate the viewer with the form 
            SuspendLayout();
            //gv.Dock = DockStyle.Fill;
            //Controls.Add(viewer);
            ResumeLayout();
            //show the form 
            //ShowDialog();*/
        }

        private void getRelation()
        {
            /*string sp = "exec dbo.CDR_A_Num '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "'";
            DataTable dt = await CommonMethods.getRecords(sp);*/
            List<string> uniqueList = Common.allRecordA_Nums.AsEnumerable().Select(x => x.B_Num.ToString()).Distinct()
                .Where(bp => bp.Substring(0, 2).Equals("92") && bp.Length == 12).ToList();

            /*System.Windows.Forms.Form form = new System.Windows.Forms.Form();*/
            //create a viewer object 
            //Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object 
            Graph graph = new Graph("graph");

            foreach (string num in uniqueList)
            {
                if (num.Length >= 10)
                {
                    Microsoft.Msagl.Drawing.Edge e = graph.AddEdge(Common.a_numForAnalysis, num);
                    //e.Attr.LineWidth = dt.Select("B_Num = '"+num+"'").Count();
                    e.LabelText = Common.allRecordA_Nums.Where(x => x.B_Num.Equals(num)).Count().ToString();
                }

            }

            graph.FindNode(Common.a_numForAnalysis).Attr.FillColor = Color.PaleGreen;

            //graph.Attr.LayerDirection = Microsoft.Msagl.Drawing.LayerDirection.LR;

            // display the graph in mds format
            graph.LayoutAlgorithmSettings = new Microsoft.Msagl.Layout.MDS.MdsLayoutSettings();
            gViewer.CurrentLayoutMethod = Microsoft.Msagl.GraphViewerGdi.LayoutMethod.UseSettingsOfTheGraph;


            /*//create the graph content 
            graph.AddEdge("A", "B");
            graph.AddEdge("B", "C");
            graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;*/
            //bind the graph to the viewer 
            gViewer.Graph = graph;
            //associate the viewer with the form 
            SuspendLayout();
            //gv.Dock = DockStyle.Fill;
            //Controls.Add(viewer);
            ResumeLayout();

        }
    }
}
