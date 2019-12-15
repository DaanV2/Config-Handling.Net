# ConfigHandling.Net

**Table of contents**
- [ConfigHandling.Net](#confighandlingnet)
  - [Compile](#compile)
    - [For .Net Core](#for-net-core)
  - [Compatiblity](#compatiblity)
  - [Overview](#overview)
- [Usage](#usage)
  - [INewConfig](#inewconfig)
  - [Config Objects](#config-objects)
    - [Customizing the XML](#customizing-the-xml)
    - [Customizing the JSON](#customizing-the-json)
      - [For .Net Framework](#for-net-framework)
      - [For .Net Core](#for-net-core-1)
    - [Example](#example)
  - [Configurating the system](#configurating-the-system)
  - [Problems](#problems)

ConfigHandling.Net takes care of all your config or options objects.
It takes care of saving, loading, and persistence of objects in memory.
Config objects are saved in a centralized location.
It also provides a general config object that can store a string under a specified key

## Compile

### For .Net Core

To compile for .net Core add an conditional compilation symbol named: 'NETCORE'.  
Found under Properties -> Build.

## Compatiblity

The **C#** code is .Net 4.8 and .Net-Core 3.1 Compatible

## Overview

TODO add more text  
![Graph](https://raw.githubusercontent.com/DaanV2/ConfigHandling.Net-Master/master/Documentation/Graph%20Overview.png)


# Usage

* [Config Objects](./Documentation/ConfigObjects.md)

## INewConfig

This interface allows the programmer to easier create config file for when the config files are missing or never given. The interface only adds one method: **SetNewInformation()**

This method is called upon when the system detects that its missing the config file. It then initializes a new instance of that config type and checks wheter or not it has implemented the interface. If it has **SetNewInformation()** is called. In this method the programmer can put down which default values need to be filled in. If the interface has not been implemented the system will save a config file based upon the empty object.

The reason it is recommend you always use this interface, comes from the amount of data that is sometimes assigned to the properties of the config object.
It not nesscary to initialize all its default values every time with preset values.

## Config Objects

**Table of contents**
- [ConfigHandling.Net](#confighandlingnet)
  - [Compile](#compile)
    - [For .Net Core](#for-net-core)
  - [Compatiblity](#compatiblity)
  - [Overview](#overview)
- [Usage](#usage)
  - [INewConfig](#inewconfig)
  - [Config Objects](#config-objects)
    - [Customizing the XML](#customizing-the-xml)
    - [Customizing the JSON](#customizing-the-json)
      - [For .Net Framework](#for-net-framework)
      - [For .Net Core](#for-net-core-1)
    - [Example](#example)
  - [Configurating the system](#configurating-the-system)
  - [Problems](#problems)

### Customizing the XML
To customize how your data is saved, you can use the XML serialization attributes or use the IXMLSerializable Interface to further expand your data handling.
To customize config objects use the following directions: [XML Attributes MSDN](https://docs.microsoft.com/en-us/dotnet/standard/serialization/controlling-xml-serialization-using-attributes)

### Customizing the JSON

#### For .Net Framework
The .Net framework version of this library uses the DataContractJsonSerializer, When .Net framework 5 drops this will be repalced with the new JSON system.
To customize config objects use the following directions: [How to use DataContractJsonSerializer](https://docs.microsoft.com/en-us/dotnet/framework/wcf/feature-details/how-to-serialize-and-deserialize-json-data)

#### For .Net Core
The .Net core version uses the new System.Text.Json serialization. To customize config objects use the following directions: [Customize JSON names and values](https://docs.microsoft.com/en-us/dotnet/standard/serialization/system-text-json-how-to?view=netcore-3.1#customize-json-names-and-values)

### Example

This ExampleConfig class has 3 properties that get saved to a json file.
* The class gets save to: %Config Folder%\DaanV2\General\Example Config.config
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

**Json file of ExampleConfig**
```Json
{
	"MultiThread": true,
	"TrimData": true,
	"DefaultValues": [ "Foo", "Bar" ]
}
```

## Configurating the system
The ConfigMapper reads it options from the ConfigLoader class. Which reads it value from an config.ini file.
if it does not exist then it is created with default values. This file is saved in the save folder as the executing program.

**Default config.ini file**
```ini
Config Extension=.config
Config Folder=\configs\
Config Serializer Name=json
```

## Problems

If any problem is arising then explore the possiblity of preloading the system. either through a task or just calling one of the follow methods:

|Name|Description|
|---|---|
|ConfigOptions.Preload|Causes a 10 ms delay while the config.ini file is loaded/created and set.|
|ConfigLoader.Preload|Causes a 20 ms delay while it calls **ConfigOptions.Preload**, and initializes it own internal serialization factories.|
|ConfigMapper.Preload|Causes a 30 ms delay while it calls **ConfigLoader.Preload**, after which it starts on reflecting on all loaded assemblies and collect all config objects marked as config objects, whereby each config gets loaded into memory and files created if missing.|

If problems still presist report them as issues to the [repository](https://github.com/DaanV2/Config-Handling.Net)
