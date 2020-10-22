using System;
using System.Globalization;

namespace WebOrderManagement
{
    public partial class Form_Serch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSerch_Click(object sender, EventArgs e)
        {
            //入力値を検索用変数に設定
            if (!String.IsNullOrEmpty(TextBox_deadline.Text))
            {
                DateTime deadline_input;
                if (!DateTime.TryParseExact(TextBox_deadline.Text, "yyyy/MM/dd", null, DateTimeStyles.None, out deadline_input))
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "check",
                                "<script/>alert('日付のは2020/01/01のように入力してください');</script>");
                    return;
                }
            }

            Form_Management.customer = TextBox_customer.Text;
            Form_Management.merchandise = TextBox_merchandise.Text;
            Form_Management.deadline = TextBox_deadline.Text;
            Form_Management.status = TextBox_status.Text;

            Response.Redirect("Form_Management.aspx");
        }

    }
}