# ConfigHandling.Net
ConfigHandling.Net takes care of all your config or options objects. 
It takes care of saving, loading, and persistence of objects in memory. 
Config objects are saved in a centralized location.
It also provides a general config object that can store a string under a specified key

## Compatiblity

The **C#** code is .Net 4.7.2 and .Net-Core 2.1 Compatible  
The **C++** code is Visual C++ / C++/clr compatible  
The **VB** code is .Net 4.7.2 and .Net-Core 2.1 Compatible  

## Overview
TODO add more text  
![Graph](https://raw.githubusercontent.com/DaanV2/ConfigHandling.Net-Master/master/Documentation/Graph%20Overview.png)

## Implementation of the API

### Config Objects Prerequisites
Config objects can be from any type that must implements the SerializableAttribute.
To give the api additional information use the ConfigAttribute.

#### ConfigAttribute
The ConfigAttribute has 3 properties that can be filled in:

##### Name
The name of the config object that is responsible for the filename of the saved config, if left empty or null the name of the type is used.

##### Category
The category of the config object that is responsible for putting the object in different subfolders. if left empty or null then nothing is done.

## How to use:
Its recommend to not use any form of initializing the object used as config objects. but let the API handle creating/loading objects.
Loading of config should go through the static class **ConfigMapper** methods. the ConfigLoader is a class that handles loading and saving of config objects to/from the disk.


**C#**
```C#
FooBarConfig Config = ConfigMapper.Get<FoobarConfig>();
```
**C++/CLI**
```Cpp
FoobarConfig^ Config = Configmapper::Get<FoobarConfig^>();
```
**VB**
```VB
Dim Config As FoobarConfig = ConfigMapper.GetItem(FoobarConfig)
```

## Customizing the XML
To customize how your data is saved, you can use the XML serialization attributes or use the IXMLSerializable Interface to further expand your data handling.
[XML Attributes MSDN](https://docs.microsoft.com/en-us/dotnet/standard/serialization/controlling-xml-serialization-using-attributes)
