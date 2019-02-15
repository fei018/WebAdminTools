using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminToolsModel.Account;

namespace AdminToolsDAL.Account
{
    public class AccountDAL
    {
        /// <summary>
        /// 驗證LoginUser是否有效 in Database
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool IsValid(LoginUser user)
        {
            AdminToolsDB db = new AdminToolsDB();

            if (user == null) return false;
            if (string.IsNullOrWhiteSpace(user.Password)) return false;

            var u = db.Accounts.FirstOrDefault(x => x.UserName == user.UserName);
            if (u == null) return false;
            if (u.Password == user.Password) return true;
            return false;
        }
    }
}
