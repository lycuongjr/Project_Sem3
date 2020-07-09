using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTM.Mgs.Common
{
   public class CommonConstants
    {
        public const int Default_PageSize = 10;
        public static string USER_SESSION = "USER_SESSION";
        public static string CartSession = "CartSession";
        public static string SESSION_CREDENTIALS = "SESSION_CREDENTIALS";
        public static string CurrentCulture { set; get; }
        public static string MEMBER_GROUP = "MEMBER";
        public static string ADMIN_GROUP = "ADMIN";
        public static string EMPLOYEE = "EMPLOYEE";
        public static string GIAM_DOC_GROUP = "GIAM_DOC";
        public static string MOD_GROUP = "MOD";
    }
}
