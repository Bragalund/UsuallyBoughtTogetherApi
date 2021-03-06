﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UsuallyBoughtTogetherApi;

namespace UsuallyBoughtTogetherApi.Migrations
{
    [DbContext(typeof(PredictionContext))]
    partial class PredictionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1");

            modelBuilder.Entity("UsuallyBoughtTogetherApi.Entities.ProductEntryEntity", b =>
                {
                    b.Property<Guid>("ProductEntryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("CoPurchaseProductId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductEntryId");

                    b.ToTable("ProductEntryEntities");
                });
#pragma warning restore 612, 618
        }
    }
}
