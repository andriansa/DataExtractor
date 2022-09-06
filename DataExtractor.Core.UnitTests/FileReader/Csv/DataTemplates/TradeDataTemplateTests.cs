// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TradeDataTemplateTests.cs" name="Andrian Sarapuu">
//   This work is licensed under the terms of the MIT license.  
//	 For a copy, see <https://opensource.org/licenses/MIT>.
// </copyright>
// <summary>
//   Defines the TradeDataTemplateTests type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Globalization;
using System.Text;

using CsvHelper;

using DataExtractor.Core.FileReader.Csv.DataTemplates;

using Microsoft.Extensions.Logging;

using Moq;

namespace DataExtractor.Core.UnitTests.FileReader.Csv.DataTemplates;

public class TradeDataTemplateTests
{
	private TradeDataTemplate tradeDataTemplate;

	private Mock<ILogger<TradeDataTemplate>> logger;

	[SetUp]
	public void Setup()
	{
		logger = new Mock<ILogger<TradeDataTemplate>>();

		tradeDataTemplate = new TradeDataTemplate(logger.Object);
	}

	[Test]
	public void BuildDataTable_WhenCalled_ReturnTradeDataTableShouldHaveFourColumns()
	{
		var tradeDataTable = tradeDataTemplate.BuildDataTable();

		Assert.That(tradeDataTable.Columns.Count, Is.EqualTo(4));
	}

	[Test]
	public void ParseRow_WhenCalled_ReturnRowWhereAllTradeTemplateFieldsInitializedFromTheSampleTradeContent()
	{
		var fakeFileContents = @"TimeZone=UTC,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,"
		                       + System.Environment.NewLine
		                       + @"IsMultiFill,ISIN,Currency,Venue,OrderRef,PMID,CFICode,ParticipantCode,TraderID,CounterPartyCode,DecisionTime,ArrivalTime_QuoteTime,FirstFillTime_TradeTime,LastFillTime,Price,Quantity,Side,TradeFlag,SettlementDate,PublicTradeID,UserDefinedFilter,TradingNetworkID,SettlementPeriod,MarketOrderId,ParticipationRate,BenchmarkVenues,BenchmarkType,FlowType,BasketID,MessageType,ParentOrderRef,ExecutionType,LimitPrice,Urgency,AlgoName,AlgoParams,Index,Sector"
		                       + System.Environment.NewLine
		                       + @"FALSE, DE000ABCDEFG, EUR, XEUR,1,Bob1,FFICSX,ABCDEFGHIJKL,,DMA,,,00:23:22,,1239.5,1,B,,,,,BigBank,,,,,,Y,,F,100000011,1,,,,InstIdentCode: DE000ABCDEFG |; InstFullName: DAX |; InstClassification: FFICSX |; NotionalCurr: EUR |; PriceMultiplier: 20.0 |; UnderlInstCode: DE0001234567 |; UnderlIndexName: DAX PERFORMANCE-INDEX |; OptionType: OTHR |; StrikePrice: 0.0 |; OptionExerciseStyle:|; ExpiryDate: 2021 - 01 - 01 |; DeliveryType: PHYS |,G,1"
		                       + System.Environment.NewLine;

		var fakeFileBytes = Encoding.UTF8.GetBytes(fakeFileContents);

		var fakeMemoryStream = new MemoryStream(fakeFileBytes);

		var fakeStreamReader = new StreamReader(fakeMemoryStream);

		var fakeCsvReader = new CsvReader(fakeStreamReader, CultureInfo.InvariantCulture);

		// input file structure requires skipping first 2 lines to get to the real data
		fakeCsvReader.Read();
		fakeCsvReader.Read();
		fakeCsvReader.ReadHeader();
		fakeCsvReader.Read();

		var tradeDataTable = tradeDataTemplate.BuildDataTable();

		var dataRow = tradeDataTemplate.ParseRow(fakeCsvReader, tradeDataTable.NewRow());

		Assert.That(dataRow.ItemArray[0], Is.EqualTo("DE000ABCDEFG"));
		Assert.That(dataRow.ItemArray[1], Is.EqualTo("FFICSX"));
		Assert.That(dataRow.ItemArray[2], Is.EqualTo("XEUR"));
		Assert.That(dataRow.ItemArray[3], Is.EqualTo(20));
	}
}

