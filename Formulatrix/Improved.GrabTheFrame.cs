using System.Runtime.InteropServices;

namespace Formulatrix;

public class ImprovedGrabTheFrame
{
    
    
}

public class FrameGrabber : IFrameCallback
{
    private byte[] _buffer;
    public delegate void FrameUpdateHandler(Frame rawFrame);
    public event FrameUpdateHandler OnFrameUpdated;

    public void FrameReceived(IntPtr frame, int width, int height)
    {
        if (_buffer == null || _buffer.Length != width * height)
        {
            _buffer = new byte[width * height];
        }

        try
        {
            Marshal.Copy(frame, _buffer, 0, width * height);
            Frame bufferedFrame = new Frame(_buffer);
            OnFrameUpdated?.Invoke(bufferedFrame);
            bufferedFrame.Dispose();
        }
        catch (Exception ex)
        {
            // Log the exception or handle it as appropriate
            Console.WriteLine($"Failed to process frame: {ex.Message}");
        }
    }
}

public class Frame
{
    public Frame(byte[] buffer)
    {
        throw new NotImplementedException();
    }
}

public interface IFrameCallback
{ 
    void FrameReceived( IntPtr pFrame, int pixelWidth, int pixelHeight );
}
public interface IValueReporter
{ 
    void Report( double value );
}