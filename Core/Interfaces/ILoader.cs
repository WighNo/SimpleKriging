﻿namespace Core.Interfaces
{
    public interface ILoader<out T>
    {
        T Load();
    }
}