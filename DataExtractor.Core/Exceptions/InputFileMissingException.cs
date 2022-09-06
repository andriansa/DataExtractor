// --------------------------------------------------------------------------------------------------------------------
// <copyright file="InputFileMissingException.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the InputFileMissingException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataExtractor.Core.Exceptions;

public sealed class InputFileMissingException : Exception
{
	public InputFileMissingException(string message) : base(message)
	{
	}
}
