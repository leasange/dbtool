using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oracle.DataAccess.Client;

namespace DbTool.DbClasses
{
    public class DbTypeConverter
    {
        private static Dictionary<string, OracleDbType> OracleDbTypeDics = new Dictionary<string, OracleDbType>();
        static DbTypeConverter()
        {
            OracleDbTypeDics.Add("BFILE", OracleDbType.BFile);
            OracleDbTypeDics.Add("BINARY ROWID", OracleDbType.Varchar2);
            OracleDbTypeDics.Add("BINARY_DOUBLE", OracleDbType.BinaryDouble);
            OracleDbTypeDics.Add("BINARY_FLOAT", OracleDbType.BinaryFloat);
            OracleDbTypeDics.Add("BLOB", OracleDbType.Blob);
            OracleDbTypeDics.Add("CANONICAL", OracleDbType.Char);
            OracleDbTypeDics.Add("CFILE", OracleDbType.BFile);
            OracleDbTypeDics.Add("CHAR", OracleDbType.Char);
            OracleDbTypeDics.Add("CLOB", OracleDbType.Clob);
            OracleDbTypeDics.Add("NCLOB", OracleDbType.NClob);
            OracleDbTypeDics.Add("CONTIGUOUS ARRAY", OracleDbType.Blob);
            OracleDbTypeDics.Add("DATE", OracleDbType.Date);
            OracleDbTypeDics.Add("DECIMAL", OracleDbType.Decimal);
            OracleDbTypeDics.Add("DOUBLE PRECISION", OracleDbType.Double);
            OracleDbTypeDics.Add("FLOAT", OracleDbType.Decimal);
            OracleDbTypeDics.Add("INTEGER", OracleDbType.Int32);
            OracleDbTypeDics.Add("INTERVAL DAY(2) TO SECOND(6)", OracleDbType.IntervalDS);
            OracleDbTypeDics.Add("INTERVAL DAY TO SECOND", OracleDbType.IntervalDS);
            OracleDbTypeDics.Add("INTERVAL YEAR(2) TO MONTH", OracleDbType.IntervalYM);
            OracleDbTypeDics.Add("INTERVAL YEAR TO MONTH", OracleDbType.IntervalYM);
            OracleDbTypeDics.Add("LOB POINTER", OracleDbType.Object);
            OracleDbTypeDics.Add("NAMED COLLECTION", OracleDbType.Array);
            OracleDbTypeDics.Add("NAMED OBJECT", OracleDbType.Object);
            OracleDbTypeDics.Add("NUMBER", OracleDbType.Decimal);
            OracleDbTypeDics.Add("OCTET", OracleDbType.Byte);
            OracleDbTypeDics.Add("OID", OracleDbType.Char);
            OracleDbTypeDics.Add("BINARY INTEGER", OracleDbType.BinaryFloat);
            OracleDbTypeDics.Add("BOOLEAN", OracleDbType.Decimal);
            OracleDbTypeDics.Add("COLLECTION", OracleDbType.Array);
            OracleDbTypeDics.Add("LONG", OracleDbType.Long);
            OracleDbTypeDics.Add("LONG RAW", OracleDbType.LongRaw);
            OracleDbTypeDics.Add("NATURAL", OracleDbType.Char);
            OracleDbTypeDics.Add("NATURALN", OracleDbType.NChar);
            OracleDbTypeDics.Add("PLS INTEGER", OracleDbType.Int32);
            OracleDbTypeDics.Add("POSITIVE", OracleDbType.Object);
            OracleDbTypeDics.Add("POSITIVEN", OracleDbType.Object);
            OracleDbTypeDics.Add("RECORD", OracleDbType.Object);
            OracleDbTypeDics.Add("REF CURSOR", OracleDbType.RefCursor);
            OracleDbTypeDics.Add("ROWID", OracleDbType.Varchar2);
            OracleDbTypeDics.Add("STRING", OracleDbType.NVarchar2);
            OracleDbTypeDics.Add("POINTER", OracleDbType.Varchar2);
            OracleDbTypeDics.Add("RAW", OracleDbType.Raw);
            OracleDbTypeDics.Add("REAL", OracleDbType.Decimal);
            OracleDbTypeDics.Add("REF", OracleDbType.Ref);
            OracleDbTypeDics.Add("SIGNED BINARY INTEGER(16)", OracleDbType.Blob);
            OracleDbTypeDics.Add("SIGNED BINARY INTEGER(32)", OracleDbType.Blob);
            OracleDbTypeDics.Add("SIGNED BINARY INTEGER(8)", OracleDbType.Blob);
            OracleDbTypeDics.Add("SMALLINT", OracleDbType.Int16);
            OracleDbTypeDics.Add("TABLE", OracleDbType.Char);
            OracleDbTypeDics.Add("TIME", OracleDbType.TimeStamp);
            OracleDbTypeDics.Add("TIME WITH TZ", OracleDbType.TimeStampTZ);
            OracleDbTypeDics.Add("TIMESTAMP", OracleDbType.TimeStamp);
            OracleDbTypeDics.Add("TIMESTAMP(6)", OracleDbType.TimeStamp);
            OracleDbTypeDics.Add("TIMESTAMP WITH LOCAL TZ", OracleDbType.TimeStampLTZ);
            OracleDbTypeDics.Add("TIMESTAMP(6) WITH LOCAL TIME ZONE", OracleDbType.TimeStampLTZ);
            OracleDbTypeDics.Add("TIMESTAMP WITH TZ", OracleDbType.TimeStampTZ);
            OracleDbTypeDics.Add("TIMESTAMP(6) WITH TIME ZONE", OracleDbType.TimeStampTZ);
            OracleDbTypeDics.Add("UNSIGNED BINARY INTEGER(16)", OracleDbType.Blob);
            OracleDbTypeDics.Add("UNSIGNED BINARY INTEGER(32)", OracleDbType.Blob);
            OracleDbTypeDics.Add("UNSIGNED BINARY INTEGER(8)", OracleDbType.Blob);
            OracleDbTypeDics.Add("UROWID", OracleDbType.Varchar2);
            OracleDbTypeDics.Add("VARCHAR", OracleDbType.Varchar2);
            OracleDbTypeDics.Add("VARCHAR2", OracleDbType.Varchar2);
            OracleDbTypeDics.Add("NVARCHAR2", OracleDbType.NVarchar2);
            OracleDbTypeDics.Add("VARYING ARRAY", OracleDbType.Array);
        }
        public static OracleDbType GetOracleDbType(string strDbType, MyDbType inType)
        {
            switch (inType)
            {
                case MyDbType.Oracle:
                    return DoOracleToOracle(strDbType);
                case MyDbType.MySql:
                    break;
                case MyDbType.SqlServer:
                    break;
                default:
                    break;
            }
            return OracleDbType.NVarchar2;
        }
        private static OracleDbType DoOracleToOracle(string strDbType)
        {
            try
            {
                return OracleDbTypeDics[strDbType];
            }
            catch (System.Exception ex)
            {
                return OracleDbType.Varchar2;
            }
            
        }
    }
}
