// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MissingDataFieldException.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the MissingDataFieldException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataExtractor.Core.Exceptions;

public sealed class MissingDataFieldException : Exception
{
	public MissingDataFieldException(string message) : base(message)
	{
	}
}

