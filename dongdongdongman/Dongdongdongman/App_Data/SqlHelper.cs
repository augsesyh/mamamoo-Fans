using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Dongdongdongman.App_Data
{
    /// <summary>
    /// 数据方法封装帮助类
    /// </summary>
    public class SqlHelper
    {
        public static Encoding encoding = Encoding.UTF8;
        //internal static string connectionString = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

        //#region 数据库访问类接口

        //#region ExecuteSql(string SQLString)---执行SQL语句（增删改）【返回影响的记录数】
        ///// <summary>
        ///// 执行SQL语句（增删改）【返回影响的记录数】
        ///// </summary>
        ///// <param name="SQLString">SQL语句</param>
        ///// <returns>影响的记录数</returns>
        //internal static int ExecuteSql(string SQLString)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        using (SqlCommand cmd = new SqlCommand(SQLString, connection))
        //        {
        //            try
        //            {
        //                connection.Open();
        //                int rows = cmd.ExecuteNonQuery();
        //                return rows;
        //            }
        //            catch (System.Data.SqlClient.SqlException e)
        //            {
        //                connection.Close();
        //                throw e;
        //            }
        //            finally
        //            {
        //                connection.Close();
        //            }
        //        }
        //    }
        //}
        //#endregion

        //#region GetDataTable(string m_strSqlString)---根据查询语句获取结果【返回DataTable】
        ///// <summary>
        ///// 根据查询语句获取结果【返回DataTable】
        ///// </summary>
        ///// <param name="m_strSqlString">查询语句</param>
        ///// <returns>返回DataTable</returns>
        //internal static DataTable GetDataTable(string m_strSqlString)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        DataTable dt = new DataTable();
        //        try
        //        {
        //            connection.Open();
        //            SqlDataAdapter command = new SqlDataAdapter(m_strSqlString, connection);
        //            command.Fill(dt);
        //            return dt;
        //        }
        //        catch (SqlException ex)
        //        {
        //            throw new Exception(ex.Message);
        //        }
        //        finally
        //        {
        //            connection.Close();
        //        }
        //    }
        //}
        //#endregion

        //#region Exists(string strSql)---检查是否存在
        ///// <summary>
        ///// 检查是否存在
        ///// </summary>
        ///// <param name="strSql">Sql语句</param>
        ///// <returns>bool结果</returns>
        //public static bool Exists(string strSql)
        //{
        //    int cmdresult = Convert.ToInt32(ExecuteScalar(connectionString, CommandType.Text, strSql, null));
        //    if (cmdresult == 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        ///// <summary>
        ///// 检查是否存在
        ///// </summary>
        ///// <param name="strSql">Sql语句</param>
        ///// <param name="cmdParms">参数</param>
        ///// <returns>bool结果</returns>
        //public static bool Exists(string strSql, params SqlParameter[] cmdParms)
        //{
        //    int cmdresult = Convert.ToInt32(ExecuteScalar(connectionString, CommandType.Text, strSql, cmdParms));
        //    if (cmdresult == 0)
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        return true;
        //    }
        //}

        /// <param name="connectionString">一个有效的数据库连接字符串</param>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">存储过程的名字或者 T-SQL 语句</param>
        /// <param name="commandParameters">以数组形式提供SqlCommand命令中用到的参数列表</param>
        /// <returns>An object that should be converted to the expected type using Convert.To{Type}</returns>
        public static object ExecuteScalar(string connectionString, CommandType cmdType, string cmdText, params SqlParameter[] commandParameters)
        {
            SqlCommand cmd = new SqlCommand();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                PrepareCommand(cmd, connection, null, cmdType, cmdText, commandParameters);
                object val = cmd.ExecuteScalar();
                cmd.Parameters.Clear();
                return val;
            }
        }

        /// <summary>
        /// 为执行命令准备参数
        /// </summary>
        /// <param name="cmd">SqlCommand 命令</param>
        /// <param name="conn">已经存在的数据库连接</param>
        /// <param name="trans">数据库事物处理</param>
        /// <param name="cmdType">SqlCommand命令类型 (存储过程， T-SQL语句， 等等。)</param>
        /// <param name="cmdText">Command text，T-SQL语句 例如 Select * from Products</param>
        /// <param name="cmdParms">返回带参数的命令</param>
        private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, CommandType cmdType, string cmdText, SqlParameter[] cmdParms)
        {
            //判断数据库连接状态
            if (conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = cmdText;
            //判断是否需要事物处理
            if (trans != null)
                cmd.Transaction = trans;
            cmd.CommandType = cmdType;
            if (cmdParms != null)
            {
                foreach (SqlParameter parm in cmdParms)
                    cmd.Parameters.Add(parm);
            }
        }
        //#endregion

        #region 存储过程操作

        ///// <summary>
        ///// 执行存储过程
        ///// </summary>
        ///// <param name="storedProcName">存储过程名</param>
        ///// <param name="parameters">存储过程参数</param>
        ///// <returns>DataSet</returns>
        //internal static DataSet RunProcedure(string storedProcName, IDataParameter[] parameters)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        DataSet dataSet = new DataSet();
        //        connection.Open();
        //        SqlDataAdapter sqlDA = new SqlDataAdapter();
        //        sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
        //        sqlDA.Fill(dataSet);
        //        connection.Close();
        //        return dataSet;
        //    }
        //}

        ///// <summary>
        ///// 执行存储过程
        ///// </summary>
        ///// <param name="storedProcName">存储过程名</param>
        ///// <param name="parameters">存储过程参数</param>
        ///// <returns>DataSet</returns>
        //internal static DataTable RunProcedureDataTable(string storedProcName, IDataParameter[] parameters)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        DataTable dataSet = new DataTable();
        //        connection.Open();
        //        SqlDataAdapter sqlDA = new SqlDataAdapter();
        //        sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
        //        sqlDA.Fill(dataSet);
        //        connection.Close();
        //        return dataSet;
        //    }
        //}

        ///// <summary>
        ///// 执行存储过程获取单个数据
        ///// </summary>
        ///// <param name="storedProcName">存储过程名</param>
        ///// <param name="parameters">存储过程参数</param>
        ///// <returns>DataTable</returns>
        //public static object RunProcedureSingle(string storedProcName, IDataParameter[] parameters)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        DataSet dataSet = new DataSet();
        //        connection.Open();
        //        DataTable dt = new DataTable();
        //        SqlDataAdapter sqlDA = new SqlDataAdapter();
        //        sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
        //        sqlDA.Fill(dt);
        //        connection.Close();
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            return dt.Rows[0][0];
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}

        ///// <summary>
        ///// 执行存储过程获取所有数据
        ///// </summary>
        ///// <param name="storedProcName">存储过程名</param>
        ///// <param name="parameters">存储过程参数</param>
        ///// <returns>DataTable</returns>
        //public static DataTable RunResultDataTable(string storedProcName, IDataParameter[] parameters)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        DataSet dataSet = new DataSet();
        //        connection.Open();
        //        DataTable dt = new DataTable();
        //        SqlDataAdapter sqlDA = new SqlDataAdapter();
        //        sqlDA.SelectCommand = BuildQueryCommand(connection, storedProcName, parameters);
        //        sqlDA.Fill(dt);
        //        connection.Close();
        //        if (dt != null && dt.Rows.Count > 0)
        //        {
        //            return dt;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //}

        /// <summary>
        /// 构建 SqlCommand 对象(用来返回一个结果集，而不是一个整数值)
        /// </summary>
        /// <param name="connection">数据库连接</param>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand</returns>
        internal static SqlCommand BuildQueryCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = new SqlCommand(storedProcName, connection);
            command.CommandType = CommandType.StoredProcedure;
            foreach (SqlParameter parameter in parameters)
            {
                if (parameter != null)
                {
                    // 检查未分配值的输出参数,将其分配以DBNull.Value.
                    if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction == ParameterDirection.Input) &&
                        (parameter.Value == null))
                    {
                        parameter.Value = DBNull.Value;
                    }
                    command.Parameters.Add(parameter);
                }
            }
            return command;
        }

        ///// <summary>
        ///// 执行存储过程，返回影响的行数		
        ///// </summary>
        ///// <param name="storedProcName">存储过程名</param>
        ///// <param name="parameters">存储过程参数</param>
        ///// <param name="rowsAffected">影响的行数</param>
        ///// <returns></returns>
        //internal static int RunProcedure(string storedProcName, IDataParameter[] parameters, out int rowsAffected)
        //{
        //    using (SqlConnection connection = new SqlConnection(connectionString))
        //    {
        //        int result;
        //        connection.Open();
        //        SqlCommand command = BuildIntCommand(connection, storedProcName, parameters);
        //        rowsAffected = command.ExecuteNonQuery();
        //        result = (int)command.Parameters["ReturnValue"].Value;
        //        connection.Close();
        //        return result;
        //    }
        //}

        /// <summary>
        /// 创建 SqlCommand 对象实例(用来返回一个整数值)	
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <returns>SqlCommand 对象实例</returns>
        internal static SqlCommand BuildIntCommand(SqlConnection connection, string storedProcName, IDataParameter[] parameters)
        {
            SqlCommand command = BuildQueryCommand(connection, storedProcName, parameters);
            command.Parameters.Add(new SqlParameter("ReturnValue", SqlDbType.Int, 4, ParameterDirection.ReturnValue, false, 0, 0, string.Empty, DataRowVersion.Default, null));
            return command;
        }
        #endregion

        //#endregion

        #region 数据转换应用库

        #region 将Json数据包转换成字典集V2
        /// <summary>
        /// 将Json数据包转换成字典集V2(利用正则，value值去掉双引号  注意：这个功能Key不能重复，值不能含逗号，因此需要优化！)
        /// </summary>
        /// <param name="jstring">字典集</param>
        /// <returns></returns>
        public static Dictionary<string, string> GetDictionaryByJson(string jstring)
        {
            MatchCollection mc = Regex.Matches(jstring, @"""(?<key>[^""]+)"":(?<value>[^,}]+)");
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (Match m in mc)
            {
                if (dict.ContainsKey(m.Groups["key"].Value)) continue; //此处有BUG，当Key重复会出现数据不准确
                dict.Add(m.Groups["key"].Value, m.Groups["value"].Value.Replace("\"", ""));
            }
            return dict;
        }
        #endregion

        #region DataTable转换为Json格式
        public static string DataTableToJson(DataTable table)
        {
            var JsonString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JsonString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JsonString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JsonString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JsonString.Append("}");
                    }
                    else
                    {
                        JsonString.Append("},");
                    }
                }
                JsonString.Append("]");
            }
            return JsonString.ToString();
        }
        #endregion

        #region GetInt(object obj)----将obj类型转换为整形
        /// <summary>
        /// 将obj类型转换为整形
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static int GetInt(object obj)
        {
            return GetInt(obj, 0);
        }

        /// <summary>
        /// 将对象转换为整形(指定默认值)
        /// </summary>
        /// <param name="obj">转换对象</param>
        /// <param name="Default">默认值</param>
        /// <returns></returns>
        public static int GetInt(object obj, int Default)
        {
            int r = Default;
            if (obj != null)
            {
                try
                {
                    r = Convert.ToInt32(obj.ToString());
                }
                catch { }
            }
            return r;
        }
        #endregion

        #region CheckIsNumber(object obj)---判断对象是否为数值(是返回true/否返回false)
        /// <summary>
        /// 判断对象是否为数值(是返回true/否返回false)
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool CheckIsNumber(object obj)
        {
            bool r = false;
            if (obj != null)
            {
                try
                {
                    Convert.ToInt32(obj.ToString());
                    r = true;
                }
                catch { r = false; }
            }
            return r;
        }
        #endregion

        #region getNormalTimeByTimeStamp(int timeStamp)---根据时间戳转换成正常日期
        /// <summary>
        /// 根据时间戳转换成正常日期
        /// </summary>
        /// <param name="timeStamp"></param>
        /// <returns></returns>
        public static DateTime getNormalTimeByTimeStamp(int timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime);
            DateTime dtResult = dtStart.Add(toNow);
            return dtResult;
        }
        #endregion

        #region ConvertIntDateTime(double d)---将Unix时间戳转换为DateTime类型时间
        /// <summary> 
        /// 将Unix时间戳转换为DateTime类型时间
        /// </summary> 
        /// <param name="d"> double 型数字 </param> 
        /// <returns> DateTime </returns> 
        public static System.DateTime ConvertIntDateTime(double d)
        {
            System.DateTime time = System.DateTime.MinValue;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            time = startTime.AddSeconds(d);
            return time;
        }
        #endregion

        #region ConvertDateTimeInt(System.DateTime time)---将c# DateTime时间格式转换为Unix时间戳格式
        /// <summary> 
        /// 将c# DateTime时间格式转换为Unix时间戳格式
        /// </summary> 
        /// <param name="time"> 时间 </param> 
        /// <returns> double </returns> 
        public static double ConvertDateTimeInt(System.DateTime time)
        {
            double intResult = 0;
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            intResult = (time - startTime).TotalSeconds;
            return intResult;
        }
        #endregion

        #region GetTimeStamp()---获取标准时间戳
        /// <summary>
        /// 获取标准时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStamp()
        {
            TimeSpan ts = DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds).ToString();
        }
        #endregion

        #region GetTimeStampMilli()---获取毫秒时间戳
        /// <summary>
        /// 获取毫秒时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimeStampMilli()
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            DateTime dtNow = DateTime.Now;
            return ((long)(dtNow - dtStart).TotalMilliseconds).ToString();
        }
        #endregion

        #region UrlAndBase64Encode(string text)---将字符串使用Url+Base64编码
        /// <summary>
        /// 将字符串使用Url+Base64编码（先UrlEncode再Base64Encode）
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string UrlAndBase64Encode(string text)
        {
            string r = "";
            if (text != null)
            {
                text = HttpContext.Current.Server.UrlEncode(text).ToUpper();
                byte[] bytes = Encoding.Default.GetBytes(text);
                r = Convert.ToBase64String(bytes);
            }
            return r;

        }
        #endregion

        #region UrlAndBase64Decode(string text)---将字符串使用Url+Base64解码
        /// <summary>
        /// 将字符串使用Url+Base64解码（先UrlDecode再Base64Decode）
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string UrlAndBase64Decode(string text)
        {
            string r = "";
            if (text != null)
            {
                try
                {
                    byte[] bytes = Convert.FromBase64String(text);
                    r = Encoding.Default.GetString(bytes);
                    r = HttpContext.Current.Server.UrlDecode(r);
                }
                catch { }
            }
            return r;
        }
        #endregion

        #endregion

        #region 随机类应用库

        /// <summary>生成随机字符串</summary><param name="Length">返回长度</param><param name="Keys">字符集</param>
        public static string RandomString(int Length, string Keys)
        {
            char[] CharArray = Keys.ToCharArray();
            string Result = "";


            for (int i = 0; i < Length; i++)
            {
                Random R = new Random((i + 1) * unchecked((int)DateTime.Now.Ticks));
                int index = R.Next(CharArray.Length);

                Result = Result + CharArray[index];
            }

            return Result;
        }

        /// <summary>生成16进制字符组成的随机字符串</summary><param name="Length">返回长度</param>
        public static string RandomHexString(int Length)
        {
            string Keys = "0123456789ABCDEF";
            return RandomString(Length, Keys);
        }

        /// <summary>生成36进制字符组成的随机字符串,0-9,A-Z，不包含0,O,I等易混淆字符</summary><param name="Length">返回长度</param>
        public static string RandomStandardString(int Length)
        {
            string Keys = "123456789ABCDEFGHJKLMNPQRSTUVWXYZ";
            return RandomString(Length, Keys);
        }

        /// <summary>
        /// 时间戳
        /// </summary>
        /// <returns></returns>
        public static int ConvertDateTimeInt()
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            return (int)(DateTime.Now - startTime).TotalSeconds;
        }
        #endregion

        #region 安全加密类应用库
        readonly static string key = "DA39A3EE5E6B4B0D3255BFEF95601890AFD80709";
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Encode(string data)
        {
            byte[] byKey = Encoding.Default.GetBytes(key.Substring(5, 8));
            byte[] byIV = Encoding.Default.GetBytes(key.Substring(5, 8));

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            int i = cryptoProvider.KeySize;
            MemoryStream ms = new MemoryStream();
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateEncryptor(byKey, byIV), CryptoStreamMode.Write);

            StreamWriter sw = new StreamWriter(cst);
            cst.Write(Encoding.Default.GetBytes(data), 0, Encoding.Default.GetByteCount(data));
            sw.Flush();
            cst.FlushFinalBlock();
            sw.Flush();
            return Convert.ToBase64String(ms.GetBuffer(), 0, (int)ms.Length);
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string Decode(string data)
        {
            //把密钥转成二进制数组
            byte[] byKey = Encoding.Default.GetBytes(key.Substring(5, 8));
            byte[] byIV = Encoding.Default.GetBytes(key.Substring(5, 8));

            byte[] byEnc;
            try
            {
                //base64解码
                byEnc = Convert.FromBase64String(data);
            }
            catch
            {
                return null;
            }

            DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
            MemoryStream ms = new MemoryStream(byEnc);
            CryptoStream cst = new CryptoStream(ms, cryptoProvider.CreateDecryptor(byKey, byIV), CryptoStreamMode.Read);
            StreamReader sr = new StreamReader(cst);
            byte[] tmp = new byte[ms.Length];
            cst.Read(tmp, 0, tmp.Length);
            string result = Encoding.Default.GetString(tmp);

            return result.Replace("\0", "");
        }
        /// <summary>
        /// MD5加密[32位]（返回小写md5）
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static String PWD_MD5(String s)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(s);
            bytes = md5.ComputeHash(bytes);
            md5.Clear();

            string ret = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                ret += Convert.ToString(bytes[i], 16).PadLeft(2, '0');
            }

            return ret.PadLeft(32, '0');
        }

        /// <summary>
        /// 将字符串编码转换，并进行MD5加密（返回大写MD5）
        /// </summary>
        /// <param name="dataStr">要加密的字符串</param>
        /// <param name="codeType">编码格式 (utf-8\gb2312)</param>
        /// <returns></returns>
        public static string GetMD5(string dataStr, string codeType)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] t = md5.ComputeHash(Encoding.GetEncoding(codeType).GetBytes(dataStr));
            StringBuilder sb = new StringBuilder(32);
            for (int i = 0; i < t.Length; i++)
            {
                sb.Append(t[i].ToString("X").PadLeft(2, '0'));
            }
            return sb.ToString();
        }

        /// <summary>
        /// 将字符串进行SHA1加密
        /// </summary>
        /// <param name="sinatureStr">需加密字符串</param>
        /// <returns></returns>
        public static string GetSha1ByString(string sinatureStr)
        {
            var sha1 = SHA1.Create();
            var sha1Arr = sha1.ComputeHash(Encoding.UTF8.GetBytes(sinatureStr));
            StringBuilder enText = new StringBuilder();
            foreach (var b in sha1Arr)
            {
                enText.AppendFormat("{0:x2}", b);
            }
            return enText.ToString();
        }

        /// <summary>
        /// 将参数按ASCII排序并加上密钥进行MD5签名（空值不参与签名）
        /// </summary>
        /// <param name="pocket">参数值</param>
        /// <param name="key">参与签名的密钥</param>
        /// <returns></returns>
        public static string GetAsciiMD5Sign(Dictionary<string, string> pocket, string key)
        {
            string sb = "";
            ArrayList akeys = new ArrayList(pocket.Keys);
            akeys.Sort();
            foreach (string k in akeys)
            {
                string v = (string)pocket[k];
                if (!string.IsNullOrEmpty(v) && "key".CompareTo(k) != 0)
                {
                    sb += (k + "=" + v + "&");
                }
            }
            sb = sb + "Key=" + key; //API密钥
            return GetMD5(sb, "utf-8").ToUpper();
        }

        /// <summary>
        /// 将参数按ASCII排序并加上密钥进行MD5签名（空值不参与签名）
        /// </summary>
        /// <param name="pocket">参数值</param>
        /// <param name="key">参与签名的密钥</param>
        /// <param name="keyName">MD5的键名名称(keyName=key)</param>
        /// <param name="isUpper">是否将签名结果转换成大写</param>
        /// <returns></returns>
        public static string GetAsciiMD5Sign(Dictionary<string, string> pocket, string key, string keyName, bool isUpper)
        {
            string sb = "";
            ArrayList akeys = new ArrayList(pocket.Keys);
            akeys.Sort();
            foreach (string k in akeys)
            {
                string v = (string)pocket[k];
                if (!string.IsNullOrEmpty(v) && "key".CompareTo(k) != 0)
                {
                    sb += (k + "=" + v + "&");
                }
            }
            sb = sb + keyName + "=" + key; //API密钥
            //throw new Exception(sb); //预签名字符串

            string mdResult = GetMD5(sb, "utf-8");
            if (isUpper) { mdResult = GetMD5(sb, "utf-8").ToUpper(); }
            return mdResult;
        }


        /// <summary>
        /// 生成MD5签名URL（返回一个签名后的网址-加签使用）
        /// </summary>
        /// <param name="parameters">需加签的字段（全部的URL参数）</param>
        /// <param name="privateKey">协商的签名密钥</param>
        /// <param name="hostUrl">主机域名（如：http://www.xxx.com）</param>
        /// <returns>生成的URL</returns>
        public static string SignUrl(Dictionary<string, string> parameters, string privateKey, string hostUrl)
        {
            string signParam = "";
            ArrayList akeys = new ArrayList(parameters.Keys);
            akeys.Sort();
            foreach (string k in akeys)
            {
                string v = (string)parameters[k];
                if (!string.IsNullOrEmpty(v) && "key".CompareTo(k) != 0)
                {
                    signParam += (k + "=" + v + "&");
                }
            }
            string signContent = signParam + "Key=" + privateKey;
            string sign = GetMD5(signContent, "utf-8").ToUpper();
            return hostUrl + "?" + signParam + "sign=" + sign;
        }

        /// <summary>
        /// 检验MD5签名（返回校验结果-验签使用）
        /// </summary>
        /// <param name="pocket">字典参数列表（可调用SafeHelper.ReceiveGetDictionary()获取全部Get参数）</param>
        /// <param name="privateKey">协商的签名密钥</param>
        /// <param name="sign">接收的签名sign值</param>
        /// <returns></returns>
        public static bool CheckSign(Dictionary<string, string> parameters, string privateKey, string sign)
        {
            bool r = false;
            string signContent = "";
            ArrayList akeys = new ArrayList(parameters.Keys);
            akeys.Sort();
            foreach (string k in akeys)
            {
                string v = (string)parameters[k];
                if (!string.IsNullOrEmpty(v) && "key".CompareTo(k) != 0)
                {
                    signContent += (k + "=" + v + "&");
                }
            }
            signContent = signContent + "Key=" + privateKey;
            if (sign == GetMD5(signContent, "utf-8").ToUpper())
            {
                r = true;
            }
            return r;
        }
        #endregion

        #region 正则表达式应用库
        /// <summary>
        /// 根据网址获取主机名 如:http://www.x.com
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static string getHostByUri(string uri)
        {
            string r = "";
            if (uri != null)
            {
                r = Regex.Match(uri, @"(?<=://)[a-zA-Z\.0-9]+").Value.ToString();
            }
            return r;
        }

        /// <summary>
        /// 根据网址获取网址文件部分, 如:http://www.x.com/x/x.aspx
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public static string getUrlfileByUrl(string uri)
        {
            string r = "";
            if (uri != null)
            {
                r = Regex.Match(uri, @"(?<=://)[a-zA-Z\.0-9\/]+").Value.ToString();
            }
            return r;
        }

        /// <summary>
        /// 检查手机号是否正确
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        public static bool CheckMobile(string mobile)
        {
            bool r = false;
            if (mobile != null)
            {
                r = Regex.IsMatch(mobile, @"1[3|4|5|7|8][0-9]\d{8}$");
            }
            return r;
        }
        #endregion

        #region Cookies类应用库

        #region 获取Cook
        /// <summary>
        /// 获得Cookie的值
        /// </summary>
        /// <param name="cookieName">Cookie名称</param>
        /// <returns></returns>
        public static string GetCookieValue(string cookieName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie == null)
                return "";
            else
                return cookie.Value;
        }
        #endregion

        #region 删除Cookie
        /// <summary>
        /// 删除Cookie的值
        /// </summary>
        /// <param name="cookieName">Cookie名称</param>
        /// <returns></returns>
        public static void RemoveCookie(string cookieName)
        {
            SetCookie(cookieName, "", DateTime.Now.AddDays(1));
        }
        #endregion

        #region 设置/修改Cookie
        /// <summary>
        /// 设置Cookie值和过期时间
        /// </summary>
        /// <param name="cookieName">Cookie名称</param>
        /// <param name="value">值</param>
        /// <param name="expires">过期时间</param>
        public static void SetCookie(string cookieName, string value, DateTime expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie != null)
            {
                cookie.Value = value;
                cookie.Expires = expires;
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
            else
            {
                cookie = new HttpCookie(cookieName);
                cookie.Value = value;
                cookie.Expires = expires;
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }
        #endregion

        #region 添加Cookie
        /// <summary>
        /// 添加Cookie
        /// </summary>
        /// <param name="cookieName">Cookie名称</param>
        /// <param name="value">值</param>
        /// <param name="expires">过期时间</param>
        public static void AddCookie(string cookieName, string value, DateTime expires)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Value = value;
            cookie.Expires = expires;
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        #endregion

        #endregion
    }
}