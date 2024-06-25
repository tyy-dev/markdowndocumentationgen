using System.Xml;
using System.Xml.Linq;

namespace documentationgenerator.Entries
{
    public class RootEntry(XElement root)
    {
        public XElement element { get; } = root;

        public XElement? GetChild(XName name) => this.element.Element(name);
        public IEnumerable<XElement>? GetChildren(XName name) => this.element.Elements(name);

        public XAttribute? GetAttribute(XName name) => this.element.Attribute(name);
        public IEnumerable<XAttribute>? GetAttributes(XName name) => this.element.Attributes(name);

        /// <summary>
        /// s
        /// </summary>
        /// <param name="name"></param>
        /// <param name="arg"></param>
        /// <returns></returns>
        public bool Validate(string name, ref string arg) => name == this.element.Name && this.element != null;
    }
}
