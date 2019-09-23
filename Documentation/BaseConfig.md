# BaseConfig\<ConfigType>

The BaseConfig\<ConfigType> abstract class is a piece of code to allow the programmer to be a bit more lazy.
Simply add the BaseConfig\<ConfigType> to whatever class has an config object as a property. 
The BaseConfig\<ConfigType> adds an property called 'Config' of the given type.
Its base constructor also request the config from the config mapper.

## Example

```C#
public class Foo : BaseConfig<BarConfig> {
    //Call the base constructor to initialize the config property.
    public Foo() : base() {
        //...
    }
}
```
