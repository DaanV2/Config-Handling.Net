using DaanV2.Config;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Config.Test
{
    [TestClass]
    public partial class ConfigMapperTest
    {
        [TestMethod]
        public void TestPresistance()
        {
            FakeConfig Config = ConfigMapper.Get<FakeConfig>(false);
            Assert.IsFalse(ConfigMapper.Configs.ContainsKey(Config.GetType()), "Presistance avoidance failed");

            Config = (FakeConfig)ConfigMapper.Get(typeof(FakeConfig), false);
            Assert.IsFalse(ConfigMapper.Configs.ContainsKey(Config.GetType()), "Presistance avoidance failed");

            Config = ConfigMapper.Get<FakeConfig>();
            Assert.IsTrue(ConfigMapper.Configs.ContainsKey(Config.GetType()), "Presistance failed");
        }
    }
}
