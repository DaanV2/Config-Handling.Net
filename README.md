# ConfigHandling.Net

ConfigHandling.Net takes care of all your config or options objects.
It takes care of saving, loading, and persistence of objects in memory.
Config objects are saved in a centralized location.

**Table of contents**
- [ConfigHandling.Net](#confighandlingnet)
- [Compile](#compile)
	- [For .Net Core](#for-net-core)
	- [Compatiblity](#compatiblity)
- [Usage](#usage)
	- [INewConfig](#inewconfig)
	- [Config Objects](#config-objects)
		- [Customizing the XML](#customizing-the-xml)
		- [Customizing the JSON](#customizing-the-json)
			- [For .Net Framework](#for-net-framework)
			- [For .Net Core](#for-net-core-1)
		- [Example](#example)
- [Problems](#problems)
   
# Compile

## For .Net Core

To compile for .net Core add an conditional compilation symbol named: 'NETCORE'.  
Found under Properties -> Build.

## Compatiblity

The **C#** code is .Net 4.8 and .Net-Core 3.1 Compatible

# Usage

## INewConfig

This interface allows the programmer to create a config file for when the config files are missing or never have been given. The interface only adds one method: **SetNewInformation()**

This method is called upon when the system detects that it's missing the config file. It then initializes a new instance of that config type and checks whether or not it has implemented the interface. If it has **SetNewInformation()** is called. In this method, the programmer can put down which default values need to be filled in. If the interface has not been implemented, the system creates a config file based upon a normally constructed object of that type.

The reason it is recommended you always use this interface comes from the amount of data that is sometimes assigned to the properties of the config object.
It not necessary to initialize all its default values every time with preset values.

## Config Objects

**Table of contents**
- [ConfigHandling.Net](#confighandlingnet)
- [Compile](#compile)
	- [For .Net Core](#for-net-core)
	- [Compatiblity](#compatiblity)
- [Usage](#usage)
	- [INewConfig](#inewconfig)
	- [Config Objects](#config-objects)
		- [Customizing the XML](#customizing-the-xml)
		- [Customizing the JSON](#customizing-the-json)
			- [For .Net Framework](#for-net-framework)
			- [For .Net Core](#for-net-core-1)
		- [Example](#example)
- [Problems](#problems)

### Customizing the XML
To customize how your data is saved, you can use the XML serialization attributes or use the IXMLSerializable Interface to expand your data handling further.
To customize config objects use the following directions: [XML Attributes MSDN](https://docs.microsoft.com/en-us/dotnet/standard/serialization/controlling-xml-serialization-using-attributes)

### Customizing the JSON

#### For .Net Framework
The .Net framework version of this library uses the DataContractJsonSerializer. When .Net framework 5 drops, this will be replaced with the new JSON system.
To customize config objects use the following directions: [How to use DataContractJsonSerializer](https://docs.microsoft.com/en-us/dotnet/framework/wcf/feature-details/how-to-serialize-and-deserialize-json-data)

#### For .Net Core
The .Net core version uses the new System.Text.Json serialization. To customize config objects use the following directions: [Customize JSON names and values](https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to?view=netcore-3.1#customize-json-names-and-values)

### Example

This ExampleConfig class has 3 properties that get saved to a JSON file.
* The class gets save to: "%Config Folder%\DaanV2\General\Example Config.config"
* INewConfig is implemented so that when ConfigMapper needs to create the fill, the object gets filled with default values.

**Class file of ExampleConfig**
```cs
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using DaanV2.Config;

[Config("Example Config", "DaanV2\\General")]
[Serializable, DataContract]
public class ExampleConfig : INewConfig {
    /// <summary>Creates a new instance of <see cref="ExampleConfig"/></summary>
    public ExampleConfig() {
        this.MultiThread = false;
        this.TrimData = false;
        this.DefaultValues = new List<string>();
    }

    /// <summary>Some property for the config</summary>
    [DataMember]
    public Boolean MultiThread { get; set; }

    /// <summary>Some property for the config</summary>
    [DataMember]
    public Boolean TrimData { get; set; }

    /// <summary>Some property for the config</summary>
    [DataMember]
    public List<String> DefaultValues { get; set; }

    /// <summary>Fills the object with default values when the ConfigMapper cannot find the file containing the data</summary>
    public void SetNewInformation() {
        this.MultiThread = true;
        this.TrimData = true;
        this.DefaultValues = new List<string>() {
            "Foo",
            "Bar"
        };
    }
}
```

**JSON file of ExampleConfig**
JSON
{
    "MultiThread": true,
    "TrimData": true,
    "DefaultValues": [ "Foo", "Bar" ]
}
```

## Configuring the system
The ConfigMapper reads its options from the ConfigLoader class. Which reads it value from a config.ini file.
If it does not exist, then it is created with default values. This file is written to the same folder as the executing program.

**Default config.ini file**
```ini
Config Extension=.config
Config Folder=\configs\
Config Serializer Name=json
```

# Problems

If any problem is arising, then explore the possibility of preloading the system. Either through a task or just call one of the following methods:

|Name|Description|
|---|---|
|ConfigOptions.Preload|Causes a 10 ms delay while the config.ini file is loaded/created and set.|
|ConfigLoader.Preload|Causes a 20 ms delay while it calls **ConfigOptions.Preload**, and initializes it own internal serialization factories.|
|ConfigMapper.Preload|Causes a 30 ms delay while it calls **ConfigLoader.Preload**, after which it starts on reflecting on all loaded assemblies and collect all config objects marked as config objects, whereby each config gets loaded into memory and files created if missing.|

If problems persist report them as issues to the [repository](https://github.com/DaanV2/Config-Handling.Net)
