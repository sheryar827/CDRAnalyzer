using GMap.NET;
using ReadExcelApp.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadExcelApp.Forms
{
    public partial class CommonLocDetailsForm : Form
    {
        public CommonLocDetailsForm(DataTable specificLatLngRecord)
        {
            InitializeComponent();
            gvCommonSpecificLatLngDetail.DataSource = specificLatLngRecord;
        }
    }
}
