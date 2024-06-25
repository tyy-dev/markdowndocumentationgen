using System.Xml;
using System.Xml.Linq;

namespace documentationgenerator.Entries
{
    public class AssemblyEntry(XElement element) : RootEntry(element)
    {
        public string? name => this.GetChild("name")?.Value;
    }
}
