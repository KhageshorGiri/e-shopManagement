﻿using System.ComponentModel.DataAnnotations;

namespace CMgt.Domain.Entities;
public class User
{
    [Key]
    public int Id { get; set; }
    public string UserName { get; set; }
}
