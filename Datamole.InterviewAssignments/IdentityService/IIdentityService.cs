using System.Collections.Generic;
using Datamole.InterviewAssignments.IdentityService.Models;

namespace Datamole.InterviewAssignments.IdentityService
{
    public interface IIdentityService
    {
        RegistrationResult Register(string userName, string password, IDictionary<string, string> properties = null);
        AuthenticationResult Authenticate(string userName, string password);
        void SaveToJson(string pathToJsonFile, bool overwrite = false);
    }
}