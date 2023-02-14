using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Factory;

namespace WebService.Repository
{
    public class TransactionRepository
    {
        public static TransactionHeader InsertHeader(int userId)
        {
            return TransactionFactory.CreateHeader(userId);
        }
        public static List<TransactionHeader> GetHeader(int userId)
        {

            Entities db = new Entities();
            List<TransactionHeader> headerList = (from data in db.TransactionHeaders select data).Where(c => c.user_id == userId).ToList<TransactionHeader>();
            return headerList;
        }

        public static List<TransactionDetail> GetDetail(int headerId)
        {
            Entities db = new Entities();
            List<TransactionDetail> detailList = (from data in db.TransactionDetails select data).Where(c => c.transaction_id == headerId).ToList<TransactionDetail>();
            return detailList;
        }

        public static void InsertDetail(int headerId, int gameId)
        {
            TransactionFactory.CreateDetail(headerId, gameId);
        }
    }
}