using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProject.Models
{


    [Table("M_INVENTORY")]
    public class MInventory : DatabaseFields
    {
        [JsonPropertyName("itemId")]
        public string ITEM_ID { get; set; }

#nullable enable 
        [JsonPropertyName("companyId")]
        public string? COMPANY_ID { get; set; }
        [JsonPropertyName("supplierId")]
        public string? SUPPLIER_ID { get; set; }
        [JsonPropertyName("locationId")]
        public string? LOCATION_ID { get; set; }
        [JsonPropertyName("orderId")]
        public string? ORDER_ID { get; set; }
        [JsonPropertyName("invoiceId")]
        public string? INVOICE_ID { get; set; }
        public string? OWNER { get; set; }
        [JsonPropertyName("qtyStockin")]
        public double? QTY_STOCKIN { get; set; }
        [JsonPropertyName("qtyStockout")]
        public double? QTY_STOCKOUT { get; set; }
        [JsonPropertyName("qtyAvailable")]
        public double? QTY_AVAILABLE { get; set; }
        [JsonPropertyName("qtyOnhold")]
        public double? QTY_ONHOLD { get; set; }
        [JsonPropertyName("unitCost")]
        public double? UNIT_COST { get; set; }
        public string? DISCRIPTION { get; set; }
        [JsonPropertyName("dateStockin")]
        public string? DATE_STOCKIN { get; set; }
        [JsonPropertyName("deliveryNote")]
        public string? DELIVERY_NOTE { get; set; }
        [JsonPropertyName("dateExpiry")]
        public string? DATE_EXPIRY { get; set; }
        [JsonPropertyName("isOverdraft")]
        public int? IS_OVERDRAFT { get; set; }
        [JsonPropertyName("totalCost")]
        public double? TOTAL_COST { get; set; }

        public Dictionary<string, dynamic> ToJson()
        {
            Dictionary<string, dynamic> map = _ToJson();
            map["itemId"] = ITEM_ID;
            map["companyId"] = COMPANY_ID;
            map["supplierId"] = SUPPLIER_ID;
            map["locationId"] = LOCATION_ID;
            map["orderId"] = ORDER_ID;
            map["invoiceId"] = INVOICE_ID;
            map["owner"] = OWNER;
            map["qtyStockin"] = QTY_STOCKIN;
            map["qtyStockout"] = QTY_STOCKOUT;
            map["qtyAvailable"] = QTY_AVAILABLE;
            map["qtyOnhold"] = QTY_ONHOLD;
            map["unitCost"] = UNIT_COST;
            map["description"] = DISCRIPTION;
            map["dateStockin"] = DATE_STOCKIN;
            map["deliveryNote"] = DELIVERY_NOTE;
            map["dateExpiry"] = DATE_EXPIRY;
            map["isOverdraft"] = IS_OVERDRAFT;
            map["totalCost"] = TOTAL_COST;
            return map;
        }

#nullable disable

    }


}
