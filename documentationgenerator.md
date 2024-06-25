<a name='assembly'></a>
# documentationgenerator
---
<a name='T:documentationgenerator.Entries.MemberEntry'></a>
### documentationgenerator.Entries.MemberEntry `Type` `public class`
#### Summary
Represents a member entry.

---
<a name='M:documentationgenerator.Entries.MemberEntry.#ctor(System.Xml.Linq.XElement)'></a>
### documentationgenerator.Entries.MemberEntry.#ctor(System.Xml.Linq.XElement) `ConstructorMethod` `public`
#### Summary
Initializes a new instance of the  class.
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| element | System.Xml.Linq.XElement | The XElement containing the member entry.

---
<a name='P:documentationgenerator.Entries.MemberEntry.raw'></a>
### documentationgenerator.Entries.MemberEntry.raw `Property` `public string`
#### Summary
Gets the raw name attribute value from the XElement.
#### Remarks
This property retrieves the "name" attribute value from the XElement. Returns string.Empty if the attribute is not present.

---
<a name='P:documentationgenerator.Entries.MemberEntry.name'></a>
### documentationgenerator.Entries.MemberEntry.name `Property` `public string`
#### Summary
Gets the processed name of the member, excluding the type prefix.
#### Remarks
This property extracts the member name from , excluding the initial type prefix if present. Returns string.Empty if  is null.

---
<a name='P:documentationgenerator.Entries.MemberEntry.typeinfo'></a>
### documentationgenerator.Entries.MemberEntry.typeinfo `Property` `public string`
#### Summary
Gets additional type information for the member.
#### Remarks
This property retrieves the content of the "typeinfo" child element under the current XElement. Returns string.Empty if the element is not found.

---
<a name='P:documentationgenerator.Entries.MemberEntry.returns'></a>
### documentationgenerator.Entries.MemberEntry.returns `Property` `public string`
#### Summary
Gets the return value description for the member.
#### Remarks
This property retrieves the content of the "returns" child element under the current XElement. Returns string.Empty if the element is not found.

---
<a name='P:documentationgenerator.Entries.MemberEntry.type'></a>
### documentationgenerator.Entries.MemberEntry.type `Property` `public char?`
#### Summary
Gets the type identifier character from .
#### Remarks
This property extracts the first character from . Returns null if  is null or empty.

---
<a name='M:documentationgenerator.Entries.MemberEntry.GetParameterTypes'></a>
### documentationgenerator.Entries.MemberEntry.GetParameterTypes `Method` `public IEnumerable<string>`
#### Summary
Retrieves parameter types from the 'name' property of the current instance.
            Assumes the 'name' follows a method signature format. Returns an enumerable
            of parameter types extracted from the method signature.
#### Returns
An enumerable of strings representing parameter types.

---
<a name='P:documentationgenerator.Entries.MemberEntry.parameters'></a>
### documentationgenerator.Entries.MemberEntry.parameters `Property` `public IEnumerable<MemberParam>`
#### Summary
Retrieves child elements named "param" and constructs  objects based on them.
            Each  object consists of a name, value, and parameter type obtained from
            the corresponding position in the method signature extracted by GetParameterTypes().
#### Remarks
Uses GetParameterTypes() to determine the parameter types for each  object.
#### Returns
An enumerable of  objects.

---
<a name='M:documentationgenerator.Entries.MemberEntry.GetMemberType'></a>
### documentationgenerator.Entries.MemberEntry.GetMemberType `Method` `public MemberType`
#### Summary
Determines the type of the member based on its identifier character.
#### Remarks
This method identifies the type of the member based on the first character of .
#### Returns
The type of the member as a  enum value.

---
<a name='M:documentationgenerator.Entries.MemberEntry.Validate'></a>
### documentationgenerator.Entries.MemberEntry.Validate `Method` `public bool`
#### Summary
Validates the member entry. It does this by checking whether the element is null or not, and it makes sure it has an valid member type.
#### Returns
True if the member entry is valid; otherwise, false.

---
<a name='M:documentationgenerator.Entries.RootEntry.Validate(System.String,System.String@)'></a>
### documentationgenerator.Entries.RootEntry.Validate(System.String,System.String@) `Method`
#### Summary
s
#### Parameters
| Name | Type | Description |
| ---- | ---- | ----------- |
| name | System.String | 
| arg | System.String@ | 

---
