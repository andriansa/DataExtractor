// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractSizeFieldExtractor.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the ContractSizeFieldExtractor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using DataExtractor.Core.Exceptions;

namespace DataExtractor.Core.FileReader.Csv.Fields.Complex;

public sealed class ContractSizeFieldExtractor : TokenValueExtractor<double>
{
    public ContractSizeFieldExtractor(): base("PriceMultiplier") { }

    protected override double ParseValue(string tokenValue)
	{
        if (!double.TryParse(tokenValue, out var doubleValue))
        {
            throw new DataFieldTypeInvalidException($"The complex field {this.TokenName} value {tokenValue} is not {typeof(double).Name}");
        }

        return doubleValue;
    }
}
