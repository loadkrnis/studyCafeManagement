using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyCafeManagement
{
    public class DataAccess
    {

        OracleDataAdapter adapter;
        DataSet DS;
        OracleCommandBuilder builder;
        DataTable branchTable;
        DataTable sitTable;
        private OracleConnection conn;

        public string bug;
        private string member_id;
        private string phone_number;
        private string selectSitNumber;
        private string selectTime;
        private string selectCharge;
        private string branch_id;
        private string branch_name;
        private string total_sit;
        private string using_sit;
        private string dayCharge;
        private string[] hourCharge;
        private string[] hourTime;
        private string branch_address;
        private bool isChange = false;
        private string beforeSit;
        public string BeforeSit
        {
            get { return beforeSit; }
            set { beforeSit = value; }
        }
        public bool IsChange
        {
            get { return isChange; }
            set { isChange = value; }
        }
        public string[] HourTime
        {
            get { return hourTime; }
            set { hourTime = value; }
        }
        public string BrachAddress
        {
            get { return branch_address; }
            set { branch_address = value; }
        }
        public string DayCharge
        {
            get { return dayCharge; }
        }
        public string[] HourCharge
        {
            get { return hourCharge; }
        }
        public string TotalSit
        {
            get { return total_sit; }
        }
        public string UsingSit
        {
            get { return using_sit; }
        }
        public string BranchName
        {
            get { return branch_name; }
        }
        public string BranchId
        {
            get { return branch_id; }
        }
        public string SelectSitNumber
        {
            get { return selectSitNumber; }
            set { selectSitNumber = value; }
        }
        public string SelectTime
        {
            get { return selectTime; }
            set { selectTime = value; }
        }
        public string SelectCharge
        {
            get { return selectCharge; }
            set { selectCharge = value; }
        }

        public DataAccess(string id, string pwd)
        {
            try
            {
                string connectionString = "User Id=" + id + "; Password=" + pwd + "; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
                string commandString = "select * from branch";
                conn = new OracleConnection(connectionString);
                conn.Open();
                adapter = new OracleDataAdapter(commandString, conn);
                builder = new OracleCommandBuilder(adapter);
                DS = new DataSet();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
        }

        public string PhoneNumber
        {
            get { return phone_number; }
            set { phone_number = value; }
        }

        public bool CheckIdPwd(string id, string pwd)
        {
            adapter.Fill(DS, "Branch");
            branchTable = DS.Tables["Branch"];
            string query = "ceo_id = '#ID' AND ceo_password = '#PWD'";
            query = query.Replace("#ID", id);
            query = query.Replace("#PWD", pwd);
            DataRow[] ResultRows = branchTable.Select(query);

            if (ResultRows.Length == 1)
            {
                branch_id = ResultRows[0]["id"].ToString();
                branch_name = ResultRows[0]["name"].ToString();
                branch_address = ResultRows[0]["address"].ToString();
                DS.Clear();
                UpdateSit();

                adapter.SelectCommand = new OracleCommand("select * from charge_plan where branch_id='" + branch_id + "' order  by time", conn);
                adapter.Fill(DS, "ChargePlan");
                ResultRows = DS.Tables["ChargePlan"].Select("time = 'day'");
                dayCharge = ResultRows[0]["charge"].ToString();

                ResultRows = DS.Tables["ChargePlan"].Select("time<>'day'");
                hourCharge = new string[3];
                hourTime = new string[3];
                for (int i = 0; i < 3; i++)
                {
                    hourCharge[i] = ResultRows[i]["charge"].ToString();
                    hourTime[i] = ResultRows[i]["time"].ToString();
                }

                return true;
            }
            else
                return false;
        }

        public void UpdateSit()
        {
            DS.Clear();
            adapter.SelectCommand = new OracleCommand("select * from sit where branch_id='" + branch_id + "'", conn);
            adapter.Fill(DS, "Sit");
            sitTable = DS.Tables["Sit"];
            total_sit = sitTable.Select("1=1").Length.ToString();
            using_sit = sitTable.Select("is_used = 'T'").Length.ToString();
        }

        public bool IsMember(string number)
        {
            adapter.SelectCommand = new OracleCommand("select * from member where phone_number = '" + number + "'", conn);
            DS.Clear();
            adapter.Fill(DS, "Member");
            if (DS.Tables["Member"].Select().Length == 1)
            {
                member_id = DS.Tables["Member"].Rows[0]["member_id"].ToString();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool InsertMember(string number)
        {
            try
            {
                DS.Clear();
                adapter.SelectCommand = new OracleCommand("select * from member where branch_id ='" + branch_id + "'", conn);
                adapter.Fill(DS, "Member");
                DataRow newRow = DS.Tables["Member"].NewRow();
                newRow["branch_id"] = branch_id;
                newRow["phone_number"] = number;
                newRow["create_at"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                DS.Tables["Member"].Rows.Add(newRow);
                adapter.Update(DS, "Member");
                DS.AcceptChanges();
                adapter.SelectCommand = new OracleCommand("select * from member where phone_number='" + number + "'", conn);
                DS.Clear();
                adapter.Fill(DS, "Member");
                member_id = DS.Tables["Member"].Rows[0]["member_id"].ToString();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "이거다");
            }
            return false;
        }

        public Sit[] GetSits()
        {
            DS.Clear();
            adapter.SelectCommand = new OracleCommand("select * from sit where branch_id='" + branch_id + "' order by sit_num asc", conn);
            adapter.Fill(DS, "Sit");
            int x;
            int y;
            char isUsed;
            DateTime now = DateTime.Now;
            DateTime sitTime = new DateTime(1);
            string temp;
            string[] Date;
            string[] Time;
            Sit[] result = new Sit[DS.Tables["Sit"].Rows.Count];
            for (int i = 0; i < result.Length; i++)
            {
                temp = (DS.Tables["Sit"].Rows[i]["end_at"]).ToString();
                //2020-12-01 오전 2:51:27
                if (temp.Length > 1)
                {
                    Date = temp.Substring(0, 10).Split('-');
                    Time = (temp.Trim()).Substring(13).Split(':');
                    if (temp.Substring(11, 2) == "오후") sitTime = new DateTime(Convert.ToInt32(Date[0]), Convert.ToInt32(Date[1]), Convert.ToInt32(Date[2]), Convert.ToInt32(Time[0])+12, Convert.ToInt32(Time[1]), Convert.ToInt32(Time[2]));
                    else sitTime = new DateTime(Convert.ToInt32(Date[0]), Convert.ToInt32(Date[1]), Convert.ToInt32(Date[2]), Convert.ToInt32(Time[0]), Convert.ToInt32(Time[1]), Convert.ToInt32(Time[2]));
                }
                if(DateTime.Compare(sitTime, now) <= 0)
                {
                    DS.Tables["Sit"].Rows[i]["is_used"] = 'F';
                    DS.Tables["Sit"].Rows[i]["member_id"] = "0";
                }
                x = Convert.ToInt32(DS.Tables["Sit"].Rows[i]["location_x"]);
                y = Convert.ToInt32(DS.Tables["Sit"].Rows[i]["location_y"]);
                isUsed = Convert.ToChar(DS.Tables["Sit"].Rows[i]["is_used"]);
                result[i] = new Sit(x, y, i + 1, isUsed);
            }
            adapter.Update(DS, "Sit");
            DS.AcceptChanges();
            return result;
        }

        public Sit[] GetFalseSits()
        {
            DS.Clear();
            adapter.SelectCommand = new OracleCommand("select * from sit where branch_id='" + branch_id + "' and is_used = 'F' order by sit_num asc", conn);
            adapter.Fill(DS, "Sit");
            int x;
            int y;
            char isUsed;
            int sitNum;
            Sit[] result = new Sit[DS.Tables["Sit"].Rows.Count];
            for (int i = 0; i < result.Length; i++)
            {
                x = Convert.ToInt32(DS.Tables["Sit"].Rows[i]["location_x"]);
                y = Convert.ToInt32(DS.Tables["Sit"].Rows[i]["location_y"]);
                isUsed = Convert.ToChar(DS.Tables["Sit"].Rows[i]["is_used"]);
                sitNum = Convert.ToInt32(DS.Tables["Sit"].Rows[i]["sit_num"]);
                result[i] = new Sit(x, y, sitNum, isUsed);
            }
            return result;
        }

        public bool InsertSale()
        {
            DS.Clear();
            adapter.SelectCommand = new OracleCommand("select * from sale where branch_id ='" + branch_id + "'", conn);
            adapter.Fill(DS, "Sale");
            DataRow newRow = DS.Tables["Sale"].NewRow();
            newRow["member_id"] = member_id;
            newRow["branch_id"] = branch_id;
            newRow["charge"] = SelectCharge;
            newRow["begin_at"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            if (SelectTime == "day")
            {
                newRow["end_at"] = DateTime.Now.AddDays(1).ToString("yyyy-MM-dd HH:mm:ss");
            }
            else //시간 정액제 선택
            {
                newRow["end_at"] = DateTime.Now.AddHours(Convert.ToInt32(SelectTime)).ToString("yyyy-MM-dd HH:mm:ss");
            }
            DS.Tables["Sale"].Rows.Add(newRow);
            adapter.Update(DS, "Sale");
            DS.AcceptChanges();
            adapter.SelectCommand = new OracleCommand("select * from sit where branch_id='" + branch_id + "' and sit_num='" + selectSitNumber + "'", conn);
            adapter.Fill(DS, "Sit");
            DS.Tables["Sit"].Rows[0]["is_used"] = 'T';
            DS.Tables["Sit"].Rows[0]["end_at"] = newRow["end_at"];
            DS.Tables["Sit"].Rows[0]["member_id"] = member_id;
            adapter.Update(DS, "Sit");
            DS.AcceptChanges();
            UpdateSit();
            return true;
        }

        public bool HasSit(string number)
        {
            DS.Clear();
            adapter.SelectCommand = new OracleCommand("select * from member where phone_number='" + number + "'", conn);
            adapter.Fill(DS, "User");
            if(DS.Tables["User"].Rows.Count == 0)
            {
                return false; 
            }
            else
            {
                member_id = DS.Tables["User"].Rows[0]["member_id"].ToString();
                PhoneNumber = number;
                adapter.SelectCommand = new OracleCommand("select * from sit where branch_id='" + branch_id + "' and member_id='" + member_id + "'", conn);
                adapter.Fill(DS, "Sit");
                if(DS.Tables["Sit"].Rows.Count == 1)
                {
                    BeforeSit = DS.Tables["Sit"].Rows[0]["sit_num"].ToString();
                    SelectSitNumber = BeforeSit;
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
        }

        public void ChangeSit()
        {
            DS.Clear();
            adapter.SelectCommand = new OracleCommand("select * from sit where branch_id='" + branch_id + "'", conn);
            adapter.Fill(DS, "Sit");
            DS.Tables["Sit"].Select("sit_num='" + SelectSitNumber + "'")[0]["end_at"] = DS.Tables["Sit"].Select("member_id='" + member_id + "'")[0]["end_at"];
            DS.Tables["Sit"].Select("sit_num='" + SelectSitNumber + "'")[0]["member_id"] = member_id;
            DS.Tables["Sit"].Select("sit_num='" + SelectSitNumber + "'")[0]["is_used"] = 'T';
            DS.Tables["Sit"].Select("member_id='" + member_id + "' and sit_num='"+BeforeSit+"'")[0]["end_at"] = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            DS.Tables["Sit"].Select("member_id='" + member_id + "' and sit_num='" + BeforeSit + "'")[0]["is_used"] = 'F';
            DS.Tables["Sit"].Select("member_id='" + member_id + "' and sit_num='" + BeforeSit + "'")[0]["member_id"] = "0";
            Console.WriteLine("ChangeSit : " + BeforeSit + " => " + SelectSitNumber);
            adapter.Update(DS, "Sit");
            DS.AcceptChanges();
            UpdateSit();
        }
        public bool Checkout()
        {
            DS.Clear();
            adapter.SelectCommand = new OracleCommand("select * from sit where member_id='" + member_id + "'", conn);
            adapter.Fill(DS, "Sit");
            DS.Tables["Sit"].Rows[0]["end_at"] = DateTime.Now;
            DS.Tables["Sit"].Rows[0]["is_used"] = 'F';
            adapter.Update(DS, "Sit");
            DS.AcceptChanges();
            UpdateSit();
            return true;
        }
        public bool Reprinting()
        {
            DS.Clear();
            adapter.SelectCommand = new OracleCommand("select * from sit where member_id='" + member_id + "'", conn);
            adapter.Fill(DS, "Sit");
            if(DS.Tables["Sit"].Rows.Count == 0) { return false; }
            adapter.SelectCommand = new OracleCommand("select * from member where member_id='" + member_id + "'", conn);
            adapter.Fill(DS, "Member");
            PhoneNumber = DS.Tables["Member"].Rows[0]["phone_number"].ToString();
            Console.WriteLine("PhoneNumber : "+PhoneNumber);
            return true;
        }
    }
}
