﻿namespace CompleteApiSample.Dtos
{
    public abstract class BaseDto
    {
        public long Id { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
