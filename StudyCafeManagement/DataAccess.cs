using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
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
        OracleCommandBuilder myCommandBuilder;
        DataTable branchTable;
        DataTable sitTable;
        private OracleConnection conn;

        private string selectSitNumber;
        private string selectTime;
        private string selectCharge;

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

        private string branch_id;
        private string branch_name;
        private string total_sit;
        private string using_sit;
        public string bug;
        private string dayCharge;
        private string[] hourCharge;

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


        public DataAccess(string id, string pwd)
        {
            try
            {
                string connectionString = "User Id=" + id + "; Password=" + pwd + "; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
                string commandString = "select * from branch";
                conn = new OracleConnection(connectionString);
                conn.Open();
                adapter = new OracleDataAdapter(commandString, conn);
                DS = new DataSet();
            }
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }
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
                DS.Clear();
                UpdateSit();

                adapter.SelectCommand = new OracleCommand("select * from charge_plan where branch_id='" + branch_id + "' order  by time", conn);
                adapter.Fill(DS, "ChargePlan");
                ResultRows = DS.Tables["ChargePlan"].Select("time = 'day'");
                dayCharge = ResultRows[0]["charge"].ToString();

                ResultRows = DS.Tables["ChargePlan"].Select("time<>'day'");
                hourCharge = new string[3];
                for (int i = 0; i < 3; i++)
                {
                    hourCharge[i] = ResultRows[i]["charge"].ToString();
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
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool InsertMember(string number)
        {
            DS.Clear();
            adapter.SelectCommand = new OracleCommand("select * from member where branch_id ='" + branch_id + "'", conn);
            adapter.Fill(DS, "Member");
            DS.Tables["Member"].Rows.Add("", int.Parse(branch_id), number); //error
            return true;
        }
    }
}
