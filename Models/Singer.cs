using System;
using System.Collections.Generic;

namespace API_SQLServer.Models;

public partial class Singer
{
    public int Singerid { get; set; }

    public string? NameSinger { get; set; }

    public string? Photo { get; set; }
}
