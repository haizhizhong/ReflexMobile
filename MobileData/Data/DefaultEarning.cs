namespace MobileData
{
    public enum EnumEarningType
    {
        LOA = 'L',
        Travel = 'T',
        EmployeeEquipmentEarnings = 'E'
    };

    public class DefaultEarning
    {
        public int CompanyId;
        public int ProjectId;
        public int? Level1Id;
        public int? Level2Id;
        public int? Level3Id;
        public int? Level4Id;
        public EnumEarningType EarningType;
    }
}
