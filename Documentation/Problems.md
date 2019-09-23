# Problems

If any problem is arising then explore the possiblity of preloading the system. either through a task or just calling one of the follow methods:

|Name|Description|
|---|---|
|ConfigOptions.Preload|Causes a 10 ms delay while the config.ini file is loaded/created and set.|
|ConfigLoader.Preload|Causes a 20 ms delay while it calls **ConfigOptions.Preload**, and initializes it own internal serialization factories.|
|ConfigMapper.Preload|Causes a 30 ms delay while it calls **ConfigLoader.Preload**, after which it starts on reflecting on all loaded assemblies and collect all config objects marked as config objects, whereby each config gets loaded into memory and files created if missing.|

If problems still presist report them as issues to the [repository](https://github.com/DaanV2/Config-Handling.Net)
