# Keynan
A strongly-typed configuration management library for .NET projects

## What is Keynan?
Keynan is a library for creating strongly-typed configurations using C# Objects, a little bit of reflection magic, some mapping, and JSON serialization and deserialization. A developer can quickly create a C# object called a Configuration Group (CG) that defines settings as properties in a group, and can use this CG object to store and retrieve values from it during runtime, all the while maintaining type checking and eliminating the need for complex key-value pair checking. 

Keynan is currently in alpha. Use at your own risk, as source code is provided as-is.

## Why another configuration management solution?
Configuration management solutions for software projects suck. Too many projects I've seen use magic strings, JSON, XML, or some other text-based system praying that configuration is defined correctly and won't break at runtime. One problem seen in enterprise software projects is that a database is used to hold all of the key-value pairs that define configuration, making it difficult to manage and even find configuration keys that are applicable to a given section of the software. Keys using magic strings are easy to implement, however to managed them over the lifetime of a project is hell. Keynan is here to change that. 

The beauty of Keynan Configuration Groups is that they live in your source code, and you can compile them and use them within your application. Displaying and storing settings becomes so much easier and straightforward, as the Configuration Groups along with their Setting properties define what can be displayed and stored. As a project matures, you know exactly what settings exist, and how they are grouped together.

# Features
* Create strongly-typed Configuration Groups by implementing the abstract `BaseConfigurationGroup` class
* Support for the following settings types out of the box:
  * Booleans
  * Decimals
  * Email addresses
  * Hidden strings
  * Integers
  * Lists
  * Select and Multiple selection lists
  * Phone numbers
  * Strings
  * Text (including multi-line and HTML) settings
  * Uris
  * and more, by implementing the `BaseSetting` class
* Localization support

# Getting Started
In the `/Keynan.UnitTests/Example` folder, there is an example of how Keynan can be used. 

In short, you implement a concrete version of the object `BaseConfigurationGroup`, and create and assign Settings for your configuration group.



# The future
* A .NET Core version 
* Versioning of Configuration Groups within an application's life.
* Persistence of configuration information.

# Updates
Feel free to send pull requests. I will definitely consider them.

# Notes
* Implemented in .NET Standard 2.0
* There's no persistence capabilities, so you'll have to roll your own. Everything output is JSON, so it should be fairly straightforward.

# Licence
MIT License 