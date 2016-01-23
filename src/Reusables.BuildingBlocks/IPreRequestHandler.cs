﻿namespace Reusables.BuildingBlocks
{
    public interface IPreRequestHandler<in TRequest>
    {
        void Handle(TRequest request);
    }
}
