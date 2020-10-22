using System;
using System.Globalization;
using System.Linq;

namespace WebOrderManagement
{
    public partial class Form_Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime deadline_input = new DateTime();
                if (!String.IsNullOrEmpty(Text_Deadline.Text))
                {
                    if (!DateTime.TryParseExact(Text_Deadline.Text, "yyyy/MM/dd", null, DateTimeStyles.None, out deadline_input))
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "check",
                                    "<script/>alert('日付のは2020/01/01のように入力してください');</script>");
                        return;
                    }
                }

                using (var dt = new DataClasses_OMDataContext())
                {
                    //顧客テーブルにない場合は、レコード追加
                    int customerCnt = dt.Customer_cls.Select(c => c).Count();
                    if (dt.Customer_cls.Where(c => c.customer.Equals(Text_Customer.Text)).ToArray().Length == 0)
                    {
                        Customer_cls cs = new Customer_cls
                        {
                            customer_code = ++customerCnt,
                            customer = Text_Customer.Text
                        };
                        dt.Customer_cls.InsertOnSubmit(cs);
                        dt.SubmitChanges();
                    }
                    else
                    {
                        //顧客テーブルにある場合は、そのコードをセット
                        customerCnt = dt.Customer_cls.Where(c => c.customer.Equals(Text_Customer.Text)).First().customer_code;
                    }

                    //商品テーブルにない場合は、レコード追加
                    int merchandiseCnt = dt.Merchandise_cls.Select(c => c).Count();
                    if (dt.Merchandise_cls.Where(c => c.merchandise.Equals(Text_Merchandise.Text)).ToArray().Length == 0)
                    {
                        Merchandise_cls mch = new Merchandise_cls
                        {
                            merchandise_code = ++merchandiseCnt,
                            merchandise = Text_Merchandise.Text
                        };
                        dt.Merchandise_cls.InsertOnSubmit(mch);
                        dt.SubmitChanges();
                    }
                    else
                    {
                        //商品テーブルにある場合は、そのコードをセット
                        merchandiseCnt = dt.Merchandise_cls.Where(c => c.merchandise.Equals(Text_Merchandise.Text)).First().merchandise_code;
                    }

                    //登録内容を注文テーブルに追加
                    int quantity_input = 0;
                    int.TryParse(Text_Quantity.Text, out quantity_input);
                    int ordercode_input = 0;
                    if (dt.Order_cls.Select(c => c).Count() > 0)
                        ordercode_input = dt.Order_cls.OrderByDescending(c => c.order_code).First().order_code;

                    Order_cls od = new Order_cls
                    {
                        order_code =  ordercode_input + 1,
                        merchandise_code = merchandiseCnt,
                        quantity = quantity_input,
                        customer_code = customerCnt,
                        deadline = deadline_input,
                        status = "受付"
                    };
                    dt.Order_cls.InsertOnSubmit(od);
                    dt.SubmitChanges();
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(this.GetType(), "check",
                                                    "<script/>alert('登録に失敗しました');</script>");
                return;
            }
            Response.Redirect("Form_Management.aspx");
        }
    }
}