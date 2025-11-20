using System.Collections.Generic;

namespace JOS.Enumeration.SourceGenerator;

/// <summary>
/// Interface for generating type-specific code in enumeration implementations.
/// </summary>
internal interface IValueTypeCodeGenerator
{
    /// <summary>
    /// Generates the body of the FromValue method for a specific value type.
    /// </summary>
    string GenerateFromValueMethodBody(
        EnumerationValue value, 
        IEnumerable<EnumerationItem> items, 
        string symbolName);

    /// <summary>
    /// Generates the body of the FromValue (out parameter) method for a specific value type.
    /// </summary>
    string GenerateFromValueOutMethodBody(
        EnumerationValue value, 
        IEnumerable<EnumerationItem> items);

    /// <summary>
    /// Generates the body of the TryParse method for a specific value type.
    /// </summary>
    string GenerateTryParseMethodBody(
        EnumerationValue enumeration, 
        string? formatProvider);
}
