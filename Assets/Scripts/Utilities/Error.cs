using System;

public class Error : Exception
{
    public Error(string message = "Undefined Error") : base(message) { }

    public static Error Number(byte min = 1, byte max = 9)
    => new($"Restricted number not between {min} and {max}");

    public static Error Enum<T>(T value) where T : Enum
    => new($"Unsupported member {value} for enum {typeof(T)}");
}

public record Player(int J, int B);