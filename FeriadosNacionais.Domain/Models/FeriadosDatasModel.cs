﻿using FeriadosNacionais.Domain.Enums;

namespace FeriadosNacionais.Domain.Models
{
    public class FeriadosDatasModel
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Legislation { get; set; }
        public string Type { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
    }
}
