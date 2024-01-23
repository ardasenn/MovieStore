using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities.Constants
{
    public class Messages
    {
        public const string AddSucceeded = "Add operation successful";
        public const string UpdateSucceeded = "Update operation successful";
        public const string DeleteSucceeded = "Delete operation successful";
        public const string Exist = "Record already exists";
        public const string NotExist = "Record does not exist";
        public const string SaveFail = "An error occurred while saving the record";
        public const string Fail = "An error occurred during the operation";
        public const string LoginFail = "Incorrect email or password";
        public const string IdFail = "Incorrect or missing ID";
        public const string BalanceFail = "Not enough money in your account";
    }
}
