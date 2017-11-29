using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using ReflexCommon;

namespace MobileData
{
    public enum EnumComponentType
    {
        Labour = 'L',
        Equipment = 'E',
        Material = 'M',
        Subcontract = 'S',
        Other = 'O'
    }

    public class FieldPODetail
    {
        public int Id;
        public int CompanyId;

        public int POId;
        public int LineNum;
        public string Description;

        public int? Level1Id;
        public int? Level2Id;
        public int? Level3Id;
        public int? Level4Id;
        public EnumComponentType Component;
        public bool Billable;
        public decimal Amount;

        public FieldPODetail()
        {
        }

        public FieldPODetail(DataRow row)
        {
            Id = Convert.ToInt32(row["Id"]);
            CompanyId = Convert.ToInt32(row["CompanyId"]);
            POId = Convert.ToInt32(row["POId"]);
            LineNum = Convert.ToInt16(row["LineNum"]);
            Description = Convert.ToString(row["Description"]);
            Level1Id = ConvertEx.ToNullable<int>(row["Level1Code"]);
            Level2Id = ConvertEx.ToNullable<int>(row["Level2Code"]);
            Level3Id = ConvertEx.ToNullable<int>(row["Level3Code"]);
            Level4Id = ConvertEx.ToNullable<int>(row["Level4Code"]);
            Component = ConvertEx.CharToEnum<EnumComponentType>(row["Component"]);
            Billable = Convert.ToBoolean(row["Billable"]);
            Amount = Convert.ToDecimal(row["Amount"]);
        }

        public static int SqlInsert(int poId, int lineNum, string desc, int? level1Id, int? level2Id, int? level3Id, int? level4Id, EnumComponentType component, bool billable, decimal amount)
        {
            string sql = $"insert FieldPODetail(CompanyId, POId, LineNum, Description, Level1Code, Level2Code, Level3Code, Level4Code, Component, Billable, Amount) " +
                $"values({Company.CurrentId}, {poId}, {lineNum}, '{desc}', {StrEx.ValueOrNull(level1Id)}, {StrEx.ValueOrNull(level2Id)}," +
                $" {StrEx.ValueOrNull(level3Id)}, {StrEx.ValueOrNull(level4Id)}, '{(char)component}', '{billable}', {amount}); " +
                $"Select CAST(SCOPE_IDENTITY() AS INT);";

            return Convert.ToInt32(MobileCommon.ExecuteScalar(sql));
        }

        public static void SqlUpdate(int id, string desc, int? level1Id, int? level2Id, int? level3Id, int? level4Id, EnumComponentType component, bool billable, decimal amount)
        {
            string sql = $"update FieldPODetail set Description='{desc}', Level1Code={StrEx.ValueOrNull(level1Id)}, Level2Code={StrEx.ValueOrNull(level2Id)}, " +
                $"Level3Code={StrEx.ValueOrNull(level3Id)}, Level4Code={StrEx.ValueOrNull(level4Id)}, Component='{(char)component}', Billable='{billable}', Amount={amount} where id={id} ";

            MobileCommon.ExecuteNonQuery(sql);
        }

        public static void SqlUpdateLineNum(int id, int lineNum)
        {
            string sql = $"update FieldPODetail set LineNum={lineNum} where id={id} ";

            MobileCommon.ExecuteNonQuery(sql);
        }

        public static void SqlDelete(int id)
        {
            string sql = $"delete FieldPODetail where id={id}";
            MobileCommon.ExecuteNonQuery(sql);
        }
    }
}
