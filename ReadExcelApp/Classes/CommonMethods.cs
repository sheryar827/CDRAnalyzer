using ExcelDataReader;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using LumenWorks.Framework.IO.Csv;
using ReadExcelApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadExcelApp
{
    class CommonMethods
    {
        public static int getCount(string qry)
        {
            int numRecs = 0;
            SqlConnection sqlcon = new SqlConnection(AppConnection.GetConnectionString());
            try
            {
                SqlCommand sqlcmnd = new SqlCommand(qry, sqlcon);
                sqlcon.Open();
                numRecs = (int)sqlcmnd.ExecuteScalar();
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                messageDialog(ex.Message);
            }
            return numRecs;
        }

        public static int getTotalCount(string sp)
        {
            int numRecs = 0;
            SqlConnection sqlcon = new SqlConnection(AppConnection.GetConnectionString());
            try
            {
                SqlCommand sqlcmnd = new SqlCommand(sp, sqlcon);
                sqlcon.Open();
                numRecs = (int)sqlcmnd.ExecuteScalar();
                sqlcon.Close();
            }
            catch (Exception ex)
            {
                messageDialog(ex.Message);
            }
            return numRecs;
        }

        public static GetSqlDRAndConn getvalues(string Qry)
        {
            // Command to connect to sql server
            SqlConnection conn = new SqlConnection(AppConnection.GetConnectionString());
            SqlDataReader dr = null;
            try
            {
                // executing the command
                SqlCommand Comm = new SqlCommand(Qry, conn);
                Comm.CommandTimeout = 0;
                // Open the connection to sql server
                conn.Open();
                // Read data from sql server
                dr = Comm.ExecuteReader();
            }
            catch (Exception ex)
            {
                messageDialog(ex.Message);
            }
            // after data read closing the sql connection

            GetSqlDRAndConn getSqlDRAndConn = new GetSqlDRAndConn(conn, dr);
            // return data to the funcation from where getvalues is called
            return getSqlDRAndConn;

            //Conn.Close();

        }

        public static async Task<DataTable> getRecords(string proc)
        {

            using (SqlConnection con = new SqlConnection(AppConnection.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(proc, con))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    DataTable dt = new DataTable();
                    // SqlCommand timeout 360 seconds
                    cmd.CommandTimeout = 360;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.UpdateBatchSize = 5000;
                    await Task.Run(() =>
                    da.Fill(dt));
                    return dt;
                }
            }
            /*SqlConnection con = new SqlConnection(AppConnection.GetConnectionString());
            DataTable dt = new DataTable();
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            try
            {

                con.Open();
                // Stored Procedure to view GeneralPoliceTable records
                SqlCommand com = new SqlCommand(proc, con);
                com.CommandTimeout = 360;
                SqlDataAdapter da = new SqlDataAdapter(com);
                da.UpdateBatchSize = 5000;
                await Task.Run(() =>
                da.Fill(dt));
            }
            catch (Exception ex)
            {
                messageDialog(ex.Message);
            }

            con.Close();*/
            //      
            //messageDialog($"Rows Uploaded: {dt.Rows.Count}, Total time: {TimeSpan.FromMilliseconds(stopwatch.ElapsedMilliseconds).Seconds} Seconds");
            // return data to the funcation from where getvalues is called
            /*return dt;*/
            // after data read closing the sql connection

        }

        public static void insertRecords(string proc)
        {
            using (SqlConnection con = new SqlConnection(AppConnection.GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(proc, con))
                {
                    if (con.State != ConnectionState.Open)
                    {
                        con.Open();
                    }

                    cmd.ExecuteNonQuery();
                }
            }
            /*SqlConnection con = new SqlConnection(Common.connectionString);
            try
            {
                con.Open();
                // Stored Procedure to view GeneralPoliceTable records
                SqlCommand com = new SqlCommand(proc, con);
                com.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                messageDialog(ex.Message);
            }*/
        }

        public static async Task<List<CDRSummary>> cdrSummary(string A_Num, string project_Name, string Lat, string Lng)
        {
            List<CDRSummary> csByTotalInOut = new List<CDRSummary>();
            string aParty = A_Num.Substring(0, A_Num.IndexOf(" "));
            string sp = "exec dbo.CDR_A_Num_Loc '" + aParty + "', '" + project_Name + "', '" + Lat + "', '" + Lng + "'";
            DataTable dt = await CommonMethods.getRecords(sp);

            /*string Qry = "select B_Num from CDR_DB_Tbl where A_Num = '" + A_Num + "' and Lat = '"+ Lat +"' and Lng = '" + Lng + "'";
            GetSqlDRAndConn getSqlDRAndConn = getvalues(Qry);
            SqlDataReader B_Num = getSqlDRAndConn.sqlDR;*/
            if (dt.Rows.Count > 0)
            {
                // Create list with non-unique values
                /*List<string> listB_Num = new List<string>();

                while (B_Num.Read())
                {
                    listB_Num.Add(B_Num["B_Num"].ToString());
                    
                    //listBox1.Items.Add(nine);
                }

                B_Num.Close();
                getSqlDRAndConn.sqlConn.Close();*/

                // Make new unique list
                List<string> uniqueListB_Num = dt.AsEnumerable().Select(x => x[1].ToString()).Distinct().ToList();

                // List to show in PiChart
                List<GetBasicConversation> getBasicConversations = new List<GetBasicConversation>();

                List<CDRSummary> cdrsum = new List<CDRSummary>();
                int inCmCalls = 0;
                int outGngCalls = 0;
                int inCmSms = 0;
                int outGngSms = 0;
                foreach (string num in uniqueListB_Num)
                {

                    // counting incoming calls of the given number
                    /*string countQryIncoming = "SELECT COUNT(*) FROM CDR_DB_Tbl WHERE A_Num = '" + A_Num + "' and B_Num = '" + num + "' and Call_Dir = 'incoming' and Call_Type = 'voice' and Lat = '"+Lat+"' and Lng = '"+Lng+"'";
                    inCmCalls = getCount(countQryIncoming);*/

                    inCmCalls = dt.Select("B_Num = '" + num + "' and Call_Dir = 'incoming' and Call_Type = 'voice'").Count();

                    // counting outgoing calls of the given number
                    /*string countQryOutgoing = "SELECT COUNT(*) FROM CDR_DB_Tbl WHERE A_Num = '" + A_Num + "' and B_Num = '" + num + "' and Call_Dir = 'outgoing' and Call_Type = 'voice' and Lat = '" + Lat + "' and Lng = '" + Lng + "'";
                    outGngCalls = getCount(countQryOutgoing);*/

                    outGngCalls = dt.Select("B_Num = '" + num + "' and Call_Dir = 'outgoing' and Call_Type = 'voice'").Count();

                    // counting incoming SMS of the given number
                    /*string countQryIncomingSms = "SELECT COUNT(*) FROM CDR_DB_Tbl WHERE A_Num = '" + A_Num + "' and B_Num = '" + num + "' and Call_Dir = 'incoming' and Call_Type = 'sms' and Lat = '" + Lat + "' and Lng = '" + Lng + "'";
                    inCmSms = getCount(countQryIncomingSms);*/

                    inCmSms = dt.Select("B_Num = '" + num + "' and Call_Dir = 'incoming' and Call_Type = 'sms'").Count();

                    // counting outgoing SMS of the given number
                    /*string countQryOutgoingSms = "SELECT COUNT(*) FROM CDR_DB_Tbl WHERE A_Num = '" + A_Num + "' and B_Num = '" + num + "' and Call_Dir = 'outgoing' and Call_Type = 'sms' and Lat = '" + Lat + "' and Lng = '" + Lng + "'";
                    outGngSms = getCount(countQryOutgoingSms);*/

                    outGngSms = dt.Select("B_Num = '" + num + "' and Call_Dir = 'outgoing' and Call_Type = 'sms'").Count();

                    CDRSummary cs = new CDRSummary("", "", num, inCmCalls, inCmSms, outGngCalls, outGngSms,
                    inCmCalls + inCmSms + outGngCalls + outGngSms, "");

                    cdrsum.Add(cs);
                    getBasicConversations.Add(new GetBasicConversation(num, inCmCalls + inCmSms + outGngCalls + outGngSms));

                }

                /*Aranging the list in decending order on the basis of total in our calls and sms*/
                csByTotalInOut = cdrsum.OrderByDescending(cs => cs.Total).ToList();
            }
            return csByTotalInOut;
        }

        public static void messageDialog(string msg)
        {
            new Forms.MsgBox(msg).ShowDialog();
        }

        public static void exportPDF(DataGridView dataGridView, string fileName)
        {
            if (dataGridView.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                /*sfd.FileName = "Loc_Summary.pdf";*/
                sfd.FileName = fileName;
                bool fileError = false;
                /*CDRSummaryGridView.DefaultCellStyle.Font = new System.Drawing.Font(BaseFont.TIMES_ROMAN, 8);*/
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;

                            CommonMethods.messageDialog("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dataGridView.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            //Table Header
                            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                            Font fntHeader = new Font(btnColumnHeader, 10);

                            //A_Num info
                            Paragraph prgA_Num = new Paragraph();
                            BaseFont btnA_Num = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                            Font fntA_Num = new Font(btnColumnHeader, 8);
                            prgA_Num.Alignment = Element.ALIGN_LEFT;
                            prgA_Num.Add(new Chunk("\nRecord From : ", fntA_Num));
                            prgA_Num.Add(new Chunk("\nTo : ", fntA_Num));
                            prgA_Num.Add(new Chunk("\nA-Party : 923335773646", fntA_Num));
                            prgA_Num.Add(new Chunk("\nSubscriber's Name : Aheen Akhtar", fntA_Num));
                            prgA_Num.Add(new Chunk("\nSubscriber's CNIC : 6110117910848", fntA_Num));
                            prgA_Num.Add(new Chunk("\nSubscriber's Address : House No NE - 2669 Street No 21", fntA_Num));



                            foreach (DataGridViewColumn column in dataGridView.Columns)
                            {

                                PdfPCell cell = new PdfPCell();
                                cell.AddElement(new Chunk(column.HeaderText.ToUpper(), fntHeader));
                                //PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));

                                pdfTable.AddCell(cell);
                            }

                            //Table Data

                            foreach (DataGridViewRow row in dataGridView.Rows)
                            {

                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if(cell.Value !=null)
                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);

                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();



                                //Report Header
                                BaseFont bfnHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                                Font fntHead = new Font(bfnHead, 16);
                                Paragraph prgHeading = new Paragraph();
                                prgHeading.Alignment = Element.ALIGN_CENTER;
                                prgHeading.Add(new Chunk(fileName + " " + Common.a_numForAnalysis, fntHead));



                                pdfDoc.Add(prgHeading);

                                //Add a line separation
                                Paragraph ps = new Paragraph(new Chunk(new LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, -4)));
                                pdfDoc.Add(ps);

                                //A_Num
                                pdfDoc.Add(prgA_Num);


                                //Add a line separation
                                Paragraph p = new Paragraph(new Chunk(new LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, -4)));
                                pdfDoc.Add(p);

                                //Add line break
                                pdfDoc.Add(new Chunk("\n\n", fntHead));

                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }


                            CommonMethods.messageDialog("Data Exported Successfully !!");
                        }
                        catch (Exception ex)
                        {

                            CommonMethods.messageDialog("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {

                CommonMethods.messageDialog("No Record To Export !!");
            }
        }

        public static void exportImagePDF(DataGridView dataGridView, string fileName, Image img)
        {
            if (dataGridView.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                /*sfd.FileName = "Loc_Summary.pdf";*/
                sfd.FileName = fileName;
                bool fileError = false;
                /*CDRSummaryGridView.DefaultCellStyle.Font = new System.Drawing.Font(BaseFont.TIMES_ROMAN, 8);*/
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;

                            CommonMethods.messageDialog("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dataGridView.Columns.Count-1);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            //Table Header
                            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                            Font fntHeader = new Font(btnColumnHeader, 10);

                            //A_Num info
                            Paragraph prgA_Num = new Paragraph();
                            BaseFont btnA_Num = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                            Font fntA_Num = new Font(btnColumnHeader, 8);
                            
                            prgA_Num.Alignment = Element.ALIGN_LEFT;
                            prgA_Num.Add(img);

                            dataGridView.Columns.RemoveAt(dataGridView.Columns.Count - 1);
                            foreach (DataGridViewColumn column in dataGridView.Columns)
                            {

                                PdfPCell cell = new PdfPCell();
                                cell.AddElement(new Chunk(column.HeaderText.ToUpper(), fntHeader));
                                //PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));

                                pdfTable.AddCell(cell);
                            }

                            //Table Data

                            foreach (DataGridViewRow row in dataGridView.Rows)
                            {

                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.Value != null)
                                        pdfTable.AddCell(cell.Value.ToString());
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);

                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();



                                //Report Header
                                BaseFont bfnHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                                Font fntHead = new Font(bfnHead, 16);
                                Paragraph prgHeading = new Paragraph();
                                prgHeading.Alignment = Element.ALIGN_CENTER;
                                prgHeading.Add(new Chunk(fileName + " " + Common.a_numForAnalysis, fntHead));



                                pdfDoc.Add(prgHeading);

                                //Add a line separation
                                Paragraph ps = new Paragraph(new Chunk(new LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, -4)));
                                pdfDoc.Add(ps);

                                //A_Num
                                pdfDoc.Add(prgA_Num);


                                //Add a line separation
                                Paragraph p = new Paragraph(new Chunk(new LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, -4)));
                                pdfDoc.Add(p);

                                //Add line break
                                pdfDoc.Add(new Chunk("\n\n", fntHead));

                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }


                            CommonMethods.messageDialog("Data Exported Successfully !!");
                        }
                        catch (Exception ex)
                        {

                            CommonMethods.messageDialog("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {

                CommonMethods.messageDialog("No Record To Export !!");
            }
        }

        public static void exportPDFBTS(DataGridView dataGridView, string fileName)
        {
            if (dataGridView.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                /*sfd.FileName = "Loc_Summary.pdf";*/
                sfd.FileName = fileName;
                bool fileError = false;
                /*CDRSummaryGridView.DefaultCellStyle.Font = new System.Drawing.Font(BaseFont.TIMES_ROMAN, 8);*/
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;

                            CommonMethods.messageDialog("It wasn't possible to write the data to the disk." + ex.Message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfTable = new PdfPTable(dataGridView.Columns.Count);
                            pdfTable.DefaultCell.Padding = 3;
                            pdfTable.WidthPercentage = 100;
                            pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            //Table Header
                            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                            Font fntHeader = new Font(btnColumnHeader, 10);

                            //A_Num info
                            Paragraph prgA_Num = new Paragraph();
                            BaseFont btnA_Num = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                            Font fntA_Num = new Font(btnColumnHeader, 8);
                            prgA_Num.Alignment = Element.ALIGN_LEFT;
                            prgA_Num.Add(new Chunk("\nRecord From : ", fntA_Num));
                            prgA_Num.Add(new Chunk("\nTo : ", fntA_Num));
                            prgA_Num.Add(new Chunk("\nA-Party : 923335773646", fntA_Num));
                            prgA_Num.Add(new Chunk("\nSubscriber's Name : Aheen Akhtar", fntA_Num));
                            prgA_Num.Add(new Chunk("\nSubscriber's CNIC : 6110117910848", fntA_Num));
                            prgA_Num.Add(new Chunk("\nSubscriber's Address : House No NE - 2669 Street No 21", fntA_Num));



                            foreach (DataGridViewColumn column in dataGridView.Columns)
                            {

                                PdfPCell cell = new PdfPCell();
                                cell.AddElement(new Chunk(column.HeaderText.ToUpper(), fntHeader));
                                //PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));

                                pdfTable.AddCell(cell);
                            }

                            //Table Data

                            foreach (DataGridViewRow row in dataGridView.Rows)
                            {

                                foreach (DataGridViewCell cell in row.Cells)
                                {

                                    pdfTable.AddCell(cell.Value.ToString());
                                }
                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);

                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();



                                //Report Header
                                BaseFont bfnHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                                Font fntHead = new Font(bfnHead, 16);
                                Paragraph prgHeading = new Paragraph();
                                prgHeading.Alignment = Element.ALIGN_CENTER;
                                prgHeading.Add(new Chunk(fileName + " " + Common.a_numForAnalysis, fntHead));



                                pdfDoc.Add(prgHeading);

                                //Add a line separation
                                Paragraph ps = new Paragraph(new Chunk(new LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, -4)));
                                pdfDoc.Add(ps);

                                //A_Num
                                pdfDoc.Add(prgA_Num);


                                //Add a line separation
                                Paragraph p = new Paragraph(new Chunk(new LineSeparator(0.0F, 100.0F, BaseColor.BLACK, Element.ALIGN_LEFT, -4)));
                                pdfDoc.Add(p);

                                //Add line break
                                pdfDoc.Add(new Chunk("\n\n", fntHead));

                                pdfDoc.Add(pdfTable);
                                pdfDoc.Close();
                                stream.Close();
                            }


                            CommonMethods.messageDialog("Data Exported Successfully !!");
                        }
                        catch (Exception ex)
                        {

                            CommonMethods.messageDialog("Error :" + ex.Message);
                        }
                    }
                }
            }
            else
            {

                CommonMethods.messageDialog("No Record To Export !!");
            }
        }

        public static void exportExcel(DataGridView dataGridView)
        {
            try
            {
                if (dataGridView.Rows.Count > 0)
                {
                    Microsoft.Office.Interop.Excel.Application xcelApp = new Microsoft.Office.Interop.Excel.Application();
                    xcelApp.Application.Workbooks.Add(Type.Missing);
                    for (int i = 1; i < dataGridView.Columns.Count + 1; i++)
                    {
                        xcelApp.Cells[1, i] = dataGridView.Columns[i - 1].HeaderText;

                    }

                    for (int i = 0; i < dataGridView.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView.Columns.Count; j++)
                        {
                            if (dataGridView.Rows[i].Cells[j].Value != null)
                                xcelApp.Cells[i + 2, j + 1] = dataGridView.Rows[i].Cells[j].Value.ToString();
                            else
                                xcelApp.Cells[i + 2, j + 1] = "";
                        }
                    }

                    xcelApp.Columns.AutoFit();
                    xcelApp.Visible = true;
                }
            }
            catch (Exception ex)
            {

                CommonMethods.messageDialog(ex.Message);
            }
        }

        public static DataTable browseFile()
        {
            DataTable dt = null;
            DataTableCollection tableCollection = null;
            try
            {

                using (FileDialog openFileDialog = new OpenFileDialog() { Filter = "All Worksheets|*.xls;*.xlsx;*.csv;|Ms 97-2003|*.xls;|Ms Office 2007|*.xlsx;|CSV file|*.csv;|All Files|*.*" })
                {
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        //txtFileName.Text = openFileDialog.FileName;
                        string extension = Path.GetExtension(openFileDialog.FileName);
                        if (extension == ".csv")
                        {

                            using (var csvReader = new CsvReader(new StreamReader(System.IO.File.OpenRead(openFileDialog.FileName)), true))
                            {
                                dt = new DataTable();
                                dt.Load(csvReader);
                                //                                standCDRs();
                            }
                        }
                        else
                        {
                            try
                            {
                                using (var stream = File.Open(openFileDialog.FileName, FileMode.Open, FileAccess.Read))
                                {
                                    using (IExcelDataReader reader = ExcelReaderFactory.CreateReader(stream))
                                    {
                                        DataSet result = reader.AsDataSet(new ExcelDataSetConfiguration()
                                        {
                                            ConfigureDataTable = (_) => new ExcelDataTableConfiguration() { UseHeaderRow = true }
                                        });

                                        tableCollection = result.Tables;

                                        /*Getting first sheet from the excel file no need to select
                                         sheet from the combobox*/
                                        dt = tableCollection[0];
                                        //standCDRs();
                                        /*cboSheet.Items.Clear();
                                        foreach (DataTable table in tableCollection)
                                            cboSheet.Items.Add(table.TableName);*/ //add sheet to combobox
                                    }
                                }

                            }
                            catch (IOException excep)
                            {

                                CommonMethods.messageDialog(excep.Message);
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }
            return dt;
        }

        public static DataTable uniqueDataTable(DataTable dt, string colName/*this column makes the datatable unique*/)
        {
            /*
             * This code make the datatable unique *
             */
            DataTable uniqueDT = dt.AsEnumerable()
             .GroupBy(x => x.Field<string>(colName))
             .Select(x => x.First()).CopyToDataTable();

            return uniqueDT;
        }


        // converting hex messages to text send by different brand and companies
        public static string ConvertHex(string hexString)
        {
            try
            {
                string ascii = string.Empty;
                //System.Text.RegularExpressions.Regex.IsMatch(item.Key, @"\A\b[0-9a-fA-F]+\b\Z")
                if (!System.Text.RegularExpressions.Regex.IsMatch(hexString, @"\A\b[0-9]+\b\Z"))
                {
                    if (hexString.Length % 2 != 0)
                    {
                        hexString = hexString.Remove(hexString.Length - 1, 1);
                        for (int i = 0; i < hexString.Length; i += 2)
                        {
                            string hs = string.Empty;

                            hs = hexString.Substring(i, 2);
                            ulong decval = Convert.ToUInt64(hs, 16);
                            long deccc = Convert.ToInt64(hs, 16);
                            char character = Convert.ToChar(deccc);
                            ascii += character;

                        }
                    }
                    else
                    {
                        for (int i = 0; i < hexString.Length; i += 2)
                        {
                            string hs = string.Empty;

                            hs = hexString.Substring(i, 2);
                            ulong decval = Convert.ToUInt64(hs, 16);
                            long deccc = Convert.ToInt64(hs, 16);
                            char character = Convert.ToChar(deccc);
                            ascii += character;

                        }
                    }
                }
                return ascii + " " + hexString;
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            return string.Empty;
        }


        public static void exportAllImagePDF(DataTable dataGridView, string fileName, Image img)
        {
            if (dataGridView.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "PDF (*.pdf)|*.pdf";
                //sfd.FileName = "Loc_Summary.pdf";
                sfd.FileName = fileName;
                bool fileError = false;
                //CDRSummaryGridView.DefaultCellStyle.Font = new System.Drawing.Font(BaseFont.TIMES_ROMAN, 8);
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(sfd.FileName))
                    {
                        try
                        {
                            File.Delete(sfd.FileName);
                        }
                        catch (IOException ex)
                        {
                            fileError = true;

                            string message = "It wasn't possible to write the data to the disk." + ex.Message;
                            MessageBox.Show(message);
                        }
                    }
                    if (!fileError)
                    {
                        try
                        {
                            PdfPTable pdfDlmsTable = new PdfPTable(dataGridView.Columns.Count);
                            PdfPTable pdf2020Table = new PdfPTable(dataGridView.Columns.Count);
                            PdfPTable pdf2021Table = new PdfPTable(dataGridView.Columns.Count);
                            PdfPTable pdfPtclTable = new PdfPTable(dataGridView.Columns.Count);

                            pdfDlmsTable.DefaultCell.Padding = 3;
                            pdfDlmsTable.WidthPercentage = 100;
                            pdfDlmsTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            pdf2020Table.DefaultCell.Padding = 3;
                            pdf2020Table.WidthPercentage = 100;
                            pdf2020Table.HorizontalAlignment = Element.ALIGN_LEFT;

                            pdf2021Table.DefaultCell.Padding = 3;
                            pdf2021Table.WidthPercentage = 100;
                            pdf2021Table.HorizontalAlignment = Element.ALIGN_LEFT;

                            pdfPtclTable.DefaultCell.Padding = 3;
                            pdfPtclTable.WidthPercentage = 100;
                            pdfPtclTable.HorizontalAlignment = Element.ALIGN_LEFT;

                            //Table Header
                            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                            Font fntHeader = new Font(btnColumnHeader, 10);

                            //A_Num info
                            string subInfo2020 = dataGridView.Select("DB = '2020'").Count().ToString();
                            string subInfo2021 = dataGridView.Select("DB = '2021'").Count().ToString();
                            string subPTCL = dataGridView.Select("DB = 'PTCL'").Count().ToString();
                            string subDLMS = dataGridView.Select("DB = 'DLMS'").Count().ToString();

                            Paragraph prgA_Num = new Paragraph();
                            BaseFont btnA_Num = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                            Font verdana = FontFactory.GetFont("Verdana", 10, Font.BOLDITALIC, BaseColor.BLUE);
                            Font titlefont = FontFactory.GetFont("Segoe UI", 14, Font.BOLDITALIC, BaseColor.RED);
                            //Font fntA_Num = FontFactory.GetFont("Segoe UI", 8, Font.BOLDITALIC, BaseColor.BLACK); //new Font(btnColumnHeader, 8);


                            PdfPTable countTable = new PdfPTable(4);
                            countTable.DefaultCell.Padding = 3;
                            countTable.WidthPercentage = 100;
                            countTable.HorizontalAlignment = Element.ALIGN_CENTER;
                            countTable.DefaultCell.Border = Rectangle.NO_BORDER;

                            prgA_Num.Add(new Chunk("\nTotal Records : " + (int.Parse(subInfo2020) + int.Parse(subInfo2021) + int.Parse(subPTCL) + int.Parse(subDLMS)).ToString(), verdana));
                            prgA_Num.Add(new Chunk("\n\nDLMS : " + subDLMS, verdana));
                            prgA_Num.Add(new Chunk("\n\nSubscriber Info : " + (int.Parse(subInfo2020) + int.Parse(subInfo2021) + int.Parse(subPTCL)).ToString(), verdana));
                            prgA_Num.Add(new Chunk("\n\nSub Info 2020 : " + subInfo2020, verdana));
                            prgA_Num.Add(new Chunk("\n\nSub Info 2021 : " + subInfo2021, verdana));
                            prgA_Num.Add(new Chunk("\n\nPTCL : " + subPTCL, verdana));

                            //prgA_Num.Add(img);

                            //prgA_Num.Alignment = Element.ALIGN_LEFT
                            countTable.AddCell(prgA_Num);

                            countTable.AddCell("");
                            countTable.AddCell("");

                            countTable.AddCell(img);

                            //prgA_Num.Add(img);

                            //dataGridView.Columns.RemoveAt(dataGridView.Columns.Count - 1);
                            foreach (DataColumn column in dataGridView.Columns)
                            {

                                PdfPCell cell = new PdfPCell();
                                cell.AddElement(new Chunk(column.ColumnName.ToUpper(), fntHeader));
                                //PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText));
                                pdfDlmsTable.AddCell(cell);
                                pdf2020Table.AddCell(cell);
                                pdf2021Table.AddCell(cell);
                                pdfPtclTable.AddCell(cell);
                            }

                            //Table Data

                            foreach (DataRow row in dataGridView.Select("DB = 'DLMS'"))
                            {
                                foreach (DataColumn column in dataGridView.Columns)
                                {

                                    if (row[column].ToString() != null)
                                    {
                                        if (string.Equals(column.ColumnName, dataGridView.Columns[dataGridView.Columns.Count - 1].ColumnName) && row[column] != DBNull.Value && !row.Equals(dataGridView.Rows[dataGridView.Rows.Count - 1]))
                                        {
                                            string hexString = BitConverter.ToString((byte[])row[column]).Replace("-", string.Empty).ToLower();
                                            //Console.WriteLine(hexString);

                                            pdfDlmsTable.AddCell(ConvertToImage((byte[])row[column]));
                                        }
                                        else
                                            pdfDlmsTable.AddCell(row[column].ToString());
                                    }
                                }

                            }

                            foreach (DataRow row in dataGridView.Select("DB = '2020'"))
                            {
                                foreach (DataColumn column in dataGridView.Columns)
                                {

                                    if (row[column].ToString() != null)
                                    {
                                        if (string.Equals(column.ColumnName, dataGridView.Columns[dataGridView.Columns.Count - 1].ColumnName) && row[column] != DBNull.Value && !row.Equals(dataGridView.Rows[dataGridView.Rows.Count - 1]))
                                        {
                                            string hexString = BitConverter.ToString((byte[])row[column]).Replace("-", string.Empty).ToLower();
                                            //Console.WriteLine(hexString);

                                            pdf2020Table.AddCell(ConvertToImage((byte[])row[column]));
                                        }
                                        else
                                            pdf2020Table.AddCell(row[column].ToString());
                                    }
                                }

                            }

                            foreach (DataRow row in dataGridView.Select("DB = '2021'"))
                            {
                                foreach (DataColumn column in dataGridView.Columns)
                                {

                                    if (row[column].ToString() != null)
                                    {
                                        if (string.Equals(column.ColumnName, dataGridView.Columns[dataGridView.Columns.Count - 1].ColumnName) && row[column] != DBNull.Value && !row.Equals(dataGridView.Rows[dataGridView.Rows.Count - 1]))
                                        {
                                            string hexString = BitConverter.ToString((byte[])row[column]).Replace("-", string.Empty).ToLower();
                                            //Console.WriteLine(hexString);

                                            pdf2021Table.AddCell(ConvertToImage((byte[])row[column]));
                                        }
                                        else
                                            pdf2021Table.AddCell(row[column].ToString());
                                    }
                                }

                            }

                            foreach (DataRow row in dataGridView.Select("DB = 'PTCL'"))
                            {
                                foreach (DataColumn column in dataGridView.Columns)
                                {

                                    if (row[column].ToString() != null)
                                    {
                                        if (string.Equals(column.ColumnName, dataGridView.Columns[dataGridView.Columns.Count - 1].ColumnName) && row[column] != DBNull.Value && !row.Equals(dataGridView.Rows[dataGridView.Rows.Count - 1]))
                                        {
                                            string hexString = BitConverter.ToString((byte[])row[column]).Replace("-", string.Empty).ToLower();
                                            //Console.WriteLine(hexString);

                                            pdfPtclTable.AddCell(ConvertToImage((byte[])row[column]));
                                        }
                                        else
                                            pdfPtclTable.AddCell(row[column].ToString());
                                    }
                                }

                            }

                            using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                            {
                                Document pdfDoc = new Document(PageSize.A4, 10f, 20f, 20f, 10f);

                                PdfWriter.GetInstance(pdfDoc, stream);
                                pdfDoc.Open();

                                //Report Header
                                BaseFont bfnHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                                Font fntHead = new Font(bfnHead, 16);
                                Paragraph prgHeading = new Paragraph();
                                prgHeading.Alignment = Element.ALIGN_CENTER;
                                prgHeading.Add(new Chunk(fileName, fntHead));



                                pdfDoc.Add(prgHeading);

                                //Add a line separation
                                Paragraph ps = new Paragraph(new Chunk(new LineSeparator(0.0F, 100.0F, BaseColor.BLUE, Element.ALIGN_LEFT, -4)));
                                pdfDoc.Add(ps);

                                pdfDoc.Add(new Chunk("\n", fntHead));

                                //A_Num
                                pdfDoc.Add(countTable);

                                //Add a line separation

                                Paragraph lsdlms = new Paragraph(new Chunk(new LineSeparator(0.0F, 100.0F, BaseColor.BLUE, Element.ALIGN_LEFT, -4)));
                                pdfDoc.Add(lsdlms);

                                Paragraph prgDLMS = new Paragraph();
                                prgDLMS.Alignment = Element.ALIGN_CENTER;
                                prgDLMS.Add(new Chunk("\nDLMS DATABASE", titlefont));

                                pdfDoc.Add(prgDLMS);

                                Paragraph lsdlms1 = new Paragraph(new Chunk(new LineSeparator(0.0F, 100.0F, BaseColor.BLUE, Element.ALIGN_LEFT, -4)));
                                pdfDoc.Add(lsdlms1);

                                //Add line break
                                pdfDoc.Add(new Chunk("\n\n", fntHead));

                                pdfDoc.Add(pdfDlmsTable);


                                //Add a line separation
                                Paragraph ls2020 = new Paragraph(new Chunk(new LineSeparator(0.0F, 100.0F, BaseColor.BLUE, Element.ALIGN_LEFT, -4)));
                                pdfDoc.Add(ls2020);

                                Paragraph prg2020 = new Paragraph();
                                prg2020.Alignment = Element.ALIGN_CENTER;
                                prg2020.Add(new Chunk("\n2020 DATABASE", titlefont));

                                pdfDoc.Add(prg2020);

                                Paragraph ls2020_1 = new Paragraph(new Chunk(new LineSeparator(0.0F, 100.0F, BaseColor.BLUE, Element.ALIGN_LEFT, -4)));
                                pdfDoc.Add(ls2020_1);

                                //Add line break
                                pdfDoc.Add(new Chunk("\n\n", fntHead));

                                pdfDoc.Add(pdf2020Table);

                                Paragraph ls2021 = new Paragraph(new Chunk(new LineSeparator(0.0F, 100.0F, BaseColor.BLUE, Element.ALIGN_LEFT, -4)));
                                pdfDoc.Add(ls2021);

                                Paragraph prg2021 = new Paragraph();
                                prg2021.Alignment = Element.ALIGN_CENTER;
                                prg2021.Add(new Chunk("\n2021 DATABASE", titlefont));

                                pdfDoc.Add(prg2021);

                                Paragraph ls2021_1 = new Paragraph(new Chunk(new LineSeparator(0.0F, 100.0F, BaseColor.BLUE, Element.ALIGN_LEFT, -4)));
                                pdfDoc.Add(ls2021_1);

                                //Add line break
                                pdfDoc.Add(new Chunk("\n\n", fntHead));

                                pdfDoc.Add(pdf2021Table);




                                Paragraph lsptcl = new Paragraph(new Chunk(new LineSeparator(0.0F, 100.0F, BaseColor.BLUE, Element.ALIGN_LEFT, -4)));
                                pdfDoc.Add(lsptcl);


                                Paragraph prgPtcl = new Paragraph();
                                prgPtcl.Alignment = Element.ALIGN_CENTER;
                                prgPtcl.Add(new Chunk("\nPTCL DATABASE", titlefont));

                                pdfDoc.Add(prgPtcl);

                                Paragraph lsptcl1 = new Paragraph(new Chunk(new LineSeparator(0.0F, 100.0F, BaseColor.BLUE, Element.ALIGN_LEFT, -4)));
                                pdfDoc.Add(lsptcl1);

                                //Add line break
                                pdfDoc.Add(new Chunk("\n\n", fntHead));

                                pdfDoc.Add(pdfPtclTable);

                                pdfDoc.Close();
                                stream.Close();
                            }

                            string message = "Data Exported Successfully!!";
                            MessageBox.Show(message);
                        }
                        catch (Exception ex)
                        {
                            string message = "Error :" + ex.Message;
                            MessageBox.Show(message);

                        }
                    }
                }
            }
            else
            {
                string message = "No Record To Export !!";
                MessageBox.Show(message);
            }
        }

        public static Image ConvertToImage(byte[] iBinary)
        {
            return Image.GetInstance(iBinary, false);
        }

        public static List<CDRSummary> getSubDataList(List<CDRSummary> bnumList)
        {
            try
            {
                DataTable allRecordsDt = new DataTable();
                DataTable subTable = new DataTable();
                subTable.Columns.Add("MSISDN", typeof(string));
                foreach (var num in bnumList)
                {
                    if (num.BParty.StartsWith("92"))
                        subTable.Rows.Add(num.BParty);
                }

                using (SqlConnection con = new SqlConnection(AppConnection.GetSubConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("get_subinfo", con))
                    {

                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@MSISDN", subTable);
                        cmd.CommandTimeout = 0;

                        if (con.State != ConnectionState.Open)
                            con.Open();

                        //cmd.ExecuteNonQuery();
                        SqlDataReader sdr = cmd.ExecuteReader();
                        allRecordsDt.Load(sdr);

                    }
                }

                for (int i = 0; i < bnumList.Count(); i++)
                {
                    DataRow firstDataRow = allRecordsDt.Select("MSISDN = '" + bnumList[i].BParty + "'").Count() > 0 ? allRecordsDt.Select("MSISDN = '" + bnumList[i].BParty + "'").First() : null;
                    //Console.WriteLine(bnumList[i].BParty);
                    if (firstDataRow != null)
                    {
                        bnumList[i].Name = firstDataRow["Name"].ToString();
                        bnumList[i].CNIC = firstDataRow["CNIC"].ToString();
                        bnumList[i].Address = firstDataRow["ADDRESS"].ToString();

                        //Console.WriteLine(bnumList[i].BParty, bnumList[i].Name);
                    }

                    
                }



            }
            catch(Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }

            return bnumList;

            /*try
            {
                List<string> uniqueNumList = bnumList.AsEnumerable().Select(x => x.BParty.ToString()).Where(l => l.Length.Equals(12)).Distinct().ToList();
                string numParameters = AddArrayParameters(uniqueNumList.ToArray());
                DataTable allRecordsDt = new DataTable();
                try
                {

                    string getRecordQuery = string.Format("SELECT MSISDN as Mobile, NAME, CNIC, '2022' AS [DB], [ADDRESS] AS [ADDR], NULL AS imgObject FROM [SubInfo2022].[dbo].[Mob1] WHERE MSISDN IN ({0}) " +
                        "UNION ALL " +
                        "SELECT MSISDN as Mobile, Name, CNIC, '2022' AS [DB], [ADDRESS] AS [ADDR], NULL AS imgObject FROM [SubInfo2022].[dbo].[Mob2] WHERE MSISDN IN ({0}) " +
                        "UNION ALL " +
                        "SELECT MSISDN as Mobile, Name, CNIC,'2022' as [DB], [ADDRESS] AS [ADDR], NULL AS imgObject FROM [SubInfo2022].[dbo].[TEL_Data_1] WHERE MSISDN IN ({0}) " +
                        "UNION ALL " +
                        "SELECT MSISDN as Mobile, Name, CNIC, '2022' as [DB], [ADDRESS] AS [ADDR], NULL AS imgObject FROM [SubInfo2022].[dbo].[TEL_Data_2] WHERE MSISDN IN ({0}) " +
                        "UNION ALL " +
                        "SELECT MSISDN as Mobile, Name, CNIC, '2022' as [DB], [ADDRESS] AS [ADDR], NULL AS imgObject FROM [SubInfo2022].[dbo].[TEL_Data_3] WHERE MSISDN IN ({0}) " +
                        "UNION ALL " +
                        "SELECT MSISDN as Mobile, Name, CNIC, '2022' as [DB], [ADDRESS] AS [ADDR], NULL AS imgObject FROM [SubInfo2022].[dbo].[TEL_Data_4] WHERE MSISDN IN ({0}) " +
                        "UNION ALL " +
                        "SELECT MSISDN as Mobile, Name, CNIC, '2022' as [DB], [ADDRESS] AS [ADDR], NULL AS imgObject FROM [SubInfo2022].[dbo].[TEL_Data_5] WHERE MSISDN IN ({0}) " +
                        "UNION ALL " +
                        "SELECT MSISDN as Mobile, Name, CNIC, '2022' as [DB], [ADDRESS] AS [ADDR], NULL AS imgObject FROM [SubInfo2022].[dbo].[Ufo01] WHERE MSISDN IN ({0}) " +
                        "UNION ALL " +
                        "SELECT MSISDN as Mobile, Name, CNIC, '2022' as [DB], [ADDRESS] AS [ADDR], NULL AS imgObject FROM [SubInfo2022].[dbo].[Ufo02] WHERE MSISDN IN ({0}) " +
                        "UNION ALL " +
                        "SELECT MSISDN as Mobile, Name, CNIC, '2022' as [DB], [ADDRESS] AS [ADDR], NULL AS imgObject FROM [SubInfo2022].[dbo].[Ufo03] WHERE MSISDN IN ({0}) " +
                        "UNION ALL " +
                        "SELECT MSISDN as Mobile, Name, CNIC, '2022' as [DB], 'N/A' AS [ADDR], NULL AS imgObject FROM [SubInfo2022].[dbo].[Zon01] WHERE MSISDN IN ({0}) " +
                        "UNION ALL " +
                        "SELECT MSISDN as Mobile, Name, CNIC, '2022' as [DB], 'N/A' AS [ADDR], NULL AS imgObject FROM [SubInfo2022].[dbo].[Zon02] WHERE MSISDN IN ({0}) " +
                        "UNION ALL " +
                        "SELECT Mobile, FirstName as Name, CAST(CNIC AS NVARCHAR) AS CNIC, 'DLMS' as DB, [DLMS_FamzSolutions].[dbo].[License_Person_Address].[Block] AS ADDR, [DLMS_FamzSolutions].[dbo].[License_Person_Images].[imgObject] AS imgObject FROM [DLMS_FamzSolutions].[dbo].[License_Person] INNER JOIN [DLMS_FamzSolutions].[dbo].[License_Person_Address] ON [DLMS_FamzSolutions].[dbo].[License_Person_Address].[PersonID] = [DLMS_FamzSolutions].[dbo].[License_Person].[PersonID] INNER JOIN [DLMS_FamzSolutions].[dbo].[License_Person_Images] ON [DLMS_FamzSolutions].[dbo].[License_Person_Images].[PersonID] = [DLMS_FamzSolutions].[dbo].[License_Person].[PersonID] WHERE Mobile IN({0})" +
                        "UNION ALL " +
                        "SELECT MSISDN as Mobile, Name, CNIC, '2021' as DB, ADDRESS AS ADDR, NULL AS imgObject from Masterdb2021 where MSISDN IN ({0}) " +
                        "UNION ALL " +
                        "SELECT MSISDN as Mobile, SubscriberName as Name, CNIC, '2020' as DB, 'N/A' AS ADDR, NULL AS imgObject from Masterdb where MSISDN IN ({0})" +
                        "UNION ALL " +
                        "SELECT MOBILE_NO as Mobile, CUSTOMER_NAME as Name, CNIC_NTN as CNIC, 'PTCL' AS DB, ADDRESS1 AS ADDR, NULL AS imgObject FROM [PTCL2021].[dbo].[Central_Zone_Part_1] WHERE MOBILE_NO IN ({0})" +
                        "UNION ALL " +
                        "SELECT MOBILE_NO as Mobile, CUSTOMER_NAME as Name, CNIC_NTN as CNIC, 'PTCL' AS DB, ADDRESS1 AS ADDR, NULL AS imgObject FROM [PTCL2021].[dbo].[Central_Zone_Part_2] WHERE MOBILE_NO IN ({0})" +
                        "UNION ALL " +
                        "SELECT MOBILE_NO as Mobile, CUSTOMER_NAME as Name, CNIC_NTN as CNIC, 'PTCL' AS DB, ADDRESS1 AS ADDR, NULL AS imgObject FROM [PTCL2021].[dbo].[North_Zone_Overall] WHERE MOBILE_NO IN ({0})" +
                        "UNION ALL " +
                        "SELECT MOBILE_NO as Mobile, CUSTOMER_NAME as Name, CNIC_NTN as CNIC, 'PTCL' AS DB, ADDRESS1 AS ADDR, NULL AS imgObject FROM [PTCL2021].[dbo].[South_Zone_Overall] WHERE MOBILE_NO IN ({0})", numParameters);

                    using (SqlConnection con = new SqlConnection(AppConnection.GetSubConnectionString()))
                    {
                        using (SqlCommand cmd = new SqlCommand(getRecordQuery, con))
                        {
                            cmd.CommandType = CommandType.Text;

                            if (con.State != ConnectionState.Open)
                                con.Open();

                            SqlDataReader sdr = cmd.ExecuteReader();

                            allRecordsDt.Load(sdr);

                            //gvLocationDetails.DataSource = allRecordsDt;

                            for (int i = 0; i < bnumList.Count(); i++)
                            {
                                DataRow firstDataRow = allRecordsDt.Select("Mobile = '" + bnumList[i].BParty + "'").Count() > 0 ? allRecordsDt.Select("Mobile = '" + bnumList[i].BParty + "'").First() : null;
                                Console.WriteLine(bnumList[i].BParty);
                                if (firstDataRow != null)
                                {
                                    bnumList[i].Name = firstDataRow["Name"].ToString();
                                    bnumList[i].CNIC = firstDataRow["CNIC"].ToString();
                                    bnumList[i].Address = firstDataRow["ADDR"].ToString();
                                }
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                   
                    MessageBox.Show(ex.Message);
                }

                //gvLocationDetails.DataSource = bnumList;
            }
            catch (Exception ex)
            {
                CommonMethods.messageDialog(ex.Message);
            }

            return bnumList;*/
        }

        public static string AddArrayParameters(string[] array)
        {
            /* An array cannot be simply added as a parameter to a SqlCommand so we need to loop through things and add it manually. 
             * Each item in the array will end up being it's own SqlParameter so the return value for this must be used as part of the
             * IN statement in the CommandText.
             */
            var parameters = new string[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                parameters[i] = string.Format("'{0}'", array[i]);
            }

            return string.Join(", ", parameters);
        }


    }
}
