﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudHomeWork.Models;

public  class Techaer
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }

    public string Subject { get; set; }

    public int Likes { get; set; }

    public int DisLikes { get; set; }

    public string Gender { get; set; }
}