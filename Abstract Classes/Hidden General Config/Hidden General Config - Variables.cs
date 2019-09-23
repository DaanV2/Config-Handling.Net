using System.Runtime.Serialization;

namespace DaanV2.Config {
    public abstract partial class HiddenGeneralConfig {
        ///DOLATER <summary>Add Description</summary>
        [IgnoreDataMember]
        private GeneralConfig _GeneralConfig;
    }
}
