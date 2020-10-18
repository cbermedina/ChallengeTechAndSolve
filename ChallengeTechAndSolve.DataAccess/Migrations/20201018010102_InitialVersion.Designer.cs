﻿// <auto-generated />
using System;
using ChallengeTechAndSolve.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ChallengeTechAndSolve.DataAccess.Migrations
{
    [DbContext(typeof(ChallengeTechAndSolveDBContext))]
    [Migration("20201018010102_InitialVersion")]
    partial class InitialVersion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ChallengeTechAndSolve.DataAccess.Contracts.Entities.TraceabilityEntity", b =>
                {
                    b.Property<Guid>("TraceabilityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Document")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TraceabilityId");

                    b.ToTable("Traceability");
                });
#pragma warning restore 612, 618
        }
    }
}
