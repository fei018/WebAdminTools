using System;
using System.Collections.Generic;
using System.Linq;
using AdminToolsModel.CSPCall;
using System.Data.Entity.Migrations;

namespace AdminToolsDAL.CSPCall
{
    public class CSPCallDAL
    {
        private AdminToolsDB _db = new AdminToolsDB();

        public List<CSPCallDetails> GetTableList()
        {
            
            var list = _db.CSPCall.ToList();
            return list;
        }

        public int AddOrUpdateCall(CSPCallDetails call)
        {
            try
            {
                _db.CSPCall.AddOrUpdate(call);
                return _db.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteCall(int id)
        {
            try
            {
                var c = _db.CSPCall.Find(id);
                if (c != null)
                {
                    _db.CSPCall.Remove(c);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}