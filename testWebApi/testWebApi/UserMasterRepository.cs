using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using testWebApi;

namespace testWebApi {
    public class UserMasterRepository : IDisposable {
        SECURITY_DBEntities context = new SECURITY_DBEntities();

        public UserMaster ValidateUser(string username, string password) {
            return context.UserMasters.FirstOrDefault(user => 
            user.UserName.Equals(username, StringComparison.OrdinalIgnoreCase)
            && user.UserPassword == password);
        }

        public void Dispose() {
            context.Dispose();
        }
    }
}