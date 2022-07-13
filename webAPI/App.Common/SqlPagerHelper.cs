using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Text;

namespace App.Common
{
    public class SqlPagerHelper
    {
        public static string GetDataPageSQL(string pStrSelectName, string pStrSortName, string pStrSortType, string pStrTable, string pStrWhere, int pIntPageIndex, int pIntPageSize)
        {
            string strSql = "SELECT * FROM (SELECT ROW_NUMBER() OVER (ORDER BY " + pStrSortName + " " + pStrSortType + ") AS Row," + pStrSelectName + " FROM " + pStrTable + " WHERE " + pStrWhere
            + ") T WHERE Row BETWEEN (" + pIntPageIndex + " - 1) * " + pIntPageSize + " + 1 and " + pIntPageIndex + "*" + pIntPageSize + " ; " ;
            return strSql;
        }

        public static string GetDataPageCountSQL(string pStrTable, string pStrWhere, string strPKName, int pIntPageIndex, int pIntPageSize)
        {
            string strSql = " SELECT ISNULL(COUNT(" + strPKName + "), 0) AS cCount FROM " + pStrTable + " WHERE " + pStrWhere;
            return strSql;
        }
    }
}
