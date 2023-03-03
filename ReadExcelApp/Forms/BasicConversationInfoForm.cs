using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ReadExcelApp.Forms
{
    public partial class BasicConversationInfoForm : Form
    {
        public BasicConversationInfoForm()
        {
            InitializeComponent();

        }

        Func<ChartPoint, string> labelPoint = chartpoint => string.Format("{0} ({1:P})", chartpoint.Y, chartpoint.Participation);

        private void basicConvInfo()
        {
            SeriesCollection series = new SeriesCollection();

            //string SP_COUNT_A_Num = "exec dbo.SP_COUNT_A_Num '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "'";
            /*lbTotalSession.Text = CommonMethods.getTotalCount(SP_COUNT_A_Num).ToString();*/

            //var lookup = Common.allRecordA_Nums.ToLookup(i => i.B_Num, j => new { j.Call_Dir, j.Call_Type });
            lbTotalSession.Text = Common.allRecordA_Nums.Count.ToString();
            lbTotalCalls.Text = Common.allRecordA_Nums.Where(x => x.Call_Type.Equals(Common.voice)).Count().ToString();
            lbTotalSms.Text = Common.allRecordA_Nums.Where(x => x.Call_Type.Equals(Common.sms)).Count().ToString();
            lbInCalls.Text = Common.allRecordA_Nums.Where(x => x.Call_Type.Equals(Common.voice) && x.Call_Dir.Equals(Common.incoming)).Count().ToString();
            lbInSms.Text = Common.allRecordA_Nums.Where(x => x.Call_Type.Equals(Common.sms) && x.Call_Dir.Equals(Common.incoming)).Count().ToString();
            lbOutCalls.Text = Common.allRecordA_Nums.Where(x => x.Call_Type.Equals(Common.voice) && x.Call_Dir.Equals(Common.outgoing)).Count().ToString();
            lbOutSms.Text = Common.allRecordA_Nums.Where(x => x.Call_Type.Equals(Common.sms) && x.Call_Dir.Equals(Common.outgoing)).Count().ToString();
            //string SP_COUNT_A_Num_Voice = "exec dbo.SP_COUNT_A_Num_Voice '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "'";
            //lbTotalCalls.Text = CommonMethods.getTotalCount(SP_COUNT_A_Num_Voice).ToString();

            //string SP_COUNT_A_Num_SMS = "exec dbo.SP_COUNT_A_Num_SMS '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "'";
            //lbTotalSms.Text = CommonMethods.getTotalCount(SP_COUNT_A_Num_SMS).ToString();

            //string SP_COUNT_A_NUM_Voice_Incoming = "exec dbo.SP_COUNT_A_NUM_Voice_Incoming '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "'";
            //lbInCalls.Text = CommonMethods.getTotalCount(SP_COUNT_A_NUM_Voice_Incoming).ToString();

            //string SP_COUNT_A_NUM_SMS_Incoming = "exec dbo.SP_COUNT_A_NUM_SMS_Incoming '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "'";
            //lbInSms.Text = CommonMethods.getTotalCount(SP_COUNT_A_NUM_SMS_Incoming).ToString();

            //string SP_COUNT_A_NUM_Voice_Outgoing = "exec dbo.SP_COUNT_A_NUM_Voice_Outgoing '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "'";
            //lbOutCalls.Text = CommonMethods.getTotalCount(SP_COUNT_A_NUM_Voice_Outgoing).ToString();

            //string SP_COUNT_A_NUM_SMS_Outgoing = "exec dbo.SP_COUNT_A_NUM_SMS_Outgoing '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "'";
            //lbOutSms.Text = CommonMethods.getTotalCount(SP_COUNT_A_NUM_SMS_Outgoing).ToString();

            List<GetBasicConversation> getBasicConversations = new List<GetBasicConversation>();
            getBasicConversations.Add(new GetBasicConversation("In", Convert.ToInt32(lbInCalls.Text.ToString())));
            getBasicConversations.Add(new GetBasicConversation("Out", Convert.ToInt32(lbOutCalls.Text.ToString())));
            getBasicConversations.Add(new GetBasicConversation("InSMS", Convert.ToInt32(lbInSms.Text.ToString())));
            getBasicConversations.Add(new GetBasicConversation("OutSMS", Convert.ToInt32(lbOutSms.Text.ToString())));


            /*GetBasicConversation getBasicConversation = new GetBasicConversation(Convert.ToInt32(lbInCalls.Text.ToString())
                , Convert.ToInt32(lbOutCalls.Text.ToString()), Convert.ToInt32(lbInSms.Text.ToString()), Convert.ToInt32(lbOutSms.Text.ToString()));*/

            foreach (var bc in getBasicConversations)
            {
                series.Add(item: new PieSeries() { Title = bc.BasicConversation, Values = new ChartValues<int> { bc.BasicConversationCount }, DataLabels = true, LabelPoint = labelPoint });
                pcbasicConver.Series = series;
            }

        }



        private Int32 GetQTR(string Call_Type, string T1, string T2)
        {
            // Sql query to get data between quarters
            //string SP_COUNT_A_NUM_Time = "exec dbo.SP_COUNT_A_NUM_Time '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "' , '" + T1 + "', '" + T2 + "', '" + Call_Type + "'";
            // Count Call_Type b/w quarters
            //Int32 a = CommonMethods.getTotalCount(SP_COUNT_A_NUM_Time);
            Int32 a = Common.allRecordA_Nums.Where(x => x.Call_Type.Equals(Call_Type)
            && Convert.ToDateTime(x.Time).TimeOfDay >= Convert.ToDateTime(T1).TimeOfDay
            && Convert.ToDateTime(x.Time).TimeOfDay <= Convert.ToDateTime(T2).TimeOfDay).Count();
            // return count to function from where GetQTR is called
            return a;

        }

        private void activeQtr()
        {
            lbQTR1Voice.Text = GetQTR(Common.voice, "08:00:00", "15:59:59").ToString();
            lbQTR1Sms.Text = GetQTR(Common.sms, "08:00:00", "15:59:59").ToString();
            lbQTR2Voice.Text = GetQTR(Common.voice, "16:00:00", "23:59:59").ToString();
            lbQTR2Sms.Text = GetQTR(Common.sms, "16:00:00", "23:59:59").ToString();
            lbQTR3Voice.Text = GetQTR(Common.voice, "00:00:00", "7:59:59").ToString();
            lbQTR3Sms.Text = GetQTR(Common.sms, "00:00:00", "7:59:59").ToString();
            /*lbQTR4Voice.Text = GetQTR("Voice", "00:00:00", "05:59:59").ToString();
            lbQTR4Sms.Text = GetQTR("SMS", "00:00:00", "05:59:59").ToString();*/
            List<GetBasicConversation> getBasicConversations = new List<GetBasicConversation>();
            getBasicConversations.Add(new GetBasicConversation("08:00:00 To 15:59:59||Calls", Convert.ToInt32(lbQTR1Voice.Text.ToString())));
            getBasicConversations.Add(new GetBasicConversation("8:00:00 To 15:59:59||SMS", Convert.ToInt32(lbQTR1Sms.Text.ToString())));

            getBasicConversations.Add(new GetBasicConversation("16:00:00 To 23:59:59||Calls", Convert.ToInt32(lbQTR2Voice.Text.ToString())));
            getBasicConversations.Add(new GetBasicConversation("16:00:00 To 23:59:59||SMS", Convert.ToInt32(lbQTR2Sms.Text.ToString())));

            getBasicConversations.Add(new GetBasicConversation("00:00:00 To 7:59:59||Calls", Convert.ToInt32(lbQTR3Voice.Text.ToString())));
            getBasicConversations.Add(new GetBasicConversation("00:00:00 To 7:59:59||SMS", Convert.ToInt32(lbQTR3Sms.Text.ToString())));


            SeriesCollection series = new SeriesCollection();

            foreach (var aq in getBasicConversations)
            {
                series.Add(item: new PieSeries() { Title = aq.BasicConversation, Values = new ChartValues<int> { aq.BasicConversationCount }, DataLabels = true, LabelPoint = labelPoint });
                pcbasicConver.Series = series;
            }

        }

        private void daysAnalyz()
        {
            string countQry = null;

            // counting calls on Sunday
            lbCallsSun.Text = Common.allRecordA_Nums.Where(x => x.Call_Type.Equals(Common.voice) && x.Weekday.Equals("Sunday")).Count().ToString();
            lbSmsSun.Text = Common.allRecordA_Nums.Where(x => x.Call_Type.Equals(Common.sms) && x.Weekday.Equals("Sunday")).Count().ToString();
            lbCallsMon.Text = Common.allRecordA_Nums.Where(x => x.Call_Type.Equals(Common.voice) && x.Weekday.Equals("Monday")).Count().ToString();
            lbSmsMon.Text = Common.allRecordA_Nums.Where(x => x.Call_Type.Equals(Common.sms) && x.Weekday.Equals("Monday")).Count().ToString();
            lbCallsTue.Text = Common.allRecordA_Nums.Where(x => x.Call_Type.Equals(Common.voice) && x.Weekday.Equals("Tuesday")).Count().ToString();
            lbSmsTue.Text = Common.allRecordA_Nums.Where(x => x.Call_Type.Equals(Common.sms) && x.Weekday.Equals("Tuesday")).Count().ToString();
            lbCallsWed.Text = Common.allRecordA_Nums.Where(x => x.Call_Type.Equals(Common.voice) && x.Weekday.Equals("Wednesday")).Count().ToString();
            lbSmsWed.Text = Common.allRecordA_Nums.Where(x => x.Call_Type.Equals(Common.sms) && x.Weekday.Equals("Wednesday")).Count().ToString();
            lbCallsThu.Text = Common.allRecordA_Nums.Where(x => x.Call_Type.Equals(Common.voice) && x.Weekday.Equals("Thursday")).Count().ToString();
            lbSmsThu.Text = Common.allRecordA_Nums.Where(x => x.Call_Type.Equals(Common.sms) && x.Weekday.Equals("Thursday")).Count().ToString();
            lbCallsFri.Text = Common.allRecordA_Nums.Where(x => x.Call_Type.Equals(Common.voice) && x.Weekday.Equals("Friday")).Count().ToString();
            lbSmsFri.Text = Common.allRecordA_Nums.Where(x => x.Call_Type.Equals(Common.sms) && x.Weekday.Equals("Friday")).Count().ToString();
            lbCallsSat.Text = Common.allRecordA_Nums.Where(x => x.Call_Type.Equals(Common.voice) && x.Weekday.Equals("Saturday")).Count().ToString();
            lbSmsSat.Text = Common.allRecordA_Nums.Where(x => x.Call_Type.Equals(Common.sms) && x.Weekday.Equals("Saturday")).Count().ToString();

            /*countQry = "exec dbo.SP_COUNT_A_NUM_Weekday '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "', 'voice', 'sunday'";
            lbCallsSun.Text = CommonMethods.getTotalCount(countQry).ToString();*/
            // counting SMS on Sunday
            //countQry = "exec dbo.SP_COUNT_A_NUM_Weekday '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "', 'sms', 'sunday'";
            //lbSmsSun.Text = CommonMethods.getTotalCount(countQry).ToString();
            // counting calls on Monday
            /*countQry = "exec dbo.SP_COUNT_A_NUM_Weekday '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "', 'voice', 'Monday'";
            lbCallsMon.Text = CommonMethods.getTotalCount(countQry).ToString();
            // counting SMS on Monday
            countQry = "exec dbo.SP_COUNT_A_NUM_Weekday '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "', 'sms', 'Monday'";
            lbSmsMon.Text = CommonMethods.getTotalCount(countQry).ToString();
            // counting calls on Tuesday
            countQry = "exec dbo.SP_COUNT_A_NUM_Weekday '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "', 'voice', 'Tuesday'";
            lbCallsTue.Text = CommonMethods.getTotalCount(countQry).ToString();
            // counting SMS on Tuesday
            countQry = "exec dbo.SP_COUNT_A_NUM_Weekday '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "', 'sms', 'Tuesday'";
            lbSmsTue.Text = CommonMethods.getTotalCount(countQry).ToString();
            // counting calls on Wednesday
            countQry = "exec dbo.SP_COUNT_A_NUM_Weekday '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "', 'voice', 'Wednesday'";
            lbCallsWed.Text = CommonMethods.getTotalCount(countQry).ToString();
            // counting SMS on Wednesday
            countQry = "exec dbo.SP_COUNT_A_NUM_Weekday '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "', 'sms', 'Wednesday'";
            lbSmsWed.Text = CommonMethods.getTotalCount(countQry).ToString();
            // counting calls on Thursday
            countQry = "exec dbo.SP_COUNT_A_NUM_Weekday '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "', 'voice', 'Thursday'";
            lbCallsThu.Text = CommonMethods.getTotalCount(countQry).ToString();
            // counting SMS on Thursday
            countQry = "exec dbo.SP_COUNT_A_NUM_Weekday '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "', 'sms', 'Thursday'";
            lbSmsThu.Text = CommonMethods.getTotalCount(countQry).ToString();
            // counting calls on Friday
            countQry = "exec dbo.SP_COUNT_A_NUM_Weekday '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "', 'voice', 'Friday'";
            lbCallsFri.Text = CommonMethods.getTotalCount(countQry).ToString();
            // counting SMS on Friday
            countQry = "exec dbo.SP_COUNT_A_NUM_Weekday '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "', 'sms', 'Friday'";
            lbSmsFri.Text = CommonMethods.getTotalCount(countQry).ToString();
            // counting Calls on Saturday
            countQry = "exec dbo.SP_COUNT_A_NUM_Weekday '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "', 'voice', 'Saturday'";
            lbCallsSat.Text = CommonMethods.getTotalCount(countQry).ToString();
            // counting SMS on Saturday
            countQry = "exec dbo.SP_COUNT_A_NUM_Weekday '" + Common.a_numForAnalysis + "', '" + Common.project_Name + "', 'sms', 'Saturday'";
            lbSmsSat.Text = CommonMethods.getTotalCount(countQry).ToString();*/
            /*daysAnalyzed.Text = StandCDR.Count().ToString();*/

            List<GetBasicConversation> getBasicConversations = new List<GetBasicConversation>();

            // Adding Calls and SMS then displaying results
            getBasicConversations.Add(new GetBasicConversation("Sun", Convert.ToInt32(lbCallsSun.Text.ToString()) + Convert.ToInt32(lbSmsSun.Text.ToString())));
            getBasicConversations.Add(new GetBasicConversation("Mon", Convert.ToInt32(lbCallsMon.Text.ToString()) + Convert.ToInt32(lbSmsMon.Text.ToString())));
            getBasicConversations.Add(new GetBasicConversation("Tue", Convert.ToInt32(lbCallsTue.Text.ToString()) + Convert.ToInt32(lbSmsTue.Text.ToString())));
            getBasicConversations.Add(new GetBasicConversation("Wed", Convert.ToInt32(lbCallsWed.Text.ToString()) + Convert.ToInt32(lbSmsWed.Text.ToString())));
            getBasicConversations.Add(new GetBasicConversation("Thu", Convert.ToInt32(lbCallsThu.Text.ToString()) + Convert.ToInt32(lbSmsThu.Text.ToString())));
            getBasicConversations.Add(new GetBasicConversation("Fri", Convert.ToInt32(lbCallsFri.Text.ToString()) + Convert.ToInt32(lbSmsFri.Text.ToString())));
            getBasicConversations.Add(new GetBasicConversation("Sat", Convert.ToInt32(lbCallsSat.Text.ToString()) + Convert.ToInt32(lbSmsSat.Text.ToString())));


            SeriesCollection series = new SeriesCollection();

            foreach (var aq in getBasicConversations)
            {
                series.Add(item: new PieSeries() { Title = aq.BasicConversation, Values = new ChartValues<int> { aq.BasicConversationCount }, DataLabels = true, LabelPoint = labelPoint });
                pcbasicConver.Series = series;
            }
        }

        private void BasicConversationInfoForm_Load(object sender, EventArgs e)
        {
            labelA_Num.Text = Common.a_numForAnalysis;
            daysAnalyz();
            pcbasicConver.LegendLocation = LegendLocation.Top;
        }

        private void gbBasicConver_MouseHover(object sender, EventArgs e)
        {
            basicConvInfo();

        }


        private void gbActiveThirds_MouseHover(object sender, EventArgs e)
        {
            activeQtr();

        }

        private void gbWeekDays_MouseHover(object sender, EventArgs e)
        {
            daysAnalyz();

        }




    }
}
