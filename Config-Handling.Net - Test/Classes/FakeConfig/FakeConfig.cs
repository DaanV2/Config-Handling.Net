using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using DaanV2.Config;

namespace Config.Test {
    ///DOLATER <summary>add description for class: FakeConfig</summary>
    [Config("Fake Config", "Somepath\\Hello")]
    public partial class FakeConfig : INewConfig {

        [DataMember]
        public Boolean Test { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public void SetNewInformation() {
            this.Test = true;
        }

        /// <summary>
        /// 
        /// </summary>
        public FakeConfig() {
            this.Test = false;
        }
    }
}
