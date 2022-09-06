// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ContractSizeFieldExtractorTests.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the ContractSizeFieldExtractorTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using DataExtractor.Core.FileReader.Csv.Fields.Complex;

namespace DataExtractor.Core.UnitTests.FileReader.Csv.Fields.Complex;

using DataExtractor.Core.Exceptions;

public class ContractSizeFieldExtractorTests
{
	[Test]
	public void ExtractData_WhenValidTokenAndValue_ReturnDoubleValue()
	{
		var contractSizeFieldExtractor = new ContractSizeFieldExtractor();

		var value = contractSizeFieldExtractor.ExtractData("field1:value1|;field2:value1|;PriceMultiplier:20.0|;field4:value1|");

		Assert.That(value, Is.EqualTo(20.0));
	}

    [Test]
    public void ExtractData_WhenNoTokenValue_ReturnDataFieldTypeInvalidException()
    {
        var contractSizeFieldExtractor = new ContractSizeFieldExtractor();

        Assert.That(() => contractSizeFieldExtractor.ExtractData("field1:value1|;field2:value1|;PriceMultiplier:|;field4:value1|"), Throws.TypeOf<DataFieldTypeInvalidException>());
    }

    [Test]
    public void ExtractData_WhenDoubledToken_ReturnComplexFieldDoubledTokenException()
    {
        var contractSizeFieldExtractor = new ContractSizeFieldExtractor();

        Assert.That(() => contractSizeFieldExtractor.ExtractData("field1:value1|;PriceMultiplier:20.0|;PriceMultiplier:20.1|;field4:value1|"), Throws.TypeOf<ComplexFieldDoubledTokenException>());
    }

    [Test]
    public void ExtractData_WhenInvalidTokenValue_ReturnDataFieldTypeInvalidException()
    {
        var contractSizeFieldExtractor = new ContractSizeFieldExtractor();

        Assert.That(() => contractSizeFieldExtractor.ExtractData("field1:value1|;field2:value1|;PriceMultiplier:asd|;field4:value1|"), Throws.TypeOf<DataFieldTypeInvalidException>());
    }
}

