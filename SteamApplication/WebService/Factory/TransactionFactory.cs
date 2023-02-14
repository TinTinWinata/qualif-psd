using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Factory
{
    public class TransactionFactory
    {
        public static TransactionHeader CreateHeader(int userId)
        {
            Entities db = new Entities();
            TransactionHeader transaction = new TransactionHeader();
            transaction.user_id = userId;
            transaction.date = DateTime.Now;

            db.TransactionHeaders.Add(transaction);
            db.SaveChanges();

            return transaction;
        }

        public static void CreateDetail(int headerId, int gameId)
        {
            Entities db = new Entities();
            TransactionDetail detail = new TransactionDetail();
            detail.game_id = gameId;
            detail.transaction_id = headerId;
            db.TransactionDetails.Add(detail);
            db.SaveChanges();
        }
    }
}