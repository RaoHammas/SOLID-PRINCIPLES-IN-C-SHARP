using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLID_PRINCIPLES.O;

namespace SOLID_PRINCIPLES.L
{
    /// <summary>
    /// LISKOV SUBSTITUTION PRINCIPLE
    /// parent class of child class should be completely replaceable
    /// and avoid exceptions in child classes
    /// </summary>

    #region PROBLEM

    public abstract class BaseSubscriber
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public abstract void AccessToStandardPackage();
        public abstract void AccessToPremiumPackage();
    }

    public class StandardSubscriber : BaseSubscriber
    {
        public override void AccessToStandardPackage()
        {
            Console.WriteLine("Access to standard package is granted !");
        }

        //This is the problem parent class is not fully 
        // substitutable in this child class
        public override void AccessToPremiumPackage()
        {
            throw new NotImplementedException();
        }
    }

    public class PremiumSubscriber : BaseSubscriber
    {
        // Here although parent class is fully substituted but
        //logically is not correct because a user with premium package
        // don't need standard package
        public override void AccessToStandardPackage()
        {
            Console.WriteLine("Access to Standard package is granted !");
        }

        public override void AccessToPremiumPackage()
        {
            Console.WriteLine("Access to Premium package is granted !");
        }
    }

    #endregion


    #region SOLUTION

    public interface ISubscriber
    {
        void AccessToStandardPackage();
        void AccessToPremiumPackage();
    }


    public abstract class Subscriber : ISubscriber
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual void AccessToStandardPackage()
        {
        }

        public virtual void AccessToPremiumPackage()
        {
        }
    }

    public class StandardSubscriberL : Subscriber
    {
        public override void AccessToStandardPackage()
        {
            Console.WriteLine($"{Name} you have access to Standard Package!");
        }
    }

    public class PremiumSubscriberL : Subscriber
    {
        public override void AccessToPremiumPackage()
        {
            Console.WriteLine($"{Name} you have access to Standard Package!");
        }
    }

    #endregion

    public class LiskovPrinciple
    {
        private ISubscriber _subscriber;

        public LiskovPrinciple(ISubscriber subscriber)
        {
            _subscriber = subscriber;
        }

        public void TestPrinciple()
        {
            _subscriber = new StandardSubscriberL();
            _subscriber = new PremiumSubscriberL();

            _subscriber.AccessToPremiumPackage();
            _subscriber.AccessToStandardPackage();
        }
    }
}