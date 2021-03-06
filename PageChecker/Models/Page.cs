﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PageCheckerAPI.Models
{
    public enum CheckingTypeEnum
    {
        Full,
        Text,
        Element
    }

    public enum RefreshRateEnum
    {
        FifteenMinutes = 15,
        HalfHour = 30,
        Hour = 60,
        ThreeHours = 180,
        HalfDay = 720,
        Day = 1440
    }

    public class Page
    {
        public Page()
        {
            HasChanged = false;
            Stopped = false;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PageId { get; set; }
        public string Name { get; set; }
        public RefreshRateEnum RefreshRate { get; set; }
        public bool HasChanged { get; set; }
        public bool Stopped { get; set; }
        public CheckingTypeEnum CheckingType { get; set; }
        public string ElementXPath { get; set; }
        public DateTime CreationDate { get; set; }
        public bool HighAccuracy { get; set; }

        [ForeignKey("WebsiteText")]
        public Guid PrimaryTextId { get; set; }
        public WebsiteText PrimaryText { get; set; }

        [Required]
        public string Url { get; set; }

        [Required]
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
