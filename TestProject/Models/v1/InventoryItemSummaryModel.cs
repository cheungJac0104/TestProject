using System;
namespace TestProject.Models.v1
{

    public class InventoryItemSummaryQuery: ApiQuery
    {
        public string CutOffDate { get; set; }
    }

	public class InventoryItemSummaryModel
    {
        public string Item_Id { get; set; }

		public string Item_EName { get; set; }

		public decimal? Stack { get; set; }

		public DateTime CutOffDate { get; set; }

        public Dictionary<string, dynamic> ToJson()
        {
            Dictionary<string, dynamic> map = new();

            map["ItemId"] = this.Item_Id;
            map["ItemName"] = this.Item_EName;
            map["Stack"] = this.Stack;
            map["CutOffDate"] = this.CutOffDate;

            return map;
        }
    }

	
}

