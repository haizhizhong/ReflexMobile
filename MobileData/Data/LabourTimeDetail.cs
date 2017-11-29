using System;
using System.Data;
using ReflexCommon;

namespace MobileData
{
    public class LabourTimeDetail     //WS_EMP_TimeClockHours
    {
        public int DetailId;
        public int CompanyId;
        public int EntryId;
        public int TimeCodeId;
        public decimal? BillRate;
        public decimal? WorkHours;
        public decimal? Amount;

        public LabourTimeDetail()
        {
        }

        public LabourTimeDetail(DataRow row)
        {
            DetailId = (int)row["DetailId"];
            CompanyId = Convert.ToInt32(row["CompanyId"]);
            EntryId = (int)row["EntryId"];
            TimeCodeId = (int)row["TimeCodeId"];
            BillRate = ConvertEx.ToNullable<decimal>(row["BillRate"]);        // EnumValueType.Hours
            WorkHours = ConvertEx.ToNullable<decimal>(row["WorkHours"]);      // EnumValueType.Hours
            Amount = ConvertEx.ToNullable<decimal>(row["Amount"]);            // EnumValueType.Dollars
        }

        public static int SqlInsert(int entryId, int timecodeId, decimal? billRate, decimal? workHours, decimal? amount)
        {
            string sql = $"Insert LabourTimeDetail(CompanyId, EntryId, TimeCodeId, BillRate, WorkHours, Amount) " +
                $"values({Company.CurrentId}, {entryId}, {timecodeId}, {StrEx.ValueOrNull(billRate)}, {StrEx.ValueOrNull(workHours)}, {StrEx.ValueOrNull(amount)}); " +
                $"Select CAST(SCOPE_IDENTITY() AS INT);";

            return Convert.ToInt32(MobileCommon.ExecuteScalar(sql));
        }

        public static void SqlUpdateBillRate(int entryId, int timecodeId, decimal? billRate)
        {
            string sql = $"update LabourTimeDetail set BillRate={StrEx.ValueOrNull(billRate)} where EntryId={entryId} and TimeCodeId={timecodeId}";

            MobileCommon.ExecuteNonQuery(sql);
        }

        public static void SqlUpdateHours(int entryId, int timecodeId, decimal workHours)
        {
            string sql = $"update LabourTimeDetail set WorkHours={workHours} where EntryId={entryId} and TimeCodeId={timecodeId}";

            MobileCommon.ExecuteNonQuery(sql);
        }

        public static void SqlUpdateAmount(int entryId, int timecodeId, decimal amount)
        {
            string sql = $"update LabourTimeDetail set Amount={amount} where EntryId={entryId} and TimeCodeId={timecodeId}";

            MobileCommon.ExecuteNonQuery(sql);
        }
    }
}
