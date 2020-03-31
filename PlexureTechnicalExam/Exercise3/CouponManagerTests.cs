using FakeItEasy;
using Microsoft.Extensions.Logging;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Exercise3
{
    [TestClass]
    public class CouponManagerTests
    {
        private ICouponProvider _fakeCouponProvider;
        private ILogger _fakeLogger;

        [TestInitialize]
        public void TestInit()
        {
            _fakeCouponProvider = A.Fake<ICouponProvider>();
            _fakeLogger = A.Fake<ILogger>();
        }

        [TestMethod]
        public async Task LoggerIsNull()
        {
            //Arrange
            _fakeLogger = null;

            //Act and Assert
            var ex = Assert.ThrowsException<ArgumentNullException>(() => new CouponManager(_fakeLogger, _fakeCouponProvider));
            Assert.AreEqual(ex.ParamName, "logger");
        }

        [TestMethod]
        public async Task CouponProviderIsNull()
        {
            //Arrange
            _fakeCouponProvider = null;

            //Act and Assert
            var ex = Assert.ThrowsException<ArgumentNullException>(() => new CouponManager(_fakeLogger, _fakeCouponProvider));
            Assert.AreEqual(ex.ParamName, "couponProvider");
        }

        [TestMethod]
        public async Task EvaluatorsAreNull()
        {
            //Arrange
            var couponManager = new CouponManager(_fakeLogger, _fakeCouponProvider);

            //Act and Assert
            var ex = await Assert.ThrowsExceptionAsync<ArgumentNullException>(() => couponManager.CanRedeemCoupon(Guid.NewGuid(), Guid.NewGuid(), null));
            Assert.AreEqual(ex.ParamName, "evaluators");
        }

        [TestMethod]
        public async Task NoCouponFound()
        {
            //Arrange
            A.CallTo(() => _fakeCouponProvider.Retrieve(Guid.NewGuid())).WithAnyArguments().Returns<Coupon>(null);
            var func = A.Fake<IEnumerable< Func<Coupon, Guid,bool>>>();

            var couponManager = new CouponManager(_fakeLogger, _fakeCouponProvider);

            //Act and Assert
            await Assert.ThrowsExceptionAsync<KeyNotFoundException>(() => couponManager.CanRedeemCoupon(Guid.NewGuid(), Guid.NewGuid(), func));
            
        }

        [TestMethod]
        public async Task WithCouponButNoEvaluator()
        {
            //Arrange
            var func = A.Fake<IEnumerable<Func<Coupon, Guid, bool>>>();
            //Assuming a coupon is found
            A.CallTo(() => _fakeCouponProvider.Retrieve(Guid.NewGuid())).WithAnyArguments().Returns<Coupon>(new Coupon());

            //Act
            var couponManager = new CouponManager(_fakeLogger, _fakeCouponProvider);
            var result = await couponManager.CanRedeemCoupon(Guid.NewGuid(), Guid.NewGuid(), func);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task WithCouponButFailingEvaluation()
        {
            //Arrange
            var fakeFuncs = A.CollectionOfFake<Func<Coupon, Guid, bool>>(10);
            //Assuming a coupon is found
            A.CallTo(() => _fakeCouponProvider.Retrieve(Guid.NewGuid())).WithAnyArguments().Returns<Coupon>(new Coupon());

      
            //Act
            var couponManager = new CouponManager(_fakeLogger, _fakeCouponProvider);
            var result = await couponManager.CanRedeemCoupon(Guid.NewGuid(), Guid.NewGuid(), fakeFuncs.AsEnumerable());

            //Assert
            Assert.IsFalse(result);
        }
    }
}
