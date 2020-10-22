using System;
using System.Data.SqlClient;
using System.Data;

namespace WebOrderManagement
{
    public partial class Form_Management : System.Web.UI.Page
    {
        static public int modOrder_id;          //更新対象ID保持用
        static public string customer;          //検索用（顧客）
        static public string merchandise;       //検索用（商品）
        static public string deadline;          //検索用（納期）
        static public string status;            //検索用（ステータス）

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //初めて表示する場合、検索用の値を使ってSELECT問い合わせを行う
                string cnStr = System.Configuration.ConfigurationManager.ConnectionStrings["OM_DATA"].ConnectionString;
                string sqlStr = "SELECT * FROM View_OM WHERE 1=1";

                if (!String.IsNullOrEmpty(customer)) sqlStr += " AND customer=N'" + customer + "'";
                if (!String.IsNullOrEmpty(merchandise)) sqlStr += " AND merchandise=N'" + merchandise + "'";
                if (!String.IsNullOrEmpty(deadline)) sqlStr += " AND deadline='" + deadline + "'";
                if (!String.IsNullOrEmpty(status)) sqlStr += " AND status=N'" + status + "'";

                var adapter = new SqlDataAdapter(sqlStr, cnStr);
                var ds = new DataSet();
                adapter.Fill(ds);
                GridView_OM.DataSource = ds;
                GridView_OM.DataBind();
            }

            ButtonDelete.Attributes["OnClick"] = "return deleteCheckDialog('ButtonDelete','本当に削除していいですか？');";
        }

        protected void ButtonMod_Click(object sender, EventArgs e)
        {
            if (GridView_OM.Rows.Count < 1)
            {
                //データがない場合、アラート表示
                ClientScript.RegisterStartupScript( this.GetType(), "check", 
                    "<script/>alert('データがありません');</script>");
                return;
            }

            if (GridView_OM.SelectedIndex < 0)
            {
                //修正対象行が選択されてない場合、アラート表示
                ClientScript.RegisterStartupScript(this.GetType(), "check",
                    "<script/>alert('修正する行を選択して下さい');</script>");
                return;
            }

            //選択行を保持
            modOrder_id = int.Parse(GridView_OM.SelectedRow.Cells[1].Text);
            Response.Redirect("Form_Mod.aspx");
        }

        protected void Button_All_Click(object sender, EventArgs e)
        {
            //全件表示を行う
            merchandise = "";
            customer = "";
            deadline = "";
            status = "";

            string cnStr = System.Configuration.ConfigurationManager.ConnectionStrings["OM_DATA"].ConnectionString;
            var adapter = new SqlDataAdapter("SELECT * FROM View_OM", cnStr);
            var ds = new DataSet();
            adapter.Fill(ds);
            GridView_OM.DataSource = ds;
            GridView_OM.DataBind();
        }

        protected void ButtonSerch_Click(object sender, EventArgs e)
        {
            merchandise = "";
            customer = "";
            deadline = "";
            status = "";

            Response.Redirect("Form_Serch.aspx");
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            merchandise = "";
            customer = "";
            deadline = "";
            status = "";

            Response.Redirect("Form_Add.aspx");
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (GridView_OM.SelectedIndex < 0)
            {
                //削除対象行が選択されてない場合、アラート表示
                ClientScript.RegisterStartupScript(this.GetType(), "check",
                    "<script/>alert('削除する行を選択して下さい');</script>");
                return;
            }

            string cnStr = System.Configuration.ConfigurationManager.ConnectionStrings["OM_DATA"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(cnStr))
            {
                try
                {
                    cn.Open();
                    using (var tran = cn.BeginTransaction())
                    using (var cmd = new SqlCommand() { Connection = cn, Transaction = tran })
                    {
                        try
                        {
                            //選択された注文番号のレコードを削除
                            cmd.CommandText = "DELETE FROM Table_Order WHERE order_code=" + int.Parse(GridView_OM.SelectedRow.Cells[1].Text);
                            cmd.ExecuteNonQuery();

                            //コミット
                            tran.Commit();
                        }
                        catch
                        {
                            //ロールバック
                            tran.Rollback();
                            throw;
                        }
                    }
                }
                catch (Exception ex)
                {
                    //削除できなかった場合
                    ClientScript.RegisterStartupScript(this.GetType(), "check",
                        "<script/>alert('削除エラー：" + ex.Message + "');</script>");
                    throw;
                }
                finally
                {
                    cn.Close();
                }
            }

            var adapter = new SqlDataAdapter("SELECT * FROM View_OM", cnStr);
            var ds = new DataSet();
            adapter.Fill(ds);
            GridView_OM.DataSource = ds;
            GridView_OM.DataBind();
        }
    }
}