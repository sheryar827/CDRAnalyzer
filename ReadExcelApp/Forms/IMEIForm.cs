using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ReadExcelApp.Forms
{
    public partial class IMEIForm : Form
    {
        List<imeiUsedDate> imei;
        List<string> imeiu = new List<string>();
        public IMEIForm()
        {
            InitializeComponent();
        }

        Func<ChartPoint, string> labelPoint = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);

        private void IMEIForm_Load(object sender, EventArgs e)
        {
            labelA_Num.Text = Common.a_numForAnalysis;
            imeiUsed();
            pcIMEIUsed.LegendLocation = LegendLocation.Bottom;
        }

        private void imeiUsed()
        {
            string qry = "select IMEI, CONVERT(DATETIME, CONVERT(CHAR(8), Date, 112) + ' ' + CONVERT(CHAR(8), Time, 108)) from CDR_DB_Tbl where A_Num = '" + Common.a_numForAnalysis + "'";
            GetSqlDRAndConn getSqlDRAndConn = CommonMethods.getvalues(qry);
            SqlDataReader dr = getSqlDRAndConn.sqlDR;
            if (dr.HasRows)
            {
                // Create list with non-unique values
                imei = new List<imeiUsedDate>();


                while (dr.Read())
                {
                    imeiu.Add(dr["IMEI"].ToString());
                    imeiUsedDate imeiUsed = new imeiUsedDate(dr["IMEI"].ToString(), dr.GetValue(1).ToString()/*Getting the date*/);
                    imei.Add(imeiUsed);
                }

                dr.Close();
                getSqlDRAndConn.sqlConn.Close();


                // Make new unique list
                List<string> uniqueImeiUsed = imeiu.Distinct().ToList();
                gvImeiUsedDate.Columns.Add("IMEI USED", "IMEI USED");

                SeriesCollection series = new SeriesCollection();

                foreach (string iu in uniqueImeiUsed)
                {
                    int row = gvImeiUsedDate.Rows.Add();
                    int count = 0;
                    DataGridViewRow ro = gvImeiUsedDate.Rows[row];
                    ro.Cells["IMEI USED"].Value = iu;
                    ro.Cells["IMEI USED"].Style.BackColor = Color.Black;
                    ro.Cells["IMEI USED"].Style.ForeColor = Color.White;
                    foreach (imeiUsedDate iud in imei)
                    {
                        if (iu.Equals(iud.imei))
                        {
                            int rowId = gvImeiUsedDate.Rows.Add();
                            DataGridViewRow roww = gvImeiUsedDate.Rows[rowId];
                            roww.Cells["IMEI USED"].Value = iud.dateTime;
                            count++;
                        }
                    }

                    series.Add(item: new PieSeries()
                    {
                        Title = iu/*BasicConversation contain B-Party Contact Number*/
                        ,
                        Values = new ChartValues<int> { count },
                        DataLabels = true,
                        LabelPoint = labelPoint
                    });
                    pcIMEIUsed.Series = series;

                }
            }
        }


    }

}
