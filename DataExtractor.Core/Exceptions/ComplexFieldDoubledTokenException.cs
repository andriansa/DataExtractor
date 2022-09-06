// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ComplexFieldDoubledTokenException.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the ComplexFieldDoubledTokenException type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace DataExtractor.Core.Exceptions;

public sealed class ComplexFieldDoubledTokenException : Exception
{
	public ComplexFieldDoubledTokenException(string message) : base(message)
	{
	}
}

