using System;
using System.Data;

namespace BusinessObject
{
    public class Payment : BaseObject
    {
        #region Property

        public Guid Id { get; set; }

        public string PaymentType { get; set; }

        public decimal DopsitFee { get; set; }

        public string Remark { get; set; }

        public string Status { get; set; }

        public string Date { get; set; }

        public decimal ExtraValue { get; set; }

        public string Extra { get; set; }

        public Guid UserId { get; set; }

        public int Code { get; set; }

        #endregion


        #region Method
        public Payment()
            : base()
        {
        }


        public Payment(IDataReader reader)
            : base(reader)
        {
            Id = DBNull.Value != reader["Id"] ? (Guid)reader["Id"] : default;
            PaymentType = DBNull.Value != reader["PaymentType"] ? (string)reader["PaymentType"] : default;
            DopsitFee = DBNull.Value != reader["DopsitFee"] ? (decimal)reader["DopsitFee"] : default;
            Remark = DBNull.Value != reader["Remark"] ? (string)reader["Remark"] : default;
            Status = DBNull.Value != reader["Status"] ? (string)reader["Status"] : default;
            Date = DBNull.Value != reader["Date"] ? (string)reader["Date"] : default;
            ExtraValue = DBNull.Value != reader["ExtraValue"] ? (decimal)reader["ExtraValue"] : default;
            Extra = DBNull.Value != reader["Extra"] ? (string)reader["Extra"] : default;
            Code = DBNull.Value != reader["Code"] ? (int)reader["Code"] : default;
        }
        #endregion
    }
}
