using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModOrientacion.Models;

namespace ModOrientacion.Data
{
    public class ModOrientacionContext:DbContext
    {
        public ModOrientacionContext(DbContextOptions<ModOrientacionContext> options) : base(options) { }
        public DbSet<Adulto> Adultos { get; set; }   
        public DbSet<FichaOri> Fichas { get; set; }   
    }
}