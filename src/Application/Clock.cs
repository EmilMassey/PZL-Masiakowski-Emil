namespace TaskFlow.Application;

public class Clock: IClock
{
    public DateTime Now() => DateTime.Now;
}