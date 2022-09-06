// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DataProcessor.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the DataProcessor type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using DataExtractor.Core.FileReader;
using DataExtractor.Core.FileWriter;
using DataExtractor.Core.Exceptions;

using Microsoft.Extensions.Logging;

namespace DataExtractor.Core;

public sealed class DataProcessor
{
	private readonly ILogger<DataProcessor> logger;
	private readonly IFileManager fileManager;
	private readonly IFileReader fileReader;
	private readonly IFileWriter fileWriter;

	public DataProcessor(ILogger<DataProcessor> logger, IFileManager fileManager, IFileReader fileReader, IFileWriter fileWriter)
	{
		this.logger = logger;
		this.fileManager = fileManager;
		this.fileReader = fileReader;
		this.fileWriter = fileWriter;
	}

	public void ExtractData(string inputFile, string outputFile)
	{
		logger.LogInformation("ExtractData called");

		if (string.IsNullOrEmpty(inputFile))
		{
			logger.LogError("Input value missing for extracting data");

			throw new InputFilePathMissingException("Input value missing for extracting data");
		}

		if (string.IsNullOrEmpty(outputFile))
		{
			logger.LogError("Output value missing for extracting data");

			throw new OutputFilePathMissingException("Output value missing for extracting data");
		}

		if (!fileManager.Exists(inputFile))
		{
			logger.LogError("Input file does not exist");

			throw new InputFileMissingException("Input file does not exist");
		}

		var content = fileReader.ReadFile(inputFile);
		fileWriter.WriteToFile(outputFile, content);
	}
}

