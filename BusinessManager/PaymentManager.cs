using System;
using System.Collections.Generic;
using DataLayer;
using BusinessObject;

namespace BusinessManager
{
    [Obsolete]
    public class PaymentManager
    {
        public static void Add(Payment payment)
        {
            if (payment == null)
            {
                throw new ArgumentException("payment is null.");
            }

            PaymentDB.Add(payment);
        }

        public static void Update(Payment payment)
        {
            if (payment == null)
            {
                throw new ArgumentException("rresult is null.");
            }

            if (payment.Id == null || payment.Id == default)
            {
                throw new ArgumentException("payment.Id value not set.");
            }

            PaymentDB.Update(payment);
        }

        public static void Delete(Payment payment)
        {
            if (payment == null)
            {
                throw new ArgumentException("payment is null.");
            }

            if (payment.Id == null || payment.Id == default)
            {
                throw new ArgumentException("rresult.Id value not set.");
            }

            PaymentDB.Delete(payment);
        }

        public static Payment GetById(Guid id)
        {
            Payment payment = PaymentDB.GetById(id);
            return payment;
        }

        public static Payment GetByUserId(Guid UserId)
        {
            Payment payment = PaymentDB.GetByUserId(UserId);
            return payment;
        }

        public static List<Payment> GetAll()
        {
            return PaymentDB.GetAll();
        }

        public static System.Data.DataSet Getdataset()
        {
            return PaymentDB.Getdataset();
        }

        public static List<Payment> Search(string word)
        {
            return PaymentDB.Search(word);
        }

    }
}