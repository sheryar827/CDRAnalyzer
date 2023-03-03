using System.Data.SqlClient;

namespace ReadExcelApp
{
    class GetSqlDRAndConn
    {
        public SqlConnection sqlConn { get; set; }
        public SqlDataReader sqlDR { get; set; }

        public GetSqlDRAndConn(SqlConnection sqlConn, SqlDataReader sqlDR)
        {
            this.sqlConn = sqlConn;
            this.sqlDR = sqlDR;
        }
    }
}
