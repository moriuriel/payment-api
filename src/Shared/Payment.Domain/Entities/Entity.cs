﻿namespace Payment.Domain.Entities;
public class Entity
{
    public Guid Id { get; }
    protected Entity(Guid id)
        => Id = id;
    
}


