using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebService.Handler;

namespace WebService.Controller
{
    public class TransactionController
    {
        public static string InsertHeader(string userId)
        {
            int userIntId = -1;
            try
            {
                userIntId = int.Parse(userId);
            }catch(Exception e)
            {
                return "Please input a validation!";
            }

            TransactionHandler.InsertHeader(userIntId);
            return "";
        }

        public static List<TransactionHeader> GetHeader(string userId)
        {
            int intUserId = -1;
            try
            {
                intUserId = int.Parse(userId);
            }catch(Exception e)
            {
                return null;
            }
            return TransactionHandler.GetHeader(intUserId);
        }

        public static List<TransactionDetail> GetDetail(string headerId)
        {
            int intHeaderId = -1;
            try
            {
                intHeaderId = int.Parse(headerId);
            }
            catch (Exception e)
            {
                return null;
            }

            return TransactionHandler.GetDetail(intHeaderId);
        }



        public static string InsertDetail(string headerId, string gameId)
        {
            int headerIntId = -1;
            int gameIntId = -1;
            try
            {
                headerIntId = int.Parse(headerId);
                gameIntId = int.Parse(gameId);
            }
            catch (Exception e)
            {
                return "Please input a validation!";
            }

            TransactionHandler.InsertDetail(headerIntId, gameIntId);
            return "";
        }
    }
}