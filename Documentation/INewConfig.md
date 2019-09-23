# INewConfig

This interface allows the programmer to easier create config file for when the config files are missing or never given. The interface only adds one method: **SetNewInformation()**

This method is called upon when the system detects that its missing the config file. It then initializes a new instance of that config type and checks wheter or not it has implemented the interface. If it has **SetNewInformation()** is called. In this method the programmer can put down which default values need to be filled in. If the interface has not been implemented the system will save a config file based upon the empty object.

The reason it is recommend you always use this interface, comes from the amount of data that is sometimes assigned to the properties of the config object.
It not nesscary to initialize all its default values every time with preset values.
