﻿using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Table;

namespace Azure.Web.Models
{

    public class Courses
    {
        public string CourseName { get; set; }
        public double Fees { get; set; }
    }

    public class StudentEntity : TableEntity
    {
        public StudentEntity()
        {

        }

        public StudentEntity(string partitionKey, string rowKey) : base(partitionKey, rowKey)
        {

        }

        public string Std { get; set; }
        public int RollNo { get; set; }
        public string Name { get; set; }
        public List<Courses> Courses { get; set; }

    }
}