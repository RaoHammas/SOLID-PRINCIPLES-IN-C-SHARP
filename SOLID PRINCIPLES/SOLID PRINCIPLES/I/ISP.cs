using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_PRINCIPLES.I
{
    /// <summary>
    /// INTERFACE SEGREGATION PRINCIPLE
    /// 
    /// </summary>
    interface IUser
    {
        void Login();
        void SignUp();
        void Log(); // this is the problem
    }

    // this is Solution should have a separate interface
    interface ILogger
    {
        void Log();
    }
}