using BenchmarkDotNet.Attributes;

namespace ImageProcessor;

[InProcess()]
[MemoryDiagnoser]
[MinColumn, MaxColumn, AllStatisticsColumn]
[GcServer(true)]
public class ImageProcessorBenchmarks
{
    [Params(1024, 2048, 5012, 10240)]
    public int ChunkSize { get; set; }

    private static readonly ImageProcessor Processor = new();
    private readonly string ImagePath = Path.Combine(Environment.CurrentDirectory, "chunk.png");

    [Benchmark]
    public void ProcessUsingSpan()
    {
        Processor.ProcessImageSpan(ImagePath, ChunkSize);
    }

    [Benchmark]
    public void ProcessUsingChunk()
    {
        Processor.ProcessImageChunk(ImagePath, ChunkSize);
    }

    [Benchmark]
    public void ProcessUsingSkipAndTake()
    {
        Processor.ProcessImageSkipAndTake(ImagePath, ChunkSize);
    }
}