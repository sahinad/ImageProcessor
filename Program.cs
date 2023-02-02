using BenchmarkDotNet.Running;
using ImageProcessor;

BenchmarkDotNet.Reports.Summary summary = BenchmarkRunner.Run<ImageProcessorBenchmarks>();