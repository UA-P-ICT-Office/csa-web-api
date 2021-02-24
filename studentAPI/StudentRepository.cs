using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace studentAPI.Models {
    public class StudentRepository : IDisposable{
        AcademicsEntities context = new AcademicsEntities();

        public STUDENT ValidateUser(string studEmail, string studPin) {
            return context.STUDENTs.FirstOrDefault(student =>
            student.FCEMAIL.Equals(studEmail, StringComparison.OrdinalIgnoreCase)
            && student.FCPIN == studPin);
        }

        public void Dispose() {
            context.Dispose();
        }
    }
}