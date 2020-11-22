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
        private int selectSitNumber; 
        OracleDataAdapter DBAdapter;
        DataSet DS;
        OracleCommandBuilder myCommandBuilder;
        DataTable branchTable;
        DataTable sitTable;
        private string branch_id;
        private string branch_name;
        private string total_sit;
        private string using_sit;

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


        public string bug;
        private string branchNumber;
        public DataAccess(string id, string pwd)
        {
            try
            {
                string connectionString = "User Id=" + id + "; Password=" + pwd + "; Data Source=(DESCRIPTION = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)) (CONNECT_DATA = (SERVER = DEDICATED) (SERVICE_NAME = xe) ) );";
                string commandString = "select * from branch";
                DBAdapter = new OracleDataAdapter(commandString, connectionString);

                myCommandBuilder = new OracleCommandBuilder(DBAdapter);
                DS = new DataSet();
                
            }  
            catch (DataException DE)
            {
                MessageBox.Show(DE.Message);
            }

            /*
            string query = "select ename from emp";
            OracleDataAdapter adapter = new OracleDataAdapter(query, conn);
            adapter.SelectCommand = new OracleCommand(query, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);

            OracleCommandBuilder builder = new OracleCommandBuilder(adapter);
            adapter.Fill(ds);


            OracleCommand comm = new OracleCommand(query, conn);
            OracleDataReader rs = comm.ExecuteReader();
            while (rs.Read())
            {
                Console.Write(" " + rs.GetString(0) + " ");
            }
            */
        }
        public bool CheckIdPwd(string id, string pwd)
        {
            DS.Clear();
            DBAdapter.Fill(DS, "Branch");
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

                DBAdapter.Fill(DS, "Sit");
                //sitTable = DS.Tables("Sit");
                return true;
            }
            else 
                return false;
        }
    }
}
