// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OutputFilePathMissingException.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the OutputFilePathMissingException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataExtractor.Core.Exceptions;

public sealed class OutputFilePathMissingException : Exception
{
	public OutputFilePathMissingException(string message) : base(message)
	{
	}
}

