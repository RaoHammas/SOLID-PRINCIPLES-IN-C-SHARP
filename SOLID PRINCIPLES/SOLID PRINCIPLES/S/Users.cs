using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_PRINCIPLES.S
{
    /// <summary>
    /// SINGLE RESPONSIBILITY PRINCIPLE
    /// A class should have one and only one reason to change.
    /// or a class should perform one and only one task related to itself.
    /// or a class should have attributes and behaviors related to itself only.
    /// </summary>

    #region PROBLEM

    public class User
    {
        public string Name { get; set; }
        public string Contact { get; set; }


        public void LoginUser(User user)
        {
            LogMessage("user login is called...");
        }

        public void SignUpUser(User user)
        {
            LogMessage("user signUp is called...");
        }

        // This method here violates the Single Responsibility Principle
        // Because this Logging has nothing to do with Users
        private void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
    } //end of class

    #endregion

    #region SOLUTION

    public interface ILog
    {
        void LogMessage(string message);
    }

    public class Log : ILog
    {
        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
    } //end of class

    public class UserSolution
    {
        private readonly ILog _log;
        public string Name { get; set; }
        public string Contact { get; set; }

        public UserSolution(ILog log)
        {
            _log = log;
        }

        public void LoginUser(UserSolution user)
        {
            _log.LogMessage("user login is called...");
        }

        public void SignUpUser(UserSolution user)
        {
            _log.LogMessage("user signUp is called...");
        }
    } //end of class

    #endregion
}