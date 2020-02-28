using DaanV2.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Config.Test {
    [TestClass]
    public partial class Tests {
        [TestInitialize]
        public void Setup() {
            ConfigMapper.Preload();
        }

        [TestMethod]
        public void TestAttribute() {
            ConfigAttribute Atr = new ConfigAttribute("Line1", "Line2", "Line3");

            if (Atr.Category == Atr.Name || Atr.Category == Atr.SubFolder || Atr.Name == Atr.SubFolder)
                Assert.Fail();
        }

        [TestMethod]
        public void TestAttribute2() {
            ConfigAttribute Atr = new ConfigAttribute("Line1", "Line2");

            if (Atr.Category == Atr.Name || Atr.Category != Atr.SubFolder || Atr.Name == Atr.SubFolder)
                Assert.Fail();
        }

        [TestMethod]
        public void RetrieveConfig() {
            FakeConfig Config = new FakeConfig();
            FakeConfig RetrievedConfig = ConfigMapper.Get<FakeConfig>();

            if (Config.Test == RetrievedConfig.Test)
                Assert.Fail();
        }
    }
}