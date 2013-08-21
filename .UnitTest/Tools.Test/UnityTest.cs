using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Practices.Unity;
using TestUnity;

namespace TestUnity.Test
{
#region class User - under test
    public interface IDateTimeManager
    {
        DateTime Now();
    }

    public class DateTimeManager:IDateTimeManager
    {
        public DateTime Now() { return DateTime.Now; }
    }

    public class User_CtorDependency
    {
        public IDateTimeManager DateTimeManager { get; set; }
        public DateTime CreationDate { get; set; }

        [InjectionConstructor]      //optional ici, required if mutiple constructors
        public User_CtorDependency(IDateTimeManager dateTimeManager)
        {
            DateTimeManager = dateTimeManager;
            CreationDate = dateTimeManager.Now();
        }
    }

    public class User_PropertyDependency
    {
        public DateTime CreationDate { get; set; }
        
        private IDateTimeManager _dateTimeManager;

        [Dependency]
        public IDateTimeManager DateTimeManager
        {
            get { return _dateTimeManager; }
            set { _dateTimeManager = value; }
        }
        
        public User_PropertyDependency()
        {
            //CreationDate = DateTimeManager.Now(); //impossible ici, DateTimeManager n'est setted que lors de l'appel explicite du setter
        }
    }

    public class User_MethodDependency
    {
        public DateTime CreationDate { get; set; }

        private IDateTimeManager _dateTimeManager;

        [InjectionMethod]
        public void Initialize(IDateTimeManager value)
        {
            _dateTimeManager = value;
        }

        public IDateTimeManager GetDateTimeManager() {
            return _dateTimeManager;
        }

        public User_MethodDependency()
        {
            //CreationDate = _dateTimeManager.Now();
        }
    }
#endregion

    [TestClass]
    public class UnitTest1
    {
        #region Unity Resolve DateTimeManager with real type
        [TestMethod]
        public void InjectionConstructor()
        {
            var container = new UnityContainer();

            container.RegisterType<IDateTimeManager, DateTimeManager>();

            var dateTimeManager = container.Resolve<IDateTimeManager>();
            var user = container.Resolve<User_CtorDependency>();
            Assert.IsInstanceOfType(user.DateTimeManager, typeof(DateTimeManager));
        }

        [TestMethod]
        public void PropertyDependency()
        {
            var container = new UnityContainer();

            container.RegisterType<IDateTimeManager, DateTimeManager>();

            var dateTimeManager = container.Resolve<IDateTimeManager>();
            var user = container.Resolve<User_PropertyDependency>();
            Assert.IsInstanceOfType(user.DateTimeManager, typeof(DateTimeManager));
        }

        [TestMethod]
        public void MethodDependency()
        {
            var container = new UnityContainer();

            container.RegisterType<IDateTimeManager, DateTimeManager>();

            var dateTimeManager = container.Resolve<IDateTimeManager>();
            var user = container.Resolve<User_MethodDependency>();
            Assert.IsInstanceOfType(user.GetDateTimeManager(), typeof(DateTimeManager));
        }

        [TestMethod]
        public void PerThreadLifetimeManager()
        {
            var container = new UnityContainer();

            container.RegisterType<IDateTimeManager, DateTimeManager>(new PerThreadLifetimeManager());

            var dateTimeManager = container.Resolve<IDateTimeManager>();
            var user1 = container.Resolve<User_CtorDependency>();
            var user2 = container.Resolve<User_CtorDependency>();
            Assert.AreSame(user1.DateTimeManager, user2.DateTimeManager);
        }
        #endregion

        [TestMethod]
        public void UserCtor_ShouldSetCreationDate()
        {
            var container = new UnityContainer();

            DateTime date1 = new DateTime(2013, 03, 23);
            Moq.Mock<IDateTimeManager> mockDate = new Moq.Mock<IDateTimeManager>();
            mockDate.Setup(x => x.Now()).Returns(date1);
            container.RegisterInstance<IDateTimeManager>(mockDate.Object);
            var user = container.Resolve<User_CtorDependency>();
            Assert.AreEqual(date1, user.CreationDate);
        }

        //TODO: automock

    }
}
