using System;

public interface IExecutorLastAction
{
    Action ExecutableBeforeDestroyed { set; }
}