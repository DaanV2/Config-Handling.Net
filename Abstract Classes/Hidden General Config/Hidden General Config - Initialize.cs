//DOLATER prune namespace: DaanV2.Config
namespace DaanV2.Config {
    public abstract partial class HiddenGeneralConfig {
        ///DOLATER <summary>Add Description</summary>
        private HiddenGeneralConfig() {
            this._GeneralConfig = ConfigMapper.Get<GeneralConfig>();
        }
    }
}