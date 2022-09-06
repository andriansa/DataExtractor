// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InputFilePathMissingException.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the InputFilePathMissingException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataExtractor.Core.Exceptions;

public sealed class InputFilePathMissingException : Exception
{
	public InputFilePathMissingException(string message) : base(message)
	{
	}
}

