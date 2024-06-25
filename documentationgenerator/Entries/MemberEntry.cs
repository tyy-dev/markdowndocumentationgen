using System;
using System.Xml.Linq;

namespace documentationgenerator.Entries
{
    /// <summary>
    /// Represents a member entry.
    /// </summary>
    /// <typeinfo>public class</typeinfo>
    public class MemberEntry : RootEntry
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberEntry"/> class.
        /// </summary>
        /// <param name="element">The XElement containing the member entry.</param>
        /// <typeinfo>public</typeinfo>
        public MemberEntry(XElement element) : base(element) { }

        /// <summary>
        /// Gets the raw name attribute value from the XElement.
        /// </summary>
        /// <remarks>
        /// This property retrieves the "name" attribute value from the XElement. Returns <c>string.Empty</c> if the attribute is not present.
        /// </remarks>
        /// <typeinfo>public string</typeinfo>
        public string raw => this.GetAttribute("name")?.Value ?? string.Empty;

        /// <summary>
        /// Gets the processed name of the member, excluding the type prefix.
        /// </summary>
        /// <remarks>
        /// This property extracts the member name from <see cref="raw"/>, excluding the initial type prefix if present. Returns <c>string.Empty</c> if <see cref="raw"/> is null.
        /// </remarks>
        /// <typeinfo>public string</typeinfo>
        public string name => this.raw?.Replace($"{this.type}:", "") ?? string.Empty;

        /// Gets the summary content for the member.
        /// </summary>
        /// <remarks>
        /// This property retrieves the content of the "summary" child element under the current XElement. Returns <c>string.Empty</c> if the element is not found.
        /// </remarks>
        /// <typeinfo>public string</typeinfo>
        public string summary => this.GetChild("summary")?.Value.Trim() ?? string.Empty;

        /// Gets the remarks content for the member.
        /// </summary>
        /// <remarks>
        /// This property retrieves the content of the "remarks" child element under the current XElement. Returns <c>string.Empty</c> if the element is not found.
        /// </remarks>
        /// <typeinfo>public string</typeinfo>
        public string remarks => this.GetChild("remarks")?.Value.Trim() ?? string.Empty;

        /// <summary>
        /// Gets additional type information for the member.
        /// </summary>
        /// <remarks>
        /// This property retrieves the content of the "typeinfo" child element under the current XElement. Returns <c>string.Empty</c> if the element is not found.
        /// </remarks>
        /// <typeinfo>public string</typeinfo>
        public string typeinfo => this.GetChild("typeinfo")?.Value.Trim() ?? string.Empty;

        /// <summary>
        /// Gets the return value description for the member.
        /// </summary>
        /// <remarks>
        /// This property retrieves the content of the "returns" child element under the current XElement. Returns <c>string.Empty</c> if the element is not found.
        /// </remarks>
        /// <typeinfo>public string</typeinfo>
        public string returns => this.GetChild("returns")?.Value.Trim() ?? string.Empty;

        /// <summary>
        /// Gets the type identifier character from <see cref="raw"/>.
        /// </summary>
        /// <remarks>
        /// This property extracts the first character from <see cref="raw"/>. Returns null if <see cref="raw"/> is null or empty.
        /// </remarks>
        /// <typeinfo>public char?</typeinfo>
        public char? type => this.raw?[0] ?? null;

        /// <summary>
        /// Retrieves parameter types from the 'name' property of the current instance.
        /// Assumes the 'name' follows a method signature format. Returns an enumerable
        /// of parameter types extracted from the method signature.
        /// </summary>
        /// <returns>An enumerable of strings representing parameter types.</returns>
        /// <typeinfo>public IEnumerable&lt;string></typeinfo>
        public IEnumerable<string> GetParameterTypes() => this.name.Split('(').Last().TrimEnd(')').Split(",");

        /// <summary>
        /// Retrieves child elements named "param" and constructs <see cref="MemberParam"/> objects based on them.
        /// Each <see cref="MemberParam"/> object consists of a name, value, and parameter type obtained from
        /// the corresponding position in the method signature extracted by GetParameterTypes().
        /// </summary>
        /// <remarks>
        /// Uses GetParameterTypes() to determine the parameter types for each <see cref="MemberParam"/> object.
        /// </remarks>
        /// <returns>An enumerable of <see cref="MemberParam"/> objects.</returns>
        /// <typeinfo>public IEnumerable&lt;MemberParam></typeinfo>
        public IEnumerable<MemberParam> parameters {
            get {
                if (this.GetMemberType() != MemberType.Method && this.GetMemberType() != MemberType.ConstructorMethod)
                    return [];

                return this.GetChildren("param")?.Select((param, index) => new MemberParam(
                    param.Attribute("name")?.Value.Trim() ?? string.Empty,
                    param.Value.Trim(),
                    this.GetParameterTypes().ToArray()[index])) ?? [];
            }
        }
           

        /// <summary>
        /// Determines the type of the member based on its identifier character.
        /// </summary>
        /// <remarks>
        /// This method identifies the type of the member based on the first character of <see cref="raw"/>.
        /// </remarks>
        /// <returns>The type of the member as a <see cref="MemberType"/> enum value.</returns>
        /// <typeinfo>public MemberType</typeinfo>
        public MemberType GetMemberType() {
            MemberType memberType = this.type switch {
                'N' => MemberType.Namespace,
                'T' => MemberType.Type,
                'F' => MemberType.Field,
                'P' => MemberType.Property,
                'M' => MemberType.Method,
                'E' => MemberType.Event,
                '!' => MemberType.Error,
                _ => MemberType.InvalidMemberType,
            };

            if (memberType == MemberType.Method && this.name.Contains(".#ctor"))
                return MemberType.ConstructorMethod;

            return memberType;
        }

        /// <summary>
        /// Validates the member entry. It does this by checking whether the element is null or not, and it makes sure it has an valid member type.
        /// </summary>
        /// <returns>True if the member entry is valid; otherwise, false.</returns>
        /// <typeinfo>public bool</typeinfo>
        public bool Validate() => this.raw != null && this.GetMemberType() != MemberType.InvalidMemberType;
    }
}
