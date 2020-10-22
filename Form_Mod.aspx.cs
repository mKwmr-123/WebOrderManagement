using System;
using System.Globalization;
using System.Linq;

namespace WebOrderManagement
{
    public partial class Form_Mod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                //ポストバックの場合は、何もしない
                return;
            }

            //選択行のデータを表示する
            using(var dt = new DataClasses_OMDataContext())
            {
                foreach (var cell in dt.Order_cls.Where(c => c.order_code == Form_Management.modOrder_id))
                {
                    Label_order.Text = cell.order_code.ToString();
                    Label_merchandise.Text = cell.Merchandise_cls.merchandise.ToString();
                    TextBox_quantity.Text = cell.quantity.ToString();
                    Label_Customer.Text = cell.Customer_cls.customer.ToString();
                    TextBox_deadline.Text = cell.deadline.ToString("yyyy/MM/dd");
                    TextBox_status.Text = cell.status.ToString();
                }
            }
        }

        protected void ButtonMod_Click(object sender, EventArgs e)
        {
            DateTime deadline_input;
            if (!DateTime.TryParseExact(TextBox_deadline.Text, "yyyy/MM/dd", null, DateTimeStyles.AssumeLocal, out deadline_input))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "check",
                            "<script/>alert('日付のは2020/01/01のように入力してください');</script>");
                return;
            }

            using (var dt = new DataClasses_OMDataContext())
            {
                try
                {
                    //入力値でデータを更新
                    foreach (var cell in dt.Order_cls.Where(c => c.order_code == Form_Management.modOrder_id))
                    {
                        int quqntity_input;
                        int.TryParse(TextBox_quantity.Text, out quqntity_input);
                        cell.quantity = quqntity_input;
                        cell.deadline = deadline_input;
                        cell.status = TextBox_status.Text;
                    }
                    dt.SubmitChanges();
                }
                catch
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "check",
                                "<script/>alert('更新に失敗しました');</script>");
                    return;
                }
            }

            Response.Redirect("Form_Management.aspx");
        }
    }
}