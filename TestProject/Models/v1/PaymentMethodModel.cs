using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestProject.Models
{


    [Table("M_PAYMENT_METHOD")]
    public class MPaymentMethod : DatabaseFields
    {



#nullable enable 
        [JsonPropertyName("eName")]
        public string? E_NAME { get; set; }

        [JsonPropertyName("cName")]
        public string? C_NAME { get; set; }

        [JsonPropertyName("methodType")]
        public string? METHOD_TYPE { get; set; }

        [JsonPropertyName("disSeq")]
        public string? DIS_SEQ { get; set; }



        public Dictionary<string, dynamic> ToJson()
        {
            Dictionary<string, dynamic> map = _ToJson();
            map["eName"] = E_NAME;
            map["cName"] = C_NAME;
            map["methodType"] = METHOD_TYPE;
            map["disSeq"] = DIS_SEQ;

            return map;
        }

#nullable disable 

    }

 


}
