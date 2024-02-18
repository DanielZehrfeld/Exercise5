using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Exercise5.Test.Utils
{
    [DebuggerStepThrough, DebuggerNonUserCode]
    public class Spec
    {
        [DebuggerStepThrough]
        [TestInitialize]
        public void SetUp()
        {
            EstablishContext();
            BecauseOf();
        }

        [DebuggerStepThrough]
        [TestCleanup]
        public void TearDown()
        {
            Cleanup();
        }

        /// <summary>
        /// Test setup. Place your initialization code here.
        /// </summary>
        [DebuggerStepThrough]
        protected virtual void EstablishContext() { }

        /// <summary>
        /// Test run. Place the tested method / action here.
        /// </summary>
        [DebuggerStepThrough]
        protected virtual void BecauseOf() { }

        /// <summary>
        /// Test clean. Close/delete files, close database connections ..
        /// </summary>
        [DebuggerStepThrough]
        protected virtual void Cleanup() { }
    }
}
