using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace TestProject.Models
{
    public class VoucherQuery : ApiQuery
    {
        public string voucherDateBegin { get; set; }
        public string voucherDateEnd { get; set; }
    }

    public interface ITVoucher
    {
        [StringLength(20)]
        public string TRANSACTION_ID { get; set; }
        [StringLength(20)]
        public string COMPANY_ID { get; set; }
        [StringLength(20)]
        public string PATIENT_ID { get; set; }
        [StringLength(20)]
        public string DOCTOR_ID { get; set; }
        [StringLength(20)]
        public string CONSULTATION_ID { get; set; }
        [StringLength(200)]
        public string CUSTOMER_NAME { get; set; }
        [StringLength(20)]
        public string REFERENCE_ID { get; set; }
        [StringLength(100)]
        public string VOUCHERCODE { get; set; }
        [StringLength(2000)]
        public string DESCRIPTION { get; set; }
        [StringLength(50)]
        public string VOUCHER_DATE { get; set; }
        [StringLength(50)]
        public string VOID_DATE { get; set; }
        [StringLength(20)]
        public string VOUCHER_LANGUAGE { get; set; }
        [StringLength(20)]
        public string STATUS { get; set; }
        [StringLength(50)]
        public string DATE_LAST_PRINT { get; set; }
        [StringLength(1000)]
        public string VOID_REASON { get; set; }

        [StringLength(20)]
        public string VOUCHER_ITEM_FORM { get; set; }
        [StringLength(2000)]
        public string VOUCHER_REMARK { get; set; }
        [StringLength(2000)]
        public string VOUCHER_DIAGNOSIS { get; set; }
        [StringLength(20)]
        public string VOUCHER_ID_REFERRED { get; set; }

        public string PID { get; set; }



#nullable enable

        public double? GRAND_TOTAL { get; set; }
        public int? IS_VOIDED { get; set; }

        public int? IS_BILLED { get; set; }
        public int? IS_PRINTED { get; set; }
        public double? PAID_TOTAL { get; set; }
        public int? DIS_SEQ { get; set; }
        public int? ISSYNC { get; set; }
        public double? BAL_BF { get; set; }
        public double? BAL_CF { get; set; }

        public double? DISPLAY_AMT_TOTAL { get; set; }
        public double? SERVICE_CHARGE_RATE { get; set; }

#nullable disable

        Dictionary<string, dynamic> ToJson();
    }

    [Table("T_VOUCHER")]
    public partial class TVoucher : DatabaseFields, ITVoucher
    {
        [StringLength(20)]
        public string TRANSACTION_ID { get; set; }
        [StringLength(20)]
        public string COMPANY_ID { get; set; }
        [StringLength(20)]
        public string PATIENT_ID { get; set; }
        [StringLength(20)]
        public string DOCTOR_ID { get; set; }
        [StringLength(20)]
        public string CONSULTATION_ID { get; set; }
        [StringLength(200)]
        public string CUSTOMER_NAME { get; set; }
        [StringLength(20)]
        public string REFERENCE_ID { get; set; }
        [StringLength(100)]
        public string VOUCHERCODE { get; set; }
        [StringLength(2000)]
        public string DESCRIPTION { get; set; }
        [StringLength(50)]
        public string VOUCHER_DATE { get; set; }
        [StringLength(50)]
        public string VOID_DATE { get; set; }
        [StringLength(20)]
        public string VOUCHER_LANGUAGE { get; set; }
        [StringLength(20)]
        public string STATUS { get; set; }
        [StringLength(50)]
        public string DATE_LAST_PRINT { get; set; }
        [StringLength(1000)]
        public string VOID_REASON { get; set; }

        [StringLength(20)]
        public string VOUCHER_ITEM_FORM { get; set; }
        [StringLength(2000)]
        public string VOUCHER_REMARK { get; set; }
        [StringLength(2000)]
        public string VOUCHER_DIAGNOSIS { get; set; }
        [StringLength(20)]
        public string VOUCHER_ID_REFERRED { get; set; }

        public string PID { get; set; }



#nullable enable

        public double? GRAND_TOTAL { get; set; }
        public int? IS_VOIDED { get; set; }

        public int? IS_BILLED { get; set; }
        public int? IS_PRINTED { get; set; }
        public double? PAID_TOTAL { get; set; }
        public int? DIS_SEQ { get; set; }
        public int? ISSYNC { get; set; }
        public double? BAL_BF { get; set; }
        public double? BAL_CF { get; set; }

        public double? DISPLAY_AMT_TOTAL { get; set; }
        public double? SERVICE_CHARGE_RATE { get; set; }

#nullable disable

        public Dictionary<string, dynamic> ToJson()
        {
            Dictionary<string, dynamic> map = _ToJson();

            map["pid"] = PID;
            map["transactionId"] = TRANSACTION_ID;
            map["companyId"] = COMPANY_ID;
            map["patientId"] = PATIENT_ID;
            map["doctorId"] = DOCTOR_ID;
            map["consultationId"] = CONSULTATION_ID;
            map["customerName"] = CUSTOMER_NAME;
            map["referenceId"] = REFERENCE_ID;
            map["voucherCode"] = VOUCHERCODE;
            map["description"] = DESCRIPTION;
            map["voucherDate"] = VOUCHER_DATE;
            map["grandTotal"] = GRAND_TOTAL;
            map["isVoided"] = IS_VOIDED;
            map["voidDate"] = VOID_DATE;
            map["voucherLanguage"] = VOUCHER_LANGUAGE;
            map["isBilled"] = IS_BILLED;
            map["status"] = STATUS;
            map["isPrinted"] = IS_PRINTED;
            map["dateLastPrint"] = DATE_LAST_PRINT;
            map["voidReason"] = VOID_REASON;
            map["paidTotal"] = PAID_TOTAL;
            map["voucherItemForm"] = VOUCHER_ITEM_FORM;
            map["voucherRemark"] = VOUCHER_REMARK;
            map["voucherDiagnosis"] = VOUCHER_DIAGNOSIS;
            map["voucherIdReferred"] = VOUCHER_ID_REFERRED;
            map["disSeq"] = DIS_SEQ;
            map["isSync"] = ISSYNC;
            map["balBf"] = BAL_BF;
            map["balCf"] = BAL_CF;
            map["displayAmtTotal"] = DISPLAY_AMT_TOTAL;
            map["serviceChargeRate"] = SERVICE_CHARGE_RATE;


            return map;
        }
    }

    public class VoucherPatientView : MPatientInfo, ITVoucher
    {
        public string TRANSACTION_ID { get; set; }
        public string PATIENT_ID { get; set; }
        public string CONSULTATION_ID { get; set; }
        public string CUSTOMER_NAME { get; set; }
        public string REFERENCE_ID { get; set; }
        public string VOUCHERCODE { get; set; }
        public string DESCRIPTION { get; set; }
        public string VOUCHER_DATE { get; set; }
        public string VOID_DATE { get; set; }
        public string VOUCHER_LANGUAGE { get; set; }
        public string STATUS { get; set; }
        public string DATE_LAST_PRINT { get; set; }
        public string VOID_REASON { get; set; }
        public string VOUCHER_ITEM_FORM { get; set; }
        public string VOUCHER_REMARK { get; set; }
        public string VOUCHER_DIAGNOSIS { get; set; }
        
        public string VOUCHER_ID_REFERRED { get; set; }



#nullable enable

        public double? GRAND_TOTAL { get; set; }
        public int? IS_VOIDED { get; set; }

        public int? IS_BILLED { get; set; }
        public int? IS_PRINTED { get; set; }
        public double? PAID_TOTAL { get; set; }
        public int? DIS_SEQ { get; set; }
        public int? ISSYNC { get; set; }
        public double? BAL_BF { get; set; }
        public double? BAL_CF { get; set; }

        public double? DISPLAY_AMT_TOTAL { get; set; }
        public double? SERVICE_CHARGE_RATE { get; set; }

#nullable disable

        public new Dictionary<string, dynamic> ToJson()
        {
            Dictionary<string, dynamic> map = base.ToJson();

            map["pid"] = PID;
            map["transactionId"] = TRANSACTION_ID;
            map["companyId"] = COMPANY_ID;
            map["patientId"] = PATIENT_ID;
            map["doctorId"] = DOCTOR_ID;
            map["consultationId"] = CONSULTATION_ID;
            map["customerName"] = CUSTOMER_NAME;
            map["referenceId"] = REFERENCE_ID;
            map["voucherCode"] = VOUCHERCODE;
            map["description"] = DESCRIPTION;
            map["voucherDate"] = VOUCHER_DATE;
            map["grandTotal"] = GRAND_TOTAL;
            map["isVoided"] = IS_VOIDED;
            map["voidDate"] = VOID_DATE;
            map["voucherLanguage"] = VOUCHER_LANGUAGE;
            map["isBilled"] = IS_BILLED;
            map["status"] = STATUS;
            map["isPrinted"] = IS_PRINTED;
            map["dateLastPrint"] = DATE_LAST_PRINT;
            map["voidReason"] = VOID_REASON;
            map["paidTotal"] = PAID_TOTAL;
            map["voucherItemForm"] = VOUCHER_ITEM_FORM;
            map["voucherRemark"] = VOUCHER_REMARK;
            map["voucherDiagnosis"] = VOUCHER_DIAGNOSIS;
            map["voucherIdReferred"] = VOUCHER_ID_REFERRED;
            map["disSeq"] = DIS_SEQ;
            map["isSync"] = ISSYNC;
            map["balBf"] = BAL_BF;
            map["balCf"] = BAL_CF;
            map["displayAmtTotal"] = DISPLAY_AMT_TOTAL;
            map["serviceChargeRate"] = SERVICE_CHARGE_RATE;

            return map;
        }
    }

    

    
}