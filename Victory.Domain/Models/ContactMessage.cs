﻿namespace Victory.Domain.Models;

public class ContactMessage : IDomainModel
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Mail { get; set; }
    public string Phone { get; set; }
    public string Message { get; set; }
}