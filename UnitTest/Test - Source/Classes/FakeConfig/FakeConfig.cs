using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using DaanV2.Config;

namespace Config.Test
{
    [Config("Fake Config", "Somepath\\Hello")]
    public partial class FakeConfig : INewConfig
    {

        [DataMember]
        public Boolean Test { get; set; }

        public void SetNewInformation()
        {
            this.Test = true;
        }

        public FakeConfig()
        {
            this.Test = false;
        }
    }
}
