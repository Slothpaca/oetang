﻿namespace Oetang.API.Domain
{
    public class Consultant
    {

        // Define all properties.
        public long Id { get; set; }
        public User User { get; set; }
        public ConsultantStatus Status { get; set; }
        public string Function { get; set; }
        public Department Department { get; set; }
    }
}
