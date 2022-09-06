// <copyright file="DataFieldTypeInvalidException.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the DataFieldTypeInvalidException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataExtractor.Core.Exceptions;

public sealed class DataFieldTypeInvalidException : Exception
{
	public DataFieldTypeInvalidException(string message) : base(message)
	{
	}
}

