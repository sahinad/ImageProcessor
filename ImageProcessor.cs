namespace ImageProcessor;

public class ImageProcessor
{
    public void ProcessImageSpan(string filePath, int chunkSize)
    {
        byte[] imageData = File.ReadAllBytes(filePath);
        Span<byte> span = imageData;

        for (int i = 0; i < span.Length; i += chunkSize)
        {
            Span<byte> chunk = span.Slice(i, Math.Min(chunkSize, span.Length - i));

            // Do something with the chunk
            Console.WriteLine($"Processing chunk of {chunk.Length} bytes");
        }

        Console.WriteLine("Image processing complete");
    }

    public void ProcessImageSkipAndTake(string filePath, int chunkSize)
    {
        byte[] imageData = File.ReadAllBytes(filePath);
        int chunks = (imageData.Length / chunkSize) + (imageData.Length % chunkSize > 0 ? 1 : 0);

        for (int i = 0; i < chunks; i++)
        {
            IEnumerable<byte> chunk = imageData.Skip(i * chunkSize).Take(chunkSize);

            // Do something with the chunk
            Console.WriteLine($"Processing chunk of {chunk.Count()} bytes");
        }

        Console.WriteLine("Image processing complete");
    }

    public void ProcessImageChunk(string filePath, int chunkSize)
    {
        byte[] imageData = File.ReadAllBytes(filePath);

        foreach (byte[] chunk in imageData.Chunk(chunkSize))
        {
            // Do something with the chunk
            Console.WriteLine($"Processing chunk of {chunk.Length} bytes");
        }

        Console.WriteLine("Image processing complete");
    }
}