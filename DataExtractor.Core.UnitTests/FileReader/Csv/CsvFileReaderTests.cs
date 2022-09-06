// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CsvFileReaderTests.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the CsvFileReaderTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Globalization;
using System.Text;

using CsvHelper;

using DataExtractor.Core.FileReader.Csv;
using DataExtractor.Core.FileReader.Csv.DataTemplates;

using Microsoft.Extensions.Logging;

using Moq;

namespace DataExtractor.Core.UnitTests.FileReader.Csv;

public class CsvFileReaderTests
{
	private Mock<ILogger<CsvFileReader>> logger;
	private Mock<IFileManager> fileManager;

	[SetUp]
	public void Setup()
	{
		logger = new Mock<ILogger<CsvFileReader>>();
		fileManager = new Mock<IFileManager>();
	}

	[Test]
	public void ReadFile_WhenInputFileExistsWithTradeTemplateContent_ReturnDataTableWithItsTradeTemplateContent()
	{
		var fakeFileContents = @"TimeZone=UTC,,,"
		                       + System.Environment.NewLine
		                       + @"TEST_BOOLEAN_COLUMN_1,TEST_STRING_COLUMN_2,TEST_INT_COLUMN_3,TEST_DOUBLE_COLUMN_4,TEST_COMPLEX_CONTRACT_SIZE_COLUMN_5"
		                       + System.Environment.NewLine
		                       + @"FALSE, string_value, 1, 10.5,field1:value1|;field2:value1|;PriceMultiplier:20.0|;field4:value1|"
		                       + System.Environment.NewLine;

		var fakeFileBytes = Encoding.UTF8.GetBytes(fakeFileContents);

		using var fakeMemoryStream = new MemoryStream(fakeFileBytes);

		using var fakeStreamReader = new StreamReader(fakeMemoryStream);

		var fakeCsvReader = new CsvReader(fakeStreamReader, CultureInfo.InvariantCulture);

		var stubDataTemplate = new StubDataTemplate();

		fileManager.Setup(fileManager => fileManager.StreamReader(It.IsAny<string>()))
			.Returns(() => fakeStreamReader);

		fileManager.Setup(fileManager => fileManager.CsvReader(fakeStreamReader, CultureInfo.InvariantCulture))
			.Returns(() => fakeCsvReader);

		var csvFileReader = new CsvFileReader(logger.Object, fileManager.Object, stubDataTemplate);


		var dataTable = csvFileReader.ReadFile("input_1.csv");

		Assert.That(dataTable.Rows.Count, Is.EqualTo(1));
		Assert.That(dataTable.Rows[0].ItemArray[0], Is.EqualTo("string_value"));
		Assert.That(dataTable.Rows[0].ItemArray[1], Is.EqualTo(20));
	}
}
