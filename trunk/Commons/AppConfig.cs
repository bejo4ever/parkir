using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
namespace Commons
{
    using MySql.Data.MySqlClient;

    public enum GateClass { car = 1, motor = 2 };
    public enum GateType { gatein = 1, gateout = 2 };

    public enum DataOperationMode
    {
        none,
        add,
        edit,
        delete
    }

    public class AppConfig
    {
        public static long NOT_DEFINED_ID = -1;
        public static long GATE_IN = 1;
        public static long GATE_OUT = 0;
        public static long ADMIN = 1;
        public static long OPERATOR = 2;

        private static AppConfig _config = null;

        private bool isLoaded = false;
        private string connectionString = null;
        private long appId = AppConfig.NOT_DEFINED_ID;
        private string companyName;
        private string companyAddress;
        private string phoneNumber;
        private long currentMotorTarifId;
        private long currentCarTarifId;

        private string gateName = "";
        private string gateCode = "";
        private long gateId;
        private GateClass gateClass;
        private GateType gateType;

        // motor tarif
        private long tarifId;
        private string tarifName;
        private long tarifInitial;
        private long tarifExtended;
        private int tarifExtendedHour;


        private string username = "";
        private long userid = NOT_DEFINED_ID;
        private long role_id = NOT_DEFINED_ID;
        private long gateOperationId = NOT_DEFINED_ID;

        private AppConfig()
        { }

        public long TarifId
        {
            get { return tarifId; }
        }

        public string TarifName
        {
            get { return tarifName; }
        }

        public long TarifInitial
        {
            get { return tarifInitial; }
        }

        public long TarifExtended
        {
            get { return tarifExtended; }
        }

        public int TarifExtendedHour
        {
            get { return tarifExtendedHour; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        public long UserID
        {
            get { return userid; }
            set { userid = value; }
        }

        public static AppConfig Instance
        {
            get
            {
                if (null == _config)
                {
                    _config = new AppConfig();
                }
                return _config;
            }
        }

        public bool IsLoaded
        {
            get { return isLoaded; }
        }

        public string CompanyName
        {
            get { return companyName; }
        }

        public string CompanyAddress
        {
            get { return companyAddress; }
        }

        public string CompanyPhoneNumber
        {
            get { return phoneNumber; }
        }

        public string ConnectionString
        {
            get { return connectionString; }
        }


        public long AppId
        {
            get { return appId; }
            set { appId = value; }
        }

        public string GateName
        {
            get
            {
                return gateName;
            }
        }

        public long GateId
        {
            get { return gateId; }
        }

        public string GateCode
        {
            get { return gateCode; }
        }

        public long GetInitialTarif
        {
            get
            {
                return -1;
            }
        }

        /// <summary>
        /// Ticket ID generator, using Gate ID and DateTime
        /// </summary>
        /// <returns></returns>
        public string GenerateTicketID()
        {
            DateTime dt = DateTime.Now;
            string dateGenerator = dt.ToString("yyMMddHHmmss");
            return gateCode + dateGenerator;
        }

        public void LoadAppSetting(string connectionString)
        {
            this.connectionString = connectionString;
            LoadAppSetting();
        }

        public void LoadGateSetting(int id)
        {

            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(
                "select id, gate_class, gate_type, gate_code, gate_name, image_dir from gates where id=" + id,
                conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                gateId = reader.GetInt64("id");
                int gtClass = reader.GetInt32("gate_class");
                switch (gtClass)
                {
                    case 1:
                        gateClass = GateClass.car;
                        break;
                    case 2:
                        gateClass = GateClass.motor;
                        break;
                }

                int type = reader.GetInt32("gate_type");
                switch (type)
                {
                    case 1:
                        gateType = GateType.gatein;
                        break;
                    case 2:
                        gateType = GateType.gateout;
                        break;
                }
                gateCode = reader.GetString("gate_code");
                gateName = reader.GetString("gate_name");
            }
            reader.Close();

            // get tarif based on gate class 
            string sql = "select id, name, initial_price, extended_price, extended_after from tarifs where id = ";
            switch (gateClass)
            {
                case GateClass.car:
                    sql += currentCarTarifId.ToString();
                    break;
                case GateClass.motor:
                    sql += currentMotorTarifId.ToString();
                    break;
            }
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = sql;
            if (conn.State != System.Data.ConnectionState.Open)
                conn.Open();

            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                tarifId = reader.GetInt32("id");
                tarifName = reader.GetString("name");
                tarifInitial = reader.GetInt64("initial_price");
                tarifExtended = reader.GetInt64("extended_price");
                tarifExtendedHour = reader.GetInt32("extended_after");
            }
            reader.Close();
            conn.Close();
        }

        public long CalculateExtendedTarif(TimeSpan duration)
        {
            long result = 0;
            int hour = duration.Hours;
            int day = duration.Days;
            int total = (day * 24) + hour;
            total = total - tarifExtendedHour;
            result = total * tarifExtended;
            return result;
        }

        private void LoadAppSetting()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(
                "select app_id, company_name, company_address, phone_number, current_motor_tarif_id, current_car_tarif_id from app limit 1",
                conn);
            conn.Open();
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                appId = reader.GetInt64("app_id");
                companyName = reader.GetString("company_name");
                companyAddress = reader.GetString("company_address");
                phoneNumber = reader.GetString("phone_number");
                currentMotorTarifId = reader.GetInt64("current_motor_tarif_id");
                currentCarTarifId = reader.GetInt64("current_car_tarif_id");
            }
            reader.Close();
            conn.Close();
        }

        public bool ValidateLogin(string username, string password)
        {
            string sql = "select count(*) as count from users where username = '" + username + "' " +
                " and password = password('" + password + "') ";
            MySqlConnection conn = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            conn.Open();
            object queryResult = cmd.ExecuteScalar();
            int count = int.Parse(queryResult.ToString());
            conn.Close();
            IdentifyCurrentUser(username, password);
            return count > 0 ? true : false;
        }

        public bool IsCurrentUserAdmin()
        {
            return role_id == ADMIN;
        }

        private void IdentifyCurrentUser(string username, string password)
        {
            string sql = "select id, role_id from users where username = '" + username + "' and " +
                " password = password('" + password + "') ";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    userid = reader.GetInt64("id");
                    role_id = reader.GetInt64("role_id");
                    this.username = username;
                }
                reader.Close();

                if (userid != NOT_DEFINED_ID && gateType == GateType.gateout)
                {
                    DateTime now = DateTime.Now;
                    string dateStr = now.Year + "-" + now.Month + "-" + now.Day +
                        " " + now.Hour + ":" + now.Minute + ":" + now.Second;
                    sql = "insert into gate_operations set user_id = " + userid +
                        ", gate_id = " + gateId + ", price_id = " + tarifId +
                        ", start = '" + dateStr + "'";
                    cmd.CommandText = sql;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.ExecuteNonQuery();

                    sql = "select id from gate_operations where user_id = " + userid +
                        " and gate_id = " + gateId + " and price_id = " + tarifId +
                        " and start = '" + dateStr + "'";
                    cmd.CommandText = sql;
                    cmd.CommandType = System.Data.CommandType.Text;
                    reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        gateOperationId = reader.GetInt64("id");
                    }
                    reader.Close();
                }
                conn.Close();
            }
        }

        public void EndUserGateOperation()
        {
            DateTime now = DateTime.Now;
            string dateStr = now.Year + "-" + now.Month + "-" + now.Day +
                " " + now.Hour + ":" + now.Minute + ":" + now.Second;
            string sql = "update gate_operations set end = '" + dateStr + "' where " +
                " id = " + gateOperationId;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }

        }
    }
}
