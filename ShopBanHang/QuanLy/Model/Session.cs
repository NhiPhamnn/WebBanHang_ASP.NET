﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLy.Model
{
    public class Session
    {
        public int id { get; set; }
        public int role { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string token { get; set; }
    }
}
