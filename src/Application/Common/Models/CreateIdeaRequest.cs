﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayApp.Application.Common.Models;
public class CreateIdeaRequest
{
    public string Content { get; set; }
    public int AuthorId { get; set; }
}
