namespace FlexPro.Client.Domain.Models;

public class BlazorDownloadFileStream
{
    public BlazorDownloadFileStream(byte[] fileBytes)
    {
        FileBytes = fileBytes;
    }

    public byte[] FileBytes { get; }
}