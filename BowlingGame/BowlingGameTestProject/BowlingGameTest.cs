using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BowlingGame;

namespace BowlingGameTestProject
{
    /// <summary>
    /// BowlingGameTest 的摘要说明
    /// </summary>
    [TestClass]
    public class BowlingGameTest
    {
        public BowlingGameTest()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///获取或设置测试上下文，该上下文提供
        ///有关当前测试运行及其功能的信息。
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region 附加测试特性
        //
        // 编写测试时，可以使用以下附加特性:
        //
        // 在运行类中的第一个测试之前使用 ClassInitialize 运行代码
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // 在类中的所有测试都已运行之后使用 ClassCleanup 运行代码
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // 在运行每个测试之前，使用 TestInitialize 来运行代码
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // 在每个测试运行完之后，使用 TestCleanup 来运行代码
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        private Game game = new Game();
        private void RollMany(int n, int pins)
        {
            for (int times = 0; times < n; times++)
            {
                game.Roll(pins);
            }
        }

        private void RollSpare()
        {
            game.Roll(6);
            game.Roll(4);
        }

        private void RollStrike()
        {
            game.Roll(10);
        }

        [TestMethod]
        public void TestAllZero()
        {
            RollMany(0, 20);
            Assert.AreEqual(0, game.Score());
        }

        [TestMethod]
        public void TestAllOne()
        {
            RollMany(1, 20);

            Assert.AreEqual(20, game.Score());
        }

        [TestMethod]
        public void TestOneSpare()
        {
            RollSpare();
            game.Roll(4);
            RollMany(17, 0);

            Assert.AreEqual(18, game.Score());
        }

        [TestMethod]
        public void TestOneStrike()
        {
            RollStrike();
            game.Roll(3);
            game.Roll(4);
            RollMany(16, 0);
            Assert.AreEqual(24, game.Score());
        }

        [TestMethod]
        public void TestPerfectGame()
        {
            RollMany(12, 10);
            Assert.AreEqual(300, game.Score());
        }
    }
}
