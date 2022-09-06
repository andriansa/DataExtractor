// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataProcessorTests.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the DataProcessorTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Data;

using DataExtractor.Core.Exceptions;
using DataExtractor.Core.FileReader;
using DataExtractor.Core.FileWriter;

using Microsoft.Extensions.Logging;

using Moq;

namespace DataExtractor.Core.UnitTests;

public class DataProcessorTests
{
	private DataProcessor dataProcessor;

	private Mock<ILogger<DataProcessor>> logger;
	private Mock<IFileManager> fileManager;
	private Mock<IFileReader> fileReader;
	private Mock<IFileWriter> fileWriter;

	[SetUp]
	public void Setup()
	{
		logger = new Mock<ILogger<DataProcessor>>();
		fileManager = new Mock<IFileManager>();
		fileReader = new Mock<IFileReader>();
		fileWriter = new Mock<IFileWriter>();

		dataProcessor = new DataProcessor(logger.Object, fileManager.Object, fileReader.Object, fileWriter.Object);
	}

	[Test]
	public void ExtractData_WhenInputFilePathNotSpecified_ReturnInputFilePathMissingException()
	{
		Assert.That(() => dataProcessor.ExtractData(null, "output_1.csv"), Throws.TypeOf<InputFilePathMissingException>()
			.With.Message.EqualTo("Input value missing for extracting data"));
	}

	[Test]
	public void ExtractData_WhenOutputFilePathNotSpecified_ReturnOutputFilePathMissingException()
	{
		Assert.That(() => dataProcessor.ExtractData("input_1.csv", null), Throws.TypeOf<OutputFilePathMissingException>()
			.With.Message.EqualTo("Output value missing for extracting data"));
	}

	[Test]
	public void ExtractData_WhenInputFilePathAndOutputFilePathNotSpecified_ReturnInputFilePathMissingException()
	{
		Assert.That(() => dataProcessor.ExtractData(null, "output_1.csv"), Throws.TypeOf<InputFilePathMissingException>()
			.With.Message.EqualTo("Input value missing for extracting data"));
	}

	[Test]
	public void ExtractData_WhenInputFileNotExists_ReturnInputFileMissingException()
	{
		fileManager.Setup(fileManager => fileManager.Exists("input_missing_1.csv"))
			.Returns(() => false);

		Assert.That(() => dataProcessor.ExtractData("input_missing_1.csv", "output_1.csv"), Throws.TypeOf<InputFileMissingException>()
			.With.Message.EqualTo("Input file does not exist"));
	}

	[Test]
	public void ExtractData_WhenInputAndOutputFilePathSpecified_WriteToFile()
	{
		var fakeDataTable = new DataTable();

		fileReader.Setup(x => x.ReadFile("input_1.csv"))
			.Returns(fakeDataTable);

		fileWriter.Setup(x => x.WriteToFile("output_1.csv", fakeDataTable));

		fileManager.Setup(fileManager => fileManager.Exists("input_1.csv"))
			.Returns(() => true);

		dataProcessor.ExtractData("input_1.csv", "output_1.csv");

		fileWriter.Verify(s => s.WriteToFile("output_1.csv", fakeDataTable));
	}
}
