using Oracle.ManagedDataAccess.Client;

namespace EZV.Utils
{
    public static class Extensions
    {

        public static void AddWithValue(this OracleParameterCollection cmd, string parameterName, object value)
        {
            cmd.Add(parameterName, value);
        }

    }
}
