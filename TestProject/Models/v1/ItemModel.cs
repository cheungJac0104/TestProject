using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProject.Models
{


    [Table("M_ITEM")]
    public class MItem : DatabaseFields
    {

        public string ENAME { get; set; }
        [JsonPropertyName("itemType")]
        public string ITEM_TYPE { get; set; }

#nullable enable 
        [JsonPropertyName("companyId")]
        public string? COMPANY_ID { get; set; }
        [JsonPropertyName("doctorId")]
        public string? DOCTOR_ID { get; set; }

        public string? CNAME { get; set; }
        [JsonPropertyName("itemSubType")]
        
        public string? ITEM_SUB_TYPE { get; set; }
        [JsonPropertyName("itemCat")]
        public string? ITEM_CAT { get; set; }
        [JsonPropertyName("unitPriceRetail")]
        public double? UNIT_PRICE_RETAIL { get; set; }
        [JsonPropertyName("standardCost")]
        public double? STANDARD_COST { get; set; }
        [JsonPropertyName("qtyOnhand")]
        public double? QTY_ONHAND { get; set; }
        [JsonPropertyName("qtyRecall")]
        public double? QTY_RECALL { get; set; }
        [JsonPropertyName("qtyOnhold")]
        public double? QTY_ONHOLD { get; set; }
        [JsonPropertyName("qtyUsage")]
        public double? QTY_USAGE { get; set; }
        public string? UOM { get; set; }
        public string? REMARK { get; set; }
        
        

        public Dictionary<string, dynamic> ToJson()
        {
            Dictionary<string, dynamic> map = _ToJson();
            map["ename"] = ENAME;
            map["itemType"] = ITEM_TYPE;
            map["companyId"] = COMPANY_ID;
            map["doctorId"] = DOCTOR_ID;
            map["cname"] = CNAME;
            map["itemSubType"] = ITEM_SUB_TYPE;
            map["itemCat"] = ITEM_CAT;
            map["unitPriceRetail"] = UNIT_PRICE_RETAIL;
            map["standardCost"] = STANDARD_COST;
            map["qtyOnhand"] = QTY_ONHAND;
            map["qtyRecall"] = QTY_RECALL;
            map["qtyOnhold"] = QTY_ONHOLD;
            map["qtyUsage"] = QTY_USAGE;
            map["uom"] = UOM;
            map["remark"] = REMARK;
            
            return map;
        }

#nullable disable 

    }

 


}
