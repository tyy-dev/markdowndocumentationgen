namespace documentationgenerator
{
    public enum MemberType
    {
        Namespace, // You can't add documentation comments to a namespace, but you can make cref ferences to them, where supported.
        Type, // A type is a class, interface, struct, enum, or delegate.
        Field,
        Property, // Includes indexers or other indexed properties.
        Method, // Includes special methods, such as constructors and operators.
        ConstructorMethod, // #CTOR
        Event,
        Error, // The rest of the string provides information about the error. The C# compiler generates error information for links that can't be resolved.
        InvalidMemberType
    }
}
