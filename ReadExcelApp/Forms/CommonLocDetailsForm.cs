using GMap.NET;
using ReadExcelApp.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ReadExcelApp.Forms
{
    public partial class CommonLocDetailsForm : Form
    {
        public CommonLocDetailsForm(DataTable specificLatLngRecord, List<AllRecordA_Num> mr)
        {
            InitializeComponent();
            gvCommonSpecificLatLngDetail.DataSource = specificLatLngRecord;
            gvCommonSpecificLatLngDetail.DataSource = specificLatLngRecord;
            gvLocation.DataSource = mr;
        }
    }
}
