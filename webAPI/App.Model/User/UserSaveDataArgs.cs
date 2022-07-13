using System;
using System.Collections.Generic;
using System.Text;

namespace App.Model
{
    public class UserSaveDataArgs : UserGetDataResponse
    {
        public string Password { get; set; }

        public string CfmPassword { get; set; }

        public string OldPassword { get; set; }
    }
}
