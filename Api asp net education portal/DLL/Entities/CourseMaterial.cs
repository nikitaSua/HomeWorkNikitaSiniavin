﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class CourseMaterial :IEntity
    {
        public int Id { get; set; }
        public int? CourseId { get; set; }
        public Course Course { get; set; }
        public int? MaterialId { get; set; }
        public Material Material { get; set; }
    }
}
