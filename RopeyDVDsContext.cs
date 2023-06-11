#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RopeyDVDs.Models;

namespace RopeyDVDs.Data
{
    //this class provides all the db set properties needed to manage the identtity tables in the data store
    public class RopeyDVDsContext : IdentityDbContext
    {

        public DbSet<Actor> Actors { get; set; }
        public DbSet<CastMember> CastMembers { get; set; }
        public DbSet<DVDCategory> DVDCategorys { get; set; }
        public DbSet<DVDCopy> DVDCopys { get; set; }
        public DbSet<DVDTitle> DVDTitles { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanType> LoanTypes { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MembershipCategory> MembershipCategorys { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Studio> Studios { get; set; }
        public DbSet<User> Users { get; set; }

        public RopeyDVDsContext (DbContextOptions<RopeyDVDsContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
 }
}
