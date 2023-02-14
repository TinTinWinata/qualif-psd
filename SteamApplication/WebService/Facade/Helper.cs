using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebService.Facade
{
    public class Helper
    {
        public static string EMPTY = "";

        public static Entities db;

        public static Entities GetDb()
        {
            if (db == null) db = new Entities();
            return db;
        }

        public static void SaveDb()
        {
            try
            {
                db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                foreach (var entityValidationErrors in ex.EntityValidationErrors)
                {
                    foreach (var validationError in entityValidationErrors.ValidationErrors)
                    {
                        System.Diagnostics.Debug.WriteLine("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                    }
                }
            }
        }

    }
}