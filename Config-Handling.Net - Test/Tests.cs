using DaanV2.Config;
using NUnit.Framework;

namespace Config.Test {
    public partial class Tests {
        [SetUp]
        public void Setup() {
            ConfigMapper.Preload();
        }

        [Test]
        public void TestAttribute() {
            ConfigAttribute Atr = new ConfigAttribute("Line1", "Line2", "Line3");

            if (Atr.Category == Atr.Name || Atr.Category == Atr.SubFolder || Atr.Name == Atr.SubFolder)
                Assert.Fail();
            
            Assert.Pass();
        }

        [Test]
        public void TestAttribute2() {
            ConfigAttribute Atr = new ConfigAttribute("Line1", "Line2");

            if (Atr.Category == Atr.Name || Atr.Category != Atr.SubFolder || Atr.Name == Atr.SubFolder)
                Assert.Fail();

            Assert.Pass();
        }

        [Test]
        public void RetrieveConfig() {
            FakeConfig Config = new FakeConfig();
            FakeConfig RetrievedConfig = ConfigMapper.Get<FakeConfig>();

            if (Config.Test == RetrievedConfig.Test)
                Assert.Fail();

            Assert.Pass();
        }
    }
}