using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Repository;

namespace WebService.Handler
{
    public class TransactionHandler
    {
        public static TransactionHeader InsertHeader(int userId)
        {
            return TransactionRepository.InsertHeader(userId);
        }

        public static List<TransactionHeader> GetHeader(int userId)
        {
            return TransactionRepository.GetHeader(userId);
        }

        public static List<TransactionDetail> GetDetail(int headerId)
        {
            return TransactionRepository.GetDetail(headerId);
        }

        public static void InsertDetail(int headerId, int gameId)
        {
            TransactionRepository.InsertDetail(headerId, gameId);
        }
    }
}