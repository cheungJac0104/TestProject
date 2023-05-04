using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProject.Models
{
    public class InventoryTransQuery : ApiQuery
    {

        public string DateBegin { get; set; }

        public string DateEnd { get; set; }

        public string TransType { get; set; }
    }

    public class InventoryTransList
    {
        public string Inventory_ID { get; set; }
        public string Item_ID { get; set; }
        public string Item_ENAME { get; set; }
        public decimal? QTY_Changes { get; set; }
        public string Trans_Type { get; set; }
        public DateTime cutOffDate { get; set; }
    }

    [Table("T_INVENTORY_TRANS")]
    public class TInventoryTrans : DatabaseFields
    {

        [JsonPropertyName("inventoryId")]
        public string INVENTORY_ID { get; set; }
        [JsonPropertyName("qtyOriginal")]
        public double QTY_ORIGINAL { get; set; } = 0;
        [JsonPropertyName("qtyAdjusted")]
        public double QTY_ADJUSTED { get; set; } = 0;
        [JsonPropertyName("qtyChanges")]
        public double QTY_CHANGES { get; set; } = 0;
        [JsonPropertyName("dateTrans")]
        public string DATE_TRANS { get; set; }

#nullable enable
        [JsonPropertyName("transType")]
        public string? TRANS_TYPE { get; set; }
        [JsonPropertyName("qtyOnhold")]
        public double? QTY_ONHOLD { get; set; } = 0;
        public string? REMARK { get; set; }
        public double? DEBIT { get; set; } = 0;
        public double? CREDIT { get; set; } = 0;
        [JsonPropertyName("referenceId")]
        public string? REFERENCE_ID { get; set; }
        [JsonPropertyName("partyId")]
        public string? PARTY_ID { get; set; }

        public Dictionary<string, dynamic> ToJson()
        {
            Dictionary<string, dynamic> map = _ToJson();
            map["inventoryId"] = INVENTORY_ID;
            map["qtyOriginal"] = QTY_ORIGINAL;
            map["qtyAdjusted"] = QTY_ADJUSTED;
            map["qtyChanges"] = QTY_CHANGES;
            map["dateTrans"] = DATE_TRANS;
            map["transType"] = TRANS_TYPE;
            map["qtyOnhold"] = QTY_ONHOLD;
            map["remark"] = REMARK;
            map["debit"] = DEBIT;
            map["credit"] = CREDIT;
            map["referenceId"] = REFERENCE_ID;
            map["partyId"] = PARTY_ID;
            
            return map;
        }

#nullable disable
        public bool IsAdjustment() {
          return TRANS_TYPE == "ADJUSTMENT";
        }
    }

 


}
