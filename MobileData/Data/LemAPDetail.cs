using ReflexCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MobileData
{
    public class LemAPDetail //WS_FLEM_APDet_Get
    {
        public int Id;
        public int MatchId;
        public int CompanyId;
        public int LemAPId;

        public int LineNum;
        public string Description;
        public string Reference;
        public decimal Amount;
        public decimal MarkupPercent;
        public decimal MarkupAmount;
        public decimal BillAmount;

        public int? Level1Id;
        public int? Level2Id;
        public int? Level3Id;
        public int? Level4Id;

        public LemAPDetail()
        {
        }

        public LemAPDetail(DataRow r)
        {
            Id = Convert.ToInt32(r["Id"]);
            MatchId = Convert.ToInt32(r["MatchId"]);
            CompanyId = Convert.ToInt32(r["CompanyId"]);
            LemAPId = Convert.ToInt32(r["LemAPId"]);
            LineNum = Convert.ToInt32(r["LineNum"]);
            Description = Convert.ToString(r["Description"]);
            Reference = Convert.ToString(r["Reference"]);
            Amount = Convert.ToDecimal(r["Amount"]);
            MarkupPercent = Convert.ToDecimal(r["MarkupPercent"]);
            MarkupAmount = Convert.ToDecimal(r["MarkupAmount"]);
            BillAmount = Convert.ToDecimal(r["BillAmount"]);
            Level1Id = ConvertEx.ToNullable<int>(r["Level1Id"]);
            Level2Id = ConvertEx.ToNullable<int>(r["Level2Id"]);
            Level3Id = ConvertEx.ToNullable<int>(r["Level3Id"]);
            Level4Id = ConvertEx.ToNullable<int>(r["Level4Id"]);
        }

        public static List<LemAPDetail> GetLemAPDetails(int apId)
        {
            string sql = $"select * from LemAPDetail where LemAPId={apId}";
            DataTable table = MobileCommon.ExecuteDataAdapter(sql);
            return table.Select().Select(r => new LemAPDetail(r)).ToList();
        }
    }
}
