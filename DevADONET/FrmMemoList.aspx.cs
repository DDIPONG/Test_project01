using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DevADONET
{
    public partial class FrmMemoList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //[1]커넥션
            SqlConnection con = new SqlConnection();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            con.Open();
            //[2]커맨드
            SqlCommand cmd = new SqlCommand("ListMemo", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            //[3] Data Adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            //[4] Dataset
            DataSet ds = new DataSet();
            da.Fill(ds, "Memos");
            //[5] Output
            ctlMemoList.DataSource = ds;
            ctlMemoList.DataBind();
            //[6]
            con.Close();


        }
    }
}